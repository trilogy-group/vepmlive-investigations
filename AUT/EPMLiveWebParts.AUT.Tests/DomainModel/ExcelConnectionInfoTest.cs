using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ExcelConnectionInfo" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ExcelConnectionInfoTest : AbstractBaseSetupTypedTest<ExcelConnectionInfo>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ExcelConnectionInfo) Initializer

        private const string PropertySiteUrl = "SiteUrl";
        private const string PropertyOdcFilePrefix = "OdcFilePrefix";
        private const string PropertyDataConnectionUserName = "DataConnectionUserName";
        private const string PropertyDataConnectionUserPassword = "DataConnectionUserPassword";
        private const string PropertyDataConnectionServerName = "DataConnectionServerName";
        private const string PropertyDataConnectionReportDbName = "DataConnectionReportDbName";
        private const string PropertyDataConnectionLibraryName = "DataConnectionLibraryName";
        private const string PropertyExcelFileLibraryName = "ExcelFileLibraryName";
        private const string PropertyReportServerToken = "ReportServerToken";
        private const string PropertyReportDatabaseToken = "ReportDatabaseToken";
        private const string PropertyUserNameToken = "UserNameToken";
        private const string PropertyPasswordToken = "PasswordToken";
        private const string PropertySiteUrlToken = "SiteUrlToken";
        private const string PropertyDataConnectionLibraryToken = "DataConnectionLibraryToken";
        private Type _excelConnectionInfoInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ExcelConnectionInfo _excelConnectionInfoInstance;
        private ExcelConnectionInfo _excelConnectionInfoInstanceFixture;

        #region General Initializer : Class (ExcelConnectionInfo) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ExcelConnectionInfo" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _excelConnectionInfoInstanceType = typeof(ExcelConnectionInfo);
            _excelConnectionInfoInstanceFixture = Create(true);
            _excelConnectionInfoInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ExcelConnectionInfo)

        #region General Initializer : Class (ExcelConnectionInfo) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ExcelConnectionInfo" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertySiteUrl)]
        [TestCase(PropertyOdcFilePrefix)]
        [TestCase(PropertyDataConnectionUserName)]
        [TestCase(PropertyDataConnectionUserPassword)]
        [TestCase(PropertyDataConnectionServerName)]
        [TestCase(PropertyDataConnectionReportDbName)]
        [TestCase(PropertyDataConnectionLibraryName)]
        [TestCase(PropertyExcelFileLibraryName)]
        [TestCase(PropertyReportServerToken)]
        [TestCase(PropertyReportDatabaseToken)]
        [TestCase(PropertyUserNameToken)]
        [TestCase(PropertyPasswordToken)]
        [TestCase(PropertySiteUrlToken)]
        [TestCase(PropertyDataConnectionLibraryToken)]
        public void AUT_ExcelConnectionInfo_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_excelConnectionInfoInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ExcelConnectionInfo" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ExcelConnectionInfo_Is_Instance_Present_Test()
        {
            // Assert
            _excelConnectionInfoInstanceType.ShouldNotBeNull();
            _excelConnectionInfoInstance.ShouldNotBeNull();
            _excelConnectionInfoInstanceFixture.ShouldNotBeNull();
            _excelConnectionInfoInstance.ShouldBeAssignableTo<ExcelConnectionInfo>();
            _excelConnectionInfoInstanceFixture.ShouldBeAssignableTo<ExcelConnectionInfo>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ExcelConnectionInfo) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ExcelConnectionInfo_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ExcelConnectionInfo instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _excelConnectionInfoInstanceType.ShouldNotBeNull();
            _excelConnectionInfoInstance.ShouldNotBeNull();
            _excelConnectionInfoInstanceFixture.ShouldNotBeNull();
            _excelConnectionInfoInstance.ShouldBeAssignableTo<ExcelConnectionInfo>();
            _excelConnectionInfoInstanceFixture.ShouldBeAssignableTo<ExcelConnectionInfo>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ExcelConnectionInfo) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertySiteUrl)]
        [TestCaseGeneric(typeof(string) , PropertyOdcFilePrefix)]
        [TestCaseGeneric(typeof(string) , PropertyDataConnectionUserName)]
        [TestCaseGeneric(typeof(string) , PropertyDataConnectionUserPassword)]
        [TestCaseGeneric(typeof(string) , PropertyDataConnectionServerName)]
        [TestCaseGeneric(typeof(string) , PropertyDataConnectionReportDbName)]
        [TestCaseGeneric(typeof(string) , PropertyDataConnectionLibraryName)]
        [TestCaseGeneric(typeof(string) , PropertyExcelFileLibraryName)]
        [TestCaseGeneric(typeof(string) , PropertyReportServerToken)]
        [TestCaseGeneric(typeof(string) , PropertyReportDatabaseToken)]
        [TestCaseGeneric(typeof(string) , PropertyUserNameToken)]
        [TestCaseGeneric(typeof(string) , PropertyPasswordToken)]
        [TestCaseGeneric(typeof(string) , PropertySiteUrlToken)]
        [TestCaseGeneric(typeof(string) , PropertyDataConnectionLibraryToken)]
        public void AUT_ExcelConnectionInfo_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ExcelConnectionInfo, T>(_excelConnectionInfoInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ExcelConnectionInfo) => Property (DataConnectionLibraryName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExcelConnectionInfo_Public_Class_DataConnectionLibraryName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDataConnectionLibraryName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExcelConnectionInfo) => Property (DataConnectionLibraryToken) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExcelConnectionInfo_Public_Class_DataConnectionLibraryToken_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDataConnectionLibraryToken);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExcelConnectionInfo) => Property (DataConnectionReportDbName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExcelConnectionInfo_Public_Class_DataConnectionReportDbName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDataConnectionReportDbName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExcelConnectionInfo) => Property (DataConnectionServerName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExcelConnectionInfo_Public_Class_DataConnectionServerName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDataConnectionServerName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExcelConnectionInfo) => Property (DataConnectionUserName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExcelConnectionInfo_Public_Class_DataConnectionUserName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDataConnectionUserName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExcelConnectionInfo) => Property (DataConnectionUserPassword) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExcelConnectionInfo_Public_Class_DataConnectionUserPassword_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDataConnectionUserPassword);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExcelConnectionInfo) => Property (ExcelFileLibraryName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExcelConnectionInfo_Public_Class_ExcelFileLibraryName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyExcelFileLibraryName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExcelConnectionInfo) => Property (OdcFilePrefix) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExcelConnectionInfo_Public_Class_OdcFilePrefix_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyOdcFilePrefix);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExcelConnectionInfo) => Property (PasswordToken) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExcelConnectionInfo_Public_Class_PasswordToken_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPasswordToken);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExcelConnectionInfo) => Property (ReportDatabaseToken) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExcelConnectionInfo_Public_Class_ReportDatabaseToken_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyReportDatabaseToken);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExcelConnectionInfo) => Property (ReportServerToken) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExcelConnectionInfo_Public_Class_ReportServerToken_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyReportServerToken);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExcelConnectionInfo) => Property (SiteUrl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExcelConnectionInfo_Public_Class_SiteUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySiteUrl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExcelConnectionInfo) => Property (SiteUrlToken) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExcelConnectionInfo_Public_Class_SiteUrlToken_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySiteUrlToken);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExcelConnectionInfo) => Property (UserNameToken) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExcelConnectionInfo_Public_Class_UserNameToken_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUserNameToken);

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