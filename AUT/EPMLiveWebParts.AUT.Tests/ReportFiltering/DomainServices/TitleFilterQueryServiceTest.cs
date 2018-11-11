using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml;
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

namespace ReportFiltering.DomainServices
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="ReportFiltering.DomainServices.TitleFilterQueryService" />)
    ///     and namespace <see cref="ReportFiltering.DomainServices"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class TitleFilterQueryServiceTest : AbstractBaseSetupTypedTest<TitleFilterQueryService>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (TitleFilterQueryService) Initializer

        private const string MethodMergeExistingQueryWithTitleQuery = "MergeExistingQueryWithTitleQuery";
        private const string MethodGetQueryForFilteringTitles = "GetQueryForFilteringTitles";
        private const string MethodGetTitleFilterQueryForLookup = "GetTitleFilterQueryForLookup";
        private const string FieldMaxLookupfilter = "MaxLookupfilter";
        private Type _titleFilterQueryServiceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private TitleFilterQueryService _titleFilterQueryServiceInstance;
        private TitleFilterQueryService _titleFilterQueryServiceInstanceFixture;

        #region General Initializer : Class (TitleFilterQueryService) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="TitleFilterQueryService" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _titleFilterQueryServiceInstanceType = typeof(TitleFilterQueryService);
            _titleFilterQueryServiceInstanceFixture = Create(true);
            _titleFilterQueryServiceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (TitleFilterQueryService)

        #region General Initializer : Class (TitleFilterQueryService) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="TitleFilterQueryService" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodMergeExistingQueryWithTitleQuery, 0)]
        [TestCase(MethodGetQueryForFilteringTitles, 0)]
        [TestCase(MethodGetTitleFilterQueryForLookup, 0)]
        public void AUT_TitleFilterQueryService_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_titleFilterQueryServiceInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (TitleFilterQueryService) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="TitleFilterQueryService" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldMaxLookupfilter)]
        public void AUT_TitleFilterQueryService_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_titleFilterQueryServiceInstanceFixture, 
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
        ///     Class (<see cref="TitleFilterQueryService" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_TitleFilterQueryService_Is_Instance_Present_Test()
        {
            // Assert
            _titleFilterQueryServiceInstanceType.ShouldNotBeNull();
            _titleFilterQueryServiceInstance.ShouldNotBeNull();
            _titleFilterQueryServiceInstanceFixture.ShouldNotBeNull();
            _titleFilterQueryServiceInstance.ShouldBeAssignableTo<TitleFilterQueryService>();
            _titleFilterQueryServiceInstanceFixture.ShouldBeAssignableTo<TitleFilterQueryService>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (TitleFilterQueryService) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_TitleFilterQueryService_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            TitleFilterQueryService instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _titleFilterQueryServiceInstanceType.ShouldNotBeNull();
            _titleFilterQueryServiceInstance.ShouldNotBeNull();
            _titleFilterQueryServiceInstanceFixture.ShouldNotBeNull();
            _titleFilterQueryServiceInstance.ShouldBeAssignableTo<TitleFilterQueryService>();
            _titleFilterQueryServiceInstanceFixture.ShouldBeAssignableTo<TitleFilterQueryService>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="TitleFilterQueryService" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetTitleFilterQueryForLookup)]
        public void AUT_TitleFilterQueryService_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_titleFilterQueryServiceInstanceFixture,
                                                                              _titleFilterQueryServiceInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="TitleFilterQueryService" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodMergeExistingQueryWithTitleQuery)]
        [TestCase(MethodGetQueryForFilteringTitles)]
        public void AUT_TitleFilterQueryService_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<TitleFilterQueryService>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (MergeExistingQueryWithTitleQuery) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TitleFilterQueryService_MergeExistingQueryWithTitleQuery_Method_Call_Internally(Type[] types)
        {
            var methodMergeExistingQueryWithTitleQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_titleFilterQueryServiceInstance, MethodMergeExistingQueryWithTitleQuery, Fixture, methodMergeExistingQueryWithTitleQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (MergeExistingQueryWithTitleQuery) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TitleFilterQueryService_MergeExistingQueryWithTitleQuery_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var reportWebPartId = CreateType<Guid>();
            var xmlDocContainingQueryXml = CreateType<XmlDocument>();
            Action executeAction = null;

            // Act
            executeAction = () => _titleFilterQueryServiceInstance.MergeExistingQueryWithTitleQuery(list, reportWebPartId, ref xmlDocContainingQueryXml);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (MergeExistingQueryWithTitleQuery) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TitleFilterQueryService_MergeExistingQueryWithTitleQuery_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var reportWebPartId = CreateType<Guid>();
            var xmlDocContainingQueryXml = CreateType<XmlDocument>();
            var methodMergeExistingQueryWithTitleQueryPrametersTypes = new Type[] { typeof(SPList), typeof(Guid), typeof(XmlDocument) };
            object[] parametersOfMergeExistingQueryWithTitleQuery = { list, reportWebPartId, xmlDocContainingQueryXml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodMergeExistingQueryWithTitleQuery, methodMergeExistingQueryWithTitleQueryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_titleFilterQueryServiceInstanceFixture, parametersOfMergeExistingQueryWithTitleQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfMergeExistingQueryWithTitleQuery.ShouldNotBeNull();
            parametersOfMergeExistingQueryWithTitleQuery.Length.ShouldBe(3);
            methodMergeExistingQueryWithTitleQueryPrametersTypes.Length.ShouldBe(3);
            methodMergeExistingQueryWithTitleQueryPrametersTypes.Length.ShouldBe(parametersOfMergeExistingQueryWithTitleQuery.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (MergeExistingQueryWithTitleQuery) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TitleFilterQueryService_MergeExistingQueryWithTitleQuery_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var reportWebPartId = CreateType<Guid>();
            var xmlDocContainingQueryXml = CreateType<XmlDocument>();
            var methodMergeExistingQueryWithTitleQueryPrametersTypes = new Type[] { typeof(SPList), typeof(Guid), typeof(XmlDocument) };
            object[] parametersOfMergeExistingQueryWithTitleQuery = { list, reportWebPartId, xmlDocContainingQueryXml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_titleFilterQueryServiceInstance, MethodMergeExistingQueryWithTitleQuery, parametersOfMergeExistingQueryWithTitleQuery, methodMergeExistingQueryWithTitleQueryPrametersTypes);

            // Assert
            parametersOfMergeExistingQueryWithTitleQuery.ShouldNotBeNull();
            parametersOfMergeExistingQueryWithTitleQuery.Length.ShouldBe(3);
            methodMergeExistingQueryWithTitleQueryPrametersTypes.Length.ShouldBe(3);
            methodMergeExistingQueryWithTitleQueryPrametersTypes.Length.ShouldBe(parametersOfMergeExistingQueryWithTitleQuery.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MergeExistingQueryWithTitleQuery) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TitleFilterQueryService_MergeExistingQueryWithTitleQuery_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMergeExistingQueryWithTitleQuery, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MergeExistingQueryWithTitleQuery) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TitleFilterQueryService_MergeExistingQueryWithTitleQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMergeExistingQueryWithTitleQueryPrametersTypes = new Type[] { typeof(SPList), typeof(Guid), typeof(XmlDocument) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_titleFilterQueryServiceInstance, MethodMergeExistingQueryWithTitleQuery, Fixture, methodMergeExistingQueryWithTitleQueryPrametersTypes);

            // Assert
            methodMergeExistingQueryWithTitleQueryPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MergeExistingQueryWithTitleQuery) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TitleFilterQueryService_MergeExistingQueryWithTitleQuery_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMergeExistingQueryWithTitleQuery, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_titleFilterQueryServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetQueryForFilteringTitles) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TitleFilterQueryService_GetQueryForFilteringTitles_Method_Call_Internally(Type[] types)
        {
            var methodGetQueryForFilteringTitlesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_titleFilterQueryServiceInstance, MethodGetQueryForFilteringTitles, Fixture, methodGetQueryForFilteringTitlesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetQueryForFilteringTitles) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TitleFilterQueryService_GetQueryForFilteringTitles_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var reportWebPartGuid = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _titleFilterQueryServiceInstance.GetQueryForFilteringTitles(list, reportWebPartGuid);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetQueryForFilteringTitles) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TitleFilterQueryService_GetQueryForFilteringTitles_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var reportWebPartGuid = CreateType<Guid>();
            var methodGetQueryForFilteringTitlesPrametersTypes = new Type[] { typeof(SPList), typeof(Guid) };
            object[] parametersOfGetQueryForFilteringTitles = { list, reportWebPartGuid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetQueryForFilteringTitles, methodGetQueryForFilteringTitlesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<TitleFilterQueryService, string>(_titleFilterQueryServiceInstanceFixture, out exception1, parametersOfGetQueryForFilteringTitles);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<TitleFilterQueryService, string>(_titleFilterQueryServiceInstance, MethodGetQueryForFilteringTitles, parametersOfGetQueryForFilteringTitles, methodGetQueryForFilteringTitlesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetQueryForFilteringTitles.ShouldNotBeNull();
            parametersOfGetQueryForFilteringTitles.Length.ShouldBe(2);
            methodGetQueryForFilteringTitlesPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetQueryForFilteringTitles) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TitleFilterQueryService_GetQueryForFilteringTitles_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var reportWebPartGuid = CreateType<Guid>();
            var methodGetQueryForFilteringTitlesPrametersTypes = new Type[] { typeof(SPList), typeof(Guid) };
            object[] parametersOfGetQueryForFilteringTitles = { list, reportWebPartGuid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<TitleFilterQueryService, string>(_titleFilterQueryServiceInstance, MethodGetQueryForFilteringTitles, parametersOfGetQueryForFilteringTitles, methodGetQueryForFilteringTitlesPrametersTypes);

            // Assert
            parametersOfGetQueryForFilteringTitles.ShouldNotBeNull();
            parametersOfGetQueryForFilteringTitles.Length.ShouldBe(2);
            methodGetQueryForFilteringTitlesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetQueryForFilteringTitles) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TitleFilterQueryService_GetQueryForFilteringTitles_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetQueryForFilteringTitlesPrametersTypes = new Type[] { typeof(SPList), typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_titleFilterQueryServiceInstance, MethodGetQueryForFilteringTitles, Fixture, methodGetQueryForFilteringTitlesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetQueryForFilteringTitlesPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetQueryForFilteringTitles) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TitleFilterQueryService_GetQueryForFilteringTitles_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetQueryForFilteringTitlesPrametersTypes = new Type[] { typeof(SPList), typeof(Guid) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_titleFilterQueryServiceInstance, MethodGetQueryForFilteringTitles, Fixture, methodGetQueryForFilteringTitlesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetQueryForFilteringTitlesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetQueryForFilteringTitles) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TitleFilterQueryService_GetQueryForFilteringTitles_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetQueryForFilteringTitles, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_titleFilterQueryServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetQueryForFilteringTitles) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TitleFilterQueryService_GetQueryForFilteringTitles_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetQueryForFilteringTitles, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTitleFilterQueryForLookup) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TitleFilterQueryService_GetTitleFilterQueryForLookup_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTitleFilterQueryForLookupPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_titleFilterQueryServiceInstanceFixture, _titleFilterQueryServiceInstanceType, MethodGetTitleFilterQueryForLookup, Fixture, methodGetTitleFilterQueryForLookupPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTitleFilterQueryForLookup) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TitleFilterQueryService_GetTitleFilterQueryForLookup_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var userSettings = CreateType<ReportFilterUserSettings>();
            var filterValues = CreateType<StringBuilder>();
            var methodGetTitleFilterQueryForLookupPrametersTypes = new Type[] { typeof(SPList), typeof(ReportFilterUserSettings), typeof(StringBuilder) };
            object[] parametersOfGetTitleFilterQueryForLookup = { list, userSettings, filterValues };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTitleFilterQueryForLookup, methodGetTitleFilterQueryForLookupPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_titleFilterQueryServiceInstanceFixture, _titleFilterQueryServiceInstanceType, MethodGetTitleFilterQueryForLookup, Fixture, methodGetTitleFilterQueryForLookupPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_titleFilterQueryServiceInstanceFixture, _titleFilterQueryServiceInstanceType, MethodGetTitleFilterQueryForLookup, parametersOfGetTitleFilterQueryForLookup, methodGetTitleFilterQueryForLookupPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_titleFilterQueryServiceInstanceFixture, parametersOfGetTitleFilterQueryForLookup);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTitleFilterQueryForLookup.ShouldNotBeNull();
            parametersOfGetTitleFilterQueryForLookup.Length.ShouldBe(3);
            methodGetTitleFilterQueryForLookupPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetTitleFilterQueryForLookup) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TitleFilterQueryService_GetTitleFilterQueryForLookup_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var userSettings = CreateType<ReportFilterUserSettings>();
            var filterValues = CreateType<StringBuilder>();
            var methodGetTitleFilterQueryForLookupPrametersTypes = new Type[] { typeof(SPList), typeof(ReportFilterUserSettings), typeof(StringBuilder) };
            object[] parametersOfGetTitleFilterQueryForLookup = { list, userSettings, filterValues };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_titleFilterQueryServiceInstanceFixture, _titleFilterQueryServiceInstanceType, MethodGetTitleFilterQueryForLookup, parametersOfGetTitleFilterQueryForLookup, methodGetTitleFilterQueryForLookupPrametersTypes);

            // Assert
            parametersOfGetTitleFilterQueryForLookup.ShouldNotBeNull();
            parametersOfGetTitleFilterQueryForLookup.Length.ShouldBe(3);
            methodGetTitleFilterQueryForLookupPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTitleFilterQueryForLookup) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TitleFilterQueryService_GetTitleFilterQueryForLookup_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTitleFilterQueryForLookupPrametersTypes = new Type[] { typeof(SPList), typeof(ReportFilterUserSettings), typeof(StringBuilder) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_titleFilterQueryServiceInstanceFixture, _titleFilterQueryServiceInstanceType, MethodGetTitleFilterQueryForLookup, Fixture, methodGetTitleFilterQueryForLookupPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTitleFilterQueryForLookupPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetTitleFilterQueryForLookup) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TitleFilterQueryService_GetTitleFilterQueryForLookup_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTitleFilterQueryForLookupPrametersTypes = new Type[] { typeof(SPList), typeof(ReportFilterUserSettings), typeof(StringBuilder) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_titleFilterQueryServiceInstanceFixture, _titleFilterQueryServiceInstanceType, MethodGetTitleFilterQueryForLookup, Fixture, methodGetTitleFilterQueryForLookupPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTitleFilterQueryForLookupPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTitleFilterQueryForLookup) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TitleFilterQueryService_GetTitleFilterQueryForLookup_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTitleFilterQueryForLookup, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_titleFilterQueryServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTitleFilterQueryForLookup) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TitleFilterQueryService_GetTitleFilterQueryForLookup_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTitleFilterQueryForLookup, 0);
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