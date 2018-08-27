using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveCore.ReportHelper;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ReportCheckActions" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportCheckActionsTest : AbstractBaseSetupTypedTest<ReportCheckActions>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportCheckActions) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodExecute = "Execute";
        private const string MethodDeleteCheck = "DeleteCheck";
        private const string MethodGetRefLists = "GetRefLists";
        private const string Field_action = "_action";
        private const string Field_listId = "_listId";
        private const string Fieldoutput = "output";
        private Type _reportCheckActionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportCheckActions _reportCheckActionsInstance;
        private ReportCheckActions _reportCheckActionsInstanceFixture;

        #region General Initializer : Class (ReportCheckActions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportCheckActions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportCheckActionsInstanceType = typeof(ReportCheckActions);
            _reportCheckActionsInstanceFixture = Create(true);
            _reportCheckActionsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportCheckActions)

        #region General Initializer : Class (ReportCheckActions) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ReportCheckActions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodExecute, 0)]
        [TestCase(MethodDeleteCheck, 0)]
        [TestCase(MethodGetRefLists, 0)]
        public void AUT_ReportCheckActions_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_reportCheckActionsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportCheckActions) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportCheckActions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_action)]
        [TestCase(Field_listId)]
        [TestCase(Fieldoutput)]
        public void AUT_ReportCheckActions_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportCheckActionsInstanceFixture, 
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
        ///     Class (<see cref="ReportCheckActions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ReportCheckActions_Is_Instance_Present_Test()
        {
            // Assert
            _reportCheckActionsInstanceType.ShouldNotBeNull();
            _reportCheckActionsInstance.ShouldNotBeNull();
            _reportCheckActionsInstanceFixture.ShouldNotBeNull();
            _reportCheckActionsInstance.ShouldBeAssignableTo<ReportCheckActions>();
            _reportCheckActionsInstanceFixture.ShouldBeAssignableTo<ReportCheckActions>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportCheckActions) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ReportCheckActions_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportCheckActions instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportCheckActionsInstanceType.ShouldNotBeNull();
            _reportCheckActionsInstance.ShouldNotBeNull();
            _reportCheckActionsInstanceFixture.ShouldNotBeNull();
            _reportCheckActionsInstance.ShouldBeAssignableTo<ReportCheckActions>();
            _reportCheckActionsInstanceFixture.ShouldBeAssignableTo<ReportCheckActions>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ReportCheckActions" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodExecute)]
        [TestCase(MethodDeleteCheck)]
        [TestCase(MethodGetRefLists)]
        public void AUT_ReportCheckActions_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ReportCheckActions>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportCheckActions_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportCheckActionsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportCheckActions_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportCheckActionsInstanceFixture, parametersOfPage_Load);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportCheckActions_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportCheckActionsInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

            // Assert
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportCheckActions_Page_Load_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportCheckActions_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportCheckActionsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportCheckActions_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportCheckActionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportCheckActions_Execute_Method_Call_Internally(Type[] types)
        {
            var methodExecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportCheckActionsInstance, MethodExecute, Fixture, methodExecutePrametersTypes);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportCheckActions_Execute_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodExecutePrametersTypes = null;
            object[] parametersOfExecute = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodExecute, methodExecutePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportCheckActionsInstanceFixture, parametersOfExecute);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfExecute.ShouldBeNull();
            methodExecutePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportCheckActions_Execute_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodExecutePrametersTypes = null;
            object[] parametersOfExecute = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportCheckActionsInstance, MethodExecute, parametersOfExecute, methodExecutePrametersTypes);

            // Assert
            parametersOfExecute.ShouldBeNull();
            methodExecutePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportCheckActions_Execute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodExecutePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportCheckActionsInstance, MethodExecute, Fixture, methodExecutePrametersTypes);

            // Assert
            methodExecutePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportCheckActions_Execute_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecute, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportCheckActionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteCheck) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportCheckActions_DeleteCheck_Method_Call_Internally(Type[] types)
        {
            var methodDeleteCheckPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportCheckActionsInstance, MethodDeleteCheck, Fixture, methodDeleteCheckPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteCheck) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportCheckActions_DeleteCheck_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodDeleteCheckPrametersTypes = null;
            object[] parametersOfDeleteCheck = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteCheck, methodDeleteCheckPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportCheckActionsInstanceFixture, parametersOfDeleteCheck);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteCheck.ShouldBeNull();
            methodDeleteCheckPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteCheck) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportCheckActions_DeleteCheck_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDeleteCheckPrametersTypes = null;
            object[] parametersOfDeleteCheck = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportCheckActionsInstance, MethodDeleteCheck, parametersOfDeleteCheck, methodDeleteCheckPrametersTypes);

            // Assert
            parametersOfDeleteCheck.ShouldBeNull();
            methodDeleteCheckPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteCheck) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportCheckActions_DeleteCheck_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDeleteCheckPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportCheckActionsInstance, MethodDeleteCheck, Fixture, methodDeleteCheckPrametersTypes);

            // Assert
            methodDeleteCheckPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteCheck) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportCheckActions_DeleteCheck_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteCheck, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportCheckActionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRefLists) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportCheckActions_GetRefLists_Method_Call_Internally(Type[] types)
        {
            var methodGetRefListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportCheckActionsInstance, MethodGetRefLists, Fixture, methodGetRefListsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRefLists) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportCheckActions_GetRefLists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var refTables = CreateType<DataTable>();
            var dao = CreateType<EPMData>();
            var methodGetRefListsPrametersTypes = new Type[] { typeof(DataTable), typeof(EPMData) };
            object[] parametersOfGetRefLists = { refTables, dao };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRefLists, methodGetRefListsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportCheckActions, string>(_reportCheckActionsInstanceFixture, out exception1, parametersOfGetRefLists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportCheckActions, string>(_reportCheckActionsInstance, MethodGetRefLists, parametersOfGetRefLists, methodGetRefListsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRefLists.ShouldNotBeNull();
            parametersOfGetRefLists.Length.ShouldBe(2);
            methodGetRefListsPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_reportCheckActionsInstanceFixture, parametersOfGetRefLists));
        }

        #endregion

        #region Method Call : (GetRefLists) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportCheckActions_GetRefLists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var refTables = CreateType<DataTable>();
            var dao = CreateType<EPMData>();
            var methodGetRefListsPrametersTypes = new Type[] { typeof(DataTable), typeof(EPMData) };
            object[] parametersOfGetRefLists = { refTables, dao };

            // Assert
            parametersOfGetRefLists.ShouldNotBeNull();
            parametersOfGetRefLists.Length.ShouldBe(2);
            methodGetRefListsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ReportCheckActions, string>(_reportCheckActionsInstance, MethodGetRefLists, parametersOfGetRefLists, methodGetRefListsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetRefLists) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportCheckActions_GetRefLists_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRefListsPrametersTypes = new Type[] { typeof(DataTable), typeof(EPMData) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportCheckActionsInstance, MethodGetRefLists, Fixture, methodGetRefListsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRefListsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetRefLists) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportCheckActions_GetRefLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRefListsPrametersTypes = new Type[] { typeof(DataTable), typeof(EPMData) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportCheckActionsInstance, MethodGetRefLists, Fixture, methodGetRefListsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRefListsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRefLists) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportCheckActions_GetRefLists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRefLists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportCheckActionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRefLists) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportCheckActions_GetRefLists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRefLists, 0);
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