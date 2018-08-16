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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceApexService.WsdlToApexResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceApexService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WsdlToApexResultTest : AbstractBaseSetupTypedTest<WsdlToApexResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WsdlToApexResult) Initializer

        private const string PropertyapexScripts = "apexScripts";
        private const string Propertyerrors = "errors";
        private const string Propertysuccess = "success";
        private const string FieldapexScriptsField = "apexScriptsField";
        private const string FielderrorsField = "errorsField";
        private const string FieldsuccessField = "successField";
        private Type _wsdlToApexResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WsdlToApexResult _wsdlToApexResultInstance;
        private WsdlToApexResult _wsdlToApexResultInstanceFixture;

        #region General Initializer : Class (WsdlToApexResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WsdlToApexResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _wsdlToApexResultInstanceType = typeof(WsdlToApexResult);
            _wsdlToApexResultInstanceFixture = Create(true);
            _wsdlToApexResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WsdlToApexResult)

        #region General Initializer : Class (WsdlToApexResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WsdlToApexResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyapexScripts)]
        [TestCase(Propertyerrors)]
        [TestCase(Propertysuccess)]
        public void AUT_WsdlToApexResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_wsdlToApexResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WsdlToApexResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WsdlToApexResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldapexScriptsField)]
        [TestCase(FielderrorsField)]
        [TestCase(FieldsuccessField)]
        public void AUT_WsdlToApexResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_wsdlToApexResultInstanceFixture, 
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
        ///     Class (<see cref="WsdlToApexResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_WsdlToApexResult_Is_Instance_Present_Test()
        {
            // Assert
            _wsdlToApexResultInstanceType.ShouldNotBeNull();
            _wsdlToApexResultInstance.ShouldNotBeNull();
            _wsdlToApexResultInstanceFixture.ShouldNotBeNull();
            _wsdlToApexResultInstance.ShouldBeAssignableTo<WsdlToApexResult>();
            _wsdlToApexResultInstanceFixture.ShouldBeAssignableTo<WsdlToApexResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WsdlToApexResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_WsdlToApexResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WsdlToApexResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _wsdlToApexResultInstanceType.ShouldNotBeNull();
            _wsdlToApexResultInstance.ShouldNotBeNull();
            _wsdlToApexResultInstanceFixture.ShouldNotBeNull();
            _wsdlToApexResultInstance.ShouldBeAssignableTo<WsdlToApexResult>();
            _wsdlToApexResultInstanceFixture.ShouldBeAssignableTo<WsdlToApexResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (WsdlToApexResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string[]) , PropertyapexScripts)]
        [TestCaseGeneric(typeof(string[]) , Propertyerrors)]
        [TestCaseGeneric(typeof(bool) , Propertysuccess)]
        public void AUT_WsdlToApexResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<WsdlToApexResult, T>(_wsdlToApexResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (WsdlToApexResult) => Property (apexScripts) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WsdlToApexResult_apexScripts_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyapexScripts);
            Action currentAction = () => propertyInfo.SetValue(_wsdlToApexResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WsdlToApexResult) => Property (apexScripts) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WsdlToApexResult_Public_Class_apexScripts_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyapexScripts);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WsdlToApexResult) => Property (errors) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WsdlToApexResult_errors_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyerrors);
            Action currentAction = () => propertyInfo.SetValue(_wsdlToApexResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WsdlToApexResult) => Property (errors) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WsdlToApexResult_Public_Class_errors_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyerrors);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WsdlToApexResult) => Property (success) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WsdlToApexResult_Public_Class_success_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysuccess);

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