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
using EPMLiveCore.Infrastructure.Logging;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;
using EPMLiveCore;
using refreshpc = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.refreshpc" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RefreshpcTest : AbstractBaseSetupTypedTest<refreshpc>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (refreshpc) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodprocessWeb = "processWeb";
        private const string MethodgetListItemCount = "getListItemCount";
        private const string FieldprojectCenter = "projectCenter";
        private const string FieldhCurrentProjectCenter = "hCurrentProjectCenter";
        private const string Fielddebug = "debug";
        private Type _refreshpcInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private refreshpc _refreshpcInstance;
        private refreshpc _refreshpcInstanceFixture;

        #region General Initializer : Class (refreshpc) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="refreshpc" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _refreshpcInstanceType = typeof(refreshpc);
            _refreshpcInstanceFixture = Create(true);
            _refreshpcInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (refreshpc)

        #region General Initializer : Class (refreshpc) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="refreshpc" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodprocessWeb, 0)]
        [TestCase(MethodgetListItemCount, 0)]
        public void AUT_Refreshpc_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_refreshpcInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (refreshpc) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="refreshpc" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldprojectCenter)]
        [TestCase(FieldhCurrentProjectCenter)]
        [TestCase(Fielddebug)]
        public void AUT_Refreshpc_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_refreshpcInstanceFixture, 
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
        ///     Class (<see cref="refreshpc" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Refreshpc_Is_Instance_Present_Test()
        {
            // Assert
            _refreshpcInstanceType.ShouldNotBeNull();
            _refreshpcInstance.ShouldNotBeNull();
            _refreshpcInstanceFixture.ShouldNotBeNull();
            _refreshpcInstance.ShouldBeAssignableTo<refreshpc>();
            _refreshpcInstanceFixture.ShouldBeAssignableTo<refreshpc>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (refreshpc) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_refreshpc_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            refreshpc instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _refreshpcInstanceType.ShouldNotBeNull();
            _refreshpcInstance.ShouldNotBeNull();
            _refreshpcInstanceFixture.ShouldNotBeNull();
            _refreshpcInstance.ShouldBeAssignableTo<refreshpc>();
            _refreshpcInstanceFixture.ShouldBeAssignableTo<refreshpc>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="refreshpc" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodprocessWeb)]
        [TestCase(MethodgetListItemCount)]
        public void AUT_Refreshpc_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<refreshpc>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Refreshpc_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_refreshpcInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Refreshpc_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_refreshpcInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Refreshpc_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_refreshpcInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Refreshpc_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Refreshpc_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_refreshpcInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Refreshpc_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_refreshpcInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Refreshpc_processWeb_Method_Call_Internally(Type[] types)
        {
            var methodprocessWebPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_refreshpcInstance, MethodprocessWeb, Fixture, methodprocessWebPrametersTypes);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Refreshpc_processWeb_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodprocessWebPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfprocessWeb = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessWeb, methodprocessWebPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_refreshpcInstanceFixture, parametersOfprocessWeb);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessWeb.ShouldNotBeNull();
            parametersOfprocessWeb.Length.ShouldBe(1);
            methodprocessWebPrametersTypes.Length.ShouldBe(1);
            methodprocessWebPrametersTypes.Length.ShouldBe(parametersOfprocessWeb.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Refreshpc_processWeb_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodprocessWebPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfprocessWeb = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_refreshpcInstance, MethodprocessWeb, parametersOfprocessWeb, methodprocessWebPrametersTypes);

            // Assert
            parametersOfprocessWeb.ShouldNotBeNull();
            parametersOfprocessWeb.Length.ShouldBe(1);
            methodprocessWebPrametersTypes.Length.ShouldBe(1);
            methodprocessWebPrametersTypes.Length.ShouldBe(parametersOfprocessWeb.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Refreshpc_processWeb_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessWeb, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Refreshpc_processWeb_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessWebPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_refreshpcInstance, MethodprocessWeb, Fixture, methodprocessWebPrametersTypes);

            // Assert
            methodprocessWebPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Refreshpc_processWeb_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessWeb, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_refreshpcInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getListItemCount) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Refreshpc_getListItemCount_Method_Call_Internally(Type[] types)
        {
            var methodgetListItemCountPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_refreshpcInstance, MethodgetListItemCount, Fixture, methodgetListItemCountPrametersTypes);
        }

        #endregion

        #region Method Call : (getListItemCount) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Refreshpc_getListItemCount_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<string>();
            var query = CreateType<string>();
            var project = CreateType<string>();
            var methodgetListItemCountPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfgetListItemCount = { web, list, query, project };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetListItemCount, methodgetListItemCountPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<refreshpc, int>(_refreshpcInstanceFixture, out exception1, parametersOfgetListItemCount);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<refreshpc, int>(_refreshpcInstance, MethodgetListItemCount, parametersOfgetListItemCount, methodgetListItemCountPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfgetListItemCount.ShouldNotBeNull();
            parametersOfgetListItemCount.Length.ShouldBe(4);
            methodgetListItemCountPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (getListItemCount) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Refreshpc_getListItemCount_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<string>();
            var query = CreateType<string>();
            var project = CreateType<string>();
            var methodgetListItemCountPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfgetListItemCount = { web, list, query, project };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetListItemCount, methodgetListItemCountPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<refreshpc, int>(_refreshpcInstanceFixture, out exception1, parametersOfgetListItemCount);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<refreshpc, int>(_refreshpcInstance, MethodgetListItemCount, parametersOfgetListItemCount, methodgetListItemCountPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfgetListItemCount.ShouldNotBeNull();
            parametersOfgetListItemCount.Length.ShouldBe(4);
            methodgetListItemCountPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (getListItemCount) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Refreshpc_getListItemCount_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<string>();
            var query = CreateType<string>();
            var project = CreateType<string>();
            var methodgetListItemCountPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfgetListItemCount = { web, list, query, project };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetListItemCount, methodgetListItemCountPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_refreshpcInstanceFixture, parametersOfgetListItemCount);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetListItemCount.ShouldNotBeNull();
            parametersOfgetListItemCount.Length.ShouldBe(4);
            methodgetListItemCountPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getListItemCount) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Refreshpc_getListItemCount_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<string>();
            var query = CreateType<string>();
            var project = CreateType<string>();
            var methodgetListItemCountPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfgetListItemCount = { web, list, query, project };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<refreshpc, int>(_refreshpcInstance, MethodgetListItemCount, parametersOfgetListItemCount, methodgetListItemCountPrametersTypes);

            // Assert
            parametersOfgetListItemCount.ShouldNotBeNull();
            parametersOfgetListItemCount.Length.ShouldBe(4);
            methodgetListItemCountPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getListItemCount) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Refreshpc_getListItemCount_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetListItemCountPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_refreshpcInstance, MethodgetListItemCount, Fixture, methodgetListItemCountPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetListItemCountPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getListItemCount) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Refreshpc_getListItemCount_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetListItemCount, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_refreshpcInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getListItemCount) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Refreshpc_getListItemCount_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetListItemCount, 0);
            const int parametersCount = 4;

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