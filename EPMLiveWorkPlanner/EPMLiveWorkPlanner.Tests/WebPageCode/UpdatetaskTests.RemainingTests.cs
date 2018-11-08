using System;
using System.Collections;
using System.Text;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using EPMLiveWorkPlanner.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWorkPlanner.Tests.WebPageCode
{
    public partial class UpdatetaskTests
    {
        private const int DummyInt = 1;
        private const string GetCellDataMethod = "getCellData";
        private const string ProcessItemMethod = "processItem";
        private const string ViewField = "view";
        private const string UseResourcePoolField = "useResourcePool";
        private const string LstProjectCenterField = "lstProjectCenter";
        private const string SlResourcesField = "slResources";
        private const string HshResourcesField = "hshResources";
        private const string ResWebField = "resWeb";
        private const string OutputField = "output";
        private const string SbUpdatedRowsField = "sbUpdatedRows";
        private const string StartDateField = "StartDate";
        private const string DueDateField = "DueDate";
        private const string ModerationStatusField = "_ModerationStatus";
        private const string ResourceNamesField = "ResourceNames";
        private const string UserField = "UserField";
        private const string UserField2 = "UserField2";
        private const string CurrencyField = "CurrencyField";
        private const string NumberField = "NumberField";
        private const string PercentField = "PercentField";
        private const string CalculatedField = "CalculatedField";
        private const string IndicatorField = "IndicatorField";
        private const string MultiChoiceField = "MultiChoiceField";
        private const string LookupField = "LookupField";
        private const string LookupMultiField = "LookupMulti";
        private const string BooleanTrueField = "BooleanTrue";
        private const string BooleanFalseField = "BooleanFalse";
        private const string TextField = "TextField";
        private const string TitleField = "Title";
        private const string StartField = "Start";
        private const string WBSField = "WBS";
        private const string LinkTitleField = "LinkTitle";
        private const string ReadOnlyField = "ReadOnlyField";
        private const string OutlineNumberField = "OutlineNumber";
        private const string UserMultiField = "UserMulti";

        [TestMethod]
        public void GetCellData_OnValidCall_ConfirmResult()
        {
            // Arrange
            var moderationStatusId = Guid.NewGuid();
            var dateId = Guid.NewGuid();
            var numberId = Guid.NewGuid();
            var booleanTrueId = Guid.NewGuid();
            var booleanFalseId = Guid.NewGuid();
            var slResources = new SortedList();
            slResources.Add(DummyString, DummyString);
            _privateObj.SetField(ViewField, new ShimSPView().Instance);
            _privateObj.SetField(UseResourcePoolField, true);
            _privateObj.SetField(LstProjectCenterField, new ShimSPList().Instance);
            _privateObj.SetField(SlResourcesField, slResources);
            ShimSPView.AllInstances.ViewFieldsGet = _ => new ShimSPViewFieldCollection().Bind(new string[]
            {
                StartDateField,
                DueDateField,
                ModerationStatusField,
                ModerationStatusField,
                ModerationStatusField,
                ResourceNamesField,
                UserField,
                UserField2,
                CurrencyField,
                NumberField,
                PercentField,
                CalculatedField,
                IndicatorField,
                MultiChoiceField,
                LookupField,
                LookupMultiField,
                BooleanTrueField,
                BooleanFalseField,
                TextField,
                TitleField
            });
            ShimSPListItem.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPListItem.AllInstances.WebGet = _ => new ShimSPWeb();
            var count = 0;
            ShimSPListItem.AllInstances.ItemGetGuid = (_, guid) =>
            {
                if (guid == moderationStatusId)
                {
                    count++;
                    switch (count)
                    {
                        case 1:
                        case 2:
                            return "0";
                        case 3:
                        case 4:
                            return "1";
                        default:
                            return "2";
                    }
                }
                if (guid == dateId)
                {
                    return DateTime.MinValue.ToString();
                }
                if (guid == numberId)
                {
                    return DummyInt.ToString();
                }
                if (guid == booleanTrueId)
                {
                    return "True";
                }
                if (guid == booleanFalseId)
                {
                    return "False";
                }
                return DummyString;
            };
            ShimSPWeb.AllInstances.UrlGet = _ => DummyUrl;
            ShimSPList.AllInstances.TitleGet = _ => DummyString;
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, name) => new ShimSPField()
            {
                SchemaXmlGet = () => name == PercentField ? "<xml Percentage=\"TRUE\" />" : "<xml />",
                InternalNameGet = () => name,
                IdGet = () =>
                {
                    if (name == UserField2)
                    {
                        _privateObj.SetField(UseResourcePoolField, false);
                    }
                    switch (name)
                    {
                        case ModerationStatusField:
                            return moderationStatusId;
                        case CurrencyField:
                        case NumberField:
                        case PercentField:
                            return numberId;
                        case StartField:
                            return dateId;
                        case BooleanTrueField:
                            return booleanTrueId;
                        case BooleanFalseField:
                            return booleanFalseId;
                        default:
                            return Guid.NewGuid();
                    }
                },
                TypeAsStringGet = () => name,
                TypeGet = () =>
                {
                    switch (name)
                    {
                        case UserField:
                        case UserField2:
                            return SPFieldType.User;
                        case StartField:
                            return SPFieldType.DateTime;
                        case CurrencyField:
                            return SPFieldType.Currency;
                        case NumberField:
                        case PercentField:
                            return SPFieldType.Number;
                        case CalculatedField:
                        case IndicatorField:
                            return SPFieldType.Calculated;
                        case MultiChoiceField:
                            return SPFieldType.MultiChoice;
                        case LookupField:
                        case LookupMultiField:
                            return SPFieldType.Lookup;
                        case BooleanTrueField:
                        case BooleanFalseField:
                            return SPFieldType.Boolean;
                        default:
                            return SPFieldType.Text;
                    }
                },
                GetFieldValueAsTextObject = __ => DummyString,
                DescriptionGet = () => name == IndicatorField ? "Indicator" : DummyString
            };

            // Act
            var result = (string)_privateObj.Invoke(GetCellDataMethod, new ShimSPListItem().Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContain($"<cell><![CDATA[{DateTime.MinValue.ToShortDateString()}]]></cell>"),
                () => result.ShouldContain($"<cell>Approved</cell>"),
                () => result.ShouldContain($"<cell>Rejected</cell>"),
                () => result.ShouldContain($"<cell>Pending</cell>"),
                () => result.ShouldContain($"<cell><![CDATA[{DummyString};#{DummyString}]]></cell>"),
                () => result.ShouldContain($"<cell><![CDATA[<img src=\"{DummyUrl}/_layouts/images/{DummyString}\">]]></cell>"),
                () => result.ShouldContain($"<cell image=\"blank.gif\">"));
        }

        [TestMethod]
        public void ProcessItem_WhenSummaryTask_ConfirmResult()
        {
            var gridId = "_SummaryTask_";
            var expectedOutput = $"<action type='update' sid='{gridId}' tid='{gridId}'/>";
            ProcessItemTest(gridId, expectedOutput);
        }

        [TestMethod]
        public void ProcessItem_WhenIgnore_ConfirmResult()
        {
            var expectedOutput = $"<action type='delete' sid='{DummyString}'/>";
            ProcessItemTest(DummyString, expectedOutput, true);
        }

        [TestMethod]
        public void ProcessItem_WhenDelete_ConfirmResult()
        {
            var expectedOutput = $"<action type='delete' sid='{DummyString}'/>";
            ProcessItemTest(DummyString, expectedOutput, false, false);
        }

        [TestMethod]
        public void ProcessItem_WhenInserted_ConfirmResult()
        {
            var expectedOutput = $"<action type='insert' sid='{DummyString}' tid='{DummyString}'/>";
            ProcessItemTest(DummyString, expectedOutput, false, true);
        }

        private void ProcessItemTest(string gridId, string expectetOutput, bool ignore = false, bool inserted = true)
        {
            // Arrange
            var itemDeleted = false;
            var itemUpdated = false;
            var hshResources = new Hashtable() { [DummyInt] = DummyString };
            _privateObj.SetField(ViewField, new ShimSPView().Instance);
            _privateObj.SetField(UseResourcePoolField, true);
            _privateObj.SetField(HshResourcesField, hshResources);
            _privateObj.SetField(ResWebField, new ShimSPWeb().Instance);
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest();
            ShimHttpRequest.AllInstances.ItemGetString = (_, item) =>
            {
                if ((item.Contains("_ignore") && ignore) || item.Contains("_SharePointId") ||
                    item.Contains("c9") || item.Contains("c10") || item.Contains("c11"))
                {
                    return "1";
                }
                if (item.Contains("_moved"))
                {
                    return string.Empty;
                }
                if (item.Contains("_!nativeeditor_status"))
                {
                    return inserted ? "inserted" : "deleted";
                }
                if (item.Contains("c5"))
                {
                    return $"{DummyInt};#{DummyString}";
                }
                if (item.Contains("c14") || item.Contains("c15"))
                {
                    return DateTime.MinValue.ToString();
                }
                return item;
            };
            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb();
            ShimSPList.AllInstances.ItemsGet = _ => new ShimSPListItemCollection();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPList.AllInstances.GetItemByIdInt32 = (_, __) => new ShimSPListItem();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.SiteUsersGet = _ => new ShimSPUserCollection();
            ShimSPWeb.AllInstances.AllUsersGet = _ => new ShimSPUserCollection();
            var countUser = 0;
            ShimSPUserCollection.AllInstances.ItemGetString = (_, __) =>
            {
                countUser++;
                return countUser == 1 ? null : new ShimSPUser();
            };
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, __) => new ShimSPUser();
            ShimSPUserCollection.AllInstances.AddStringStringStringString = (_, _1, _2, _3, _4) => new ShimSPUser();
            ShimSPFieldUserValue.ConstructorSPWebInt32String = (_, _1, _2, _3) => { };
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, __) => true;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, name) => new ShimSPField()
            {
                InternalNameGet = () => name,
                ReadOnlyFieldGet = () => name == ReadOnlyField,
                TypeGet = () =>
                {
                    switch (name)
                    {
                        case CalculatedField:
                            return SPFieldType.Calculated;
                        case UserField:
                        case UserMultiField:
                            return SPFieldType.User;
                        case CurrencyField:
                            return SPFieldType.Currency;
                        case NumberField:
                        case PercentField:
                            return SPFieldType.Number;
                        case MultiChoiceField:
                            return SPFieldType.MultiChoice;
                        case LookupField:
                            return SPFieldType.Lookup;
                        case StartDateField:
                        case DueDateField:
                            return SPFieldType.DateTime;
                        default:
                            return SPFieldType.Text;
                    }
                },
                TypeAsStringGet = () => name,
                SchemaXmlGet = () => name == PercentField ? "<xml Percentage=\"TRUE\"/>" : "<xml />"
            };
            ShimSPListItemCollection.AllInstances.DeleteItemByIdInt32 = (_, __) => itemDeleted = true;
            ShimSPListItemCollection.AllInstances.Add = _ => new ShimSPListItem();
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => DummyString;
            ShimSPListItem.AllInstances.ModerationInformationGet = _ => new ShimSPModerationInformation();
            ShimSPListItem.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPListItem.AllInstances.Update = _ => itemUpdated = true;
            ShimSPView.AllInstances.ViewFieldsGet = _ => new ShimSPViewFieldCollection().Bind(new string[] 
            {
                WBSField,
                LinkTitleField,
                ReadOnlyField,
                OutlineNumberField,
                ResourceNamesField,
                CalculatedField,
                UserField,
                UserMultiField,
                CurrencyField,
                NumberField,
                PercentField,
                MultiChoiceField,
                LookupField,
                StartDateField,
                DueDateField,
                TextField
            });
            ShimSPFieldLookupValue.ConstructorString = (_, __) => { };
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => DummyInt;
            Shimupdatetask.AllInstances.getCellDataSPListItem = (_, __) => DummyString;

            // Act
            _privateObj.Invoke(ProcessItemMethod,
                gridId, 
                new ShimSPWeb().Instance, 
                new ShimSPList().Instance, 
                new ShimSPView().Instance);

            // Assert
            var output = (string)_privateObj.GetField(OutputField);
            var sbUpdatedRows = (StringBuilder)_privateObj.GetField(SbUpdatedRowsField);
            this.ShouldSatisfyAllConditions(
                () => output.ShouldBe(expectetOutput),
                () => itemDeleted.ShouldBe(!inserted),
                () => itemUpdated.ShouldBe(gridId == DummyString && !ignore && inserted),
                () => sbUpdatedRows.ToString().Contains($"<row id='{DummyString}'><userdata name='SharePointId'>0</userdata>{DummyString}</row>")
                    .ShouldBe(gridId == DummyString && !ignore && inserted));
        }
    }
}
