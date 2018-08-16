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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowApexPluginCallOutputParameter" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowApexPluginCallOutputParameterTest : AbstractBaseSetupTypedTest<FlowApexPluginCallOutputParameter>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowApexPluginCallOutputParameter) Initializer

        private const string PropertyassignToReference = "assignToReference";
        private const string Propertyname = "name";
        private const string FieldassignToReferenceField = "assignToReferenceField";
        private const string FieldnameField = "nameField";
        private Type _flowApexPluginCallOutputParameterInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowApexPluginCallOutputParameter _flowApexPluginCallOutputParameterInstance;
        private FlowApexPluginCallOutputParameter _flowApexPluginCallOutputParameterInstanceFixture;

        #region General Initializer : Class (FlowApexPluginCallOutputParameter) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowApexPluginCallOutputParameter" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowApexPluginCallOutputParameterInstanceType = typeof(FlowApexPluginCallOutputParameter);
            _flowApexPluginCallOutputParameterInstanceFixture = Create(true);
            _flowApexPluginCallOutputParameterInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowApexPluginCallOutputParameter)

        #region General Initializer : Class (FlowApexPluginCallOutputParameter) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowApexPluginCallOutputParameter" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyassignToReference)]
        [TestCase(Propertyname)]
        public void AUT_FlowApexPluginCallOutputParameter_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowApexPluginCallOutputParameterInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowApexPluginCallOutputParameter) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowApexPluginCallOutputParameter" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldassignToReferenceField)]
        [TestCase(FieldnameField)]
        public void AUT_FlowApexPluginCallOutputParameter_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowApexPluginCallOutputParameterInstanceFixture, 
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
        ///     Class (<see cref="FlowApexPluginCallOutputParameter" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowApexPluginCallOutputParameter_Is_Instance_Present_Test()
        {
            // Assert
            _flowApexPluginCallOutputParameterInstanceType.ShouldNotBeNull();
            _flowApexPluginCallOutputParameterInstance.ShouldNotBeNull();
            _flowApexPluginCallOutputParameterInstanceFixture.ShouldNotBeNull();
            _flowApexPluginCallOutputParameterInstance.ShouldBeAssignableTo<FlowApexPluginCallOutputParameter>();
            _flowApexPluginCallOutputParameterInstanceFixture.ShouldBeAssignableTo<FlowApexPluginCallOutputParameter>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowApexPluginCallOutputParameter) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowApexPluginCallOutputParameter_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowApexPluginCallOutputParameter instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowApexPluginCallOutputParameterInstanceType.ShouldNotBeNull();
            _flowApexPluginCallOutputParameterInstance.ShouldNotBeNull();
            _flowApexPluginCallOutputParameterInstanceFixture.ShouldNotBeNull();
            _flowApexPluginCallOutputParameterInstance.ShouldBeAssignableTo<FlowApexPluginCallOutputParameter>();
            _flowApexPluginCallOutputParameterInstanceFixture.ShouldBeAssignableTo<FlowApexPluginCallOutputParameter>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowApexPluginCallOutputParameter) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyassignToReference)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_FlowApexPluginCallOutputParameter_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowApexPluginCallOutputParameter, T>(_flowApexPluginCallOutputParameterInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowApexPluginCallOutputParameter) => Property (assignToReference) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowApexPluginCallOutputParameter_Public_Class_assignToReference_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassignToReference);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowApexPluginCallOutputParameter) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowApexPluginCallOutputParameter_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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