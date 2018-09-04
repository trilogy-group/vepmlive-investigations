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
using PlannerDefinition = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.PlannerDefinition" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PlannerDefinitionTest : AbstractBaseSetupTypedTest<PlannerDefinition>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PlannerDefinition) Initializer

        private const string Fieldtitle = "title";
        private const string Fieldimage = "image";
        private const string Fieldenabled = "enabled";
        private const string Fieldcommand = "command";
        private const string Fielddescription = "description";
        private const string Fielddisplaytype = "displaytype";
        private const string FieldcommandPrefix = "commandPrefix";
        private Type _plannerDefinitionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PlannerDefinition _plannerDefinitionInstance;
        private PlannerDefinition _plannerDefinitionInstanceFixture;

        #region General Initializer : Class (PlannerDefinition) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PlannerDefinition" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _plannerDefinitionInstanceType = typeof(PlannerDefinition);
            _plannerDefinitionInstanceFixture = Create(true);
            _plannerDefinitionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PlannerDefinition)

        #region General Initializer : Class (PlannerDefinition) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PlannerDefinition" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldtitle)]
        [TestCase(Fieldimage)]
        [TestCase(Fieldenabled)]
        [TestCase(Fieldcommand)]
        [TestCase(Fielddescription)]
        [TestCase(Fielddisplaytype)]
        [TestCase(FieldcommandPrefix)]
        public void AUT_PlannerDefinition_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_plannerDefinitionInstanceFixture, 
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
        ///     Class (<see cref="PlannerDefinition" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PlannerDefinition_Is_Instance_Present_Test()
        {
            // Assert
            _plannerDefinitionInstanceType.ShouldNotBeNull();
            _plannerDefinitionInstance.ShouldNotBeNull();
            _plannerDefinitionInstanceFixture.ShouldNotBeNull();
            _plannerDefinitionInstance.ShouldBeAssignableTo<PlannerDefinition>();
            _plannerDefinitionInstanceFixture.ShouldBeAssignableTo<PlannerDefinition>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PlannerDefinition) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_PlannerDefinition_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PlannerDefinition instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _plannerDefinitionInstanceType.ShouldNotBeNull();
            _plannerDefinitionInstance.ShouldNotBeNull();
            _plannerDefinitionInstanceFixture.ShouldNotBeNull();
            _plannerDefinitionInstance.ShouldBeAssignableTo<PlannerDefinition>();
            _plannerDefinitionInstanceFixture.ShouldBeAssignableTo<PlannerDefinition>();
        }

        #endregion

        #endregion

        #endregion
    }
}