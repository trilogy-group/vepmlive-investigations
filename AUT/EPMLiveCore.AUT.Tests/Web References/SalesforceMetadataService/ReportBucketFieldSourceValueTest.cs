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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ReportBucketFieldSourceValue" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportBucketFieldSourceValueTest : AbstractBaseSetupTypedTest<ReportBucketFieldSourceValue>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportBucketFieldSourceValue) Initializer

        private const string Propertyfrom = "from";
        private const string PropertysourceValue = "sourceValue";
        private const string Propertyto = "to";
        private const string FieldfromField = "fromField";
        private const string FieldsourceValueField = "sourceValueField";
        private const string FieldtoField = "toField";
        private Type _reportBucketFieldSourceValueInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportBucketFieldSourceValue _reportBucketFieldSourceValueInstance;
        private ReportBucketFieldSourceValue _reportBucketFieldSourceValueInstanceFixture;

        #region General Initializer : Class (ReportBucketFieldSourceValue) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportBucketFieldSourceValue" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportBucketFieldSourceValueInstanceType = typeof(ReportBucketFieldSourceValue);
            _reportBucketFieldSourceValueInstanceFixture = Create(true);
            _reportBucketFieldSourceValueInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportBucketFieldSourceValue)

        #region General Initializer : Class (ReportBucketFieldSourceValue) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportBucketFieldSourceValue" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyfrom)]
        [TestCase(PropertysourceValue)]
        [TestCase(Propertyto)]
        public void AUT_ReportBucketFieldSourceValue_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportBucketFieldSourceValueInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportBucketFieldSourceValue) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportBucketFieldSourceValue" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldfromField)]
        [TestCase(FieldsourceValueField)]
        [TestCase(FieldtoField)]
        public void AUT_ReportBucketFieldSourceValue_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportBucketFieldSourceValueInstanceFixture, 
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
        ///     Class (<see cref="ReportBucketFieldSourceValue" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportBucketFieldSourceValue_Is_Instance_Present_Test()
        {
            // Assert
            _reportBucketFieldSourceValueInstanceType.ShouldNotBeNull();
            _reportBucketFieldSourceValueInstance.ShouldNotBeNull();
            _reportBucketFieldSourceValueInstanceFixture.ShouldNotBeNull();
            _reportBucketFieldSourceValueInstance.ShouldBeAssignableTo<ReportBucketFieldSourceValue>();
            _reportBucketFieldSourceValueInstanceFixture.ShouldBeAssignableTo<ReportBucketFieldSourceValue>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportBucketFieldSourceValue) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportBucketFieldSourceValue_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportBucketFieldSourceValue instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportBucketFieldSourceValueInstanceType.ShouldNotBeNull();
            _reportBucketFieldSourceValueInstance.ShouldNotBeNull();
            _reportBucketFieldSourceValueInstanceFixture.ShouldNotBeNull();
            _reportBucketFieldSourceValueInstance.ShouldBeAssignableTo<ReportBucketFieldSourceValue>();
            _reportBucketFieldSourceValueInstanceFixture.ShouldBeAssignableTo<ReportBucketFieldSourceValue>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportBucketFieldSourceValue) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyfrom)]
        [TestCaseGeneric(typeof(string) , PropertysourceValue)]
        [TestCaseGeneric(typeof(string) , Propertyto)]
        public void AUT_ReportBucketFieldSourceValue_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportBucketFieldSourceValue, T>(_reportBucketFieldSourceValueInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportBucketFieldSourceValue) => Property (from) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBucketFieldSourceValue_Public_Class_from_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfrom);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportBucketFieldSourceValue) => Property (sourceValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBucketFieldSourceValue_Public_Class_sourceValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysourceValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportBucketFieldSourceValue) => Property (to) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBucketFieldSourceValue_Public_Class_to_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyto);

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