using System;
using System.Data;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.WebPageCode
{
    public partial class GetGanttTasksTests
    {
        [TestMethod]
        public void FormatField_User_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.User, TypeText);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodFormatField, new object[] { DummyVal, DummyFieldName, true, false });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DummyVal);
        }

        [TestMethod]
        public void FormatField_UserGroup_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.User, TypeText);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodFormatField, new object[] { DummyVal, DummyFieldName, true, true });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DummyVal);
        }

        [TestMethod]
        public void FormatField_CalculatedText_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Calculated, TypeText);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodFormatField, new object[] { DummyVal, DummyFieldName, true, true });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DummyVal);
        }

        [TestMethod]
        public void FormatField_CalculatedCurrency_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Calculated, TypeCurrency);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodFormatField, new object[] { "1.1", DummyFieldName, true, true });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(1.1.ToString("c"));
        }

        [TestMethod]
        public void FormatField_CalculatedDateTimeMaxValue_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Calculated, TypeDateTime);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodFormatField, new object[] { DateTime.MaxValue.ToString(), DummyFieldName, true, true });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void FormatField_CalculatedDateTime_ReturnsValue()
        {
            // Arrange
            var date = new DateTime(2019, 1, 1);
            PrepareForFormatField(SPFieldType.Calculated, TypeDateTime, FormatDateOnly);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodFormatField, new object[] { date.ToString(), DummyFieldName, true, true });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(date.ToShortDateString());
        }

        [TestMethod]
        public void FormatField_CalculatedNumber_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Calculated, TypeNumber, FormatTwoDecimals);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodFormatField, new object[] { One, DummyFieldName, true, true });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe("1.00");
        }

        [TestMethod]
        public void FormatField_CalculatedNumberPercentage_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Calculated, TypeNumber, FormatTwoDecimalsPercentage);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodFormatField, new object[] { One, DummyFieldName, true, true });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe("100.00%");
        }

        [TestMethod]
        public void FormatField_DateTimeMaxDate_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.DateTime, TypeText);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodFormatField, new object[] { DateTime.MaxValue.ToString(), DummyFieldName, true, true });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void FormatField_DateTime_ReturnsValue()
        {
            // Arrange
            var date = new DateTime(2019, 1, 1);
            PrepareForFormatField(SPFieldType.DateTime, TypeText, FormatDateOnly);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodFormatField, new object[] { date.ToString(), DummyFieldName, true, true });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(date.ToShortDateString());
        }

        [TestMethod]
        public void FormatField_BooleanYes_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Boolean, TypeText);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodFormatField, new object[] { bool.TrueString, DummyFieldName, true, true });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe("Yes");
        }

        [TestMethod]
        public void FormatField_BooleanNo_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Boolean, TypeText);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodFormatField, new object[] { bool.FalseString, DummyFieldName, true, true });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe("No");
        }

        [TestMethod]
        public void FormatField_Url_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.URL, TypeText);
            ShimSPField.AllInstances.GetFieldValueAsHtmlObject = (_, __) => $" href={ExampleUrl}";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodFormatField, new object[] { DummyText, DummyFieldName, true, true });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(ExampleUrl);
        }

        [TestMethod]
        public void FormatField_Lookup_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Lookup, TypeLookupMulti);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodFormatField, new object[] { DummyText, DummyFieldName, true, true });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DummyVal);
        }

        [TestMethod]
        public void FormatField_Invalid_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Invalid, TypeInvalid);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodFormatField, new object[] { One, DummyFieldName, true, true });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DummyVal);
        }

        [TestMethod]
        public void FormatFieldDataRow_Empty_ReturnsEmptyValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.User, TypeText);
            var row = GetFormatFieldDataRow();

            // Act
            var result = _getGanttTasks.formatField(string.Empty, DummyFieldName, row, false);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void FormatFieldDataRow_User_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.User, TypeText);
            var row = GetFormatFieldDataRow();

            // Act
            var result = _getGanttTasks.formatField(DummyVal, DummyFieldName, row, false);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe($"<a href=\"{ExampleUrl}/_layouts/userdisp.aspx?ID=1\">{DummyText}</a>");
        }

        [TestMethod]
        public void FormatFieldDataRow_CalculatedText_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Calculated, TypeText);
            ShimSPField.AllInstances.DescriptionGet = _ => "Indicator";
            var row = GetFormatFieldDataRow();

            // Act
            var result = _getGanttTasks.formatField(DummyVal, DummyFieldName, row, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe($"<img>{DummyVal.ToLower()}</img>");
        }

        [TestMethod]
        public void FormatFieldDataRow_CalculatedCurrency_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Calculated, TypeCurrency);
            var row = GetFormatFieldDataRow();

            // Act
            var result = _getGanttTasks.formatField("1.1", DummyFieldName, row, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(1.1.ToString("c"));
        }

        [TestMethod]
        public void FormatFieldDataRow_CalculatedDateTimeMaxValue_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Calculated, TypeDateTime);
            var row = GetFormatFieldDataRow();

            // Act
            var result = _getGanttTasks.formatField(DateTime.MaxValue.ToString(), DummyFieldName, row, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void FormatFieldDataRow_CalculatedDateTime_ReturnsValue()
        {
            // Arrange
            var date = new DateTime(2019, 1, 1);
            PrepareForFormatField(SPFieldType.Calculated, TypeDateTime, FormatDateOnly);
            var row = GetFormatFieldDataRow();

            // Act
            var result = _getGanttTasks.formatField(date.ToString(), DummyFieldName, row, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(date.ToShortDateString());
        }

        [TestMethod]
        public void FormatFieldDataRow_CalculatedNumber_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Calculated, TypeNumber, FormatTwoDecimals);
            var row = GetFormatFieldDataRow();

            // Act
            var result = _getGanttTasks.formatField(One, DummyFieldName, row, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe("1.00");
        }

        [TestMethod]
        public void FormatFieldDataRow_CalculatedNumberPercentage_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Calculated, TypeNumber, FormatTwoDecimalsPercentage);
            var row = GetFormatFieldDataRow();

            // Act
            var result = _getGanttTasks.formatField(One, DummyFieldName, row, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe("100.00%");
        }

        [TestMethod]
        public void FormatFieldDataRow_CalculatedDefault_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Calculated, TypeDefault);
            var row = GetFormatFieldDataRow();

            // Act
            var result = _getGanttTasks.formatField(One, DummyFieldName, row, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(One);
        }

        [TestMethod]
        public void FormatFieldDataRow_DateTimeMaxDate_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.DateTime, TypeText);
            var row = GetFormatFieldDataRow();

            // Act
            var result = _getGanttTasks.formatField(DateTime.MaxValue.ToString(), DummyFieldName, row, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void FormatFieldDataRow_DateTime_ReturnsValue()
        {
            // Arrange
            var date = new DateTime(2019, 1, 1);
            PrepareForFormatField(SPFieldType.DateTime, TypeText, FormatDateOnly);
            var row = GetFormatFieldDataRow();

            // Act
            var result = _getGanttTasks.formatField(date.ToString(), DummyFieldName, row, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(date.ToShortDateString());
        }

        [TestMethod]
        public void FormatFieldDataRow_Number_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Number, TypeNumber);
            var row = GetFormatFieldDataRow();

            // Act
            var result = _getGanttTasks.formatField(One, DummyFieldName, row, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DummyVal);
        }

        [TestMethod]
        public void FormatFieldDataRow_BooleanYes_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Boolean, TypeText);
            var row = GetFormatFieldDataRow();

            // Act
            var result = _getGanttTasks.formatField(bool.TrueString, DummyFieldName, row, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe("Yes");
        }

        [TestMethod]
        public void FormatFieldDataRow_BooleanNo_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Boolean, TypeText);
            var row = GetFormatFieldDataRow();

            // Act
            var result = _getGanttTasks.formatField(bool.FalseString, DummyFieldName, row, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe("No");
        }

        [TestMethod]
        public void FormatFieldDataRow_UrlImage_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.URL, TypeText);
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPFieldUrl().Instance;
            ShimSPFieldUrl.AllInstances.DisplayFormatGet = _ => SPUrlFieldFormatType.Image;

            ShimSPField.AllInstances.GetFieldValueAsHtmlObject = (_, __) => $"<a href={ExampleUrl}>{DummyText}</a>";
            var row = GetFormatFieldDataRow();

            // Act
            var result = _getGanttTasks.formatField(DummyText, DummyFieldName, row, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe($"<img src={ExampleUrl} alt=\"{DummyText}\">");
        }

        [TestMethod]
        public void FormatFieldDataRow_UrlHyperlink_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.URL, TypeText);
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPFieldUrl().Instance;
            ShimSPFieldUrl.AllInstances.DisplayFormatGet = _ => SPUrlFieldFormatType.Hyperlink;

            var fieldValue = $"<a href={ExampleUrl}>{DummyText}</a>";
            ShimSPField.AllInstances.GetFieldValueAsHtmlObject = (_, __) => fieldValue;
            var row = GetFormatFieldDataRow();

            // Act
            var result = _getGanttTasks.formatField(DummyText, DummyFieldName, row, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(fieldValue);
        }

        [TestMethod]
        public void FormatFieldDataRow_Lookup_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Lookup, TypeLookupMulti);
            var row = GetFormatFieldDataRow();

            // Act
            var result = _getGanttTasks.formatField(DummyText, DummyFieldName, row, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DummyVal);
        }

        [TestMethod]
        public void FormatFieldDataRow_MultiChoice_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.MultiChoice, TypeLookupMulti);
            var row = GetFormatFieldDataRow();

            // Act
            var result = _getGanttTasks.formatField($";#{DummyText};#{DummyVal}", DummyFieldName, row, false);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DummyVal);
        }

        [TestMethod]
        public void FormatFieldDataRow_MultiChoiceGroup_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.MultiChoice, TypeLookupMulti);
            var row = GetFormatFieldDataRow();

            // Act
            var result = _getGanttTasks.formatField($";#{DummyText};#{DummyVal}", DummyFieldName, row, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe($"{DummyText}\nDummyV");
        }

        [TestMethod]
        public void FormatFieldDataRow_Computed_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Computed, TypeComputed, $"DisplayNameSrcField='{DummyFieldName}'");
            var row = GetFormatFieldDataRow();

            // Act
            var result = _getGanttTasks.formatField(One, DummyFieldName, row, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(One);
        }

        [TestMethod]
        public void FormatFieldDataRow_TotalRollup_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Invalid, TypeTotalRollup);
            var row = GetFormatFieldDataRow();

            // Act
            var result = _getGanttTasks.formatField("0.123", DummyFieldName, row, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe("0.1");
        }

        [TestMethod]
        public void FormatFieldDataRow_Invalid_ReturnsValue()
        {
            // Arrange
            PrepareForFormatField(SPFieldType.Invalid, TypeInvalid);
            var row = GetFormatFieldDataRow();

            // Act
            var result = _getGanttTasks.formatField(One, DummyFieldName, row, true);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(One);
        }

        private DataRow GetFormatFieldDataRow()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("SiteUrl");
            var row = dataTable.LoadDataRow(new object[] { ExampleUrl }, true);
            return row;
        }

        private void PrepareForFormatField(SPFieldType fieldType, string type, string otherAttributes = "")
        {
            PrepareSpListRelatedShims();
            PrepareSpFieldRelatedShims(DummyFieldName, fieldType);
            PrepareSpWebRelatedShims();

            ShimSPField.AllInstances.TypeAsStringGet = _ => type;
            ShimSPField.AllInstances.SchemaXmlGet = _ => $"<root ResultType='{type}' {otherAttributes}></root>";
            _getGanttTasksPrivate.SetField("list", new ShimSPList().Instance);
        }
    }
}
