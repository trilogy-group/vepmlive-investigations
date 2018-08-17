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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ReportTimeFrameFilter" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportTimeFrameFilterTest : AbstractBaseSetupTypedTest<ReportTimeFrameFilter>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportTimeFrameFilter) Initializer

        private const string PropertydateColumn = "dateColumn";
        private const string PropertyendDate = "endDate";
        private const string PropertyendDateSpecified = "endDateSpecified";
        private const string Propertyinterval = "interval";
        private const string PropertystartDate = "startDate";
        private const string PropertystartDateSpecified = "startDateSpecified";
        private const string FielddateColumnField = "dateColumnField";
        private const string FieldendDateField = "endDateField";
        private const string FieldendDateFieldSpecified = "endDateFieldSpecified";
        private const string FieldintervalField = "intervalField";
        private const string FieldstartDateField = "startDateField";
        private const string FieldstartDateFieldSpecified = "startDateFieldSpecified";
        private Type _reportTimeFrameFilterInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportTimeFrameFilter _reportTimeFrameFilterInstance;
        private ReportTimeFrameFilter _reportTimeFrameFilterInstanceFixture;

        #region General Initializer : Class (ReportTimeFrameFilter) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportTimeFrameFilter" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportTimeFrameFilterInstanceType = typeof(ReportTimeFrameFilter);
            _reportTimeFrameFilterInstanceFixture = Create(true);
            _reportTimeFrameFilterInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportTimeFrameFilter)

        #region General Initializer : Class (ReportTimeFrameFilter) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportTimeFrameFilter" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertydateColumn)]
        [TestCase(PropertyendDate)]
        [TestCase(PropertyendDateSpecified)]
        [TestCase(Propertyinterval)]
        [TestCase(PropertystartDate)]
        [TestCase(PropertystartDateSpecified)]
        public void AUT_ReportTimeFrameFilter_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportTimeFrameFilterInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportTimeFrameFilter) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportTimeFrameFilter" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddateColumnField)]
        [TestCase(FieldendDateField)]
        [TestCase(FieldendDateFieldSpecified)]
        [TestCase(FieldintervalField)]
        [TestCase(FieldstartDateField)]
        [TestCase(FieldstartDateFieldSpecified)]
        public void AUT_ReportTimeFrameFilter_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportTimeFrameFilterInstanceFixture, 
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
        ///     Class (<see cref="ReportTimeFrameFilter" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportTimeFrameFilter_Is_Instance_Present_Test()
        {
            // Assert
            _reportTimeFrameFilterInstanceType.ShouldNotBeNull();
            _reportTimeFrameFilterInstance.ShouldNotBeNull();
            _reportTimeFrameFilterInstanceFixture.ShouldNotBeNull();
            _reportTimeFrameFilterInstance.ShouldBeAssignableTo<ReportTimeFrameFilter>();
            _reportTimeFrameFilterInstanceFixture.ShouldBeAssignableTo<ReportTimeFrameFilter>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportTimeFrameFilter) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportTimeFrameFilter_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportTimeFrameFilter instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportTimeFrameFilterInstanceType.ShouldNotBeNull();
            _reportTimeFrameFilterInstance.ShouldNotBeNull();
            _reportTimeFrameFilterInstanceFixture.ShouldNotBeNull();
            _reportTimeFrameFilterInstance.ShouldBeAssignableTo<ReportTimeFrameFilter>();
            _reportTimeFrameFilterInstanceFixture.ShouldBeAssignableTo<ReportTimeFrameFilter>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportTimeFrameFilter) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertydateColumn)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyendDate)]
        [TestCaseGeneric(typeof(bool) , PropertyendDateSpecified)]
        [TestCaseGeneric(typeof(UserDateInterval) , Propertyinterval)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertystartDate)]
        [TestCaseGeneric(typeof(bool) , PropertystartDateSpecified)]
        public void AUT_ReportTimeFrameFilter_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportTimeFrameFilter, T>(_reportTimeFrameFilterInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportTimeFrameFilter) => Property (dateColumn) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTimeFrameFilter_Public_Class_dateColumn_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydateColumn);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportTimeFrameFilter) => Property (endDate) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTimeFrameFilter_endDate_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyendDate);
            Action currentAction = () => propertyInfo.SetValue(_reportTimeFrameFilterInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportTimeFrameFilter) => Property (endDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTimeFrameFilter_Public_Class_endDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyendDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportTimeFrameFilter) => Property (endDateSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTimeFrameFilter_Public_Class_endDateSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyendDateSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportTimeFrameFilter) => Property (interval) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTimeFrameFilter_interval_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyinterval);
            Action currentAction = () => propertyInfo.SetValue(_reportTimeFrameFilterInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportTimeFrameFilter) => Property (interval) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTimeFrameFilter_Public_Class_interval_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyinterval);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportTimeFrameFilter) => Property (startDate) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTimeFrameFilter_startDate_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertystartDate);
            Action currentAction = () => propertyInfo.SetValue(_reportTimeFrameFilterInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportTimeFrameFilter) => Property (startDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTimeFrameFilter_Public_Class_startDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertystartDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportTimeFrameFilter) => Property (startDateSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTimeFrameFilter_Public_Class_startDateSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertystartDateSpecified);

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