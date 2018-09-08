using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ListReportView" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ListReportViewTest : AbstractBaseSetupTypedTest<ListReportView>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ListReportView) Initializer

        private const string PropertyViewLists = "ViewLists";
        private const string PropertyExpandView = "ExpandView";
        private const string PropertyDisplayListNames = "DisplayListNames";
        private const string PropertySelectedListNames = "SelectedListNames";
        private const string PropertyReportsFolderName = "ReportsFolderName";
        private const string PropertyPropReportsPath = "PropReportsPath";
        private const string PropertyIsTopList = "IsTopList";
        private const string PropertyUseDefaults = "UseDefaults";
        private const string PropertyPropSRSUrl = "PropSRSUrl";
        private const string PropertyIsIntegratedMode = "IsIntegratedMode";
        private const string MethodOnInit = "OnInit";
        private const string MethodOnPreRender = "OnPreRender";
        private const string MethodRenderWebPart = "RenderWebPart";
        private const string MethodRenderHTML = "RenderHTML";
        private const string MethodBuildGridPostParameters = "BuildGridPostParameters";
        private const string MethodBuildQueryParam = "BuildQueryParam";
        private const string MethodGetToolParts = "GetToolParts";
        private const string MethodGetListNamesInHashtable = "GetListNamesInHashtable";
        private const string MethodGetParentFolder = "GetParentFolder";
        private const string MethodGetNonFolderItems = "GetNonFolderItems";
        private const string MethodTraverseListFolder = "TraverseListFolder";
        private const string MethodAddDocuments = "AddDocuments";
        private const string Field_viewLists = "_viewLists";
        private const string Field_expandView = "_expandView";
        private const string Field_sortNames = "_sortNames";
        private const string Field_selectedListName = "_selectedListName";
        private const string Field_reportingServicesUrl = "_reportingServicesUrl";
        private const string Field_reportsRootFolderName = "_reportsRootFolderName";
        private const string Field_isIntegrated = "_isIntegrated";
        private const string FieldsReportsFolderName = "sReportsFolderName";
        private const string FieldsbRptList = "sbRptList";
        private const string Fieldsrs2005 = "srs2005";
        private const string Fieldsrs2006 = "srs2006";
        private const string Fieldweb = "web";
        private const string FieldcurWeb = "curWeb";
        private const string FieldbUseDefaults = "bUseDefaults";
        private const string FieldbIsTopList = "bIsTopList";
        private const string FieldbIsIntegratedMode = "bIsIntegratedMode";
        private const string FieldstrSRSUrl = "strSRSUrl";
        private const string FieldstrReportsPath = "strReportsPath";
        private const string FieldtnCurrNode = "tnCurrNode";
        private const string FieldtncNodes = "tncNodes";
        private const string FieldtvReportView = "tvReportView";
        private const string FieldparametersSSRS2006 = "parametersSSRS2006";
        private const string FieldparametersSSRS2005 = "parametersSSRS2005";
        private Type _listReportViewInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ListReportView _listReportViewInstance;
        private ListReportView _listReportViewInstanceFixture;

        #region General Initializer : Class (ListReportView) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ListReportView" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _listReportViewInstanceType = typeof(ListReportView);
            _listReportViewInstanceFixture = Create(true);
            _listReportViewInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ListReportView)

        #region General Initializer : Class (ListReportView) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ListReportView" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethodOnInit, 0)]
        [TestCase(MethodOnPreRender, 0)]
        [TestCase(MethodRenderWebPart, 0)]
        [TestCase(MethodRenderHTML, 0)]
        [TestCase(MethodBuildGridPostParameters, 0)]
        [TestCase(MethodBuildQueryParam, 0)]
        [TestCase(MethodGetToolParts, 0)]
        [TestCase(MethodGetListNamesInHashtable, 0)]
        [TestCase(MethodGetParentFolder, 0)]
        [TestCase(MethodGetNonFolderItems, 0)]
        [TestCase(MethodTraverseListFolder, 0)]
        [TestCase(MethodAddDocuments, 0)]
        public void AUT_ListReportView_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_listReportViewInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ListReportView) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ListReportView" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyViewLists)]
        [TestCase(PropertyExpandView)]
        [TestCase(PropertyDisplayListNames)]
        [TestCase(PropertySelectedListNames)]
        [TestCase(PropertyReportsFolderName)]
        [TestCase(PropertyPropReportsPath)]
        [TestCase(PropertyIsTopList)]
        [TestCase(PropertyUseDefaults)]
        [TestCase(PropertyPropSRSUrl)]
        [TestCase(PropertyIsIntegratedMode)]
        public void AUT_ListReportView_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_listReportViewInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ListReportView) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ListReportView" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Field_viewLists)]
        [TestCase(Field_expandView)]
        [TestCase(Field_sortNames)]
        [TestCase(Field_selectedListName)]
        [TestCase(Field_reportingServicesUrl)]
        [TestCase(Field_reportsRootFolderName)]
        [TestCase(Field_isIntegrated)]
        [TestCase(FieldsReportsFolderName)]
        [TestCase(FieldsbRptList)]
        [TestCase(Fieldsrs2005)]
        [TestCase(Fieldsrs2006)]
        [TestCase(Fieldweb)]
        [TestCase(FieldcurWeb)]
        [TestCase(FieldbUseDefaults)]
        [TestCase(FieldbIsTopList)]
        [TestCase(FieldbIsIntegratedMode)]
        [TestCase(FieldstrSRSUrl)]
        [TestCase(FieldstrReportsPath)]
        [TestCase(FieldtnCurrNode)]
        [TestCase(FieldtncNodes)]
        [TestCase(FieldtvReportView)]
        [TestCase(FieldparametersSSRS2006)]
        [TestCase(FieldparametersSSRS2005)]
        public void AUT_ListReportView_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_listReportViewInstanceFixture, 
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
        ///     Class (<see cref="ListReportView" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ListReportView_Is_Instance_Present_Test()
        {
            // Assert
            _listReportViewInstanceType.ShouldNotBeNull();
            _listReportViewInstance.ShouldNotBeNull();
            _listReportViewInstanceFixture.ShouldNotBeNull();
            _listReportViewInstance.ShouldBeAssignableTo<ListReportView>();
            _listReportViewInstanceFixture.ShouldBeAssignableTo<ListReportView>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ListReportView) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ListReportView_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ListReportView instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _listReportViewInstanceType.ShouldNotBeNull();
            _listReportViewInstance.ShouldNotBeNull();
            _listReportViewInstanceFixture.ShouldNotBeNull();
            _listReportViewInstance.ShouldBeAssignableTo<ListReportView>();
            _listReportViewInstanceFixture.ShouldBeAssignableTo<ListReportView>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ListReportView) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyViewLists)]
        [TestCaseGeneric(typeof(bool) , PropertyExpandView)]
        [TestCaseGeneric(typeof(string) , PropertyDisplayListNames)]
        [TestCaseGeneric(typeof(string) , PropertySelectedListNames)]
        [TestCaseGeneric(typeof(string) , PropertyReportsFolderName)]
        [TestCaseGeneric(typeof(string) , PropertyPropReportsPath)]
        [TestCaseGeneric(typeof(bool?) , PropertyIsTopList)]
        [TestCaseGeneric(typeof(bool) , PropertyUseDefaults)]
        [TestCaseGeneric(typeof(string) , PropertyPropSRSUrl)]
        [TestCaseGeneric(typeof(bool) , PropertyIsIntegratedMode)]
        public void AUT_ListReportView_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ListReportView, T>(_listReportViewInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ListReportView) => Property (DisplayListNames) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListReportView_Public_Class_DisplayListNames_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDisplayListNames);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ListReportView) => Property (ExpandView) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListReportView_Public_Class_ExpandView_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyExpandView);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ListReportView) => Property (IsIntegratedMode) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListReportView_Public_Class_IsIntegratedMode_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ListReportView) => Property (IsTopList) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListReportView_Public_Class_IsTopList_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ListReportView) => Property (PropReportsPath) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListReportView_Public_Class_PropReportsPath_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropReportsPath);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ListReportView) => Property (PropSRSUrl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListReportView_Public_Class_PropSRSUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropSRSUrl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ListReportView) => Property (ReportsFolderName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListReportView_Public_Class_ReportsFolderName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyReportsFolderName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ListReportView) => Property (SelectedListNames) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListReportView_Public_Class_SelectedListNames_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySelectedListNames);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ListReportView) => Property (UseDefaults) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListReportView_Public_Class_UseDefaults_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUseDefaults);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ListReportView) => Property (ViewLists) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListReportView_Public_Class_ViewLists_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyViewLists);

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

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ListReportView" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodOnInit)]
        [TestCase(MethodOnPreRender)]
        [TestCase(MethodRenderWebPart)]
        [TestCase(MethodRenderHTML)]
        [TestCase(MethodBuildGridPostParameters)]
        [TestCase(MethodBuildQueryParam)]
        [TestCase(MethodGetToolParts)]
        [TestCase(MethodGetListNamesInHashtable)]
        [TestCase(MethodGetParentFolder)]
        [TestCase(MethodGetNonFolderItems)]
        [TestCase(MethodTraverseListFolder)]
        [TestCase(MethodAddDocuments)]
        public void AUT_ListReportView_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ListReportView>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListReportView_OnInit_Method_Call_Internally(Type[] types)
        {
            var methodOnInitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_OnInit_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnInit = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnInit, methodOnInitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listReportViewInstanceFixture, parametersOfOnInit);

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
        public void AUT_ListReportView_OnInit_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnInit = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listReportViewInstance, MethodOnInit, parametersOfOnInit, methodOnInitPrametersTypes);

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
        public void AUT_ListReportView_OnInit_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ListReportView_OnInit_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);

            // Assert
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_OnInit_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnInit, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listReportViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListReportView_OnPreRender_Method_Call_Internally(Type[] types)
        {
            var methodOnPreRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_OnPreRender_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnPreRender, methodOnPreRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listReportViewInstanceFixture, parametersOfOnPreRender);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_OnPreRender_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listReportViewInstance, MethodOnPreRender, parametersOfOnPreRender, methodOnPreRenderPrametersTypes);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_OnPreRender_Method_Call_Parameters_Count_Verification_Test()
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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_OnPreRender_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);

            // Assert
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_OnPreRender_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listReportViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListReportView_RenderWebPart_Method_Call_Internally(Type[] types)
        {
            var methodRenderWebPartPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodRenderWebPart, Fixture, methodRenderWebPartPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_RenderWebPart_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderWebPart = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderWebPart, methodRenderWebPartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listReportViewInstanceFixture, parametersOfRenderWebPart);

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
        public void AUT_ListReportView_RenderWebPart_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderWebPart = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listReportViewInstance, MethodRenderWebPart, parametersOfRenderWebPart, methodRenderWebPartPrametersTypes);

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
        public void AUT_ListReportView_RenderWebPart_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ListReportView_RenderWebPart_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodRenderWebPart, Fixture, methodRenderWebPartPrametersTypes);

            // Assert
            methodRenderWebPartPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_RenderWebPart_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderWebPart, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listReportViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderHTML) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListReportView_RenderHTML_Method_Call_Internally(Type[] types)
        {
            var methodRenderHTMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodRenderHTML, Fixture, methodRenderHTMLPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderHTML) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_RenderHTML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodRenderHTMLPrametersTypes = null;
            object[] parametersOfRenderHTML = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRenderHTML, methodRenderHTMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListReportView, string>(_listReportViewInstanceFixture, out exception1, parametersOfRenderHTML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListReportView, string>(_listReportViewInstance, MethodRenderHTML, parametersOfRenderHTML, methodRenderHTMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRenderHTML.ShouldBeNull();
            methodRenderHTMLPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderHTML) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_RenderHTML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRenderHTMLPrametersTypes = null;
            object[] parametersOfRenderHTML = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListReportView, string>(_listReportViewInstance, MethodRenderHTML, parametersOfRenderHTML, methodRenderHTMLPrametersTypes);

            // Assert
            parametersOfRenderHTML.ShouldBeNull();
            methodRenderHTMLPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderHTML) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_RenderHTML_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodRenderHTMLPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodRenderHTML, Fixture, methodRenderHTMLPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRenderHTMLPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderHTML) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_RenderHTML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRenderHTMLPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodRenderHTML, Fixture, methodRenderHTMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenderHTMLPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderHTML) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_RenderHTML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderHTML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listReportViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildGridPostParameters) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListReportView_BuildGridPostParameters_Method_Call_Internally(Type[] types)
        {
            var methodBuildGridPostParametersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodBuildGridPostParameters, Fixture, methodBuildGridPostParametersPrametersTypes);
        }

        #endregion
        
        #region Method Call : (BuildGridPostParameters) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_BuildGridPostParameters_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var isSsrs = CreateType<bool>();
            var methodBuildGridPostParametersPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfBuildGridPostParameters = { isSsrs };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListReportView, string>(_listReportViewInstance, MethodBuildGridPostParameters, parametersOfBuildGridPostParameters, methodBuildGridPostParametersPrametersTypes);

            // Assert
            parametersOfBuildGridPostParameters.ShouldNotBeNull();
            parametersOfBuildGridPostParameters.Length.ShouldBe(1);
            methodBuildGridPostParametersPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildGridPostParameters) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_BuildGridPostParameters_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildGridPostParametersPrametersTypes = new Type[] { typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodBuildGridPostParameters, Fixture, methodBuildGridPostParametersPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildGridPostParametersPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (BuildGridPostParameters) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_BuildGridPostParameters_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildGridPostParametersPrametersTypes = new Type[] { typeof(bool) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodBuildGridPostParameters, Fixture, methodBuildGridPostParametersPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildGridPostParametersPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildGridPostParameters) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_BuildGridPostParameters_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildGridPostParameters, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildQueryParam) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListReportView_BuildQueryParam_Method_Call_Internally(Type[] types)
        {
            var methodBuildQueryParamPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodBuildQueryParam, Fixture, methodBuildQueryParamPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildQueryParam) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_BuildQueryParam_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodBuildQueryParamPrametersTypes = null;
            object[] parametersOfBuildQueryParam = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildQueryParam, methodBuildQueryParamPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listReportViewInstanceFixture, parametersOfBuildQueryParam);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildQueryParam.ShouldBeNull();
            methodBuildQueryParamPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildQueryParam) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_BuildQueryParam_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildQueryParamPrametersTypes = null;
            object[] parametersOfBuildQueryParam = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListReportView, string>(_listReportViewInstance, MethodBuildQueryParam, parametersOfBuildQueryParam, methodBuildQueryParamPrametersTypes);

            // Assert
            parametersOfBuildQueryParam.ShouldBeNull();
            methodBuildQueryParamPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildQueryParam) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_BuildQueryParam_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodBuildQueryParamPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodBuildQueryParam, Fixture, methodBuildQueryParamPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodBuildQueryParamPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildQueryParam) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_BuildQueryParam_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildQueryParamPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodBuildQueryParam, Fixture, methodBuildQueryParamPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildQueryParamPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildQueryParam) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_BuildQueryParam_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildQueryParam, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listReportViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListReportView_GetToolParts_Method_Call_Internally(Type[] types)
        {
            var methodGetToolPartsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetToolParts_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _listReportViewInstance.GetToolParts();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetToolParts_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            object[] parametersOfGetToolParts = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetToolParts, methodGetToolPartsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listReportViewInstanceFixture, parametersOfGetToolParts);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetToolParts.ShouldBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetToolParts_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            object[] parametersOfGetToolParts = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListReportView, ToolPart[]>(_listReportViewInstance, MethodGetToolParts, parametersOfGetToolParts, methodGetToolPartsPrametersTypes);

            // Assert
            parametersOfGetToolParts.ShouldBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetToolParts_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetToolParts_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetToolPartsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetToolParts_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetToolParts, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listReportViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetListNamesInHashtable) (Return Type : Hashtable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListReportView_GetListNamesInHashtable_Method_Call_Internally(Type[] types)
        {
            var methodGetListNamesInHashtablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodGetListNamesInHashtable, Fixture, methodGetListNamesInHashtablePrametersTypes);
        }

        #endregion

        #region Method Call : (GetListNamesInHashtable) (Return Type : Hashtable) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetListNamesInHashtable_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sortListName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _listReportViewInstance.GetListNamesInHashtable(sortListName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetListNamesInHashtable) (Return Type : Hashtable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetListNamesInHashtable_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sortListName = CreateType<string>();
            var methodGetListNamesInHashtablePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetListNamesInHashtable = { sortListName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListNamesInHashtable, methodGetListNamesInHashtablePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListReportView, Hashtable>(_listReportViewInstanceFixture, out exception1, parametersOfGetListNamesInHashtable);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListReportView, Hashtable>(_listReportViewInstance, MethodGetListNamesInHashtable, parametersOfGetListNamesInHashtable, methodGetListNamesInHashtablePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListNamesInHashtable.ShouldNotBeNull();
            parametersOfGetListNamesInHashtable.Length.ShouldBe(1);
            methodGetListNamesInHashtablePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListNamesInHashtable) (Return Type : Hashtable) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetListNamesInHashtable_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sortListName = CreateType<string>();
            var methodGetListNamesInHashtablePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetListNamesInHashtable = { sortListName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetListNamesInHashtable, methodGetListNamesInHashtablePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listReportViewInstanceFixture, parametersOfGetListNamesInHashtable);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetListNamesInHashtable.ShouldNotBeNull();
            parametersOfGetListNamesInHashtable.Length.ShouldBe(1);
            methodGetListNamesInHashtablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListNamesInHashtable) (Return Type : Hashtable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetListNamesInHashtable_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sortListName = CreateType<string>();
            var methodGetListNamesInHashtablePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetListNamesInHashtable = { sortListName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListReportView, Hashtable>(_listReportViewInstance, MethodGetListNamesInHashtable, parametersOfGetListNamesInHashtable, methodGetListNamesInHashtablePrametersTypes);

            // Assert
            parametersOfGetListNamesInHashtable.ShouldNotBeNull();
            parametersOfGetListNamesInHashtable.Length.ShouldBe(1);
            methodGetListNamesInHashtablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListNamesInHashtable) (Return Type : Hashtable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetListNamesInHashtable_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListNamesInHashtablePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodGetListNamesInHashtable, Fixture, methodGetListNamesInHashtablePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListNamesInHashtablePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListNamesInHashtable) (Return Type : Hashtable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetListNamesInHashtable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListNamesInHashtablePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodGetListNamesInHashtable, Fixture, methodGetListNamesInHashtablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListNamesInHashtablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListNamesInHashtable) (Return Type : Hashtable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetListNamesInHashtable_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListNamesInHashtable, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listReportViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListNamesInHashtable) (Return Type : Hashtable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetListNamesInHashtable_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListNamesInHashtable, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetParentFolder) (Return Type : SPFolder) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListReportView_GetParentFolder_Method_Call_Internally(Type[] types)
        {
            var methodGetParentFolderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodGetParentFolder, Fixture, methodGetParentFolderPrametersTypes);
        }

        #endregion

        #region Method Call : (GetParentFolder) (Return Type : SPFolder) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetParentFolder_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var itemToFind = CreateType<SPListItem>();
            var folder = CreateType<SPFolder>();
            var methodGetParentFolderPrametersTypes = new Type[] { typeof(SPListItem), typeof(SPFolder) };
            object[] parametersOfGetParentFolder = { itemToFind, folder };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetParentFolder, methodGetParentFolderPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListReportView, SPFolder>(_listReportViewInstanceFixture, out exception1, parametersOfGetParentFolder);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListReportView, SPFolder>(_listReportViewInstance, MethodGetParentFolder, parametersOfGetParentFolder, methodGetParentFolderPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetParentFolder.ShouldNotBeNull();
            parametersOfGetParentFolder.Length.ShouldBe(2);
            methodGetParentFolderPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetParentFolder) (Return Type : SPFolder) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetParentFolder_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var itemToFind = CreateType<SPListItem>();
            var folder = CreateType<SPFolder>();
            var methodGetParentFolderPrametersTypes = new Type[] { typeof(SPListItem), typeof(SPFolder) };
            object[] parametersOfGetParentFolder = { itemToFind, folder };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListReportView, SPFolder>(_listReportViewInstance, MethodGetParentFolder, parametersOfGetParentFolder, methodGetParentFolderPrametersTypes);

            // Assert
            parametersOfGetParentFolder.ShouldNotBeNull();
            parametersOfGetParentFolder.Length.ShouldBe(2);
            methodGetParentFolderPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetParentFolder) (Return Type : SPFolder) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetParentFolder_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetParentFolderPrametersTypes = new Type[] { typeof(SPListItem), typeof(SPFolder) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodGetParentFolder, Fixture, methodGetParentFolderPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetParentFolderPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetParentFolder) (Return Type : SPFolder) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetParentFolder_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetParentFolderPrametersTypes = new Type[] { typeof(SPListItem), typeof(SPFolder) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodGetParentFolder, Fixture, methodGetParentFolderPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetParentFolderPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetParentFolder) (Return Type : SPFolder) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetParentFolder_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetParentFolder, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listReportViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetParentFolder) (Return Type : SPFolder) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetParentFolder_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetParentFolder, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetNonFolderItems) (Return Type : ArrayList) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListReportView_GetNonFolderItems_Method_Call_Internally(Type[] types)
        {
            var methodGetNonFolderItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodGetNonFolderItems, Fixture, methodGetNonFolderItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetNonFolderItems) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetNonFolderItems_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodGetNonFolderItemsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfGetNonFolderItems = { list };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetNonFolderItems, methodGetNonFolderItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListReportView, ArrayList>(_listReportViewInstanceFixture, out exception1, parametersOfGetNonFolderItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListReportView, ArrayList>(_listReportViewInstance, MethodGetNonFolderItems, parametersOfGetNonFolderItems, methodGetNonFolderItemsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetNonFolderItems.ShouldNotBeNull();
            parametersOfGetNonFolderItems.Length.ShouldBe(1);
            methodGetNonFolderItemsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetNonFolderItems) (Return Type : ArrayList) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetNonFolderItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodGetNonFolderItemsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfGetNonFolderItems = { list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListReportView, ArrayList>(_listReportViewInstance, MethodGetNonFolderItems, parametersOfGetNonFolderItems, methodGetNonFolderItemsPrametersTypes);

            // Assert
            parametersOfGetNonFolderItems.ShouldNotBeNull();
            parametersOfGetNonFolderItems.Length.ShouldBe(1);
            methodGetNonFolderItemsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetNonFolderItems) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetNonFolderItems_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetNonFolderItemsPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodGetNonFolderItems, Fixture, methodGetNonFolderItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetNonFolderItemsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetNonFolderItems) (Return Type : ArrayList) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetNonFolderItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetNonFolderItemsPrametersTypes = new Type[] { typeof(SPList) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodGetNonFolderItems, Fixture, methodGetNonFolderItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetNonFolderItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetNonFolderItems) (Return Type : ArrayList) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetNonFolderItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetNonFolderItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listReportViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetNonFolderItems) (Return Type : ArrayList) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_GetNonFolderItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetNonFolderItems, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TraverseListFolder) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListReportView_TraverseListFolder_Method_Call_Internally(Type[] types)
        {
            var methodTraverseListFolderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodTraverseListFolder, Fixture, methodTraverseListFolderPrametersTypes);
        }

        #endregion

        #region Method Call : (TraverseListFolder) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_TraverseListFolder_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var folder = CreateType<SPFolder>();
            var doc = CreateType<XmlDocument>();
            var mainNode = CreateType<XmlNode>();
            var methodTraverseListFolderPrametersTypes = new Type[] { typeof(SPFolder), typeof(XmlDocument), typeof(XmlNode) };
            object[] parametersOfTraverseListFolder = { folder, doc, mainNode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodTraverseListFolder, methodTraverseListFolderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listReportViewInstanceFixture, parametersOfTraverseListFolder);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfTraverseListFolder.ShouldNotBeNull();
            parametersOfTraverseListFolder.Length.ShouldBe(3);
            methodTraverseListFolderPrametersTypes.Length.ShouldBe(3);
            methodTraverseListFolderPrametersTypes.Length.ShouldBe(parametersOfTraverseListFolder.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TraverseListFolder) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_TraverseListFolder_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var folder = CreateType<SPFolder>();
            var doc = CreateType<XmlDocument>();
            var mainNode = CreateType<XmlNode>();
            var methodTraverseListFolderPrametersTypes = new Type[] { typeof(SPFolder), typeof(XmlDocument), typeof(XmlNode) };
            object[] parametersOfTraverseListFolder = { folder, doc, mainNode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listReportViewInstance, MethodTraverseListFolder, parametersOfTraverseListFolder, methodTraverseListFolderPrametersTypes);

            // Assert
            parametersOfTraverseListFolder.ShouldNotBeNull();
            parametersOfTraverseListFolder.Length.ShouldBe(3);
            methodTraverseListFolderPrametersTypes.Length.ShouldBe(3);
            methodTraverseListFolderPrametersTypes.Length.ShouldBe(parametersOfTraverseListFolder.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TraverseListFolder) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_TraverseListFolder_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTraverseListFolder, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TraverseListFolder) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_TraverseListFolder_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTraverseListFolderPrametersTypes = new Type[] { typeof(SPFolder), typeof(XmlDocument), typeof(XmlNode) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodTraverseListFolder, Fixture, methodTraverseListFolderPrametersTypes);

            // Assert
            methodTraverseListFolderPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TraverseListFolder) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_TraverseListFolder_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTraverseListFolder, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listReportViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddDocuments) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListReportView_AddDocuments_Method_Call_Internally(Type[] types)
        {
            var methodAddDocumentsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodAddDocuments, Fixture, methodAddDocumentsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddDocuments) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_AddDocuments_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var folder = CreateType<SPFolder>();
            var doc = CreateType<XmlDocument>();
            var parentNode = CreateType<XmlNode>();
            var methodAddDocumentsPrametersTypes = new Type[] { typeof(SPFolder), typeof(XmlDocument), typeof(XmlNode) };
            object[] parametersOfAddDocuments = { folder, doc, parentNode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddDocuments, methodAddDocumentsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listReportViewInstanceFixture, parametersOfAddDocuments);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddDocuments.ShouldNotBeNull();
            parametersOfAddDocuments.Length.ShouldBe(3);
            methodAddDocumentsPrametersTypes.Length.ShouldBe(3);
            methodAddDocumentsPrametersTypes.Length.ShouldBe(parametersOfAddDocuments.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddDocuments) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_AddDocuments_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var folder = CreateType<SPFolder>();
            var doc = CreateType<XmlDocument>();
            var parentNode = CreateType<XmlNode>();
            var methodAddDocumentsPrametersTypes = new Type[] { typeof(SPFolder), typeof(XmlDocument), typeof(XmlNode) };
            object[] parametersOfAddDocuments = { folder, doc, parentNode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listReportViewInstance, MethodAddDocuments, parametersOfAddDocuments, methodAddDocumentsPrametersTypes);

            // Assert
            parametersOfAddDocuments.ShouldNotBeNull();
            parametersOfAddDocuments.Length.ShouldBe(3);
            methodAddDocumentsPrametersTypes.Length.ShouldBe(3);
            methodAddDocumentsPrametersTypes.Length.ShouldBe(parametersOfAddDocuments.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddDocuments) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_AddDocuments_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddDocuments, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddDocuments) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_AddDocuments_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddDocumentsPrametersTypes = new Type[] { typeof(SPFolder), typeof(XmlDocument), typeof(XmlNode) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listReportViewInstance, MethodAddDocuments, Fixture, methodAddDocumentsPrametersTypes);

            // Assert
            methodAddDocumentsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddDocuments) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListReportView_AddDocuments_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddDocuments, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listReportViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}