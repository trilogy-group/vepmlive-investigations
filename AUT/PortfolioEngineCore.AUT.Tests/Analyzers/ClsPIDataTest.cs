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

namespace CostDataValues
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="CostDataValues.clsPIData" />)
    ///     and namespace <see cref="CostDataValues"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ClsPIDataTest : AbstractBaseSetupTypedTest<clsPIData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (clsPIData) Initializer

        private const string MethodCompareTo = "CompareTo";
        private const string FieldPI_ID = "PI_ID";
        private const string FieldStartDate = "StartDate";
        private const string FieldPI_Name = "PI_Name";
        private const string Fieldm_PI_Extra_data = "m_PI_Extra_data";
        private const string Fieldm_PI_Format_Extra_data = "m_PI_Format_Extra_data";
        private Type _clsPIDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private clsPIData _clsPIDataInstance;
        private clsPIData _clsPIDataInstanceFixture;

        #region General Initializer : Class (clsPIData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="clsPIData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _clsPIDataInstanceType = typeof(clsPIData);
            _clsPIDataInstanceFixture = Create(true);
            _clsPIDataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (clsPIData)

        #region General Initializer : Class (clsPIData) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="clsPIData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodCompareTo, 0)]
        public void AUT_ClsPIData_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_clsPIDataInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (clsPIData) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="clsPIData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldPI_ID)]
        [TestCase(FieldStartDate)]
        [TestCase(FieldPI_Name)]
        [TestCase(Fieldm_PI_Extra_data)]
        [TestCase(Fieldm_PI_Format_Extra_data)]
        public void AUT_ClsPIData_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_clsPIDataInstanceFixture, 
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
        ///     Class (<see cref="clsPIData" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ClsPIData_Is_Instance_Present_Test()
        {
            // Assert
            _clsPIDataInstanceType.ShouldNotBeNull();
            _clsPIDataInstance.ShouldNotBeNull();
            _clsPIDataInstanceFixture.ShouldNotBeNull();
            _clsPIDataInstance.ShouldBeAssignableTo<clsPIData>();
            _clsPIDataInstanceFixture.ShouldBeAssignableTo<clsPIData>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (clsPIData) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ClsPIData_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var arraysize = CreateType<int>();
            clsPIData instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new clsPIData(arraysize);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _clsPIDataInstance.ShouldNotBeNull();
            _clsPIDataInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<clsPIData>();
        }

        #endregion

        #region General Constructor : Class (clsPIData) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ClsPIData_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var arraysize = CreateType<int>();
            clsPIData instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new clsPIData(arraysize);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _clsPIDataInstance.ShouldNotBeNull();
            _clsPIDataInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="clsPIData" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCompareTo)]
        public void AUT_ClsPIData_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<clsPIData>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (CompareTo) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClsPIData_CompareTo_Method_Call_Internally(Type[] types)
        {
            var methodCompareToPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsPIDataInstance, MethodCompareTo, Fixture, methodCompareToPrametersTypes);
        }

        #endregion

        #region Method Call : (CompareTo) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsPIData_CompareTo_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var rhs = CreateType<clsPIData>();
            Action executeAction = null;

            // Act
            executeAction = () => _clsPIDataInstance.CompareTo(rhs);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CompareTo) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsPIData_CompareTo_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var rhs = CreateType<clsPIData>();
            var methodCompareToPrametersTypes = new Type[] { typeof(clsPIData) };
            object[] parametersOfCompareTo = { rhs };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCompareTo, methodCompareToPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_clsPIDataInstanceFixture, parametersOfCompareTo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCompareTo.ShouldNotBeNull();
            parametersOfCompareTo.Length.ShouldBe(1);
            methodCompareToPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CompareTo) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsPIData_CompareTo_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var rhs = CreateType<clsPIData>();
            var methodCompareToPrametersTypes = new Type[] { typeof(clsPIData) };
            object[] parametersOfCompareTo = { rhs };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<clsPIData, int>(_clsPIDataInstance, MethodCompareTo, parametersOfCompareTo, methodCompareToPrametersTypes);

            // Assert
            parametersOfCompareTo.ShouldNotBeNull();
            parametersOfCompareTo.Length.ShouldBe(1);
            methodCompareToPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CompareTo) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsPIData_CompareTo_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCompareToPrametersTypes = new Type[] { typeof(clsPIData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsPIDataInstance, MethodCompareTo, Fixture, methodCompareToPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCompareToPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CompareTo) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsPIData_CompareTo_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCompareTo, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_clsPIDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (CompareTo) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsPIData_CompareTo_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCompareTo, 0);
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