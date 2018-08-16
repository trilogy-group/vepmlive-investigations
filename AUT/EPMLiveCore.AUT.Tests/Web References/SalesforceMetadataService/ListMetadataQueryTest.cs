using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ListMetadataQuery" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ListMetadataQueryTest : AbstractBaseSetupTypedTest<ListMetadataQuery>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ListMetadataQuery) Initializer

        private const string Propertyfolder = "folder";
        private const string Propertytype = "type";
        private const string FieldfolderField = "folderField";
        private const string FieldtypeField = "typeField";
        private Type _listMetadataQueryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ListMetadataQuery _listMetadataQueryInstance;
        private ListMetadataQuery _listMetadataQueryInstanceFixture;

        #region General Initializer : Class (ListMetadataQuery) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ListMetadataQuery" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _listMetadataQueryInstanceType = typeof(ListMetadataQuery);
            _listMetadataQueryInstanceFixture = Create(true);
            _listMetadataQueryInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ListMetadataQuery)

        #region General Initializer : Class (ListMetadataQuery) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ListMetadataQuery" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyfolder)]
        [TestCase(Propertytype)]
        public void AUT_ListMetadataQuery_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_listMetadataQueryInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ListMetadataQuery) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ListMetadataQuery" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldfolderField)]
        [TestCase(FieldtypeField)]
        public void AUT_ListMetadataQuery_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_listMetadataQueryInstanceFixture, 
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
        ///     Class (<see cref="ListMetadataQuery" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ListMetadataQuery_Is_Instance_Present_Test()
        {
            // Assert
            _listMetadataQueryInstanceType.ShouldNotBeNull();
            _listMetadataQueryInstance.ShouldNotBeNull();
            _listMetadataQueryInstanceFixture.ShouldNotBeNull();
            _listMetadataQueryInstance.ShouldBeAssignableTo<ListMetadataQuery>();
            _listMetadataQueryInstanceFixture.ShouldBeAssignableTo<ListMetadataQuery>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ListMetadataQuery) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ListMetadataQuery_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ListMetadataQuery instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _listMetadataQueryInstanceType.ShouldNotBeNull();
            _listMetadataQueryInstance.ShouldNotBeNull();
            _listMetadataQueryInstanceFixture.ShouldNotBeNull();
            _listMetadataQueryInstance.ShouldBeAssignableTo<ListMetadataQuery>();
            _listMetadataQueryInstanceFixture.ShouldBeAssignableTo<ListMetadataQuery>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ListMetadataQuery) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyfolder)]
        [TestCaseGeneric(typeof(string) , Propertytype)]
        public void AUT_ListMetadataQuery_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ListMetadataQuery, T>(_listMetadataQueryInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ListMetadataQuery) => Property (folder) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListMetadataQuery_Public_Class_folder_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfolder);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ListMetadataQuery) => Property (type) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListMetadataQuery_Public_Class_type_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytype);

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