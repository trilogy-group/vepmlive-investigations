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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ProfileLoginHours" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ProfileLoginHoursTest : AbstractBaseSetupTypedTest<ProfileLoginHours>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ProfileLoginHours) Initializer

        private const string PropertyfridayEnd = "fridayEnd";
        private const string PropertyfridayStart = "fridayStart";
        private const string PropertymondayEnd = "mondayEnd";
        private const string PropertymondayStart = "mondayStart";
        private const string PropertysaturdayEnd = "saturdayEnd";
        private const string PropertysaturdayStart = "saturdayStart";
        private const string PropertysundayEnd = "sundayEnd";
        private const string PropertysundayStart = "sundayStart";
        private const string PropertythursdayEnd = "thursdayEnd";
        private const string PropertythursdayStart = "thursdayStart";
        private const string PropertytuesdayEnd = "tuesdayEnd";
        private const string PropertytuesdayStart = "tuesdayStart";
        private const string PropertywednesdayEnd = "wednesdayEnd";
        private const string PropertywednesdayStart = "wednesdayStart";
        private const string FieldfridayEndField = "fridayEndField";
        private const string FieldfridayStartField = "fridayStartField";
        private const string FieldmondayEndField = "mondayEndField";
        private const string FieldmondayStartField = "mondayStartField";
        private const string FieldsaturdayEndField = "saturdayEndField";
        private const string FieldsaturdayStartField = "saturdayStartField";
        private const string FieldsundayEndField = "sundayEndField";
        private const string FieldsundayStartField = "sundayStartField";
        private const string FieldthursdayEndField = "thursdayEndField";
        private const string FieldthursdayStartField = "thursdayStartField";
        private const string FieldtuesdayEndField = "tuesdayEndField";
        private const string FieldtuesdayStartField = "tuesdayStartField";
        private const string FieldwednesdayEndField = "wednesdayEndField";
        private const string FieldwednesdayStartField = "wednesdayStartField";
        private Type _profileLoginHoursInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ProfileLoginHours _profileLoginHoursInstance;
        private ProfileLoginHours _profileLoginHoursInstanceFixture;

        #region General Initializer : Class (ProfileLoginHours) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ProfileLoginHours" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _profileLoginHoursInstanceType = typeof(ProfileLoginHours);
            _profileLoginHoursInstanceFixture = Create(true);
            _profileLoginHoursInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ProfileLoginHours)

        #region General Initializer : Class (ProfileLoginHours) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ProfileLoginHours" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyfridayEnd)]
        [TestCase(PropertyfridayStart)]
        [TestCase(PropertymondayEnd)]
        [TestCase(PropertymondayStart)]
        [TestCase(PropertysaturdayEnd)]
        [TestCase(PropertysaturdayStart)]
        [TestCase(PropertysundayEnd)]
        [TestCase(PropertysundayStart)]
        [TestCase(PropertythursdayEnd)]
        [TestCase(PropertythursdayStart)]
        [TestCase(PropertytuesdayEnd)]
        [TestCase(PropertytuesdayStart)]
        [TestCase(PropertywednesdayEnd)]
        [TestCase(PropertywednesdayStart)]
        public void AUT_ProfileLoginHours_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_profileLoginHoursInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ProfileLoginHours) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ProfileLoginHours" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldfridayEndField)]
        [TestCase(FieldfridayStartField)]
        [TestCase(FieldmondayEndField)]
        [TestCase(FieldmondayStartField)]
        [TestCase(FieldsaturdayEndField)]
        [TestCase(FieldsaturdayStartField)]
        [TestCase(FieldsundayEndField)]
        [TestCase(FieldsundayStartField)]
        [TestCase(FieldthursdayEndField)]
        [TestCase(FieldthursdayStartField)]
        [TestCase(FieldtuesdayEndField)]
        [TestCase(FieldtuesdayStartField)]
        [TestCase(FieldwednesdayEndField)]
        [TestCase(FieldwednesdayStartField)]
        public void AUT_ProfileLoginHours_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_profileLoginHoursInstanceFixture, 
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
        ///     Class (<see cref="ProfileLoginHours" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ProfileLoginHours_Is_Instance_Present_Test()
        {
            // Assert
            _profileLoginHoursInstanceType.ShouldNotBeNull();
            _profileLoginHoursInstance.ShouldNotBeNull();
            _profileLoginHoursInstanceFixture.ShouldNotBeNull();
            _profileLoginHoursInstance.ShouldBeAssignableTo<ProfileLoginHours>();
            _profileLoginHoursInstanceFixture.ShouldBeAssignableTo<ProfileLoginHours>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ProfileLoginHours) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ProfileLoginHours_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ProfileLoginHours instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _profileLoginHoursInstanceType.ShouldNotBeNull();
            _profileLoginHoursInstance.ShouldNotBeNull();
            _profileLoginHoursInstanceFixture.ShouldNotBeNull();
            _profileLoginHoursInstance.ShouldBeAssignableTo<ProfileLoginHours>();
            _profileLoginHoursInstanceFixture.ShouldBeAssignableTo<ProfileLoginHours>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ProfileLoginHours) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyfridayEnd)]
        [TestCaseGeneric(typeof(string) , PropertyfridayStart)]
        [TestCaseGeneric(typeof(string) , PropertymondayEnd)]
        [TestCaseGeneric(typeof(string) , PropertymondayStart)]
        [TestCaseGeneric(typeof(string) , PropertysaturdayEnd)]
        [TestCaseGeneric(typeof(string) , PropertysaturdayStart)]
        [TestCaseGeneric(typeof(string) , PropertysundayEnd)]
        [TestCaseGeneric(typeof(string) , PropertysundayStart)]
        [TestCaseGeneric(typeof(string) , PropertythursdayEnd)]
        [TestCaseGeneric(typeof(string) , PropertythursdayStart)]
        [TestCaseGeneric(typeof(string) , PropertytuesdayEnd)]
        [TestCaseGeneric(typeof(string) , PropertytuesdayStart)]
        [TestCaseGeneric(typeof(string) , PropertywednesdayEnd)]
        [TestCaseGeneric(typeof(string) , PropertywednesdayStart)]
        public void AUT_ProfileLoginHours_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ProfileLoginHours, T>(_profileLoginHoursInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ProfileLoginHours) => Property (fridayEnd) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileLoginHours_Public_Class_fridayEnd_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfridayEnd);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileLoginHours) => Property (fridayStart) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileLoginHours_Public_Class_fridayStart_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfridayStart);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileLoginHours) => Property (mondayEnd) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileLoginHours_Public_Class_mondayEnd_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymondayEnd);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileLoginHours) => Property (mondayStart) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileLoginHours_Public_Class_mondayStart_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymondayStart);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileLoginHours) => Property (saturdayEnd) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileLoginHours_Public_Class_saturdayEnd_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysaturdayEnd);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileLoginHours) => Property (saturdayStart) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileLoginHours_Public_Class_saturdayStart_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysaturdayStart);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileLoginHours) => Property (sundayEnd) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileLoginHours_Public_Class_sundayEnd_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysundayEnd);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileLoginHours) => Property (sundayStart) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileLoginHours_Public_Class_sundayStart_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysundayStart);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileLoginHours) => Property (thursdayEnd) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileLoginHours_Public_Class_thursdayEnd_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertythursdayEnd);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileLoginHours) => Property (thursdayStart) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileLoginHours_Public_Class_thursdayStart_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertythursdayStart);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileLoginHours) => Property (tuesdayEnd) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileLoginHours_Public_Class_tuesdayEnd_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytuesdayEnd);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileLoginHours) => Property (tuesdayStart) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileLoginHours_Public_Class_tuesdayStart_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytuesdayStart);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileLoginHours) => Property (wednesdayEnd) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileLoginHours_Public_Class_wednesdayEnd_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertywednesdayEnd);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileLoginHours) => Property (wednesdayStart) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileLoginHours_Public_Class_wednesdayStart_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertywednesdayStart);

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