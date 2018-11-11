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
using FindSimpleUsersByNameResponse = UplandIntegrations.TenroxUserService;

namespace UplandIntegrations.TenroxUserService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxUserService.FindSimpleUsersByNameResponse" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxUserService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FindSimpleUsersByNameResponseTest : AbstractBaseSetupV3Test
    {
        public FindSimpleUsersByNameResponseTest() : base(typeof(FindSimpleUsersByNameResponse))
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

        #region General Initializer : Class (FindSimpleUsersByNameResponse) Initializer

        #region Fields

        private const string FieldFindSimpleUsersByNameResult = "FindSimpleUsersByNameResult";
        private const string FieldtotalRecords = "totalRecords";

        #endregion

        private Type _findSimpleUsersByNameResponseInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private FindSimpleUsersByNameResponse _findSimpleUsersByNameResponseInstance;
        private FindSimpleUsersByNameResponse _findSimpleUsersByNameResponseInstanceFixture;

        #region General Initializer : Class (FindSimpleUsersByNameResponse) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FindSimpleUsersByNameResponse" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _findSimpleUsersByNameResponseInstanceType = typeof(FindSimpleUsersByNameResponse);
            _findSimpleUsersByNameResponseInstanceFixture = this.Create<FindSimpleUsersByNameResponse>(true);
            _findSimpleUsersByNameResponseInstance = _findSimpleUsersByNameResponseInstanceFixture ?? this.Create<FindSimpleUsersByNameResponse>(false);
            CurrentInstance = _findSimpleUsersByNameResponseInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FindSimpleUsersByNameResponse)

        #region General Initializer : Class (FindSimpleUsersByNameResponse) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FindSimpleUsersByNameResponse" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldFindSimpleUsersByNameResult)]
        [TestCase(FieldtotalRecords)]
        public void AUT_FindSimpleUsersByNameResponse_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_findSimpleUsersByNameResponseInstanceFixture, 
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
        ///     Class (<see cref="FindSimpleUsersByNameResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_FindSimpleUsersByNameResponse_Is_Instance_Present_Test()
        {
            // Assert
            _findSimpleUsersByNameResponseInstanceType.ShouldNotBeNull();
            _findSimpleUsersByNameResponseInstance.ShouldNotBeNull();
            _findSimpleUsersByNameResponseInstanceFixture.ShouldNotBeNull();
            _findSimpleUsersByNameResponseInstance.ShouldBeAssignableTo<FindSimpleUsersByNameResponse>();
            _findSimpleUsersByNameResponseInstanceFixture.ShouldBeAssignableTo<FindSimpleUsersByNameResponse>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FindSimpleUsersByNameResponse) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_FindSimpleUsersByNameResponse_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FindSimpleUsersByNameResponse instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _findSimpleUsersByNameResponseInstanceType.ShouldNotBeNull();
            _findSimpleUsersByNameResponseInstance.ShouldNotBeNull();
            _findSimpleUsersByNameResponseInstanceFixture.ShouldNotBeNull();
            _findSimpleUsersByNameResponseInstance.ShouldBeAssignableTo<FindSimpleUsersByNameResponse>();
            _findSimpleUsersByNameResponseInstanceFixture.ShouldBeAssignableTo<FindSimpleUsersByNameResponse>();
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByNameResponse) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByNameResponse_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var FindSimpleUsersByNameResult = this.CreateType<UplandIntegrations.TenroxUserService.UserSimple[]>();
            var totalRecords = this.CreateType<int>();
            FindSimpleUsersByNameResponse instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new FindSimpleUsersByNameResponse(FindSimpleUsersByNameResult, totalRecords);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _findSimpleUsersByNameResponseInstance.ShouldNotBeNull();
            _findSimpleUsersByNameResponseInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<FindSimpleUsersByNameResponse>();
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByNameResponse) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByNameResponse_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var FindSimpleUsersByNameResult = this.CreateType<UplandIntegrations.TenroxUserService.UserSimple[]>();
            var totalRecords = this.CreateType<int>();
            FindSimpleUsersByNameResponse instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new FindSimpleUsersByNameResponse(FindSimpleUsersByNameResult, totalRecords);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _findSimpleUsersByNameResponseInstance.ShouldNotBeNull();
            _findSimpleUsersByNameResponseInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByNameResponse) instance created

        /// <summary>
        ///     Class (<see cref="FindSimpleUsersByNameResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByNameResponse_Is_Created_Test()
        {
            // Assert
            _findSimpleUsersByNameResponseInstance.ShouldNotBeNull();
            _findSimpleUsersByNameResponseInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByNameResponse) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="FindSimpleUsersByNameResponse" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_FindSimpleUsersByNameResponse_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<FindSimpleUsersByNameResponse>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByNameResponse) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="FindSimpleUsersByNameResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByNameResponse_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<FindSimpleUsersByNameResponse>(Fixture);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByNameResponse) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="FindSimpleUsersByNameResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByNameResponse_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfFindSimpleUsersByNameResponse = {  };
            Type [] methodFindSimpleUsersByNameResponsePrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_findSimpleUsersByNameResponseInstanceType, methodFindSimpleUsersByNameResponsePrametersTypes, parametersOfFindSimpleUsersByNameResponse);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByNameResponse) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="FindSimpleUsersByNameResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByNameResponse_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodFindSimpleUsersByNameResponsePrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_findSimpleUsersByNameResponseInstanceType, Fixture, methodFindSimpleUsersByNameResponsePrametersTypes);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByNameResponse) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="FindSimpleUsersByNameResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByNameResponse_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var FindSimpleUsersByNameResult = this.CreateType<UplandIntegrations.TenroxUserService.UserSimple[]>();
            var totalRecords = this.CreateType<int>();
            object[] parametersOfFindSimpleUsersByNameResponse = { FindSimpleUsersByNameResult, totalRecords };
            var methodFindSimpleUsersByNameResponsePrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxUserService.UserSimple[]), typeof(int) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_findSimpleUsersByNameResponseInstanceType, methodFindSimpleUsersByNameResponsePrametersTypes, parametersOfFindSimpleUsersByNameResponse);
        }

        #endregion

        #region General Constructor : Class (FindSimpleUsersByNameResponse) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="FindSimpleUsersByNameResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FindSimpleUsersByNameResponse_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodFindSimpleUsersByNameResponsePrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxUserService.UserSimple[]), typeof(int) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_findSimpleUsersByNameResponseInstanceType, Fixture, methodFindSimpleUsersByNameResponsePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}