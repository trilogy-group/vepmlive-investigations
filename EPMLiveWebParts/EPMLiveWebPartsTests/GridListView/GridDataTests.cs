using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Xml;
using EPMLiveWebParts.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.JSGrid;
using Microsoft.SharePoint.JSGrid.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class GridDataTests
    {
        private GridData testObject;
        private PrivateObject privateObject;
        private IDisposable shimsContext;
        private BindingFlags publicStatic;
        private BindingFlags publicInstance;
        private BindingFlags nonPublicInstance;
        private ShimSPWeb spWeb;
        private ShimSPSite spSite;
        private ShimSPListCollection spListCollection;
        private ShimSPList spList;
        private ShimSPListItemCollection spListItemCollection;
        private ShimSPListItem spListItem;
        private ShimSPFieldCollection spFieldCollection;
        private ShimSPField spField;
        private ShimSPViewCollection spViewCollection;
        private ShimSPView spView;
        private ShimSPViewFieldCollection spViewFieldCollection;
        private Guid guid;
        private Hashtable GanttParameters;
        private DateTime currentDateTime;
        private int validations;
        private const int DummyInt = 1;
        private const int Zero = 0;
        private const int One = 1;
        private const int Two = 2;
        private const int Three = 3;
        private const int Four = 4;
        private const int Five = 5;
        private const string SampleGuidString1 = "83e81819-0112-4c22-bb70-d8ba101e9e0c";
        private const string SampleGuidString2 = "83e81819-0104-4c22-bb70-d8ba101e9e0c";
        private const string DummyString = "DummyString";
        private const string IDStringCaps = "ID";
        private const string SampleUrl = "http://www.sampleurl.com";
        private const string HierarchyParentKeyString = "HierarchyParentKey";
        private const string KeyString = "Key";
        private const string IdNumberString = "idno";
        private const string RowIdString = "rowid";
        private const string SPListFieldName = "_spList";
        private const string SPViewFieldName = "_spView";
        private const string GanttParamtetersFieldName = "_htGanttParams";
        private const string LTypeFieldName = "LType";
        private const string EditString = "Edit";
        private const string SPViewFieldsFieldName = "_spvwFields";
        private const string RequiredFieldsFieldName = "_reqdfields";
        private const string ImageColumnsFieldName = "_imageColumns";
        private const string ColumnDefinitionsFieldName = "_columnDefinitions";
        private const string FieldNamesFieldName = "_fieldNames";
        private const string WbsFieldName = "_wbs";
        private const string RollupListsFieldName = "_rollupLists";
        private const string RollupSitesFieldName = "_rollupSites";
        private const string UseCurrentFieldName = "_useCurrent";
        private const string FieldsAddedToViewFieldName = "_fieldsAddedToView";
        private const string GanttStartFieldPropertyName = "GanttStartField";
        private const string GanttFinishFieldPropertyName = "GanttFinishField";
        private const string GanttStartDateFieldName = "_ganttStartDate";
        private const string GanttFinishDateFieldName = "_ganttFinishDate";
        private const string NodeDataFieldName = "_htNodeData";
        private const string ImagesFieldName = "_images";
        private const string ImagesClientSideFieldName = "_imagesClientSide";
        private const string DisplayNameColumn = "DisplayName";
        private const string IsImageColumn = "IsImage";
        private const string ColumnTypeColumn = "ColumnType";
        private const string InternalNameColumn = "InternalName";
        private const string TrueStringLowerCase = "true";
        private const string IsHyperLinkColumn = "IsHyperLink";
        private const string XmlDocFieldName = "_xmlDoc";
        private const string GlobalIndexFieldName = "_globalIndex";
        private const string ImagesHashTableFieldName = "_htImages";
        private const string GetListIDMethodName = "GetListID";
        private const string UsePopupMethodName = "UsePopup";
        private const string GetActionMethodName = "GetAction";
        private const string GetGridColumnsMethodName = "GetGridColumns";
        private const string InitGanttParamsMethodName = "InitGanttParams";
        private const string InitializeReqdFieldsMethodName = "InitializeReqdFields";
        private const string AddColumnsMethodName = "AddColumns";
        private const string GetGridFieldsMethodName = "GetGridFields";
        private const string FormatGridFieldMethodName = "formatGridField";
        private const string GetInternalNameMethodName = "GetInternalName";
        private const string GetOrderByFieldMethodName = "GetOrderByField";
        private const string InitRoutineMethodName = "InitRoutine";
        private const string ConvertXmlToDatatableMethodName = "ConvertXmlToDatatable";
        private const string InitializeGanttStartAndFinishMethodName = "InitializeGanttStartAndFinish";
        private const string FinalizeDataMethodName = "FinalizeData";
        private const string AddRowHierarchyMethodName = "AddRowHierarchy";
        private const string AddReqdFieldsToViewMethodName = "AddReqdFieldsToView";
        private const string RemoveReqdFieldsFromViewMethodName = "RemoveReqdFieldsFromView";
        private const string InitializeColumnDefsMethodName = "InitializeColumnDefs";
        private const string LoadDataMethodName = "LoadData";
        private const string PopulateViewFieldValuesMethodName = "PopulateViewFieldValues";
        private const string PopulateDefaultFieldValuesMethodName = "PopulateDefaultFieldValues";
        private const string CalcPercentCompleteMethodName = "CalcPercentComplete";
        private const string GetGanttStartDateMethodName = "GetGanttStartDate";
        private const string GetGanttFinishDateMethodName = "GetGanttFinishDate";
        private const string ApplyGanttStyleMethodName = "ApplyGanttStyle";
        private const string ApplyGanttStylesMethodName = "ApplyGanttStyles";
        private const string GetNodeByNameMethodName = "GetNodeByName";

        [TestInitialize]
        public void Setup()
        {
            testObject = new GridData();
            privateObject = new PrivateObject(testObject);

            SetupShims();

            privateObject.SetFieldOrProperty(SPListFieldName, nonPublicInstance, spList.Instance);
            privateObject.SetFieldOrProperty(SPViewFieldName, nonPublicInstance, spView.Instance);
        }

        private void SetupShims()
        {
            shimsContext = ShimsContext.Create();
            SetupVariables();

            ShimSPSite.ConstructorString = (_, __) => new ShimSPSite();
            ShimSPSite.ConstructorGuid = (_, __) => new ShimSPSite();
            ShimSPSite.AllInstances.AllWebsGet = _ => new ShimSPWebCollection();
            ShimSPSite.AllInstances.OpenWeb = _ => spWeb;
            ShimSPSite.AllInstances.Dispose = _ => { };
            ShimSPWeb.AllInstances.Dispose = _ => { };
            ShimSPWebCollection.AllInstances.ItemGetGuid = (_, __) => spWeb;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => spWeb;
            ShimSPContext.AllInstances.SiteGet = _ => spSite;
        }

        private void SetupVariables()
        {
            validations = 0;
            publicStatic = BindingFlags.Static | BindingFlags.Public;
            publicInstance = BindingFlags.Instance | BindingFlags.Public;
            nonPublicInstance = BindingFlags.Instance | BindingFlags.NonPublic;
            guid = Guid.Parse(SampleGuidString1);
            currentDateTime = DateTime.Now;
            spWeb = new ShimSPWeb()
            {
                ListsGet = () => spListCollection,
                GetListFromUrlString = _ => spList,
                Update = () => { }
            };
            spSite = new ShimSPSite();
            spListCollection = new ShimSPListCollection()
            {
                ItemGetString = _ => spList
            };
            spList = new ShimSPList()
            {
                IDGet = () => guid,
                FieldsGet = () => spFieldCollection,
                ItemsGet = () => spListItemCollection,
                ViewsGet = () => spViewCollection,
                Update = () => { }
            };
            spListItemCollection = new ShimSPListItemCollection();
            spListItem = new ShimSPListItem();
            spFieldCollection = new ShimSPFieldCollection()
            {
                GetFieldString = _ => spField
            };
            spField = new ShimSPField()
            {
                TitleGet = () => DummyString,
                InternalNameGet = () => DummyString
            };
            spViewCollection = new ShimSPViewCollection()
            {
                ItemGetString = _ => spView
            };
            spView = new ShimSPView()
            {
                ViewFieldsGet = () => spViewFieldCollection,
                Update = () => { }
            };
            spViewFieldCollection = new ShimSPViewFieldCollection()
            {
                ToStringCollection = () => new StringCollection()
            };
            GanttParameters = new Hashtable();
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void GetListID_WhenCalled_ReturnsListId()
        {
            // Arrange and  Act
            var actual = (Guid)privateObject.Invoke(
                GetListIDMethodName,
                publicStatic,
                new object[]
                {
                    guid,
                    guid,
                    DummyString
                });

            // Assert
            actual.Equals(guid).ShouldBeTrue();
        }

        [TestMethod]
        public void UsePopup_WhenCalled_ReturnsUsePopupValueFromHashTable()
        {
            // Arrange
            GanttParameters.Add(UsePopupMethodName, DummyString);
            privateObject.SetFieldOrProperty(GanttParamtetersFieldName, nonPublicInstance, GanttParameters);

            // Act
            var actual = (string)privateObject.Invoke(UsePopupMethodName, publicInstance, new object[] { });

            // Assert
            actual.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetAction_WhenCalled_ReturnsLTypeValueFromHashTable()
        {
            // Arrange
            GanttParameters.Add(LTypeFieldName, DummyString);
            privateObject.SetFieldOrProperty(GanttParamtetersFieldName, nonPublicInstance, GanttParameters);

            // Act
            var actual = (string)privateObject.Invoke(GetActionMethodName, publicInstance, new object[] { });

            // Assert
            actual.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetGridColumns_WhenCalled_ReturnsListOfGridColumn()
        {
            // Arrange
            var fields = new StringCollection()
            {
                DummyString
            };
            var dataTable = new DataTable();
            var gridColumns = new List<GridColumn>();

            dataTable.Columns.Add(EditString);
            dataTable.Columns.Add(DummyString);

            ShimGridData.AllInstances.GetInternalNameString = (_, input) => input;
            ShimGridData.AllInstances.GetDisplayNameString = (_, input) => input;

            privateObject.SetFieldOrProperty(SPViewFieldsFieldName, nonPublicInstance, fields);

            // Act
            gridColumns.AddRange((IList<GridColumn>)privateObject.Invoke(GetGridColumnsMethodName, publicInstance, new object[] { dataTable }));
            var editColumn = gridColumns.FirstOrDefault(x => x.FieldKey.Equals(EditString));
            var dummyColumn = gridColumns.FirstOrDefault(x => x.FieldKey.Equals(DummyString));

            // Assert
            gridColumns.ShouldSatisfyAllConditions(
                () => gridColumns.Count.ShouldBe(Two),
                () => editColumn.IsVisible.ShouldBeFalse(),
                () => editColumn.IsSortable.ShouldBeTrue(),
                () => editColumn.IsAutoFilterable.ShouldBeTrue(),
                () => editColumn.Width.ShouldBe(50),
                () => dummyColumn.Width.ShouldBe(100));
        }

        [TestMethod]
        public void InitGanttParams_WhenCalled_InitializeGanttParametersFromHashTable()
        {
            // Arrange
            var now = DateTime.Now;

            GanttParameters.Add("Start", now);
            GanttParameters.Add("Finish", now);
            GanttParameters.Add("Percent", One);
            GanttParameters.Add("Milestone", Two);
            GanttParameters.Add("WBS", DummyString);

            privateObject.SetFieldOrProperty(GanttParamtetersFieldName, nonPublicInstance, GanttParameters);

            // Act
            privateObject.Invoke(InitGanttParamsMethodName, nonPublicInstance, new object[] { });

            // Assert
            GanttParameters.ShouldSatisfyAllConditions(
                () => testObject.GanttStartField.ShouldBe(now.ToString()),
                () => testObject.GanttFinishField.ShouldBe(now.ToString()),
                () => testObject.PctComplete.ShouldBe(One.ToString()),
                () => testObject.GanttMilestone.ShouldBe(Two.ToString()),
                () => testObject.WBS.ShouldBe(DummyString));
        }

        [TestMethod]
        public void InitializeReqdFields_WhenCalled_InitializeGanttParametersFromHashTable()
        {
            // Arrange
            spFieldCollection.ContainsFieldString = _ => true;

            // Act
            privateObject.Invoke(InitializeReqdFieldsMethodName, nonPublicInstance, new object[] { });
            var requiredFields = (List<string>)privateObject.GetFieldOrProperty(RequiredFieldsFieldName, nonPublicInstance);

            // Assert
            GanttParameters.ShouldSatisfyAllConditions(
                () => requiredFields.Count.ShouldBe(9),
                () => requiredFields.ShouldContain("Predecessors"),
                () => requiredFields.ShouldContain("Critical"));
        }

        [TestMethod]
        public void AddColumns_WhenCalled_AddsDefaultColumnsToDataTable()
        {
            // Arrange
            var row = default(DataRow);
            var dataTable = new DataTable();

            dataTable.Columns.Add(DisplayNameColumn);
            dataTable.Columns.Add(IsImageColumn);
            dataTable.Columns.Add(ColumnTypeColumn);
            dataTable.Columns.Add(InternalNameColumn);
            row = dataTable.NewRow();
            row[DisplayNameColumn] = DummyString;
            row[IsImageColumn] = TrueStringLowerCase;
            dataTable.Rows.Add(row);

            privateObject.SetFieldOrProperty(ColumnDefinitionsFieldName, nonPublicInstance, dataTable);

            // Act
            var actual = (DataTable)privateObject.Invoke(AddColumnsMethodName, nonPublicInstance, new object[] { dataTable });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Columns.Count.ShouldBe(25),
                () => actual.Rows.Count.ShouldBe(21));
        }

        [TestMethod]
        public void GetGridFields_WhenCalled_ReturnsGridFieldsList()
        {
            // Arrange
            var imageColumns = new List<string>()
            {
                One.ToString(),
                Two.ToString(),
                Three.ToString(),
            };
            var formatGridHit = 0;
            var ganttImageHit = 0;
            var row = default(DataRow);
            var dataTable = new DataTable();

            dataTable.Columns.Add(One.ToString());
            dataTable.Columns.Add(Two.ToString());
            dataTable.Columns.Add(Three.ToString());
            row = dataTable.NewRow();
            dataTable.Rows.Add(row);

            ShimGridData.AllInstances.formatGridFieldGridFieldDataColumn = (_, _1, _2) =>
            {
                formatGridHit += 1;
                var result = new GridField()
                {
                    FieldKey = formatGridHit.ToString()
                };
                if (formatGridHit.Equals(One))
                {
                    result.DefaultCellStyleId = DummyString;
                }
                else if (formatGridHit.Equals(Three))
                {
                    result.DefaultCellStyleId = null;
                }
                return result;
            };
            ShimGanttUtilities.GanttImageHashtableListOfString = (_1, _2) =>
            {
                ganttImageHit += 1;
                if (ganttImageHit.Equals(One) || ganttImageHit.Equals(Four))
                {
                    return null;
                }
                return new LookupTypeInfo(DummyString, new List<LookupTypeItem>());
            };
            ShimGridField.AllInstances.AssociateWithLookupTypeInfoLookupTypeInfo = (_, _1) =>
            {
                validations += 1;
            };
            ShimGridData.AllInstances.GetInternalNameString = (_, input) =>
            {
                validations += 1;
                return input;
            };

            privateObject.SetFieldOrProperty(ImageColumnsFieldName, nonPublicInstance, imageColumns);

            // Act
            var actual = (List<GridField>)privateObject.Invoke(GetGridFieldsMethodName, publicInstance, new object[] { dataTable });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(Three),
                () => actual.FirstOrDefault(x => x.FieldKey.Equals(One.ToString())).DefaultCellStyleId.ShouldBe("ralign"),
                () => actual.FirstOrDefault(x => x.FieldKey.Equals(Two.ToString())).DefaultCellStyleId.ShouldBe("halign"),
                () => actual.FirstOrDefault(x => x.FieldKey.Equals(Three.ToString())).DefaultCellStyleId.ShouldBe("ralign"),
                () => formatGridHit.ShouldBe(Three),
                () => ganttImageHit.ShouldBe(Four),
                () => validations.ShouldBe(Four));
        }

        [TestMethod]
        public void FormatGridField_ColumnDataTypeString_ReturnsGridField()
        {
            // Arrange
            const string expected = "String";
            const string columnName = "Quarter";
            var columnType = typeof(String);
            var dataTable = new DataTable();
            var dataColumn = default(DataColumn);
            var field = new GridField()
            {
                DefaultCellStyleId = DummyString
            };
            var fieldNames = new List<string>()
            {
                "master_checkbox2"
            };
            var viewFields = new StringCollection()
            {
                "linktitle",
                "LinkTitleVersionNoMenu"
            };

            dataTable.Columns.Add(DummyString, columnType);
            dataTable.Columns.Add(columnName, columnType);
            dataColumn = dataTable.Columns[One];

            ShimGridData.AllInstances.GetInternalNameString = (_, input) =>
            {
                validations += 1;
                return input;
            };

            privateObject.SetFieldOrProperty(SPViewFieldsFieldName, nonPublicInstance, viewFields);
            privateObject.SetFieldOrProperty(FieldNamesFieldName, nonPublicInstance, fieldNames);

            // Act
            var actual = (GridField)privateObject.Invoke(FormatGridFieldMethodName, nonPublicInstance, new object[] { field, dataColumn });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.DefaultCellStyleId.ShouldBe("link"),
                () => actual.EditMode.ShouldBe(EditMode.ReadOnly),
                () => actual.TextDirection.ShouldBe(TextDirection.LeftToRight),
                () => actual.PropertyTypeId.ShouldBe(expected),
                () => actual.FieldKey.ShouldBe(columnName),
                () => actual.SerializeLocalizedValue.ShouldBeTrue(),
                () => actual.SerializeDataValue.ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void FormatGridField_ColumnDataTypeInt_ReturnsGridField()
        {
            // Arrange
            const string expected = "JSNumber";
            const string columnName = "costq";
            var columnType = typeof(Int32);
            var dataTable = new DataTable();
            var dataColumn = default(DataColumn);
            var field = new GridField()
            {
                DefaultCellStyleId = DummyString
            };
            var fieldNames = new List<string>()
            {
                "master_checkbox2"
            };
            var viewFields = new StringCollection()
            {
                "linktitle",
                "LinkTitleVersionNoMenu"
            };

            dataTable.Columns.Add(DummyString, columnType);
            dataTable.Columns.Add(columnName, columnType);
            dataColumn = dataTable.Columns[One];

            ShimGridData.AllInstances.GetInternalNameString = (_, input) =>
            {
                validations += 1;
                return input;
            };

            privateObject.SetFieldOrProperty(SPViewFieldsFieldName, nonPublicInstance, viewFields);
            privateObject.SetFieldOrProperty(FieldNamesFieldName, nonPublicInstance, fieldNames);

            // Act
            var actual = (GridField)privateObject.Invoke(FormatGridFieldMethodName, nonPublicInstance, new object[] { field, dataColumn });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.DefaultCellStyleId.ShouldBe("link"),
                () => actual.EditMode.ShouldBe(EditMode.ReadOnly),
                () => actual.TextDirection.ShouldBe(TextDirection.LeftToRight),
                () => actual.PropertyTypeId.ShouldBe(expected),
                () => actual.FieldKey.ShouldBe(columnName),
                () => actual.SerializeLocalizedValue.ShouldBeTrue(),
                () => actual.SerializeDataValue.ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void FormatGridField_ColumnDataTypeLookupTypeItem_ReturnsGridField()
        {
            // Arrange
            const string expected = "GanttImage";
            const string columnName = "Quarter";
            var columnType = typeof(LookupTypeItem);
            var dataTable = new DataTable();
            var dataColumn = default(DataColumn);
            var field = new GridField()
            {
                DefaultCellStyleId = DummyString
            };
            var fieldNames = new List<string>()
            {
                "master_checkbox2"
            };
            var viewFields = new StringCollection()
            {
                "linktitle",
                "LinkTitleVersionNoMenu"
            };

            dataTable.Columns.Add(DummyString, columnType);
            dataTable.Columns.Add(columnName, columnType);
            dataColumn = dataTable.Columns[One];

            ShimGridData.AllInstances.GetInternalNameString = (_, input) =>
            {
                validations += 1;
                return input;
            };

            privateObject.SetFieldOrProperty(SPViewFieldsFieldName, nonPublicInstance, viewFields);
            privateObject.SetFieldOrProperty(FieldNamesFieldName, nonPublicInstance, fieldNames);

            // Act
            var actual = (GridField)privateObject.Invoke(FormatGridFieldMethodName, nonPublicInstance, new object[] { field, dataColumn });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.DefaultCellStyleId.ShouldBe("link"),
                () => actual.EditMode.ShouldBe(EditMode.ReadOnly),
                () => actual.TextDirection.ShouldBe(TextDirection.LeftToRight),
                () => actual.PropertyTypeId.ShouldBe(expected),
                () => actual.FieldKey.ShouldBe(columnName),
                () => actual.SerializeLocalizedValue.ShouldBeTrue(),
                () => actual.SerializeDataValue.ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void FormatGridField_ColumnDataTypeHyperlink_ReturnsGridField()
        {
            // Arrange
            const string expected = "Hyperlink";
            const string columnName = "Quarter";
            var columnType = typeof(Hyperlink);
            var dataTable = new DataTable();
            var dataColumn = default(DataColumn);
            var field = new GridField()
            {
                DefaultCellStyleId = DummyString
            };
            var fieldNames = new List<string>()
            {
                "master_checkbox2"
            };
            var viewFields = new StringCollection()
            {
                "linktitle",
                "LinkTitleVersionNoMenu"
            };

            dataTable.Columns.Add(DummyString, columnType);
            dataTable.Columns.Add(columnName, columnType);
            dataColumn = dataTable.Columns[One];

            ShimGridData.AllInstances.GetInternalNameString = (_, input) =>
            {
                validations += 1;
                return input;
            };

            privateObject.SetFieldOrProperty(SPViewFieldsFieldName, nonPublicInstance, viewFields);
            privateObject.SetFieldOrProperty(FieldNamesFieldName, nonPublicInstance, fieldNames);

            // Act
            var actual = (GridField)privateObject.Invoke(FormatGridFieldMethodName, nonPublicInstance, new object[] { field, dataColumn });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.DefaultCellStyleId.ShouldBe("link"),
                () => actual.EditMode.ShouldBe(EditMode.ReadOnly),
                () => actual.TextDirection.ShouldBe(TextDirection.LeftToRight),
                () => actual.PropertyTypeId.ShouldBe(expected),
                () => actual.FieldKey.ShouldBe(columnName),
                () => actual.SerializeLocalizedValue.ShouldBeFalse(),
                () => actual.SerializeDataValue.ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void FormatGridField_ColumnDataTypeBoolean_ReturnsGridField()
        {
            // Arrange
            const string expected = "CheckBoxBoolean";
            const string columnName = "Quarter";
            var columnType = typeof(bool);
            var dataTable = new DataTable();
            var dataColumn = default(DataColumn);
            var field = new GridField()
            {
                DefaultCellStyleId = DummyString
            };
            var fieldNames = new List<string>()
            {
                "master_checkbox2"
            };
            var viewFields = new StringCollection()
            {
                "linktitle",
                "LinkTitleVersionNoMenu"
            };

            dataTable.Columns.Add(DummyString, columnType);
            dataTable.Columns.Add(columnName, columnType);
            dataColumn = dataTable.Columns[One];

            ShimGridData.AllInstances.GetInternalNameString = (_, input) =>
            {
                validations += 1;
                return input;
            };

            privateObject.SetFieldOrProperty(SPViewFieldsFieldName, nonPublicInstance, viewFields);
            privateObject.SetFieldOrProperty(FieldNamesFieldName, nonPublicInstance, fieldNames);

            // Act
            var actual = (GridField)privateObject.Invoke(FormatGridFieldMethodName, nonPublicInstance, new object[] { field, dataColumn });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.DefaultCellStyleId.ShouldBe("link"),
                () => actual.EditMode.ShouldBe(EditMode.ReadOnly),
                () => actual.TextDirection.ShouldBe(TextDirection.LeftToRight),
                () => actual.PropertyTypeId.ShouldBe(expected),
                () => actual.FieldKey.ShouldBe(columnName),
                () => actual.SerializeLocalizedValue.ShouldBeFalse(),
                () => actual.SerializeDataValue.ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void FormatGridField_ColumnDataTypeDateTime_ReturnsGridField()
        {
            // Arrange
            const string expected = "JSDateTime";
            const string columnName = "Quarter";
            var columnType = typeof(DateTime);
            var dataTable = new DataTable();
            var dataColumn = default(DataColumn);
            var field = new GridField()
            {
                DefaultCellStyleId = DummyString
            };
            var fieldNames = new List<string>()
            {
                "master_checkbox2"
            };
            var viewFields = new StringCollection()
            {
                "linktitle",
                "LinkTitleVersionNoMenu"
            };

            dataTable.Columns.Add(DummyString, columnType);
            dataTable.Columns.Add(columnName, columnType);
            dataColumn = dataTable.Columns[One];

            ShimGridData.AllInstances.GetInternalNameString = (_, input) =>
            {
                validations += 1;
                return input;
            };

            privateObject.SetFieldOrProperty(SPViewFieldsFieldName, nonPublicInstance, viewFields);
            privateObject.SetFieldOrProperty(FieldNamesFieldName, nonPublicInstance, fieldNames);

            // Act
            var actual = (GridField)privateObject.Invoke(FormatGridFieldMethodName, nonPublicInstance, new object[] { field, dataColumn });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.DefaultCellStyleId.ShouldBe("link"),
                () => actual.EditMode.ShouldBe(EditMode.ReadOnly),
                () => actual.TextDirection.ShouldBe(TextDirection.LeftToRight),
                () => actual.PropertyTypeId.ShouldBe(expected),
                () => actual.FieldKey.ShouldBe(columnName),
                () => actual.SerializeLocalizedValue.ShouldBeTrue(),
                () => actual.SerializeDataValue.ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void FormatGridField_ColumnDataTypeGuid_ReturnsGridField()
        {
            // Arrange
            const string expected = "String";
            const string columnName = "Quarter";
            var columnType = typeof(Guid);
            var dataTable = new DataTable();
            var dataColumn = default(DataColumn);
            var field = new GridField()
            {
                DefaultCellStyleId = DummyString
            };
            var fieldNames = new List<string>()
            {
                "master_checkbox2"
            };
            var viewFields = new StringCollection()
            {
                "linktitle",
                "LinkTitleVersionNoMenu"
            };

            dataTable.Columns.Add(DummyString, columnType);
            dataTable.Columns.Add(columnName, columnType);
            dataColumn = dataTable.Columns[One];

            ShimGridData.AllInstances.GetInternalNameString = (_, input) =>
            {
                validations += 1;
                return input;
            };

            privateObject.SetFieldOrProperty(SPViewFieldsFieldName, nonPublicInstance, viewFields);
            privateObject.SetFieldOrProperty(FieldNamesFieldName, nonPublicInstance, fieldNames);

            // Act
            var actual = (GridField)privateObject.Invoke(FormatGridFieldMethodName, nonPublicInstance, new object[] { field, dataColumn });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.DefaultCellStyleId.ShouldBe("link"),
                () => actual.EditMode.ShouldBe(EditMode.ReadOnly),
                () => actual.TextDirection.ShouldBe(TextDirection.LeftToRight),
                () => actual.PropertyTypeId.ShouldBe(expected),
                () => actual.FieldKey.ShouldBe(columnName),
                () => actual.SerializeLocalizedValue.ShouldBeTrue(),
                () => actual.SerializeDataValue.ShouldBeFalse(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void FormatGridField_ColumnDataTypeDouble_ReturnsGridField()
        {
            // Arrange
            const string expected = "JSNumber";
            const string columnName = "Quarter";
            var columnType = typeof(Double);
            var dataTable = new DataTable();
            var dataColumn = default(DataColumn);
            var field = new GridField()
            {
                DefaultCellStyleId = DummyString
            };
            var fieldNames = new List<string>()
            {
                "master_checkbox2"
            };
            var viewFields = new StringCollection()
            {
                "linktitle",
                "LinkTitleVersionNoMenu"
            };

            dataTable.Columns.Add(DummyString, columnType);
            dataTable.Columns.Add(columnName, columnType);
            dataColumn = dataTable.Columns[One];

            ShimGridData.AllInstances.GetInternalNameString = (_, input) =>
            {
                validations += 1;
                return input;
            };

            privateObject.SetFieldOrProperty(SPViewFieldsFieldName, nonPublicInstance, viewFields);
            privateObject.SetFieldOrProperty(FieldNamesFieldName, nonPublicInstance, fieldNames);

            // Act
            var actual = (GridField)privateObject.Invoke(FormatGridFieldMethodName, nonPublicInstance, new object[] { field, dataColumn });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.DefaultCellStyleId.ShouldBe("link"),
                () => actual.EditMode.ShouldBe(EditMode.ReadOnly),
                () => actual.TextDirection.ShouldBe(TextDirection.LeftToRight),
                () => actual.PropertyTypeId.ShouldBe(expected),
                () => actual.FieldKey.ShouldBe(columnName),
                () => actual.SerializeLocalizedValue.ShouldBeTrue(),
                () => actual.SerializeDataValue.ShouldBeFalse(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void GetInternalName_WhenCalled_ReturnsInternalName()
        {
            // Arrange
            spFieldCollection.ContainsFieldString = _ =>
            {
                validations += 1;
                return true;
            };

            // Act
            var actual = (string)privateObject.Invoke(GetInternalNameMethodName, nonPublicInstance, new object[] { string.Empty });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(DummyString),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void GetOrderByField_WbsFieldEqualsWBS_ReturnsWbs()
        {
            // Arrange
            const string wbs = "WBS";
            const string title = "Task Center";

            spList.TitleGet = () =>
            {
                validations += 1;
                return title;
            };
            spView.QueryGet = () =>
            {
                validations += 1;
                return string.Empty;
            };

            privateObject.SetFieldOrProperty(SPListFieldName, nonPublicInstance, spList.Instance);
            privateObject.SetFieldOrProperty(SPViewFieldName, nonPublicInstance, spView.Instance);
            privateObject.SetFieldOrProperty(WbsFieldName, nonPublicInstance, wbs);

            // Act
            var actual = (string)privateObject.Invoke(GetOrderByFieldMethodName, nonPublicInstance, new object[] { });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(wbs),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void GetOrderByField_WbsFieldNotEqualsWBS_ReturnsWbs()
        {
            // Arrange
            const string wbs = "NotWBS";
            const string title = "Task Center";
            const string expected = "Outline Number";
            const string query = @"
                <OrderBy>
                    <Field Name=""FieldName""/>
                </OrderBy>";

            spList.TitleGet = () =>
            {
                validations += 1;
                return title;
            };

            spView.QueryGet = () =>
            {
                validations += 1;
                return query;
            };

            privateObject.SetFieldOrProperty(SPListFieldName, nonPublicInstance, spList.Instance);
            privateObject.SetFieldOrProperty(SPViewFieldName, nonPublicInstance, spView.Instance);
            privateObject.SetFieldOrProperty(WbsFieldName, nonPublicInstance, wbs);

            // Act
            var actual = (string)privateObject.Invoke(GetOrderByFieldMethodName, nonPublicInstance, new object[] { });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void GetOrderByField_WbsFieldEmpty_ReturnsWbs()
        {
            // Arrange
            const string expected = "Task ID";
            const string title = "Task Center";

            spList.TitleGet = () =>
            {
                validations += 1;
                return title;
            };
            spView.QueryGet = () =>
            {
                validations += 1;
                return string.Empty;
            };

            privateObject.SetFieldOrProperty(SPListFieldName, nonPublicInstance, spList.Instance);
            privateObject.SetFieldOrProperty(SPViewFieldName, nonPublicInstance, spView.Instance);
            privateObject.SetFieldOrProperty(WbsFieldName, nonPublicInstance, string.Empty);

            // Act
            var actual = (string)privateObject.Invoke(GetOrderByFieldMethodName, nonPublicInstance, new object[] { });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void InitRoutine_UrlPresent_InitiaizesRoutine()
        {
            // Arrange
            var stringArray = new string[]
            {
                SampleUrl
            };
            var parameters = new object[]
            {
                true
            };

            GanttParameters.Add("List", DummyString);
            GanttParameters.Add("View", DummyString);

            spSite.UrlGet = () => SampleUrl;

            ShimGridData.AllInstances.InitGanttParamsString = (_, __) =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(SPListFieldName, nonPublicInstance, null);
            privateObject.SetFieldOrProperty(SPViewFieldName, nonPublicInstance, null);
            privateObject.SetFieldOrProperty(GanttParamtetersFieldName, nonPublicInstance, GanttParameters);
            privateObject.SetFieldOrProperty(RollupListsFieldName, nonPublicInstance, stringArray);
            privateObject.SetFieldOrProperty(RollupSitesFieldName, nonPublicInstance, stringArray);

            // Act
            privateObject.Invoke(InitRoutineMethodName, publicInstance, parameters);
            var list = privateObject.GetFieldOrProperty(SPListFieldName, nonPublicInstance);
            var view = privateObject.GetFieldOrProperty(SPViewFieldName, nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => list.ShouldNotBeNull(),
                () => view.ShouldNotBeNull(),
                () => ((bool)parameters[0]).ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void InitRoutine_UrlNotPresent_InitiaizesRoutine()
        {
            // Arrange
            var stringArray = new string[]
            {
                DummyString
            };
            var parameters = new object[]
            {
                true
            };

            GanttParameters.Add("List", DummyString);
            GanttParameters.Add("View", DummyString);

            spSite.UrlGet = () => SampleUrl;

            ShimGridData.AllInstances.InitGanttParamsString = (_, __) =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(SPListFieldName, nonPublicInstance, null);
            privateObject.SetFieldOrProperty(SPViewFieldName, nonPublicInstance, null);
            privateObject.SetFieldOrProperty(GanttParamtetersFieldName, nonPublicInstance, GanttParameters);
            privateObject.SetFieldOrProperty(RollupListsFieldName, nonPublicInstance, stringArray);
            privateObject.SetFieldOrProperty(RollupSitesFieldName, nonPublicInstance, stringArray);

            // Act
            privateObject.Invoke(InitRoutineMethodName, publicInstance, parameters);
            var list = privateObject.GetFieldOrProperty(SPListFieldName, nonPublicInstance);
            var view = privateObject.GetFieldOrProperty(SPViewFieldName, nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => list.ShouldNotBeNull(),
                () => view.ShouldNotBeNull(),
                () => ((bool)parameters[0]).ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void InitRoutine_RollUpSitesNull_InitiaizesRoutine()
        {
            // Arrange
            var stringArray = new string[]
            {
                DummyString
            };
            var parameters = new object[]
            {
                true
            };

            GanttParameters.Add("List", DummyString);
            GanttParameters.Add("View", DummyString);

            spSite.UrlGet = () => SampleUrl;

            ShimGridData.AllInstances.InitGanttParamsString = (_, __) =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(SPListFieldName, nonPublicInstance, null);
            privateObject.SetFieldOrProperty(SPViewFieldName, nonPublicInstance, null);
            privateObject.SetFieldOrProperty(GanttParamtetersFieldName, nonPublicInstance, GanttParameters);
            privateObject.SetFieldOrProperty(RollupListsFieldName, nonPublicInstance, stringArray);
            privateObject.SetFieldOrProperty(RollupSitesFieldName, nonPublicInstance, null);
            privateObject.SetFieldOrProperty(UseCurrentFieldName, nonPublicInstance, false);

            // Act
            privateObject.Invoke(InitRoutineMethodName, publicInstance, parameters);
            var list = privateObject.GetFieldOrProperty(SPListFieldName, nonPublicInstance);
            var view = privateObject.GetFieldOrProperty(SPViewFieldName, nonPublicInstance);
            var rollupSites = (string[])privateObject.GetFieldOrProperty(RollupSitesFieldName, nonPublicInstance);
            var useCurrent = (bool)privateObject.GetFieldOrProperty(UseCurrentFieldName, nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => list.ShouldNotBeNull(),
                () => view.ShouldNotBeNull(),
                () => ((bool)parameters[0]).ShouldBeTrue(),
                () => rollupSites.Length.ShouldBe(1),
                () => rollupSites[0].ShouldBe(SampleUrl),
                () => useCurrent.ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void InitRoutine_RollupListsNull_InitiaizesRoutine()
        {
            // Arrange
            var stringArray = new string[]
            {
                DummyString
            };
            var parameters = new object[]
            {
                true
            };

            GanttParameters.Add("List", DummyString);
            GanttParameters.Add("View", DummyString);

            spSite.UrlGet = () => SampleUrl;

            ShimGridData.AllInstances.InitGanttParamsString = (_, __) =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(SPListFieldName, nonPublicInstance, null);
            privateObject.SetFieldOrProperty(SPViewFieldName, nonPublicInstance, null);
            privateObject.SetFieldOrProperty(GanttParamtetersFieldName, nonPublicInstance, GanttParameters);
            privateObject.SetFieldOrProperty(RollupListsFieldName, nonPublicInstance, null);
            privateObject.SetFieldOrProperty(RollupSitesFieldName, nonPublicInstance, null);

            // Act
            privateObject.Invoke(InitRoutineMethodName, publicInstance, parameters);
            var list = privateObject.GetFieldOrProperty(SPListFieldName, nonPublicInstance);
            var view = privateObject.GetFieldOrProperty(SPViewFieldName, nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => list.ShouldNotBeNull(),
                () => view.ShouldNotBeNull(),
                () => ((bool)parameters[0]).ShouldBeFalse(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void ConvertXmlToDatatable_WhenCalled_ReturnsDataTable()
        {
            // Arrange
            ShimGridData.AllInstances.InitializeColumnDefsString = (_, __) =>
            {
                validations += 1;
            };
            ShimGridData.AllInstances.AddColumnsDataTable = (_, input) =>
            {
                validations += 1;
                return input;
            };
            ShimGridData.AllInstances.LoadDataDataTable = (_, __) =>
            {
                validations += 1;
            };
            ShimGridData.AllInstances.FinalizeDataDataTable = (_, __) =>
            {
                validations += 1;
            };
            ShimGridData.AllInstances.InitializeGanttStartAndFinishDataTable = (_, __) =>
            {
                validations += 1;
            };

            // Act
            var actual = (DataTable)privateObject.Invoke(ConvertXmlToDatatableMethodName, nonPublicInstance, new object[] { DummyString });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldNotBeNull(),
                () => validations.ShouldBe(5));
        }

        [TestMethod]
        public void InitializeGanttStartAndFinish_WhenCalled_InitializesGanttStartAndFinish()
        {
            // Arrange
            currentDateTime = currentDateTime.Date;

            var row = default(DataRow);
            var dataTable = new DataTable();
            var rows = new string[]
            {
                currentDateTime.AddDays(-1).ToString(),
                currentDateTime.AddDays(-2).ToString(),
                currentDateTime.ToString(),
                currentDateTime.AddDays(1).ToString(),
                currentDateTime.AddDays(2).ToString()
            };

            dataTable.Columns.Add(DummyString);
            foreach (var item in rows)
            {
                row = dataTable.NewRow();
                row[DummyString] = item;
                dataTable.Rows.Add(row);
            }

            spFieldCollection.ContainsFieldString = _ => true;
            privateObject.SetFieldOrProperty(GanttStartFieldPropertyName, publicInstance, DummyString);
            privateObject.SetFieldOrProperty(GanttFinishFieldPropertyName, publicInstance, DummyString);

            // Act
            privateObject.Invoke(InitializeGanttStartAndFinishMethodName, nonPublicInstance, new object[] { dataTable });
            var startDate = privateObject.GetFieldOrProperty(GanttStartDateFieldName, nonPublicInstance);
            var finishDate = privateObject.GetFieldOrProperty(GanttFinishDateFieldName, nonPublicInstance);

            // Assert
            startDate.ShouldSatisfyAllConditions(
                () => startDate.ShouldBe(currentDateTime.AddDays(-2)),
                () => finishDate.ShouldBe(currentDateTime.AddDays(2)));
        }

        [TestMethod]
        public void FinalizeData_WhenCalled_FinalizesData()
        {
            // Arrange
            const string expected = "1,2,3";
            var row = default(DataRow);
            var dataTable = new DataTable();
            var nodeData = new Hashtable()
            {
                [Zero] = default(XmlNode),
                [One] = default(XmlNode)
            };
            var addRowPredecessors = 0;
            var images = new List<string>()
            {
                One.ToString(),
                Two.ToString(),
                Three.ToString(),
            };

            dataTable.Columns.Add(HierarchyParentKeyString, typeof(int));
            dataTable.Columns.Add(KeyString, typeof(int));

            row = dataTable.NewRow();
            row[HierarchyParentKeyString] = Zero;
            row[KeyString] = One;
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row[HierarchyParentKeyString] = One;
            row[KeyString] = Two;
            dataTable.Rows.Add(row);

            ShimGridData.AllInstances.AddRowHierarchyDataRowDataTableXmlNode = (_, rowInput, table, node) =>
            {
                validations += 1;
            };
            ShimGridData.AllInstances.AddRowPredecessorsDataRowDataTable = (_, rowInput, table) =>
            {
                addRowPredecessors += 1;
                if ((int)rowInput[HierarchyParentKeyString] == (int)rowInput[KeyString])
                {
                    validations += 1;
                }
            };
            ShimGanttUtilities.ImageNamesSetListOfString = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(NodeDataFieldName, nonPublicInstance, nodeData);
            privateObject.SetFieldOrProperty(ImagesFieldName, nonPublicInstance, images);
            privateObject.SetFieldOrProperty(ImagesClientSideFieldName, nonPublicInstance, string.Empty);

            // Act
            privateObject.Invoke(FinalizeDataMethodName, nonPublicInstance, new object[] { dataTable });
            var actual = privateObject.GetFieldOrProperty(ImagesClientSideFieldName, nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => addRowPredecessors.ShouldBe(2),
                () => validations.ShouldBe(3));
        }

        [TestMethod]
        public void AddRowHierarchy_ParentNotRows_EditsDataRow()
        {
            // Arrange
            const string xmlString = @"
                <xmlcfg id=""2"">
                    <row/>
                </xmlcfg>";
            var dataXml = new XmlDocument();
            var node = default(XmlNode);
            var row = default(DataRow);
            var dataTable = new DataTable();

            dataTable.Columns.Add(HierarchyParentKeyString, typeof(int));
            dataTable.Columns.Add(KeyString, typeof(int));
            dataTable.Columns.Add(IdNumberString, typeof(int));
            dataTable.Columns.Add(RowIdString, typeof(int));

            row = dataTable.NewRow();
            row[HierarchyParentKeyString] = Zero;
            row[KeyString] = Two;
            row[IdNumberString] = Two;
            row[RowIdString] = Two;
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row[HierarchyParentKeyString] = Zero;
            row[KeyString] = One;
            row[IdNumberString] = One;
            row[RowIdString] = One;

            dataXml.LoadXml(xmlString);
            node = dataXml.FirstChild.FirstChild;

            var parameters = new object[]
            {
                row,
                dataTable,
                node
            };

            // Act
            privateObject.Invoke(AddRowHierarchyMethodName, nonPublicInstance, parameters);
            var actual = (DataRow)parameters[0];

            // Assert
            actual[HierarchyParentKeyString].ToString().ShouldBe(Two.ToString());
        }

        [TestMethod]
        public void AddRowHierarchy_ParentRows_EditsDataRow()
        {
            // Arrange
            const string xmlString = @"
                <rows id=""2"">
                    <row/>
                </rows>";
            var dataXml = new XmlDocument();
            var node = default(XmlNode);
            var row = default(DataRow);
            var dataTable = new DataTable();

            dataTable.Columns.Add(HierarchyParentKeyString, typeof(int));
            dataTable.Columns.Add(KeyString, typeof(int));
            dataTable.Columns.Add(IdNumberString, typeof(int));
            dataTable.Columns.Add(RowIdString, typeof(int));

            row = dataTable.NewRow();
            row[HierarchyParentKeyString] = Zero;
            row[KeyString] = Two;
            row[IdNumberString] = Two;
            row[RowIdString] = Two;
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row[HierarchyParentKeyString] = Zero;
            row[KeyString] = One;
            row[IdNumberString] = One;
            row[RowIdString] = One;

            dataXml.LoadXml(xmlString);
            node = dataXml.FirstChild.FirstChild;

            var parameters = new object[]
            {
                row,
                dataTable,
                node
            };

            // Act
            privateObject.Invoke(AddRowHierarchyMethodName, nonPublicInstance, parameters);
            var actual = (DataRow)parameters[0];

            // Assert
            actual[HierarchyParentKeyString].ToString().ShouldBe(One.ToString());
        }

        [TestMethod]
        public void AddReqdFieldsToView_WhenCalled_ReturnsSPWeb()
        {
            // Arrange
            var stringCollection = new StringCollection()
            {
                DummyString
            };
            var requiredFields = new List<string>()
            {
                DummyString,
                One.ToString()
            };

            GanttParameters.Add("List", DummyString);
            GanttParameters.Add("View", DummyString);

            spFieldCollection.ContainsFieldString = _ => true;
            spWeb.AllowUnsafeUpdatesSetBoolean = input =>
            {
                validations += 1;
            };
            spViewFieldCollection.DeleteAll = () =>
            {
                validations += 1;
            };
            spViewFieldCollection.ToStringCollection = () =>
            {
                validations += 1;
                return stringCollection;
            };
            spViewFieldCollection.AddString = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(GanttParamtetersFieldName, nonPublicInstance, GanttParameters);
            privateObject.SetFieldOrProperty(RequiredFieldsFieldName, nonPublicInstance, requiredFields);

            // Act
            var actual = (SPWeb)privateObject.Invoke(AddReqdFieldsToViewMethodName, nonPublicInstance, new object[] { });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldNotBeNull(),
                () => validations.ShouldBe(7));
        }

        [TestMethod]
        public void RemoveReqdFieldsFromView_WhenCalled_RemovesFieldsFromView()
        {
            // Arrange
            var requiredFields = new List<string>()
            {
                DummyString,
                One.ToString()
            };

            GanttParameters.Add("View", DummyString);

            spFieldCollection.ContainsFieldString = _ => true;
            spWeb.AllowUnsafeUpdatesSetBoolean = input =>
            {
                validations += 1;
            };
            spViewFieldCollection.DeleteString = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(GanttParamtetersFieldName, nonPublicInstance, GanttParameters);
            privateObject.SetFieldOrProperty(RequiredFieldsFieldName, nonPublicInstance, requiredFields);
            privateObject.SetFieldOrProperty(FieldsAddedToViewFieldName, nonPublicInstance, requiredFields);

            // Act
            privateObject.Invoke(RemoveReqdFieldsFromViewMethodName, nonPublicInstance, new object[] { });

            // Assert
            validations.ShouldBe(4);
        }

        [TestMethod]
        public void InitializeColumnDefs_WhenCalled_InitializeColumnDefinitions()
        {
            // Arrange
            const string xmlString = @"<xmlcfg/>";
            const string IndicatorString = "indicator";
            var fieldNames = new List<string>()
            {
                $"1|2",
                DummyString,
                "master_checkbox2"
            };
            var viewFields = new StringCollection()
            {
                DummyString
            };

            spFieldCollection.ContainsFieldString = _ => true;
            spField.DescriptionGet = () => IndicatorString;

            ShimGridData.AllInstances.IsHyperLinkStringInt32 = (_, _1, _2) => true;
            ShimGridData.AllInstances.InitViewFieldNames = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(FieldNamesFieldName, nonPublicInstance, fieldNames);
            privateObject.SetFieldOrProperty(SPViewFieldsFieldName, nonPublicInstance, viewFields);

            // Act
            privateObject.Invoke(InitializeColumnDefsMethodName, nonPublicInstance, new object[] { xmlString });
            var actual = (DataTable)privateObject.GetFieldOrProperty(ColumnDefinitionsFieldName, nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Rows.Count.ShouldBe(3),
                () => actual.Rows[0][DisplayNameColumn].ToString().ShouldBe(fieldNames[0]),
                () => actual.Rows[0][InternalNameColumn].ToString().ShouldBe(DummyString),
                () => actual.Rows[0][IsHyperLinkColumn].ToString().ShouldBe(TrueStringLowerCase),
                () => actual.Rows[0][IsImageColumn].ToString().ShouldBe(TrueStringLowerCase),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void LoadData_WhenCalled_ProcessesNodeData()
        {
            // Arrange
            const string xmlString = @"
                <Rows>
                    <row/>
                    <row/>
                </Rows>";
            var xmlDocument = new XmlDocument();
            var parameters = new object[]
            {
                new DataTable()
            };

            xmlDocument.LoadXml(xmlString);

            ShimGridData.AllInstances.ProcessChildRowsXmlNodeDataTable = (_, _1, _2) =>
            {
                validations += 1;
            };
            ShimGridData.AllInstances.PopulateViewFieldValuesXmlNodeDataRow = (_, _1, _2) =>
            {
                validations += 1;
            };
            ShimGridData.AllInstances.PopulateDefaultFieldValuesXmlNodeDataRowDataTable = (_, _1, _2, _3) =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(XmlDocFieldName, nonPublicInstance, xmlDocument);
            privateObject.SetFieldOrProperty(GlobalIndexFieldName, nonPublicInstance, One);

            // Act
            privateObject.Invoke(LoadDataMethodName, nonPublicInstance, parameters);
            var actual = (DataTable)parameters[0];
            var nodeData = (Hashtable)privateObject.GetFieldOrProperty(NodeDataFieldName, nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Rows.Count.ShouldBe(2),
                () => nodeData.Count.ShouldBe(2),
                () => validations.ShouldBe(6));
        }

        [TestMethod]
        public void PopulateViewFieldValues_WhenCalled_PopulatesViewFieldValues()
        {
            // Arrange
            const string workspaceurlString = "workspaceurl";
            var xmlString = $@"
                <Fields>
                    <cell></cell>
                    <cell>Field1</cell>
                    <cell>Field2</cell>
                    <cell>{workspaceurlString}</cell>
                    <cell>{DummyString}</cell>
                </Fields>";
            var xmlDocument = new XmlDocument();
            var row = default(DataRow);
            var dataTable = new DataTable();
            var fieldNames = new List<string>()
            {
                workspaceurlString,
                One.ToString(),
                Two.ToString(),
                Three.ToString(),
                Four.ToString()
            };

            xmlDocument.LoadXml(xmlString);

            dataTable.Columns.Add(DisplayNameColumn);
            dataTable.Columns.Add(IsImageColumn);
            dataTable.Columns.Add(IsHyperLinkColumn);
            dataTable.Columns.Add(workspaceurlString);
            dataTable.Columns.Add(One.ToString());
            dataTable.Columns.Add(Two.ToString());
            dataTable.Columns.Add(Three.ToString());
            dataTable.Columns.Add(Four.ToString());

            row = dataTable.NewRow();
            row[DisplayNameColumn] = workspaceurlString;
            row[IsImageColumn] = $"not{TrueStringLowerCase}";
            row[IsHyperLinkColumn] = $"not{TrueStringLowerCase}";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row[DisplayNameColumn] = One;
            row[IsImageColumn] = $"not{TrueStringLowerCase}";
            row[IsHyperLinkColumn] = $"not{TrueStringLowerCase}";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row[DisplayNameColumn] = Two;
            row[IsImageColumn] = $"not{TrueStringLowerCase}";
            row[IsHyperLinkColumn] = TrueStringLowerCase;
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row[DisplayNameColumn] = Three;
            row[IsImageColumn] = TrueStringLowerCase;
            row[IsHyperLinkColumn] = $"not{TrueStringLowerCase}";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row[DisplayNameColumn] = Four;
            row[IsImageColumn] = TrueStringLowerCase;
            row[IsHyperLinkColumn] = $"not{TrueStringLowerCase}";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();

            var parameters = new object[]
            {
                xmlDocument.FirstChild,
                row
            };

            privateObject.SetFieldOrProperty(ColumnDefinitionsFieldName, nonPublicInstance, dataTable);
            privateObject.SetFieldOrProperty(FieldNamesFieldName, nonPublicInstance, fieldNames);
            privateObject.SetFieldOrProperty(ImagesFieldName, nonPublicInstance, fieldNames);

            // Act
            privateObject.Invoke(PopulateViewFieldValuesMethodName, nonPublicInstance, parameters);
            var actual = (DataRow)parameters[1];
            var images = (List<string>)privateObject.GetFieldOrProperty(ImagesFieldName, nonPublicInstance);
            var imagesHashTable = (Hashtable)privateObject.GetFieldOrProperty(ImagesHashTableFieldName, nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual[fieldNames[0]].ToString().ShouldBe(string.Empty),
                () => actual[fieldNames[1]].ToString().ShouldBe("Field1"),
                () => actual[fieldNames[2]].ToString().ShouldBe("Field2"),
                () => actual[fieldNames[3]].ToString().ShouldBe("0"),
                () => actual[fieldNames[4]].ToString().ShouldBe("5"),
                () => images.Count.ShouldBe(6),
                () => images[5].ShouldBe(DummyString),
                () => imagesHashTable.Count.ShouldBe(1));
        }

        [TestMethod]
        public void PopulateDefaultFieldValues_WhenCalled_PopulatesDefaultFieldValues()
        {
            // Arrange
            var xmlString = $@"
                <Fields id=""{Five}"">
                    <userdata name=""{One}"">{guid}</userdata>
                    <userdata name=""{Two}"">{Two}</userdata>
                    <userdata name=""{Three}"">{DummyString}</userdata>
                    <userdata name=""{Four}""></userdata>
                </Fields>";
            var xmlDocument = new XmlDocument();
            var row = default(DataRow);
            var dataTable = new DataTable();

            xmlDocument.LoadXml(xmlString);

            dataTable.Columns.Add(DisplayNameColumn);
            dataTable.Columns.Add(ColumnTypeColumn);
            dataTable.Columns.Add(KeyString);
            dataTable.Columns.Add("viewUrl");
            dataTable.Columns.Add("siteUrl");
            dataTable.Columns.Add("rowid");
            dataTable.Columns.Add("ganttStart");
            dataTable.Columns.Add("ganttFinish");
            dataTable.Columns.Add("completeThrough");
            dataTable.Columns.Add(One.ToString());
            dataTable.Columns.Add(Two.ToString());
            dataTable.Columns.Add(Three.ToString());
            dataTable.Columns.Add(Four.ToString());

            row = dataTable.NewRow();
            row[DisplayNameColumn] = One;
            row[ColumnTypeColumn] = "guid";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row[DisplayNameColumn] = Two;
            row[ColumnTypeColumn] = "int";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row[DisplayNameColumn] = Three;
            row[ColumnTypeColumn] = "string";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row[DisplayNameColumn] = Four;
            row[ColumnTypeColumn] = "datetime";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();

            spView.UrlGet = () => SampleUrl;
            spSite.UrlGet = () => SampleUrl;

            ShimGridData.AllInstances.GetGanttStartDateXmlNode = (_, __) =>
            {
                validations += 1;
                return currentDateTime;
            };
            ShimGridData.AllInstances.GetGanttFinishDateXmlNode = (_, __) =>
            {
                validations += 1;
                return currentDateTime;
            };
            ShimGridData.AllInstances.CalcPercentCompleteDataRow = (_, __) =>
            {
                validations += 1;
                return currentDateTime;
            };
            ShimGridData.AllInstances.ApplyGanttStyleDataRowXmlNode = (_, input, _2) =>
            {
                validations += 1;
            };

            var parameters = new object[]
            {
                xmlDocument.FirstChild,
                row,
                default(DataTable)
            };

            privateObject.SetFieldOrProperty(SPViewFieldName, nonPublicInstance, spView.Instance);
            privateObject.SetFieldOrProperty(ColumnDefinitionsFieldName, nonPublicInstance, dataTable);

            // Act
            privateObject.Invoke(PopulateDefaultFieldValuesMethodName, nonPublicInstance, parameters);
            var actual = ((DataRow)parameters[1]);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual[One.ToString()].ToString().ShouldBe($"{guid}"),
                () => actual[Two.ToString()].ToString().ShouldBe($"{Two}"),
                () => actual[Three.ToString()].ToString().ShouldBe(DummyString),
                () => actual["ganttStart"].ToString().ShouldBe($"{currentDateTime}"),
                () => actual["ganttFinish"].ToString().ShouldBe($"{currentDateTime}"),
                () => actual["completeThrough"].ToString().ShouldBe($"{currentDateTime}"),
                () => validations.ShouldBe(7));
        }

        [TestMethod]
        public void CalcPercentComplete_WhenCalled_ReturnsCompleteThruDateTime()
        {
            // Arrange
            var row = default(DataRow);
            var dataTable = new DataTable();

            dataTable.Columns.Add("PctComplete");
            dataTable.Columns.Add(GanttStartFieldPropertyName);
            dataTable.Columns.Add(GanttFinishFieldPropertyName);
            row = dataTable.NewRow();
            row["PctComplete"] = One;
            row[GanttStartFieldPropertyName] = currentDateTime.Date;
            row[GanttFinishFieldPropertyName] = currentDateTime.Date.AddDays(100);

            var parameters = new object[]
            {
                row
            };

            spFieldCollection.GetFieldString = input =>
            {
                spField.TitleGet = () => input;
                return spField;
            };

            privateObject.SetFieldOrProperty("PctComplete", publicInstance, "PctComplete");
            privateObject.SetFieldOrProperty(GanttStartFieldPropertyName, publicInstance, GanttStartFieldPropertyName);
            privateObject.SetFieldOrProperty(GanttFinishFieldPropertyName, publicInstance, GanttFinishFieldPropertyName);

            // Act
            var actual = (DateTime)privateObject.Invoke(CalcPercentCompleteMethodName, nonPublicInstance, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(currentDateTime.Date.AddDays(100)),
                () => ((DataRow)parameters[0])["PctComplete"].ToString().ShouldBe("100"));
        }

        [TestMethod]
        public void GetGanttStartDate_WhenCalled_ReturnsGanttStartDate()
        {
            // Arrange
            var xmlString = $@"
                <Fields>
                    <cell>{DummyString}</cell>
                    <cell>{currentDateTime.Date}</cell>
                    <cell>{One}</cell>
                </Fields>";
            var xmlDocument = new XmlDocument();
            var fieldNames = new List<string>()
            {
                Zero.ToString(),
                DummyString,
                One.ToString(),
            };

            xmlDocument.LoadXml(xmlString);

            privateObject.SetFieldOrProperty(FieldNamesFieldName, nonPublicInstance, fieldNames);

            // Act
            var actual = (DateTime)privateObject.Invoke(
                GetGanttStartDateMethodName,
                nonPublicInstance,
                new object[]
                {
                    xmlDocument.FirstChild
                });

            // Assert
            actual.ShouldBe(currentDateTime.Date);
        }

        [TestMethod]
        public void GetGanttFinishDate_WhenCalled_ReturnsGanttStartDate()
        {
            // Arrange
            var xmlString = $@"
                <Fields>
                    <cell>{DummyString}</cell>
                    <cell>{currentDateTime.Date}</cell>
                    <cell>{One}</cell>
                </Fields>";
            var xmlDocument = new XmlDocument();
            var fieldNames = new List<string>()
            {
                Zero.ToString(),
                DummyString,
                One.ToString(),
            };

            xmlDocument.LoadXml(xmlString);

            privateObject.SetFieldOrProperty(FieldNamesFieldName, nonPublicInstance, fieldNames);

            // Act
            var actual = (DateTime)privateObject.Invoke(
                GetGanttFinishDateMethodName,
                nonPublicInstance,
                new object[]
                {
                    xmlDocument.FirstChild
                });

            // Assert
            actual.ShouldBe(currentDateTime.Date);
        }

        [TestMethod]
        public void ApplyGanttStyle_CaseOne_AppliesGroupHeaderStyle()
        {
            // Arrange
            const string expectedStyle = "groupheader";
            const string expected = "H1";
            const string xmlString = @"
                <Fields style=""font-weight:bold;"">
                    <cell>1</cell>
                </Fields>";
            var xmlDocument = new XmlDocument();
            var row = default(DataRow);
            var dataTable = new DataTable();

            xmlDocument.LoadXml(xmlString);

            dataTable.Columns.Add(IDStringCaps);
            dataTable.Columns.Add(GridSerializer.DefaultGridRowStyleIdColumnName);
            row = dataTable.NewRow();
            row[IDStringCaps] = string.Empty;
            dataTable.Rows.Add(row);

            var parameters = new object[]
            {
                row,
                xmlDocument.FirstChild
            };

            ShimGridData.AllInstances.ApplyGanttStylesDataRowString = (_, _1, input) =>
            {
                if (input.Equals(expectedStyle))
                {
                    validations += 1;
                }
            };

            // Act
            privateObject.Invoke(ApplyGanttStyleMethodName, nonPublicInstance, parameters);
            var actual = (DataRow)parameters[0];

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual[GridSerializer.DefaultGridRowStyleIdColumnName].ShouldBe(expected),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void ApplyGanttStyle_CaseTwo_AppliesCriticalSummaryStyle()
        {
            // Arrange
            const string expectedStyle = "critical summary";
            const string expected = "H1";
            const string xmlString = @"
                <Fields style=""font-weight:bold;"">
                    <cell>yes</cell>
                </Fields>";
            var xmlDocument = new XmlDocument();
            var row = default(DataRow);
            var dataTable = new DataTable();
            var fieldNames = new List<string>()
            {
                "Critical"
            };

            xmlDocument.LoadXml(xmlString);

            dataTable.Columns.Add(IDStringCaps);
            dataTable.Columns.Add(GridSerializer.DefaultGridRowStyleIdColumnName);
            row = dataTable.NewRow();
            row[IDStringCaps] = One;
            dataTable.Rows.Add(row);

            var parameters = new object[]
            {
                row,
                xmlDocument.FirstChild
            };

            ShimGridData.AllInstances.ApplyGanttStylesDataRowString = (_, _1, input) =>
            {
                if (input.Equals(expectedStyle))
                {
                    validations += 1;
                }
            };

            privateObject.SetFieldOrProperty(FieldNamesFieldName, nonPublicInstance, fieldNames);

            // Act
            privateObject.Invoke(ApplyGanttStyleMethodName, nonPublicInstance, parameters);
            var actual = (DataRow)parameters[0];

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual[GridSerializer.DefaultGridRowStyleIdColumnName].ShouldBe(expected),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void ApplyGanttStyle_CaseThree_AppliesSummaryStyle()
        {
            // Arrange
            const string expectedStyle = "summary";
            const string expected = "H1";
            const string xmlString = @"
                <Fields style=""font-weight:bold;"">
                    <cell>no</cell>
                </Fields>";
            var xmlDocument = new XmlDocument();
            var row = default(DataRow);
            var dataTable = new DataTable();
            var fieldNames = new List<string>()
            {
                "Critical"
            };

            xmlDocument.LoadXml(xmlString);

            dataTable.Columns.Add(IDStringCaps);
            dataTable.Columns.Add(GridSerializer.DefaultGridRowStyleIdColumnName);
            row = dataTable.NewRow();
            row[IDStringCaps] = One;
            dataTable.Rows.Add(row);

            var parameters = new object[]
            {
                row,
                xmlDocument.FirstChild
            };

            ShimGridData.AllInstances.ApplyGanttStylesDataRowString = (_, _1, input) =>
            {
                if (input.Equals(expectedStyle))
                {
                    validations += 1;
                }
            };

            privateObject.SetFieldOrProperty(FieldNamesFieldName, nonPublicInstance, fieldNames);

            // Act
            privateObject.Invoke(ApplyGanttStyleMethodName, nonPublicInstance, parameters);
            var actual = (DataRow)parameters[0];

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual[GridSerializer.DefaultGridRowStyleIdColumnName].ShouldBe(expected),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void ApplyGanttStyle_CaseFour_AppliesCriticalStyle()
        {
            // Arrange
            const string expectedStyle = "critical";
            const string xmlString = @"
                <Fields style=""none"">
                    <cell>yes</cell>
                </Fields>";
            var xmlDocument = new XmlDocument();
            var row = default(DataRow);
            var dataTable = new DataTable();
            var fieldNames = new List<string>()
            {
                "Critical"
            };

            xmlDocument.LoadXml(xmlString);

            dataTable.Columns.Add(IDStringCaps);
            dataTable.Columns.Add(GridSerializer.DefaultGridRowStyleIdColumnName);
            row = dataTable.NewRow();
            row[IDStringCaps] = One;
            row[GridSerializer.DefaultGridRowStyleIdColumnName] = DummyString;
            dataTable.Rows.Add(row);

            var parameters = new object[]
            {
                row,
                xmlDocument.FirstChild
            };

            ShimGridData.AllInstances.ApplyGanttStylesDataRowString = (_, _1, input) =>
            {
                if (input.Equals(expectedStyle))
                {
                    validations += 1;
                }
            };

            privateObject.SetFieldOrProperty(FieldNamesFieldName, nonPublicInstance, fieldNames);

            // Act
            privateObject.Invoke(ApplyGanttStyleMethodName, nonPublicInstance, parameters);
            var actual = (DataRow)parameters[0];

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual[GridSerializer.DefaultGridRowStyleIdColumnName].ShouldBe(DummyString),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void ApplyGanttStyle_CaseFive_AppliesStandardStyle()
        {
            // Arrange
            const string expectedStyle = "standard";
            const string xmlString = @"
                <Fields style=""none"">
                    <cell>no</cell>
                </Fields>";
            var xmlDocument = new XmlDocument();
            var row = default(DataRow);
            var dataTable = new DataTable();
            var fieldNames = new List<string>()
            {
                "Critical"
            };

            xmlDocument.LoadXml(xmlString);

            dataTable.Columns.Add(IDStringCaps);
            dataTable.Columns.Add(GridSerializer.DefaultGridRowStyleIdColumnName);
            row = dataTable.NewRow();
            row[IDStringCaps] = One;
            row[GridSerializer.DefaultGridRowStyleIdColumnName] = DummyString;
            dataTable.Rows.Add(row);

            var parameters = new object[]
            {
                row,
                xmlDocument.FirstChild
            };

            ShimGridData.AllInstances.ApplyGanttStylesDataRowString = (_, _1, input) =>
            {
                if (input.Equals(expectedStyle))
                {
                    validations += 1;
                }
            };

            privateObject.SetFieldOrProperty(FieldNamesFieldName, nonPublicInstance, fieldNames);

            // Act
            privateObject.Invoke(ApplyGanttStyleMethodName, nonPublicInstance, parameters);
            var actual = (DataRow)parameters[0];

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual[GridSerializer.DefaultGridRowStyleIdColumnName].ShouldBe(DummyString),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void ApplyGanttStyles_TypeGroupHeader_ReturnsCustomBarStyleArray()
        {
            // Arrange
            const string yesString = "yes";
            const string type = "groupheader";
            var row = default(DataRow);
            var dataTable = new DataTable();
            var expected = new GanttUtilities.CustomBarStyle[]
            {
                0
            };

            dataTable.Columns.Add(DummyString);
            dataTable.Columns.Add(GridSerializer.DefaultGanttBarStyleIdsColumnName);
            row = dataTable.NewRow();
            row[DummyString] = yesString;
            row[GridSerializer.DefaultGanttBarStyleIdsColumnName] = null;
            dataTable.Rows.Add(row);

            var parameters = new object[]
            {
                row,
                type
            };

            spFieldCollection.ContainsFieldString = _ => true;

            privateObject.SetFieldOrProperty("GanttMilestone", publicInstance, DummyString);

            // Act
            privateObject.Invoke(ApplyGanttStylesMethodName, publicInstance, parameters);
            var actual = ((DataRow)parameters[0])[GridSerializer.DefaultGanttBarStyleIdsColumnName];

            // Assert
            actual.ShouldNotBeNull();
        }

        [TestMethod]
        public void ApplyGanttStyles_Typesummary_ReturnsCustomBarStyleArray()
        {
            // Arrange
            const string yesString = "yes";
            const string type = "summary";
            var row = default(DataRow);
            var dataTable = new DataTable();
            var expected = new GanttUtilities.CustomBarStyle[]
            {
                0
            };

            dataTable.Columns.Add(DummyString);
            dataTable.Columns.Add(GridSerializer.DefaultGanttBarStyleIdsColumnName);
            row = dataTable.NewRow();
            row[DummyString] = yesString;
            row[GridSerializer.DefaultGanttBarStyleIdsColumnName] = null;
            dataTable.Rows.Add(row);

            var parameters = new object[]
            {
                row,
                type
            };

            spFieldCollection.ContainsFieldString = _ => true;

            privateObject.SetFieldOrProperty("GanttMilestone", publicInstance, DummyString);

            // Act
            privateObject.Invoke(ApplyGanttStylesMethodName, publicInstance, parameters);
            var actual = ((DataRow)parameters[0])[GridSerializer.DefaultGanttBarStyleIdsColumnName];

            // Assert
            actual.ShouldNotBeNull();
        }

        [TestMethod]
        public void ApplyGanttStyles_TypestandardMilestoneTrue_ReturnsCustomBarStyleArray()
        {
            // Arrange
            const string yesString = "yes";
            const string type = "standard";
            var row = default(DataRow);
            var dataTable = new DataTable();
            var expected = new GanttUtilities.CustomBarStyle[]
            {
                0
            };

            dataTable.Columns.Add(DummyString);
            dataTable.Columns.Add(GridSerializer.DefaultGanttBarStyleIdsColumnName);
            row = dataTable.NewRow();
            row[DummyString] = yesString;
            row[GridSerializer.DefaultGanttBarStyleIdsColumnName] = null;
            dataTable.Rows.Add(row);

            var parameters = new object[]
            {
                row,
                type
            };

            spFieldCollection.ContainsFieldString = _ => true;

            privateObject.SetFieldOrProperty("GanttMilestone", publicInstance, DummyString);

            // Act
            privateObject.Invoke(ApplyGanttStylesMethodName, publicInstance, parameters);
            var actual = ((DataRow)parameters[0])[GridSerializer.DefaultGanttBarStyleIdsColumnName];

            // Assert
            actual.ShouldNotBeNull();
        }

        [TestMethod]
        public void ApplyGanttStyles_TypestandardMilestoneFalse_ReturnsCustomBarStyleArray()
        {
            // Arrange
            const string yesString = "no";
            const string type = "standard";
            var row = default(DataRow);
            var dataTable = new DataTable();
            var expected = new GanttUtilities.CustomBarStyle[]
            {
                0
            };

            dataTable.Columns.Add(DummyString);
            dataTable.Columns.Add(GridSerializer.DefaultGanttBarStyleIdsColumnName);
            row = dataTable.NewRow();
            row[DummyString] = yesString;
            row[GridSerializer.DefaultGanttBarStyleIdsColumnName] = null;
            dataTable.Rows.Add(row);

            var parameters = new object[]
            {
                row,
                type
            };

            spFieldCollection.ContainsFieldString = _ => true;

            privateObject.SetFieldOrProperty("GanttMilestone", publicInstance, DummyString);

            // Act
            privateObject.Invoke(ApplyGanttStylesMethodName, publicInstance, parameters);
            var actual = ((DataRow)parameters[0])[GridSerializer.DefaultGanttBarStyleIdsColumnName];

            // Assert
            actual.ShouldNotBeNull();
        }

        [TestMethod]
        public void ApplyGanttStyles_TypecriticalMilestoneTrue_ReturnsCustomBarStyleArray()
        {
            // Arrange
            const string yesString = "yes";
            const string type = "critical";
            var row = default(DataRow);
            var dataTable = new DataTable();
            var expected = new GanttUtilities.CustomBarStyle[]
            {
                0
            };

            dataTable.Columns.Add(DummyString);
            dataTable.Columns.Add(GridSerializer.DefaultGanttBarStyleIdsColumnName);
            row = dataTable.NewRow();
            row[DummyString] = yesString;
            row[GridSerializer.DefaultGanttBarStyleIdsColumnName] = null;
            dataTable.Rows.Add(row);

            var parameters = new object[]
            {
                row,
                type
            };

            spFieldCollection.ContainsFieldString = _ => true;

            privateObject.SetFieldOrProperty("GanttMilestone", publicInstance, DummyString);

            // Act
            privateObject.Invoke(ApplyGanttStylesMethodName, publicInstance, parameters);
            var actual = ((DataRow)parameters[0])[GridSerializer.DefaultGanttBarStyleIdsColumnName];

            // Assert
            actual.ShouldNotBeNull();
        }

        [TestMethod]
        public void ApplyGanttStyles_TypecriticalMilestoneFalse_ReturnsCustomBarStyleArray()
        {
            // Arrange
            const string yesString = "no";
            const string type = "critical";
            var row = default(DataRow);
            var dataTable = new DataTable();
            var expected = new GanttUtilities.CustomBarStyle[]
            {
                0
            };

            dataTable.Columns.Add(DummyString);
            dataTable.Columns.Add(GridSerializer.DefaultGanttBarStyleIdsColumnName);
            row = dataTable.NewRow();
            row[DummyString] = yesString;
            row[GridSerializer.DefaultGanttBarStyleIdsColumnName] = null;
            dataTable.Rows.Add(row);

            var parameters = new object[]
            {
                row,
                type
            };

            spFieldCollection.ContainsFieldString = _ => true;

            privateObject.SetFieldOrProperty("GanttMilestone", publicInstance, DummyString);

            // Act
            privateObject.Invoke(ApplyGanttStylesMethodName, publicInstance, parameters);
            var actual = ((DataRow)parameters[0])[GridSerializer.DefaultGanttBarStyleIdsColumnName];

            // Assert
            actual.ShouldNotBeNull();
        }

        [TestMethod]
        public void ApplyGanttStyles_Typecriticalsummary_ReturnsCustomBarStyleArray()
        {
            // Arrange
            const string yesString = "yes";
            const string type = "critical summary";
            var row = default(DataRow);
            var dataTable = new DataTable();
            var expected = new GanttUtilities.CustomBarStyle[]
            {
                0
            };

            dataTable.Columns.Add(DummyString);
            dataTable.Columns.Add(GridSerializer.DefaultGanttBarStyleIdsColumnName);
            row = dataTable.NewRow();
            row[DummyString] = yesString;
            row[GridSerializer.DefaultGanttBarStyleIdsColumnName] = null;
            dataTable.Rows.Add(row);

            var parameters = new object[]
            {
                row,
                type
            };

            spFieldCollection.ContainsFieldString = _ => true;

            privateObject.SetFieldOrProperty("GanttMilestone", publicInstance, DummyString);

            // Act
            privateObject.Invoke(ApplyGanttStylesMethodName, publicInstance, parameters);
            var actual = ((DataRow)parameters[0])[GridSerializer.DefaultGanttBarStyleIdsColumnName];

            // Assert
            actual.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetNodeByName_WhenCalled_ReturnsMatchingNode()
        {
            // Arrange
            const string name = "NodeName";
            var xmlString = $@"
                <nodes>
                    <node name=""{name}"" {DummyString}=""{DummyString}""/>
                    <node name=""{DummyString}"" {DummyString}=""""/>
                </nodes>";
            var xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(xmlString);

            // Act
            var actual = (XmlNode)privateObject.Invoke(
                GetNodeByNameMethodName,
                nonPublicInstance,
                new object[]
                {
                    name,
                    xmlDocument.FirstChild.ChildNodes
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Attributes["name"].Value.ShouldBe(name),
                () => actual.Attributes[DummyString].Value.ShouldBe(DummyString));
        }
    }
}