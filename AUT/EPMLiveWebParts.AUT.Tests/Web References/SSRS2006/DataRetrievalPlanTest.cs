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

namespace EPMLiveWebParts.SSRS2006
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2006.DataRetrievalPlan" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2006"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DataRetrievalPlanTest : AbstractBaseSetupTypedTest<DataRetrievalPlan>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DataRetrievalPlan) Initializer

        private const string PropertyItem = "Item";
        private const string PropertyDataSet = "DataSet";
        private const string FielditemField = "itemField";
        private const string FielddataSetField = "dataSetField";
        private Type _dataRetrievalPlanInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DataRetrievalPlan _dataRetrievalPlanInstance;
        private DataRetrievalPlan _dataRetrievalPlanInstanceFixture;

        #region General Initializer : Class (DataRetrievalPlan) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DataRetrievalPlan" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dataRetrievalPlanInstanceType = typeof(DataRetrievalPlan);
            _dataRetrievalPlanInstanceFixture = Create(true);
            _dataRetrievalPlanInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DataRetrievalPlan)

        #region General Initializer : Class (DataRetrievalPlan) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DataRetrievalPlan" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyItem)]
        [TestCase(PropertyDataSet)]
        public void AUT_DataRetrievalPlan_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_dataRetrievalPlanInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DataRetrievalPlan) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DataRetrievalPlan" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielditemField)]
        [TestCase(FielddataSetField)]
        public void AUT_DataRetrievalPlan_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_dataRetrievalPlanInstanceFixture, 
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
        ///     Class (<see cref="DataRetrievalPlan" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DataRetrievalPlan_Is_Instance_Present_Test()
        {
            // Assert
            _dataRetrievalPlanInstanceType.ShouldNotBeNull();
            _dataRetrievalPlanInstance.ShouldNotBeNull();
            _dataRetrievalPlanInstanceFixture.ShouldNotBeNull();
            _dataRetrievalPlanInstance.ShouldBeAssignableTo<DataRetrievalPlan>();
            _dataRetrievalPlanInstanceFixture.ShouldBeAssignableTo<DataRetrievalPlan>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DataRetrievalPlan) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DataRetrievalPlan_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DataRetrievalPlan instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dataRetrievalPlanInstanceType.ShouldNotBeNull();
            _dataRetrievalPlanInstance.ShouldNotBeNull();
            _dataRetrievalPlanInstanceFixture.ShouldNotBeNull();
            _dataRetrievalPlanInstance.ShouldBeAssignableTo<DataRetrievalPlan>();
            _dataRetrievalPlanInstanceFixture.ShouldBeAssignableTo<DataRetrievalPlan>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DataRetrievalPlan) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(DataSourceDefinitionOrReference) , PropertyItem)]
        [TestCaseGeneric(typeof(DataSetDefinition) , PropertyDataSet)]
        public void AUT_DataRetrievalPlan_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DataRetrievalPlan, T>(_dataRetrievalPlanInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DataRetrievalPlan) => Property (DataSet) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataRetrievalPlan_DataSet_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyDataSet);
            Action currentAction = () => propertyInfo.SetValue(_dataRetrievalPlanInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DataRetrievalPlan) => Property (DataSet) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataRetrievalPlan_Public_Class_DataSet_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDataSet);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataRetrievalPlan) => Property (Item) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataRetrievalPlan_Item_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyItem);
            Action currentAction = () => propertyInfo.SetValue(_dataRetrievalPlanInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DataRetrievalPlan) => Property (Item) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataRetrievalPlan_Public_Class_Item_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyItem);

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