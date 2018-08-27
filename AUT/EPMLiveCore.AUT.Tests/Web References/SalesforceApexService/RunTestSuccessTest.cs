using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.SalesforceApexService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceApexService.RunTestSuccess" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceApexService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RunTestSuccessTest : AbstractBaseSetupTypedTest<RunTestSuccess>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RunTestSuccess) Initializer

        private const string Propertyid = "id";
        private const string PropertymethodName = "methodName";
        private const string Propertyname = "name";
        private const string Propertyanamespace = "@namespace";
        private const string Propertytime = "time";
        private const string FieldidField = "idField";
        private const string FieldmethodNameField = "methodNameField";
        private const string FieldnameField = "nameField";
        private const string FieldnamespaceField = "namespaceField";
        private const string FieldtimeField = "timeField";
        private Type _runTestSuccessInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RunTestSuccess _runTestSuccessInstance;
        private RunTestSuccess _runTestSuccessInstanceFixture;

        #region General Initializer : Class (RunTestSuccess) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RunTestSuccess" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _runTestSuccessInstanceType = typeof(RunTestSuccess);
            _runTestSuccessInstanceFixture = Create(true);
            _runTestSuccessInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RunTestSuccess)

        #region General Initializer : Class (RunTestSuccess) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="RunTestSuccess" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyid)]
        [TestCase(PropertymethodName)]
        [TestCase(Propertyname)]
        [TestCase(Propertytime)]
        public void AUT_RunTestSuccess_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_runTestSuccessInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (RunTestSuccess) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RunTestSuccess" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldidField)]
        [TestCase(FieldmethodNameField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldnamespaceField)]
        [TestCase(FieldtimeField)]
        public void AUT_RunTestSuccess_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_runTestSuccessInstanceFixture, 
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
        ///     Class (<see cref="RunTestSuccess" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_RunTestSuccess_Is_Instance_Present_Test()
        {
            // Assert
            _runTestSuccessInstanceType.ShouldNotBeNull();
            _runTestSuccessInstance.ShouldNotBeNull();
            _runTestSuccessInstanceFixture.ShouldNotBeNull();
            _runTestSuccessInstance.ShouldBeAssignableTo<RunTestSuccess>();
            _runTestSuccessInstanceFixture.ShouldBeAssignableTo<RunTestSuccess>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RunTestSuccess) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_RunTestSuccess_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RunTestSuccess instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _runTestSuccessInstanceType.ShouldNotBeNull();
            _runTestSuccessInstance.ShouldNotBeNull();
            _runTestSuccessInstanceFixture.ShouldNotBeNull();
            _runTestSuccessInstance.ShouldBeAssignableTo<RunTestSuccess>();
            _runTestSuccessInstanceFixture.ShouldBeAssignableTo<RunTestSuccess>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (RunTestSuccess) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyid)]
        [TestCaseGeneric(typeof(string) , PropertymethodName)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(double) , Propertytime)]
        public void AUT_RunTestSuccess_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<RunTestSuccess, T>(_runTestSuccessInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (RunTestSuccess) => Property (id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestSuccess_Public_Class_id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyid);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RunTestSuccess) => Property (methodName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestSuccess_Public_Class_methodName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymethodName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RunTestSuccess) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestSuccess_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyname);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RunTestSuccess) => Property (time) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestSuccess_Public_Class_time_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytime);

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