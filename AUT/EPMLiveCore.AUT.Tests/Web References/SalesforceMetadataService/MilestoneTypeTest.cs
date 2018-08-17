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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.MilestoneType" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class MilestoneTypeTest : AbstractBaseSetupTypedTest<MilestoneType>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (MilestoneType) Initializer

        private const string Propertydescription = "description";
        private const string FielddescriptionField = "descriptionField";
        private Type _milestoneTypeInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private MilestoneType _milestoneTypeInstance;
        private MilestoneType _milestoneTypeInstanceFixture;

        #region General Initializer : Class (MilestoneType) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="MilestoneType" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _milestoneTypeInstanceType = typeof(MilestoneType);
            _milestoneTypeInstanceFixture = Create(true);
            _milestoneTypeInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (MilestoneType)

        #region General Initializer : Class (MilestoneType) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="MilestoneType" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertydescription)]
        public void AUT_MilestoneType_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_milestoneTypeInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (MilestoneType) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="MilestoneType" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddescriptionField)]
        public void AUT_MilestoneType_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_milestoneTypeInstanceFixture, 
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
        ///     Class (<see cref="MilestoneType" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_MilestoneType_Is_Instance_Present_Test()
        {
            // Assert
            _milestoneTypeInstanceType.ShouldNotBeNull();
            _milestoneTypeInstance.ShouldNotBeNull();
            _milestoneTypeInstanceFixture.ShouldNotBeNull();
            _milestoneTypeInstance.ShouldBeAssignableTo<MilestoneType>();
            _milestoneTypeInstanceFixture.ShouldBeAssignableTo<MilestoneType>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (MilestoneType) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_MilestoneType_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            MilestoneType instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _milestoneTypeInstanceType.ShouldNotBeNull();
            _milestoneTypeInstance.ShouldNotBeNull();
            _milestoneTypeInstanceFixture.ShouldNotBeNull();
            _milestoneTypeInstance.ShouldBeAssignableTo<MilestoneType>();
            _milestoneTypeInstanceFixture.ShouldBeAssignableTo<MilestoneType>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (MilestoneType) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        public void AUT_MilestoneType_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<MilestoneType, T>(_milestoneTypeInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (MilestoneType) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MilestoneType_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydescription);

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