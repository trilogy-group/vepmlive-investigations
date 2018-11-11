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

namespace WorkEnginePPM.Core.Entities
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Core.Entities.PersonalItem" />)
    ///     and namespace <see cref="WorkEnginePPM.Core.Entities"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PersonalItemTest : AbstractBaseSetupTypedTest<PersonalItem>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PersonalItem) Initializer

        private const string PropertyExtId = "ExtId";
        private const string PropertyId = "Id";
        private const string PropertyTitle = "Title";
        private const string PropertyUniqueId = "UniqueId";
        private Type _personalItemInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PersonalItem _personalItemInstance;
        private PersonalItem _personalItemInstanceFixture;

        #region General Initializer : Class (PersonalItem) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PersonalItem" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _personalItemInstanceType = typeof(PersonalItem);
            _personalItemInstanceFixture = Create(true);
            _personalItemInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PersonalItem)

        #region General Initializer : Class (PersonalItem) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PersonalItem" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtId)]
        [TestCase(PropertyId)]
        [TestCase(PropertyTitle)]
        [TestCase(PropertyUniqueId)]
        public void AUT_PersonalItem_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_personalItemInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="PersonalItem" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PersonalItem_Is_Instance_Present_Test()
        {
            // Assert
            _personalItemInstanceType.ShouldNotBeNull();
            _personalItemInstance.ShouldNotBeNull();
            _personalItemInstanceFixture.ShouldNotBeNull();
            _personalItemInstance.ShouldBeAssignableTo<PersonalItem>();
            _personalItemInstanceFixture.ShouldBeAssignableTo<PersonalItem>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PersonalItem) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_PersonalItem_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PersonalItem instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _personalItemInstanceType.ShouldNotBeNull();
            _personalItemInstance.ShouldNotBeNull();
            _personalItemInstanceFixture.ShouldNotBeNull();
            _personalItemInstance.ShouldBeAssignableTo<PersonalItem>();
            _personalItemInstanceFixture.ShouldBeAssignableTo<PersonalItem>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PersonalItem) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyExtId)]
        [TestCaseGeneric(typeof(int?) , PropertyId)]
        [TestCaseGeneric(typeof(string) , PropertyTitle)]
        [TestCaseGeneric(typeof(Guid) , PropertyUniqueId)]
        public void AUT_PersonalItem_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<PersonalItem, T>(_personalItemInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (PersonalItem) => Property (ExtId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalItem_Public_Class_ExtId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyExtId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PersonalItem) => Property (Id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalItem_Public_Class_Id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PersonalItem) => Property (Title) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalItem_Public_Class_Title_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTitle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PersonalItem) => Property (UniqueId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalItem_UniqueId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyUniqueId);
            Action currentAction = () => propertyInfo.SetValue(_personalItemInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PersonalItem) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalItem_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUniqueId);

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