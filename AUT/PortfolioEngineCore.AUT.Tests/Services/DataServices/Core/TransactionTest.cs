using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace PortfolioEngineCore.Services.DataServices.Core
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.Services.DataServices.Core.Transaction" />)
    ///     and namespace <see cref="PortfolioEngineCore.Services.DataServices.Core"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class TransactionTest : AbstractBaseSetupTypedTest<Transaction>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Transaction) Initializer

        private const string PropertyActionKind = "ActionKind";
        private const string PropertyId = "Id";
        private const string PropertyLogger = "Logger";
        private const string PropertyModuleKind = "ModuleKind";
        private const string PropertyOnCanceled = "OnCanceled";
        private const string PropertyOnComplete = "OnComplete";
        private const string PropertyOnProgressed = "OnProgressed";
        private const string MethodCancel = "Cancel";
        private const string MethodComplete = "Complete";
        private const string MethodReportProgress = "ReportProgress";
        private const string Field_actionKind = "_actionKind";
        private const string Field_id = "_id";
        private const string Field_logger = "_logger";
        private const string Field_moduleKind = "_moduleKind";
        private Type _transactionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Transaction _transactionInstance;
        private Transaction _transactionInstanceFixture;

        #region General Initializer : Class (Transaction) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Transaction" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _transactionInstanceType = typeof(Transaction);
            _transactionInstanceFixture = Create(true);
            _transactionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Transaction)

        #region General Initializer : Class (Transaction) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Transaction" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodCancel, 0)]
        [TestCase(MethodComplete, 0)]
        [TestCase(MethodReportProgress, 0)]
        public void AUT_Transaction_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_transactionInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Transaction) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Transaction" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyActionKind)]
        [TestCase(PropertyId)]
        [TestCase(PropertyLogger)]
        [TestCase(PropertyModuleKind)]
        [TestCase(PropertyOnCanceled)]
        [TestCase(PropertyOnComplete)]
        [TestCase(PropertyOnProgressed)]
        public void AUT_Transaction_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_transactionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Transaction) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Transaction" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_actionKind)]
        [TestCase(Field_id)]
        [TestCase(Field_logger)]
        [TestCase(Field_moduleKind)]
        public void AUT_Transaction_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_transactionInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Transaction) => Property (ActionKind) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Transaction_ActionKind_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyActionKind);
            Action currentAction = () => propertyInfo.SetValue(_transactionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Transaction) => Property (ActionKind) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Transaction_Public_Class_ActionKind_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyActionKind);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Transaction) => Property (Id) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Transaction_Id_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyId);
            Action currentAction = () => propertyInfo.SetValue(_transactionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Transaction) => Property (Id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Transaction_Public_Class_Id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Transaction) => Property (Logger) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Transaction_Logger_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyLogger);
            Action currentAction = () => propertyInfo.SetValue(_transactionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Transaction) => Property (Logger) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Transaction_Public_Class_Logger_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLogger);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Transaction) => Property (ModuleKind) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Transaction_ModuleKind_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyModuleKind);
            Action currentAction = () => propertyInfo.SetValue(_transactionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Transaction) => Property (ModuleKind) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Transaction_Public_Class_ModuleKind_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyModuleKind);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Transaction) => Property (OnCanceled) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Transaction_Public_Class_OnCanceled_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyOnCanceled);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Transaction) => Property (OnComplete) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Transaction_Public_Class_OnComplete_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyOnComplete);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Transaction) => Property (OnProgressed) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Transaction_Public_Class_OnProgressed_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyOnProgressed);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Transaction" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCancel)]
        [TestCase(MethodComplete)]
        [TestCase(MethodReportProgress)]
        public void AUT_Transaction_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Transaction>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Cancel) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Transaction_Cancel_Method_Call_Internally(Type[] types)
        {
            var methodCancelPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_transactionInstance, MethodCancel, Fixture, methodCancelPrametersTypes);
        }

        #endregion

        #region Method Call : (Cancel) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Transaction_Cancel_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var methodCancelPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCancel = { message };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCancel, methodCancelPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_transactionInstanceFixture, parametersOfCancel);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCancel.ShouldNotBeNull();
            parametersOfCancel.Length.ShouldBe(1);
            methodCancelPrametersTypes.Length.ShouldBe(1);
            methodCancelPrametersTypes.Length.ShouldBe(parametersOfCancel.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Cancel) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Transaction_Cancel_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var methodCancelPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCancel = { message };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_transactionInstance, MethodCancel, parametersOfCancel, methodCancelPrametersTypes);

            // Assert
            parametersOfCancel.ShouldNotBeNull();
            parametersOfCancel.Length.ShouldBe(1);
            methodCancelPrametersTypes.Length.ShouldBe(1);
            methodCancelPrametersTypes.Length.ShouldBe(parametersOfCancel.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Cancel) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Transaction_Cancel_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCancel, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Cancel) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Transaction_Cancel_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCancelPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_transactionInstance, MethodCancel, Fixture, methodCancelPrametersTypes);

            // Assert
            methodCancelPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Cancel) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Transaction_Cancel_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCancel, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_transactionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Complete) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Transaction_Complete_Method_Call_Internally(Type[] types)
        {
            var methodCompletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_transactionInstance, MethodComplete, Fixture, methodCompletePrametersTypes);
        }

        #endregion

        #region Method Call : (Complete) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Transaction_Complete_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<object>();
            var methodCompletePrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfComplete = { data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodComplete, methodCompletePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_transactionInstanceFixture, parametersOfComplete);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfComplete.ShouldNotBeNull();
            parametersOfComplete.Length.ShouldBe(1);
            methodCompletePrametersTypes.Length.ShouldBe(1);
            methodCompletePrametersTypes.Length.ShouldBe(parametersOfComplete.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Complete) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Transaction_Complete_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<object>();
            var methodCompletePrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfComplete = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_transactionInstance, MethodComplete, parametersOfComplete, methodCompletePrametersTypes);

            // Assert
            parametersOfComplete.ShouldNotBeNull();
            parametersOfComplete.Length.ShouldBe(1);
            methodCompletePrametersTypes.Length.ShouldBe(1);
            methodCompletePrametersTypes.Length.ShouldBe(parametersOfComplete.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Complete) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Transaction_Complete_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodComplete, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Complete) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Transaction_Complete_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCompletePrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_transactionInstance, MethodComplete, Fixture, methodCompletePrametersTypes);

            // Assert
            methodCompletePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Complete) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Transaction_Complete_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodComplete, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_transactionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReportProgress) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Transaction_ReportProgress_Method_Call_Internally(Type[] types)
        {
            var methodReportProgressPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_transactionInstance, MethodReportProgress, Fixture, methodReportProgressPrametersTypes);
        }

        #endregion

        #region Method Call : (ReportProgress) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Transaction_ReportProgress_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var percentage = CreateType<decimal>();
            var methodReportProgressPrametersTypes = new Type[] { typeof(decimal) };
            object[] parametersOfReportProgress = { percentage };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReportProgress, methodReportProgressPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_transactionInstanceFixture, parametersOfReportProgress);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReportProgress.ShouldNotBeNull();
            parametersOfReportProgress.Length.ShouldBe(1);
            methodReportProgressPrametersTypes.Length.ShouldBe(1);
            methodReportProgressPrametersTypes.Length.ShouldBe(parametersOfReportProgress.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReportProgress) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Transaction_ReportProgress_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var percentage = CreateType<decimal>();
            var methodReportProgressPrametersTypes = new Type[] { typeof(decimal) };
            object[] parametersOfReportProgress = { percentage };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_transactionInstance, MethodReportProgress, parametersOfReportProgress, methodReportProgressPrametersTypes);

            // Assert
            parametersOfReportProgress.ShouldNotBeNull();
            parametersOfReportProgress.Length.ShouldBe(1);
            methodReportProgressPrametersTypes.Length.ShouldBe(1);
            methodReportProgressPrametersTypes.Length.ShouldBe(parametersOfReportProgress.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReportProgress) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Transaction_ReportProgress_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReportProgress, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReportProgress) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Transaction_ReportProgress_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReportProgressPrametersTypes = new Type[] { typeof(decimal) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_transactionInstance, MethodReportProgress, Fixture, methodReportProgressPrametersTypes);

            // Assert
            methodReportProgressPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReportProgress) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Transaction_ReportProgress_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReportProgress, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_transactionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}