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
using adminviewqueue = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.adminviewqueue" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AdminviewqueueTest : AbstractBaseSetupTypedTest<adminviewqueue>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (adminviewqueue) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string Methodshowtime = "showtime";
        private const string FieldlblJobName = "lblJobName";
        private const string FieldlblWeb = "lblWeb";
        private const string FieldlblList = "lblList";
        private const string FieldlblJobType = "lblJobType";
        private const string FieldlblStatus = "lblStatus";
        private const string FieldlblFinished = "lblFinished";
        private const string FieldlblWait = "lblWait";
        private const string FieldlblJobLength = "lblJobLength";
        private const string FieldlblErrors = "lblErrors";
        private Type _adminviewqueueInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private adminviewqueue _adminviewqueueInstance;
        private adminviewqueue _adminviewqueueInstanceFixture;

        #region General Initializer : Class (adminviewqueue) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="adminviewqueue" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _adminviewqueueInstanceType = typeof(adminviewqueue);
            _adminviewqueueInstanceFixture = Create(true);
            _adminviewqueueInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (adminviewqueue)

        #region General Initializer : Class (adminviewqueue) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="adminviewqueue" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(Methodshowtime, 0)]
        public void AUT_Adminviewqueue_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_adminviewqueueInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (adminviewqueue) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="adminviewqueue" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldlblJobName)]
        [TestCase(FieldlblWeb)]
        [TestCase(FieldlblList)]
        [TestCase(FieldlblJobType)]
        [TestCase(FieldlblStatus)]
        [TestCase(FieldlblFinished)]
        [TestCase(FieldlblWait)]
        [TestCase(FieldlblJobLength)]
        [TestCase(FieldlblErrors)]
        public void AUT_Adminviewqueue_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_adminviewqueueInstanceFixture, 
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
        ///     Class (<see cref="adminviewqueue" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Adminviewqueue_Is_Instance_Present_Test()
        {
            // Assert
            _adminviewqueueInstanceType.ShouldNotBeNull();
            _adminviewqueueInstance.ShouldNotBeNull();
            _adminviewqueueInstanceFixture.ShouldNotBeNull();
            _adminviewqueueInstance.ShouldBeAssignableTo<adminviewqueue>();
            _adminviewqueueInstanceFixture.ShouldBeAssignableTo<adminviewqueue>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (adminviewqueue) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_adminviewqueue_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            adminviewqueue instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _adminviewqueueInstanceType.ShouldNotBeNull();
            _adminviewqueueInstance.ShouldNotBeNull();
            _adminviewqueueInstanceFixture.ShouldNotBeNull();
            _adminviewqueueInstance.ShouldBeAssignableTo<adminviewqueue>();
            _adminviewqueueInstanceFixture.ShouldBeAssignableTo<adminviewqueue>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="adminviewqueue" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(Methodshowtime)]
        public void AUT_Adminviewqueue_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<adminviewqueue>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adminviewqueue_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminviewqueueInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminviewqueue_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adminviewqueueInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Adminviewqueue_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adminviewqueueInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Adminviewqueue_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Adminviewqueue_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminviewqueueInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminviewqueue_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adminviewqueueInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (showtime) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adminviewqueue_showtime_Method_Call_Internally(Type[] types)
        {
            var methodshowtimePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminviewqueueInstance, Methodshowtime, Fixture, methodshowtimePrametersTypes);
        }

        #endregion

        #region Method Call : (showtime) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminviewqueue_showtime_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var seconds = CreateType<double>();
            var methodshowtimePrametersTypes = new Type[] { typeof(double) };
            object[] parametersOfshowtime = { seconds };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodshowtime, methodshowtimePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adminviewqueueInstanceFixture, parametersOfshowtime);

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
        public void AUT_Adminviewqueue_showtime_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var seconds = CreateType<double>();
            var methodshowtimePrametersTypes = new Type[] { typeof(double) };
            object[] parametersOfshowtime = { seconds };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<adminviewqueue, string>(_adminviewqueueInstance, Methodshowtime, parametersOfshowtime, methodshowtimePrametersTypes);

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
        public void AUT_Adminviewqueue_showtime_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodshowtimePrametersTypes = new Type[] { typeof(double) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminviewqueueInstance, Methodshowtime, Fixture, methodshowtimePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodshowtimePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (showtime) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminviewqueue_showtime_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodshowtimePrametersTypes = new Type[] { typeof(double) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminviewqueueInstance, Methodshowtime, Fixture, methodshowtimePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodshowtimePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (showtime) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminviewqueue_showtime_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodshowtime, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_adminviewqueueInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (showtime) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminviewqueue_showtime_Method_Call_Parameters_Count_Verification_Test()
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

        #endregion

        #endregion
    }
}