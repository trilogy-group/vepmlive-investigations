using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using EPMLiveWorkPlanner.Fakes;
using System.Data.Fakes;
using System.Collections;

namespace EPMLiveWorkPlanner.Tests.WebPageCode
{
    [TestClass, ExcludeFromCodeCoverage]
    public class TaskCenterCalculateTests
    {
        private IDisposable _shimObject;
        private TaskCenterCalculate _testObject;
        private PrivateObject _privateObject;
        private bool _systemUpdated;

        private readonly DateTime DummyDate = new DateTime(2018, 10, 1);
        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string StartDateField = "StartDate";
        private const string DueDateField = "DueDate";
        private const string PredecessorsField = "Predecessors";
        private const string TaskIDField = "TaskID";
        private const string PredCalcDoneField = "PredCalcDone";
        private const string DurationField = "Duration";
        private const string SetStartDateForLinkMethod = "setStartDateForLink";
        private const string TaskChangedField = "TaskChanged";
        private const string IDField = "ID";
        private const string ActualDurationField = "ActualDuration";
        private const string ActualFinishField = "ActualFinish";
        private const string WBSField = "WBS";
        private const string PercentCompleteField = "PercentComplete";
        private const string CalcDurationsMethod = "calcDurations";
        private const string GetFinishMethod = "getFinish";
        private const string NonWorkMethod = "nonWork";
        private const string CalcItemMethod = "calcItem";
        private const string NumberField = "NumberField";
        private const string ArrFields = "arrFields";
        private const string ListField = "list";
        private const string CalcChildrenMethod = "calcChildren";

        [TestInitialize]
        public void TestInitialize()
        {
            _systemUpdated = false;
            _shimObject = ShimsContext.Create();
            _testObject = new TaskCenterCalculate();
            _privateObject = new PrivateObject(_testObject);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }

        [TestMethod]
        public void SetBaseline_OnValidCall_ConfirmResult()
        {
            // Arrange
            var fieldAdded = false;
            var fieldUpdated = false;
            var listUpdated = false;
            var listItemUpdated = false;
            var systemUpdated = false;
            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection().Bind(new SPField[]
            {
                new ShimSPField()
                {
                    InternalNameGet = () => StartDateField
                },
                new ShimSPField()
                {
                    InternalNameGet = () => DueDateField
                }
            });
            ShimSPList.AllInstances.Update = _ => listUpdated = true;
            ShimSPList.AllInstances.GetItemByIdInt32 = (_, __) => new ShimSPListItem();
            ShimSPList.AllInstances.GetItemsSPQuery = (_, __) => new ShimSPListItemCollection().Bind(new SPListItem[]
            {
                new ShimSPListItem()
            });
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => DummyString;
            ShimSPListItem.AllInstances.ModerationInformationGet = _ => new ShimSPModerationInformation();
            ShimSPListItem.AllInstances.Update = _ => listItemUpdated = true;
            ShimSPListItem.AllInstances.SystemUpdateBoolean = (_, __) => systemUpdated = true;
            ShimSPListItem.AllInstances.ParentListGet = _ => new ShimSPList();
            var count = 0;
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, __) =>
            {
                count++;
                return count > 1;
            };
            ShimSPFieldCollection.AllInstances.AddStringSPFieldTypeBoolean = (_, _1, _2, _3) =>
            {
                fieldAdded = true;
                return DummyString;
            };
            ShimSPFieldCollection.AllInstances.ItemGetString = (_, __) => new ShimSPField();
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField();
            ShimSPField.AllInstances.Update = _ => fieldUpdated = true;
            ShimSPQuery.Constructor = _ => { };

            // Act
            _testObject.setBaseline(new ShimSPList(), DummyInt.ToString(), new ShimSPList());

            // Assert
            this.ShouldSatisfyAllConditions(
                () => fieldAdded.ShouldBeTrue(),
                () => fieldUpdated.ShouldBeTrue(),
                () => listUpdated.ShouldBeTrue(),
                () => listItemUpdated.ShouldBeTrue(),
                () => systemUpdated.ShouldBeTrue());
        }

