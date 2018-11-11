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
using UplandIntegrations.TenroxAssignmentService;
using QueryByIdSerializedRequest = UplandIntegrations.TenroxAssignmentService;

namespace UplandIntegrations.TenroxAssignmentService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxAssignmentService.QueryByIdSerializedRequest" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxAssignmentService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class QueryByIdSerializedRequestTest : AbstractBaseSetupV3Test
    {
        public QueryByIdSerializedRequestTest() : base(typeof(QueryByIdSerializedRequest))
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

        #region General Initializer : Class (QueryByIdSerializedRequest) Initializer

        #region Fields

        private const string Fieldp_strToken = "p_strToken";
        private const string Fieldp_strId = "p_strId";

        #endregion

        private Type _queryByIdSerializedRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private QueryByIdSerializedRequest _queryByIdSerializedRequestInstance;
        private QueryByIdSerializedRequest _queryByIdSerializedRequestInstanceFixture;

        #region General Initializer : Class (QueryByIdSerializedRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="QueryByIdSerializedRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _queryByIdSerializedRequestInstanceType = typeof(QueryByIdSerializedRequest);
            _queryByIdSerializedRequestInstanceFixture = this.Create<QueryByIdSerializedRequest>(true);
            _queryByIdSerializedRequestInstance = _queryByIdSerializedRequestInstanceFixture ?? this.Create<QueryByIdSerializedRequest>(false);
            CurrentInstance = _queryByIdSerializedRequestInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (QueryByIdSerializedRequest)

        #region General Initializer : Class (QueryByIdSerializedRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="QueryByIdSerializedRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldp_strToken)]
        [TestCase(Fieldp_strId)]
        public void AUT_QueryByIdSerializedRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_queryByIdSerializedRequestInstanceFixture, 
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
        ///     Class (<see cref="QueryByIdSerializedRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_QueryByIdSerializedRequest_Is_Instance_Present_Test()
        {
            // Assert
            _queryByIdSerializedRequestInstanceType.ShouldNotBeNull();
            _queryByIdSerializedRequestInstance.ShouldNotBeNull();
            _queryByIdSerializedRequestInstanceFixture.ShouldNotBeNull();
            _queryByIdSerializedRequestInstance.ShouldBeAssignableTo<QueryByIdSerializedRequest>();
            _queryByIdSerializedRequestInstanceFixture.ShouldBeAssignableTo<QueryByIdSerializedRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (QueryByIdSerializedRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_QueryByIdSerializedRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            QueryByIdSerializedRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _queryByIdSerializedRequestInstanceType.ShouldNotBeNull();
            _queryByIdSerializedRequestInstance.ShouldNotBeNull();
            _queryByIdSerializedRequestInstanceFixture.ShouldNotBeNull();
            _queryByIdSerializedRequestInstance.ShouldBeAssignableTo<QueryByIdSerializedRequest>();
            _queryByIdSerializedRequestInstanceFixture.ShouldBeAssignableTo<QueryByIdSerializedRequest>();
        }

        #endregion

        #region General Constructor : Class (QueryByIdSerializedRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByIdSerializedRequest_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var p_strToken = this.CreateType<string>();
            var p_strId = this.CreateType<string>();
            QueryByIdSerializedRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new QueryByIdSerializedRequest(p_strToken, p_strId);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _queryByIdSerializedRequestInstance.ShouldNotBeNull();
            _queryByIdSerializedRequestInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<QueryByIdSerializedRequest>();
        }

        #endregion

        #region General Constructor : Class (QueryByIdSerializedRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByIdSerializedRequest_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var p_strToken = this.CreateType<string>();
            var p_strId = this.CreateType<string>();
            QueryByIdSerializedRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new QueryByIdSerializedRequest(p_strToken, p_strId);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _queryByIdSerializedRequestInstance.ShouldNotBeNull();
            _queryByIdSerializedRequestInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (QueryByIdSerializedRequest) instance created

        /// <summary>
        ///     Class (<see cref="QueryByIdSerializedRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByIdSerializedRequest_Is_Created_Test()
        {
            // Assert
            _queryByIdSerializedRequestInstance.ShouldNotBeNull();
            _queryByIdSerializedRequestInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (QueryByIdSerializedRequest) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="QueryByIdSerializedRequest" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_QueryByIdSerializedRequest_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<QueryByIdSerializedRequest>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (QueryByIdSerializedRequest) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="QueryByIdSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByIdSerializedRequest_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<QueryByIdSerializedRequest>(Fixture);
        }

        #endregion

        #region General Constructor : Class (QueryByIdSerializedRequest) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByIdSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByIdSerializedRequest_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfQueryByIdSerializedRequest = {  };
            Type [] methodQueryByIdSerializedRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_queryByIdSerializedRequestInstanceType, methodQueryByIdSerializedRequestPrametersTypes, parametersOfQueryByIdSerializedRequest);
        }

        #endregion

        #region General Constructor : Class (QueryByIdSerializedRequest) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByIdSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByIdSerializedRequest_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodQueryByIdSerializedRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_queryByIdSerializedRequestInstanceType, Fixture, methodQueryByIdSerializedRequestPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (QueryByIdSerializedRequest) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByIdSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByIdSerializedRequest_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var p_strToken = this.CreateType<string>();
            var p_strId = this.CreateType<string>();
            object[] parametersOfQueryByIdSerializedRequest = { p_strToken, p_strId };
            var methodQueryByIdSerializedRequestPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_queryByIdSerializedRequestInstanceType, methodQueryByIdSerializedRequestPrametersTypes, parametersOfQueryByIdSerializedRequest);
        }

        #endregion

        #region General Constructor : Class (QueryByIdSerializedRequest) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByIdSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByIdSerializedRequest_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodQueryByIdSerializedRequestPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_queryByIdSerializedRequestInstanceType, Fixture, methodQueryByIdSerializedRequestPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}