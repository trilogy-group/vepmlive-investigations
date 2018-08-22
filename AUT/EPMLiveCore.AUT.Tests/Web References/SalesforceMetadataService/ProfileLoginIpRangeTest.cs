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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ProfileLoginIpRange" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ProfileLoginIpRangeTest : AbstractBaseSetupTypedTest<ProfileLoginIpRange>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ProfileLoginIpRange) Initializer

        private const string PropertyendAddress = "endAddress";
        private const string PropertystartAddress = "startAddress";
        private const string FieldendAddressField = "endAddressField";
        private const string FieldstartAddressField = "startAddressField";
        private Type _profileLoginIpRangeInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ProfileLoginIpRange _profileLoginIpRangeInstance;
        private ProfileLoginIpRange _profileLoginIpRangeInstanceFixture;

        #region General Initializer : Class (ProfileLoginIpRange) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ProfileLoginIpRange" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _profileLoginIpRangeInstanceType = typeof(ProfileLoginIpRange);
            _profileLoginIpRangeInstanceFixture = Create(true);
            _profileLoginIpRangeInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ProfileLoginIpRange)

        #region General Initializer : Class (ProfileLoginIpRange) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ProfileLoginIpRange" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyendAddress)]
        [TestCase(PropertystartAddress)]
        public void AUT_ProfileLoginIpRange_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_profileLoginIpRangeInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ProfileLoginIpRange) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ProfileLoginIpRange" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldendAddressField)]
        [TestCase(FieldstartAddressField)]
        public void AUT_ProfileLoginIpRange_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_profileLoginIpRangeInstanceFixture, 
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
        ///     Class (<see cref="ProfileLoginIpRange" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ProfileLoginIpRange_Is_Instance_Present_Test()
        {
            // Assert
            _profileLoginIpRangeInstanceType.ShouldNotBeNull();
            _profileLoginIpRangeInstance.ShouldNotBeNull();
            _profileLoginIpRangeInstanceFixture.ShouldNotBeNull();
            _profileLoginIpRangeInstance.ShouldBeAssignableTo<ProfileLoginIpRange>();
            _profileLoginIpRangeInstanceFixture.ShouldBeAssignableTo<ProfileLoginIpRange>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ProfileLoginIpRange) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ProfileLoginIpRange_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ProfileLoginIpRange instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _profileLoginIpRangeInstanceType.ShouldNotBeNull();
            _profileLoginIpRangeInstance.ShouldNotBeNull();
            _profileLoginIpRangeInstanceFixture.ShouldNotBeNull();
            _profileLoginIpRangeInstance.ShouldBeAssignableTo<ProfileLoginIpRange>();
            _profileLoginIpRangeInstanceFixture.ShouldBeAssignableTo<ProfileLoginIpRange>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ProfileLoginIpRange) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyendAddress)]
        [TestCaseGeneric(typeof(string) , PropertystartAddress)]
        public void AUT_ProfileLoginIpRange_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ProfileLoginIpRange, T>(_profileLoginIpRangeInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ProfileLoginIpRange) => Property (endAddress) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileLoginIpRange_Public_Class_endAddress_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyendAddress);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileLoginIpRange) => Property (startAddress) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileLoginIpRange_Public_Class_startAddress_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertystartAddress);

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