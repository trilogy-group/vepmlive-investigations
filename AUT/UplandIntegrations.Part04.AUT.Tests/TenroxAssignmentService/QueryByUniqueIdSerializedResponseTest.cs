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
using QueryByUniqueIdSerializedResponse = UplandIntegrations.TenroxAssignmentService;

namespace UplandIntegrations.TenroxAssignmentService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxAssignmentService.QueryByUniqueIdSerializedResponse" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxAssignmentService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class QueryByUniqueIdSerializedResponseTest : AbstractBaseSetupV3Test
    {
        public QueryByUniqueIdSerializedResponseTest() : base(typeof(QueryByUniqueIdSerializedResponse))
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

        #region General Initializer : Class (QueryByUniqueIdSerializedResponse) Initializer

        #region Fields

        private const string FieldQueryByUniqueIdSerializedResult = "QueryByUniqueIdSerializedResult";

        #endregion

        private Type _queryByUniqueIdSerializedResponseInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private QueryByUniqueIdSerializedResponse _queryByUniqueIdSerializedResponseInstance;
        private QueryByUniqueIdSerializedResponse _queryByUniqueIdSerializedResponseInstanceFixture;

        #region General Initializer : Class (QueryByUniqueIdSerializedResponse) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="QueryByUniqueIdSerializedResponse" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _queryByUniqueIdSerializedResponseInstanceType = typeof(QueryByUniqueIdSerializedResponse);
            _queryByUniqueIdSerializedResponseInstanceFixture = this.Create<QueryByUniqueIdSerializedResponse>(true);
            _queryByUniqueIdSerializedResponseInstance = _queryByUniqueIdSerializedResponseInstanceFixture ?? this.Create<QueryByUniqueIdSerializedResponse>(false);
            CurrentInstance = _queryByUniqueIdSerializedResponseInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (QueryByUniqueIdSerializedResponse)

        #region General Initializer : Class (QueryByUniqueIdSerializedResponse) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="QueryByUniqueIdSerializedResponse" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldQueryByUniqueIdSerializedResult)]
        public void AUT_QueryByUniqueIdSerializedResponse_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_queryByUniqueIdSerializedResponseInstanceFixture, 
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
        ///     Class (<see cref="QueryByUniqueIdSerializedResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_QueryByUniqueIdSerializedResponse_Is_Instance_Present_Test()
        {
            // Assert
            _queryByUniqueIdSerializedResponseInstanceType.ShouldNotBeNull();
            _queryByUniqueIdSerializedResponseInstance.ShouldNotBeNull();
            _queryByUniqueIdSerializedResponseInstanceFixture.ShouldNotBeNull();
            _queryByUniqueIdSerializedResponseInstance.ShouldBeAssignableTo<QueryByUniqueIdSerializedResponse>();
            _queryByUniqueIdSerializedResponseInstanceFixture.ShouldBeAssignableTo<QueryByUniqueIdSerializedResponse>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (QueryByUniqueIdSerializedResponse) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_QueryByUniqueIdSerializedResponse_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            QueryByUniqueIdSerializedResponse instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _queryByUniqueIdSerializedResponseInstanceType.ShouldNotBeNull();
            _queryByUniqueIdSerializedResponseInstance.ShouldNotBeNull();
            _queryByUniqueIdSerializedResponseInstanceFixture.ShouldNotBeNull();
            _queryByUniqueIdSerializedResponseInstance.ShouldBeAssignableTo<QueryByUniqueIdSerializedResponse>();
            _queryByUniqueIdSerializedResponseInstanceFixture.ShouldBeAssignableTo<QueryByUniqueIdSerializedResponse>();
        }

        #endregion

        #region General Constructor : Class (QueryByUniqueIdSerializedResponse) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByUniqueIdSerializedResponse_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var QueryByUniqueIdSerializedResult = this.CreateType<string>();
            QueryByUniqueIdSerializedResponse instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new QueryByUniqueIdSerializedResponse(QueryByUniqueIdSerializedResult);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _queryByUniqueIdSerializedResponseInstance.ShouldNotBeNull();
            _queryByUniqueIdSerializedResponseInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<QueryByUniqueIdSerializedResponse>();
        }

        #endregion

        #region General Constructor : Class (QueryByUniqueIdSerializedResponse) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByUniqueIdSerializedResponse_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var QueryByUniqueIdSerializedResult = this.CreateType<string>();
            QueryByUniqueIdSerializedResponse instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new QueryByUniqueIdSerializedResponse(QueryByUniqueIdSerializedResult);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _queryByUniqueIdSerializedResponseInstance.ShouldNotBeNull();
            _queryByUniqueIdSerializedResponseInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (QueryByUniqueIdSerializedResponse) instance created

        /// <summary>
        ///     Class (<see cref="QueryByUniqueIdSerializedResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByUniqueIdSerializedResponse_Is_Created_Test()
        {
            // Assert
            _queryByUniqueIdSerializedResponseInstance.ShouldNotBeNull();
            _queryByUniqueIdSerializedResponseInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (QueryByUniqueIdSerializedResponse) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="QueryByUniqueIdSerializedResponse" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_QueryByUniqueIdSerializedResponse_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<QueryByUniqueIdSerializedResponse>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (QueryByUniqueIdSerializedResponse) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="QueryByUniqueIdSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByUniqueIdSerializedResponse_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<QueryByUniqueIdSerializedResponse>(Fixture);
        }

        #endregion

        #region General Constructor : Class (QueryByUniqueIdSerializedResponse) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByUniqueIdSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByUniqueIdSerializedResponse_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfQueryByUniqueIdSerializedResponse = {  };
            Type [] methodQueryByUniqueIdSerializedResponsePrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_queryByUniqueIdSerializedResponseInstanceType, methodQueryByUniqueIdSerializedResponsePrametersTypes, parametersOfQueryByUniqueIdSerializedResponse);
        }

        #endregion

        #region General Constructor : Class (QueryByUniqueIdSerializedResponse) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByUniqueIdSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByUniqueIdSerializedResponse_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodQueryByUniqueIdSerializedResponsePrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_queryByUniqueIdSerializedResponseInstanceType, Fixture, methodQueryByUniqueIdSerializedResponsePrametersTypes);
        }

        #endregion

        #region General Constructor : Class (QueryByUniqueIdSerializedResponse) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByUniqueIdSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByUniqueIdSerializedResponse_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var QueryByUniqueIdSerializedResult = this.CreateType<string>();
            object[] parametersOfQueryByUniqueIdSerializedResponse = { QueryByUniqueIdSerializedResult };
            var methodQueryByUniqueIdSerializedResponsePrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_queryByUniqueIdSerializedResponseInstanceType, methodQueryByUniqueIdSerializedResponsePrametersTypes, parametersOfQueryByUniqueIdSerializedResponse);
        }

        #endregion

        #region General Constructor : Class (QueryByUniqueIdSerializedResponse) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByUniqueIdSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByUniqueIdSerializedResponse_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodQueryByUniqueIdSerializedResponsePrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_queryByUniqueIdSerializedResponseInstanceType, Fixture, methodQueryByUniqueIdSerializedResponsePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}