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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.MetadataWithContent" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class MetadataWithContentTest : AbstractBaseSetupTypedTest<MetadataWithContent>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (MetadataWithContent) Initializer

        private const string Propertycontent = "content";
        private const string FieldcontentField = "contentField";
        private Type _metadataWithContentInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private MetadataWithContent _metadataWithContentInstance;
        private MetadataWithContent _metadataWithContentInstanceFixture;

        #region General Initializer : Class (MetadataWithContent) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="MetadataWithContent" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _metadataWithContentInstanceType = typeof(MetadataWithContent);
            _metadataWithContentInstanceFixture = Create(true);
            _metadataWithContentInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (MetadataWithContent)

        #region General Initializer : Class (MetadataWithContent) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="MetadataWithContent" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertycontent)]
        public void AUT_MetadataWithContent_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_metadataWithContentInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (MetadataWithContent) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="MetadataWithContent" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcontentField)]
        public void AUT_MetadataWithContent_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_metadataWithContentInstanceFixture, 
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
        ///     Class (<see cref="MetadataWithContent" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_MetadataWithContent_Is_Instance_Present_Test()
        {
            // Assert
            _metadataWithContentInstanceType.ShouldNotBeNull();
            _metadataWithContentInstance.ShouldNotBeNull();
            _metadataWithContentInstanceFixture.ShouldNotBeNull();
            _metadataWithContentInstance.ShouldBeAssignableTo<MetadataWithContent>();
            _metadataWithContentInstanceFixture.ShouldBeAssignableTo<MetadataWithContent>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (MetadataWithContent) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_MetadataWithContent_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            MetadataWithContent instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _metadataWithContentInstanceType.ShouldNotBeNull();
            _metadataWithContentInstance.ShouldNotBeNull();
            _metadataWithContentInstanceFixture.ShouldNotBeNull();
            _metadataWithContentInstance.ShouldBeAssignableTo<MetadataWithContent>();
            _metadataWithContentInstanceFixture.ShouldBeAssignableTo<MetadataWithContent>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (MetadataWithContent) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(byte[]) , Propertycontent)]
        public void AUT_MetadataWithContent_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<MetadataWithContent, T>(_metadataWithContentInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (MetadataWithContent) => Property (content) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MetadataWithContent_content_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertycontent);
            Action currentAction = () => propertyInfo.SetValue(_metadataWithContentInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MetadataWithContent) => Property (content) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MetadataWithContent_Public_Class_content_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycontent);

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