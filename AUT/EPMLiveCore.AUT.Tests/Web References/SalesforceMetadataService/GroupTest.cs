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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.Group" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GroupTest : AbstractBaseSetupTypedTest<Group>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Group) Initializer

        private const string PropertydoesIncludeBosses = "doesIncludeBosses";
        private const string PropertydoesIncludeBossesSpecified = "doesIncludeBossesSpecified";
        private const string Propertyname = "name";
        private const string FielddoesIncludeBossesField = "doesIncludeBossesField";
        private const string FielddoesIncludeBossesFieldSpecified = "doesIncludeBossesFieldSpecified";
        private const string FieldnameField = "nameField";
        private Type _groupInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Group _groupInstance;
        private Group _groupInstanceFixture;

        #region General Initializer : Class (Group) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Group" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _groupInstanceType = typeof(Group);
            _groupInstanceFixture = Create(true);
            _groupInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Group)

        #region General Initializer : Class (Group) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Group" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertydoesIncludeBosses)]
        [TestCase(PropertydoesIncludeBossesSpecified)]
        [TestCase(Propertyname)]
        public void AUT_Group_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_groupInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Group) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Group" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddoesIncludeBossesField)]
        [TestCase(FielddoesIncludeBossesFieldSpecified)]
        [TestCase(FieldnameField)]
        public void AUT_Group_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_groupInstanceFixture, 
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
        ///     Class (<see cref="Group" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Group_Is_Instance_Present_Test()
        {
            // Assert
            _groupInstanceType.ShouldNotBeNull();
            _groupInstance.ShouldNotBeNull();
            _groupInstanceFixture.ShouldNotBeNull();
            _groupInstance.ShouldBeAssignableTo<Group>();
            _groupInstanceFixture.ShouldBeAssignableTo<Group>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Group) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Group_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Group instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _groupInstanceType.ShouldNotBeNull();
            _groupInstance.ShouldNotBeNull();
            _groupInstanceFixture.ShouldNotBeNull();
            _groupInstance.ShouldBeAssignableTo<Group>();
            _groupInstanceFixture.ShouldBeAssignableTo<Group>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Group) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertydoesIncludeBosses)]
        [TestCaseGeneric(typeof(bool) , PropertydoesIncludeBossesSpecified)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_Group_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Group, T>(_groupInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Group) => Property (doesIncludeBosses) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Group_Public_Class_doesIncludeBosses_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydoesIncludeBosses);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Group) => Property (doesIncludeBossesSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Group_Public_Class_doesIncludeBossesSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydoesIncludeBossesSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Group) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Group_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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