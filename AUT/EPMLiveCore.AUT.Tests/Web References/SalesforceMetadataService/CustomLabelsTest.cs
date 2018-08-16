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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CustomLabels" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomLabelsTest : AbstractBaseSetupTypedTest<CustomLabels>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomLabels) Initializer

        private const string Propertylabels = "labels";
        private const string FieldlabelsField = "labelsField";
        private Type _customLabelsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomLabels _customLabelsInstance;
        private CustomLabels _customLabelsInstanceFixture;

        #region General Initializer : Class (CustomLabels) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomLabels" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customLabelsInstanceType = typeof(CustomLabels);
            _customLabelsInstanceFixture = Create(true);
            _customLabelsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomLabels)

        #region General Initializer : Class (CustomLabels) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomLabels" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertylabels)]
        public void AUT_CustomLabels_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_customLabelsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomLabels) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomLabels" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldlabelsField)]
        public void AUT_CustomLabels_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customLabelsInstanceFixture, 
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
        ///     Class (<see cref="CustomLabels" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CustomLabels_Is_Instance_Present_Test()
        {
            // Assert
            _customLabelsInstanceType.ShouldNotBeNull();
            _customLabelsInstance.ShouldNotBeNull();
            _customLabelsInstanceFixture.ShouldNotBeNull();
            _customLabelsInstance.ShouldBeAssignableTo<CustomLabels>();
            _customLabelsInstanceFixture.ShouldBeAssignableTo<CustomLabels>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomLabels) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CustomLabels_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomLabels instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customLabelsInstanceType.ShouldNotBeNull();
            _customLabelsInstance.ShouldNotBeNull();
            _customLabelsInstanceFixture.ShouldNotBeNull();
            _customLabelsInstance.ShouldBeAssignableTo<CustomLabels>();
            _customLabelsInstanceFixture.ShouldBeAssignableTo<CustomLabels>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CustomLabels) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(CustomLabel[]) , Propertylabels)]
        public void AUT_CustomLabels_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CustomLabels, T>(_customLabelsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CustomLabels) => Property (labels) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomLabels_labels_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertylabels);
            Action currentAction = () => propertyInfo.SetValue(_customLabelsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomLabels) => Property (labels) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomLabels_Public_Class_labels_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylabels);

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