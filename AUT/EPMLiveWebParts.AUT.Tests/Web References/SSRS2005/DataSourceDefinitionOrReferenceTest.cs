using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveWebParts.SSRS2005
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2005.DataSourceDefinitionOrReference" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2005"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DataSourceDefinitionOrReferenceTest : AbstractBaseSetupTypedTest<DataSourceDefinitionOrReference>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DataSourceDefinitionOrReference) Initializer

        private Type _dataSourceDefinitionOrReferenceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DataSourceDefinitionOrReference _dataSourceDefinitionOrReferenceInstance;
        private DataSourceDefinitionOrReference _dataSourceDefinitionOrReferenceInstanceFixture;

        #region General Initializer : Class (DataSourceDefinitionOrReference) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DataSourceDefinitionOrReference" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dataSourceDefinitionOrReferenceInstanceType = typeof(DataSourceDefinitionOrReference);
            _dataSourceDefinitionOrReferenceInstanceFixture = Create(true);
            _dataSourceDefinitionOrReferenceInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="DataSourceDefinitionOrReference" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DataSourceDefinitionOrReference_Is_Instance_Present_Test()
        {
            // Assert
            _dataSourceDefinitionOrReferenceInstanceType.ShouldNotBeNull();
            _dataSourceDefinitionOrReferenceInstance.ShouldNotBeNull();
            _dataSourceDefinitionOrReferenceInstanceFixture.ShouldNotBeNull();
            _dataSourceDefinitionOrReferenceInstance.ShouldBeAssignableTo<DataSourceDefinitionOrReference>();
            _dataSourceDefinitionOrReferenceInstanceFixture.ShouldBeAssignableTo<DataSourceDefinitionOrReference>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DataSourceDefinitionOrReference) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DataSourceDefinitionOrReference_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DataSourceDefinitionOrReference instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dataSourceDefinitionOrReferenceInstanceType.ShouldNotBeNull();
            _dataSourceDefinitionOrReferenceInstance.ShouldNotBeNull();
            _dataSourceDefinitionOrReferenceInstanceFixture.ShouldNotBeNull();
            _dataSourceDefinitionOrReferenceInstance.ShouldBeAssignableTo<DataSourceDefinitionOrReference>();
            _dataSourceDefinitionOrReferenceInstanceFixture.ShouldBeAssignableTo<DataSourceDefinitionOrReference>();
        }

        #endregion

        #endregion

        #endregion
    }
}