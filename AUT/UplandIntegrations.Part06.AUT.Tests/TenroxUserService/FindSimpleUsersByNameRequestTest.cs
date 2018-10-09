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
using FindSimpleUsersByNameRequest = UplandIntegrations.TenroxUserService;

namespace UplandIntegrations.TenroxUserService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxUserService.FindSimpleUsersByNameRequest" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxUserService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FindSimpleUsersByNameRequestTest : AbstractBaseSetupV3Test
    {
        public FindSimpleUsersByNameRequestTest() : base(typeof(FindSimpleUsersByNameRequest))
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

        #region General Initializer : Class (FindSimpleUsersByNameRequest) Initializer

        #region Fields

        private const string Fieldp_userToken = "p_userToken";
        private const string FieldusernameToMatch = "usernameToMatch";
        private const string FieldpageIndex = "pageIndex";
        private const string FieldpageSize = "pageSize";

        #endregion

        private Type _findSimpleUsersByNameRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private FindSimpleUsersByNameRequest _findSimpleUsersByNameRequestInstance;
        private FindSimpleUsersByNameRequest _findSimpleUsersByNameRequestInstanceFixture;

        #region General Initializer : Class (FindSimpleUsersByNameRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FindSimpleUsersByNameRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _findSimpleUsersByNameRequestInstanceType = typeof(FindSimpleUsersByNameRequest);
            _findSimpleUsersByNameRequestInstanceFixture = this.Create<FindSimpleUsersByNameRequest>(true);
            _findSimpleUsersByNameRequestInstance = _findSimpleUsersByNameRequestInstanceFixture ?? this.Create<FindSimpleUsersByNameRequest>(false);
            CurrentInstance = _findSimpleUsersByNameRequestInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FindSimpleUsersByNameRequest)

        #region General Initializer : Class (FindSimpleUsersByNameRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FindSimpleUsersByNameRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldp_userToken)]
        [TestCase(FieldusernameToMatch)]
        [TestCase(FieldpageIndex)]
        public void AUT_FindSimpleUsersByNameRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_findSimpleUsersByNameRequestInstanceFixture, 
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
        ///     Class (<see cref="FindSimpleUsersByNameRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_FindSimpleUsersByNameRequest_Is_Instance_Present_Test()
        {
            // Assert
            _findSimpleUsersByNameRequestInstanceType.ShouldNotBeNull();
            _findSimpleUsersByNameRequestInstance.ShouldNotBeNull();
            _findSimpleUsersByNameRequestInstanceFixture.ShouldNotBeNull();
            _findSimpleUsersByNameRequestInstance.ShouldBeAssignableTo<FindSimpleUsersByNameRequest>();
            _findSimpleUsersByNameRequestInstanceFixture.ShouldBeAssignableTo<FindSimpleUsersByNameRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FindSimpleUsersByNameRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_FindSimpleUsersByNameRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FindSimpleUsersByNameRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _findSimpleUsersByNameRequestInstanceType.ShouldNotBeNull();
            _findSimpleUsersByNameRequestInstance.ShouldNotBeNull();
            _findSimpleUsersByNameRequestInstanceFixture.ShouldNotBeNull();
            _findSimpleUsersByNameRequestInstance.ShouldBeAssignableTo<FindSimpleUsersByNameRequest>();
            _findSimpleUsersByNameRequestInstanceFixture.ShouldBeAssignableTo<FindSimpleUsersByNameRequest>();
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByNameRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByNameRequest_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var p_userToken = this.CreateType<UplandIntegrations.TenroxUserService.UserToken>();
            var usernameToMatch = this.CreateType<string>();
            var pageIndex = this.CreateType<int>();
            var pageSize = this.CreateType<int>();
            FindSimpleUsersByNameRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new FindSimpleUsersByNameRequest(p_userToken, usernameToMatch, pageIndex, pageSize);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _findSimpleUsersByNameRequestInstance.ShouldNotBeNull();
            _findSimpleUsersByNameRequestInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<FindSimpleUsersByNameRequest>();
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByNameRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByNameRequest_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var p_userToken = this.CreateType<UplandIntegrations.TenroxUserService.UserToken>();
            var usernameToMatch = this.CreateType<string>();
            var pageIndex = this.CreateType<int>();
            var pageSize = this.CreateType<int>();
            FindSimpleUsersByNameRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new FindSimpleUsersByNameRequest(p_userToken, usernameToMatch, pageIndex, pageSize);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _findSimpleUsersByNameRequestInstance.ShouldNotBeNull();
            _findSimpleUsersByNameRequestInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByNameRequest) instance created

        /// <summary>
        ///     Class (<see cref="FindSimpleUsersByNameRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByNameRequest_Is_Created_Test()
        {
            // Assert
            _findSimpleUsersByNameRequestInstance.ShouldNotBeNull();
            _findSimpleUsersByNameRequestInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByNameRequest) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="FindSimpleUsersByNameRequest" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_FindSimpleUsersByNameRequest_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<FindSimpleUsersByNameRequest>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByNameRequest) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="FindSimpleUsersByNameRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByNameRequest_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<FindSimpleUsersByNameRequest>(Fixture);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByNameRequest) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="FindSimpleUsersByNameRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByNameRequest_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfFindSimpleUsersByNameRequest = {  };
            Type [] methodFindSimpleUsersByNameRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_findSimpleUsersByNameRequestInstanceType, methodFindSimpleUsersByNameRequestPrametersTypes, parametersOfFindSimpleUsersByNameRequest);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByNameRequest) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="FindSimpleUsersByNameRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByNameRequest_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodFindSimpleUsersByNameRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_findSimpleUsersByNameRequestInstanceType, Fixture, methodFindSimpleUsersByNameRequestPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByNameRequest) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="FindSimpleUsersByNameRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByNameRequest_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var p_userToken = this.CreateType<UplandIntegrations.TenroxUserService.UserToken>();
            var usernameToMatch = this.CreateType<string>();
            var pageIndex = this.CreateType<int>();
            var pageSize = this.CreateType<int>();
            object[] parametersOfFindSimpleUsersByNameRequest = { p_userToken, usernameToMatch, pageIndex, pageSize };
            var methodFindSimpleUsersByNameRequestPrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxUserService.UserToken), typeof(string), typeof(int), typeof(int) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_findSimpleUsersByNameRequestInstanceType, methodFindSimpleUsersByNameRequestPrametersTypes, parametersOfFindSimpleUsersByNameRequest);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByNameRequest) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="FindSimpleUsersByNameRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByNameRequest_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodFindSimpleUsersByNameRequestPrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxUserService.UserToken), typeof(string), typeof(int), typeof(int) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_findSimpleUsersByNameRequestInstanceType, Fixture, methodFindSimpleUsersByNameRequestPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}