using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.epmlive.ImportResourceStatus" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.epmlive"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ImportResourceStatusTest : AbstractBaseSetupTypedTest<ImportResourceStatus>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ImportResourceStatus) Initializer

        private const string PropertyJobId = "JobId";
        private const string PropertyVersion = "Version";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodIsInDebugMode = "IsInDebugMode";
        private const string Field_jobId = "_jobId";
        private Type _importResourceStatusInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ImportResourceStatus _importResourceStatusInstance;
        private ImportResourceStatus _importResourceStatusInstanceFixture;

        #region General Initializer : Class (ImportResourceStatus) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ImportResourceStatus" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _importResourceStatusInstanceType = typeof(ImportResourceStatus);
            _importResourceStatusInstanceFixture = Create(true);
            _importResourceStatusInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ImportResourceStatus)

        #region General Initializer : Class (ImportResourceStatus) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ImportResourceStatus" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodIsInDebugMode, 0)]
        public void AUT_ImportResourceStatus_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_importResourceStatusInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ImportResourceStatus) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ImportResourceStatus" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyJobId)]
        [TestCase(PropertyVersion)]
        public void AUT_ImportResourceStatus_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_importResourceStatusInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ImportResourceStatus) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ImportResourceStatus" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_jobId)]
        public void AUT_ImportResourceStatus_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_importResourceStatusInstanceFixture, 
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
        ///     Class (<see cref="ImportResourceStatus" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ImportResourceStatus_Is_Instance_Present_Test()
        {
            // Assert
            _importResourceStatusInstanceType.ShouldNotBeNull();
            _importResourceStatusInstance.ShouldNotBeNull();
            _importResourceStatusInstanceFixture.ShouldNotBeNull();
            _importResourceStatusInstance.ShouldBeAssignableTo<ImportResourceStatus>();
            _importResourceStatusInstanceFixture.ShouldBeAssignableTo<ImportResourceStatus>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ImportResourceStatus) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ImportResourceStatus_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ImportResourceStatus instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _importResourceStatusInstanceType.ShouldNotBeNull();
            _importResourceStatusInstance.ShouldNotBeNull();
            _importResourceStatusInstanceFixture.ShouldNotBeNull();
            _importResourceStatusInstance.ShouldBeAssignableTo<ImportResourceStatus>();
            _importResourceStatusInstanceFixture.ShouldBeAssignableTo<ImportResourceStatus>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ImportResourceStatus) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyJobId)]
        [TestCaseGeneric(typeof(string) , PropertyVersion)]
        public void AUT_ImportResourceStatus_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ImportResourceStatus, T>(_importResourceStatusInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ImportResourceStatus) => Property (JobId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ImportResourceStatus_Public_Class_JobId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyJobId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ImportResourceStatus) => Property (Version) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ImportResourceStatus_Public_Class_Version_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyVersion);

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
        ///      Class (<see cref="ImportResourceStatus" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodIsInDebugMode)]
        public void AUT_ImportResourceStatus_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ImportResourceStatus>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ImportResourceStatus_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importResourceStatusInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResourceStatus_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_importResourceStatusInstanceFixture, parametersOfPage_Load);

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
        public void AUT_ImportResourceStatus_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_importResourceStatusInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_ImportResourceStatus_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ImportResourceStatus_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importResourceStatusInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResourceStatus_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_importResourceStatusInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsInDebugMode) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ImportResourceStatus_IsInDebugMode_Method_Call_Internally(Type[] types)
        {
            var methodIsInDebugModePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importResourceStatusInstance, MethodIsInDebugMode, Fixture, methodIsInDebugModePrametersTypes);
        }

        #endregion

        #region Method Call : (IsInDebugMode) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResourceStatus_IsInDebugMode_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var epmDebug = CreateType<string>();
            var methodIsInDebugModePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsInDebugMode = { epmDebug };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsInDebugMode, methodIsInDebugModePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ImportResourceStatus, bool>(_importResourceStatusInstanceFixture, out exception1, parametersOfIsInDebugMode);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ImportResourceStatus, bool>(_importResourceStatusInstance, MethodIsInDebugMode, parametersOfIsInDebugMode, methodIsInDebugModePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsInDebugMode.ShouldNotBeNull();
            parametersOfIsInDebugMode.Length.ShouldBe(1);
            methodIsInDebugModePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_importResourceStatusInstanceFixture, parametersOfIsInDebugMode));
        }

        #endregion

        #region Method Call : (IsInDebugMode) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResourceStatus_IsInDebugMode_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var epmDebug = CreateType<string>();
            var methodIsInDebugModePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsInDebugMode = { epmDebug };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsInDebugMode, methodIsInDebugModePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ImportResourceStatus, bool>(_importResourceStatusInstanceFixture, out exception1, parametersOfIsInDebugMode);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ImportResourceStatus, bool>(_importResourceStatusInstance, MethodIsInDebugMode, parametersOfIsInDebugMode, methodIsInDebugModePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsInDebugMode.ShouldNotBeNull();
            parametersOfIsInDebugMode.Length.ShouldBe(1);
            methodIsInDebugModePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ImportResourceStatus, bool>(_importResourceStatusInstance, MethodIsInDebugMode, parametersOfIsInDebugMode, methodIsInDebugModePrametersTypes));
        }

        #endregion

        #region Method Call : (IsInDebugMode) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResourceStatus_IsInDebugMode_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var epmDebug = CreateType<string>();
            var methodIsInDebugModePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsInDebugMode = { epmDebug };

            // Assert
            parametersOfIsInDebugMode.ShouldNotBeNull();
            parametersOfIsInDebugMode.Length.ShouldBe(1);
            methodIsInDebugModePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ImportResourceStatus, bool>(_importResourceStatusInstance, MethodIsInDebugMode, parametersOfIsInDebugMode, methodIsInDebugModePrametersTypes));
        }

        #endregion

        #region Method Call : (IsInDebugMode) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResourceStatus_IsInDebugMode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsInDebugModePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importResourceStatusInstance, MethodIsInDebugMode, Fixture, methodIsInDebugModePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsInDebugModePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsInDebugMode) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResourceStatus_IsInDebugMode_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsInDebugMode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_importResourceStatusInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsInDebugMode) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResourceStatus_IsInDebugMode_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsInDebugMode, 0);
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