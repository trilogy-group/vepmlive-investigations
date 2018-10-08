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
using GetAllSimpleUsersRequest = UplandIntegrations.TenroxUserService;

namespace UplandIntegrations.TenroxUserService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxUserService.GetAllSimpleUsersRequest" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxUserService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GetAllSimpleUsersRequestTest : AbstractBaseSetupV3Test
    {
        public GetAllSimpleUsersRequestTest() : base(typeof(GetAllSimpleUsersRequest))
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

        #region General Initializer : Class (GetAllSimpleUsersRequest) Initializer

        #region Fields

        private const string Fieldp_userToken = "p_userToken";
        private const string FieldpageIndex = "pageIndex";
        private const string FieldpageSize = "pageSize";

        #endregion

        private Type _getAllSimpleUsersRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private GetAllSimpleUsersRequest _getAllSimpleUsersRequestInstance;
        private GetAllSimpleUsersRequest _getAllSimpleUsersRequestInstanceFixture;

        #region General Initializer : Class (GetAllSimpleUsersRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GetAllSimpleUsersRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _getAllSimpleUsersRequestInstanceType = typeof(GetAllSimpleUsersRequest);
            _getAllSimpleUsersRequestInstanceFixture = this.Create<GetAllSimpleUsersRequest>(true);
            _getAllSimpleUsersRequestInstance = _getAllSimpleUsersRequestInstanceFixture ?? this.Create<GetAllSimpleUsersRequest>(false);
            CurrentInstance = _getAllSimpleUsersRequestInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GetAllSimpleUsersRequest)

        #region General Initializer : Class (GetAllSimpleUsersRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="GetAllSimpleUsersRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldp_userToken)]
        [TestCase(FieldpageIndex)]
        public void AUT_GetAllSimpleUsersRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_getAllSimpleUsersRequestInstanceFixture, 
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
        ///     Class (<see cref="GetAllSimpleUsersRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_GetAllSimpleUsersRequest_Is_Instance_Present_Test()
        {
            // Assert
            _getAllSimpleUsersRequestInstanceType.ShouldNotBeNull();
            _getAllSimpleUsersRequestInstance.ShouldNotBeNull();
            _getAllSimpleUsersRequestInstanceFixture.ShouldNotBeNull();
            _getAllSimpleUsersRequestInstance.ShouldBeAssignableTo<GetAllSimpleUsersRequest>();
            _getAllSimpleUsersRequestInstanceFixture.ShouldBeAssignableTo<GetAllSimpleUsersRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (GetAllSimpleUsersRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_GetAllSimpleUsersRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            GetAllSimpleUsersRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _getAllSimpleUsersRequestInstanceType.ShouldNotBeNull();
            _getAllSimpleUsersRequestInstance.ShouldNotBeNull();
            _getAllSimpleUsersRequestInstanceFixture.ShouldNotBeNull();
            _getAllSimpleUsersRequestInstance.ShouldBeAssignableTo<GetAllSimpleUsersRequest>();
            _getAllSimpleUsersRequestInstanceFixture.ShouldBeAssignableTo<GetAllSimpleUsersRequest>();
        }

        #endregion

        #region General Constructor : Class (GetAllSimpleUsersRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GetAllSimpleUsersRequest_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var p_userToken = this.CreateType<UplandIntegrations.TenroxUserService.UserToken>();
            var pageIndex = this.CreateType<int>();
            var pageSize = this.CreateType<int>();
            GetAllSimpleUsersRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new GetAllSimpleUsersRequest(p_userToken, pageIndex, pageSize);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _getAllSimpleUsersRequestInstance.ShouldNotBeNull();
            _getAllSimpleUsersRequestInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<GetAllSimpleUsersRequest>();
        }

        #endregion

        #region General Constructor : Class (GetAllSimpleUsersRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GetAllSimpleUsersRequest_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var p_userToken = this.CreateType<UplandIntegrations.TenroxUserService.UserToken>();
            var pageIndex = this.CreateType<int>();
            var pageSize = this.CreateType<int>();
            GetAllSimpleUsersRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new GetAllSimpleUsersRequest(p_userToken, pageIndex, pageSize);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _getAllSimpleUsersRequestInstance.ShouldNotBeNull();
            _getAllSimpleUsersRequestInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (GetAllSimpleUsersRequest) instance created

        /// <summary>
        ///     Class (<see cref="GetAllSimpleUsersRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GetAllSimpleUsersRequest_Is_Created_Test()
        {
            // Assert
            _getAllSimpleUsersRequestInstance.ShouldNotBeNull();
            _getAllSimpleUsersRequestInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (GetAllSimpleUsersRequest) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="GetAllSimpleUsersRequest" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_GetAllSimpleUsersRequest_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<GetAllSimpleUsersRequest>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (GetAllSimpleUsersRequest) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="GetAllSimpleUsersRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GetAllSimpleUsersRequest_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<GetAllSimpleUsersRequest>(Fixture);
        }

        #endregion

        #region General Constructor : Class (GetAllSimpleUsersRequest) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="GetAllSimpleUsersRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GetAllSimpleUsersRequest_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfGetAllSimpleUsersRequest = {  };
            Type [] methodGetAllSimpleUsersRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_getAllSimpleUsersRequestInstanceType, methodGetAllSimpleUsersRequestPrametersTypes, parametersOfGetAllSimpleUsersRequest);
        }

        #endregion

        #region General Constructor : Class (GetAllSimpleUsersRequest) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="GetAllSimpleUsersRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GetAllSimpleUsersRequest_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodGetAllSimpleUsersRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_getAllSimpleUsersRequestInstanceType, Fixture, methodGetAllSimpleUsersRequestPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (GetAllSimpleUsersRequest) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="GetAllSimpleUsersRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GetAllSimpleUsersRequest_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var p_userToken = this.CreateType<UplandIntegrations.TenroxUserService.UserToken>();
            var pageIndex = this.CreateType<int>();
            var pageSize = this.CreateType<int>();
            object[] parametersOfGetAllSimpleUsersRequest = { p_userToken, pageIndex, pageSize };
            var methodGetAllSimpleUsersRequestPrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxUserService.UserToken), typeof(int), typeof(int) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_getAllSimpleUsersRequestInstanceType, methodGetAllSimpleUsersRequestPrametersTypes, parametersOfGetAllSimpleUsersRequest);
        }

        #endregion

        #region General Constructor : Class (GetAllSimpleUsersRequest) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="GetAllSimpleUsersRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GetAllSimpleUsersRequest_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodGetAllSimpleUsersRequestPrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxUserService.UserToken), typeof(int), typeof(int) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_getAllSimpleUsersRequestInstanceType, Fixture, methodGetAllSimpleUsersRequestPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}