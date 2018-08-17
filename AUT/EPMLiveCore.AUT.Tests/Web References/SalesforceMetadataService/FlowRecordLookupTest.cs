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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowRecordLookup" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowRecordLookupTest : AbstractBaseSetupTypedTest<FlowRecordLookup>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowRecordLookup) Initializer

        private const string Propertyconnector = "connector";
        private const string PropertyfaultConnector = "faultConnector";
        private const string Propertyfilters = "filters";
        private const string PropertyoutputAssignments = "outputAssignments";
        private const string PropertysortField = "sortField";
        private const string PropertysortOrder = "sortOrder";
        private const string PropertysortOrderSpecified = "sortOrderSpecified";
        private const string FieldconnectorField = "connectorField";
        private const string FieldfaultConnectorField = "faultConnectorField";
        private const string FieldfiltersField = "filtersField";
        private const string FieldobjectField = "objectField";
        private const string FieldoutputAssignmentsField = "outputAssignmentsField";
        private const string FieldsortFieldField = "sortFieldField";
        private const string FieldsortOrderField = "sortOrderField";
        private const string FieldsortOrderFieldSpecified = "sortOrderFieldSpecified";
        private Type _flowRecordLookupInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowRecordLookup _flowRecordLookupInstance;
        private FlowRecordLookup _flowRecordLookupInstanceFixture;

        #region General Initializer : Class (FlowRecordLookup) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowRecordLookup" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowRecordLookupInstanceType = typeof(FlowRecordLookup);
            _flowRecordLookupInstanceFixture = Create(true);
            _flowRecordLookupInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowRecordLookup)

        #region General Initializer : Class (FlowRecordLookup) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowRecordLookup" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyconnector)]
        [TestCase(PropertyfaultConnector)]
        [TestCase(Propertyfilters)]
        [TestCase(PropertyoutputAssignments)]
        [TestCase(PropertysortField)]
        [TestCase(PropertysortOrder)]
        [TestCase(PropertysortOrderSpecified)]
        public void AUT_FlowRecordLookup_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowRecordLookupInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowRecordLookup) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowRecordLookup" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldconnectorField)]
        [TestCase(FieldfaultConnectorField)]
        [TestCase(FieldfiltersField)]
        [TestCase(FieldobjectField)]
        [TestCase(FieldoutputAssignmentsField)]
        [TestCase(FieldsortFieldField)]
        [TestCase(FieldsortOrderField)]
        [TestCase(FieldsortOrderFieldSpecified)]
        public void AUT_FlowRecordLookup_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowRecordLookupInstanceFixture, 
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
        ///     Class (<see cref="FlowRecordLookup" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowRecordLookup_Is_Instance_Present_Test()
        {
            // Assert
            _flowRecordLookupInstanceType.ShouldNotBeNull();
            _flowRecordLookupInstance.ShouldNotBeNull();
            _flowRecordLookupInstanceFixture.ShouldNotBeNull();
            _flowRecordLookupInstance.ShouldBeAssignableTo<FlowRecordLookup>();
            _flowRecordLookupInstanceFixture.ShouldBeAssignableTo<FlowRecordLookup>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowRecordLookup) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowRecordLookup_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowRecordLookup instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowRecordLookupInstanceType.ShouldNotBeNull();
            _flowRecordLookupInstance.ShouldNotBeNull();
            _flowRecordLookupInstanceFixture.ShouldNotBeNull();
            _flowRecordLookupInstance.ShouldBeAssignableTo<FlowRecordLookup>();
            _flowRecordLookupInstanceFixture.ShouldBeAssignableTo<FlowRecordLookup>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowRecordLookup) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(FlowConnector) , Propertyconnector)]
        [TestCaseGeneric(typeof(FlowConnector) , PropertyfaultConnector)]
        [TestCaseGeneric(typeof(FlowRecordFilter[]) , Propertyfilters)]
        [TestCaseGeneric(typeof(FlowOutputFieldAssignment[]) , PropertyoutputAssignments)]
        [TestCaseGeneric(typeof(string) , PropertysortField)]
        [TestCaseGeneric(typeof(SortOrder) , PropertysortOrder)]
        [TestCaseGeneric(typeof(bool) , PropertysortOrderSpecified)]
        public void AUT_FlowRecordLookup_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowRecordLookup, T>(_flowRecordLookupInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (FlowRecordLookup) => Property (connector) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordLookup_connector_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyconnector);
            Action currentAction = () => propertyInfo.SetValue(_flowRecordLookupInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordLookup) => Property (connector) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordLookup_Public_Class_connector_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyconnector);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordLookup) => Property (faultConnector) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordLookup_faultConnector_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyfaultConnector);
            Action currentAction = () => propertyInfo.SetValue(_flowRecordLookupInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordLookup) => Property (faultConnector) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordLookup_Public_Class_faultConnector_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfaultConnector);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordLookup) => Property (filters) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordLookup_filters_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyfilters);
            Action currentAction = () => propertyInfo.SetValue(_flowRecordLookupInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordLookup) => Property (filters) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordLookup_Public_Class_filters_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfilters);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordLookup) => Property (outputAssignments) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordLookup_outputAssignments_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyoutputAssignments);
            Action currentAction = () => propertyInfo.SetValue(_flowRecordLookupInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordLookup) => Property (outputAssignments) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordLookup_Public_Class_outputAssignments_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyoutputAssignments);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordLookup) => Property (sortField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordLookup_Public_Class_sortField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysortField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordLookup) => Property (sortOrder) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordLookup_sortOrder_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysortOrder);
            Action currentAction = () => propertyInfo.SetValue(_flowRecordLookupInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordLookup) => Property (sortOrder) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordLookup_Public_Class_sortOrder_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysortOrder);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordLookup) => Property (sortOrderSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordLookup_Public_Class_sortOrderSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysortOrderSpecified);

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