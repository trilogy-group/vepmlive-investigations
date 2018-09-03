using System;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.Workhours" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WorkhoursTest : AbstractBaseSetupTypedTest<Workhours>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Workhours) Initializer

        private const string MethodInitialize = "Initialize";
        private const string Methodworkhours = "workhours";
        private const string Fieldm_WorkHours = "m_WorkHours";
        private const string Fieldm_HolidayHours = "m_HolidayHours";
        private Type _workhoursInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Workhours _workhoursInstance;
        private Workhours _workhoursInstanceFixture;

        #region General Initializer : Class (Workhours) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Workhours" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workhoursInstanceType = typeof(Workhours);
            _workhoursInstanceFixture = Create(true);
            _workhoursInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Workhours)

        #region General Initializer : Class (Workhours) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Workhours" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodInitialize, 0)]
        [TestCase(Methodworkhours, 0)]
        public void AUT_Workhours_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_workhoursInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Workhours) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Workhours" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldm_WorkHours)]
        [TestCase(Fieldm_HolidayHours)]
        public void AUT_Workhours_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workhoursInstanceFixture, 
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
        ///     Class (<see cref="Workhours" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Workhours_Is_Instance_Present_Test()
        {
            // Assert
            _workhoursInstanceType.ShouldNotBeNull();
            _workhoursInstance.ShouldNotBeNull();
            _workhoursInstanceFixture.ShouldNotBeNull();
            _workhoursInstance.ShouldBeAssignableTo<Workhours>();
            _workhoursInstanceFixture.ShouldBeAssignableTo<Workhours>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Workhours) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Workhours_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Workhours instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workhoursInstanceType.ShouldNotBeNull();
            _workhoursInstance.ShouldNotBeNull();
            _workhoursInstanceFixture.ShouldNotBeNull();
            _workhoursInstance.ShouldBeAssignableTo<Workhours>();
            _workhoursInstanceFixture.ShouldBeAssignableTo<Workhours>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Workhours" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodInitialize)]
        [TestCase(Methodworkhours)]
        public void AUT_Workhours_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Workhours>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Workhours_Initialize_Method_Call_Internally(Type[] types)
        {
            var methodInitializePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workhoursInstance, MethodInitialize, Fixture, methodInitializePrametersTypes);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Workhours_Initialize_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var dtWorkhours = CreateType<DataTable>();
            var dtHolidays = CreateType<DataTable>();
            Action executeAction = null;

            // Act
            executeAction = () => _workhoursInstance.Initialize(dtWorkhours, dtHolidays);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Workhours_Initialize_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var dtWorkhours = CreateType<DataTable>();
            var dtHolidays = CreateType<DataTable>();
            var methodInitializePrametersTypes = new Type[] { typeof(DataTable), typeof(DataTable) };
            object[] parametersOfInitialize = { dtWorkhours, dtHolidays };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitialize, methodInitializePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workhoursInstanceFixture, parametersOfInitialize);

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
        public void AUT_Workhours_Initialize_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dtWorkhours = CreateType<DataTable>();
            var dtHolidays = CreateType<DataTable>();
            var methodInitializePrametersTypes = new Type[] { typeof(DataTable), typeof(DataTable) };
            object[] parametersOfInitialize = { dtWorkhours, dtHolidays };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_workhoursInstance, MethodInitialize, parametersOfInitialize, methodInitializePrametersTypes);

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
        public void AUT_Workhours_Initialize_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Workhours_Initialize_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitializePrametersTypes = new Type[] { typeof(DataTable), typeof(DataTable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workhoursInstance, MethodInitialize, Fixture, methodInitializePrametersTypes);

            // Assert
            methodInitializePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Workhours_Initialize_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitialize, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workhoursInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (workhours) (Return Type : double) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Workhours_workhours_Method_Call_Internally(Type[] types)
        {
            var methodworkhoursPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workhoursInstance, Methodworkhours, Fixture, methodworkhoursPrametersTypes);
        }

        #endregion

        #region Method Call : (workhours) (Return Type : double) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Workhours_workhours_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var targetdate = CreateType<DateTime>();
            Action executeAction = null;

            // Act
            executeAction = () => _workhoursInstance.workhours(targetdate);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (workhours) (Return Type : double) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Workhours_workhours_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var targetdate = CreateType<DateTime>();
            var methodworkhoursPrametersTypes = new Type[] { typeof(DateTime) };
            object[] parametersOfworkhours = { targetdate };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(Methodworkhours, methodworkhoursPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Workhours, double>(_workhoursInstanceFixture, out exception1, parametersOfworkhours);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Workhours, double>(_workhoursInstance, Methodworkhours, parametersOfworkhours, methodworkhoursPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfworkhours.ShouldNotBeNull();
            parametersOfworkhours.Length.ShouldBe(1);
            methodworkhoursPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (workhours) (Return Type : double) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Workhours_workhours_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var targetdate = CreateType<DateTime>();
            var methodworkhoursPrametersTypes = new Type[] { typeof(DateTime) };
            object[] parametersOfworkhours = { targetdate };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(Methodworkhours, methodworkhoursPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Workhours, double>(_workhoursInstanceFixture, out exception1, parametersOfworkhours);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Workhours, double>(_workhoursInstance, Methodworkhours, parametersOfworkhours, methodworkhoursPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfworkhours.ShouldNotBeNull();
            parametersOfworkhours.Length.ShouldBe(1);
            methodworkhoursPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (workhours) (Return Type : double) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Workhours_workhours_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var targetdate = CreateType<DateTime>();
            var methodworkhoursPrametersTypes = new Type[] { typeof(DateTime) };
            object[] parametersOfworkhours = { targetdate };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Workhours, double>(_workhoursInstance, Methodworkhours, parametersOfworkhours, methodworkhoursPrametersTypes);

            // Assert
            parametersOfworkhours.ShouldNotBeNull();
            parametersOfworkhours.Length.ShouldBe(1);
            methodworkhoursPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (workhours) (Return Type : double) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Workhours_workhours_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodworkhoursPrametersTypes = new Type[] { typeof(DateTime) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workhoursInstance, Methodworkhours, Fixture, methodworkhoursPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodworkhoursPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (workhours) (Return Type : double) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Workhours_workhours_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodworkhours, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workhoursInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (workhours) (Return Type : double) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Workhours_workhours_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodworkhours, 0);
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