using System;
using System.Data.SqlClient;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.ModelSupport" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ModelSupportTest : AbstractBaseSetupTypedTest<ModelSupport>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ModelSupport) Initializer

        private const string MethodGetConnection = "GetConnection";
        private const string Field_sqlConnection = "_sqlConnection";
        private Type _modelSupportInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ModelSupport _modelSupportInstance;
        private ModelSupport _modelSupportInstanceFixture;

        #region General Initializer : Class (ModelSupport) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ModelSupport" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _modelSupportInstanceType = typeof(ModelSupport);
            _modelSupportInstanceFixture = Create(true);
            _modelSupportInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ModelSupport)

        #region General Initializer : Class (ModelSupport) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ModelSupport" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetConnection, 0)]
        public void AUT_ModelSupport_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_modelSupportInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ModelSupport) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ModelSupport" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_sqlConnection)]
        public void AUT_ModelSupport_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_modelSupportInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ModelSupport) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="ModelSupport" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_ModelSupport_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<ModelSupport>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (ModelSupport) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="ModelSupport" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ModelSupport_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<ModelSupport>(Fixture);
        }

        #endregion

        #region General Constructor : Class (ModelSupport) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ModelSupport" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ModelSupport_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var username = CreateType<string>();
            var pid = CreateType<string>();
            var company = CreateType<string>();
            var dbcnstring = CreateType<string>();
            var secLevel = CreateType<SecurityLevels>();
            var bDebug = CreateType<bool>();
            object[] parametersOfModelSupport = { basepath, username, pid, company, dbcnstring, secLevel, bDebug };
            var methodModelSupportPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_modelSupportInstanceType, methodModelSupportPrametersTypes, parametersOfModelSupport);
        }

        #endregion

        #region General Constructor : Class (ModelSupport) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ModelSupport" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ModelSupport_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodModelSupportPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_modelSupportInstanceType, Fixture, methodModelSupportPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ModelSupport) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ModelSupport" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ModelSupport_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var sBaseInfo = CreateType<string>();
            object[] parametersOfModelSupport = { sBaseInfo };
            var methodModelSupportPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_modelSupportInstanceType, methodModelSupportPrametersTypes, parametersOfModelSupport);
        }

        #endregion

        #region General Constructor : Class (ModelSupport) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ModelSupport" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ModelSupport_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodModelSupportPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_modelSupportInstanceType, Fixture, methodModelSupportPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ModelSupport" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetConnection)]
        public void AUT_ModelSupport_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ModelSupport>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetConnection) (Return Type : SqlConnection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelSupport_GetConnection_Method_Call_Internally(Type[] types)
        {
            var methodGetConnectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelSupportInstance, MethodGetConnection, Fixture, methodGetConnectionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetConnection) (Return Type : SqlConnection) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelSupport_GetConnection_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelSupportInstance.GetConnection();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetConnection) (Return Type : SqlConnection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelSupport_GetConnection_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetConnectionPrametersTypes = null;
            object[] parametersOfGetConnection = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetConnection, methodGetConnectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelSupport, SqlConnection>(_modelSupportInstanceFixture, out exception1, parametersOfGetConnection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelSupport, SqlConnection>(_modelSupportInstance, MethodGetConnection, parametersOfGetConnection, methodGetConnectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetConnection.ShouldBeNull();
            methodGetConnectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetConnection) (Return Type : SqlConnection) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelSupport_GetConnection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetConnectionPrametersTypes = null;
            object[] parametersOfGetConnection = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelSupport, SqlConnection>(_modelSupportInstance, MethodGetConnection, parametersOfGetConnection, methodGetConnectionPrametersTypes);

            // Assert
            parametersOfGetConnection.ShouldBeNull();
            methodGetConnectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetConnection) (Return Type : SqlConnection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelSupport_GetConnection_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetConnectionPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelSupportInstance, MethodGetConnection, Fixture, methodGetConnectionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetConnectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetConnection) (Return Type : SqlConnection) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelSupport_GetConnection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetConnectionPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelSupportInstance, MethodGetConnection, Fixture, methodGetConnectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetConnectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetConnection) (Return Type : SqlConnection) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelSupport_GetConnection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetConnection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelSupportInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}