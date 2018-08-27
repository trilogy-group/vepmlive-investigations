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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowTextTemplate" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowTextTemplateTest : AbstractBaseSetupTypedTest<FlowTextTemplate>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowTextTemplate) Initializer

        private const string Propertytext = "text";
        private const string FieldtextField = "textField";
        private Type _flowTextTemplateInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowTextTemplate _flowTextTemplateInstance;
        private FlowTextTemplate _flowTextTemplateInstanceFixture;

        #region General Initializer : Class (FlowTextTemplate) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowTextTemplate" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowTextTemplateInstanceType = typeof(FlowTextTemplate);
            _flowTextTemplateInstanceFixture = Create(true);
            _flowTextTemplateInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowTextTemplate)

        #region General Initializer : Class (FlowTextTemplate) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowTextTemplate" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertytext)]
        public void AUT_FlowTextTemplate_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowTextTemplateInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowTextTemplate) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowTextTemplate" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldtextField)]
        public void AUT_FlowTextTemplate_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowTextTemplateInstanceFixture, 
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
        ///     Class (<see cref="FlowTextTemplate" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowTextTemplate_Is_Instance_Present_Test()
        {
            // Assert
            _flowTextTemplateInstanceType.ShouldNotBeNull();
            _flowTextTemplateInstance.ShouldNotBeNull();
            _flowTextTemplateInstanceFixture.ShouldNotBeNull();
            _flowTextTemplateInstance.ShouldBeAssignableTo<FlowTextTemplate>();
            _flowTextTemplateInstanceFixture.ShouldBeAssignableTo<FlowTextTemplate>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowTextTemplate) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowTextTemplate_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowTextTemplate instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowTextTemplateInstanceType.ShouldNotBeNull();
            _flowTextTemplateInstance.ShouldNotBeNull();
            _flowTextTemplateInstanceFixture.ShouldNotBeNull();
            _flowTextTemplateInstance.ShouldBeAssignableTo<FlowTextTemplate>();
            _flowTextTemplateInstanceFixture.ShouldBeAssignableTo<FlowTextTemplate>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowTextTemplate) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertytext)]
        public void AUT_FlowTextTemplate_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowTextTemplate, T>(_flowTextTemplateInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowTextTemplate) => Property (text) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowTextTemplate_Public_Class_text_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytext);

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