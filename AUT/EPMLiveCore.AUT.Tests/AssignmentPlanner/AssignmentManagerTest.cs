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

namespace EPMLiveCore.AssignmentPlanner
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.AssignmentPlanner.AssignmentManager" />)
    ///     and namespace <see cref="EPMLiveCore.AssignmentPlanner"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AssignmentManagerTest : AbstractBaseSetupTypedTest<AssignmentManager>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AssignmentManager) Initializer

        private const string MethodPublish = "Publish";
        private const string MethodGetUpdatedItems = "GetUpdatedItems";
        private const string Field_spWeb = "_spWeb";
        private Type _assignmentManagerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AssignmentManager _assignmentManagerInstance;
        private AssignmentManager _assignmentManagerInstanceFixture;

        #region General Initializer : Class (AssignmentManager) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AssignmentManager" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _assignmentManagerInstanceType = typeof(AssignmentManager);
            _assignmentManagerInstanceFixture = Create(true);
            _assignmentManagerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AssignmentManager)

        #region General Initializer : Class (AssignmentManager) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="AssignmentManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPublish, 0)]
        [TestCase(MethodGetUpdatedItems, 0)]
        public void AUT_AssignmentManager_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_assignmentManagerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AssignmentManager) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AssignmentManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_spWeb)]
        public void AUT_AssignmentManager_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_assignmentManagerInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="AssignmentManager" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetUpdatedItems)]
        public void AUT_AssignmentManager_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_assignmentManagerInstanceFixture,
                                                                              _assignmentManagerInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="AssignmentManager" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPublish)]
        public void AUT_AssignmentManager_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<AssignmentManager>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Publish) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentManager_Publish_Method_Call_Internally(Type[] types)
        {
            var methodPublishPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentManagerInstance, MethodPublish, Fixture, methodPublishPrametersTypes);
        }

        #endregion

        #region Method Call : (Publish) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentManager_Publish_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _assignmentManagerInstance.Publish(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Publish) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentManager_Publish_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodPublishPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPublish = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPublish, methodPublishPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AssignmentManager, string>(_assignmentManagerInstanceFixture, out exception1, parametersOfPublish);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AssignmentManager, string>(_assignmentManagerInstance, MethodPublish, parametersOfPublish, methodPublishPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfPublish.ShouldNotBeNull();
            parametersOfPublish.Length.ShouldBe(1);
            methodPublishPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_assignmentManagerInstanceFixture, parametersOfPublish));
        }

        #endregion

        #region Method Call : (Publish) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentManager_Publish_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodPublishPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPublish = { data };

            // Assert
            parametersOfPublish.ShouldNotBeNull();
            parametersOfPublish.Length.ShouldBe(1);
            methodPublishPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<AssignmentManager, string>(_assignmentManagerInstance, MethodPublish, parametersOfPublish, methodPublishPrametersTypes));
        }

        #endregion

        #region Method Call : (Publish) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentManager_Publish_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodPublishPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentManagerInstance, MethodPublish, Fixture, methodPublishPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPublishPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Publish) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentManager_Publish_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPublishPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentManagerInstance, MethodPublish, Fixture, methodPublishPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPublishPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Publish) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentManager_Publish_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPublish, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_assignmentManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Publish) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentManager_Publish_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPublish, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUpdatedItems) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentManager_GetUpdatedItems_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetUpdatedItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_assignmentManagerInstanceFixture, _assignmentManagerInstanceType, MethodGetUpdatedItems, Fixture, methodGetUpdatedItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetUpdatedItems) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentManager_GetUpdatedItems_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetUpdatedItemsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetUpdatedItems = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetUpdatedItems, methodGetUpdatedItemsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_assignmentManagerInstanceFixture, _assignmentManagerInstanceType, MethodGetUpdatedItems, Fixture, methodGetUpdatedItemsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_assignmentManagerInstanceFixture, _assignmentManagerInstanceType, MethodGetUpdatedItems, parametersOfGetUpdatedItems, methodGetUpdatedItemsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_assignmentManagerInstanceFixture, parametersOfGetUpdatedItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetUpdatedItems.ShouldNotBeNull();
            parametersOfGetUpdatedItems.Length.ShouldBe(1);
            methodGetUpdatedItemsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetUpdatedItems) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentManager_GetUpdatedItems_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetUpdatedItemsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetUpdatedItems = { data };

            // Assert
            parametersOfGetUpdatedItems.ShouldNotBeNull();
            parametersOfGetUpdatedItems.Length.ShouldBe(1);
            methodGetUpdatedItemsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_assignmentManagerInstanceFixture, _assignmentManagerInstanceType, MethodGetUpdatedItems, parametersOfGetUpdatedItems, methodGetUpdatedItemsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetUpdatedItems) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentManager_GetUpdatedItems_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetUpdatedItemsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_assignmentManagerInstanceFixture, _assignmentManagerInstanceType, MethodGetUpdatedItems, Fixture, methodGetUpdatedItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetUpdatedItemsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetUpdatedItems) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentManager_GetUpdatedItems_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetUpdatedItemsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_assignmentManagerInstanceFixture, _assignmentManagerInstanceType, MethodGetUpdatedItems, Fixture, methodGetUpdatedItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetUpdatedItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUpdatedItems) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentManager_GetUpdatedItems_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetUpdatedItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_assignmentManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetUpdatedItems) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentManager_GetUpdatedItems_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetUpdatedItems, 0);
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