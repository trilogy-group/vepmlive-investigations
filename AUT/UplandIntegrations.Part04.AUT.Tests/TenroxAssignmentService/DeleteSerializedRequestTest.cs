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
using DeleteSerializedRequest = UplandIntegrations.TenroxAssignmentService;

namespace UplandIntegrations.TenroxAssignmentService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxAssignmentService.DeleteSerializedRequest" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxAssignmentService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DeleteSerializedRequestTest : AbstractBaseSetupV3Test
    {
        public DeleteSerializedRequestTest() : base(typeof(DeleteSerializedRequest))
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

        #region General Initializer : Class (DeleteSerializedRequest) Initializer

        #region Fields

        private const string Fieldp_strToken = "p_strToken";
        private const string Fieldp_intUniqueId = "p_intUniqueId";

        #endregion

        private Type _deleteSerializedRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private DeleteSerializedRequest _deleteSerializedRequestInstance;
        private DeleteSerializedRequest _deleteSerializedRequestInstanceFixture;

        #region General Initializer : Class (DeleteSerializedRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DeleteSerializedRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _deleteSerializedRequestInstanceType = typeof(DeleteSerializedRequest);
            _deleteSerializedRequestInstanceFixture = this.Create<DeleteSerializedRequest>(true);
            _deleteSerializedRequestInstance = _deleteSerializedRequestInstanceFixture ?? this.Create<DeleteSerializedRequest>(false);
            CurrentInstance = _deleteSerializedRequestInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DeleteSerializedRequest)

        #region General Initializer : Class (DeleteSerializedRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DeleteSerializedRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldp_strToken)]
        [TestCase(Fieldp_intUniqueId)]
        public void AUT_DeleteSerializedRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_deleteSerializedRequestInstanceFixture, 
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
        ///     Class (<see cref="DeleteSerializedRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_DeleteSerializedRequest_Is_Instance_Present_Test()
        {
            // Assert
            _deleteSerializedRequestInstanceType.ShouldNotBeNull();
            _deleteSerializedRequestInstance.ShouldNotBeNull();
            _deleteSerializedRequestInstanceFixture.ShouldNotBeNull();
            _deleteSerializedRequestInstance.ShouldBeAssignableTo<DeleteSerializedRequest>();
            _deleteSerializedRequestInstanceFixture.ShouldBeAssignableTo<DeleteSerializedRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DeleteSerializedRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_DeleteSerializedRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DeleteSerializedRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _deleteSerializedRequestInstanceType.ShouldNotBeNull();
            _deleteSerializedRequestInstance.ShouldNotBeNull();
            _deleteSerializedRequestInstanceFixture.ShouldNotBeNull();
            _deleteSerializedRequestInstance.ShouldBeAssignableTo<DeleteSerializedRequest>();
            _deleteSerializedRequestInstanceFixture.ShouldBeAssignableTo<DeleteSerializedRequest>();
        }

        #endregion

        #region General Constructor : Class (DeleteSerializedRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DeleteSerializedRequest_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var p_strToken = this.CreateType<string>();
            var p_intUniqueId = this.CreateType<int>();
            DeleteSerializedRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new DeleteSerializedRequest(p_strToken, p_intUniqueId);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _deleteSerializedRequestInstance.ShouldNotBeNull();
            _deleteSerializedRequestInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<DeleteSerializedRequest>();
        }

        #endregion

        #region General Constructor : Class (DeleteSerializedRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DeleteSerializedRequest_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var p_strToken = this.CreateType<string>();
            var p_intUniqueId = this.CreateType<int>();
            DeleteSerializedRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new DeleteSerializedRequest(p_strToken, p_intUniqueId);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _deleteSerializedRequestInstance.ShouldNotBeNull();
            _deleteSerializedRequestInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (DeleteSerializedRequest) instance created

        /// <summary>
        ///     Class (<see cref="DeleteSerializedRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DeleteSerializedRequest_Is_Created_Test()
        {
            // Assert
            _deleteSerializedRequestInstance.ShouldNotBeNull();
            _deleteSerializedRequestInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (DeleteSerializedRequest) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="DeleteSerializedRequest" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_DeleteSerializedRequest_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<DeleteSerializedRequest>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (DeleteSerializedRequest) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="DeleteSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DeleteSerializedRequest_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<DeleteSerializedRequest>(Fixture);
        }

        #endregion

        #region General Constructor : Class (DeleteSerializedRequest) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="DeleteSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DeleteSerializedRequest_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfDeleteSerializedRequest = {  };
            Type [] methodDeleteSerializedRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_deleteSerializedRequestInstanceType, methodDeleteSerializedRequestPrametersTypes, parametersOfDeleteSerializedRequest);
        }

        #endregion

        #region General Constructor : Class (DeleteSerializedRequest) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="DeleteSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DeleteSerializedRequest_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodDeleteSerializedRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_deleteSerializedRequestInstanceType, Fixture, methodDeleteSerializedRequestPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (DeleteSerializedRequest) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="DeleteSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DeleteSerializedRequest_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var p_strToken = this.CreateType<string>();
            var p_intUniqueId = this.CreateType<int>();
            object[] parametersOfDeleteSerializedRequest = { p_strToken, p_intUniqueId };
            var methodDeleteSerializedRequestPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_deleteSerializedRequestInstanceType, methodDeleteSerializedRequestPrametersTypes, parametersOfDeleteSerializedRequest);
        }

        #endregion

        #region General Constructor : Class (DeleteSerializedRequest) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="DeleteSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DeleteSerializedRequest_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodDeleteSerializedRequestPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_deleteSerializedRequestInstanceType, Fixture, methodDeleteSerializedRequestPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}