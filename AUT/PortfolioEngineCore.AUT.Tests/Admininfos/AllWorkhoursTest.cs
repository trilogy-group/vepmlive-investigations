using System;
using System.Collections.Generic;
using System.Data;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.AllWorkhours" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AllWorkhoursTest : AbstractBaseSetupTypedTest<AllWorkhours>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AllWorkhours) Initializer

        private const string MethodInitialize = "Initialize";
        private const string MethodGetHolidayHours = "GetHolidayHours";
        private const string MethodProrate = "Prorate";
        private const string MethodGetwork = "Getwork";
        private const string Methodworkhours = "workhours";
        private const string Methodoffhours = "offhours";
        private const string Fieldm_WorkHours = "m_WorkHours";
        private const string Fieldm_HolidayHours = "m_HolidayHours";
        private const string Fieldwork = "work";
        private Type _allWorkhoursInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AllWorkhours _allWorkhoursInstance;
        private AllWorkhours _allWorkhoursInstanceFixture;

        #region General Initializer : Class (AllWorkhours) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AllWorkhours" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _allWorkhoursInstanceType = typeof(AllWorkhours);
            _allWorkhoursInstanceFixture = Create(true);
            _allWorkhoursInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AllWorkhours)

        #region General Initializer : Class (AllWorkhours) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="AllWorkhours" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodInitialize, 0)]
        [TestCase(MethodGetHolidayHours, 0)]
        [TestCase(MethodProrate, 0)]
        [TestCase(MethodGetwork, 0)]
        [TestCase(Methodworkhours, 0)]
        [TestCase(Methodoffhours, 0)]
        public void AUT_AllWorkhours_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_allWorkhoursInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AllWorkhours) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AllWorkhours" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldm_WorkHours)]
        [TestCase(Fieldm_HolidayHours)]
        [TestCase(Fieldwork)]
        public void AUT_AllWorkhours_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_allWorkhoursInstanceFixture, 
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
        ///     Class (<see cref="AllWorkhours" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_AllWorkhours_Is_Instance_Present_Test()
        {
            // Assert
            _allWorkhoursInstanceType.ShouldNotBeNull();
            _allWorkhoursInstance.ShouldNotBeNull();
            _allWorkhoursInstanceFixture.ShouldNotBeNull();
            _allWorkhoursInstance.ShouldBeAssignableTo<AllWorkhours>();
            _allWorkhoursInstanceFixture.ShouldBeAssignableTo<AllWorkhours>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AllWorkhours) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_AllWorkhours_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            AllWorkhours instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _allWorkhoursInstanceType.ShouldNotBeNull();
            _allWorkhoursInstance.ShouldNotBeNull();
            _allWorkhoursInstanceFixture.ShouldNotBeNull();
            _allWorkhoursInstance.ShouldBeAssignableTo<AllWorkhours>();
            _allWorkhoursInstanceFixture.ShouldBeAssignableTo<AllWorkhours>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="AllWorkhours" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodInitialize)]
        [TestCase(MethodGetHolidayHours)]
        [TestCase(MethodProrate)]
        [TestCase(MethodGetwork)]
        [TestCase(Methodworkhours)]
        [TestCase(Methodoffhours)]
        public void AUT_AllWorkhours_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<AllWorkhours>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AllWorkhours_Initialize_Method_Call_Internally(Type[] types)
        {
            var methodInitializePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_allWorkhoursInstance, MethodInitialize, Fixture, methodInitializePrametersTypes);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_Initialize_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var dtWorkhours = CreateType<DataTable>();
            var dtHolidays = CreateType<DataTable>();
            Action executeAction = null;

            // Act
            executeAction = () => _allWorkhoursInstance.Initialize(dtWorkhours, dtHolidays);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_Initialize_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var dtWorkhours = CreateType<DataTable>();
            var dtHolidays = CreateType<DataTable>();
            var methodInitializePrametersTypes = new Type[] { typeof(DataTable), typeof(DataTable) };
            object[] parametersOfInitialize = { dtWorkhours, dtHolidays };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitialize, methodInitializePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_allWorkhoursInstanceFixture, parametersOfInitialize);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitialize.ShouldNotBeNull();
            parametersOfInitialize.Length.ShouldBe(2);
            methodInitializePrametersTypes.Length.ShouldBe(2);
            methodInitializePrametersTypes.Length.ShouldBe(parametersOfInitialize.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_Initialize_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dtWorkhours = CreateType<DataTable>();
            var dtHolidays = CreateType<DataTable>();
            var methodInitializePrametersTypes = new Type[] { typeof(DataTable), typeof(DataTable) };
            object[] parametersOfInitialize = { dtWorkhours, dtHolidays };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_allWorkhoursInstance, MethodInitialize, parametersOfInitialize, methodInitializePrametersTypes);

            // Assert
            parametersOfInitialize.ShouldNotBeNull();
            parametersOfInitialize.Length.ShouldBe(2);
            methodInitializePrametersTypes.Length.ShouldBe(2);
            methodInitializePrametersTypes.Length.ShouldBe(parametersOfInitialize.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_Initialize_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInitialize, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_Initialize_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitializePrametersTypes = new Type[] { typeof(DataTable), typeof(DataTable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_allWorkhoursInstance, MethodInitialize, Fixture, methodInitializePrametersTypes);

            // Assert
            methodInitializePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_Initialize_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitialize, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_allWorkhoursInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetHolidayHours) (Return Type : double) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AllWorkhours_GetHolidayHours_Method_Call_Internally(Type[] types)
        {
            var methodGetHolidayHoursPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_allWorkhoursInstance, MethodGetHolidayHours, Fixture, methodGetHolidayHoursPrametersTypes);
        }

        #endregion

        #region Method Call : (GetHolidayHours) (Return Type : double) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_GetHolidayHours_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var HolidayHours = CreateType<Dictionary<int, double>>();
            var targetdate = CreateType<DateTime>();
            var methodGetHolidayHoursPrametersTypes = new Type[] { typeof(Dictionary<int, double>), typeof(DateTime) };
            object[] parametersOfGetHolidayHours = { HolidayHours, targetdate };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetHolidayHours, methodGetHolidayHoursPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AllWorkhours, double>(_allWorkhoursInstanceFixture, out exception1, parametersOfGetHolidayHours);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AllWorkhours, double>(_allWorkhoursInstance, MethodGetHolidayHours, parametersOfGetHolidayHours, methodGetHolidayHoursPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetHolidayHours.ShouldNotBeNull();
            parametersOfGetHolidayHours.Length.ShouldBe(2);
            methodGetHolidayHoursPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetHolidayHours) (Return Type : double) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_GetHolidayHours_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var HolidayHours = CreateType<Dictionary<int, double>>();
            var targetdate = CreateType<DateTime>();
            var methodGetHolidayHoursPrametersTypes = new Type[] { typeof(Dictionary<int, double>), typeof(DateTime) };
            object[] parametersOfGetHolidayHours = { HolidayHours, targetdate };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetHolidayHours, methodGetHolidayHoursPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AllWorkhours, double>(_allWorkhoursInstanceFixture, out exception1, parametersOfGetHolidayHours);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AllWorkhours, double>(_allWorkhoursInstance, MethodGetHolidayHours, parametersOfGetHolidayHours, methodGetHolidayHoursPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetHolidayHours.ShouldNotBeNull();
            parametersOfGetHolidayHours.Length.ShouldBe(2);
            methodGetHolidayHoursPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetHolidayHours) (Return Type : double) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_GetHolidayHours_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var HolidayHours = CreateType<Dictionary<int, double>>();
            var targetdate = CreateType<DateTime>();
            var methodGetHolidayHoursPrametersTypes = new Type[] { typeof(Dictionary<int, double>), typeof(DateTime) };
            object[] parametersOfGetHolidayHours = { HolidayHours, targetdate };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetHolidayHours, methodGetHolidayHoursPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_allWorkhoursInstanceFixture, parametersOfGetHolidayHours);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetHolidayHours.ShouldNotBeNull();
            parametersOfGetHolidayHours.Length.ShouldBe(2);
            methodGetHolidayHoursPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetHolidayHours) (Return Type : double) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_GetHolidayHours_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var HolidayHours = CreateType<Dictionary<int, double>>();
            var targetdate = CreateType<DateTime>();
            var methodGetHolidayHoursPrametersTypes = new Type[] { typeof(Dictionary<int, double>), typeof(DateTime) };
            object[] parametersOfGetHolidayHours = { HolidayHours, targetdate };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AllWorkhours, double>(_allWorkhoursInstance, MethodGetHolidayHours, parametersOfGetHolidayHours, methodGetHolidayHoursPrametersTypes);

            // Assert
            parametersOfGetHolidayHours.ShouldNotBeNull();
            parametersOfGetHolidayHours.Length.ShouldBe(2);
            methodGetHolidayHoursPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetHolidayHours) (Return Type : double) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_GetHolidayHours_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetHolidayHoursPrametersTypes = new Type[] { typeof(Dictionary<int, double>), typeof(DateTime) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_allWorkhoursInstance, MethodGetHolidayHours, Fixture, methodGetHolidayHoursPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetHolidayHoursPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetHolidayHours) (Return Type : double) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_GetHolidayHours_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetHolidayHours, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_allWorkhoursInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetHolidayHours) (Return Type : double) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_GetHolidayHours_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetHolidayHours, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Prorate) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AllWorkhours_Prorate_Method_Call_Internally(Type[] types)
        {
            var methodProratePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_allWorkhoursInstance, MethodProrate, Fixture, methodProratePrametersTypes);
        }

        #endregion

        #region Method Call : (Prorate) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_Prorate_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var workhourgroup = CreateType<int>();
            var holidaygroup = CreateType<int>();
            var startdate = CreateType<DateTime>();
            var finishdate = CreateType<DateTime>();
            var hours = CreateType<double>();
            Action executeAction = null;

            // Act
            executeAction = () => _allWorkhoursInstance.Prorate(workhourgroup, holidaygroup, startdate, finishdate, hours);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Prorate) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_Prorate_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var workhourgroup = CreateType<int>();
            var holidaygroup = CreateType<int>();
            var startdate = CreateType<DateTime>();
            var finishdate = CreateType<DateTime>();
            var hours = CreateType<double>();
            var methodProratePrametersTypes = new Type[] { typeof(int), typeof(int), typeof(DateTime), typeof(DateTime), typeof(double) };
            object[] parametersOfProrate = { workhourgroup, holidaygroup, startdate, finishdate, hours };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodProrate, methodProratePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AllWorkhours, bool>(_allWorkhoursInstanceFixture, out exception1, parametersOfProrate);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AllWorkhours, bool>(_allWorkhoursInstance, MethodProrate, parametersOfProrate, methodProratePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfProrate.ShouldNotBeNull();
            parametersOfProrate.Length.ShouldBe(5);
            methodProratePrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (Prorate) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_Prorate_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var workhourgroup = CreateType<int>();
            var holidaygroup = CreateType<int>();
            var startdate = CreateType<DateTime>();
            var finishdate = CreateType<DateTime>();
            var hours = CreateType<double>();
            var methodProratePrametersTypes = new Type[] { typeof(int), typeof(int), typeof(DateTime), typeof(DateTime), typeof(double) };
            object[] parametersOfProrate = { workhourgroup, holidaygroup, startdate, finishdate, hours };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodProrate, methodProratePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AllWorkhours, bool>(_allWorkhoursInstanceFixture, out exception1, parametersOfProrate);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AllWorkhours, bool>(_allWorkhoursInstance, MethodProrate, parametersOfProrate, methodProratePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfProrate.ShouldNotBeNull();
            parametersOfProrate.Length.ShouldBe(5);
            methodProratePrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (Prorate) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_Prorate_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var workhourgroup = CreateType<int>();
            var holidaygroup = CreateType<int>();
            var startdate = CreateType<DateTime>();
            var finishdate = CreateType<DateTime>();
            var hours = CreateType<double>();
            var methodProratePrametersTypes = new Type[] { typeof(int), typeof(int), typeof(DateTime), typeof(DateTime), typeof(double) };
            object[] parametersOfProrate = { workhourgroup, holidaygroup, startdate, finishdate, hours };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProrate, methodProratePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_allWorkhoursInstanceFixture, parametersOfProrate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProrate.ShouldNotBeNull();
            parametersOfProrate.Length.ShouldBe(5);
            methodProratePrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Prorate) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_Prorate_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var workhourgroup = CreateType<int>();
            var holidaygroup = CreateType<int>();
            var startdate = CreateType<DateTime>();
            var finishdate = CreateType<DateTime>();
            var hours = CreateType<double>();
            var methodProratePrametersTypes = new Type[] { typeof(int), typeof(int), typeof(DateTime), typeof(DateTime), typeof(double) };
            object[] parametersOfProrate = { workhourgroup, holidaygroup, startdate, finishdate, hours };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AllWorkhours, bool>(_allWorkhoursInstance, MethodProrate, parametersOfProrate, methodProratePrametersTypes);

            // Assert
            parametersOfProrate.ShouldNotBeNull();
            parametersOfProrate.Length.ShouldBe(5);
            methodProratePrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Prorate) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_Prorate_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodProratePrametersTypes = new Type[] { typeof(int), typeof(int), typeof(DateTime), typeof(DateTime), typeof(double) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_allWorkhoursInstance, MethodProrate, Fixture, methodProratePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodProratePrametersTypes.Length.ShouldBe(5);
        }

        #endregion
        
        #region Method Call : (Prorate) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_Prorate_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProratePrametersTypes = new Type[] { typeof(int), typeof(int), typeof(DateTime), typeof(DateTime), typeof(double) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_allWorkhoursInstance, MethodProrate, Fixture, methodProratePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodProratePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Prorate) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_Prorate_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProrate, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_allWorkhoursInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Prorate) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_Prorate_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProrate, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Getwork) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AllWorkhours_Getwork_Method_Call_Internally(Type[] types)
        {
            var methodGetworkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_allWorkhoursInstance, MethodGetwork, Fixture, methodGetworkPrametersTypes);
        }

        #endregion

        #region Method Call : (Getwork) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_Getwork_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var index = CreateType<int>();
            var hours = CreateType<double>();
            Action executeAction = null;

            // Act
            executeAction = () => _allWorkhoursInstance.Getwork(index, out hours);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Getwork) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_Getwork_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var index = CreateType<int>();
            var hours = CreateType<double>();
            var methodGetworkPrametersTypes = new Type[] { typeof(int), typeof(double) };
            object[] parametersOfGetwork = { index, hours };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetwork, methodGetworkPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_allWorkhoursInstanceFixture, parametersOfGetwork);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetwork.ShouldNotBeNull();
            parametersOfGetwork.Length.ShouldBe(2);
            methodGetworkPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Getwork) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_Getwork_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var index = CreateType<int>();
            var hours = CreateType<double>();
            var methodGetworkPrametersTypes = new Type[] { typeof(int), typeof(double) };
            object[] parametersOfGetwork = { index, hours };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AllWorkhours, bool>(_allWorkhoursInstance, MethodGetwork, parametersOfGetwork, methodGetworkPrametersTypes);

            // Assert
            parametersOfGetwork.ShouldNotBeNull();
            parametersOfGetwork.Length.ShouldBe(2);
            methodGetworkPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Getwork) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_Getwork_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetworkPrametersTypes = new Type[] { typeof(int), typeof(double) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_allWorkhoursInstance, MethodGetwork, Fixture, methodGetworkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetworkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Getwork) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_Getwork_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetwork, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_allWorkhoursInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Getwork) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_Getwork_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetwork, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (workhours) (Return Type : double) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AllWorkhours_workhours_Method_Call_Internally(Type[] types)
        {
            var methodworkhoursPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_allWorkhoursInstance, Methodworkhours, Fixture, methodworkhoursPrametersTypes);
        }

        #endregion

        #region Method Call : (workhours) (Return Type : double) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_workhours_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var workhourgroup = CreateType<int>();
            var holidaygroup = CreateType<int>();
            var startdate = CreateType<DateTime>();
            var finishdate = CreateType<DateTime>();
            var deductHolidays = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _allWorkhoursInstance.workhours(workhourgroup, holidaygroup, startdate, finishdate, deductHolidays);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (workhours) (Return Type : double) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_workhours_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var workhourgroup = CreateType<int>();
            var holidaygroup = CreateType<int>();
            var startdate = CreateType<DateTime>();
            var finishdate = CreateType<DateTime>();
            var deductHolidays = CreateType<bool>();
            var methodworkhoursPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(DateTime), typeof(DateTime), typeof(bool) };
            object[] parametersOfworkhours = { workhourgroup, holidaygroup, startdate, finishdate, deductHolidays };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(Methodworkhours, methodworkhoursPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AllWorkhours, double>(_allWorkhoursInstanceFixture, out exception1, parametersOfworkhours);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AllWorkhours, double>(_allWorkhoursInstance, Methodworkhours, parametersOfworkhours, methodworkhoursPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfworkhours.ShouldNotBeNull();
            parametersOfworkhours.Length.ShouldBe(5);
            methodworkhoursPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (workhours) (Return Type : double) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_workhours_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var workhourgroup = CreateType<int>();
            var holidaygroup = CreateType<int>();
            var startdate = CreateType<DateTime>();
            var finishdate = CreateType<DateTime>();
            var deductHolidays = CreateType<bool>();
            var methodworkhoursPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(DateTime), typeof(DateTime), typeof(bool) };
            object[] parametersOfworkhours = { workhourgroup, holidaygroup, startdate, finishdate, deductHolidays };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(Methodworkhours, methodworkhoursPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AllWorkhours, double>(_allWorkhoursInstanceFixture, out exception1, parametersOfworkhours);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AllWorkhours, double>(_allWorkhoursInstance, Methodworkhours, parametersOfworkhours, methodworkhoursPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfworkhours.ShouldNotBeNull();
            parametersOfworkhours.Length.ShouldBe(5);
            methodworkhoursPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (workhours) (Return Type : double) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_workhours_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var workhourgroup = CreateType<int>();
            var holidaygroup = CreateType<int>();
            var startdate = CreateType<DateTime>();
            var finishdate = CreateType<DateTime>();
            var deductHolidays = CreateType<bool>();
            var methodworkhoursPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(DateTime), typeof(DateTime), typeof(bool) };
            object[] parametersOfworkhours = { workhourgroup, holidaygroup, startdate, finishdate, deductHolidays };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodworkhours, methodworkhoursPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_allWorkhoursInstanceFixture, parametersOfworkhours);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfworkhours.ShouldNotBeNull();
            parametersOfworkhours.Length.ShouldBe(5);
            methodworkhoursPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (workhours) (Return Type : double) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_workhours_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var workhourgroup = CreateType<int>();
            var holidaygroup = CreateType<int>();
            var startdate = CreateType<DateTime>();
            var finishdate = CreateType<DateTime>();
            var deductHolidays = CreateType<bool>();
            var methodworkhoursPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(DateTime), typeof(DateTime), typeof(bool) };
            object[] parametersOfworkhours = { workhourgroup, holidaygroup, startdate, finishdate, deductHolidays };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AllWorkhours, double>(_allWorkhoursInstance, Methodworkhours, parametersOfworkhours, methodworkhoursPrametersTypes);

            // Assert
            parametersOfworkhours.ShouldNotBeNull();
            parametersOfworkhours.Length.ShouldBe(5);
            methodworkhoursPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (workhours) (Return Type : double) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_workhours_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodworkhoursPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(DateTime), typeof(DateTime), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_allWorkhoursInstance, Methodworkhours, Fixture, methodworkhoursPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodworkhoursPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (workhours) (Return Type : double) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_workhours_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodworkhoursPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(DateTime), typeof(DateTime), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_allWorkhoursInstance, Methodworkhours, Fixture, methodworkhoursPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodworkhoursPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (workhours) (Return Type : double) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_workhours_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodworkhoursPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(DateTime), typeof(DateTime), typeof(bool) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_allWorkhoursInstance, Methodworkhours, Fixture, methodworkhoursPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodworkhoursPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (workhours) (Return Type : double) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_workhours_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodworkhours, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_allWorkhoursInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (workhours) (Return Type : double) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_workhours_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodworkhours, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (offhours) (Return Type : double) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AllWorkhours_offhours_Method_Call_Internally(Type[] types)
        {
            var methodoffhoursPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_allWorkhoursInstance, Methodoffhours, Fixture, methodoffhoursPrametersTypes);
        }

        #endregion

        #region Method Call : (offhours) (Return Type : double) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_offhours_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var workhourgroup = CreateType<int>();
            var holidaygroup = CreateType<int>();
            var startdate = CreateType<DateTime>();
            var finishdate = CreateType<DateTime>();
            Action executeAction = null;

            // Act
            executeAction = () => _allWorkhoursInstance.offhours(workhourgroup, holidaygroup, startdate, finishdate);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (offhours) (Return Type : double) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_offhours_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var workhourgroup = CreateType<int>();
            var holidaygroup = CreateType<int>();
            var startdate = CreateType<DateTime>();
            var finishdate = CreateType<DateTime>();
            var methodoffhoursPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(DateTime), typeof(DateTime) };
            object[] parametersOfoffhours = { workhourgroup, holidaygroup, startdate, finishdate };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(Methodoffhours, methodoffhoursPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AllWorkhours, double>(_allWorkhoursInstanceFixture, out exception1, parametersOfoffhours);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AllWorkhours, double>(_allWorkhoursInstance, Methodoffhours, parametersOfoffhours, methodoffhoursPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfoffhours.ShouldNotBeNull();
            parametersOfoffhours.Length.ShouldBe(4);
            methodoffhoursPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (offhours) (Return Type : double) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_offhours_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var workhourgroup = CreateType<int>();
            var holidaygroup = CreateType<int>();
            var startdate = CreateType<DateTime>();
            var finishdate = CreateType<DateTime>();
            var methodoffhoursPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(DateTime), typeof(DateTime) };
            object[] parametersOfoffhours = { workhourgroup, holidaygroup, startdate, finishdate };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(Methodoffhours, methodoffhoursPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AllWorkhours, double>(_allWorkhoursInstanceFixture, out exception1, parametersOfoffhours);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AllWorkhours, double>(_allWorkhoursInstance, Methodoffhours, parametersOfoffhours, methodoffhoursPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfoffhours.ShouldNotBeNull();
            parametersOfoffhours.Length.ShouldBe(4);
            methodoffhoursPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (offhours) (Return Type : double) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_offhours_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var workhourgroup = CreateType<int>();
            var holidaygroup = CreateType<int>();
            var startdate = CreateType<DateTime>();
            var finishdate = CreateType<DateTime>();
            var methodoffhoursPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(DateTime), typeof(DateTime) };
            object[] parametersOfoffhours = { workhourgroup, holidaygroup, startdate, finishdate };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodoffhours, methodoffhoursPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_allWorkhoursInstanceFixture, parametersOfoffhours);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfoffhours.ShouldNotBeNull();
            parametersOfoffhours.Length.ShouldBe(4);
            methodoffhoursPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (offhours) (Return Type : double) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_offhours_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var workhourgroup = CreateType<int>();
            var holidaygroup = CreateType<int>();
            var startdate = CreateType<DateTime>();
            var finishdate = CreateType<DateTime>();
            var methodoffhoursPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(DateTime), typeof(DateTime) };
            object[] parametersOfoffhours = { workhourgroup, holidaygroup, startdate, finishdate };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AllWorkhours, double>(_allWorkhoursInstance, Methodoffhours, parametersOfoffhours, methodoffhoursPrametersTypes);

            // Assert
            parametersOfoffhours.ShouldNotBeNull();
            parametersOfoffhours.Length.ShouldBe(4);
            methodoffhoursPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (offhours) (Return Type : double) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_offhours_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodoffhoursPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(DateTime), typeof(DateTime) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_allWorkhoursInstance, Methodoffhours, Fixture, methodoffhoursPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodoffhoursPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (offhours) (Return Type : double) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_offhours_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodoffhoursPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(DateTime), typeof(DateTime) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_allWorkhoursInstance, Methodoffhours, Fixture, methodoffhoursPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodoffhoursPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (offhours) (Return Type : double) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_offhours_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodoffhoursPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(DateTime), typeof(DateTime) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_allWorkhoursInstance, Methodoffhours, Fixture, methodoffhoursPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodoffhoursPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (offhours) (Return Type : double) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_offhours_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodoffhours, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_allWorkhoursInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (offhours) (Return Type : double) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AllWorkhours_offhours_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodoffhours, 0);
            const int parametersCount = 4;

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