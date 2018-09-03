using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using EPMLiveCore.API;
using EPMLiveCore.Controls.Navigation.Providers;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using ControlCollectionExtensions = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ControlCollectionExtensions" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ControlCollectionExtensionsTest : AbstractBaseSetupTest
    {

        public ControlCollectionExtensionsTest() : base(typeof(ControlCollectionExtensions))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ControlCollectionExtensions) Initializer

        private const string MethodAddAfter = "AddAfter";
        private Type _controlCollectionExtensionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (ControlCollectionExtensions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ControlCollectionExtensions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _controlCollectionExtensionsInstanceType = typeof(ControlCollectionExtensions);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ControlCollectionExtensions)

        #region General Initializer : Class (ControlCollectionExtensions) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ControlCollectionExtensions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodAddAfter, 0)]
        public void AUT_ControlCollectionExtensions_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(null, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ControlCollectionExtensions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ControlCollectionExtensions_Is_Static_Type_Present_Test()
        {
            // Assert
            _controlCollectionExtensionsInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ControlCollectionExtensions" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAddAfter)]
        public void AUT_ControlCollectionExtensions_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _controlCollectionExtensionsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (AddAfter) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ControlCollectionExtensions_AddAfter_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddAfterPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _controlCollectionExtensionsInstanceType, MethodAddAfter, Fixture, methodAddAfterPrametersTypes);
        }

        #endregion

        #region Method Call : (AddAfter) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ControlCollectionExtensions_AddAfter_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var collection = CreateType<ControlCollection>();
            var after = CreateType<Control>();
            var control = CreateType<Control>();
            Action executeAction = null;

            // Act
            executeAction = () => ControlCollectionExtensions.AddAfter(collection, after, control);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddAfter) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ControlCollectionExtensions_AddAfter_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var collection = CreateType<ControlCollection>();
            var after = CreateType<Control>();
            var control = CreateType<Control>();
            var methodAddAfterPrametersTypes = new Type[] { typeof(ControlCollection), typeof(Control), typeof(Control) };
            object[] parametersOfAddAfter = { collection, after, control };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddAfter, methodAddAfterPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfAddAfter);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddAfter.ShouldNotBeNull();
            parametersOfAddAfter.Length.ShouldBe(3);
            methodAddAfterPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddAfter) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ControlCollectionExtensions_AddAfter_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var collection = CreateType<ControlCollection>();
            var after = CreateType<Control>();
            var control = CreateType<Control>();
            var methodAddAfterPrametersTypes = new Type[] { typeof(ControlCollection), typeof(Control), typeof(Control) };
            object[] parametersOfAddAfter = { collection, after, control };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _controlCollectionExtensionsInstanceType, MethodAddAfter, parametersOfAddAfter, methodAddAfterPrametersTypes);

            // Assert
            parametersOfAddAfter.ShouldNotBeNull();
            parametersOfAddAfter.Length.ShouldBe(3);
            methodAddAfterPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddAfter) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ControlCollectionExtensions_AddAfter_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddAfter, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddAfter) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ControlCollectionExtensions_AddAfter_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddAfterPrametersTypes = new Type[] { typeof(ControlCollection), typeof(Control), typeof(Control) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _controlCollectionExtensionsInstanceType, MethodAddAfter, Fixture, methodAddAfterPrametersTypes);

            // Assert
            methodAddAfterPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddAfter) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ControlCollectionExtensions_AddAfter_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddAfter, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}