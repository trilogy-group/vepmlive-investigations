using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace CostDataValues
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="CostDataValues.clsDataItem" />)
    ///     and namespace <see cref="CostDataValues"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ClsDataItemTest : AbstractBaseSetupTypedTest<clsDataItem>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (clsDataItem) Initializer

        private const string PropertyName = "Name";
        private const string PropertyDesc = "Desc";
        private const string PropertyUID = "UID";
        private const string PropertyID = "ID";
        private const string PropertybEditiable = "bEditiable";
        private const string PropertybSelected = "bSelected";
        private Type _clsDataItemInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private clsDataItem _clsDataItemInstance;
        private clsDataItem _clsDataItemInstanceFixture;

        #region General Initializer : Class (clsDataItem) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="clsDataItem" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _clsDataItemInstanceType = typeof(clsDataItem);
            _clsDataItemInstanceFixture = Create(true);
            _clsDataItemInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="clsDataItem" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ClsDataItem_Is_Instance_Present_Test()
        {
            // Assert
            _clsDataItemInstanceType.ShouldNotBeNull();
            _clsDataItemInstance.ShouldNotBeNull();
            _clsDataItemInstanceFixture.ShouldNotBeNull();
            _clsDataItemInstance.ShouldBeAssignableTo<clsDataItem>();
            _clsDataItemInstanceFixture.ShouldBeAssignableTo<clsDataItem>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (clsDataItem) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_clsDataItem_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            clsDataItem instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _clsDataItemInstanceType.ShouldNotBeNull();
            _clsDataItemInstance.ShouldNotBeNull();
            _clsDataItemInstanceFixture.ShouldNotBeNull();
            _clsDataItemInstance.ShouldBeAssignableTo<clsDataItem>();
            _clsDataItemInstanceFixture.ShouldBeAssignableTo<clsDataItem>();
        }

        #endregion

        #endregion

        #endregion
    }
}