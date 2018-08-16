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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.Scontrol" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ScontrolTest : AbstractBaseSetupTypedTest<Scontrol>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Scontrol) Initializer

        private const string PropertycontentSource = "contentSource";
        private const string Propertydescription = "description";
        private const string PropertyencodingKey = "encodingKey";
        private const string PropertyfileContent = "fileContent";
        private const string PropertyfileName = "fileName";
        private const string Propertyname = "name";
        private const string PropertysupportsCaching = "supportsCaching";
        private const string FieldcontentSourceField = "contentSourceField";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldencodingKeyField = "encodingKeyField";
        private const string FieldfileContentField = "fileContentField";
        private const string FieldfileNameField = "fileNameField";
        private const string FieldnameField = "nameField";
        private const string FieldsupportsCachingField = "supportsCachingField";
        private Type _scontrolInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Scontrol _scontrolInstance;
        private Scontrol _scontrolInstanceFixture;

        #region General Initializer : Class (Scontrol) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Scontrol" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _scontrolInstanceType = typeof(Scontrol);
            _scontrolInstanceFixture = Create(true);
            _scontrolInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Scontrol)

        #region General Initializer : Class (Scontrol) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Scontrol" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycontentSource)]
        [TestCase(Propertydescription)]
        [TestCase(PropertyencodingKey)]
        [TestCase(PropertyfileContent)]
        [TestCase(PropertyfileName)]
        [TestCase(Propertyname)]
        [TestCase(PropertysupportsCaching)]
        public void AUT_Scontrol_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_scontrolInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Scontrol) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Scontrol" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcontentSourceField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldencodingKeyField)]
        [TestCase(FieldfileContentField)]
        [TestCase(FieldfileNameField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldsupportsCachingField)]
        public void AUT_Scontrol_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_scontrolInstanceFixture, 
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
        ///     Class (<see cref="Scontrol" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Scontrol_Is_Instance_Present_Test()
        {
            // Assert
            _scontrolInstanceType.ShouldNotBeNull();
            _scontrolInstance.ShouldNotBeNull();
            _scontrolInstanceFixture.ShouldNotBeNull();
            _scontrolInstance.ShouldBeAssignableTo<Scontrol>();
            _scontrolInstanceFixture.ShouldBeAssignableTo<Scontrol>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Scontrol) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Scontrol_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Scontrol instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _scontrolInstanceType.ShouldNotBeNull();
            _scontrolInstance.ShouldNotBeNull();
            _scontrolInstanceFixture.ShouldNotBeNull();
            _scontrolInstance.ShouldBeAssignableTo<Scontrol>();
            _scontrolInstanceFixture.ShouldBeAssignableTo<Scontrol>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Scontrol) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(SControlContentSource) , PropertycontentSource)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(Encoding) , PropertyencodingKey)]
        [TestCaseGeneric(typeof(byte[]) , PropertyfileContent)]
        [TestCaseGeneric(typeof(string) , PropertyfileName)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(bool) , PropertysupportsCaching)]
        public void AUT_Scontrol_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Scontrol, T>(_scontrolInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Scontrol) => Property (contentSource) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Scontrol_contentSource_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycontentSource);
            Action currentAction = () => propertyInfo.SetValue(_scontrolInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Scontrol) => Property (contentSource) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Scontrol_Public_Class_contentSource_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycontentSource);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Scontrol) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Scontrol_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Scontrol) => Property (encodingKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Scontrol_encodingKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyencodingKey);
            Action currentAction = () => propertyInfo.SetValue(_scontrolInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Scontrol) => Property (encodingKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Scontrol_Public_Class_encodingKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyencodingKey);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Scontrol) => Property (fileContent) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Scontrol_fileContent_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyfileContent);
            Action currentAction = () => propertyInfo.SetValue(_scontrolInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Scontrol) => Property (fileContent) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Scontrol_Public_Class_fileContent_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfileContent);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Scontrol) => Property (fileName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Scontrol_Public_Class_fileName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfileName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Scontrol) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Scontrol_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Scontrol) => Property (supportsCaching) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Scontrol_Public_Class_supportsCaching_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysupportsCaching);

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