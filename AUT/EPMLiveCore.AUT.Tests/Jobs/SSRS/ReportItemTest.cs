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

namespace EPMLiveCore.Jobs.SSRS
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.SSRS.ReportItem" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.SSRS"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ReportItemTest : AbstractBaseSetupTypedTest<ReportItem>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportItem) Initializer

        private const string PropertyBinaryData = "BinaryData";
        private const string PropertyFileName = "FileName";
        private const string PropertyFolder = "Folder";
        private const string PropertyLastModified = "LastModified";
        private const string PropertyDatasourceCredentials = "DatasourceCredentials";
        private Type _reportItemInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportItem _reportItemInstance;
        private ReportItem _reportItemInstanceFixture;

        #region General Initializer : Class (ReportItem) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportItem" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportItemInstanceType = typeof(ReportItem);
            _reportItemInstanceFixture = Create(true);
            _reportItemInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportItem)

        #region General Initializer : Class (ReportItem) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportItem" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyBinaryData)]
        [TestCase(PropertyFileName)]
        [TestCase(PropertyFolder)]
        [TestCase(PropertyLastModified)]
        [TestCase(PropertyDatasourceCredentials)]
        public void AUT_ReportItem_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportItemInstanceFixture,
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
        ///     Class (<see cref="ReportItem" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ReportItem_Is_Instance_Present_Test()
        {
            // Assert
            _reportItemInstanceType.ShouldNotBeNull();
            _reportItemInstance.ShouldNotBeNull();
            _reportItemInstanceFixture.ShouldNotBeNull();
            _reportItemInstance.ShouldBeAssignableTo<ReportItem>();
            _reportItemInstanceFixture.ShouldBeAssignableTo<ReportItem>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportItem) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ReportItem_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportItem instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportItemInstanceType.ShouldNotBeNull();
            _reportItemInstance.ShouldNotBeNull();
            _reportItemInstanceFixture.ShouldNotBeNull();
            _reportItemInstance.ShouldBeAssignableTo<ReportItem>();
            _reportItemInstanceFixture.ShouldBeAssignableTo<ReportItem>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportItem) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(byte[]) , PropertyBinaryData)]
        [TestCaseGeneric(typeof(string) , PropertyFileName)]
        [TestCaseGeneric(typeof(string) , PropertyFolder)]
        [TestCaseGeneric(typeof(DateTime) , PropertyLastModified)]
        [TestCaseGeneric(typeof(string) , PropertyDatasourceCredentials)]
        public void AUT_ReportItem_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportItem, T>(_reportItemInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportItem) => Property (BinaryData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportItem_BinaryData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyBinaryData);
            Action currentAction = () => propertyInfo.SetValue(_reportItemInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportItem) => Property (BinaryData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportItem_Public_Class_BinaryData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyBinaryData);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportItem) => Property (DatasourceCredentials) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportItem_Public_Class_DatasourceCredentials_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDatasourceCredentials);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportItem) => Property (FileName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportItem_Public_Class_FileName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyFileName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportItem) => Property (Folder) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportItem_Public_Class_Folder_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyFolder);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportItem) => Property (LastModified) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportItem_LastModified_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyLastModified);
            Action currentAction = () => propertyInfo.SetValue(_reportItemInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportItem) => Property (LastModified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportItem_Public_Class_LastModified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLastModified);

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