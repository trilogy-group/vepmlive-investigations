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
using UplandIntegrations.TenroxClientService;
using QueryByUniqueIdSerializedRequest = UplandIntegrations.TenroxClientService;

namespace UplandIntegrations.TenroxClientService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxClientService.QueryByUniqueIdSerializedRequest" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxClientService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class QueryByUniqueIdSerializedRequestTest : AbstractBaseSetupV3Test
    {
        public QueryByUniqueIdSerializedRequestTest() : base(typeof(QueryByUniqueIdSerializedRequest))
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

        #region General Initializer : Class (QueryByUniqueIdSerializedRequest) Initializer

        #region Fields

        private const string Fieldp_strToken = "p_strToken";
        private const string Fieldp_intUniqueId = "p_intUniqueId";

        #endregion

        private Type _queryByUniqueIdSerializedRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private QueryByUniqueIdSerializedRequest _queryByUniqueIdSerializedRequestInstance;
        private QueryByUniqueIdSerializedRequest _queryByUniqueIdSerializedRequestInstanceFixture;

        #region General Initializer : Class (QueryByUniqueIdSerializedRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="QueryByUniqueIdSerializedRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _queryByUniqueIdSerializedRequestInstanceType = typeof(QueryByUniqueIdSerializedRequest);
            _queryByUniqueIdSerializedRequestInstanceFixture = this.Create<QueryByUniqueIdSerializedRequest>(true);
            _queryByUniqueIdSerializedRequestInstance = _queryByUniqueIdSerializedRequestInstanceFixture ?? this.Create<QueryByUniqueIdSerializedRequest>(false);
            CurrentInstance = _queryByUniqueIdSerializedRequestInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (QueryByUniqueIdSerializedRequest)

        #region General Initializer : Class (QueryByUniqueIdSerializedRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="QueryByUniqueIdSerializedRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldp_strToken)]
        [TestCase(Fieldp_intUniqueId)]
        public void AUT_QueryByUniqueIdSerializedRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_queryByUniqueIdSerializedRequestInstanceFixture, 
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
        ///     Class (<see cref="QueryByUniqueIdSerializedRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_QueryByUniqueIdSerializedRequest_Is_Instance_Present_Test()
        {
            // Assert
            _queryByUniqueIdSerializedRequestInstanceType.ShouldNotBeNull();
            _queryByUniqueIdSerializedRequestInstance.ShouldNotBeNull();
            _queryByUniqueIdSerializedRequestInstanceFixture.ShouldNotBeNull();
            _queryByUniqueIdSerializedRequestInstance.ShouldBeAssignableTo<QueryByUniqueIdSerializedRequest>();
            _queryByUniqueIdSerializedRequestInstanceFixture.ShouldBeAssignableTo<QueryByUniqueIdSerializedRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (QueryByUniqueIdSerializedRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_QueryByUniqueIdSerializedRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            QueryByUniqueIdSerializedRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _queryByUniqueIdSerializedRequestInstanceType.ShouldNotBeNull();
            _queryByUniqueIdSerializedRequestInstance.ShouldNotBeNull();
            _queryByUniqueIdSerializedRequestInstanceFixture.ShouldNotBeNull();
            _queryByUniqueIdSerializedRequestInstance.ShouldBeAssignableTo<QueryByUniqueIdSerializedRequest>();
            _queryByUniqueIdSerializedRequestInstanceFixture.ShouldBeAssignableTo<QueryByUniqueIdSerializedRequest>();
        }

        #endregion

        #region General Constructor : Class (QueryByUniqueIdSerializedRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByUniqueIdSerializedRequest_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var p_strToken = this.CreateType<string>();
            var p_intUniqueId = this.CreateType<int>();
            QueryByUniqueIdSerializedRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new QueryByUniqueIdSerializedRequest(p_strToken, p_intUniqueId);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _queryByUniqueIdSerializedRequestInstance.ShouldNotBeNull();
            _queryByUniqueIdSerializedRequestInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<QueryByUniqueIdSerializedRequest>();
        }

        #endregion

        #region General Constructor : Class (QueryByUniqueIdSerializedRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByUniqueIdSerializedRequest_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var p_strToken = this.CreateType<string>();
            var p_intUniqueId = this.CreateType<int>();
            QueryByUniqueIdSerializedRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new QueryByUniqueIdSerializedRequest(p_strToken, p_intUniqueId);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _queryByUniqueIdSerializedRequestInstance.ShouldNotBeNull();
            _queryByUniqueIdSerializedRequestInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (QueryByUniqueIdSerializedRequest) instance created

        /// <summary>
        ///     Class (<see cref="QueryByUniqueIdSerializedRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByUniqueIdSerializedRequest_Is_Created_Test()
        {
            // Assert
            _queryByUniqueIdSerializedRequestInstance.ShouldNotBeNull();
            _queryByUniqueIdSerializedRequestInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (QueryByUniqueIdSerializedRequest) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="QueryByUniqueIdSerializedRequest" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_QueryByUniqueIdSerializedRequest_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<QueryByUniqueIdSerializedRequest>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (QueryByUniqueIdSerializedRequest) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="QueryByUniqueIdSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByUniqueIdSerializedRequest_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<QueryByUniqueIdSerializedRequest>(Fixture);
        }

        #endregion

        #region General Constructor : Class (QueryByUniqueIdSerializedRequest) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByUniqueIdSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByUniqueIdSerializedRequest_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfQueryByUniqueIdSerializedRequest = {  };
            Type [] methodQueryByUniqueIdSerializedRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_queryByUniqueIdSerializedRequestInstanceType, methodQueryByUniqueIdSerializedRequestPrametersTypes, parametersOfQueryByUniqueIdSerializedRequest);
        }

        #endregion

        #region General Constructor : Class (QueryByUniqueIdSerializedRequest) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByUniqueIdSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByUniqueIdSerializedRequest_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodQueryByUniqueIdSerializedRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_queryByUniqueIdSerializedRequestInstanceType, Fixture, methodQueryByUniqueIdSerializedRequestPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (QueryByUniqueIdSerializedRequest) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByUniqueIdSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByUniqueIdSerializedRequest_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var p_strToken = this.CreateType<string>();
            var p_intUniqueId = this.CreateType<int>();
            object[] parametersOfQueryByUniqueIdSerializedRequest = { p_strToken, p_intUniqueId };
            var methodQueryByUniqueIdSerializedRequestPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_queryByUniqueIdSerializedRequestInstanceType, methodQueryByUniqueIdSerializedRequestPrametersTypes, parametersOfQueryByUniqueIdSerializedRequest);
        }

        #endregion

        #region General Constructor : Class (QueryByUniqueIdSerializedRequest) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByUniqueIdSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByUniqueIdSerializedRequest_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodQueryByUniqueIdSerializedRequestPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_queryByUniqueIdSerializedRequestInstanceType, Fixture, methodQueryByUniqueIdSerializedRequestPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}