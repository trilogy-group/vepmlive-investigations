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

namespace EPMLiveWebParts.SSRS2006
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2006.CatalogItem" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2006"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CatalogItemTest : AbstractBaseSetupTypedTest<CatalogItem>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CatalogItem) Initializer

        private const string PropertyID = "ID";
        private const string PropertyName = "Name";
        private const string PropertyPath = "Path";
        private const string PropertyVirtualPath = "VirtualPath";
        private const string PropertyType = "Type";
        private const string PropertySize = "Size";
        private const string PropertySizeSpecified = "SizeSpecified";
        private const string PropertyDescription = "Description";
        private const string PropertyHidden = "Hidden";
        private const string PropertyHiddenSpecified = "HiddenSpecified";
        private const string PropertyCreationDate = "CreationDate";
        private const string PropertyCreationDateSpecified = "CreationDateSpecified";
        private const string PropertyModifiedDate = "ModifiedDate";
        private const string PropertyModifiedDateSpecified = "ModifiedDateSpecified";
        private const string PropertyCreatedBy = "CreatedBy";
        private const string PropertyModifiedBy = "ModifiedBy";
        private const string PropertyMimeType = "MimeType";
        private const string PropertyExecutionDate = "ExecutionDate";
        private const string PropertyExecutionDateSpecified = "ExecutionDateSpecified";
        private const string FieldidField = "idField";
        private const string FieldnameField = "nameField";
        private const string FieldpathField = "pathField";
        private const string FieldvirtualPathField = "virtualPathField";
        private const string FieldtypeField = "typeField";
        private const string FieldsizeField = "sizeField";
        private const string FieldsizeFieldSpecified = "sizeFieldSpecified";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldhiddenField = "hiddenField";
        private const string FieldhiddenFieldSpecified = "hiddenFieldSpecified";
        private const string FieldcreationDateField = "creationDateField";
        private const string FieldcreationDateFieldSpecified = "creationDateFieldSpecified";
        private const string FieldmodifiedDateField = "modifiedDateField";
        private const string FieldmodifiedDateFieldSpecified = "modifiedDateFieldSpecified";
        private const string FieldcreatedByField = "createdByField";
        private const string FieldmodifiedByField = "modifiedByField";
        private const string FieldmimeTypeField = "mimeTypeField";
        private const string FieldexecutionDateField = "executionDateField";
        private const string FieldexecutionDateFieldSpecified = "executionDateFieldSpecified";
        private Type _catalogItemInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CatalogItem _catalogItemInstance;
        private CatalogItem _catalogItemInstanceFixture;

        #region General Initializer : Class (CatalogItem) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CatalogItem" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _catalogItemInstanceType = typeof(CatalogItem);
            _catalogItemInstanceFixture = Create(true);
            _catalogItemInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CatalogItem)

        #region General Initializer : Class (CatalogItem) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CatalogItem" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyID)]
        [TestCase(PropertyName)]
        [TestCase(PropertyPath)]
        [TestCase(PropertyVirtualPath)]
        [TestCase(PropertyType)]
        [TestCase(PropertySize)]
        [TestCase(PropertySizeSpecified)]
        [TestCase(PropertyDescription)]
        [TestCase(PropertyHidden)]
        [TestCase(PropertyHiddenSpecified)]
        [TestCase(PropertyCreationDate)]
        [TestCase(PropertyCreationDateSpecified)]
        [TestCase(PropertyModifiedDate)]
        [TestCase(PropertyModifiedDateSpecified)]
        [TestCase(PropertyCreatedBy)]
        [TestCase(PropertyModifiedBy)]
        [TestCase(PropertyMimeType)]
        [TestCase(PropertyExecutionDate)]
        [TestCase(PropertyExecutionDateSpecified)]
        public void AUT_CatalogItem_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_catalogItemInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CatalogItem) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CatalogItem" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldidField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldpathField)]
        [TestCase(FieldvirtualPathField)]
        [TestCase(FieldtypeField)]
        [TestCase(FieldsizeField)]
        [TestCase(FieldsizeFieldSpecified)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldhiddenField)]
        [TestCase(FieldhiddenFieldSpecified)]
        [TestCase(FieldcreationDateField)]
        [TestCase(FieldcreationDateFieldSpecified)]
        [TestCase(FieldmodifiedDateField)]
        [TestCase(FieldmodifiedDateFieldSpecified)]
        [TestCase(FieldcreatedByField)]
        [TestCase(FieldmodifiedByField)]
        [TestCase(FieldmimeTypeField)]
        [TestCase(FieldexecutionDateField)]
        [TestCase(FieldexecutionDateFieldSpecified)]
        public void AUT_CatalogItem_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_catalogItemInstanceFixture, 
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
        ///     Class (<see cref="CatalogItem" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CatalogItem_Is_Instance_Present_Test()
        {
            // Assert
            _catalogItemInstanceType.ShouldNotBeNull();
            _catalogItemInstance.ShouldNotBeNull();
            _catalogItemInstanceFixture.ShouldNotBeNull();
            _catalogItemInstance.ShouldBeAssignableTo<CatalogItem>();
            _catalogItemInstanceFixture.ShouldBeAssignableTo<CatalogItem>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CatalogItem) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CatalogItem_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CatalogItem instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _catalogItemInstanceType.ShouldNotBeNull();
            _catalogItemInstance.ShouldNotBeNull();
            _catalogItemInstanceFixture.ShouldNotBeNull();
            _catalogItemInstance.ShouldBeAssignableTo<CatalogItem>();
            _catalogItemInstanceFixture.ShouldBeAssignableTo<CatalogItem>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CatalogItem) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyID)]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(string) , PropertyPath)]
        [TestCaseGeneric(typeof(string) , PropertyVirtualPath)]
        [TestCaseGeneric(typeof(ItemTypeEnum) , PropertyType)]
        [TestCaseGeneric(typeof(int) , PropertySize)]
        [TestCaseGeneric(typeof(bool) , PropertySizeSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyDescription)]
        [TestCaseGeneric(typeof(bool) , PropertyHidden)]
        [TestCaseGeneric(typeof(bool) , PropertyHiddenSpecified)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyCreationDate)]
        [TestCaseGeneric(typeof(bool) , PropertyCreationDateSpecified)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyModifiedDate)]
        [TestCaseGeneric(typeof(bool) , PropertyModifiedDateSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyCreatedBy)]
        [TestCaseGeneric(typeof(string) , PropertyModifiedBy)]
        [TestCaseGeneric(typeof(string) , PropertyMimeType)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyExecutionDate)]
        [TestCaseGeneric(typeof(bool) , PropertyExecutionDateSpecified)]
        public void AUT_CatalogItem_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CatalogItem, T>(_catalogItemInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (CreatedBy) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_Public_Class_CreatedBy_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCreatedBy);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (CreationDate) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_CreationDate_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyCreationDate);
            Action currentAction = () => propertyInfo.SetValue(_catalogItemInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (CreationDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_Public_Class_CreationDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCreationDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (CreationDateSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_Public_Class_CreationDateSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCreationDateSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (Description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_Public_Class_Description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (ExecutionDate) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_ExecutionDate_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyExecutionDate);
            Action currentAction = () => propertyInfo.SetValue(_catalogItemInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (ExecutionDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_Public_Class_ExecutionDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyExecutionDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (ExecutionDateSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_Public_Class_ExecutionDateSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyExecutionDateSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (Hidden) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_Public_Class_Hidden_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyHidden);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (HiddenSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_Public_Class_HiddenSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyHiddenSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (ID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_Public_Class_ID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (MimeType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_Public_Class_MimeType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyMimeType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (ModifiedBy) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_Public_Class_ModifiedBy_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyModifiedBy);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (ModifiedDate) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_ModifiedDate_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyModifiedDate);
            Action currentAction = () => propertyInfo.SetValue(_catalogItemInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (ModifiedDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_Public_Class_ModifiedDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyModifiedDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (ModifiedDateSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_Public_Class_ModifiedDateSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyModifiedDateSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (Path) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_Public_Class_Path_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPath);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (Size) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_Public_Class_Size_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySize);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (SizeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_Public_Class_SizeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySizeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (Type) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_Type_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyType);
            Action currentAction = () => propertyInfo.SetValue(_catalogItemInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (Type) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_Public_Class_Type_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CatalogItem) => Property (VirtualPath) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CatalogItem_Public_Class_VirtualPath_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyVirtualPath);

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