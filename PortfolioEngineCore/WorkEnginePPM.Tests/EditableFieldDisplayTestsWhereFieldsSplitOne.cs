using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace WorkEnginePPM.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public partial class EditableFieldDisplayTestsWhereFields
    {
        private IDisposable _shimsObject;
        private PrivateType _privateType;
        private const string WhereFieldMethod = "WhereField";
        private const string DummyGroup = "DummyGroup";
        private const string DummyValue = "DummyValue";
        private const string DummyUser = "DummyUser";
        private const string FormatDateTime = "Format=\"DateTime\"";
        private const string FormatShortDate = "Format=\"ShortDate\"";
        private const string DummyTrue = "True";
        private const string DummyFalse = "False";
        private const string DummyString = "DummyString";
        private const string DummyStringDifferent = "Dummy$tring";
        private const int DummyInt = 999;
        private const int BiggerDummyInt = 1000;
        private const double DummyDouble = 11111.1111;
        private const double BiggerDummyDouble = 22222.2222;

        private const string ConditionContains = "Contains";
        private const string ConditionIsEqualTo = "IsEqualTo";
        private const string ConditionIsNotEqualTo = "IsNotEqualTo";
        private const string ConditionIsGreaterThan = "IsGreaterThan";
        private const string ConditionIsGreaterThanOrEqual = "IsGreaterThanOrEqual";
        private const string ConditionIsLessThan = "IsLessThan";
        private const string ConditionIsLessThanOrEqual = "IsLessThanOrEqual";
        private static readonly Guid ConditionFieldId = Guid.NewGuid();
        private static readonly DateTime DummyDateTime = new DateTime(2018, 1, 1, 0, 0, 0);
        private static readonly DateTime BiggerDummyDateTime = new DateTime(2018, 1, 2, 0, 0, 0);

        private ShimSPField _conditionField;
        private ShimSPListItem _listItem;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsObject = ShimsContext.Create();
            _privateType = new PrivateType(typeof(EditableFieldDisplay));
            SetupShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsObject?.Dispose();
        }

        [TestMethod]
        public void WhereField_ValueMeConditionContainsToSameValue_ReturnsTrue()
        {
            // Arrange
            _conditionField.IdGet = () => ConditionFieldId;
            _conditionField.GetFieldValueAsTextObject = item => DummyUser;
            _listItem.ItemGetGuid = guid => DummyValue;

            var valueParam = "[Me]";

            // Act
            var actualResult = (bool)_privateType.InvokeStatic(
                WhereFieldMethod,
                new object[]
                {
                    _conditionField.Instance,
                    string.Empty,
                    ConditionContains,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_ValueMeConditionContainsDifferentValue_ReturnsFalse()
        {
            // Arrange
            _conditionField.IdGet = () => ConditionFieldId;
            _conditionField.GetFieldValueAsTextObject = item => DummyValue;
            _listItem.ItemGetGuid = guid => DummyValue;

            var valueParam = "[Me]";

            // Act
            var actualResult = (bool)_privateType.InvokeStatic(
                WhereFieldMethod,
                new object[]
                {
                    _conditionField.Instance,
                    string.Empty,
                    ConditionContains,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_ConditionEmpty_ReturnsFalse()
        {
            // Arrange
            _conditionField.IdGet = () => ConditionFieldId;
            _conditionField.GetFieldValueAsTextObject = item => DummyString;
            _listItem.ItemGetGuid = guid => DummyString;

            var valueParam = DummyString;

            // Act
            var actualResult = (bool)_privateType.InvokeStatic(
                WhereFieldMethod,
                new object[]
                {
                    _conditionField.Instance,
                    string.Empty,
                    string.Empty,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_ConditionIsEqualToDateTimeSame_ReturnsTrue()
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
                    ConditionIsEqualTo,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_ConditionIsEqualToDateTimeDifferent_ReturnsFalse()
        {
            // Arrange
            _conditionField.IdGet = () => ConditionFieldId;
            _conditionField.GetFieldValueAsTextObject = item => BiggerDummyDateTime.ToString();
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
                    ConditionIsEqualTo,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_ConditionIsEqualToDateTimeSameFormatShort_ReturnsTrue()
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
                    ConditionIsEqualTo,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_ConditionIsEqualToDateTimeDifferentFormatShort_ReturnsFalse()
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
                    ConditionIsEqualTo,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_ConditionIsEqualToNumberSame_ReturnsTrue()
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
                    ConditionIsEqualTo,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_ConditionIsEqualToNumberDifferent_ReturnsFalse()
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
                    ConditionIsEqualTo,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_ConditionIsEqualToCurrencySame_ReturnsTrue()
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
                    ConditionIsEqualTo,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_ConditionIsEqualToCurrencyDifferent_ReturnsFalse()
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
                    ConditionIsEqualTo,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_ConditionIsEqualToBooleanSame_ReturnsTrue()
        {
            // Arrange
            _conditionField.IdGet = () => ConditionFieldId;
            _conditionField.GetFieldValueAsTextObject = item => DummyTrue;
            _conditionField.TypeGet = () => SPFieldType.Boolean;
            _listItem.ItemGetGuid = guid => true;

            var valueParam = DummyTrue;

            // Act
            var actualResult = (bool)_privateType.InvokeStatic(
                WhereFieldMethod,
                new object[]
                {
                    _conditionField.Instance,
                    string.Empty,
                    ConditionIsEqualTo,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_ConditionIsEqualToBooleanDifferent_ReturnsFalse()
        {
            // Arrange
            _conditionField.IdGet = () => ConditionFieldId;
            _conditionField.GetFieldValueAsTextObject = item => DummyFalse;
            _conditionField.TypeGet = () => SPFieldType.Boolean;
            _listItem.ItemGetGuid = guid => true;

            var valueParam = DummyFalse;

            // Act
            var actualResult = (bool)_privateType.InvokeStatic(
                WhereFieldMethod,
                new object[]
                {
                    _conditionField.Instance,
                    string.Empty,
                    ConditionIsEqualTo,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_ConditionIsEqualToStringSame_ReturnsTrue()
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
                    ConditionIsEqualTo,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_ConditionIsEqualToStringDifferent_ReturnsFalse()
        {
            // Arrange
            _conditionField.IdGet = () => ConditionFieldId;
            _conditionField.GetFieldValueAsTextObject = item => DummyStringDifferent;
            _conditionField.TypeGet = () => SPFieldType.Text;
            _listItem.ItemGetGuid = guid => DummyStringDifferent;

            var valueParam = DummyString;

            // Act
            var actualResult = (bool)_privateType.InvokeStatic(
                WhereFieldMethod,
                new object[]
                {
                    _conditionField.Instance,
                    string.Empty,
                    ConditionIsEqualTo,
                    valueParam,
                    _listItem.Instance
                });

            // Assert
            actualResult.ShouldBeFalse();
        }

        private void SetupShims()
        {
            _conditionField = new ShimSPField();
            _listItem = new ShimSPListItem()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName => new ShimSPField()
                    {
                        TypeGet = () => SPFieldType.Text
                    }
                }
            };

            ShimDateTime.NowGet = () => DummyDateTime;

            const string Group = "group";

            var userGroups = new ShimSPGroupCollection().Instance;
            userGroups.Add(DummyGroup, null, null, Group);

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    CurrentUserGet = () => new ShimSPUser()
                    {
                        GroupsGet = () => userGroups,
                        NameGet = () => DummyUser
                    }
                }
            };

            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPGroup>()
            {
                new ShimSPGroup()
                {
                    NameGet = () => DummyGroup
                }
            }.GetEnumerator();
        }
    }
}