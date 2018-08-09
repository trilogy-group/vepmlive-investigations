using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveCore.SSRS2010;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Jobs.SSRS
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.SSRS.ExtensionMethods" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.SSRS"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ExtensionMethodsTest : AbstractBaseSetupTest
    {
        public ExtensionMethodsTest() : base(typeof(ExtensionMethods))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ExtensionMethods) Initializer

        private const string MethodGetRole = "GetRole";
        private const string MethodGetStringValue = "GetStringValue";
        private const string MethodGetBooleanValue = "GetBooleanValue";
        private Type _extensionMethodsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (ExtensionMethods) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ExtensionMethods" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _extensionMethodsInstanceType = typeof(ExtensionMethods);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ExtensionMethods)

        #region General Initializer : Class (ExtensionMethods) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ExtensionMethods" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetRole, 0)]
        [TestCase(MethodGetStringValue, 0)]
        [TestCase(MethodGetBooleanValue, 0)]
        public void AUT_ExtensionMethods_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(null, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ExtensionMethods" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ExtensionMethods_Is_Static_Type_Present_Test()
        {
            // Assert
            _extensionMethodsInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ExtensionMethods" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetRole)]
        [TestCase(MethodGetStringValue)]
        [TestCase(MethodGetBooleanValue)]
        public void AUT_ExtensionMethods_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _extensionMethodsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetRole) (Return Type : Role) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_GetRole_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRolePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetRole, Fixture, methodGetRolePrametersTypes);
        }

        #endregion

        #region Method Call : (GetRole) (Return Type : Role) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetRole_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var roles = CreateType<Role[]>();
            var role = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.GetRole(roles, role);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetRole) (Return Type : Role) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetRole_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var roles = CreateType<Role[]>();
            var role = CreateType<string>();
            var methodGetRolePrametersTypes = new Type[] { typeof(Role[]), typeof(string) };
            object[] parametersOfGetRole = { roles, role };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRole, methodGetRolePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetRole, Fixture, methodGetRolePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Role>(null, _extensionMethodsInstanceType, MethodGetRole, parametersOfGetRole, methodGetRolePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetRole);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRole.ShouldNotBeNull();
            parametersOfGetRole.Length.ShouldBe(2);
            methodGetRolePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetRole) (Return Type : Role) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetRole_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var roles = CreateType<Role[]>();
            var role = CreateType<string>();
            var methodGetRolePrametersTypes = new Type[] { typeof(Role[]), typeof(string) };
            object[] parametersOfGetRole = { roles, role };

            // Assert
            parametersOfGetRole.ShouldNotBeNull();
            parametersOfGetRole.Length.ShouldBe(2);
            methodGetRolePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Role>(null, _extensionMethodsInstanceType, MethodGetRole, parametersOfGetRole, methodGetRolePrametersTypes));
        }

        #endregion

        #region Method Call : (GetRole) (Return Type : Role) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetRole_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRolePrametersTypes = new Type[] { typeof(Role[]), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetRole, Fixture, methodGetRolePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRolePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetRole) (Return Type : Role) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetRole_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRolePrametersTypes = new Type[] { typeof(Role[]), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetRole, Fixture, methodGetRolePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRolePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRole) (Return Type : Role) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetRole_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRole, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRole) (Return Type : Role) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetRole_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRole, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetStringValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_GetStringValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetStringValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetStringValue, Fixture, methodGetStringValuePrametersTypes);
        }

        #endregion
        
        #region Method Call : (GetStringValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetStringValue_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var path = CreateType<string>();
            var methodGetStringValuePrametersTypes = new Type[] { typeof(XmlDocument), typeof(string) };
            object[] parametersOfGetStringValue = { doc, path };

            // Assert
            parametersOfGetStringValue.ShouldNotBeNull();
            parametersOfGetStringValue.Length.ShouldBe(2);
            methodGetStringValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodGetStringValue, parametersOfGetStringValue, methodGetStringValuePrametersTypes));
        }

        #endregion

        #region Method Call : (GetStringValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetStringValue_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetStringValuePrametersTypes = new Type[] { typeof(XmlDocument), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetStringValue, Fixture, methodGetStringValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetStringValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetStringValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetStringValue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetStringValuePrametersTypes = new Type[] { typeof(XmlDocument), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetStringValue, Fixture, methodGetStringValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetStringValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetStringValue) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetStringValue_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetStringValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetStringValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetStringValue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetStringValue, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBooleanValue) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_GetBooleanValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetBooleanValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetBooleanValue, Fixture, methodGetBooleanValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetBooleanValue) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetBooleanValue_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var path = CreateType<string>();
            var methodGetBooleanValuePrametersTypes = new Type[] { typeof(XmlDocument), typeof(string) };
            object[] parametersOfGetBooleanValue = { doc, path };

            // Assert
            parametersOfGetBooleanValue.ShouldNotBeNull();
            parametersOfGetBooleanValue.Length.ShouldBe(2);
            methodGetBooleanValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodGetBooleanValue, parametersOfGetBooleanValue, methodGetBooleanValuePrametersTypes));
        }

        #endregion

        #region Method Call : (GetBooleanValue) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetBooleanValue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetBooleanValuePrametersTypes = new Type[] { typeof(XmlDocument), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetBooleanValue, Fixture, methodGetBooleanValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetBooleanValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBooleanValue) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetBooleanValue_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBooleanValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBooleanValue) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetBooleanValue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetBooleanValue, 0);
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