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
using QueryByAllSerializedResponse = UplandIntegrations.TenroxAssignmentService;

namespace UplandIntegrations.TenroxAssignmentService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxAssignmentService.QueryByAllSerializedResponse" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxAssignmentService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class QueryByAllSerializedResponseTest : AbstractBaseSetupV3Test
    {
        public QueryByAllSerializedResponseTest() : base(typeof(QueryByAllSerializedResponse))
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

        #region General Initializer : Class (QueryByAllSerializedResponse) Initializer

        #region Fields

        private const string FieldQueryByAllSerializedResult = "QueryByAllSerializedResult";

        #endregion

        private Type _queryByAllSerializedResponseInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private QueryByAllSerializedResponse _queryByAllSerializedResponseInstance;
        private QueryByAllSerializedResponse _queryByAllSerializedResponseInstanceFixture;

        #region General Initializer : Class (QueryByAllSerializedResponse) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="QueryByAllSerializedResponse" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _queryByAllSerializedResponseInstanceType = typeof(QueryByAllSerializedResponse);
            _queryByAllSerializedResponseInstanceFixture = this.Create<QueryByAllSerializedResponse>(true);
            _queryByAllSerializedResponseInstance = _queryByAllSerializedResponseInstanceFixture ?? this.Create<QueryByAllSerializedResponse>(false);
            CurrentInstance = _queryByAllSerializedResponseInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (QueryByAllSerializedResponse)

        #region General Initializer : Class (QueryByAllSerializedResponse) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="QueryByAllSerializedResponse" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldQueryByAllSerializedResult)]
        public void AUT_QueryByAllSerializedResponse_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_queryByAllSerializedResponseInstanceFixture, 
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
        ///     Class (<see cref="QueryByAllSerializedResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_QueryByAllSerializedResponse_Is_Instance_Present_Test()
        {
            // Assert
            _queryByAllSerializedResponseInstanceType.ShouldNotBeNull();
            _queryByAllSerializedResponseInstance.ShouldNotBeNull();
            _queryByAllSerializedResponseInstanceFixture.ShouldNotBeNull();
            _queryByAllSerializedResponseInstance.ShouldBeAssignableTo<QueryByAllSerializedResponse>();
            _queryByAllSerializedResponseInstanceFixture.ShouldBeAssignableTo<QueryByAllSerializedResponse>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (QueryByAllSerializedResponse) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_QueryByAllSerializedResponse_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            QueryByAllSerializedResponse instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _queryByAllSerializedResponseInstanceType.ShouldNotBeNull();
            _queryByAllSerializedResponseInstance.ShouldNotBeNull();
            _queryByAllSerializedResponseInstanceFixture.ShouldNotBeNull();
            _queryByAllSerializedResponseInstance.ShouldBeAssignableTo<QueryByAllSerializedResponse>();
            _queryByAllSerializedResponseInstanceFixture.ShouldBeAssignableTo<QueryByAllSerializedResponse>();
        }

        #endregion

        #region General Constructor : Class (QueryByAllSerializedResponse) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByAllSerializedResponse_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var QueryByAllSerializedResult = this.CreateType<string>();
            QueryByAllSerializedResponse instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new QueryByAllSerializedResponse(QueryByAllSerializedResult);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _queryByAllSerializedResponseInstance.ShouldNotBeNull();
            _queryByAllSerializedResponseInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<QueryByAllSerializedResponse>();
        }

        #endregion

        #region General Constructor : Class (QueryByAllSerializedResponse) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByAllSerializedResponse_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var QueryByAllSerializedResult = this.CreateType<string>();
            QueryByAllSerializedResponse instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new QueryByAllSerializedResponse(QueryByAllSerializedResult);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _queryByAllSerializedResponseInstance.ShouldNotBeNull();
            _queryByAllSerializedResponseInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (QueryByAllSerializedResponse) instance created

        /// <summary>
        ///     Class (<see cref="QueryByAllSerializedResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByAllSerializedResponse_Is_Created_Test()
        {
            // Assert
            _queryByAllSerializedResponseInstance.ShouldNotBeNull();
            _queryByAllSerializedResponseInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (QueryByAllSerializedResponse) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="QueryByAllSerializedResponse" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_QueryByAllSerializedResponse_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<QueryByAllSerializedResponse>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (QueryByAllSerializedResponse) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="QueryByAllSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByAllSerializedResponse_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<QueryByAllSerializedResponse>(Fixture);
        }

        #endregion

        #region General Constructor : Class (QueryByAllSerializedResponse) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByAllSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByAllSerializedResponse_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfQueryByAllSerializedResponse = {  };
            Type [] methodQueryByAllSerializedResponsePrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_queryByAllSerializedResponseInstanceType, methodQueryByAllSerializedResponsePrametersTypes, parametersOfQueryByAllSerializedResponse);
        }

        #endregion

        #region General Constructor : Class (QueryByAllSerializedResponse) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByAllSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByAllSerializedResponse_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodQueryByAllSerializedResponsePrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_queryByAllSerializedResponseInstanceType, Fixture, methodQueryByAllSerializedResponsePrametersTypes);
        }

        #endregion

        #region General Constructor : Class (QueryByAllSerializedResponse) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByAllSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByAllSerializedResponse_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var QueryByAllSerializedResult = this.CreateType<string>();
            object[] parametersOfQueryByAllSerializedResponse = { QueryByAllSerializedResult };
            var methodQueryByAllSerializedResponsePrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_queryByAllSerializedResponseInstanceType, methodQueryByAllSerializedResponsePrametersTypes, parametersOfQueryByAllSerializedResponse);
        }

        #endregion

        #region General Constructor : Class (QueryByAllSerializedResponse) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByAllSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByAllSerializedResponse_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodQueryByAllSerializedResponsePrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_queryByAllSerializedResponseInstanceType, Fixture, methodQueryByAllSerializedResponsePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}