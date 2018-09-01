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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Microsoft.SharePoint;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using Security = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Security" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SecurityTest : AbstractBaseSetupTest
    {

        public SecurityTest() : base(typeof(Security))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Security) Initializer

        private const string MethodAddBasicSecurityToWorkspace = "AddBasicSecurityToWorkspace";
        private Type _securityInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (Security) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Security" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _securityInstanceType = typeof(Security);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Security)

        #region General Initializer : Class (Security) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Security" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodAddBasicSecurityToWorkspace, 0)]
        public void AUT_Security_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(null, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="Security" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Security_Is_Static_Type_Present_Test()
        {
            // Assert
            _securityInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="Security" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAddBasicSecurityToWorkspace)]
        public void AUT_Security_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _securityInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (AddBasicSecurityToWorkspace) (Return Type : Dictionary<string, SPRoleType>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Security_AddBasicSecurityToWorkspace_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddBasicSecurityToWorkspacePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _securityInstanceType, MethodAddBasicSecurityToWorkspace, Fixture, methodAddBasicSecurityToWorkspacePrametersTypes);
        }

        #endregion

        #region Method Call : (AddBasicSecurityToWorkspace) (Return Type : Dictionary<string, SPRoleType>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Security_AddBasicSecurityToWorkspace_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var eleWeb = CreateType<SPWeb>();
            var safeTitle = CreateType<string>();
            var owner = CreateType<SPUser>();
            Action executeAction = null;

            // Act
            executeAction = () => Security.AddBasicSecurityToWorkspace(eleWeb, safeTitle, owner);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddBasicSecurityToWorkspace) (Return Type : Dictionary<string, SPRoleType>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Security_AddBasicSecurityToWorkspace_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var eleWeb = CreateType<SPWeb>();
            var safeTitle = CreateType<string>();
            var owner = CreateType<SPUser>();
            var methodAddBasicSecurityToWorkspacePrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(SPUser) };
            object[] parametersOfAddBasicSecurityToWorkspace = { eleWeb, safeTitle, owner };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddBasicSecurityToWorkspace, methodAddBasicSecurityToWorkspacePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _securityInstanceType, MethodAddBasicSecurityToWorkspace, Fixture, methodAddBasicSecurityToWorkspacePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, SPRoleType>>(null, _securityInstanceType, MethodAddBasicSecurityToWorkspace, parametersOfAddBasicSecurityToWorkspace, methodAddBasicSecurityToWorkspacePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfAddBasicSecurityToWorkspace);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfAddBasicSecurityToWorkspace.ShouldNotBeNull();
            parametersOfAddBasicSecurityToWorkspace.Length.ShouldBe(3);
            methodAddBasicSecurityToWorkspacePrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddBasicSecurityToWorkspace) (Return Type : Dictionary<string, SPRoleType>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Security_AddBasicSecurityToWorkspace_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var eleWeb = CreateType<SPWeb>();
            var safeTitle = CreateType<string>();
            var owner = CreateType<SPUser>();
            var methodAddBasicSecurityToWorkspacePrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(SPUser) };
            object[] parametersOfAddBasicSecurityToWorkspace = { eleWeb, safeTitle, owner };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, SPRoleType>>(null, _securityInstanceType, MethodAddBasicSecurityToWorkspace, parametersOfAddBasicSecurityToWorkspace, methodAddBasicSecurityToWorkspacePrametersTypes);

            // Assert
            parametersOfAddBasicSecurityToWorkspace.ShouldNotBeNull();
            parametersOfAddBasicSecurityToWorkspace.Length.ShouldBe(3);
            methodAddBasicSecurityToWorkspacePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddBasicSecurityToWorkspace) (Return Type : Dictionary<string, SPRoleType>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Security_AddBasicSecurityToWorkspace_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddBasicSecurityToWorkspacePrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(SPUser) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _securityInstanceType, MethodAddBasicSecurityToWorkspace, Fixture, methodAddBasicSecurityToWorkspacePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddBasicSecurityToWorkspacePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (AddBasicSecurityToWorkspace) (Return Type : Dictionary<string, SPRoleType>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Security_AddBasicSecurityToWorkspace_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddBasicSecurityToWorkspacePrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(SPUser) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _securityInstanceType, MethodAddBasicSecurityToWorkspace, Fixture, methodAddBasicSecurityToWorkspacePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddBasicSecurityToWorkspacePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddBasicSecurityToWorkspace) (Return Type : Dictionary<string, SPRoleType>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Security_AddBasicSecurityToWorkspace_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddBasicSecurityToWorkspace, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddBasicSecurityToWorkspace) (Return Type : Dictionary<string, SPRoleType>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Security_AddBasicSecurityToWorkspace_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddBasicSecurityToWorkspace, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #endregion

        #endregion
    }
}