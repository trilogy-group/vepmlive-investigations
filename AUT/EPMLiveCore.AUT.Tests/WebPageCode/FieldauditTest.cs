using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
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
using EPMLiveCore.Infrastructure.Logging;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.WebControls;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;
using EPMLiveCore;
using fieldaudit = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.fieldaudit" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FieldauditTest : AbstractBaseSetupTypedTest<fieldaudit>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (fieldaudit) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodprocessList = "processList";
        private const string MethodprocessWeb = "processWeb";
        private const string FieldGvItems = "GvItems";
        private const string Fielddt = "dt";
        private const string Fieldlists = "lists";
        private const string FieldmainList = "mainList";
        private Type _fieldauditInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private fieldaudit _fieldauditInstance;
        private fieldaudit _fieldauditInstanceFixture;

        #region General Initializer : Class (fieldaudit) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="fieldaudit" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _fieldauditInstanceType = typeof(fieldaudit);
            _fieldauditInstanceFixture = Create(true);
            _fieldauditInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (fieldaudit)

        #region General Initializer : Class (fieldaudit) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="fieldaudit" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodprocessList, 0)]
        [TestCase(MethodprocessWeb, 0)]
        public void AUT_Fieldaudit_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_fieldauditInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (fieldaudit) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="fieldaudit" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldGvItems)]
        [TestCase(Fielddt)]
        [TestCase(Fieldlists)]
        [TestCase(FieldmainList)]
        public void AUT_Fieldaudit_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_fieldauditInstanceFixture, 
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
        ///     Class (<see cref="fieldaudit" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Fieldaudit_Is_Instance_Present_Test()
        {
            // Assert
            _fieldauditInstanceType.ShouldNotBeNull();
            _fieldauditInstance.ShouldNotBeNull();
            _fieldauditInstanceFixture.ShouldNotBeNull();
            _fieldauditInstance.ShouldBeAssignableTo<fieldaudit>();
            _fieldauditInstanceFixture.ShouldBeAssignableTo<fieldaudit>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (fieldaudit) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_fieldaudit_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            fieldaudit instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _fieldauditInstanceType.ShouldNotBeNull();
            _fieldauditInstance.ShouldNotBeNull();
            _fieldauditInstanceFixture.ShouldNotBeNull();
            _fieldauditInstance.ShouldBeAssignableTo<fieldaudit>();
            _fieldauditInstanceFixture.ShouldBeAssignableTo<fieldaudit>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="fieldaudit" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodprocessList)]
        [TestCase(MethodprocessWeb)]
        public void AUT_Fieldaudit_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<fieldaudit>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Fieldaudit_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_fieldauditInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Fieldaudit_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_fieldauditInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Fieldaudit_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_fieldauditInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Fieldaudit_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Fieldaudit_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_fieldauditInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Fieldaudit_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_fieldauditInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Fieldaudit_processList_Method_Call_Internally(Type[] types)
        {
            var methodprocessListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_fieldauditInstance, MethodprocessList, Fixture, methodprocessListPrametersTypes);
        }

        #endregion

        #region Method Call : (processList) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Fieldaudit_processList_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var listname = CreateType<string>();
            var spaces = CreateType<string>();
            var methodprocessListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfprocessList = { web, listname, spaces };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessList, methodprocessListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_fieldauditInstanceFixture, parametersOfprocessList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessList.ShouldNotBeNull();
            parametersOfprocessList.Length.ShouldBe(3);
            methodprocessListPrametersTypes.Length.ShouldBe(3);
            methodprocessListPrametersTypes.Length.ShouldBe(parametersOfprocessList.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Fieldaudit_processList_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var listname = CreateType<string>();
            var spaces = CreateType<string>();
            var methodprocessListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfprocessList = { web, listname, spaces };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_fieldauditInstance, MethodprocessList, parametersOfprocessList, methodprocessListPrametersTypes);

            // Assert
            parametersOfprocessList.ShouldNotBeNull();
            parametersOfprocessList.Length.ShouldBe(3);
            methodprocessListPrametersTypes.Length.ShouldBe(3);
            methodprocessListPrametersTypes.Length.ShouldBe(parametersOfprocessList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Fieldaudit_processList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessList, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Fieldaudit_processList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_fieldauditInstance, MethodprocessList, Fixture, methodprocessListPrametersTypes);

            // Assert
            methodprocessListPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Fieldaudit_processList_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_fieldauditInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Fieldaudit_processWeb_Method_Call_Internally(Type[] types)
        {
            var methodprocessWebPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_fieldauditInstance, MethodprocessWeb, Fixture, methodprocessWebPrametersTypes);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Fieldaudit_processWeb_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var spaces = CreateType<string>();
            var methodprocessWebPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfprocessWeb = { web, spaces };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessWeb, methodprocessWebPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_fieldauditInstanceFixture, parametersOfprocessWeb);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessWeb.ShouldNotBeNull();
            parametersOfprocessWeb.Length.ShouldBe(2);
            methodprocessWebPrametersTypes.Length.ShouldBe(2);
            methodprocessWebPrametersTypes.Length.ShouldBe(parametersOfprocessWeb.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Fieldaudit_processWeb_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var spaces = CreateType<string>();
            var methodprocessWebPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfprocessWeb = { web, spaces };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_fieldauditInstance, MethodprocessWeb, parametersOfprocessWeb, methodprocessWebPrametersTypes);

            // Assert
            parametersOfprocessWeb.ShouldNotBeNull();
            parametersOfprocessWeb.Length.ShouldBe(2);
            methodprocessWebPrametersTypes.Length.ShouldBe(2);
            methodprocessWebPrametersTypes.Length.ShouldBe(parametersOfprocessWeb.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Fieldaudit_processWeb_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessWeb, 0);
            const int parametersCount = 2;

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
        public void AUT_Fieldaudit_processWeb_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessWebPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_fieldauditInstance, MethodprocessWeb, Fixture, methodprocessWebPrametersTypes);

            // Assert
            methodprocessWebPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Fieldaudit_processWeb_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessWeb, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_fieldauditInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}