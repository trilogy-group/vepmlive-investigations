using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Jobs
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.SecurityUpdate" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SecurityUpdateTest : AbstractBaseSetupTypedTest<SecurityUpdate>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SecurityUpdate) Initializer

        private const string Methodexecute = "execute";
        private const string MethodGetIdenticalGroupName = "GetIdenticalGroupName";
        private const string MethodProcessSecurity = "ProcessSecurity";
        private const string MethodAddBasicSecurityGroups = "AddBasicSecurityGroups";
        private const string MethodAddBuildTeamSecurityGroups = "AddBuildTeamSecurityGroups";
        private const string MethodAddNewItemLvlPerm = "AddNewItemLvlPerm";
        private const string MethodGetSafeGroupTitle = "GetSafeGroupTitle";
        private const string FieldsafeGroupTitle = "safeGroupTitle";
        private Type _securityUpdateInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SecurityUpdate _securityUpdateInstance;
        private SecurityUpdate _securityUpdateInstanceFixture;

        #region General Initializer : Class (SecurityUpdate) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SecurityUpdate" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _securityUpdateInstanceType = typeof(SecurityUpdate);
            _securityUpdateInstanceFixture = Create(true);
            _securityUpdateInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SecurityUpdate)

        #region General Initializer : Class (SecurityUpdate) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="SecurityUpdate" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Methodexecute, 0)]
        [TestCase(MethodGetIdenticalGroupName, 0)]
        [TestCase(MethodProcessSecurity, 0)]
        [TestCase(MethodAddBasicSecurityGroups, 0)]
        [TestCase(MethodAddBuildTeamSecurityGroups, 0)]
        [TestCase(MethodAddNewItemLvlPerm, 0)]
        [TestCase(MethodAddNewItemLvlPerm, 1)]
        [TestCase(MethodGetSafeGroupTitle, 0)]
        public void AUT_SecurityUpdate_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_securityUpdateInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SecurityUpdate) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SecurityUpdate" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldsafeGroupTitle)]
        public void AUT_SecurityUpdate_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_securityUpdateInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="SecurityUpdate" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(Methodexecute)]
        [TestCase(MethodGetIdenticalGroupName)]
        [TestCase(MethodProcessSecurity)]
        [TestCase(MethodAddBasicSecurityGroups)]
        [TestCase(MethodAddBuildTeamSecurityGroups)]
        [TestCase(MethodAddNewItemLvlPerm)]
        [TestCase(MethodGetSafeGroupTitle)]
        public void AUT_SecurityUpdate_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<SecurityUpdate>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SecurityUpdate_execute_Method_Call_Internally(Type[] types)
        {
            var methodexecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_securityUpdateInstance, Methodexecute, Fixture, methodexecutePrametersTypes);
        }

        #endregion

        #region Method Call : (GetIdenticalGroupName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SecurityUpdate_GetIdenticalGroupName_Method_Call_Internally(Type[] types)
        {
            var methodGetIdenticalGroupNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_securityUpdateInstance, MethodGetIdenticalGroupName, Fixture, methodGetIdenticalGroupNamePrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessSecurity) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SecurityUpdate_ProcessSecurity_Method_Call_Internally(Type[] types)
        {
            var methodProcessSecurityPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_securityUpdateInstance, MethodProcessSecurity, Fixture, methodProcessSecurityPrametersTypes);
        }

        #endregion

        #region Method Call : (AddBasicSecurityGroups) (Return Type : Dictionary<string, SPRoleType>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SecurityUpdate_AddBasicSecurityGroups_Method_Call_Internally(Type[] types)
        {
            var methodAddBasicSecurityGroupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_securityUpdateInstance, MethodAddBasicSecurityGroups, Fixture, methodAddBasicSecurityGroupsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddBuildTeamSecurityGroups) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SecurityUpdate_AddBuildTeamSecurityGroups_Method_Call_Internally(Type[] types)
        {
            var methodAddBuildTeamSecurityGroupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_securityUpdateInstance, MethodAddBuildTeamSecurityGroups, Fixture, methodAddBuildTeamSecurityGroupsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddNewItemLvlPerm) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SecurityUpdate_AddNewItemLvlPerm_Method_Call_Internally(Type[] types)
        {
            var methodAddNewItemLvlPermPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_securityUpdateInstance, MethodAddNewItemLvlPerm, Fixture, methodAddNewItemLvlPermPrametersTypes);
        }

        #endregion

        #region Method Call : (AddNewItemLvlPerm) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SecurityUpdate_AddNewItemLvlPerm_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodAddNewItemLvlPermPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_securityUpdateInstance, MethodAddNewItemLvlPerm, Fixture, methodAddNewItemLvlPermPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSafeGroupTitle) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SecurityUpdate_GetSafeGroupTitle_Method_Call_Internally(Type[] types)
        {
            var methodGetSafeGroupTitlePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_securityUpdateInstance, MethodGetSafeGroupTitle, Fixture, methodGetSafeGroupTitlePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}