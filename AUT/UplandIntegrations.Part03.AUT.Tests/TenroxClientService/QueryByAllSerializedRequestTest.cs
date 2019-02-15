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
using QueryByAllSerializedRequest = UplandIntegrations.TenroxClientService;

namespace UplandIntegrations.TenroxClientService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxClientService.QueryByAllSerializedRequest" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxClientService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class QueryByAllSerializedRequestTest : AbstractBaseSetupV3Test
    {
        public QueryByAllSerializedRequestTest() : base(typeof(QueryByAllSerializedRequest))
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

        #region General Initializer : Class (QueryByAllSerializedRequest) Initializer

        #region Fields

        private const string Fieldp_strToken = "p_strToken";

        #endregion

        private Type _queryByAllSerializedRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private QueryByAllSerializedRequest _queryByAllSerializedRequestInstance;
        private QueryByAllSerializedRequest _queryByAllSerializedRequestInstanceFixture;

        #region General Initializer : Class (QueryByAllSerializedRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="QueryByAllSerializedRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _queryByAllSerializedRequestInstanceType = typeof(QueryByAllSerializedRequest);
            _queryByAllSerializedRequestInstanceFixture = this.Create<QueryByAllSerializedRequest>(true);
            _queryByAllSerializedRequestInstance = _queryByAllSerializedRequestInstanceFixture ?? this.Create<QueryByAllSerializedRequest>(false);
            CurrentInstance = _queryByAllSerializedRequestInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (QueryByAllSerializedRequest)

        #region General Initializer : Class (QueryByAllSerializedRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="QueryByAllSerializedRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldp_strToken)]
        public void AUT_QueryByAllSerializedRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_queryByAllSerializedRequestInstanceFixture, 
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
        ///     Class (<see cref="QueryByAllSerializedRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_QueryByAllSerializedRequest_Is_Instance_Present_Test()
        {
            // Assert
            _queryByAllSerializedRequestInstanceType.ShouldNotBeNull();
            _queryByAllSerializedRequestInstance.ShouldNotBeNull();
            _queryByAllSerializedRequestInstanceFixture.ShouldNotBeNull();
            _queryByAllSerializedRequestInstance.ShouldBeAssignableTo<QueryByAllSerializedRequest>();
            _queryByAllSerializedRequestInstanceFixture.ShouldBeAssignableTo<QueryByAllSerializedRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (QueryByAllSerializedRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_QueryByAllSerializedRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            QueryByAllSerializedRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _queryByAllSerializedRequestInstanceType.ShouldNotBeNull();
            _queryByAllSerializedRequestInstance.ShouldNotBeNull();
            _queryByAllSerializedRequestInstanceFixture.ShouldNotBeNull();
            _queryByAllSerializedRequestInstance.ShouldBeAssignableTo<QueryByAllSerializedRequest>();
            _queryByAllSerializedRequestInstanceFixture.ShouldBeAssignableTo<QueryByAllSerializedRequest>();
        }

        #endregion

        #region General Constructor : Class (QueryByAllSerializedRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByAllSerializedRequest_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var p_strToken = this.CreateType<string>();
            QueryByAllSerializedRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new QueryByAllSerializedRequest(p_strToken);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _queryByAllSerializedRequestInstance.ShouldNotBeNull();
            _queryByAllSerializedRequestInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<QueryByAllSerializedRequest>();
        }

        #endregion

        #region General Constructor : Class (QueryByAllSerializedRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByAllSerializedRequest_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var p_strToken = this.CreateType<string>();
            QueryByAllSerializedRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new QueryByAllSerializedRequest(p_strToken);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _queryByAllSerializedRequestInstance.ShouldNotBeNull();
            _queryByAllSerializedRequestInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (QueryByAllSerializedRequest) instance created

        /// <summary>
        ///     Class (<see cref="QueryByAllSerializedRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByAllSerializedRequest_Is_Created_Test()
        {
            // Assert
            _queryByAllSerializedRequestInstance.ShouldNotBeNull();
            _queryByAllSerializedRequestInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (QueryByAllSerializedRequest) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="QueryByAllSerializedRequest" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_QueryByAllSerializedRequest_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<QueryByAllSerializedRequest>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (QueryByAllSerializedRequest) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="QueryByAllSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByAllSerializedRequest_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<QueryByAllSerializedRequest>(Fixture);
        }

        #endregion

        #region General Constructor : Class (QueryByAllSerializedRequest) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByAllSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByAllSerializedRequest_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfQueryByAllSerializedRequest = {  };
            Type [] methodQueryByAllSerializedRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_queryByAllSerializedRequestInstanceType, methodQueryByAllSerializedRequestPrametersTypes, parametersOfQueryByAllSerializedRequest);
        }

        #endregion

        #region General Constructor : Class (QueryByAllSerializedRequest) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByAllSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByAllSerializedRequest_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodQueryByAllSerializedRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_queryByAllSerializedRequestInstanceType, Fixture, methodQueryByAllSerializedRequestPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (QueryByAllSerializedRequest) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByAllSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByAllSerializedRequest_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var p_strToken = this.CreateType<string>();
            object[] parametersOfQueryByAllSerializedRequest = { p_strToken };
            var methodQueryByAllSerializedRequestPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_queryByAllSerializedRequestInstanceType, methodQueryByAllSerializedRequestPrametersTypes, parametersOfQueryByAllSerializedRequest);
        }

        #endregion

        #region General Constructor : Class (QueryByAllSerializedRequest) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByAllSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByAllSerializedRequest_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodQueryByAllSerializedRequestPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_queryByAllSerializedRequestInstanceType, Fixture, methodQueryByAllSerializedRequestPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}