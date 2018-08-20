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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.DescribeMetadataObject" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DescribeMetadataObjectTest : AbstractBaseSetupTypedTest<DescribeMetadataObject>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DescribeMetadataObject) Initializer

        private const string PropertychildXmlNames = "childXmlNames";
        private const string PropertydirectoryName = "directoryName";
        private const string PropertyinFolder = "inFolder";
        private const string PropertymetaFile = "metaFile";
        private const string Propertysuffix = "suffix";
        private const string PropertyxmlName = "xmlName";
        private const string FieldchildXmlNamesField = "childXmlNamesField";
        private const string FielddirectoryNameField = "directoryNameField";
        private const string FieldinFolderField = "inFolderField";
        private const string FieldmetaFileField = "metaFileField";
        private const string FieldsuffixField = "suffixField";
        private const string FieldxmlNameField = "xmlNameField";
        private Type _describeMetadataObjectInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DescribeMetadataObject _describeMetadataObjectInstance;
        private DescribeMetadataObject _describeMetadataObjectInstanceFixture;

        #region General Initializer : Class (DescribeMetadataObject) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DescribeMetadataObject" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _describeMetadataObjectInstanceType = typeof(DescribeMetadataObject);
            _describeMetadataObjectInstanceFixture = Create(true);
            _describeMetadataObjectInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DescribeMetadataObject)

        #region General Initializer : Class (DescribeMetadataObject) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeMetadataObject" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertychildXmlNames)]
        [TestCase(PropertydirectoryName)]
        [TestCase(PropertyinFolder)]
        [TestCase(PropertymetaFile)]
        [TestCase(Propertysuffix)]
        [TestCase(PropertyxmlName)]
        public void AUT_DescribeMetadataObject_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_describeMetadataObjectInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DescribeMetadataObject) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeMetadataObject" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldchildXmlNamesField)]
        [TestCase(FielddirectoryNameField)]
        [TestCase(FieldinFolderField)]
        [TestCase(FieldmetaFileField)]
        [TestCase(FieldsuffixField)]
        [TestCase(FieldxmlNameField)]
        public void AUT_DescribeMetadataObject_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_describeMetadataObjectInstanceFixture, 
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
        ///     Class (<see cref="DescribeMetadataObject" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DescribeMetadataObject_Is_Instance_Present_Test()
        {
            // Assert
            _describeMetadataObjectInstanceType.ShouldNotBeNull();
            _describeMetadataObjectInstance.ShouldNotBeNull();
            _describeMetadataObjectInstanceFixture.ShouldNotBeNull();
            _describeMetadataObjectInstance.ShouldBeAssignableTo<DescribeMetadataObject>();
            _describeMetadataObjectInstanceFixture.ShouldBeAssignableTo<DescribeMetadataObject>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DescribeMetadataObject) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DescribeMetadataObject_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DescribeMetadataObject instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _describeMetadataObjectInstanceType.ShouldNotBeNull();
            _describeMetadataObjectInstance.ShouldNotBeNull();
            _describeMetadataObjectInstanceFixture.ShouldNotBeNull();
            _describeMetadataObjectInstance.ShouldBeAssignableTo<DescribeMetadataObject>();
            _describeMetadataObjectInstanceFixture.ShouldBeAssignableTo<DescribeMetadataObject>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DescribeMetadataObject) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string[]) , PropertychildXmlNames)]
        [TestCaseGeneric(typeof(string) , PropertydirectoryName)]
        [TestCaseGeneric(typeof(bool) , PropertyinFolder)]
        [TestCaseGeneric(typeof(bool) , PropertymetaFile)]
        [TestCaseGeneric(typeof(string) , Propertysuffix)]
        [TestCaseGeneric(typeof(string) , PropertyxmlName)]
        public void AUT_DescribeMetadataObject_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DescribeMetadataObject, T>(_describeMetadataObjectInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeMetadataObject) => Property (childXmlNames) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeMetadataObject_childXmlNames_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertychildXmlNames);
            Action currentAction = () => propertyInfo.SetValue(_describeMetadataObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeMetadataObject) => Property (childXmlNames) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeMetadataObject_Public_Class_childXmlNames_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertychildXmlNames);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeMetadataObject) => Property (directoryName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeMetadataObject_Public_Class_directoryName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydirectoryName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeMetadataObject) => Property (inFolder) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeMetadataObject_Public_Class_inFolder_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyinFolder);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeMetadataObject) => Property (metaFile) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeMetadataObject_Public_Class_metaFile_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymetaFile);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeMetadataObject) => Property (suffix) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeMetadataObject_Public_Class_suffix_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysuffix);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeMetadataObject) => Property (xmlName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeMetadataObject_Public_Class_xmlName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyxmlName);

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