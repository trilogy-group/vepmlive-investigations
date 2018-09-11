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

namespace EPMLiveWebParts.SSRS2005
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2005.ModelDrillthroughReport" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2005"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ModelDrillthroughReportTest : AbstractBaseSetupTypedTest<ModelDrillthroughReport>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ModelDrillthroughReport) Initializer

        private const string PropertyPath = "Path";
        private const string PropertyType = "Type";
        private const string FieldpathField = "pathField";
        private const string FieldtypeField = "typeField";
        private Type _modelDrillthroughReportInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ModelDrillthroughReport _modelDrillthroughReportInstance;
        private ModelDrillthroughReport _modelDrillthroughReportInstanceFixture;

        #region General Initializer : Class (ModelDrillthroughReport) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ModelDrillthroughReport" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _modelDrillthroughReportInstanceType = typeof(ModelDrillthroughReport);
            _modelDrillthroughReportInstanceFixture = Create(true);
            _modelDrillthroughReportInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ModelDrillthroughReport)

        #region General Initializer : Class (ModelDrillthroughReport) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ModelDrillthroughReport" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyPath)]
        [TestCase(PropertyType)]
        public void AUT_ModelDrillthroughReport_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_modelDrillthroughReportInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ModelDrillthroughReport) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ModelDrillthroughReport" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldpathField)]
        [TestCase(FieldtypeField)]
        public void AUT_ModelDrillthroughReport_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_modelDrillthroughReportInstanceFixture, 
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
        ///     Class (<see cref="ModelDrillthroughReport" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ModelDrillthroughReport_Is_Instance_Present_Test()
        {
            // Assert
            _modelDrillthroughReportInstanceType.ShouldNotBeNull();
            _modelDrillthroughReportInstance.ShouldNotBeNull();
            _modelDrillthroughReportInstanceFixture.ShouldNotBeNull();
            _modelDrillthroughReportInstance.ShouldBeAssignableTo<ModelDrillthroughReport>();
            _modelDrillthroughReportInstanceFixture.ShouldBeAssignableTo<ModelDrillthroughReport>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ModelDrillthroughReport) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ModelDrillthroughReport_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ModelDrillthroughReport instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _modelDrillthroughReportInstanceType.ShouldNotBeNull();
            _modelDrillthroughReportInstance.ShouldNotBeNull();
            _modelDrillthroughReportInstanceFixture.ShouldNotBeNull();
            _modelDrillthroughReportInstance.ShouldBeAssignableTo<ModelDrillthroughReport>();
            _modelDrillthroughReportInstanceFixture.ShouldBeAssignableTo<ModelDrillthroughReport>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ModelDrillthroughReport) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyPath)]
        [TestCaseGeneric(typeof(DrillthroughType) , PropertyType)]
        public void AUT_ModelDrillthroughReport_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ModelDrillthroughReport, T>(_modelDrillthroughReportInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ModelDrillthroughReport) => Property (Path) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ModelDrillthroughReport_Public_Class_Path_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPath);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ModelDrillthroughReport) => Property (Type) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ModelDrillthroughReport_Type_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyType);
            Action currentAction = () => propertyInfo.SetValue(_modelDrillthroughReportInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ModelDrillthroughReport) => Property (Type) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ModelDrillthroughReport_Public_Class_Type_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyType);

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