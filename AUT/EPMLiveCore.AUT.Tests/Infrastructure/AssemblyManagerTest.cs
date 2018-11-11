using System;
using System.Collections.Generic;
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

namespace EPMLiveCore.Infrastructure
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.AssemblyManager" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AssemblyManagerTest : AbstractBaseSetupTypedTest<AssemblyManager>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AssemblyManager) Initializer

        private const string PropertyCurrent = "Current";
        private const string MethodGetTypes = "GetTypes";
        private const string Field_instance = "_instance";
        private const string FieldLocker = "Locker";
        private const string Field_types = "_types";
        private Type _assemblyManagerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AssemblyManager _assemblyManagerInstance;
        private AssemblyManager _assemblyManagerInstanceFixture;

        #region General Initializer : Class (AssemblyManager) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AssemblyManager" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _assemblyManagerInstanceType = typeof(AssemblyManager);
            _assemblyManagerInstanceFixture = Create(true);
            _assemblyManagerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AssemblyManager)

        #region General Initializer : Class (AssemblyManager) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="AssemblyManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetTypes, 0)]
        public void AUT_AssemblyManager_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_assemblyManagerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AssemblyManager) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="AssemblyManager" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyCurrent)]
        public void AUT_AssemblyManager_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_assemblyManagerInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AssemblyManager) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AssemblyManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_instance)]
        [TestCase(FieldLocker)]
        [TestCase(Field_types)]
        public void AUT_AssemblyManager_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_assemblyManagerInstanceFixture, 
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
        ///     Class (<see cref="AssemblyManager" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_AssemblyManager_Is_Instance_Present_Test()
        {
            // Assert
            _assemblyManagerInstanceType.ShouldNotBeNull();
            _assemblyManagerInstance.ShouldNotBeNull();
            _assemblyManagerInstanceFixture.ShouldNotBeNull();
            _assemblyManagerInstance.ShouldBeAssignableTo<AssemblyManager>();
            _assemblyManagerInstanceFixture.ShouldBeAssignableTo<AssemblyManager>();
        }

        #endregion
        
        #region Category : GetterSetter

        #region General Getters/Setters : Class (AssemblyManager) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(AssemblyManager) , PropertyCurrent)]
        public void AUT_AssemblyManager_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<AssemblyManager, T>(_assemblyManagerInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (AssemblyManager) => Property (Current) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AssemblyManager_Current_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyCurrent);
            Action currentAction = () => propertyInfo.SetValue(_assemblyManagerInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AssemblyManager) => Property (Current) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AssemblyManager_Public_Class_Current_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCurrent);

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
        ///      Class (<see cref="AssemblyManager" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetTypes)]
        public void AUT_AssemblyManager_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<AssemblyManager>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetTypes) (Return Type : IEnumerable<Type>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssemblyManager_GetTypes_Method_Call_Internally(Type[] types)
        {
            var methodGetTypesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assemblyManagerInstance, MethodGetTypes, Fixture, methodGetTypesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTypes) (Return Type : IEnumerable<Type>) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssemblyManager_GetTypes_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _assemblyManagerInstance.GetTypes();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetTypes) (Return Type : IEnumerable<Type>) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssemblyManager_GetTypes_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetTypesPrametersTypes = null;
            object[] parametersOfGetTypes = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTypes, methodGetTypesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AssemblyManager, IEnumerable<Type>>(_assemblyManagerInstanceFixture, out exception1, parametersOfGetTypes);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AssemblyManager, IEnumerable<Type>>(_assemblyManagerInstance, MethodGetTypes, parametersOfGetTypes, methodGetTypesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetTypes.ShouldBeNull();
            methodGetTypesPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<AssemblyManager, IEnumerable<Type>>(_assemblyManagerInstance, MethodGetTypes, parametersOfGetTypes, methodGetTypesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetTypes) (Return Type : IEnumerable<Type>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssemblyManager_GetTypes_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetTypesPrametersTypes = null;
            object[] parametersOfGetTypes = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTypes, methodGetTypesPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTypes.ShouldBeNull();
            methodGetTypesPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => methodInfo.Invoke(_assemblyManagerInstanceFixture, parametersOfGetTypes));
        }

        #endregion

        #region Method Call : (GetTypes) (Return Type : IEnumerable<Type>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssemblyManager_GetTypes_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetTypesPrametersTypes = null;
            object[] parametersOfGetTypes = null; // no parameter present

            // Assert
            parametersOfGetTypes.ShouldBeNull();
            methodGetTypesPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<AssemblyManager, IEnumerable<Type>>(_assemblyManagerInstance, MethodGetTypes, parametersOfGetTypes, methodGetTypesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetTypes) (Return Type : IEnumerable<Type>) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssemblyManager_GetTypes_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetTypesPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assemblyManagerInstance, MethodGetTypes, Fixture, methodGetTypesPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetTypesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTypes) (Return Type : IEnumerable<Type>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssemblyManager_GetTypes_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetTypesPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assemblyManagerInstance, MethodGetTypes, Fixture, methodGetTypesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTypesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTypes) (Return Type : IEnumerable<Type>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssemblyManager_GetTypes_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTypes, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_assemblyManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}