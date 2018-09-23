using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Linq.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API.MyWork
{
    using EPMLiveCore.API;
    using EPMLiveCore.API.Fakes;
    using Fakes;

    [TestClass]
    public class UtilsTests
    {
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private const string DummyString = "DummyString";
        private const string GetCleanValueFromFormattedMethodName = "GetCleanValueFromFormatted";
        private const string FormatTypeName = "Format";
        private const string TypeName = "Type";
        private IDisposable shimContext;
        private PrivateType privateType;

        [TestInitialize]
        public void Initialize()
        {
            shimContext = ShimsContext.Create();
            SetupShims();
            privateType = new PrivateType(typeof(Utils));
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.AllInstances.UrlGet = _ => "DummyUrl";
            ShimSPSite.ConstructorString = (_, url) => { };
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb();
            ShimCoreFunctions.getLockedWebSPWeb = _ => DummyGuid;
        }

        [TestMethod]
        public void GetCleanValueFromFormatted_WithSpecificContentFloat_ReturnsExpectedValue()
        {
            // Arrange
            const int ExpectedValue = 1;
            var formatValue = $"float;#{ExpectedValue}";

            // Act
            var result = privateType.InvokeStatic(GetCleanValueFromFormattedMethodName, formatValue) as string;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(ExpectedValue.ToString(), result);
        }

        [TestMethod]
        public void GetCleanValueFromFormatted_WithSpecificContent_ReturnsExpectedValue()
        {
            // Arrange
            const int ExpectedValue = 1;
            var formatValue = $"{DummyString}#{ExpectedValue}";

            // Act
            var result = privateType.InvokeStatic(GetCleanValueFromFormattedMethodName, formatValue) as string;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(ExpectedValue.ToString(), result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForReadOnly_FieldTypeInteger_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Int";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Integer
            };

            // Act
            var result = Utils.GetRelatedGridTypeForReadOnly(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForReadOnly_FieldTypeCurrency_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Float";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Currency
            };

            // Act
            var result = Utils.GetRelatedGridTypeForReadOnly(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForReadOnly_FieldTypeDateTime_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Date";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.DateTime
            };

            // Act
            var result = Utils.GetRelatedGridTypeForReadOnly(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForReadOnly_FieldTypeBoolean_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Bool";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Boolean
            };

            // Act
            var result = Utils.GetRelatedGridTypeForReadOnly(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForReadOnly_FieldTypeNote_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Lines";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Note
            };

            // Act
            var result = Utils.GetRelatedGridTypeForReadOnly(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForReadOnly_FieldTypeURL_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Link";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.URL
            };

            // Act
            var result = Utils.GetRelatedGridTypeForReadOnly(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForReadOnly_FieldTypeChoice_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Enum";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Choice
            };

            // Act
            var result = Utils.GetRelatedGridTypeForReadOnly(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForReadOnly_FieldTypeCalculated_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Icon";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Calculated,
                DescriptionGet = () => "Indicator"
            };

            // Act
            var result = Utils.GetRelatedGridTypeForReadOnly(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForReadOnly_FieldTypeInvalid_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Html";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Invalid,
            };

            // Act
            var result = Utils.GetRelatedGridTypeForReadOnly(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForReadOnly_FieldTypeDefaultValue_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Html";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.ModStat,
            };

            // Act
            var result = Utils.GetRelatedGridTypeForReadOnly(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetGridEnum_FieldTypeChoice_ExecutesCorrectly()
        {
            // Arrange
            var site = new ShimSPSite().Instance;
            var field = new ShimSPFieldChoice().Instance;
            ShimSPFieldMultiChoice.AllInstances.ChoicesGet = _ => new StringCollection
            {
                DummyString
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Choice;
            var values = string.Empty;
            var range = 0;
            var keys = string.Empty;

            // Act
            Utils.GetGridEnum(site, field, out values, out range, out keys);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(values));
        }

        [TestMethod]
        public void GetGridEnum_FieldTypeLookup_ExecutesCorrectly()
        {
            // Arrange
            var site = new ShimSPSite().Instance;
            var field = new ShimSPFieldLookup
            {
                AllowMultipleValuesGet = () => true,
                LookupWebIdGet = () => DummyGuid,
                LookupListGet = () => DummyGuid.ToString()
            }.Instance;
            ShimSPFieldMultiChoice.AllInstances.ChoicesGet = _ => new StringCollection
            {
                DummyString
            };
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb();
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = guid => new ShimSPList
                {
                    ItemsGet = () => new ShimSPListItemCollection
                    {
                        GetEnumerator = () => new List<SPListItem>
                        {
                            new ShimSPListItem
                            {
                                ItemGetString = name => DummyString
                            }
                        }.GetEnumerator()
                    }
                }
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Lookup;
            var values = string.Empty;
            var range = 0;
            var keys = string.Empty;

            // Act
            Utils.GetGridEnum(site, field, out values, out range, out keys);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(values));
            Assert.IsFalse(string.IsNullOrWhiteSpace(keys));
        }

        [TestMethod]
        public void GetGridEnum_FieldTypeMultiChoice_ExecutesCorrectly()
        {
            // Arrange
            var site = new ShimSPSite().Instance;
            var field = new ShimSPFieldMultiChoice().Instance;
            ShimSPFieldMultiChoice.AllInstances.ChoicesGet = _ => new StringCollection
            {
                DummyString
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.MultiChoice;
            var values = string.Empty;
            var range = 0;
            var keys = string.Empty;

            // Act
            Utils.GetGridEnum(site, field, out values, out range, out keys);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(values));
            Assert.IsFalse(string.IsNullOrWhiteSpace(keys));
            Assert.AreEqual(1, range);
        }

        [TestMethod]
        public void GetFormat_FieldTypeDateTime_ReturnsExpectedValue()
        {
            // Arrange
            var expectedValue = SPDateTimeFieldFormatType.DateTime.ToString();
            var field = new ShimSPFieldDateTime
            {
                DisplayFormatGet = () => SPDateTimeFieldFormatType.DateTime
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.DateTime;

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void GetFormat_FieldTypeCurrency_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Currency";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Currency
            };

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetFormat_FieldTypeCalculated_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Indicator";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Calculated,
                DescriptionGet = () => ExpectedValue
            };

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetFormat_FieldTypeDefaultValue_ReturnsExpectedValue()
        {
            // Arrange
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Attachments
            };

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsTrue(string.IsNullOrWhiteSpace(result));
        }

        [TestMethod]
        public void GetFormat_FieldTypeNumberAndDisplayFormatAutomatic_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = ",#0.##########";
            var field = new ShimSPFieldNumber
            {
                DisplayFormatGet = () => SPNumberFormatTypes.Automatic,
                ShowAsPercentageGet = () => true
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Contains(ExpectedValue));
        }

        [TestMethod]
        public void GetFormat_FieldTypeNumberAndDisplayFormatNoDecimal_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = ",#0";
            var field = new ShimSPFieldNumber
            {
                DisplayFormatGet = () => SPNumberFormatTypes.NoDecimal,
                ShowAsPercentageGet = () => true
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Contains(ExpectedValue));
        }

        [TestMethod]
        public void GetFormat_FieldTypeNumberAndDisplayFormatOneDecimal_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = ",#0.0";
            var field = new ShimSPFieldNumber
            {
                DisplayFormatGet = () => SPNumberFormatTypes.OneDecimal,
                ShowAsPercentageGet = () => true
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Contains(ExpectedValue));
        }

        [TestMethod]
        public void GetFormat_FieldTypeNumberAndDisplayFormatTwoDecimals_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = ",#0.00";
            var field = new ShimSPFieldNumber
            {
                DisplayFormatGet = () => SPNumberFormatTypes.TwoDecimals,
                ShowAsPercentageGet = () => true
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Contains(ExpectedValue));
        }

        [TestMethod]
        public void GetFormat_FieldTypeNumberAndDisplayFormatThreeDecimals_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = ",#0.000";
            var field = new ShimSPFieldNumber
            {
                DisplayFormatGet = () => SPNumberFormatTypes.ThreeDecimals,
                ShowAsPercentageGet = () => true
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Contains(ExpectedValue));
        }

        [TestMethod]
        public void GetFormat_FieldTypeNumberAndDisplayFormatFourDecimals_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = ",#0.0000";
            var field = new ShimSPFieldNumber
            {
                DisplayFormatGet = () => SPNumberFormatTypes.FourDecimals,
                ShowAsPercentageGet = () => true
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Contains(ExpectedValue));
        }

        [TestMethod]
        public void GetFormat_FieldTypeNumberAndDisplayFormatFiveDecimals_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = ",#0.00000";
            var field = new ShimSPFieldNumber
            {
                DisplayFormatGet = () => SPNumberFormatTypes.FiveDecimals,
                ShowAsPercentageGet = () => true
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Contains(ExpectedValue));
        }

        [TestMethod]
        public void GetFormat_FieldTypeNumberAndDisplayFormatUnknownValue_ReturnsExpectedValue()
        {
            // Arrange
            var field = new ShimSPFieldNumber
            {
                DisplayFormatGet = () => (SPNumberFormatTypes)10,
                ShowAsPercentageGet = () => true
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsTrue(string.IsNullOrEmpty(result));
        }
    }
}
