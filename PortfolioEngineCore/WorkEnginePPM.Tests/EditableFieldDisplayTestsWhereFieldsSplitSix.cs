﻿using Microsoft.SharePoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace WorkEnginePPM.Tests
{
    public partial class EditableFieldDisplayTestsWhereFields
    {
        [TestMethod]
        public void WhereField_ConditionIsLessThanOrEqualDateTimeSame_ReturnsTrue()
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
                    ConditionIsLessThanOrEqual,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_ConditionIsLessThanOrEqualDateTimeBigger_ReturnsFalse()
        {
            // Arrange
            _conditionField.IdGet = () => ConditionFieldId;
            _conditionField.GetFieldValueAsTextObject = item => BiggerDummyDateTime.ToString();
            _conditionField.TypeGet = () => SPFieldType.Text;
            _conditionField.SchemaXmlGet = () => FormatDateTime;
            _listItem.ItemGetGuid = guid => BiggerDummyDateTime;

            var valueParam = DummyDateTime.ToString();

            // Act
            var actualResult = (bool)_privateType.InvokeStatic(
                WhereFieldMethod,
                new object[]
                {
                    _conditionField.Instance,
                    string.Empty,
                    ConditionIsLessThanOrEqual,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_ConditionIsLessThanOrEqualDateTimeSameFormatShort_ReturnsTrue()
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
                    ConditionIsLessThanOrEqual,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_ConditionIsLessThanOrEqualDateTimeBiggerFormatShort_ReturnsFalse()
        {
            // Arrange
            _conditionField.IdGet = () => ConditionFieldId;
            _conditionField.GetFieldValueAsTextObject = item => BiggerDummyDateTime.ToShortDateString();
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
                    ConditionIsLessThanOrEqual,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_ConditionIsLessThanOrEqualNumberSame_ReturnsTrue()
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
                    ConditionIsLessThanOrEqual,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_ConditionIsLessThanOrEqualNumberBigger_ReturnsFalse()
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
                    ConditionIsLessThanOrEqual,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_ConditionIsLessThanOrEqualCurrencySame_ReturnsTrue()
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
                    ConditionIsLessThanOrEqual,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_ConditionIsLessThanOrEqualCurrencyBigger_ReturnsFalse()
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
                    ConditionIsLessThanOrEqual,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_ConditionIsLessThanOrEqualStringSame_ReturnFalse()
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
                    ConditionIsLessThanOrEqual,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeFalse();
        }
    }
}
