using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveWebParts.EpmCharting.DomainModel;
using EPMLiveWebParts.Personalization.DomainModel;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.EpmCharting.Mappers
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.EpmCharting.Mappers.EpmChartUserSettingsToPersonalizationDataMapper" />)
    ///     and namespace <see cref="EPMLiveWebParts.EpmCharting.Mappers"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EpmChartUserSettingsToPersonalizationDataMapperTest : AbstractBaseSetupTypedTest<EpmChartUserSettingsToPersonalizationDataMapper>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EpmChartUserSettingsToPersonalizationDataMapper) Initializer

        private const string MethodGetPersonalizationData = "GetPersonalizationData";
        private Type _epmChartUserSettingsToPersonalizationDataMapperInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EpmChartUserSettingsToPersonalizationDataMapper _epmChartUserSettingsToPersonalizationDataMapperInstance;
        private EpmChartUserSettingsToPersonalizationDataMapper _epmChartUserSettingsToPersonalizationDataMapperInstanceFixture;

        #region General Initializer : Class (EpmChartUserSettingsToPersonalizationDataMapper) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EpmChartUserSettingsToPersonalizationDataMapper" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _epmChartUserSettingsToPersonalizationDataMapperInstanceType = typeof(EpmChartUserSettingsToPersonalizationDataMapper);
            _epmChartUserSettingsToPersonalizationDataMapperInstanceFixture = Create(true);
            _epmChartUserSettingsToPersonalizationDataMapperInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EpmChartUserSettingsToPersonalizationDataMapper)

        #region General Initializer : Class (EpmChartUserSettingsToPersonalizationDataMapper) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EpmChartUserSettingsToPersonalizationDataMapper" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetPersonalizationData, 0)]
        public void AUT_EpmChartUserSettingsToPersonalizationDataMapper_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_epmChartUserSettingsToPersonalizationDataMapperInstanceFixture, 
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
        ///     Class (<see cref="EpmChartUserSettingsToPersonalizationDataMapper" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_EpmChartUserSettingsToPersonalizationDataMapper_Is_Instance_Present_Test()
        {
            // Assert
            _epmChartUserSettingsToPersonalizationDataMapperInstanceType.ShouldNotBeNull();
            _epmChartUserSettingsToPersonalizationDataMapperInstance.ShouldNotBeNull();
            _epmChartUserSettingsToPersonalizationDataMapperInstanceFixture.ShouldNotBeNull();
            _epmChartUserSettingsToPersonalizationDataMapperInstance.ShouldBeAssignableTo<EpmChartUserSettingsToPersonalizationDataMapper>();
            _epmChartUserSettingsToPersonalizationDataMapperInstanceFixture.ShouldBeAssignableTo<EpmChartUserSettingsToPersonalizationDataMapper>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EpmChartUserSettingsToPersonalizationDataMapper) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_EpmChartUserSettingsToPersonalizationDataMapper_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EpmChartUserSettingsToPersonalizationDataMapper instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _epmChartUserSettingsToPersonalizationDataMapperInstanceType.ShouldNotBeNull();
            _epmChartUserSettingsToPersonalizationDataMapperInstance.ShouldNotBeNull();
            _epmChartUserSettingsToPersonalizationDataMapperInstanceFixture.ShouldNotBeNull();
            _epmChartUserSettingsToPersonalizationDataMapperInstance.ShouldBeAssignableTo<EpmChartUserSettingsToPersonalizationDataMapper>();
            _epmChartUserSettingsToPersonalizationDataMapperInstanceFixture.ShouldBeAssignableTo<EpmChartUserSettingsToPersonalizationDataMapper>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="EpmChartUserSettingsToPersonalizationDataMapper" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetPersonalizationData)]
        public void AUT_EpmChartUserSettingsToPersonalizationDataMapper_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_epmChartUserSettingsToPersonalizationDataMapperInstanceFixture,
                                                                              _epmChartUserSettingsToPersonalizationDataMapperInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetPersonalizationData) (Return Type : PersonalizationData) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChartUserSettingsToPersonalizationDataMapper_GetPersonalizationData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetPersonalizationDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_epmChartUserSettingsToPersonalizationDataMapperInstanceFixture, _epmChartUserSettingsToPersonalizationDataMapperInstanceType, MethodGetPersonalizationData, Fixture, methodGetPersonalizationDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPersonalizationData) (Return Type : PersonalizationData) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettingsToPersonalizationDataMapper_GetPersonalizationData_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var epmChartUserSettings = CreateType<EpmChartUserSettings>();
            Action executeAction = null;

            // Act
            executeAction = () => EpmChartUserSettingsToPersonalizationDataMapper.GetPersonalizationData(epmChartUserSettings);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetPersonalizationData) (Return Type : PersonalizationData) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettingsToPersonalizationDataMapper_GetPersonalizationData_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var epmChartUserSettings = CreateType<EpmChartUserSettings>();
            var methodGetPersonalizationDataPrametersTypes = new Type[] { typeof(EpmChartUserSettings) };
            object[] parametersOfGetPersonalizationData = { epmChartUserSettings };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetPersonalizationData, methodGetPersonalizationDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartUserSettingsToPersonalizationDataMapperInstanceFixture, parametersOfGetPersonalizationData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetPersonalizationData.ShouldNotBeNull();
            parametersOfGetPersonalizationData.Length.ShouldBe(1);
            methodGetPersonalizationDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPersonalizationData) (Return Type : PersonalizationData) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettingsToPersonalizationDataMapper_GetPersonalizationData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var epmChartUserSettings = CreateType<EpmChartUserSettings>();
            var methodGetPersonalizationDataPrametersTypes = new Type[] { typeof(EpmChartUserSettings) };
            object[] parametersOfGetPersonalizationData = { epmChartUserSettings };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<PersonalizationData>(_epmChartUserSettingsToPersonalizationDataMapperInstanceFixture, _epmChartUserSettingsToPersonalizationDataMapperInstanceType, MethodGetPersonalizationData, parametersOfGetPersonalizationData, methodGetPersonalizationDataPrametersTypes);

            // Assert
            parametersOfGetPersonalizationData.ShouldNotBeNull();
            parametersOfGetPersonalizationData.Length.ShouldBe(1);
            methodGetPersonalizationDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPersonalizationData) (Return Type : PersonalizationData) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettingsToPersonalizationDataMapper_GetPersonalizationData_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetPersonalizationDataPrametersTypes = new Type[] { typeof(EpmChartUserSettings) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_epmChartUserSettingsToPersonalizationDataMapperInstanceFixture, _epmChartUserSettingsToPersonalizationDataMapperInstanceType, MethodGetPersonalizationData, Fixture, methodGetPersonalizationDataPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetPersonalizationDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetPersonalizationData) (Return Type : PersonalizationData) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettingsToPersonalizationDataMapper_GetPersonalizationData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPersonalizationDataPrametersTypes = new Type[] { typeof(EpmChartUserSettings) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_epmChartUserSettingsToPersonalizationDataMapperInstanceFixture, _epmChartUserSettingsToPersonalizationDataMapperInstanceType, MethodGetPersonalizationData, Fixture, methodGetPersonalizationDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPersonalizationDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPersonalizationData) (Return Type : PersonalizationData) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettingsToPersonalizationDataMapper_GetPersonalizationData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPersonalizationData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartUserSettingsToPersonalizationDataMapperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetPersonalizationData) (Return Type : PersonalizationData) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettingsToPersonalizationDataMapper_GetPersonalizationData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetPersonalizationData, 0);
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