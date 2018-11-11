using System;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace PortfolioEngineCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.DBAccess" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DBAccessTest : AbstractBaseSetupTypedTest<DBAccess>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DBAccess) Initializer

        private Type _dBAccessInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DBAccess _dBAccessInstance;
        private DBAccess _dBAccessInstanceFixture;

        #region General Initializer : Class (DBAccess) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DBAccess" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dBAccessInstanceType = typeof(DBAccess);
            _dBAccessInstanceFixture = Create(true);
            _dBAccessInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="DBAccess" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_DBAccess_Is_Instance_Present_Test()
        {
            // Assert
            _dBAccessInstanceType.ShouldNotBeNull();
            _dBAccessInstance.ShouldNotBeNull();
            _dBAccessInstanceFixture.ShouldNotBeNull();
            _dBAccessInstance.ShouldBeAssignableTo<DBAccess>();
            _dBAccessInstanceFixture.ShouldBeAssignableTo<DBAccess>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DBAccess) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DBAccess_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var connectionString = CreateType<string>();
            DBAccess instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new DBAccess(connectionString);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _dBAccessInstance.ShouldNotBeNull();
            _dBAccessInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<DBAccess>();
        }

        #endregion

        #region General Constructor : Class (DBAccess) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DBAccess_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var connectionString = CreateType<string>();
            DBAccess instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new DBAccess(connectionString);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _dBAccessInstance.ShouldNotBeNull();
            _dBAccessInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (DBAccess) instance created

        /// <summary>
        ///     Class (<see cref="DBAccess" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DBAccess_Is_Created_Test()
        {
            // Assert
            _dBAccessInstance.ShouldNotBeNull();
            _dBAccessInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (DBAccess) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="DBAccess" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_DBAccess_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<DBAccess>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (DBAccess) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="DBAccess" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DBAccess_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<DBAccess>(Fixture);
        }

        #endregion

        #region General Constructor : Class (DBAccess) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="DBAccess" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DBAccess_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var connectionString = CreateType<string>();
            object[] parametersOfDBAccess = { connectionString };
            var methodDBAccessPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_dBAccessInstanceType, methodDBAccessPrametersTypes, parametersOfDBAccess);
        }

        #endregion

        #region General Constructor : Class (DBAccess) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="DBAccess" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DBAccess_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodDBAccessPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_dBAccessInstanceType, Fixture, methodDBAccessPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (DBAccess) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="DBAccess" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DBAccess_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var connectionString = CreateType<string>();
            var connection = CreateType<SqlConnection>();
            object[] parametersOfDBAccess = { connectionString, connection };
            var methodDBAccessPrametersTypes = new Type[] { typeof(string), typeof(SqlConnection) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_dBAccessInstanceType, methodDBAccessPrametersTypes, parametersOfDBAccess);
        }

        #endregion

        #region General Constructor : Class (DBAccess) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="DBAccess" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DBAccess_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodDBAccessPrametersTypes = new Type[] { typeof(string), typeof(SqlConnection) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_dBAccessInstanceType, Fixture, methodDBAccessPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}