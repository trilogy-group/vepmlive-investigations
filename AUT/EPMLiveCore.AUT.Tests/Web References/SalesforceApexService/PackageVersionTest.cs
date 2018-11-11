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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceApexService.PackageVersion" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceApexService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PackageVersionTest : AbstractBaseSetupTypedTest<PackageVersion>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PackageVersion) Initializer

        private const string PropertymajorNumber = "majorNumber";
        private const string PropertyminorNumber = "minorNumber";
        private const string Propertyanamespace = "@namespace";
        private const string FieldmajorNumberField = "majorNumberField";
        private const string FieldminorNumberField = "minorNumberField";
        private const string FieldnamespaceField = "namespaceField";
        private Type _packageVersionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PackageVersion _packageVersionInstance;
        private PackageVersion _packageVersionInstanceFixture;

        #region General Initializer : Class (PackageVersion) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PackageVersion" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _packageVersionInstanceType = typeof(PackageVersion);
            _packageVersionInstanceFixture = Create(true);
            _packageVersionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PackageVersion)

        #region General Initializer : Class (PackageVersion) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PackageVersion" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertymajorNumber)]
        [TestCase(PropertyminorNumber)]
        public void AUT_PackageVersion_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_packageVersionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PackageVersion) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PackageVersion" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldmajorNumberField)]
        [TestCase(FieldminorNumberField)]
        [TestCase(FieldnamespaceField)]
        public void AUT_PackageVersion_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_packageVersionInstanceFixture, 
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
        ///     Class (<see cref="PackageVersion" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_PackageVersion_Is_Instance_Present_Test()
        {
            // Assert
            _packageVersionInstanceType.ShouldNotBeNull();
            _packageVersionInstance.ShouldNotBeNull();
            _packageVersionInstanceFixture.ShouldNotBeNull();
            _packageVersionInstance.ShouldBeAssignableTo<PackageVersion>();
            _packageVersionInstanceFixture.ShouldBeAssignableTo<PackageVersion>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PackageVersion) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_PackageVersion_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PackageVersion instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _packageVersionInstanceType.ShouldNotBeNull();
            _packageVersionInstance.ShouldNotBeNull();
            _packageVersionInstanceFixture.ShouldNotBeNull();
            _packageVersionInstance.ShouldBeAssignableTo<PackageVersion>();
            _packageVersionInstanceFixture.ShouldBeAssignableTo<PackageVersion>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PackageVersion) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(int) , PropertymajorNumber)]
        [TestCaseGeneric(typeof(int) , PropertyminorNumber)]
        public void AUT_PackageVersion_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<PackageVersion, T>(_packageVersionInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (PackageVersion) => Property (majorNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PackageVersion_Public_Class_majorNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymajorNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PackageVersion) => Property (minorNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PackageVersion_Public_Class_minorNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyminorNumber);

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