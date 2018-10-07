using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.JSGrid;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.GridData" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class GridDataTest : AbstractBaseSetupTypedTest<GridData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (GridData) Initializer

        private const string PropertyViewFields = "ViewFields";
        private const string PropertyLinkTitle = "LinkTitle";
        private const string PropertyWorkspaceUrl = "WorkspaceUrl";
        private const string PropertyAssignedTo = "AssignedTo";
        private const string PropertyImages = "Images";
        private const string PropertyImageNames = "ImageNames";
        private const string PropertyOrderByField = "OrderByField";
        private const string PropertyGanttImages = "GanttImages";
        private const string PropertyGroupByFields = "GroupByFields";
        private const string PropertyLinkTitleNoMenu = "LinkTitleNoMenu";
        private const string PropertyRollupLists = "RollupLists";
        private const string PropertyRollupSites = "RollupSites";
        private const string PropertyFilterByFields = "FilterByFields";
        private const string PropertyGanttStart = "GanttStart";
        private const string PropertyGanttFinish = "GanttFinish";
        private const string PropertyGanttMilestone = "GanttMilestone";
        private const string PropertyGanttStartField = "GanttStartField";
        private const string PropertyGanttFinishField = "GanttFinishField";
        private const string PropertyPctComplete = "PctComplete";
        private const string PropertyWBS = "WBS";
        private const string PropertyUseCurrent = "UseCurrent";
        private const string PropertyList = "List";
        private const string PropertyView = "View";
        private const string PropertyGanttParams64bitString = "GanttParams64bitString";
        private const string PropertyGanttParams = "GanttParams";
        private const string MethodGetListID = "GetListID";
        private const string MethodUsePopup = "UsePopup";
        private const string MethodGetAction = "GetAction";
        private const string MethodGetGridColumns = "GetGridColumns";
        private const string MethodGetGridFields = "GetGridFields";
        private const string MethodformatGridField = "formatGridField";
        private const string MethodGetInternalName = "GetInternalName";
        private const string MethodGetOrderByField = "GetOrderByField";
        private const string MethodInitRoutine = "InitRoutine";
        private const string MethodConvertXmlToDatatable = "ConvertXmlToDatatable";
        private const string MethodInitGanttParams = "InitGanttParams";
        private const string MethodInitializeGanttStartAndFinish = "InitializeGanttStartAndFinish";
        private const string MethodGetDisplayName = "GetDisplayName";
        private const string MethodGetStartDate = "GetStartDate";
        private const string MethodGetFinishDate = "GetFinishDate";
        private const string MethodFinalizeData = "FinalizeData";
        private const string MethodAddRowHierarchy = "AddRowHierarchy";
        private const string MethodGetPredecessors = "GetPredecessors";
        private const string MethodGetTaskId = "GetTaskId";
        private const string MethodGetLinkType = "GetLinkType";
        private const string MethodAddRowPredecessors = "AddRowPredecessors";
        private const string MethodInitializeReqdFields = "InitializeReqdFields";
        private const string MethodAddReqdFieldsToView = "AddReqdFieldsToView";
        private const string MethodRemoveReqdFieldsFromView = "RemoveReqdFieldsFromView";
        private const string MethodInitializeColumnDefs = "InitializeColumnDefs";
        private const string MethodLoadData = "LoadData";
        private const string MethodProcessNode = "ProcessNode";
        private const string MethodAddColumns = "AddColumns";
        private const string MethodPopulateFieldValues = "PopulateFieldValues";
        private const string MethodPopulateViewFieldValues = "PopulateViewFieldValues";
        private const string MethodPopulateDefaultFieldValues = "PopulateDefaultFieldValues";
        private const string MethodPopulateGanttStartAndDates = "PopulateGanttStartAndDates";
        private const string MethodCalcPercentComplete = "CalcPercentComplete";
        private const string MethodGetGanttStartDate = "GetGanttStartDate";
        private const string MethodGetGanttFinishDate = "GetGanttFinishDate";
        private const string MethodApplyGanttStyle = "ApplyGanttStyle";
        private const string MethodApplyGanttStyles = "ApplyGanttStyles";
        private const string MethodGetNodeByName = "GetNodeByName";
        private const string MethodProcessChildRows = "ProcessChildRows";
        private const string MethodIsHyperLink = "IsHyperLink";
        private const string MethodInitViewFieldNames = "InitViewFieldNames";
        private const string MethodGetDupFieldName = "GetDupFieldName";
        private const string MethodRemoveNonViewFields = "RemoveNonViewFields";
        private const string FieldarrAggregationDef = "arrAggregationDef";
        private const string Field_spList = "_spList";
        private const string Field_spView = "_spView";
        private const string Field_columnDefinitions = "_columnDefinitions";
        private const string Field_xmlDoc = "_xmlDoc";
        private const string Field_rand = "_rand";
        private const string Field_htGanttParams = "_htGanttParams";
        private const string Field_htNodeData = "_htNodeData";
        private const string Field_htImages = "_htImages";
        private const string Field_globalIndex = "_globalIndex";
        private const string Field_fieldNames = "_fieldNames";
        private const string Field_images = "_images";
        private const string Field_imageColumns = "_imageColumns";
        private const string Field_fieldsAddedToView = "_fieldsAddedToView";
        private const string Field_reqdfields = "_reqdfields";
        private const string Field_useCurrent = "_useCurrent";
        private const string Field_wbs = "_wbs";
        private const string Field_ganttStartField = "_ganttStartField";
        private const string Field_ganttFinishField = "_ganttFinishField";
        private const string Field_ganttMilestone = "_ganttMilestone";
        private const string Field_pctComplete = "_pctComplete";
        private const string Field_linkTitle = "_linkTitle";
        private const string Field_workspaceUrl = "_workspaceUrl";
        private const string Field_assignedTo = "_assignedTo";
        private const string Field_linkTitleNoMenu = "_linkTitleNoMenu";
        private const string Field_linkTitleColumnName = "_linkTitleColumnName";
        private const string Field_linkTitleNoMenuColumnName = "_linkTitleNoMenuColumnName";
        private const string Field_orderByField = "_orderByField";
        private const string Field_imagesClientSide = "_imagesClientSide";
        private const string Field_ganttParams64bit = "_ganttParams64bit";
        private const string Field_rollupLists = "_rollupLists";
        private const string Field_rollupSites = "_rollupSites";
        private const string Field_filterByFields = "_filterByFields";
        private const string Field_groupByFields = "_groupByFields";
        private const string Field_ganttStartDate = "_ganttStartDate";
        private const string Field_ganttFinishDate = "_ganttFinishDate";
        private const string Field_spvwFields = "_spvwFields";
        private const string FieldhshMenus = "hshMenus";
        private Type _gridDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private GridData _gridDataInstance;
        private GridData _gridDataInstanceFixture;

        #region General Initializer : Class (GridData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GridData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _gridDataInstanceType = typeof(GridData);
            _gridDataInstanceFixture = Create(true);
            _gridDataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GridData)

        #region General Initializer : Class (GridData) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="GridData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetListID, 0)]
        [TestCase(MethodUsePopup, 0)]
        [TestCase(MethodGetAction, 0)]
        [TestCase(MethodGetGridColumns, 0)]
        [TestCase(MethodGetGridFields, 0)]
        [TestCase(MethodformatGridField, 0)]
        [TestCase(MethodGetInternalName, 0)]
        [TestCase(MethodGetOrderByField, 0)]
        [TestCase(MethodInitRoutine, 0)]
        [TestCase(MethodConvertXmlToDatatable, 0)]
        [TestCase(MethodInitGanttParams, 0)]
        [TestCase(MethodInitializeGanttStartAndFinish, 0)]
        [TestCase(MethodGetDisplayName, 0)]
        [TestCase(MethodGetStartDate, 0)]
        [TestCase(MethodGetFinishDate, 0)]
        [TestCase(MethodFinalizeData, 0)]
        [TestCase(MethodAddRowHierarchy, 0)]
        [TestCase(MethodGetPredecessors, 0)]
        [TestCase(MethodGetTaskId, 0)]
        [TestCase(MethodGetLinkType, 0)]
        [TestCase(MethodAddRowPredecessors, 0)]
        [TestCase(MethodInitializeReqdFields, 0)]
        [TestCase(MethodAddReqdFieldsToView, 0)]
        [TestCase(MethodRemoveReqdFieldsFromView, 0)]
        [TestCase(MethodInitializeColumnDefs, 0)]
        [TestCase(MethodLoadData, 0)]
        [TestCase(MethodProcessNode, 0)]
        [TestCase(MethodAddColumns, 0)]
        [TestCase(MethodPopulateFieldValues, 0)]
        [TestCase(MethodPopulateViewFieldValues, 0)]
        [TestCase(MethodPopulateDefaultFieldValues, 0)]
        [TestCase(MethodPopulateGanttStartAndDates, 0)]
        [TestCase(MethodCalcPercentComplete, 0)]
        [TestCase(MethodGetGanttStartDate, 0)]
        [TestCase(MethodGetGanttFinishDate, 0)]
        [TestCase(MethodApplyGanttStyle, 0)]
        [TestCase(MethodApplyGanttStyles, 0)]
        [TestCase(MethodGetNodeByName, 0)]
        [TestCase(MethodProcessChildRows, 0)]
        [TestCase(MethodIsHyperLink, 0)]
        [TestCase(MethodInitViewFieldNames, 0)]
        [TestCase(MethodGetDupFieldName, 0)]
        [TestCase(MethodRemoveNonViewFields, 0)]
        [TestCase(MethodInitGanttParams, 1)]
        public void AUT_GridData_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_gridDataInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GridData) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="GridData" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyViewFields)]
        [TestCase(PropertyLinkTitle)]
        [TestCase(PropertyWorkspaceUrl)]
        [TestCase(PropertyAssignedTo)]
        [TestCase(PropertyImages)]
        [TestCase(PropertyImageNames)]
        [TestCase(PropertyOrderByField)]
        [TestCase(PropertyGanttImages)]
        [TestCase(PropertyGroupByFields)]
        [TestCase(PropertyLinkTitleNoMenu)]
        [TestCase(PropertyRollupLists)]
        [TestCase(PropertyRollupSites)]
        [TestCase(PropertyFilterByFields)]
        [TestCase(PropertyGanttStart)]
        [TestCase(PropertyGanttFinish)]
        [TestCase(PropertyGanttMilestone)]
        [TestCase(PropertyGanttStartField)]
        [TestCase(PropertyGanttFinishField)]
        [TestCase(PropertyPctComplete)]
        [TestCase(PropertyWBS)]
        [TestCase(PropertyUseCurrent)]
        [TestCase(PropertyList)]
        [TestCase(PropertyView)]
        [TestCase(PropertyGanttParams64bitString)]
        [TestCase(PropertyGanttParams)]
        public void AUT_GridData_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_gridDataInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GridData) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="GridData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldarrAggregationDef)]
        [TestCase(Field_spList)]
        [TestCase(Field_spView)]
        [TestCase(Field_columnDefinitions)]
        [TestCase(Field_xmlDoc)]
        [TestCase(Field_rand)]
        [TestCase(Field_htGanttParams)]
        [TestCase(Field_htNodeData)]
        [TestCase(Field_htImages)]
        [TestCase(Field_globalIndex)]
        [TestCase(Field_fieldNames)]
        [TestCase(Field_images)]
        [TestCase(Field_imageColumns)]
        [TestCase(Field_fieldsAddedToView)]
        [TestCase(Field_reqdfields)]
        [TestCase(Field_useCurrent)]
        [TestCase(Field_wbs)]
        [TestCase(Field_ganttStartField)]
        [TestCase(Field_ganttFinishField)]
        [TestCase(Field_ganttMilestone)]
        [TestCase(Field_pctComplete)]
        [TestCase(Field_linkTitle)]
        [TestCase(Field_workspaceUrl)]
        [TestCase(Field_assignedTo)]
        [TestCase(Field_linkTitleNoMenu)]
        [TestCase(Field_linkTitleColumnName)]
        [TestCase(Field_linkTitleNoMenuColumnName)]
        [TestCase(Field_orderByField)]
        [TestCase(Field_imagesClientSide)]
        [TestCase(Field_ganttParams64bit)]
        [TestCase(Field_rollupLists)]
        [TestCase(Field_rollupSites)]
        [TestCase(Field_filterByFields)]
        [TestCase(Field_groupByFields)]
        [TestCase(Field_ganttStartDate)]
        [TestCase(Field_ganttFinishDate)]
        [TestCase(Field_spvwFields)]
        [TestCase(FieldhshMenus)]
        public void AUT_GridData_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_gridDataInstanceFixture, 
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
        ///     Class (<see cref="GridData" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_GridData_Is_Instance_Present_Test()
        {
            // Assert
            _gridDataInstanceType.ShouldNotBeNull();
            _gridDataInstance.ShouldNotBeNull();
            _gridDataInstanceFixture.ShouldNotBeNull();
            _gridDataInstance.ShouldBeAssignableTo<GridData>();
            _gridDataInstanceFixture.ShouldBeAssignableTo<GridData>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (GridData) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_GridData_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            GridData instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _gridDataInstanceType.ShouldNotBeNull();
            _gridDataInstance.ShouldNotBeNull();
            _gridDataInstanceFixture.ShouldNotBeNull();
            _gridDataInstance.ShouldBeAssignableTo<GridData>();
            _gridDataInstanceFixture.ShouldBeAssignableTo<GridData>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (GridData) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Collections.Specialized.StringCollection) , PropertyViewFields)]
        [TestCaseGeneric(typeof(string) , PropertyLinkTitle)]
        [TestCaseGeneric(typeof(string) , PropertyWorkspaceUrl)]
        [TestCaseGeneric(typeof(string) , PropertyAssignedTo)]
        [TestCaseGeneric(typeof(string) , PropertyImages)]
        [TestCaseGeneric(typeof(List<string>) , PropertyImageNames)]
        [TestCaseGeneric(typeof(string) , PropertyOrderByField)]
        [TestCaseGeneric(typeof(Hashtable) , PropertyGanttImages)]
        [TestCaseGeneric(typeof(string[]) , PropertyGroupByFields)]
        [TestCaseGeneric(typeof(string) , PropertyLinkTitleNoMenu)]
        [TestCaseGeneric(typeof(string[]) , PropertyRollupLists)]
        [TestCaseGeneric(typeof(string[]) , PropertyRollupSites)]
        [TestCaseGeneric(typeof(string[]) , PropertyFilterByFields)]
        [TestCaseGeneric(typeof(DateTime) , PropertyGanttStart)]
        [TestCaseGeneric(typeof(DateTime) , PropertyGanttFinish)]
        [TestCaseGeneric(typeof(string) , PropertyGanttMilestone)]
        [TestCaseGeneric(typeof(string) , PropertyGanttStartField)]
        [TestCaseGeneric(typeof(string) , PropertyGanttFinishField)]
        [TestCaseGeneric(typeof(string) , PropertyPctComplete)]
        [TestCaseGeneric(typeof(string) , PropertyWBS)]
        [TestCaseGeneric(typeof(bool) , PropertyUseCurrent)]
        [TestCaseGeneric(typeof(SPList) , PropertyList)]
        [TestCaseGeneric(typeof(SPView) , PropertyView)]
        [TestCaseGeneric(typeof(string) , PropertyGanttParams64bitString)]
        [TestCaseGeneric(typeof(Hashtable) , PropertyGanttParams)]
        public void AUT_GridData_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<GridData, T>(_gridDataInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (AssignedTo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_AssignedTo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAssignedTo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (FilterByFields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_FilterByFields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyFilterByFields);
            Action currentAction = () => propertyInfo.SetValue(_gridDataInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (FilterByFields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_FilterByFields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyFilterByFields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (GanttFinish) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_GanttFinish_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyGanttFinish);
            Action currentAction = () => propertyInfo.SetValue(_gridDataInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (GanttFinish) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_GanttFinish_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyGanttFinish);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (GanttFinishField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_GanttFinishField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyGanttFinishField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (GanttImages) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_GanttImages_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyGanttImages);
            Action currentAction = () => propertyInfo.SetValue(_gridDataInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (GanttImages) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_GanttImages_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyGanttImages);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (GanttMilestone) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_GanttMilestone_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyGanttMilestone);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (GanttParams) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_GanttParams_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyGanttParams);
            Action currentAction = () => propertyInfo.SetValue(_gridDataInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (GanttParams) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_GanttParams_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyGanttParams);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (GanttParams64bitString) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_GanttParams64bitString_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyGanttParams64bitString);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (GanttStart) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_GanttStart_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyGanttStart);
            Action currentAction = () => propertyInfo.SetValue(_gridDataInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (GanttStart) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_GanttStart_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyGanttStart);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (GanttStartField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_GanttStartField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyGanttStartField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (GroupByFields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_GroupByFields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyGroupByFields);
            Action currentAction = () => propertyInfo.SetValue(_gridDataInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (GroupByFields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_GroupByFields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyGroupByFields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (ImageNames) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_ImageNames_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyImageNames);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (Images) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_Images_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyImages);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (LinkTitle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_LinkTitle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLinkTitle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (LinkTitleNoMenu) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_LinkTitleNoMenu_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLinkTitleNoMenu);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (List) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_List_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyList);
            Action currentAction = () => propertyInfo.SetValue(_gridDataInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (List) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_List_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyList);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (OrderByField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_OrderByField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyOrderByField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (PctComplete) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_PctComplete_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPctComplete);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (RollupLists) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_RollupLists_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyRollupLists);
            Action currentAction = () => propertyInfo.SetValue(_gridDataInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (RollupLists) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_RollupLists_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyRollupLists);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (RollupSites) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_RollupSites_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyRollupSites);
            Action currentAction = () => propertyInfo.SetValue(_gridDataInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (RollupSites) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_RollupSites_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyRollupSites);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (UseCurrent) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_UseCurrent_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUseCurrent);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (View) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_View_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyView);
            Action currentAction = () => propertyInfo.SetValue(_gridDataInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (View) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_View_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyView);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (ViewFields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_ViewFields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyViewFields);
            Action currentAction = () => propertyInfo.SetValue(_gridDataInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (ViewFields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_ViewFields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyViewFields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (WBS) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_WBS_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWBS);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridData) => Property (WorkspaceUrl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridData_Public_Class_WorkspaceUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWorkspaceUrl);

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

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="GridData" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetListID)]
        public void AUT_GridData_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_gridDataInstanceFixture,
                                                                              _gridDataInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="GridData" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodUsePopup)]
        [TestCase(MethodGetAction)]
        [TestCase(MethodGetGridColumns)]
        [TestCase(MethodGetGridFields)]
        [TestCase(MethodformatGridField)]
        [TestCase(MethodGetInternalName)]
        [TestCase(MethodGetOrderByField)]
        [TestCase(MethodInitRoutine)]
        [TestCase(MethodConvertXmlToDatatable)]
        [TestCase(MethodInitGanttParams)]
        [TestCase(MethodInitializeGanttStartAndFinish)]
        [TestCase(MethodGetDisplayName)]
        [TestCase(MethodGetStartDate)]
        [TestCase(MethodGetFinishDate)]
        [TestCase(MethodFinalizeData)]
        [TestCase(MethodAddRowHierarchy)]
        [TestCase(MethodGetPredecessors)]
        [TestCase(MethodGetTaskId)]
        [TestCase(MethodGetLinkType)]
        [TestCase(MethodAddRowPredecessors)]
        [TestCase(MethodInitializeReqdFields)]
        [TestCase(MethodAddReqdFieldsToView)]
        [TestCase(MethodRemoveReqdFieldsFromView)]
        [TestCase(MethodInitializeColumnDefs)]
        [TestCase(MethodLoadData)]
        [TestCase(MethodProcessNode)]
        [TestCase(MethodAddColumns)]
        [TestCase(MethodPopulateFieldValues)]
        [TestCase(MethodPopulateViewFieldValues)]
        [TestCase(MethodPopulateDefaultFieldValues)]
        [TestCase(MethodPopulateGanttStartAndDates)]
        [TestCase(MethodCalcPercentComplete)]
        [TestCase(MethodGetGanttStartDate)]
        [TestCase(MethodGetGanttFinishDate)]
        [TestCase(MethodApplyGanttStyle)]
        [TestCase(MethodApplyGanttStyles)]
        [TestCase(MethodGetNodeByName)]
        [TestCase(MethodProcessChildRows)]
        [TestCase(MethodIsHyperLink)]
        [TestCase(MethodInitViewFieldNames)]
        [TestCase(MethodGetDupFieldName)]
        [TestCase(MethodRemoveNonViewFields)]
        public void AUT_GridData_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<GridData>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetListID) (Return Type : Guid) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_GetListID_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetListIDPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_gridDataInstanceFixture, _gridDataInstanceType, MethodGetListID, Fixture, methodGetListIDPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListID) (Return Type : Guid) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetListID_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webid = CreateType<Guid>();
            var listname = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => GridData.GetListID(siteId, webid, listname);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetListID) (Return Type : Guid) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetListID_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webid = CreateType<Guid>();
            var listname = CreateType<string>();
            var methodGetListIDPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfGetListID = { siteId, webid, listname };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListID, methodGetListIDPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_gridDataInstanceFixture, _gridDataInstanceType, MethodGetListID, Fixture, methodGetListIDPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Guid>(_gridDataInstanceFixture, _gridDataInstanceType, MethodGetListID, parametersOfGetListID, methodGetListIDPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetListID.ShouldNotBeNull();
            parametersOfGetListID.Length.ShouldBe(3);
            methodGetListIDPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Guid>(_gridDataInstanceFixture, _gridDataInstanceType, MethodGetListID, parametersOfGetListID, methodGetListIDPrametersTypes));
        }

        #endregion

        #region Method Call : (GetListID) (Return Type : Guid) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetListID_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webid = CreateType<Guid>();
            var listname = CreateType<string>();
            var methodGetListIDPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfGetListID = { siteId, webid, listname };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetListID, methodGetListIDPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfGetListID);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetListID.ShouldNotBeNull();
            parametersOfGetListID.Length.ShouldBe(3);
            methodGetListIDPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListID) (Return Type : Guid) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetListID_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webid = CreateType<Guid>();
            var listname = CreateType<string>();
            var methodGetListIDPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfGetListID = { siteId, webid, listname };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<Guid>(_gridDataInstanceFixture, _gridDataInstanceType, MethodGetListID, parametersOfGetListID, methodGetListIDPrametersTypes);

            // Assert
            parametersOfGetListID.ShouldNotBeNull();
            parametersOfGetListID.Length.ShouldBe(3);
            methodGetListIDPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListID) (Return Type : Guid) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetListID_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetListIDPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_gridDataInstanceFixture, _gridDataInstanceType, MethodGetListID, Fixture, methodGetListIDPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetListIDPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetListID) (Return Type : Guid) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetListID_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListIDPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_gridDataInstanceFixture, _gridDataInstanceType, MethodGetListID, Fixture, methodGetListIDPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListIDPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListID) (Return Type : Guid) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetListID_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListID, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetListID) (Return Type : Guid) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetListID_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListID, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UsePopup) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_UsePopup_Method_Call_Internally(Type[] types)
        {
            var methodUsePopupPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodUsePopup, Fixture, methodUsePopupPrametersTypes);
        }

        #endregion

        #region Method Call : (UsePopup) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_UsePopup_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _gridDataInstance.UsePopup();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UsePopup) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_UsePopup_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodUsePopupPrametersTypes = null;
            object[] parametersOfUsePopup = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUsePopup, methodUsePopupPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridData, string>(_gridDataInstanceFixture, out exception1, parametersOfUsePopup);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridData, string>(_gridDataInstance, MethodUsePopup, parametersOfUsePopup, methodUsePopupPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUsePopup.ShouldBeNull();
            methodUsePopupPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UsePopup) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_UsePopup_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodUsePopupPrametersTypes = null;
            object[] parametersOfUsePopup = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridData, string>(_gridDataInstance, MethodUsePopup, parametersOfUsePopup, methodUsePopupPrametersTypes);

            // Assert
            parametersOfUsePopup.ShouldBeNull();
            methodUsePopupPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UsePopup) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_UsePopup_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodUsePopupPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodUsePopup, Fixture, methodUsePopupPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUsePopupPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UsePopup) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_UsePopup_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodUsePopupPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodUsePopup, Fixture, methodUsePopupPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUsePopupPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UsePopup) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_UsePopup_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUsePopup, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAction) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_GetAction_Method_Call_Internally(Type[] types)
        {
            var methodGetActionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetAction, Fixture, methodGetActionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAction) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetAction_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _gridDataInstance.GetAction();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetAction) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetAction_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetActionPrametersTypes = null;
            object[] parametersOfGetAction = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAction, methodGetActionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridData, string>(_gridDataInstanceFixture, out exception1, parametersOfGetAction);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridData, string>(_gridDataInstance, MethodGetAction, parametersOfGetAction, methodGetActionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetAction.ShouldBeNull();
            methodGetActionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAction) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetAction_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetActionPrametersTypes = null;
            object[] parametersOfGetAction = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridData, string>(_gridDataInstance, MethodGetAction, parametersOfGetAction, methodGetActionPrametersTypes);

            // Assert
            parametersOfGetAction.ShouldBeNull();
            methodGetActionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAction) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetAction_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetActionPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetAction, Fixture, methodGetActionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetActionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAction) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetAction_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetActionPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetAction, Fixture, methodGetActionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetActionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAction) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetAction_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAction, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGridColumns) (Return Type : IList<GridColumn>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_GetGridColumns_Method_Call_Internally(Type[] types)
        {
            var methodGetGridColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetGridColumns, Fixture, methodGetGridColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGridColumns) (Return Type : IList<GridColumn>) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGridColumns_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var table = CreateType<DataTable>();
            Action executeAction = null;

            // Act
            executeAction = () => _gridDataInstance.GetGridColumns(table);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetGridColumns) (Return Type : IList<GridColumn>) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGridColumns_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var table = CreateType<DataTable>();
            var methodGetGridColumnsPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfGetGridColumns = { table };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetGridColumns, methodGetGridColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridData, IList<GridColumn>>(_gridDataInstanceFixture, out exception1, parametersOfGetGridColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridData, IList<GridColumn>>(_gridDataInstance, MethodGetGridColumns, parametersOfGetGridColumns, methodGetGridColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetGridColumns.ShouldNotBeNull();
            parametersOfGetGridColumns.Length.ShouldBe(1);
            methodGetGridColumnsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetGridColumns) (Return Type : IList<GridColumn>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGridColumns_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var table = CreateType<DataTable>();
            var methodGetGridColumnsPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfGetGridColumns = { table };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetGridColumns, methodGetGridColumnsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfGetGridColumns);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetGridColumns.ShouldNotBeNull();
            parametersOfGetGridColumns.Length.ShouldBe(1);
            methodGetGridColumnsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGridColumns) (Return Type : IList<GridColumn>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGridColumns_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var table = CreateType<DataTable>();
            var methodGetGridColumnsPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfGetGridColumns = { table };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridData, IList<GridColumn>>(_gridDataInstance, MethodGetGridColumns, parametersOfGetGridColumns, methodGetGridColumnsPrametersTypes);

            // Assert
            parametersOfGetGridColumns.ShouldNotBeNull();
            parametersOfGetGridColumns.Length.ShouldBe(1);
            methodGetGridColumnsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGridColumns) (Return Type : IList<GridColumn>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGridColumns_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetGridColumnsPrametersTypes = new Type[] { typeof(DataTable) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetGridColumns, Fixture, methodGetGridColumnsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetGridColumnsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetGridColumns) (Return Type : IList<GridColumn>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGridColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetGridColumnsPrametersTypes = new Type[] { typeof(DataTable) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetGridColumns, Fixture, methodGetGridColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGridColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGridColumns) (Return Type : IList<GridColumn>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGridColumns_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGridColumns, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGridColumns) (Return Type : IList<GridColumn>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGridColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetGridColumns, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGridFields) (Return Type : IList<GridField>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_GetGridFields_Method_Call_Internally(Type[] types)
        {
            var methodGetGridFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetGridFields, Fixture, methodGetGridFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGridFields) (Return Type : IList<GridField>) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGridFields_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var table = CreateType<DataTable>();
            Action executeAction = null;

            // Act
            executeAction = () => _gridDataInstance.GetGridFields(table);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetGridFields) (Return Type : IList<GridField>) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGridFields_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var table = CreateType<DataTable>();
            var methodGetGridFieldsPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfGetGridFields = { table };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetGridFields, methodGetGridFieldsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridData, IList<GridField>>(_gridDataInstanceFixture, out exception1, parametersOfGetGridFields);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridData, IList<GridField>>(_gridDataInstance, MethodGetGridFields, parametersOfGetGridFields, methodGetGridFieldsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetGridFields.ShouldNotBeNull();
            parametersOfGetGridFields.Length.ShouldBe(1);
            methodGetGridFieldsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetGridFields) (Return Type : IList<GridField>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGridFields_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var table = CreateType<DataTable>();
            var methodGetGridFieldsPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfGetGridFields = { table };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetGridFields, methodGetGridFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfGetGridFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetGridFields.ShouldNotBeNull();
            parametersOfGetGridFields.Length.ShouldBe(1);
            methodGetGridFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGridFields) (Return Type : IList<GridField>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGridFields_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var table = CreateType<DataTable>();
            var methodGetGridFieldsPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfGetGridFields = { table };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridData, IList<GridField>>(_gridDataInstance, MethodGetGridFields, parametersOfGetGridFields, methodGetGridFieldsPrametersTypes);

            // Assert
            parametersOfGetGridFields.ShouldNotBeNull();
            parametersOfGetGridFields.Length.ShouldBe(1);
            methodGetGridFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGridFields) (Return Type : IList<GridField>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGridFields_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetGridFieldsPrametersTypes = new Type[] { typeof(DataTable) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetGridFields, Fixture, methodGetGridFieldsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetGridFieldsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetGridFields) (Return Type : IList<GridField>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGridFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetGridFieldsPrametersTypes = new Type[] { typeof(DataTable) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetGridFields, Fixture, methodGetGridFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGridFieldsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGridFields) (Return Type : IList<GridField>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGridFields_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGridFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGridFields) (Return Type : IList<GridField>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGridFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetGridFields, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (formatGridField) (Return Type : GridField) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_formatGridField_Method_Call_Internally(Type[] types)
        {
            var methodformatGridFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodformatGridField, Fixture, methodformatGridFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (formatGridField) (Return Type : GridField) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_formatGridField_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var gf = CreateType<GridField>();
            var dc = CreateType<DataColumn>();
            var methodformatGridFieldPrametersTypes = new Type[] { typeof(GridField), typeof(DataColumn) };
            object[] parametersOfformatGridField = { gf, dc };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridData, GridField>(_gridDataInstance, MethodformatGridField, parametersOfformatGridField, methodformatGridFieldPrametersTypes);

            // Assert
            parametersOfformatGridField.ShouldNotBeNull();
            parametersOfformatGridField.Length.ShouldBe(2);
            methodformatGridFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (formatGridField) (Return Type : GridField) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_formatGridField_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodformatGridFieldPrametersTypes = new Type[] { typeof(GridField), typeof(DataColumn) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodformatGridField, Fixture, methodformatGridFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodformatGridFieldPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (formatGridField) (Return Type : GridField) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_formatGridField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodformatGridFieldPrametersTypes = new Type[] { typeof(GridField), typeof(DataColumn) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodformatGridField, Fixture, methodformatGridFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodformatGridFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (formatGridField) (Return Type : GridField) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_formatGridField_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodformatGridField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (formatGridField) (Return Type : GridField) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_formatGridField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodformatGridField, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetInternalName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_GetInternalName_Method_Call_Internally(Type[] types)
        {
            var methodGetInternalNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetInternalName, Fixture, methodGetInternalNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetInternalName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetInternalName_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var displayName = CreateType<string>();
            var methodGetInternalNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetInternalName = { displayName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetInternalName, methodGetInternalNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfGetInternalName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetInternalName.ShouldNotBeNull();
            parametersOfGetInternalName.Length.ShouldBe(1);
            methodGetInternalNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetInternalName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetInternalName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var displayName = CreateType<string>();
            var methodGetInternalNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetInternalName = { displayName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridData, string>(_gridDataInstance, MethodGetInternalName, parametersOfGetInternalName, methodGetInternalNamePrametersTypes);

            // Assert
            parametersOfGetInternalName.ShouldNotBeNull();
            parametersOfGetInternalName.Length.ShouldBe(1);
            methodGetInternalNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetInternalName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetInternalName_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetInternalNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetInternalName, Fixture, methodGetInternalNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetInternalNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetInternalName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetInternalName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetInternalNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetInternalName, Fixture, methodGetInternalNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetInternalNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetInternalName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetInternalName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetInternalName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetInternalName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetInternalName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetInternalName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetOrderByField) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_GetOrderByField_Method_Call_Internally(Type[] types)
        {
            var methodGetOrderByFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetOrderByField, Fixture, methodGetOrderByFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (GetOrderByField) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetOrderByField_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetOrderByFieldPrametersTypes = null;
            object[] parametersOfGetOrderByField = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetOrderByField, methodGetOrderByFieldPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridData, string>(_gridDataInstanceFixture, out exception1, parametersOfGetOrderByField);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridData, string>(_gridDataInstance, MethodGetOrderByField, parametersOfGetOrderByField, methodGetOrderByFieldPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetOrderByField.ShouldBeNull();
            methodGetOrderByFieldPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetOrderByField) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetOrderByField_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetOrderByFieldPrametersTypes = null;
            object[] parametersOfGetOrderByField = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetOrderByField, methodGetOrderByFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfGetOrderByField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetOrderByField.ShouldBeNull();
            methodGetOrderByFieldPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetOrderByField) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetOrderByField_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetOrderByFieldPrametersTypes = null;
            object[] parametersOfGetOrderByField = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridData, string>(_gridDataInstance, MethodGetOrderByField, parametersOfGetOrderByField, methodGetOrderByFieldPrametersTypes);

            // Assert
            parametersOfGetOrderByField.ShouldBeNull();
            methodGetOrderByFieldPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetOrderByField) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetOrderByField_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetOrderByFieldPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetOrderByField, Fixture, methodGetOrderByFieldPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetOrderByFieldPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetOrderByField) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetOrderByField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetOrderByFieldPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetOrderByField, Fixture, methodGetOrderByFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetOrderByFieldPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetOrderByField) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetOrderByField_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetOrderByField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (InitRoutine) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_InitRoutine_Method_Call_Internally(Type[] types)
        {
            var methodInitRoutinePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodInitRoutine, Fixture, methodInitRoutinePrametersTypes);
        }

        #endregion

        #region Method Call : (InitRoutine) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitRoutine_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var isRollup = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _gridDataInstance.InitRoutine(out isRollup);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (InitRoutine) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitRoutine_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var isRollup = CreateType<bool>();
            var methodInitRoutinePrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfInitRoutine = { isRollup };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitRoutine, methodInitRoutinePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfInitRoutine);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitRoutine.ShouldNotBeNull();
            parametersOfInitRoutine.Length.ShouldBe(1);
            methodInitRoutinePrametersTypes.Length.ShouldBe(1);
            methodInitRoutinePrametersTypes.Length.ShouldBe(parametersOfInitRoutine.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitRoutine) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitRoutine_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var isRollup = CreateType<bool>();
            var methodInitRoutinePrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfInitRoutine = { isRollup };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridDataInstance, MethodInitRoutine, parametersOfInitRoutine, methodInitRoutinePrametersTypes);

            // Assert
            parametersOfInitRoutine.ShouldNotBeNull();
            parametersOfInitRoutine.Length.ShouldBe(1);
            methodInitRoutinePrametersTypes.Length.ShouldBe(1);
            methodInitRoutinePrametersTypes.Length.ShouldBe(parametersOfInitRoutine.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitRoutine) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitRoutine_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInitRoutine, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitRoutine) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitRoutine_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitRoutinePrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodInitRoutine, Fixture, methodInitRoutinePrametersTypes);

            // Assert
            methodInitRoutinePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitRoutine) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitRoutine_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitRoutine, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertXmlToDatatable) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_ConvertXmlToDatatable_Method_Call_Internally(Type[] types)
        {
            var methodConvertXmlToDatatablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodConvertXmlToDatatable, Fixture, methodConvertXmlToDatatablePrametersTypes);
        }

        #endregion

        #region Method Call : (ConvertXmlToDatatable) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ConvertXmlToDatatable_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodConvertXmlToDatatablePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfConvertXmlToDatatable = { xml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodConvertXmlToDatatable, methodConvertXmlToDatatablePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridData, DataTable>(_gridDataInstanceFixture, out exception1, parametersOfConvertXmlToDatatable);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridData, DataTable>(_gridDataInstance, MethodConvertXmlToDatatable, parametersOfConvertXmlToDatatable, methodConvertXmlToDatatablePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfConvertXmlToDatatable.ShouldNotBeNull();
            parametersOfConvertXmlToDatatable.Length.ShouldBe(1);
            methodConvertXmlToDatatablePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ConvertXmlToDatatable) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ConvertXmlToDatatable_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodConvertXmlToDatatablePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfConvertXmlToDatatable = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridData, DataTable>(_gridDataInstance, MethodConvertXmlToDatatable, parametersOfConvertXmlToDatatable, methodConvertXmlToDatatablePrametersTypes);

            // Assert
            parametersOfConvertXmlToDatatable.ShouldNotBeNull();
            parametersOfConvertXmlToDatatable.Length.ShouldBe(1);
            methodConvertXmlToDatatablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertXmlToDatatable) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ConvertXmlToDatatable_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodConvertXmlToDatatablePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodConvertXmlToDatatable, Fixture, methodConvertXmlToDatatablePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodConvertXmlToDatatablePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ConvertXmlToDatatable) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ConvertXmlToDatatable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodConvertXmlToDatatablePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodConvertXmlToDatatable, Fixture, methodConvertXmlToDatatablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodConvertXmlToDatatablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvertXmlToDatatable) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ConvertXmlToDatatable_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvertXmlToDatatable, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ConvertXmlToDatatable) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ConvertXmlToDatatable_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodConvertXmlToDatatable, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitGanttParams) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_InitGanttParams_Method_Call_Internally(Type[] types)
        {
            var methodInitGanttParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodInitGanttParams, Fixture, methodInitGanttParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (InitGanttParams) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitGanttParams_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitGanttParamsPrametersTypes = null;
            object[] parametersOfInitGanttParams = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitGanttParams, methodInitGanttParamsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfInitGanttParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitGanttParams.ShouldBeNull();
            methodInitGanttParamsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitGanttParams) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitGanttParams_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitGanttParamsPrametersTypes = null;
            object[] parametersOfInitGanttParams = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridDataInstance, MethodInitGanttParams, parametersOfInitGanttParams, methodInitGanttParamsPrametersTypes);

            // Assert
            parametersOfInitGanttParams.ShouldBeNull();
            methodInitGanttParamsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitGanttParams) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitGanttParams_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitGanttParamsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodInitGanttParams, Fixture, methodInitGanttParamsPrametersTypes);

            // Assert
            methodInitGanttParamsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitGanttParams) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitGanttParams_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitGanttParams, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeGanttStartAndFinish) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_InitializeGanttStartAndFinish_Method_Call_Internally(Type[] types)
        {
            var methodInitializeGanttStartAndFinishPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodInitializeGanttStartAndFinish, Fixture, methodInitializeGanttStartAndFinishPrametersTypes);
        }

        #endregion

        #region Method Call : (InitializeGanttStartAndFinish) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitializeGanttStartAndFinish_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var methodInitializeGanttStartAndFinishPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfInitializeGanttStartAndFinish = { dt };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitializeGanttStartAndFinish, methodInitializeGanttStartAndFinishPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfInitializeGanttStartAndFinish);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitializeGanttStartAndFinish.ShouldNotBeNull();
            parametersOfInitializeGanttStartAndFinish.Length.ShouldBe(1);
            methodInitializeGanttStartAndFinishPrametersTypes.Length.ShouldBe(1);
            methodInitializeGanttStartAndFinishPrametersTypes.Length.ShouldBe(parametersOfInitializeGanttStartAndFinish.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeGanttStartAndFinish) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitializeGanttStartAndFinish_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var methodInitializeGanttStartAndFinishPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfInitializeGanttStartAndFinish = { dt };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridDataInstance, MethodInitializeGanttStartAndFinish, parametersOfInitializeGanttStartAndFinish, methodInitializeGanttStartAndFinishPrametersTypes);

            // Assert
            parametersOfInitializeGanttStartAndFinish.ShouldNotBeNull();
            parametersOfInitializeGanttStartAndFinish.Length.ShouldBe(1);
            methodInitializeGanttStartAndFinishPrametersTypes.Length.ShouldBe(1);
            methodInitializeGanttStartAndFinishPrametersTypes.Length.ShouldBe(parametersOfInitializeGanttStartAndFinish.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeGanttStartAndFinish) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitializeGanttStartAndFinish_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInitializeGanttStartAndFinish, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitializeGanttStartAndFinish) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitializeGanttStartAndFinish_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitializeGanttStartAndFinishPrametersTypes = new Type[] { typeof(DataTable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodInitializeGanttStartAndFinish, Fixture, methodInitializeGanttStartAndFinishPrametersTypes);

            // Assert
            methodInitializeGanttStartAndFinishPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeGanttStartAndFinish) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitializeGanttStartAndFinish_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitializeGanttStartAndFinish, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDisplayName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_GetDisplayName_Method_Call_Internally(Type[] types)
        {
            var methodGetDisplayNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetDisplayName, Fixture, methodGetDisplayNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetDisplayName) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetDisplayName_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _gridDataInstance.GetDisplayName(internalName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetDisplayName) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetDisplayName_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var methodGetDisplayNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetDisplayName = { internalName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDisplayName, methodGetDisplayNamePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridData, string>(_gridDataInstanceFixture, out exception1, parametersOfGetDisplayName);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridData, string>(_gridDataInstance, MethodGetDisplayName, parametersOfGetDisplayName, methodGetDisplayNamePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetDisplayName.ShouldNotBeNull();
            parametersOfGetDisplayName.Length.ShouldBe(1);
            methodGetDisplayNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDisplayName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetDisplayName_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var methodGetDisplayNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetDisplayName = { internalName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetDisplayName, methodGetDisplayNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfGetDisplayName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDisplayName.ShouldNotBeNull();
            parametersOfGetDisplayName.Length.ShouldBe(1);
            methodGetDisplayNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDisplayName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetDisplayName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var methodGetDisplayNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetDisplayName = { internalName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridData, string>(_gridDataInstance, MethodGetDisplayName, parametersOfGetDisplayName, methodGetDisplayNamePrametersTypes);

            // Assert
            parametersOfGetDisplayName.ShouldNotBeNull();
            parametersOfGetDisplayName.Length.ShouldBe(1);
            methodGetDisplayNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDisplayName) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetDisplayName_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetDisplayNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetDisplayName, Fixture, methodGetDisplayNamePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetDisplayNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDisplayName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetDisplayName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDisplayNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetDisplayName, Fixture, methodGetDisplayNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDisplayNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDisplayName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetDisplayName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDisplayName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetDisplayName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetDisplayName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDisplayName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetStartDate) (Return Type : DateTime) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_GetStartDate_Method_Call_Internally(Type[] types)
        {
            var methodGetStartDatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetStartDate, Fixture, methodGetStartDatePrametersTypes);
        }

        #endregion

        #region Method Call : (GetStartDate) (Return Type : DateTime) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetStartDate_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var splist = CreateType<SPList>();
            var methodGetStartDatePrametersTypes = new Type[] { typeof(DataTable), typeof(SPList) };
            object[] parametersOfGetStartDate = { dt, splist };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetStartDate, methodGetStartDatePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridData, DateTime>(_gridDataInstanceFixture, out exception1, parametersOfGetStartDate);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridData, DateTime>(_gridDataInstance, MethodGetStartDate, parametersOfGetStartDate, methodGetStartDatePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfGetStartDate.ShouldNotBeNull();
            parametersOfGetStartDate.Length.ShouldBe(2);
            methodGetStartDatePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetStartDate) (Return Type : DateTime) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetStartDate_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var splist = CreateType<SPList>();
            var methodGetStartDatePrametersTypes = new Type[] { typeof(DataTable), typeof(SPList) };
            object[] parametersOfGetStartDate = { dt, splist };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetStartDate, methodGetStartDatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfGetStartDate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetStartDate.ShouldNotBeNull();
            parametersOfGetStartDate.Length.ShouldBe(2);
            methodGetStartDatePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStartDate) (Return Type : DateTime) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetStartDate_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var splist = CreateType<SPList>();
            var methodGetStartDatePrametersTypes = new Type[] { typeof(DataTable), typeof(SPList) };
            object[] parametersOfGetStartDate = { dt, splist };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridData, DateTime>(_gridDataInstance, MethodGetStartDate, parametersOfGetStartDate, methodGetStartDatePrametersTypes);

            // Assert
            parametersOfGetStartDate.ShouldNotBeNull();
            parametersOfGetStartDate.Length.ShouldBe(2);
            methodGetStartDatePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStartDate) (Return Type : DateTime) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetStartDate_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetStartDatePrametersTypes = new Type[] { typeof(DataTable), typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetStartDate, Fixture, methodGetStartDatePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetStartDatePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetStartDate) (Return Type : DateTime) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetStartDate_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetStartDatePrametersTypes = new Type[] { typeof(DataTable), typeof(SPList) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetStartDate, Fixture, methodGetStartDatePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetStartDatePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetStartDate) (Return Type : DateTime) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetStartDate_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetStartDate, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetStartDate) (Return Type : DateTime) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetStartDate_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetStartDate, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFinishDate) (Return Type : DateTime) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_GetFinishDate_Method_Call_Internally(Type[] types)
        {
            var methodGetFinishDatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetFinishDate, Fixture, methodGetFinishDatePrametersTypes);
        }

        #endregion

        #region Method Call : (GetFinishDate) (Return Type : DateTime) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetFinishDate_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var splist = CreateType<SPList>();
            var methodGetFinishDatePrametersTypes = new Type[] { typeof(DataTable), typeof(SPList) };
            object[] parametersOfGetFinishDate = { dt, splist };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFinishDate, methodGetFinishDatePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridData, DateTime>(_gridDataInstanceFixture, out exception1, parametersOfGetFinishDate);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridData, DateTime>(_gridDataInstance, MethodGetFinishDate, parametersOfGetFinishDate, methodGetFinishDatePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfGetFinishDate.ShouldNotBeNull();
            parametersOfGetFinishDate.Length.ShouldBe(2);
            methodGetFinishDatePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFinishDate) (Return Type : DateTime) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetFinishDate_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var splist = CreateType<SPList>();
            var methodGetFinishDatePrametersTypes = new Type[] { typeof(DataTable), typeof(SPList) };
            object[] parametersOfGetFinishDate = { dt, splist };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFinishDate, methodGetFinishDatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfGetFinishDate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFinishDate.ShouldNotBeNull();
            parametersOfGetFinishDate.Length.ShouldBe(2);
            methodGetFinishDatePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFinishDate) (Return Type : DateTime) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetFinishDate_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var splist = CreateType<SPList>();
            var methodGetFinishDatePrametersTypes = new Type[] { typeof(DataTable), typeof(SPList) };
            object[] parametersOfGetFinishDate = { dt, splist };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridData, DateTime>(_gridDataInstance, MethodGetFinishDate, parametersOfGetFinishDate, methodGetFinishDatePrametersTypes);

            // Assert
            parametersOfGetFinishDate.ShouldNotBeNull();
            parametersOfGetFinishDate.Length.ShouldBe(2);
            methodGetFinishDatePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFinishDate) (Return Type : DateTime) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetFinishDate_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFinishDatePrametersTypes = new Type[] { typeof(DataTable), typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetFinishDate, Fixture, methodGetFinishDatePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFinishDatePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFinishDate) (Return Type : DateTime) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetFinishDate_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFinishDatePrametersTypes = new Type[] { typeof(DataTable), typeof(SPList) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetFinishDate, Fixture, methodGetFinishDatePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFinishDatePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFinishDate) (Return Type : DateTime) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetFinishDate_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFinishDate, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetFinishDate) (Return Type : DateTime) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetFinishDate_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFinishDate, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FinalizeData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_FinalizeData_Method_Call_Internally(Type[] types)
        {
            var methodFinalizeDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodFinalizeData, Fixture, methodFinalizeDataPrametersTypes);
        }

        #endregion

        #region Method Call : (FinalizeData) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_FinalizeData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var convertedXMLdata = CreateType<DataTable>();
            var methodFinalizeDataPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfFinalizeData = { convertedXMLdata };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFinalizeData, methodFinalizeDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfFinalizeData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFinalizeData.ShouldNotBeNull();
            parametersOfFinalizeData.Length.ShouldBe(1);
            methodFinalizeDataPrametersTypes.Length.ShouldBe(1);
            methodFinalizeDataPrametersTypes.Length.ShouldBe(parametersOfFinalizeData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FinalizeData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_FinalizeData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var convertedXMLdata = CreateType<DataTable>();
            var methodFinalizeDataPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfFinalizeData = { convertedXMLdata };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridDataInstance, MethodFinalizeData, parametersOfFinalizeData, methodFinalizeDataPrametersTypes);

            // Assert
            parametersOfFinalizeData.ShouldNotBeNull();
            parametersOfFinalizeData.Length.ShouldBe(1);
            methodFinalizeDataPrametersTypes.Length.ShouldBe(1);
            methodFinalizeDataPrametersTypes.Length.ShouldBe(parametersOfFinalizeData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FinalizeData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_FinalizeData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFinalizeData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FinalizeData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_FinalizeData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFinalizeDataPrametersTypes = new Type[] { typeof(DataTable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodFinalizeData, Fixture, methodFinalizeDataPrametersTypes);

            // Assert
            methodFinalizeDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FinalizeData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_FinalizeData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFinalizeData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddRowHierarchy) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_AddRowHierarchy_Method_Call_Internally(Type[] types)
        {
            var methodAddRowHierarchyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodAddRowHierarchy, Fixture, methodAddRowHierarchyPrametersTypes);
        }

        #endregion

        #region Method Call : (AddRowHierarchy) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_AddRowHierarchy_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var data = CreateType<DataTable>();
            var nodeData = CreateType<XmlNode>();
            var methodAddRowHierarchyPrametersTypes = new Type[] { typeof(DataRow), typeof(DataTable), typeof(XmlNode) };
            object[] parametersOfAddRowHierarchy = { dr, data, nodeData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddRowHierarchy, methodAddRowHierarchyPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfAddRowHierarchy);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddRowHierarchy.ShouldNotBeNull();
            parametersOfAddRowHierarchy.Length.ShouldBe(3);
            methodAddRowHierarchyPrametersTypes.Length.ShouldBe(3);
            methodAddRowHierarchyPrametersTypes.Length.ShouldBe(parametersOfAddRowHierarchy.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddRowHierarchy) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_AddRowHierarchy_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var data = CreateType<DataTable>();
            var nodeData = CreateType<XmlNode>();
            var methodAddRowHierarchyPrametersTypes = new Type[] { typeof(DataRow), typeof(DataTable), typeof(XmlNode) };
            object[] parametersOfAddRowHierarchy = { dr, data, nodeData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridDataInstance, MethodAddRowHierarchy, parametersOfAddRowHierarchy, methodAddRowHierarchyPrametersTypes);

            // Assert
            parametersOfAddRowHierarchy.ShouldNotBeNull();
            parametersOfAddRowHierarchy.Length.ShouldBe(3);
            methodAddRowHierarchyPrametersTypes.Length.ShouldBe(3);
            methodAddRowHierarchyPrametersTypes.Length.ShouldBe(parametersOfAddRowHierarchy.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddRowHierarchy) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_AddRowHierarchy_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddRowHierarchy, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddRowHierarchy) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_AddRowHierarchy_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddRowHierarchyPrametersTypes = new Type[] { typeof(DataRow), typeof(DataTable), typeof(XmlNode) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodAddRowHierarchy, Fixture, methodAddRowHierarchyPrametersTypes);

            // Assert
            methodAddRowHierarchyPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddRowHierarchy) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_AddRowHierarchy_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddRowHierarchy, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPredecessors) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_GetPredecessors_Method_Call_Internally(Type[] types)
        {
            var methodGetPredecessorsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetPredecessors, Fixture, methodGetPredecessorsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPredecessors) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetPredecessors_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var curTask = CreateType<DataRow>();
            var allTasks = CreateType<DataTable>();
            var methodGetPredecessorsPrametersTypes = new Type[] { typeof(DataRow), typeof(DataTable) };
            object[] parametersOfGetPredecessors = { curTask, allTasks };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetPredecessors, methodGetPredecessorsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfGetPredecessors);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetPredecessors.ShouldNotBeNull();
            parametersOfGetPredecessors.Length.ShouldBe(2);
            methodGetPredecessorsPrametersTypes.Length.ShouldBe(2);
            methodGetPredecessorsPrametersTypes.Length.ShouldBe(parametersOfGetPredecessors.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetPredecessors) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetPredecessors_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var curTask = CreateType<DataRow>();
            var allTasks = CreateType<DataTable>();
            var methodGetPredecessorsPrametersTypes = new Type[] { typeof(DataRow), typeof(DataTable) };
            object[] parametersOfGetPredecessors = { curTask, allTasks };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridDataInstance, MethodGetPredecessors, parametersOfGetPredecessors, methodGetPredecessorsPrametersTypes);

            // Assert
            parametersOfGetPredecessors.ShouldNotBeNull();
            parametersOfGetPredecessors.Length.ShouldBe(2);
            methodGetPredecessorsPrametersTypes.Length.ShouldBe(2);
            methodGetPredecessorsPrametersTypes.Length.ShouldBe(parametersOfGetPredecessors.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPredecessors) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetPredecessors_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetPredecessors, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPredecessors) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetPredecessors_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPredecessorsPrametersTypes = new Type[] { typeof(DataRow), typeof(DataTable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetPredecessors, Fixture, methodGetPredecessorsPrametersTypes);

            // Assert
            methodGetPredecessorsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPredecessors) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetPredecessors_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPredecessors, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTaskId) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_GetTaskId_Method_Call_Internally(Type[] types)
        {
            var methodGetTaskIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetTaskId, Fixture, methodGetTaskIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTaskId) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetTaskId_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var predecessorString = CreateType<string>();
            var methodGetTaskIdPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTaskId = { predecessorString };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTaskId, methodGetTaskIdPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfGetTaskId);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTaskId.ShouldNotBeNull();
            parametersOfGetTaskId.Length.ShouldBe(1);
            methodGetTaskIdPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTaskId) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetTaskId_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var predecessorString = CreateType<string>();
            var methodGetTaskIdPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTaskId = { predecessorString };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridData, string>(_gridDataInstance, MethodGetTaskId, parametersOfGetTaskId, methodGetTaskIdPrametersTypes);

            // Assert
            parametersOfGetTaskId.ShouldNotBeNull();
            parametersOfGetTaskId.Length.ShouldBe(1);
            methodGetTaskIdPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTaskId) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetTaskId_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTaskIdPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetTaskId, Fixture, methodGetTaskIdPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTaskIdPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTaskId) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetTaskId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTaskIdPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetTaskId, Fixture, methodGetTaskIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTaskIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTaskId) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetTaskId_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTaskId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetTaskId) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetTaskId_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTaskId, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLinkType) (Return Type : LinkType) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_GetLinkType_Method_Call_Internally(Type[] types)
        {
            var methodGetLinkTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetLinkType, Fixture, methodGetLinkTypePrametersTypes);
        }

        #endregion

        #region Method Call : (GetLinkType) (Return Type : LinkType) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetLinkType_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var predecessorString = CreateType<string>();
            var methodGetLinkTypePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetLinkType = { predecessorString };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetLinkType, methodGetLinkTypePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfGetLinkType);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetLinkType.ShouldNotBeNull();
            parametersOfGetLinkType.Length.ShouldBe(1);
            methodGetLinkTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLinkType) (Return Type : LinkType) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetLinkType_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var predecessorString = CreateType<string>();
            var methodGetLinkTypePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetLinkType = { predecessorString };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridData, LinkType>(_gridDataInstance, MethodGetLinkType, parametersOfGetLinkType, methodGetLinkTypePrametersTypes);

            // Assert
            parametersOfGetLinkType.ShouldNotBeNull();
            parametersOfGetLinkType.Length.ShouldBe(1);
            methodGetLinkTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLinkType) (Return Type : LinkType) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetLinkType_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetLinkTypePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetLinkType, Fixture, methodGetLinkTypePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLinkTypePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetLinkType) (Return Type : LinkType) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetLinkType_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetLinkTypePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetLinkType, Fixture, methodGetLinkTypePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLinkTypePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLinkType) (Return Type : LinkType) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetLinkType_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLinkType, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetLinkType) (Return Type : LinkType) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetLinkType_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetLinkType, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddRowPredecessors) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_AddRowPredecessors_Method_Call_Internally(Type[] types)
        {
            var methodAddRowPredecessorsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodAddRowPredecessors, Fixture, methodAddRowPredecessorsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddRowPredecessors) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_AddRowPredecessors_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var data = CreateType<DataTable>();
            var methodAddRowPredecessorsPrametersTypes = new Type[] { typeof(DataRow), typeof(DataTable) };
            object[] parametersOfAddRowPredecessors = { dr, data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddRowPredecessors, methodAddRowPredecessorsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfAddRowPredecessors);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddRowPredecessors.ShouldNotBeNull();
            parametersOfAddRowPredecessors.Length.ShouldBe(2);
            methodAddRowPredecessorsPrametersTypes.Length.ShouldBe(2);
            methodAddRowPredecessorsPrametersTypes.Length.ShouldBe(parametersOfAddRowPredecessors.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddRowPredecessors) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_AddRowPredecessors_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var data = CreateType<DataTable>();
            var methodAddRowPredecessorsPrametersTypes = new Type[] { typeof(DataRow), typeof(DataTable) };
            object[] parametersOfAddRowPredecessors = { dr, data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridDataInstance, MethodAddRowPredecessors, parametersOfAddRowPredecessors, methodAddRowPredecessorsPrametersTypes);

            // Assert
            parametersOfAddRowPredecessors.ShouldNotBeNull();
            parametersOfAddRowPredecessors.Length.ShouldBe(2);
            methodAddRowPredecessorsPrametersTypes.Length.ShouldBe(2);
            methodAddRowPredecessorsPrametersTypes.Length.ShouldBe(parametersOfAddRowPredecessors.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddRowPredecessors) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_AddRowPredecessors_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddRowPredecessors, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddRowPredecessors) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_AddRowPredecessors_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddRowPredecessorsPrametersTypes = new Type[] { typeof(DataRow), typeof(DataTable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodAddRowPredecessors, Fixture, methodAddRowPredecessorsPrametersTypes);

            // Assert
            methodAddRowPredecessorsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddRowPredecessors) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_AddRowPredecessors_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddRowPredecessors, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeReqdFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_InitializeReqdFields_Method_Call_Internally(Type[] types)
        {
            var methodInitializeReqdFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodInitializeReqdFields, Fixture, methodInitializeReqdFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (InitializeReqdFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitializeReqdFields_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitializeReqdFieldsPrametersTypes = null;
            object[] parametersOfInitializeReqdFields = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitializeReqdFields, methodInitializeReqdFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfInitializeReqdFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitializeReqdFields.ShouldBeNull();
            methodInitializeReqdFieldsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitializeReqdFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitializeReqdFields_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitializeReqdFieldsPrametersTypes = null;
            object[] parametersOfInitializeReqdFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridDataInstance, MethodInitializeReqdFields, parametersOfInitializeReqdFields, methodInitializeReqdFieldsPrametersTypes);

            // Assert
            parametersOfInitializeReqdFields.ShouldBeNull();
            methodInitializeReqdFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeReqdFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitializeReqdFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitializeReqdFieldsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodInitializeReqdFields, Fixture, methodInitializeReqdFieldsPrametersTypes);

            // Assert
            methodInitializeReqdFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeReqdFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitializeReqdFields_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitializeReqdFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddReqdFieldsToView) (Return Type : SPWeb) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_AddReqdFieldsToView_Method_Call_Internally(Type[] types)
        {
            var methodAddReqdFieldsToViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodAddReqdFieldsToView, Fixture, methodAddReqdFieldsToViewPrametersTypes);
        }

        #endregion

        #region Method Call : (AddReqdFieldsToView) (Return Type : SPWeb) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_AddReqdFieldsToView_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodAddReqdFieldsToViewPrametersTypes = null;
            object[] parametersOfAddReqdFieldsToView = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddReqdFieldsToView, methodAddReqdFieldsToViewPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridData, SPWeb>(_gridDataInstanceFixture, out exception1, parametersOfAddReqdFieldsToView);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridData, SPWeb>(_gridDataInstance, MethodAddReqdFieldsToView, parametersOfAddReqdFieldsToView, methodAddReqdFieldsToViewPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfAddReqdFieldsToView.ShouldBeNull();
            methodAddReqdFieldsToViewPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddReqdFieldsToView) (Return Type : SPWeb) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_AddReqdFieldsToView_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAddReqdFieldsToViewPrametersTypes = null;
            object[] parametersOfAddReqdFieldsToView = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridData, SPWeb>(_gridDataInstance, MethodAddReqdFieldsToView, parametersOfAddReqdFieldsToView, methodAddReqdFieldsToViewPrametersTypes);

            // Assert
            parametersOfAddReqdFieldsToView.ShouldBeNull();
            methodAddReqdFieldsToViewPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddReqdFieldsToView) (Return Type : SPWeb) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_AddReqdFieldsToView_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodAddReqdFieldsToViewPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodAddReqdFieldsToView, Fixture, methodAddReqdFieldsToViewPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddReqdFieldsToViewPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddReqdFieldsToView) (Return Type : SPWeb) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_AddReqdFieldsToView_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAddReqdFieldsToViewPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodAddReqdFieldsToView, Fixture, methodAddReqdFieldsToViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddReqdFieldsToViewPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddReqdFieldsToView) (Return Type : SPWeb) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_AddReqdFieldsToView_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddReqdFieldsToView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RemoveReqdFieldsFromView) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_RemoveReqdFieldsFromView_Method_Call_Internally(Type[] types)
        {
            var methodRemoveReqdFieldsFromViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodRemoveReqdFieldsFromView, Fixture, methodRemoveReqdFieldsFromViewPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveReqdFieldsFromView) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_RemoveReqdFieldsFromView_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRemoveReqdFieldsFromViewPrametersTypes = null;
            object[] parametersOfRemoveReqdFieldsFromView = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRemoveReqdFieldsFromView, methodRemoveReqdFieldsFromViewPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfRemoveReqdFieldsFromView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRemoveReqdFieldsFromView.ShouldBeNull();
            methodRemoveReqdFieldsFromViewPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RemoveReqdFieldsFromView) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_RemoveReqdFieldsFromView_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRemoveReqdFieldsFromViewPrametersTypes = null;
            object[] parametersOfRemoveReqdFieldsFromView = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridDataInstance, MethodRemoveReqdFieldsFromView, parametersOfRemoveReqdFieldsFromView, methodRemoveReqdFieldsFromViewPrametersTypes);

            // Assert
            parametersOfRemoveReqdFieldsFromView.ShouldBeNull();
            methodRemoveReqdFieldsFromViewPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveReqdFieldsFromView) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_RemoveReqdFieldsFromView_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRemoveReqdFieldsFromViewPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodRemoveReqdFieldsFromView, Fixture, methodRemoveReqdFieldsFromViewPrametersTypes);

            // Assert
            methodRemoveReqdFieldsFromViewPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveReqdFieldsFromView) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_RemoveReqdFieldsFromView_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveReqdFieldsFromView, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeColumnDefs) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_InitializeColumnDefs_Method_Call_Internally(Type[] types)
        {
            var methodInitializeColumnDefsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodInitializeColumnDefs, Fixture, methodInitializeColumnDefsPrametersTypes);
        }

        #endregion

        #region Method Call : (InitializeColumnDefs) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitializeColumnDefs_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodInitializeColumnDefsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfInitializeColumnDefs = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitializeColumnDefs, methodInitializeColumnDefsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfInitializeColumnDefs);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitializeColumnDefs.ShouldNotBeNull();
            parametersOfInitializeColumnDefs.Length.ShouldBe(1);
            methodInitializeColumnDefsPrametersTypes.Length.ShouldBe(1);
            methodInitializeColumnDefsPrametersTypes.Length.ShouldBe(parametersOfInitializeColumnDefs.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitializeColumnDefs) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitializeColumnDefs_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodInitializeColumnDefsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfInitializeColumnDefs = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridDataInstance, MethodInitializeColumnDefs, parametersOfInitializeColumnDefs, methodInitializeColumnDefsPrametersTypes);

            // Assert
            parametersOfInitializeColumnDefs.ShouldNotBeNull();
            parametersOfInitializeColumnDefs.Length.ShouldBe(1);
            methodInitializeColumnDefsPrametersTypes.Length.ShouldBe(1);
            methodInitializeColumnDefsPrametersTypes.Length.ShouldBe(parametersOfInitializeColumnDefs.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeColumnDefs) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitializeColumnDefs_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInitializeColumnDefs, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitializeColumnDefs) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitializeColumnDefs_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitializeColumnDefsPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodInitializeColumnDefs, Fixture, methodInitializeColumnDefsPrametersTypes);

            // Assert
            methodInitializeColumnDefsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeColumnDefs) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitializeColumnDefs_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitializeColumnDefs, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_LoadData_Method_Call_Internally(Type[] types)
        {
            var methodLoadDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodLoadData, Fixture, methodLoadDataPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_LoadData_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<DataTable>();
            var methodLoadDataPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfLoadData = { data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadData, methodLoadDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfLoadData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadData.ShouldNotBeNull();
            parametersOfLoadData.Length.ShouldBe(1);
            methodLoadDataPrametersTypes.Length.ShouldBe(1);
            methodLoadDataPrametersTypes.Length.ShouldBe(parametersOfLoadData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LoadData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_LoadData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<DataTable>();
            var methodLoadDataPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfLoadData = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridDataInstance, MethodLoadData, parametersOfLoadData, methodLoadDataPrametersTypes);

            // Assert
            parametersOfLoadData.ShouldNotBeNull();
            parametersOfLoadData.Length.ShouldBe(1);
            methodLoadDataPrametersTypes.Length.ShouldBe(1);
            methodLoadDataPrametersTypes.Length.ShouldBe(parametersOfLoadData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_LoadData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLoadData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_LoadData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadDataPrametersTypes = new Type[] { typeof(DataTable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodLoadData, Fixture, methodLoadDataPrametersTypes);

            // Assert
            methodLoadDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_LoadData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessNode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_ProcessNode_Method_Call_Internally(Type[] types)
        {
            var methodProcessNodePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodProcessNode, Fixture, methodProcessNodePrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessNode) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ProcessNode_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var nodeData = CreateType<XmlNode>();
            var dt = CreateType<DataTable>();
            var methodProcessNodePrametersTypes = new Type[] { typeof(XmlNode), typeof(DataTable) };
            object[] parametersOfProcessNode = { nodeData, dt };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessNode, methodProcessNodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfProcessNode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessNode.ShouldNotBeNull();
            parametersOfProcessNode.Length.ShouldBe(2);
            methodProcessNodePrametersTypes.Length.ShouldBe(2);
            methodProcessNodePrametersTypes.Length.ShouldBe(parametersOfProcessNode.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessNode) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ProcessNode_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var nodeData = CreateType<XmlNode>();
            var dt = CreateType<DataTable>();
            var methodProcessNodePrametersTypes = new Type[] { typeof(XmlNode), typeof(DataTable) };
            object[] parametersOfProcessNode = { nodeData, dt };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridDataInstance, MethodProcessNode, parametersOfProcessNode, methodProcessNodePrametersTypes);

            // Assert
            parametersOfProcessNode.ShouldNotBeNull();
            parametersOfProcessNode.Length.ShouldBe(2);
            methodProcessNodePrametersTypes.Length.ShouldBe(2);
            methodProcessNodePrametersTypes.Length.ShouldBe(parametersOfProcessNode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessNode) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ProcessNode_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessNode, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessNode) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ProcessNode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessNodePrametersTypes = new Type[] { typeof(XmlNode), typeof(DataTable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodProcessNode, Fixture, methodProcessNodePrametersTypes);

            // Assert
            methodProcessNodePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessNode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ProcessNode_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessNode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumns) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_AddColumns_Method_Call_Internally(Type[] types)
        {
            var methodAddColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodAddColumns, Fixture, methodAddColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddColumns) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_AddColumns_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<DataTable>();
            var methodAddColumnsPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfAddColumns = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddColumns, methodAddColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridData, DataTable>(_gridDataInstanceFixture, out exception1, parametersOfAddColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridData, DataTable>(_gridDataInstance, MethodAddColumns, parametersOfAddColumns, methodAddColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfAddColumns.ShouldNotBeNull();
            parametersOfAddColumns.Length.ShouldBe(1);
            methodAddColumnsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AddColumns) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_AddColumns_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<DataTable>();
            var methodAddColumnsPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfAddColumns = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridData, DataTable>(_gridDataInstance, MethodAddColumns, parametersOfAddColumns, methodAddColumnsPrametersTypes);

            // Assert
            parametersOfAddColumns.ShouldNotBeNull();
            parametersOfAddColumns.Length.ShouldBe(1);
            methodAddColumnsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumns) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_AddColumns_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddColumnsPrametersTypes = new Type[] { typeof(DataTable) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodAddColumns, Fixture, methodAddColumnsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddColumnsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AddColumns) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_AddColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddColumnsPrametersTypes = new Type[] { typeof(DataTable) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodAddColumns, Fixture, methodAddColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddColumns) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_AddColumns_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddColumns, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddColumns) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_AddColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddColumns, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateFieldValues) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_PopulateFieldValues_Method_Call_Internally(Type[] types)
        {
            var methodPopulateFieldValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodPopulateFieldValues, Fixture, methodPopulateFieldValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateFieldValues) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_PopulateFieldValues_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var nodeData = CreateType<XmlNode>();
            var dt = CreateType<DataTable>();
            var methodPopulateFieldValuesPrametersTypes = new Type[] { typeof(XmlNode), typeof(DataTable) };
            object[] parametersOfPopulateFieldValues = { nodeData, dt };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateFieldValues, methodPopulateFieldValuesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfPopulateFieldValues);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateFieldValues.ShouldNotBeNull();
            parametersOfPopulateFieldValues.Length.ShouldBe(2);
            methodPopulateFieldValuesPrametersTypes.Length.ShouldBe(2);
            methodPopulateFieldValuesPrametersTypes.Length.ShouldBe(parametersOfPopulateFieldValues.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PopulateFieldValues) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_PopulateFieldValues_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var nodeData = CreateType<XmlNode>();
            var dt = CreateType<DataTable>();
            var methodPopulateFieldValuesPrametersTypes = new Type[] { typeof(XmlNode), typeof(DataTable) };
            object[] parametersOfPopulateFieldValues = { nodeData, dt };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridDataInstance, MethodPopulateFieldValues, parametersOfPopulateFieldValues, methodPopulateFieldValuesPrametersTypes);

            // Assert
            parametersOfPopulateFieldValues.ShouldNotBeNull();
            parametersOfPopulateFieldValues.Length.ShouldBe(2);
            methodPopulateFieldValuesPrametersTypes.Length.ShouldBe(2);
            methodPopulateFieldValuesPrametersTypes.Length.ShouldBe(parametersOfPopulateFieldValues.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateFieldValues) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_PopulateFieldValues_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateFieldValues, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateFieldValues) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_PopulateFieldValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateFieldValuesPrametersTypes = new Type[] { typeof(XmlNode), typeof(DataTable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodPopulateFieldValues, Fixture, methodPopulateFieldValuesPrametersTypes);

            // Assert
            methodPopulateFieldValuesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateFieldValues) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_PopulateFieldValues_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateFieldValues, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateViewFieldValues) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_PopulateViewFieldValues_Method_Call_Internally(Type[] types)
        {
            var methodPopulateViewFieldValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodPopulateViewFieldValues, Fixture, methodPopulateViewFieldValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateViewFieldValues) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_PopulateViewFieldValues_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var nodeData = CreateType<XmlNode>();
            var dr = CreateType<DataRow>();
            var methodPopulateViewFieldValuesPrametersTypes = new Type[] { typeof(XmlNode), typeof(DataRow) };
            object[] parametersOfPopulateViewFieldValues = { nodeData, dr };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateViewFieldValues, methodPopulateViewFieldValuesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfPopulateViewFieldValues);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateViewFieldValues.ShouldNotBeNull();
            parametersOfPopulateViewFieldValues.Length.ShouldBe(2);
            methodPopulateViewFieldValuesPrametersTypes.Length.ShouldBe(2);
            methodPopulateViewFieldValuesPrametersTypes.Length.ShouldBe(parametersOfPopulateViewFieldValues.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PopulateViewFieldValues) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_PopulateViewFieldValues_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var nodeData = CreateType<XmlNode>();
            var dr = CreateType<DataRow>();
            var methodPopulateViewFieldValuesPrametersTypes = new Type[] { typeof(XmlNode), typeof(DataRow) };
            object[] parametersOfPopulateViewFieldValues = { nodeData, dr };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridDataInstance, MethodPopulateViewFieldValues, parametersOfPopulateViewFieldValues, methodPopulateViewFieldValuesPrametersTypes);

            // Assert
            parametersOfPopulateViewFieldValues.ShouldNotBeNull();
            parametersOfPopulateViewFieldValues.Length.ShouldBe(2);
            methodPopulateViewFieldValuesPrametersTypes.Length.ShouldBe(2);
            methodPopulateViewFieldValuesPrametersTypes.Length.ShouldBe(parametersOfPopulateViewFieldValues.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateViewFieldValues) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_PopulateViewFieldValues_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateViewFieldValues, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateViewFieldValues) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_PopulateViewFieldValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateViewFieldValuesPrametersTypes = new Type[] { typeof(XmlNode), typeof(DataRow) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodPopulateViewFieldValues, Fixture, methodPopulateViewFieldValuesPrametersTypes);

            // Assert
            methodPopulateViewFieldValuesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateViewFieldValues) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_PopulateViewFieldValues_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateViewFieldValues, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateDefaultFieldValues) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_PopulateDefaultFieldValues_Method_Call_Internally(Type[] types)
        {
            var methodPopulateDefaultFieldValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodPopulateDefaultFieldValues, Fixture, methodPopulateDefaultFieldValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateDefaultFieldValues) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_PopulateDefaultFieldValues_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var nodeData = CreateType<XmlNode>();
            var dr = CreateType<DataRow>();
            var data = CreateType<DataTable>();
            var methodPopulateDefaultFieldValuesPrametersTypes = new Type[] { typeof(XmlNode), typeof(DataRow), typeof(DataTable) };
            object[] parametersOfPopulateDefaultFieldValues = { nodeData, dr, data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateDefaultFieldValues, methodPopulateDefaultFieldValuesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfPopulateDefaultFieldValues);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateDefaultFieldValues.ShouldNotBeNull();
            parametersOfPopulateDefaultFieldValues.Length.ShouldBe(3);
            methodPopulateDefaultFieldValuesPrametersTypes.Length.ShouldBe(3);
            methodPopulateDefaultFieldValuesPrametersTypes.Length.ShouldBe(parametersOfPopulateDefaultFieldValues.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PopulateDefaultFieldValues) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_PopulateDefaultFieldValues_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var nodeData = CreateType<XmlNode>();
            var dr = CreateType<DataRow>();
            var data = CreateType<DataTable>();
            var methodPopulateDefaultFieldValuesPrametersTypes = new Type[] { typeof(XmlNode), typeof(DataRow), typeof(DataTable) };
            object[] parametersOfPopulateDefaultFieldValues = { nodeData, dr, data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridDataInstance, MethodPopulateDefaultFieldValues, parametersOfPopulateDefaultFieldValues, methodPopulateDefaultFieldValuesPrametersTypes);

            // Assert
            parametersOfPopulateDefaultFieldValues.ShouldNotBeNull();
            parametersOfPopulateDefaultFieldValues.Length.ShouldBe(3);
            methodPopulateDefaultFieldValuesPrametersTypes.Length.ShouldBe(3);
            methodPopulateDefaultFieldValuesPrametersTypes.Length.ShouldBe(parametersOfPopulateDefaultFieldValues.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateDefaultFieldValues) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_PopulateDefaultFieldValues_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateDefaultFieldValues, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateDefaultFieldValues) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_PopulateDefaultFieldValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateDefaultFieldValuesPrametersTypes = new Type[] { typeof(XmlNode), typeof(DataRow), typeof(DataTable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodPopulateDefaultFieldValues, Fixture, methodPopulateDefaultFieldValuesPrametersTypes);

            // Assert
            methodPopulateDefaultFieldValuesPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateDefaultFieldValues) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_PopulateDefaultFieldValues_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateDefaultFieldValues, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateGanttStartAndDates) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_PopulateGanttStartAndDates_Method_Call_Internally(Type[] types)
        {
            var methodPopulateGanttStartAndDatesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodPopulateGanttStartAndDates, Fixture, methodPopulateGanttStartAndDatesPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateGanttStartAndDates) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_PopulateGanttStartAndDates_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var node = CreateType<XmlNode>();
            var methodPopulateGanttStartAndDatesPrametersTypes = new Type[] { typeof(DataRow), typeof(XmlNode) };
            object[] parametersOfPopulateGanttStartAndDates = { dr, node };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateGanttStartAndDates, methodPopulateGanttStartAndDatesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfPopulateGanttStartAndDates);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateGanttStartAndDates.ShouldNotBeNull();
            parametersOfPopulateGanttStartAndDates.Length.ShouldBe(2);
            methodPopulateGanttStartAndDatesPrametersTypes.Length.ShouldBe(2);
            methodPopulateGanttStartAndDatesPrametersTypes.Length.ShouldBe(parametersOfPopulateGanttStartAndDates.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PopulateGanttStartAndDates) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_PopulateGanttStartAndDates_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var node = CreateType<XmlNode>();
            var methodPopulateGanttStartAndDatesPrametersTypes = new Type[] { typeof(DataRow), typeof(XmlNode) };
            object[] parametersOfPopulateGanttStartAndDates = { dr, node };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridDataInstance, MethodPopulateGanttStartAndDates, parametersOfPopulateGanttStartAndDates, methodPopulateGanttStartAndDatesPrametersTypes);

            // Assert
            parametersOfPopulateGanttStartAndDates.ShouldNotBeNull();
            parametersOfPopulateGanttStartAndDates.Length.ShouldBe(2);
            methodPopulateGanttStartAndDatesPrametersTypes.Length.ShouldBe(2);
            methodPopulateGanttStartAndDatesPrametersTypes.Length.ShouldBe(parametersOfPopulateGanttStartAndDates.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateGanttStartAndDates) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_PopulateGanttStartAndDates_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateGanttStartAndDates, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateGanttStartAndDates) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_PopulateGanttStartAndDates_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateGanttStartAndDatesPrametersTypes = new Type[] { typeof(DataRow), typeof(XmlNode) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodPopulateGanttStartAndDates, Fixture, methodPopulateGanttStartAndDatesPrametersTypes);

            // Assert
            methodPopulateGanttStartAndDatesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateGanttStartAndDates) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_PopulateGanttStartAndDates_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateGanttStartAndDates, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CalcPercentComplete) (Return Type : DateTime) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_CalcPercentComplete_Method_Call_Internally(Type[] types)
        {
            var methodCalcPercentCompletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodCalcPercentComplete, Fixture, methodCalcPercentCompletePrametersTypes);
        }

        #endregion

        #region Method Call : (CalcPercentComplete) (Return Type : DateTime) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_CalcPercentComplete_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var item = CreateType<DataRow>();
            var methodCalcPercentCompletePrametersTypes = new Type[] { typeof(DataRow) };
            object[] parametersOfCalcPercentComplete = { item };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCalcPercentComplete, methodCalcPercentCompletePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridData, DateTime>(_gridDataInstanceFixture, out exception1, parametersOfCalcPercentComplete);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridData, DateTime>(_gridDataInstance, MethodCalcPercentComplete, parametersOfCalcPercentComplete, methodCalcPercentCompletePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfCalcPercentComplete.ShouldNotBeNull();
            parametersOfCalcPercentComplete.Length.ShouldBe(1);
            methodCalcPercentCompletePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CalcPercentComplete) (Return Type : DateTime) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_CalcPercentComplete_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var item = CreateType<DataRow>();
            var methodCalcPercentCompletePrametersTypes = new Type[] { typeof(DataRow) };
            object[] parametersOfCalcPercentComplete = { item };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCalcPercentComplete, methodCalcPercentCompletePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfCalcPercentComplete);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCalcPercentComplete.ShouldNotBeNull();
            parametersOfCalcPercentComplete.Length.ShouldBe(1);
            methodCalcPercentCompletePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CalcPercentComplete) (Return Type : DateTime) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_CalcPercentComplete_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var item = CreateType<DataRow>();
            var methodCalcPercentCompletePrametersTypes = new Type[] { typeof(DataRow) };
            object[] parametersOfCalcPercentComplete = { item };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridData, DateTime>(_gridDataInstance, MethodCalcPercentComplete, parametersOfCalcPercentComplete, methodCalcPercentCompletePrametersTypes);

            // Assert
            parametersOfCalcPercentComplete.ShouldNotBeNull();
            parametersOfCalcPercentComplete.Length.ShouldBe(1);
            methodCalcPercentCompletePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CalcPercentComplete) (Return Type : DateTime) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_CalcPercentComplete_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCalcPercentCompletePrametersTypes = new Type[] { typeof(DataRow) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodCalcPercentComplete, Fixture, methodCalcPercentCompletePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCalcPercentCompletePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CalcPercentComplete) (Return Type : DateTime) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_CalcPercentComplete_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCalcPercentCompletePrametersTypes = new Type[] { typeof(DataRow) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodCalcPercentComplete, Fixture, methodCalcPercentCompletePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCalcPercentCompletePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CalcPercentComplete) (Return Type : DateTime) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_CalcPercentComplete_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCalcPercentComplete, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (CalcPercentComplete) (Return Type : DateTime) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_CalcPercentComplete_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCalcPercentComplete, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGanttStartDate) (Return Type : DateTime) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_GetGanttStartDate_Method_Call_Internally(Type[] types)
        {
            var methodGetGanttStartDatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetGanttStartDate, Fixture, methodGetGanttStartDatePrametersTypes);
        }

        #endregion

        #region Method Call : (GetGanttStartDate) (Return Type : DateTime) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGanttStartDate_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var node = CreateType<XmlNode>();
            var methodGetGanttStartDatePrametersTypes = new Type[] { typeof(XmlNode) };
            object[] parametersOfGetGanttStartDate = { node };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetGanttStartDate, methodGetGanttStartDatePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridData, DateTime>(_gridDataInstanceFixture, out exception1, parametersOfGetGanttStartDate);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridData, DateTime>(_gridDataInstance, MethodGetGanttStartDate, parametersOfGetGanttStartDate, methodGetGanttStartDatePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfGetGanttStartDate.ShouldNotBeNull();
            parametersOfGetGanttStartDate.Length.ShouldBe(1);
            methodGetGanttStartDatePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetGanttStartDate) (Return Type : DateTime) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGanttStartDate_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var node = CreateType<XmlNode>();
            var methodGetGanttStartDatePrametersTypes = new Type[] { typeof(XmlNode) };
            object[] parametersOfGetGanttStartDate = { node };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridData, DateTime>(_gridDataInstance, MethodGetGanttStartDate, parametersOfGetGanttStartDate, methodGetGanttStartDatePrametersTypes);

            // Assert
            parametersOfGetGanttStartDate.ShouldNotBeNull();
            parametersOfGetGanttStartDate.Length.ShouldBe(1);
            methodGetGanttStartDatePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGanttStartDate) (Return Type : DateTime) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGanttStartDate_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetGanttStartDatePrametersTypes = new Type[] { typeof(XmlNode) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetGanttStartDate, Fixture, methodGetGanttStartDatePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetGanttStartDatePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetGanttStartDate) (Return Type : DateTime) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGanttStartDate_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetGanttStartDatePrametersTypes = new Type[] { typeof(XmlNode) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetGanttStartDate, Fixture, methodGetGanttStartDatePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGanttStartDatePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGanttStartDate) (Return Type : DateTime) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGanttStartDate_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGanttStartDate, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGanttStartDate) (Return Type : DateTime) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGanttStartDate_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetGanttStartDate, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGanttFinishDate) (Return Type : DateTime) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_GetGanttFinishDate_Method_Call_Internally(Type[] types)
        {
            var methodGetGanttFinishDatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetGanttFinishDate, Fixture, methodGetGanttFinishDatePrametersTypes);
        }

        #endregion

        #region Method Call : (GetGanttFinishDate) (Return Type : DateTime) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGanttFinishDate_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var node = CreateType<XmlNode>();
            var methodGetGanttFinishDatePrametersTypes = new Type[] { typeof(XmlNode) };
            object[] parametersOfGetGanttFinishDate = { node };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetGanttFinishDate, methodGetGanttFinishDatePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridData, DateTime>(_gridDataInstanceFixture, out exception1, parametersOfGetGanttFinishDate);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridData, DateTime>(_gridDataInstance, MethodGetGanttFinishDate, parametersOfGetGanttFinishDate, methodGetGanttFinishDatePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfGetGanttFinishDate.ShouldNotBeNull();
            parametersOfGetGanttFinishDate.Length.ShouldBe(1);
            methodGetGanttFinishDatePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetGanttFinishDate) (Return Type : DateTime) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGanttFinishDate_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var node = CreateType<XmlNode>();
            var methodGetGanttFinishDatePrametersTypes = new Type[] { typeof(XmlNode) };
            object[] parametersOfGetGanttFinishDate = { node };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridData, DateTime>(_gridDataInstance, MethodGetGanttFinishDate, parametersOfGetGanttFinishDate, methodGetGanttFinishDatePrametersTypes);

            // Assert
            parametersOfGetGanttFinishDate.ShouldNotBeNull();
            parametersOfGetGanttFinishDate.Length.ShouldBe(1);
            methodGetGanttFinishDatePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGanttFinishDate) (Return Type : DateTime) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGanttFinishDate_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetGanttFinishDatePrametersTypes = new Type[] { typeof(XmlNode) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetGanttFinishDate, Fixture, methodGetGanttFinishDatePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetGanttFinishDatePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetGanttFinishDate) (Return Type : DateTime) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGanttFinishDate_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetGanttFinishDatePrametersTypes = new Type[] { typeof(XmlNode) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetGanttFinishDate, Fixture, methodGetGanttFinishDatePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGanttFinishDatePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGanttFinishDate) (Return Type : DateTime) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGanttFinishDate_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGanttFinishDate, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGanttFinishDate) (Return Type : DateTime) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetGanttFinishDate_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetGanttFinishDate, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ApplyGanttStyle) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_ApplyGanttStyle_Method_Call_Internally(Type[] types)
        {
            var methodApplyGanttStylePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodApplyGanttStyle, Fixture, methodApplyGanttStylePrametersTypes);
        }

        #endregion

        #region Method Call : (ApplyGanttStyle) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ApplyGanttStyle_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var node = CreateType<XmlNode>();
            var methodApplyGanttStylePrametersTypes = new Type[] { typeof(DataRow), typeof(XmlNode) };
            object[] parametersOfApplyGanttStyle = { dr, node };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodApplyGanttStyle, methodApplyGanttStylePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfApplyGanttStyle);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfApplyGanttStyle.ShouldNotBeNull();
            parametersOfApplyGanttStyle.Length.ShouldBe(2);
            methodApplyGanttStylePrametersTypes.Length.ShouldBe(2);
            methodApplyGanttStylePrametersTypes.Length.ShouldBe(parametersOfApplyGanttStyle.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ApplyGanttStyle) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ApplyGanttStyle_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var node = CreateType<XmlNode>();
            var methodApplyGanttStylePrametersTypes = new Type[] { typeof(DataRow), typeof(XmlNode) };
            object[] parametersOfApplyGanttStyle = { dr, node };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridDataInstance, MethodApplyGanttStyle, parametersOfApplyGanttStyle, methodApplyGanttStylePrametersTypes);

            // Assert
            parametersOfApplyGanttStyle.ShouldNotBeNull();
            parametersOfApplyGanttStyle.Length.ShouldBe(2);
            methodApplyGanttStylePrametersTypes.Length.ShouldBe(2);
            methodApplyGanttStylePrametersTypes.Length.ShouldBe(parametersOfApplyGanttStyle.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyGanttStyle) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ApplyGanttStyle_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodApplyGanttStyle, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ApplyGanttStyle) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ApplyGanttStyle_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodApplyGanttStylePrametersTypes = new Type[] { typeof(DataRow), typeof(XmlNode) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodApplyGanttStyle, Fixture, methodApplyGanttStylePrametersTypes);

            // Assert
            methodApplyGanttStylePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyGanttStyle) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ApplyGanttStyle_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodApplyGanttStyle, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyGanttStyles) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_ApplyGanttStyles_Method_Call_Internally(Type[] types)
        {
            var methodApplyGanttStylesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodApplyGanttStyles, Fixture, methodApplyGanttStylesPrametersTypes);
        }

        #endregion

        #region Method Call : (ApplyGanttStyles) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ApplyGanttStyles_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var item = CreateType<DataRow>();
            var type = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _gridDataInstance.ApplyGanttStyles(item, type);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion
        
        #region Method Call : (ApplyGanttStyles) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ApplyGanttStyles_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var item = CreateType<DataRow>();
            var type = CreateType<string>();
            var methodApplyGanttStylesPrametersTypes = new Type[] { typeof(DataRow), typeof(string) };
            object[] parametersOfApplyGanttStyles = { item, type };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridDataInstance, MethodApplyGanttStyles, parametersOfApplyGanttStyles, methodApplyGanttStylesPrametersTypes);

            // Assert
            parametersOfApplyGanttStyles.ShouldNotBeNull();
            parametersOfApplyGanttStyles.Length.ShouldBe(2);
            methodApplyGanttStylesPrametersTypes.Length.ShouldBe(2);
            methodApplyGanttStylesPrametersTypes.Length.ShouldBe(parametersOfApplyGanttStyles.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyGanttStyles) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ApplyGanttStyles_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodApplyGanttStyles, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ApplyGanttStyles) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ApplyGanttStyles_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodApplyGanttStylesPrametersTypes = new Type[] { typeof(DataRow), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodApplyGanttStyles, Fixture, methodApplyGanttStylesPrametersTypes);

            // Assert
            methodApplyGanttStylesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyGanttStyles) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ApplyGanttStyles_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodApplyGanttStyles, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetNodeByName) (Return Type : XmlNode) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_GetNodeByName_Method_Call_Internally(Type[] types)
        {
            var methodGetNodeByNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetNodeByName, Fixture, methodGetNodeByNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetNodeByName) (Return Type : XmlNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetNodeByName_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var nl = CreateType<XmlNodeList>();
            var methodGetNodeByNamePrametersTypes = new Type[] { typeof(string), typeof(XmlNodeList) };
            object[] parametersOfGetNodeByName = { name, nl };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetNodeByName, methodGetNodeByNamePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridData, XmlNode>(_gridDataInstanceFixture, out exception1, parametersOfGetNodeByName);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridData, XmlNode>(_gridDataInstance, MethodGetNodeByName, parametersOfGetNodeByName, methodGetNodeByNamePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetNodeByName.ShouldNotBeNull();
            parametersOfGetNodeByName.Length.ShouldBe(2);
            methodGetNodeByNamePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetNodeByName) (Return Type : XmlNode) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetNodeByName_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var nl = CreateType<XmlNodeList>();
            var methodGetNodeByNamePrametersTypes = new Type[] { typeof(string), typeof(XmlNodeList) };
            object[] parametersOfGetNodeByName = { name, nl };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetNodeByName, methodGetNodeByNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfGetNodeByName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetNodeByName.ShouldNotBeNull();
            parametersOfGetNodeByName.Length.ShouldBe(2);
            methodGetNodeByNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetNodeByName) (Return Type : XmlNode) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetNodeByName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var nl = CreateType<XmlNodeList>();
            var methodGetNodeByNamePrametersTypes = new Type[] { typeof(string), typeof(XmlNodeList) };
            object[] parametersOfGetNodeByName = { name, nl };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridData, XmlNode>(_gridDataInstance, MethodGetNodeByName, parametersOfGetNodeByName, methodGetNodeByNamePrametersTypes);

            // Assert
            parametersOfGetNodeByName.ShouldNotBeNull();
            parametersOfGetNodeByName.Length.ShouldBe(2);
            methodGetNodeByNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetNodeByName) (Return Type : XmlNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetNodeByName_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetNodeByNamePrametersTypes = new Type[] { typeof(string), typeof(XmlNodeList) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetNodeByName, Fixture, methodGetNodeByNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetNodeByNamePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetNodeByName) (Return Type : XmlNode) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetNodeByName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetNodeByNamePrametersTypes = new Type[] { typeof(string), typeof(XmlNodeList) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetNodeByName, Fixture, methodGetNodeByNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetNodeByNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetNodeByName) (Return Type : XmlNode) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetNodeByName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetNodeByName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetNodeByName) (Return Type : XmlNode) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetNodeByName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetNodeByName, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessChildRows) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_ProcessChildRows_Method_Call_Internally(Type[] types)
        {
            var methodProcessChildRowsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodProcessChildRows, Fixture, methodProcessChildRowsPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessChildRows) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ProcessChildRows_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var nodeData = CreateType<XmlNode>();
            var dt = CreateType<DataTable>();
            var methodProcessChildRowsPrametersTypes = new Type[] { typeof(XmlNode), typeof(DataTable) };
            object[] parametersOfProcessChildRows = { nodeData, dt };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessChildRows, methodProcessChildRowsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfProcessChildRows);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessChildRows.ShouldNotBeNull();
            parametersOfProcessChildRows.Length.ShouldBe(2);
            methodProcessChildRowsPrametersTypes.Length.ShouldBe(2);
            methodProcessChildRowsPrametersTypes.Length.ShouldBe(parametersOfProcessChildRows.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessChildRows) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ProcessChildRows_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var nodeData = CreateType<XmlNode>();
            var dt = CreateType<DataTable>();
            var methodProcessChildRowsPrametersTypes = new Type[] { typeof(XmlNode), typeof(DataTable) };
            object[] parametersOfProcessChildRows = { nodeData, dt };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridDataInstance, MethodProcessChildRows, parametersOfProcessChildRows, methodProcessChildRowsPrametersTypes);

            // Assert
            parametersOfProcessChildRows.ShouldNotBeNull();
            parametersOfProcessChildRows.Length.ShouldBe(2);
            methodProcessChildRowsPrametersTypes.Length.ShouldBe(2);
            methodProcessChildRowsPrametersTypes.Length.ShouldBe(parametersOfProcessChildRows.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessChildRows) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ProcessChildRows_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessChildRows, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessChildRows) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ProcessChildRows_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessChildRowsPrametersTypes = new Type[] { typeof(XmlNode), typeof(DataTable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodProcessChildRows, Fixture, methodProcessChildRowsPrametersTypes);

            // Assert
            methodProcessChildRowsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessChildRows) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_ProcessChildRows_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessChildRows, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsHyperLink) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_IsHyperLink_Method_Call_Internally(Type[] types)
        {
            var methodIsHyperLinkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodIsHyperLink, Fixture, methodIsHyperLinkPrametersTypes);
        }

        #endregion

        #region Method Call : (IsHyperLink) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_IsHyperLink_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var fieldName = CreateType<string>();
            var fieldIndexInView = CreateType<int>();
            var methodIsHyperLinkPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfIsHyperLink = { fieldName, fieldIndexInView };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsHyperLink, methodIsHyperLinkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridData, bool>(_gridDataInstanceFixture, out exception1, parametersOfIsHyperLink);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridData, bool>(_gridDataInstance, MethodIsHyperLink, parametersOfIsHyperLink, methodIsHyperLinkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsHyperLink.ShouldNotBeNull();
            parametersOfIsHyperLink.Length.ShouldBe(2);
            methodIsHyperLinkPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (IsHyperLink) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_IsHyperLink_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var fieldName = CreateType<string>();
            var fieldIndexInView = CreateType<int>();
            var methodIsHyperLinkPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfIsHyperLink = { fieldName, fieldIndexInView };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsHyperLink, methodIsHyperLinkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridData, bool>(_gridDataInstanceFixture, out exception1, parametersOfIsHyperLink);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridData, bool>(_gridDataInstance, MethodIsHyperLink, parametersOfIsHyperLink, methodIsHyperLinkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsHyperLink.ShouldNotBeNull();
            parametersOfIsHyperLink.Length.ShouldBe(2);
            methodIsHyperLinkPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (IsHyperLink) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_IsHyperLink_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var fieldName = CreateType<string>();
            var fieldIndexInView = CreateType<int>();
            var methodIsHyperLinkPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfIsHyperLink = { fieldName, fieldIndexInView };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIsHyperLink, methodIsHyperLinkPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfIsHyperLink);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfIsHyperLink.ShouldNotBeNull();
            parametersOfIsHyperLink.Length.ShouldBe(2);
            methodIsHyperLinkPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsHyperLink) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_IsHyperLink_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldName = CreateType<string>();
            var fieldIndexInView = CreateType<int>();
            var methodIsHyperLinkPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfIsHyperLink = { fieldName, fieldIndexInView };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridData, bool>(_gridDataInstance, MethodIsHyperLink, parametersOfIsHyperLink, methodIsHyperLinkPrametersTypes);

            // Assert
            parametersOfIsHyperLink.ShouldNotBeNull();
            parametersOfIsHyperLink.Length.ShouldBe(2);
            methodIsHyperLinkPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsHyperLink) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_IsHyperLink_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsHyperLinkPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodIsHyperLink, Fixture, methodIsHyperLinkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsHyperLinkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsHyperLink) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_IsHyperLink_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsHyperLink, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (IsHyperLink) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_IsHyperLink_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsHyperLink, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitViewFieldNames) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_InitViewFieldNames_Method_Call_Internally(Type[] types)
        {
            var methodInitViewFieldNamesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodInitViewFieldNames, Fixture, methodInitViewFieldNamesPrametersTypes);
        }

        #endregion
        
        #region Method Call : (InitViewFieldNames) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitViewFieldNames_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitViewFieldNamesPrametersTypes = null;
            object[] parametersOfInitViewFieldNames = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridDataInstance, MethodInitViewFieldNames, parametersOfInitViewFieldNames, methodInitViewFieldNamesPrametersTypes);

            // Assert
            parametersOfInitViewFieldNames.ShouldBeNull();
            methodInitViewFieldNamesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitViewFieldNames) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitViewFieldNames_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitViewFieldNamesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodInitViewFieldNames, Fixture, methodInitViewFieldNamesPrametersTypes);

            // Assert
            methodInitViewFieldNamesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitViewFieldNames) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitViewFieldNames_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitViewFieldNames, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDupFieldName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_GetDupFieldName_Method_Call_Internally(Type[] types)
        {
            var methodGetDupFieldNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetDupFieldName, Fixture, methodGetDupFieldNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetDupFieldName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetDupFieldName_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodGetDupFieldNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetDupFieldName = { name };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetDupFieldName, methodGetDupFieldNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfGetDupFieldName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDupFieldName.ShouldNotBeNull();
            parametersOfGetDupFieldName.Length.ShouldBe(1);
            methodGetDupFieldNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDupFieldName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetDupFieldName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodGetDupFieldNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetDupFieldName = { name };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridData, string>(_gridDataInstance, MethodGetDupFieldName, parametersOfGetDupFieldName, methodGetDupFieldNamePrametersTypes);

            // Assert
            parametersOfGetDupFieldName.ShouldNotBeNull();
            parametersOfGetDupFieldName.Length.ShouldBe(1);
            methodGetDupFieldNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDupFieldName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetDupFieldName_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDupFieldNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetDupFieldName, Fixture, methodGetDupFieldNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDupFieldNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDupFieldName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetDupFieldName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDupFieldNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodGetDupFieldName, Fixture, methodGetDupFieldNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDupFieldNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDupFieldName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetDupFieldName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDupFieldName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetDupFieldName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_GetDupFieldName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDupFieldName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveNonViewFields) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_RemoveNonViewFields_Method_Call_Internally(Type[] types)
        {
            var methodRemoveNonViewFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodRemoveNonViewFields, Fixture, methodRemoveNonViewFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveNonViewFields) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_RemoveNonViewFields_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<DataTable>();
            var methodRemoveNonViewFieldsPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfRemoveNonViewFields = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRemoveNonViewFields, methodRemoveNonViewFieldsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridData, DataTable>(_gridDataInstanceFixture, out exception1, parametersOfRemoveNonViewFields);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridData, DataTable>(_gridDataInstance, MethodRemoveNonViewFields, parametersOfRemoveNonViewFields, methodRemoveNonViewFieldsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRemoveNonViewFields.ShouldNotBeNull();
            parametersOfRemoveNonViewFields.Length.ShouldBe(1);
            methodRemoveNonViewFieldsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RemoveNonViewFields) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_RemoveNonViewFields_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<DataTable>();
            var methodRemoveNonViewFieldsPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfRemoveNonViewFields = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridData, DataTable>(_gridDataInstance, MethodRemoveNonViewFields, parametersOfRemoveNonViewFields, methodRemoveNonViewFieldsPrametersTypes);

            // Assert
            parametersOfRemoveNonViewFields.ShouldNotBeNull();
            parametersOfRemoveNonViewFields.Length.ShouldBe(1);
            methodRemoveNonViewFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveNonViewFields) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_RemoveNonViewFields_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRemoveNonViewFieldsPrametersTypes = new Type[] { typeof(DataTable) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodRemoveNonViewFields, Fixture, methodRemoveNonViewFieldsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRemoveNonViewFieldsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RemoveNonViewFields) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_RemoveNonViewFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemoveNonViewFieldsPrametersTypes = new Type[] { typeof(DataTable) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodRemoveNonViewFields, Fixture, methodRemoveNonViewFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRemoveNonViewFieldsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveNonViewFields) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_RemoveNonViewFields_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveNonViewFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RemoveNonViewFields) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_RemoveNonViewFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRemoveNonViewFields, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitGanttParams) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridData_InitGanttParams_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodInitGanttParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodInitGanttParams, Fixture, methodInitGanttParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (InitGanttParams) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitGanttParams_Method_Call_Void_Overloading_Of_1_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodInitGanttParamsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfInitGanttParams = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitGanttParams, methodInitGanttParamsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDataInstanceFixture, parametersOfInitGanttParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitGanttParams.ShouldNotBeNull();
            parametersOfInitGanttParams.Length.ShouldBe(1);
            methodInitGanttParamsPrametersTypes.Length.ShouldBe(1);
            methodInitGanttParamsPrametersTypes.Length.ShouldBe(parametersOfInitGanttParams.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitGanttParams) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitGanttParams_Method_Call_Void_Overloading_Of_1_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodInitGanttParamsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfInitGanttParams = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridDataInstance, MethodInitGanttParams, parametersOfInitGanttParams, methodInitGanttParamsPrametersTypes);

            // Assert
            parametersOfInitGanttParams.ShouldNotBeNull();
            parametersOfInitGanttParams.Length.ShouldBe(1);
            methodInitGanttParamsPrametersTypes.Length.ShouldBe(1);
            methodInitGanttParamsPrametersTypes.Length.ShouldBe(parametersOfInitGanttParams.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitGanttParams) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitGanttParams_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitGanttParamsPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDataInstance, MethodInitGanttParams, Fixture, methodInitGanttParamsPrametersTypes);

            // Assert
            methodInitGanttParamsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitGanttParams) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridData_InitGanttParams_Method_Call_Overloading_Of_1_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitGanttParams, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}