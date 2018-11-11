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
using UplandIntegrations.TenroxProjectService;
using QueryByNameSerializedResponse = UplandIntegrations.TenroxProjectService;

namespace UplandIntegrations.TenroxProjectService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxProjectService.QueryByNameSerializedResponse" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxProjectService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class QueryByNameSerializedResponseTest : AbstractBaseSetupV3Test
    {
        public QueryByNameSerializedResponseTest() : base(typeof(QueryByNameSerializedResponse))
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

        #region General Initializer : Class (QueryByNameSerializedResponse) Initializer

        #region Fields

        private const string FieldQueryByNameSerializedResult = "QueryByNameSerializedResult";

        #endregion

        private Type _queryByNameSerializedResponseInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private QueryByNameSerializedResponse _queryByNameSerializedResponseInstance;
        private QueryByNameSerializedResponse _queryByNameSerializedResponseInstanceFixture;

        #region General Initializer : Class (QueryByNameSerializedResponse) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="QueryByNameSerializedResponse" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _queryByNameSerializedResponseInstanceType = typeof(QueryByNameSerializedResponse);
            _queryByNameSerializedResponseInstanceFixture = this.Create<QueryByNameSerializedResponse>(true);
            _queryByNameSerializedResponseInstance = _queryByNameSerializedResponseInstanceFixture ?? this.Create<QueryByNameSerializedResponse>(false);
            CurrentInstance = _queryByNameSerializedResponseInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (QueryByNameSerializedResponse)

        #region General Initializer : Class (QueryByNameSerializedResponse) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="QueryByNameSerializedResponse" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldQueryByNameSerializedResult)]
        public void AUT_QueryByNameSerializedResponse_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_queryByNameSerializedResponseInstanceFixture, 
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
        ///     Class (<see cref="QueryByNameSerializedResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_QueryByNameSerializedResponse_Is_Instance_Present_Test()
        {
            // Assert
            _queryByNameSerializedResponseInstanceType.ShouldNotBeNull();
            _queryByNameSerializedResponseInstance.ShouldNotBeNull();
            _queryByNameSerializedResponseInstanceFixture.ShouldNotBeNull();
            _queryByNameSerializedResponseInstance.ShouldBeAssignableTo<QueryByNameSerializedResponse>();
            _queryByNameSerializedResponseInstanceFixture.ShouldBeAssignableTo<QueryByNameSerializedResponse>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (QueryByNameSerializedResponse) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_QueryByNameSerializedResponse_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            QueryByNameSerializedResponse instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _queryByNameSerializedResponseInstanceType.ShouldNotBeNull();
            _queryByNameSerializedResponseInstance.ShouldNotBeNull();
            _queryByNameSerializedResponseInstanceFixture.ShouldNotBeNull();
            _queryByNameSerializedResponseInstance.ShouldBeAssignableTo<QueryByNameSerializedResponse>();
            _queryByNameSerializedResponseInstanceFixture.ShouldBeAssignableTo<QueryByNameSerializedResponse>();
        }

        #endregion

        #region General Constructor : Class (QueryByNameSerializedResponse) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByNameSerializedResponse_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var QueryByNameSerializedResult = this.CreateType<string>();
            QueryByNameSerializedResponse instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new QueryByNameSerializedResponse(QueryByNameSerializedResult);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _queryByNameSerializedResponseInstance.ShouldNotBeNull();
            _queryByNameSerializedResponseInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<QueryByNameSerializedResponse>();
        }

        #endregion

        #region General Constructor : Class (QueryByNameSerializedResponse) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByNameSerializedResponse_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var QueryByNameSerializedResult = this.CreateType<string>();
            QueryByNameSerializedResponse instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new QueryByNameSerializedResponse(QueryByNameSerializedResult);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _queryByNameSerializedResponseInstance.ShouldNotBeNull();
            _queryByNameSerializedResponseInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (QueryByNameSerializedResponse) instance created

        /// <summary>
        ///     Class (<see cref="QueryByNameSerializedResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByNameSerializedResponse_Is_Created_Test()
        {
            // Assert
            _queryByNameSerializedResponseInstance.ShouldNotBeNull();
            _queryByNameSerializedResponseInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (QueryByNameSerializedResponse) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="QueryByNameSerializedResponse" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_QueryByNameSerializedResponse_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<QueryByNameSerializedResponse>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (QueryByNameSerializedResponse) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="QueryByNameSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByNameSerializedResponse_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<QueryByNameSerializedResponse>(Fixture);
        }

        #endregion

        #region General Constructor : Class (QueryByNameSerializedResponse) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByNameSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByNameSerializedResponse_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfQueryByNameSerializedResponse = {  };
            Type [] methodQueryByNameSerializedResponsePrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_queryByNameSerializedResponseInstanceType, methodQueryByNameSerializedResponsePrametersTypes, parametersOfQueryByNameSerializedResponse);
        }

        #endregion

        #region General Constructor : Class (QueryByNameSerializedResponse) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByNameSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByNameSerializedResponse_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodQueryByNameSerializedResponsePrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_queryByNameSerializedResponseInstanceType, Fixture, methodQueryByNameSerializedResponsePrametersTypes);
        }

        #endregion

        #region General Constructor : Class (QueryByNameSerializedResponse) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByNameSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByNameSerializedResponse_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var QueryByNameSerializedResult = this.CreateType<string>();
            object[] parametersOfQueryByNameSerializedResponse = { QueryByNameSerializedResult };
            var methodQueryByNameSerializedResponsePrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_queryByNameSerializedResponseInstanceType, methodQueryByNameSerializedResponsePrametersTypes, parametersOfQueryByNameSerializedResponse);
        }

        #endregion

        #region General Constructor : Class (QueryByNameSerializedResponse) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByNameSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByNameSerializedResponse_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodQueryByNameSerializedResponsePrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_queryByNameSerializedResponseInstanceType, Fixture, methodQueryByNameSerializedResponsePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}