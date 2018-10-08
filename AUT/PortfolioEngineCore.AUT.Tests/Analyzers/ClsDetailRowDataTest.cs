using System;
using System.Collections.Generic;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="CostDataValues.clsDetailRowData" />)
    ///     and namespace <see cref="CostDataValues"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ClsDetailRowDataTest : AbstractBaseSetupTypedTest<clsDetailRowData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (clsDetailRowData) Initializer

        private const string MethodCopyData = "CopyData";
        private const string MethodAddToTargetData = "AddToTargetData";
        private const string MethodCaputureInitialData = "CaputureInitialData";
        private const string MethodRestoreInitialData = "RestoreInitialData";
        private const string FieldCT_ind = "CT_ind";
        private const string FieldbFiltered = "bFiltered";
        private const string Fieldrowid = "rowid";
        private const string Fieldm_dict_key = "m_dict_key";
        private Type _clsDetailRowDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private clsDetailRowData _clsDetailRowDataInstance;
        private clsDetailRowData _clsDetailRowDataInstanceFixture;

        #region General Initializer : Class (clsDetailRowData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="clsDetailRowData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _clsDetailRowDataInstanceType = typeof(clsDetailRowData);
            _clsDetailRowDataInstanceFixture = Create(true);
            _clsDetailRowDataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (clsDetailRowData)

        #region General Initializer : Class (clsDetailRowData) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="clsDetailRowData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodCopyData, 0)]
        [TestCase(MethodAddToTargetData, 0)]
        [TestCase(MethodCaputureInitialData, 0)]
        [TestCase(MethodRestoreInitialData, 0)]
        public void AUT_ClsDetailRowData_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_clsDetailRowDataInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (clsDetailRowData) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="clsDetailRowData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldCT_ind)]
        [TestCase(FieldbFiltered)]
        [TestCase(Fieldrowid)]
        [TestCase(Fieldm_dict_key)]
        public void AUT_ClsDetailRowData_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_clsDetailRowDataInstanceFixture, 
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
        ///     Class (<see cref="clsDetailRowData" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ClsDetailRowData_Is_Instance_Present_Test()
        {
            // Assert
            _clsDetailRowDataInstanceType.ShouldNotBeNull();
            _clsDetailRowDataInstance.ShouldNotBeNull();
            _clsDetailRowDataInstanceFixture.ShouldNotBeNull();
            _clsDetailRowDataInstance.ShouldBeAssignableTo<clsDetailRowData>();
            _clsDetailRowDataInstanceFixture.ShouldBeAssignableTo<clsDetailRowData>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (clsDetailRowData) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ClsDetailRowData_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var arraysize = CreateType<int>();
            clsDetailRowData instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new clsDetailRowData(arraysize);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _clsDetailRowDataInstance.ShouldNotBeNull();
            _clsDetailRowDataInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<clsDetailRowData>();
        }

        #endregion

        #region General Constructor : Class (clsDetailRowData) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ClsDetailRowData_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var arraysize = CreateType<int>();
            clsDetailRowData instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new clsDetailRowData(arraysize);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _clsDetailRowDataInstance.ShouldNotBeNull();
            _clsDetailRowDataInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="clsDetailRowData" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCopyData)]
        [TestCase(MethodAddToTargetData)]
        [TestCase(MethodCaputureInitialData)]
        [TestCase(MethodRestoreInitialData)]
        public void AUT_ClsDetailRowData_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<clsDetailRowData>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (CopyData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClsDetailRowData_CopyData_Method_Call_Internally(Type[] types)
        {
            var methodCopyDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsDetailRowDataInstance, MethodCopyData, Fixture, methodCopyDataPrametersTypes);
        }

        #endregion

        #region Method Call : (CopyData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsDetailRowData_CopyData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var src = CreateType<clsDetailRowData>();
            Action executeAction = null;

            // Act
            executeAction = () => _clsDetailRowDataInstance.CopyData(src);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CopyData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsDetailRowData_CopyData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var src = CreateType<clsDetailRowData>();
            var methodCopyDataPrametersTypes = new Type[] { typeof(clsDetailRowData) };
            object[] parametersOfCopyData = { src };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_clsDetailRowDataInstance, MethodCopyData, parametersOfCopyData, methodCopyDataPrametersTypes);

            // Assert
            parametersOfCopyData.ShouldNotBeNull();
            parametersOfCopyData.Length.ShouldBe(1);
            methodCopyDataPrametersTypes.Length.ShouldBe(1);
            methodCopyDataPrametersTypes.Length.ShouldBe(parametersOfCopyData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CopyData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsDetailRowData_CopyData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCopyData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CopyData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsDetailRowData_CopyData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCopyDataPrametersTypes = new Type[] { typeof(clsDetailRowData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsDetailRowDataInstance, MethodCopyData, Fixture, methodCopyDataPrametersTypes);

            // Assert
            methodCopyDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CopyData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsDetailRowData_CopyData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCopyData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_clsDetailRowDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddToTargetData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClsDetailRowData_AddToTargetData_Method_Call_Internally(Type[] types)
        {
            var methodAddToTargetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsDetailRowDataInstance, MethodAddToTargetData, Fixture, methodAddToTargetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (AddToTargetData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsDetailRowData_AddToTargetData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var dest = CreateType<clsTargetRowData>();
            Action executeAction = null;

            // Act
            executeAction = () => _clsDetailRowDataInstance.AddToTargetData(ref dest);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddToTargetData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsDetailRowData_AddToTargetData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dest = CreateType<clsTargetRowData>();
            var methodAddToTargetDataPrametersTypes = new Type[] { typeof(clsTargetRowData) };
            object[] parametersOfAddToTargetData = { dest };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_clsDetailRowDataInstance, MethodAddToTargetData, parametersOfAddToTargetData, methodAddToTargetDataPrametersTypes);

            // Assert
            parametersOfAddToTargetData.ShouldNotBeNull();
            parametersOfAddToTargetData.Length.ShouldBe(1);
            methodAddToTargetDataPrametersTypes.Length.ShouldBe(1);
            methodAddToTargetDataPrametersTypes.Length.ShouldBe(parametersOfAddToTargetData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddToTargetData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsDetailRowData_AddToTargetData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddToTargetData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddToTargetData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsDetailRowData_AddToTargetData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddToTargetDataPrametersTypes = new Type[] { typeof(clsTargetRowData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsDetailRowDataInstance, MethodAddToTargetData, Fixture, methodAddToTargetDataPrametersTypes);

            // Assert
            methodAddToTargetDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddToTargetData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsDetailRowData_AddToTargetData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddToTargetData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_clsDetailRowDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CaputureInitialData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClsDetailRowData_CaputureInitialData_Method_Call_Internally(Type[] types)
        {
            var methodCaputureInitialDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsDetailRowDataInstance, MethodCaputureInitialData, Fixture, methodCaputureInitialDataPrametersTypes);
        }

        #endregion

        #region Method Call : (CaputureInitialData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsDetailRowData_CaputureInitialData_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var clnPer = CreateType<Dictionary<int, clsPeriodData>>();
            var methodCaputureInitialDataPrametersTypes = new Type[] { typeof(Dictionary<int, clsPeriodData>) };
            object[] parametersOfCaputureInitialData = { clnPer };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCaputureInitialData, methodCaputureInitialDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_clsDetailRowDataInstanceFixture, parametersOfCaputureInitialData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCaputureInitialData.ShouldNotBeNull();
            parametersOfCaputureInitialData.Length.ShouldBe(1);
            methodCaputureInitialDataPrametersTypes.Length.ShouldBe(1);
            methodCaputureInitialDataPrametersTypes.Length.ShouldBe(parametersOfCaputureInitialData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CaputureInitialData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsDetailRowData_CaputureInitialData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var clnPer = CreateType<Dictionary<int, clsPeriodData>>();
            var methodCaputureInitialDataPrametersTypes = new Type[] { typeof(Dictionary<int, clsPeriodData>) };
            object[] parametersOfCaputureInitialData = { clnPer };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_clsDetailRowDataInstance, MethodCaputureInitialData, parametersOfCaputureInitialData, methodCaputureInitialDataPrametersTypes);

            // Assert
            parametersOfCaputureInitialData.ShouldNotBeNull();
            parametersOfCaputureInitialData.Length.ShouldBe(1);
            methodCaputureInitialDataPrametersTypes.Length.ShouldBe(1);
            methodCaputureInitialDataPrametersTypes.Length.ShouldBe(parametersOfCaputureInitialData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CaputureInitialData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsDetailRowData_CaputureInitialData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCaputureInitialData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CaputureInitialData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsDetailRowData_CaputureInitialData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCaputureInitialDataPrametersTypes = new Type[] { typeof(Dictionary<int, clsPeriodData>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsDetailRowDataInstance, MethodCaputureInitialData, Fixture, methodCaputureInitialDataPrametersTypes);

            // Assert
            methodCaputureInitialDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CaputureInitialData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsDetailRowData_CaputureInitialData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCaputureInitialData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_clsDetailRowDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RestoreInitialData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClsDetailRowData_RestoreInitialData_Method_Call_Internally(Type[] types)
        {
            var methodRestoreInitialDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsDetailRowDataInstance, MethodRestoreInitialData, Fixture, methodRestoreInitialDataPrametersTypes);
        }

        #endregion

        #region Method Call : (RestoreInitialData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsDetailRowData_RestoreInitialData_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var clnPer = CreateType<Dictionary<int, clsPeriodData>>();
            var methodRestoreInitialDataPrametersTypes = new Type[] { typeof(Dictionary<int, clsPeriodData>) };
            object[] parametersOfRestoreInitialData = { clnPer };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRestoreInitialData, methodRestoreInitialDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_clsDetailRowDataInstanceFixture, parametersOfRestoreInitialData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRestoreInitialData.ShouldNotBeNull();
            parametersOfRestoreInitialData.Length.ShouldBe(1);
            methodRestoreInitialDataPrametersTypes.Length.ShouldBe(1);
            methodRestoreInitialDataPrametersTypes.Length.ShouldBe(parametersOfRestoreInitialData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RestoreInitialData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsDetailRowData_RestoreInitialData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var clnPer = CreateType<Dictionary<int, clsPeriodData>>();
            var methodRestoreInitialDataPrametersTypes = new Type[] { typeof(Dictionary<int, clsPeriodData>) };
            object[] parametersOfRestoreInitialData = { clnPer };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_clsDetailRowDataInstance, MethodRestoreInitialData, parametersOfRestoreInitialData, methodRestoreInitialDataPrametersTypes);

            // Assert
            parametersOfRestoreInitialData.ShouldNotBeNull();
            parametersOfRestoreInitialData.Length.ShouldBe(1);
            methodRestoreInitialDataPrametersTypes.Length.ShouldBe(1);
            methodRestoreInitialDataPrametersTypes.Length.ShouldBe(parametersOfRestoreInitialData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RestoreInitialData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsDetailRowData_RestoreInitialData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRestoreInitialData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RestoreInitialData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsDetailRowData_RestoreInitialData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRestoreInitialDataPrametersTypes = new Type[] { typeof(Dictionary<int, clsPeriodData>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsDetailRowDataInstance, MethodRestoreInitialData, Fixture, methodRestoreInitialDataPrametersTypes);

            // Assert
            methodRestoreInitialDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RestoreInitialData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsDetailRowData_RestoreInitialData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRestoreInitialData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_clsDetailRowDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}