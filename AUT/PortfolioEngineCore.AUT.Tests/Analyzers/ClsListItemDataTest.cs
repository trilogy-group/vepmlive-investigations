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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="CostDataValues.clsListItemData" />)
    ///     and namespace <see cref="CostDataValues"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ClsListItemDataTest : AbstractBaseSetupTypedTest<clsListItemData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (clsListItemData) Initializer

        private const string PropertyUID = "UID";
        private const string PropertyID = "ID";
        private const string PropertyLevel = "Level";
        private const string PropertyName = "Name";
        private const string PropertyFullName = "FullName";
        private const string PropertyInActive = "InActive";
        private Type _clsListItemDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private clsListItemData _clsListItemDataInstance;
        private clsListItemData _clsListItemDataInstanceFixture;

        #region General Initializer : Class (clsListItemData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="clsListItemData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _clsListItemDataInstanceType = typeof(clsListItemData);
            _clsListItemDataInstanceFixture = Create(true);
            _clsListItemDataInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="clsListItemData" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ClsListItemData_Is_Instance_Present_Test()
        {
            // Assert
            _clsListItemDataInstanceType.ShouldNotBeNull();
            _clsListItemDataInstance.ShouldNotBeNull();
            _clsListItemDataInstanceFixture.ShouldNotBeNull();
            _clsListItemDataInstance.ShouldBeAssignableTo<clsListItemData>();
            _clsListItemDataInstanceFixture.ShouldBeAssignableTo<clsListItemData>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (clsListItemData) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_clsListItemData_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            clsListItemData instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _clsListItemDataInstanceType.ShouldNotBeNull();
            _clsListItemDataInstance.ShouldNotBeNull();
            _clsListItemDataInstanceFixture.ShouldNotBeNull();
            _clsListItemDataInstance.ShouldBeAssignableTo<clsListItemData>();
            _clsListItemDataInstanceFixture.ShouldBeAssignableTo<clsListItemData>();
        }

        #endregion

        #endregion

        #endregion
    }
}