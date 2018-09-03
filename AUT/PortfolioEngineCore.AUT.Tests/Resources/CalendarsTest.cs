using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace PortfolioEngineCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.Calendars" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CalendarsTest : AbstractBaseSetupTypedTest<Calendars>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Calendars) Initializer

        private const string MethodDeleteCalendar = "DeleteCalendar";
        private const string MethodAddCalendar = "AddCalendar";
        private const string MethodSaveCalendarPeriods = "SaveCalendarPeriods";
        private const string MethodSaveCalendarRatesFTES = "SaveCalendarRatesFTES";
        private const string MethodReadCalendarListXML = "ReadCalendarListXML";
        private const string MethodReadCalendarDataXML = "ReadCalendarDataXML";
        private const string Field_sqlConnection = "_sqlConnection";
        private Type _calendarsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Calendars _calendarsInstance;
        private Calendars _calendarsInstanceFixture;

        #region General Initializer : Class (Calendars) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Calendars" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _calendarsInstanceType = typeof(Calendars);
            _calendarsInstanceFixture = Create(true);
            _calendarsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Calendars)

        #region General Initializer : Class (Calendars) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Calendars" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodDeleteCalendar, 0)]
        [TestCase(MethodAddCalendar, 0)]
        [TestCase(MethodSaveCalendarPeriods, 0)]
        [TestCase(MethodSaveCalendarRatesFTES, 0)]
        [TestCase(MethodReadCalendarListXML, 0)]
        [TestCase(MethodReadCalendarDataXML, 0)]
        public void AUT_Calendars_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_calendarsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Calendars) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Calendars" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_sqlConnection)]
        public void AUT_Calendars_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_calendarsInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Calendars) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="Calendars" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_Calendars_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<Calendars>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (Calendars) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="Calendars" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Calendars_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<Calendars>(Fixture);
        }

        #endregion

        #region General Constructor : Class (Calendars) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="Calendars" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Calendars_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var username = CreateType<string>();
            var pid = CreateType<string>();
            var company = CreateType<string>();
            var dbcnstring = CreateType<string>();
            var secLevel = CreateType<SecurityLevels>();
            var bDebug = CreateType<bool>();
            object[] parametersOfCalendars = { basepath, username, pid, company, dbcnstring, secLevel, bDebug };
            var methodCalendarsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_calendarsInstanceType, methodCalendarsPrametersTypes, parametersOfCalendars);
        }

        #endregion

        #region General Constructor : Class (Calendars) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="Calendars" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Calendars_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodCalendarsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_calendarsInstanceType, Fixture, methodCalendarsPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (Calendars) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="Calendars" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Calendars_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var sBaseInfo = CreateType<string>();
            object[] parametersOfCalendars = { sBaseInfo };
            var methodCalendarsPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_calendarsInstanceType, methodCalendarsPrametersTypes, parametersOfCalendars);
        }

        #endregion

        #region General Constructor : Class (Calendars) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="Calendars" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Calendars_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodCalendarsPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_calendarsInstanceType, Fixture, methodCalendarsPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Calendars" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodDeleteCalendar)]
        [TestCase(MethodAddCalendar)]
        [TestCase(MethodSaveCalendarPeriods)]
        [TestCase(MethodSaveCalendarRatesFTES)]
        [TestCase(MethodReadCalendarListXML)]
        [TestCase(MethodReadCalendarDataXML)]
        public void AUT_Calendars_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Calendars>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (DeleteCalendar) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Calendars_DeleteCalendar_Method_Call_Internally(Type[] types)
        {
            var methodDeleteCalendarPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_calendarsInstance, MethodDeleteCalendar, Fixture, methodDeleteCalendarPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteCalendar) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_DeleteCalendar_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var iCalendarID = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _calendarsInstance.DeleteCalendar(iCalendarID);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteCalendar) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_DeleteCalendar_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var iCalendarID = CreateType<int>();
            var methodDeleteCalendarPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeleteCalendar = { iCalendarID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteCalendar, methodDeleteCalendarPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Calendars, bool>(_calendarsInstanceFixture, out exception1, parametersOfDeleteCalendar);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Calendars, bool>(_calendarsInstance, MethodDeleteCalendar, parametersOfDeleteCalendar, methodDeleteCalendarPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteCalendar.ShouldNotBeNull();
            parametersOfDeleteCalendar.Length.ShouldBe(1);
            methodDeleteCalendarPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteCalendar) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_DeleteCalendar_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var iCalendarID = CreateType<int>();
            var methodDeleteCalendarPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeleteCalendar = { iCalendarID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteCalendar, methodDeleteCalendarPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Calendars, bool>(_calendarsInstanceFixture, out exception1, parametersOfDeleteCalendar);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Calendars, bool>(_calendarsInstance, MethodDeleteCalendar, parametersOfDeleteCalendar, methodDeleteCalendarPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteCalendar.ShouldNotBeNull();
            parametersOfDeleteCalendar.Length.ShouldBe(1);
            methodDeleteCalendarPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteCalendar) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_DeleteCalendar_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var iCalendarID = CreateType<int>();
            var methodDeleteCalendarPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeleteCalendar = { iCalendarID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Calendars, bool>(_calendarsInstance, MethodDeleteCalendar, parametersOfDeleteCalendar, methodDeleteCalendarPrametersTypes);

            // Assert
            parametersOfDeleteCalendar.ShouldNotBeNull();
            parametersOfDeleteCalendar.Length.ShouldBe(1);
            methodDeleteCalendarPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteCalendar) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_DeleteCalendar_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteCalendarPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_calendarsInstance, MethodDeleteCalendar, Fixture, methodDeleteCalendarPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteCalendarPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteCalendar) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_DeleteCalendar_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteCalendar, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_calendarsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteCalendar) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_DeleteCalendar_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteCalendar, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddCalendar) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Calendars_AddCalendar_Method_Call_Internally(Type[] types)
        {
            var methodAddCalendarPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_calendarsInstance, MethodAddCalendar, Fixture, methodAddCalendarPrametersTypes);
        }

        #endregion

        #region Method Call : (AddCalendar) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_AddCalendar_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sCalendarName = CreateType<string>();
            var sCalendarDesc = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _calendarsInstance.AddCalendar(sCalendarName, sCalendarDesc);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddCalendar) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_AddCalendar_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sCalendarName = CreateType<string>();
            var sCalendarDesc = CreateType<string>();
            var methodAddCalendarPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfAddCalendar = { sCalendarName, sCalendarDesc };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddCalendar, methodAddCalendarPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Calendars, int>(_calendarsInstanceFixture, out exception1, parametersOfAddCalendar);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Calendars, int>(_calendarsInstance, MethodAddCalendar, parametersOfAddCalendar, methodAddCalendarPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAddCalendar.ShouldNotBeNull();
            parametersOfAddCalendar.Length.ShouldBe(2);
            methodAddCalendarPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (AddCalendar) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_AddCalendar_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sCalendarName = CreateType<string>();
            var sCalendarDesc = CreateType<string>();
            var methodAddCalendarPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfAddCalendar = { sCalendarName, sCalendarDesc };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddCalendar, methodAddCalendarPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Calendars, int>(_calendarsInstanceFixture, out exception1, parametersOfAddCalendar);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Calendars, int>(_calendarsInstance, MethodAddCalendar, parametersOfAddCalendar, methodAddCalendarPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAddCalendar.ShouldNotBeNull();
            parametersOfAddCalendar.Length.ShouldBe(2);
            methodAddCalendarPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (AddCalendar) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_AddCalendar_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sCalendarName = CreateType<string>();
            var sCalendarDesc = CreateType<string>();
            var methodAddCalendarPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfAddCalendar = { sCalendarName, sCalendarDesc };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Calendars, int>(_calendarsInstance, MethodAddCalendar, parametersOfAddCalendar, methodAddCalendarPrametersTypes);

            // Assert
            parametersOfAddCalendar.ShouldNotBeNull();
            parametersOfAddCalendar.Length.ShouldBe(2);
            methodAddCalendarPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddCalendar) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_AddCalendar_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddCalendarPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_calendarsInstance, MethodAddCalendar, Fixture, methodAddCalendarPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddCalendarPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddCalendar) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_AddCalendar_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddCalendar, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_calendarsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddCalendar) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_AddCalendar_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddCalendar, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCalendarPeriods) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Calendars_SaveCalendarPeriods_Method_Call_Internally(Type[] types)
        {
            var methodSaveCalendarPeriodsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_calendarsInstance, MethodSaveCalendarPeriods, Fixture, methodSaveCalendarPeriodsPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveCalendarPeriods) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_SaveCalendarPeriods_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var iCalendarID = CreateType<int>();
            var sCalendarDataXML = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _calendarsInstance.SaveCalendarPeriods(iCalendarID, sCalendarDataXML);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveCalendarPeriods) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_SaveCalendarPeriods_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var iCalendarID = CreateType<int>();
            var sCalendarDataXML = CreateType<string>();
            var methodSaveCalendarPeriodsPrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfSaveCalendarPeriods = { iCalendarID, sCalendarDataXML };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveCalendarPeriods, methodSaveCalendarPeriodsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Calendars, bool>(_calendarsInstanceFixture, out exception1, parametersOfSaveCalendarPeriods);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Calendars, bool>(_calendarsInstance, MethodSaveCalendarPeriods, parametersOfSaveCalendarPeriods, methodSaveCalendarPeriodsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveCalendarPeriods.ShouldNotBeNull();
            parametersOfSaveCalendarPeriods.Length.ShouldBe(2);
            methodSaveCalendarPeriodsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SaveCalendarPeriods) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_SaveCalendarPeriods_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var iCalendarID = CreateType<int>();
            var sCalendarDataXML = CreateType<string>();
            var methodSaveCalendarPeriodsPrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfSaveCalendarPeriods = { iCalendarID, sCalendarDataXML };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveCalendarPeriods, methodSaveCalendarPeriodsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Calendars, bool>(_calendarsInstanceFixture, out exception1, parametersOfSaveCalendarPeriods);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Calendars, bool>(_calendarsInstance, MethodSaveCalendarPeriods, parametersOfSaveCalendarPeriods, methodSaveCalendarPeriodsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveCalendarPeriods.ShouldNotBeNull();
            parametersOfSaveCalendarPeriods.Length.ShouldBe(2);
            methodSaveCalendarPeriodsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SaveCalendarPeriods) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_SaveCalendarPeriods_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var iCalendarID = CreateType<int>();
            var sCalendarDataXML = CreateType<string>();
            var methodSaveCalendarPeriodsPrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfSaveCalendarPeriods = { iCalendarID, sCalendarDataXML };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Calendars, bool>(_calendarsInstance, MethodSaveCalendarPeriods, parametersOfSaveCalendarPeriods, methodSaveCalendarPeriodsPrametersTypes);

            // Assert
            parametersOfSaveCalendarPeriods.ShouldNotBeNull();
            parametersOfSaveCalendarPeriods.Length.ShouldBe(2);
            methodSaveCalendarPeriodsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveCalendarPeriods) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_SaveCalendarPeriods_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveCalendarPeriodsPrametersTypes = new Type[] { typeof(int), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_calendarsInstance, MethodSaveCalendarPeriods, Fixture, methodSaveCalendarPeriodsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveCalendarPeriodsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCalendarPeriods) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_SaveCalendarPeriods_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveCalendarPeriods, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_calendarsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveCalendarPeriods) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_SaveCalendarPeriods_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveCalendarPeriods, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCalendarRatesFTES) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Calendars_SaveCalendarRatesFTES_Method_Call_Internally(Type[] types)
        {
            var methodSaveCalendarRatesFTESPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_calendarsInstance, MethodSaveCalendarRatesFTES, Fixture, methodSaveCalendarRatesFTESPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveCalendarRatesFTES) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_SaveCalendarRatesFTES_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var iCalendarID = CreateType<int>();
            var sCalendarDataXML = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _calendarsInstance.SaveCalendarRatesFTES(iCalendarID, sCalendarDataXML);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveCalendarRatesFTES) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_SaveCalendarRatesFTES_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var iCalendarID = CreateType<int>();
            var sCalendarDataXML = CreateType<string>();
            var methodSaveCalendarRatesFTESPrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfSaveCalendarRatesFTES = { iCalendarID, sCalendarDataXML };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveCalendarRatesFTES, methodSaveCalendarRatesFTESPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Calendars, bool>(_calendarsInstanceFixture, out exception1, parametersOfSaveCalendarRatesFTES);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Calendars, bool>(_calendarsInstance, MethodSaveCalendarRatesFTES, parametersOfSaveCalendarRatesFTES, methodSaveCalendarRatesFTESPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveCalendarRatesFTES.ShouldNotBeNull();
            parametersOfSaveCalendarRatesFTES.Length.ShouldBe(2);
            methodSaveCalendarRatesFTESPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SaveCalendarRatesFTES) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_SaveCalendarRatesFTES_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var iCalendarID = CreateType<int>();
            var sCalendarDataXML = CreateType<string>();
            var methodSaveCalendarRatesFTESPrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfSaveCalendarRatesFTES = { iCalendarID, sCalendarDataXML };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveCalendarRatesFTES, methodSaveCalendarRatesFTESPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Calendars, bool>(_calendarsInstanceFixture, out exception1, parametersOfSaveCalendarRatesFTES);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Calendars, bool>(_calendarsInstance, MethodSaveCalendarRatesFTES, parametersOfSaveCalendarRatesFTES, methodSaveCalendarRatesFTESPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveCalendarRatesFTES.ShouldNotBeNull();
            parametersOfSaveCalendarRatesFTES.Length.ShouldBe(2);
            methodSaveCalendarRatesFTESPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SaveCalendarRatesFTES) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_SaveCalendarRatesFTES_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var iCalendarID = CreateType<int>();
            var sCalendarDataXML = CreateType<string>();
            var methodSaveCalendarRatesFTESPrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfSaveCalendarRatesFTES = { iCalendarID, sCalendarDataXML };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Calendars, bool>(_calendarsInstance, MethodSaveCalendarRatesFTES, parametersOfSaveCalendarRatesFTES, methodSaveCalendarRatesFTESPrametersTypes);

            // Assert
            parametersOfSaveCalendarRatesFTES.ShouldNotBeNull();
            parametersOfSaveCalendarRatesFTES.Length.ShouldBe(2);
            methodSaveCalendarRatesFTESPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveCalendarRatesFTES) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_SaveCalendarRatesFTES_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveCalendarRatesFTESPrametersTypes = new Type[] { typeof(int), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_calendarsInstance, MethodSaveCalendarRatesFTES, Fixture, methodSaveCalendarRatesFTESPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveCalendarRatesFTESPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCalendarRatesFTES) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_SaveCalendarRatesFTES_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveCalendarRatesFTES, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_calendarsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveCalendarRatesFTES) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_SaveCalendarRatesFTES_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveCalendarRatesFTES, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadCalendarListXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Calendars_ReadCalendarListXML_Method_Call_Internally(Type[] types)
        {
            var methodReadCalendarListXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_calendarsInstance, MethodReadCalendarListXML, Fixture, methodReadCalendarListXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadCalendarListXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_ReadCalendarListXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _calendarsInstance.ReadCalendarListXML(out sReply);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ReadCalendarListXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_ReadCalendarListXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodReadCalendarListXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfReadCalendarListXML = { sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodReadCalendarListXML, methodReadCalendarListXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Calendars, bool>(_calendarsInstanceFixture, out exception1, parametersOfReadCalendarListXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Calendars, bool>(_calendarsInstance, MethodReadCalendarListXML, parametersOfReadCalendarListXML, methodReadCalendarListXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfReadCalendarListXML.ShouldNotBeNull();
            parametersOfReadCalendarListXML.Length.ShouldBe(1);
            methodReadCalendarListXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ReadCalendarListXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_ReadCalendarListXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodReadCalendarListXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfReadCalendarListXML = { sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodReadCalendarListXML, methodReadCalendarListXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Calendars, bool>(_calendarsInstanceFixture, out exception1, parametersOfReadCalendarListXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Calendars, bool>(_calendarsInstance, MethodReadCalendarListXML, parametersOfReadCalendarListXML, methodReadCalendarListXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfReadCalendarListXML.ShouldNotBeNull();
            parametersOfReadCalendarListXML.Length.ShouldBe(1);
            methodReadCalendarListXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ReadCalendarListXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_ReadCalendarListXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodReadCalendarListXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfReadCalendarListXML = { sReply };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Calendars, bool>(_calendarsInstance, MethodReadCalendarListXML, parametersOfReadCalendarListXML, methodReadCalendarListXMLPrametersTypes);

            // Assert
            parametersOfReadCalendarListXML.ShouldNotBeNull();
            parametersOfReadCalendarListXML.Length.ShouldBe(1);
            methodReadCalendarListXMLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCalendarListXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_ReadCalendarListXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadCalendarListXMLPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_calendarsInstance, MethodReadCalendarListXML, Fixture, methodReadCalendarListXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReadCalendarListXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadCalendarListXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_ReadCalendarListXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadCalendarListXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_calendarsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ReadCalendarListXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_ReadCalendarListXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadCalendarListXML, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadCalendarDataXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Calendars_ReadCalendarDataXML_Method_Call_Internally(Type[] types)
        {
            var methodReadCalendarDataXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_calendarsInstance, MethodReadCalendarDataXML, Fixture, methodReadCalendarDataXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadCalendarDataXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_ReadCalendarDataXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var iCalendarID = CreateType<int>();
            var sReply = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _calendarsInstance.ReadCalendarDataXML(iCalendarID, out sReply);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ReadCalendarDataXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_ReadCalendarDataXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var iCalendarID = CreateType<int>();
            var sReply = CreateType<string>();
            var methodReadCalendarDataXMLPrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfReadCalendarDataXML = { iCalendarID, sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodReadCalendarDataXML, methodReadCalendarDataXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Calendars, bool>(_calendarsInstanceFixture, out exception1, parametersOfReadCalendarDataXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Calendars, bool>(_calendarsInstance, MethodReadCalendarDataXML, parametersOfReadCalendarDataXML, methodReadCalendarDataXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfReadCalendarDataXML.ShouldNotBeNull();
            parametersOfReadCalendarDataXML.Length.ShouldBe(2);
            methodReadCalendarDataXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ReadCalendarDataXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_ReadCalendarDataXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var iCalendarID = CreateType<int>();
            var sReply = CreateType<string>();
            var methodReadCalendarDataXMLPrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfReadCalendarDataXML = { iCalendarID, sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodReadCalendarDataXML, methodReadCalendarDataXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Calendars, bool>(_calendarsInstanceFixture, out exception1, parametersOfReadCalendarDataXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Calendars, bool>(_calendarsInstance, MethodReadCalendarDataXML, parametersOfReadCalendarDataXML, methodReadCalendarDataXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfReadCalendarDataXML.ShouldNotBeNull();
            parametersOfReadCalendarDataXML.Length.ShouldBe(2);
            methodReadCalendarDataXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ReadCalendarDataXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_ReadCalendarDataXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var iCalendarID = CreateType<int>();
            var sReply = CreateType<string>();
            var methodReadCalendarDataXMLPrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfReadCalendarDataXML = { iCalendarID, sReply };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Calendars, bool>(_calendarsInstance, MethodReadCalendarDataXML, parametersOfReadCalendarDataXML, methodReadCalendarDataXMLPrametersTypes);

            // Assert
            parametersOfReadCalendarDataXML.ShouldNotBeNull();
            parametersOfReadCalendarDataXML.Length.ShouldBe(2);
            methodReadCalendarDataXMLPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCalendarDataXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_ReadCalendarDataXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadCalendarDataXMLPrametersTypes = new Type[] { typeof(int), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_calendarsInstance, MethodReadCalendarDataXML, Fixture, methodReadCalendarDataXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReadCalendarDataXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadCalendarDataXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_ReadCalendarDataXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadCalendarDataXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_calendarsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ReadCalendarDataXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Calendars_ReadCalendarDataXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadCalendarDataXML, 0);
            const int parametersCount = 2;

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