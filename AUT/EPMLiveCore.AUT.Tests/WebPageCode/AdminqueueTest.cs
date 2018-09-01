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
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.WebControls;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using adminqueue = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.adminqueue" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AdminqueueTest : AbstractBaseSetupTypedTest<adminqueue>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (adminqueue) Initializer

        private const string MethodWebApplicationSelector1_ContextChange = "WebApplicationSelector1_ContextChange";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodGetInfo = "GetInfo";
        private const string MethodButton1_OnClick = "Button1_OnClick";
        private const string Methodshowtime = "showtime";
        private const string MethodGvItems_RowDataBound = "GvItems_RowDataBound";
        private const string FieldGvItems = "GvItems";
        private const string FieldlblLength = "lblLength";
        private const string FieldlblWait = "lblWait";
        private const string FieldlblJobTime = "lblJobTime";
        private const string FieldlblTotalJobs = "lblTotalJobs";
        private const string FieldlblMaxQueue = "lblMaxQueue";
        private const string FieldlblMaxJob = "lblMaxJob";
        private const string FieldtxtMainThreads = "txtMainThreads";
        private const string FieldtxtInterval = "txtInterval";
        private const string FieldtxtSecurityThreads = "txtSecurityThreads";
        private const string FieldtxtRollupQueueThreads = "txtRollupQueueThreads";
        private const string FieldtxtHighPriorityQueueThreads = "txtHighPriorityQueueThreads";
        private const string FieldtxtTimesheetThreads = "txtTimesheetThreads";
        private const string FieldWebApplicationSelector1 = "WebApplicationSelector1";
        private Type _adminqueueInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private adminqueue _adminqueueInstance;
        private adminqueue _adminqueueInstanceFixture;

        #region General Initializer : Class (adminqueue) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="adminqueue" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _adminqueueInstanceType = typeof(adminqueue);
            _adminqueueInstanceFixture = Create(true);
            _adminqueueInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (adminqueue)

        #region General Initializer : Class (adminqueue) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="adminqueue" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodWebApplicationSelector1_ContextChange, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodGetInfo, 0)]
        [TestCase(MethodButton1_OnClick, 0)]
        [TestCase(Methodshowtime, 0)]
        [TestCase(MethodGvItems_RowDataBound, 0)]
        public void AUT_Adminqueue_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_adminqueueInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (adminqueue) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="adminqueue" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldGvItems)]
        [TestCase(FieldlblLength)]
        [TestCase(FieldlblWait)]
        [TestCase(FieldlblJobTime)]
        [TestCase(FieldlblTotalJobs)]
        [TestCase(FieldlblMaxQueue)]
        [TestCase(FieldlblMaxJob)]
        [TestCase(FieldtxtMainThreads)]
        [TestCase(FieldtxtInterval)]
        [TestCase(FieldtxtSecurityThreads)]
        [TestCase(FieldtxtRollupQueueThreads)]
        [TestCase(FieldtxtHighPriorityQueueThreads)]
        [TestCase(FieldtxtTimesheetThreads)]
        [TestCase(FieldWebApplicationSelector1)]
        public void AUT_Adminqueue_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_adminqueueInstanceFixture, 
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
        ///     Class (<see cref="adminqueue" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Adminqueue_Is_Instance_Present_Test()
        {
            // Assert
            _adminqueueInstanceType.ShouldNotBeNull();
            _adminqueueInstance.ShouldNotBeNull();
            _adminqueueInstanceFixture.ShouldNotBeNull();
            _adminqueueInstance.ShouldBeAssignableTo<adminqueue>();
            _adminqueueInstanceFixture.ShouldBeAssignableTo<adminqueue>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (adminqueue) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_adminqueue_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            adminqueue instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _adminqueueInstanceType.ShouldNotBeNull();
            _adminqueueInstance.ShouldNotBeNull();
            _adminqueueInstanceFixture.ShouldNotBeNull();
            _adminqueueInstance.ShouldBeAssignableTo<adminqueue>();
            _adminqueueInstanceFixture.ShouldBeAssignableTo<adminqueue>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="adminqueue" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodWebApplicationSelector1_ContextChange)]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodGetInfo)]
        [TestCase(MethodButton1_OnClick)]
        [TestCase(Methodshowtime)]
        [TestCase(MethodGvItems_RowDataBound)]
        public void AUT_Adminqueue_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<adminqueue>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (WebApplicationSelector1_ContextChange) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adminqueue_WebApplicationSelector1_ContextChange_Method_Call_Internally(Type[] types)
        {
            var methodWebApplicationSelector1_ContextChangePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminqueueInstance, MethodWebApplicationSelector1_ContextChange, Fixture, methodWebApplicationSelector1_ContextChangePrametersTypes);
        }

        #endregion

        #region Method Call : (WebApplicationSelector1_ContextChange) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_WebApplicationSelector1_ContextChange_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodWebApplicationSelector1_ContextChangePrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfWebApplicationSelector1_ContextChange = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWebApplicationSelector1_ContextChange, methodWebApplicationSelector1_ContextChangePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adminqueueInstanceFixture, parametersOfWebApplicationSelector1_ContextChange);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWebApplicationSelector1_ContextChange.ShouldNotBeNull();
            parametersOfWebApplicationSelector1_ContextChange.Length.ShouldBe(2);
            methodWebApplicationSelector1_ContextChangePrametersTypes.Length.ShouldBe(2);
            methodWebApplicationSelector1_ContextChangePrametersTypes.Length.ShouldBe(parametersOfWebApplicationSelector1_ContextChange.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WebApplicationSelector1_ContextChange) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_WebApplicationSelector1_ContextChange_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodWebApplicationSelector1_ContextChangePrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfWebApplicationSelector1_ContextChange = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adminqueueInstance, MethodWebApplicationSelector1_ContextChange, parametersOfWebApplicationSelector1_ContextChange, methodWebApplicationSelector1_ContextChangePrametersTypes);

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
        public void AUT_Adminqueue_WebApplicationSelector1_ContextChange_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Adminqueue_WebApplicationSelector1_ContextChange_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWebApplicationSelector1_ContextChangePrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminqueueInstance, MethodWebApplicationSelector1_ContextChange, Fixture, methodWebApplicationSelector1_ContextChangePrametersTypes);

            // Assert
            methodWebApplicationSelector1_ContextChangePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WebApplicationSelector1_ContextChange) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_WebApplicationSelector1_ContextChange_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWebApplicationSelector1_ContextChange, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adminqueueInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adminqueue_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminqueueInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adminqueueInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Adminqueue_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adminqueueInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Adminqueue_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Adminqueue_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminqueueInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adminqueueInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetInfo) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adminqueue_GetInfo_Method_Call_Internally(Type[] types)
        {
            var methodGetInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminqueueInstance, MethodGetInfo, Fixture, methodGetInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (GetInfo) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_GetInfo_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetInfoPrametersTypes = null;
            object[] parametersOfGetInfo = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetInfo, methodGetInfoPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adminqueueInstanceFixture, parametersOfGetInfo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetInfo.ShouldBeNull();
            methodGetInfoPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetInfo) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_GetInfo_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetInfoPrametersTypes = null;
            object[] parametersOfGetInfo = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adminqueueInstance, MethodGetInfo, parametersOfGetInfo, methodGetInfoPrametersTypes);

            // Assert
            parametersOfGetInfo.ShouldBeNull();
            methodGetInfoPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetInfo) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_GetInfo_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetInfoPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminqueueInstance, MethodGetInfo, Fixture, methodGetInfoPrametersTypes);

            // Assert
            methodGetInfoPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetInfo) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_GetInfo_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetInfo, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adminqueueInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button1_OnClick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adminqueue_Button1_OnClick_Method_Call_Internally(Type[] types)
        {
            var methodButton1_OnClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminqueueInstance, MethodButton1_OnClick, Fixture, methodButton1_OnClickPrametersTypes);
        }

        #endregion

        #region Method Call : (Button1_OnClick) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_Button1_OnClick_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton1_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton1_OnClick = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodButton1_OnClick, methodButton1_OnClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adminqueueInstanceFixture, parametersOfButton1_OnClick);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfButton1_OnClick.ShouldNotBeNull();
            parametersOfButton1_OnClick.Length.ShouldBe(2);
            methodButton1_OnClickPrametersTypes.Length.ShouldBe(2);
            methodButton1_OnClickPrametersTypes.Length.ShouldBe(parametersOfButton1_OnClick.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Button1_OnClick) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_Button1_OnClick_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton1_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton1_OnClick = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adminqueueInstance, MethodButton1_OnClick, parametersOfButton1_OnClick, methodButton1_OnClickPrametersTypes);

            // Assert
            parametersOfButton1_OnClick.ShouldNotBeNull();
            parametersOfButton1_OnClick.Length.ShouldBe(2);
            methodButton1_OnClickPrametersTypes.Length.ShouldBe(2);
            methodButton1_OnClickPrametersTypes.Length.ShouldBe(parametersOfButton1_OnClick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button1_OnClick) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_Button1_OnClick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodButton1_OnClick, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Button1_OnClick) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_Button1_OnClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodButton1_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminqueueInstance, MethodButton1_OnClick, Fixture, methodButton1_OnClickPrametersTypes);

            // Assert
            methodButton1_OnClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button1_OnClick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_Button1_OnClick_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodButton1_OnClick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adminqueueInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (showtime) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adminqueue_showtime_Method_Call_Internally(Type[] types)
        {
            var methodshowtimePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminqueueInstance, Methodshowtime, Fixture, methodshowtimePrametersTypes);
        }

        #endregion

        #region Method Call : (showtime) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_showtime_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var seconds = CreateType<int>();
            var methodshowtimePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfshowtime = { seconds };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodshowtime, methodshowtimePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adminqueueInstanceFixture, parametersOfshowtime);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfshowtime.ShouldNotBeNull();
            parametersOfshowtime.Length.ShouldBe(1);
            methodshowtimePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (showtime) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_showtime_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var seconds = CreateType<int>();
            var methodshowtimePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfshowtime = { seconds };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<adminqueue, string>(_adminqueueInstance, Methodshowtime, parametersOfshowtime, methodshowtimePrametersTypes);

            // Assert
            parametersOfshowtime.ShouldNotBeNull();
            parametersOfshowtime.Length.ShouldBe(1);
            methodshowtimePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (showtime) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_showtime_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodshowtimePrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminqueueInstance, Methodshowtime, Fixture, methodshowtimePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodshowtimePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (showtime) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_showtime_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodshowtimePrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminqueueInstance, Methodshowtime, Fixture, methodshowtimePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodshowtimePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (showtime) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_showtime_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodshowtime, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_adminqueueInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (showtime) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_showtime_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodshowtime, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GvItems_RowDataBound) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adminqueue_GvItems_RowDataBound_Method_Call_Internally(Type[] types)
        {
            var methodGvItems_RowDataBoundPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminqueueInstance, MethodGvItems_RowDataBound, Fixture, methodGvItems_RowDataBoundPrametersTypes);
        }

        #endregion

        #region Method Call : (GvItems_RowDataBound) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_GvItems_RowDataBound_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodGvItems_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGvItems_RowDataBound = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGvItems_RowDataBound, methodGvItems_RowDataBoundPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adminqueueInstanceFixture, parametersOfGvItems_RowDataBound);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGvItems_RowDataBound.ShouldNotBeNull();
            parametersOfGvItems_RowDataBound.Length.ShouldBe(2);
            methodGvItems_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodGvItems_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfGvItems_RowDataBound.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GvItems_RowDataBound) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_GvItems_RowDataBound_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodGvItems_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGvItems_RowDataBound = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adminqueueInstance, MethodGvItems_RowDataBound, parametersOfGvItems_RowDataBound, methodGvItems_RowDataBoundPrametersTypes);

            // Assert
            parametersOfGvItems_RowDataBound.ShouldNotBeNull();
            parametersOfGvItems_RowDataBound.Length.ShouldBe(2);
            methodGvItems_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodGvItems_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfGvItems_RowDataBound.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GvItems_RowDataBound) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_GvItems_RowDataBound_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGvItems_RowDataBound, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GvItems_RowDataBound) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_GvItems_RowDataBound_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGvItems_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminqueueInstance, MethodGvItems_RowDataBound, Fixture, methodGvItems_RowDataBoundPrametersTypes);

            // Assert
            methodGvItems_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GvItems_RowDataBound) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminqueue_GvItems_RowDataBound_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGvItems_RowDataBound, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adminqueueInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}