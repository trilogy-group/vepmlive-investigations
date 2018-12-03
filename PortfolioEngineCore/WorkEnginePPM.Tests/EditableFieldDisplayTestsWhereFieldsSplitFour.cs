using Microsoft.SharePoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace WorkEnginePPM.Tests
{
    public partial class EditableFieldDisplayTestsWhereFields
    {
        [TestMethod]
        public void WhereField_ConditionIsLessThanDateTimeSame_ReturnsFalse()
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
                    ConditionIsLessThan,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_ConditionIsLessThanDateTimeSmaller_ReturnsTrue()
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
                    ConditionIsLessThan,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_ConditionIsLessThanDateTimeSameFormatShort_ReturnsFalse()
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
                    ConditionIsLessThan,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_ConditionIsLessThanDateTimeSmallerFormatShort_ReturnsTrue()
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
                    ConditionIsLessThan,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_ConditionIsLessThanNumberSame_ReturnsFalse()
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
                    ConditionIsLessThan,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_ConditionIsLessThanNumberSmaller_ReturnsTrue()
        {
            // Arrange
            _conditionField.IdGet = () => ConditionFieldId;
            _conditionField.GetFieldValueAsTextObject = item => BiggerDummyInt.ToString();
            _conditionField.TypeGet = () => SPFieldType.Number;
            _listItem.ItemGetGuid = guid => DummyInt;

            var valueParam = BiggerDummyInt.ToString();

            // Act
            var actualResult = (bool)_privateType.InvokeStatic(
                WhereFieldMethod,
                new object[]
                {
                    _conditionField.Instance,
                    string.Empty,
                    ConditionIsLessThan,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_ConditionIsLessThanCurrencySame_ReturnsFalse()
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
                    ConditionIsLessThan,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_ConditionIsLessThanCurrencySmaller_ReturnsTrue()
        {
            // Arrange
            _conditionField.IdGet = () => ConditionFieldId;
            _conditionField.GetFieldValueAsTextObject = item => BiggerDummyDouble.ToString();
            _conditionField.TypeGet = () => SPFieldType.Currency;
            _listItem.ItemGetGuid = guid => DummyDouble;

            var valueParam = BiggerDummyDouble.ToString();

            // Act
            var actualResult = (bool)_privateType.InvokeStatic(
                WhereFieldMethod,
                new object[]
                {
                    _conditionField.Instance,
                    string.Empty,
                    ConditionIsLessThan,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_ConditionIsLessThanStringSame_ReturnFalse()
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
                    ConditionIsLessThan,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeFalse();
        }
    }
}
