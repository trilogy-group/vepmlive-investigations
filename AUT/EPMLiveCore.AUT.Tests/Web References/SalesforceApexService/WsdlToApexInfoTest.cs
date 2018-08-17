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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceApexService.WsdlToApexInfo" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceApexService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WsdlToApexInfoTest : AbstractBaseSetupTypedTest<WsdlToApexInfo>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WsdlToApexInfo) Initializer

        private const string Propertymapping = "mapping";
        private const string Propertywsdl = "wsdl";
        private const string FieldmappingField = "mappingField";
        private const string FieldwsdlField = "wsdlField";
        private Type _wsdlToApexInfoInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WsdlToApexInfo _wsdlToApexInfoInstance;
        private WsdlToApexInfo _wsdlToApexInfoInstanceFixture;

        #region General Initializer : Class (WsdlToApexInfo) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WsdlToApexInfo" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _wsdlToApexInfoInstanceType = typeof(WsdlToApexInfo);
            _wsdlToApexInfoInstanceFixture = Create(true);
            _wsdlToApexInfoInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WsdlToApexInfo)

        #region General Initializer : Class (WsdlToApexInfo) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WsdlToApexInfo" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertymapping)]
        [TestCase(Propertywsdl)]
        public void AUT_WsdlToApexInfo_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_wsdlToApexInfoInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WsdlToApexInfo) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WsdlToApexInfo" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldmappingField)]
        [TestCase(FieldwsdlField)]
        public void AUT_WsdlToApexInfo_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_wsdlToApexInfoInstanceFixture, 
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
        ///     Class (<see cref="WsdlToApexInfo" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_WsdlToApexInfo_Is_Instance_Present_Test()
        {
            // Assert
            _wsdlToApexInfoInstanceType.ShouldNotBeNull();
            _wsdlToApexInfoInstance.ShouldNotBeNull();
            _wsdlToApexInfoInstanceFixture.ShouldNotBeNull();
            _wsdlToApexInfoInstance.ShouldBeAssignableTo<WsdlToApexInfo>();
            _wsdlToApexInfoInstanceFixture.ShouldBeAssignableTo<WsdlToApexInfo>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WsdlToApexInfo) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_WsdlToApexInfo_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WsdlToApexInfo instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _wsdlToApexInfoInstanceType.ShouldNotBeNull();
            _wsdlToApexInfoInstance.ShouldNotBeNull();
            _wsdlToApexInfoInstanceFixture.ShouldNotBeNull();
            _wsdlToApexInfoInstance.ShouldBeAssignableTo<WsdlToApexInfo>();
            _wsdlToApexInfoInstanceFixture.ShouldBeAssignableTo<WsdlToApexInfo>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (WsdlToApexInfo) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(NamespacePackagePair[]) , Propertymapping)]
        [TestCaseGeneric(typeof(string) , Propertywsdl)]
        public void AUT_WsdlToApexInfo_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<WsdlToApexInfo, T>(_wsdlToApexInfoInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (WsdlToApexInfo) => Property (mapping) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WsdlToApexInfo_mapping_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertymapping);
            Action currentAction = () => propertyInfo.SetValue(_wsdlToApexInfoInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WsdlToApexInfo) => Property (mapping) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WsdlToApexInfo_Public_Class_mapping_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertymapping);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WsdlToApexInfo) => Property (wsdl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WsdlToApexInfo_Public_Class_wsdl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertywsdl);

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