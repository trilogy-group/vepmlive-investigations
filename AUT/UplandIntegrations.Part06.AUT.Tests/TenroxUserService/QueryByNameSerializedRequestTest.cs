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
using System.Runtime.Serialization;
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
using UplandIntegrations.TenroxUserService;
using QueryByNameSerializedRequest = UplandIntegrations.TenroxUserService;

namespace UplandIntegrations.TenroxUserService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxUserService.QueryByNameSerializedRequest" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxUserService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class QueryByNameSerializedRequestTest : AbstractBaseSetupV3Test
    {
        public QueryByNameSerializedRequestTest() : base(typeof(QueryByNameSerializedRequest))
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

        #region General Initializer : Class (QueryByNameSerializedRequest) Initializer

        #region Fields

        private const string Fieldp_strToken = "p_strToken";
        private const string Fieldp_strName = "p_strName";

        #endregion

        private Type _queryByNameSerializedRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private QueryByNameSerializedRequest _queryByNameSerializedRequestInstance;
        private QueryByNameSerializedRequest _queryByNameSerializedRequestInstanceFixture;

        #region General Initializer : Class (QueryByNameSerializedRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="QueryByNameSerializedRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _queryByNameSerializedRequestInstanceType = typeof(QueryByNameSerializedRequest);
            _queryByNameSerializedRequestInstanceFixture = this.Create<QueryByNameSerializedRequest>(true);
            _queryByNameSerializedRequestInstance = _queryByNameSerializedRequestInstanceFixture ?? this.Create<QueryByNameSerializedRequest>(false);
            CurrentInstance = _queryByNameSerializedRequestInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (QueryByNameSerializedRequest)

        #region General Initializer : Class (QueryByNameSerializedRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="QueryByNameSerializedRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldp_strToken)]
        [TestCase(Fieldp_strName)]
        public void AUT_QueryByNameSerializedRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_queryByNameSerializedRequestInstanceFixture, 
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
        ///     Class (<see cref="QueryByNameSerializedRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_QueryByNameSerializedRequest_Is_Instance_Present_Test()
        {
            // Assert
            _queryByNameSerializedRequestInstanceType.ShouldNotBeNull();
            _queryByNameSerializedRequestInstance.ShouldNotBeNull();
            _queryByNameSerializedRequestInstanceFixture.ShouldNotBeNull();
            _queryByNameSerializedRequestInstance.ShouldBeAssignableTo<QueryByNameSerializedRequest>();
            _queryByNameSerializedRequestInstanceFixture.ShouldBeAssignableTo<QueryByNameSerializedRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (QueryByNameSerializedRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_QueryByNameSerializedRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            QueryByNameSerializedRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _queryByNameSerializedRequestInstanceType.ShouldNotBeNull();
            _queryByNameSerializedRequestInstance.ShouldNotBeNull();
            _queryByNameSerializedRequestInstanceFixture.ShouldNotBeNull();
            _queryByNameSerializedRequestInstance.ShouldBeAssignableTo<QueryByNameSerializedRequest>();
            _queryByNameSerializedRequestInstanceFixture.ShouldBeAssignableTo<QueryByNameSerializedRequest>();
        }

        #endregion

        #region General Constructor : Class (QueryByNameSerializedRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByNameSerializedRequest_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var p_strToken = this.CreateType<string>();
            var p_strName = this.CreateType<string>();
            QueryByNameSerializedRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new QueryByNameSerializedRequest(p_strToken, p_strName);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _queryByNameSerializedRequestInstance.ShouldNotBeNull();
            _queryByNameSerializedRequestInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<QueryByNameSerializedRequest>();
        }

        #endregion

        #region General Constructor : Class (QueryByNameSerializedRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByNameSerializedRequest_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var p_strToken = this.CreateType<string>();
            var p_strName = this.CreateType<string>();
            QueryByNameSerializedRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new QueryByNameSerializedRequest(p_strToken, p_strName);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _queryByNameSerializedRequestInstance.ShouldNotBeNull();
            _queryByNameSerializedRequestInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (QueryByNameSerializedRequest) instance created

        /// <summary>
        ///     Class (<see cref="QueryByNameSerializedRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByNameSerializedRequest_Is_Created_Test()
        {
            // Assert
            _queryByNameSerializedRequestInstance.ShouldNotBeNull();
            _queryByNameSerializedRequestInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (QueryByNameSerializedRequest) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="QueryByNameSerializedRequest" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_QueryByNameSerializedRequest_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<QueryByNameSerializedRequest>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (QueryByNameSerializedRequest) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="QueryByNameSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByNameSerializedRequest_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<QueryByNameSerializedRequest>(Fixture);
        }

        #endregion

        #region General Constructor : Class (QueryByNameSerializedRequest) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByNameSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByNameSerializedRequest_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfQueryByNameSerializedRequest = {  };
            Type [] methodQueryByNameSerializedRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_queryByNameSerializedRequestInstanceType, methodQueryByNameSerializedRequestPrametersTypes, parametersOfQueryByNameSerializedRequest);
        }

        #endregion

        #region General Constructor : Class (QueryByNameSerializedRequest) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByNameSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByNameSerializedRequest_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodQueryByNameSerializedRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_queryByNameSerializedRequestInstanceType, Fixture, methodQueryByNameSerializedRequestPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (QueryByNameSerializedRequest) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByNameSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByNameSerializedRequest_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var p_strToken = this.CreateType<string>();
            var p_strName = this.CreateType<string>();
            object[] parametersOfQueryByNameSerializedRequest = { p_strToken, p_strName };
            var methodQueryByNameSerializedRequestPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_queryByNameSerializedRequestInstanceType, methodQueryByNameSerializedRequestPrametersTypes, parametersOfQueryByNameSerializedRequest);
        }

        #endregion

        #region General Constructor : Class (QueryByNameSerializedRequest) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByNameSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByNameSerializedRequest_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodQueryByNameSerializedRequestPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_queryByNameSerializedRequestInstanceType, Fixture, methodQueryByNameSerializedRequestPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}