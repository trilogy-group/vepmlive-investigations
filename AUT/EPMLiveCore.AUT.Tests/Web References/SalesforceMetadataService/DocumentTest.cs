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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.Document" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DocumentTest : AbstractBaseSetupTypedTest<Document>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Document) Initializer

        private const string Propertydescription = "description";
        private const string PropertyinternalUseOnly = "internalUseOnly";
        private const string Propertykeywords = "keywords";
        private const string Propertyname = "name";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldinternalUseOnlyField = "internalUseOnlyField";
        private const string FieldkeywordsField = "keywordsField";
        private const string FieldnameField = "nameField";
        private const string FieldpublicField = "publicField";
        private Type _documentInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Document _documentInstance;
        private Document _documentInstanceFixture;

        #region General Initializer : Class (Document) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Document" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _documentInstanceType = typeof(Document);
            _documentInstanceFixture = Create(true);
            _documentInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Document)

        #region General Initializer : Class (Document) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Document" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertydescription)]
        [TestCase(PropertyinternalUseOnly)]
        [TestCase(Propertykeywords)]
        [TestCase(Propertyname)]
        public void AUT_Document_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_documentInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Document) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Document" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldinternalUseOnlyField)]
        [TestCase(FieldkeywordsField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldpublicField)]
        public void AUT_Document_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_documentInstanceFixture, 
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
        ///     Class (<see cref="Document" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Document_Is_Instance_Present_Test()
        {
            // Assert
            _documentInstanceType.ShouldNotBeNull();
            _documentInstance.ShouldNotBeNull();
            _documentInstanceFixture.ShouldNotBeNull();
            _documentInstance.ShouldBeAssignableTo<Document>();
            _documentInstanceFixture.ShouldBeAssignableTo<Document>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Document) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Document_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Document instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _documentInstanceType.ShouldNotBeNull();
            _documentInstance.ShouldNotBeNull();
            _documentInstanceFixture.ShouldNotBeNull();
            _documentInstance.ShouldBeAssignableTo<Document>();
            _documentInstanceFixture.ShouldBeAssignableTo<Document>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Document) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(bool) , PropertyinternalUseOnly)]
        [TestCaseGeneric(typeof(string) , Propertykeywords)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_Document_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Document, T>(_documentInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (Document) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Document_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Document) => Property (internalUseOnly) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Document_Public_Class_internalUseOnly_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyinternalUseOnly);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Document) => Property (keywords) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Document_Public_Class_keywords_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertykeywords);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Document) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Document_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}