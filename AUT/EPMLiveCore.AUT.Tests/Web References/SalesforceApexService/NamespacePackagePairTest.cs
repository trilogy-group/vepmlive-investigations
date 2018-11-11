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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceApexService.NamespacePackagePair" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceApexService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class NamespacePackagePairTest : AbstractBaseSetupTypedTest<NamespacePackagePair>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (NamespacePackagePair) Initializer

        private const string Propertyanamespace = "@namespace";
        private const string PropertypackageName = "packageName";
        private const string FieldnamespaceField = "namespaceField";
        private const string FieldpackageNameField = "packageNameField";
        private Type _namespacePackagePairInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private NamespacePackagePair _namespacePackagePairInstance;
        private NamespacePackagePair _namespacePackagePairInstanceFixture;

        #region General Initializer : Class (NamespacePackagePair) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="NamespacePackagePair" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _namespacePackagePairInstanceType = typeof(NamespacePackagePair);
            _namespacePackagePairInstanceFixture = Create(true);
            _namespacePackagePairInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (NamespacePackagePair)

        #region General Initializer : Class (NamespacePackagePair) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="NamespacePackagePair" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertypackageName)]
        public void AUT_NamespacePackagePair_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_namespacePackagePairInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (NamespacePackagePair) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="NamespacePackagePair" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldnamespaceField)]
        [TestCase(FieldpackageNameField)]
        public void AUT_NamespacePackagePair_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_namespacePackagePairInstanceFixture, 
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
        ///     Class (<see cref="NamespacePackagePair" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_NamespacePackagePair_Is_Instance_Present_Test()
        {
            // Assert
            _namespacePackagePairInstanceType.ShouldNotBeNull();
            _namespacePackagePairInstance.ShouldNotBeNull();
            _namespacePackagePairInstanceFixture.ShouldNotBeNull();
            _namespacePackagePairInstance.ShouldBeAssignableTo<NamespacePackagePair>();
            _namespacePackagePairInstanceFixture.ShouldBeAssignableTo<NamespacePackagePair>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (NamespacePackagePair) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_NamespacePackagePair_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            NamespacePackagePair instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _namespacePackagePairInstanceType.ShouldNotBeNull();
            _namespacePackagePairInstance.ShouldNotBeNull();
            _namespacePackagePairInstanceFixture.ShouldNotBeNull();
            _namespacePackagePairInstance.ShouldBeAssignableTo<NamespacePackagePair>();
            _namespacePackagePairInstanceFixture.ShouldBeAssignableTo<NamespacePackagePair>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (NamespacePackagePair) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertypackageName)]
        public void AUT_NamespacePackagePair_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<NamespacePackagePair, T>(_namespacePackagePairInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (NamespacePackagePair) => Property (packageName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_NamespacePackagePair_Public_Class_packageName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypackageName);

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