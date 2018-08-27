using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.ProductionStore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ProductionStore.UpdateContentTypesXmlDocumentCompletedEventArgs" />)
    ///     and namespace <see cref="EPMLiveCore.ProductionStore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class UpdateContentTypesXmlDocumentCompletedEventArgsTest : AbstractBaseSetupTypedTest<UpdateContentTypesXmlDocumentCompletedEventArgs>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (UpdateContentTypesXmlDocumentCompletedEventArgs) Initializer

        private const string PropertyResult = "Result";
        private const string Fieldresults = "results";
        private Type _updateContentTypesXmlDocumentCompletedEventArgsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private UpdateContentTypesXmlDocumentCompletedEventArgs _updateContentTypesXmlDocumentCompletedEventArgsInstance;
        private UpdateContentTypesXmlDocumentCompletedEventArgs _updateContentTypesXmlDocumentCompletedEventArgsInstanceFixture;

        #region General Initializer : Class (UpdateContentTypesXmlDocumentCompletedEventArgs) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="UpdateContentTypesXmlDocumentCompletedEventArgs" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _updateContentTypesXmlDocumentCompletedEventArgsInstanceType = typeof(UpdateContentTypesXmlDocumentCompletedEventArgs);
            _updateContentTypesXmlDocumentCompletedEventArgsInstanceFixture = Create(true);
            _updateContentTypesXmlDocumentCompletedEventArgsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (UpdateContentTypesXmlDocumentCompletedEventArgs)

        #region General Initializer : Class (UpdateContentTypesXmlDocumentCompletedEventArgs) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="UpdateContentTypesXmlDocumentCompletedEventArgs" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyResult)]
        public void AUT_UpdateContentTypesXmlDocumentCompletedEventArgs_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_updateContentTypesXmlDocumentCompletedEventArgsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (UpdateContentTypesXmlDocumentCompletedEventArgs) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="UpdateContentTypesXmlDocumentCompletedEventArgs" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Fieldresults)]
        public void AUT_UpdateContentTypesXmlDocumentCompletedEventArgs_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_updateContentTypesXmlDocumentCompletedEventArgsInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (UpdateContentTypesXmlDocumentCompletedEventArgs) => Property (Result) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_UpdateContentTypesXmlDocumentCompletedEventArgs_Result_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyResult);
            Action currentAction = () => propertyInfo.SetValue(_updateContentTypesXmlDocumentCompletedEventArgsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (UpdateContentTypesXmlDocumentCompletedEventArgs) => Property (Result) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_UpdateContentTypesXmlDocumentCompletedEventArgs_Public_Class_Result_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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