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
using GetAllSimpleUsersResponse = UplandIntegrations.TenroxUserService;

namespace UplandIntegrations.TenroxUserService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxUserService.GetAllSimpleUsersResponse" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxUserService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GetAllSimpleUsersResponseTest : AbstractBaseSetupV3Test
    {
        public GetAllSimpleUsersResponseTest() : base(typeof(GetAllSimpleUsersResponse))
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

        #region General Initializer : Class (GetAllSimpleUsersResponse) Initializer

        #region Fields

        private const string FieldGetAllSimpleUsersResult = "GetAllSimpleUsersResult";
        private const string FieldtotalRecords = "totalRecords";

        #endregion

        private Type _getAllSimpleUsersResponseInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private GetAllSimpleUsersResponse _getAllSimpleUsersResponseInstance;
        private GetAllSimpleUsersResponse _getAllSimpleUsersResponseInstanceFixture;

        #region General Initializer : Class (GetAllSimpleUsersResponse) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GetAllSimpleUsersResponse" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _getAllSimpleUsersResponseInstanceType = typeof(GetAllSimpleUsersResponse);
            _getAllSimpleUsersResponseInstanceFixture = this.Create<GetAllSimpleUsersResponse>(true);
            _getAllSimpleUsersResponseInstance = _getAllSimpleUsersResponseInstanceFixture ?? this.Create<GetAllSimpleUsersResponse>(false);
            CurrentInstance = _getAllSimpleUsersResponseInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GetAllSimpleUsersResponse)

        #region General Initializer : Class (GetAllSimpleUsersResponse) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="GetAllSimpleUsersResponse" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldGetAllSimpleUsersResult)]
        [TestCase(FieldtotalRecords)]
        public void AUT_GetAllSimpleUsersResponse_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_getAllSimpleUsersResponseInstanceFixture, 
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
        ///     Class (<see cref="GetAllSimpleUsersResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_GetAllSimpleUsersResponse_Is_Instance_Present_Test()
        {
            // Assert
            _getAllSimpleUsersResponseInstanceType.ShouldNotBeNull();
            _getAllSimpleUsersResponseInstance.ShouldNotBeNull();
            _getAllSimpleUsersResponseInstanceFixture.ShouldNotBeNull();
            _getAllSimpleUsersResponseInstance.ShouldBeAssignableTo<GetAllSimpleUsersResponse>();
            _getAllSimpleUsersResponseInstanceFixture.ShouldBeAssignableTo<GetAllSimpleUsersResponse>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (GetAllSimpleUsersResponse) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_GetAllSimpleUsersResponse_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            GetAllSimpleUsersResponse instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _getAllSimpleUsersResponseInstanceType.ShouldNotBeNull();
            _getAllSimpleUsersResponseInstance.ShouldNotBeNull();
            _getAllSimpleUsersResponseInstanceFixture.ShouldNotBeNull();
            _getAllSimpleUsersResponseInstance.ShouldBeAssignableTo<GetAllSimpleUsersResponse>();
            _getAllSimpleUsersResponseInstanceFixture.ShouldBeAssignableTo<GetAllSimpleUsersResponse>();
        }

        #endregion

        #region General Constructor : Class (GetAllSimpleUsersResponse) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GetAllSimpleUsersResponse_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var GetAllSimpleUsersResult = this.CreateType<UplandIntegrations.TenroxUserService.UserSimple[]>();
            var totalRecords = this.CreateType<int>();
            GetAllSimpleUsersResponse instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new GetAllSimpleUsersResponse(GetAllSimpleUsersResult, totalRecords);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _getAllSimpleUsersResponseInstance.ShouldNotBeNull();
            _getAllSimpleUsersResponseInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<GetAllSimpleUsersResponse>();
        }

        #endregion

        #region General Constructor : Class (GetAllSimpleUsersResponse) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GetAllSimpleUsersResponse_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var GetAllSimpleUsersResult = this.CreateType<UplandIntegrations.TenroxUserService.UserSimple[]>();
            var totalRecords = this.CreateType<int>();
            GetAllSimpleUsersResponse instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new GetAllSimpleUsersResponse(GetAllSimpleUsersResult, totalRecords);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _getAllSimpleUsersResponseInstance.ShouldNotBeNull();
            _getAllSimpleUsersResponseInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (GetAllSimpleUsersResponse) instance created

        /// <summary>
        ///     Class (<see cref="GetAllSimpleUsersResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GetAllSimpleUsersResponse_Is_Created_Test()
        {
            // Assert
            _getAllSimpleUsersResponseInstance.ShouldNotBeNull();
            _getAllSimpleUsersResponseInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (GetAllSimpleUsersResponse) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="GetAllSimpleUsersResponse" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_GetAllSimpleUsersResponse_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<GetAllSimpleUsersResponse>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (GetAllSimpleUsersResponse) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="GetAllSimpleUsersResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GetAllSimpleUsersResponse_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<GetAllSimpleUsersResponse>(Fixture);
        }

        #endregion

        #region General Constructor : Class (GetAllSimpleUsersResponse) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="GetAllSimpleUsersResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GetAllSimpleUsersResponse_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfGetAllSimpleUsersResponse = {  };
            Type [] methodGetAllSimpleUsersResponsePrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_getAllSimpleUsersResponseInstanceType, methodGetAllSimpleUsersResponsePrametersTypes, parametersOfGetAllSimpleUsersResponse);
        }

        #endregion

        #region General Constructor : Class (GetAllSimpleUsersResponse) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="GetAllSimpleUsersResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GetAllSimpleUsersResponse_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodGetAllSimpleUsersResponsePrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_getAllSimpleUsersResponseInstanceType, Fixture, methodGetAllSimpleUsersResponsePrametersTypes);
        }

        #endregion

        #region General Constructor : Class (GetAllSimpleUsersResponse) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="GetAllSimpleUsersResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GetAllSimpleUsersResponse_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var GetAllSimpleUsersResult = this.CreateType<UplandIntegrations.TenroxUserService.UserSimple[]>();
            var totalRecords = this.CreateType<int>();
            object[] parametersOfGetAllSimpleUsersResponse = { GetAllSimpleUsersResult, totalRecords };
            var methodGetAllSimpleUsersResponsePrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxUserService.UserSimple[]), typeof(int) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_getAllSimpleUsersResponseInstanceType, methodGetAllSimpleUsersResponsePrametersTypes, parametersOfGetAllSimpleUsersResponse);
        }

        #endregion

        #region General Constructor : Class (GetAllSimpleUsersResponse) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="GetAllSimpleUsersResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GetAllSimpleUsersResponse_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodGetAllSimpleUsersResponsePrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxUserService.UserSimple[]), typeof(int) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_getAllSimpleUsersResponseInstanceType, Fixture, methodGetAllSimpleUsersResponsePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}