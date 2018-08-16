using System;
using System.Collections.Generic;
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
using static EPMLiveCore.Services.DataContracts.SocialEngine.SEActivities;

namespace EPMLiveCore.Services.DataContracts.SocialEngine
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Services.DataContracts.SocialEngine.SEActivities" />)
    ///     and namespace <see cref="EPMLiveCore.Services.DataContracts.SocialEngine"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SEActivitiesTest : AbstractBaseSetupTypedTest<SEActivities>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SEActivities) Initializer

        private const string Propertyerror = "error";
        private const string Propertylists = "lists";
        private const string Propertysuid = "suid";
        private const string Propertythreads = "threads";
        private const string Propertyusers = "users";
        private const string Propertywebs = "webs";
        private Type _sEActivitiesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SEActivities _sEActivitiesInstance;
        private SEActivities _sEActivitiesInstanceFixture;

        #region General Initializer : Class (SEActivities) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SEActivities" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sEActivitiesInstanceType = typeof(SEActivities);
            _sEActivitiesInstanceFixture = Create(true);
            _sEActivitiesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SEActivities)

        #region General Initializer : Class (SEActivities) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SEActivities" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Propertyerror)]
        [TestCase(Propertylists)]
        [TestCase(Propertysuid)]
        [TestCase(Propertythreads)]
        [TestCase(Propertyusers)]
        [TestCase(Propertywebs)]
        public void AUT_SEActivities_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_sEActivitiesInstanceFixture,
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
        ///     Class (<see cref="SEActivities" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_SEActivities_Is_Instance_Present_Test()
        {
            // Assert
            _sEActivitiesInstanceType.ShouldNotBeNull();
            _sEActivitiesInstance.ShouldNotBeNull();
            _sEActivitiesInstanceFixture.ShouldNotBeNull();
            _sEActivitiesInstance.ShouldBeAssignableTo<SEActivities>();
            _sEActivitiesInstanceFixture.ShouldBeAssignableTo<SEActivities>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SEActivities) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_SEActivities_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SEActivities instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sEActivitiesInstanceType.ShouldNotBeNull();
            _sEActivitiesInstance.ShouldNotBeNull();
            _sEActivitiesInstanceFixture.ShouldNotBeNull();
            _sEActivitiesInstance.ShouldBeAssignableTo<SEActivities>();
            _sEActivitiesInstanceFixture.ShouldBeAssignableTo<SEActivities>();
        }

        #endregion

        #region General Constructor : Class (SEActivities) Default Assignment Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_SEActivities_Constructor_Instantiated_With_Default_Assignments_Test()
        {

            // Act
            var sEActivitiesInstance  = new SEActivities();

            // Asserts
            sEActivitiesInstance.ShouldNotBeNull();
            sEActivitiesInstance.ShouldBeAssignableTo<SEActivities>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SEActivities) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(Error) , Propertyerror)]
        [TestCaseGeneric(typeof(List<ItemList>) , Propertylists)]
        [TestCaseGeneric(typeof(Guid) , Propertysuid)]
        [TestCaseGeneric(typeof(List<Thread>) , Propertythreads)]
        [TestCaseGeneric(typeof(List<User>) , Propertyusers)]
        [TestCaseGeneric(typeof(List<Web>) , Propertywebs)]
        public void AUT_SEActivities_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SEActivities, T>(_sEActivitiesInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SEActivities) => Property (error) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SEActivities_error_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyerror);
            Action currentAction = () => propertyInfo.SetValue(_sEActivitiesInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SEActivities) => Property (error) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SEActivities_Public_Class_error_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyerror);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SEActivities) => Property (lists) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SEActivities_Public_Class_lists_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylists);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SEActivities) => Property (suid) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SEActivities_suid_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertysuid);
            Action currentAction = () => propertyInfo.SetValue(_sEActivitiesInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SEActivities) => Property (suid) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SEActivities_Public_Class_suid_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysuid);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SEActivities) => Property (users) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SEActivities_Public_Class_users_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyusers);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SEActivities) => Property (webs) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SEActivities_Public_Class_webs_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertywebs);

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