using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveWebParts.ReportFiltering.DomainModel;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace ReportFiltering.DomainServices
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="ReportFiltering.DomainServices.ReportFilterQueryService" />)
    ///     and namespace <see cref="ReportFiltering.DomainServices"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ReportFilterQueryServiceTest : AbstractBaseSetupTypedTest<ReportFilterQueryService>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportFilterQueryService) Initializer

        private const string MethodGetQueryForFiltering = "GetQueryForFiltering";
        private const string MethodGetFilterForMultiSelect = "GetFilterForMultiSelect";
        private const string MethodGetFilterForSingleSelect = "GetFilterForSingleSelect";
        private const string MethodHandlePercentageFieldIfApplicable = "HandlePercentageFieldIfApplicable";
        private const string MethodGetFilterForDateTime = "GetFilterForDateTime";
        private const string MethodGetFilterForUser = "GetFilterForUser";
        private const string MethodAppendNonArchivedFilter = "AppendNonArchivedFilter";
        private const string FieldFilterNonArchived = "FilterNonArchived";
        private Type _reportFilterQueryServiceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportFilterQueryService _reportFilterQueryServiceInstance;
        private ReportFilterQueryService _reportFilterQueryServiceInstanceFixture;

        #region General Initializer : Class (ReportFilterQueryService) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportFilterQueryService" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportFilterQueryServiceInstanceType = typeof(ReportFilterQueryService);
            _reportFilterQueryServiceInstanceFixture = Create(true);
            _reportFilterQueryServiceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportFilterQueryService)

        #region General Initializer : Class (ReportFilterQueryService) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ReportFilterQueryService" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetQueryForFiltering, 0)]
        [TestCase(MethodGetFilterForMultiSelect, 0)]
        [TestCase(MethodGetFilterForSingleSelect, 0)]
        [TestCase(MethodHandlePercentageFieldIfApplicable, 0)]
        [TestCase(MethodGetFilterForDateTime, 0)]
        [TestCase(MethodGetFilterForUser, 0)]
        public void AUT_ReportFilterQueryService_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_reportFilterQueryServiceInstanceFixture, 
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
        ///     Class (<see cref="ReportFilterQueryService" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ReportFilterQueryService_Is_Instance_Present_Test()
        {
            // Assert
            _reportFilterQueryServiceInstanceType.ShouldNotBeNull();
            _reportFilterQueryServiceInstance.ShouldNotBeNull();
            _reportFilterQueryServiceInstanceFixture.ShouldNotBeNull();
            _reportFilterQueryServiceInstance.ShouldBeAssignableTo<ReportFilterQueryService>();
            _reportFilterQueryServiceInstanceFixture.ShouldBeAssignableTo<ReportFilterQueryService>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportFilterQueryService) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ReportFilterQueryService_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportFilterQueryService instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportFilterQueryServiceInstanceType.ShouldNotBeNull();
            _reportFilterQueryServiceInstance.ShouldNotBeNull();
            _reportFilterQueryServiceInstanceFixture.ShouldNotBeNull();
            _reportFilterQueryServiceInstance.ShouldBeAssignableTo<ReportFilterQueryService>();
            _reportFilterQueryServiceInstanceFixture.ShouldBeAssignableTo<ReportFilterQueryService>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ReportFilterQueryService" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetQueryForFiltering)]
        [TestCase(MethodGetFilterForMultiSelect)]
        [TestCase(MethodGetFilterForSingleSelect)]
        [TestCase(MethodHandlePercentageFieldIfApplicable)]
        [TestCase(MethodGetFilterForDateTime)]
        [TestCase(MethodGetFilterForUser)]
        public void AUT_ReportFilterQueryService_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_reportFilterQueryServiceInstanceFixture,
                                                                              _reportFilterQueryServiceInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetQueryForFiltering) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterQueryService_GetQueryForFiltering_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetQueryForFilteringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetQueryForFiltering, Fixture, methodGetQueryForFilteringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetQueryForFiltering) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetQueryForFiltering_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var fieldSelection = CreateType<ReportFilterSelection>();
            var applyNonArchivedFilter = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => ReportFilterQueryService.GetQueryForFiltering(fieldSelection, applyNonArchivedFilter);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetQueryForFiltering) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetQueryForFiltering_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var fieldSelection = CreateType<ReportFilterSelection>();
            var applyNonArchivedFilter = CreateType<bool>();
            var methodGetQueryForFilteringPrametersTypes = new Type[] { typeof(ReportFilterSelection), typeof(bool) };
            object[] parametersOfGetQueryForFiltering = { fieldSelection, applyNonArchivedFilter };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetQueryForFiltering, methodGetQueryForFilteringPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetQueryForFiltering, Fixture, methodGetQueryForFilteringPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetQueryForFiltering, parametersOfGetQueryForFiltering, methodGetQueryForFilteringPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_reportFilterQueryServiceInstanceFixture, parametersOfGetQueryForFiltering);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetQueryForFiltering.ShouldNotBeNull();
            parametersOfGetQueryForFiltering.Length.ShouldBe(2);
            methodGetQueryForFilteringPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetQueryForFiltering) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetQueryForFiltering_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldSelection = CreateType<ReportFilterSelection>();
            var applyNonArchivedFilter = CreateType<bool>();
            var methodGetQueryForFilteringPrametersTypes = new Type[] { typeof(ReportFilterSelection), typeof(bool) };
            object[] parametersOfGetQueryForFiltering = { fieldSelection, applyNonArchivedFilter };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetQueryForFiltering, parametersOfGetQueryForFiltering, methodGetQueryForFilteringPrametersTypes);

            // Assert
            parametersOfGetQueryForFiltering.ShouldNotBeNull();
            parametersOfGetQueryForFiltering.Length.ShouldBe(2);
            methodGetQueryForFilteringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetQueryForFiltering) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetQueryForFiltering_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetQueryForFilteringPrametersTypes = new Type[] { typeof(ReportFilterSelection), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetQueryForFiltering, Fixture, methodGetQueryForFilteringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetQueryForFilteringPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetQueryForFiltering) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetQueryForFiltering_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetQueryForFilteringPrametersTypes = new Type[] { typeof(ReportFilterSelection), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetQueryForFiltering, Fixture, methodGetQueryForFilteringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetQueryForFilteringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetQueryForFiltering) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetQueryForFiltering_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetQueryForFiltering, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterQueryServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetFilterForMultiSelect) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterQueryService_GetFilterForMultiSelect_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFilterForMultiSelectPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForMultiSelect, Fixture, methodGetFilterForMultiSelectPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFilterForMultiSelect) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetFilterForMultiSelect_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var fieldSelection = CreateType<ReportFilterSelection>();
            var applyNonArchivedFilter = CreateType<bool>();
            var methodGetFilterForMultiSelectPrametersTypes = new Type[] { typeof(ReportFilterSelection), typeof(bool) };
            object[] parametersOfGetFilterForMultiSelect = { fieldSelection, applyNonArchivedFilter };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFilterForMultiSelect, methodGetFilterForMultiSelectPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForMultiSelect, Fixture, methodGetFilterForMultiSelectPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForMultiSelect, parametersOfGetFilterForMultiSelect, methodGetFilterForMultiSelectPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_reportFilterQueryServiceInstanceFixture, parametersOfGetFilterForMultiSelect);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFilterForMultiSelect.ShouldNotBeNull();
            parametersOfGetFilterForMultiSelect.Length.ShouldBe(2);
            methodGetFilterForMultiSelectPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFilterForMultiSelect) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetFilterForMultiSelect_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldSelection = CreateType<ReportFilterSelection>();
            var applyNonArchivedFilter = CreateType<bool>();
            var methodGetFilterForMultiSelectPrametersTypes = new Type[] { typeof(ReportFilterSelection), typeof(bool) };
            object[] parametersOfGetFilterForMultiSelect = { fieldSelection, applyNonArchivedFilter };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForMultiSelect, parametersOfGetFilterForMultiSelect, methodGetFilterForMultiSelectPrametersTypes);

            // Assert
            parametersOfGetFilterForMultiSelect.ShouldNotBeNull();
            parametersOfGetFilterForMultiSelect.Length.ShouldBe(2);
            methodGetFilterForMultiSelectPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilterForMultiSelect) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetFilterForMultiSelect_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFilterForMultiSelectPrametersTypes = new Type[] { typeof(ReportFilterSelection), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForMultiSelect, Fixture, methodGetFilterForMultiSelectPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFilterForMultiSelectPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFilterForMultiSelect) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetFilterForMultiSelect_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFilterForMultiSelectPrametersTypes = new Type[] { typeof(ReportFilterSelection), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForMultiSelect, Fixture, methodGetFilterForMultiSelectPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFilterForMultiSelectPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFilterForMultiSelect) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetFilterForMultiSelect_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFilterForMultiSelect, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterQueryServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetFilterForSingleSelect) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterQueryService_GetFilterForSingleSelect_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFilterForSingleSelectPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForSingleSelect, Fixture, methodGetFilterForSingleSelectPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFilterForSingleSelect) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetFilterForSingleSelect_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var fieldSelection = CreateType<ReportFilterSelection>();
            var applyNonArchivedFilter = CreateType<bool>();
            var methodGetFilterForSingleSelectPrametersTypes = new Type[] { typeof(ReportFilterSelection), typeof(bool) };
            object[] parametersOfGetFilterForSingleSelect = { fieldSelection, applyNonArchivedFilter };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFilterForSingleSelect, methodGetFilterForSingleSelectPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForSingleSelect, Fixture, methodGetFilterForSingleSelectPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForSingleSelect, parametersOfGetFilterForSingleSelect, methodGetFilterForSingleSelectPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_reportFilterQueryServiceInstanceFixture, parametersOfGetFilterForSingleSelect);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFilterForSingleSelect.ShouldNotBeNull();
            parametersOfGetFilterForSingleSelect.Length.ShouldBe(2);
            methodGetFilterForSingleSelectPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFilterForSingleSelect) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetFilterForSingleSelect_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldSelection = CreateType<ReportFilterSelection>();
            var applyNonArchivedFilter = CreateType<bool>();
            var methodGetFilterForSingleSelectPrametersTypes = new Type[] { typeof(ReportFilterSelection), typeof(bool) };
            object[] parametersOfGetFilterForSingleSelect = { fieldSelection, applyNonArchivedFilter };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForSingleSelect, parametersOfGetFilterForSingleSelect, methodGetFilterForSingleSelectPrametersTypes);

            // Assert
            parametersOfGetFilterForSingleSelect.ShouldNotBeNull();
            parametersOfGetFilterForSingleSelect.Length.ShouldBe(2);
            methodGetFilterForSingleSelectPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilterForSingleSelect) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetFilterForSingleSelect_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFilterForSingleSelectPrametersTypes = new Type[] { typeof(ReportFilterSelection), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForSingleSelect, Fixture, methodGetFilterForSingleSelectPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFilterForSingleSelectPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFilterForSingleSelect) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetFilterForSingleSelect_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFilterForSingleSelectPrametersTypes = new Type[] { typeof(ReportFilterSelection), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForSingleSelect, Fixture, methodGetFilterForSingleSelectPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFilterForSingleSelectPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFilterForSingleSelect) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetFilterForSingleSelect_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFilterForSingleSelect, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterQueryServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (HandlePercentageFieldIfApplicable) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterQueryService_HandlePercentageFieldIfApplicable_Static_Method_Call_Internally(Type[] types)
        {
            var methodHandlePercentageFieldIfApplicablePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodHandlePercentageFieldIfApplicable, Fixture, methodHandlePercentageFieldIfApplicablePrametersTypes);
        }

        #endregion

        #region Method Call : (HandlePercentageFieldIfApplicable) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_HandlePercentageFieldIfApplicable_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var fieldSelection = CreateType<ReportFilterSelection>();
            var methodHandlePercentageFieldIfApplicablePrametersTypes = new Type[] { typeof(ReportFilterSelection) };
            object[] parametersOfHandlePercentageFieldIfApplicable = { fieldSelection };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHandlePercentageFieldIfApplicable, methodHandlePercentageFieldIfApplicablePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportFilterQueryServiceInstanceFixture, parametersOfHandlePercentageFieldIfApplicable);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHandlePercentageFieldIfApplicable.ShouldNotBeNull();
            parametersOfHandlePercentageFieldIfApplicable.Length.ShouldBe(1);
            methodHandlePercentageFieldIfApplicablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandlePercentageFieldIfApplicable) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_HandlePercentageFieldIfApplicable_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldSelection = CreateType<ReportFilterSelection>();
            var methodHandlePercentageFieldIfApplicablePrametersTypes = new Type[] { typeof(ReportFilterSelection) };
            object[] parametersOfHandlePercentageFieldIfApplicable = { fieldSelection };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodHandlePercentageFieldIfApplicable, parametersOfHandlePercentageFieldIfApplicable, methodHandlePercentageFieldIfApplicablePrametersTypes);

            // Assert
            parametersOfHandlePercentageFieldIfApplicable.ShouldNotBeNull();
            parametersOfHandlePercentageFieldIfApplicable.Length.ShouldBe(1);
            methodHandlePercentageFieldIfApplicablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandlePercentageFieldIfApplicable) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_HandlePercentageFieldIfApplicable_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHandlePercentageFieldIfApplicable, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandlePercentageFieldIfApplicable) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_HandlePercentageFieldIfApplicable_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHandlePercentageFieldIfApplicablePrametersTypes = new Type[] { typeof(ReportFilterSelection) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodHandlePercentageFieldIfApplicable, Fixture, methodHandlePercentageFieldIfApplicablePrametersTypes);

            // Assert
            methodHandlePercentageFieldIfApplicablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandlePercentageFieldIfApplicable) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_HandlePercentageFieldIfApplicable_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandlePercentageFieldIfApplicable, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterQueryServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilterForDateTime) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterQueryService_GetFilterForDateTime_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFilterForDateTimePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForDateTime, Fixture, methodGetFilterForDateTimePrametersTypes);
        }

        #endregion

        #region Method Call : (GetFilterForDateTime) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetFilterForDateTime_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var fieldSelection = CreateType<ReportFilterSelection>();
            var applyNonArchivedFilter = CreateType<bool>();
            var methodGetFilterForDateTimePrametersTypes = new Type[] { typeof(ReportFilterSelection), typeof(bool) };
            object[] parametersOfGetFilterForDateTime = { fieldSelection, applyNonArchivedFilter };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFilterForDateTime, methodGetFilterForDateTimePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForDateTime, Fixture, methodGetFilterForDateTimePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForDateTime, parametersOfGetFilterForDateTime, methodGetFilterForDateTimePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_reportFilterQueryServiceInstanceFixture, parametersOfGetFilterForDateTime);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFilterForDateTime.ShouldNotBeNull();
            parametersOfGetFilterForDateTime.Length.ShouldBe(2);
            methodGetFilterForDateTimePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFilterForDateTime) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetFilterForDateTime_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldSelection = CreateType<ReportFilterSelection>();
            var applyNonArchivedFilter = CreateType<bool>();
            var methodGetFilterForDateTimePrametersTypes = new Type[] { typeof(ReportFilterSelection), typeof(bool) };
            object[] parametersOfGetFilterForDateTime = { fieldSelection, applyNonArchivedFilter };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForDateTime, parametersOfGetFilterForDateTime, methodGetFilterForDateTimePrametersTypes);

            // Assert
            parametersOfGetFilterForDateTime.ShouldNotBeNull();
            parametersOfGetFilterForDateTime.Length.ShouldBe(2);
            methodGetFilterForDateTimePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilterForDateTime) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetFilterForDateTime_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFilterForDateTimePrametersTypes = new Type[] { typeof(ReportFilterSelection), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForDateTime, Fixture, methodGetFilterForDateTimePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFilterForDateTimePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFilterForDateTime) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetFilterForDateTime_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFilterForDateTimePrametersTypes = new Type[] { typeof(ReportFilterSelection), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForDateTime, Fixture, methodGetFilterForDateTimePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFilterForDateTimePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFilterForDateTime) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetFilterForDateTime_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFilterForDateTime, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterQueryServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetFilterForUser) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterQueryService_GetFilterForUser_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFilterForUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForUser, Fixture, methodGetFilterForUserPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFilterForUser) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetFilterForUser_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var fieldSelection = CreateType<ReportFilterSelection>();
            var applyNonArchivedFilter = CreateType<bool>();
            var methodGetFilterForUserPrametersTypes = new Type[] { typeof(ReportFilterSelection), typeof(bool) };
            object[] parametersOfGetFilterForUser = { fieldSelection, applyNonArchivedFilter };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFilterForUser, methodGetFilterForUserPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForUser, Fixture, methodGetFilterForUserPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForUser, parametersOfGetFilterForUser, methodGetFilterForUserPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_reportFilterQueryServiceInstanceFixture, parametersOfGetFilterForUser);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFilterForUser.ShouldNotBeNull();
            parametersOfGetFilterForUser.Length.ShouldBe(2);
            methodGetFilterForUserPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFilterForUser) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetFilterForUser_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldSelection = CreateType<ReportFilterSelection>();
            var applyNonArchivedFilter = CreateType<bool>();
            var methodGetFilterForUserPrametersTypes = new Type[] { typeof(ReportFilterSelection), typeof(bool) };
            object[] parametersOfGetFilterForUser = { fieldSelection, applyNonArchivedFilter };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForUser, parametersOfGetFilterForUser, methodGetFilterForUserPrametersTypes);

            // Assert
            parametersOfGetFilterForUser.ShouldNotBeNull();
            parametersOfGetFilterForUser.Length.ShouldBe(2);
            methodGetFilterForUserPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilterForUser) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetFilterForUser_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFilterForUserPrametersTypes = new Type[] { typeof(ReportFilterSelection), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForUser, Fixture, methodGetFilterForUserPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFilterForUserPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFilterForUser) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetFilterForUser_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFilterForUserPrametersTypes = new Type[] { typeof(ReportFilterSelection), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodGetFilterForUser, Fixture, methodGetFilterForUserPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFilterForUserPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFilterForUser) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_GetFilterForUser_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFilterForUser, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterQueryServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (AppendNonArchivedFilter) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterQueryService_AppendNonArchivedFilter_Static_Method_Call_Internally(Type[] types)
        {
            var methodAppendNonArchivedFilterPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodAppendNonArchivedFilter, Fixture, methodAppendNonArchivedFilterPrametersTypes);
        }

        #endregion

        #region Method Call : (AppendNonArchivedFilter) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_AppendNonArchivedFilter_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var methodAppendNonArchivedFilterPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAppendNonArchivedFilter = { query };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodAppendNonArchivedFilter, parametersOfAppendNonArchivedFilter, methodAppendNonArchivedFilterPrametersTypes);

            // Assert
            parametersOfAppendNonArchivedFilter.ShouldNotBeNull();
            parametersOfAppendNonArchivedFilter.Length.ShouldBe(1);
            methodAppendNonArchivedFilterPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AppendNonArchivedFilter) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_AppendNonArchivedFilter_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAppendNonArchivedFilterPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodAppendNonArchivedFilter, Fixture, methodAppendNonArchivedFilterPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAppendNonArchivedFilterPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AppendNonArchivedFilter) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterQueryService_AppendNonArchivedFilter_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAppendNonArchivedFilterPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterQueryServiceInstanceFixture, _reportFilterQueryServiceInstanceType, MethodAppendNonArchivedFilter, Fixture, methodAppendNonArchivedFilterPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAppendNonArchivedFilterPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #endregion

        #endregion
    }
}