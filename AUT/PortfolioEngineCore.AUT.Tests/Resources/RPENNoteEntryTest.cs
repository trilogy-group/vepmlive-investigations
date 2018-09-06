using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace PortfolioEngineCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.RPEN_NoteEntry" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class RPENNoteEntryTest : AbstractBaseSetupTypedTest<RPEN_NoteEntry>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RPEN_NoteEntry) Initializer

        private const string FieldUID = "UID";
        private const string FieldPID = "PID";
        private const string FieldcmtGuid = "cmtGuid";
        private const string FieldresID = "resID";
        private const string Fieldtitle = "title";
        private const string Fieldhtml = "html";
        private const string Fieldcontext = "context";
        private const string FieldresName = "resName";
        private const string FieldresNTAcctount = "resNTAcctount";
        private const string FieldresEmail = "resEmail";
        private const string FieldresExtUID = "resExtUID";
        private const string Fieldproject = "project";
        private const string Fieldcmt = "cmt";
        private Type _rPENNoteEntryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RPEN_NoteEntry _rPENNoteEntryInstance;
        private RPEN_NoteEntry _rPENNoteEntryInstanceFixture;

        #region General Initializer : Class (RPEN_NoteEntry) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RPEN_NoteEntry" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _rPENNoteEntryInstanceType = typeof(RPEN_NoteEntry);
            _rPENNoteEntryInstanceFixture = Create(true);
            _rPENNoteEntryInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RPEN_NoteEntry)

        #region General Initializer : Class (RPEN_NoteEntry) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RPEN_NoteEntry" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldUID)]
        [TestCase(FieldPID)]
        [TestCase(FieldcmtGuid)]
        [TestCase(FieldresID)]
        [TestCase(Fieldtitle)]
        [TestCase(Fieldhtml)]
        [TestCase(Fieldcontext)]
        [TestCase(FieldresName)]
        [TestCase(FieldresNTAcctount)]
        [TestCase(FieldresEmail)]
        [TestCase(FieldresExtUID)]
        [TestCase(Fieldproject)]
        [TestCase(Fieldcmt)]
        public void AUT_RPENNoteEntry_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_rPENNoteEntryInstanceFixture, 
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
        ///     Class (<see cref="RPEN_NoteEntry" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RPENNoteEntry_Is_Instance_Present_Test()
        {
            // Assert
            _rPENNoteEntryInstanceType.ShouldNotBeNull();
            _rPENNoteEntryInstance.ShouldNotBeNull();
            _rPENNoteEntryInstanceFixture.ShouldNotBeNull();
            _rPENNoteEntryInstance.ShouldBeAssignableTo<RPEN_NoteEntry>();
            _rPENNoteEntryInstanceFixture.ShouldBeAssignableTo<RPEN_NoteEntry>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RPEN_NoteEntry) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RPEN_NoteEntry_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RPEN_NoteEntry instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _rPENNoteEntryInstanceType.ShouldNotBeNull();
            _rPENNoteEntryInstance.ShouldNotBeNull();
            _rPENNoteEntryInstanceFixture.ShouldNotBeNull();
            _rPENNoteEntryInstance.ShouldBeAssignableTo<RPEN_NoteEntry>();
            _rPENNoteEntryInstanceFixture.ShouldBeAssignableTo<RPEN_NoteEntry>();
        }

        #endregion

        #endregion

        #endregion
    }
}