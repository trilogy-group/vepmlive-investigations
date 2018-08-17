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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.State" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class StateTest : AbstractBaseSetupTypedTest<State>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (State) Initializer

        private const string Propertyactive = "active";
        private const string PropertyintegrationValue = "integrationValue";
        private const string PropertyisoCode = "isoCode";
        private const string Propertylabel = "label";
        private const string FieldactiveField = "activeField";
        private const string FieldintegrationValueField = "integrationValueField";
        private const string FieldisoCodeField = "isoCodeField";
        private const string FieldlabelField = "labelField";
        private Type _stateInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private State _stateInstance;
        private State _stateInstanceFixture;

        #region General Initializer : Class (State) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="State" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _stateInstanceType = typeof(State);
            _stateInstanceFixture = Create(true);
            _stateInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (State)

        #region General Initializer : Class (State) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="State" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyactive)]
        [TestCase(PropertyintegrationValue)]
        [TestCase(PropertyisoCode)]
        [TestCase(Propertylabel)]
        public void AUT_State_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_stateInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (State) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="State" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldactiveField)]
        [TestCase(FieldintegrationValueField)]
        [TestCase(FieldisoCodeField)]
        [TestCase(FieldlabelField)]
        public void AUT_State_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_stateInstanceFixture, 
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
        ///     Class (<see cref="State" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_State_Is_Instance_Present_Test()
        {
            // Assert
            _stateInstanceType.ShouldNotBeNull();
            _stateInstance.ShouldNotBeNull();
            _stateInstanceFixture.ShouldNotBeNull();
            _stateInstance.ShouldBeAssignableTo<State>();
            _stateInstanceFixture.ShouldBeAssignableTo<State>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (State) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_State_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            State instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _stateInstanceType.ShouldNotBeNull();
            _stateInstance.ShouldNotBeNull();
            _stateInstanceFixture.ShouldNotBeNull();
            _stateInstance.ShouldBeAssignableTo<State>();
            _stateInstanceFixture.ShouldBeAssignableTo<State>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (State) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , Propertyactive)]
        [TestCaseGeneric(typeof(string) , PropertyintegrationValue)]
        [TestCaseGeneric(typeof(string) , PropertyisoCode)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        public void AUT_State_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<State, T>(_stateInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (State) => Property (active) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_State_Public_Class_active_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyactive);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (State) => Property (integrationValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_State_Public_Class_integrationValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyintegrationValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (State) => Property (isoCode) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_State_Public_Class_isoCode_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisoCode);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (State) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_State_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}