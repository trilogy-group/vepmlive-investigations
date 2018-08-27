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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.StaticResource" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class StaticResourceTest : AbstractBaseSetupTypedTest<StaticResource>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (StaticResource) Initializer

        private const string PropertycacheControl = "cacheControl";
        private const string PropertycontentType = "contentType";
        private const string Propertydescription = "description";
        private const string FieldcacheControlField = "cacheControlField";
        private const string FieldcontentTypeField = "contentTypeField";
        private const string FielddescriptionField = "descriptionField";
        private Type _staticResourceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private StaticResource _staticResourceInstance;
        private StaticResource _staticResourceInstanceFixture;

        #region General Initializer : Class (StaticResource) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="StaticResource" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _staticResourceInstanceType = typeof(StaticResource);
            _staticResourceInstanceFixture = Create(true);
            _staticResourceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (StaticResource)

        #region General Initializer : Class (StaticResource) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="StaticResource" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycacheControl)]
        [TestCase(PropertycontentType)]
        [TestCase(Propertydescription)]
        public void AUT_StaticResource_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_staticResourceInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (StaticResource) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="StaticResource" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcacheControlField)]
        [TestCase(FieldcontentTypeField)]
        [TestCase(FielddescriptionField)]
        public void AUT_StaticResource_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_staticResourceInstanceFixture, 
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
        ///     Class (<see cref="StaticResource" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_StaticResource_Is_Instance_Present_Test()
        {
            // Assert
            _staticResourceInstanceType.ShouldNotBeNull();
            _staticResourceInstance.ShouldNotBeNull();
            _staticResourceInstanceFixture.ShouldNotBeNull();
            _staticResourceInstance.ShouldBeAssignableTo<StaticResource>();
            _staticResourceInstanceFixture.ShouldBeAssignableTo<StaticResource>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (StaticResource) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_StaticResource_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            StaticResource instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _staticResourceInstanceType.ShouldNotBeNull();
            _staticResourceInstance.ShouldNotBeNull();
            _staticResourceInstanceFixture.ShouldNotBeNull();
            _staticResourceInstance.ShouldBeAssignableTo<StaticResource>();
            _staticResourceInstanceFixture.ShouldBeAssignableTo<StaticResource>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (StaticResource) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(StaticResourceCacheControl) , PropertycacheControl)]
        [TestCaseGeneric(typeof(string) , PropertycontentType)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        public void AUT_StaticResource_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<StaticResource, T>(_staticResourceInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (StaticResource) => Property (cacheControl) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_StaticResource_cacheControl_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycacheControl);
            Action currentAction = () => propertyInfo.SetValue(_staticResourceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (StaticResource) => Property (cacheControl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_StaticResource_Public_Class_cacheControl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycacheControl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (StaticResource) => Property (contentType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_StaticResource_Public_Class_contentType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycontentType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (StaticResource) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_StaticResource_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}