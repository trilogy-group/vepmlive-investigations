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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.AnalyticSnapshot" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AnalyticSnapshotTest : AbstractBaseSetupTypedTest<AnalyticSnapshot>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AnalyticSnapshot) Initializer

        private const string Propertydescription = "description";
        private const string PropertygroupColumn = "groupColumn";
        private const string Propertymappings = "mappings";
        private const string Propertyname = "name";
        private const string PropertyrunningUser = "runningUser";
        private const string PropertysourceReport = "sourceReport";
        private const string PropertytargetObject = "targetObject";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldgroupColumnField = "groupColumnField";
        private const string FieldmappingsField = "mappingsField";
        private const string FieldnameField = "nameField";
        private const string FieldrunningUserField = "runningUserField";
        private const string FieldsourceReportField = "sourceReportField";
        private const string FieldtargetObjectField = "targetObjectField";
        private Type _analyticSnapshotInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AnalyticSnapshot _analyticSnapshotInstance;
        private AnalyticSnapshot _analyticSnapshotInstanceFixture;

        #region General Initializer : Class (AnalyticSnapshot) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AnalyticSnapshot" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _analyticSnapshotInstanceType = typeof(AnalyticSnapshot);
            _analyticSnapshotInstanceFixture = Create(true);
            _analyticSnapshotInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AnalyticSnapshot)

        #region General Initializer : Class (AnalyticSnapshot) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="AnalyticSnapshot" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertydescription)]
        [TestCase(PropertygroupColumn)]
        [TestCase(Propertymappings)]
        [TestCase(Propertyname)]
        [TestCase(PropertyrunningUser)]
        [TestCase(PropertysourceReport)]
        [TestCase(PropertytargetObject)]
        public void AUT_AnalyticSnapshot_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_analyticSnapshotInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AnalyticSnapshot) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AnalyticSnapshot" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldgroupColumnField)]
        [TestCase(FieldmappingsField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldrunningUserField)]
        [TestCase(FieldsourceReportField)]
        [TestCase(FieldtargetObjectField)]
        public void AUT_AnalyticSnapshot_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_analyticSnapshotInstanceFixture, 
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
        ///     Class (<see cref="AnalyticSnapshot" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_AnalyticSnapshot_Is_Instance_Present_Test()
        {
            // Assert
            _analyticSnapshotInstanceType.ShouldNotBeNull();
            _analyticSnapshotInstance.ShouldNotBeNull();
            _analyticSnapshotInstanceFixture.ShouldNotBeNull();
            _analyticSnapshotInstance.ShouldBeAssignableTo<AnalyticSnapshot>();
            _analyticSnapshotInstanceFixture.ShouldBeAssignableTo<AnalyticSnapshot>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AnalyticSnapshot) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_AnalyticSnapshot_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            AnalyticSnapshot instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _analyticSnapshotInstanceType.ShouldNotBeNull();
            _analyticSnapshotInstance.ShouldNotBeNull();
            _analyticSnapshotInstanceFixture.ShouldNotBeNull();
            _analyticSnapshotInstance.ShouldBeAssignableTo<AnalyticSnapshot>();
            _analyticSnapshotInstanceFixture.ShouldBeAssignableTo<AnalyticSnapshot>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (AnalyticSnapshot) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , PropertygroupColumn)]
        [TestCaseGeneric(typeof(AnalyticSnapshotMapping[]) , Propertymappings)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(string) , PropertyrunningUser)]
        [TestCaseGeneric(typeof(string) , PropertysourceReport)]
        [TestCaseGeneric(typeof(string) , PropertytargetObject)]
        public void AUT_AnalyticSnapshot_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<AnalyticSnapshot, T>(_analyticSnapshotInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticSnapshot) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AnalyticSnapshot_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticSnapshot) => Property (groupColumn) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AnalyticSnapshot_Public_Class_groupColumn_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertygroupColumn);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticSnapshot) => Property (mappings) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AnalyticSnapshot_mappings_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertymappings);
            Action currentAction = () => propertyInfo.SetValue(_analyticSnapshotInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticSnapshot) => Property (mappings) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AnalyticSnapshot_Public_Class_mappings_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertymappings);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticSnapshot) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AnalyticSnapshot_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyname);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticSnapshot) => Property (runningUser) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AnalyticSnapshot_Public_Class_runningUser_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrunningUser);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticSnapshot) => Property (sourceReport) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AnalyticSnapshot_Public_Class_sourceReport_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysourceReport);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticSnapshot) => Property (targetObject) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AnalyticSnapshot_Public_Class_targetObject_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytargetObject);

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