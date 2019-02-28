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
using QueryByIdSerializedResponse = UplandIntegrations.TenroxUserService;

namespace UplandIntegrations.TenroxUserService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxUserService.QueryByIdSerializedResponse" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxUserService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class QueryByIdSerializedResponseTest : AbstractBaseSetupV3Test
    {
        public QueryByIdSerializedResponseTest() : base(typeof(QueryByIdSerializedResponse))
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

        #region General Initializer : Class (QueryByIdSerializedResponse) Initializer

        #region Fields

        private const string FieldQueryByIdSerializedResult = "QueryByIdSerializedResult";

        #endregion

        private Type _queryByIdSerializedResponseInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private QueryByIdSerializedResponse _queryByIdSerializedResponseInstance;
        private QueryByIdSerializedResponse _queryByIdSerializedResponseInstanceFixture;

        #region General Initializer : Class (QueryByIdSerializedResponse) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="QueryByIdSerializedResponse" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _queryByIdSerializedResponseInstanceType = typeof(QueryByIdSerializedResponse);
            _queryByIdSerializedResponseInstanceFixture = this.Create<QueryByIdSerializedResponse>(true);
            _queryByIdSerializedResponseInstance = _queryByIdSerializedResponseInstanceFixture ?? this.Create<QueryByIdSerializedResponse>(false);
            CurrentInstance = _queryByIdSerializedResponseInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (QueryByIdSerializedResponse)

        #region General Initializer : Class (QueryByIdSerializedResponse) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="QueryByIdSerializedResponse" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldQueryByIdSerializedResult)]
        public void AUT_QueryByIdSerializedResponse_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_queryByIdSerializedResponseInstanceFixture, 
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
        ///     Class (<see cref="QueryByIdSerializedResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_QueryByIdSerializedResponse_Is_Instance_Present_Test()
        {
            // Assert
            _queryByIdSerializedResponseInstanceType.ShouldNotBeNull();
            _queryByIdSerializedResponseInstance.ShouldNotBeNull();
            _queryByIdSerializedResponseInstanceFixture.ShouldNotBeNull();
            _queryByIdSerializedResponseInstance.ShouldBeAssignableTo<QueryByIdSerializedResponse>();
            _queryByIdSerializedResponseInstanceFixture.ShouldBeAssignableTo<QueryByIdSerializedResponse>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (QueryByIdSerializedResponse) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_QueryByIdSerializedResponse_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            QueryByIdSerializedResponse instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _queryByIdSerializedResponseInstanceType.ShouldNotBeNull();
            _queryByIdSerializedResponseInstance.ShouldNotBeNull();
            _queryByIdSerializedResponseInstanceFixture.ShouldNotBeNull();
            _queryByIdSerializedResponseInstance.ShouldBeAssignableTo<QueryByIdSerializedResponse>();
            _queryByIdSerializedResponseInstanceFixture.ShouldBeAssignableTo<QueryByIdSerializedResponse>();
        }

        #endregion

        #region General Constructor : Class (QueryByIdSerializedResponse) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByIdSerializedResponse_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var QueryByIdSerializedResult = this.CreateType<string>();
            QueryByIdSerializedResponse instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new QueryByIdSerializedResponse(QueryByIdSerializedResult);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _queryByIdSerializedResponseInstance.ShouldNotBeNull();
            _queryByIdSerializedResponseInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<QueryByIdSerializedResponse>();
        }

        #endregion

        #region General Constructor : Class (QueryByIdSerializedResponse) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByIdSerializedResponse_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var QueryByIdSerializedResult = this.CreateType<string>();
            QueryByIdSerializedResponse instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new QueryByIdSerializedResponse(QueryByIdSerializedResult);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _queryByIdSerializedResponseInstance.ShouldNotBeNull();
            _queryByIdSerializedResponseInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (QueryByIdSerializedResponse) instance created

        /// <summary>
        ///     Class (<see cref="QueryByIdSerializedResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByIdSerializedResponse_Is_Created_Test()
        {
            // Assert
            _queryByIdSerializedResponseInstance.ShouldNotBeNull();
            _queryByIdSerializedResponseInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (QueryByIdSerializedResponse) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="QueryByIdSerializedResponse" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_QueryByIdSerializedResponse_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<QueryByIdSerializedResponse>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (QueryByIdSerializedResponse) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="QueryByIdSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByIdSerializedResponse_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<QueryByIdSerializedResponse>(Fixture);
        }

        #endregion

        #region General Constructor : Class (QueryByIdSerializedResponse) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByIdSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByIdSerializedResponse_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfQueryByIdSerializedResponse = {  };
            Type [] methodQueryByIdSerializedResponsePrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_queryByIdSerializedResponseInstanceType, methodQueryByIdSerializedResponsePrametersTypes, parametersOfQueryByIdSerializedResponse);
        }

        #endregion

        #region General Constructor : Class (QueryByIdSerializedResponse) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByIdSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByIdSerializedResponse_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodQueryByIdSerializedResponsePrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_queryByIdSerializedResponseInstanceType, Fixture, methodQueryByIdSerializedResponsePrametersTypes);
        }

        #endregion

        #region General Constructor : Class (QueryByIdSerializedResponse) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByIdSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByIdSerializedResponse_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var QueryByIdSerializedResult = this.CreateType<string>();
            object[] parametersOfQueryByIdSerializedResponse = { QueryByIdSerializedResult };
            var methodQueryByIdSerializedResponsePrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_queryByIdSerializedResponseInstanceType, methodQueryByIdSerializedResponsePrametersTypes, parametersOfQueryByIdSerializedResponse);
        }

        #endregion

        #region General Constructor : Class (QueryByIdSerializedResponse) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueryByIdSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueryByIdSerializedResponse_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodQueryByIdSerializedResponsePrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_queryByIdSerializedResponseInstanceType, Fixture, methodQueryByIdSerializedResponsePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}