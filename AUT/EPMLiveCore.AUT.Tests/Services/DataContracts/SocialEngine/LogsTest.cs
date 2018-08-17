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
using static EPMLiveCore.Services.DataContracts.SocialEngine.Logs;

namespace EPMLiveCore.Services.DataContracts.SocialEngine
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Services.DataContracts.SocialEngine.Logs" />)
    ///     and namespace <see cref="EPMLiveCore.Services.DataContracts.SocialEngine"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class LogsTest : AbstractBaseSetupTypedTest<Logs>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Logs) Initializer

        private const string Propertycollection = "collection";
        private const string Propertyerror = "error";
        private const string Propertyusers = "users";
        private const string Propertywebs = "webs";
        private Type _logsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Logs _logsInstance;
        private Logs _logsInstanceFixture;

        #region General Initializer : Class (Logs) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Logs" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _logsInstanceType = typeof(Logs);
            _logsInstanceFixture = Create(true);
            _logsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Logs)

        #region General Initializer : Class (Logs) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Logs" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Propertycollection)]
        [TestCase(Propertyerror)]
        [TestCase(Propertyusers)]
        [TestCase(Propertywebs)]
        public void AUT_Logs_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_logsInstanceFixture,
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
        ///     Class (<see cref="Logs" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Logs_Is_Instance_Present_Test()
        {
            // Assert
            _logsInstanceType.ShouldNotBeNull();
            _logsInstance.ShouldNotBeNull();
            _logsInstanceFixture.ShouldNotBeNull();
            _logsInstance.ShouldBeAssignableTo<Logs>();
            _logsInstanceFixture.ShouldBeAssignableTo<Logs>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Logs) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Logs_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Logs instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _logsInstanceType.ShouldNotBeNull();
            _logsInstance.ShouldNotBeNull();
            _logsInstanceFixture.ShouldNotBeNull();
            _logsInstance.ShouldBeAssignableTo<Logs>();
            _logsInstanceFixture.ShouldBeAssignableTo<Logs>();
        }

        #endregion

        #region General Constructor : Class (Logs) Default Assignment Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Logs_Constructor_Instantiated_With_Default_Assignments_Test()
        {

            // Act
            var logsInstance  = new Logs();

            // Asserts
            logsInstance.ShouldNotBeNull();
            logsInstance.ShouldBeAssignableTo<Logs>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Logs) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(List<Log>) , Propertycollection)]
        [TestCaseGeneric(typeof(Error) , Propertyerror)]
        [TestCaseGeneric(typeof(List<SEActivities.User>) , Propertyusers)]
        [TestCaseGeneric(typeof(List<SEActivities.Web>) , Propertywebs)]
        public void AUT_Logs_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Logs, T>(_logsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Logs) => Property (collection) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Logs_Public_Class_collection_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycollection);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Logs) => Property (error) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Logs_error_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyerror);
            Action currentAction = () => propertyInfo.SetValue(_logsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Logs) => Property (error) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Logs_Public_Class_error_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Logs) => Property (users) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Logs_Public_Class_users_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Logs) => Property (webs) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Logs_Public_Class_webs_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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