using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.SalesforceApexService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceApexService.DisableFeedTrackingHeader" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceApexService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DisableFeedTrackingHeaderTest : AbstractBaseSetupTypedTest<DisableFeedTrackingHeader>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DisableFeedTrackingHeader) Initializer

        private const string PropertydisableFeedTracking = "disableFeedTracking";
        private const string FielddisableFeedTrackingField = "disableFeedTrackingField";
        private Type _disableFeedTrackingHeaderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DisableFeedTrackingHeader _disableFeedTrackingHeaderInstance;
        private DisableFeedTrackingHeader _disableFeedTrackingHeaderInstanceFixture;

        #region General Initializer : Class (DisableFeedTrackingHeader) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DisableFeedTrackingHeader" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _disableFeedTrackingHeaderInstanceType = typeof(DisableFeedTrackingHeader);
            _disableFeedTrackingHeaderInstanceFixture = Create(true);
            _disableFeedTrackingHeaderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DisableFeedTrackingHeader)

        #region General Initializer : Class (DisableFeedTrackingHeader) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DisableFeedTrackingHeader" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertydisableFeedTracking)]
        public void AUT_DisableFeedTrackingHeader_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_disableFeedTrackingHeaderInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DisableFeedTrackingHeader) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DisableFeedTrackingHeader" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddisableFeedTrackingField)]
        public void AUT_DisableFeedTrackingHeader_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_disableFeedTrackingHeaderInstanceFixture, 
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
        ///     Class (<see cref="DisableFeedTrackingHeader" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DisableFeedTrackingHeader_Is_Instance_Present_Test()
        {
            // Assert
            _disableFeedTrackingHeaderInstanceType.ShouldNotBeNull();
            _disableFeedTrackingHeaderInstance.ShouldNotBeNull();
            _disableFeedTrackingHeaderInstanceFixture.ShouldNotBeNull();
            _disableFeedTrackingHeaderInstance.ShouldBeAssignableTo<DisableFeedTrackingHeader>();
            _disableFeedTrackingHeaderInstanceFixture.ShouldBeAssignableTo<DisableFeedTrackingHeader>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DisableFeedTrackingHeader) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DisableFeedTrackingHeader_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DisableFeedTrackingHeader instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _disableFeedTrackingHeaderInstanceType.ShouldNotBeNull();
            _disableFeedTrackingHeaderInstance.ShouldNotBeNull();
            _disableFeedTrackingHeaderInstanceFixture.ShouldNotBeNull();
            _disableFeedTrackingHeaderInstance.ShouldBeAssignableTo<DisableFeedTrackingHeader>();
            _disableFeedTrackingHeaderInstanceFixture.ShouldBeAssignableTo<DisableFeedTrackingHeader>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DisableFeedTrackingHeader) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertydisableFeedTracking)]
        public void AUT_DisableFeedTrackingHeader_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DisableFeedTrackingHeader, T>(_disableFeedTrackingHeaderInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DisableFeedTrackingHeader) => Property (disableFeedTracking) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DisableFeedTrackingHeader_Public_Class_disableFeedTracking_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydisableFeedTracking);

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