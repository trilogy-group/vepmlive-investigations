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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowDynamicChoiceSet" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowDynamicChoiceSetTest : AbstractBaseSetupTypedTest<FlowDynamicChoiceSet>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowDynamicChoiceSet) Initializer

        private const string PropertydataType = "dataType";
        private const string PropertydisplayField = "displayField";
        private const string Propertyfilters = "filters";
        private const string Propertylimit = "limit";
        private const string PropertylimitSpecified = "limitSpecified";
        private const string PropertyoutputAssignments = "outputAssignments";
        private const string PropertysortField = "sortField";
        private const string PropertysortOrder = "sortOrder";
        private const string PropertysortOrderSpecified = "sortOrderSpecified";
        private const string PropertyvalueField = "valueField";
        private const string FielddataTypeField = "dataTypeField";
        private const string FielddisplayFieldField = "displayFieldField";
        private const string FieldfiltersField = "filtersField";
        private const string FieldlimitField = "limitField";
        private const string FieldlimitFieldSpecified = "limitFieldSpecified";
        private const string FieldobjectField = "objectField";
        private const string FieldoutputAssignmentsField = "outputAssignmentsField";
        private const string FieldsortFieldField = "sortFieldField";
        private const string FieldsortOrderField = "sortOrderField";
        private const string FieldsortOrderFieldSpecified = "sortOrderFieldSpecified";
        private const string FieldvalueFieldField = "valueFieldField";
        private Type _flowDynamicChoiceSetInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowDynamicChoiceSet _flowDynamicChoiceSetInstance;
        private FlowDynamicChoiceSet _flowDynamicChoiceSetInstanceFixture;

        #region General Initializer : Class (FlowDynamicChoiceSet) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowDynamicChoiceSet" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowDynamicChoiceSetInstanceType = typeof(FlowDynamicChoiceSet);
            _flowDynamicChoiceSetInstanceFixture = Create(true);
            _flowDynamicChoiceSetInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowDynamicChoiceSet)

        #region General Initializer : Class (FlowDynamicChoiceSet) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowDynamicChoiceSet" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertydataType)]
        [TestCase(PropertydisplayField)]
        [TestCase(Propertyfilters)]
        [TestCase(Propertylimit)]
        [TestCase(PropertylimitSpecified)]
        [TestCase(PropertyoutputAssignments)]
        [TestCase(PropertysortField)]
        [TestCase(PropertysortOrder)]
        [TestCase(PropertysortOrderSpecified)]
        [TestCase(PropertyvalueField)]
        public void AUT_FlowDynamicChoiceSet_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowDynamicChoiceSetInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowDynamicChoiceSet) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowDynamicChoiceSet" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddataTypeField)]
        [TestCase(FielddisplayFieldField)]
        [TestCase(FieldfiltersField)]
        [TestCase(FieldlimitField)]
        [TestCase(FieldlimitFieldSpecified)]
        [TestCase(FieldobjectField)]
        [TestCase(FieldoutputAssignmentsField)]
        [TestCase(FieldsortFieldField)]
        [TestCase(FieldsortOrderField)]
        [TestCase(FieldsortOrderFieldSpecified)]
        [TestCase(FieldvalueFieldField)]
        public void AUT_FlowDynamicChoiceSet_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowDynamicChoiceSetInstanceFixture, 
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
        ///     Class (<see cref="FlowDynamicChoiceSet" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowDynamicChoiceSet_Is_Instance_Present_Test()
        {
            // Assert
            _flowDynamicChoiceSetInstanceType.ShouldNotBeNull();
            _flowDynamicChoiceSetInstance.ShouldNotBeNull();
            _flowDynamicChoiceSetInstanceFixture.ShouldNotBeNull();
            _flowDynamicChoiceSetInstance.ShouldBeAssignableTo<FlowDynamicChoiceSet>();
            _flowDynamicChoiceSetInstanceFixture.ShouldBeAssignableTo<FlowDynamicChoiceSet>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowDynamicChoiceSet) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowDynamicChoiceSet_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowDynamicChoiceSet instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowDynamicChoiceSetInstanceType.ShouldNotBeNull();
            _flowDynamicChoiceSetInstance.ShouldNotBeNull();
            _flowDynamicChoiceSetInstanceFixture.ShouldNotBeNull();
            _flowDynamicChoiceSetInstance.ShouldBeAssignableTo<FlowDynamicChoiceSet>();
            _flowDynamicChoiceSetInstanceFixture.ShouldBeAssignableTo<FlowDynamicChoiceSet>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowDynamicChoiceSet) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(FlowDataType) , PropertydataType)]
        [TestCaseGeneric(typeof(string) , PropertydisplayField)]
        [TestCaseGeneric(typeof(FlowRecordFilter[]) , Propertyfilters)]
        [TestCaseGeneric(typeof(int) , Propertylimit)]
        [TestCaseGeneric(typeof(bool) , PropertylimitSpecified)]
        [TestCaseGeneric(typeof(FlowOutputFieldAssignment[]) , PropertyoutputAssignments)]
        [TestCaseGeneric(typeof(string) , PropertysortField)]
        [TestCaseGeneric(typeof(SortOrder) , PropertysortOrder)]
        [TestCaseGeneric(typeof(bool) , PropertysortOrderSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyvalueField)]
        public void AUT_FlowDynamicChoiceSet_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowDynamicChoiceSet, T>(_flowDynamicChoiceSetInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (FlowDynamicChoiceSet) => Property (dataType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowDynamicChoiceSet_dataType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydataType);
            Action currentAction = () => propertyInfo.SetValue(_flowDynamicChoiceSetInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowDynamicChoiceSet) => Property (dataType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowDynamicChoiceSet_Public_Class_dataType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydataType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowDynamicChoiceSet) => Property (displayField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowDynamicChoiceSet_Public_Class_displayField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydisplayField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowDynamicChoiceSet) => Property (filters) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowDynamicChoiceSet_filters_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyfilters);
            Action currentAction = () => propertyInfo.SetValue(_flowDynamicChoiceSetInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowDynamicChoiceSet) => Property (filters) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowDynamicChoiceSet_Public_Class_filters_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowDynamicChoiceSet) => Property (limit) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowDynamicChoiceSet_Public_Class_limit_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylimit);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowDynamicChoiceSet) => Property (limitSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowDynamicChoiceSet_Public_Class_limitSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylimitSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowDynamicChoiceSet) => Property (outputAssignments) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowDynamicChoiceSet_outputAssignments_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyoutputAssignments);
            Action currentAction = () => propertyInfo.SetValue(_flowDynamicChoiceSetInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowDynamicChoiceSet) => Property (outputAssignments) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowDynamicChoiceSet_Public_Class_outputAssignments_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowDynamicChoiceSet) => Property (sortField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowDynamicChoiceSet_Public_Class_sortField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowDynamicChoiceSet) => Property (sortOrder) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowDynamicChoiceSet_sortOrder_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysortOrder);
            Action currentAction = () => propertyInfo.SetValue(_flowDynamicChoiceSetInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowDynamicChoiceSet) => Property (sortOrder) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowDynamicChoiceSet_Public_Class_sortOrder_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowDynamicChoiceSet) => Property (sortOrderSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowDynamicChoiceSet_Public_Class_sortOrderSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowDynamicChoiceSet) => Property (valueField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowDynamicChoiceSet_Public_Class_valueField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyvalueField);

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