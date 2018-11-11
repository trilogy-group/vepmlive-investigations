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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.Folder" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FolderTest : AbstractBaseSetupTypedTest<Folder>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Folder) Initializer

        private const string PropertyaccessType = "accessType";
        private const string PropertyaccessTypeSpecified = "accessTypeSpecified";
        private const string Propertyname = "name";
        private const string PropertypublicFolderAccess = "publicFolderAccess";
        private const string PropertypublicFolderAccessSpecified = "publicFolderAccessSpecified";
        private const string PropertysharedTo = "sharedTo";
        private const string FieldaccessTypeField = "accessTypeField";
        private const string FieldaccessTypeFieldSpecified = "accessTypeFieldSpecified";
        private const string FieldnameField = "nameField";
        private const string FieldpublicFolderAccessField = "publicFolderAccessField";
        private const string FieldpublicFolderAccessFieldSpecified = "publicFolderAccessFieldSpecified";
        private const string FieldsharedToField = "sharedToField";
        private Type _folderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Folder _folderInstance;
        private Folder _folderInstanceFixture;

        #region General Initializer : Class (Folder) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Folder" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _folderInstanceType = typeof(Folder);
            _folderInstanceFixture = Create(true);
            _folderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Folder)

        #region General Initializer : Class (Folder) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Folder" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyaccessType)]
        [TestCase(PropertyaccessTypeSpecified)]
        [TestCase(Propertyname)]
        [TestCase(PropertypublicFolderAccess)]
        [TestCase(PropertypublicFolderAccessSpecified)]
        [TestCase(PropertysharedTo)]
        public void AUT_Folder_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_folderInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Folder) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Folder" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldaccessTypeField)]
        [TestCase(FieldaccessTypeFieldSpecified)]
        [TestCase(FieldnameField)]
        [TestCase(FieldpublicFolderAccessField)]
        [TestCase(FieldpublicFolderAccessFieldSpecified)]
        [TestCase(FieldsharedToField)]
        public void AUT_Folder_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_folderInstanceFixture, 
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
        ///     Class (<see cref="Folder" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Folder_Is_Instance_Present_Test()
        {
            // Assert
            _folderInstanceType.ShouldNotBeNull();
            _folderInstance.ShouldNotBeNull();
            _folderInstanceFixture.ShouldNotBeNull();
            _folderInstance.ShouldBeAssignableTo<Folder>();
            _folderInstanceFixture.ShouldBeAssignableTo<Folder>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Folder) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Folder_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Folder instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _folderInstanceType.ShouldNotBeNull();
            _folderInstance.ShouldNotBeNull();
            _folderInstanceFixture.ShouldNotBeNull();
            _folderInstance.ShouldBeAssignableTo<Folder>();
            _folderInstanceFixture.ShouldBeAssignableTo<Folder>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Folder) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(FolderAccessTypes) , PropertyaccessType)]
        [TestCaseGeneric(typeof(bool) , PropertyaccessTypeSpecified)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(PublicFolderAccess) , PropertypublicFolderAccess)]
        [TestCaseGeneric(typeof(bool) , PropertypublicFolderAccessSpecified)]
        [TestCaseGeneric(typeof(SharedTo) , PropertysharedTo)]
        public void AUT_Folder_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Folder, T>(_folderInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Folder) => Property (accessType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Folder_accessType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyaccessType);
            Action currentAction = () => propertyInfo.SetValue(_folderInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Folder) => Property (accessType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Folder_Public_Class_accessType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyaccessType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Folder) => Property (accessTypeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Folder_Public_Class_accessTypeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyaccessTypeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Folder) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Folder_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Folder) => Property (publicFolderAccess) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Folder_publicFolderAccess_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertypublicFolderAccess);
            Action currentAction = () => propertyInfo.SetValue(_folderInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Folder) => Property (publicFolderAccess) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Folder_Public_Class_publicFolderAccess_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypublicFolderAccess);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Folder) => Property (publicFolderAccessSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Folder_Public_Class_publicFolderAccessSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypublicFolderAccessSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Folder) => Property (sharedTo) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Folder_sharedTo_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysharedTo);
            Action currentAction = () => propertyInfo.SetValue(_folderInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Folder) => Property (sharedTo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Folder_Public_Class_sharedTo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysharedTo);

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