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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.EntitlementTemplate" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EntitlementTemplateTest : AbstractBaseSetupTypedTest<EntitlementTemplate>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EntitlementTemplate) Initializer

        private const string PropertybusinessHours = "businessHours";
        private const string PropertycasesPerEntitlement = "casesPerEntitlement";
        private const string PropertycasesPerEntitlementSpecified = "casesPerEntitlementSpecified";
        private const string PropertyentitlementProcess = "entitlementProcess";
        private const string PropertyisPerIncident = "isPerIncident";
        private const string PropertyisPerIncidentSpecified = "isPerIncidentSpecified";
        private const string Propertyterm = "term";
        private const string PropertytermSpecified = "termSpecified";
        private const string Propertytype = "type";
        private const string FieldbusinessHoursField = "businessHoursField";
        private const string FieldcasesPerEntitlementField = "casesPerEntitlementField";
        private const string FieldcasesPerEntitlementFieldSpecified = "casesPerEntitlementFieldSpecified";
        private const string FieldentitlementProcessField = "entitlementProcessField";
        private const string FieldisPerIncidentField = "isPerIncidentField";
        private const string FieldisPerIncidentFieldSpecified = "isPerIncidentFieldSpecified";
        private const string FieldtermField = "termField";
        private const string FieldtermFieldSpecified = "termFieldSpecified";
        private const string FieldtypeField = "typeField";
        private Type _entitlementTemplateInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EntitlementTemplate _entitlementTemplateInstance;
        private EntitlementTemplate _entitlementTemplateInstanceFixture;

        #region General Initializer : Class (EntitlementTemplate) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EntitlementTemplate" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _entitlementTemplateInstanceType = typeof(EntitlementTemplate);
            _entitlementTemplateInstanceFixture = Create(true);
            _entitlementTemplateInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EntitlementTemplate)

        #region General Initializer : Class (EntitlementTemplate) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EntitlementTemplate" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertybusinessHours)]
        [TestCase(PropertycasesPerEntitlement)]
        [TestCase(PropertycasesPerEntitlementSpecified)]
        [TestCase(PropertyentitlementProcess)]
        [TestCase(PropertyisPerIncident)]
        [TestCase(PropertyisPerIncidentSpecified)]
        [TestCase(Propertyterm)]
        [TestCase(PropertytermSpecified)]
        [TestCase(Propertytype)]
        public void AUT_EntitlementTemplate_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_entitlementTemplateInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EntitlementTemplate) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EntitlementTemplate" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldbusinessHoursField)]
        [TestCase(FieldcasesPerEntitlementField)]
        [TestCase(FieldcasesPerEntitlementFieldSpecified)]
        [TestCase(FieldentitlementProcessField)]
        [TestCase(FieldisPerIncidentField)]
        [TestCase(FieldisPerIncidentFieldSpecified)]
        [TestCase(FieldtermField)]
        [TestCase(FieldtermFieldSpecified)]
        [TestCase(FieldtypeField)]
        public void AUT_EntitlementTemplate_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_entitlementTemplateInstanceFixture, 
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
        ///     Class (<see cref="EntitlementTemplate" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_EntitlementTemplate_Is_Instance_Present_Test()
        {
            // Assert
            _entitlementTemplateInstanceType.ShouldNotBeNull();
            _entitlementTemplateInstance.ShouldNotBeNull();
            _entitlementTemplateInstanceFixture.ShouldNotBeNull();
            _entitlementTemplateInstance.ShouldBeAssignableTo<EntitlementTemplate>();
            _entitlementTemplateInstanceFixture.ShouldBeAssignableTo<EntitlementTemplate>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EntitlementTemplate) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_EntitlementTemplate_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EntitlementTemplate instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _entitlementTemplateInstanceType.ShouldNotBeNull();
            _entitlementTemplateInstance.ShouldNotBeNull();
            _entitlementTemplateInstanceFixture.ShouldNotBeNull();
            _entitlementTemplateInstance.ShouldBeAssignableTo<EntitlementTemplate>();
            _entitlementTemplateInstanceFixture.ShouldBeAssignableTo<EntitlementTemplate>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (EntitlementTemplate) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertybusinessHours)]
        [TestCaseGeneric(typeof(int) , PropertycasesPerEntitlement)]
        [TestCaseGeneric(typeof(bool) , PropertycasesPerEntitlementSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyentitlementProcess)]
        [TestCaseGeneric(typeof(bool) , PropertyisPerIncident)]
        [TestCaseGeneric(typeof(bool) , PropertyisPerIncidentSpecified)]
        [TestCaseGeneric(typeof(int) , Propertyterm)]
        [TestCaseGeneric(typeof(bool) , PropertytermSpecified)]
        [TestCaseGeneric(typeof(string) , Propertytype)]
        public void AUT_EntitlementTemplate_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<EntitlementTemplate, T>(_entitlementTemplateInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementTemplate) => Property (businessHours) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementTemplate_Public_Class_businessHours_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybusinessHours);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementTemplate) => Property (casesPerEntitlement) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementTemplate_Public_Class_casesPerEntitlement_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycasesPerEntitlement);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementTemplate) => Property (casesPerEntitlementSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementTemplate_Public_Class_casesPerEntitlementSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycasesPerEntitlementSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementTemplate) => Property (entitlementProcess) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementTemplate_Public_Class_entitlementProcess_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyentitlementProcess);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementTemplate) => Property (isPerIncident) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementTemplate_Public_Class_isPerIncident_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisPerIncident);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementTemplate) => Property (isPerIncidentSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementTemplate_Public_Class_isPerIncidentSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisPerIncidentSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementTemplate) => Property (term) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementTemplate_Public_Class_term_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyterm);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementTemplate) => Property (termSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementTemplate_Public_Class_termSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytermSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementTemplate) => Property (type) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementTemplate_Public_Class_type_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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