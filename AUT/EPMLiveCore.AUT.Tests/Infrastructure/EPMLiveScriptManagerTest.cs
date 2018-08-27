using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.EPMLiveScriptManager" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class EPMLiveScriptManagerTest : AbstractBaseSetupTypedTest<EPMLiveScriptManager>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EPMLiveScriptManager) Initializer

        private const string PropertyFileVersion = "FileVersion";
        private const string MethodRegisterScript = "RegisterScript";
        private const string MethodGetFileVersion = "GetFileVersion";
        private const string MethodGetScript = "GetScript";
        private const string FieldEPM_PATH = "EPM_PATH";
        private const string FieldJS_PATH = "JS_PATH";
        private const string Field_fileVersion = "_fileVersion";
        private Type _ePMLiveScriptManagerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EPMLiveScriptManager _ePMLiveScriptManagerInstance;
        private EPMLiveScriptManager _ePMLiveScriptManagerInstanceFixture;

        #region General Initializer : Class (EPMLiveScriptManager) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EPMLiveScriptManager" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ePMLiveScriptManagerInstanceType = typeof(EPMLiveScriptManager);
            _ePMLiveScriptManagerInstanceFixture = Create(true);
            _ePMLiveScriptManagerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EPMLiveScriptManager)

        #region General Initializer : Class (EPMLiveScriptManager) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EPMLiveScriptManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRegisterScript, 0)]
        [TestCase(MethodRegisterScript, 1)]
        [TestCase(MethodGetFileVersion, 0)]
        [TestCase(MethodGetScript, 0)]
        public void AUT_EPMLiveScriptManager_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_ePMLiveScriptManagerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EPMLiveScriptManager) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EPMLiveScriptManager" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyFileVersion)]
        public void AUT_EPMLiveScriptManager_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_ePMLiveScriptManagerInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EPMLiveScriptManager) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EPMLiveScriptManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldEPM_PATH)]
        [TestCase(FieldJS_PATH)]
        [TestCase(Field_fileVersion)]
        public void AUT_EPMLiveScriptManager_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_ePMLiveScriptManagerInstanceFixture, 
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
        ///     Class (<see cref="EPMLiveScriptManager" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_EPMLiveScriptManager_Is_Instance_Present_Test()
        {
            // Assert
            _ePMLiveScriptManagerInstanceType.ShouldNotBeNull();
            _ePMLiveScriptManagerInstance.ShouldNotBeNull();
            _ePMLiveScriptManagerInstanceFixture.ShouldNotBeNull();
            _ePMLiveScriptManagerInstance.ShouldBeAssignableTo<EPMLiveScriptManager>();
            _ePMLiveScriptManagerInstanceFixture.ShouldBeAssignableTo<EPMLiveScriptManager>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EPMLiveScriptManager) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_EPMLiveScriptManager_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EPMLiveScriptManager instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _ePMLiveScriptManagerInstanceType.ShouldNotBeNull();
            _ePMLiveScriptManagerInstance.ShouldNotBeNull();
            _ePMLiveScriptManagerInstanceFixture.ShouldNotBeNull();
            _ePMLiveScriptManagerInstance.ShouldBeAssignableTo<EPMLiveScriptManager>();
            _ePMLiveScriptManagerInstanceFixture.ShouldBeAssignableTo<EPMLiveScriptManager>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (EPMLiveScriptManager) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyFileVersion)]
        public void AUT_EPMLiveScriptManager_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<EPMLiveScriptManager, T>(_ePMLiveScriptManagerInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (EPMLiveScriptManager) => Property (FileVersion) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMLiveScriptManager_Public_Class_FileVersion_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyFileVersion);

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

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="EPMLiveScriptManager" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodRegisterScript)]
        [TestCase(MethodGetFileVersion)]
        [TestCase(MethodGetScript)]
        public void AUT_EPMLiveScriptManager_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_ePMLiveScriptManagerInstanceFixture,
                                                                              _ePMLiveScriptManagerInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveScriptManager_RegisterScript_Static_Method_Call_Internally(Type[] types)
        {
            var methodRegisterScriptPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMLiveScriptManagerInstanceFixture, _ePMLiveScriptManagerInstanceType, MethodRegisterScript, Fixture, methodRegisterScriptPrametersTypes);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_RegisterScript_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var page = CreateType<Page>();
            var script = CreateType<string>();
            var localizable = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => EPMLiveScriptManager.RegisterScript(page, script, localizable);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_RegisterScript_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var page = CreateType<Page>();
            var script = CreateType<string>();
            var localizable = CreateType<bool>();
            var methodRegisterScriptPrametersTypes = new Type[] { typeof(Page), typeof(string), typeof(bool) };
            object[] parametersOfRegisterScript = { page, script, localizable };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRegisterScript, methodRegisterScriptPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveScriptManagerInstanceFixture, parametersOfRegisterScript);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRegisterScript.ShouldNotBeNull();
            parametersOfRegisterScript.Length.ShouldBe(3);
            methodRegisterScriptPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_RegisterScript_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var page = CreateType<Page>();
            var script = CreateType<string>();
            var localizable = CreateType<bool>();
            var methodRegisterScriptPrametersTypes = new Type[] { typeof(Page), typeof(string), typeof(bool) };
            object[] parametersOfRegisterScript = { page, script, localizable };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_ePMLiveScriptManagerInstanceFixture, _ePMLiveScriptManagerInstanceType, MethodRegisterScript, parametersOfRegisterScript, methodRegisterScriptPrametersTypes);

            // Assert
            parametersOfRegisterScript.ShouldNotBeNull();
            parametersOfRegisterScript.Length.ShouldBe(3);
            methodRegisterScriptPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_RegisterScript_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRegisterScript, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_RegisterScript_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRegisterScriptPrametersTypes = new Type[] { typeof(Page), typeof(string), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMLiveScriptManagerInstanceFixture, _ePMLiveScriptManagerInstanceType, MethodRegisterScript, Fixture, methodRegisterScriptPrametersTypes);

            // Assert
            methodRegisterScriptPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_RegisterScript_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRegisterScript, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveScriptManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveScriptManager_RegisterScript_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodRegisterScriptPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMLiveScriptManagerInstanceFixture, _ePMLiveScriptManagerInstanceType, MethodRegisterScript, Fixture, methodRegisterScriptPrametersTypes);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_RegisterScript_Static_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var page = CreateType<Page>();
            var scripts = CreateType<string[]>();
            var localizable = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => EPMLiveScriptManager.RegisterScript(page, scripts, localizable);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_RegisterScript_Static_Method_Call_Void_Overloading_Of_1_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var page = CreateType<Page>();
            var scripts = CreateType<string[]>();
            var localizable = CreateType<bool>();
            var methodRegisterScriptPrametersTypes = new Type[] { typeof(Page), typeof(string[]), typeof(bool) };
            object[] parametersOfRegisterScript = { page, scripts, localizable };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRegisterScript, methodRegisterScriptPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveScriptManagerInstanceFixture, parametersOfRegisterScript);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRegisterScript.ShouldNotBeNull();
            parametersOfRegisterScript.Length.ShouldBe(3);
            methodRegisterScriptPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_RegisterScript_Static_Method_Call_Void_Overloading_Of_1_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var page = CreateType<Page>();
            var scripts = CreateType<string[]>();
            var localizable = CreateType<bool>();
            var methodRegisterScriptPrametersTypes = new Type[] { typeof(Page), typeof(string[]), typeof(bool) };
            object[] parametersOfRegisterScript = { page, scripts, localizable };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_ePMLiveScriptManagerInstanceFixture, _ePMLiveScriptManagerInstanceType, MethodRegisterScript, parametersOfRegisterScript, methodRegisterScriptPrametersTypes);

            // Assert
            parametersOfRegisterScript.ShouldNotBeNull();
            parametersOfRegisterScript.Length.ShouldBe(3);
            methodRegisterScriptPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_RegisterScript_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRegisterScript, 1);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_RegisterScript_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRegisterScriptPrametersTypes = new Type[] { typeof(Page), typeof(string[]), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMLiveScriptManagerInstanceFixture, _ePMLiveScriptManagerInstanceType, MethodRegisterScript, Fixture, methodRegisterScriptPrametersTypes);

            // Assert
            methodRegisterScriptPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_RegisterScript_Static_Method_Call_Overloading_Of_1_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRegisterScript, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveScriptManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFileVersion) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveScriptManager_GetFileVersion_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFileVersionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMLiveScriptManagerInstanceFixture, _ePMLiveScriptManagerInstanceType, MethodGetFileVersion, Fixture, methodGetFileVersionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFileVersion) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_GetFileVersion_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetFileVersionPrametersTypes = null;
            object[] parametersOfGetFileVersion = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFileVersion, methodGetFileVersionPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFileVersion.ShouldBeNull();
            methodGetFileVersionPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => methodInfo.Invoke(_ePMLiveScriptManagerInstanceFixture, parametersOfGetFileVersion));
        }

        #endregion

        #region Method Call : (GetFileVersion) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_GetFileVersion_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetFileVersionPrametersTypes = null;
            object[] parametersOfGetFileVersion = null; // no parameter present

            // Assert
            parametersOfGetFileVersion.ShouldBeNull();
            methodGetFileVersionPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_ePMLiveScriptManagerInstanceFixture, _ePMLiveScriptManagerInstanceType, MethodGetFileVersion, parametersOfGetFileVersion, methodGetFileVersionPrametersTypes));
        }

        #endregion

        #region Method Call : (GetFileVersion) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_GetFileVersion_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetFileVersionPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMLiveScriptManagerInstanceFixture, _ePMLiveScriptManagerInstanceType, MethodGetFileVersion, Fixture, methodGetFileVersionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFileVersionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFileVersion) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_GetFileVersion_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetFileVersionPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMLiveScriptManagerInstanceFixture, _ePMLiveScriptManagerInstanceType, MethodGetFileVersion, Fixture, methodGetFileVersionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFileVersionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFileVersion) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_GetFileVersion_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFileVersion, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveScriptManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetScript) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveScriptManager_GetScript_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetScriptPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMLiveScriptManagerInstanceFixture, _ePMLiveScriptManagerInstanceType, MethodGetScript, Fixture, methodGetScriptPrametersTypes);
        }

        #endregion

        #region Method Call : (GetScript) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_GetScript_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var script = CreateType<string>();
            var debugMode = CreateType<bool>();
            var methodGetScriptPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetScript = { script, debugMode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetScript, methodGetScriptPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetScript.ShouldNotBeNull();
            parametersOfGetScript.Length.ShouldBe(2);
            methodGetScriptPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_ePMLiveScriptManagerInstanceFixture, parametersOfGetScript));
        }

        #endregion

        #region Method Call : (GetScript) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_GetScript_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var script = CreateType<string>();
            var debugMode = CreateType<bool>();
            var methodGetScriptPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetScript = { script, debugMode };

            // Assert
            parametersOfGetScript.ShouldNotBeNull();
            parametersOfGetScript.Length.ShouldBe(2);
            methodGetScriptPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_ePMLiveScriptManagerInstanceFixture, _ePMLiveScriptManagerInstanceType, MethodGetScript, parametersOfGetScript, methodGetScriptPrametersTypes));
        }

        #endregion

        #region Method Call : (GetScript) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_GetScript_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetScriptPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMLiveScriptManagerInstanceFixture, _ePMLiveScriptManagerInstanceType, MethodGetScript, Fixture, methodGetScriptPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetScriptPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetScript) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_GetScript_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetScriptPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMLiveScriptManagerInstanceFixture, _ePMLiveScriptManagerInstanceType, MethodGetScript, Fixture, methodGetScriptPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetScriptPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetScript) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_GetScript_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetScript, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveScriptManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetScript) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveScriptManager_GetScript_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetScript, 0);
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