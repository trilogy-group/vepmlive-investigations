using Microsoft.SharePoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace WorkEnginePPM.Tests
{
    public partial class EditableFieldDisplayTestsWhereFields
    {
        [TestMethod]
        public void WhereField_ConditionIsGreaterThanOrEqualDateTimeSame_ReturnsTrue()
        {
            // Arrange
            _conditionField.IdGet = () => ConditionFieldId;
            _conditionField.GetFieldValueAsTextObject = item => DummyDateTime.ToString();
            _conditionField.TypeGet = () => SPFieldType.Text;
            _conditionField.SchemaXmlGet = () => FormatDateTime;
            _listItem.ItemGetGuid = guid => DummyDateTime;

            var valueParam = "[Today]";

            // Act
            var actualResult = (bool)_privateType.InvokeStatic(
                WhereFieldMethod,
                new object[]
                {
                    _conditionField.Instance,
                    string.Empty,
                    ConditionIsGreaterThanOrEqual,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_ConditionIsGreaterThanOrEqualDateTimeSmaller_ReturnsFalse()
        {
            // Arrange
            _conditionField.IdGet = () => ConditionFieldId;
            _conditionField.GetFieldValueAsTextObject = item => DummyDateTime.ToString();
            _conditionField.TypeGet = () => SPFieldType.Text;
            _conditionField.SchemaXmlGet = () => FormatDateTime;
            _listItem.ItemGetGuid = guid => DummyDateTime;

            var valueParam = BiggerDummyDateTime.ToString();

            // Act
            var actualResult = (bool)_privateType.InvokeStatic(
                WhereFieldMethod,
                new object[]
                {
                    _conditionField.Instance,
                    string.Empty,
                    ConditionIsGreaterThanOrEqual,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_ConditionIsGreaterThanOrEqualDateTimeSameFormatShort_ReturnsTrue()
        {
            // Arrange
            _conditionField.IdGet = () => ConditionFieldId;
            _conditionField.GetFieldValueAsTextObject = item => DummyDateTime.ToShortDateString();
            _conditionField.TypeGet = () => SPFieldType.Text;
            _conditionField.SchemaXmlGet = () => FormatShortDate;
            _listItem.ItemGetGuid = guid => DummyDateTime;

            var valueParam = "[Today]";

            // Act
            var actualResult = (bool)_privateType.InvokeStatic(
                WhereFieldMethod,
                new object[]
                {
                    _conditionField.Instance,
                    string.Empty,
                    ConditionIsGreaterThanOrEqual,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_ConditionIsGreaterThanOrEqualDateTimeSmallerFormatShort_ReturnsFalse()
        {
            // Arrange
            _conditionField.IdGet = () => ConditionFieldId;
            _conditionField.GetFieldValueAsTextObject = item => DummyDateTime.ToShortDateString();
            _conditionField.TypeGet = () => SPFieldType.Text;
            _conditionField.SchemaXmlGet = () => FormatShortDate;
            _listItem.ItemGetGuid = guid => DummyDateTime;

            var valueParam = BiggerDummyDateTime.ToShortDateString();

            // Act
            var actualResult = (bool)_privateType.InvokeStatic(
                WhereFieldMethod,
                new object[]
                {
                    _conditionField.Instance,
                    string.Empty,
                    ConditionIsGreaterThanOrEqual,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_ConditionIsGreaterThanOrEqualNumberSame_ReturnsTrue()
        {
            // Arrange
            _conditionField.IdGet = () => ConditionFieldId;
            _conditionField.GetFieldValueAsTextObject = item => DummyInt.ToString();
            _conditionField.TypeGet = () => SPFieldType.Number;
            _listItem.ItemGetGuid = guid => DummyInt;

            var valueParam = DummyInt.ToString();

            // Act
            var actualResult = (bool)_privateType.InvokeStatic(
                WhereFieldMethod,
                new object[]
                {
                    _conditionField.Instance,
                    string.Empty,
                    ConditionIsGreaterThanOrEqual,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_ConditionIsGreaterThanOrEqualNumberDifferent_ReturnsTrue()
        {
            // Arrange
            _conditionField.IdGet = () => ConditionFieldId;
            _conditionField.GetFieldValueAsTextObject = item => DummyInt.ToString();
            _conditionField.TypeGet = () => SPFieldType.Number;
            _listItem.ItemGetGuid = guid => BiggerDummyInt;

            var valueParam = DummyInt.ToString();

            // Act
            var actualResult = (bool)_privateType.InvokeStatic(
                WhereFieldMethod,
                new object[]
                {
                    _conditionField.Instance,
                    string.Empty,
                    ConditionIsGreaterThanOrEqual,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_ConditionIsGreaterThanOrEqualCurrencySame_ReturnsTrue()
        {
            // Arrange
            _conditionField.IdGet = () => ConditionFieldId;
            _conditionField.GetFieldValueAsTextObject = item => DummyDouble.ToString();
            _conditionField.TypeGet = () => SPFieldType.Currency;
            _listItem.ItemGetGuid = guid => DummyDouble;

            var valueParam = DummyDouble.ToString();

            // Act
            var actualResult = (bool)_privateType.InvokeStatic(
                WhereFieldMethod,
                new object[]
                {
                    _conditionField.Instance,
                    string.Empty,
                    ConditionIsGreaterThanOrEqual,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_ConditionIsGreaterThanOrEqualCurrencyDifferent_ReturnsTrue()
        {
            // Arrange
            _conditionField.IdGet = () => ConditionFieldId;
            _conditionField.GetFieldValueAsTextObject = item => DummyDouble.ToString();
            _conditionField.TypeGet = () => SPFieldType.Currency;
            _listItem.ItemGetGuid = guid => BiggerDummyDouble;

            var valueParam = DummyDouble.ToString();

            // Act
            var actualResult = (bool)_privateType.InvokeStatic(
                WhereFieldMethod,
                new object[]
                {
                    _conditionField.Instance,
                    string.Empty,
                    ConditionIsGreaterThanOrEqual,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_ConditionIsGreaterThanOrEqualStringSame_ReturnFalse()
        {
            // Arrange
            _conditionField.IdGet = () => ConditionFieldId;
            _conditionField.GetFieldValueAsTextObject = item => DummyString;
            _conditionField.TypeGet = () => SPFieldType.Text;
            _listItem.ItemGetGuid = guid => DummyString;

            var valueParam = DummyString;

            // Act
            var actualResult = (bool)_privateType.InvokeStatic(
                WhereFieldMethod,
                new object[]
                {
                    _conditionField.Instance,
                    string.Empty,
                    ConditionIsGreaterThanOrEqual,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeFalse();
        }
    }
}
