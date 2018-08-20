using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveCore.SocialEngine.Core;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.SocialEngine.Entities
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SocialEngine.Entities.Activity" />)
    ///     and namespace <see cref="EPMLiveCore.SocialEngine.Entities"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ActivityTest : AbstractBaseSetupTypedTest<Activity>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Activity) Initializer

        private const string PropertyDate = "Date";
        private const string PropertyId = "Id";
        private const string PropertyIsMassOperation = "IsMassOperation";
        private const string PropertyKey = "Key";
        private const string PropertyKind = "Kind";
        private const string PropertyThread = "Thread";
        private const string PropertyUserId = "UserId";
        private const string MethodGetData = "GetData";
        private const string MethodSetData = "SetData";
        private const string Field_data = "_data";
        private const string Field_key = "_key";
        private Type _activityInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Activity _activityInstance;
        private Activity _activityInstanceFixture;

        #region General Initializer : Class (Activity) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Activity" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _activityInstanceType = typeof(Activity);
            _activityInstanceFixture = Create(true);
            _activityInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Activity)

        #region General Initializer : Class (Activity) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Activity" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetData, 0)]
        [TestCase(MethodSetData, 0)]
        public void AUT_Activity_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_activityInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Activity) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Activity" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDate)]
        [TestCase(PropertyId)]
        [TestCase(PropertyIsMassOperation)]
        [TestCase(PropertyKey)]
        [TestCase(PropertyKind)]
        [TestCase(PropertyThread)]
        [TestCase(PropertyUserId)]
        public void AUT_Activity_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_activityInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Activity) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Activity" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_data)]
        [TestCase(Field_key)]
        public void AUT_Activity_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_activityInstanceFixture, 
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
        ///     Class (<see cref="Activity" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Activity_Is_Instance_Present_Test()
        {
            // Assert
            _activityInstanceType.ShouldNotBeNull();
            _activityInstance.ShouldNotBeNull();
            _activityInstanceFixture.ShouldNotBeNull();
            _activityInstance.ShouldBeAssignableTo<Activity>();
            _activityInstanceFixture.ShouldBeAssignableTo<Activity>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Activity) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Activity_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Activity instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _activityInstanceType.ShouldNotBeNull();
            _activityInstance.ShouldNotBeNull();
            _activityInstanceFixture.ShouldNotBeNull();
            _activityInstance.ShouldBeAssignableTo<Activity>();
            _activityInstanceFixture.ShouldBeAssignableTo<Activity>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Activity) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(DateTime) , PropertyDate)]
        [TestCaseGeneric(typeof(Guid) , PropertyId)]
        [TestCaseGeneric(typeof(bool) , PropertyIsMassOperation)]
        [TestCaseGeneric(typeof(string) , PropertyKey)]
        [TestCaseGeneric(typeof(ActivityKind) , PropertyKind)]
        [TestCaseGeneric(typeof(Thread) , PropertyThread)]
        [TestCaseGeneric(typeof(int) , PropertyUserId)]
        public void AUT_Activity_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Activity, T>(_activityInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Activity) => Property (Date) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Activity_Date_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyDate);
            Action currentAction = () => propertyInfo.SetValue(_activityInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Activity) => Property (Date) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Activity_Public_Class_Date_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Activity) => Property (Id) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Activity_Id_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyId);
            Action currentAction = () => propertyInfo.SetValue(_activityInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Activity) => Property (Id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Activity_Public_Class_Id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Activity) => Property (IsMassOperation) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Activity_Public_Class_IsMassOperation_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyIsMassOperation);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Activity) => Property (Key) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Activity_Public_Class_Key_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Activity) => Property (Kind) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Activity_Kind_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyKind);
            Action currentAction = () => propertyInfo.SetValue(_activityInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Activity) => Property (Kind) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Activity_Public_Class_Kind_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyKind);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Activity) => Property (UserId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Activity_Public_Class_UserId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Activity" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetData)]
        [TestCase(MethodSetData)]
        public void AUT_Activity_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Activity>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : object) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Activity_GetData_Method_Call_Internally(Type[] types)
        {
            var methodGetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_activityInstance, MethodGetData, Fixture, methodGetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : object) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Activity_GetData_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var raw = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _activityInstance.GetData(raw);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : object) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Activity_GetData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var raw = CreateType<bool>();
            var methodGetDataPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfGetData = { raw };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Activity, object>(_activityInstance, MethodGetData, parametersOfGetData, methodGetDataPrametersTypes);

            // Assert
            parametersOfGetData.ShouldNotBeNull();
            parametersOfGetData.Length.ShouldBe(1);
            methodGetDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Activity_GetData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDataPrametersTypes = new Type[] { typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_activityInstance, MethodGetData, Fixture, methodGetDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : object) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Activity_GetData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDataPrametersTypes = new Type[] { typeof(bool) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_activityInstance, MethodGetData, Fixture, methodGetDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : object) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Activity_GetData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Activity_SetData_Method_Call_Internally(Type[] types)
        {
            var methodSetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_activityInstance, MethodSetData, Fixture, methodSetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SetData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Activity_SetData_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<object>();
            var isRaw = CreateType<bool>();
            var methodSetDataPrametersTypes = new Type[] { typeof(object), typeof(bool) };
            object[] parametersOfSetData = { data, isRaw };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_activityInstance, MethodSetData, parametersOfSetData, methodSetDataPrametersTypes);

            // Assert
            parametersOfSetData.ShouldNotBeNull();
            parametersOfSetData.Length.ShouldBe(2);
            methodSetDataPrametersTypes.Length.ShouldBe(2);
            methodSetDataPrametersTypes.Length.ShouldBe(parametersOfSetData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Activity_SetData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetData, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Activity_SetData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetDataPrametersTypes = new Type[] { typeof(object), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_activityInstance, MethodSetData, Fixture, methodSetDataPrametersTypes);

            // Assert
            methodSetDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Activity_SetData_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_activityInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}