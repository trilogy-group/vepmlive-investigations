using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveCore.SSRS2010;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Jobs.SSRS
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.SSRS.SubscriptionProperties" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.SSRS"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SubscriptionPropertiesTest : AbstractBaseSetupTypedTest<SubscriptionProperties>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SubscriptionProperties) Initializer

        private const string PropertyReportParams = "ReportParams";
        private const string PropertyMatchData = "MatchData";
        private Type _subscriptionPropertiesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SubscriptionProperties _subscriptionPropertiesInstance;
        private SubscriptionProperties _subscriptionPropertiesInstanceFixture;

        #region General Initializer : Class (SubscriptionProperties) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SubscriptionProperties" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _subscriptionPropertiesInstanceType = typeof(SubscriptionProperties);
            _subscriptionPropertiesInstanceFixture = Create(true);
            _subscriptionPropertiesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SubscriptionProperties)

        #region General Initializer : Class (SubscriptionProperties) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SubscriptionProperties" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyReportParams)]
        [TestCase(PropertyMatchData)]
        public void AUT_SubscriptionProperties_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_subscriptionPropertiesInstanceFixture,
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
        ///     Class (<see cref="SubscriptionProperties" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_SubscriptionProperties_Is_Instance_Present_Test()
        {
            // Assert
            _subscriptionPropertiesInstanceType.ShouldNotBeNull();
            _subscriptionPropertiesInstance.ShouldNotBeNull();
            _subscriptionPropertiesInstanceFixture.ShouldNotBeNull();
            _subscriptionPropertiesInstance.ShouldBeAssignableTo<SubscriptionProperties>();
            _subscriptionPropertiesInstanceFixture.ShouldBeAssignableTo<SubscriptionProperties>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SubscriptionProperties) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_SubscriptionProperties_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SubscriptionProperties instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _subscriptionPropertiesInstanceType.ShouldNotBeNull();
            _subscriptionPropertiesInstance.ShouldNotBeNull();
            _subscriptionPropertiesInstanceFixture.ShouldNotBeNull();
            _subscriptionPropertiesInstance.ShouldBeAssignableTo<SubscriptionProperties>();
            _subscriptionPropertiesInstanceFixture.ShouldBeAssignableTo<SubscriptionProperties>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SubscriptionProperties) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ParameterValue[]) , PropertyReportParams)]
        [TestCaseGeneric(typeof(string) , PropertyMatchData)]
        public void AUT_SubscriptionProperties_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SubscriptionProperties, T>(_subscriptionPropertiesInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SubscriptionProperties) => Property (MatchData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SubscriptionProperties_Public_Class_MatchData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyMatchData);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SubscriptionProperties) => Property (ReportParams) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SubscriptionProperties_ReportParams_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyReportParams);
            Action currentAction = () => propertyInfo.SetValue(_subscriptionPropertiesInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SubscriptionProperties) => Property (ReportParams) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SubscriptionProperties_Public_Class_ReportParams_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyReportParams);

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