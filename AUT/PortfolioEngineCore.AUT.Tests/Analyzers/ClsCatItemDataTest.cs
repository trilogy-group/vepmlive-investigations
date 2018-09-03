using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace CostDataValues
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="CostDataValues.clsCatItemData" />)
    ///     and namespace <see cref="CostDataValues"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ClsCatItemDataTest : AbstractBaseSetupTypedTest<clsCatItemData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (clsCatItemData) Initializer

        private const string FieldUID = "UID";
        private const string FieldName = "Name";
        private const string FieldRates = "Rates";
        private Type _clsCatItemDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private clsCatItemData _clsCatItemDataInstance;
        private clsCatItemData _clsCatItemDataInstanceFixture;

        #region General Initializer : Class (clsCatItemData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="clsCatItemData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _clsCatItemDataInstanceType = typeof(clsCatItemData);
            _clsCatItemDataInstanceFixture = Create(true);
            _clsCatItemDataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (clsCatItemData)

        #region General Initializer : Class (clsCatItemData) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="clsCatItemData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldUID)]
        [TestCase(FieldName)]
        [TestCase(FieldRates)]
        public void AUT_ClsCatItemData_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_clsCatItemDataInstanceFixture, 
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
        ///     Class (<see cref="clsCatItemData" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ClsCatItemData_Is_Instance_Present_Test()
        {
            // Assert
            _clsCatItemDataInstanceType.ShouldNotBeNull();
            _clsCatItemDataInstance.ShouldNotBeNull();
            _clsCatItemDataInstanceFixture.ShouldNotBeNull();
            _clsCatItemDataInstance.ShouldBeAssignableTo<clsCatItemData>();
            _clsCatItemDataInstanceFixture.ShouldBeAssignableTo<clsCatItemData>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (clsCatItemData) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ClsCatItemData_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var arraysize = CreateType<int>();
            clsCatItemData instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new clsCatItemData(arraysize);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _clsCatItemDataInstance.ShouldNotBeNull();
            _clsCatItemDataInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<clsCatItemData>();
        }

        #endregion

        #region General Constructor : Class (clsCatItemData) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ClsCatItemData_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var arraysize = CreateType<int>();
            clsCatItemData instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new clsCatItemData(arraysize);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _clsCatItemDataInstance.ShouldNotBeNull();
            _clsCatItemDataInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #endregion
    }
}