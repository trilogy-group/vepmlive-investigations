using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
using System.Web.UI.WebControls;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ReportViewer" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ReportViewerTest : AbstractBaseSetupTypedTest<ReportViewer>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportViewer) Initializer

        private const string PropertyIsTopList = "IsTopList";
        private const string PropertyIsIntegratedMode = "IsIntegratedMode";
        private const string Methodddl_DataBound = "ddl_DataBound";
        private const string MethodRenderWebPart = "RenderWebPart";
        private const string MethodBuildTree = "BuildTree";
        private const string MethodloadTree = "loadTree";
        private const string MethodPopulateTree = "PopulateTree";
        private const string MethodGetFileNodeNavigationUrl = "GetFileNodeNavigationUrl";
        private const string MethodGetFileNodeErrorText = "GetFileNodeErrorText";
        private const string MethodAppendToRptList = "AppendToRptList";
        private const string MethodOnInit = "OnInit";
        private const string FieldReportingServicesURL = "ReportingServicesURL";
        private const string FieldIntegrated = "Integrated";
        private const string FieldsbRptList = "sbRptList";
        private const string FieldbIsIntegratedMode = "bIsIntegratedMode";
        private const string FieldtvReportView = "tvReportView";
        private Type _reportViewerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportViewer _reportViewerInstance;
        private ReportViewer _reportViewerInstanceFixture;

        #region General Initializer : Class (ReportViewer) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportViewer" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportViewerInstanceType = typeof(ReportViewer);
            _reportViewerInstanceFixture = Create(true);
            _reportViewerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportViewer)

        #region General Initializer : Class (ReportViewer) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportViewer" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyIsTopList)]
        [TestCase(PropertyIsIntegratedMode)]
        public void AUT_ReportViewer_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportViewerInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportViewer) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportViewer" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldReportingServicesURL)]
        [TestCase(FieldIntegrated)]
        [TestCase(FieldsbRptList)]
        [TestCase(FieldbIsIntegratedMode)]
        [TestCase(FieldtvReportView)]
        public void AUT_ReportViewer_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportViewerInstanceFixture, 
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
        ///     Class (<see cref="ReportViewer" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportViewer_Is_Instance_Present_Test()
        {
            // Assert
            _reportViewerInstanceType.ShouldNotBeNull();
            _reportViewerInstance.ShouldNotBeNull();
            _reportViewerInstanceFixture.ShouldNotBeNull();
            _reportViewerInstance.ShouldBeAssignableTo<ReportViewer>();
            _reportViewerInstanceFixture.ShouldBeAssignableTo<ReportViewer>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportViewer) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportViewer_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportViewer instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportViewerInstanceType.ShouldNotBeNull();
            _reportViewerInstance.ShouldNotBeNull();
            _reportViewerInstanceFixture.ShouldNotBeNull();
            _reportViewerInstance.ShouldBeAssignableTo<ReportViewer>();
            _reportViewerInstanceFixture.ShouldBeAssignableTo<ReportViewer>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportViewer) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyIsTopList)]
        [TestCaseGeneric(typeof(bool) , PropertyIsIntegratedMode)]
        public void AUT_ReportViewer_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportViewer, T>(_reportViewerInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportViewer) => Property (IsIntegratedMode) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportViewer_Public_Class_IsIntegratedMode_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyIsIntegratedMode);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportViewer) => Property (IsTopList) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportViewer_Public_Class_IsTopList_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyIsTopList);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (ddl_DataBound) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportViewer_ddl_DataBound_Method_Call_Internally(Type[] types)
        {
            var methodddl_DataBoundPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerInstance, Methodddl_DataBound, Fixture, methodddl_DataBoundPrametersTypes);
        }

        #endregion

        #region Method Call : (ddl_DataBound) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_ddl_DataBound_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodddl_DataBoundPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfddl_DataBound = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodddl_DataBound, methodddl_DataBoundPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportViewerInstanceFixture, parametersOfddl_DataBound);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfddl_DataBound.ShouldNotBeNull();
            parametersOfddl_DataBound.Length.ShouldBe(2);
            methodddl_DataBoundPrametersTypes.Length.ShouldBe(2);
            methodddl_DataBoundPrametersTypes.Length.ShouldBe(parametersOfddl_DataBound.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddl_DataBound) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_ddl_DataBound_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodddl_DataBoundPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfddl_DataBound = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportViewerInstance, Methodddl_DataBound, parametersOfddl_DataBound, methodddl_DataBoundPrametersTypes);

            // Assert
            parametersOfddl_DataBound.ShouldNotBeNull();
            parametersOfddl_DataBound.Length.ShouldBe(2);
            methodddl_DataBoundPrametersTypes.Length.ShouldBe(2);
            methodddl_DataBoundPrametersTypes.Length.ShouldBe(parametersOfddl_DataBound.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddl_DataBound) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_ddl_DataBound_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodddl_DataBound, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ddl_DataBound) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_ddl_DataBound_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodddl_DataBoundPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerInstance, Methodddl_DataBound, Fixture, methodddl_DataBoundPrametersTypes);

            // Assert
            methodddl_DataBoundPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddl_DataBound) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_ddl_DataBound_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodddl_DataBound, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportViewerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportViewer_RenderWebPart_Method_Call_Internally(Type[] types)
        {
            var methodRenderWebPartPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerInstance, MethodRenderWebPart, Fixture, methodRenderWebPartPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_RenderWebPart_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderWebPart = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderWebPart, methodRenderWebPartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportViewerInstanceFixture, parametersOfRenderWebPart);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenderWebPart.ShouldNotBeNull();
            parametersOfRenderWebPart.Length.ShouldBe(1);
            methodRenderWebPartPrametersTypes.Length.ShouldBe(1);
            methodRenderWebPartPrametersTypes.Length.ShouldBe(parametersOfRenderWebPart.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_RenderWebPart_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderWebPart = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportViewerInstance, MethodRenderWebPart, parametersOfRenderWebPart, methodRenderWebPartPrametersTypes);

            // Assert
            parametersOfRenderWebPart.ShouldNotBeNull();
            parametersOfRenderWebPart.Length.ShouldBe(1);
            methodRenderWebPartPrametersTypes.Length.ShouldBe(1);
            methodRenderWebPartPrametersTypes.Length.ShouldBe(parametersOfRenderWebPart.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_RenderWebPart_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderWebPart, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_RenderWebPart_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerInstance, MethodRenderWebPart, Fixture, methodRenderWebPartPrametersTypes);

            // Assert
            methodRenderWebPartPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_RenderWebPart_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderWebPart, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportViewerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildTree) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportViewer_BuildTree_Method_Call_Internally(Type[] types)
        {
            var methodBuildTreePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerInstance, MethodBuildTree, Fixture, methodBuildTreePrametersTypes);
        }

        #endregion

        #region Method Call : (BuildTree) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_BuildTree_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var catalogItems = CreateType<SSRS2005.CatalogItem[]>();
            var methodBuildTreePrametersTypes = new Type[] { typeof(SSRS2005.CatalogItem[]) };
            object[] parametersOfBuildTree = { catalogItems };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildTree, methodBuildTreePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportViewerInstanceFixture, parametersOfBuildTree);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildTree.ShouldNotBeNull();
            parametersOfBuildTree.Length.ShouldBe(1);
            methodBuildTreePrametersTypes.Length.ShouldBe(1);
            methodBuildTreePrametersTypes.Length.ShouldBe(parametersOfBuildTree.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildTree) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_BuildTree_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var catalogItems = CreateType<SSRS2005.CatalogItem[]>();
            var methodBuildTreePrametersTypes = new Type[] { typeof(SSRS2005.CatalogItem[]) };
            object[] parametersOfBuildTree = { catalogItems };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportViewerInstance, MethodBuildTree, parametersOfBuildTree, methodBuildTreePrametersTypes);

            // Assert
            parametersOfBuildTree.ShouldNotBeNull();
            parametersOfBuildTree.Length.ShouldBe(1);
            methodBuildTreePrametersTypes.Length.ShouldBe(1);
            methodBuildTreePrametersTypes.Length.ShouldBe(parametersOfBuildTree.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildTree) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_BuildTree_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildTree, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildTree) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_BuildTree_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildTreePrametersTypes = new Type[] { typeof(SSRS2005.CatalogItem[]) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerInstance, MethodBuildTree, Fixture, methodBuildTreePrametersTypes);

            // Assert
            methodBuildTreePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildTree) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_BuildTree_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildTree, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportViewerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadTree) (Return Type : TreeNode) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportViewer_loadTree_Method_Call_Internally(Type[] types)
        {
            var methodloadTreePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerInstance, MethodloadTree, Fixture, methodloadTreePrametersTypes);
        }

        #endregion

        #region Method Call : (loadTree) (Return Type : TreeNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_loadTree_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listItems = CreateType<SPListItemCollection>();
            var doc = CreateType<SPDocumentLibrary>();
            var methodloadTreePrametersTypes = new Type[] { typeof(SPListItemCollection), typeof(SPDocumentLibrary) };
            object[] parametersOfloadTree = { listItems, doc };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodloadTree, methodloadTreePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportViewer, TreeNode>(_reportViewerInstanceFixture, out exception1, parametersOfloadTree);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportViewer, TreeNode>(_reportViewerInstance, MethodloadTree, parametersOfloadTree, methodloadTreePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfloadTree.ShouldNotBeNull();
            parametersOfloadTree.Length.ShouldBe(2);
            methodloadTreePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (loadTree) (Return Type : TreeNode) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_loadTree_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listItems = CreateType<SPListItemCollection>();
            var doc = CreateType<SPDocumentLibrary>();
            var methodloadTreePrametersTypes = new Type[] { typeof(SPListItemCollection), typeof(SPDocumentLibrary) };
            object[] parametersOfloadTree = { listItems, doc };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportViewer, TreeNode>(_reportViewerInstance, MethodloadTree, parametersOfloadTree, methodloadTreePrametersTypes);

            // Assert
            parametersOfloadTree.ShouldNotBeNull();
            parametersOfloadTree.Length.ShouldBe(2);
            methodloadTreePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadTree) (Return Type : TreeNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_loadTree_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodloadTreePrametersTypes = new Type[] { typeof(SPListItemCollection), typeof(SPDocumentLibrary) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerInstance, MethodloadTree, Fixture, methodloadTreePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodloadTreePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (loadTree) (Return Type : TreeNode) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_loadTree_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodloadTreePrametersTypes = new Type[] { typeof(SPListItemCollection), typeof(SPDocumentLibrary) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerInstance, MethodloadTree, Fixture, methodloadTreePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodloadTreePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (loadTree) (Return Type : TreeNode) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_loadTree_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodloadTree, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportViewerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (loadTree) (Return Type : TreeNode) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_loadTree_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodloadTree, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateTree) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportViewer_PopulateTree_Method_Call_Internally(Type[] types)
        {
            var methodPopulateTreePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerInstance, MethodPopulateTree, Fixture, methodPopulateTreePrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateTree) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_PopulateTree_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listItems = CreateType<SPListItemCollection>();
            var doc = CreateType<SPDocumentLibrary>();
            var treeNode = CreateType<TreeNode>();
            var methodPopulateTreePrametersTypes = new Type[] { typeof(SPListItemCollection), typeof(SPDocumentLibrary), typeof(TreeNode) };
            object[] parametersOfPopulateTree = { listItems, doc, treeNode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportViewerInstance, MethodPopulateTree, parametersOfPopulateTree, methodPopulateTreePrametersTypes);

            // Assert
            parametersOfPopulateTree.ShouldNotBeNull();
            parametersOfPopulateTree.Length.ShouldBe(3);
            methodPopulateTreePrametersTypes.Length.ShouldBe(3);
            methodPopulateTreePrametersTypes.Length.ShouldBe(parametersOfPopulateTree.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateTree) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_PopulateTree_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateTreePrametersTypes = new Type[] { typeof(SPListItemCollection), typeof(SPDocumentLibrary), typeof(TreeNode) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerInstance, MethodPopulateTree, Fixture, methodPopulateTreePrametersTypes);

            // Assert
            methodPopulateTreePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFileNodeNavigationUrl) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportViewer_GetFileNodeNavigationUrl_Method_Call_Internally(Type[] types)
        {
            var methodGetFileNodeNavigationUrlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerInstance, MethodGetFileNodeNavigationUrl, Fixture, methodGetFileNodeNavigationUrlPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFileNodeNavigationUrl) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_GetFileNodeNavigationUrl_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var methodGetFileNodeNavigationUrlPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfGetFileNodeNavigationUrl = { item };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportViewer, string>(_reportViewerInstance, MethodGetFileNodeNavigationUrl, parametersOfGetFileNodeNavigationUrl, methodGetFileNodeNavigationUrlPrametersTypes);

            // Assert
            parametersOfGetFileNodeNavigationUrl.ShouldNotBeNull();
            parametersOfGetFileNodeNavigationUrl.Length.ShouldBe(1);
            methodGetFileNodeNavigationUrlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFileNodeNavigationUrl) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_GetFileNodeNavigationUrl_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFileNodeNavigationUrlPrametersTypes = new Type[] { typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerInstance, MethodGetFileNodeNavigationUrl, Fixture, methodGetFileNodeNavigationUrlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFileNodeNavigationUrlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFileNodeNavigationUrl) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_GetFileNodeNavigationUrl_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFileNodeNavigationUrlPrametersTypes = new Type[] { typeof(SPListItem) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerInstance, MethodGetFileNodeNavigationUrl, Fixture, methodGetFileNodeNavigationUrlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFileNodeNavigationUrlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFileNodeErrorText) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportViewer_GetFileNodeErrorText_Method_Call_Internally(Type[] types)
        {
            var methodGetFileNodeErrorTextPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerInstance, MethodGetFileNodeErrorText, Fixture, methodGetFileNodeErrorTextPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFileNodeErrorText) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_GetFileNodeErrorText_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var exception = CreateType<Exception>();
            var methodGetFileNodeErrorTextPrametersTypes = new Type[] { typeof(SPListItem), typeof(Exception) };
            object[] parametersOfGetFileNodeErrorText = { item, exception };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportViewer, string>(_reportViewerInstance, MethodGetFileNodeErrorText, parametersOfGetFileNodeErrorText, methodGetFileNodeErrorTextPrametersTypes);

            // Assert
            parametersOfGetFileNodeErrorText.ShouldNotBeNull();
            parametersOfGetFileNodeErrorText.Length.ShouldBe(2);
            methodGetFileNodeErrorTextPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFileNodeErrorText) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_GetFileNodeErrorText_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFileNodeErrorTextPrametersTypes = new Type[] { typeof(SPListItem), typeof(Exception) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerInstance, MethodGetFileNodeErrorText, Fixture, methodGetFileNodeErrorTextPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFileNodeErrorTextPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFileNodeErrorText) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_GetFileNodeErrorText_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFileNodeErrorTextPrametersTypes = new Type[] { typeof(SPListItem), typeof(Exception) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerInstance, MethodGetFileNodeErrorText, Fixture, methodGetFileNodeErrorTextPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFileNodeErrorTextPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AppendToRptList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportViewer_AppendToRptList_Method_Call_Internally(Type[] types)
        {
            var methodAppendToRptListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerInstance, MethodAppendToRptList, Fixture, methodAppendToRptListPrametersTypes);
        }

        #endregion

        #region Method Call : (AppendToRptList) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_AppendToRptList_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var item = CreateType<SSRS2005.CatalogItem>();
            var tab = CreateType<bool>();
            var isFldr = CreateType<bool>();
            var imgURL = CreateType<string>();
            var methodAppendToRptListPrametersTypes = new Type[] { typeof(SSRS2005.CatalogItem), typeof(bool), typeof(bool), typeof(string) };
            object[] parametersOfAppendToRptList = { item, tab, isFldr, imgURL };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAppendToRptList, methodAppendToRptListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportViewerInstanceFixture, parametersOfAppendToRptList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAppendToRptList.ShouldNotBeNull();
            parametersOfAppendToRptList.Length.ShouldBe(4);
            methodAppendToRptListPrametersTypes.Length.ShouldBe(4);
            methodAppendToRptListPrametersTypes.Length.ShouldBe(parametersOfAppendToRptList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AppendToRptList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_AppendToRptList_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var item = CreateType<SSRS2005.CatalogItem>();
            var tab = CreateType<bool>();
            var isFldr = CreateType<bool>();
            var imgURL = CreateType<string>();
            var methodAppendToRptListPrametersTypes = new Type[] { typeof(SSRS2005.CatalogItem), typeof(bool), typeof(bool), typeof(string) };
            object[] parametersOfAppendToRptList = { item, tab, isFldr, imgURL };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportViewerInstance, MethodAppendToRptList, parametersOfAppendToRptList, methodAppendToRptListPrametersTypes);

            // Assert
            parametersOfAppendToRptList.ShouldNotBeNull();
            parametersOfAppendToRptList.Length.ShouldBe(4);
            methodAppendToRptListPrametersTypes.Length.ShouldBe(4);
            methodAppendToRptListPrametersTypes.Length.ShouldBe(parametersOfAppendToRptList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AppendToRptList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_AppendToRptList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAppendToRptList, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AppendToRptList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_AppendToRptList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAppendToRptListPrametersTypes = new Type[] { typeof(SSRS2005.CatalogItem), typeof(bool), typeof(bool), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerInstance, MethodAppendToRptList, Fixture, methodAppendToRptListPrametersTypes);

            // Assert
            methodAppendToRptListPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AppendToRptList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_AppendToRptList_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAppendToRptList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportViewerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportViewer_OnInit_Method_Call_Internally(Type[] types)
        {
            var methodOnInitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_OnInit_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnInit = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnInit, methodOnInitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportViewerInstanceFixture, parametersOfOnInit);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnInit.ShouldNotBeNull();
            parametersOfOnInit.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(parametersOfOnInit.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_OnInit_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnInit = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportViewerInstance, MethodOnInit, parametersOfOnInit, methodOnInitPrametersTypes);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_OnInit_Method_Call_Parameters_Count_Verification_Test()
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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_OnInit_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);

            // Assert
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewer_OnInit_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnInit, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportViewerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}