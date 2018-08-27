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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowNode" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowNodeTest : AbstractBaseSetupTypedTest<FlowNode>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowNode) Initializer

        private const string Propertylabel = "label";
        private const string PropertylocationX = "locationX";
        private const string PropertylocationY = "locationY";
        private const string FieldlabelField = "labelField";
        private const string FieldlocationXField = "locationXField";
        private const string FieldlocationYField = "locationYField";
        private Type _flowNodeInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowNode _flowNodeInstance;
        private FlowNode _flowNodeInstanceFixture;

        #region General Initializer : Class (FlowNode) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowNode" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowNodeInstanceType = typeof(FlowNode);
            _flowNodeInstanceFixture = Create(true);
            _flowNodeInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowNode)

        #region General Initializer : Class (FlowNode) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowNode" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertylabel)]
        [TestCase(PropertylocationX)]
        [TestCase(PropertylocationY)]
        public void AUT_FlowNode_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowNodeInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowNode) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowNode" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldlabelField)]
        [TestCase(FieldlocationXField)]
        [TestCase(FieldlocationYField)]
        public void AUT_FlowNode_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowNodeInstanceFixture, 
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
        ///     Class (<see cref="FlowNode" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowNode_Is_Instance_Present_Test()
        {
            // Assert
            _flowNodeInstanceType.ShouldNotBeNull();
            _flowNodeInstance.ShouldNotBeNull();
            _flowNodeInstanceFixture.ShouldNotBeNull();
            _flowNodeInstance.ShouldBeAssignableTo<FlowNode>();
            _flowNodeInstanceFixture.ShouldBeAssignableTo<FlowNode>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowNode) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowNode_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowNode instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowNodeInstanceType.ShouldNotBeNull();
            _flowNodeInstance.ShouldNotBeNull();
            _flowNodeInstanceFixture.ShouldNotBeNull();
            _flowNodeInstance.ShouldBeAssignableTo<FlowNode>();
            _flowNodeInstanceFixture.ShouldBeAssignableTo<FlowNode>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowNode) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(int) , PropertylocationX)]
        [TestCaseGeneric(typeof(int) , PropertylocationY)]
        public void AUT_FlowNode_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowNode, T>(_flowNodeInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowNode) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowNode_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowNode) => Property (locationX) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowNode_Public_Class_locationX_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylocationX);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowNode) => Property (locationY) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowNode_Public_Class_locationY_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylocationY);

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