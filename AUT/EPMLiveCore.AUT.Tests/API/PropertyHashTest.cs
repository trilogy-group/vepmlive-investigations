using System;
using System.Collections;
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

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.PropertyHash" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class PropertyHashTest : AbstractBaseSetupTypedTest<PropertyHash>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PropertyHash) Initializer

        private const string PropertyKeys = "Keys";
        private const string PropertyValues = "Values";
        private const string PropertyIsReadOnly = "IsReadOnly";
        private const string PropertyCount = "Count";
        private const string MethodGetEnumerator = "GetEnumerator";
        private const string MethodAdd = "Add";
        private const string MethodUpdate = "Update";
        private const string MethodRemove = "Remove";
        private const string MethodClear = "Clear";
        private const string MethodTryGetValue = "TryGetValue";
        private const string MethodContains = "Contains";
        private const string MethodCopyTo = "CopyTo";
        private const string MethodContainsKey = "ContainsKey";
        private const string MethodloadProps = "loadProps";
        private const string MethodGetKeyValue = "GetKeyValue";
        private const string MethodToString = "ToString";
        private const string Field_props = "_props";
        private const string Field_CollectionSeperator = "_CollectionSeperator";
        private const string Field_ItemSeperator = "_ItemSeperator";
        private const string Field_KeySeperator = "_KeySeperator";
        private Type _propertyHashInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PropertyHash _propertyHashInstance;
        private PropertyHash _propertyHashInstanceFixture;

        #region General Initializer : Class (PropertyHash) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PropertyHash" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _propertyHashInstanceType = typeof(PropertyHash);
            _propertyHashInstanceFixture = Create(true);
            _propertyHashInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PropertyHash)

        #region General Initializer : Class (PropertyHash) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="PropertyHash" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetEnumerator, 0)]
        [TestCase(MethodAdd, 0)]
        [TestCase(MethodAdd, 1)]
        [TestCase(MethodAdd, 2)]
        [TestCase(MethodUpdate, 0)]
        [TestCase(MethodRemove, 0)]
        [TestCase(MethodRemove, 1)]
        [TestCase(MethodClear, 0)]
        [TestCase(MethodTryGetValue, 0)]
        [TestCase(MethodContains, 0)]
        [TestCase(MethodCopyTo, 0)]
        [TestCase(MethodContainsKey, 0)]
        [TestCase(MethodloadProps, 0)]
        [TestCase(MethodGetKeyValue, 0)]
        [TestCase(MethodToString, 0)]
        public void AUT_PropertyHash_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_propertyHashInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PropertyHash) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PropertyHash" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyKeys)]
        [TestCase(PropertyValues)]
        [TestCase(PropertyIsReadOnly)]
        [TestCase(PropertyCount)]
        public void AUT_PropertyHash_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_propertyHashInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PropertyHash) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PropertyHash" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_props)]
        [TestCase(Field_CollectionSeperator)]
        [TestCase(Field_ItemSeperator)]
        [TestCase(Field_KeySeperator)]
        public void AUT_PropertyHash_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_propertyHashInstanceFixture, 
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
        ///     Class (<see cref="PropertyHash" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PropertyHash_Is_Instance_Present_Test()
        {
            // Assert
            _propertyHashInstanceType.ShouldNotBeNull();
            _propertyHashInstance.ShouldNotBeNull();
            _propertyHashInstanceFixture.ShouldNotBeNull();
            _propertyHashInstance.ShouldBeAssignableTo<PropertyHash>();
            _propertyHashInstanceFixture.ShouldBeAssignableTo<PropertyHash>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PropertyHash) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PropertyHash_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var values = CreateType<string>();
            var CollectionSeperator = CreateType<string>();
            var ItemSeperator = CreateType<char>();
            var KeySeperator = CreateType<char>();
            PropertyHash instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new PropertyHash(values, CollectionSeperator, ItemSeperator, KeySeperator);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _propertyHashInstance.ShouldNotBeNull();
            _propertyHashInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<PropertyHash>();
        }

        #endregion

        #region General Constructor : Class (PropertyHash) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PropertyHash_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var values = CreateType<string>();
            var CollectionSeperator = CreateType<string>();
            var ItemSeperator = CreateType<char>();
            var KeySeperator = CreateType<char>();
            PropertyHash instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new PropertyHash(values, CollectionSeperator, ItemSeperator, KeySeperator);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _propertyHashInstance.ShouldNotBeNull();
            _propertyHashInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (PropertyHash) instance created

        /// <summary>
        ///     Class (<see cref="PropertyHash" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PropertyHash_Is_Created_Test()
        {
            // Assert
            _propertyHashInstance.ShouldNotBeNull();
            _propertyHashInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (PropertyHash) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="PropertyHash" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_PropertyHash_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<PropertyHash>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (PropertyHash) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="PropertyHash" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PropertyHash_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<PropertyHash>(Fixture);
        }

        #endregion

        #region General Constructor : Class (PropertyHash) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="PropertyHash" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PropertyHash_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var values = CreateType<string>();
            var CollectionSeperator = CreateType<string>();
            var ItemSeperator = CreateType<char>();
            var KeySeperator = CreateType<char>();
            object[] parametersOfPropertyHash = { values, CollectionSeperator, ItemSeperator, KeySeperator };
            var methodPropertyHashPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(char), typeof(char) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_propertyHashInstanceType, methodPropertyHashPrametersTypes, parametersOfPropertyHash);
        }

        #endregion

        #region General Constructor : Class (PropertyHash) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="PropertyHash" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PropertyHash_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodPropertyHashPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(char), typeof(char) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_propertyHashInstanceType, Fixture, methodPropertyHashPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (PropertyHash) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="PropertyHash" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PropertyHash_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var values = CreateType<string>();
            object[] parametersOfPropertyHash = { values };
            var methodPropertyHashPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_propertyHashInstanceType, methodPropertyHashPrametersTypes, parametersOfPropertyHash);
        }

        #endregion

        #region General Constructor : Class (PropertyHash) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="PropertyHash" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PropertyHash_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodPropertyHashPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_propertyHashInstanceType, Fixture, methodPropertyHashPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PropertyHash) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ICollection<int>) , PropertyKeys)]
        [TestCaseGeneric(typeof(ICollection<Dictionary<object, object>>) , PropertyValues)]
        [TestCaseGeneric(typeof(bool) , PropertyIsReadOnly)]
        [TestCaseGeneric(typeof(int) , PropertyCount)]
        public void AUT_PropertyHash_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<PropertyHash, T>(_propertyHashInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (PropertyHash) => Property (Count) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PropertyHash_Public_Class_Count_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PropertyHash) => Property (IsReadOnly) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PropertyHash_Public_Class_IsReadOnly_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyIsReadOnly);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PropertyHash) => Property (Keys) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PropertyHash_Public_Class_Keys_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyKeys);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PropertyHash) => Property (Values) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PropertyHash_Public_Class_Values_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyValues);

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
        ///      Class (<see cref="PropertyHash" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetEnumerator)]
        [TestCase(MethodAdd)]
        [TestCase(MethodUpdate)]
        [TestCase(MethodRemove)]
        [TestCase(MethodClear)]
        [TestCase(MethodTryGetValue)]
        [TestCase(MethodContains)]
        [TestCase(MethodCopyTo)]
        [TestCase(MethodContainsKey)]
        [TestCase(MethodloadProps)]
        [TestCase(MethodGetKeyValue)]
        [TestCase(MethodToString)]
        public void AUT_PropertyHash_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<PropertyHash>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetEnumerator) (Return Type : IEnumerator<KeyValuePair<int, Dictionary<object, object>>>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PropertyHash_GetEnumerator_Method_Call_Internally(Type[] types)
        {
            var methodGetEnumeratorPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodGetEnumerator, Fixture, methodGetEnumeratorPrametersTypes);
        }

        #endregion

        #region Method Call : (GetEnumerator) (Return Type : IEnumerator<KeyValuePair<int, Dictionary<object, object>>>) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_GetEnumerator_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _propertyHashInstance.GetEnumerator();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetEnumerator) (Return Type : IEnumerator<KeyValuePair<int, Dictionary<object, object>>>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_GetEnumerator_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetEnumeratorPrametersTypes = null;
            object[] parametersOfGetEnumerator = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetEnumerator, methodGetEnumeratorPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetEnumerator.ShouldBeNull();
            methodGetEnumeratorPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => methodInfo.Invoke(_propertyHashInstanceFixture, parametersOfGetEnumerator));
        }

        #endregion

        #region Method Call : (GetEnumerator) (Return Type : IEnumerator<KeyValuePair<int, Dictionary<object, object>>>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_GetEnumerator_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetEnumeratorPrametersTypes = null;
            object[] parametersOfGetEnumerator = null; // no parameter present

            // Assert
            parametersOfGetEnumerator.ShouldBeNull();
            methodGetEnumeratorPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<PropertyHash, IEnumerator<KeyValuePair<int, Dictionary<object, object>>>>(_propertyHashInstance, MethodGetEnumerator, parametersOfGetEnumerator, methodGetEnumeratorPrametersTypes));
        }

        #endregion

        #region Method Call : (GetEnumerator) (Return Type : IEnumerator<KeyValuePair<int, Dictionary<object, object>>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_GetEnumerator_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetEnumeratorPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodGetEnumerator, Fixture, methodGetEnumeratorPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetEnumeratorPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetEnumerator) (Return Type : IEnumerator<KeyValuePair<int, Dictionary<object, object>>>) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_GetEnumerator_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetEnumeratorPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodGetEnumerator, Fixture, methodGetEnumeratorPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetEnumeratorPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetEnumerator) (Return Type : IEnumerator<KeyValuePair<int, Dictionary<object, object>>>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_GetEnumerator_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetEnumeratorPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodGetEnumerator, Fixture, methodGetEnumeratorPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetEnumeratorPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetEnumerator) (Return Type : IEnumerator<KeyValuePair<int, Dictionary<object, object>>>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_GetEnumerator_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetEnumerator, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_propertyHashInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetEnumerator) (Return Type : IEnumerator) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PropertyHash_GetEnumerator_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetEnumeratorPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodGetEnumerator, Fixture, methodGetEnumeratorPrametersTypes);
        }

        #endregion

        #region Method Call : (GetEnumerator) (Return Type : IEnumerator) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_GetEnumerator_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetEnumeratorPrametersTypes = null;
            object[] parametersOfGetEnumerator = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetEnumerator, methodGetEnumeratorPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetEnumerator.ShouldBeNull();
            methodGetEnumeratorPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => methodInfo.Invoke(_propertyHashInstanceFixture, parametersOfGetEnumerator));
        }

        #endregion

        #region Method Call : (GetEnumerator) (Return Type : IEnumerator) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_GetEnumerator_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetEnumeratorPrametersTypes = null;
            object[] parametersOfGetEnumerator = null; // no parameter present

            // Assert
            parametersOfGetEnumerator.ShouldBeNull();
            methodGetEnumeratorPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<PropertyHash, IEnumerator>(_propertyHashInstance, MethodGetEnumerator, parametersOfGetEnumerator, methodGetEnumeratorPrametersTypes));
        }

        #endregion

        #region Method Call : (GetEnumerator) (Return Type : IEnumerator) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_GetEnumerator_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetEnumeratorPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodGetEnumerator, Fixture, methodGetEnumeratorPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetEnumeratorPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetEnumerator) (Return Type : IEnumerator) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_GetEnumerator_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetEnumeratorPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodGetEnumerator, Fixture, methodGetEnumeratorPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetEnumeratorPrametersTypes.ShouldBeNull();
        }

        #endregion
        
        #region Method Call : (Add) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PropertyHash_Add_Method_Call_Internally(Type[] types)
        {
            var methodAddPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodAdd, Fixture, methodAddPrametersTypes);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Add_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var pair = CreateType<KeyValuePair<int, Dictionary<object, object>>>();
            Action executeAction = null;

            // Act
            executeAction = () => _propertyHashInstance.Add(pair);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Add_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var pair = CreateType<KeyValuePair<int, Dictionary<object, object>>>();
            var methodAddPrametersTypes = new Type[] { typeof(KeyValuePair<int, Dictionary<object, object>>) };
            object[] parametersOfAdd = { pair };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAdd, methodAddPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_propertyHashInstanceFixture, parametersOfAdd);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAdd.ShouldNotBeNull();
            parametersOfAdd.Length.ShouldBe(1);
            methodAddPrametersTypes.Length.ShouldBe(1);
            methodAddPrametersTypes.Length.ShouldBe(parametersOfAdd.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Add_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var pair = CreateType<KeyValuePair<int, Dictionary<object, object>>>();
            var methodAddPrametersTypes = new Type[] { typeof(KeyValuePair<int, Dictionary<object, object>>) };
            object[] parametersOfAdd = { pair };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_propertyHashInstance, MethodAdd, parametersOfAdd, methodAddPrametersTypes);

            // Assert
            parametersOfAdd.ShouldNotBeNull();
            parametersOfAdd.Length.ShouldBe(1);
            methodAddPrametersTypes.Length.ShouldBe(1);
            methodAddPrametersTypes.Length.ShouldBe(parametersOfAdd.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Add_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAdd, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Add_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddPrametersTypes = new Type[] { typeof(KeyValuePair<int, Dictionary<object, object>>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodAdd, Fixture, methodAddPrametersTypes);

            // Assert
            methodAddPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Add_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAdd, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_propertyHashInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PropertyHash_Add_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodAddPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodAdd, Fixture, methodAddPrametersTypes);
        }

        #endregion
        
        #region Method Call : (Add) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Add_Method_Call_Void_Overloading_Of_1_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var key = CreateType<int>();
            var value = CreateType<Dictionary<object, object>>();
            var methodAddPrametersTypes = new Type[] { typeof(int), typeof(Dictionary<object, object>) };
            object[] parametersOfAdd = { key, value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAdd, methodAddPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_propertyHashInstanceFixture, parametersOfAdd);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAdd.ShouldNotBeNull();
            parametersOfAdd.Length.ShouldBe(2);
            methodAddPrametersTypes.Length.ShouldBe(2);
            methodAddPrametersTypes.Length.ShouldBe(parametersOfAdd.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Add_Method_Call_Void_Overloading_Of_1_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var key = CreateType<int>();
            var value = CreateType<Dictionary<object, object>>();
            var methodAddPrametersTypes = new Type[] { typeof(int), typeof(Dictionary<object, object>) };
            object[] parametersOfAdd = { key, value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_propertyHashInstance, MethodAdd, parametersOfAdd, methodAddPrametersTypes);

            // Assert
            parametersOfAdd.ShouldNotBeNull();
            parametersOfAdd.Length.ShouldBe(2);
            methodAddPrametersTypes.Length.ShouldBe(2);
            methodAddPrametersTypes.Length.ShouldBe(parametersOfAdd.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Add_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAdd, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Add_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddPrametersTypes = new Type[] { typeof(int), typeof(Dictionary<object, object>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodAdd, Fixture, methodAddPrametersTypes);

            // Assert
            methodAddPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Add_Method_Call_Overloading_Of_1_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAdd, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_propertyHashInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PropertyHash_Add_Method_Overloading_Of_2_Call_Internally(Type[] types)
        {
            var methodAddPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodAdd, Fixture, methodAddPrametersTypes);
        }

        #endregion
        
        #region Method Call : (Add) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Add_Method_Call_Void_Overloading_Of_2_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var values = CreateType<string>();
            var methodAddPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAdd = { values };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAdd, methodAddPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_propertyHashInstanceFixture, parametersOfAdd);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAdd.ShouldNotBeNull();
            parametersOfAdd.Length.ShouldBe(1);
            methodAddPrametersTypes.Length.ShouldBe(1);
            methodAddPrametersTypes.Length.ShouldBe(parametersOfAdd.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Add_Method_Call_Void_Overloading_Of_2_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var values = CreateType<string>();
            var methodAddPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAdd = { values };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_propertyHashInstance, MethodAdd, parametersOfAdd, methodAddPrametersTypes);

            // Assert
            parametersOfAdd.ShouldNotBeNull();
            parametersOfAdd.Length.ShouldBe(1);
            methodAddPrametersTypes.Length.ShouldBe(1);
            methodAddPrametersTypes.Length.ShouldBe(parametersOfAdd.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Add_Method_Call_Overloading_Of_2_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAdd, 2);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Add_Method_Call_Overloading_Of_2_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodAdd, Fixture, methodAddPrametersTypes);

            // Assert
            methodAddPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Add_Method_Call_Overloading_Of_2_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAdd, 2);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_propertyHashInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PropertyHash_Update_Method_Call_Internally(Type[] types)
        {
            var methodUpdatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodUpdate, Fixture, methodUpdatePrametersTypes);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Update_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var key = CreateType<int>();
            var val = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _propertyHashInstance.Update(key, val);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Update_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var key = CreateType<int>();
            var val = CreateType<string>();
            var methodUpdatePrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfUpdate = { key, val };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdate, methodUpdatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_propertyHashInstanceFixture, parametersOfUpdate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdate.ShouldNotBeNull();
            parametersOfUpdate.Length.ShouldBe(2);
            methodUpdatePrametersTypes.Length.ShouldBe(2);
            methodUpdatePrametersTypes.Length.ShouldBe(parametersOfUpdate.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Update_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var key = CreateType<int>();
            var val = CreateType<string>();
            var methodUpdatePrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfUpdate = { key, val };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_propertyHashInstance, MethodUpdate, parametersOfUpdate, methodUpdatePrametersTypes);

            // Assert
            parametersOfUpdate.ShouldNotBeNull();
            parametersOfUpdate.Length.ShouldBe(2);
            methodUpdatePrametersTypes.Length.ShouldBe(2);
            methodUpdatePrametersTypes.Length.ShouldBe(parametersOfUpdate.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Update_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdate, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Update_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdatePrametersTypes = new Type[] { typeof(int), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodUpdate, Fixture, methodUpdatePrametersTypes);

            // Assert
            methodUpdatePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Update_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdate, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_propertyHashInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PropertyHash_Remove_Method_Call_Internally(Type[] types)
        {
            var methodRemovePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodRemove, Fixture, methodRemovePrametersTypes);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Remove_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var pair = CreateType<KeyValuePair<int, Dictionary<object, object>>>();
            Action executeAction = null;

            // Act
            executeAction = () => _propertyHashInstance.Remove(pair);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Remove_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var pair = CreateType<KeyValuePair<int, Dictionary<object, object>>>();
            var methodRemovePrametersTypes = new Type[] { typeof(KeyValuePair<int, Dictionary<object, object>>) };
            object[] parametersOfRemove = { pair };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRemove, methodRemovePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PropertyHash, bool>(_propertyHashInstanceFixture, out exception1, parametersOfRemove);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PropertyHash, bool>(_propertyHashInstance, MethodRemove, parametersOfRemove, methodRemovePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRemove.ShouldNotBeNull();
            parametersOfRemove.Length.ShouldBe(1);
            methodRemovePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<PropertyHash, bool>(_propertyHashInstance, MethodRemove, parametersOfRemove, methodRemovePrametersTypes));
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Remove_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var pair = CreateType<KeyValuePair<int, Dictionary<object, object>>>();
            var methodRemovePrametersTypes = new Type[] { typeof(KeyValuePair<int, Dictionary<object, object>>) };
            object[] parametersOfRemove = { pair };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRemove, methodRemovePrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRemove.ShouldNotBeNull();
            parametersOfRemove.Length.ShouldBe(1);
            methodRemovePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_propertyHashInstanceFixture, parametersOfRemove));
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Remove_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var pair = CreateType<KeyValuePair<int, Dictionary<object, object>>>();
            var methodRemovePrametersTypes = new Type[] { typeof(KeyValuePair<int, Dictionary<object, object>>) };
            object[] parametersOfRemove = { pair };

            // Assert
            parametersOfRemove.ShouldNotBeNull();
            parametersOfRemove.Length.ShouldBe(1);
            methodRemovePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<PropertyHash, bool>(_propertyHashInstance, MethodRemove, parametersOfRemove, methodRemovePrametersTypes));
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Remove_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRemovePrametersTypes = new Type[] { typeof(KeyValuePair<int, Dictionary<object, object>>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodRemove, Fixture, methodRemovePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodRemovePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Remove_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodRemovePrametersTypes = new Type[] { typeof(KeyValuePair<int, Dictionary<object, object>>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodRemove, Fixture, methodRemovePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodRemovePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Remove_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemovePrametersTypes = new Type[] { typeof(KeyValuePair<int, Dictionary<object, object>>) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodRemove, Fixture, methodRemovePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRemovePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Remove_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemove, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_propertyHashInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Remove_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRemove, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PropertyHash_Remove_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodRemovePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodRemove, Fixture, methodRemovePrametersTypes);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Remove_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var key = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _propertyHashInstance.Remove(key);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Remove_Method_Call_Overloading_Of_1_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var key = CreateType<int>();
            var methodRemovePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfRemove = { key };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRemove, methodRemovePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PropertyHash, bool>(_propertyHashInstanceFixture, out exception1, parametersOfRemove);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PropertyHash, bool>(_propertyHashInstance, MethodRemove, parametersOfRemove, methodRemovePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRemove.ShouldNotBeNull();
            parametersOfRemove.Length.ShouldBe(1);
            methodRemovePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<PropertyHash, bool>(_propertyHashInstance, MethodRemove, parametersOfRemove, methodRemovePrametersTypes));
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Remove_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var key = CreateType<int>();
            var methodRemovePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfRemove = { key };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRemove, methodRemovePrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRemove.ShouldNotBeNull();
            parametersOfRemove.Length.ShouldBe(1);
            methodRemovePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_propertyHashInstanceFixture, parametersOfRemove));
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Remove_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var key = CreateType<int>();
            var methodRemovePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfRemove = { key };

            // Assert
            parametersOfRemove.ShouldNotBeNull();
            parametersOfRemove.Length.ShouldBe(1);
            methodRemovePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<PropertyHash, bool>(_propertyHashInstance, MethodRemove, parametersOfRemove, methodRemovePrametersTypes));
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Remove_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRemovePrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodRemove, Fixture, methodRemovePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodRemovePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Remove_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodRemovePrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodRemove, Fixture, methodRemovePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodRemovePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Remove_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemovePrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodRemove, Fixture, methodRemovePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRemovePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Remove_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemove, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_propertyHashInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Remove_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRemove, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Clear) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PropertyHash_Clear_Method_Call_Internally(Type[] types)
        {
            var methodClearPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodClear, Fixture, methodClearPrametersTypes);
        }

        #endregion

        #region Method Call : (Clear) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Clear_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _propertyHashInstance.Clear();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Clear) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Clear_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodClearPrametersTypes = null;
            object[] parametersOfClear = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodClear, methodClearPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_propertyHashInstanceFixture, parametersOfClear);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfClear.ShouldBeNull();
            methodClearPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Clear) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Clear_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodClearPrametersTypes = null;
            object[] parametersOfClear = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_propertyHashInstance, MethodClear, parametersOfClear, methodClearPrametersTypes);

            // Assert
            parametersOfClear.ShouldBeNull();
            methodClearPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Clear) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Clear_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodClearPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodClear, Fixture, methodClearPrametersTypes);

            // Assert
            methodClearPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Clear) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Clear_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodClear, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_propertyHashInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryGetValue) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PropertyHash_TryGetValue_Method_Call_Internally(Type[] types)
        {
            var methodTryGetValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodTryGetValue, Fixture, methodTryGetValuePrametersTypes);
        }

        #endregion

        #region Method Call : (TryGetValue) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_TryGetValue_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var key = CreateType<int>();
            var val = CreateType<Dictionary<object, object>>();
            Action executeAction = null;

            // Act
            executeAction = () => _propertyHashInstance.TryGetValue(key, out val);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (TryGetValue) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_TryGetValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var key = CreateType<int>();
            var val = CreateType<Dictionary<object, object>>();
            var methodTryGetValuePrametersTypes = new Type[] { typeof(int), typeof(Dictionary<object, object>) };
            object[] parametersOfTryGetValue = { key, val };

            // Assert
            parametersOfTryGetValue.ShouldNotBeNull();
            parametersOfTryGetValue.Length.ShouldBe(2);
            methodTryGetValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<PropertyHash, bool>(_propertyHashInstance, MethodTryGetValue, parametersOfTryGetValue, methodTryGetValuePrametersTypes));
        }

        #endregion

        #region Method Call : (TryGetValue) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_TryGetValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTryGetValuePrametersTypes = new Type[] { typeof(int), typeof(Dictionary<object, object>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodTryGetValue, Fixture, methodTryGetValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryGetValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryGetValue) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_TryGetValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryGetValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_propertyHashInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (TryGetValue) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_TryGetValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTryGetValue, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Contains) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PropertyHash_Contains_Method_Call_Internally(Type[] types)
        {
            var methodContainsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodContains, Fixture, methodContainsPrametersTypes);
        }

        #endregion

        #region Method Call : (Contains) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Contains_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var pair = CreateType<KeyValuePair<int, Dictionary<object, object>>>();
            Action executeAction = null;

            // Act
            executeAction = () => _propertyHashInstance.Contains(pair);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Contains) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Contains_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var pair = CreateType<KeyValuePair<int, Dictionary<object, object>>>();
            var methodContainsPrametersTypes = new Type[] { typeof(KeyValuePair<int, Dictionary<object, object>>) };
            object[] parametersOfContains = { pair };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodContains, methodContainsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PropertyHash, bool>(_propertyHashInstanceFixture, out exception1, parametersOfContains);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PropertyHash, bool>(_propertyHashInstance, MethodContains, parametersOfContains, methodContainsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfContains.ShouldNotBeNull();
            parametersOfContains.Length.ShouldBe(1);
            methodContainsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<PropertyHash, bool>(_propertyHashInstance, MethodContains, parametersOfContains, methodContainsPrametersTypes));
        }

        #endregion

        #region Method Call : (Contains) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Contains_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var pair = CreateType<KeyValuePair<int, Dictionary<object, object>>>();
            var methodContainsPrametersTypes = new Type[] { typeof(KeyValuePair<int, Dictionary<object, object>>) };
            object[] parametersOfContains = { pair };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodContains, methodContainsPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfContains.ShouldNotBeNull();
            parametersOfContains.Length.ShouldBe(1);
            methodContainsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_propertyHashInstanceFixture, parametersOfContains));
        }

        #endregion

        #region Method Call : (Contains) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Contains_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var pair = CreateType<KeyValuePair<int, Dictionary<object, object>>>();
            var methodContainsPrametersTypes = new Type[] { typeof(KeyValuePair<int, Dictionary<object, object>>) };
            object[] parametersOfContains = { pair };

            // Assert
            parametersOfContains.ShouldNotBeNull();
            parametersOfContains.Length.ShouldBe(1);
            methodContainsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<PropertyHash, bool>(_propertyHashInstance, MethodContains, parametersOfContains, methodContainsPrametersTypes));
        }

        #endregion

        #region Method Call : (Contains) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Contains_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodContainsPrametersTypes = new Type[] { typeof(KeyValuePair<int, Dictionary<object, object>>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodContains, Fixture, methodContainsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodContainsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Contains) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Contains_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodContainsPrametersTypes = new Type[] { typeof(KeyValuePair<int, Dictionary<object, object>>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodContains, Fixture, methodContainsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodContainsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Contains) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Contains_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodContainsPrametersTypes = new Type[] { typeof(KeyValuePair<int, Dictionary<object, object>>) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodContains, Fixture, methodContainsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodContainsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Contains) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Contains_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodContains, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_propertyHashInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Contains) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_Contains_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodContains, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CopyTo) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PropertyHash_CopyTo_Method_Call_Internally(Type[] types)
        {
            var methodCopyToPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodCopyTo, Fixture, methodCopyToPrametersTypes);
        }

        #endregion

        #region Method Call : (CopyTo) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_CopyTo_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var pair = CreateType<KeyValuePair<int, Dictionary<object, object>>[]>();
            var i = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _propertyHashInstance.CopyTo(pair, i);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CopyTo) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_CopyTo_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var pair = CreateType<KeyValuePair<int, Dictionary<object, object>>[]>();
            var i = CreateType<int>();
            var methodCopyToPrametersTypes = new Type[] { typeof(KeyValuePair<int, Dictionary<object, object>>[]), typeof(int) };
            object[] parametersOfCopyTo = { pair, i };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCopyTo, methodCopyToPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_propertyHashInstanceFixture, parametersOfCopyTo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCopyTo.ShouldNotBeNull();
            parametersOfCopyTo.Length.ShouldBe(2);
            methodCopyToPrametersTypes.Length.ShouldBe(2);
            methodCopyToPrametersTypes.Length.ShouldBe(parametersOfCopyTo.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CopyTo) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_CopyTo_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var pair = CreateType<KeyValuePair<int, Dictionary<object, object>>[]>();
            var i = CreateType<int>();
            var methodCopyToPrametersTypes = new Type[] { typeof(KeyValuePair<int, Dictionary<object, object>>[]), typeof(int) };
            object[] parametersOfCopyTo = { pair, i };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_propertyHashInstance, MethodCopyTo, parametersOfCopyTo, methodCopyToPrametersTypes);

            // Assert
            parametersOfCopyTo.ShouldNotBeNull();
            parametersOfCopyTo.Length.ShouldBe(2);
            methodCopyToPrametersTypes.Length.ShouldBe(2);
            methodCopyToPrametersTypes.Length.ShouldBe(parametersOfCopyTo.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CopyTo) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_CopyTo_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCopyTo, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CopyTo) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_CopyTo_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCopyToPrametersTypes = new Type[] { typeof(KeyValuePair<int, Dictionary<object, object>>[]), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodCopyTo, Fixture, methodCopyToPrametersTypes);

            // Assert
            methodCopyToPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CopyTo) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_CopyTo_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCopyTo, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_propertyHashInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ContainsKey) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PropertyHash_ContainsKey_Method_Call_Internally(Type[] types)
        {
            var methodContainsKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodContainsKey, Fixture, methodContainsKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (ContainsKey) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_ContainsKey_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var key = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _propertyHashInstance.ContainsKey(key);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ContainsKey) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_ContainsKey_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var key = CreateType<int>();
            var methodContainsKeyPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfContainsKey = { key };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodContainsKey, methodContainsKeyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PropertyHash, bool>(_propertyHashInstanceFixture, out exception1, parametersOfContainsKey);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PropertyHash, bool>(_propertyHashInstance, MethodContainsKey, parametersOfContainsKey, methodContainsKeyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfContainsKey.ShouldNotBeNull();
            parametersOfContainsKey.Length.ShouldBe(1);
            methodContainsKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<PropertyHash, bool>(_propertyHashInstance, MethodContainsKey, parametersOfContainsKey, methodContainsKeyPrametersTypes));
        }

        #endregion

        #region Method Call : (ContainsKey) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_ContainsKey_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var key = CreateType<int>();
            var methodContainsKeyPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfContainsKey = { key };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodContainsKey, methodContainsKeyPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfContainsKey.ShouldNotBeNull();
            parametersOfContainsKey.Length.ShouldBe(1);
            methodContainsKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_propertyHashInstanceFixture, parametersOfContainsKey));
        }

        #endregion

        #region Method Call : (ContainsKey) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_ContainsKey_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var key = CreateType<int>();
            var methodContainsKeyPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfContainsKey = { key };

            // Assert
            parametersOfContainsKey.ShouldNotBeNull();
            parametersOfContainsKey.Length.ShouldBe(1);
            methodContainsKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<PropertyHash, bool>(_propertyHashInstance, MethodContainsKey, parametersOfContainsKey, methodContainsKeyPrametersTypes));
        }

        #endregion

        #region Method Call : (ContainsKey) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_ContainsKey_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodContainsKeyPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodContainsKey, Fixture, methodContainsKeyPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodContainsKeyPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ContainsKey) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_ContainsKey_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodContainsKeyPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodContainsKey, Fixture, methodContainsKeyPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodContainsKeyPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ContainsKey) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_ContainsKey_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodContainsKeyPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodContainsKey, Fixture, methodContainsKeyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodContainsKeyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ContainsKey) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_ContainsKey_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodContainsKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_propertyHashInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ContainsKey) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_ContainsKey_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodContainsKey, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (loadProps) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PropertyHash_loadProps_Method_Call_Internally(Type[] types)
        {
            var methodloadPropsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodloadProps, Fixture, methodloadPropsPrametersTypes);
        }

        #endregion
        
        #region Method Call : (loadProps) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_loadProps_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var values = CreateType<string>();
            var CollectionSeperator = CreateType<string>();
            var ItemSeperator = CreateType<char>();
            var KeySeperator = CreateType<char>();
            var methodloadPropsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(char), typeof(char) };
            object[] parametersOfloadProps = { values, CollectionSeperator, ItemSeperator, KeySeperator };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_propertyHashInstance, MethodloadProps, parametersOfloadProps, methodloadPropsPrametersTypes);

            // Assert
            parametersOfloadProps.ShouldNotBeNull();
            parametersOfloadProps.Length.ShouldBe(4);
            methodloadPropsPrametersTypes.Length.ShouldBe(4);
            methodloadPropsPrametersTypes.Length.ShouldBe(parametersOfloadProps.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadProps) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_loadProps_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodloadProps, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (loadProps) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_loadProps_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodloadPropsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(char), typeof(char) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodloadProps, Fixture, methodloadPropsPrametersTypes);

            // Assert
            methodloadPropsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadProps) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_loadProps_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodloadProps, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_propertyHashInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetKeyValue) (Return Type : Dictionary<object, object>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PropertyHash_GetKeyValue_Method_Call_Internally(Type[] types)
        {
            var methodGetKeyValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodGetKeyValue, Fixture, methodGetKeyValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetKeyValue) (Return Type : Dictionary<object, object>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_GetKeyValue_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var values = CreateType<string>();
            var ItemSeperator = CreateType<char>();
            var KeySeperator = CreateType<char>();
            var methodGetKeyValuePrametersTypes = new Type[] { typeof(string), typeof(char), typeof(char) };
            object[] parametersOfGetKeyValue = { values, ItemSeperator, KeySeperator };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetKeyValue, methodGetKeyValuePrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetKeyValue.ShouldNotBeNull();
            parametersOfGetKeyValue.Length.ShouldBe(3);
            methodGetKeyValuePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => methodInfo.Invoke(_propertyHashInstanceFixture, parametersOfGetKeyValue));
        }

        #endregion

        #region Method Call : (GetKeyValue) (Return Type : Dictionary<object, object>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_GetKeyValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var values = CreateType<string>();
            var ItemSeperator = CreateType<char>();
            var KeySeperator = CreateType<char>();
            var methodGetKeyValuePrametersTypes = new Type[] { typeof(string), typeof(char), typeof(char) };
            object[] parametersOfGetKeyValue = { values, ItemSeperator, KeySeperator };

            // Assert
            parametersOfGetKeyValue.ShouldNotBeNull();
            parametersOfGetKeyValue.Length.ShouldBe(3);
            methodGetKeyValuePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<PropertyHash, Dictionary<object, object>>(_propertyHashInstance, MethodGetKeyValue, parametersOfGetKeyValue, methodGetKeyValuePrametersTypes));
        }

        #endregion

        #region Method Call : (GetKeyValue) (Return Type : Dictionary<object, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_GetKeyValue_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetKeyValuePrametersTypes = new Type[] { typeof(string), typeof(char), typeof(char) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodGetKeyValue, Fixture, methodGetKeyValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetKeyValuePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetKeyValue) (Return Type : Dictionary<object, object>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_GetKeyValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetKeyValuePrametersTypes = new Type[] { typeof(string), typeof(char), typeof(char) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodGetKeyValue, Fixture, methodGetKeyValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetKeyValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetKeyValue) (Return Type : Dictionary<object, object>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_GetKeyValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetKeyValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_propertyHashInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetKeyValue) (Return Type : Dictionary<object, object>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_GetKeyValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetKeyValue, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PropertyHash_ToString_Method_Call_Internally(Type[] types)
        {
            var methodToStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodToString, Fixture, methodToStringPrametersTypes);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_ToString_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _propertyHashInstance.ToString();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_ToString_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodToStringPrametersTypes = null;
            object[] parametersOfToString = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodToString, methodToStringPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfToString.ShouldBeNull();
            methodToStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => methodInfo.Invoke(_propertyHashInstanceFixture, parametersOfToString));
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_ToString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodToStringPrametersTypes = null;
            object[] parametersOfToString = null; // no parameter present

            // Assert
            parametersOfToString.ShouldBeNull();
            methodToStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<PropertyHash, string>(_propertyHashInstance, MethodToString, parametersOfToString, methodToStringPrametersTypes));
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_ToString_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodToStringPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodToString, Fixture, methodToStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodToStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_ToString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodToStringPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_propertyHashInstance, MethodToString, Fixture, methodToStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PropertyHash_ToString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_propertyHashInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}