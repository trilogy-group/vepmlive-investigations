using System;
using System.Diagnostics.CodeAnalysis;
using Shouldly;
using Should = Shouldly.Should;
using NUnit.Framework;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Extensions;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests for (<see cref="FRFQueryParamFactory" />) class
    ///     using generator's artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class FRFQueryParamFactoryTest : AbstractGenericTest
    {
        #region Category : General

        #region Category : MethodCallTest

        #region General Method Call : Class (FRFQueryParamFactory) => Method (GetParam) (Return Type : Dictionary<string, object>) Test

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetParam_Static_Method_1_Parameters_Method_Direct_Call_ParameterToken_1_Simple_Exploration_With_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            Action executeAction = null;

            // Act
            executeAction = () => FRFQueryParamFactory.GetParam(data);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            // Assert
            Should.Throw(() => FRFQueryParamFactory.GetParam(data), exceptionType: actionException.GetType());
            Should.Throw<Exception>(() => FRFQueryParamFactory.GetParam(data));
            actionException.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #region Category : Initializer

        #region General Initializer : Class (FRFQueryParamFactory) Initializer

        /// <summary>
        ///    Create parameter or simple data-type using AutoFixture or Activator.
        /// </summary>
        /// <typeparam name="T">Create Given type.</typeparam>
        /// <returns>Returns a type of T</returns>
        [ExcludeFromCodeCoverage]
        private T CreateType<T>()
        {
            Exception exception;
            return CreateType<T>(out exception);
        }

        /// <summary>
        ///    Create parameter or simple data-type using AutoFixture or Activator or Constructor.
        /// </summary>
        /// <typeparam name="T">Create Given type.</typeparam>
        /// <returns>Returns a type of T</returns>
        [ExcludeFromCodeCoverage]
        private T CreateType<T>(out Exception exception)
        {
            return CreateAnalyzer.CreateTypeUsingFixtureOrConstuctor<T>(fixture: Fixture, exception: out exception);
        }
        #endregion

        #region Explore Class for Coverage Gain : Class (FRFQueryParamFactory)

        /// <summary>
        ///     Static class (<see cref="FRFQueryParamFactory" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Category("AUT Initializer")]
        public void AUT_StaticClass_FRFQueryParamFactory_Fields_Explore_Verify()
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticClassVerifiesFields(Fixture, type: typeof(FRFQueryParamFactory));
        }

        /// <summary>
        ///     Static class (<see cref="FRFQueryParamFactory" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Category("AUT Initializer")]
        public void AUT_StaticClass_FRFQueryParamFactory_Properties_Explore_Verify()
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticClassVerifiesProperties(Fixture, type: typeof(FRFQueryParamFactory));
        }

        /// <summary>
        ///     Static class (<see cref="FRFQueryParamFactory" />) explore and verify methods for coverage gain.
        /// </summary>
        /// <param name="pageNumber">Current page number for explore and coverage gain.</param>
        /// <param name="perPageMethodsToVerify">Per page how many items should be tested and explored.</param>
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [Category("AUT Initializer")]
        public void AUT_StaticClass_FRFQueryParamFactory_Methods_Explore_Verify(int pageNumber = 1, int perPageMethodsToVerify = 3)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticClassVerifiesMethodCalls(Fixture, type: typeof(FRFQueryParamFactory), pageNumber: pageNumber, perPageItems: perPageMethodsToVerify);
        }

        #endregion

        #endregion

        #endregion
    }
}