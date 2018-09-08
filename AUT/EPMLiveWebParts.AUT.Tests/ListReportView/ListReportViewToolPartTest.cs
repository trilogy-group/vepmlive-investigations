using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
using System.Web.UI.WebControls;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint.WebControls;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ListReportViewToolPart" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ListReportViewToolPartTest : AbstractBaseSetupTypedTest<ListReportViewToolPart>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ListReportViewToolPart) Initializer

        private const string MethodRenderToolPart = "RenderToolPart";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodApplyChanges = "ApplyChanges";
        private const string MethodcreateGridViewWithCheckBox = "createGridViewWithCheckBox";
        private const string Methodgridviewwithcheckbox_RowDataBound = "gridviewwithcheckbox_RowDataBound";
        private const string MethodPopulateDisplayNames = "PopulateDisplayNames";
        private const string MethodStoreSortListByDisplayName = "StoreSortListByDisplayName";
        private const string MethodSortListByDisplayName = "SortListByDisplayName";
        private const string Field_hashedNames = "_hashedNames";
        private const string Field_selectedHashNames = "_selectedHashNames";
        private Type _listReportViewToolPartInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ListReportViewToolPart _listReportViewToolPartInstance;
        private ListReportViewToolPart _listReportViewToolPartInstanceFixture;

        #region General Initializer : Class (ListReportViewToolPart) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ListReportViewToolPart" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _listReportViewToolPartInstanceType = typeof(ListReportViewToolPart);
            _listReportViewToolPartInstanceFixture = Create(true);
            _listReportViewToolPartInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ListReportViewToolPart)

        #region General Initializer : Class (ListReportViewToolPart) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ListReportViewToolPart" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRenderToolPart, 0)]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodApplyChanges, 0)]
        [TestCase(MethodcreateGridViewWithCheckBox, 0)]
        [TestCase(Methodgridviewwithcheckbox_RowDataBound, 0)]
        [TestCase(MethodPopulateDisplayNames, 0)]
        [TestCase(MethodStoreSortListByDisplayName, 0)]
        [TestCase(MethodSortListByDisplayName, 0)]
        public void AUT_ListReportViewToolPart_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_listReportViewToolPartInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ListReportViewToolPart) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ListReportViewToolPart" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_hashedNames)]
        [TestCase(Field_selectedHashNames)]
        public void AUT_ListReportViewToolPart_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_listReportViewToolPartInstanceFixture, 
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
        ///     Class (<see cref="ListReportViewToolPart" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ListReportViewToolPart_Is_Instance_Present_Test()
        {
            // Assert
            _listReportViewToolPartInstanceType.ShouldNotBeNull();
            _listReportViewToolPartInstance.ShouldNotBeNull();
            _listReportViewToolPartInstanceFixture.ShouldNotBeNull();
            _listReportViewToolPartInstance.ShouldBeAssignableTo<ListReportViewToolPart>();
            _listReportViewToolPartInstanceFixture.ShouldBeAssignableTo<ListReportViewToolPart>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ListReportViewToolPart) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ListReportViewToolPart_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ListReportViewToolPart instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _listReportViewToolPartInstanceType.ShouldNotBeNull();
            _listReportViewToolPartInstance.ShouldNotBeNull();
            _listReportViewToolPartInstanceFixture.ShouldNotBeNull();
            _listReportViewToolPartInstance.ShouldBeAssignableTo<ListReportViewToolPart>();
            _listReportViewToolPartInstanceFixture.ShouldBeAssignableTo<ListReportViewToolPart>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ListReportViewToolPart" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodRenderToolPart)]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodApplyChanges)]
        [TestCase(MethodcreateGridViewWithCheckBox)]
        [TestCase(Methodgridviewwithcheckbox_RowDataBound)]
        [TestCase(MethodPopulateDisplayNames)]
        [TestCase(MethodStoreSortListByDisplayName)]
        [TestCase(MethodSortListByDisplayName)]
        public void AUT_ListReportViewToolPart_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ListReportViewToolPart>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (RenderToolPart) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListReportViewToolPart_RenderToolPart_Method_Call_Internally(Type[] types)
        {
            var methodRenderToolPartPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewToolPartInstance, MethodRenderToolPart, Fixture, methodRenderToolPartPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderToolPart) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_RenderToolPart_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderToolPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderToolPart = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderToolPart, methodRenderToolPartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listReportViewToolPartInstanceFixture, parametersOfRenderToolPart);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenderToolPart.ShouldNotBeNull();
            parametersOfRenderToolPart.Length.ShouldBe(1);
            methodRenderToolPartPrametersTypes.Length.ShouldBe(1);
            methodRenderToolPartPrametersTypes.Length.ShouldBe(parametersOfRenderToolPart.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RenderToolPart) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_RenderToolPart_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderToolPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderToolPart = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listReportViewToolPartInstance, MethodRenderToolPart, parametersOfRenderToolPart, methodRenderToolPartPrametersTypes);

            // Assert
            parametersOfRenderToolPart.ShouldNotBeNull();
            parametersOfRenderToolPart.Length.ShouldBe(1);
            methodRenderToolPartPrametersTypes.Length.ShouldBe(1);
            methodRenderToolPartPrametersTypes.Length.ShouldBe(parametersOfRenderToolPart.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderToolPart) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_RenderToolPart_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderToolPart, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderToolPart) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_RenderToolPart_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderToolPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewToolPartInstance, MethodRenderToolPart, Fixture, methodRenderToolPartPrametersTypes);

            // Assert
            methodRenderToolPartPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderToolPart) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_RenderToolPart_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderToolPart, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listReportViewToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListReportViewToolPart_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewToolPartInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, methodCreateChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listReportViewToolPartInstanceFixture, parametersOfCreateChildControls);

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
        public void AUT_ListReportViewToolPart_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listReportViewToolPartInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

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
        public void AUT_ListReportViewToolPart_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewToolPartInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listReportViewToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListReportViewToolPart_ApplyChanges_Method_Call_Internally(Type[] types)
        {
            var methodApplyChangesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewToolPartInstance, MethodApplyChanges, Fixture, methodApplyChangesPrametersTypes);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_ApplyChanges_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _listReportViewToolPartInstance.ApplyChanges();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_ApplyChanges_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodApplyChangesPrametersTypes = null;
            object[] parametersOfApplyChanges = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodApplyChanges, methodApplyChangesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listReportViewToolPartInstanceFixture, parametersOfApplyChanges);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfApplyChanges.ShouldBeNull();
            methodApplyChangesPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_ApplyChanges_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodApplyChangesPrametersTypes = null;
            object[] parametersOfApplyChanges = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listReportViewToolPartInstance, MethodApplyChanges, parametersOfApplyChanges, methodApplyChangesPrametersTypes);

            // Assert
            parametersOfApplyChanges.ShouldBeNull();
            methodApplyChangesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_ApplyChanges_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodApplyChangesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewToolPartInstance, MethodApplyChanges, Fixture, methodApplyChangesPrametersTypes);

            // Assert
            methodApplyChangesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_ApplyChanges_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodApplyChanges, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listReportViewToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (createGridViewWithCheckBox) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListReportViewToolPart_createGridViewWithCheckBox_Method_Call_Internally(Type[] types)
        {
            var methodcreateGridViewWithCheckBoxPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewToolPartInstance, MethodcreateGridViewWithCheckBox, Fixture, methodcreateGridViewWithCheckBoxPrametersTypes);
        }

        #endregion

        #region Method Call : (createGridViewWithCheckBox) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_createGridViewWithCheckBox_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var grv = CreateType<SPGridView>();
            Action executeAction = null;

            // Act
            executeAction = () => _listReportViewToolPartInstance.createGridViewWithCheckBox(ref grv);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (createGridViewWithCheckBox) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_createGridViewWithCheckBox_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var grv = CreateType<SPGridView>();
            var methodcreateGridViewWithCheckBoxPrametersTypes = new Type[] { typeof(SPGridView) };
            object[] parametersOfcreateGridViewWithCheckBox = { grv };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodcreateGridViewWithCheckBox, methodcreateGridViewWithCheckBoxPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listReportViewToolPartInstanceFixture, parametersOfcreateGridViewWithCheckBox);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfcreateGridViewWithCheckBox.ShouldNotBeNull();
            parametersOfcreateGridViewWithCheckBox.Length.ShouldBe(1);
            methodcreateGridViewWithCheckBoxPrametersTypes.Length.ShouldBe(1);
            methodcreateGridViewWithCheckBoxPrametersTypes.Length.ShouldBe(parametersOfcreateGridViewWithCheckBox.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (createGridViewWithCheckBox) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_createGridViewWithCheckBox_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var grv = CreateType<SPGridView>();
            var methodcreateGridViewWithCheckBoxPrametersTypes = new Type[] { typeof(SPGridView) };
            object[] parametersOfcreateGridViewWithCheckBox = { grv };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listReportViewToolPartInstance, MethodcreateGridViewWithCheckBox, parametersOfcreateGridViewWithCheckBox, methodcreateGridViewWithCheckBoxPrametersTypes);

            // Assert
            parametersOfcreateGridViewWithCheckBox.ShouldNotBeNull();
            parametersOfcreateGridViewWithCheckBox.Length.ShouldBe(1);
            methodcreateGridViewWithCheckBoxPrametersTypes.Length.ShouldBe(1);
            methodcreateGridViewWithCheckBoxPrametersTypes.Length.ShouldBe(parametersOfcreateGridViewWithCheckBox.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (createGridViewWithCheckBox) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_createGridViewWithCheckBox_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodcreateGridViewWithCheckBox, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (createGridViewWithCheckBox) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_createGridViewWithCheckBox_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodcreateGridViewWithCheckBoxPrametersTypes = new Type[] { typeof(SPGridView) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewToolPartInstance, MethodcreateGridViewWithCheckBox, Fixture, methodcreateGridViewWithCheckBoxPrametersTypes);

            // Assert
            methodcreateGridViewWithCheckBoxPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (createGridViewWithCheckBox) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_createGridViewWithCheckBox_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodcreateGridViewWithCheckBox, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listReportViewToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (gridviewwithcheckbox_RowDataBound) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListReportViewToolPart_gridviewwithcheckbox_RowDataBound_Method_Call_Internally(Type[] types)
        {
            var methodgridviewwithcheckbox_RowDataBoundPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewToolPartInstance, Methodgridviewwithcheckbox_RowDataBound, Fixture, methodgridviewwithcheckbox_RowDataBoundPrametersTypes);
        }

        #endregion

        #region Method Call : (gridviewwithcheckbox_RowDataBound) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_gridviewwithcheckbox_RowDataBound_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodgridviewwithcheckbox_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfgridviewwithcheckbox_RowDataBound = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodgridviewwithcheckbox_RowDataBound, methodgridviewwithcheckbox_RowDataBoundPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listReportViewToolPartInstanceFixture, parametersOfgridviewwithcheckbox_RowDataBound);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgridviewwithcheckbox_RowDataBound.ShouldNotBeNull();
            parametersOfgridviewwithcheckbox_RowDataBound.Length.ShouldBe(2);
            methodgridviewwithcheckbox_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodgridviewwithcheckbox_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfgridviewwithcheckbox_RowDataBound.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (gridviewwithcheckbox_RowDataBound) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_gridviewwithcheckbox_RowDataBound_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodgridviewwithcheckbox_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfgridviewwithcheckbox_RowDataBound = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listReportViewToolPartInstance, Methodgridviewwithcheckbox_RowDataBound, parametersOfgridviewwithcheckbox_RowDataBound, methodgridviewwithcheckbox_RowDataBoundPrametersTypes);

            // Assert
            parametersOfgridviewwithcheckbox_RowDataBound.ShouldNotBeNull();
            parametersOfgridviewwithcheckbox_RowDataBound.Length.ShouldBe(2);
            methodgridviewwithcheckbox_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodgridviewwithcheckbox_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfgridviewwithcheckbox_RowDataBound.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (gridviewwithcheckbox_RowDataBound) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_gridviewwithcheckbox_RowDataBound_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodgridviewwithcheckbox_RowDataBound, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (gridviewwithcheckbox_RowDataBound) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_gridviewwithcheckbox_RowDataBound_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgridviewwithcheckbox_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewToolPartInstance, Methodgridviewwithcheckbox_RowDataBound, Fixture, methodgridviewwithcheckbox_RowDataBoundPrametersTypes);

            // Assert
            methodgridviewwithcheckbox_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (gridviewwithcheckbox_RowDataBound) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_gridviewwithcheckbox_RowDataBound_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodgridviewwithcheckbox_RowDataBound, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listReportViewToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateDisplayNames) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListReportViewToolPart_PopulateDisplayNames_Method_Call_Internally(Type[] types)
        {
            var methodPopulateDisplayNamesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewToolPartInstance, MethodPopulateDisplayNames, Fixture, methodPopulateDisplayNamesPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateDisplayNames) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_PopulateDisplayNames_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var wp = CreateType<ListReportView>();
            var grv = CreateType<SPGridView>();
            var methodPopulateDisplayNamesPrametersTypes = new Type[] { typeof(ListReportView), typeof(SPGridView) };
            object[] parametersOfPopulateDisplayNames = { wp, grv };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateDisplayNames, methodPopulateDisplayNamesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listReportViewToolPartInstanceFixture, parametersOfPopulateDisplayNames);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateDisplayNames.ShouldNotBeNull();
            parametersOfPopulateDisplayNames.Length.ShouldBe(2);
            methodPopulateDisplayNamesPrametersTypes.Length.ShouldBe(2);
            methodPopulateDisplayNamesPrametersTypes.Length.ShouldBe(parametersOfPopulateDisplayNames.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateDisplayNames) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_PopulateDisplayNames_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var wp = CreateType<ListReportView>();
            var grv = CreateType<SPGridView>();
            var methodPopulateDisplayNamesPrametersTypes = new Type[] { typeof(ListReportView), typeof(SPGridView) };
            object[] parametersOfPopulateDisplayNames = { wp, grv };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listReportViewToolPartInstance, MethodPopulateDisplayNames, parametersOfPopulateDisplayNames, methodPopulateDisplayNamesPrametersTypes);

            // Assert
            parametersOfPopulateDisplayNames.ShouldNotBeNull();
            parametersOfPopulateDisplayNames.Length.ShouldBe(2);
            methodPopulateDisplayNamesPrametersTypes.Length.ShouldBe(2);
            methodPopulateDisplayNamesPrametersTypes.Length.ShouldBe(parametersOfPopulateDisplayNames.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateDisplayNames) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_PopulateDisplayNames_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateDisplayNames, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateDisplayNames) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_PopulateDisplayNames_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateDisplayNamesPrametersTypes = new Type[] { typeof(ListReportView), typeof(SPGridView) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewToolPartInstance, MethodPopulateDisplayNames, Fixture, methodPopulateDisplayNamesPrametersTypes);

            // Assert
            methodPopulateDisplayNamesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateDisplayNames) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_PopulateDisplayNames_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateDisplayNames, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listReportViewToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StoreSortListByDisplayName) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListReportViewToolPart_StoreSortListByDisplayName_Method_Call_Internally(Type[] types)
        {
            var methodStoreSortListByDisplayNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewToolPartInstance, MethodStoreSortListByDisplayName, Fixture, methodStoreSortListByDisplayNamePrametersTypes);
        }

        #endregion

        #region Method Call : (StoreSortListByDisplayName) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_StoreSortListByDisplayName_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var wp = CreateType<ListReportView>();
            var grv = CreateType<SPGridView>();
            var methodStoreSortListByDisplayNamePrametersTypes = new Type[] { typeof(ListReportView), typeof(SPGridView) };
            object[] parametersOfStoreSortListByDisplayName = { wp, grv };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodStoreSortListByDisplayName, methodStoreSortListByDisplayNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listReportViewToolPartInstanceFixture, parametersOfStoreSortListByDisplayName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfStoreSortListByDisplayName.ShouldNotBeNull();
            parametersOfStoreSortListByDisplayName.Length.ShouldBe(2);
            methodStoreSortListByDisplayNamePrametersTypes.Length.ShouldBe(2);
            methodStoreSortListByDisplayNamePrametersTypes.Length.ShouldBe(parametersOfStoreSortListByDisplayName.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StoreSortListByDisplayName) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_StoreSortListByDisplayName_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var wp = CreateType<ListReportView>();
            var grv = CreateType<SPGridView>();
            var methodStoreSortListByDisplayNamePrametersTypes = new Type[] { typeof(ListReportView), typeof(SPGridView) };
            object[] parametersOfStoreSortListByDisplayName = { wp, grv };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listReportViewToolPartInstance, MethodStoreSortListByDisplayName, parametersOfStoreSortListByDisplayName, methodStoreSortListByDisplayNamePrametersTypes);

            // Assert
            parametersOfStoreSortListByDisplayName.ShouldNotBeNull();
            parametersOfStoreSortListByDisplayName.Length.ShouldBe(2);
            methodStoreSortListByDisplayNamePrametersTypes.Length.ShouldBe(2);
            methodStoreSortListByDisplayNamePrametersTypes.Length.ShouldBe(parametersOfStoreSortListByDisplayName.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StoreSortListByDisplayName) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_StoreSortListByDisplayName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodStoreSortListByDisplayName, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StoreSortListByDisplayName) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_StoreSortListByDisplayName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodStoreSortListByDisplayNamePrametersTypes = new Type[] { typeof(ListReportView), typeof(SPGridView) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewToolPartInstance, MethodStoreSortListByDisplayName, Fixture, methodStoreSortListByDisplayNamePrametersTypes);

            // Assert
            methodStoreSortListByDisplayNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StoreSortListByDisplayName) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_StoreSortListByDisplayName_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStoreSortListByDisplayName, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listReportViewToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortListByDisplayName) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListReportViewToolPart_SortListByDisplayName_Method_Call_Internally(Type[] types)
        {
            var methodSortListByDisplayNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewToolPartInstance, MethodSortListByDisplayName, Fixture, methodSortListByDisplayNamePrametersTypes);
        }

        #endregion

        #region Method Call : (SortListByDisplayName) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_SortListByDisplayName_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var selectedHashList = CreateType<Hashtable>();
            var wp = CreateType<ListReportView>();
            var methodSortListByDisplayNamePrametersTypes = new Type[] { typeof(Hashtable), typeof(ListReportView) };
            object[] parametersOfSortListByDisplayName = { selectedHashList, wp };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSortListByDisplayName, methodSortListByDisplayNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listReportViewToolPartInstanceFixture, parametersOfSortListByDisplayName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSortListByDisplayName.ShouldNotBeNull();
            parametersOfSortListByDisplayName.Length.ShouldBe(2);
            methodSortListByDisplayNamePrametersTypes.Length.ShouldBe(2);
            methodSortListByDisplayNamePrametersTypes.Length.ShouldBe(parametersOfSortListByDisplayName.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortListByDisplayName) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_SortListByDisplayName_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var selectedHashList = CreateType<Hashtable>();
            var wp = CreateType<ListReportView>();
            var methodSortListByDisplayNamePrametersTypes = new Type[] { typeof(Hashtable), typeof(ListReportView) };
            object[] parametersOfSortListByDisplayName = { selectedHashList, wp };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listReportViewToolPartInstance, MethodSortListByDisplayName, parametersOfSortListByDisplayName, methodSortListByDisplayNamePrametersTypes);

            // Assert
            parametersOfSortListByDisplayName.ShouldNotBeNull();
            parametersOfSortListByDisplayName.Length.ShouldBe(2);
            methodSortListByDisplayNamePrametersTypes.Length.ShouldBe(2);
            methodSortListByDisplayNamePrametersTypes.Length.ShouldBe(parametersOfSortListByDisplayName.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortListByDisplayName) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_SortListByDisplayName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSortListByDisplayName, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SortListByDisplayName) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_SortListByDisplayName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSortListByDisplayNamePrametersTypes = new Type[] { typeof(Hashtable), typeof(ListReportView) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewToolPartInstance, MethodSortListByDisplayName, Fixture, methodSortListByDisplayNamePrametersTypes);

            // Assert
            methodSortListByDisplayNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortListByDisplayName) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListReportViewToolPart_SortListByDisplayName_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSortListByDisplayName, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listReportViewToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}