using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace PortfolioEngineCore.Setup
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.Setup.UserInformation" />)
    ///     and namespace <see cref="PortfolioEngineCore.Setup"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class UserInformationTest : AbstractBaseSetupTypedTest<UserInformation>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (UserInformation) Initializer

        private const string FieldUsername = "Username";
        private const string FieldDisplayName = "DisplayName";
        private const string FieldEmail = "Email";
        private const string Fieldextid = "extid";
        private Type _userInformationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private UserInformation _userInformationInstance;
        private UserInformation _userInformationInstanceFixture;

        #region General Initializer : Class (UserInformation) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="UserInformation" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _userInformationInstanceType = typeof(UserInformation);
            _userInformationInstanceFixture = Create(true);
            _userInformationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (UserInformation)

        #region General Initializer : Class (UserInformation) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="UserInformation" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldUsername)]
        [TestCase(FieldDisplayName)]
        [TestCase(FieldEmail)]
        [TestCase(Fieldextid)]
        public void AUT_UserInformation_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_userInformationInstanceFixture, 
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
        ///     Class (<see cref="UserInformation" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_UserInformation_Is_Instance_Present_Test()
        {
            // Assert
            _userInformationInstanceType.ShouldNotBeNull();
            _userInformationInstance.ShouldNotBeNull();
            _userInformationInstanceFixture.ShouldNotBeNull();
            _userInformationInstance.ShouldBeAssignableTo<UserInformation>();
            _userInformationInstanceFixture.ShouldBeAssignableTo<UserInformation>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (UserInformation) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_UserInformation_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            UserInformation instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _userInformationInstanceType.ShouldNotBeNull();
            _userInformationInstance.ShouldNotBeNull();
            _userInformationInstanceFixture.ShouldNotBeNull();
            _userInformationInstance.ShouldBeAssignableTo<UserInformation>();
            _userInformationInstanceFixture.ShouldBeAssignableTo<UserInformation>();
        }

        #endregion

        #endregion

        #endregion
    }
}