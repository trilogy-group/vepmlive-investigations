using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace ModelDataCache
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="ModelDataCache.ItemDefn" />)
    ///     and namespace <see cref="ModelDataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ItemDefnTest : AbstractBaseSetupTypedTest<ItemDefn>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ItemDefn) Initializer

        private const string FieldId = "Id";
        private const string FieldName = "Name";
        private const string FieldDeflt = "Deflt";
        private const string Fieldeditable = "editable";
        private Type _itemDefnInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ItemDefn _itemDefnInstance;
        private ItemDefn _itemDefnInstanceFixture;

        #region General Initializer : Class (ItemDefn) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ItemDefn" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _itemDefnInstanceType = typeof(ItemDefn);
            _itemDefnInstanceFixture = Create(true);
            _itemDefnInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ItemDefn)

        #region General Initializer : Class (ItemDefn) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ItemDefn" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldId)]
        [TestCase(FieldName)]
        [TestCase(FieldDeflt)]
        [TestCase(Fieldeditable)]
        public void AUT_ItemDefn_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_itemDefnInstanceFixture, 
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
        ///     Class (<see cref="ItemDefn" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ItemDefn_Is_Instance_Present_Test()
        {
            // Assert
            _itemDefnInstanceType.ShouldNotBeNull();
            _itemDefnInstance.ShouldNotBeNull();
            _itemDefnInstanceFixture.ShouldNotBeNull();
            _itemDefnInstance.ShouldBeAssignableTo<ItemDefn>();
            _itemDefnInstanceFixture.ShouldBeAssignableTo<ItemDefn>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ItemDefn) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ItemDefn_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ItemDefn instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _itemDefnInstanceType.ShouldNotBeNull();
            _itemDefnInstance.ShouldNotBeNull();
            _itemDefnInstanceFixture.ShouldNotBeNull();
            _itemDefnInstance.ShouldBeAssignableTo<ItemDefn>();
            _itemDefnInstanceFixture.ShouldBeAssignableTo<ItemDefn>();
        }

        #endregion

        #endregion

        #endregion
    }
}