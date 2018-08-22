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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceApexService.RunTestsRequest" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceApexService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RunTestsRequestTest : AbstractBaseSetupTypedTest<RunTestsRequest>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RunTestsRequest) Initializer

        private const string PropertyallTests = "allTests";
        private const string Propertyclasses = "classes";
        private const string Propertyanamespace = "@namespace";
        private const string Propertypackages = "packages";
        private const string FieldallTestsField = "allTestsField";
        private const string FieldclassesField = "classesField";
        private const string FieldnamespaceField = "namespaceField";
        private const string FieldpackagesField = "packagesField";
        private Type _runTestsRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RunTestsRequest _runTestsRequestInstance;
        private RunTestsRequest _runTestsRequestInstanceFixture;

        #region General Initializer : Class (RunTestsRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RunTestsRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _runTestsRequestInstanceType = typeof(RunTestsRequest);
            _runTestsRequestInstanceFixture = Create(true);
            _runTestsRequestInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RunTestsRequest)

        #region General Initializer : Class (RunTestsRequest) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="RunTestsRequest" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyallTests)]
        [TestCase(Propertyclasses)]
        [TestCase(Propertypackages)]
        public void AUT_RunTestsRequest_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_runTestsRequestInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (RunTestsRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RunTestsRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldallTestsField)]
        [TestCase(FieldclassesField)]
        [TestCase(FieldnamespaceField)]
        [TestCase(FieldpackagesField)]
        public void AUT_RunTestsRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_runTestsRequestInstanceFixture, 
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
        ///     Class (<see cref="RunTestsRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_RunTestsRequest_Is_Instance_Present_Test()
        {
            // Assert
            _runTestsRequestInstanceType.ShouldNotBeNull();
            _runTestsRequestInstance.ShouldNotBeNull();
            _runTestsRequestInstanceFixture.ShouldNotBeNull();
            _runTestsRequestInstance.ShouldBeAssignableTo<RunTestsRequest>();
            _runTestsRequestInstanceFixture.ShouldBeAssignableTo<RunTestsRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RunTestsRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_RunTestsRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RunTestsRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _runTestsRequestInstanceType.ShouldNotBeNull();
            _runTestsRequestInstance.ShouldNotBeNull();
            _runTestsRequestInstanceFixture.ShouldNotBeNull();
            _runTestsRequestInstance.ShouldBeAssignableTo<RunTestsRequest>();
            _runTestsRequestInstanceFixture.ShouldBeAssignableTo<RunTestsRequest>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (RunTestsRequest) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyallTests)]
        [TestCaseGeneric(typeof(string[]) , Propertyclasses)]
        [TestCaseGeneric(typeof(string[]) , Propertypackages)]
        public void AUT_RunTestsRequest_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<RunTestsRequest, T>(_runTestsRequestInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (RunTestsRequest) => Property (allTests) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestsRequest_Public_Class_allTests_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallTests);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RunTestsRequest) => Property (classes) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestsRequest_classes_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyclasses);
            Action currentAction = () => propertyInfo.SetValue(_runTestsRequestInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RunTestsRequest) => Property (classes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestsRequest_Public_Class_classes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyclasses);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RunTestsRequest) => Property (packages) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestsRequest_packages_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertypackages);
            Action currentAction = () => propertyInfo.SetValue(_runTestsRequestInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RunTestsRequest) => Property (packages) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestsRequest_Public_Class_packages_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertypackages);

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