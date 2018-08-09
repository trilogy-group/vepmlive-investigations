using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.CreatedWorkspaceInfo" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CreatedWorkspaceInfoTest : AbstractBaseSetupTypedTest<CreatedWorkspaceInfo>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CreatedWorkspaceInfo) Initializer

        private const string FieldsXml = "sXml";
        private Type _createdWorkspaceInfoInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CreatedWorkspaceInfo _createdWorkspaceInfoInstance;
        private CreatedWorkspaceInfo _createdWorkspaceInfoInstanceFixture;
        private Type[] _abstractClassInstanciatedTypesList;

        #region General Initializer : Class (CreatedWorkspaceInfo) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CreatedWorkspaceInfo" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _createdWorkspaceInfoInstanceType = typeof(CreatedWorkspaceInfo);
            _abstractClassInstanciatedTypesList = new Type[] { typeof(DownloadedWorkspaceInfo) };
            _createdWorkspaceInfoInstanceFixture = Create(true);
            _createdWorkspaceInfoInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CreatedWorkspaceInfo)

        #region General Initializer : Class (CreatedWorkspaceInfo) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CreatedWorkspaceInfo" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldsXml)]
        public void AUT_CreatedWorkspaceInfo_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_createdWorkspaceInfoInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #endregion
    }
}