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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.PermissionSetApexClassAccess" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PermissionSetApexClassAccessTest : AbstractBaseSetupTypedTest<PermissionSetApexClassAccess>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PermissionSetApexClassAccess) Initializer

        private const string PropertyapexClass = "apexClass";
        private const string Propertyenabled = "enabled";
        private const string FieldapexClassField = "apexClassField";
        private const string FieldenabledField = "enabledField";
        private Type _permissionSetApexClassAccessInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PermissionSetApexClassAccess _permissionSetApexClassAccessInstance;
        private PermissionSetApexClassAccess _permissionSetApexClassAccessInstanceFixture;

        #region General Initializer : Class (PermissionSetApexClassAccess) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PermissionSetApexClassAccess" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _permissionSetApexClassAccessInstanceType = typeof(PermissionSetApexClassAccess);
            _permissionSetApexClassAccessInstanceFixture = Create(true);
            _permissionSetApexClassAccessInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PermissionSetApexClassAccess)

        #region General Initializer : Class (PermissionSetApexClassAccess) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PermissionSetApexClassAccess" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyapexClass)]
        [TestCase(Propertyenabled)]
        public void AUT_PermissionSetApexClassAccess_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_permissionSetApexClassAccessInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PermissionSetApexClassAccess) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PermissionSetApexClassAccess" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldapexClassField)]
        [TestCase(FieldenabledField)]
        public void AUT_PermissionSetApexClassAccess_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_permissionSetApexClassAccessInstanceFixture, 
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
        ///     Class (<see cref="PermissionSetApexClassAccess" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_PermissionSetApexClassAccess_Is_Instance_Present_Test()
        {
            // Assert
            _permissionSetApexClassAccessInstanceType.ShouldNotBeNull();
            _permissionSetApexClassAccessInstance.ShouldNotBeNull();
            _permissionSetApexClassAccessInstanceFixture.ShouldNotBeNull();
            _permissionSetApexClassAccessInstance.ShouldBeAssignableTo<PermissionSetApexClassAccess>();
            _permissionSetApexClassAccessInstanceFixture.ShouldBeAssignableTo<PermissionSetApexClassAccess>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PermissionSetApexClassAccess) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_PermissionSetApexClassAccess_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PermissionSetApexClassAccess instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _permissionSetApexClassAccessInstanceType.ShouldNotBeNull();
            _permissionSetApexClassAccessInstance.ShouldNotBeNull();
            _permissionSetApexClassAccessInstanceFixture.ShouldNotBeNull();
            _permissionSetApexClassAccessInstance.ShouldBeAssignableTo<PermissionSetApexClassAccess>();
            _permissionSetApexClassAccessInstanceFixture.ShouldBeAssignableTo<PermissionSetApexClassAccess>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PermissionSetApexClassAccess) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyapexClass)]
        [TestCaseGeneric(typeof(bool) , Propertyenabled)]
        public void AUT_PermissionSetApexClassAccess_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<PermissionSetApexClassAccess, T>(_permissionSetApexClassAccessInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSetApexClassAccess) => Property (apexClass) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSetApexClassAccess_Public_Class_apexClass_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyapexClass);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSetApexClassAccess) => Property (enabled) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSetApexClassAccess_Public_Class_enabled_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}