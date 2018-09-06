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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2005.DataSourceCredentials" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2005"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DataSourceCredentialsTest : AbstractBaseSetupTypedTest<DataSourceCredentials>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DataSourceCredentials) Initializer

        private const string PropertyDataSourceName = "DataSourceName";
        private const string PropertyUserName = "UserName";
        private const string PropertyPassword = "Password";
        private const string FielddataSourceNameField = "dataSourceNameField";
        private const string FielduserNameField = "userNameField";
        private const string FieldpasswordField = "passwordField";
        private Type _dataSourceCredentialsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DataSourceCredentials _dataSourceCredentialsInstance;
        private DataSourceCredentials _dataSourceCredentialsInstanceFixture;

        #region General Initializer : Class (DataSourceCredentials) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DataSourceCredentials" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dataSourceCredentialsInstanceType = typeof(DataSourceCredentials);
            _dataSourceCredentialsInstanceFixture = Create(true);
            _dataSourceCredentialsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DataSourceCredentials)

        #region General Initializer : Class (DataSourceCredentials) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DataSourceCredentials" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyDataSourceName)]
        [TestCase(PropertyUserName)]
        [TestCase(PropertyPassword)]
        public void AUT_DataSourceCredentials_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_dataSourceCredentialsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DataSourceCredentials) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DataSourceCredentials" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddataSourceNameField)]
        [TestCase(FielduserNameField)]
        [TestCase(FieldpasswordField)]
        public void AUT_DataSourceCredentials_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_dataSourceCredentialsInstanceFixture, 
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
        ///     Class (<see cref="DataSourceCredentials" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DataSourceCredentials_Is_Instance_Present_Test()
        {
            // Assert
            _dataSourceCredentialsInstanceType.ShouldNotBeNull();
            _dataSourceCredentialsInstance.ShouldNotBeNull();
            _dataSourceCredentialsInstanceFixture.ShouldNotBeNull();
            _dataSourceCredentialsInstance.ShouldBeAssignableTo<DataSourceCredentials>();
            _dataSourceCredentialsInstanceFixture.ShouldBeAssignableTo<DataSourceCredentials>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DataSourceCredentials) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DataSourceCredentials_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DataSourceCredentials instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dataSourceCredentialsInstanceType.ShouldNotBeNull();
            _dataSourceCredentialsInstance.ShouldNotBeNull();
            _dataSourceCredentialsInstanceFixture.ShouldNotBeNull();
            _dataSourceCredentialsInstance.ShouldBeAssignableTo<DataSourceCredentials>();
            _dataSourceCredentialsInstanceFixture.ShouldBeAssignableTo<DataSourceCredentials>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DataSourceCredentials) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyDataSourceName)]
        [TestCaseGeneric(typeof(string) , PropertyUserName)]
        [TestCaseGeneric(typeof(string) , PropertyPassword)]
        public void AUT_DataSourceCredentials_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DataSourceCredentials, T>(_dataSourceCredentialsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DataSourceCredentials) => Property (DataSourceName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSourceCredentials_Public_Class_DataSourceName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDataSourceName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSourceCredentials) => Property (Password) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSourceCredentials_Public_Class_Password_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPassword);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSourceCredentials) => Property (UserName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSourceCredentials_Public_Class_UserName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUserName);

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