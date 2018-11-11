using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.CachedValue" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CachedValueTest : AbstractBaseSetupTypedTest<CachedValue>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CachedValue) Initializer

        private const string PropertyCreatedAt = "CreatedAt";
        private const string PropertyLastReadAt = "LastReadAt";
        private const string PropertyUpdatedAt = "UpdatedAt";
        private const string PropertyValue = "Value";
        private const string Field_value = "_value";
        private Type _cachedValueInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CachedValue _cachedValueInstance;
        private CachedValue _cachedValueInstanceFixture;

        #region General Initializer : Class (CachedValue) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CachedValue" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _cachedValueInstanceType = typeof(CachedValue);
            _cachedValueInstanceFixture = Create(true);
            _cachedValueInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CachedValue)

        #region General Initializer : Class (CachedValue) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CachedValue" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyCreatedAt)]
        [TestCase(PropertyLastReadAt)]
        [TestCase(PropertyUpdatedAt)]
        [TestCase(PropertyValue)]
        public void AUT_CachedValue_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_cachedValueInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CachedValue) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CachedValue" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_value)]
        public void AUT_CachedValue_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_cachedValueInstanceFixture, 
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
        ///     Class (<see cref="CachedValue" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CachedValue_Is_Instance_Present_Test()
        {
            // Assert
            _cachedValueInstanceType.ShouldNotBeNull();
            _cachedValueInstance.ShouldNotBeNull();
            _cachedValueInstanceFixture.ShouldNotBeNull();
            _cachedValueInstance.ShouldBeAssignableTo<CachedValue>();
            _cachedValueInstanceFixture.ShouldBeAssignableTo<CachedValue>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CachedValue) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_CachedValue_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var value = CreateType<object>();
            CachedValue instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new CachedValue(value);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _cachedValueInstance.ShouldNotBeNull();
            _cachedValueInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<CachedValue>();
        }

        #endregion

        #region General Constructor : Class (CachedValue) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_CachedValue_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var value = CreateType<object>();
            CachedValue instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new CachedValue(value);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _cachedValueInstance.ShouldNotBeNull();
            _cachedValueInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CachedValue) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(DateTime) , PropertyCreatedAt)]
        [TestCaseGeneric(typeof(DateTime) , PropertyLastReadAt)]
        [TestCaseGeneric(typeof(DateTime) , PropertyUpdatedAt)]
        [TestCaseGeneric(typeof(object) , PropertyValue)]
        public void AUT_CachedValue_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CachedValue, T>(_cachedValueInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CachedValue) => Property (CreatedAt) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CachedValue_CreatedAt_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyCreatedAt);
            Action currentAction = () => propertyInfo.SetValue(_cachedValueInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CachedValue) => Property (CreatedAt) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CachedValue_Public_Class_CreatedAt_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCreatedAt);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CachedValue) => Property (LastReadAt) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CachedValue_LastReadAt_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyLastReadAt);
            Action currentAction = () => propertyInfo.SetValue(_cachedValueInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CachedValue) => Property (LastReadAt) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CachedValue_Public_Class_LastReadAt_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLastReadAt);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CachedValue) => Property (UpdatedAt) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CachedValue_UpdatedAt_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyUpdatedAt);
            Action currentAction = () => propertyInfo.SetValue(_cachedValueInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CachedValue) => Property (UpdatedAt) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CachedValue_Public_Class_UpdatedAt_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUpdatedAt);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CachedValue) => Property (Value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CachedValue_Public_Class_Value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}