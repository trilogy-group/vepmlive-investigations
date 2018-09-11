using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.getgriditems" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class GetgriditemsTest : AbstractBaseSetupTypedTest<getgriditems>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (getgriditems) Initializer

        private const string MethodoutputXml = "outputXml";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodaddItems = "addItems";
        private const string MethodaddMenus = "addMenus";
        private const string MethodaddFilterItems = "addFilterItems";
        private const string MethodaddItem = "addItem";
        private const string MethodisEditable = "isEditable";
        private const string MethodgetSingleLookup = "getSingleLookup";
        private const string MethodgetLookupList = "getLookupList";
        private const string MethodgetMultiUser = "getMultiUser";
        private const string MethodsetAggVal = "setAggVal";
        private const string MethodprocessList = "processList";
        private const string MethodprocessListDT = "processListDT";
        private const string MethodgetQuery = "getQuery";
        private const string MethodaddGroups = "addGroups";
        private const string MethodsetInitialAggs = "setInitialAggs";
        private const string MethodpopulateGroups = "populateGroups";
        private const string MethodGetLookupValuesQuery = "GetLookupValuesQuery";
        private const string MethodGetReportFilters = "GetReportFilters";
        private const string MethodappendLookupQuery = "appendLookupQuery";
        private const string MethodaddHeader = "addHeader";
        private const string MethodgetRealField = "getRealField";
        private const string MethodgetParams = "getParams";
        private const string MethodgetField = "getField";
        private const string MethodformatField = "formatField";
        private const string MethodGetTaskFile = "GetTaskFile";
        private const string FieldMAX_LOOKUPFILTER = "MAX_LOOKUPFILTER";
        private const string FielddocXml = "docXml";
        private const string Fielddata = "data";
        private const string FieldisTimesheet = "isTimesheet";
        private const string FieldtitleFieldFound = "titleFieldFound";
        private const string Fieldlist = "list";
        private const string Fieldview = "view";
        private const string FieldsPlannerID = "sPlannerID";
        private const string FieldTitleProjectCenter = "TitleProjectCenter";
        private const string FieldDoesUserHavePermissionsViewListItems = "DoesUserHavePermissionsViewListItems";
        private const string FieldDoesUserHavePermissionsEditListItems = "DoesUserHavePermissionsEditListItems";
        private const string FieldDoesUserHavePermissionsManagePermissions = "DoesUserHavePermissionsManagePermissions";
        private const string FieldDoesUserHavePermissionsDeleteListItems = "DoesUserHavePermissionsDeleteListItems";
        private const string FieldDoesUserHavePermissionsViewVersions = "DoesUserHavePermissionsViewVersions";
        private const string FieldDoesUserHavePermissionsApproveItems = "DoesUserHavePermissionsApproveItems";
        private const string Fieldstrlist = "strlist";
        private const string Fieldstrview = "strview";
        private const string Fieldusewbs = "usewbs";
        private const string Fieldexecutive = "executive";
        private const string Fieldlinktype = "linktype";
        private const string Fieldrollupsites = "rollupsites";
        private const string Fieldrolluplists = "rolluplists";
        private const string Fieldgridname = "gridname";
        private const string Fieldadditionalgroups = "additionalgroups";
        private const string Fieldexpandlevel = "expandlevel";
        private const string FieldinEditMode = "inEditMode";
        private const string Fieldshowinsertrow = "showinsertrow";
        private const string FieldusePerformance = "usePerformance";
        private const string FieldusePopup = "usePopup";
        private const string Fieldrequestsenabled = "requestsenabled";
        private const string FieldshowCheckboxes = "showCheckboxes";
        private const string FieldiPageSize = "iPageSize";
        private const string FieldiPage = "iPage";
        private const string FieldDifferentColumns = "DifferentColumns";
        private const string FieldDifferentGroups = "DifferentGroups";
        private const string FieldFromGroupBy = "FromGroupBy";
        private const string FieldGroupByFromToolbar = "GroupByFromToolbar";
        private const string FieldaViewFields = "aViewFields";
        private const string FieldaHiddenViewFields = "aHiddenViewFields";
        private const string FieldbWorkspaceUrl = "bWorkspaceUrl";
        private const string FieldWPID = "WPID";
        private const string Fieldexpanded = "expanded";
        private const string Fieldfilterfield = "filterfield";
        private const string Fieldfiltervalue = "filtervalue";
        private const string FieldlookupFilterField = "lookupFilterField";
        private const string FieldlookupFilterFieldList = "lookupFilterFieldList";
        private const string FieldlookupFilterIDs = "lookupFilterIDs";
        private const string FieldreportFilterIDs = "reportFilterIDs";
        private const string FieldreportFilterField = "reportFilterField";
        private const string FieldsSearchField = "sSearchField";
        private const string FieldsSearchValue = "sSearchValue";
        private const string FieldsSearchType = "sSearchType";
        private const string FieldhshGroups = "hshGroups";
        private const string FieldarrGroupFields = "arrGroupFields";
        private const string FieldglobalError = "globalError";
        private const string FieldbCleanValues = "bCleanValues";
        private const string FieldReportID = "ReportID";
        private const string FieldbUseReporting = "bUseReporting";
        private const string FieldhshMenus = "hshMenus";
        private const string FieldqueueAllItems = "queueAllItems";
        private const string FieldarrItems = "arrItems";
        private const string FieldhshItemNodes = "hshItemNodes";
        private const string FieldtreeCol = "treeCol";
        private const string FieldarrAggregationDef = "arrAggregationDef";
        private const string FieldarrAggregationVals = "arrAggregationVals";
        private const string FieldhshWBS = "hshWBS";
        private const string FieldarrGroupMin = "arrGroupMin";
        private const string FieldarrGroupMax = "arrGroupMax";
        private const string FieldndMainParent = "ndMainParent";
        private const string FieldhshLists = "hshLists";
        private const string FieldhshColumnSelectFilter = "hshColumnSelectFilter";
        private const string FieldhshFieldProperties = "hshFieldProperties";
        private const string FieldarrColumns = "arrColumns";
        private const string FieldndBeforeInit = "ndBeforeInit";
        private const string FieldhshComboCells = "hshComboCells";
        private const string FieldproviderEn = "providerEn";
        private const string FieldisResPlan = "isResPlan";
        private const string FieldndNewRowCells = "ndNewRowCells";
        private const string FieldhasGroups = "hasGroups";
        private const string FieldLookupFilterField = "LookupFilterField";
        private const string FieldLookupFilterValue = "LookupFilterValue";
        private const string FieldStartDateField = "StartDateField";
        private const string FieldDueDateField = "DueDateField";
        private const string FieldProgressField = "ProgressField";
        private const string FieldInfoField = "InfoField";
        private const string FieldbShowGantt = "bShowGantt";
        private const string Fieldtb = "tb";
        private const string Fieldepmdebug = "epmdebug";
        private Type _getgriditemsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private getgriditems _getgriditemsInstance;
        private getgriditems _getgriditemsInstanceFixture;

        #region General Initializer : Class (getgriditems) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="getgriditems" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _getgriditemsInstanceType = typeof(getgriditems);
            _getgriditemsInstanceFixture = Create(true);
            _getgriditemsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (getgriditems)

        #region General Initializer : Class (getgriditems) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="getgriditems" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodoutputXml, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodaddItems, 0)]
        [TestCase(MethodaddMenus, 0)]
        [TestCase(MethodaddFilterItems, 0)]
        [TestCase(MethodaddItem, 0)]
        [TestCase(MethodisEditable, 0)]
        [TestCase(MethodaddItem, 1)]
        [TestCase(MethodgetSingleLookup, 0)]
        [TestCase(MethodgetLookupList, 0)]
        [TestCase(MethodgetLookupList, 1)]
        [TestCase(MethodgetMultiUser, 0)]
        [TestCase(MethodsetAggVal, 0)]
        [TestCase(MethodprocessList, 0)]
        [TestCase(MethodprocessListDT, 0)]
        [TestCase(MethodgetQuery, 0)]
        [TestCase(MethodaddGroups, 0)]
        [TestCase(MethodsetInitialAggs, 0)]
        [TestCase(MethodpopulateGroups, 0)]
        [TestCase(MethodGetLookupValuesQuery, 0)]
        [TestCase(MethodGetReportFilters, 0)]
        [TestCase(MethodappendLookupQuery, 0)]
        [TestCase(MethodaddGroups, 1)]
        [TestCase(MethodaddHeader, 0)]
        [TestCase(MethodgetRealField, 0)]
        [TestCase(MethodgetParams, 0)]
        [TestCase(MethodgetField, 0)]
        [TestCase(MethodformatField, 0)]
        [TestCase(MethodformatField, 1)]
        [TestCase(MethodGetTaskFile, 0)]
        public void AUT_Getgriditems_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_getgriditemsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (getgriditems) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="getgriditems" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldMAX_LOOKUPFILTER)]
        [TestCase(FielddocXml)]
        [TestCase(Fielddata)]
        [TestCase(FieldisTimesheet)]
        [TestCase(FieldtitleFieldFound)]
        [TestCase(Fieldlist)]
        [TestCase(Fieldview)]
        [TestCase(FieldsPlannerID)]
        [TestCase(FieldTitleProjectCenter)]
        [TestCase(FieldDoesUserHavePermissionsViewListItems)]
        [TestCase(FieldDoesUserHavePermissionsEditListItems)]
        [TestCase(FieldDoesUserHavePermissionsManagePermissions)]
        [TestCase(FieldDoesUserHavePermissionsDeleteListItems)]
        [TestCase(FieldDoesUserHavePermissionsViewVersions)]
        [TestCase(FieldDoesUserHavePermissionsApproveItems)]
        [TestCase(Fieldstrlist)]
        [TestCase(Fieldstrview)]
        [TestCase(Fieldusewbs)]
        [TestCase(Fieldexecutive)]
        [TestCase(Fieldlinktype)]
        [TestCase(Fieldrollupsites)]
        [TestCase(Fieldrolluplists)]
        [TestCase(Fieldgridname)]
        [TestCase(Fieldadditionalgroups)]
        [TestCase(Fieldexpandlevel)]
        [TestCase(FieldinEditMode)]
        [TestCase(Fieldshowinsertrow)]
        [TestCase(FieldusePerformance)]
        [TestCase(FieldusePopup)]
        [TestCase(Fieldrequestsenabled)]
        [TestCase(FieldshowCheckboxes)]
        [TestCase(FieldiPageSize)]
        [TestCase(FieldiPage)]
        [TestCase(FieldDifferentColumns)]
        [TestCase(FieldDifferentGroups)]
        [TestCase(FieldFromGroupBy)]
        [TestCase(FieldGroupByFromToolbar)]
        [TestCase(FieldaViewFields)]
        [TestCase(FieldaHiddenViewFields)]
        [TestCase(FieldbWorkspaceUrl)]
        [TestCase(FieldWPID)]
        [TestCase(Fieldexpanded)]
        [TestCase(Fieldfilterfield)]
        [TestCase(Fieldfiltervalue)]
        [TestCase(FieldlookupFilterField)]
        [TestCase(FieldlookupFilterFieldList)]
        [TestCase(FieldlookupFilterIDs)]
        [TestCase(FieldreportFilterIDs)]
        [TestCase(FieldreportFilterField)]
        [TestCase(FieldsSearchField)]
        [TestCase(FieldsSearchValue)]
        [TestCase(FieldsSearchType)]
        [TestCase(FieldhshGroups)]
        [TestCase(FieldarrGroupFields)]
        [TestCase(FieldglobalError)]
        [TestCase(FieldbCleanValues)]
        [TestCase(FieldReportID)]
        [TestCase(FieldbUseReporting)]
        [TestCase(FieldhshMenus)]
        [TestCase(FieldqueueAllItems)]
        [TestCase(FieldarrItems)]
        [TestCase(FieldhshItemNodes)]
        [TestCase(FieldtreeCol)]
        [TestCase(FieldarrAggregationDef)]
        [TestCase(FieldarrAggregationVals)]
        [TestCase(FieldhshWBS)]
        [TestCase(FieldarrGroupMin)]
        [TestCase(FieldarrGroupMax)]
        [TestCase(FieldndMainParent)]
        [TestCase(FieldhshLists)]
        [TestCase(FieldhshColumnSelectFilter)]
        [TestCase(FieldhshFieldProperties)]
        [TestCase(FieldarrColumns)]
        [TestCase(FieldndBeforeInit)]
        [TestCase(FieldhshComboCells)]
        [TestCase(FieldproviderEn)]
        [TestCase(FieldisResPlan)]
        [TestCase(FieldndNewRowCells)]
        [TestCase(FieldhasGroups)]
        [TestCase(FieldLookupFilterField)]
        [TestCase(FieldLookupFilterValue)]
        [TestCase(FieldStartDateField)]
        [TestCase(FieldDueDateField)]
        [TestCase(FieldProgressField)]
        [TestCase(FieldInfoField)]
        [TestCase(FieldbShowGantt)]
        [TestCase(Fieldtb)]
        [TestCase(Fieldepmdebug)]
        public void AUT_Getgriditems_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_getgriditemsInstanceFixture, 
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
        ///     Class (<see cref="getgriditems" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Getgriditems_Is_Instance_Present_Test()
        {
            // Assert
            _getgriditemsInstanceType.ShouldNotBeNull();
            _getgriditemsInstance.ShouldNotBeNull();
            _getgriditemsInstanceFixture.ShouldNotBeNull();
            _getgriditemsInstance.ShouldBeAssignableTo<getgriditems>();
            _getgriditemsInstanceFixture.ShouldBeAssignableTo<getgriditems>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (getgriditems) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_getgriditems_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            getgriditems instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _getgriditemsInstanceType.ShouldNotBeNull();
            _getgriditemsInstance.ShouldNotBeNull();
            _getgriditemsInstanceFixture.ShouldNotBeNull();
            _getgriditemsInstance.ShouldBeAssignableTo<getgriditems>();
            _getgriditemsInstanceFixture.ShouldBeAssignableTo<getgriditems>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="getgriditems" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetTaskFile)]
        public void AUT_Getgriditems_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_getgriditemsInstanceFixture,
                                                                              _getgriditemsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="getgriditems" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodoutputXml)]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodaddItems)]
        [TestCase(MethodaddMenus)]
        [TestCase(MethodaddFilterItems)]
        [TestCase(MethodaddItem)]
        [TestCase(MethodisEditable)]
        [TestCase(MethodgetSingleLookup)]
        [TestCase(MethodgetLookupList)]
        [TestCase(MethodgetMultiUser)]
        [TestCase(MethodsetAggVal)]
        [TestCase(MethodprocessList)]
        [TestCase(MethodprocessListDT)]
        [TestCase(MethodgetQuery)]
        [TestCase(MethodaddGroups)]
        [TestCase(MethodsetInitialAggs)]
        [TestCase(MethodpopulateGroups)]
        [TestCase(MethodGetLookupValuesQuery)]
        [TestCase(MethodGetReportFilters)]
        [TestCase(MethodappendLookupQuery)]
        [TestCase(MethodaddHeader)]
        [TestCase(MethodgetRealField)]
        [TestCase(MethodgetParams)]
        [TestCase(MethodgetField)]
        [TestCase(MethodformatField)]
        public void AUT_Getgriditems_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<getgriditems>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (outputXml) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_outputXml_Method_Call_Internally(Type[] types)
        {
            var methodoutputXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodoutputXml, Fixture, methodoutputXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (outputXml) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_outputXml_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodoutputXmlPrametersTypes = null;
            object[] parametersOfoutputXml = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodoutputXml, methodoutputXmlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfoutputXml);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfoutputXml.ShouldBeNull();
            methodoutputXmlPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (outputXml) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_outputXml_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodoutputXmlPrametersTypes = null;
            object[] parametersOfoutputXml = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgriditemsInstance, MethodoutputXml, parametersOfoutputXml, methodoutputXmlPrametersTypes);

            // Assert
            parametersOfoutputXml.ShouldBeNull();
            methodoutputXmlPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (outputXml) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_outputXml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodoutputXmlPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodoutputXml, Fixture, methodoutputXmlPrametersTypes);

            // Assert
            methodoutputXmlPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (outputXml) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_outputXml_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodoutputXml, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Getgriditems_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgriditemsInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Getgriditems_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Getgriditems_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addItems) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_addItems_Method_Call_Internally(Type[] types)
        {
            var methodaddItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodaddItems, Fixture, methodaddItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (addItems) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addItems_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodaddItemsPrametersTypes = null;
            object[] parametersOfaddItems = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodaddItems, methodaddItemsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfaddItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfaddItems.ShouldBeNull();
            methodaddItemsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addItems) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addItems_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodaddItemsPrametersTypes = null;
            object[] parametersOfaddItems = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgriditemsInstance, MethodaddItems, parametersOfaddItems, methodaddItemsPrametersTypes);

            // Assert
            parametersOfaddItems.ShouldBeNull();
            methodaddItemsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addItems) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodaddItemsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodaddItems, Fixture, methodaddItemsPrametersTypes);

            // Assert
            methodaddItemsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addItems) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addItems_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddItems, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addMenus) (Return Type : XmlNode) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_addMenus_Method_Call_Internally(Type[] types)
        {
            var methodaddMenusPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodaddMenus, Fixture, methodaddMenusPrametersTypes);
        }

        #endregion

        #region Method Call : (addMenus) (Return Type : XmlNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addMenus_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var ndNewItem = CreateType<XmlNode>();
            var list = CreateType<SPList>();
            var showcreateworkspace = CreateType<string>();
            var methodaddMenusPrametersTypes = new Type[] { typeof(XmlNode), typeof(SPList), typeof(string) };
            object[] parametersOfaddMenus = { ndNewItem, list, showcreateworkspace };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodaddMenus, methodaddMenusPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getgriditems, XmlNode>(_getgriditemsInstanceFixture, out exception1, parametersOfaddMenus);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getgriditems, XmlNode>(_getgriditemsInstance, MethodaddMenus, parametersOfaddMenus, methodaddMenusPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfaddMenus.ShouldNotBeNull();
            parametersOfaddMenus.Length.ShouldBe(3);
            methodaddMenusPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (addMenus) (Return Type : XmlNode) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addMenus_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ndNewItem = CreateType<XmlNode>();
            var list = CreateType<SPList>();
            var showcreateworkspace = CreateType<string>();
            var methodaddMenusPrametersTypes = new Type[] { typeof(XmlNode), typeof(SPList), typeof(string) };
            object[] parametersOfaddMenus = { ndNewItem, list, showcreateworkspace };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgriditems, XmlNode>(_getgriditemsInstance, MethodaddMenus, parametersOfaddMenus, methodaddMenusPrametersTypes);

            // Assert
            parametersOfaddMenus.ShouldNotBeNull();
            parametersOfaddMenus.Length.ShouldBe(3);
            methodaddMenusPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addMenus) (Return Type : XmlNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addMenus_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodaddMenusPrametersTypes = new Type[] { typeof(XmlNode), typeof(SPList), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodaddMenus, Fixture, methodaddMenusPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodaddMenusPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (addMenus) (Return Type : XmlNode) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addMenus_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddMenusPrametersTypes = new Type[] { typeof(XmlNode), typeof(SPList), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodaddMenus, Fixture, methodaddMenusPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodaddMenusPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addMenus) (Return Type : XmlNode) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addMenus_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddMenus, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (addMenus) (Return Type : XmlNode) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addMenus_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddMenus, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addFilterItems) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_addFilterItems_Method_Call_Internally(Type[] types)
        {
            var methodaddFilterItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodaddFilterItems, Fixture, methodaddFilterItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (addFilterItems) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addFilterItems_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<string>();
            var value = CreateType<string>();
            var methodaddFilterItemsPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfaddFilterItems = { field, value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodaddFilterItems, methodaddFilterItemsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfaddFilterItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfaddFilterItems.ShouldNotBeNull();
            parametersOfaddFilterItems.Length.ShouldBe(2);
            methodaddFilterItemsPrametersTypes.Length.ShouldBe(2);
            methodaddFilterItemsPrametersTypes.Length.ShouldBe(parametersOfaddFilterItems.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (addFilterItems) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addFilterItems_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<string>();
            var value = CreateType<string>();
            var methodaddFilterItemsPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfaddFilterItems = { field, value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgriditemsInstance, MethodaddFilterItems, parametersOfaddFilterItems, methodaddFilterItemsPrametersTypes);

            // Assert
            parametersOfaddFilterItems.ShouldNotBeNull();
            parametersOfaddFilterItems.Length.ShouldBe(2);
            methodaddFilterItemsPrametersTypes.Length.ShouldBe(2);
            methodaddFilterItemsPrametersTypes.Length.ShouldBe(parametersOfaddFilterItems.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addFilterItems) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addFilterItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddFilterItems, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addFilterItems) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addFilterItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddFilterItemsPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodaddFilterItems, Fixture, methodaddFilterItemsPrametersTypes);

            // Assert
            methodaddFilterItemsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addFilterItems) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addFilterItems_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddFilterItems, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_addItem_Method_Call_Internally(Type[] types)
        {
            var methodaddItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodaddItem, Fixture, methodaddItemPrametersTypes);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addItem_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var methodaddItemPrametersTypes = new Type[] { typeof(DataRow) };
            object[] parametersOfaddItem = { dr };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodaddItem, methodaddItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfaddItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfaddItem.ShouldNotBeNull();
            parametersOfaddItem.Length.ShouldBe(1);
            methodaddItemPrametersTypes.Length.ShouldBe(1);
            methodaddItemPrametersTypes.Length.ShouldBe(parametersOfaddItem.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addItem_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var methodaddItemPrametersTypes = new Type[] { typeof(DataRow) };
            object[] parametersOfaddItem = { dr };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgriditemsInstance, MethodaddItem, parametersOfaddItem, methodaddItemPrametersTypes);

            // Assert
            parametersOfaddItem.ShouldNotBeNull();
            parametersOfaddItem.Length.ShouldBe(1);
            methodaddItemPrametersTypes.Length.ShouldBe(1);
            methodaddItemPrametersTypes.Length.ShouldBe(parametersOfaddItem.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddItem, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddItemPrametersTypes = new Type[] { typeof(DataRow) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodaddItem, Fixture, methodaddItemPrametersTypes);

            // Assert
            methodaddItemPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addItem_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddItem, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (isEditable) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_isEditable_Method_Call_Internally(Type[] types)
        {
            var methodisEditablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodisEditable, Fixture, methodisEditablePrametersTypes);
        }

        #endregion

        #region Method Call : (isEditable) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_isEditable_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var field = CreateType<SPField>();
            var fieldProperties = CreateType<Dictionary<string, Dictionary<string, string>>>();
            var methodisEditablePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPField), typeof(Dictionary<string, Dictionary<string, string>>) };
            object[] parametersOfisEditable = { li, field, fieldProperties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodisEditable, methodisEditablePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfisEditable);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfisEditable.ShouldNotBeNull();
            parametersOfisEditable.Length.ShouldBe(3);
            methodisEditablePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (isEditable) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_isEditable_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var field = CreateType<SPField>();
            var fieldProperties = CreateType<Dictionary<string, Dictionary<string, string>>>();
            var methodisEditablePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPField), typeof(Dictionary<string, Dictionary<string, string>>) };
            object[] parametersOfisEditable = { li, field, fieldProperties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgriditems, bool>(_getgriditemsInstance, MethodisEditable, parametersOfisEditable, methodisEditablePrametersTypes);

            // Assert
            parametersOfisEditable.ShouldNotBeNull();
            parametersOfisEditable.Length.ShouldBe(3);
            methodisEditablePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (isEditable) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_isEditable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodisEditablePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPField), typeof(Dictionary<string, Dictionary<string, string>>) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodisEditable, Fixture, methodisEditablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodisEditablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (isEditable) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_isEditable_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodisEditable, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (isEditable) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_isEditable_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodisEditable, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_addItem_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodaddItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodaddItem, Fixture, methodaddItemPrametersTypes);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addItem_Method_Call_Void_Overloading_Of_1_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var indexer = CreateType<string>();
            var methodaddItemPrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };
            object[] parametersOfaddItem = { li, indexer };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodaddItem, methodaddItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfaddItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfaddItem.ShouldNotBeNull();
            parametersOfaddItem.Length.ShouldBe(2);
            methodaddItemPrametersTypes.Length.ShouldBe(2);
            methodaddItemPrametersTypes.Length.ShouldBe(parametersOfaddItem.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addItem_Method_Call_Void_Overloading_Of_1_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var indexer = CreateType<string>();
            var methodaddItemPrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };
            object[] parametersOfaddItem = { li, indexer };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgriditemsInstance, MethodaddItem, parametersOfaddItem, methodaddItemPrametersTypes);

            // Assert
            parametersOfaddItem.ShouldNotBeNull();
            parametersOfaddItem.Length.ShouldBe(2);
            methodaddItemPrametersTypes.Length.ShouldBe(2);
            methodaddItemPrametersTypes.Length.ShouldBe(parametersOfaddItem.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addItem_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddItem, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addItem_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddItemPrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodaddItem, Fixture, methodaddItemPrametersTypes);

            // Assert
            methodaddItemPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addItem_Method_Call_Overloading_Of_1_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddItem, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getSingleLookup) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_getSingleLookup_Method_Call_Internally(Type[] types)
        {
            var methodgetSingleLookupPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetSingleLookup, Fixture, methodgetSingleLookupPrametersTypes);
        }

        #endregion

        #region Method Call : (getSingleLookup) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getSingleLookup_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<string>();
            var field = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodgetSingleLookupPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SPWeb) };
            object[] parametersOfgetSingleLookup = { list, field, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetSingleLookup, methodgetSingleLookupPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfgetSingleLookup);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetSingleLookup.ShouldNotBeNull();
            parametersOfgetSingleLookup.Length.ShouldBe(3);
            methodgetSingleLookupPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getSingleLookup) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getSingleLookup_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<string>();
            var field = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodgetSingleLookupPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SPWeb) };
            object[] parametersOfgetSingleLookup = { list, field, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgriditems, string>(_getgriditemsInstance, MethodgetSingleLookup, parametersOfgetSingleLookup, methodgetSingleLookupPrametersTypes);

            // Assert
            parametersOfgetSingleLookup.ShouldNotBeNull();
            parametersOfgetSingleLookup.Length.ShouldBe(3);
            methodgetSingleLookupPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getSingleLookup) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getSingleLookup_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetSingleLookupPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetSingleLookup, Fixture, methodgetSingleLookupPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetSingleLookupPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (getSingleLookup) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getSingleLookup_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetSingleLookupPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SPWeb) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetSingleLookup, Fixture, methodgetSingleLookupPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetSingleLookupPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getSingleLookup) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getSingleLookup_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetSingleLookup, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getSingleLookup) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getSingleLookup_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetSingleLookup, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getLookupList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_getLookupList_Method_Call_Internally(Type[] types)
        {
            var methodgetLookupListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetLookupList, Fixture, methodgetLookupListPrametersTypes);
        }

        #endregion

        #region Method Call : (getLookupList) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getLookupList_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<string>();
            var field = CreateType<string>();
            var methodgetLookupListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfgetLookupList = { web, list, field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetLookupList, methodgetLookupListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfgetLookupList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetLookupList.ShouldNotBeNull();
            parametersOfgetLookupList.Length.ShouldBe(3);
            methodgetLookupListPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getLookupList) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getLookupList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<string>();
            var field = CreateType<string>();
            var methodgetLookupListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfgetLookupList = { web, list, field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgriditems, string>(_getgriditemsInstance, MethodgetLookupList, parametersOfgetLookupList, methodgetLookupListPrametersTypes);

            // Assert
            parametersOfgetLookupList.ShouldNotBeNull();
            parametersOfgetLookupList.Length.ShouldBe(3);
            methodgetLookupListPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getLookupList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getLookupList_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetLookupListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetLookupList, Fixture, methodgetLookupListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetLookupListPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (getLookupList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getLookupList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetLookupListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetLookupList, Fixture, methodgetLookupListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetLookupListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getLookupList) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getLookupList_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetLookupList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getLookupList) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getLookupList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetLookupList, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getLookupList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_getLookupList_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodgetLookupListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetLookupList, Fixture, methodgetLookupListPrametersTypes);
        }

        #endregion

        #region Method Call : (getLookupList) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getLookupList_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<Guid>();
            var field = CreateType<Guid>();
            var query = CreateType<string>();
            var view = CreateType<string>();
            var methodgetLookupListPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid), typeof(Guid), typeof(string), typeof(string) };
            object[] parametersOfgetLookupList = { web, list, field, query, view };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetLookupList, methodgetLookupListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfgetLookupList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetLookupList.ShouldNotBeNull();
            parametersOfgetLookupList.Length.ShouldBe(5);
            methodgetLookupListPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getLookupList) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getLookupList_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<Guid>();
            var field = CreateType<Guid>();
            var query = CreateType<string>();
            var view = CreateType<string>();
            var methodgetLookupListPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid), typeof(Guid), typeof(string), typeof(string) };
            object[] parametersOfgetLookupList = { web, list, field, query, view };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgriditems, string>(_getgriditemsInstance, MethodgetLookupList, parametersOfgetLookupList, methodgetLookupListPrametersTypes);

            // Assert
            parametersOfgetLookupList.ShouldNotBeNull();
            parametersOfgetLookupList.Length.ShouldBe(5);
            methodgetLookupListPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getLookupList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getLookupList_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetLookupListPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid), typeof(Guid), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetLookupList, Fixture, methodgetLookupListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetLookupListPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (getLookupList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getLookupList_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetLookupListPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid), typeof(Guid), typeof(string), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetLookupList, Fixture, methodgetLookupListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetLookupListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getLookupList) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getLookupList_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetLookupList, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getLookupList) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getLookupList_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetLookupList, 1);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getMultiUser) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_getMultiUser_Method_Call_Internally(Type[] types)
        {
            var methodgetMultiUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetMultiUser, Fixture, methodgetMultiUserPrametersTypes);
        }

        #endregion

        #region Method Call : (getMultiUser) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getMultiUser_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var mode = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodgetMultiUserPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfgetMultiUser = { mode, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetMultiUser, methodgetMultiUserPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfgetMultiUser);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetMultiUser.ShouldNotBeNull();
            parametersOfgetMultiUser.Length.ShouldBe(2);
            methodgetMultiUserPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getMultiUser) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getMultiUser_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var mode = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodgetMultiUserPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfgetMultiUser = { mode, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgriditems, string>(_getgriditemsInstance, MethodgetMultiUser, parametersOfgetMultiUser, methodgetMultiUserPrametersTypes);

            // Assert
            parametersOfgetMultiUser.ShouldNotBeNull();
            parametersOfgetMultiUser.Length.ShouldBe(2);
            methodgetMultiUserPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getMultiUser) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getMultiUser_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetMultiUserPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetMultiUser, Fixture, methodgetMultiUserPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetMultiUserPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getMultiUser) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getMultiUser_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetMultiUserPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetMultiUser, Fixture, methodgetMultiUserPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetMultiUserPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getMultiUser) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getMultiUser_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetMultiUser, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getMultiUser) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getMultiUser_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetMultiUser, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setAggVal) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_setAggVal_Method_Call_Internally(Type[] types)
        {
            var methodsetAggValPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodsetAggVal, Fixture, methodsetAggValPrametersTypes);
        }

        #endregion

        #region Method Call : (setAggVal) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_setAggVal_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var group = CreateType<string>();
            var fieldname = CreateType<string>();
            var val = CreateType<string>();
            var aggList = CreateType<SPList>();
            var methodsetAggValPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(SPList) };
            object[] parametersOfsetAggVal = { group, fieldname, val, aggList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsetAggVal, methodsetAggValPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfsetAggVal);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetAggVal.ShouldNotBeNull();
            parametersOfsetAggVal.Length.ShouldBe(4);
            methodsetAggValPrametersTypes.Length.ShouldBe(4);
            methodsetAggValPrametersTypes.Length.ShouldBe(parametersOfsetAggVal.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setAggVal) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_setAggVal_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var group = CreateType<string>();
            var fieldname = CreateType<string>();
            var val = CreateType<string>();
            var aggList = CreateType<SPList>();
            var methodsetAggValPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(SPList) };
            object[] parametersOfsetAggVal = { group, fieldname, val, aggList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgriditemsInstance, MethodsetAggVal, parametersOfsetAggVal, methodsetAggValPrametersTypes);

            // Assert
            parametersOfsetAggVal.ShouldNotBeNull();
            parametersOfsetAggVal.Length.ShouldBe(4);
            methodsetAggValPrametersTypes.Length.ShouldBe(4);
            methodsetAggValPrametersTypes.Length.ShouldBe(parametersOfsetAggVal.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setAggVal) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_setAggVal_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsetAggVal, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setAggVal) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_setAggVal_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsetAggValPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodsetAggVal, Fixture, methodsetAggValPrametersTypes);

            // Assert
            methodsetAggValPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setAggVal) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_setAggVal_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsetAggVal, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_processList_Method_Call_Internally(Type[] types)
        {
            var methodprocessListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodprocessList, Fixture, methodprocessListPrametersTypes);
        }

        #endregion
        
        #region Method Call : (processList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_processList_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var spquery = CreateType<string>();
            var curList = CreateType<SPList>();
            var arrGTemp = CreateType<SortedList>();
            var methodprocessListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(SPList), typeof(SortedList) };
            object[] parametersOfprocessList = { web, spquery, curList, arrGTemp };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgriditemsInstance, MethodprocessList, parametersOfprocessList, methodprocessListPrametersTypes);

            // Assert
            parametersOfprocessList.ShouldNotBeNull();
            parametersOfprocessList.Length.ShouldBe(4);
            methodprocessListPrametersTypes.Length.ShouldBe(4);
            methodprocessListPrametersTypes.Length.ShouldBe(parametersOfprocessList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_processList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessList, 0);
            const int parametersCount = 4;

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
        public void AUT_Getgriditems_processList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(SPList), typeof(SortedList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodprocessList, Fixture, methodprocessListPrametersTypes);

            // Assert
            methodprocessListPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_processList_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processListDT) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_processListDT_Method_Call_Internally(Type[] types)
        {
            var methodprocessListDTPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodprocessListDT, Fixture, methodprocessListDTPrametersTypes);
        }

        #endregion

        #region Method Call : (processListDT) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_processListDT_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var dtRows = CreateType<DataRow[]>();
            var arrGTemp = CreateType<SortedList>();
            var listname = CreateType<string>();
            var methodprocessListDTPrametersTypes = new Type[] { typeof(SPWeb), typeof(DataRow[]), typeof(SortedList), typeof(string) };
            object[] parametersOfprocessListDT = { web, dtRows, arrGTemp, listname };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessListDT, methodprocessListDTPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfprocessListDT);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessListDT.ShouldNotBeNull();
            parametersOfprocessListDT.Length.ShouldBe(4);
            methodprocessListDTPrametersTypes.Length.ShouldBe(4);
            methodprocessListDTPrametersTypes.Length.ShouldBe(parametersOfprocessListDT.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processListDT) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_processListDT_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var dtRows = CreateType<DataRow[]>();
            var arrGTemp = CreateType<SortedList>();
            var listname = CreateType<string>();
            var methodprocessListDTPrametersTypes = new Type[] { typeof(SPWeb), typeof(DataRow[]), typeof(SortedList), typeof(string) };
            object[] parametersOfprocessListDT = { web, dtRows, arrGTemp, listname };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgriditemsInstance, MethodprocessListDT, parametersOfprocessListDT, methodprocessListDTPrametersTypes);

            // Assert
            parametersOfprocessListDT.ShouldNotBeNull();
            parametersOfprocessListDT.Length.ShouldBe(4);
            methodprocessListDTPrametersTypes.Length.ShouldBe(4);
            methodprocessListDTPrametersTypes.Length.ShouldBe(parametersOfprocessListDT.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processListDT) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_processListDT_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessListDT, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processListDT) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_processListDT_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessListDTPrametersTypes = new Type[] { typeof(SPWeb), typeof(DataRow[]), typeof(SortedList), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodprocessListDT, Fixture, methodprocessListDTPrametersTypes);

            // Assert
            methodprocessListDTPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processListDT) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_processListDT_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessListDT, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_getQuery_Method_Call_Internally(Type[] types)
        {
            var methodgetQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetQuery, Fixture, methodgetQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (getQuery) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getQuery_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _getgriditemsInstance.getQuery();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getQuery_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodgetQueryPrametersTypes = null;
            object[] parametersOfgetQuery = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetQuery, methodgetQueryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getgriditems, string>(_getgriditemsInstanceFixture, out exception1, parametersOfgetQuery);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getgriditems, string>(_getgriditemsInstance, MethodgetQuery, parametersOfgetQuery, methodgetQueryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetQuery.ShouldBeNull();
            methodgetQueryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getQuery_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodgetQueryPrametersTypes = null;
            object[] parametersOfgetQuery = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgriditems, string>(_getgriditemsInstance, MethodgetQuery, parametersOfgetQuery, methodgetQueryPrametersTypes);

            // Assert
            parametersOfgetQuery.ShouldBeNull();
            methodgetQueryPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getQuery_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodgetQueryPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetQuery, Fixture, methodgetQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetQueryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodgetQueryPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetQuery, Fixture, methodgetQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetQueryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getQuery) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getQuery_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_addGroups_Method_Call_Internally(Type[] types)
        {
            var methodaddGroupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodaddGroups, Fixture, methodaddGroupsPrametersTypes);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addGroups_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var spquery = CreateType<string>();
            var arrGTemp = CreateType<SortedList>();
            Action executeAction = null;

            // Act
            executeAction = () => _getgriditemsInstance.addGroups(web, spquery, arrGTemp);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addGroups_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var spquery = CreateType<string>();
            var arrGTemp = CreateType<SortedList>();
            var methodaddGroupsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(SortedList) };
            object[] parametersOfaddGroups = { web, spquery, arrGTemp };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodaddGroups, methodaddGroupsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfaddGroups);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfaddGroups.ShouldNotBeNull();
            parametersOfaddGroups.Length.ShouldBe(3);
            methodaddGroupsPrametersTypes.Length.ShouldBe(3);
            methodaddGroupsPrametersTypes.Length.ShouldBe(parametersOfaddGroups.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addGroups_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var spquery = CreateType<string>();
            var arrGTemp = CreateType<SortedList>();
            var methodaddGroupsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(SortedList) };
            object[] parametersOfaddGroups = { web, spquery, arrGTemp };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgriditemsInstance, MethodaddGroups, parametersOfaddGroups, methodaddGroupsPrametersTypes);

            // Assert
            parametersOfaddGroups.ShouldNotBeNull();
            parametersOfaddGroups.Length.ShouldBe(3);
            methodaddGroupsPrametersTypes.Length.ShouldBe(3);
            methodaddGroupsPrametersTypes.Length.ShouldBe(parametersOfaddGroups.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addGroups_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddGroups, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addGroups_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddGroupsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(SortedList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodaddGroups, Fixture, methodaddGroupsPrametersTypes);

            // Assert
            methodaddGroupsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addGroups_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddGroups, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setInitialAggs) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_setInitialAggs_Method_Call_Internally(Type[] types)
        {
            var methodsetInitialAggsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodsetInitialAggs, Fixture, methodsetInitialAggsPrametersTypes);
        }

        #endregion

        #region Method Call : (setInitialAggs) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_setInitialAggs_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var grouping = CreateType<string>();
            var methodsetInitialAggsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfsetInitialAggs = { grouping };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsetInitialAggs, methodsetInitialAggsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfsetInitialAggs);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetInitialAggs.ShouldNotBeNull();
            parametersOfsetInitialAggs.Length.ShouldBe(1);
            methodsetInitialAggsPrametersTypes.Length.ShouldBe(1);
            methodsetInitialAggsPrametersTypes.Length.ShouldBe(parametersOfsetInitialAggs.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setInitialAggs) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_setInitialAggs_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var grouping = CreateType<string>();
            var methodsetInitialAggsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfsetInitialAggs = { grouping };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgriditemsInstance, MethodsetInitialAggs, parametersOfsetInitialAggs, methodsetInitialAggsPrametersTypes);

            // Assert
            parametersOfsetInitialAggs.ShouldNotBeNull();
            parametersOfsetInitialAggs.Length.ShouldBe(1);
            methodsetInitialAggsPrametersTypes.Length.ShouldBe(1);
            methodsetInitialAggsPrametersTypes.Length.ShouldBe(parametersOfsetInitialAggs.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setInitialAggs) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_setInitialAggs_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsetInitialAggs, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setInitialAggs) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_setInitialAggs_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsetInitialAggsPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodsetInitialAggs, Fixture, methodsetInitialAggsPrametersTypes);

            // Assert
            methodsetInitialAggsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setInitialAggs) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_setInitialAggs_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsetInitialAggs, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (populateGroups) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_populateGroups_Method_Call_Internally(Type[] types)
        {
            var methodpopulateGroupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodpopulateGroups, Fixture, methodpopulateGroupsPrametersTypes);
        }

        #endregion

        #region Method Call : (populateGroups) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_populateGroups_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var arrGTemp = CreateType<SortedList>();
            var curWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => _getgriditemsInstance.populateGroups(query, arrGTemp, curWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (populateGroups) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_populateGroups_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var arrGTemp = CreateType<SortedList>();
            var curWeb = CreateType<SPWeb>();
            var methodpopulateGroupsPrametersTypes = new Type[] { typeof(string), typeof(SortedList), typeof(SPWeb) };
            object[] parametersOfpopulateGroups = { query, arrGTemp, curWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodpopulateGroups, methodpopulateGroupsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfpopulateGroups);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfpopulateGroups.ShouldNotBeNull();
            parametersOfpopulateGroups.Length.ShouldBe(3);
            methodpopulateGroupsPrametersTypes.Length.ShouldBe(3);
            methodpopulateGroupsPrametersTypes.Length.ShouldBe(parametersOfpopulateGroups.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (populateGroups) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_populateGroups_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var arrGTemp = CreateType<SortedList>();
            var curWeb = CreateType<SPWeb>();
            var methodpopulateGroupsPrametersTypes = new Type[] { typeof(string), typeof(SortedList), typeof(SPWeb) };
            object[] parametersOfpopulateGroups = { query, arrGTemp, curWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgriditemsInstance, MethodpopulateGroups, parametersOfpopulateGroups, methodpopulateGroupsPrametersTypes);

            // Assert
            parametersOfpopulateGroups.ShouldNotBeNull();
            parametersOfpopulateGroups.Length.ShouldBe(3);
            methodpopulateGroupsPrametersTypes.Length.ShouldBe(3);
            methodpopulateGroupsPrametersTypes.Length.ShouldBe(parametersOfpopulateGroups.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (populateGroups) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_populateGroups_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodpopulateGroups, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (populateGroups) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_populateGroups_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodpopulateGroupsPrametersTypes = new Type[] { typeof(string), typeof(SortedList), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodpopulateGroups, Fixture, methodpopulateGroupsPrametersTypes);

            // Assert
            methodpopulateGroupsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (populateGroups) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_populateGroups_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodpopulateGroups, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLookupValuesQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_GetLookupValuesQuery_Method_Call_Internally(Type[] types)
        {
            var methodGetLookupValuesQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodGetLookupValuesQuery, Fixture, methodGetLookupValuesQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLookupValuesQuery) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_GetLookupValuesQuery_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetLookupValuesQueryPrametersTypes = null;
            object[] parametersOfGetLookupValuesQuery = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLookupValuesQuery, methodGetLookupValuesQueryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getgriditems, string>(_getgriditemsInstanceFixture, out exception1, parametersOfGetLookupValuesQuery);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getgriditems, string>(_getgriditemsInstance, MethodGetLookupValuesQuery, parametersOfGetLookupValuesQuery, methodGetLookupValuesQueryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetLookupValuesQuery.ShouldBeNull();
            methodGetLookupValuesQueryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLookupValuesQuery) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_GetLookupValuesQuery_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetLookupValuesQueryPrametersTypes = null;
            object[] parametersOfGetLookupValuesQuery = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetLookupValuesQuery, methodGetLookupValuesQueryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfGetLookupValuesQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetLookupValuesQuery.ShouldBeNull();
            methodGetLookupValuesQueryPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLookupValuesQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_GetLookupValuesQuery_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetLookupValuesQueryPrametersTypes = null;
            object[] parametersOfGetLookupValuesQuery = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgriditems, string>(_getgriditemsInstance, MethodGetLookupValuesQuery, parametersOfGetLookupValuesQuery, methodGetLookupValuesQueryPrametersTypes);

            // Assert
            parametersOfGetLookupValuesQuery.ShouldBeNull();
            methodGetLookupValuesQueryPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLookupValuesQuery) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_GetLookupValuesQuery_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetLookupValuesQueryPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodGetLookupValuesQuery, Fixture, methodGetLookupValuesQueryPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetLookupValuesQueryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLookupValuesQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_GetLookupValuesQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetLookupValuesQueryPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodGetLookupValuesQuery, Fixture, methodGetLookupValuesQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLookupValuesQueryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLookupValuesQuery) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_GetLookupValuesQuery_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLookupValuesQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetReportFilters) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_GetReportFilters_Method_Call_Internally(Type[] types)
        {
            var methodGetReportFiltersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodGetReportFilters, Fixture, methodGetReportFiltersPrametersTypes);
        }

        #endregion

        #region Method Call : (GetReportFilters) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_GetReportFilters_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetReportFiltersPrametersTypes = null;
            object[] parametersOfGetReportFilters = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetReportFilters, methodGetReportFiltersPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getgriditems, string>(_getgriditemsInstanceFixture, out exception1, parametersOfGetReportFilters);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getgriditems, string>(_getgriditemsInstance, MethodGetReportFilters, parametersOfGetReportFilters, methodGetReportFiltersPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetReportFilters.ShouldBeNull();
            methodGetReportFiltersPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetReportFilters) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_GetReportFilters_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetReportFiltersPrametersTypes = null;
            object[] parametersOfGetReportFilters = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetReportFilters, methodGetReportFiltersPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfGetReportFilters);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetReportFilters.ShouldBeNull();
            methodGetReportFiltersPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetReportFilters) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_GetReportFilters_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetReportFiltersPrametersTypes = null;
            object[] parametersOfGetReportFilters = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgriditems, string>(_getgriditemsInstance, MethodGetReportFilters, parametersOfGetReportFilters, methodGetReportFiltersPrametersTypes);

            // Assert
            parametersOfGetReportFilters.ShouldBeNull();
            methodGetReportFiltersPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetReportFilters) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_GetReportFilters_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetReportFiltersPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodGetReportFilters, Fixture, methodGetReportFiltersPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetReportFiltersPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetReportFilters) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_GetReportFilters_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetReportFiltersPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodGetReportFilters, Fixture, methodGetReportFiltersPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetReportFiltersPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetReportFilters) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_GetReportFilters_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetReportFilters, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (appendLookupQuery) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_appendLookupQuery_Method_Call_Internally(Type[] types)
        {
            var methodappendLookupQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodappendLookupQuery, Fixture, methodappendLookupQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (appendLookupQuery) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_appendLookupQuery_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var xmlQuery = CreateType<XmlDocument>();
            var arrTempGroups = CreateType<ArrayList>();
            var methodappendLookupQueryPrametersTypes = new Type[] { typeof(XmlDocument), typeof(ArrayList) };
            object[] parametersOfappendLookupQuery = { xmlQuery, arrTempGroups };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodappendLookupQuery, methodappendLookupQueryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfappendLookupQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfappendLookupQuery.ShouldNotBeNull();
            parametersOfappendLookupQuery.Length.ShouldBe(2);
            methodappendLookupQueryPrametersTypes.Length.ShouldBe(2);
            methodappendLookupQueryPrametersTypes.Length.ShouldBe(parametersOfappendLookupQuery.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (appendLookupQuery) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_appendLookupQuery_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xmlQuery = CreateType<XmlDocument>();
            var arrTempGroups = CreateType<ArrayList>();
            var methodappendLookupQueryPrametersTypes = new Type[] { typeof(XmlDocument), typeof(ArrayList) };
            object[] parametersOfappendLookupQuery = { xmlQuery, arrTempGroups };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgriditemsInstance, MethodappendLookupQuery, parametersOfappendLookupQuery, methodappendLookupQueryPrametersTypes);

            // Assert
            parametersOfappendLookupQuery.ShouldNotBeNull();
            parametersOfappendLookupQuery.Length.ShouldBe(2);
            methodappendLookupQueryPrametersTypes.Length.ShouldBe(2);
            methodappendLookupQueryPrametersTypes.Length.ShouldBe(parametersOfappendLookupQuery.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (appendLookupQuery) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_appendLookupQuery_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodappendLookupQuery, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (appendLookupQuery) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_appendLookupQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodappendLookupQueryPrametersTypes = new Type[] { typeof(XmlDocument), typeof(ArrayList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodappendLookupQuery, Fixture, methodappendLookupQueryPrametersTypes);

            // Assert
            methodappendLookupQueryPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (appendLookupQuery) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_appendLookupQuery_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodappendLookupQuery, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_addGroups_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodaddGroupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodaddGroups, Fixture, methodaddGroupsPrametersTypes);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addGroups_Method_Call_Void_Overloading_Of_1_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var curWeb = CreateType<SPWeb>();
            var methodaddGroupsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfaddGroups = { curWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodaddGroups, methodaddGroupsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfaddGroups);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfaddGroups.ShouldNotBeNull();
            parametersOfaddGroups.Length.ShouldBe(1);
            methodaddGroupsPrametersTypes.Length.ShouldBe(1);
            methodaddGroupsPrametersTypes.Length.ShouldBe(parametersOfaddGroups.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addGroups_Method_Call_Void_Overloading_Of_1_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var curWeb = CreateType<SPWeb>();
            var methodaddGroupsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfaddGroups = { curWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgriditemsInstance, MethodaddGroups, parametersOfaddGroups, methodaddGroupsPrametersTypes);

            // Assert
            parametersOfaddGroups.ShouldNotBeNull();
            parametersOfaddGroups.Length.ShouldBe(1);
            methodaddGroupsPrametersTypes.Length.ShouldBe(1);
            methodaddGroupsPrametersTypes.Length.ShouldBe(parametersOfaddGroups.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addGroups_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddGroups, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addGroups_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddGroupsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodaddGroups, Fixture, methodaddGroupsPrametersTypes);

            // Assert
            methodaddGroupsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addGroups_Method_Call_Overloading_Of_1_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddGroups, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_addHeader_Method_Call_Internally(Type[] types)
        {
            var methodaddHeaderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodaddHeader, Fixture, methodaddHeaderPrametersTypes);
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addHeader_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodaddHeaderPrametersTypes = null;
            object[] parametersOfaddHeader = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodaddHeader, methodaddHeaderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfaddHeader);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfaddHeader.ShouldBeNull();
            methodaddHeaderPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addHeader_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodaddHeaderPrametersTypes = null;
            object[] parametersOfaddHeader = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgriditemsInstance, MethodaddHeader, parametersOfaddHeader, methodaddHeaderPrametersTypes);

            // Assert
            parametersOfaddHeader.ShouldBeNull();
            methodaddHeaderPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addHeader_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodaddHeaderPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodaddHeader, Fixture, methodaddHeaderPrametersTypes);

            // Assert
            methodaddHeaderPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_addHeader_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddHeader, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_getRealField_Method_Call_Internally(Type[] types)
        {
            var methodgetRealFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getRealField_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetRealField, methodgetRealFieldPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getgriditems, SPField>(_getgriditemsInstanceFixture, out exception1, parametersOfgetRealField);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getgriditems, SPField>(_getgriditemsInstance, MethodgetRealField, parametersOfgetRealField, methodgetRealFieldPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetRealField.ShouldNotBeNull();
            parametersOfgetRealField.Length.ShouldBe(1);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getRealField_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetRealField, methodgetRealFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfgetRealField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetRealField.ShouldNotBeNull();
            parametersOfgetRealField.Length.ShouldBe(1);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getRealField_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgriditems, SPField>(_getgriditemsInstance, MethodgetRealField, parametersOfgetRealField, methodgetRealFieldPrametersTypes);

            // Assert
            parametersOfgetRealField.ShouldNotBeNull();
            parametersOfgetRealField.Length.ShouldBe(1);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getRealField_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getRealField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getRealField_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetRealField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getRealField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetRealField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_getParams_Method_Call_Internally(Type[] types)
        {
            var methodgetParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetParams, Fixture, methodgetParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getParams_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var curWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => _getgriditemsInstance.getParams(curWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getParams_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var curWeb = CreateType<SPWeb>();
            var methodgetParamsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetParams = { curWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetParams, methodgetParamsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfgetParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetParams.ShouldNotBeNull();
            parametersOfgetParams.Length.ShouldBe(1);
            methodgetParamsPrametersTypes.Length.ShouldBe(1);
            methodgetParamsPrametersTypes.Length.ShouldBe(parametersOfgetParams.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getParams_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var curWeb = CreateType<SPWeb>();
            var methodgetParamsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetParams = { curWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgriditemsInstance, MethodgetParams, parametersOfgetParams, methodgetParamsPrametersTypes);

            // Assert
            parametersOfgetParams.ShouldNotBeNull();
            parametersOfgetParams.Length.ShouldBe(1);
            methodgetParamsPrametersTypes.Length.ShouldBe(1);
            methodgetParamsPrametersTypes.Length.ShouldBe(parametersOfgetParams.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getParams_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetParams, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getParams_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetParamsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetParams, Fixture, methodgetParamsPrametersTypes);

            // Assert
            methodgetParamsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getParams_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetParams, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_getField_Method_Call_Internally(Type[] types)
        {
            var methodgetFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetField, Fixture, methodgetFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getField_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var field = CreateType<string>();
            var group = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _getgriditemsInstance.getField(li, field, group);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getField_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var field = CreateType<string>();
            var group = CreateType<bool>();
            var methodgetFieldPrametersTypes = new Type[] { typeof(SPListItem), typeof(string), typeof(bool) };
            object[] parametersOfgetField = { li, field, group };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetField, methodgetFieldPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getgriditems, string>(_getgriditemsInstanceFixture, out exception1, parametersOfgetField);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getgriditems, string>(_getgriditemsInstance, MethodgetField, parametersOfgetField, methodgetFieldPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfgetField.ShouldNotBeNull();
            parametersOfgetField.Length.ShouldBe(3);
            methodgetFieldPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getField_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var field = CreateType<string>();
            var group = CreateType<bool>();
            var methodgetFieldPrametersTypes = new Type[] { typeof(SPListItem), typeof(string), typeof(bool) };
            object[] parametersOfgetField = { li, field, group };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetField, methodgetFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfgetField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetField.ShouldNotBeNull();
            parametersOfgetField.Length.ShouldBe(3);
            methodgetFieldPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getField_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var field = CreateType<string>();
            var group = CreateType<bool>();
            var methodgetFieldPrametersTypes = new Type[] { typeof(SPListItem), typeof(string), typeof(bool) };
            object[] parametersOfgetField = { li, field, group };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgriditems, string>(_getgriditemsInstance, MethodgetField, parametersOfgetField, methodgetFieldPrametersTypes);

            // Assert
            parametersOfgetField.ShouldNotBeNull();
            parametersOfgetField.Length.ShouldBe(3);
            methodgetFieldPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getField_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodgetFieldPrametersTypes = new Type[] { typeof(SPListItem), typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetField, Fixture, methodgetFieldPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodgetFieldPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetFieldPrametersTypes = new Type[] { typeof(SPListItem), typeof(string), typeof(bool) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodgetField, Fixture, methodgetFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getField_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_getField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetField, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_formatField_Method_Call_Internally(Type[] types)
        {
            var methodformatFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodformatField, Fixture, methodformatFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_formatField_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var val = CreateType<string>();
            var fieldname = CreateType<string>();
            var calculated = CreateType<bool>();
            var group = CreateType<bool>();
            var li = CreateType<SPListItem>();
            Action executeAction = null;

            // Act
            executeAction = () => _getgriditemsInstance.formatField(val, fieldname, calculated, group, li);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_formatField_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var val = CreateType<string>();
            var fieldname = CreateType<string>();
            var calculated = CreateType<bool>();
            var group = CreateType<bool>();
            var li = CreateType<SPListItem>();
            var methodformatFieldPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(SPListItem) };
            object[] parametersOfformatField = { val, fieldname, calculated, group, li };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodformatField, methodformatFieldPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getgriditems, string>(_getgriditemsInstanceFixture, out exception1, parametersOfformatField);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getgriditems, string>(_getgriditemsInstance, MethodformatField, parametersOfformatField, methodformatFieldPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfformatField.ShouldNotBeNull();
            parametersOfformatField.Length.ShouldBe(5);
            methodformatFieldPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_formatField_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var val = CreateType<string>();
            var fieldname = CreateType<string>();
            var calculated = CreateType<bool>();
            var group = CreateType<bool>();
            var li = CreateType<SPListItem>();
            var methodformatFieldPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(SPListItem) };
            object[] parametersOfformatField = { val, fieldname, calculated, group, li };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgriditems, string>(_getgriditemsInstance, MethodformatField, parametersOfformatField, methodformatFieldPrametersTypes);

            // Assert
            parametersOfformatField.ShouldNotBeNull();
            parametersOfformatField.Length.ShouldBe(5);
            methodformatFieldPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_formatField_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodformatFieldPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodformatField, Fixture, methodformatFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodformatFieldPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_formatField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodformatFieldPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(SPListItem) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodformatField, Fixture, methodformatFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodformatFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_formatField_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodformatField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_formatField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodformatField, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_formatField_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodformatFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodformatField, Fixture, methodformatFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_formatField_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var val = CreateType<string>();
            var fieldname = CreateType<string>();
            var dr = CreateType<DataRow>();
            var group = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _getgriditemsInstance.formatField(val, fieldname, dr, group);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_formatField_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var val = CreateType<string>();
            var fieldname = CreateType<string>();
            var dr = CreateType<DataRow>();
            var group = CreateType<bool>();
            var methodformatFieldPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(DataRow), typeof(bool) };
            object[] parametersOfformatField = { val, fieldname, dr, group };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodformatField, methodformatFieldPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getgriditems, string>(_getgriditemsInstanceFixture, out exception1, parametersOfformatField);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getgriditems, string>(_getgriditemsInstance, MethodformatField, parametersOfformatField, methodformatFieldPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfformatField.ShouldNotBeNull();
            parametersOfformatField.Length.ShouldBe(4);
            methodformatFieldPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_formatField_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var val = CreateType<string>();
            var fieldname = CreateType<string>();
            var dr = CreateType<DataRow>();
            var group = CreateType<bool>();
            var methodformatFieldPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(DataRow), typeof(bool) };
            object[] parametersOfformatField = { val, fieldname, dr, group };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgriditems, string>(_getgriditemsInstance, MethodformatField, parametersOfformatField, methodformatFieldPrametersTypes);

            // Assert
            parametersOfformatField.ShouldNotBeNull();
            parametersOfformatField.Length.ShouldBe(4);
            methodformatFieldPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_formatField_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodformatFieldPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(DataRow), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodformatField, Fixture, methodformatFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodformatFieldPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_formatField_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodformatFieldPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(DataRow), typeof(bool) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgriditemsInstance, MethodformatField, Fixture, methodformatFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodformatFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_formatField_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodformatField, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_formatField_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodformatField, 1);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTaskFile) (Return Type : SPFile) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgriditems_GetTaskFile_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTaskFilePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getgriditemsInstanceFixture, _getgriditemsInstanceType, MethodGetTaskFile, Fixture, methodGetTaskFilePrametersTypes);
        }

        #endregion

        #region Method Call : (GetTaskFile) (Return Type : SPFile) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_GetTaskFile_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var id = CreateType<string>();
            var planner = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => getgriditems.GetTaskFile(web, id, planner);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTaskFile) (Return Type : SPFile) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_GetTaskFile_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var id = CreateType<string>();
            var planner = CreateType<string>();
            var methodGetTaskFilePrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfGetTaskFile = { web, id, planner };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTaskFile, methodGetTaskFilePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getgriditemsInstanceFixture, _getgriditemsInstanceType, MethodGetTaskFile, Fixture, methodGetTaskFilePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SPFile>(_getgriditemsInstanceFixture, _getgriditemsInstanceType, MethodGetTaskFile, parametersOfGetTaskFile, methodGetTaskFilePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_getgriditemsInstanceFixture, parametersOfGetTaskFile);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTaskFile.ShouldNotBeNull();
            parametersOfGetTaskFile.Length.ShouldBe(3);
            methodGetTaskFilePrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetTaskFile) (Return Type : SPFile) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_GetTaskFile_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var id = CreateType<string>();
            var planner = CreateType<string>();
            var methodGetTaskFilePrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfGetTaskFile = { web, id, planner };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SPFile>(_getgriditemsInstanceFixture, _getgriditemsInstanceType, MethodGetTaskFile, parametersOfGetTaskFile, methodGetTaskFilePrametersTypes);

            // Assert
            parametersOfGetTaskFile.ShouldNotBeNull();
            parametersOfGetTaskFile.Length.ShouldBe(3);
            methodGetTaskFilePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTaskFile) (Return Type : SPFile) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_GetTaskFile_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTaskFilePrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getgriditemsInstanceFixture, _getgriditemsInstanceType, MethodGetTaskFile, Fixture, methodGetTaskFilePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTaskFilePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetTaskFile) (Return Type : SPFile) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_GetTaskFile_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTaskFilePrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getgriditemsInstanceFixture, _getgriditemsInstanceType, MethodGetTaskFile, Fixture, methodGetTaskFilePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTaskFilePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTaskFile) (Return Type : SPFile) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_GetTaskFile_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTaskFile, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgriditemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTaskFile) (Return Type : SPFile) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgriditems_GetTaskFile_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTaskFile, 0);
            const int parametersCount = 3;

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