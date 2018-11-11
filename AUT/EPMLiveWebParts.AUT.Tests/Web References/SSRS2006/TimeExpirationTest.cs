using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveWebParts.SSRS2006
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2006.TimeExpiration" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2006"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class TimeExpirationTest : AbstractBaseSetupTypedTest<TimeExpiration>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (TimeExpiration) Initializer

        private const string PropertyMinutes = "Minutes";
        private const string FieldminutesField = "minutesField";
        private Type _timeExpirationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private TimeExpiration _timeExpirationInstance;
        private TimeExpiration _timeExpirationInstanceFixture;

        #region General Initializer : Class (TimeExpiration) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="TimeExpiration" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _timeExpirationInstanceType = typeof(TimeExpiration);
            _timeExpirationInstanceFixture = Create(true);
            _timeExpirationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (TimeExpiration)

        #region General Initializer : Class (TimeExpiration) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="TimeExpiration" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyMinutes)]
        public void AUT_TimeExpiration_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_timeExpirationInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (TimeExpiration) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="TimeExpiration" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldminutesField)]
        public void AUT_TimeExpiration_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_timeExpirationInstanceFixture, 
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
        ///     Class (<see cref="TimeExpiration" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_TimeExpiration_Is_Instance_Present_Test()
        {
            // Assert
            _timeExpirationInstanceType.ShouldNotBeNull();
            _timeExpirationInstance.ShouldNotBeNull();
            _timeExpirationInstanceFixture.ShouldNotBeNull();
            _timeExpirationInstance.ShouldBeAssignableTo<TimeExpiration>();
            _timeExpirationInstanceFixture.ShouldBeAssignableTo<TimeExpiration>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (TimeExpiration) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_TimeExpiration_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            TimeExpiration instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _timeExpirationInstanceType.ShouldNotBeNull();
            _timeExpirationInstance.ShouldNotBeNull();
            _timeExpirationInstanceFixture.ShouldNotBeNull();
            _timeExpirationInstance.ShouldBeAssignableTo<TimeExpiration>();
            _timeExpirationInstanceFixture.ShouldBeAssignableTo<TimeExpiration>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (TimeExpiration) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(int) , PropertyMinutes)]
        public void AUT_TimeExpiration_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<TimeExpiration, T>(_timeExpirationInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (TimeExpiration) => Property (Minutes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TimeExpiration_Public_Class_Minutes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyMinutes);

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