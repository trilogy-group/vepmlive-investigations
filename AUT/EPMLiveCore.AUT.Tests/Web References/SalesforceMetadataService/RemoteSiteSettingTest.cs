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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.RemoteSiteSetting" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RemoteSiteSettingTest : AbstractBaseSetupTypedTest<RemoteSiteSetting>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RemoteSiteSetting) Initializer

        private const string Propertydescription = "description";
        private const string PropertydisableProtocolSecurity = "disableProtocolSecurity";
        private const string PropertyisActive = "isActive";
        private const string Propertyurl = "url";
        private const string FielddescriptionField = "descriptionField";
        private const string FielddisableProtocolSecurityField = "disableProtocolSecurityField";
        private const string FieldisActiveField = "isActiveField";
        private const string FieldurlField = "urlField";
        private Type _remoteSiteSettingInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RemoteSiteSetting _remoteSiteSettingInstance;
        private RemoteSiteSetting _remoteSiteSettingInstanceFixture;

        #region General Initializer : Class (RemoteSiteSetting) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RemoteSiteSetting" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _remoteSiteSettingInstanceType = typeof(RemoteSiteSetting);
            _remoteSiteSettingInstanceFixture = Create(true);
            _remoteSiteSettingInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RemoteSiteSetting)

        #region General Initializer : Class (RemoteSiteSetting) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="RemoteSiteSetting" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertydescription)]
        [TestCase(PropertydisableProtocolSecurity)]
        [TestCase(PropertyisActive)]
        [TestCase(Propertyurl)]
        public void AUT_RemoteSiteSetting_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_remoteSiteSettingInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (RemoteSiteSetting) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RemoteSiteSetting" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddescriptionField)]
        [TestCase(FielddisableProtocolSecurityField)]
        [TestCase(FieldisActiveField)]
        [TestCase(FieldurlField)]
        public void AUT_RemoteSiteSetting_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_remoteSiteSettingInstanceFixture, 
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
        ///     Class (<see cref="RemoteSiteSetting" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_RemoteSiteSetting_Is_Instance_Present_Test()
        {
            // Assert
            _remoteSiteSettingInstanceType.ShouldNotBeNull();
            _remoteSiteSettingInstance.ShouldNotBeNull();
            _remoteSiteSettingInstanceFixture.ShouldNotBeNull();
            _remoteSiteSettingInstance.ShouldBeAssignableTo<RemoteSiteSetting>();
            _remoteSiteSettingInstanceFixture.ShouldBeAssignableTo<RemoteSiteSetting>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RemoteSiteSetting) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_RemoteSiteSetting_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RemoteSiteSetting instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _remoteSiteSettingInstanceType.ShouldNotBeNull();
            _remoteSiteSettingInstance.ShouldNotBeNull();
            _remoteSiteSettingInstanceFixture.ShouldNotBeNull();
            _remoteSiteSettingInstance.ShouldBeAssignableTo<RemoteSiteSetting>();
            _remoteSiteSettingInstanceFixture.ShouldBeAssignableTo<RemoteSiteSetting>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (RemoteSiteSetting) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(bool) , PropertydisableProtocolSecurity)]
        [TestCaseGeneric(typeof(bool) , PropertyisActive)]
        [TestCaseGeneric(typeof(string) , Propertyurl)]
        public void AUT_RemoteSiteSetting_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<RemoteSiteSetting, T>(_remoteSiteSettingInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (RemoteSiteSetting) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RemoteSiteSetting_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (RemoteSiteSetting) => Property (disableProtocolSecurity) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RemoteSiteSetting_Public_Class_disableProtocolSecurity_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydisableProtocolSecurity);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RemoteSiteSetting) => Property (isActive) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RemoteSiteSetting_Public_Class_isActive_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (RemoteSiteSetting) => Property (url) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RemoteSiteSetting_Public_Class_url_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyurl);

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