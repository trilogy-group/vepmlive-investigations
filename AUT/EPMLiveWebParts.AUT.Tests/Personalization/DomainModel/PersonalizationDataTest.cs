using System;
using System.Data;
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

namespace EPMLiveWebParts.Personalization.DomainModel
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.Personalization.DomainModel.PersonalizationData" />)
    ///     and namespace <see cref="EPMLiveWebParts.Personalization.DomainModel"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PersonalizationDataTest : AbstractBaseSetupTypedTest<PersonalizationData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PersonalizationData) Initializer

        private const string PropertyForeignKey = "ForeignKey";
        private const string PropertyUserId = "UserId";
        private const string PropertySiteId = "SiteId";
        private const string PropertyWebId = "WebId";
        private const string PropertyListId = "ListId";
        private const string PropertyItemId = "ItemId";
        private const string PropertyKey = "Key";
        private const string PropertyValue = "Value";
        private const string MethodHydrate = "Hydrate";
        private Type _personalizationDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PersonalizationData _personalizationDataInstance;
        private PersonalizationData _personalizationDataInstanceFixture;

        #region General Initializer : Class (PersonalizationData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PersonalizationData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _personalizationDataInstanceType = typeof(PersonalizationData);
            _personalizationDataInstanceFixture = Create(true);
            _personalizationDataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PersonalizationData)

        #region General Initializer : Class (PersonalizationData) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="PersonalizationData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodHydrate, 0)]
        public void AUT_PersonalizationData_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_personalizationDataInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PersonalizationData) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PersonalizationData" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyForeignKey)]
        [TestCase(PropertyUserId)]
        [TestCase(PropertySiteId)]
        [TestCase(PropertyWebId)]
        [TestCase(PropertyListId)]
        [TestCase(PropertyItemId)]
        [TestCase(PropertyKey)]
        [TestCase(PropertyValue)]
        public void AUT_PersonalizationData_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_personalizationDataInstanceFixture,
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
        ///     Class (<see cref="PersonalizationData" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PersonalizationData_Is_Instance_Present_Test()
        {
            // Assert
            _personalizationDataInstanceType.ShouldNotBeNull();
            _personalizationDataInstance.ShouldNotBeNull();
            _personalizationDataInstanceFixture.ShouldNotBeNull();
            _personalizationDataInstance.ShouldBeAssignableTo<PersonalizationData>();
            _personalizationDataInstanceFixture.ShouldBeAssignableTo<PersonalizationData>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PersonalizationData) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_PersonalizationData_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PersonalizationData instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _personalizationDataInstanceType.ShouldNotBeNull();
            _personalizationDataInstance.ShouldNotBeNull();
            _personalizationDataInstanceFixture.ShouldNotBeNull();
            _personalizationDataInstance.ShouldBeAssignableTo<PersonalizationData>();
            _personalizationDataInstanceFixture.ShouldBeAssignableTo<PersonalizationData>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PersonalizationData) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(Guid?) , PropertyForeignKey)]
        [TestCaseGeneric(typeof(string) , PropertyUserId)]
        [TestCaseGeneric(typeof(Guid?) , PropertySiteId)]
        [TestCaseGeneric(typeof(Guid?) , PropertyWebId)]
        [TestCaseGeneric(typeof(Guid?) , PropertyListId)]
        [TestCaseGeneric(typeof(int?) , PropertyItemId)]
        [TestCaseGeneric(typeof(string) , PropertyKey)]
        [TestCaseGeneric(typeof(string) , PropertyValue)]
        public void AUT_PersonalizationData_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<PersonalizationData, T>(_personalizationDataInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (PersonalizationData) => Property (ForeignKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalizationData_ForeignKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyForeignKey);
            Action currentAction = () => propertyInfo.SetValue(_personalizationDataInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PersonalizationData) => Property (ForeignKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalizationData_Public_Class_ForeignKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyForeignKey);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PersonalizationData) => Property (ItemId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalizationData_Public_Class_ItemId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyItemId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PersonalizationData) => Property (Key) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalizationData_Public_Class_Key_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PersonalizationData) => Property (ListId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalizationData_ListId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyListId);
            Action currentAction = () => propertyInfo.SetValue(_personalizationDataInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PersonalizationData) => Property (ListId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalizationData_Public_Class_ListId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyListId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PersonalizationData) => Property (SiteId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalizationData_SiteId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertySiteId);
            Action currentAction = () => propertyInfo.SetValue(_personalizationDataInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PersonalizationData) => Property (SiteId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalizationData_Public_Class_SiteId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySiteId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PersonalizationData) => Property (UserId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalizationData_Public_Class_UserId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PersonalizationData) => Property (Value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalizationData_Public_Class_Value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PersonalizationData) => Property (WebId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalizationData_WebId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyWebId);
            Action currentAction = () => propertyInfo.SetValue(_personalizationDataInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PersonalizationData) => Property (WebId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalizationData_Public_Class_WebId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWebId);

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
        ///      Class (<see cref="PersonalizationData" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodHydrate)]
        public void AUT_PersonalizationData_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<PersonalizationData>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Hydrate) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PersonalizationData_Hydrate_Method_Call_Internally(Type[] types)
        {
            var methodHydratePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalizationDataInstance, MethodHydrate, Fixture, methodHydratePrametersTypes);
        }

        #endregion

        #region Method Call : (Hydrate) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationData_Hydrate_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var reader = CreateType<IDataReader>();
            Action executeAction = null;

            // Act
            executeAction = () => _personalizationDataInstance.Hydrate(reader);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Hydrate) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationData_Hydrate_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var reader = CreateType<IDataReader>();
            var methodHydratePrametersTypes = new Type[] { typeof(IDataReader) };
            object[] parametersOfHydrate = { reader };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHydrate, methodHydratePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_personalizationDataInstanceFixture, parametersOfHydrate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHydrate.ShouldNotBeNull();
            parametersOfHydrate.Length.ShouldBe(1);
            methodHydratePrametersTypes.Length.ShouldBe(1);
            methodHydratePrametersTypes.Length.ShouldBe(parametersOfHydrate.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Hydrate) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationData_Hydrate_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var reader = CreateType<IDataReader>();
            var methodHydratePrametersTypes = new Type[] { typeof(IDataReader) };
            object[] parametersOfHydrate = { reader };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_personalizationDataInstance, MethodHydrate, parametersOfHydrate, methodHydratePrametersTypes);

            // Assert
            parametersOfHydrate.ShouldNotBeNull();
            parametersOfHydrate.Length.ShouldBe(1);
            methodHydratePrametersTypes.Length.ShouldBe(1);
            methodHydratePrametersTypes.Length.ShouldBe(parametersOfHydrate.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Hydrate) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationData_Hydrate_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHydrate, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Hydrate) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationData_Hydrate_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHydratePrametersTypes = new Type[] { typeof(IDataReader) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalizationDataInstance, MethodHydrate, Fixture, methodHydratePrametersTypes);

            // Assert
            methodHydratePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Hydrate) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalizationData_Hydrate_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHydrate, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_personalizationDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}