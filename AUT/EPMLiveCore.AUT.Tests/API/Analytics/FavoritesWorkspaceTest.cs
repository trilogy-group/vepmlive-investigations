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
    ///     Automatic Unit Tests for (<see cref="FavoritesWorkspace" />) class
    ///     using generator's artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class FavoritesWorkspaceTest : AbstractGenericTest
    {
        #region Category : General

        #region Category : MethodCallTest

        #region General Method Call : Class (FavoritesWorkspace) => Method (IsFavWorkspace) (Return Type : string) Test

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_IsFavWorkspace_Static_Method_1_Parameters_Method_Direct_Call_ParameterToken_1_Simple_Exploration_With_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => FavoritesWorkspace.IsFavWorkspace(xml);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            // Assert
            Should.Throw(() => FavoritesWorkspace.IsFavWorkspace(xml), exceptionType: actionException.GetType());
            Should.Throw<Exception>(() => FavoritesWorkspace.IsFavWorkspace(xml));
            actionException.ShouldNotBeNull();
        }

        #endregion

        #region General Method Call : Class (FavoritesWorkspace) => Method (AddFavWorkspace) (Return Type : string) Test

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_AddFavWorkspace_Static_Method_1_Parameters_Method_Direct_Call_ParameterToken_2_Simple_Exploration_With_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => FavoritesWorkspace.AddFavWorkspace(xml);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            // Assert
            Should.Throw(() => FavoritesWorkspace.AddFavWorkspace(xml), exceptionType: actionException.GetType());
            Should.Throw<Exception>(() => FavoritesWorkspace.AddFavWorkspace(xml));
            actionException.ShouldNotBeNull();
        }

        #endregion

        #region General Method Call : Class (FavoritesWorkspace) => Method (RemoveFavWorkspace) (Return Type : string) Test

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_RemoveFavWorkspace_Static_Method_1_Parameters_Method_Direct_Call_ParameterToken_3_Simple_Exploration_With_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => FavoritesWorkspace.RemoveFavWorkspace(xml);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            // Assert
            Should.Throw(() => FavoritesWorkspace.RemoveFavWorkspace(xml), exceptionType: actionException.GetType());
            Should.Throw<Exception>(() => FavoritesWorkspace.RemoveFavWorkspace(xml));
            actionException.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #region Category : Initializer

        #region General Initializer : Class (FavoritesWorkspace) Initializer

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

        #region Explore Class for Coverage Gain : Class (FavoritesWorkspace)

        /// <summary>
        ///     Static class (<see cref="FavoritesWorkspace" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Category("AUT Initializer")]
        public void AUT_StaticClass_FavoritesWorkspace_Fields_Explore_Verify()
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticClassVerifiesFields(Fixture, type: typeof(FavoritesWorkspace));
        }

        /// <summary>
        ///     Static class (<see cref="FavoritesWorkspace" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Category("AUT Initializer")]
        public void AUT_StaticClass_FavoritesWorkspace_Properties_Explore_Verify()
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticClassVerifiesProperties(Fixture, type: typeof(FavoritesWorkspace));
        }

        /// <summary>
        ///     Static class (<see cref="FavoritesWorkspace" />) explore and verify methods for coverage gain.
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
        public void AUT_StaticClass_FavoritesWorkspace_Methods_Explore_Verify(int pageNumber = 1, int perPageMethodsToVerify = 3)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticClassVerifiesMethodCalls(Fixture, type: typeof(FavoritesWorkspace), pageNumber: pageNumber, perPageItems: perPageMethodsToVerify);
        }

        #endregion

        #endregion

        #endregion
    }
}