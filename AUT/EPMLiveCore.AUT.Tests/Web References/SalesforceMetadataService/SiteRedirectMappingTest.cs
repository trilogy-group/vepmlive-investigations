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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.SiteRedirectMapping" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SiteRedirectMappingTest : AbstractBaseSetupTypedTest<SiteRedirectMapping>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SiteRedirectMapping) Initializer

        private const string Propertyaction = "action";
        private const string PropertyisActive = "isActive";
        private const string PropertyisActiveSpecified = "isActiveSpecified";
        private const string Propertysource = "source";
        private const string Propertytarget = "target";
        private const string FieldactionField = "actionField";
        private const string FieldisActiveField = "isActiveField";
        private const string FieldisActiveFieldSpecified = "isActiveFieldSpecified";
        private const string FieldsourceField = "sourceField";
        private const string FieldtargetField = "targetField";
        private Type _siteRedirectMappingInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SiteRedirectMapping _siteRedirectMappingInstance;
        private SiteRedirectMapping _siteRedirectMappingInstanceFixture;

        #region General Initializer : Class (SiteRedirectMapping) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SiteRedirectMapping" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _siteRedirectMappingInstanceType = typeof(SiteRedirectMapping);
            _siteRedirectMappingInstanceFixture = Create(true);
            _siteRedirectMappingInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SiteRedirectMapping)

        #region General Initializer : Class (SiteRedirectMapping) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SiteRedirectMapping" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyaction)]
        [TestCase(PropertyisActive)]
        [TestCase(PropertyisActiveSpecified)]
        [TestCase(Propertysource)]
        [TestCase(Propertytarget)]
        public void AUT_SiteRedirectMapping_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_siteRedirectMappingInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SiteRedirectMapping) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SiteRedirectMapping" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldactionField)]
        [TestCase(FieldisActiveField)]
        [TestCase(FieldisActiveFieldSpecified)]
        [TestCase(FieldsourceField)]
        [TestCase(FieldtargetField)]
        public void AUT_SiteRedirectMapping_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_siteRedirectMappingInstanceFixture, 
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
        ///     Class (<see cref="SiteRedirectMapping" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_SiteRedirectMapping_Is_Instance_Present_Test()
        {
            // Assert
            _siteRedirectMappingInstanceType.ShouldNotBeNull();
            _siteRedirectMappingInstance.ShouldNotBeNull();
            _siteRedirectMappingInstanceFixture.ShouldNotBeNull();
            _siteRedirectMappingInstance.ShouldBeAssignableTo<SiteRedirectMapping>();
            _siteRedirectMappingInstanceFixture.ShouldBeAssignableTo<SiteRedirectMapping>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SiteRedirectMapping) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_SiteRedirectMapping_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SiteRedirectMapping instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _siteRedirectMappingInstanceType.ShouldNotBeNull();
            _siteRedirectMappingInstance.ShouldNotBeNull();
            _siteRedirectMappingInstanceFixture.ShouldNotBeNull();
            _siteRedirectMappingInstance.ShouldBeAssignableTo<SiteRedirectMapping>();
            _siteRedirectMappingInstanceFixture.ShouldBeAssignableTo<SiteRedirectMapping>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SiteRedirectMapping) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(SiteRedirect) , Propertyaction)]
        [TestCaseGeneric(typeof(bool) , PropertyisActive)]
        [TestCaseGeneric(typeof(bool) , PropertyisActiveSpecified)]
        [TestCaseGeneric(typeof(string) , Propertysource)]
        [TestCaseGeneric(typeof(string) , Propertytarget)]
        public void AUT_SiteRedirectMapping_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SiteRedirectMapping, T>(_siteRedirectMappingInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SiteRedirectMapping) => Property (action) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SiteRedirectMapping_action_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyaction);
            Action currentAction = () => propertyInfo.SetValue(_siteRedirectMappingInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SiteRedirectMapping) => Property (action) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SiteRedirectMapping_Public_Class_action_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyaction);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SiteRedirectMapping) => Property (isActive) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SiteRedirectMapping_Public_Class_isActive_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisActive);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SiteRedirectMapping) => Property (isActiveSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SiteRedirectMapping_Public_Class_isActiveSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisActiveSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SiteRedirectMapping) => Property (source) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SiteRedirectMapping_Public_Class_source_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysource);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SiteRedirectMapping) => Property (target) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SiteRedirectMapping_Public_Class_target_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytarget);

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