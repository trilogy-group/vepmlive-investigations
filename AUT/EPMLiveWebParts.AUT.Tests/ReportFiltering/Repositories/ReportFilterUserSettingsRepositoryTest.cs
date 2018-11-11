using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveWebParts.ReportFiltering.DomainModel;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace ReportFiltering.Repositories
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="ReportFiltering.Repositories.ReportFilterUserSettingsRepository" />)
    ///     and namespace <see cref="ReportFiltering.Repositories"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ReportFilterUserSettingsRepositoryTest : AbstractBaseSetupTypedTest<ReportFilterUserSettingsRepository>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportFilterUserSettingsRepository) Initializer

        private const string MethodPersistUserSettings = "PersistUserSettings";
        private const string MethodUserHasPersistedSettings = "UserHasPersistedSettings";
        private const string MethodUpdateUserSettings = "UpdateUserSettings";
        private const string MethodInsertUserSettings = "InsertUserSettings";
        private const string MethodGetUserSettings = "GetUserSettings";
        private const string Field_web = "_web";
        private const string FieldKey = "Key";
        private Type _reportFilterUserSettingsRepositoryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportFilterUserSettingsRepository _reportFilterUserSettingsRepositoryInstance;
        private ReportFilterUserSettingsRepository _reportFilterUserSettingsRepositoryInstanceFixture;

        #region General Initializer : Class (ReportFilterUserSettingsRepository) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportFilterUserSettingsRepository" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportFilterUserSettingsRepositoryInstanceType = typeof(ReportFilterUserSettingsRepository);
            _reportFilterUserSettingsRepositoryInstanceFixture = Create(true);
            _reportFilterUserSettingsRepositoryInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportFilterUserSettingsRepository)

        #region General Initializer : Class (ReportFilterUserSettingsRepository) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ReportFilterUserSettingsRepository" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPersistUserSettings, 0)]
        [TestCase(MethodUserHasPersistedSettings, 0)]
        [TestCase(MethodUpdateUserSettings, 0)]
        [TestCase(MethodInsertUserSettings, 0)]
        [TestCase(MethodGetUserSettings, 0)]
        public void AUT_ReportFilterUserSettingsRepository_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_reportFilterUserSettingsRepositoryInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportFilterUserSettingsRepository) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportFilterUserSettingsRepository" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_web)]
        [TestCase(FieldKey)]
        public void AUT_ReportFilterUserSettingsRepository_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportFilterUserSettingsRepositoryInstanceFixture, 
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
        ///     Class (<see cref="ReportFilterUserSettingsRepository" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ReportFilterUserSettingsRepository_Is_Instance_Present_Test()
        {
            // Assert
            _reportFilterUserSettingsRepositoryInstanceType.ShouldNotBeNull();
            _reportFilterUserSettingsRepositoryInstance.ShouldNotBeNull();
            _reportFilterUserSettingsRepositoryInstanceFixture.ShouldNotBeNull();
            _reportFilterUserSettingsRepositoryInstance.ShouldBeAssignableTo<ReportFilterUserSettingsRepository>();
            _reportFilterUserSettingsRepositoryInstanceFixture.ShouldBeAssignableTo<ReportFilterUserSettingsRepository>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportFilterUserSettingsRepository) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportFilterUserSettingsRepository_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            ReportFilterUserSettingsRepository instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new ReportFilterUserSettingsRepository(web);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _reportFilterUserSettingsRepositoryInstance.ShouldNotBeNull();
            _reportFilterUserSettingsRepositoryInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<ReportFilterUserSettingsRepository>();
        }

        #endregion

        #region General Constructor : Class (ReportFilterUserSettingsRepository) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportFilterUserSettingsRepository_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            ReportFilterUserSettingsRepository instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new ReportFilterUserSettingsRepository(web);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _reportFilterUserSettingsRepositoryInstance.ShouldNotBeNull();
            _reportFilterUserSettingsRepositoryInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ReportFilterUserSettingsRepository" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPersistUserSettings)]
        [TestCase(MethodUserHasPersistedSettings)]
        [TestCase(MethodUpdateUserSettings)]
        [TestCase(MethodInsertUserSettings)]
        [TestCase(MethodGetUserSettings)]
        public void AUT_ReportFilterUserSettingsRepository_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ReportFilterUserSettingsRepository>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterUserSettingsRepository_PersistUserSettings_Method_Call_Internally(Type[] types)
        {
            var methodPersistUserSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsRepositoryInstance, MethodPersistUserSettings, Fixture, methodPersistUserSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_PersistUserSettings_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var userSettings = CreateType<ReportFilterUserSettings>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportFilterUserSettingsRepositoryInstance.PersistUserSettings(userSettings);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_PersistUserSettings_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var userSettings = CreateType<ReportFilterUserSettings>();
            var methodPersistUserSettingsPrametersTypes = new Type[] { typeof(ReportFilterUserSettings) };
            object[] parametersOfPersistUserSettings = { userSettings };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPersistUserSettings, methodPersistUserSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportFilterUserSettingsRepositoryInstanceFixture, parametersOfPersistUserSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPersistUserSettings.ShouldNotBeNull();
            parametersOfPersistUserSettings.Length.ShouldBe(1);
            methodPersistUserSettingsPrametersTypes.Length.ShouldBe(1);
            methodPersistUserSettingsPrametersTypes.Length.ShouldBe(parametersOfPersistUserSettings.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_PersistUserSettings_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var userSettings = CreateType<ReportFilterUserSettings>();
            var methodPersistUserSettingsPrametersTypes = new Type[] { typeof(ReportFilterUserSettings) };
            object[] parametersOfPersistUserSettings = { userSettings };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportFilterUserSettingsRepositoryInstance, MethodPersistUserSettings, parametersOfPersistUserSettings, methodPersistUserSettingsPrametersTypes);

            // Assert
            parametersOfPersistUserSettings.ShouldNotBeNull();
            parametersOfPersistUserSettings.Length.ShouldBe(1);
            methodPersistUserSettingsPrametersTypes.Length.ShouldBe(1);
            methodPersistUserSettingsPrametersTypes.Length.ShouldBe(parametersOfPersistUserSettings.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_PersistUserSettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPersistUserSettings, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_PersistUserSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPersistUserSettingsPrametersTypes = new Type[] { typeof(ReportFilterUserSettings) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsRepositoryInstance, MethodPersistUserSettings, Fixture, methodPersistUserSettingsPrametersTypes);

            // Assert
            methodPersistUserSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_PersistUserSettings_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPersistUserSettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterUserSettingsRepositoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UserHasPersistedSettings) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterUserSettingsRepository_UserHasPersistedSettings_Method_Call_Internally(Type[] types)
        {
            var methodUserHasPersistedSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsRepositoryInstance, MethodUserHasPersistedSettings, Fixture, methodUserHasPersistedSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (UserHasPersistedSettings) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_UserHasPersistedSettings_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var userSettings = CreateType<ReportFilterSearchCriteria>();
            var methodUserHasPersistedSettingsPrametersTypes = new Type[] { typeof(ReportFilterSearchCriteria) };
            object[] parametersOfUserHasPersistedSettings = { userSettings };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUserHasPersistedSettings, methodUserHasPersistedSettingsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportFilterUserSettingsRepository, bool>(_reportFilterUserSettingsRepositoryInstanceFixture, out exception1, parametersOfUserHasPersistedSettings);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportFilterUserSettingsRepository, bool>(_reportFilterUserSettingsRepositoryInstance, MethodUserHasPersistedSettings, parametersOfUserHasPersistedSettings, methodUserHasPersistedSettingsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUserHasPersistedSettings.ShouldNotBeNull();
            parametersOfUserHasPersistedSettings.Length.ShouldBe(1);
            methodUserHasPersistedSettingsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UserHasPersistedSettings) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_UserHasPersistedSettings_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var userSettings = CreateType<ReportFilterSearchCriteria>();
            var methodUserHasPersistedSettingsPrametersTypes = new Type[] { typeof(ReportFilterSearchCriteria) };
            object[] parametersOfUserHasPersistedSettings = { userSettings };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUserHasPersistedSettings, methodUserHasPersistedSettingsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportFilterUserSettingsRepository, bool>(_reportFilterUserSettingsRepositoryInstanceFixture, out exception1, parametersOfUserHasPersistedSettings);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportFilterUserSettingsRepository, bool>(_reportFilterUserSettingsRepositoryInstance, MethodUserHasPersistedSettings, parametersOfUserHasPersistedSettings, methodUserHasPersistedSettingsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUserHasPersistedSettings.ShouldNotBeNull();
            parametersOfUserHasPersistedSettings.Length.ShouldBe(1);
            methodUserHasPersistedSettingsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UserHasPersistedSettings) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_UserHasPersistedSettings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var userSettings = CreateType<ReportFilterSearchCriteria>();
            var methodUserHasPersistedSettingsPrametersTypes = new Type[] { typeof(ReportFilterSearchCriteria) };
            object[] parametersOfUserHasPersistedSettings = { userSettings };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportFilterUserSettingsRepository, bool>(_reportFilterUserSettingsRepositoryInstance, MethodUserHasPersistedSettings, parametersOfUserHasPersistedSettings, methodUserHasPersistedSettingsPrametersTypes);

            // Assert
            parametersOfUserHasPersistedSettings.ShouldNotBeNull();
            parametersOfUserHasPersistedSettings.Length.ShouldBe(1);
            methodUserHasPersistedSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UserHasPersistedSettings) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_UserHasPersistedSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUserHasPersistedSettingsPrametersTypes = new Type[] { typeof(ReportFilterSearchCriteria) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsRepositoryInstance, MethodUserHasPersistedSettings, Fixture, methodUserHasPersistedSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUserHasPersistedSettingsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UserHasPersistedSettings) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_UserHasPersistedSettings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUserHasPersistedSettings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterUserSettingsRepositoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UserHasPersistedSettings) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_UserHasPersistedSettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUserHasPersistedSettings, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateUserSettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterUserSettingsRepository_UpdateUserSettings_Method_Call_Internally(Type[] types)
        {
            var methodUpdateUserSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsRepositoryInstance, MethodUpdateUserSettings, Fixture, methodUpdateUserSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateUserSettings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_UpdateUserSettings_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var userSettings = CreateType<ReportFilterUserSettings>();
            var methodUpdateUserSettingsPrametersTypes = new Type[] { typeof(ReportFilterUserSettings) };
            object[] parametersOfUpdateUserSettings = { userSettings };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateUserSettings, methodUpdateUserSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportFilterUserSettingsRepositoryInstanceFixture, parametersOfUpdateUserSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateUserSettings.ShouldNotBeNull();
            parametersOfUpdateUserSettings.Length.ShouldBe(1);
            methodUpdateUserSettingsPrametersTypes.Length.ShouldBe(1);
            methodUpdateUserSettingsPrametersTypes.Length.ShouldBe(parametersOfUpdateUserSettings.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateUserSettings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_UpdateUserSettings_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var userSettings = CreateType<ReportFilterUserSettings>();
            var methodUpdateUserSettingsPrametersTypes = new Type[] { typeof(ReportFilterUserSettings) };
            object[] parametersOfUpdateUserSettings = { userSettings };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportFilterUserSettingsRepositoryInstance, MethodUpdateUserSettings, parametersOfUpdateUserSettings, methodUpdateUserSettingsPrametersTypes);

            // Assert
            parametersOfUpdateUserSettings.ShouldNotBeNull();
            parametersOfUpdateUserSettings.Length.ShouldBe(1);
            methodUpdateUserSettingsPrametersTypes.Length.ShouldBe(1);
            methodUpdateUserSettingsPrametersTypes.Length.ShouldBe(parametersOfUpdateUserSettings.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateUserSettings) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_UpdateUserSettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateUserSettings, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateUserSettings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_UpdateUserSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateUserSettingsPrametersTypes = new Type[] { typeof(ReportFilterUserSettings) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsRepositoryInstance, MethodUpdateUserSettings, Fixture, methodUpdateUserSettingsPrametersTypes);

            // Assert
            methodUpdateUserSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateUserSettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_UpdateUserSettings_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateUserSettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterUserSettingsRepositoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertUserSettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterUserSettingsRepository_InsertUserSettings_Method_Call_Internally(Type[] types)
        {
            var methodInsertUserSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsRepositoryInstance, MethodInsertUserSettings, Fixture, methodInsertUserSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (InsertUserSettings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_InsertUserSettings_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var userSettings = CreateType<ReportFilterUserSettings>();
            var methodInsertUserSettingsPrametersTypes = new Type[] { typeof(ReportFilterUserSettings) };
            object[] parametersOfInsertUserSettings = { userSettings };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInsertUserSettings, methodInsertUserSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportFilterUserSettingsRepositoryInstanceFixture, parametersOfInsertUserSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInsertUserSettings.ShouldNotBeNull();
            parametersOfInsertUserSettings.Length.ShouldBe(1);
            methodInsertUserSettingsPrametersTypes.Length.ShouldBe(1);
            methodInsertUserSettingsPrametersTypes.Length.ShouldBe(parametersOfInsertUserSettings.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InsertUserSettings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_InsertUserSettings_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var userSettings = CreateType<ReportFilterUserSettings>();
            var methodInsertUserSettingsPrametersTypes = new Type[] { typeof(ReportFilterUserSettings) };
            object[] parametersOfInsertUserSettings = { userSettings };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportFilterUserSettingsRepositoryInstance, MethodInsertUserSettings, parametersOfInsertUserSettings, methodInsertUserSettingsPrametersTypes);

            // Assert
            parametersOfInsertUserSettings.ShouldNotBeNull();
            parametersOfInsertUserSettings.Length.ShouldBe(1);
            methodInsertUserSettingsPrametersTypes.Length.ShouldBe(1);
            methodInsertUserSettingsPrametersTypes.Length.ShouldBe(parametersOfInsertUserSettings.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertUserSettings) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_InsertUserSettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInsertUserSettings, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InsertUserSettings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_InsertUserSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInsertUserSettingsPrametersTypes = new Type[] { typeof(ReportFilterUserSettings) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsRepositoryInstance, MethodInsertUserSettings, Fixture, methodInsertUserSettingsPrametersTypes);

            // Assert
            methodInsertUserSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertUserSettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_InsertUserSettings_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInsertUserSettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterUserSettingsRepositoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUserSettings) (Return Type : ReportFilterUserSettings) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterUserSettingsRepository_GetUserSettings_Method_Call_Internally(Type[] types)
        {
            var methodGetUserSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsRepositoryInstance, MethodGetUserSettings, Fixture, methodGetUserSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetUserSettings) (Return Type : ReportFilterUserSettings) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_GetUserSettings_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var searchCriteria = CreateType<ReportFilterSearchCriteria>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportFilterUserSettingsRepositoryInstance.GetUserSettings(searchCriteria);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetUserSettings) (Return Type : ReportFilterUserSettings) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_GetUserSettings_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var searchCriteria = CreateType<ReportFilterSearchCriteria>();
            var methodGetUserSettingsPrametersTypes = new Type[] { typeof(ReportFilterSearchCriteria) };
            object[] parametersOfGetUserSettings = { searchCriteria };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetUserSettings, methodGetUserSettingsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportFilterUserSettingsRepository, ReportFilterUserSettings>(_reportFilterUserSettingsRepositoryInstanceFixture, out exception1, parametersOfGetUserSettings);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportFilterUserSettingsRepository, ReportFilterUserSettings>(_reportFilterUserSettingsRepositoryInstance, MethodGetUserSettings, parametersOfGetUserSettings, methodGetUserSettingsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetUserSettings.ShouldNotBeNull();
            parametersOfGetUserSettings.Length.ShouldBe(1);
            methodGetUserSettingsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetUserSettings) (Return Type : ReportFilterUserSettings) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_GetUserSettings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var searchCriteria = CreateType<ReportFilterSearchCriteria>();
            var methodGetUserSettingsPrametersTypes = new Type[] { typeof(ReportFilterSearchCriteria) };
            object[] parametersOfGetUserSettings = { searchCriteria };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportFilterUserSettingsRepository, ReportFilterUserSettings>(_reportFilterUserSettingsRepositoryInstance, MethodGetUserSettings, parametersOfGetUserSettings, methodGetUserSettingsPrametersTypes);

            // Assert
            parametersOfGetUserSettings.ShouldNotBeNull();
            parametersOfGetUserSettings.Length.ShouldBe(1);
            methodGetUserSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUserSettings) (Return Type : ReportFilterUserSettings) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_GetUserSettings_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetUserSettingsPrametersTypes = new Type[] { typeof(ReportFilterSearchCriteria) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsRepositoryInstance, MethodGetUserSettings, Fixture, methodGetUserSettingsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetUserSettingsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetUserSettings) (Return Type : ReportFilterUserSettings) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_GetUserSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetUserSettingsPrametersTypes = new Type[] { typeof(ReportFilterSearchCriteria) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsRepositoryInstance, MethodGetUserSettings, Fixture, methodGetUserSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetUserSettingsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUserSettings) (Return Type : ReportFilterUserSettings) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_GetUserSettings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetUserSettings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterUserSettingsRepositoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetUserSettings) (Return Type : ReportFilterUserSettings) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettingsRepository_GetUserSettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetUserSettings, 0);
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