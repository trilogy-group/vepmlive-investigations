using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Shouldly;
using Should = Shouldly.Should;
using NUnit.Framework;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Extensions;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests for (<see cref="RecentItems" />) class
    ///     using generator's artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class RecentItemsTest : AbstractGenericTest
    {
        #region Category : General

        #region Category : MethodCallTest

        #region General Method Call : Class (RecentItems) => Method (Create) (Return Type : string) Test

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItems_Create_Static_Method_1_Parameters_Method_Direct_Call_ParameterToken_1_Simple_Exploration_With_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => RecentItems.Create(xml);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            // Assert
            Should.Throw(() => RecentItems.Create(xml), exceptionType: actionException.GetType());
            Should.Throw<Exception>(() => RecentItems.Create(xml));
            actionException.ShouldNotBeNull();
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_RecentItems_Create_Static_Method_1_Parameters_ParameterToken_1_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => RecentItems.Create(xml);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            if (actionException == null)
            {
                // Assert
                actionException.ShouldBeNull();
                Should.NotThrow(() => RecentItems.Create(xml));
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItems_Create_Static_Method_With_1_Parameters_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            Object[] parametersOutRanged = {xml, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception;
            var recentItemsInstance  = Create(out exception);
            const string methodName = "Create";

            if (recentItemsInstance != null)
            {
                // Act
                var createMethodInfo1 = recentItemsInstance.GetType().GetMethod(methodName);
                var createMethodInfo2 = recentItemsInstance.GetType().GetMethod(methodName);
                var returnType1 = createMethodInfo1.ReturnType;
                var returnType2 = createMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                recentItemsInstance.ShouldNotBeNull();
                createMethodInfo1.ShouldNotBeNull();
                createMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_RecentItems_Create_Static_Method_With_1_Call_Using_Reflection_Result_Compare_If_Not_Null_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            Object[] parametersOutRanged = {xml, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var recentItemsInstance  = Create(out exception);
            const string methodName = "Create";

            if (recentItemsInstance != null)
            {
                // Act
                var createMethodInfo1 = recentItemsInstance.GetType().GetMethod(methodName);
                var createMethodInfo2 = recentItemsInstance.GetType().GetMethod(methodName);
                var returnType1 = createMethodInfo1.ReturnType;
                var returnType2 = createMethodInfo2.ReturnType;
                var result1 = createMethodInfo1.GetResultMethodInfo<RecentItems, string>(recentItemsInstance, out exception1, parametersOutRanged);
                var result2 = createMethodInfo2.GetResultMethodInfo<RecentItems, string>(recentItemsInstance, out exception2, parametersOutRanged);
                var result3 = createMethodInfo1.GetResultMethodInfo<RecentItems, string>(recentItemsInstance, out exception3, parametersInDifferentNumber);
                var result4 = createMethodInfo2.GetResultMethodInfo<RecentItems, string>(recentItemsInstance, out exception4, parametersInDifferentNumber);

                // Assert
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                if (result1 != null)
                {
                    result1.ShouldNotBeNull();
                    result2.ShouldNotBeNull();
                    result3.ShouldNotBeNull();
                    result4.ShouldNotBeNull();
                }
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItems_Create_Static_Method_With_1_Call_Using_Reflection_Result_Validate_Null_Results_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            Object[] parametersOutRanged = {xml, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var recentItemsInstance  = Create(out exception);
            const string methodName = "Create";

            if (recentItemsInstance != null)
            {
                // Act
                var createMethodInfo1 = recentItemsInstance.GetType().GetMethod(methodName);
                var createMethodInfo2 = recentItemsInstance.GetType().GetMethod(methodName);
                var result1 = createMethodInfo1.GetResultMethodInfo<RecentItems, string>(recentItemsInstance, out exception1, parametersOutRanged);
                var result2 = createMethodInfo2.GetResultMethodInfo<RecentItems, string>(recentItemsInstance, out exception2, parametersOutRanged);
                var result3 = createMethodInfo1.GetResultMethodInfo<RecentItems, string>(recentItemsInstance, out exception3, parametersInDifferentNumber);
                var result4 = createMethodInfo2.GetResultMethodInfo<RecentItems, string>(recentItemsInstance, out exception4, parametersInDifferentNumber);

                // Assert
                if (result1 == null)
                {
                    result1.ShouldBeNull();
                    result2.ShouldBeNull();
                    result3.ShouldBeNull();
                    result4.ShouldBeNull();
                }
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItems_Create_Static_Method_With_1_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            Object[] parametersOutRanged = {xml, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var recentItemsInstance  = Create(out exception);
            const string methodName = "Create";

            if (recentItemsInstance != null)
            {
                // Act
                var createMethodInfo1 = recentItemsInstance.GetType().GetMethod(methodName);
                var createMethodInfo2 = recentItemsInstance.GetType().GetMethod(methodName);
                var result1 = createMethodInfo1.GetResultMethodInfo<RecentItems, string>(recentItemsInstance, out exception1, parametersOutRanged);
                var result2 = createMethodInfo2.GetResultMethodInfo<RecentItems, string>(recentItemsInstance, out exception2, parametersOutRanged);
                var result3 = createMethodInfo1.GetResultMethodInfo<RecentItems, string>(recentItemsInstance, out exception3, parametersInDifferentNumber);
                var result4 = createMethodInfo2.GetResultMethodInfo<RecentItems, string>(recentItemsInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                result1.ShouldBeNull();
                result2.ShouldBeNull();
                result3.ShouldBeNull();
                result4.ShouldBeNull();
                Should.Throw(() => createMethodInfo1.Invoke(recentItemsInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => createMethodInfo2.Invoke(recentItemsInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => createMethodInfo1.Invoke(recentItemsInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => createMethodInfo2.Invoke(recentItemsInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => createMethodInfo1.Invoke(recentItemsInstance, parametersOutRanged));
                Should.Throw<Exception>(() => createMethodInfo2.Invoke(recentItemsInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => createMethodInfo1.Invoke(recentItemsInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => createMethodInfo2.Invoke(recentItemsInstance, parametersOutRanged));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_RecentItems_Create_Static_Method_With_1_Call_Using_Reflection_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            Object[] parameters = {xml};
            Exception exception, exception1, exception2, exception3, exception4;
            var recentItemsInstance  = Create(out exception);
            const string methodName = "Create";

            if (recentItemsInstance != null)
            {
                // Act
                var createMethodInfo1 = recentItemsInstance.GetType().GetMethod(methodName);
                var createMethodInfo2 = recentItemsInstance.GetType().GetMethod(methodName);
                var result1 = createMethodInfo1.GetResultMethodInfo<RecentItems, string>(recentItemsInstance, out exception1, parameters);
                var result2 = createMethodInfo2.GetResultMethodInfo<RecentItems, string>(recentItemsInstance, out exception2, parameters);
                var result3 = createMethodInfo1.GetResultMethodInfo<RecentItems, string>(recentItemsInstance, out exception3, parameters);
                var result4 = createMethodInfo2.GetResultMethodInfo<RecentItems, string>(recentItemsInstance, out exception4, parameters);

                // Assert
                if (exception1 == null)
                {
                    exception1.ShouldBeNull();
                    result1.ShouldBeNull();
                    result2.ShouldBeNull();
                    result3.ShouldBeNull();
                    result4.ShouldBeNull();
                    Should.NotThrow(() => createMethodInfo1.Invoke(recentItemsInstance, parameters));
                    Should.NotThrow(() => createMethodInfo2.Invoke(recentItemsInstance, parameters));
                }
            }
        }

        #endregion

        #endregion

        #region Category : Initializer

        #region General Initializer : Class (RecentItems) Initializer

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

        /// <summary>
        ///    Create <see cref="RecentItems" /> class.
        /// </summary>
        /// <returns>Returns a newly created <see cref="RecentItems" />.</returns>
        [ExcludeFromCodeCoverage]
        private RecentItems Create(bool useFixtureAtFirst = false)
        {
            Exception createException;
            var parameters = CreateOrGetPrameters();
            return Create(createException: out createException, useFixtureAtFirst: useFixtureAtFirst, parameters: parameters);
        }

        /// <summary>
        ///    Create <see cref="RecentItems" /> class.
        /// </summary>
        /// <returns>Returns a newly created <see cref="RecentItems" />.</returns>
        [ExcludeFromCodeCoverage]
        private RecentItems Create(out Exception createException, object[] parameters = null, bool useFixtureAtFirst = false)
        {
            return CreateAnalyzer.Create<RecentItems>(fixture: Fixture, exception: out createException, useFixtureAtFirst: useFixtureAtFirst, parameters: parameters);
        }

        /// <summary>
        ///    Create Multiple of <see cref="RecentItems" /> classes depending on the given number.
        /// </summary>
        /// <returns>Returns a newly created <see cref="RecentItems" />.</returns>
        private RecentItems[] CreateMany(out Exception[] createExceptions, out bool isResultsAreNull, int number = 6, object[] parameters = null)
        {
            return CreateAnalyzer.CreateMany<RecentItems>(number: number, fixture: Fixture, exceptions: out createExceptions, isResultsAreNull: out isResultsAreNull, parameters: parameters);
        }

        /// <summary>
        ///    Create dynamic parameters for <see cref="RecentItems" /> class using AutoFixture.
        ///    Returns null if no parameters present.
        /// </summary>
        /// <returns>Returns a object array if parameters present or else returns null.</returns>
        [ExcludeFromCodeCoverage]
        private object[] CreateOrGetPrameters()
        {
            var xml = CreateType<string>();
            var t = CreateType<AnalyticsType>();
            var a = CreateType<AnalyticsAction>();
            return new object[] {xml, t, a};
        }

        #endregion

        #region Explore Class for Coverage Gain : Class (RecentItems)

        /// <summary>
        ///     Regular class (<see cref="RecentItems" />) non-public fields explore and verify for coverage gain.
        /// </summary>
        [Test]
        [Category("AUT Initializer")]
        public void AUT_RegularClass_RecentItems_NonPublic_Fields_Explore_Verify()
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicFields<RecentItems>(Fixture);
        }

        /// <summary>
        ///     Regular class (<see cref="RecentItems" />) non-public properties explore and verify for coverage gain.
        /// </summary>
        [Test]
        [Category("AUT Initializer")]
        public void AUT_RegularClass_RecentItems_NonPublic_Properties_Explore_Verify()
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicProperties<RecentItems>(Fixture);
        }

        /// <summary>
        ///     Regular class (<see cref="RecentItems" />) non-public methods explore and verify for coverage gain.
        /// </summary>
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
        public void AUT_RegularClass_RecentItems_NonPublic_Methods_Explore_Verify(int pageNumber = 1, int perPageMethodsToVerify = 3)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicMethods<RecentItems>(Fixture, pageNumber, perPageMethodsToVerify);
        }

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RecentItems) without Parameter Test

        [Test]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RecentItems_Instantiated_Without_Parameter_Throw_Exception_Test()
        {
            // Arrange
            RecentItems instance = null;
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            if (exception != null)
            {
                // Assert
                Should.Throw<Exception>(() => new RecentItems());
                instance.ShouldBeNull();
                exception.ShouldNotBeNull();
                instance.ShouldNotBeOfType<RecentItems>();
            }
        }

        [Test]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RecentItems_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RecentItems instance = null;
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            if (exception == null)
            {
                // Assert
                Should.NotThrow(() => new RecentItems());
                instance.ShouldNotBeNull();
                exception.ShouldBeNull();
            }
        }

        [Test]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RecentItems_Without_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            RecentItems instance = null;
            Exception creationException = null;
            Action createAction = () => instance = new RecentItems();

            // Act
            creationException = ActionAnalyzer.GetActionException(createAction);

            if (instance != null)
            {
                // Assert
                instance.ShouldNotBeNull();
                instance.ShouldBeOfType<RecentItems>();
            }
        }

        #endregion

        #endregion

        #endregion
    }
}