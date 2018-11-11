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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ReportBucketFieldValue" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportBucketFieldValueTest : AbstractBaseSetupTypedTest<ReportBucketFieldValue>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportBucketFieldValue) Initializer

        private const string PropertysourceValues = "sourceValues";
        private const string Propertyvalue = "value";
        private const string FieldsourceValuesField = "sourceValuesField";
        private const string FieldvalueField = "valueField";
        private Type _reportBucketFieldValueInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportBucketFieldValue _reportBucketFieldValueInstance;
        private ReportBucketFieldValue _reportBucketFieldValueInstanceFixture;

        #region General Initializer : Class (ReportBucketFieldValue) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportBucketFieldValue" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportBucketFieldValueInstanceType = typeof(ReportBucketFieldValue);
            _reportBucketFieldValueInstanceFixture = Create(true);
            _reportBucketFieldValueInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportBucketFieldValue)

        #region General Initializer : Class (ReportBucketFieldValue) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportBucketFieldValue" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertysourceValues)]
        [TestCase(Propertyvalue)]
        public void AUT_ReportBucketFieldValue_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportBucketFieldValueInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportBucketFieldValue) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportBucketFieldValue" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldsourceValuesField)]
        [TestCase(FieldvalueField)]
        public void AUT_ReportBucketFieldValue_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportBucketFieldValueInstanceFixture, 
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
        ///     Class (<see cref="ReportBucketFieldValue" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportBucketFieldValue_Is_Instance_Present_Test()
        {
            // Assert
            _reportBucketFieldValueInstanceType.ShouldNotBeNull();
            _reportBucketFieldValueInstance.ShouldNotBeNull();
            _reportBucketFieldValueInstanceFixture.ShouldNotBeNull();
            _reportBucketFieldValueInstance.ShouldBeAssignableTo<ReportBucketFieldValue>();
            _reportBucketFieldValueInstanceFixture.ShouldBeAssignableTo<ReportBucketFieldValue>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportBucketFieldValue) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportBucketFieldValue_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportBucketFieldValue instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportBucketFieldValueInstanceType.ShouldNotBeNull();
            _reportBucketFieldValueInstance.ShouldNotBeNull();
            _reportBucketFieldValueInstanceFixture.ShouldNotBeNull();
            _reportBucketFieldValueInstance.ShouldBeAssignableTo<ReportBucketFieldValue>();
            _reportBucketFieldValueInstanceFixture.ShouldBeAssignableTo<ReportBucketFieldValue>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportBucketFieldValue) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ReportBucketFieldSourceValue[]) , PropertysourceValues)]
        [TestCaseGeneric(typeof(string) , Propertyvalue)]
        public void AUT_ReportBucketFieldValue_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportBucketFieldValue, T>(_reportBucketFieldValueInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportBucketFieldValue) => Property (sourceValues) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBucketFieldValue_sourceValues_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysourceValues);
            Action currentAction = () => propertyInfo.SetValue(_reportBucketFieldValueInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportBucketFieldValue) => Property (sourceValues) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBucketFieldValue_Public_Class_sourceValues_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysourceValues);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportBucketFieldValue) => Property (value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBucketFieldValue_Public_Class_value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyvalue);

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