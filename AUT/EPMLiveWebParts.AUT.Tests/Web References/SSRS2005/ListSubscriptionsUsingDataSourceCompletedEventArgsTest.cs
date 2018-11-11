using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.SSRS2005
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2005.ListSubscriptionsUsingDataSourceCompletedEventArgs" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2005"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ListSubscriptionsUsingDataSourceCompletedEventArgsTest : AbstractBaseSetupTypedTest<ListSubscriptionsUsingDataSourceCompletedEventArgs>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ListSubscriptionsUsingDataSourceCompletedEventArgs) Initializer

        private const string PropertyResult = "Result";
        private const string Fieldresults = "results";
        private Type _listSubscriptionsUsingDataSourceCompletedEventArgsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ListSubscriptionsUsingDataSourceCompletedEventArgs _listSubscriptionsUsingDataSourceCompletedEventArgsInstance;
        private ListSubscriptionsUsingDataSourceCompletedEventArgs _listSubscriptionsUsingDataSourceCompletedEventArgsInstanceFixture;

        #region General Initializer : Class (ListSubscriptionsUsingDataSourceCompletedEventArgs) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ListSubscriptionsUsingDataSourceCompletedEventArgs" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _listSubscriptionsUsingDataSourceCompletedEventArgsInstanceType = typeof(ListSubscriptionsUsingDataSourceCompletedEventArgs);
            _listSubscriptionsUsingDataSourceCompletedEventArgsInstanceFixture = Create(true);
            _listSubscriptionsUsingDataSourceCompletedEventArgsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ListSubscriptionsUsingDataSourceCompletedEventArgs)

        #region General Initializer : Class (ListSubscriptionsUsingDataSourceCompletedEventArgs) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ListSubscriptionsUsingDataSourceCompletedEventArgs" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyResult)]
        public void AUT_ListSubscriptionsUsingDataSourceCompletedEventArgs_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_listSubscriptionsUsingDataSourceCompletedEventArgsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ListSubscriptionsUsingDataSourceCompletedEventArgs) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ListSubscriptionsUsingDataSourceCompletedEventArgs" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Fieldresults)]
        public void AUT_ListSubscriptionsUsingDataSourceCompletedEventArgs_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_listSubscriptionsUsingDataSourceCompletedEventArgsInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ListSubscriptionsUsingDataSourceCompletedEventArgs) => Property (Result) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListSubscriptionsUsingDataSourceCompletedEventArgs_Result_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyResult);
            Action currentAction = () => propertyInfo.SetValue(_listSubscriptionsUsingDataSourceCompletedEventArgsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ListSubscriptionsUsingDataSourceCompletedEventArgs) => Property (Result) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListSubscriptionsUsingDataSourceCompletedEventArgs_Public_Class_Result_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyResult);

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