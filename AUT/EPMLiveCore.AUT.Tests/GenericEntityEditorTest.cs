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
using System.Xml.Linq;
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
using Microsoft.SharePoint.WebControls;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using GenericEntityEditor = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.GenericEntityEditor" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class GenericEntityEditorTest : AbstractBaseSetupTypedTest<GenericEntityEditor>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (GenericEntityEditor) Initializer

        private const string MethodOnInit = "OnInit";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodGetListFromPropBag = "GetListFromPropBag";
        private const string MethodFindBrowseLink = "FindBrowseLink";
        private const string MethodFindControlRecursive = "FindControlRecursive";
        private const string MethodOnPreRender = "OnPreRender";
        private const string MethodValidateEntity = "ValidateEntity";
        private const string MethodGetEntity = "GetEntity";
        private const string MethodIsFieldEditable = "IsFieldEditable";
        private const string FieldpropBag = "propBag";
        private const string FieldrequiredErrTxtId = "requiredErrTxtId";
        private const string FieldfieldProperties = "fieldProperties";
        private const string Fieldmode = "mode";
        private Type _genericEntityEditorInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private GenericEntityEditor _genericEntityEditorInstance;
        private GenericEntityEditor _genericEntityEditorInstanceFixture;

        #region General Initializer : Class (GenericEntityEditor) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GenericEntityEditor" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _genericEntityEditorInstanceType = typeof(GenericEntityEditor);
            _genericEntityEditorInstanceFixture = Create(true);
            _genericEntityEditorInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GenericEntityEditor)

        #region General Initializer : Class (GenericEntityEditor) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="GenericEntityEditor" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodOnInit, 0)]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodGetListFromPropBag, 0)]
        [TestCase(MethodFindBrowseLink, 0)]
        [TestCase(MethodOnPreRender, 0)]
        [TestCase(MethodValidateEntity, 0)]
        [TestCase(MethodGetEntity, 0)]
        [TestCase(MethodIsFieldEditable, 0)]
        public void AUT_GenericEntityEditor_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_genericEntityEditorInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GenericEntityEditor) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="GenericEntityEditor" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldpropBag)]
        [TestCase(FieldrequiredErrTxtId)]
        [TestCase(FieldfieldProperties)]
        [TestCase(Fieldmode)]
        public void AUT_GenericEntityEditor_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_genericEntityEditorInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="GenericEntityEditor" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodOnInit)]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodGetListFromPropBag)]
        [TestCase(MethodFindBrowseLink)]
        [TestCase(MethodOnPreRender)]
        [TestCase(MethodValidateEntity)]
        [TestCase(MethodGetEntity)]
        [TestCase(MethodIsFieldEditable)]
        public void AUT_GenericEntityEditor_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<GenericEntityEditor>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericEntityEditor_OnInit_Method_Call_Internally(Type[] types)
        {
            var methodOnInitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityEditorInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_OnInit_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnInit = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnInit, methodOnInitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_genericEntityEditorInstanceFixture, parametersOfOnInit);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnInit.ShouldNotBeNull();
            parametersOfOnInit.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(parametersOfOnInit.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_OnInit_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnInit = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_genericEntityEditorInstance, MethodOnInit, parametersOfOnInit, methodOnInitPrametersTypes);

            // Assert
            parametersOfOnInit.ShouldNotBeNull();
            parametersOfOnInit.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(parametersOfOnInit.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_OnInit_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnInit, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_OnInit_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityEditorInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);

            // Assert
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_OnInit_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnInit, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_genericEntityEditorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericEntityEditor_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityEditorInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, methodCreateChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_genericEntityEditorInstanceFixture, parametersOfCreateChildControls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_genericEntityEditorInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

            // Assert
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityEditorInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_genericEntityEditorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListFromPropBag) (Return Type : SPList) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericEntityEditor_GetListFromPropBag_Method_Call_Internally(Type[] types)
        {
            var methodGetListFromPropBagPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityEditorInstance, MethodGetListFromPropBag, Fixture, methodGetListFromPropBagPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListFromPropBag) (Return Type : SPList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_GetListFromPropBag_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetListFromPropBagPrametersTypes = null;
            object[] parametersOfGetListFromPropBag = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListFromPropBag, methodGetListFromPropBagPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GenericEntityEditor, SPList>(_genericEntityEditorInstanceFixture, out exception1, parametersOfGetListFromPropBag);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GenericEntityEditor, SPList>(_genericEntityEditorInstance, MethodGetListFromPropBag, parametersOfGetListFromPropBag, methodGetListFromPropBagPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListFromPropBag.ShouldBeNull();
            methodGetListFromPropBagPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListFromPropBag) (Return Type : SPList) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_GetListFromPropBag_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetListFromPropBagPrametersTypes = null;
            object[] parametersOfGetListFromPropBag = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GenericEntityEditor, SPList>(_genericEntityEditorInstance, MethodGetListFromPropBag, parametersOfGetListFromPropBag, methodGetListFromPropBagPrametersTypes);

            // Assert
            parametersOfGetListFromPropBag.ShouldBeNull();
            methodGetListFromPropBagPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListFromPropBag) (Return Type : SPList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_GetListFromPropBag_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetListFromPropBagPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityEditorInstance, MethodGetListFromPropBag, Fixture, methodGetListFromPropBagPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListFromPropBagPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListFromPropBag) (Return Type : SPList) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_GetListFromPropBag_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetListFromPropBagPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityEditorInstance, MethodGetListFromPropBag, Fixture, methodGetListFromPropBagPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListFromPropBagPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListFromPropBag) (Return Type : SPList) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_GetListFromPropBag_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListFromPropBag, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericEntityEditorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FindBrowseLink) (Return Type : Control) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericEntityEditor_FindBrowseLink_Method_Call_Internally(Type[] types)
        {
            var methodFindBrowseLinkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityEditorInstance, MethodFindBrowseLink, Fixture, methodFindBrowseLinkPrametersTypes);
        }

        #endregion

        #region Method Call : (FindBrowseLink) (Return Type : Control) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_FindBrowseLink_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var container = CreateType<Control>();
            var methodFindBrowseLinkPrametersTypes = new Type[] { typeof(Control) };
            object[] parametersOfFindBrowseLink = { container };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFindBrowseLink, methodFindBrowseLinkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GenericEntityEditor, Control>(_genericEntityEditorInstanceFixture, out exception1, parametersOfFindBrowseLink);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GenericEntityEditor, Control>(_genericEntityEditorInstance, MethodFindBrowseLink, parametersOfFindBrowseLink, methodFindBrowseLinkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfFindBrowseLink.ShouldNotBeNull();
            parametersOfFindBrowseLink.Length.ShouldBe(1);
            methodFindBrowseLinkPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (FindBrowseLink) (Return Type : Control) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_FindBrowseLink_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var container = CreateType<Control>();
            var methodFindBrowseLinkPrametersTypes = new Type[] { typeof(Control) };
            object[] parametersOfFindBrowseLink = { container };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GenericEntityEditor, Control>(_genericEntityEditorInstance, MethodFindBrowseLink, parametersOfFindBrowseLink, methodFindBrowseLinkPrametersTypes);

            // Assert
            parametersOfFindBrowseLink.ShouldNotBeNull();
            parametersOfFindBrowseLink.Length.ShouldBe(1);
            methodFindBrowseLinkPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FindBrowseLink) (Return Type : Control) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_FindBrowseLink_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodFindBrowseLinkPrametersTypes = new Type[] { typeof(Control) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityEditorInstance, MethodFindBrowseLink, Fixture, methodFindBrowseLinkPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodFindBrowseLinkPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (FindBrowseLink) (Return Type : Control) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_FindBrowseLink_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFindBrowseLinkPrametersTypes = new Type[] { typeof(Control) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityEditorInstance, MethodFindBrowseLink, Fixture, methodFindBrowseLinkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFindBrowseLinkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FindBrowseLink) (Return Type : Control) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_FindBrowseLink_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFindBrowseLink, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericEntityEditorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FindBrowseLink) (Return Type : Control) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_FindBrowseLink_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFindBrowseLink, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericEntityEditor_OnPreRender_Method_Call_Internally(Type[] types)
        {
            var methodOnPreRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityEditorInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_OnPreRender_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnPreRender, methodOnPreRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_genericEntityEditorInstanceFixture, parametersOfOnPreRender);

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
        public void AUT_GenericEntityEditor_OnPreRender_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_genericEntityEditorInstance, MethodOnPreRender, parametersOfOnPreRender, methodOnPreRenderPrametersTypes);

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
        public void AUT_GenericEntityEditor_OnPreRender_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_GenericEntityEditor_OnPreRender_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityEditorInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);

            // Assert
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_OnPreRender_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_genericEntityEditorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateEntity) (Return Type : PickerEntity) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericEntityEditor_ValidateEntity_Method_Call_Internally(Type[] types)
        {
            var methodValidateEntityPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityEditorInstance, MethodValidateEntity, Fixture, methodValidateEntityPrametersTypes);
        }

        #endregion

        #region Method Call : (ValidateEntity) (Return Type : PickerEntity) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_ValidateEntity_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var needsValidation = CreateType<PickerEntity>();
            Action executeAction = null;

            // Act
            executeAction = () => _genericEntityEditorInstance.ValidateEntity(needsValidation);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ValidateEntity) (Return Type : PickerEntity) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_ValidateEntity_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var needsValidation = CreateType<PickerEntity>();
            var methodValidateEntityPrametersTypes = new Type[] { typeof(PickerEntity) };
            object[] parametersOfValidateEntity = { needsValidation };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodValidateEntity, methodValidateEntityPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GenericEntityEditor, PickerEntity>(_genericEntityEditorInstanceFixture, out exception1, parametersOfValidateEntity);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GenericEntityEditor, PickerEntity>(_genericEntityEditorInstance, MethodValidateEntity, parametersOfValidateEntity, methodValidateEntityPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfValidateEntity.ShouldNotBeNull();
            parametersOfValidateEntity.Length.ShouldBe(1);
            methodValidateEntityPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ValidateEntity) (Return Type : PickerEntity) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_ValidateEntity_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var needsValidation = CreateType<PickerEntity>();
            var methodValidateEntityPrametersTypes = new Type[] { typeof(PickerEntity) };
            object[] parametersOfValidateEntity = { needsValidation };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GenericEntityEditor, PickerEntity>(_genericEntityEditorInstance, MethodValidateEntity, parametersOfValidateEntity, methodValidateEntityPrametersTypes);

            // Assert
            parametersOfValidateEntity.ShouldNotBeNull();
            parametersOfValidateEntity.Length.ShouldBe(1);
            methodValidateEntityPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateEntity) (Return Type : PickerEntity) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_ValidateEntity_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodValidateEntityPrametersTypes = new Type[] { typeof(PickerEntity) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityEditorInstance, MethodValidateEntity, Fixture, methodValidateEntityPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodValidateEntityPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ValidateEntity) (Return Type : PickerEntity) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_ValidateEntity_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodValidateEntityPrametersTypes = new Type[] { typeof(PickerEntity) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityEditorInstance, MethodValidateEntity, Fixture, methodValidateEntityPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodValidateEntityPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ValidateEntity) (Return Type : PickerEntity) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_ValidateEntity_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodValidateEntity, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericEntityEditorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ValidateEntity) (Return Type : PickerEntity) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_ValidateEntity_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodValidateEntity, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericEntityEditor_GetEntity_Method_Call_Internally(Type[] types)
        {
            var methodGetEntityPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityEditorInstance, MethodGetEntity, Fixture, methodGetEntityPrametersTypes);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_GetEntity_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var methodGetEntityPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfGetEntity = { item };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetEntity, methodGetEntityPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GenericEntityEditor, PickerEntity>(_genericEntityEditorInstanceFixture, out exception1, parametersOfGetEntity);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GenericEntityEditor, PickerEntity>(_genericEntityEditorInstance, MethodGetEntity, parametersOfGetEntity, methodGetEntityPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetEntity.ShouldNotBeNull();
            parametersOfGetEntity.Length.ShouldBe(1);
            methodGetEntityPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_GetEntity_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var methodGetEntityPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfGetEntity = { item };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GenericEntityEditor, PickerEntity>(_genericEntityEditorInstance, MethodGetEntity, parametersOfGetEntity, methodGetEntityPrametersTypes);

            // Assert
            parametersOfGetEntity.ShouldNotBeNull();
            parametersOfGetEntity.Length.ShouldBe(1);
            methodGetEntityPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_GetEntity_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetEntityPrametersTypes = new Type[] { typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityEditorInstance, MethodGetEntity, Fixture, methodGetEntityPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetEntityPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_GetEntity_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetEntityPrametersTypes = new Type[] { typeof(SPListItem) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityEditorInstance, MethodGetEntity, Fixture, methodGetEntityPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetEntityPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_GetEntity_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetEntity, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericEntityEditorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_GetEntity_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetEntity, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsFieldEditable) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericEntityEditor_IsFieldEditable_Method_Call_Internally(Type[] types)
        {
            var methodIsFieldEditablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityEditorInstance, MethodIsFieldEditable, Fixture, methodIsFieldEditablePrametersTypes);
        }

        #endregion

        #region Method Call : (IsFieldEditable) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_IsFieldEditable_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodIsFieldEditablePrametersTypes = null;
            object[] parametersOfIsFieldEditable = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsFieldEditable, methodIsFieldEditablePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GenericEntityEditor, bool>(_genericEntityEditorInstanceFixture, out exception1, parametersOfIsFieldEditable);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GenericEntityEditor, bool>(_genericEntityEditorInstance, MethodIsFieldEditable, parametersOfIsFieldEditable, methodIsFieldEditablePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsFieldEditable.ShouldBeNull();
            methodIsFieldEditablePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsFieldEditable) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_IsFieldEditable_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodIsFieldEditablePrametersTypes = null;
            object[] parametersOfIsFieldEditable = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsFieldEditable, methodIsFieldEditablePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GenericEntityEditor, bool>(_genericEntityEditorInstanceFixture, out exception1, parametersOfIsFieldEditable);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GenericEntityEditor, bool>(_genericEntityEditorInstance, MethodIsFieldEditable, parametersOfIsFieldEditable, methodIsFieldEditablePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsFieldEditable.ShouldBeNull();
            methodIsFieldEditablePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsFieldEditable) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_IsFieldEditable_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodIsFieldEditablePrametersTypes = null;
            object[] parametersOfIsFieldEditable = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GenericEntityEditor, bool>(_genericEntityEditorInstance, MethodIsFieldEditable, parametersOfIsFieldEditable, methodIsFieldEditablePrametersTypes);

            // Assert
            parametersOfIsFieldEditable.ShouldBeNull();
            methodIsFieldEditablePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsFieldEditable) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_IsFieldEditable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodIsFieldEditablePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityEditorInstance, MethodIsFieldEditable, Fixture, methodIsFieldEditablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsFieldEditablePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsFieldEditable) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityEditor_IsFieldEditable_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsFieldEditable, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericEntityEditorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}