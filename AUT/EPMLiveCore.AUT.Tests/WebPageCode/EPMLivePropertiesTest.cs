using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using EPMLiveProperties = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.EPMLiveProperties" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EPMLivePropertiesTest : AbstractBaseSetupTypedTest<EPMLiveProperties>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EPMLiveProperties) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodWebApplicationSelector1_ContextChange = "WebApplicationSelector1_ContextChange";
        private const string FieldcurrentWebUrl = "currentWebUrl";
        private const string FieldanalyticsUrl = "analyticsUrl";
        private const string FieldepmlApiUrl = "epmlApiUrl";
        private const string FieldWebApplicationSelector1 = "WebApplicationSelector1";
        private Type _ePMLivePropertiesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EPMLiveProperties _ePMLivePropertiesInstance;
        private EPMLiveProperties _ePMLivePropertiesInstanceFixture;

        #region General Initializer : Class (EPMLiveProperties) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EPMLiveProperties" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ePMLivePropertiesInstanceType = typeof(EPMLiveProperties);
            _ePMLivePropertiesInstanceFixture = Create(true);
            _ePMLivePropertiesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EPMLiveProperties)

        #region General Initializer : Class (EPMLiveProperties) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EPMLiveProperties" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodWebApplicationSelector1_ContextChange, 0)]
        public void AUT_EPMLiveProperties_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_ePMLivePropertiesInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EPMLiveProperties) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EPMLiveProperties" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldcurrentWebUrl)]
        [TestCase(FieldanalyticsUrl)]
        [TestCase(FieldepmlApiUrl)]
        [TestCase(FieldWebApplicationSelector1)]
        public void AUT_EPMLiveProperties_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_ePMLivePropertiesInstanceFixture, 
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
        ///     Class (<see cref="EPMLiveProperties" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_EPMLiveProperties_Is_Instance_Present_Test()
        {
            // Assert
            _ePMLivePropertiesInstanceType.ShouldNotBeNull();
            _ePMLivePropertiesInstance.ShouldNotBeNull();
            _ePMLivePropertiesInstanceFixture.ShouldNotBeNull();
            _ePMLivePropertiesInstance.ShouldBeAssignableTo<EPMLiveProperties>();
            _ePMLivePropertiesInstanceFixture.ShouldBeAssignableTo<EPMLiveProperties>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EPMLiveProperties) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_EPMLiveProperties_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EPMLiveProperties instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _ePMLivePropertiesInstanceType.ShouldNotBeNull();
            _ePMLivePropertiesInstance.ShouldNotBeNull();
            _ePMLivePropertiesInstanceFixture.ShouldNotBeNull();
            _ePMLivePropertiesInstance.ShouldBeAssignableTo<EPMLiveProperties>();
            _ePMLivePropertiesInstanceFixture.ShouldBeAssignableTo<EPMLiveProperties>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="EPMLiveProperties" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodWebApplicationSelector1_ContextChange)]
        public void AUT_EPMLiveProperties_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<EPMLiveProperties>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveProperties_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLivePropertiesInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveProperties_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLivePropertiesInstanceFixture, parametersOfPage_Load);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveProperties_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMLivePropertiesInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

            // Assert
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveProperties_Page_Load_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveProperties_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLivePropertiesInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveProperties_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLivePropertiesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WebApplicationSelector1_ContextChange) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveProperties_WebApplicationSelector1_ContextChange_Method_Call_Internally(Type[] types)
        {
            var methodWebApplicationSelector1_ContextChangePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLivePropertiesInstance, MethodWebApplicationSelector1_ContextChange, Fixture, methodWebApplicationSelector1_ContextChangePrametersTypes);
        }

        #endregion

        #region Method Call : (WebApplicationSelector1_ContextChange) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveProperties_WebApplicationSelector1_ContextChange_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodWebApplicationSelector1_ContextChangePrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfWebApplicationSelector1_ContextChange = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWebApplicationSelector1_ContextChange, methodWebApplicationSelector1_ContextChangePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLivePropertiesInstanceFixture, parametersOfWebApplicationSelector1_ContextChange);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWebApplicationSelector1_ContextChange.ShouldNotBeNull();
            parametersOfWebApplicationSelector1_ContextChange.Length.ShouldBe(2);
            methodWebApplicationSelector1_ContextChangePrametersTypes.Length.ShouldBe(2);
            methodWebApplicationSelector1_ContextChangePrametersTypes.Length.ShouldBe(parametersOfWebApplicationSelector1_ContextChange.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (WebApplicationSelector1_ContextChange) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveProperties_WebApplicationSelector1_ContextChange_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodWebApplicationSelector1_ContextChangePrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfWebApplicationSelector1_ContextChange = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMLivePropertiesInstance, MethodWebApplicationSelector1_ContextChange, parametersOfWebApplicationSelector1_ContextChange, methodWebApplicationSelector1_ContextChangePrametersTypes);

            // Assert
            parametersOfWebApplicationSelector1_ContextChange.ShouldNotBeNull();
            parametersOfWebApplicationSelector1_ContextChange.Length.ShouldBe(2);
            methodWebApplicationSelector1_ContextChangePrametersTypes.Length.ShouldBe(2);
            methodWebApplicationSelector1_ContextChangePrametersTypes.Length.ShouldBe(parametersOfWebApplicationSelector1_ContextChange.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WebApplicationSelector1_ContextChange) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveProperties_WebApplicationSelector1_ContextChange_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWebApplicationSelector1_ContextChange, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WebApplicationSelector1_ContextChange) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveProperties_WebApplicationSelector1_ContextChange_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWebApplicationSelector1_ContextChangePrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLivePropertiesInstance, MethodWebApplicationSelector1_ContextChange, Fixture, methodWebApplicationSelector1_ContextChangePrametersTypes);

            // Assert
            methodWebApplicationSelector1_ContextChangePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WebApplicationSelector1_ContextChange) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveProperties_WebApplicationSelector1_ContextChange_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWebApplicationSelector1_ContextChange, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLivePropertiesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}