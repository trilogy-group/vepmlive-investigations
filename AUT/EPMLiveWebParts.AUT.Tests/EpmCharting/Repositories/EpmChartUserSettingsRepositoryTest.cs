using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveWebParts.EpmCharting.DomainModel;
using EPMLiveWebParts.Personalization.DomainModel;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.EpmCharting.Repositories
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.EpmCharting.Repositories.EpmChartUserSettingsRepository" />)
    ///     and namespace <see cref="EPMLiveWebParts.EpmCharting.Repositories"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EpmChartUserSettingsRepositoryTest : AbstractBaseSetupTypedTest<EpmChartUserSettingsRepository>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EpmChartUserSettingsRepository) Initializer

        private const string MethodGetChartSettings = "GetChartSettings";
        private const string MethodPersistChartSettings = "PersistChartSettings";
        private const string Field_web = "_web";
        private Type _epmChartUserSettingsRepositoryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EpmChartUserSettingsRepository _epmChartUserSettingsRepositoryInstance;
        private EpmChartUserSettingsRepository _epmChartUserSettingsRepositoryInstanceFixture;

        #region General Initializer : Class (EpmChartUserSettingsRepository) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EpmChartUserSettingsRepository" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _epmChartUserSettingsRepositoryInstanceType = typeof(EpmChartUserSettingsRepository);
            _epmChartUserSettingsRepositoryInstanceFixture = Create(true);
            _epmChartUserSettingsRepositoryInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EpmChartUserSettingsRepository)

        #region General Initializer : Class (EpmChartUserSettingsRepository) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EpmChartUserSettingsRepository" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetChartSettings, 0)]
        [TestCase(MethodPersistChartSettings, 0)]
        public void AUT_EpmChartUserSettingsRepository_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_epmChartUserSettingsRepositoryInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EpmChartUserSettingsRepository) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EpmChartUserSettingsRepository" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_web)]
        public void AUT_EpmChartUserSettingsRepository_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_epmChartUserSettingsRepositoryInstanceFixture, 
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
        ///     Class (<see cref="EpmChartUserSettingsRepository" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_EpmChartUserSettingsRepository_Is_Instance_Present_Test()
        {
            // Assert
            _epmChartUserSettingsRepositoryInstanceType.ShouldNotBeNull();
            _epmChartUserSettingsRepositoryInstance.ShouldNotBeNull();
            _epmChartUserSettingsRepositoryInstanceFixture.ShouldNotBeNull();
            _epmChartUserSettingsRepositoryInstance.ShouldBeAssignableTo<EpmChartUserSettingsRepository>();
            _epmChartUserSettingsRepositoryInstanceFixture.ShouldBeAssignableTo<EpmChartUserSettingsRepository>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EpmChartUserSettingsRepository) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EpmChartUserSettingsRepository_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            EpmChartUserSettingsRepository instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new EpmChartUserSettingsRepository(web);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _epmChartUserSettingsRepositoryInstance.ShouldNotBeNull();
            _epmChartUserSettingsRepositoryInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<EpmChartUserSettingsRepository>();
        }

        #endregion

        #region General Constructor : Class (EpmChartUserSettingsRepository) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EpmChartUserSettingsRepository_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            EpmChartUserSettingsRepository instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new EpmChartUserSettingsRepository(web);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _epmChartUserSettingsRepositoryInstance.ShouldNotBeNull();
            _epmChartUserSettingsRepositoryInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="EpmChartUserSettingsRepository" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetChartSettings)]
        [TestCase(MethodPersistChartSettings)]
        public void AUT_EpmChartUserSettingsRepository_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<EpmChartUserSettingsRepository>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetChartSettings) (Return Type : EpmChartUserSettings) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChartUserSettingsRepository_GetChartSettings_Method_Call_Internally(Type[] types)
        {
            var methodGetChartSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartUserSettingsRepositoryInstance, MethodGetChartSettings, Fixture, methodGetChartSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetChartSettings) (Return Type : EpmChartUserSettings) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettingsRepository_GetChartSettings_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var searchCriteria = CreateType<PersonalizationSearchCriteria>();
            Action executeAction = null;

            // Act
            executeAction = () => _epmChartUserSettingsRepositoryInstance.GetChartSettings(searchCriteria);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetChartSettings) (Return Type : EpmChartUserSettings) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettingsRepository_GetChartSettings_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var searchCriteria = CreateType<PersonalizationSearchCriteria>();
            var methodGetChartSettingsPrametersTypes = new Type[] { typeof(PersonalizationSearchCriteria) };
            object[] parametersOfGetChartSettings = { searchCriteria };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetChartSettings, methodGetChartSettingsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EpmChartUserSettingsRepository, EpmChartUserSettings>(_epmChartUserSettingsRepositoryInstanceFixture, out exception1, parametersOfGetChartSettings);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EpmChartUserSettingsRepository, EpmChartUserSettings>(_epmChartUserSettingsRepositoryInstance, MethodGetChartSettings, parametersOfGetChartSettings, methodGetChartSettingsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetChartSettings.ShouldNotBeNull();
            parametersOfGetChartSettings.Length.ShouldBe(1);
            methodGetChartSettingsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetChartSettings) (Return Type : EpmChartUserSettings) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettingsRepository_GetChartSettings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var searchCriteria = CreateType<PersonalizationSearchCriteria>();
            var methodGetChartSettingsPrametersTypes = new Type[] { typeof(PersonalizationSearchCriteria) };
            object[] parametersOfGetChartSettings = { searchCriteria };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EpmChartUserSettingsRepository, EpmChartUserSettings>(_epmChartUserSettingsRepositoryInstance, MethodGetChartSettings, parametersOfGetChartSettings, methodGetChartSettingsPrametersTypes);

            // Assert
            parametersOfGetChartSettings.ShouldNotBeNull();
            parametersOfGetChartSettings.Length.ShouldBe(1);
            methodGetChartSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetChartSettings) (Return Type : EpmChartUserSettings) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettingsRepository_GetChartSettings_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetChartSettingsPrametersTypes = new Type[] { typeof(PersonalizationSearchCriteria) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartUserSettingsRepositoryInstance, MethodGetChartSettings, Fixture, methodGetChartSettingsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetChartSettingsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetChartSettings) (Return Type : EpmChartUserSettings) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettingsRepository_GetChartSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetChartSettingsPrametersTypes = new Type[] { typeof(PersonalizationSearchCriteria) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartUserSettingsRepositoryInstance, MethodGetChartSettings, Fixture, methodGetChartSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetChartSettingsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetChartSettings) (Return Type : EpmChartUserSettings) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettingsRepository_GetChartSettings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetChartSettings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartUserSettingsRepositoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetChartSettings) (Return Type : EpmChartUserSettings) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettingsRepository_GetChartSettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetChartSettings, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PersistChartSettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChartUserSettingsRepository_PersistChartSettings_Method_Call_Internally(Type[] types)
        {
            var methodPersistChartSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartUserSettingsRepositoryInstance, MethodPersistChartSettings, Fixture, methodPersistChartSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (PersistChartSettings) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettingsRepository_PersistChartSettings_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var chartSettings = CreateType<EpmChartUserSettings>();
            Action executeAction = null;

            // Act
            executeAction = () => _epmChartUserSettingsRepositoryInstance.PersistChartSettings(chartSettings);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (PersistChartSettings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettingsRepository_PersistChartSettings_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var chartSettings = CreateType<EpmChartUserSettings>();
            var methodPersistChartSettingsPrametersTypes = new Type[] { typeof(EpmChartUserSettings) };
            object[] parametersOfPersistChartSettings = { chartSettings };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPersistChartSettings, methodPersistChartSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartUserSettingsRepositoryInstanceFixture, parametersOfPersistChartSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPersistChartSettings.ShouldNotBeNull();
            parametersOfPersistChartSettings.Length.ShouldBe(1);
            methodPersistChartSettingsPrametersTypes.Length.ShouldBe(1);
            methodPersistChartSettingsPrametersTypes.Length.ShouldBe(parametersOfPersistChartSettings.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PersistChartSettings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettingsRepository_PersistChartSettings_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var chartSettings = CreateType<EpmChartUserSettings>();
            var methodPersistChartSettingsPrametersTypes = new Type[] { typeof(EpmChartUserSettings) };
            object[] parametersOfPersistChartSettings = { chartSettings };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_epmChartUserSettingsRepositoryInstance, MethodPersistChartSettings, parametersOfPersistChartSettings, methodPersistChartSettingsPrametersTypes);

            // Assert
            parametersOfPersistChartSettings.ShouldNotBeNull();
            parametersOfPersistChartSettings.Length.ShouldBe(1);
            methodPersistChartSettingsPrametersTypes.Length.ShouldBe(1);
            methodPersistChartSettingsPrametersTypes.Length.ShouldBe(parametersOfPersistChartSettings.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PersistChartSettings) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettingsRepository_PersistChartSettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPersistChartSettings, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PersistChartSettings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettingsRepository_PersistChartSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPersistChartSettingsPrametersTypes = new Type[] { typeof(EpmChartUserSettings) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartUserSettingsRepositoryInstance, MethodPersistChartSettings, Fixture, methodPersistChartSettingsPrametersTypes);

            // Assert
            methodPersistChartSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PersistChartSettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettingsRepository_PersistChartSettings_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPersistChartSettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartUserSettingsRepositoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}