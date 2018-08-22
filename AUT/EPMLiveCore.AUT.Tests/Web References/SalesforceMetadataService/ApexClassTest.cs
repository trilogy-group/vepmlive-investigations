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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ApexClass" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ApexClassTest : AbstractBaseSetupTypedTest<ApexClass>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ApexClass) Initializer

        private const string PropertyapiVersion = "apiVersion";
        private const string PropertypackageVersions = "packageVersions";
        private const string Propertystatus = "status";
        private const string FieldapiVersionField = "apiVersionField";
        private const string FieldpackageVersionsField = "packageVersionsField";
        private const string FieldstatusField = "statusField";
        private Type _apexClassInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ApexClass _apexClassInstance;
        private ApexClass _apexClassInstanceFixture;

        #region General Initializer : Class (ApexClass) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ApexClass" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _apexClassInstanceType = typeof(ApexClass);
            _apexClassInstanceFixture = Create(true);
            _apexClassInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ApexClass)

        #region General Initializer : Class (ApexClass) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ApexClass" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyapiVersion)]
        [TestCase(PropertypackageVersions)]
        [TestCase(Propertystatus)]
        public void AUT_ApexClass_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_apexClassInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ApexClass) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ApexClass" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldapiVersionField)]
        [TestCase(FieldpackageVersionsField)]
        [TestCase(FieldstatusField)]
        public void AUT_ApexClass_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_apexClassInstanceFixture, 
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
        ///     Class (<see cref="ApexClass" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ApexClass_Is_Instance_Present_Test()
        {
            // Assert
            _apexClassInstanceType.ShouldNotBeNull();
            _apexClassInstance.ShouldNotBeNull();
            _apexClassInstanceFixture.ShouldNotBeNull();
            _apexClassInstance.ShouldBeAssignableTo<ApexClass>();
            _apexClassInstanceFixture.ShouldBeAssignableTo<ApexClass>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ApexClass) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ApexClass_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ApexClass instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _apexClassInstanceType.ShouldNotBeNull();
            _apexClassInstance.ShouldNotBeNull();
            _apexClassInstanceFixture.ShouldNotBeNull();
            _apexClassInstance.ShouldBeAssignableTo<ApexClass>();
            _apexClassInstanceFixture.ShouldBeAssignableTo<ApexClass>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ApexClass) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(double) , PropertyapiVersion)]
        [TestCaseGeneric(typeof(PackageVersion[]) , PropertypackageVersions)]
        [TestCaseGeneric(typeof(ApexCodeUnitStatus) , Propertystatus)]
        public void AUT_ApexClass_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ApexClass, T>(_apexClassInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ApexClass) => Property (apiVersion) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexClass_Public_Class_apiVersion_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ApexClass) => Property (packageVersions) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexClass_packageVersions_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertypackageVersions);
            Action currentAction = () => propertyInfo.SetValue(_apexClassInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ApexClass) => Property (packageVersions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexClass_Public_Class_packageVersions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ApexClass) => Property (status) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexClass_status_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertystatus);
            Action currentAction = () => propertyInfo.SetValue(_apexClassInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ApexClass) => Property (status) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexClass_Public_Class_status_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertystatus);

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