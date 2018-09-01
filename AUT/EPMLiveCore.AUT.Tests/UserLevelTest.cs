using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using EPMLiveCore.API.ProjectArchiver;
using EPMLiveCore.Infrastructure.Logging;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Utilities;
using Microsoft.Win32;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;
using EPMLiveCore;
using UserLevel = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.UserLevel" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class UserLevelTest : AbstractBaseSetupTypedTest<UserLevel>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (UserLevel) Initializer

        private const string Fieldname = "name";
        private const string Fieldid = "id";
        private const string Fieldlevels = "levels";
        private Type _userLevelInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private UserLevel _userLevelInstance;
        private UserLevel _userLevelInstanceFixture;

        #region General Initializer : Class (UserLevel) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="UserLevel" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _userLevelInstanceType = typeof(UserLevel);
            _userLevelInstanceFixture = Create(true);
            _userLevelInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (UserLevel)

        #region General Initializer : Class (UserLevel) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="UserLevel" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldname)]
        [TestCase(Fieldid)]
        [TestCase(Fieldlevels)]
        public void AUT_UserLevel_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_userLevelInstanceFixture, 
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
        ///     Class (<see cref="UserLevel" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_UserLevel_Is_Instance_Present_Test()
        {
            // Assert
            _userLevelInstanceType.ShouldNotBeNull();
            _userLevelInstance.ShouldNotBeNull();
            _userLevelInstanceFixture.ShouldNotBeNull();
            _userLevelInstance.ShouldBeAssignableTo<UserLevel>();
            _userLevelInstanceFixture.ShouldBeAssignableTo<UserLevel>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (UserLevel) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_UserLevel_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            UserLevel instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _userLevelInstanceType.ShouldNotBeNull();
            _userLevelInstance.ShouldNotBeNull();
            _userLevelInstanceFixture.ShouldNotBeNull();
            _userLevelInstance.ShouldBeAssignableTo<UserLevel>();
            _userLevelInstanceFixture.ShouldBeAssignableTo<UserLevel>();
        }

        #endregion

        #endregion

        #endregion
    }
}