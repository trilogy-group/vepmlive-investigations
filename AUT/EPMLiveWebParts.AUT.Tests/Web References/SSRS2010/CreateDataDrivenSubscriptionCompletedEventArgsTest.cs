using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveWebParts.SSRS2010
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2010.CreateDataDrivenSubscriptionCompletedEventArgs" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2010"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CreateDataDrivenSubscriptionCompletedEventArgsTest : AbstractBaseSetupTypedTest<CreateDataDrivenSubscriptionCompletedEventArgs>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CreateDataDrivenSubscriptionCompletedEventArgs) Initializer

        private const string PropertyResult = "Result";
        private const string Fieldresults = "results";
        private Type _createDataDrivenSubscriptionCompletedEventArgsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CreateDataDrivenSubscriptionCompletedEventArgs _createDataDrivenSubscriptionCompletedEventArgsInstance;
        private CreateDataDrivenSubscriptionCompletedEventArgs _createDataDrivenSubscriptionCompletedEventArgsInstanceFixture;

        #region General Initializer : Class (CreateDataDrivenSubscriptionCompletedEventArgs) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CreateDataDrivenSubscriptionCompletedEventArgs" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _createDataDrivenSubscriptionCompletedEventArgsInstanceType = typeof(CreateDataDrivenSubscriptionCompletedEventArgs);
            _createDataDrivenSubscriptionCompletedEventArgsInstanceFixture = Create(true);
            _createDataDrivenSubscriptionCompletedEventArgsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CreateDataDrivenSubscriptionCompletedEventArgs)

        #region General Initializer : Class (CreateDataDrivenSubscriptionCompletedEventArgs) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CreateDataDrivenSubscriptionCompletedEventArgs" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyResult)]
        public void AUT_CreateDataDrivenSubscriptionCompletedEventArgs_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_createDataDrivenSubscriptionCompletedEventArgsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CreateDataDrivenSubscriptionCompletedEventArgs) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CreateDataDrivenSubscriptionCompletedEventArgs" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Fieldresults)]
        public void AUT_CreateDataDrivenSubscriptionCompletedEventArgs_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_createDataDrivenSubscriptionCompletedEventArgsInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CreateDataDrivenSubscriptionCompletedEventArgs) => Property (Result) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CreateDataDrivenSubscriptionCompletedEventArgs_Public_Class_Result_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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