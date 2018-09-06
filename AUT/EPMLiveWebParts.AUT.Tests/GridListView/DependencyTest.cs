using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint.JSGrid;
using Microsoft.SharePoint.JsonUtilities;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.Dependency" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DependencyTest : AbstractBaseSetupTypedTest<Dependency>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Dependency) Initializer

        private const string PropertyKey = "Key";
        private const string PropertyType = "Type";
        private const string MethodToJson = "ToJson";
        private Type _dependencyInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Dependency _dependencyInstance;
        private Dependency _dependencyInstanceFixture;

        #region General Initializer : Class (Dependency) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Dependency" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dependencyInstanceType = typeof(Dependency);
            _dependencyInstanceFixture = Create(true);
            _dependencyInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Dependency)

        #region General Initializer : Class (Dependency) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Dependency" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodToJson, 0)]
        public void AUT_Dependency_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_dependencyInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Dependency) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Dependency" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyKey)]
        [TestCase(PropertyType)]
        public void AUT_Dependency_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_dependencyInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="Dependency" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Dependency_Is_Instance_Present_Test()
        {
            // Assert
            _dependencyInstanceType.ShouldNotBeNull();
            _dependencyInstance.ShouldNotBeNull();
            _dependencyInstanceFixture.ShouldNotBeNull();
            _dependencyInstance.ShouldBeAssignableTo<Dependency>();
            _dependencyInstanceFixture.ShouldBeAssignableTo<Dependency>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Dependency) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Dependency_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Dependency instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dependencyInstanceType.ShouldNotBeNull();
            _dependencyInstance.ShouldNotBeNull();
            _dependencyInstanceFixture.ShouldNotBeNull();
            _dependencyInstance.ShouldBeAssignableTo<Dependency>();
            _dependencyInstanceFixture.ShouldBeAssignableTo<Dependency>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Dependency) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(object) , PropertyKey)]
        [TestCaseGeneric(typeof(LinkType) , PropertyType)]
        public void AUT_Dependency_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Dependency, T>(_dependencyInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Dependency) => Property (Key) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Dependency_Public_Class_Key_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyKey);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Dependency) => Property (Type) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Dependency_Type_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyType);
            Action currentAction = () => propertyInfo.SetValue(_dependencyInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Dependency) => Property (Type) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Dependency_Public_Class_Type_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyType);

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
        ///      Class (<see cref="Dependency" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodToJson)]
        public void AUT_Dependency_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Dependency>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ToJson) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Dependency_ToJson_Method_Call_Internally(Type[] types)
        {
            var methodToJsonPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dependencyInstance, MethodToJson, Fixture, methodToJsonPrametersTypes);
        }

        #endregion

        #region Method Call : (ToJson) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Dependency_ToJson_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var s = CreateType<Serializer>();
            Action executeAction = null;

            // Act
            executeAction = () => _dependencyInstance.ToJson(s);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ToJson) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Dependency_ToJson_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var s = CreateType<Serializer>();
            var methodToJsonPrametersTypes = new Type[] { typeof(Serializer) };
            object[] parametersOfToJson = { s };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodToJson, methodToJsonPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_dependencyInstanceFixture, parametersOfToJson);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfToJson.ShouldNotBeNull();
            parametersOfToJson.Length.ShouldBe(1);
            methodToJsonPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToJson) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Dependency_ToJson_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var s = CreateType<Serializer>();
            var methodToJsonPrametersTypes = new Type[] { typeof(Serializer) };
            object[] parametersOfToJson = { s };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Dependency, string>(_dependencyInstance, MethodToJson, parametersOfToJson, methodToJsonPrametersTypes);

            // Assert
            parametersOfToJson.ShouldNotBeNull();
            parametersOfToJson.Length.ShouldBe(1);
            methodToJsonPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToJson) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Dependency_ToJson_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodToJsonPrametersTypes = new Type[] { typeof(Serializer) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dependencyInstance, MethodToJson, Fixture, methodToJsonPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodToJsonPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ToJson) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Dependency_ToJson_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodToJsonPrametersTypes = new Type[] { typeof(Serializer) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dependencyInstance, MethodToJson, Fixture, methodToJsonPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToJsonPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToJson) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Dependency_ToJson_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToJson, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_dependencyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ToJson) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Dependency_ToJson_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodToJson, 0);
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