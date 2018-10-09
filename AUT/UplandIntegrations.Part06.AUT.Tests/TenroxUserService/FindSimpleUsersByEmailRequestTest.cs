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
using FindSimpleUsersByEmailRequest = UplandIntegrations.TenroxUserService;

namespace UplandIntegrations.TenroxUserService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxUserService.FindSimpleUsersByEmailRequest" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxUserService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FindSimpleUsersByEmailRequestTest : AbstractBaseSetupV3Test
    {
        public FindSimpleUsersByEmailRequestTest() : base(typeof(FindSimpleUsersByEmailRequest))
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

        #region General Initializer : Class (FindSimpleUsersByEmailRequest) Initializer

        #region Fields

        private const string Fieldp_userToken = "p_userToken";
        private const string FieldemailToMatch = "emailToMatch";
        private const string FieldpageIndex = "pageIndex";
        private const string FieldpageSize = "pageSize";

        #endregion

        private Type _findSimpleUsersByEmailRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private FindSimpleUsersByEmailRequest _findSimpleUsersByEmailRequestInstance;
        private FindSimpleUsersByEmailRequest _findSimpleUsersByEmailRequestInstanceFixture;

        #region General Initializer : Class (FindSimpleUsersByEmailRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FindSimpleUsersByEmailRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _findSimpleUsersByEmailRequestInstanceType = typeof(FindSimpleUsersByEmailRequest);
            _findSimpleUsersByEmailRequestInstanceFixture = this.Create<FindSimpleUsersByEmailRequest>(true);
            _findSimpleUsersByEmailRequestInstance = _findSimpleUsersByEmailRequestInstanceFixture ?? this.Create<FindSimpleUsersByEmailRequest>(false);
            CurrentInstance = _findSimpleUsersByEmailRequestInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FindSimpleUsersByEmailRequest)

        #region General Initializer : Class (FindSimpleUsersByEmailRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FindSimpleUsersByEmailRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldp_userToken)]
        [TestCase(FieldemailToMatch)]
        [TestCase(FieldpageIndex)]
        public void AUT_FindSimpleUsersByEmailRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_findSimpleUsersByEmailRequestInstanceFixture, 
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
        ///     Class (<see cref="FindSimpleUsersByEmailRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_FindSimpleUsersByEmailRequest_Is_Instance_Present_Test()
        {
            // Assert
            _findSimpleUsersByEmailRequestInstanceType.ShouldNotBeNull();
            _findSimpleUsersByEmailRequestInstance.ShouldNotBeNull();
            _findSimpleUsersByEmailRequestInstanceFixture.ShouldNotBeNull();
            _findSimpleUsersByEmailRequestInstance.ShouldBeAssignableTo<FindSimpleUsersByEmailRequest>();
            _findSimpleUsersByEmailRequestInstanceFixture.ShouldBeAssignableTo<FindSimpleUsersByEmailRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FindSimpleUsersByEmailRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_FindSimpleUsersByEmailRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FindSimpleUsersByEmailRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _findSimpleUsersByEmailRequestInstanceType.ShouldNotBeNull();
            _findSimpleUsersByEmailRequestInstance.ShouldNotBeNull();
            _findSimpleUsersByEmailRequestInstanceFixture.ShouldNotBeNull();
            _findSimpleUsersByEmailRequestInstance.ShouldBeAssignableTo<FindSimpleUsersByEmailRequest>();
            _findSimpleUsersByEmailRequestInstanceFixture.ShouldBeAssignableTo<FindSimpleUsersByEmailRequest>();
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByEmailRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByEmailRequest_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var p_userToken = this.CreateType<UplandIntegrations.TenroxUserService.UserToken>();
            var emailToMatch = this.CreateType<string>();
            var pageIndex = this.CreateType<int>();
            var pageSize = this.CreateType<int>();
            FindSimpleUsersByEmailRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new FindSimpleUsersByEmailRequest(p_userToken, emailToMatch, pageIndex, pageSize);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _findSimpleUsersByEmailRequestInstance.ShouldNotBeNull();
            _findSimpleUsersByEmailRequestInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<FindSimpleUsersByEmailRequest>();
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByEmailRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByEmailRequest_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var p_userToken = this.CreateType<UplandIntegrations.TenroxUserService.UserToken>();
            var emailToMatch = this.CreateType<string>();
            var pageIndex = this.CreateType<int>();
            var pageSize = this.CreateType<int>();
            FindSimpleUsersByEmailRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new FindSimpleUsersByEmailRequest(p_userToken, emailToMatch, pageIndex, pageSize);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _findSimpleUsersByEmailRequestInstance.ShouldNotBeNull();
            _findSimpleUsersByEmailRequestInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByEmailRequest) instance created

        /// <summary>
        ///     Class (<see cref="FindSimpleUsersByEmailRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByEmailRequest_Is_Created_Test()
        {
            // Assert
            _findSimpleUsersByEmailRequestInstance.ShouldNotBeNull();
            _findSimpleUsersByEmailRequestInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByEmailRequest) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="FindSimpleUsersByEmailRequest" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_FindSimpleUsersByEmailRequest_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<FindSimpleUsersByEmailRequest>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByEmailRequest) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="FindSimpleUsersByEmailRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByEmailRequest_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<FindSimpleUsersByEmailRequest>(Fixture);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByEmailRequest) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="FindSimpleUsersByEmailRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByEmailRequest_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfFindSimpleUsersByEmailRequest = {  };
            Type [] methodFindSimpleUsersByEmailRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_findSimpleUsersByEmailRequestInstanceType, methodFindSimpleUsersByEmailRequestPrametersTypes, parametersOfFindSimpleUsersByEmailRequest);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByEmailRequest) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="FindSimpleUsersByEmailRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByEmailRequest_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodFindSimpleUsersByEmailRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_findSimpleUsersByEmailRequestInstanceType, Fixture, methodFindSimpleUsersByEmailRequestPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByEmailRequest) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="FindSimpleUsersByEmailRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByEmailRequest_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var p_userToken = this.CreateType<UplandIntegrations.TenroxUserService.UserToken>();
            var emailToMatch = this.CreateType<string>();
            var pageIndex = this.CreateType<int>();
            var pageSize = this.CreateType<int>();
            object[] parametersOfFindSimpleUsersByEmailRequest = { p_userToken, emailToMatch, pageIndex, pageSize };
            var methodFindSimpleUsersByEmailRequestPrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxUserService.UserToken), typeof(string), typeof(int), typeof(int) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_findSimpleUsersByEmailRequestInstanceType, methodFindSimpleUsersByEmailRequestPrametersTypes, parametersOfFindSimpleUsersByEmailRequest);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByEmailRequest) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="FindSimpleUsersByEmailRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByEmailRequest_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodFindSimpleUsersByEmailRequestPrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxUserService.UserToken), typeof(string), typeof(int), typeof(int) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_findSimpleUsersByEmailRequestInstanceType, Fixture, methodFindSimpleUsersByEmailRequestPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}