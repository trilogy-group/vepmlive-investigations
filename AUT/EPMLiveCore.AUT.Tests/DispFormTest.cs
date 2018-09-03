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
using System.Web.UI;
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
using EPMLiveCore.API.ProjectArchiver;
using EPMLiveCore.ListDefinitions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using DispForm = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.DispForm" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DispFormTest : AbstractBaseSetupTypedTest<DispForm>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DispForm) Initializer

        private const string MethodRender = "Render";
        private const string MethodRegisterArchiveRestoreFormButtons = "RegisterArchiveRestoreFormButtons";
        private const string MethodAllowArchiveRestoreProjectForList = "AllowArchiveRestoreProjectForList";
        private const string MethodOnPreRender = "OnPreRender";
        private const string FieldListFormEditActionsGroupId = "ListFormEditActionsGroupId";
        private const string FieldArchiveProjectActionId = "ArchiveProjectActionId";
        private const string FieldArchiveProjectActionTitle = "ArchiveProjectActionTitle";
        private const string FieldRestoreProjectActionId = "RestoreProjectActionId";
        private const string FieldRestoreProjectActionTitle = "RestoreProjectActionTitle";
        private const string FieldArchivedColumn = "ArchivedColumn";
        private Type _dispFormInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DispForm _dispFormInstance;
        private DispForm _dispFormInstanceFixture;

        #region General Initializer : Class (DispForm) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DispForm" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dispFormInstanceType = typeof(DispForm);
            _dispFormInstanceFixture = Create(true);
            _dispFormInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="DispForm" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_DispForm_Is_Instance_Present_Test()
        {
            // Assert
            _dispFormInstanceType.ShouldNotBeNull();
            _dispFormInstance.ShouldNotBeNull();
            _dispFormInstanceFixture.ShouldNotBeNull();
            _dispFormInstance.ShouldBeAssignableTo<DispForm>();
            _dispFormInstanceFixture.ShouldBeAssignableTo<DispForm>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DispForm) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_DispForm_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DispForm instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dispFormInstanceType.ShouldNotBeNull();
            _dispFormInstance.ShouldNotBeNull();
            _dispFormInstanceFixture.ShouldNotBeNull();
            _dispFormInstance.ShouldBeAssignableTo<DispForm>();
            _dispFormInstanceFixture.ShouldBeAssignableTo<DispForm>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (Render) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DispForm_Render_Method_Call_Internally(Type[] types)
        {
            var methodRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dispFormInstance, MethodRender, Fixture, methodRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DispForm_Render_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            var methodRenderPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRender = { writer };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRender, methodRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_dispFormInstanceFixture, parametersOfRender);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRender.ShouldNotBeNull();
            parametersOfRender.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(parametersOfRender.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DispForm_Render_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            var methodRenderPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRender = { writer };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_dispFormInstance, MethodRender, parametersOfRender, methodRenderPrametersTypes);

            // Assert
            parametersOfRender.ShouldNotBeNull();
            parametersOfRender.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(parametersOfRender.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DispForm_Render_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRender, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DispForm_Render_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dispFormInstance, MethodRender, Fixture, methodRenderPrametersTypes);

            // Assert
            methodRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DispForm_Render_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_dispFormInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterArchiveRestoreFormButtons) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DispForm_RegisterArchiveRestoreFormButtons_Method_Call_Internally(Type[] types)
        {
            var methodRegisterArchiveRestoreFormButtonsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dispFormInstance, MethodRegisterArchiveRestoreFormButtons, Fixture, methodRegisterArchiveRestoreFormButtonsPrametersTypes);
        }

        #endregion

        #region Method Call : (RegisterArchiveRestoreFormButtons) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DispForm_RegisterArchiveRestoreFormButtons_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<SPList>();
            var item = CreateType<SPListItem>();
            var ribbon = CreateType<SPRibbon>();
            var methodRegisterArchiveRestoreFormButtonsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList), typeof(SPListItem), typeof(SPRibbon) };
            object[] parametersOfRegisterArchiveRestoreFormButtons = { web, list, item, ribbon };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_dispFormInstance, MethodRegisterArchiveRestoreFormButtons, parametersOfRegisterArchiveRestoreFormButtons, methodRegisterArchiveRestoreFormButtonsPrametersTypes);

            // Assert
            parametersOfRegisterArchiveRestoreFormButtons.ShouldNotBeNull();
            parametersOfRegisterArchiveRestoreFormButtons.Length.ShouldBe(4);
            methodRegisterArchiveRestoreFormButtonsPrametersTypes.Length.ShouldBe(4);
            methodRegisterArchiveRestoreFormButtonsPrametersTypes.Length.ShouldBe(parametersOfRegisterArchiveRestoreFormButtons.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterArchiveRestoreFormButtons) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DispForm_RegisterArchiveRestoreFormButtons_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRegisterArchiveRestoreFormButtonsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList), typeof(SPListItem), typeof(SPRibbon) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dispFormInstance, MethodRegisterArchiveRestoreFormButtons, Fixture, methodRegisterArchiveRestoreFormButtonsPrametersTypes);

            // Assert
            methodRegisterArchiveRestoreFormButtonsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AllowArchiveRestoreProjectForList) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DispForm_AllowArchiveRestoreProjectForList_Method_Call_Internally(Type[] types)
        {
            var methodAllowArchiveRestoreProjectForListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dispFormInstance, MethodAllowArchiveRestoreProjectForList, Fixture, methodAllowArchiveRestoreProjectForListPrametersTypes);
        }

        #endregion

        #region Method Call : (AllowArchiveRestoreProjectForList) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DispForm_AllowArchiveRestoreProjectForList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodAllowArchiveRestoreProjectForListPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfAllowArchiveRestoreProjectForList = { list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DispForm, bool>(_dispFormInstance, MethodAllowArchiveRestoreProjectForList, parametersOfAllowArchiveRestoreProjectForList, methodAllowArchiveRestoreProjectForListPrametersTypes);

            // Assert
            parametersOfAllowArchiveRestoreProjectForList.ShouldNotBeNull();
            parametersOfAllowArchiveRestoreProjectForList.Length.ShouldBe(1);
            methodAllowArchiveRestoreProjectForListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AllowArchiveRestoreProjectForList) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DispForm_AllowArchiveRestoreProjectForList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAllowArchiveRestoreProjectForListPrametersTypes = new Type[] { typeof(SPList) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dispFormInstance, MethodAllowArchiveRestoreProjectForList, Fixture, methodAllowArchiveRestoreProjectForListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAllowArchiveRestoreProjectForListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DispForm_OnPreRender_Method_Call_Internally(Type[] types)
        {
            var methodOnPreRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dispFormInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DispForm_OnPreRender_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<System.EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(System.EventArgs) };
            object[] parametersOfOnPreRender = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnPreRender, methodOnPreRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_dispFormInstanceFixture, parametersOfOnPreRender);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnPreRender.ShouldNotBeNull();
            parametersOfOnPreRender.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(parametersOfOnPreRender.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DispForm_OnPreRender_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<System.EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(System.EventArgs) };
            object[] parametersOfOnPreRender = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_dispFormInstance, MethodOnPreRender, parametersOfOnPreRender, methodOnPreRenderPrametersTypes);

            // Assert
            parametersOfOnPreRender.ShouldNotBeNull();
            parametersOfOnPreRender.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(parametersOfOnPreRender.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DispForm_OnPreRender_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DispForm_OnPreRender_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(System.EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dispFormInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);

            // Assert
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DispForm_OnPreRender_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_dispFormInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}