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
using UplandIntegrations.TenroxDataService;
using ProcessErrorMessagesRequest = UplandIntegrations.TenroxDataService;

namespace UplandIntegrations.TenroxDataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxDataService.ProcessErrorMessagesRequest" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxDataService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ProcessErrorMessagesRequestTest : AbstractBaseSetupV3Test
    {
        public ProcessErrorMessagesRequestTest() : base(typeof(ProcessErrorMessagesRequest))
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

        #region General Initializer : Class (ProcessErrorMessagesRequest) Initializer

        #region Fields

        private const string Fieldp_UserToken = "p_UserToken";
        private const string FieldretDataTable = "retDataTable";

        #endregion

        private Type _processErrorMessagesRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private ProcessErrorMessagesRequest _processErrorMessagesRequestInstance;
        private ProcessErrorMessagesRequest _processErrorMessagesRequestInstanceFixture;

        #region General Initializer : Class (ProcessErrorMessagesRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ProcessErrorMessagesRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _processErrorMessagesRequestInstanceType = typeof(ProcessErrorMessagesRequest);
            _processErrorMessagesRequestInstanceFixture = this.Create<ProcessErrorMessagesRequest>(true);
            _processErrorMessagesRequestInstance = _processErrorMessagesRequestInstanceFixture ?? this.Create<ProcessErrorMessagesRequest>(false);
            CurrentInstance = _processErrorMessagesRequestInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ProcessErrorMessagesRequest)

        #region General Initializer : Class (ProcessErrorMessagesRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ProcessErrorMessagesRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldp_UserToken)]
        [TestCase(FieldretDataTable)]
        public void AUT_ProcessErrorMessagesRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_processErrorMessagesRequestInstanceFixture, 
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
        ///     Class (<see cref="ProcessErrorMessagesRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ProcessErrorMessagesRequest_Is_Instance_Present_Test()
        {
            // Assert
            _processErrorMessagesRequestInstanceType.ShouldNotBeNull();
            _processErrorMessagesRequestInstance.ShouldNotBeNull();
            _processErrorMessagesRequestInstanceFixture.ShouldNotBeNull();
            _processErrorMessagesRequestInstance.ShouldBeAssignableTo<ProcessErrorMessagesRequest>();
            _processErrorMessagesRequestInstanceFixture.ShouldBeAssignableTo<ProcessErrorMessagesRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ProcessErrorMessagesRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ProcessErrorMessagesRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ProcessErrorMessagesRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _processErrorMessagesRequestInstanceType.ShouldNotBeNull();
            _processErrorMessagesRequestInstance.ShouldNotBeNull();
            _processErrorMessagesRequestInstanceFixture.ShouldNotBeNull();
            _processErrorMessagesRequestInstance.ShouldBeAssignableTo<ProcessErrorMessagesRequest>();
            _processErrorMessagesRequestInstanceFixture.ShouldBeAssignableTo<ProcessErrorMessagesRequest>();
        }

        #endregion

        #region General Constructor : Class (ProcessErrorMessagesRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ProcessErrorMessagesRequest_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var p_UserToken = this.CreateType<string>();
            var retDataTable = this.CreateType<System.Data.DataTable>();
            ProcessErrorMessagesRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new ProcessErrorMessagesRequest(p_UserToken, retDataTable);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _processErrorMessagesRequestInstance.ShouldNotBeNull();
            _processErrorMessagesRequestInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<ProcessErrorMessagesRequest>();
        }

        #endregion

        #region General Constructor : Class (ProcessErrorMessagesRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ProcessErrorMessagesRequest_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var p_UserToken = this.CreateType<string>();
            var retDataTable = this.CreateType<System.Data.DataTable>();
            ProcessErrorMessagesRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new ProcessErrorMessagesRequest(p_UserToken, retDataTable);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _processErrorMessagesRequestInstance.ShouldNotBeNull();
            _processErrorMessagesRequestInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (ProcessErrorMessagesRequest) instance created

        /// <summary>
        ///     Class (<see cref="ProcessErrorMessagesRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ProcessErrorMessagesRequest_Is_Created_Test()
        {
            // Assert
            _processErrorMessagesRequestInstance.ShouldNotBeNull();
            _processErrorMessagesRequestInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (ProcessErrorMessagesRequest) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="ProcessErrorMessagesRequest" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_ProcessErrorMessagesRequest_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<ProcessErrorMessagesRequest>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (ProcessErrorMessagesRequest) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="ProcessErrorMessagesRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ProcessErrorMessagesRequest_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<ProcessErrorMessagesRequest>(Fixture);
        }

        #endregion

        #region General Constructor : Class (ProcessErrorMessagesRequest) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ProcessErrorMessagesRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ProcessErrorMessagesRequest_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfProcessErrorMessagesRequest = {  };
            Type [] methodProcessErrorMessagesRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_processErrorMessagesRequestInstanceType, methodProcessErrorMessagesRequestPrametersTypes, parametersOfProcessErrorMessagesRequest);
        }

        #endregion

        #region General Constructor : Class (ProcessErrorMessagesRequest) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ProcessErrorMessagesRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ProcessErrorMessagesRequest_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodProcessErrorMessagesRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_processErrorMessagesRequestInstanceType, Fixture, methodProcessErrorMessagesRequestPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ProcessErrorMessagesRequest) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ProcessErrorMessagesRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ProcessErrorMessagesRequest_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var p_UserToken = this.CreateType<string>();
            var retDataTable = this.CreateType<System.Data.DataTable>();
            object[] parametersOfProcessErrorMessagesRequest = { p_UserToken, retDataTable };
            var methodProcessErrorMessagesRequestPrametersTypes = new Type[] { typeof(string), typeof(System.Data.DataTable) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_processErrorMessagesRequestInstanceType, methodProcessErrorMessagesRequestPrametersTypes, parametersOfProcessErrorMessagesRequest);
        }

        #endregion

        #region General Constructor : Class (ProcessErrorMessagesRequest) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ProcessErrorMessagesRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ProcessErrorMessagesRequest_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodProcessErrorMessagesRequestPrametersTypes = new Type[] { typeof(string), typeof(System.Data.DataTable) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_processErrorMessagesRequestInstanceType, Fixture, methodProcessErrorMessagesRequestPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}