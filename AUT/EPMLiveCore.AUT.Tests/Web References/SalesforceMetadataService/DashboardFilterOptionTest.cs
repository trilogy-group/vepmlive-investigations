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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.DashboardFilterOption" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DashboardFilterOptionTest : AbstractBaseSetupTypedTest<DashboardFilterOption>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DashboardFilterOption) Initializer
        
        private const string Propertyvalues = "values";
        private const string FieldoperatorField = "operatorField";
        private const string FieldvaluesField = "valuesField";
        private Type _dashboardFilterOptionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DashboardFilterOption _dashboardFilterOptionInstance;
        private DashboardFilterOption _dashboardFilterOptionInstanceFixture;

        #region General Initializer : Class (DashboardFilterOption) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DashboardFilterOption" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dashboardFilterOptionInstanceType = typeof(DashboardFilterOption);
            _dashboardFilterOptionInstanceFixture = Create(true);
            _dashboardFilterOptionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DashboardFilterOption)

        #region General Initializer : Class (DashboardFilterOption) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DashboardFilterOption" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyvalues)]
        public void AUT_DashboardFilterOption_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_dashboardFilterOptionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DashboardFilterOption) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DashboardFilterOption" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldoperatorField)]
        [TestCase(FieldvaluesField)]
        public void AUT_DashboardFilterOption_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_dashboardFilterOptionInstanceFixture, 
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
        ///     Class (<see cref="DashboardFilterOption" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DashboardFilterOption_Is_Instance_Present_Test()
        {
            // Assert
            _dashboardFilterOptionInstanceType.ShouldNotBeNull();
            _dashboardFilterOptionInstance.ShouldNotBeNull();
            _dashboardFilterOptionInstanceFixture.ShouldNotBeNull();
            _dashboardFilterOptionInstance.ShouldBeAssignableTo<DashboardFilterOption>();
            _dashboardFilterOptionInstanceFixture.ShouldBeAssignableTo<DashboardFilterOption>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DashboardFilterOption) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DashboardFilterOption_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DashboardFilterOption instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dashboardFilterOptionInstanceType.ShouldNotBeNull();
            _dashboardFilterOptionInstance.ShouldNotBeNull();
            _dashboardFilterOptionInstanceFixture.ShouldNotBeNull();
            _dashboardFilterOptionInstance.ShouldBeAssignableTo<DashboardFilterOption>();
            _dashboardFilterOptionInstanceFixture.ShouldBeAssignableTo<DashboardFilterOption>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DashboardFilterOption) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string[]) , Propertyvalues)]
        public void AUT_DashboardFilterOption_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DashboardFilterOption, T>(_dashboardFilterOptionInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (DashboardFilterOption) => Property (values) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardFilterOption_values_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyvalues);
            Action currentAction = () => propertyInfo.SetValue(_dashboardFilterOptionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DashboardFilterOption) => Property (values) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardFilterOption_Public_Class_values_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyvalues);

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