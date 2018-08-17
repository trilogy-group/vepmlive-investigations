using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.checkDeployStatusCompletedEventArgs" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CheckDeployStatusCompletedEventArgsTest : AbstractBaseSetupTypedTest<checkDeployStatusCompletedEventArgs>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (checkDeployStatusCompletedEventArgs) Initializer

        private const string PropertyResult = "Result";
        private const string Fieldresults = "results";
        private Type _checkDeployStatusCompletedEventArgsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private checkDeployStatusCompletedEventArgs _checkDeployStatusCompletedEventArgsInstance;
        private checkDeployStatusCompletedEventArgs _checkDeployStatusCompletedEventArgsInstanceFixture;

        #region General Initializer : Class (checkDeployStatusCompletedEventArgs) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="checkDeployStatusCompletedEventArgs" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _checkDeployStatusCompletedEventArgsInstanceType = typeof(checkDeployStatusCompletedEventArgs);
            _checkDeployStatusCompletedEventArgsInstanceFixture = Create(true);
            _checkDeployStatusCompletedEventArgsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (checkDeployStatusCompletedEventArgs)

        #region General Initializer : Class (checkDeployStatusCompletedEventArgs) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="checkDeployStatusCompletedEventArgs" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyResult)]
        public void AUT_CheckDeployStatusCompletedEventArgs_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_checkDeployStatusCompletedEventArgsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (checkDeployStatusCompletedEventArgs) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="checkDeployStatusCompletedEventArgs" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Fieldresults)]
        public void AUT_CheckDeployStatusCompletedEventArgs_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_checkDeployStatusCompletedEventArgsInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion
        
        #region Category : GetterSetter

        #region General Getters/Setters : Class (checkDeployStatusCompletedEventArgs) => Property (Result) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CheckDeployStatusCompletedEventArgs_Result_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyResult);
            Action currentAction = () => propertyInfo.SetValue(_checkDeployStatusCompletedEventArgsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (checkDeployStatusCompletedEventArgs) => Property (Result) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CheckDeployStatusCompletedEventArgs_Public_Class_Result_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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