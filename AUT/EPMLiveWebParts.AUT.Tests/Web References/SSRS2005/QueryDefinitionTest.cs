using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveWebParts.SSRS2005
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2005.QueryDefinition" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2005"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class QueryDefinitionTest : AbstractBaseSetupTypedTest<QueryDefinition>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (QueryDefinition) Initializer

        private const string PropertyCommandType = "CommandType";
        private const string PropertyCommandText = "CommandText";
        private const string PropertyTimeout = "Timeout";
        private const string PropertyTimeoutSpecified = "TimeoutSpecified";
        private const string FieldcommandTypeField = "commandTypeField";
        private const string FieldcommandTextField = "commandTextField";
        private const string FieldtimeoutField = "timeoutField";
        private const string FieldtimeoutFieldSpecified = "timeoutFieldSpecified";
        private Type _queryDefinitionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private QueryDefinition _queryDefinitionInstance;
        private QueryDefinition _queryDefinitionInstanceFixture;

        #region General Initializer : Class (QueryDefinition) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="QueryDefinition" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _queryDefinitionInstanceType = typeof(QueryDefinition);
            _queryDefinitionInstanceFixture = Create(true);
            _queryDefinitionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (QueryDefinition)

        #region General Initializer : Class (QueryDefinition) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="QueryDefinition" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyCommandType)]
        [TestCase(PropertyCommandText)]
        [TestCase(PropertyTimeout)]
        [TestCase(PropertyTimeoutSpecified)]
        public void AUT_QueryDefinition_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_queryDefinitionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (QueryDefinition) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="QueryDefinition" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcommandTypeField)]
        [TestCase(FieldcommandTextField)]
        [TestCase(FieldtimeoutField)]
        [TestCase(FieldtimeoutFieldSpecified)]
        public void AUT_QueryDefinition_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_queryDefinitionInstanceFixture, 
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
        ///     Class (<see cref="QueryDefinition" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_QueryDefinition_Is_Instance_Present_Test()
        {
            // Assert
            _queryDefinitionInstanceType.ShouldNotBeNull();
            _queryDefinitionInstance.ShouldNotBeNull();
            _queryDefinitionInstanceFixture.ShouldNotBeNull();
            _queryDefinitionInstance.ShouldBeAssignableTo<QueryDefinition>();
            _queryDefinitionInstanceFixture.ShouldBeAssignableTo<QueryDefinition>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (QueryDefinition) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_QueryDefinition_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            QueryDefinition instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _queryDefinitionInstanceType.ShouldNotBeNull();
            _queryDefinitionInstance.ShouldNotBeNull();
            _queryDefinitionInstanceFixture.ShouldNotBeNull();
            _queryDefinitionInstance.ShouldBeAssignableTo<QueryDefinition>();
            _queryDefinitionInstanceFixture.ShouldBeAssignableTo<QueryDefinition>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (QueryDefinition) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyCommandType)]
        [TestCaseGeneric(typeof(string) , PropertyCommandText)]
        [TestCaseGeneric(typeof(int) , PropertyTimeout)]
        [TestCaseGeneric(typeof(bool) , PropertyTimeoutSpecified)]
        public void AUT_QueryDefinition_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<QueryDefinition, T>(_queryDefinitionInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (QueryDefinition) => Property (CommandText) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_QueryDefinition_Public_Class_CommandText_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCommandText);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (QueryDefinition) => Property (CommandType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_QueryDefinition_Public_Class_CommandType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCommandType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (QueryDefinition) => Property (Timeout) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_QueryDefinition_Public_Class_Timeout_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTimeout);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (QueryDefinition) => Property (TimeoutSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_QueryDefinition_Public_Class_TimeoutSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTimeoutSpecified);

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