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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FileProperties" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FilePropertiesTest : AbstractBaseSetupTypedTest<FileProperties>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FileProperties) Initializer

        private const string PropertycreatedById = "createdById";
        private const string PropertycreatedByName = "createdByName";
        private const string PropertycreatedDate = "createdDate";
        private const string PropertyfileName = "fileName";
        private const string PropertyfullName = "fullName";
        private const string Propertyid = "id";
        private const string PropertylastModifiedById = "lastModifiedById";
        private const string PropertylastModifiedByName = "lastModifiedByName";
        private const string PropertylastModifiedDate = "lastModifiedDate";
        private const string PropertymanageableState = "manageableState";
        private const string PropertymanageableStateSpecified = "manageableStateSpecified";
        private const string PropertynamespacePrefix = "namespacePrefix";
        private const string Propertytype = "type";
        private const string FieldcreatedByIdField = "createdByIdField";
        private const string FieldcreatedByNameField = "createdByNameField";
        private const string FieldcreatedDateField = "createdDateField";
        private const string FieldfileNameField = "fileNameField";
        private const string FieldfullNameField = "fullNameField";
        private const string FieldidField = "idField";
        private const string FieldlastModifiedByIdField = "lastModifiedByIdField";
        private const string FieldlastModifiedByNameField = "lastModifiedByNameField";
        private const string FieldlastModifiedDateField = "lastModifiedDateField";
        private const string FieldmanageableStateField = "manageableStateField";
        private const string FieldmanageableStateFieldSpecified = "manageableStateFieldSpecified";
        private const string FieldnamespacePrefixField = "namespacePrefixField";
        private const string FieldtypeField = "typeField";
        private Type _filePropertiesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FileProperties _filePropertiesInstance;
        private FileProperties _filePropertiesInstanceFixture;

        #region General Initializer : Class (FileProperties) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FileProperties" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _filePropertiesInstanceType = typeof(FileProperties);
            _filePropertiesInstanceFixture = Create(true);
            _filePropertiesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FileProperties)

        #region General Initializer : Class (FileProperties) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FileProperties" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycreatedById)]
        [TestCase(PropertycreatedByName)]
        [TestCase(PropertycreatedDate)]
        [TestCase(PropertyfileName)]
        [TestCase(PropertyfullName)]
        [TestCase(Propertyid)]
        [TestCase(PropertylastModifiedById)]
        [TestCase(PropertylastModifiedByName)]
        [TestCase(PropertylastModifiedDate)]
        [TestCase(PropertymanageableState)]
        [TestCase(PropertymanageableStateSpecified)]
        [TestCase(PropertynamespacePrefix)]
        [TestCase(Propertytype)]
        public void AUT_FileProperties_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_filePropertiesInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FileProperties) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FileProperties" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcreatedByIdField)]
        [TestCase(FieldcreatedByNameField)]
        [TestCase(FieldcreatedDateField)]
        [TestCase(FieldfileNameField)]
        [TestCase(FieldfullNameField)]
        [TestCase(FieldidField)]
        [TestCase(FieldlastModifiedByIdField)]
        [TestCase(FieldlastModifiedByNameField)]
        [TestCase(FieldlastModifiedDateField)]
        [TestCase(FieldmanageableStateField)]
        [TestCase(FieldmanageableStateFieldSpecified)]
        [TestCase(FieldnamespacePrefixField)]
        [TestCase(FieldtypeField)]
        public void AUT_FileProperties_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_filePropertiesInstanceFixture, 
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
        ///     Class (<see cref="FileProperties" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FileProperties_Is_Instance_Present_Test()
        {
            // Assert
            _filePropertiesInstanceType.ShouldNotBeNull();
            _filePropertiesInstance.ShouldNotBeNull();
            _filePropertiesInstanceFixture.ShouldNotBeNull();
            _filePropertiesInstance.ShouldBeAssignableTo<FileProperties>();
            _filePropertiesInstanceFixture.ShouldBeAssignableTo<FileProperties>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FileProperties) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FileProperties_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FileProperties instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _filePropertiesInstanceType.ShouldNotBeNull();
            _filePropertiesInstance.ShouldNotBeNull();
            _filePropertiesInstanceFixture.ShouldNotBeNull();
            _filePropertiesInstance.ShouldBeAssignableTo<FileProperties>();
            _filePropertiesInstanceFixture.ShouldBeAssignableTo<FileProperties>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FileProperties) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertycreatedById)]
        [TestCaseGeneric(typeof(string) , PropertycreatedByName)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertycreatedDate)]
        [TestCaseGeneric(typeof(string) , PropertyfileName)]
        [TestCaseGeneric(typeof(string) , PropertyfullName)]
        [TestCaseGeneric(typeof(string) , Propertyid)]
        [TestCaseGeneric(typeof(string) , PropertylastModifiedById)]
        [TestCaseGeneric(typeof(string) , PropertylastModifiedByName)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertylastModifiedDate)]
        [TestCaseGeneric(typeof(ManageableState) , PropertymanageableState)]
        [TestCaseGeneric(typeof(bool) , PropertymanageableStateSpecified)]
        [TestCaseGeneric(typeof(string) , PropertynamespacePrefix)]
        [TestCaseGeneric(typeof(string) , Propertytype)]
        public void AUT_FileProperties_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FileProperties, T>(_filePropertiesInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FileProperties) => Property (createdById) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FileProperties_Public_Class_createdById_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycreatedById);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FileProperties) => Property (createdByName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FileProperties_Public_Class_createdByName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycreatedByName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FileProperties) => Property (createdDate) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FileProperties_createdDate_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycreatedDate);
            Action currentAction = () => propertyInfo.SetValue(_filePropertiesInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FileProperties) => Property (createdDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FileProperties_Public_Class_createdDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycreatedDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FileProperties) => Property (fileName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FileProperties_Public_Class_fileName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FileProperties) => Property (fullName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FileProperties_Public_Class_fullName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfullName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FileProperties) => Property (id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FileProperties_Public_Class_id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyid);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FileProperties) => Property (lastModifiedById) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FileProperties_Public_Class_lastModifiedById_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylastModifiedById);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FileProperties) => Property (lastModifiedByName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FileProperties_Public_Class_lastModifiedByName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylastModifiedByName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FileProperties) => Property (lastModifiedDate) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FileProperties_lastModifiedDate_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertylastModifiedDate);
            Action currentAction = () => propertyInfo.SetValue(_filePropertiesInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FileProperties) => Property (lastModifiedDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FileProperties_Public_Class_lastModifiedDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylastModifiedDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FileProperties) => Property (manageableState) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FileProperties_manageableState_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertymanageableState);
            Action currentAction = () => propertyInfo.SetValue(_filePropertiesInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FileProperties) => Property (manageableState) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FileProperties_Public_Class_manageableState_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymanageableState);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FileProperties) => Property (manageableStateSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FileProperties_Public_Class_manageableStateSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymanageableStateSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FileProperties) => Property (namespacePrefix) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FileProperties_Public_Class_namespacePrefix_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynamespacePrefix);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FileProperties) => Property (type) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FileProperties_Public_Class_type_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytype);

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