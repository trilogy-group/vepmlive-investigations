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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.CapacityScenarios" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class CapacityScenariosTest : AbstractBaseSetupTypedTest<CapacityScenarios>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CapacityScenarios) Initializer

        private const string MethodRoleBasedCSAllowed = "RoleBasedCSAllowed";
        private const string MethodGetCapacityScenariosXML = "GetCapacityScenariosXML";
        private const string MethodDeleteCapacityScenario = "DeleteCapacityScenario";
        private const string MethodAddCapacityScenarioXML = "AddCapacityScenarioXML";
        private const string MethodGetCapacityScenarioValuesXML = "GetCapacityScenarioValuesXML";
        private const string MethodSaveCapacityScenario = "SaveCapacityScenario";
        private const string MethodSaveCapacityScenarioData = "SaveCapacityScenarioData";
        private const string MethodSaveCurrentScenarioData = "SaveCurrentScenarioData";
        private const string MethodGetListTicket = "GetListTicket";
        private const string MethodPrivateAllowed = "PrivateAllowed";
        private const string Field_sqlConnection = "_sqlConnection";
        private Type _capacityScenariosInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CapacityScenarios _capacityScenariosInstance;
        private CapacityScenarios _capacityScenariosInstanceFixture;

        #region General Initializer : Class (CapacityScenarios) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CapacityScenarios" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _capacityScenariosInstanceType = typeof(CapacityScenarios);
            _capacityScenariosInstanceFixture = Create(true);
            _capacityScenariosInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CapacityScenarios)

        #region General Initializer : Class (CapacityScenarios) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CapacityScenarios" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRoleBasedCSAllowed, 0)]
        [TestCase(MethodGetCapacityScenariosXML, 0)]
        [TestCase(MethodDeleteCapacityScenario, 0)]
        [TestCase(MethodAddCapacityScenarioXML, 0)]
        [TestCase(MethodGetCapacityScenarioValuesXML, 0)]
        [TestCase(MethodSaveCapacityScenario, 0)]
        [TestCase(MethodSaveCapacityScenarioData, 0)]
        [TestCase(MethodSaveCurrentScenarioData, 0)]
        [TestCase(MethodGetListTicket, 0)]
        [TestCase(MethodPrivateAllowed, 0)]
        public void AUT_CapacityScenarios_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_capacityScenariosInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CapacityScenarios) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CapacityScenarios" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_sqlConnection)]
        public void AUT_CapacityScenarios_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_capacityScenariosInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CapacityScenarios) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="CapacityScenarios" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_CapacityScenarios_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<CapacityScenarios>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (CapacityScenarios) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="CapacityScenarios" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_CapacityScenarios_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<CapacityScenarios>(Fixture);
        }

        #endregion

        #region General Constructor : Class (CapacityScenarios) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="CapacityScenarios" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_CapacityScenarios_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var username = CreateType<string>();
            var pid = CreateType<string>();
            var company = CreateType<string>();
            var dbcnstring = CreateType<string>();
            var secLevel = CreateType<SecurityLevels>();
            var bDebug = CreateType<bool>();
            object[] parametersOfCapacityScenarios = { basepath, username, pid, company, dbcnstring, secLevel, bDebug };
            var methodCapacityScenariosPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_capacityScenariosInstanceType, methodCapacityScenariosPrametersTypes, parametersOfCapacityScenarios);
        }

        #endregion

        #region General Constructor : Class (CapacityScenarios) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="CapacityScenarios" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_CapacityScenarios_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodCapacityScenariosPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_capacityScenariosInstanceType, Fixture, methodCapacityScenariosPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (CapacityScenarios) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="CapacityScenarios" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_CapacityScenarios_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var sBaseInfo = CreateType<string>();
            object[] parametersOfCapacityScenarios = { sBaseInfo };
            var methodCapacityScenariosPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_capacityScenariosInstanceType, methodCapacityScenariosPrametersTypes, parametersOfCapacityScenarios);
        }

        #endregion

        #region General Constructor : Class (CapacityScenarios) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="CapacityScenarios" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_CapacityScenarios_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodCapacityScenariosPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_capacityScenariosInstanceType, Fixture, methodCapacityScenariosPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="CapacityScenarios" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodRoleBasedCSAllowed)]
        [TestCase(MethodGetCapacityScenariosXML)]
        [TestCase(MethodDeleteCapacityScenario)]
        [TestCase(MethodAddCapacityScenarioXML)]
        [TestCase(MethodGetCapacityScenarioValuesXML)]
        [TestCase(MethodSaveCapacityScenario)]
        [TestCase(MethodSaveCapacityScenarioData)]
        [TestCase(MethodSaveCurrentScenarioData)]
        [TestCase(MethodGetListTicket)]
        [TestCase(MethodPrivateAllowed)]
        public void AUT_CapacityScenarios_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CapacityScenarios>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (RoleBasedCSAllowed) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CapacityScenarios_RoleBasedCSAllowed_Method_Call_Internally(Type[] types)
        {
            var methodRoleBasedCSAllowedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityScenariosInstance, MethodRoleBasedCSAllowed, Fixture, methodRoleBasedCSAllowedPrametersTypes);
        }

        #endregion

        #region Method Call : (RoleBasedCSAllowed) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_RoleBasedCSAllowed_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _capacityScenariosInstance.RoleBasedCSAllowed();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RoleBasedCSAllowed) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_RoleBasedCSAllowed_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodRoleBasedCSAllowedPrametersTypes = null;
            object[] parametersOfRoleBasedCSAllowed = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRoleBasedCSAllowed, methodRoleBasedCSAllowedPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CapacityScenarios, bool>(_capacityScenariosInstanceFixture, out exception1, parametersOfRoleBasedCSAllowed);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodRoleBasedCSAllowed, parametersOfRoleBasedCSAllowed, methodRoleBasedCSAllowedPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRoleBasedCSAllowed.ShouldBeNull();
            methodRoleBasedCSAllowedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RoleBasedCSAllowed) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_RoleBasedCSAllowed_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodRoleBasedCSAllowedPrametersTypes = null;
            object[] parametersOfRoleBasedCSAllowed = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRoleBasedCSAllowed, methodRoleBasedCSAllowedPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CapacityScenarios, bool>(_capacityScenariosInstanceFixture, out exception1, parametersOfRoleBasedCSAllowed);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodRoleBasedCSAllowed, parametersOfRoleBasedCSAllowed, methodRoleBasedCSAllowedPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRoleBasedCSAllowed.ShouldBeNull();
            methodRoleBasedCSAllowedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RoleBasedCSAllowed) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_RoleBasedCSAllowed_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRoleBasedCSAllowedPrametersTypes = null;
            object[] parametersOfRoleBasedCSAllowed = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodRoleBasedCSAllowed, parametersOfRoleBasedCSAllowed, methodRoleBasedCSAllowedPrametersTypes);

            // Assert
            parametersOfRoleBasedCSAllowed.ShouldBeNull();
            methodRoleBasedCSAllowedPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RoleBasedCSAllowed) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_RoleBasedCSAllowed_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRoleBasedCSAllowedPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityScenariosInstance, MethodRoleBasedCSAllowed, Fixture, methodRoleBasedCSAllowedPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRoleBasedCSAllowedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RoleBasedCSAllowed) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_RoleBasedCSAllowed_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRoleBasedCSAllowed, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityScenariosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCapacityScenariosXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CapacityScenarios_GetCapacityScenariosXML_Method_Call_Internally(Type[] types)
        {
            var methodGetCapacityScenariosXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityScenariosInstance, MethodGetCapacityScenariosXML, Fixture, methodGetCapacityScenariosXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCapacityScenariosXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_GetCapacityScenariosXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var CSRoleAllowed = CreateType<bool>();
            var DeptUIDs = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _capacityScenariosInstance.GetCapacityScenariosXML(out sReply, CSRoleAllowed, DeptUIDs);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCapacityScenariosXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_GetCapacityScenariosXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var CSRoleAllowed = CreateType<bool>();
            var DeptUIDs = CreateType<string>();
            var methodGetCapacityScenariosXMLPrametersTypes = new Type[] { typeof(string), typeof(bool), typeof(string) };
            object[] parametersOfGetCapacityScenariosXML = { sReply, CSRoleAllowed, DeptUIDs };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCapacityScenariosXML, methodGetCapacityScenariosXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CapacityScenarios, bool>(_capacityScenariosInstanceFixture, out exception1, parametersOfGetCapacityScenariosXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodGetCapacityScenariosXML, parametersOfGetCapacityScenariosXML, methodGetCapacityScenariosXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetCapacityScenariosXML.ShouldNotBeNull();
            parametersOfGetCapacityScenariosXML.Length.ShouldBe(3);
            methodGetCapacityScenariosXMLPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetCapacityScenariosXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_GetCapacityScenariosXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var CSRoleAllowed = CreateType<bool>();
            var DeptUIDs = CreateType<string>();
            var methodGetCapacityScenariosXMLPrametersTypes = new Type[] { typeof(string), typeof(bool), typeof(string) };
            object[] parametersOfGetCapacityScenariosXML = { sReply, CSRoleAllowed, DeptUIDs };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCapacityScenariosXML, methodGetCapacityScenariosXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CapacityScenarios, bool>(_capacityScenariosInstanceFixture, out exception1, parametersOfGetCapacityScenariosXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodGetCapacityScenariosXML, parametersOfGetCapacityScenariosXML, methodGetCapacityScenariosXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetCapacityScenariosXML.ShouldNotBeNull();
            parametersOfGetCapacityScenariosXML.Length.ShouldBe(3);
            methodGetCapacityScenariosXMLPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetCapacityScenariosXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_GetCapacityScenariosXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var CSRoleAllowed = CreateType<bool>();
            var DeptUIDs = CreateType<string>();
            var methodGetCapacityScenariosXMLPrametersTypes = new Type[] { typeof(string), typeof(bool), typeof(string) };
            object[] parametersOfGetCapacityScenariosXML = { sReply, CSRoleAllowed, DeptUIDs };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodGetCapacityScenariosXML, parametersOfGetCapacityScenariosXML, methodGetCapacityScenariosXMLPrametersTypes);

            // Assert
            parametersOfGetCapacityScenariosXML.ShouldNotBeNull();
            parametersOfGetCapacityScenariosXML.Length.ShouldBe(3);
            methodGetCapacityScenariosXMLPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCapacityScenariosXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_GetCapacityScenariosXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCapacityScenariosXMLPrametersTypes = new Type[] { typeof(string), typeof(bool), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityScenariosInstance, MethodGetCapacityScenariosXML, Fixture, methodGetCapacityScenariosXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCapacityScenariosXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCapacityScenariosXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_GetCapacityScenariosXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCapacityScenariosXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityScenariosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCapacityScenariosXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_GetCapacityScenariosXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCapacityScenariosXML, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteCapacityScenario) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CapacityScenarios_DeleteCapacityScenario_Method_Call_Internally(Type[] types)
        {
            var methodDeleteCapacityScenarioPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityScenariosInstance, MethodDeleteCapacityScenario, Fixture, methodDeleteCapacityScenarioPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteCapacityScenario) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_DeleteCapacityScenario_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var iCapacityID = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _capacityScenariosInstance.DeleteCapacityScenario(iCapacityID);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteCapacityScenario) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_DeleteCapacityScenario_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var iCapacityID = CreateType<int>();
            var methodDeleteCapacityScenarioPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeleteCapacityScenario = { iCapacityID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteCapacityScenario, methodDeleteCapacityScenarioPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CapacityScenarios, bool>(_capacityScenariosInstanceFixture, out exception1, parametersOfDeleteCapacityScenario);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodDeleteCapacityScenario, parametersOfDeleteCapacityScenario, methodDeleteCapacityScenarioPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteCapacityScenario.ShouldNotBeNull();
            parametersOfDeleteCapacityScenario.Length.ShouldBe(1);
            methodDeleteCapacityScenarioPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteCapacityScenario) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_DeleteCapacityScenario_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var iCapacityID = CreateType<int>();
            var methodDeleteCapacityScenarioPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeleteCapacityScenario = { iCapacityID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteCapacityScenario, methodDeleteCapacityScenarioPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CapacityScenarios, bool>(_capacityScenariosInstanceFixture, out exception1, parametersOfDeleteCapacityScenario);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodDeleteCapacityScenario, parametersOfDeleteCapacityScenario, methodDeleteCapacityScenarioPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteCapacityScenario.ShouldNotBeNull();
            parametersOfDeleteCapacityScenario.Length.ShouldBe(1);
            methodDeleteCapacityScenarioPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteCapacityScenario) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_DeleteCapacityScenario_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var iCapacityID = CreateType<int>();
            var methodDeleteCapacityScenarioPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeleteCapacityScenario = { iCapacityID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodDeleteCapacityScenario, parametersOfDeleteCapacityScenario, methodDeleteCapacityScenarioPrametersTypes);

            // Assert
            parametersOfDeleteCapacityScenario.ShouldNotBeNull();
            parametersOfDeleteCapacityScenario.Length.ShouldBe(1);
            methodDeleteCapacityScenarioPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteCapacityScenario) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_DeleteCapacityScenario_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteCapacityScenarioPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityScenariosInstance, MethodDeleteCapacityScenario, Fixture, methodDeleteCapacityScenarioPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteCapacityScenarioPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteCapacityScenario) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_DeleteCapacityScenario_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteCapacityScenario, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityScenariosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteCapacityScenario) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_DeleteCapacityScenario_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteCapacityScenario, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddCapacityScenarioXML) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CapacityScenarios_AddCapacityScenarioXML_Method_Call_Internally(Type[] types)
        {
            var methodAddCapacityScenarioXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityScenariosInstance, MethodAddCapacityScenarioXML, Fixture, methodAddCapacityScenarioXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (AddCapacityScenarioXML) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_AddCapacityScenarioXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sScenarioName = CreateType<string>();
            var bPriv = CreateType<bool>();
            var deptID = CreateType<int>();
            var rmode = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _capacityScenariosInstance.AddCapacityScenarioXML(sScenarioName, bPriv, deptID, rmode);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddCapacityScenarioXML) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_AddCapacityScenarioXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sScenarioName = CreateType<string>();
            var bPriv = CreateType<bool>();
            var deptID = CreateType<int>();
            var rmode = CreateType<int>();
            var methodAddCapacityScenarioXMLPrametersTypes = new Type[] { typeof(string), typeof(bool), typeof(int), typeof(int) };
            object[] parametersOfAddCapacityScenarioXML = { sScenarioName, bPriv, deptID, rmode };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddCapacityScenarioXML, methodAddCapacityScenarioXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CapacityScenarios, int>(_capacityScenariosInstanceFixture, out exception1, parametersOfAddCapacityScenarioXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, int>(_capacityScenariosInstance, MethodAddCapacityScenarioXML, parametersOfAddCapacityScenarioXML, methodAddCapacityScenarioXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAddCapacityScenarioXML.ShouldNotBeNull();
            parametersOfAddCapacityScenarioXML.Length.ShouldBe(4);
            methodAddCapacityScenarioXMLPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (AddCapacityScenarioXML) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_AddCapacityScenarioXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sScenarioName = CreateType<string>();
            var bPriv = CreateType<bool>();
            var deptID = CreateType<int>();
            var rmode = CreateType<int>();
            var methodAddCapacityScenarioXMLPrametersTypes = new Type[] { typeof(string), typeof(bool), typeof(int), typeof(int) };
            object[] parametersOfAddCapacityScenarioXML = { sScenarioName, bPriv, deptID, rmode };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddCapacityScenarioXML, methodAddCapacityScenarioXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CapacityScenarios, int>(_capacityScenariosInstanceFixture, out exception1, parametersOfAddCapacityScenarioXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, int>(_capacityScenariosInstance, MethodAddCapacityScenarioXML, parametersOfAddCapacityScenarioXML, methodAddCapacityScenarioXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAddCapacityScenarioXML.ShouldNotBeNull();
            parametersOfAddCapacityScenarioXML.Length.ShouldBe(4);
            methodAddCapacityScenarioXMLPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (AddCapacityScenarioXML) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_AddCapacityScenarioXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sScenarioName = CreateType<string>();
            var bPriv = CreateType<bool>();
            var deptID = CreateType<int>();
            var rmode = CreateType<int>();
            var methodAddCapacityScenarioXMLPrametersTypes = new Type[] { typeof(string), typeof(bool), typeof(int), typeof(int) };
            object[] parametersOfAddCapacityScenarioXML = { sScenarioName, bPriv, deptID, rmode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, int>(_capacityScenariosInstance, MethodAddCapacityScenarioXML, parametersOfAddCapacityScenarioXML, methodAddCapacityScenarioXMLPrametersTypes);

            // Assert
            parametersOfAddCapacityScenarioXML.ShouldNotBeNull();
            parametersOfAddCapacityScenarioXML.Length.ShouldBe(4);
            methodAddCapacityScenarioXMLPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddCapacityScenarioXML) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_AddCapacityScenarioXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddCapacityScenarioXMLPrametersTypes = new Type[] { typeof(string), typeof(bool), typeof(int), typeof(int) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityScenariosInstance, MethodAddCapacityScenarioXML, Fixture, methodAddCapacityScenarioXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddCapacityScenarioXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddCapacityScenarioXML) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_AddCapacityScenarioXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddCapacityScenarioXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityScenariosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddCapacityScenarioXML) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_AddCapacityScenarioXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddCapacityScenarioXML, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioValuesXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CapacityScenarios_GetCapacityScenarioValuesXML_Method_Call_Internally(Type[] types)
        {
            var methodGetCapacityScenarioValuesXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityScenariosInstance, MethodGetCapacityScenarioValuesXML, Fixture, methodGetCapacityScenarioValuesXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioValuesXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_GetCapacityScenarioValuesXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var iCapacityID = CreateType<int>();
            var sReply = CreateType<string>();
            var statusvalue = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _capacityScenariosInstance.GetCapacityScenarioValuesXML(iCapacityID, out sReply, out statusvalue);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioValuesXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_GetCapacityScenarioValuesXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var iCapacityID = CreateType<int>();
            var sReply = CreateType<string>();
            var statusvalue = CreateType<int>();
            var methodGetCapacityScenarioValuesXMLPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(int) };
            object[] parametersOfGetCapacityScenarioValuesXML = { iCapacityID, sReply, statusvalue };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCapacityScenarioValuesXML, methodGetCapacityScenarioValuesXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CapacityScenarios, bool>(_capacityScenariosInstanceFixture, out exception1, parametersOfGetCapacityScenarioValuesXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodGetCapacityScenarioValuesXML, parametersOfGetCapacityScenarioValuesXML, methodGetCapacityScenarioValuesXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetCapacityScenarioValuesXML.ShouldNotBeNull();
            parametersOfGetCapacityScenarioValuesXML.Length.ShouldBe(3);
            methodGetCapacityScenarioValuesXMLPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioValuesXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_GetCapacityScenarioValuesXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var iCapacityID = CreateType<int>();
            var sReply = CreateType<string>();
            var statusvalue = CreateType<int>();
            var methodGetCapacityScenarioValuesXMLPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(int) };
            object[] parametersOfGetCapacityScenarioValuesXML = { iCapacityID, sReply, statusvalue };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCapacityScenarioValuesXML, methodGetCapacityScenarioValuesXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CapacityScenarios, bool>(_capacityScenariosInstanceFixture, out exception1, parametersOfGetCapacityScenarioValuesXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodGetCapacityScenarioValuesXML, parametersOfGetCapacityScenarioValuesXML, methodGetCapacityScenarioValuesXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetCapacityScenarioValuesXML.ShouldNotBeNull();
            parametersOfGetCapacityScenarioValuesXML.Length.ShouldBe(3);
            methodGetCapacityScenarioValuesXMLPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioValuesXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_GetCapacityScenarioValuesXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var iCapacityID = CreateType<int>();
            var sReply = CreateType<string>();
            var statusvalue = CreateType<int>();
            var methodGetCapacityScenarioValuesXMLPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(int) };
            object[] parametersOfGetCapacityScenarioValuesXML = { iCapacityID, sReply, statusvalue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodGetCapacityScenarioValuesXML, parametersOfGetCapacityScenarioValuesXML, methodGetCapacityScenarioValuesXMLPrametersTypes);

            // Assert
            parametersOfGetCapacityScenarioValuesXML.ShouldNotBeNull();
            parametersOfGetCapacityScenarioValuesXML.Length.ShouldBe(3);
            methodGetCapacityScenarioValuesXMLPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioValuesXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_GetCapacityScenarioValuesXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCapacityScenarioValuesXMLPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(int) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityScenariosInstance, MethodGetCapacityScenarioValuesXML, Fixture, methodGetCapacityScenarioValuesXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCapacityScenarioValuesXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioValuesXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_GetCapacityScenarioValuesXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCapacityScenarioValuesXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityScenariosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCapacityScenarioValuesXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_GetCapacityScenarioValuesXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCapacityScenarioValuesXML, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCapacityScenario) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CapacityScenarios_SaveCapacityScenario_Method_Call_Internally(Type[] types)
        {
            var methodSaveCapacityScenarioPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityScenariosInstance, MethodSaveCapacityScenario, Fixture, methodSaveCapacityScenarioPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveCapacityScenario) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_SaveCapacityScenario_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var iCapacityID = CreateType<int>();
            var sXLMDataIn = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _capacityScenariosInstance.SaveCapacityScenario(iCapacityID, sXLMDataIn);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveCapacityScenario) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_SaveCapacityScenario_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var iCapacityID = CreateType<int>();
            var sXLMDataIn = CreateType<string>();
            var methodSaveCapacityScenarioPrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfSaveCapacityScenario = { iCapacityID, sXLMDataIn };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveCapacityScenario, methodSaveCapacityScenarioPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CapacityScenarios, bool>(_capacityScenariosInstanceFixture, out exception1, parametersOfSaveCapacityScenario);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodSaveCapacityScenario, parametersOfSaveCapacityScenario, methodSaveCapacityScenarioPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveCapacityScenario.ShouldNotBeNull();
            parametersOfSaveCapacityScenario.Length.ShouldBe(2);
            methodSaveCapacityScenarioPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SaveCapacityScenario) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_SaveCapacityScenario_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var iCapacityID = CreateType<int>();
            var sXLMDataIn = CreateType<string>();
            var methodSaveCapacityScenarioPrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfSaveCapacityScenario = { iCapacityID, sXLMDataIn };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveCapacityScenario, methodSaveCapacityScenarioPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CapacityScenarios, bool>(_capacityScenariosInstanceFixture, out exception1, parametersOfSaveCapacityScenario);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodSaveCapacityScenario, parametersOfSaveCapacityScenario, methodSaveCapacityScenarioPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveCapacityScenario.ShouldNotBeNull();
            parametersOfSaveCapacityScenario.Length.ShouldBe(2);
            methodSaveCapacityScenarioPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SaveCapacityScenario) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_SaveCapacityScenario_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var iCapacityID = CreateType<int>();
            var sXLMDataIn = CreateType<string>();
            var methodSaveCapacityScenarioPrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfSaveCapacityScenario = { iCapacityID, sXLMDataIn };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodSaveCapacityScenario, parametersOfSaveCapacityScenario, methodSaveCapacityScenarioPrametersTypes);

            // Assert
            parametersOfSaveCapacityScenario.ShouldNotBeNull();
            parametersOfSaveCapacityScenario.Length.ShouldBe(2);
            methodSaveCapacityScenarioPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveCapacityScenario) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_SaveCapacityScenario_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveCapacityScenarioPrametersTypes = new Type[] { typeof(int), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityScenariosInstance, MethodSaveCapacityScenario, Fixture, methodSaveCapacityScenarioPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveCapacityScenarioPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCapacityScenario) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_SaveCapacityScenario_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveCapacityScenario, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityScenariosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveCapacityScenario) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_SaveCapacityScenario_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveCapacityScenario, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCapacityScenarioData) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CapacityScenarios_SaveCapacityScenarioData_Method_Call_Internally(Type[] types)
        {
            var methodSaveCapacityScenarioDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityScenariosInstance, MethodSaveCapacityScenarioData, Fixture, methodSaveCapacityScenarioDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveCapacityScenarioData) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_SaveCapacityScenarioData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sCSDataXML = CreateType<string>();
            var sReply = CreateType<string>();
            var statusvalue = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _capacityScenariosInstance.SaveCapacityScenarioData(sCSDataXML, out sReply, out statusvalue);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveCapacityScenarioData) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_SaveCapacityScenarioData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sCSDataXML = CreateType<string>();
            var sReply = CreateType<string>();
            var statusvalue = CreateType<int>();
            var methodSaveCapacityScenarioDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int) };
            object[] parametersOfSaveCapacityScenarioData = { sCSDataXML, sReply, statusvalue };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveCapacityScenarioData, methodSaveCapacityScenarioDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CapacityScenarios, bool>(_capacityScenariosInstanceFixture, out exception1, parametersOfSaveCapacityScenarioData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodSaveCapacityScenarioData, parametersOfSaveCapacityScenarioData, methodSaveCapacityScenarioDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveCapacityScenarioData.ShouldNotBeNull();
            parametersOfSaveCapacityScenarioData.Length.ShouldBe(3);
            methodSaveCapacityScenarioDataPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SaveCapacityScenarioData) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_SaveCapacityScenarioData_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sCSDataXML = CreateType<string>();
            var sReply = CreateType<string>();
            var statusvalue = CreateType<int>();
            var methodSaveCapacityScenarioDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int) };
            object[] parametersOfSaveCapacityScenarioData = { sCSDataXML, sReply, statusvalue };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveCapacityScenarioData, methodSaveCapacityScenarioDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CapacityScenarios, bool>(_capacityScenariosInstanceFixture, out exception1, parametersOfSaveCapacityScenarioData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodSaveCapacityScenarioData, parametersOfSaveCapacityScenarioData, methodSaveCapacityScenarioDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveCapacityScenarioData.ShouldNotBeNull();
            parametersOfSaveCapacityScenarioData.Length.ShouldBe(3);
            methodSaveCapacityScenarioDataPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SaveCapacityScenarioData) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_SaveCapacityScenarioData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sCSDataXML = CreateType<string>();
            var sReply = CreateType<string>();
            var statusvalue = CreateType<int>();
            var methodSaveCapacityScenarioDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int) };
            object[] parametersOfSaveCapacityScenarioData = { sCSDataXML, sReply, statusvalue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodSaveCapacityScenarioData, parametersOfSaveCapacityScenarioData, methodSaveCapacityScenarioDataPrametersTypes);

            // Assert
            parametersOfSaveCapacityScenarioData.ShouldNotBeNull();
            parametersOfSaveCapacityScenarioData.Length.ShouldBe(3);
            methodSaveCapacityScenarioDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveCapacityScenarioData) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_SaveCapacityScenarioData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveCapacityScenarioDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityScenariosInstance, MethodSaveCapacityScenarioData, Fixture, methodSaveCapacityScenarioDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveCapacityScenarioDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCapacityScenarioData) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_SaveCapacityScenarioData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveCapacityScenarioData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityScenariosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveCapacityScenarioData) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_SaveCapacityScenarioData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveCapacityScenarioData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCurrentScenarioData) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CapacityScenarios_SaveCurrentScenarioData_Method_Call_Internally(Type[] types)
        {
            var methodSaveCurrentScenarioDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityScenariosInstance, MethodSaveCurrentScenarioData, Fixture, methodSaveCurrentScenarioDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveCurrentScenarioData) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_SaveCurrentScenarioData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sSaveToName = CreateType<string>();
            var sCSDataXML = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _capacityScenariosInstance.SaveCurrentScenarioData(sSaveToName, sCSDataXML);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveCurrentScenarioData) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_SaveCurrentScenarioData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sSaveToName = CreateType<string>();
            var sCSDataXML = CreateType<string>();
            var methodSaveCurrentScenarioDataPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfSaveCurrentScenarioData = { sSaveToName, sCSDataXML };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveCurrentScenarioData, methodSaveCurrentScenarioDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CapacityScenarios, bool>(_capacityScenariosInstanceFixture, out exception1, parametersOfSaveCurrentScenarioData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodSaveCurrentScenarioData, parametersOfSaveCurrentScenarioData, methodSaveCurrentScenarioDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveCurrentScenarioData.ShouldNotBeNull();
            parametersOfSaveCurrentScenarioData.Length.ShouldBe(2);
            methodSaveCurrentScenarioDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SaveCurrentScenarioData) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_SaveCurrentScenarioData_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sSaveToName = CreateType<string>();
            var sCSDataXML = CreateType<string>();
            var methodSaveCurrentScenarioDataPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfSaveCurrentScenarioData = { sSaveToName, sCSDataXML };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveCurrentScenarioData, methodSaveCurrentScenarioDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CapacityScenarios, bool>(_capacityScenariosInstanceFixture, out exception1, parametersOfSaveCurrentScenarioData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodSaveCurrentScenarioData, parametersOfSaveCurrentScenarioData, methodSaveCurrentScenarioDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveCurrentScenarioData.ShouldNotBeNull();
            parametersOfSaveCurrentScenarioData.Length.ShouldBe(2);
            methodSaveCurrentScenarioDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SaveCurrentScenarioData) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_SaveCurrentScenarioData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sSaveToName = CreateType<string>();
            var sCSDataXML = CreateType<string>();
            var methodSaveCurrentScenarioDataPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfSaveCurrentScenarioData = { sSaveToName, sCSDataXML };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodSaveCurrentScenarioData, parametersOfSaveCurrentScenarioData, methodSaveCurrentScenarioDataPrametersTypes);

            // Assert
            parametersOfSaveCurrentScenarioData.ShouldNotBeNull();
            parametersOfSaveCurrentScenarioData.Length.ShouldBe(2);
            methodSaveCurrentScenarioDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveCurrentScenarioData) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_SaveCurrentScenarioData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveCurrentScenarioDataPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityScenariosInstance, MethodSaveCurrentScenarioData, Fixture, methodSaveCurrentScenarioDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveCurrentScenarioDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCurrentScenarioData) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_SaveCurrentScenarioData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveCurrentScenarioData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityScenariosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveCurrentScenarioData) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_SaveCurrentScenarioData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveCurrentScenarioData, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListTicket) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CapacityScenarios_GetListTicket_Method_Call_Internally(Type[] types)
        {
            var methodGetListTicketPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityScenariosInstance, MethodGetListTicket, Fixture, methodGetListTicketPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListTicket) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_GetListTicket_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sList = CreateType<string>();
            var bIsPIList = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _capacityScenariosInstance.GetListTicket(sList, bIsPIList);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetListTicket) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_GetListTicket_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sList = CreateType<string>();
            var bIsPIList = CreateType<bool>();
            var methodGetListTicketPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetListTicket = { sList, bIsPIList };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListTicket, methodGetListTicketPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CapacityScenarios, string>(_capacityScenariosInstanceFixture, out exception1, parametersOfGetListTicket);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, string>(_capacityScenariosInstance, MethodGetListTicket, parametersOfGetListTicket, methodGetListTicketPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListTicket.ShouldNotBeNull();
            parametersOfGetListTicket.Length.ShouldBe(2);
            methodGetListTicketPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetListTicket) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_GetListTicket_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sList = CreateType<string>();
            var bIsPIList = CreateType<bool>();
            var methodGetListTicketPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetListTicket = { sList, bIsPIList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, string>(_capacityScenariosInstance, MethodGetListTicket, parametersOfGetListTicket, methodGetListTicketPrametersTypes);

            // Assert
            parametersOfGetListTicket.ShouldNotBeNull();
            parametersOfGetListTicket.Length.ShouldBe(2);
            methodGetListTicketPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListTicket) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_GetListTicket_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListTicketPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityScenariosInstance, MethodGetListTicket, Fixture, methodGetListTicketPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListTicketPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetListTicket) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_GetListTicket_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListTicketPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityScenariosInstance, MethodGetListTicket, Fixture, methodGetListTicketPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListTicketPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListTicket) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_GetListTicket_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListTicket, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityScenariosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListTicket) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_GetListTicket_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListTicket, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PrivateAllowed) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CapacityScenarios_PrivateAllowed_Method_Call_Internally(Type[] types)
        {
            var methodPrivateAllowedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityScenariosInstance, MethodPrivateAllowed, Fixture, methodPrivateAllowedPrametersTypes);
        }

        #endregion

        #region Method Call : (PrivateAllowed) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_PrivateAllowed_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodPrivateAllowedPrametersTypes = null;
            object[] parametersOfPrivateAllowed = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPrivateAllowed, methodPrivateAllowedPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CapacityScenarios, bool>(_capacityScenariosInstanceFixture, out exception1, parametersOfPrivateAllowed);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodPrivateAllowed, parametersOfPrivateAllowed, methodPrivateAllowedPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfPrivateAllowed.ShouldBeNull();
            methodPrivateAllowedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PrivateAllowed) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_PrivateAllowed_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodPrivateAllowedPrametersTypes = null;
            object[] parametersOfPrivateAllowed = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPrivateAllowed, methodPrivateAllowedPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CapacityScenarios, bool>(_capacityScenariosInstanceFixture, out exception1, parametersOfPrivateAllowed);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodPrivateAllowed, parametersOfPrivateAllowed, methodPrivateAllowedPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfPrivateAllowed.ShouldBeNull();
            methodPrivateAllowedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PrivateAllowed) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_PrivateAllowed_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodPrivateAllowedPrametersTypes = null;
            object[] parametersOfPrivateAllowed = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CapacityScenarios, bool>(_capacityScenariosInstance, MethodPrivateAllowed, parametersOfPrivateAllowed, methodPrivateAllowedPrametersTypes);

            // Assert
            parametersOfPrivateAllowed.ShouldBeNull();
            methodPrivateAllowedPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PrivateAllowed) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_PrivateAllowed_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodPrivateAllowedPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityScenariosInstance, MethodPrivateAllowed, Fixture, methodPrivateAllowedPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPrivateAllowedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PrivateAllowed) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CapacityScenarios_PrivateAllowed_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPrivateAllowed, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityScenariosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}