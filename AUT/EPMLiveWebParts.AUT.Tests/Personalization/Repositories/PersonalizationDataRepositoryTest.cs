using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveWebParts.Personalization.DomainModel;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.Personalization.Repositories
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.Personalization.Repositories.PersonalizationDataRepository" />)
    ///     and namespace <see cref="EPMLiveWebParts.Personalization.Repositories"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PersonalizationDataRepositoryTest : AbstractBaseSetupTypedTest<PersonalizationDataRepository>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PersonalizationDataRepository) Initializer

        private const string MethodPersistUserSettings = "PersistUserSettings";
        private const string MethodUserHasPersistedSettings = "UserHasPersistedSettings";
        private const string MethodUpdateUserSettings = "UpdateUserSettings";
        private const string MethodInsertUserSettings = "InsertUserSettings";
        private const string MethodGetUserSettings = "GetUserSettings";
        private const string Field_web = "_web";
        private const string Field_personalizationKey = "_personalizationKey";
        private Type _personalizationDataRepositoryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PersonalizationDataRepository _personalizationDataRepositoryInstance;
        private PersonalizationDataRepository _personalizationDataRepositoryInstanceFixture;

        #region General Initializer : Class (PersonalizationDataRepository) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PersonalizationDataRepository" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _personalizationDataRepositoryInstanceType = typeof(PersonalizationDataRepository);
            _personalizationDataRepositoryInstanceFixture = Create(true);
            _personalizationDataRepositoryInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PersonalizationDataRepository)

        #region General Initializer : Class (PersonalizationDataRepository) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="PersonalizationDataRepository" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPersistUserSettings, 0)]
        [TestCase(MethodUserHasPersistedSettings, 0)]
        [TestCase(MethodUpdateUserSettings, 0)]
        [TestCase(MethodInsertUserSettings, 0)]
        [TestCase(MethodGetUserSettings, 0)]
        public void AUT_PersonalizationDataRepository_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_personalizationDataRepositoryInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PersonalizationDataRepository) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PersonalizationDataRepository" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_web)]
        [TestCase(Field_personalizationKey)]
        public void AUT_PersonalizationDataRepository_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_personalizationDataRepositoryInstanceFixture, 
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
        ///     Class (<see cref="PersonalizationDataRepository" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PersonalizationDataRepository_Is_Instance_Present_Test()
        {
            // Assert
            _personalizationDataRepositoryInstanceType.ShouldNotBeNull();
            _personalizationDataRepositoryInstance.ShouldNotBeNull();
            _personalizationDataRepositoryInstanceFixture.ShouldNotBeNull();
            _personalizationDataRepositoryInstance.ShouldBeAssignableTo<PersonalizationDataRepository>();
            _personalizationDataRepositoryInstanceFixture.ShouldBeAssignableTo<PersonalizationDataRepository>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PersonalizationDataRepository) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PersonalizationDataRepository_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var personalizationKey = CreateType<string>();
            PersonalizationDataRepository instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new PersonalizationDataRepository(web, personalizationKey);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _personalizationDataRepositoryInstance.ShouldNotBeNull();
            _personalizationDataRepositoryInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<PersonalizationDataRepository>();
        }

        #endregion

        #region General Constructor : Class (PersonalizationDataRepository) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PersonalizationDataRepository_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var personalizationKey = CreateType<string>();
            PersonalizationDataRepository instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new PersonalizationDataRepository(web, personalizationKey);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _personalizationDataRepositoryInstance.ShouldNotBeNull();
            _personalizationDataRepositoryInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="PersonalizationDataRepository" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPersistUserSettings)]
        [TestCase(MethodUserHasPersistedSettings)]
        [TestCase(MethodUpdateUserSettings)]
        [TestCase(MethodInsertUserSettings)]
        [TestCase(MethodGetUserSettings)]
        public void AUT_PersonalizationDataRepository_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<PersonalizationDataRepository>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PersonalizationDataRepository_PersistUserSettings_Method_Call_Internally(Type[] types)
        {
            var methodPersistUserSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalizationDataRepositoryInstance, MethodPersistUserSettings, Fixture, methodPersistUserSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationDataRepository_PersistUserSettings_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var userSettings = CreateType<PersonalizationData>();
            Action executeAction = null;

            // Act
            executeAction = () => _personalizationDataRepositoryInstance.PersistUserSettings(userSettings);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationDataRepository_PersistUserSettings_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var userSettings = CreateType<PersonalizationData>();
            var methodPersistUserSettingsPrametersTypes = new Type[] { typeof(PersonalizationData) };
            object[] parametersOfPersistUserSettings = { userSettings };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPersistUserSettings, methodPersistUserSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_personalizationDataRepositoryInstanceFixture, parametersOfPersistUserSettings);

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
        public void AUT_PersonalizationDataRepository_PersistUserSettings_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var userSettings = CreateType<PersonalizationData>();
            var methodPersistUserSettingsPrametersTypes = new Type[] { typeof(PersonalizationData) };
            object[] parametersOfPersistUserSettings = { userSettings };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_personalizationDataRepositoryInstance, MethodPersistUserSettings, parametersOfPersistUserSettings, methodPersistUserSettingsPrametersTypes);

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
        public void AUT_PersonalizationDataRepository_PersistUserSettings_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_PersonalizationDataRepository_PersistUserSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPersistUserSettingsPrametersTypes = new Type[] { typeof(PersonalizationData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalizationDataRepositoryInstance, MethodPersistUserSettings, Fixture, methodPersistUserSettingsPrametersTypes);

            // Assert
            methodPersistUserSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationDataRepository_PersistUserSettings_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPersistUserSettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_personalizationDataRepositoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UserHasPersistedSettings) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PersonalizationDataRepository_UserHasPersistedSettings_Method_Call_Internally(Type[] types)
        {
            var methodUserHasPersistedSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalizationDataRepositoryInstance, MethodUserHasPersistedSettings, Fixture, methodUserHasPersistedSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (UserHasPersistedSettings) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationDataRepository_UserHasPersistedSettings_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var personalizationSearchCriteria = CreateType<PersonalizationSearchCriteria>();
            var methodUserHasPersistedSettingsPrametersTypes = new Type[] { typeof(PersonalizationSearchCriteria) };
            object[] parametersOfUserHasPersistedSettings = { personalizationSearchCriteria };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUserHasPersistedSettings, methodUserHasPersistedSettingsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PersonalizationDataRepository, bool>(_personalizationDataRepositoryInstanceFixture, out exception1, parametersOfUserHasPersistedSettings);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PersonalizationDataRepository, bool>(_personalizationDataRepositoryInstance, MethodUserHasPersistedSettings, parametersOfUserHasPersistedSettings, methodUserHasPersistedSettingsPrametersTypes);

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
        public void AUT_PersonalizationDataRepository_UserHasPersistedSettings_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var personalizationSearchCriteria = CreateType<PersonalizationSearchCriteria>();
            var methodUserHasPersistedSettingsPrametersTypes = new Type[] { typeof(PersonalizationSearchCriteria) };
            object[] parametersOfUserHasPersistedSettings = { personalizationSearchCriteria };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUserHasPersistedSettings, methodUserHasPersistedSettingsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PersonalizationDataRepository, bool>(_personalizationDataRepositoryInstanceFixture, out exception1, parametersOfUserHasPersistedSettings);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PersonalizationDataRepository, bool>(_personalizationDataRepositoryInstance, MethodUserHasPersistedSettings, parametersOfUserHasPersistedSettings, methodUserHasPersistedSettingsPrametersTypes);

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
        public void AUT_PersonalizationDataRepository_UserHasPersistedSettings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var personalizationSearchCriteria = CreateType<PersonalizationSearchCriteria>();
            var methodUserHasPersistedSettingsPrametersTypes = new Type[] { typeof(PersonalizationSearchCriteria) };
            object[] parametersOfUserHasPersistedSettings = { personalizationSearchCriteria };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PersonalizationDataRepository, bool>(_personalizationDataRepositoryInstance, MethodUserHasPersistedSettings, parametersOfUserHasPersistedSettings, methodUserHasPersistedSettingsPrametersTypes);

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
        public void AUT_PersonalizationDataRepository_UserHasPersistedSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUserHasPersistedSettingsPrametersTypes = new Type[] { typeof(PersonalizationSearchCriteria) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalizationDataRepositoryInstance, MethodUserHasPersistedSettings, Fixture, methodUserHasPersistedSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUserHasPersistedSettingsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UserHasPersistedSettings) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationDataRepository_UserHasPersistedSettings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUserHasPersistedSettings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_personalizationDataRepositoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UserHasPersistedSettings) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationDataRepository_UserHasPersistedSettings_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_PersonalizationDataRepository_UpdateUserSettings_Method_Call_Internally(Type[] types)
        {
            var methodUpdateUserSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalizationDataRepositoryInstance, MethodUpdateUserSettings, Fixture, methodUpdateUserSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateUserSettings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationDataRepository_UpdateUserSettings_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var personalizationData = CreateType<PersonalizationData>();
            var methodUpdateUserSettingsPrametersTypes = new Type[] { typeof(PersonalizationData) };
            object[] parametersOfUpdateUserSettings = { personalizationData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateUserSettings, methodUpdateUserSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_personalizationDataRepositoryInstanceFixture, parametersOfUpdateUserSettings);

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
        public void AUT_PersonalizationDataRepository_UpdateUserSettings_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var personalizationData = CreateType<PersonalizationData>();
            var methodUpdateUserSettingsPrametersTypes = new Type[] { typeof(PersonalizationData) };
            object[] parametersOfUpdateUserSettings = { personalizationData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_personalizationDataRepositoryInstance, MethodUpdateUserSettings, parametersOfUpdateUserSettings, methodUpdateUserSettingsPrametersTypes);

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
        public void AUT_PersonalizationDataRepository_UpdateUserSettings_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_PersonalizationDataRepository_UpdateUserSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateUserSettingsPrametersTypes = new Type[] { typeof(PersonalizationData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalizationDataRepositoryInstance, MethodUpdateUserSettings, Fixture, methodUpdateUserSettingsPrametersTypes);

            // Assert
            methodUpdateUserSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateUserSettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationDataRepository_UpdateUserSettings_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateUserSettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_personalizationDataRepositoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertUserSettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PersonalizationDataRepository_InsertUserSettings_Method_Call_Internally(Type[] types)
        {
            var methodInsertUserSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalizationDataRepositoryInstance, MethodInsertUserSettings, Fixture, methodInsertUserSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (InsertUserSettings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationDataRepository_InsertUserSettings_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var userSettings = CreateType<PersonalizationData>();
            var methodInsertUserSettingsPrametersTypes = new Type[] { typeof(PersonalizationData) };
            object[] parametersOfInsertUserSettings = { userSettings };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInsertUserSettings, methodInsertUserSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_personalizationDataRepositoryInstanceFixture, parametersOfInsertUserSettings);

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
        public void AUT_PersonalizationDataRepository_InsertUserSettings_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var userSettings = CreateType<PersonalizationData>();
            var methodInsertUserSettingsPrametersTypes = new Type[] { typeof(PersonalizationData) };
            object[] parametersOfInsertUserSettings = { userSettings };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_personalizationDataRepositoryInstance, MethodInsertUserSettings, parametersOfInsertUserSettings, methodInsertUserSettingsPrametersTypes);

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
        public void AUT_PersonalizationDataRepository_InsertUserSettings_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_PersonalizationDataRepository_InsertUserSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInsertUserSettingsPrametersTypes = new Type[] { typeof(PersonalizationData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalizationDataRepositoryInstance, MethodInsertUserSettings, Fixture, methodInsertUserSettingsPrametersTypes);

            // Assert
            methodInsertUserSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertUserSettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationDataRepository_InsertUserSettings_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInsertUserSettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_personalizationDataRepositoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUserSettings) (Return Type : PersonalizationData) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PersonalizationDataRepository_GetUserSettings_Method_Call_Internally(Type[] types)
        {
            var methodGetUserSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalizationDataRepositoryInstance, MethodGetUserSettings, Fixture, methodGetUserSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetUserSettings) (Return Type : PersonalizationData) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationDataRepository_GetUserSettings_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var searchCriteria = CreateType<PersonalizationSearchCriteria>();
            Action executeAction = null;

            // Act
            executeAction = () => _personalizationDataRepositoryInstance.GetUserSettings(searchCriteria);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetUserSettings) (Return Type : PersonalizationData) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationDataRepository_GetUserSettings_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var searchCriteria = CreateType<PersonalizationSearchCriteria>();
            var methodGetUserSettingsPrametersTypes = new Type[] { typeof(PersonalizationSearchCriteria) };
            object[] parametersOfGetUserSettings = { searchCriteria };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetUserSettings, methodGetUserSettingsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PersonalizationDataRepository, PersonalizationData>(_personalizationDataRepositoryInstanceFixture, out exception1, parametersOfGetUserSettings);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PersonalizationDataRepository, PersonalizationData>(_personalizationDataRepositoryInstance, MethodGetUserSettings, parametersOfGetUserSettings, methodGetUserSettingsPrametersTypes);

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

        #region Method Call : (GetUserSettings) (Return Type : PersonalizationData) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationDataRepository_GetUserSettings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var searchCriteria = CreateType<PersonalizationSearchCriteria>();
            var methodGetUserSettingsPrametersTypes = new Type[] { typeof(PersonalizationSearchCriteria) };
            object[] parametersOfGetUserSettings = { searchCriteria };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PersonalizationDataRepository, PersonalizationData>(_personalizationDataRepositoryInstance, MethodGetUserSettings, parametersOfGetUserSettings, methodGetUserSettingsPrametersTypes);

            // Assert
            parametersOfGetUserSettings.ShouldNotBeNull();
            parametersOfGetUserSettings.Length.ShouldBe(1);
            methodGetUserSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUserSettings) (Return Type : PersonalizationData) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationDataRepository_GetUserSettings_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetUserSettingsPrametersTypes = new Type[] { typeof(PersonalizationSearchCriteria) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalizationDataRepositoryInstance, MethodGetUserSettings, Fixture, methodGetUserSettingsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetUserSettingsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetUserSettings) (Return Type : PersonalizationData) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationDataRepository_GetUserSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetUserSettingsPrametersTypes = new Type[] { typeof(PersonalizationSearchCriteria) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalizationDataRepositoryInstance, MethodGetUserSettings, Fixture, methodGetUserSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetUserSettingsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUserSettings) (Return Type : PersonalizationData) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationDataRepository_GetUserSettings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetUserSettings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_personalizationDataRepositoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetUserSettings) (Return Type : PersonalizationData) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationDataRepository_GetUserSettings_Method_Call_Parameters_Count_Verification_Test()
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