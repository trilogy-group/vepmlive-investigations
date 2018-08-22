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

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.DescribeMetadataResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DescribeMetadataResultTest : AbstractBaseSetupTypedTest<DescribeMetadataResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DescribeMetadataResult) Initializer

        private const string PropertymetadataObjects = "metadataObjects";
        private const string PropertyorganizationNamespace = "organizationNamespace";
        private const string PropertypartialSaveAllowed = "partialSaveAllowed";
        private const string PropertytestRequired = "testRequired";
        private const string FieldmetadataObjectsField = "metadataObjectsField";
        private const string FieldorganizationNamespaceField = "organizationNamespaceField";
        private const string FieldpartialSaveAllowedField = "partialSaveAllowedField";
        private const string FieldtestRequiredField = "testRequiredField";
        private Type _describeMetadataResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DescribeMetadataResult _describeMetadataResultInstance;
        private DescribeMetadataResult _describeMetadataResultInstanceFixture;

        #region General Initializer : Class (DescribeMetadataResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DescribeMetadataResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _describeMetadataResultInstanceType = typeof(DescribeMetadataResult);
            _describeMetadataResultInstanceFixture = Create(true);
            _describeMetadataResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DescribeMetadataResult)

        #region General Initializer : Class (DescribeMetadataResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeMetadataResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertymetadataObjects)]
        [TestCase(PropertyorganizationNamespace)]
        [TestCase(PropertypartialSaveAllowed)]
        [TestCase(PropertytestRequired)]
        public void AUT_DescribeMetadataResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_describeMetadataResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DescribeMetadataResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeMetadataResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldmetadataObjectsField)]
        [TestCase(FieldorganizationNamespaceField)]
        [TestCase(FieldpartialSaveAllowedField)]
        [TestCase(FieldtestRequiredField)]
        public void AUT_DescribeMetadataResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_describeMetadataResultInstanceFixture, 
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
        ///     Class (<see cref="DescribeMetadataResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DescribeMetadataResult_Is_Instance_Present_Test()
        {
            // Assert
            _describeMetadataResultInstanceType.ShouldNotBeNull();
            _describeMetadataResultInstance.ShouldNotBeNull();
            _describeMetadataResultInstanceFixture.ShouldNotBeNull();
            _describeMetadataResultInstance.ShouldBeAssignableTo<DescribeMetadataResult>();
            _describeMetadataResultInstanceFixture.ShouldBeAssignableTo<DescribeMetadataResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DescribeMetadataResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DescribeMetadataResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DescribeMetadataResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _describeMetadataResultInstanceType.ShouldNotBeNull();
            _describeMetadataResultInstance.ShouldNotBeNull();
            _describeMetadataResultInstanceFixture.ShouldNotBeNull();
            _describeMetadataResultInstance.ShouldBeAssignableTo<DescribeMetadataResult>();
            _describeMetadataResultInstanceFixture.ShouldBeAssignableTo<DescribeMetadataResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DescribeMetadataResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(DescribeMetadataObject[]) , PropertymetadataObjects)]
        [TestCaseGeneric(typeof(string) , PropertyorganizationNamespace)]
        [TestCaseGeneric(typeof(bool) , PropertypartialSaveAllowed)]
        [TestCaseGeneric(typeof(bool) , PropertytestRequired)]
        public void AUT_DescribeMetadataResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DescribeMetadataResult, T>(_describeMetadataResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeMetadataResult) => Property (metadataObjects) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeMetadataResult_metadataObjects_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertymetadataObjects);
            Action currentAction = () => propertyInfo.SetValue(_describeMetadataResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeMetadataResult) => Property (metadataObjects) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeMetadataResult_Public_Class_metadataObjects_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymetadataObjects);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeMetadataResult) => Property (organizationNamespace) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeMetadataResult_Public_Class_organizationNamespace_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyorganizationNamespace);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeMetadataResult) => Property (partialSaveAllowed) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeMetadataResult_Public_Class_partialSaveAllowed_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypartialSaveAllowed);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeMetadataResult) => Property (testRequired) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeMetadataResult_Public_Class_testRequired_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytestRequired);

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