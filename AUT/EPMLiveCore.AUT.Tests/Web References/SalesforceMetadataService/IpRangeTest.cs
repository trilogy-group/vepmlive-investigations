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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.IpRange" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class IpRangeTest : AbstractBaseSetupTypedTest<IpRange>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (IpRange) Initializer

        private const string Propertyend = "end";
        private const string Propertystart = "start";
        private const string FieldendField = "endField";
        private const string FieldstartField = "startField";
        private Type _ipRangeInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private IpRange _ipRangeInstance;
        private IpRange _ipRangeInstanceFixture;

        #region General Initializer : Class (IpRange) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="IpRange" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ipRangeInstanceType = typeof(IpRange);
            _ipRangeInstanceFixture = Create(true);
            _ipRangeInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (IpRange)

        #region General Initializer : Class (IpRange) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="IpRange" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyend)]
        [TestCase(Propertystart)]
        public void AUT_IpRange_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_ipRangeInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (IpRange) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="IpRange" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldendField)]
        [TestCase(FieldstartField)]
        public void AUT_IpRange_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_ipRangeInstanceFixture, 
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
        ///     Class (<see cref="IpRange" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_IpRange_Is_Instance_Present_Test()
        {
            // Assert
            _ipRangeInstanceType.ShouldNotBeNull();
            _ipRangeInstance.ShouldNotBeNull();
            _ipRangeInstanceFixture.ShouldNotBeNull();
            _ipRangeInstance.ShouldBeAssignableTo<IpRange>();
            _ipRangeInstanceFixture.ShouldBeAssignableTo<IpRange>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (IpRange) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_IpRange_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            IpRange instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _ipRangeInstanceType.ShouldNotBeNull();
            _ipRangeInstance.ShouldNotBeNull();
            _ipRangeInstanceFixture.ShouldNotBeNull();
            _ipRangeInstance.ShouldBeAssignableTo<IpRange>();
            _ipRangeInstanceFixture.ShouldBeAssignableTo<IpRange>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (IpRange) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyend)]
        [TestCaseGeneric(typeof(string) , Propertystart)]
        public void AUT_IpRange_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<IpRange, T>(_ipRangeInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (IpRange) => Property (end) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_IpRange_Public_Class_end_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyend);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (IpRange) => Property (start) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_IpRange_Public_Class_start_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertystart);

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