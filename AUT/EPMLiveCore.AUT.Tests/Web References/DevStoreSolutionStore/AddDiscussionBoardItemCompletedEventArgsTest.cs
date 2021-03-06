using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.DevStoreSolutionStore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.DevStoreSolutionStore.AddDiscussionBoardItemCompletedEventArgs" />)
    ///     and namespace <see cref="EPMLiveCore.DevStoreSolutionStore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AddDiscussionBoardItemCompletedEventArgsTest : AbstractBaseSetupTypedTest<AddDiscussionBoardItemCompletedEventArgs>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AddDiscussionBoardItemCompletedEventArgs) Initializer

        private const string PropertyResult = "Result";
        private const string Fieldresults = "results";
        private Type _addDiscussionBoardItemCompletedEventArgsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AddDiscussionBoardItemCompletedEventArgs _addDiscussionBoardItemCompletedEventArgsInstance;
        private AddDiscussionBoardItemCompletedEventArgs _addDiscussionBoardItemCompletedEventArgsInstanceFixture;

        #region General Initializer : Class (AddDiscussionBoardItemCompletedEventArgs) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AddDiscussionBoardItemCompletedEventArgs" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _addDiscussionBoardItemCompletedEventArgsInstanceType = typeof(AddDiscussionBoardItemCompletedEventArgs);
            _addDiscussionBoardItemCompletedEventArgsInstanceFixture = Create(true);
            _addDiscussionBoardItemCompletedEventArgsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AddDiscussionBoardItemCompletedEventArgs)

        #region General Initializer : Class (AddDiscussionBoardItemCompletedEventArgs) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="AddDiscussionBoardItemCompletedEventArgs" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyResult)]
        public void AUT_AddDiscussionBoardItemCompletedEventArgs_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_addDiscussionBoardItemCompletedEventArgsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AddDiscussionBoardItemCompletedEventArgs) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AddDiscussionBoardItemCompletedEventArgs" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Fieldresults)]
        public void AUT_AddDiscussionBoardItemCompletedEventArgs_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_addDiscussionBoardItemCompletedEventArgsInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (AddDiscussionBoardItemCompletedEventArgs) => Property (Result) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AddDiscussionBoardItemCompletedEventArgs_Result_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyResult);
            Action currentAction = () => propertyInfo.SetValue(_addDiscussionBoardItemCompletedEventArgsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AddDiscussionBoardItemCompletedEventArgs) => Property (Result) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AddDiscussionBoardItemCompletedEventArgs_Public_Class_Result_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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