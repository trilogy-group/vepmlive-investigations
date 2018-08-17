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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.DashboardComponentSection" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DashboardComponentSectionTest : AbstractBaseSetupTypedTest<DashboardComponentSection>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DashboardComponentSection) Initializer

        private const string PropertycolumnSize = "columnSize";
        private const string Propertycomponents = "components";
        private const string FieldcolumnSizeField = "columnSizeField";
        private const string FieldcomponentsField = "componentsField";
        private Type _dashboardComponentSectionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DashboardComponentSection _dashboardComponentSectionInstance;
        private DashboardComponentSection _dashboardComponentSectionInstanceFixture;

        #region General Initializer : Class (DashboardComponentSection) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DashboardComponentSection" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dashboardComponentSectionInstanceType = typeof(DashboardComponentSection);
            _dashboardComponentSectionInstanceFixture = Create(true);
            _dashboardComponentSectionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DashboardComponentSection)

        #region General Initializer : Class (DashboardComponentSection) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DashboardComponentSection" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycolumnSize)]
        [TestCase(Propertycomponents)]
        public void AUT_DashboardComponentSection_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_dashboardComponentSectionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DashboardComponentSection) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DashboardComponentSection" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcolumnSizeField)]
        [TestCase(FieldcomponentsField)]
        public void AUT_DashboardComponentSection_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_dashboardComponentSectionInstanceFixture, 
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
        ///     Class (<see cref="DashboardComponentSection" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DashboardComponentSection_Is_Instance_Present_Test()
        {
            // Assert
            _dashboardComponentSectionInstanceType.ShouldNotBeNull();
            _dashboardComponentSectionInstance.ShouldNotBeNull();
            _dashboardComponentSectionInstanceFixture.ShouldNotBeNull();
            _dashboardComponentSectionInstance.ShouldBeAssignableTo<DashboardComponentSection>();
            _dashboardComponentSectionInstanceFixture.ShouldBeAssignableTo<DashboardComponentSection>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DashboardComponentSection) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DashboardComponentSection_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DashboardComponentSection instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dashboardComponentSectionInstanceType.ShouldNotBeNull();
            _dashboardComponentSectionInstance.ShouldNotBeNull();
            _dashboardComponentSectionInstanceFixture.ShouldNotBeNull();
            _dashboardComponentSectionInstance.ShouldBeAssignableTo<DashboardComponentSection>();
            _dashboardComponentSectionInstanceFixture.ShouldBeAssignableTo<DashboardComponentSection>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DashboardComponentSection) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(DashboardComponentSize) , PropertycolumnSize)]
        [TestCaseGeneric(typeof(DashboardComponent[]) , Propertycomponents)]
        public void AUT_DashboardComponentSection_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DashboardComponentSection, T>(_dashboardComponentSectionInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponentSection) => Property (columnSize) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponentSection_columnSize_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycolumnSize);
            Action currentAction = () => propertyInfo.SetValue(_dashboardComponentSectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponentSection) => Property (columnSize) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponentSection_Public_Class_columnSize_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycolumnSize);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponentSection) => Property (components) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponentSection_components_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertycomponents);
            Action currentAction = () => propertyInfo.SetValue(_dashboardComponentSectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponentSection) => Property (components) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponentSection_Public_Class_components_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycomponents);

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