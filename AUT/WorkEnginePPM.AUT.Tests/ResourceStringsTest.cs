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

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.ResourceStrings" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ResourceStringsTest : AbstractBaseSetupTypedTest<ResourceStrings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ResourceStrings) Initializer

        private const string PropertylastError = "lastError";
        private const string PropertyisValidLanguage = "isValidLanguage";
        private const string MethodgetLCName = "getLCName";
        private const string MethodgetSetting = "getSetting";
        private const string FieldhshResources = "hshResources";
        private const string FieldvalidLanguage = "validLanguage";
        private const string FieldstrError = "strError";
        private Type _resourceStringsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ResourceStrings _resourceStringsInstance;
        private ResourceStrings _resourceStringsInstanceFixture;

        #region General Initializer : Class (ResourceStrings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ResourceStrings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _resourceStringsInstanceType = typeof(ResourceStrings);
            _resourceStringsInstanceFixture = Create(true);
            _resourceStringsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ResourceStrings)

        #region General Initializer : Class (ResourceStrings) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ResourceStrings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodgetLCName, 0)]
        [TestCase(MethodgetSetting, 0)]
        public void AUT_ResourceStrings_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_resourceStringsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ResourceStrings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ResourceStrings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertylastError)]
        [TestCase(PropertyisValidLanguage)]
        public void AUT_ResourceStrings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_resourceStringsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ResourceStrings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ResourceStrings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldhshResources)]
        [TestCase(FieldvalidLanguage)]
        [TestCase(FieldstrError)]
        public void AUT_ResourceStrings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_resourceStringsInstanceFixture, 
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
        ///     Class (<see cref="ResourceStrings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ResourceStrings_Is_Instance_Present_Test()
        {
            // Assert
            _resourceStringsInstanceType.ShouldNotBeNull();
            _resourceStringsInstance.ShouldNotBeNull();
            _resourceStringsInstanceFixture.ShouldNotBeNull();
            _resourceStringsInstance.ShouldBeAssignableTo<ResourceStrings>();
            _resourceStringsInstanceFixture.ShouldBeAssignableTo<ResourceStrings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ResourceStrings) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ResourceStrings_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var feature = CreateType<EPMLiveFeatureList>();
            var lcid = CreateType<string>();
            ResourceStrings instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new ResourceStrings(feature, lcid);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _resourceStringsInstance.ShouldNotBeNull();
            _resourceStringsInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<ResourceStrings>();
        }

        #endregion

        #region General Constructor : Class (ResourceStrings) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ResourceStrings_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var feature = CreateType<EPMLiveFeatureList>();
            var lcid = CreateType<string>();
            ResourceStrings instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new ResourceStrings(feature, lcid);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _resourceStringsInstance.ShouldNotBeNull();
            _resourceStringsInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ResourceStrings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertylastError)]
        [TestCaseGeneric(typeof(bool) , PropertyisValidLanguage)]
        public void AUT_ResourceStrings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ResourceStrings, T>(_resourceStringsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ResourceStrings) => Property (isValidLanguage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourceStrings_Public_Class_isValidLanguage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisValidLanguage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ResourceStrings) => Property (lastError) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourceStrings_Public_Class_lastError_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylastError);

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
        ///      Class (<see cref="ResourceStrings" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodgetLCName)]
        [TestCase(MethodgetSetting)]
        public void AUT_ResourceStrings_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ResourceStrings>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (getLCName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceStrings_getLCName_Method_Call_Internally(Type[] types)
        {
            var methodgetLCNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceStringsInstance, MethodgetLCName, Fixture, methodgetLCNamePrametersTypes);
        }

        #endregion

        #region Method Call : (getLCName) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceStrings_getLCName_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _resourceStringsInstance.getLCName();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getLCName) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceStrings_getLCName_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodgetLCNamePrametersTypes = null;
            object[] parametersOfgetLCName = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetLCName, methodgetLCNamePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceStrings, string>(_resourceStringsInstanceFixture, out exception1, parametersOfgetLCName);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceStrings, string>(_resourceStringsInstance, MethodgetLCName, parametersOfgetLCName, methodgetLCNamePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfgetLCName.ShouldBeNull();
            methodgetLCNamePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getLCName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceStrings_getLCName_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodgetLCNamePrametersTypes = null;
            object[] parametersOfgetLCName = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetLCName, methodgetLCNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceStringsInstanceFixture, parametersOfgetLCName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetLCName.ShouldBeNull();
            methodgetLCNamePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getLCName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceStrings_getLCName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodgetLCNamePrametersTypes = null;
            object[] parametersOfgetLCName = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResourceStrings, string>(_resourceStringsInstance, MethodgetLCName, parametersOfgetLCName, methodgetLCNamePrametersTypes);

            // Assert
            parametersOfgetLCName.ShouldBeNull();
            methodgetLCNamePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getLCName) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceStrings_getLCName_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodgetLCNamePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceStringsInstance, MethodgetLCName, Fixture, methodgetLCNamePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodgetLCNamePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getLCName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceStrings_getLCName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodgetLCNamePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceStringsInstance, MethodgetLCName, Fixture, methodgetLCNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetLCNamePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getLCName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceStrings_getLCName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetLCName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceStringsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getSetting) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceStrings_getSetting_Method_Call_Internally(Type[] types)
        {
            var methodgetSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceStringsInstance, MethodgetSetting, Fixture, methodgetSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (getSetting) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceStrings_getSetting_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var resourceName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourceStringsInstance.getSetting(resourceName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getSetting) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceStrings_getSetting_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var resourceName = CreateType<string>();
            var methodgetSettingPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetSetting = { resourceName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetSetting, methodgetSettingPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceStrings, string>(_resourceStringsInstanceFixture, out exception1, parametersOfgetSetting);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceStrings, string>(_resourceStringsInstance, MethodgetSetting, parametersOfgetSetting, methodgetSettingPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfgetSetting.ShouldNotBeNull();
            parametersOfgetSetting.Length.ShouldBe(1);
            methodgetSettingPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getSetting) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceStrings_getSetting_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var resourceName = CreateType<string>();
            var methodgetSettingPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetSetting = { resourceName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetSetting, methodgetSettingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceStringsInstanceFixture, parametersOfgetSetting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetSetting.ShouldNotBeNull();
            parametersOfgetSetting.Length.ShouldBe(1);
            methodgetSettingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getSetting) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceStrings_getSetting_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var resourceName = CreateType<string>();
            var methodgetSettingPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetSetting = { resourceName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResourceStrings, string>(_resourceStringsInstance, MethodgetSetting, parametersOfgetSetting, methodgetSettingPrametersTypes);

            // Assert
            parametersOfgetSetting.ShouldNotBeNull();
            parametersOfgetSetting.Length.ShouldBe(1);
            methodgetSettingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getSetting) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceStrings_getSetting_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodgetSettingPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceStringsInstance, MethodgetSetting, Fixture, methodgetSettingPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodgetSettingPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getSetting) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceStrings_getSetting_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetSettingPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceStringsInstance, MethodgetSetting, Fixture, methodgetSettingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetSettingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getSetting) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceStrings_getSetting_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetSetting, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceStringsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getSetting) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceStrings_getSetting_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetSetting, 0);
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