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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.PermissionSetExternalDataSourceAccess" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PermissionSetExternalDataSourceAccessTest : AbstractBaseSetupTypedTest<PermissionSetExternalDataSourceAccess>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PermissionSetExternalDataSourceAccess) Initializer

        private const string Propertyenabled = "enabled";
        private const string PropertyexternalDataSource = "externalDataSource";
        private const string FieldenabledField = "enabledField";
        private const string FieldexternalDataSourceField = "externalDataSourceField";
        private Type _permissionSetExternalDataSourceAccessInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PermissionSetExternalDataSourceAccess _permissionSetExternalDataSourceAccessInstance;
        private PermissionSetExternalDataSourceAccess _permissionSetExternalDataSourceAccessInstanceFixture;

        #region General Initializer : Class (PermissionSetExternalDataSourceAccess) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PermissionSetExternalDataSourceAccess" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _permissionSetExternalDataSourceAccessInstanceType = typeof(PermissionSetExternalDataSourceAccess);
            _permissionSetExternalDataSourceAccessInstanceFixture = Create(true);
            _permissionSetExternalDataSourceAccessInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PermissionSetExternalDataSourceAccess)

        #region General Initializer : Class (PermissionSetExternalDataSourceAccess) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PermissionSetExternalDataSourceAccess" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyenabled)]
        [TestCase(PropertyexternalDataSource)]
        public void AUT_PermissionSetExternalDataSourceAccess_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_permissionSetExternalDataSourceAccessInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PermissionSetExternalDataSourceAccess) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PermissionSetExternalDataSourceAccess" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldenabledField)]
        [TestCase(FieldexternalDataSourceField)]
        public void AUT_PermissionSetExternalDataSourceAccess_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_permissionSetExternalDataSourceAccessInstanceFixture, 
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
        ///     Class (<see cref="PermissionSetExternalDataSourceAccess" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_PermissionSetExternalDataSourceAccess_Is_Instance_Present_Test()
        {
            // Assert
            _permissionSetExternalDataSourceAccessInstanceType.ShouldNotBeNull();
            _permissionSetExternalDataSourceAccessInstance.ShouldNotBeNull();
            _permissionSetExternalDataSourceAccessInstanceFixture.ShouldNotBeNull();
            _permissionSetExternalDataSourceAccessInstance.ShouldBeAssignableTo<PermissionSetExternalDataSourceAccess>();
            _permissionSetExternalDataSourceAccessInstanceFixture.ShouldBeAssignableTo<PermissionSetExternalDataSourceAccess>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PermissionSetExternalDataSourceAccess) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_PermissionSetExternalDataSourceAccess_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PermissionSetExternalDataSourceAccess instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _permissionSetExternalDataSourceAccessInstanceType.ShouldNotBeNull();
            _permissionSetExternalDataSourceAccessInstance.ShouldNotBeNull();
            _permissionSetExternalDataSourceAccessInstanceFixture.ShouldNotBeNull();
            _permissionSetExternalDataSourceAccessInstance.ShouldBeAssignableTo<PermissionSetExternalDataSourceAccess>();
            _permissionSetExternalDataSourceAccessInstanceFixture.ShouldBeAssignableTo<PermissionSetExternalDataSourceAccess>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PermissionSetExternalDataSourceAccess) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , Propertyenabled)]
        [TestCaseGeneric(typeof(string) , PropertyexternalDataSource)]
        public void AUT_PermissionSetExternalDataSourceAccess_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<PermissionSetExternalDataSourceAccess, T>(_permissionSetExternalDataSourceAccessInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSetExternalDataSourceAccess) => Property (enabled) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSetExternalDataSourceAccess_Public_Class_enabled_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyenabled);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSetExternalDataSourceAccess) => Property (externalDataSource) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSetExternalDataSourceAccess_Public_Class_externalDataSource_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyexternalDataSource);

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