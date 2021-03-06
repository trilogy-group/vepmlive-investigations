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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ChatterAnswersReputationLevel" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ChatterAnswersReputationLevelTest : AbstractBaseSetupTypedTest<ChatterAnswersReputationLevel>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ChatterAnswersReputationLevel) Initializer

        private const string Propertyname = "name";
        private const string Propertyvalue = "value";
        private const string FieldnameField = "nameField";
        private const string FieldvalueField = "valueField";
        private Type _chatterAnswersReputationLevelInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ChatterAnswersReputationLevel _chatterAnswersReputationLevelInstance;
        private ChatterAnswersReputationLevel _chatterAnswersReputationLevelInstanceFixture;

        #region General Initializer : Class (ChatterAnswersReputationLevel) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ChatterAnswersReputationLevel" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _chatterAnswersReputationLevelInstanceType = typeof(ChatterAnswersReputationLevel);
            _chatterAnswersReputationLevelInstanceFixture = Create(true);
            _chatterAnswersReputationLevelInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ChatterAnswersReputationLevel)

        #region General Initializer : Class (ChatterAnswersReputationLevel) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ChatterAnswersReputationLevel" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyname)]
        [TestCase(Propertyvalue)]
        public void AUT_ChatterAnswersReputationLevel_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_chatterAnswersReputationLevelInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ChatterAnswersReputationLevel) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ChatterAnswersReputationLevel" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldnameField)]
        [TestCase(FieldvalueField)]
        public void AUT_ChatterAnswersReputationLevel_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_chatterAnswersReputationLevelInstanceFixture, 
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
        ///     Class (<see cref="ChatterAnswersReputationLevel" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ChatterAnswersReputationLevel_Is_Instance_Present_Test()
        {
            // Assert
            _chatterAnswersReputationLevelInstanceType.ShouldNotBeNull();
            _chatterAnswersReputationLevelInstance.ShouldNotBeNull();
            _chatterAnswersReputationLevelInstanceFixture.ShouldNotBeNull();
            _chatterAnswersReputationLevelInstance.ShouldBeAssignableTo<ChatterAnswersReputationLevel>();
            _chatterAnswersReputationLevelInstanceFixture.ShouldBeAssignableTo<ChatterAnswersReputationLevel>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ChatterAnswersReputationLevel) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ChatterAnswersReputationLevel_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ChatterAnswersReputationLevel instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _chatterAnswersReputationLevelInstanceType.ShouldNotBeNull();
            _chatterAnswersReputationLevelInstance.ShouldNotBeNull();
            _chatterAnswersReputationLevelInstanceFixture.ShouldNotBeNull();
            _chatterAnswersReputationLevelInstance.ShouldBeAssignableTo<ChatterAnswersReputationLevel>();
            _chatterAnswersReputationLevelInstanceFixture.ShouldBeAssignableTo<ChatterAnswersReputationLevel>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ChatterAnswersReputationLevel) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(int) , Propertyvalue)]
        public void AUT_ChatterAnswersReputationLevel_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ChatterAnswersReputationLevel, T>(_chatterAnswersReputationLevelInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ChatterAnswersReputationLevel) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterAnswersReputationLevel_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ChatterAnswersReputationLevel) => Property (value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterAnswersReputationLevel_Public_Class_value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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