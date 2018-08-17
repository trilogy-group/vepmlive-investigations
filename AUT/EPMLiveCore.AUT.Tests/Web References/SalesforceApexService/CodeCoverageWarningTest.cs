using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.SalesforceApexService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceApexService.CodeCoverageWarning" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceApexService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CodeCoverageWarningTest : AbstractBaseSetupTypedTest<CodeCoverageWarning>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CodeCoverageWarning) Initializer

        private const string Propertyid = "id";
        private const string Propertymessage = "message";
        private const string Propertyname = "name";
        private const string Propertyanamespace = "@namespace";
        private const string FieldidField = "idField";
        private const string FieldmessageField = "messageField";
        private const string FieldnameField = "nameField";
        private const string FieldnamespaceField = "namespaceField";
        private Type _codeCoverageWarningInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CodeCoverageWarning _codeCoverageWarningInstance;
        private CodeCoverageWarning _codeCoverageWarningInstanceFixture;

        #region General Initializer : Class (CodeCoverageWarning) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CodeCoverageWarning" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _codeCoverageWarningInstanceType = typeof(CodeCoverageWarning);
            _codeCoverageWarningInstanceFixture = Create(true);
            _codeCoverageWarningInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CodeCoverageWarning)

        #region General Initializer : Class (CodeCoverageWarning) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CodeCoverageWarning" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyid)]
        [TestCase(Propertymessage)]
        [TestCase(Propertyname)]
        public void AUT_CodeCoverageWarning_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_codeCoverageWarningInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CodeCoverageWarning) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CodeCoverageWarning" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldidField)]
        [TestCase(FieldmessageField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldnamespaceField)]
        public void AUT_CodeCoverageWarning_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_codeCoverageWarningInstanceFixture, 
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
        ///     Class (<see cref="CodeCoverageWarning" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CodeCoverageWarning_Is_Instance_Present_Test()
        {
            // Assert
            _codeCoverageWarningInstanceType.ShouldNotBeNull();
            _codeCoverageWarningInstance.ShouldNotBeNull();
            _codeCoverageWarningInstanceFixture.ShouldNotBeNull();
            _codeCoverageWarningInstance.ShouldBeAssignableTo<CodeCoverageWarning>();
            _codeCoverageWarningInstanceFixture.ShouldBeAssignableTo<CodeCoverageWarning>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CodeCoverageWarning) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CodeCoverageWarning_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CodeCoverageWarning instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _codeCoverageWarningInstanceType.ShouldNotBeNull();
            _codeCoverageWarningInstance.ShouldNotBeNull();
            _codeCoverageWarningInstanceFixture.ShouldNotBeNull();
            _codeCoverageWarningInstance.ShouldBeAssignableTo<CodeCoverageWarning>();
            _codeCoverageWarningInstanceFixture.ShouldBeAssignableTo<CodeCoverageWarning>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CodeCoverageWarning) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyid)]
        [TestCaseGeneric(typeof(string) , Propertymessage)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_CodeCoverageWarning_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CodeCoverageWarning, T>(_codeCoverageWarningInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (CodeCoverageWarning) => Property (id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CodeCoverageWarning_Public_Class_id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CodeCoverageWarning) => Property (message) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CodeCoverageWarning_Public_Class_message_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertymessage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CodeCoverageWarning) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CodeCoverageWarning_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}