using System;
using System.Collections.Generic;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.Capacity" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class CapacityTest : AbstractBaseSetupTypedTest<Capacity>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Capacity) Initializer

        private const string MethodGetSuperRM = "GetSuperRM";
        private const string MethodGetSuperPM = "GetSuperPM";
        private const string MethodSelectMyDepts = "SelectMyDepts";
        private const string MethodSelectMyResources = "SelectMyResources";
        private const string MethodSelectMyProjects = "SelectMyProjects";
        private const string MethodSelectResourcesFromTicket = "SelectResourcesFromTicket";
        private const string MethodGetRVInfo = "GetRVInfo";
        private const string MethodSetParentUIDs = "SetParentUIDs";
        private const string MethodAddCustomField = "AddCustomField";
        private const string MethodAddCustomFieldLookup = "AddCustomFieldLookup";
        private const string MethodMakeListFromCollection = "MakeListFromCollection";
        private const string MethodRemovePlanRowsWOHours = "RemovePlanRowsWOHours";
        private const string MethodMapToPeriod = "MapToPeriod";
        private const string MethodGetBCUID = "GetBCUID";
        private const string MethodGetFTEValue = "GetFTEValue";
        private const string MethodGetFTEConv = "GetFTEConv";
        private Type _capacityInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Capacity _capacityInstance;
        private Capacity _capacityInstanceFixture;

        #region General Initializer : Class (Capacity) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Capacity" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _capacityInstanceType = typeof(Capacity);
            _capacityInstanceFixture = Create(true);
            _capacityInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Capacity)

        #region General Initializer : Class (Capacity) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Capacity" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetSuperRM, 0)]
        [TestCase(MethodGetSuperPM, 0)]
        [TestCase(MethodSelectMyDepts, 0)]
        [TestCase(MethodSelectMyResources, 0)]
        [TestCase(MethodSelectMyProjects, 0)]
        [TestCase(MethodSelectResourcesFromTicket, 0)]
        [TestCase(MethodGetRVInfo, 0)]
        [TestCase(MethodSetParentUIDs, 0)]
        [TestCase(MethodAddCustomField, 0)]
        [TestCase(MethodAddCustomFieldLookup, 0)]
        [TestCase(MethodMakeListFromCollection, 0)]
        [TestCase(MethodRemovePlanRowsWOHours, 0)]
        [TestCase(MethodMapToPeriod, 0)]
        [TestCase(MethodGetBCUID, 0)]
        [TestCase(MethodGetFTEValue, 0)]
        [TestCase(MethodGetFTEConv, 0)]
        public void AUT_Capacity_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_capacityInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Capacity) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="Capacity" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_Capacity_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<Capacity>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (Capacity) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="Capacity" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Capacity_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<Capacity>(Fixture);
        }

        #endregion

        #region General Constructor : Class (Capacity) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="Capacity" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Capacity_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var username = CreateType<string>();
            var pid = CreateType<string>();
            var company = CreateType<string>();
            var dbcnstring = CreateType<string>();
            var secLevel = CreateType<SecurityLevels>();
            var bDebug = CreateType<bool>();
            object[] parametersOfCapacity = { basepath, username, pid, company, dbcnstring, secLevel, bDebug };
            var methodCapacityPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_capacityInstanceType, methodCapacityPrametersTypes, parametersOfCapacity);
        }

        #endregion

        #region General Constructor : Class (Capacity) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="Capacity" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Capacity_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodCapacityPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_capacityInstanceType, Fixture, methodCapacityPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (Capacity) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="Capacity" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Capacity_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var sBaseInfo = CreateType<string>();
            object[] parametersOfCapacity = { sBaseInfo };
            var methodCapacityPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_capacityInstanceType, methodCapacityPrametersTypes, parametersOfCapacity);
        }

        #endregion

        #region General Constructor : Class (Capacity) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="Capacity" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Capacity_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodCapacityPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_capacityInstanceType, Fixture, methodCapacityPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="Capacity" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodSetParentUIDs)]
        [TestCase(MethodAddCustomField)]
        [TestCase(MethodAddCustomFieldLookup)]
        [TestCase(MethodMakeListFromCollection)]
        [TestCase(MethodRemovePlanRowsWOHours)]
        [TestCase(MethodMapToPeriod)]
        [TestCase(MethodGetBCUID)]
        [TestCase(MethodGetFTEValue)]
        [TestCase(MethodGetFTEConv)]
        public void AUT_Capacity_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_capacityInstanceFixture,
                                                                              _capacityInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Capacity" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetSuperRM)]
        [TestCase(MethodGetSuperPM)]
        [TestCase(MethodSelectMyDepts)]
        [TestCase(MethodSelectMyResources)]
        [TestCase(MethodSelectMyProjects)]
        [TestCase(MethodSelectResourcesFromTicket)]
        [TestCase(MethodGetRVInfo)]
        public void AUT_Capacity_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Capacity>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetSuperRM) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capacity_GetSuperRM_Method_Call_Internally(Type[] types)
        {
            var methodGetSuperRMPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityInstance, MethodGetSuperRM, Fixture, methodGetSuperRMPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSuperRM) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetSuperRM_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _capacityInstance.GetSuperRM();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSuperRM) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetSuperRM_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSuperRMPrametersTypes = null;
            object[] parametersOfGetSuperRM = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSuperRM, methodGetSuperRMPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Capacity, bool>(_capacityInstanceFixture, out exception1, parametersOfGetSuperRM);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Capacity, bool>(_capacityInstance, MethodGetSuperRM, parametersOfGetSuperRM, methodGetSuperRMPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetSuperRM.ShouldBeNull();
            methodGetSuperRMPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSuperRM) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetSuperRM_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetSuperRMPrametersTypes = null;
            object[] parametersOfGetSuperRM = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSuperRM, methodGetSuperRMPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Capacity, bool>(_capacityInstanceFixture, out exception1, parametersOfGetSuperRM);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Capacity, bool>(_capacityInstance, MethodGetSuperRM, parametersOfGetSuperRM, methodGetSuperRMPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetSuperRM.ShouldBeNull();
            methodGetSuperRMPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSuperRM) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetSuperRM_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetSuperRMPrametersTypes = null;
            object[] parametersOfGetSuperRM = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Capacity, bool>(_capacityInstance, MethodGetSuperRM, parametersOfGetSuperRM, methodGetSuperRMPrametersTypes);

            // Assert
            parametersOfGetSuperRM.ShouldBeNull();
            methodGetSuperRMPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSuperRM) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetSuperRM_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetSuperRMPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityInstance, MethodGetSuperRM, Fixture, methodGetSuperRMPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSuperRMPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSuperRM) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetSuperRM_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSuperRM, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSuperPM) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capacity_GetSuperPM_Method_Call_Internally(Type[] types)
        {
            var methodGetSuperPMPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityInstance, MethodGetSuperPM, Fixture, methodGetSuperPMPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSuperPM) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetSuperPM_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _capacityInstance.GetSuperPM();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSuperPM) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetSuperPM_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSuperPMPrametersTypes = null;
            object[] parametersOfGetSuperPM = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSuperPM, methodGetSuperPMPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Capacity, bool>(_capacityInstanceFixture, out exception1, parametersOfGetSuperPM);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Capacity, bool>(_capacityInstance, MethodGetSuperPM, parametersOfGetSuperPM, methodGetSuperPMPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetSuperPM.ShouldBeNull();
            methodGetSuperPMPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSuperPM) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetSuperPM_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetSuperPMPrametersTypes = null;
            object[] parametersOfGetSuperPM = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSuperPM, methodGetSuperPMPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Capacity, bool>(_capacityInstanceFixture, out exception1, parametersOfGetSuperPM);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Capacity, bool>(_capacityInstance, MethodGetSuperPM, parametersOfGetSuperPM, methodGetSuperPMPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetSuperPM.ShouldBeNull();
            methodGetSuperPMPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSuperPM) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetSuperPM_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetSuperPMPrametersTypes = null;
            object[] parametersOfGetSuperPM = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Capacity, bool>(_capacityInstance, MethodGetSuperPM, parametersOfGetSuperPM, methodGetSuperPMPrametersTypes);

            // Assert
            parametersOfGetSuperPM.ShouldBeNull();
            methodGetSuperPMPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSuperPM) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetSuperPM_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetSuperPMPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityInstance, MethodGetSuperPM, Fixture, methodGetSuperPMPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSuperPMPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSuperPM) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetSuperPM_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSuperPM, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SelectMyDepts) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capacity_SelectMyDepts_Method_Call_Internally(Type[] types)
        {
            var methodSelectMyDeptsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityInstance, MethodSelectMyDepts, Fixture, methodSelectMyDeptsPrametersTypes);
        }

        #endregion

        #region Method Call : (SelectMyDepts) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectMyDepts_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _capacityInstance.SelectMyDepts(out sReply);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SelectMyDepts) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectMyDepts_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodSelectMyDeptsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSelectMyDepts = { sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSelectMyDepts, methodSelectMyDeptsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Capacity, int>(_capacityInstanceFixture, out exception1, parametersOfSelectMyDepts);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Capacity, int>(_capacityInstance, MethodSelectMyDepts, parametersOfSelectMyDepts, methodSelectMyDeptsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSelectMyDepts.ShouldNotBeNull();
            parametersOfSelectMyDepts.Length.ShouldBe(1);
            methodSelectMyDeptsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SelectMyDepts) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectMyDepts_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodSelectMyDeptsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSelectMyDepts = { sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSelectMyDepts, methodSelectMyDeptsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Capacity, int>(_capacityInstanceFixture, out exception1, parametersOfSelectMyDepts);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Capacity, int>(_capacityInstance, MethodSelectMyDepts, parametersOfSelectMyDepts, methodSelectMyDeptsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSelectMyDepts.ShouldNotBeNull();
            parametersOfSelectMyDepts.Length.ShouldBe(1);
            methodSelectMyDeptsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SelectMyDepts) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectMyDepts_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodSelectMyDeptsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSelectMyDepts = { sReply };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Capacity, int>(_capacityInstance, MethodSelectMyDepts, parametersOfSelectMyDepts, methodSelectMyDeptsPrametersTypes);

            // Assert
            parametersOfSelectMyDepts.ShouldNotBeNull();
            parametersOfSelectMyDepts.Length.ShouldBe(1);
            methodSelectMyDeptsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SelectMyDepts) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectMyDepts_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSelectMyDeptsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityInstance, MethodSelectMyDepts, Fixture, methodSelectMyDeptsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSelectMyDeptsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SelectMyDepts) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectMyDepts_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSelectMyDepts, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SelectMyDepts) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectMyDepts_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSelectMyDepts, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SelectMyResources) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capacity_SelectMyResources_Method_Call_Internally(Type[] types)
        {
            var methodSelectMyResourcesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityInstance, MethodSelectMyResources, Fixture, methodSelectMyResourcesPrametersTypes);
        }

        #endregion

        #region Method Call : (SelectMyResources) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectMyResources_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _capacityInstance.SelectMyResources(out sReply);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SelectMyResources) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectMyResources_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodSelectMyResourcesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSelectMyResources = { sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSelectMyResources, methodSelectMyResourcesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Capacity, int>(_capacityInstanceFixture, out exception1, parametersOfSelectMyResources);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Capacity, int>(_capacityInstance, MethodSelectMyResources, parametersOfSelectMyResources, methodSelectMyResourcesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSelectMyResources.ShouldNotBeNull();
            parametersOfSelectMyResources.Length.ShouldBe(1);
            methodSelectMyResourcesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SelectMyResources) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectMyResources_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodSelectMyResourcesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSelectMyResources = { sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSelectMyResources, methodSelectMyResourcesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Capacity, int>(_capacityInstanceFixture, out exception1, parametersOfSelectMyResources);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Capacity, int>(_capacityInstance, MethodSelectMyResources, parametersOfSelectMyResources, methodSelectMyResourcesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSelectMyResources.ShouldNotBeNull();
            parametersOfSelectMyResources.Length.ShouldBe(1);
            methodSelectMyResourcesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SelectMyResources) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectMyResources_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodSelectMyResourcesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSelectMyResources = { sReply };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Capacity, int>(_capacityInstance, MethodSelectMyResources, parametersOfSelectMyResources, methodSelectMyResourcesPrametersTypes);

            // Assert
            parametersOfSelectMyResources.ShouldNotBeNull();
            parametersOfSelectMyResources.Length.ShouldBe(1);
            methodSelectMyResourcesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SelectMyResources) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectMyResources_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSelectMyResourcesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityInstance, MethodSelectMyResources, Fixture, methodSelectMyResourcesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSelectMyResourcesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SelectMyResources) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectMyResources_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSelectMyResources, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SelectMyResources) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectMyResources_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSelectMyResources, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SelectMyProjects) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capacity_SelectMyProjects_Method_Call_Internally(Type[] types)
        {
            var methodSelectMyProjectsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityInstance, MethodSelectMyProjects, Fixture, methodSelectMyProjectsPrametersTypes);
        }

        #endregion

        #region Method Call : (SelectMyProjects) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectMyProjects_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _capacityInstance.SelectMyProjects(out sReply);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SelectMyProjects) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectMyProjects_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodSelectMyProjectsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSelectMyProjects = { sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSelectMyProjects, methodSelectMyProjectsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Capacity, int>(_capacityInstanceFixture, out exception1, parametersOfSelectMyProjects);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Capacity, int>(_capacityInstance, MethodSelectMyProjects, parametersOfSelectMyProjects, methodSelectMyProjectsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSelectMyProjects.ShouldNotBeNull();
            parametersOfSelectMyProjects.Length.ShouldBe(1);
            methodSelectMyProjectsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SelectMyProjects) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectMyProjects_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodSelectMyProjectsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSelectMyProjects = { sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSelectMyProjects, methodSelectMyProjectsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Capacity, int>(_capacityInstanceFixture, out exception1, parametersOfSelectMyProjects);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Capacity, int>(_capacityInstance, MethodSelectMyProjects, parametersOfSelectMyProjects, methodSelectMyProjectsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSelectMyProjects.ShouldNotBeNull();
            parametersOfSelectMyProjects.Length.ShouldBe(1);
            methodSelectMyProjectsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SelectMyProjects) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectMyProjects_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodSelectMyProjectsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSelectMyProjects = { sReply };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Capacity, int>(_capacityInstance, MethodSelectMyProjects, parametersOfSelectMyProjects, methodSelectMyProjectsPrametersTypes);

            // Assert
            parametersOfSelectMyProjects.ShouldNotBeNull();
            parametersOfSelectMyProjects.Length.ShouldBe(1);
            methodSelectMyProjectsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SelectMyProjects) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectMyProjects_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSelectMyProjectsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityInstance, MethodSelectMyProjects, Fixture, methodSelectMyProjectsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSelectMyProjectsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SelectMyProjects) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectMyProjects_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSelectMyProjects, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SelectMyProjects) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectMyProjects_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSelectMyProjects, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SelectResourcesFromTicket) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capacity_SelectResourcesFromTicket_Method_Call_Internally(Type[] types)
        {
            var methodSelectResourcesFromTicketPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityInstance, MethodSelectResourcesFromTicket, Fixture, methodSelectResourcesFromTicketPrametersTypes);
        }

        #endregion

        #region Method Call : (SelectResourcesFromTicket) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectResourcesFromTicket_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sTicket = CreateType<string>();
            var sReply = CreateType<string>();
            var sReplyMessage = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _capacityInstance.SelectResourcesFromTicket(sTicket, out sReply, out sReplyMessage);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SelectResourcesFromTicket) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectResourcesFromTicket_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sTicket = CreateType<string>();
            var sReply = CreateType<string>();
            var sReplyMessage = CreateType<string>();
            var methodSelectResourcesFromTicketPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfSelectResourcesFromTicket = { sTicket, sReply, sReplyMessage };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSelectResourcesFromTicket, methodSelectResourcesFromTicketPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Capacity, int>(_capacityInstanceFixture, out exception1, parametersOfSelectResourcesFromTicket);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Capacity, int>(_capacityInstance, MethodSelectResourcesFromTicket, parametersOfSelectResourcesFromTicket, methodSelectResourcesFromTicketPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSelectResourcesFromTicket.ShouldNotBeNull();
            parametersOfSelectResourcesFromTicket.Length.ShouldBe(3);
            methodSelectResourcesFromTicketPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SelectResourcesFromTicket) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectResourcesFromTicket_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sTicket = CreateType<string>();
            var sReply = CreateType<string>();
            var sReplyMessage = CreateType<string>();
            var methodSelectResourcesFromTicketPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfSelectResourcesFromTicket = { sTicket, sReply, sReplyMessage };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSelectResourcesFromTicket, methodSelectResourcesFromTicketPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Capacity, int>(_capacityInstanceFixture, out exception1, parametersOfSelectResourcesFromTicket);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Capacity, int>(_capacityInstance, MethodSelectResourcesFromTicket, parametersOfSelectResourcesFromTicket, methodSelectResourcesFromTicketPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSelectResourcesFromTicket.ShouldNotBeNull();
            parametersOfSelectResourcesFromTicket.Length.ShouldBe(3);
            methodSelectResourcesFromTicketPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SelectResourcesFromTicket) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectResourcesFromTicket_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sTicket = CreateType<string>();
            var sReply = CreateType<string>();
            var sReplyMessage = CreateType<string>();
            var methodSelectResourcesFromTicketPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfSelectResourcesFromTicket = { sTicket, sReply, sReplyMessage };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Capacity, int>(_capacityInstance, MethodSelectResourcesFromTicket, parametersOfSelectResourcesFromTicket, methodSelectResourcesFromTicketPrametersTypes);

            // Assert
            parametersOfSelectResourcesFromTicket.ShouldNotBeNull();
            parametersOfSelectResourcesFromTicket.Length.ShouldBe(3);
            methodSelectResourcesFromTicketPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SelectResourcesFromTicket) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectResourcesFromTicket_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSelectResourcesFromTicketPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityInstance, MethodSelectResourcesFromTicket, Fixture, methodSelectResourcesFromTicketPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSelectResourcesFromTicketPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SelectResourcesFromTicket) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectResourcesFromTicket_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSelectResourcesFromTicket, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SelectResourcesFromTicket) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SelectResourcesFromTicket_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSelectResourcesFromTicket, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRVInfo) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capacity_GetRVInfo_Method_Call_Internally(Type[] types)
        {
            var methodGetRVInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityInstance, MethodGetRVInfo, Fixture, methodGetRVInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRVInfo) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetRVInfo_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sParmXML = CreateType<string>();
            var sReplyXML = CreateType<string>();
            var sResult = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _capacityInstance.GetRVInfo(sParmXML, out sReplyXML, out sResult);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetRVInfo) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetRVInfo_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sParmXML = CreateType<string>();
            var sReplyXML = CreateType<string>();
            var sResult = CreateType<string>();
            var methodGetRVInfoPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetRVInfo = { sParmXML, sReplyXML, sResult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRVInfo, methodGetRVInfoPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Capacity, int>(_capacityInstanceFixture, out exception1, parametersOfGetRVInfo);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Capacity, int>(_capacityInstance, MethodGetRVInfo, parametersOfGetRVInfo, methodGetRVInfoPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetRVInfo.ShouldNotBeNull();
            parametersOfGetRVInfo.Length.ShouldBe(3);
            methodGetRVInfoPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetRVInfo) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetRVInfo_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sParmXML = CreateType<string>();
            var sReplyXML = CreateType<string>();
            var sResult = CreateType<string>();
            var methodGetRVInfoPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetRVInfo = { sParmXML, sReplyXML, sResult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRVInfo, methodGetRVInfoPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Capacity, int>(_capacityInstanceFixture, out exception1, parametersOfGetRVInfo);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Capacity, int>(_capacityInstance, MethodGetRVInfo, parametersOfGetRVInfo, methodGetRVInfoPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetRVInfo.ShouldNotBeNull();
            parametersOfGetRVInfo.Length.ShouldBe(3);
            methodGetRVInfoPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetRVInfo) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetRVInfo_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sParmXML = CreateType<string>();
            var sReplyXML = CreateType<string>();
            var sResult = CreateType<string>();
            var methodGetRVInfoPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetRVInfo = { sParmXML, sReplyXML, sResult };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Capacity, int>(_capacityInstance, MethodGetRVInfo, parametersOfGetRVInfo, methodGetRVInfoPrametersTypes);

            // Assert
            parametersOfGetRVInfo.ShouldNotBeNull();
            parametersOfGetRVInfo.Length.ShouldBe(3);
            methodGetRVInfoPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRVInfo) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetRVInfo_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRVInfoPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capacityInstance, MethodGetRVInfo, Fixture, methodGetRVInfoPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRVInfoPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRVInfo) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetRVInfo_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRVInfo, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRVInfo) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetRVInfo_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRVInfo, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetParentUIDs) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capacity_SetParentUIDs_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetParentUIDsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_capacityInstanceFixture, _capacityInstanceType, MethodSetParentUIDs, Fixture, methodSetParentUIDsPrametersTypes);
        }

        #endregion
        
        #region Method Call : (SetParentUIDs) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SetParentUIDs_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetParentUIDs, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion
        
        #region Method Call : (SetParentUIDs) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_SetParentUIDs_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetParentUIDs, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddCustomField) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capacity_AddCustomField_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddCustomFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_capacityInstanceFixture, _capacityInstanceType, MethodAddCustomField, Fixture, methodAddCustomFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (AddCustomField) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_AddCustomField_Static_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var customfields = CreateType<List<string>>();
            var lFieldID = CreateType<int>();
            var lFieldType = CreateType<int>();
            var reader = CreateType<SqlDataReader>();
            var sFieldName = CreateType<string>();
            var methodAddCustomFieldPrametersTypes = new Type[] { typeof(List<string>), typeof(int), typeof(int), typeof(SqlDataReader), typeof(string) };
            object[] parametersOfAddCustomField = { customfields, lFieldID, lFieldType, reader, sFieldName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_capacityInstanceFixture, _capacityInstanceType, MethodAddCustomField, parametersOfAddCustomField, methodAddCustomFieldPrametersTypes);

            // Assert
            parametersOfAddCustomField.ShouldNotBeNull();
            parametersOfAddCustomField.Length.ShouldBe(5);
            methodAddCustomFieldPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddCustomField) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_AddCustomField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddCustomField, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddCustomField) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_AddCustomField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddCustomFieldPrametersTypes = new Type[] { typeof(List<string>), typeof(int), typeof(int), typeof(SqlDataReader), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_capacityInstanceFixture, _capacityInstanceType, MethodAddCustomField, Fixture, methodAddCustomFieldPrametersTypes);

            // Assert
            methodAddCustomFieldPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddCustomField) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_AddCustomField_Static_Method_Call_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddCustomField, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddCustomFieldLookup) (Return Type : StatusEnum) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capacity_AddCustomFieldLookup_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddCustomFieldLookupPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_capacityInstanceFixture, _capacityInstanceType, MethodAddCustomFieldLookup, Fixture, methodAddCustomFieldLookupPrametersTypes);
        }

        #endregion

        #region Method Call : (AddCustomFieldLookup) (Return Type : StatusEnum) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_AddCustomFieldLookup_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddCustomFieldLookup, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddCustomFieldLookup) (Return Type : StatusEnum) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_AddCustomFieldLookup_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddCustomFieldLookup, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MakeListFromCollection) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capacity_MakeListFromCollection_Static_Method_Call_Internally(Type[] types)
        {
            var methodMakeListFromCollectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_capacityInstanceFixture, _capacityInstanceType, MethodMakeListFromCollection, Fixture, methodMakeListFromCollectionPrametersTypes);
        }

        #endregion

        #region Method Call : (MakeListFromCollection) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_MakeListFromCollection_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var uids = CreateType<List<int>>();
            var methodMakeListFromCollectionPrametersTypes = new Type[] { typeof(List<int>) };
            object[] parametersOfMakeListFromCollection = { uids };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodMakeListFromCollection, methodMakeListFromCollectionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_capacityInstanceFixture, parametersOfMakeListFromCollection);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfMakeListFromCollection.ShouldNotBeNull();
            parametersOfMakeListFromCollection.Length.ShouldBe(1);
            methodMakeListFromCollectionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MakeListFromCollection) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_MakeListFromCollection_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var uids = CreateType<List<int>>();
            var methodMakeListFromCollectionPrametersTypes = new Type[] { typeof(List<int>) };
            object[] parametersOfMakeListFromCollection = { uids };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_capacityInstanceFixture, _capacityInstanceType, MethodMakeListFromCollection, parametersOfMakeListFromCollection, methodMakeListFromCollectionPrametersTypes);

            // Assert
            parametersOfMakeListFromCollection.ShouldNotBeNull();
            parametersOfMakeListFromCollection.Length.ShouldBe(1);
            methodMakeListFromCollectionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MakeListFromCollection) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_MakeListFromCollection_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodMakeListFromCollectionPrametersTypes = new Type[] { typeof(List<int>) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_capacityInstanceFixture, _capacityInstanceType, MethodMakeListFromCollection, Fixture, methodMakeListFromCollectionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodMakeListFromCollectionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (MakeListFromCollection) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_MakeListFromCollection_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMakeListFromCollectionPrametersTypes = new Type[] { typeof(List<int>) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_capacityInstanceFixture, _capacityInstanceType, MethodMakeListFromCollection, Fixture, methodMakeListFromCollectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodMakeListFromCollectionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MakeListFromCollection) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_MakeListFromCollection_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMakeListFromCollection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (MakeListFromCollection) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_MakeListFromCollection_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMakeListFromCollection, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemovePlanRowsWOHours) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capacity_RemovePlanRowsWOHours_Static_Method_Call_Internally(Type[] types)
        {
            var methodRemovePlanRowsWOHoursPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_capacityInstanceFixture, _capacityInstanceType, MethodRemovePlanRowsWOHours, Fixture, methodRemovePlanRowsWOHoursPrametersTypes);
        }

        #endregion
        
        #region Method Call : (RemovePlanRowsWOHours) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_RemovePlanRowsWOHours_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRemovePlanRowsWOHours, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion
        
        #region Method Call : (RemovePlanRowsWOHours) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_RemovePlanRowsWOHours_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemovePlanRowsWOHours, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MapToPeriod) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capacity_MapToPeriod_Static_Method_Call_Internally(Type[] types)
        {
            var methodMapToPeriodPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_capacityInstanceFixture, _capacityInstanceType, MethodMapToPeriod, Fixture, methodMapToPeriodPrametersTypes);
        }

        #endregion
        
        #region Method Call : (MapToPeriod) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_MapToPeriod_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMapToPeriod, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (MapToPeriod) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_MapToPeriod_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMapToPeriod, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBCUID) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capacity_GetBCUID_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetBCUIDPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_capacityInstanceFixture, _capacityInstanceType, MethodGetBCUID, Fixture, methodGetBCUIDPrametersTypes);
        }

        #endregion

        #region Method Call : (GetBCUID) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetBCUID_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var clnXrefs = CreateType<Dictionary<int, int>>();
            var lWResID = CreateType<int>();
            var methodGetBCUIDPrametersTypes = new Type[] { typeof(Dictionary<int, int>), typeof(int) };
            object[] parametersOfGetBCUID = { clnXrefs, lWResID };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetBCUID, methodGetBCUIDPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_capacityInstanceFixture, parametersOfGetBCUID);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetBCUID.ShouldNotBeNull();
            parametersOfGetBCUID.Length.ShouldBe(2);
            methodGetBCUIDPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBCUID) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetBCUID_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var clnXrefs = CreateType<Dictionary<int, int>>();
            var lWResID = CreateType<int>();
            var methodGetBCUIDPrametersTypes = new Type[] { typeof(Dictionary<int, int>), typeof(int) };
            object[] parametersOfGetBCUID = { clnXrefs, lWResID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<int>(_capacityInstanceFixture, _capacityInstanceType, MethodGetBCUID, parametersOfGetBCUID, methodGetBCUIDPrametersTypes);

            // Assert
            parametersOfGetBCUID.ShouldNotBeNull();
            parametersOfGetBCUID.Length.ShouldBe(2);
            methodGetBCUIDPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBCUID) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetBCUID_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetBCUIDPrametersTypes = new Type[] { typeof(Dictionary<int, int>), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_capacityInstanceFixture, _capacityInstanceType, MethodGetBCUID, Fixture, methodGetBCUIDPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetBCUIDPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBCUID) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetBCUID_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBCUID, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetBCUID) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetBCUID_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetBCUID, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFTEValue) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capacity_GetFTEValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFTEValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_capacityInstanceFixture, _capacityInstanceType, MethodGetFTEValue, Fixture, methodGetFTEValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetFTEValue) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetFTEValue_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var clnFTEs = CreateType<Dictionary<int, Dictionary<int, int>>>();
            var lBC_UID = CreateType<int>();
            var dblHours = CreateType<double>();
            var lPeriodID = CreateType<int>();
            var dblOffHours = CreateType<double>();
            var methodGetFTEValuePrametersTypes = new Type[] { typeof(Dictionary<int, Dictionary<int, int>>), typeof(int), typeof(double), typeof(int), typeof(double) };
            object[] parametersOfGetFTEValue = { clnFTEs, lBC_UID, dblHours, lPeriodID, dblOffHours };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFTEValue, methodGetFTEValuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_capacityInstanceFixture, parametersOfGetFTEValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFTEValue.ShouldNotBeNull();
            parametersOfGetFTEValue.Length.ShouldBe(5);
            methodGetFTEValuePrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFTEValue) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetFTEValue_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var clnFTEs = CreateType<Dictionary<int, Dictionary<int, int>>>();
            var lBC_UID = CreateType<int>();
            var dblHours = CreateType<double>();
            var lPeriodID = CreateType<int>();
            var dblOffHours = CreateType<double>();
            var methodGetFTEValuePrametersTypes = new Type[] { typeof(Dictionary<int, Dictionary<int, int>>), typeof(int), typeof(double), typeof(int), typeof(double) };
            object[] parametersOfGetFTEValue = { clnFTEs, lBC_UID, dblHours, lPeriodID, dblOffHours };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<int>(_capacityInstanceFixture, _capacityInstanceType, MethodGetFTEValue, parametersOfGetFTEValue, methodGetFTEValuePrametersTypes);

            // Assert
            parametersOfGetFTEValue.ShouldNotBeNull();
            parametersOfGetFTEValue.Length.ShouldBe(5);
            methodGetFTEValuePrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFTEValue) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetFTEValue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFTEValuePrametersTypes = new Type[] { typeof(Dictionary<int, Dictionary<int, int>>), typeof(int), typeof(double), typeof(int), typeof(double) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_capacityInstanceFixture, _capacityInstanceType, MethodGetFTEValue, Fixture, methodGetFTEValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFTEValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFTEValue) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetFTEValue_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFTEValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetFTEValue) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetFTEValue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFTEValue, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFTEConv) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capacity_GetFTEConv_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFTEConvPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_capacityInstanceFixture, _capacityInstanceType, MethodGetFTEConv, Fixture, methodGetFTEConvPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFTEConv) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetFTEConv_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var clnFTEs = CreateType<Dictionary<int, Dictionary<int, int>>>();
            var lBC_UID = CreateType<int>();
            var lPeriodID = CreateType<int>();
            var methodGetFTEConvPrametersTypes = new Type[] { typeof(Dictionary<int, Dictionary<int, int>>), typeof(int), typeof(int) };
            object[] parametersOfGetFTEConv = { clnFTEs, lBC_UID, lPeriodID };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFTEConv, methodGetFTEConvPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_capacityInstanceFixture, parametersOfGetFTEConv);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFTEConv.ShouldNotBeNull();
            parametersOfGetFTEConv.Length.ShouldBe(3);
            methodGetFTEConvPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFTEConv) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetFTEConv_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var clnFTEs = CreateType<Dictionary<int, Dictionary<int, int>>>();
            var lBC_UID = CreateType<int>();
            var lPeriodID = CreateType<int>();
            var methodGetFTEConvPrametersTypes = new Type[] { typeof(Dictionary<int, Dictionary<int, int>>), typeof(int), typeof(int) };
            object[] parametersOfGetFTEConv = { clnFTEs, lBC_UID, lPeriodID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<int>(_capacityInstanceFixture, _capacityInstanceType, MethodGetFTEConv, parametersOfGetFTEConv, methodGetFTEConvPrametersTypes);

            // Assert
            parametersOfGetFTEConv.ShouldNotBeNull();
            parametersOfGetFTEConv.Length.ShouldBe(3);
            methodGetFTEConvPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFTEConv) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetFTEConv_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFTEConvPrametersTypes = new Type[] { typeof(Dictionary<int, Dictionary<int, int>>), typeof(int), typeof(int) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_capacityInstanceFixture, _capacityInstanceType, MethodGetFTEConv, Fixture, methodGetFTEConvPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFTEConvPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFTEConv) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetFTEConv_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFTEConv, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_capacityInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetFTEConv) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capacity_GetFTEConv_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFTEConv, 0);
            const int parametersCount = 3;

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