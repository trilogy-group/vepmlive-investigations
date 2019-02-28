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
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.BaseSetup.Version.V2;
using AUT.ConfigureTestProjects.BaseSetup.Version.V3;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.Model;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveWorkPlanner.Layouts.EPMLiveWorkPlanner;
using NoteEditor = EPMLiveWorkPlanner.Layouts.EPMLiveWorkPlanner;

namespace EPMLiveWorkPlanner.Layouts.EPMLiveWorkPlanner
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWorkPlanner.Layouts.EPMLiveWorkPlanner.NoteEditor" />)
    ///     and namespace <see cref="EPMLiveWorkPlanner.Layouts.EPMLiveWorkPlanner"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class NoteEditorTest : AbstractBaseSetupV3Test
    {
        public NoteEditorTest() : base(typeof(NoteEditor))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Overrides of IAbstractBaseSetupV2Test

        /// <summary>
        ///    Configure and ignore problematic tests.
        ///    Added tests will be ignored.
        /// </summary>
        public override void ConfigureIgnoringTests()
        {
            base.ConfigureIgnoringTests();
        }

        #endregion

        #region General Initializer : Class (NoteEditor) Initializer

        private Type _noteEditorInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private NoteEditor _noteEditorInstance;
        private NoteEditor _noteEditorInstanceFixture;

        #region General Initializer : Class (NoteEditor) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="NoteEditor" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _noteEditorInstanceType = typeof(NoteEditor);
            _noteEditorInstanceFixture = this.Create<NoteEditor>(true);
            _noteEditorInstance = _noteEditorInstanceFixture ?? this.Create<NoteEditor>(false);
            CurrentInstance = _noteEditorInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="NoteEditor" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_NoteEditor_Is_Instance_Present_Test()
        {
            // Assert
            _noteEditorInstanceType.ShouldNotBeNull();
            _noteEditorInstance.ShouldNotBeNull();
            _noteEditorInstanceFixture.ShouldNotBeNull();
            _noteEditorInstance.ShouldBeAssignableTo<NoteEditor>();
            _noteEditorInstanceFixture.ShouldBeAssignableTo<NoteEditor>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (NoteEditor) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_NoteEditor_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            NoteEditor instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _noteEditorInstanceType.ShouldNotBeNull();
            _noteEditorInstance.ShouldNotBeNull();
            _noteEditorInstanceFixture.ShouldNotBeNull();
            _noteEditorInstance.ShouldBeAssignableTo<NoteEditor>();
            _noteEditorInstanceFixture.ShouldBeAssignableTo<NoteEditor>();
        }

        #endregion

        #endregion

        #endregion
    }
}