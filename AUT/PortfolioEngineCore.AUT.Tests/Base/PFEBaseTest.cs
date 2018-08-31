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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.PFEBase" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PFEBaseTest : AbstractBaseSetupTypedTest<PFEBase>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PFEBase) Initializer

        private const string PropertyStatus = "Status";
        private const string PropertyStatusText = "StatusText";
        private const string PropertyStackTrace = "StackTrace";
        private const string PropertyBasePath = "BasePath";
        private const string PropertyUserName = "UserName";
        private const string PropertyUserId = "UserId";
        private const string MethodPFEBaseCommon = "PFEBaseCommon";
        private const string MethodgetDebugInfo = "getDebugInfo";
        private const string MethodFormatErrorText = "FormatErrorText";
        private const string MethodDispose = "Dispose";
        private const string Field_PFECN = "_PFECN";
        private const string Field_basepath = "_basepath";
        private const string Field_company = "_company";
        private const string Field_dbcnstring = "_dbcnstring";
        private const string Field_debug = "_debug";
        private const string Field_pid = "_pid";
        private const string Field_username = "_username";
        private const string Fielddebug = "debug";
        private const string Field_userWResID = "_userWResID";
        private const string Field_port = "_port";
        private const string Field_session = "_session";
        private const string Field_dba = "_dba";
        private Type _pFEBaseInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PFEBase _pFEBaseInstance;
        private PFEBase _pFEBaseInstanceFixture;

        #region General Initializer : Class (PFEBase) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PFEBase" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _pFEBaseInstanceType = typeof(PFEBase);
            _pFEBaseInstanceFixture = Create(true);
            _pFEBaseInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PFEBase)

        #region General Initializer : Class (PFEBase) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="PFEBase" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPFEBaseCommon, 0)]
        [TestCase(MethodgetDebugInfo, 0)]
        [TestCase(MethodFormatErrorText, 0)]
        [TestCase(MethodDispose, 0)]
        public void AUT_PFEBase_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_pFEBaseInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PFEBase) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PFEBase" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyStatus)]
        [TestCase(PropertyStatusText)]
        [TestCase(PropertyStackTrace)]
        [TestCase(PropertyBasePath)]
        [TestCase(PropertyUserName)]
        [TestCase(PropertyUserId)]
        public void AUT_PFEBase_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_pFEBaseInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PFEBase) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PFEBase" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_PFECN)]
        [TestCase(Field_basepath)]
        [TestCase(Field_company)]
        [TestCase(Field_dbcnstring)]
        [TestCase(Field_debug)]
        [TestCase(Field_pid)]
        [TestCase(Field_username)]
        [TestCase(Fielddebug)]
        [TestCase(Field_userWResID)]
        [TestCase(Field_port)]
        [TestCase(Field_session)]
        [TestCase(Field_dba)]
        public void AUT_PFEBase_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_pFEBaseInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PFEBase) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="PFEBase" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_PFEBase_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<PFEBase>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (PFEBase) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="PFEBase" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PFEBase_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<PFEBase>(Fixture);
        }

        #endregion

        #region General Constructor : Class (PFEBase) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="PFEBase" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PFEBase_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var username = CreateType<string>();
            var pid = CreateType<string>();
            var company = CreateType<string>();
            var dbcnstring = CreateType<string>();
            var secLevel = CreateType<SecurityLevels>();
            var bDebug = CreateType<bool>();
            object[] parametersOfPFEBase = { basepath, username, pid, company, dbcnstring, secLevel, bDebug };
            var methodPFEBasePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_pFEBaseInstanceType, methodPFEBasePrametersTypes, parametersOfPFEBase);
        }

        #endregion

        #region General Constructor : Class (PFEBase) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="PFEBase" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PFEBase_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodPFEBasePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_pFEBaseInstanceType, Fixture, methodPFEBasePrametersTypes);
        }

        #endregion

        #region General Constructor : Class (PFEBase) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="PFEBase" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PFEBase_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var sBaseInfo = CreateType<string>();
            var secLevel = CreateType<SecurityLevels>();
            var bDebug = CreateType<bool>();
            object[] parametersOfPFEBase = { sBaseInfo, secLevel, bDebug };
            var methodPFEBasePrametersTypes = new Type[] { typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_pFEBaseInstanceType, methodPFEBasePrametersTypes, parametersOfPFEBase);
        }

        #endregion

        #region General Constructor : Class (PFEBase) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="PFEBase" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PFEBase_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodPFEBasePrametersTypes = new Type[] { typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_pFEBaseInstanceType, Fixture, methodPFEBasePrametersTypes);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PFEBase) => Property (BasePath) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PFEBase_Public_Class_BasePath_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyBasePath);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PFEBase) => Property (StackTrace) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PFEBase_Public_Class_StackTrace_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyStackTrace);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PFEBase) => Property (Status) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PFEBase_Public_Class_Status_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyStatus);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PFEBase) => Property (StatusText) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PFEBase_Public_Class_StatusText_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyStatusText);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PFEBase) => Property (UserId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PFEBase_Public_Class_UserId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUserId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PFEBase) => Property (UserName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PFEBase_Public_Class_UserName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUserName);

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
        ///      Class (<see cref="PFEBase" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPFEBaseCommon)]
        [TestCase(MethodgetDebugInfo)]
        [TestCase(MethodFormatErrorText)]
        [TestCase(MethodDispose)]
        public void AUT_PFEBase_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<PFEBase>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (PFEBaseCommon) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PFEBase_PFEBaseCommon_Method_Call_Internally(Type[] types)
        {
            var methodPFEBaseCommonPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEBaseInstance, MethodPFEBaseCommon, Fixture, methodPFEBaseCommonPrametersTypes);
        }

        #endregion

        #region Method Call : (PFEBaseCommon) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEBase_PFEBaseCommon_Method_Call_Void_With_7_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var username = CreateType<string>();
            var pid = CreateType<string>();
            var company = CreateType<string>();
            var dbcnstring = CreateType<string>();
            var secLevel = CreateType<SecurityLevels>();
            var bDebug = CreateType<bool>();
            var methodPFEBaseCommonPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };
            object[] parametersOfPFEBaseCommon = { basepath, username, pid, company, dbcnstring, secLevel, bDebug };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPFEBaseCommon, methodPFEBaseCommonPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_pFEBaseInstanceFixture, parametersOfPFEBaseCommon);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPFEBaseCommon.ShouldNotBeNull();
            parametersOfPFEBaseCommon.Length.ShouldBe(7);
            methodPFEBaseCommonPrametersTypes.Length.ShouldBe(7);
            methodPFEBaseCommonPrametersTypes.Length.ShouldBe(parametersOfPFEBaseCommon.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PFEBaseCommon) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEBase_PFEBaseCommon_Method_Call_Void_With_7_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var username = CreateType<string>();
            var pid = CreateType<string>();
            var company = CreateType<string>();
            var dbcnstring = CreateType<string>();
            var secLevel = CreateType<SecurityLevels>();
            var bDebug = CreateType<bool>();
            var methodPFEBaseCommonPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };
            object[] parametersOfPFEBaseCommon = { basepath, username, pid, company, dbcnstring, secLevel, bDebug };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_pFEBaseInstance, MethodPFEBaseCommon, parametersOfPFEBaseCommon, methodPFEBaseCommonPrametersTypes);

            // Assert
            parametersOfPFEBaseCommon.ShouldNotBeNull();
            parametersOfPFEBaseCommon.Length.ShouldBe(7);
            methodPFEBaseCommonPrametersTypes.Length.ShouldBe(7);
            methodPFEBaseCommonPrametersTypes.Length.ShouldBe(parametersOfPFEBaseCommon.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PFEBaseCommon) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEBase_PFEBaseCommon_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPFEBaseCommon, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PFEBaseCommon) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEBase_PFEBaseCommon_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPFEBaseCommonPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEBaseInstance, MethodPFEBaseCommon, Fixture, methodPFEBaseCommonPrametersTypes);

            // Assert
            methodPFEBaseCommonPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PFEBaseCommon) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEBase_PFEBaseCommon_Method_Call_With_7_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPFEBaseCommon, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_pFEBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getDebugInfo) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PFEBase_getDebugInfo_Method_Call_Internally(Type[] types)
        {
            var methodgetDebugInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEBaseInstance, MethodgetDebugInfo, Fixture, methodgetDebugInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (getDebugInfo) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEBase_getDebugInfo_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _pFEBaseInstance.getDebugInfo();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getDebugInfo) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEBase_getDebugInfo_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodgetDebugInfoPrametersTypes = null;
            object[] parametersOfgetDebugInfo = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetDebugInfo, methodgetDebugInfoPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PFEBase, string>(_pFEBaseInstanceFixture, out exception1, parametersOfgetDebugInfo);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PFEBase, string>(_pFEBaseInstance, MethodgetDebugInfo, parametersOfgetDebugInfo, methodgetDebugInfoPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetDebugInfo.ShouldBeNull();
            methodgetDebugInfoPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getDebugInfo) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEBase_getDebugInfo_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodgetDebugInfoPrametersTypes = null;
            object[] parametersOfgetDebugInfo = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PFEBase, string>(_pFEBaseInstance, MethodgetDebugInfo, parametersOfgetDebugInfo, methodgetDebugInfoPrametersTypes);

            // Assert
            parametersOfgetDebugInfo.ShouldBeNull();
            methodgetDebugInfoPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getDebugInfo) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEBase_getDebugInfo_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodgetDebugInfoPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEBaseInstance, MethodgetDebugInfo, Fixture, methodgetDebugInfoPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetDebugInfoPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getDebugInfo) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEBase_getDebugInfo_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodgetDebugInfoPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEBaseInstance, MethodgetDebugInfo, Fixture, methodgetDebugInfoPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetDebugInfoPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getDebugInfo) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEBase_getDebugInfo_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetDebugInfo, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_pFEBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FormatErrorText) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PFEBase_FormatErrorText_Method_Call_Internally(Type[] types)
        {
            var methodFormatErrorTextPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEBaseInstance, MethodFormatErrorText, Fixture, methodFormatErrorTextPrametersTypes);
        }

        #endregion

        #region Method Call : (FormatErrorText) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEBase_FormatErrorText_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _pFEBaseInstance.FormatErrorText();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (FormatErrorText) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEBase_FormatErrorText_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodFormatErrorTextPrametersTypes = null;
            object[] parametersOfFormatErrorText = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFormatErrorText, methodFormatErrorTextPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PFEBase, string>(_pFEBaseInstanceFixture, out exception1, parametersOfFormatErrorText);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PFEBase, string>(_pFEBaseInstance, MethodFormatErrorText, parametersOfFormatErrorText, methodFormatErrorTextPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfFormatErrorText.ShouldBeNull();
            methodFormatErrorTextPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FormatErrorText) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEBase_FormatErrorText_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodFormatErrorTextPrametersTypes = null;
            object[] parametersOfFormatErrorText = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PFEBase, string>(_pFEBaseInstance, MethodFormatErrorText, parametersOfFormatErrorText, methodFormatErrorTextPrametersTypes);

            // Assert
            parametersOfFormatErrorText.ShouldBeNull();
            methodFormatErrorTextPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FormatErrorText) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEBase_FormatErrorText_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodFormatErrorTextPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEBaseInstance, MethodFormatErrorText, Fixture, methodFormatErrorTextPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodFormatErrorTextPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FormatErrorText) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEBase_FormatErrorText_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodFormatErrorTextPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEBaseInstance, MethodFormatErrorText, Fixture, methodFormatErrorTextPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFormatErrorTextPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FormatErrorText) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEBase_FormatErrorText_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFormatErrorText, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_pFEBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PFEBase_Dispose_Method_Call_Internally(Type[] types)
        {
            var methodDisposePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEBaseInstance, MethodDispose, Fixture, methodDisposePrametersTypes);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEBase_Dispose_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _pFEBaseInstance.Dispose();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEBase_Dispose_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;
            object[] parametersOfDispose = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDispose, methodDisposePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_pFEBaseInstanceFixture, parametersOfDispose);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDispose.ShouldBeNull();
            methodDisposePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEBase_Dispose_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;
            object[] parametersOfDispose = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_pFEBaseInstance, MethodDispose, parametersOfDispose, methodDisposePrametersTypes);

            // Assert
            parametersOfDispose.ShouldBeNull();
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEBase_Dispose_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEBaseInstance, MethodDispose, Fixture, methodDisposePrametersTypes);

            // Assert
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEBase_Dispose_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDispose, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_pFEBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}