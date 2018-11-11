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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ReportBlockInfo" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportBlockInfoTest : AbstractBaseSetupTypedTest<ReportBlockInfo>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportBlockInfo) Initializer

        private const string PropertyaggregateReferences = "aggregateReferences";
        private const string PropertyblockId = "blockId";
        private const string PropertyjoinTable = "joinTable";
        private const string FieldaggregateReferencesField = "aggregateReferencesField";
        private const string FieldblockIdField = "blockIdField";
        private const string FieldjoinTableField = "joinTableField";
        private Type _reportBlockInfoInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportBlockInfo _reportBlockInfoInstance;
        private ReportBlockInfo _reportBlockInfoInstanceFixture;

        #region General Initializer : Class (ReportBlockInfo) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportBlockInfo" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportBlockInfoInstanceType = typeof(ReportBlockInfo);
            _reportBlockInfoInstanceFixture = Create(true);
            _reportBlockInfoInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportBlockInfo)

        #region General Initializer : Class (ReportBlockInfo) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportBlockInfo" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyaggregateReferences)]
        [TestCase(PropertyblockId)]
        [TestCase(PropertyjoinTable)]
        public void AUT_ReportBlockInfo_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportBlockInfoInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportBlockInfo) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportBlockInfo" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldaggregateReferencesField)]
        [TestCase(FieldblockIdField)]
        [TestCase(FieldjoinTableField)]
        public void AUT_ReportBlockInfo_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportBlockInfoInstanceFixture, 
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
        ///     Class (<see cref="ReportBlockInfo" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportBlockInfo_Is_Instance_Present_Test()
        {
            // Assert
            _reportBlockInfoInstanceType.ShouldNotBeNull();
            _reportBlockInfoInstance.ShouldNotBeNull();
            _reportBlockInfoInstanceFixture.ShouldNotBeNull();
            _reportBlockInfoInstance.ShouldBeAssignableTo<ReportBlockInfo>();
            _reportBlockInfoInstanceFixture.ShouldBeAssignableTo<ReportBlockInfo>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportBlockInfo) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportBlockInfo_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportBlockInfo instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportBlockInfoInstanceType.ShouldNotBeNull();
            _reportBlockInfoInstance.ShouldNotBeNull();
            _reportBlockInfoInstanceFixture.ShouldNotBeNull();
            _reportBlockInfoInstance.ShouldBeAssignableTo<ReportBlockInfo>();
            _reportBlockInfoInstanceFixture.ShouldBeAssignableTo<ReportBlockInfo>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportBlockInfo) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ReportAggregateReference[]) , PropertyaggregateReferences)]
        [TestCaseGeneric(typeof(string) , PropertyblockId)]
        [TestCaseGeneric(typeof(string) , PropertyjoinTable)]
        public void AUT_ReportBlockInfo_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportBlockInfo, T>(_reportBlockInfoInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportBlockInfo) => Property (aggregateReferences) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBlockInfo_aggregateReferences_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyaggregateReferences);
            Action currentAction = () => propertyInfo.SetValue(_reportBlockInfoInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportBlockInfo) => Property (aggregateReferences) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBlockInfo_Public_Class_aggregateReferences_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyaggregateReferences);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportBlockInfo) => Property (blockId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBlockInfo_Public_Class_blockId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyblockId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportBlockInfo) => Property (joinTable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBlockInfo_Public_Class_joinTable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyjoinTable);

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