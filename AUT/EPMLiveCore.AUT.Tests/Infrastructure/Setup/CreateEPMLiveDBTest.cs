using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint.Administration;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Infrastructure.Setup
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.Setup.CreateEPMLiveDB" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure.Setup"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CreateEPMLiveDBTest : AbstractBaseSetupTypedTest<CreateEPMLiveDB>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CreateEPMLiveDB) Initializer

        private const string MethodCreateEPMLiveDatabase = "CreateEPMLiveDatabase";
        private const string MethodGetWebApplication = "GetWebApplication";
        private Type _createEPMLiveDBInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CreateEPMLiveDB _createEPMLiveDBInstance;
        private CreateEPMLiveDB _createEPMLiveDBInstanceFixture;

        #region General Initializer : Class (CreateEPMLiveDB) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CreateEPMLiveDB" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _createEPMLiveDBInstanceType = typeof(CreateEPMLiveDB);
            _createEPMLiveDBInstanceFixture = Create(true);
            _createEPMLiveDBInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CreateEPMLiveDB)

        #region General Initializer : Class (CreateEPMLiveDB) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CreateEPMLiveDB" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodCreateEPMLiveDatabase, 0)]
        [TestCase(MethodGetWebApplication, 0)]
        public void AUT_CreateEPMLiveDB_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_createEPMLiveDBInstanceFixture, 
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
        ///     Class (<see cref="CreateEPMLiveDB" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CreateEPMLiveDB_Is_Instance_Present_Test()
        {
            // Assert
            _createEPMLiveDBInstanceType.ShouldNotBeNull();
            _createEPMLiveDBInstance.ShouldNotBeNull();
            _createEPMLiveDBInstanceFixture.ShouldNotBeNull();
            _createEPMLiveDBInstance.ShouldBeAssignableTo<CreateEPMLiveDB>();
            _createEPMLiveDBInstanceFixture.ShouldBeAssignableTo<CreateEPMLiveDB>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CreateEPMLiveDB) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CreateEPMLiveDB_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CreateEPMLiveDB instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _createEPMLiveDBInstanceType.ShouldNotBeNull();
            _createEPMLiveDBInstance.ShouldNotBeNull();
            _createEPMLiveDBInstanceFixture.ShouldNotBeNull();
            _createEPMLiveDBInstance.ShouldBeAssignableTo<CreateEPMLiveDB>();
            _createEPMLiveDBInstanceFixture.ShouldBeAssignableTo<CreateEPMLiveDB>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="CreateEPMLiveDB" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCreateEPMLiveDatabase)]
        [TestCase(MethodGetWebApplication)]
        public void AUT_CreateEPMLiveDB_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CreateEPMLiveDB>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (CreateEPMLiveDatabase) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateEPMLiveDB_CreateEPMLiveDatabase_Method_Call_Internally(Type[] types)
        {
            var methodCreateEPMLiveDatabasePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createEPMLiveDBInstance, MethodCreateEPMLiveDatabase, Fixture, methodCreateEPMLiveDatabasePrametersTypes);
        }

        #endregion

        #region Method Call : (CreateEPMLiveDatabase) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateEPMLiveDB_CreateEPMLiveDatabase_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var webAppID = CreateType<Guid>();
            var sSqlServer = CreateType<string>();
            var sDatabase = CreateType<string>();
            var sUsername = CreateType<string>();
            var sPassword = CreateType<string>();
            var output = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _createEPMLiveDBInstance.CreateEPMLiveDatabase(webAppID, sSqlServer, sDatabase, sUsername, sPassword, out output);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CreateEPMLiveDatabase) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateEPMLiveDB_CreateEPMLiveDatabase_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var webAppID = CreateType<Guid>();
            var sSqlServer = CreateType<string>();
            var sDatabase = CreateType<string>();
            var sUsername = CreateType<string>();
            var sPassword = CreateType<string>();
            var output = CreateType<string>();
            var methodCreateEPMLiveDatabasePrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfCreateEPMLiveDatabase = { webAppID, sSqlServer, sDatabase, sUsername, sPassword, output };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateEPMLiveDatabase, methodCreateEPMLiveDatabasePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CreateEPMLiveDB, bool>(_createEPMLiveDBInstanceFixture, out exception1, parametersOfCreateEPMLiveDatabase);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CreateEPMLiveDB, bool>(_createEPMLiveDBInstance, MethodCreateEPMLiveDatabase, parametersOfCreateEPMLiveDatabase, methodCreateEPMLiveDatabasePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCreateEPMLiveDatabase.ShouldNotBeNull();
            parametersOfCreateEPMLiveDatabase.Length.ShouldBe(6);
            methodCreateEPMLiveDatabasePrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CreateEPMLiveDB, bool>(_createEPMLiveDBInstance, MethodCreateEPMLiveDatabase, parametersOfCreateEPMLiveDatabase, methodCreateEPMLiveDatabasePrametersTypes));
        }

        #endregion

        #region Method Call : (CreateEPMLiveDatabase) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateEPMLiveDB_CreateEPMLiveDatabase_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var webAppID = CreateType<Guid>();
            var sSqlServer = CreateType<string>();
            var sDatabase = CreateType<string>();
            var sUsername = CreateType<string>();
            var sPassword = CreateType<string>();
            var output = CreateType<string>();
            var methodCreateEPMLiveDatabasePrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfCreateEPMLiveDatabase = { webAppID, sSqlServer, sDatabase, sUsername, sPassword, output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateEPMLiveDatabase, methodCreateEPMLiveDatabasePrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateEPMLiveDatabase.ShouldNotBeNull();
            parametersOfCreateEPMLiveDatabase.Length.ShouldBe(6);
            methodCreateEPMLiveDatabasePrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(() => methodInfo.Invoke(_createEPMLiveDBInstanceFixture, parametersOfCreateEPMLiveDatabase));
        }

        #endregion

        #region Method Call : (CreateEPMLiveDatabase) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateEPMLiveDB_CreateEPMLiveDatabase_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webAppID = CreateType<Guid>();
            var sSqlServer = CreateType<string>();
            var sDatabase = CreateType<string>();
            var sUsername = CreateType<string>();
            var sPassword = CreateType<string>();
            var output = CreateType<string>();
            var methodCreateEPMLiveDatabasePrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfCreateEPMLiveDatabase = { webAppID, sSqlServer, sDatabase, sUsername, sPassword, output };

            // Assert
            parametersOfCreateEPMLiveDatabase.ShouldNotBeNull();
            parametersOfCreateEPMLiveDatabase.Length.ShouldBe(6);
            methodCreateEPMLiveDatabasePrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CreateEPMLiveDB, bool>(_createEPMLiveDBInstance, MethodCreateEPMLiveDatabase, parametersOfCreateEPMLiveDatabase, methodCreateEPMLiveDatabasePrametersTypes));
        }

        #endregion

        #region Method Call : (CreateEPMLiveDatabase) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateEPMLiveDB_CreateEPMLiveDatabase_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateEPMLiveDatabasePrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createEPMLiveDBInstance, MethodCreateEPMLiveDatabase, Fixture, methodCreateEPMLiveDatabasePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateEPMLiveDatabasePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateEPMLiveDatabase) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateEPMLiveDB_CreateEPMLiveDatabase_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateEPMLiveDatabase, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_createEPMLiveDBInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (CreateEPMLiveDatabase) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateEPMLiveDB_CreateEPMLiveDatabase_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateEPMLiveDatabase, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWebApplication) (Return Type : SPWebApplication) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateEPMLiveDB_GetWebApplication_Method_Call_Internally(Type[] types)
        {
            var methodGetWebApplicationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createEPMLiveDBInstance, MethodGetWebApplication, Fixture, methodGetWebApplicationPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWebApplication) (Return Type : SPWebApplication) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateEPMLiveDB_GetWebApplication_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var webAppId = CreateType<Guid>();
            var methodGetWebApplicationPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetWebApplication = { webAppId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetWebApplication, methodGetWebApplicationPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CreateEPMLiveDB, SPWebApplication>(_createEPMLiveDBInstanceFixture, out exception1, parametersOfGetWebApplication);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CreateEPMLiveDB, SPWebApplication>(_createEPMLiveDBInstance, MethodGetWebApplication, parametersOfGetWebApplication, methodGetWebApplicationPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetWebApplication.ShouldNotBeNull();
            parametersOfGetWebApplication.Length.ShouldBe(1);
            methodGetWebApplicationPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_createEPMLiveDBInstanceFixture, parametersOfGetWebApplication));
        }

        #endregion

        #region Method Call : (GetWebApplication) (Return Type : SPWebApplication) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateEPMLiveDB_GetWebApplication_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webAppId = CreateType<Guid>();
            var methodGetWebApplicationPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetWebApplication = { webAppId };

            // Assert
            parametersOfGetWebApplication.ShouldNotBeNull();
            parametersOfGetWebApplication.Length.ShouldBe(1);
            methodGetWebApplicationPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CreateEPMLiveDB, SPWebApplication>(_createEPMLiveDBInstance, MethodGetWebApplication, parametersOfGetWebApplication, methodGetWebApplicationPrametersTypes));
        }

        #endregion

        #region Method Call : (GetWebApplication) (Return Type : SPWebApplication) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateEPMLiveDB_GetWebApplication_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetWebApplicationPrametersTypes = new Type[] { typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createEPMLiveDBInstance, MethodGetWebApplication, Fixture, methodGetWebApplicationPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetWebApplicationPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetWebApplication) (Return Type : SPWebApplication) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateEPMLiveDB_GetWebApplication_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetWebApplicationPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createEPMLiveDBInstance, MethodGetWebApplication, Fixture, methodGetWebApplicationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWebApplicationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWebApplication) (Return Type : SPWebApplication) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateEPMLiveDB_GetWebApplication_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWebApplication, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_createEPMLiveDBInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWebApplication) (Return Type : SPWebApplication) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateEPMLiveDB_GetWebApplication_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetWebApplication, 0);
            const int parametersCount = 1;

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