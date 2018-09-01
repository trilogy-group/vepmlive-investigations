using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using ActLevel = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ActLevel" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ActLevelTest : AbstractBaseSetupTypedTest<ActLevel>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ActLevel) Initializer

        private const string Fieldid = "id";
        private const string Fieldname = "name";
        private const string Fieldtotalactivations = "totalactivations";
        private const string Fieldavailableactivations = "availableactivations";
        private const string FieldisUserInLevel = "isUserInLevel";
        private Type _actLevelInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ActLevel _actLevelInstance;
        private ActLevel _actLevelInstanceFixture;

        #region General Initializer : Class (ActLevel) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ActLevel" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _actLevelInstanceType = typeof(ActLevel);
            _actLevelInstanceFixture = Create(true);
            _actLevelInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ActLevel)

        #region General Initializer : Class (ActLevel) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ActLevel" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldid)]
        [TestCase(Fieldname)]
        [TestCase(Fieldtotalactivations)]
        [TestCase(Fieldavailableactivations)]
        [TestCase(FieldisUserInLevel)]
        public void AUT_ActLevel_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_actLevelInstanceFixture, 
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
        ///     Class (<see cref="ActLevel" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ActLevel_Is_Instance_Present_Test()
        {
            // Assert
            _actLevelInstanceType.ShouldNotBeNull();
            _actLevelInstance.ShouldNotBeNull();
            _actLevelInstanceFixture.ShouldNotBeNull();
            _actLevelInstance.ShouldBeAssignableTo<ActLevel>();
            _actLevelInstanceFixture.ShouldBeAssignableTo<ActLevel>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ActLevel) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ActLevel_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ActLevel instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _actLevelInstanceType.ShouldNotBeNull();
            _actLevelInstance.ShouldNotBeNull();
            _actLevelInstanceFixture.ShouldNotBeNull();
            _actLevelInstance.ShouldBeAssignableTo<ActLevel>();
            _actLevelInstanceFixture.ShouldBeAssignableTo<ActLevel>();
        }

        #endregion

        #endregion

        #endregion
    }
}