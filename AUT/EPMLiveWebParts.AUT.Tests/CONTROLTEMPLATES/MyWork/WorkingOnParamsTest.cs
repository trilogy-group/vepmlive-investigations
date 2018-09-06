using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.CONTROLTEMPLATES.MyWork
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.CONTROLTEMPLATES.MyWork.WorkingOnParams" />)
    ///     and namespace <see cref="EPMLiveWebParts.CONTROLTEMPLATES.MyWork"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WorkingOnParamsTest : AbstractBaseSetupTypedTest<WorkingOnParams>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkingOnParams) Initializer

        private const string PropertyGridId = "GridId";
        private const string Field_gridId = "_gridId";
        private Type _workingOnParamsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkingOnParams _workingOnParamsInstance;
        private WorkingOnParams _workingOnParamsInstanceFixture;

        #region General Initializer : Class (WorkingOnParams) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkingOnParams" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workingOnParamsInstanceType = typeof(WorkingOnParams);
            _workingOnParamsInstanceFixture = Create(true);
            _workingOnParamsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkingOnParams)

        #region General Initializer : Class (WorkingOnParams) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkingOnParams" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyGridId)]
        public void AUT_WorkingOnParams_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_workingOnParamsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkingOnParams) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkingOnParams" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_gridId)]
        public void AUT_WorkingOnParams_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workingOnParamsInstanceFixture, 
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
        ///     Class (<see cref="WorkingOnParams" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WorkingOnParams_Is_Instance_Present_Test()
        {
            // Assert
            _workingOnParamsInstanceType.ShouldNotBeNull();
            _workingOnParamsInstance.ShouldNotBeNull();
            _workingOnParamsInstanceFixture.ShouldNotBeNull();
            _workingOnParamsInstance.ShouldBeAssignableTo<WorkingOnParams>();
            _workingOnParamsInstanceFixture.ShouldBeAssignableTo<WorkingOnParams>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkingOnParams) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_WorkingOnParams_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var gridId = CreateType<string>();
            WorkingOnParams instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new WorkingOnParams(gridId);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _workingOnParamsInstance.ShouldNotBeNull();
            _workingOnParamsInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<WorkingOnParams>();
        }

        #endregion

        #region General Constructor : Class (WorkingOnParams) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_WorkingOnParams_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var gridId = CreateType<string>();
            WorkingOnParams instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new WorkingOnParams(gridId);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _workingOnParamsInstance.ShouldNotBeNull();
            _workingOnParamsInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (WorkingOnParams) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyGridId)]
        public void AUT_WorkingOnParams_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<WorkingOnParams, T>(_workingOnParamsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (WorkingOnParams) => Property (GridId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkingOnParams_Public_Class_GridId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyGridId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #endregion
    }
}