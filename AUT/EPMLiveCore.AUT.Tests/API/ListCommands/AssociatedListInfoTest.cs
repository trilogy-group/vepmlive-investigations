using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.AssociatedListInfo" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AssociatedListInfoTest : AbstractBaseSetupTypedTest<AssociatedListInfo>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AssociatedListInfo) Initializer

        private const string FieldListId = "ListId";
        private const string FieldTitle = "Title";
        private const string FieldLinkedField = "LinkedField";
        private const string Fieldicon = "icon";
        private Type _associatedListInfoInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AssociatedListInfo _associatedListInfoInstance;
        private AssociatedListInfo _associatedListInfoInstanceFixture;

        #region General Initializer : Class (AssociatedListInfo) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AssociatedListInfo" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _associatedListInfoInstanceType = typeof(AssociatedListInfo);
            _associatedListInfoInstanceFixture = Create(true);
            _associatedListInfoInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AssociatedListInfo)

        #region General Initializer : Class (AssociatedListInfo) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AssociatedListInfo" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldListId)]
        [TestCase(FieldTitle)]
        [TestCase(FieldLinkedField)]
        [TestCase(Fieldicon)]
        public void AUT_AssociatedListInfo_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_associatedListInfoInstanceFixture, 
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
        ///     Class (<see cref="AssociatedListInfo" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_AssociatedListInfo_Is_Instance_Present_Test()
        {
            // Assert
            _associatedListInfoInstanceType.ShouldNotBeNull();
            _associatedListInfoInstance.ShouldNotBeNull();
            _associatedListInfoInstanceFixture.ShouldNotBeNull();
            _associatedListInfoInstance.ShouldBeAssignableTo<AssociatedListInfo>();
            _associatedListInfoInstanceFixture.ShouldBeAssignableTo<AssociatedListInfo>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AssociatedListInfo) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_AssociatedListInfo_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            AssociatedListInfo instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _associatedListInfoInstanceType.ShouldNotBeNull();
            _associatedListInfoInstance.ShouldNotBeNull();
            _associatedListInfoInstanceFixture.ShouldNotBeNull();
            _associatedListInfoInstance.ShouldBeAssignableTo<AssociatedListInfo>();
            _associatedListInfoInstanceFixture.ShouldBeAssignableTo<AssociatedListInfo>();
        }

        #endregion

        #endregion

        #endregion
    }
}