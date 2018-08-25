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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ListViewFilter" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ListViewFilterTest : AbstractBaseSetupTypedTest<ListViewFilter>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ListViewFilter) Initializer

        private const string Propertyfield = "field";
        private const string Propertyoperation = "operation";
        private const string Propertyvalue = "value";
        private const string FieldfieldField = "fieldField";
        private const string FieldoperationField = "operationField";
        private const string FieldvalueField = "valueField";
        private Type _listViewFilterInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ListViewFilter _listViewFilterInstance;
        private ListViewFilter _listViewFilterInstanceFixture;

        #region General Initializer : Class (ListViewFilter) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ListViewFilter" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _listViewFilterInstanceType = typeof(ListViewFilter);
            _listViewFilterInstanceFixture = Create(true);
            _listViewFilterInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ListViewFilter)

        #region General Initializer : Class (ListViewFilter) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ListViewFilter" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyfield)]
        [TestCase(Propertyoperation)]
        [TestCase(Propertyvalue)]
        public void AUT_ListViewFilter_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_listViewFilterInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ListViewFilter) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ListViewFilter" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldfieldField)]
        [TestCase(FieldoperationField)]
        [TestCase(FieldvalueField)]
        public void AUT_ListViewFilter_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_listViewFilterInstanceFixture, 
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
        ///     Class (<see cref="ListViewFilter" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ListViewFilter_Is_Instance_Present_Test()
        {
            // Assert
            _listViewFilterInstanceType.ShouldNotBeNull();
            _listViewFilterInstance.ShouldNotBeNull();
            _listViewFilterInstanceFixture.ShouldNotBeNull();
            _listViewFilterInstance.ShouldBeAssignableTo<ListViewFilter>();
            _listViewFilterInstanceFixture.ShouldBeAssignableTo<ListViewFilter>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ListViewFilter) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ListViewFilter_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ListViewFilter instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _listViewFilterInstanceType.ShouldNotBeNull();
            _listViewFilterInstance.ShouldNotBeNull();
            _listViewFilterInstanceFixture.ShouldNotBeNull();
            _listViewFilterInstance.ShouldBeAssignableTo<ListViewFilter>();
            _listViewFilterInstanceFixture.ShouldBeAssignableTo<ListViewFilter>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ListViewFilter) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyfield)]
        [TestCaseGeneric(typeof(FilterOperation) , Propertyoperation)]
        [TestCaseGeneric(typeof(string) , Propertyvalue)]
        public void AUT_ListViewFilter_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ListViewFilter, T>(_listViewFilterInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ListViewFilter) => Property (field) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListViewFilter_Public_Class_field_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ListViewFilter) => Property (operation) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListViewFilter_operation_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyoperation);
            Action currentAction = () => propertyInfo.SetValue(_listViewFilterInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ListViewFilter) => Property (operation) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListViewFilter_Public_Class_operation_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyoperation);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ListViewFilter) => Property (value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListViewFilter_Public_Class_value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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