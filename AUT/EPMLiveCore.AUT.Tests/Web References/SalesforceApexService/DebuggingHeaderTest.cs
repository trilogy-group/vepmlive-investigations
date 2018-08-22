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

namespace EPMLiveCore.SalesforceApexService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceApexService.DebuggingHeader" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceApexService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DebuggingHeaderTest : AbstractBaseSetupTypedTest<DebuggingHeader>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DebuggingHeader) Initializer

        private const string Propertycategories = "categories";
        private const string PropertydebugLevel = "debugLevel";
        private const string FieldcategoriesField = "categoriesField";
        private const string FielddebugLevelField = "debugLevelField";
        private Type _debuggingHeaderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DebuggingHeader _debuggingHeaderInstance;
        private DebuggingHeader _debuggingHeaderInstanceFixture;

        #region General Initializer : Class (DebuggingHeader) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DebuggingHeader" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _debuggingHeaderInstanceType = typeof(DebuggingHeader);
            _debuggingHeaderInstanceFixture = Create(true);
            _debuggingHeaderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DebuggingHeader)

        #region General Initializer : Class (DebuggingHeader) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DebuggingHeader" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertycategories)]
        [TestCase(PropertydebugLevel)]
        public void AUT_DebuggingHeader_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_debuggingHeaderInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DebuggingHeader) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DebuggingHeader" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcategoriesField)]
        [TestCase(FielddebugLevelField)]
        public void AUT_DebuggingHeader_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_debuggingHeaderInstanceFixture, 
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
        ///     Class (<see cref="DebuggingHeader" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DebuggingHeader_Is_Instance_Present_Test()
        {
            // Assert
            _debuggingHeaderInstanceType.ShouldNotBeNull();
            _debuggingHeaderInstance.ShouldNotBeNull();
            _debuggingHeaderInstanceFixture.ShouldNotBeNull();
            _debuggingHeaderInstance.ShouldBeAssignableTo<DebuggingHeader>();
            _debuggingHeaderInstanceFixture.ShouldBeAssignableTo<DebuggingHeader>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DebuggingHeader) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DebuggingHeader_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DebuggingHeader instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _debuggingHeaderInstanceType.ShouldNotBeNull();
            _debuggingHeaderInstance.ShouldNotBeNull();
            _debuggingHeaderInstanceFixture.ShouldNotBeNull();
            _debuggingHeaderInstance.ShouldBeAssignableTo<DebuggingHeader>();
            _debuggingHeaderInstanceFixture.ShouldBeAssignableTo<DebuggingHeader>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DebuggingHeader) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(LogInfo[]) , Propertycategories)]
        [TestCaseGeneric(typeof(LogType) , PropertydebugLevel)]
        public void AUT_DebuggingHeader_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DebuggingHeader, T>(_debuggingHeaderInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DebuggingHeader) => Property (categories) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DebuggingHeader_categories_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertycategories);
            Action currentAction = () => propertyInfo.SetValue(_debuggingHeaderInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DebuggingHeader) => Property (categories) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DebuggingHeader_Public_Class_categories_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycategories);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DebuggingHeader) => Property (debugLevel) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DebuggingHeader_debugLevel_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydebugLevel);
            Action currentAction = () => propertyInfo.SetValue(_debuggingHeaderInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DebuggingHeader) => Property (debugLevel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DebuggingHeader_Public_Class_debugLevel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydebugLevel);

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