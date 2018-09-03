using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
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
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using reportlist = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.reportlist" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportlistTest : AbstractBaseSetupTypedTest<reportlist>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (reportlist) Initializer

        private const string Methodhltpreport_OnClick = "hltpreport_OnClick";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodStrToByteArray = "StrToByteArray";
        private Type _reportlistInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private reportlist _reportlistInstance;
        private reportlist _reportlistInstanceFixture;

        #region General Initializer : Class (reportlist) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="reportlist" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportlistInstanceType = typeof(reportlist);
            _reportlistInstanceFixture = Create(true);
            _reportlistInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (reportlist)

        #region General Initializer : Class (reportlist) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="reportlist" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Methodhltpreport_OnClick, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodStrToByteArray, 0)]
        public void AUT_Reportlist_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_reportlistInstanceFixture, 
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
        ///     Class (<see cref="reportlist" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Reportlist_Is_Instance_Present_Test()
        {
            // Assert
            _reportlistInstanceType.ShouldNotBeNull();
            _reportlistInstance.ShouldNotBeNull();
            _reportlistInstanceFixture.ShouldNotBeNull();
            _reportlistInstance.ShouldBeAssignableTo<reportlist>();
            _reportlistInstanceFixture.ShouldBeAssignableTo<reportlist>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (reportlist) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_reportlist_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            reportlist instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportlistInstanceType.ShouldNotBeNull();
            _reportlistInstance.ShouldNotBeNull();
            _reportlistInstanceFixture.ShouldNotBeNull();
            _reportlistInstance.ShouldBeAssignableTo<reportlist>();
            _reportlistInstanceFixture.ShouldBeAssignableTo<reportlist>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="reportlist" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodStrToByteArray)]
        public void AUT_Reportlist_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_reportlistInstanceFixture,
                                                                              _reportlistInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="reportlist" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(Methodhltpreport_OnClick)]
        [TestCase(MethodPage_Load)]
        public void AUT_Reportlist_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<reportlist>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (hltpreport_OnClick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Reportlist_hltpreport_OnClick_Method_Call_Internally(Type[] types)
        {
            var methodhltpreport_OnClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportlistInstance, Methodhltpreport_OnClick, Fixture, methodhltpreport_OnClickPrametersTypes);
        }

        #endregion

        #region Method Call : (hltpreport_OnClick) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reportlist_hltpreport_OnClick_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<CommandEventArgs>();
            var methodhltpreport_OnClickPrametersTypes = new Type[] { typeof(object), typeof(CommandEventArgs) };
            object[] parametersOfhltpreport_OnClick = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodhltpreport_OnClick, methodhltpreport_OnClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportlistInstanceFixture, parametersOfhltpreport_OnClick);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfhltpreport_OnClick.ShouldNotBeNull();
            parametersOfhltpreport_OnClick.Length.ShouldBe(2);
            methodhltpreport_OnClickPrametersTypes.Length.ShouldBe(2);
            methodhltpreport_OnClickPrametersTypes.Length.ShouldBe(parametersOfhltpreport_OnClick.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (hltpreport_OnClick) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reportlist_hltpreport_OnClick_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<CommandEventArgs>();
            var methodhltpreport_OnClickPrametersTypes = new Type[] { typeof(object), typeof(CommandEventArgs) };
            object[] parametersOfhltpreport_OnClick = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportlistInstance, Methodhltpreport_OnClick, parametersOfhltpreport_OnClick, methodhltpreport_OnClickPrametersTypes);

            // Assert
            parametersOfhltpreport_OnClick.ShouldNotBeNull();
            parametersOfhltpreport_OnClick.Length.ShouldBe(2);
            methodhltpreport_OnClickPrametersTypes.Length.ShouldBe(2);
            methodhltpreport_OnClickPrametersTypes.Length.ShouldBe(parametersOfhltpreport_OnClick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (hltpreport_OnClick) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reportlist_hltpreport_OnClick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodhltpreport_OnClick, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (hltpreport_OnClick) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reportlist_hltpreport_OnClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodhltpreport_OnClickPrametersTypes = new Type[] { typeof(object), typeof(CommandEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportlistInstance, Methodhltpreport_OnClick, Fixture, methodhltpreport_OnClickPrametersTypes);

            // Assert
            methodhltpreport_OnClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (hltpreport_OnClick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reportlist_hltpreport_OnClick_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodhltpreport_OnClick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportlistInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Reportlist_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportlistInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reportlist_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportlistInstanceFixture, parametersOfPage_Load);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reportlist_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportlistInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Reportlist_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Reportlist_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportlistInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reportlist_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportlistInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Reportlist_StrToByteArray_Static_Method_Call_Internally(Type[] types)
        {
            var methodStrToByteArrayPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportlistInstanceFixture, _reportlistInstanceType, MethodStrToByteArray, Fixture, methodStrToByteArrayPrametersTypes);
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reportlist_StrToByteArray_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var str = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => reportlist.StrToByteArray(str);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reportlist_StrToByteArray_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var str = CreateType<string>();
            var methodStrToByteArrayPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStrToByteArray = { str };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodStrToByteArray, methodStrToByteArrayPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportlistInstanceFixture, parametersOfStrToByteArray);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfStrToByteArray.ShouldNotBeNull();
            parametersOfStrToByteArray.Length.ShouldBe(1);
            methodStrToByteArrayPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reportlist_StrToByteArray_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var str = CreateType<string>();
            var methodStrToByteArrayPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStrToByteArray = { str };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<byte[]>(_reportlistInstanceFixture, _reportlistInstanceType, MethodStrToByteArray, parametersOfStrToByteArray, methodStrToByteArrayPrametersTypes);

            // Assert
            parametersOfStrToByteArray.ShouldNotBeNull();
            parametersOfStrToByteArray.Length.ShouldBe(1);
            methodStrToByteArrayPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reportlist_StrToByteArray_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodStrToByteArrayPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportlistInstanceFixture, _reportlistInstanceType, MethodStrToByteArray, Fixture, methodStrToByteArrayPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodStrToByteArrayPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reportlist_StrToByteArray_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodStrToByteArrayPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportlistInstanceFixture, _reportlistInstanceType, MethodStrToByteArray, Fixture, methodStrToByteArrayPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodStrToByteArrayPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reportlist_StrToByteArray_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStrToByteArray, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportlistInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reportlist_StrToByteArray_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodStrToByteArray, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #endregion

        #endregion
    }
}