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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.DeployOptions" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DeployOptionsTest : AbstractBaseSetupTypedTest<DeployOptions>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DeployOptions) Initializer

        private const string PropertyallowMissingFiles = "allowMissingFiles";
        private const string PropertyautoUpdatePackage = "autoUpdatePackage";
        private const string PropertycheckOnly = "checkOnly";
        private const string PropertyignoreWarnings = "ignoreWarnings";
        private const string PropertyperformRetrieve = "performRetrieve";
        private const string PropertypurgeOnDelete = "purgeOnDelete";
        private const string PropertyrollbackOnError = "rollbackOnError";
        private const string PropertyrunAllTests = "runAllTests";
        private const string PropertyrunTests = "runTests";
        private const string PropertysinglePackage = "singlePackage";
        private const string FieldallowMissingFilesField = "allowMissingFilesField";
        private const string FieldautoUpdatePackageField = "autoUpdatePackageField";
        private const string FieldcheckOnlyField = "checkOnlyField";
        private const string FieldignoreWarningsField = "ignoreWarningsField";
        private const string FieldperformRetrieveField = "performRetrieveField";
        private const string FieldpurgeOnDeleteField = "purgeOnDeleteField";
        private const string FieldrollbackOnErrorField = "rollbackOnErrorField";
        private const string FieldrunAllTestsField = "runAllTestsField";
        private const string FieldrunTestsField = "runTestsField";
        private const string FieldsinglePackageField = "singlePackageField";
        private Type _deployOptionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DeployOptions _deployOptionsInstance;
        private DeployOptions _deployOptionsInstanceFixture;

        #region General Initializer : Class (DeployOptions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DeployOptions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _deployOptionsInstanceType = typeof(DeployOptions);
            _deployOptionsInstanceFixture = Create(true);
            _deployOptionsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DeployOptions)

        #region General Initializer : Class (DeployOptions) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DeployOptions" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyallowMissingFiles)]
        [TestCase(PropertyautoUpdatePackage)]
        [TestCase(PropertycheckOnly)]
        [TestCase(PropertyignoreWarnings)]
        [TestCase(PropertyperformRetrieve)]
        [TestCase(PropertypurgeOnDelete)]
        [TestCase(PropertyrollbackOnError)]
        [TestCase(PropertyrunAllTests)]
        [TestCase(PropertyrunTests)]
        [TestCase(PropertysinglePackage)]
        public void AUT_DeployOptions_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_deployOptionsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DeployOptions) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DeployOptions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldallowMissingFilesField)]
        [TestCase(FieldautoUpdatePackageField)]
        [TestCase(FieldcheckOnlyField)]
        [TestCase(FieldignoreWarningsField)]
        [TestCase(FieldperformRetrieveField)]
        [TestCase(FieldpurgeOnDeleteField)]
        [TestCase(FieldrollbackOnErrorField)]
        [TestCase(FieldrunAllTestsField)]
        [TestCase(FieldrunTestsField)]
        [TestCase(FieldsinglePackageField)]
        public void AUT_DeployOptions_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_deployOptionsInstanceFixture, 
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
        ///     Class (<see cref="DeployOptions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DeployOptions_Is_Instance_Present_Test()
        {
            // Assert
            _deployOptionsInstanceType.ShouldNotBeNull();
            _deployOptionsInstance.ShouldNotBeNull();
            _deployOptionsInstanceFixture.ShouldNotBeNull();
            _deployOptionsInstance.ShouldBeAssignableTo<DeployOptions>();
            _deployOptionsInstanceFixture.ShouldBeAssignableTo<DeployOptions>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DeployOptions) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DeployOptions_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DeployOptions instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _deployOptionsInstanceType.ShouldNotBeNull();
            _deployOptionsInstance.ShouldNotBeNull();
            _deployOptionsInstanceFixture.ShouldNotBeNull();
            _deployOptionsInstance.ShouldBeAssignableTo<DeployOptions>();
            _deployOptionsInstanceFixture.ShouldBeAssignableTo<DeployOptions>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DeployOptions) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyallowMissingFiles)]
        [TestCaseGeneric(typeof(bool) , PropertyautoUpdatePackage)]
        [TestCaseGeneric(typeof(bool) , PropertycheckOnly)]
        [TestCaseGeneric(typeof(bool) , PropertyignoreWarnings)]
        [TestCaseGeneric(typeof(bool) , PropertyperformRetrieve)]
        [TestCaseGeneric(typeof(bool) , PropertypurgeOnDelete)]
        [TestCaseGeneric(typeof(bool) , PropertyrollbackOnError)]
        [TestCaseGeneric(typeof(bool) , PropertyrunAllTests)]
        [TestCaseGeneric(typeof(string[]) , PropertyrunTests)]
        [TestCaseGeneric(typeof(bool) , PropertysinglePackage)]
        public void AUT_DeployOptions_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DeployOptions, T>(_deployOptionsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DeployOptions) => Property (allowMissingFiles) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployOptions_Public_Class_allowMissingFiles_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallowMissingFiles);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeployOptions) => Property (autoUpdatePackage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployOptions_Public_Class_autoUpdatePackage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyautoUpdatePackage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeployOptions) => Property (checkOnly) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployOptions_Public_Class_checkOnly_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycheckOnly);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeployOptions) => Property (ignoreWarnings) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployOptions_Public_Class_ignoreWarnings_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyignoreWarnings);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeployOptions) => Property (performRetrieve) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployOptions_Public_Class_performRetrieve_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyperformRetrieve);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeployOptions) => Property (purgeOnDelete) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployOptions_Public_Class_purgeOnDelete_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypurgeOnDelete);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeployOptions) => Property (rollbackOnError) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployOptions_Public_Class_rollbackOnError_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrollbackOnError);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeployOptions) => Property (runAllTests) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployOptions_Public_Class_runAllTests_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrunAllTests);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeployOptions) => Property (runTests) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployOptions_runTests_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyrunTests);
            Action currentAction = () => propertyInfo.SetValue(_deployOptionsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DeployOptions) => Property (runTests) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployOptions_Public_Class_runTests_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrunTests);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeployOptions) => Property (singlePackage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployOptions_Public_Class_singlePackage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysinglePackage);

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