        [TestMethod]
        public void SetStartDateForLink_OnValidCall_ConfirmResult()
        {
            // Arrange
            const string TaskID1Value = "TaskID1";
            const string TaskID2Value = "TaskID2";
            const string NValue = "N";
            const string YValue = "Y";
            var dataTable = CreateDataTable();
            var dataRow1 = dataTable.NewRow();
            dataRow1[PredecessorsField] = TaskID2Value;
            dataRow1[TaskIDField] = TaskID1Value;
            dataRow1[PredCalcDoneField] = NValue;
            dataRow1[DueDateField] = DummyDate;
            dataRow1[DurationField] = "0";
            var dataRow2 = dataTable.NewRow();
            dataRow2[PredecessorsField] = TaskID1Value;
            dataRow2[TaskIDField] = TaskID2Value;
            dataRow2[PredCalcDoneField] = YValue;
            dataRow2[DueDateField] = DummyDate;
            dataRow2[DurationField] = "0";
            dataTable.Rows.Add(dataRow1);
            dataTable.Rows.Add(dataRow2);
            ShimTaskCenterCalculate.AllInstances.getFinishStringString = (_, _1, _2) => DummyDate;

            // Act
            var result = (DataTable)_privateObject.Invoke(SetStartDateForLinkMethod, dataRow2);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Rows[0][DueDateField].ShouldBe(DummyDate),
                () => result.Rows[0][StartDateField].ShouldBe(DummyDate.AddDays(7).ToString()),
                () => result.Rows[0][TaskChangedField].ShouldBe(YValue),
                () => result.Rows[1][DueDateField].ShouldBe(DummyDate),
                () => result.Rows[1][StartDateField].ShouldBe(DummyDate.AddDays(8).ToString()),
                () => result.Rows[1][TaskChangedField].ShouldBe(YValue));
        }

        private static DataTable CreateDataTable()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(IDField);
            dataTable.Columns.Add(PredCalcDoneField);
            dataTable.Columns.Add(PredecessorsField);
            dataTable.Columns.Add(TaskIDField);
            dataTable.Columns.Add(StartDateField);
            dataTable.Columns.Add(TaskChangedField);
            dataTable.Columns.Add(DurationField);
            dataTable.Columns.Add(DueDateField, typeof(DateTime));
            dataTable.Columns.Add(ActualDurationField);
            dataTable.Columns.Add(ActualFinishField);
            dataTable.Columns.Add(WBSField);
            dataTable.Columns.Add(PercentCompleteField);
            dataTable.Columns.Add(DummyString);
            return dataTable;
        }

        [TestMethod]
        public void CalcDurations_OnValidCall_ConfirmResult()
        {
            // Arrange
            var dataTable = CreateDataTable();
            var dataRow = dataTable.NewRow();
            dataTable.Rows.Add(dataRow);
            ShimSPListItem.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPListItem.AllInstances.ItemGetGuid = (_, __) => DummyDate.ToString();
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, __) => true;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField();
            ShimSPField.AllInstances.IdGet = _ => Guid.NewGuid();

            // Act
            var result = _privateObject.Invoke(CalcDurationsMethod, new ShimSPListItem().Instance, dataRow);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull());
        }

        [TestMethod]
        public void GetFinish_WhenDurationIsZero_ConfirmResult()
        {
            // Arrange, Act
            var result = _privateObject.Invoke(GetFinishMethod, DummyDate.ToString(), "0");

            // Assert
            result.ShouldBe(DummyDate);
        }

        [TestMethod]
        public void GetFinish_WhenDurationIsNotZero_ConfirmResult()
        {
            // Arrange
            _privateObject.SetField(NonWorkMethod, DummyInt);

            // Act
            var result = _privateObject.Invoke(GetFinishMethod, DummyDate.ToString(), "10");

            // Assert
            var expectedResult = new DateTime(2018, 10, 18, 0, 0, 0);
            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public void CalcItem_WhenListItemIsEmpty_ConfirmResult()
        {
            // Arrange
            DataTable dataTable;
            DataRow dataRow;
            SetupForCalcItemMethod(false, out dataTable, out dataRow);

            // Act
            var result = _privateObject.Invoke(CalcItemMethod, new ShimSPListItem().Instance, dataRow);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBeSameAs(dataTable),
                () => _systemUpdated.ShouldBeTrue());
        }

        [TestMethod]
        public void CalcItem_WhenListItemIsNotEmpty_ConfirmResult()
        {
            // Arrange
            DataTable dataTable;
            DataRow dataRow;
            SetupForCalcItemMethod(true, out dataTable, out dataRow);

            // Act
            var result = _privateObject.Invoke(CalcItemMethod, new ShimSPListItem().Instance, dataRow);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBeSameAs(dataTable),
                () => _systemUpdated.ShouldBeTrue());
        }

        private void SetupForCalcItemMethod(bool listItemHasValue, out DataTable dataTable, out DataRow dataRow)
        {
            dataTable = CreateDataTable();
            dataRow = dataTable.NewRow();
            dataTable.Rows.Add(dataRow);
            ShimSPListItem.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPListItem.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPListItem.AllInstances.ItemGetString = (_, itemName) =>
            {
                if (!listItemHasValue)
                {
                    return string.Empty;
                }
                if (itemName == DueDateField)
                {
                    return DummyDate;
                }
                return DummyString;
            };
            ShimSPListItem.AllInstances.SystemUpdate = _ => _systemUpdated = true;
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, __) => true;
            ShimTaskCenterCalculate.AllInstances.getDurationStringString = (_, _1, _2) => DummyInt.ToString();
            ShimTaskCenterCalculate.AllInstances.getFinishStringString = (_, _1, _2) => DummyDate;
        }

        [TestMethod]
        public void Calculate_OnValidCall_ConfirmResult()
        {
            // Arrange
            var dataTable = CreateDataTable();
            var dataRow = dataTable.NewRow();
            dataRow[IDField] = Guid.NewGuid().ToString();
            dataTable.Rows.Add(dataRow);
            var addedRows = 0;
            var fields = "DueDate\nStartDate\nWBS\nPercentComplete|NumberField";
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = _ => { };
            ShimSPList.AllInstances.GetItemByIdInt32 = (_, __) => new ShimSPListItem();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPList.AllInstances.GetItemsSPQuery = (_, __) => new ShimSPListItemCollection().Bind(new SPListItem[]
            {
                new ShimSPListItem()
            });
            ShimSPList.AllInstances.GetItemByUniqueIdGuid = (_, __) => new ShimSPListItem();
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => DummyString;
            ShimSPListItem.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPListItem.AllInstances.SystemUpdate = _ => _systemUpdated = true;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, fieldName) => new ShimSPField
            {
                TypeGet = () =>
                {
                    switch (fieldName)
                    {
                        case DueDateField:
                        case StartDateField:
                            return SPFieldType.DateTime;
                        case PercentCompleteField:
                        case NumberField:
                            return SPFieldType.Number;
                        default:
                            return SPFieldType.Text;
                    }
                }
            };
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, __) => true;
            ShimSPQuery.Constructor = _ => { };
            ShimDataRowCollection.AllInstances.AddObjectArray = (_, __) =>
            {
                addedRows++;
                return null;
            };
            ShimDataTable.AllInstances.SelectString = (_, __) => new DataRow[] { dataRow };

            // Act
            _testObject.Calculate(new ShimSPList(), DummyInt.ToString(), new ShimSPList(), fields);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => addedRows.ShouldBe(2),
                () => _systemUpdated.ShouldBeTrue());
        }

        [TestMethod]
        public void CalcChildren_OnValidCall_ConfirmResult()
        {
            // Arrange
            var dataTable = CreateDataTable();
            var dataRow = dataTable.NewRow();
            dataRow[DummyString] = DummyInt;
            dataRow[PercentCompleteField] = DummyInt;
            dataRow[StartDateField] = DummyDate.ToString();
            dataTable.Rows.Add(dataRow);
            var arrayFields = new ArrayList
            {
                $"{PercentCompleteField}|{DummyString}",
                $"{DummyString}|Min",
                $"{DummyString}|Min",
                $"{DummyString}|Max",
                $"{DummyString}|Sum",
                $"{DummyString}|Avg",
                $"{StartDateField}|Min",
                $"{StartDateField}|Min",
                $"{StartDateField}|Max",
                DueDateField
            };
            _privateObject.SetField(ArrFields, arrayFields);
            _privateObject.SetField(ListField, new ShimSPList().Instance);
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, name) => new ShimSPField
            {
                TypeGet = () =>
                {
                    switch (name)
                    {
                        case StartDateField:
                            return SPFieldType.DateTime;
                        case DummyString:
                            return SPFieldType.Number;
                        default:
                            return SPFieldType.Text;
                    }
                }
            };
            ShimSPListItem.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPList.AllInstances.TitleGet = _ => DummyString;

            // Act
            var result = _privateObject.Invoke(CalcChildrenMethod, 
                new DataRow[] { dataRow },
                new ShimSPListItem().Instance,
                dataRow,
                new ShimSPList().Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeSameAs(dataTable));
        }
    }
}
