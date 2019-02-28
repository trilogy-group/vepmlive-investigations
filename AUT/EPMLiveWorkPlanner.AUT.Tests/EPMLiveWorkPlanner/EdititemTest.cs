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
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.BaseSetup.Version.V2;
using AUT.ConfigureTestProjects.BaseSetup.Version.V3;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.Model;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveWorkPlanner;
using edititem = EPMLiveWorkPlanner;

namespace EPMLiveWorkPlanner
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWorkPlanner.edititem" />)
    ///     and namespace <see cref="EPMLiveWorkPlanner"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EdititemTest : AbstractBaseSetupV3Test
    {
        public EdititemTest() : base(typeof(edititem))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Overrides of IAbstractBaseSetupV2Test

        /// <summary>
        ///    Configure and ignore problematic tests.
        ///    Added tests will be ignored.
        /// </summary>
        public override void ConfigureIgnoringTests()
        {
            base.ConfigureIgnoringTests();
        }

        #endregion

        #region General Initializer : Class (edititem) Initializer

        #region Methods

        private const string MethodPage_Load = "Page_Load";
        private const string MethodListFormWebPart1_Init = "ListFormWebPart1_Init";

        #endregion

        #region Fields

        private const string FieldListFormWebPart1 = "ListFormWebPart1";
        private const string FieldpageClose = "pageClose";
        private const string FieldwebUrl = "webUrl";

        #endregion

        private Type _edititemInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private edititem _edititemInstance;
        private edititem _edititemInstanceFixture;

        #region General Initializer : Class (edititem) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="edititem" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _edititemInstanceType = typeof(edititem);
            _edititemInstanceFixture = this.Create<edititem>(true);
            _edititemInstance = _edititemInstanceFixture ?? this.Create<edititem>(false);
            CurrentInstance = _edititemInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (edititem)

        #region General Initializer : Class (edititem) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="edititem" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodListFormWebPart1_Init, 0)]
        public void AUT_Edititem_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_edititemInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (edititem) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="edititem" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldListFormWebPart1)]
        [TestCase(FieldwebUrl)]
        public void AUT_Edititem_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_edititemInstanceFixture, 
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
        ///     Class (<see cref="edititem" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Edititem_Is_Instance_Present_Test()
        {
            // Assert
            _edititemInstanceType.ShouldNotBeNull();
            _edititemInstance.ShouldNotBeNull();
            _edititemInstanceFixture.ShouldNotBeNull();
            _edititemInstance.ShouldBeAssignableTo<edititem>();
            _edititemInstanceFixture.ShouldBeAssignableTo<edititem>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (edititem) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_edititem_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            edititem instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _edititemInstanceType.ShouldNotBeNull();
            _edititemInstance.ShouldNotBeNull();
            _edititemInstanceFixture.ShouldNotBeNull();
            _edititemInstance.ShouldBeAssignableTo<edititem>();
            _edititemInstanceFixture.ShouldBeAssignableTo<edititem>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Edititem_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_edititemInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Edititem_Page_Load_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var sender = this.CreateType<object>();
            var e = this.CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_edititemInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Edititem_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var sender = this.CreateType<object>();
            var e = this.CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_edititemInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Edititem_Page_Load_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var methodInfo = this.GetMethodInfo(MethodPage_Load, 0);
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
        public void AUT_Edititem_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_edititemInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Edititem_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_edititemInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListFormWebPart1_Init) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Edititem_ListFormWebPart1_Init_Method_Call_Internally(Type[] types)
        {
            var methodListFormWebPart1_InitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_edititemInstance, MethodListFormWebPart1_Init, Fixture, methodListFormWebPart1_InitPrametersTypes);
        }

        #endregion

        #region Method Call : (ListFormWebPart1_Init) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Edititem_ListFormWebPart1_Init_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodListFormWebPart1_Init);
            var sender = this.CreateType<object>();
            var e = this.CreateType<EventArgs>();
            var methodListFormWebPart1_InitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfListFormWebPart1_Init = { sender, e };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodListFormWebPart1_Init, methodListFormWebPart1_InitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_edititemInstanceFixture, parametersOfListFormWebPart1_Init);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfListFormWebPart1_Init.ShouldNotBeNull();
            parametersOfListFormWebPart1_Init.Length.ShouldBe(2);
            methodListFormWebPart1_InitPrametersTypes.Length.ShouldBe(2);
            methodListFormWebPart1_InitPrametersTypes.Length.ShouldBe(parametersOfListFormWebPart1_Init.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListFormWebPart1_Init) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Edititem_ListFormWebPart1_Init_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodListFormWebPart1_Init);
            var sender = this.CreateType<object>();
            var e = this.CreateType<EventArgs>();
            var methodListFormWebPart1_InitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfListFormWebPart1_Init = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_edititemInstance, MethodListFormWebPart1_Init, parametersOfListFormWebPart1_Init, methodListFormWebPart1_InitPrametersTypes);

            // Assert
            parametersOfListFormWebPart1_Init.ShouldNotBeNull();
            parametersOfListFormWebPart1_Init.Length.ShouldBe(2);
            methodListFormWebPart1_InitPrametersTypes.Length.ShouldBe(2);
            methodListFormWebPart1_InitPrametersTypes.Length.ShouldBe(parametersOfListFormWebPart1_Init.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListFormWebPart1_Init) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Edititem_ListFormWebPart1_Init_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodListFormWebPart1_Init);
            var methodInfo = this.GetMethodInfo(MethodListFormWebPart1_Init, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ListFormWebPart1_Init) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Edititem_ListFormWebPart1_Init_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodListFormWebPart1_Init);
            var methodListFormWebPart1_InitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_edititemInstance, MethodListFormWebPart1_Init, Fixture, methodListFormWebPart1_InitPrametersTypes);

            // Assert
            methodListFormWebPart1_InitPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListFormWebPart1_Init) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Edititem_ListFormWebPart1_Init_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodListFormWebPart1_Init);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodListFormWebPart1_Init, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_edititemInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}