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
using UplandIntegrations.TenroxAuthService;
using LogonAsClient = UplandIntegrations.TenroxAuthService;

namespace UplandIntegrations.TenroxAuthService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxAuthService.LogonAsClient" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxAuthService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class LogonAsClientTest : AbstractBaseSetupV3Test
    {
        public LogonAsClientTest() : base(typeof(LogonAsClient))
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

        #region General Initializer : Class (LogonAsClient) Initializer

        #region Methods

        private const string MethodAuthUser = "AuthUser";
        private const string MethodAuthUserAsync = "AuthUserAsync";
        private const string MethodAuthUserDesktop = "AuthUserDesktop";
        private const string MethodAuthUserDesktopAsync = "AuthUserDesktopAsync";
        private const string MethodAuthUserMobile = "AuthUserMobile";
        private const string MethodAuthUserMobileAsync = "AuthUserMobileAsync";
        private const string MethodAuthenticate = "Authenticate";
        private const string MethodAuthenticateAsync = "AuthenticateAsync";
        private const string MethodImpersonateUser = "ImpersonateUser";
        private const string MethodImpersonateUserAsync = "ImpersonateUserAsync";
        private const string MethodImpersonateUserToken = "ImpersonateUserToken";
        private const string MethodImpersonateUserTokenAsync = "ImpersonateUserTokenAsync";
        private const string MethodReinitializeToken = "ReinitializeToken";
        private const string MethodReinitializeTokenAsync = "ReinitializeTokenAsync";
        private const string MethodReinitialize = "Reinitialize";
        private const string MethodReinitializeAsync = "ReinitializeAsync";
        private const string MethodVerifyUserInCache = "VerifyUserInCache";
        private const string MethodVerifyUserInCacheAsync = "VerifyUserInCacheAsync";

        #endregion

        private Type _logonAsClientInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private LogonAsClient _logonAsClientInstance;
        private LogonAsClient _logonAsClientInstanceFixture;

        #region General Initializer : Class (LogonAsClient) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="LogonAsClient" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _logonAsClientInstanceType = typeof(LogonAsClient);
            _logonAsClientInstanceFixture = this.Create<LogonAsClient>(true);
            _logonAsClientInstance = _logonAsClientInstanceFixture ?? this.Create<LogonAsClient>(false);
            CurrentInstance = _logonAsClientInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (LogonAsClient) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="LogonAsClient" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void AUT_LogonAsClient_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<LogonAsClient>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (LogonAsClient) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="LogonAsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_LogonAsClient_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<LogonAsClient>(Fixture);
        }

        #endregion

        #region General Constructor : Class (LogonAsClient) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="LogonAsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_LogonAsClient_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfLogonAsClient = {  };
            Type [] methodLogonAsClientPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_logonAsClientInstanceType, methodLogonAsClientPrametersTypes, parametersOfLogonAsClient);
        }

        #endregion

        #region General Constructor : Class (LogonAsClient) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="LogonAsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_LogonAsClient_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodLogonAsClientPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_logonAsClientInstanceType, Fixture, methodLogonAsClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (LogonAsClient) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="LogonAsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_LogonAsClient_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = this.CreateType<string>();
            object[] parametersOfLogonAsClient = { endpointConfigurationName };
            var methodLogonAsClientPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_logonAsClientInstanceType, methodLogonAsClientPrametersTypes, parametersOfLogonAsClient);
        }

        #endregion

        #region General Constructor : Class (LogonAsClient) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="LogonAsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_LogonAsClient_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodLogonAsClientPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_logonAsClientInstanceType, Fixture, methodLogonAsClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (LogonAsClient) constructors with parameter (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="LogonAsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_LogonAsClient_Constructors_Overloading_Of_2_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = this.CreateType<string>();
            var remoteAddress = this.CreateType<string>();
            object[] parametersOfLogonAsClient = { endpointConfigurationName, remoteAddress };
            var methodLogonAsClientPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_logonAsClientInstanceType, methodLogonAsClientPrametersTypes, parametersOfLogonAsClient);
        }

        #endregion

        #region General Constructor : Class (LogonAsClient) constructors with dynamic parameters (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="LogonAsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_LogonAsClient_Constructors_Overloading_Of_2_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodLogonAsClientPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_logonAsClientInstanceType, Fixture, methodLogonAsClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (LogonAsClient) constructors with parameter (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="LogonAsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_LogonAsClient_Constructors_Overloading_Of_3_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = this.CreateType<string>();
            var remoteAddress = this.CreateType<System.ServiceModel.EndpointAddress>();
            object[] parametersOfLogonAsClient = { endpointConfigurationName, remoteAddress };
            var methodLogonAsClientPrametersTypes = new Type[] { typeof(string), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_logonAsClientInstanceType, methodLogonAsClientPrametersTypes, parametersOfLogonAsClient);
        }

        #endregion

        #region General Constructor : Class (LogonAsClient) constructors with dynamic parameters (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="LogonAsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_LogonAsClient_Constructors_Overloading_Of_3_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodLogonAsClientPrametersTypes = new Type[] { typeof(string), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_logonAsClientInstanceType, Fixture, methodLogonAsClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (LogonAsClient) constructors with parameter (Overloading_Of_4_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="LogonAsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_LogonAsClient_Constructors_Overloading_Of_4_Explore_Verify_Test()
        {
            // Arrange
            var binding = this.CreateType<System.ServiceModel.Channels.Binding>();
            var remoteAddress = this.CreateType<System.ServiceModel.EndpointAddress>();
            object[] parametersOfLogonAsClient = { binding, remoteAddress };
            var methodLogonAsClientPrametersTypes = new Type[] { typeof(System.ServiceModel.Channels.Binding), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_logonAsClientInstanceType, methodLogonAsClientPrametersTypes, parametersOfLogonAsClient);
        }

        #endregion

        #region General Constructor : Class (LogonAsClient) constructors with dynamic parameters (Overloading_Of_4_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="LogonAsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_LogonAsClient_Constructors_Overloading_Of_4_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodLogonAsClientPrametersTypes = new Type[] { typeof(System.ServiceModel.Channels.Binding), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_logonAsClientInstanceType, Fixture, methodLogonAsClientPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (AuthUser) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_LogonAsClient_AuthUser_Method_Call_Internally(Type[] types)
        {
            var methodAuthUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_logonAsClientInstance, MethodAuthUser, Fixture, methodAuthUserPrametersTypes);
        }

        #endregion

        #region Method Call : (AuthUserDesktop) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_LogonAsClient_AuthUserDesktop_Method_Call_Internally(Type[] types)
        {
            var methodAuthUserDesktopPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_logonAsClientInstance, MethodAuthUserDesktop, Fixture, methodAuthUserDesktopPrametersTypes);
        }

        #endregion

        #region Method Call : (AuthUserMobile) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_LogonAsClient_AuthUserMobile_Method_Call_Internally(Type[] types)
        {
            var methodAuthUserMobilePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_logonAsClientInstance, MethodAuthUserMobile, Fixture, methodAuthUserMobilePrametersTypes);
        }

        #endregion

        #region Method Call : (Authenticate) (Return Type : UplandIntegrations.TenroxAuthService.UserToken) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_LogonAsClient_Authenticate_Method_Call_Internally(Type[] types)
        {
            var methodAuthenticatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_logonAsClientInstance, MethodAuthenticate, Fixture, methodAuthenticatePrametersTypes);
        }

        #endregion

        #region Method Call : (ImpersonateUser) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_LogonAsClient_ImpersonateUser_Method_Call_Internally(Type[] types)
        {
            var methodImpersonateUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_logonAsClientInstance, MethodImpersonateUser, Fixture, methodImpersonateUserPrametersTypes);
        }

        #endregion

        #region Method Call : (ImpersonateUserToken) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_LogonAsClient_ImpersonateUserToken_Method_Call_Internally(Type[] types)
        {
            var methodImpersonateUserTokenPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_logonAsClientInstance, MethodImpersonateUserToken, Fixture, methodImpersonateUserTokenPrametersTypes);
        }

        #endregion

        #region Method Call : (ReinitializeToken) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_LogonAsClient_ReinitializeToken_Method_Call_Internally(Type[] types)
        {
            var methodReinitializeTokenPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_logonAsClientInstance, MethodReinitializeToken, Fixture, methodReinitializeTokenPrametersTypes);
        }

        #endregion

        #region Method Call : (Reinitialize) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_LogonAsClient_Reinitialize_Method_Call_Internally(Type[] types)
        {
            var methodReinitializePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_logonAsClientInstance, MethodReinitialize, Fixture, methodReinitializePrametersTypes);
        }

        #endregion

        #region Method Call : (VerifyUserInCache) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_LogonAsClient_VerifyUserInCache_Method_Call_Internally(Type[] types)
        {
            var methodVerifyUserInCachePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_logonAsClientInstance, MethodVerifyUserInCache, Fixture, methodVerifyUserInCachePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}