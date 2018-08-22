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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.RetrieveRequest" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RetrieveRequestTest : AbstractBaseSetupTypedTest<RetrieveRequest>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RetrieveRequest) Initializer

        private const string PropertyapiVersion = "apiVersion";
        private const string PropertypackageNames = "packageNames";
        private const string PropertysinglePackage = "singlePackage";
        private const string PropertyspecificFiles = "specificFiles";
        private const string Propertyunpackaged = "unpackaged";
        private const string FieldapiVersionField = "apiVersionField";
        private const string FieldpackageNamesField = "packageNamesField";
        private const string FieldsinglePackageField = "singlePackageField";
        private const string FieldspecificFilesField = "specificFilesField";
        private const string FieldunpackagedField = "unpackagedField";
        private Type _retrieveRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RetrieveRequest _retrieveRequestInstance;
        private RetrieveRequest _retrieveRequestInstanceFixture;

        #region General Initializer : Class (RetrieveRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RetrieveRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _retrieveRequestInstanceType = typeof(RetrieveRequest);
            _retrieveRequestInstanceFixture = Create(true);
            _retrieveRequestInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RetrieveRequest)

        #region General Initializer : Class (RetrieveRequest) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="RetrieveRequest" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyapiVersion)]
        [TestCase(PropertypackageNames)]
        [TestCase(PropertysinglePackage)]
        [TestCase(PropertyspecificFiles)]
        [TestCase(Propertyunpackaged)]
        public void AUT_RetrieveRequest_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_retrieveRequestInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (RetrieveRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RetrieveRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldapiVersionField)]
        [TestCase(FieldpackageNamesField)]
        [TestCase(FieldsinglePackageField)]
        [TestCase(FieldspecificFilesField)]
        [TestCase(FieldunpackagedField)]
        public void AUT_RetrieveRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_retrieveRequestInstanceFixture, 
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
        ///     Class (<see cref="RetrieveRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_RetrieveRequest_Is_Instance_Present_Test()
        {
            // Assert
            _retrieveRequestInstanceType.ShouldNotBeNull();
            _retrieveRequestInstance.ShouldNotBeNull();
            _retrieveRequestInstanceFixture.ShouldNotBeNull();
            _retrieveRequestInstance.ShouldBeAssignableTo<RetrieveRequest>();
            _retrieveRequestInstanceFixture.ShouldBeAssignableTo<RetrieveRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RetrieveRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_RetrieveRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RetrieveRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _retrieveRequestInstanceType.ShouldNotBeNull();
            _retrieveRequestInstance.ShouldNotBeNull();
            _retrieveRequestInstanceFixture.ShouldNotBeNull();
            _retrieveRequestInstance.ShouldBeAssignableTo<RetrieveRequest>();
            _retrieveRequestInstanceFixture.ShouldBeAssignableTo<RetrieveRequest>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (RetrieveRequest) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(double) , PropertyapiVersion)]
        [TestCaseGeneric(typeof(string[]) , PropertypackageNames)]
        [TestCaseGeneric(typeof(bool) , PropertysinglePackage)]
        [TestCaseGeneric(typeof(string[]) , PropertyspecificFiles)]
        [TestCaseGeneric(typeof(Package) , Propertyunpackaged)]
        public void AUT_RetrieveRequest_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<RetrieveRequest, T>(_retrieveRequestInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (RetrieveRequest) => Property (apiVersion) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RetrieveRequest_Public_Class_apiVersion_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (RetrieveRequest) => Property (packageNames) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RetrieveRequest_packageNames_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertypackageNames);
            Action currentAction = () => propertyInfo.SetValue(_retrieveRequestInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RetrieveRequest) => Property (packageNames) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RetrieveRequest_Public_Class_packageNames_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypackageNames);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RetrieveRequest) => Property (singlePackage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RetrieveRequest_Public_Class_singlePackage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (RetrieveRequest) => Property (specificFiles) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RetrieveRequest_specificFiles_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyspecificFiles);
            Action currentAction = () => propertyInfo.SetValue(_retrieveRequestInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RetrieveRequest) => Property (specificFiles) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RetrieveRequest_Public_Class_specificFiles_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyspecificFiles);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RetrieveRequest) => Property (unpackaged) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RetrieveRequest_unpackaged_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyunpackaged);
            Action currentAction = () => propertyInfo.SetValue(_retrieveRequestInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RetrieveRequest) => Property (unpackaged) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RetrieveRequest_Public_Class_unpackaged_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyunpackaged);

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