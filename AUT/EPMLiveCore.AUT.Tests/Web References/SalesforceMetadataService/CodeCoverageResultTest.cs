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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CodeCoverageResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CodeCoverageResultTest : AbstractBaseSetupTypedTest<CodeCoverageResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CodeCoverageResult) Initializer

        private const string PropertydmlInfo = "dmlInfo";
        private const string Propertyid = "id";
        private const string PropertylocationsNotCovered = "locationsNotCovered";
        private const string PropertymethodInfo = "methodInfo";
        private const string Propertyname = "name";
        private const string PropertynumLocations = "numLocations";
        private const string PropertynumLocationsNotCovered = "numLocationsNotCovered";
        private const string PropertysoqlInfo = "soqlInfo";
        private const string PropertysoslInfo = "soslInfo";
        private const string Propertytype = "type";
        private const string FielddmlInfoField = "dmlInfoField";
        private const string FieldidField = "idField";
        private const string FieldlocationsNotCoveredField = "locationsNotCoveredField";
        private const string FieldmethodInfoField = "methodInfoField";
        private const string FieldnameField = "nameField";
        private const string FieldnamespaceField = "namespaceField";
        private const string FieldnumLocationsField = "numLocationsField";
        private const string FieldnumLocationsNotCoveredField = "numLocationsNotCoveredField";
        private const string FieldsoqlInfoField = "soqlInfoField";
        private const string FieldsoslInfoField = "soslInfoField";
        private const string FieldtypeField = "typeField";
        private Type _codeCoverageResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CodeCoverageResult _codeCoverageResultInstance;
        private CodeCoverageResult _codeCoverageResultInstanceFixture;

        #region General Initializer : Class (CodeCoverageResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CodeCoverageResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _codeCoverageResultInstanceType = typeof(CodeCoverageResult);
            _codeCoverageResultInstanceFixture = Create(true);
            _codeCoverageResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CodeCoverageResult)

        #region General Initializer : Class (CodeCoverageResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CodeCoverageResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertydmlInfo)]
        [TestCase(Propertyid)]
        [TestCase(PropertylocationsNotCovered)]
        [TestCase(PropertymethodInfo)]
        [TestCase(Propertyname)]
        [TestCase(PropertynumLocations)]
        [TestCase(PropertynumLocationsNotCovered)]
        [TestCase(PropertysoqlInfo)]
        [TestCase(PropertysoslInfo)]
        [TestCase(Propertytype)]
        public void AUT_CodeCoverageResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_codeCoverageResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CodeCoverageResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CodeCoverageResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddmlInfoField)]
        [TestCase(FieldidField)]
        [TestCase(FieldlocationsNotCoveredField)]
        [TestCase(FieldmethodInfoField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldnamespaceField)]
        [TestCase(FieldnumLocationsField)]
        [TestCase(FieldnumLocationsNotCoveredField)]
        [TestCase(FieldsoqlInfoField)]
        [TestCase(FieldsoslInfoField)]
        [TestCase(FieldtypeField)]
        public void AUT_CodeCoverageResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_codeCoverageResultInstanceFixture, 
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
        ///     Class (<see cref="CodeCoverageResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CodeCoverageResult_Is_Instance_Present_Test()
        {
            // Assert
            _codeCoverageResultInstanceType.ShouldNotBeNull();
            _codeCoverageResultInstance.ShouldNotBeNull();
            _codeCoverageResultInstanceFixture.ShouldNotBeNull();
            _codeCoverageResultInstance.ShouldBeAssignableTo<CodeCoverageResult>();
            _codeCoverageResultInstanceFixture.ShouldBeAssignableTo<CodeCoverageResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CodeCoverageResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CodeCoverageResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CodeCoverageResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _codeCoverageResultInstanceType.ShouldNotBeNull();
            _codeCoverageResultInstance.ShouldNotBeNull();
            _codeCoverageResultInstanceFixture.ShouldNotBeNull();
            _codeCoverageResultInstance.ShouldBeAssignableTo<CodeCoverageResult>();
            _codeCoverageResultInstanceFixture.ShouldBeAssignableTo<CodeCoverageResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CodeCoverageResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(CodeLocation[]) , PropertydmlInfo)]
        [TestCaseGeneric(typeof(string) , Propertyid)]
        [TestCaseGeneric(typeof(CodeLocation[]) , PropertylocationsNotCovered)]
        [TestCaseGeneric(typeof(CodeLocation[]) , PropertymethodInfo)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(int) , PropertynumLocations)]
        [TestCaseGeneric(typeof(int) , PropertynumLocationsNotCovered)]
        [TestCaseGeneric(typeof(CodeLocation[]) , PropertysoqlInfo)]
        [TestCaseGeneric(typeof(CodeLocation[]) , PropertysoslInfo)]
        [TestCaseGeneric(typeof(string) , Propertytype)]
        public void AUT_CodeCoverageResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CodeCoverageResult, T>(_codeCoverageResultInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (CodeCoverageResult) => Property (dmlInfo) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CodeCoverageResult_dmlInfo_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydmlInfo);
            Action currentAction = () => propertyInfo.SetValue(_codeCoverageResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CodeCoverageResult) => Property (dmlInfo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CodeCoverageResult_Public_Class_dmlInfo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydmlInfo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CodeCoverageResult) => Property (id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CodeCoverageResult_Public_Class_id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyid);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CodeCoverageResult) => Property (locationsNotCovered) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CodeCoverageResult_locationsNotCovered_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertylocationsNotCovered);
            Action currentAction = () => propertyInfo.SetValue(_codeCoverageResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CodeCoverageResult) => Property (locationsNotCovered) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CodeCoverageResult_Public_Class_locationsNotCovered_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylocationsNotCovered);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CodeCoverageResult) => Property (methodInfo) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CodeCoverageResult_methodInfo_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertymethodInfo);
            Action currentAction = () => propertyInfo.SetValue(_codeCoverageResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CodeCoverageResult) => Property (methodInfo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CodeCoverageResult_Public_Class_methodInfo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymethodInfo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CodeCoverageResult) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CodeCoverageResult_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CodeCoverageResult) => Property (numLocations) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CodeCoverageResult_Public_Class_numLocations_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynumLocations);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CodeCoverageResult) => Property (numLocationsNotCovered) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CodeCoverageResult_Public_Class_numLocationsNotCovered_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynumLocationsNotCovered);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CodeCoverageResult) => Property (soqlInfo) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CodeCoverageResult_soqlInfo_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysoqlInfo);
            Action currentAction = () => propertyInfo.SetValue(_codeCoverageResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CodeCoverageResult) => Property (soqlInfo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CodeCoverageResult_Public_Class_soqlInfo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysoqlInfo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CodeCoverageResult) => Property (soslInfo) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CodeCoverageResult_soslInfo_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysoslInfo);
            Action currentAction = () => propertyInfo.SetValue(_codeCoverageResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CodeCoverageResult) => Property (soslInfo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CodeCoverageResult_Public_Class_soslInfo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysoslInfo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CodeCoverageResult) => Property (type) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CodeCoverageResult_Public_Class_type_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytype);

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