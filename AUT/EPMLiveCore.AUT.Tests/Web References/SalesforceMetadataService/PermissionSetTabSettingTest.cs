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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.PermissionSetTabSetting" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PermissionSetTabSettingTest : AbstractBaseSetupTypedTest<PermissionSetTabSetting>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PermissionSetTabSetting) Initializer

        private const string Propertytab = "tab";
        private const string Propertyvisibility = "visibility";
        private const string FieldtabField = "tabField";
        private const string FieldvisibilityField = "visibilityField";
        private Type _permissionSetTabSettingInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PermissionSetTabSetting _permissionSetTabSettingInstance;
        private PermissionSetTabSetting _permissionSetTabSettingInstanceFixture;

        #region General Initializer : Class (PermissionSetTabSetting) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PermissionSetTabSetting" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _permissionSetTabSettingInstanceType = typeof(PermissionSetTabSetting);
            _permissionSetTabSettingInstanceFixture = Create(true);
            _permissionSetTabSettingInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PermissionSetTabSetting)

        #region General Initializer : Class (PermissionSetTabSetting) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PermissionSetTabSetting" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertytab)]
        [TestCase(Propertyvisibility)]
        public void AUT_PermissionSetTabSetting_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_permissionSetTabSettingInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PermissionSetTabSetting) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PermissionSetTabSetting" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldtabField)]
        [TestCase(FieldvisibilityField)]
        public void AUT_PermissionSetTabSetting_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_permissionSetTabSettingInstanceFixture, 
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
        ///     Class (<see cref="PermissionSetTabSetting" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_PermissionSetTabSetting_Is_Instance_Present_Test()
        {
            // Assert
            _permissionSetTabSettingInstanceType.ShouldNotBeNull();
            _permissionSetTabSettingInstance.ShouldNotBeNull();
            _permissionSetTabSettingInstanceFixture.ShouldNotBeNull();
            _permissionSetTabSettingInstance.ShouldBeAssignableTo<PermissionSetTabSetting>();
            _permissionSetTabSettingInstanceFixture.ShouldBeAssignableTo<PermissionSetTabSetting>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PermissionSetTabSetting) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_PermissionSetTabSetting_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PermissionSetTabSetting instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _permissionSetTabSettingInstanceType.ShouldNotBeNull();
            _permissionSetTabSettingInstance.ShouldNotBeNull();
            _permissionSetTabSettingInstanceFixture.ShouldNotBeNull();
            _permissionSetTabSettingInstance.ShouldBeAssignableTo<PermissionSetTabSetting>();
            _permissionSetTabSettingInstanceFixture.ShouldBeAssignableTo<PermissionSetTabSetting>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PermissionSetTabSetting) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertytab)]
        [TestCaseGeneric(typeof(PermissionSetTabVisibility) , Propertyvisibility)]
        public void AUT_PermissionSetTabSetting_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<PermissionSetTabSetting, T>(_permissionSetTabSettingInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSetTabSetting) => Property (tab) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSetTabSetting_Public_Class_tab_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytab);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSetTabSetting) => Property (visibility) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSetTabSetting_visibility_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyvisibility);
            Action currentAction = () => propertyInfo.SetValue(_permissionSetTabSettingInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSetTabSetting) => Property (visibility) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSetTabSetting_Public_Class_visibility_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyvisibility);

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