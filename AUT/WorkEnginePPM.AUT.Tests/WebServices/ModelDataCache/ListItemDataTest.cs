using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace ModelDataCache
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="ModelDataCache.ListItemData" />)
    ///     and namespace <see cref="ModelDataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ListItemDataTest : AbstractBaseSetupTypedTest<ListItemData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ListItemData) Initializer

        private const string PropertyUID = "UID";
        private const string PropertyID = "ID";
        private const string PropertyLevel = "Level";
        private const string PropertyName = "Name";
        private const string PropertyFullName = "FullName";
        private const string PropertyInActive = "InActive";
        private Type _listItemDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ListItemData _listItemDataInstance;
        private ListItemData _listItemDataInstanceFixture;

        #region General Initializer : Class (ListItemData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ListItemData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _listItemDataInstanceType = typeof(ListItemData);
            _listItemDataInstanceFixture = Create(true);
            _listItemDataInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ListItemData" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ListItemData_Is_Instance_Present_Test()
        {
            // Assert
            _listItemDataInstanceType.ShouldNotBeNull();
            _listItemDataInstance.ShouldNotBeNull();
            _listItemDataInstanceFixture.ShouldNotBeNull();
            _listItemDataInstance.ShouldBeAssignableTo<ListItemData>();
            _listItemDataInstanceFixture.ShouldBeAssignableTo<ListItemData>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ListItemData) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ListItemData_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ListItemData instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _listItemDataInstanceType.ShouldNotBeNull();
            _listItemDataInstance.ShouldNotBeNull();
            _listItemDataInstanceFixture.ShouldNotBeNull();
            _listItemDataInstance.ShouldBeAssignableTo<ListItemData>();
            _listItemDataInstanceFixture.ShouldBeAssignableTo<ListItemData>();
        }

        #endregion

        #endregion

        #endregion
    }
}