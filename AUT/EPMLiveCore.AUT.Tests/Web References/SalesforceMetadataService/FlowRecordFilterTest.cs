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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowRecordFilter" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowRecordFilterTest : AbstractBaseSetupTypedTest<FlowRecordFilter>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowRecordFilter) Initializer

        private const string Propertyfield = "field";
        private const string Propertyvalue = "value";
        private const string FieldfieldField = "fieldField";
        private const string FieldoperatorField = "operatorField";
        private const string FieldvalueField = "valueField";
        private Type _flowRecordFilterInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowRecordFilter _flowRecordFilterInstance;
        private FlowRecordFilter _flowRecordFilterInstanceFixture;

        #region General Initializer : Class (FlowRecordFilter) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowRecordFilter" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowRecordFilterInstanceType = typeof(FlowRecordFilter);
            _flowRecordFilterInstanceFixture = Create(true);
            _flowRecordFilterInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowRecordFilter)

        #region General Initializer : Class (FlowRecordFilter) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowRecordFilter" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyfield)]
        [TestCase(Propertyvalue)]
        public void AUT_FlowRecordFilter_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowRecordFilterInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowRecordFilter) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowRecordFilter" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldfieldField)]
        [TestCase(FieldoperatorField)]
        [TestCase(FieldvalueField)]
        public void AUT_FlowRecordFilter_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowRecordFilterInstanceFixture, 
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
        ///     Class (<see cref="FlowRecordFilter" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowRecordFilter_Is_Instance_Present_Test()
        {
            // Assert
            _flowRecordFilterInstanceType.ShouldNotBeNull();
            _flowRecordFilterInstance.ShouldNotBeNull();
            _flowRecordFilterInstanceFixture.ShouldNotBeNull();
            _flowRecordFilterInstance.ShouldBeAssignableTo<FlowRecordFilter>();
            _flowRecordFilterInstanceFixture.ShouldBeAssignableTo<FlowRecordFilter>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowRecordFilter) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowRecordFilter_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowRecordFilter instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowRecordFilterInstanceType.ShouldNotBeNull();
            _flowRecordFilterInstance.ShouldNotBeNull();
            _flowRecordFilterInstanceFixture.ShouldNotBeNull();
            _flowRecordFilterInstance.ShouldBeAssignableTo<FlowRecordFilter>();
            _flowRecordFilterInstanceFixture.ShouldBeAssignableTo<FlowRecordFilter>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowRecordFilter) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyfield)]
        [TestCaseGeneric(typeof(FlowElementReferenceOrValue) , Propertyvalue)]
        public void AUT_FlowRecordFilter_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowRecordFilter, T>(_flowRecordFilterInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (FlowRecordFilter) => Property (field) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordFilter_Public_Class_field_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfield);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordFilter) => Property (value) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordFilter_value_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyvalue);
            Action currentAction = () => propertyInfo.SetValue(_flowRecordFilterInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordFilter) => Property (value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordFilter_Public_Class_value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyvalue);

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