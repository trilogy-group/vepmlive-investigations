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

namespace EPMLiveWebParts.ReportFiltering.DomainModel
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ReportFiltering.DomainModel.ReportFilterSearchCriteria" />)
    ///     and namespace <see cref="EPMLiveWebParts.ReportFiltering.DomainModel"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ReportFilterSearchCriteriaTest : AbstractBaseSetupTypedTest<ReportFilterSearchCriteria>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportFilterSearchCriteria) Initializer

        private const string PropertyWebPartId = "WebPartId";
        private const string PropertyUserId = "UserId";
        private const string PropertySiteId = "SiteId";
        private const string PropertyWebId = "WebId";
        private Type _reportFilterSearchCriteriaInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportFilterSearchCriteria _reportFilterSearchCriteriaInstance;
        private ReportFilterSearchCriteria _reportFilterSearchCriteriaInstanceFixture;

        #region General Initializer : Class (ReportFilterSearchCriteria) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportFilterSearchCriteria" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportFilterSearchCriteriaInstanceType = typeof(ReportFilterSearchCriteria);
            _reportFilterSearchCriteriaInstanceFixture = Create(true);
            _reportFilterSearchCriteriaInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportFilterSearchCriteria)

        #region General Initializer : Class (ReportFilterSearchCriteria) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportFilterSearchCriteria" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyWebPartId)]
        [TestCase(PropertyUserId)]
        [TestCase(PropertySiteId)]
        [TestCase(PropertyWebId)]
        public void AUT_ReportFilterSearchCriteria_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportFilterSearchCriteriaInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ReportFilterSearchCriteria" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ReportFilterSearchCriteria_Is_Instance_Present_Test()
        {
            // Assert
            _reportFilterSearchCriteriaInstanceType.ShouldNotBeNull();
            _reportFilterSearchCriteriaInstance.ShouldNotBeNull();
            _reportFilterSearchCriteriaInstanceFixture.ShouldNotBeNull();
            _reportFilterSearchCriteriaInstance.ShouldBeAssignableTo<ReportFilterSearchCriteria>();
            _reportFilterSearchCriteriaInstanceFixture.ShouldBeAssignableTo<ReportFilterSearchCriteria>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportFilterSearchCriteria) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ReportFilterSearchCriteria_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportFilterSearchCriteria instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportFilterSearchCriteriaInstanceType.ShouldNotBeNull();
            _reportFilterSearchCriteriaInstance.ShouldNotBeNull();
            _reportFilterSearchCriteriaInstanceFixture.ShouldNotBeNull();
            _reportFilterSearchCriteriaInstance.ShouldBeAssignableTo<ReportFilterSearchCriteria>();
            _reportFilterSearchCriteriaInstanceFixture.ShouldBeAssignableTo<ReportFilterSearchCriteria>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportFilterSearchCriteria) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(Guid?) , PropertyWebPartId)]
        [TestCaseGeneric(typeof(string) , PropertyUserId)]
        [TestCaseGeneric(typeof(Guid?) , PropertySiteId)]
        [TestCaseGeneric(typeof(Guid?) , PropertyWebId)]
        public void AUT_ReportFilterSearchCriteria_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportFilterSearchCriteria, T>(_reportFilterSearchCriteriaInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSearchCriteria) => Property (SiteId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSearchCriteria_SiteId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertySiteId);
            Action currentAction = () => propertyInfo.SetValue(_reportFilterSearchCriteriaInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSearchCriteria) => Property (SiteId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSearchCriteria_Public_Class_SiteId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySiteId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSearchCriteria) => Property (UserId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSearchCriteria_Public_Class_UserId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUserId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSearchCriteria) => Property (WebId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSearchCriteria_WebId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyWebId);
            Action currentAction = () => propertyInfo.SetValue(_reportFilterSearchCriteriaInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSearchCriteria) => Property (WebId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSearchCriteria_Public_Class_WebId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWebId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSearchCriteria) => Property (WebPartId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSearchCriteria_WebPartId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyWebPartId);
            Action currentAction = () => propertyInfo.SetValue(_reportFilterSearchCriteriaInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSearchCriteria) => Property (WebPartId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSearchCriteria_Public_Class_WebPartId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWebPartId);

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