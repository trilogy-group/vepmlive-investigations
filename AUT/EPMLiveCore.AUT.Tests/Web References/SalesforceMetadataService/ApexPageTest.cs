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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ApexPage" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ApexPageTest : AbstractBaseSetupTypedTest<ApexPage>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ApexPage) Initializer

        private const string PropertyapiVersion = "apiVersion";
        private const string PropertyavailableInTouch = "availableInTouch";
        private const string PropertyavailableInTouchSpecified = "availableInTouchSpecified";
        private const string Propertydescription = "description";
        private const string Propertylabel = "label";
        private const string PropertypackageVersions = "packageVersions";
        private const string FieldapiVersionField = "apiVersionField";
        private const string FieldavailableInTouchField = "availableInTouchField";
        private const string FieldavailableInTouchFieldSpecified = "availableInTouchFieldSpecified";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldlabelField = "labelField";
        private const string FieldpackageVersionsField = "packageVersionsField";
        private Type _apexPageInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ApexPage _apexPageInstance;
        private ApexPage _apexPageInstanceFixture;

        #region General Initializer : Class (ApexPage) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ApexPage" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _apexPageInstanceType = typeof(ApexPage);
            _apexPageInstanceFixture = Create(true);
            _apexPageInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ApexPage)

        #region General Initializer : Class (ApexPage) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ApexPage" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyapiVersion)]
        [TestCase(PropertyavailableInTouch)]
        [TestCase(PropertyavailableInTouchSpecified)]
        [TestCase(Propertydescription)]
        [TestCase(Propertylabel)]
        [TestCase(PropertypackageVersions)]
        public void AUT_ApexPage_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_apexPageInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ApexPage) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ApexPage" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldapiVersionField)]
        [TestCase(FieldavailableInTouchField)]
        [TestCase(FieldavailableInTouchFieldSpecified)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldpackageVersionsField)]
        public void AUT_ApexPage_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_apexPageInstanceFixture, 
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
        ///     Class (<see cref="ApexPage" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ApexPage_Is_Instance_Present_Test()
        {
            // Assert
            _apexPageInstanceType.ShouldNotBeNull();
            _apexPageInstance.ShouldNotBeNull();
            _apexPageInstanceFixture.ShouldNotBeNull();
            _apexPageInstance.ShouldBeAssignableTo<ApexPage>();
            _apexPageInstanceFixture.ShouldBeAssignableTo<ApexPage>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ApexPage) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ApexPage_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ApexPage instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _apexPageInstanceType.ShouldNotBeNull();
            _apexPageInstance.ShouldNotBeNull();
            _apexPageInstanceFixture.ShouldNotBeNull();
            _apexPageInstance.ShouldBeAssignableTo<ApexPage>();
            _apexPageInstanceFixture.ShouldBeAssignableTo<ApexPage>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ApexPage) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(double) , PropertyapiVersion)]
        [TestCaseGeneric(typeof(bool) , PropertyavailableInTouch)]
        [TestCaseGeneric(typeof(bool) , PropertyavailableInTouchSpecified)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(PackageVersion[]) , PropertypackageVersions)]
        public void AUT_ApexPage_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ApexPage, T>(_apexPageInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ApexPage) => Property (apiVersion) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexPage_Public_Class_apiVersion_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyapiVersion);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ApexPage) => Property (availableInTouch) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexPage_Public_Class_availableInTouch_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyavailableInTouch);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ApexPage) => Property (availableInTouchSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexPage_Public_Class_availableInTouchSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyavailableInTouchSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ApexPage) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexPage_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ApexPage) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexPage_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ApexPage) => Property (packageVersions) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexPage_packageVersions_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertypackageVersions);
            Action currentAction = () => propertyInfo.SetValue(_apexPageInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ApexPage) => Property (packageVersions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexPage_Public_Class_packageVersions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypackageVersions);

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