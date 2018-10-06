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
using EPMLiveWorkPlanner.Layouts.epmlive;
using ImportCsv = EPMLiveWorkPlanner.Layouts.epmlive;

namespace EPMLiveWorkPlanner.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWorkPlanner.Layouts.epmlive.ImportCsv" />)
    ///     and namespace <see cref="EPMLiveWorkPlanner.Layouts.epmlive"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ImportCsvTest : AbstractBaseSetupV3Test
    {
        public ImportCsvTest() : base(typeof(ImportCsv))
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

        #region General Initializer : Class (ImportCsv) Initializer

        #region Fields

        private const string FieldhdnFilename = "hdnFilename";
        private const string FieldpnlUpload = "pnlUpload";
        private const string FieldlblError = "lblError";
        private const string FieldFileUpload1 = "FileUpload1";
        private const string FieldddlSep = "ddlSep";
        private const string FieldbtnUpload = "btnUpload";
        private const string FieldpnlColumns = "pnlColumns";
        private const string FieldddlUID = "ddlUID";
        private const string FieldddlWBS = "ddlWBS";
        private const string FieldgvColumns = "gvColumns";
        private const string FieldchkNoDuplicates = "chkNoDuplicates";
        private const string FieldbtnImport = "btnImport";

        #endregion

        private Type _importCsvInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private ImportCsv _importCsvInstance;
        private ImportCsv _importCsvInstanceFixture;

        #region General Initializer : Class (ImportCsv) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ImportCsv" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _importCsvInstanceType = typeof(ImportCsv);
            _importCsvInstanceFixture = this.Create<ImportCsv>(true);
            _importCsvInstance = _importCsvInstanceFixture ?? this.Create<ImportCsv>(false);
            CurrentInstance = _importCsvInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ImportCsv)

        #region General Initializer : Class (ImportCsv) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ImportCsv" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldhdnFilename)]
        [TestCase(FieldpnlUpload)]
        [TestCase(FieldlblError)]
        [TestCase(FieldFileUpload1)]
        [TestCase(FieldddlSep)]
        [TestCase(FieldbtnUpload)]
        [TestCase(FieldpnlColumns)]
        [TestCase(FieldddlUID)]
        [TestCase(FieldddlWBS)]
        [TestCase(FieldgvColumns)]
        [TestCase(FieldchkNoDuplicates)]
        [TestCase(FieldbtnImport)]
        public void AUT_ImportCsv_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_importCsvInstanceFixture, 
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
        ///     Class (<see cref="ImportCsv" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ImportCsv_Is_Instance_Present_Test()
        {
            // Assert
            _importCsvInstanceType.ShouldNotBeNull();
            _importCsvInstance.ShouldNotBeNull();
            _importCsvInstanceFixture.ShouldNotBeNull();
            _importCsvInstance.ShouldBeAssignableTo<ImportCsv>();
            _importCsvInstanceFixture.ShouldBeAssignableTo<ImportCsv>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ImportCsv) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ImportCsv_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ImportCsv instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _importCsvInstanceType.ShouldNotBeNull();
            _importCsvInstance.ShouldNotBeNull();
            _importCsvInstanceFixture.ShouldNotBeNull();
            _importCsvInstance.ShouldBeAssignableTo<ImportCsv>();
            _importCsvInstanceFixture.ShouldBeAssignableTo<ImportCsv>();
        }

        #endregion

        #endregion

        #endregion
    }
}