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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.ListPlannerProps" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ListPlannerPropsTest : AbstractBaseSetupTypedTest<ListPlannerProps>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ListPlannerProps) Initializer

        private const string FieldPlannerV2CurPlanner = "PlannerV2CurPlanner";
        private const string FieldPlannerV2Menu = "PlannerV2Menu";
        private Type _listPlannerPropsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ListPlannerProps _listPlannerPropsInstance;
        private ListPlannerProps _listPlannerPropsInstanceFixture;

        #region General Initializer : Class (ListPlannerProps) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ListPlannerProps" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _listPlannerPropsInstanceType = typeof(ListPlannerProps);
            _listPlannerPropsInstanceFixture = Create(true);
            _listPlannerPropsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ListPlannerProps)

        #region General Initializer : Class (ListPlannerProps) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ListPlannerProps" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldPlannerV2CurPlanner)]
        [TestCase(FieldPlannerV2Menu)]
        public void AUT_ListPlannerProps_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_listPlannerPropsInstanceFixture, 
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
        ///     Class (<see cref="ListPlannerProps" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ListPlannerProps_Is_Instance_Present_Test()
        {
            // Assert
            _listPlannerPropsInstanceType.ShouldNotBeNull();
            _listPlannerPropsInstance.ShouldNotBeNull();
            _listPlannerPropsInstanceFixture.ShouldNotBeNull();
            _listPlannerPropsInstance.ShouldBeAssignableTo<ListPlannerProps>();
            _listPlannerPropsInstanceFixture.ShouldBeAssignableTo<ListPlannerProps>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ListPlannerProps) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ListPlannerProps_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ListPlannerProps instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _listPlannerPropsInstanceType.ShouldNotBeNull();
            _listPlannerPropsInstance.ShouldNotBeNull();
            _listPlannerPropsInstanceFixture.ShouldNotBeNull();
            _listPlannerPropsInstance.ShouldBeAssignableTo<ListPlannerProps>();
            _listPlannerPropsInstanceFixture.ShouldBeAssignableTo<ListPlannerProps>();
        }

        #endregion

        #endregion

        #endregion
    }
}