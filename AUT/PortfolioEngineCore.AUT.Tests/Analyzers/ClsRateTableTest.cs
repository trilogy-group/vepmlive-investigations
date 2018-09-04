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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="CostDataValues.clsRateTable" />)
    ///     and namespace <see cref="CostDataValues"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ClsRateTableTest : AbstractBaseSetupTypedTest<clsRateTable>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (clsRateTable) Initializer

        private const string FieldUID = "UID";
        private const string FieldName = "Name";
        private const string FieldzRate = "zRate";
        private const string Fieldmxdim = "mxdim";
        private Type _clsRateTableInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private clsRateTable _clsRateTableInstance;
        private clsRateTable _clsRateTableInstanceFixture;

        #region General Initializer : Class (clsRateTable) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="clsRateTable" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _clsRateTableInstanceType = typeof(clsRateTable);
            _clsRateTableInstanceFixture = Create(true);
            _clsRateTableInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (clsRateTable)

        #region General Initializer : Class (clsRateTable) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="clsRateTable" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldUID)]
        [TestCase(FieldName)]
        [TestCase(FieldzRate)]
        [TestCase(Fieldmxdim)]
        public void AUT_ClsRateTable_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_clsRateTableInstanceFixture, 
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
        ///     Class (<see cref="clsRateTable" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ClsRateTable_Is_Instance_Present_Test()
        {
            // Assert
            _clsRateTableInstanceType.ShouldNotBeNull();
            _clsRateTableInstance.ShouldNotBeNull();
            _clsRateTableInstanceFixture.ShouldNotBeNull();
            _clsRateTableInstance.ShouldBeAssignableTo<clsRateTable>();
            _clsRateTableInstanceFixture.ShouldBeAssignableTo<clsRateTable>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (clsRateTable) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ClsRateTable_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var arraysize = CreateType<int>();
            clsRateTable instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new clsRateTable(arraysize);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _clsRateTableInstance.ShouldNotBeNull();
            _clsRateTableInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<clsRateTable>();
        }

        #endregion

        #region General Constructor : Class (clsRateTable) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ClsRateTable_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var arraysize = CreateType<int>();
            clsRateTable instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new clsRateTable(arraysize);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _clsRateTableInstance.ShouldNotBeNull();
            _clsRateTableInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #endregion
    }
}