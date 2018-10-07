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
using FindSimpleUsersByEmailResponse = UplandIntegrations.TenroxUserService;

namespace UplandIntegrations.TenroxUserService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxUserService.FindSimpleUsersByEmailResponse" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxUserService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FindSimpleUsersByEmailResponseTest : AbstractBaseSetupV3Test
    {
        public FindSimpleUsersByEmailResponseTest() : base(typeof(FindSimpleUsersByEmailResponse))
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

        #region General Initializer : Class (FindSimpleUsersByEmailResponse) Initializer

        #region Fields

        private const string FieldFindSimpleUsersByEmailResult = "FindSimpleUsersByEmailResult";
        private const string FieldtotalRecords = "totalRecords";

        #endregion

        private Type _findSimpleUsersByEmailResponseInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private FindSimpleUsersByEmailResponse _findSimpleUsersByEmailResponseInstance;
        private FindSimpleUsersByEmailResponse _findSimpleUsersByEmailResponseInstanceFixture;

        #region General Initializer : Class (FindSimpleUsersByEmailResponse) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FindSimpleUsersByEmailResponse" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _findSimpleUsersByEmailResponseInstanceType = typeof(FindSimpleUsersByEmailResponse);
            _findSimpleUsersByEmailResponseInstanceFixture = this.Create<FindSimpleUsersByEmailResponse>(true);
            _findSimpleUsersByEmailResponseInstance = _findSimpleUsersByEmailResponseInstanceFixture ?? this.Create<FindSimpleUsersByEmailResponse>(false);
            CurrentInstance = _findSimpleUsersByEmailResponseInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FindSimpleUsersByEmailResponse)

        #region General Initializer : Class (FindSimpleUsersByEmailResponse) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FindSimpleUsersByEmailResponse" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldFindSimpleUsersByEmailResult)]
        [TestCase(FieldtotalRecords)]
        public void AUT_FindSimpleUsersByEmailResponse_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_findSimpleUsersByEmailResponseInstanceFixture, 
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
        ///     Class (<see cref="FindSimpleUsersByEmailResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_FindSimpleUsersByEmailResponse_Is_Instance_Present_Test()
        {
            // Assert
            _findSimpleUsersByEmailResponseInstanceType.ShouldNotBeNull();
            _findSimpleUsersByEmailResponseInstance.ShouldNotBeNull();
            _findSimpleUsersByEmailResponseInstanceFixture.ShouldNotBeNull();
            _findSimpleUsersByEmailResponseInstance.ShouldBeAssignableTo<FindSimpleUsersByEmailResponse>();
            _findSimpleUsersByEmailResponseInstanceFixture.ShouldBeAssignableTo<FindSimpleUsersByEmailResponse>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FindSimpleUsersByEmailResponse) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_FindSimpleUsersByEmailResponse_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FindSimpleUsersByEmailResponse instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _findSimpleUsersByEmailResponseInstanceType.ShouldNotBeNull();
            _findSimpleUsersByEmailResponseInstance.ShouldNotBeNull();
            _findSimpleUsersByEmailResponseInstanceFixture.ShouldNotBeNull();
            _findSimpleUsersByEmailResponseInstance.ShouldBeAssignableTo<FindSimpleUsersByEmailResponse>();
            _findSimpleUsersByEmailResponseInstanceFixture.ShouldBeAssignableTo<FindSimpleUsersByEmailResponse>();
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByEmailResponse) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByEmailResponse_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var FindSimpleUsersByEmailResult = this.CreateType<UplandIntegrations.TenroxUserService.UserSimple[]>();
            var totalRecords = this.CreateType<int>();
            FindSimpleUsersByEmailResponse instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new FindSimpleUsersByEmailResponse(FindSimpleUsersByEmailResult, totalRecords);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _findSimpleUsersByEmailResponseInstance.ShouldNotBeNull();
            _findSimpleUsersByEmailResponseInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<FindSimpleUsersByEmailResponse>();
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByEmailResponse) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByEmailResponse_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var FindSimpleUsersByEmailResult = this.CreateType<UplandIntegrations.TenroxUserService.UserSimple[]>();
            var totalRecords = this.CreateType<int>();
            FindSimpleUsersByEmailResponse instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new FindSimpleUsersByEmailResponse(FindSimpleUsersByEmailResult, totalRecords);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _findSimpleUsersByEmailResponseInstance.ShouldNotBeNull();
            _findSimpleUsersByEmailResponseInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByEmailResponse) instance created

        /// <summary>
        ///     Class (<see cref="FindSimpleUsersByEmailResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByEmailResponse_Is_Created_Test()
        {
            // Assert
            _findSimpleUsersByEmailResponseInstance.ShouldNotBeNull();
            _findSimpleUsersByEmailResponseInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByEmailResponse) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="FindSimpleUsersByEmailResponse" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_FindSimpleUsersByEmailResponse_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<FindSimpleUsersByEmailResponse>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByEmailResponse) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="FindSimpleUsersByEmailResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByEmailResponse_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<FindSimpleUsersByEmailResponse>(Fixture);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByEmailResponse) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="FindSimpleUsersByEmailResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByEmailResponse_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfFindSimpleUsersByEmailResponse = {  };
            Type [] methodFindSimpleUsersByEmailResponsePrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_findSimpleUsersByEmailResponseInstanceType, methodFindSimpleUsersByEmailResponsePrametersTypes, parametersOfFindSimpleUsersByEmailResponse);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByEmailResponse) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="FindSimpleUsersByEmailResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByEmailResponse_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodFindSimpleUsersByEmailResponsePrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_findSimpleUsersByEmailResponseInstanceType, Fixture, methodFindSimpleUsersByEmailResponsePrametersTypes);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByEmailResponse) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="FindSimpleUsersByEmailResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByEmailResponse_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var FindSimpleUsersByEmailResult = this.CreateType<UplandIntegrations.TenroxUserService.UserSimple[]>();
            var totalRecords = this.CreateType<int>();
            object[] parametersOfFindSimpleUsersByEmailResponse = { FindSimpleUsersByEmailResult, totalRecords };
            var methodFindSimpleUsersByEmailResponsePrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxUserService.UserSimple[]), typeof(int) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_findSimpleUsersByEmailResponseInstanceType, methodFindSimpleUsersByEmailResponsePrametersTypes, parametersOfFindSimpleUsersByEmailResponse);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByEmailResponse) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="FindSimpleUsersByEmailResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByEmailResponse_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodFindSimpleUsersByEmailResponsePrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxUserService.UserSimple[]), typeof(int) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_findSimpleUsersByEmailResponseInstanceType, Fixture, methodFindSimpleUsersByEmailResponsePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}