using System;
using System.Collections;
using System.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests
{
    public partial class GetGridItemsTests
    {
        private const string FieldDue = "Due";
        private const string FieldDaysOverdue = "DaysOverdue";
        private const string FieldScheduleStatus = "ScheduleStatus";
        private const string MethodSetAggVal = "setAggVal";

        [TestMethod]
        public void GetField_Text_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.Text);

            // Act
            var result = _testObj.getField(new ShimSPListItem(), DummyFieldName, false);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DummyVal);
        }

        [TestMethod]
        public void GetField_DateTimeToday_ReturnsTodayValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.DateTime);
            ShimDateTime.NowGet = () => new DateTime(2019, 1, 1);
            ShimSPField.AllInstances.GetFieldValueString = (_, __) => "[today]";

            // Act
            var result = _testObj.getField(new ShimSPListItem(), DummyFieldName, false);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DateTime.Now.ToShortDateString());
        }

        [TestMethod]
        public void GetField_DateTime_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.DateTime);
            var date = new DateTime(2018, 10, 10);
            ShimSPField.AllInstances.GetFieldValueString = (_, __) => date.ToString();
            ShimSPUtility.CreateDateTimeFromISO8601DateTimeStringString = dateStr => DateTime.Parse(dateStr);

            // Act
            var result = _testObj.getField(new ShimSPListItem(), DummyFieldName, false);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(date.ToShortDateString());
        }

        [TestMethod]
        public void GetField_SiteUrl_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.URL, 1);

            // Act
            var result = _testObj.getField(new ShimSPListItem(), "Site", false);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe($"<a href=\"{ExampleUrl}\">1</a>");
        }

        [TestMethod]
        public void GetField_Site_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.Text, 1);

            // Act
            var result = _testObj.getField(new ShimSPListItem(), "Site", false);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe("1");
        }

        [TestMethod]
        public void GetField_ListUrl_ReturnsValue()
        {
            // Arrange
            const string ListUrl = "www.foo.com";
            PrepareForGetField(SPFieldType.URL, 1);
            ShimSPList.AllInstances.DefaultViewUrlGet = _ => ListUrl;

            // Act
            var result = _testObj.getField(new ShimSPListItem(), "List", false);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe($"<a href=\"{ListUrl}\">{DummyVal}</a>");
        }

        [TestMethod]
        public void GetField_List_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.Text, 1);

            // Act
            var result = _testObj.getField(new ShimSPListItem(), "List", false);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DummyVal);
        }

        [TestMethod]
        public void GetField_Due_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.Text, 1);
            ShimCoreFunctions.GetDueFieldSPListItem = _ => FieldDue;

            // Act
            var result = _testObj.getField(new ShimSPListItem(), FieldDue, false);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(FieldDue);
        }

        [TestMethod]
        public void GetField_DaysOverdue_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.Text, 1);
            ShimCoreFunctions.GetDaysOverdueFieldSPListItem = _ => FieldDaysOverdue;

            // Act
            var result = _testObj.getField(new ShimSPListItem(), FieldDaysOverdue, false);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(FieldDaysOverdue);
        }

        [TestMethod]
        public void GetField_ScheduleStatus_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.Text, 1);
            ShimCoreFunctions.GetScheduleStatusFieldSPListItem = _ => FieldScheduleStatus;

            // Act
            var result = _testObj.getField(new ShimSPListItem(), FieldScheduleStatus, false);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(FieldScheduleStatus);
        }

        [TestMethod]
        public void GetField_TitleDateTime_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.DateTime, 1);
            var date = new DateTime(2019, 1, 1);
            ShimSPListItem.AllInstances.ItemGetGuid = (_, __) => date;

            // Act
            var result = _testObj.getField(new ShimSPListItem(), FieldTitle, false);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(date.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        [TestMethod]
        public void GetField_TitleUserGroup_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.User, 1);

            // Act
            var result = _testObj.getField(new ShimSPListItem(), FieldTitle, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DummyVal);
        }

        [TestMethod]
        public void GetField_TitleUserNotGroup_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.User, 1);

            // Act
            var result = _testObj.getField(new ShimSPListItem(), FieldTitle, false);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DummyVal);
        }

        [TestMethod]
        public void GetField_TitleLookup_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.Lookup, 1);

            // Act
            var result = _testObj.getField(new ShimSPListItem(), FieldTitle, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DummyVal);
        }

        [TestMethod]
        public void GetField_TitleLookupNotInEditMode_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.Lookup, 1);
            _privateObj.SetField(FieldInEditMode, false);

            // Act
            var result = _testObj.getField(new ShimSPListItem(), FieldTitle, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DummyVal);
        }

        [TestMethod]
        public void GetField_TitleLookupMultiNotInEditMode_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.Lookup, 1);
            _privateObj.SetField(FieldInEditMode, false);
            ShimSPField.AllInstances.TypeAsStringGet = _ => "LookupMulti";

            // Act
            var result = _testObj.getField(new ShimSPListItem(), FieldTitle, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DummyVal);
        }

        [TestMethod]
        public void GetField_TitleCalculated_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.Calculated, 1);
            _privateObj.SetField(FieldInEditMode, false);
            ShimSPListItem.AllInstances.ItemGetGuid = (_, __) => "Item1;#Item2";

            // Act
            var result = _testObj.getField(new ShimSPListItem(), FieldTitle, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe("Item2");
        }

        [TestMethod]
        public void GetField_TitleCurrency_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.Currency, 1);
            _privateObj.SetField(FieldInEditMode, false);
            ShimSPListItem.AllInstances.ItemGetGuid = (_, __) => "0.1";

            // Act
            var result = _testObj.getField(new ShimSPListItem(), FieldTitle, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe("0.1");
        }

        [TestMethod]
        public void GetField_TitleFilteredLookup_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.Invalid, 1);
            _privateObj.SetField(FieldInEditMode, false);
            ShimSPField.AllInstances.TypeAsStringGet = _ => "FilteredLookup";
            ShimSPListItem.AllInstances.ItemGetGuid = (_, __) => "Item1,Item2";

            // Act
            var result = _testObj.getField(new ShimSPListItem(), FieldTitle, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe("Item1\nItem2");
        }

        [TestMethod]
        public void FormatField_CalculatedText_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Calculated, "Text");

            // Act
            var result = _testObj.formatField(DummyVal, DummyFieldName, true, true, new ShimSPListItem());

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DummyVal);
        }

        [TestMethod]
        public void FormatField_CalculatedCurrency_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Calculated, "Currency");

            // Act
            var result = _testObj.formatField("1.1", DummyFieldName, true, true, new ShimSPListItem());

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(1.1.ToString("c"));
        }

        [TestMethod]
        public void FormatField_CalculatedDateTimeMaxValue_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Calculated, "DateTime");

            // Act
            var result = _testObj.formatField(DateTime.MaxValue.ToString(), DummyFieldName, true, true, new ShimSPListItem());

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeEmpty();
        }

        [TestMethod]
        public void FormatField_CalculatedDateTime_ReturnsValue()
        {
            // Arrange
            var date = new DateTime(2019, 1, 1);
            PrepareForFormatField(SPFieldType.Calculated, "DateTime", "Format='DateOnly'");

            // Act
            var result = _testObj.formatField(date.ToString(), DummyFieldName, true, true, new ShimSPListItem());

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(date.ToShortDateString());
        }

        [TestMethod]
        public void FormatField_CalculatedNumber_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Calculated, "Number", "Decimals=\"2\"");

            // Act
            var result = _testObj.formatField("1", DummyFieldName, true, true, new ShimSPListItem());

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe("1.00");
        }

        [TestMethod]
        public void FormatField_CalculatedNumberPercentage_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Calculated, "Number", "Decimals=\"2\" Percentage=\"TRUE\"");

            // Act
            var result = _testObj.formatField("1", DummyFieldName, true, true, new ShimSPListItem());

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe("100.00%");
        }

        [TestMethod]
        public void FormatField_InvalidTotalRollup_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Invalid, "TotalRollup");

            // Act
            var result = _testObj.formatField("1", DummyFieldName, true, true, new ShimSPListItem());

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DummyVal);
        }

        [TestMethod]
        public void FormatField_InvalidFilteredLookup_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Invalid, "FilteredLookup");

            // Act
            var result = _testObj.formatField("1", DummyFieldName, true, true, new ShimSPListItem());

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DummyVal);
        }

        [TestMethod]
        public void FormatField_InvalidFilteredLookupNotGroup_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Invalid, "FilteredLookup");

            // Act
            var result = _testObj.formatField("1", DummyFieldName, true, false, new ShimSPListItem());

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe("1");
        }

        [TestMethod]
        public void SetAggVal_Count_ReturnsValue()
        {
            // Arrange
            const string key = "COUNT";
            const string currentValue = "1";
            var aggregationVals = PrepareForSetAggVal(key, currentValue);

            // Act
            _privateObj.Invoke(MethodSetAggVal, new object[] { DummyText, DummyFieldName, DummyVal, new ShimSPList().Instance });

            // Assert
            var result = aggregationVals[$"{DummyText}\n{DummyText}"];
            result.ShouldNotBeNull();
            result.ShouldBe(2);
        }

        [TestMethod]
        public void SetAggVal_Average_ReturnsValue()
        {
            // Arrange
            const string key = "AVG";
            const string currentValue = "1";
            var aggregationVals = PrepareForSetAggVal(key, currentValue);

            // Act
            _privateObj.Invoke(MethodSetAggVal, new object[] { DummyText, DummyFieldName, "50%", new ShimSPList().Instance });

            // Assert
            var result = aggregationVals[$"{DummyText}\n{DummyText}"];
            result.ShouldNotBeNull();
            result.ShouldBe("1,50");
        }

        [TestMethod]
        public void SetAggVal_Sum_ReturnsValue()
        {
            // Arrange
            const string key = "SUM";
            const string currentValue = "10";
            var aggregationVals = PrepareForSetAggVal(key, currentValue);

            // Act
            _privateObj.Invoke(MethodSetAggVal, new object[] { DummyText, DummyFieldName, "50%", new ShimSPList().Instance });

            // Assert
            var result = aggregationVals[$"{DummyText}\n{DummyText}"];
            result.ShouldNotBeNull();
            result.ShouldBe("60");
        }

        [TestMethod]
        public void SetAggVal_MinNumber_ReturnsValue()
        {
            // Arrange
            const string key = "MIN";
            const string currentValue = "60";
            var aggregationVals = PrepareForSetAggVal(key, currentValue, SPFieldType.Number);

            // Act
            _privateObj.Invoke(MethodSetAggVal, new object[] { DummyText, DummyFieldName, "50%", new ShimSPList().Instance });

            // Assert
            var result = aggregationVals[$"{DummyText}\n{DummyText}"];
            result.ShouldNotBeNull();
            result.ShouldBe("50");
        }

        [TestMethod]
        public void SetAggVal_MinNumberNoCurrent_ReturnsNewValue()
        {
            // Arrange
            const string key = "MIN";
            var aggregationVals = PrepareForSetAggVal(key, string.Empty, SPFieldType.Number);

            // Act
            _privateObj.Invoke(MethodSetAggVal, new object[] { DummyText, DummyFieldName, "50%", new ShimSPList().Instance });

            // Assert
            var result = aggregationVals[$"{DummyText}\n{DummyText}"];
            result.ShouldNotBeNull();
            result.ShouldBe("50");
        }

        [TestMethod]
        public void SetAggVal_MinDateTime_ReturnsValue()
        {
            // Arrange
            const string key = "MIN";
            var currentValue = new DateTime(2019, 1, 1).ToString();
            var newDate = new DateTime(2018, 1, 1);
            var newValue = newDate.ToString();
            var aggregationVals = PrepareForSetAggVal(key, currentValue, SPFieldType.DateTime);

            // Act
            _privateObj.Invoke(MethodSetAggVal, new object[] { DummyText, DummyFieldName, newValue, new ShimSPList().Instance });

            // Assert
            var result = aggregationVals[$"{DummyText}\n{DummyText}"];
            result.ShouldNotBeNull();
            result.ShouldBe(newDate.ToShortDateString());
        }

        [TestMethod]
        public void SetAggVal_MaxNumber_ReturnsValue()
        {
            // Arrange
            const string key = "MAX";
            const string currentValue = "40";
            var aggregationVals = PrepareForSetAggVal(key, currentValue, SPFieldType.Number);

            // Act
            _privateObj.Invoke(MethodSetAggVal, new object[] { DummyText, DummyFieldName, "50%", new ShimSPList().Instance });

            // Assert
            var result = aggregationVals[$"{DummyText}\n{DummyText}"];
            result.ShouldNotBeNull();
            result.ShouldBe("50");
        }

        [TestMethod]
        public void SetAggVal_MaxNumberNoCurrent_ReturnsNewValue()
        {
            // Arrange
            const string key = "MAX";
            var aggregationVals = PrepareForSetAggVal(key, string.Empty, SPFieldType.Number);

            // Act
            _privateObj.Invoke(MethodSetAggVal, new object[] { DummyText, DummyFieldName, "50%", new ShimSPList().Instance });

            // Assert
            var result = aggregationVals[$"{DummyText}\n{DummyText}"];
            result.ShouldNotBeNull();
            result.ShouldBe("50");
        }

        [TestMethod]
        public void SetAggVal_MaxDateTime_ReturnsValue()
        {
            // Arrange
            const string key = "MAX";
            var currentValue = new DateTime(2018, 1, 1).ToString();
            var newDate = new DateTime(2019, 1, 1);
            var newValue = newDate.ToString();
            var aggregationVals = PrepareForSetAggVal(key, currentValue, SPFieldType.DateTime);

            // Act
            _privateObj.Invoke(MethodSetAggVal, new object[] { DummyText, DummyFieldName, newValue, new ShimSPList().Instance });

            // Assert
            var result = aggregationVals[$"{DummyText}\n{DummyText}"];
            result.ShouldNotBeNull();
            result.ShouldBe(newDate.ToShortDateString());
        }

        private SortedList PrepareForSetAggVal(string key, string fieldValue, SPFieldType fieldType = SPFieldType.Text)
        {
            var aggregationVals = new SortedList();
            aggregationVals.Add(DummyText, key);
            aggregationVals.Add($"{DummyText}\n{DummyText}", fieldValue);
            _privateObj.SetField("arrAggregationVals", aggregationVals);
            _privateObj.SetField("arrAggregationDef", aggregationVals);

            PrepareSpFieldRelatedShims(DummyText, fieldType);
            PrepareSpListRelatedShims();

            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root Format='DateOnly'></root>";

            return aggregationVals;
        }

        private void PrepareForGetField(SPFieldType fieldType, int id = 0)
        {
            PrepareSpListRelatedShims();
            PrepareSpFieldRelatedShims(DummyFieldName, fieldType);
            PrepareSpWebRelatedShims();

            ShimSPListItem.AllInstances.IDGet = _ => id;
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><Default></Default></root>";
            _privateObj.SetField("list", new ShimSPList().Instance);
            _privateObj.SetField(FieldInEditMode, true);
        }

        private void PrepareForFormatField(SPFieldType fieldType, string type, string otherAttributes = "")
        {
            PrepareSpListRelatedShims();
            PrepareSpFieldRelatedShims(DummyFieldName, fieldType);
            PrepareSpWebRelatedShims();

            ShimSPField.AllInstances.TypeAsStringGet = _ => type;
            ShimSPField.AllInstances.SchemaXmlGet = _ => $"<root ResultType='{type}' {otherAttributes}></root>";
            _privateObj.SetField("list", new ShimSPList().Instance);
            _privateObj.SetField(FieldInEditMode, true);
        }
    }
}
