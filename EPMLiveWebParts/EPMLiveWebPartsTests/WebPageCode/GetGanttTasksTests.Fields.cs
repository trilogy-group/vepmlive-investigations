using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic.Fakes;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Xml;
using System.Xml.Fakes;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.Fakes;
using EPMLiveWebParts.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.WebPageCode
{
    public partial class GetGanttTasksTests
    {
        private const string One = "1";
        private const string DummyText = "DummyText";
        private const string DummyVal = "DummyVal";
        private const string DummyFieldName = "DummyFieldName";
        private const string ExampleUrl = "http://www.example.com";
        private const string FormatDateOnly = "Format='DateOnly'";
        private const string FormatTwoDecimals = "Decimals=\"2\"";
        private const string FormatTwoDecimalsPercentage = "Decimals=\"2\" Percentage=\"TRUE\"";
        private const string TypeTextXml = "text/xml";
        private const string TypeText = "Text";
        private const string TypeCurrency = "Currency";
        private const string TypeDateTime = "DateTime";
        private const string TypeNumber = "Number";
        private const string TypeDefault = "Default";
        private const string TypeLookupMulti = "LookupMulti";
        private const string TypeComputed = "Computed";
        private const string TypeTotalRollup = "TotalRollup";
        private const string TypeInvalid = "Invalid";
        private const string MethodFormatField = "formatField";

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

        private void PrepareSpListRelatedShims(string listId = null)
        {
            ShimSPListCollection.AllInstances.ItemGetString = (_, key) =>
            {
                switch (key)
                {
                    case "Project Schedules":
                        return new ShimSPDocumentLibrary().Instance;
                    default:
                        return new ShimSPList();
                }
            };
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, __) => new ShimSPList();
            ShimSPListItem.AllInstances.IDGet = _ => 1;
            ShimSPListItem.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPListItem.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPListItem.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPListItem.AllInstances.ContentTypeGet = _ => new ShimSPContentType { NameGet = () => TypeTextXml };
            ShimSPListItem.AllInstances.XmlGet = _ => "<root ows_FileDirRef='ows_FileDirRef' ows_DocIcon='ows_DocIcon' ows_BaseName='ows_BaseName' ows_ContentTypeId='ows_ContentTypeId' ows_PermMask='ows_PermMask'></root>";
            ShimSPListItem.AllInstances.ItemGetString = (_, key) =>
            {
                switch (key)
                {
                    case "Created":
                        return DateTime.Today.ToString();
                    case "CommentCount":
                        return 2;
                    default:
                        return DummyVal;
                }
            };
            ShimSPListItem.AllInstances.ItemGetGuid = (_, __) => DummyVal;

            var listGuid = listId == null ? Guid.NewGuid() : new Guid(listId);
            ShimSPList.AllInstances.IDGet = _ => listGuid;
            ShimSPList.AllInstances.TitleGet = _ => DummyVal;
            ShimSPList.AllInstances.ImageUrlGet = _ => $"image.png";
            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb();
            ShimSPList.AllInstances.ContentTypesGet = _ => new ShimSPContentTypeCollection();
            ShimSPList.AllInstances.FormsGet = _ => new ShimSPFormCollection();
            ShimSPList.AllInstances.DefaultViewGet = _ => new ShimSPView();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPList.AllInstances.EnableVersioningGet = _ => true;
            ShimSPList.AllInstances.EnableModerationGet = _ => true;
            ShimSPList.AllInstances.ViewsGet = _ => new ShimSPViewCollection { ItemGetGuid = __ => new ShimSPView() };
            ShimSPList.AllInstances.ItemsGet = _ => new ShimSPListItemCollection();
            ShimSPList.AllInstances.RootFolderGet = _ => new ShimSPFolder();
            ShimSPFolder.AllInstances.NameGet = _ => "Project Center";

            ShimSPListItemCollection.AllInstances.Add = _ => new ShimSPListItem();
            var itemCollection = new ShimSPListItemCollection();
            itemCollection.Bind(new List<SPListItem>
            {
                new ShimSPListItem()
            });
            ShimSPList.AllInstances.GetItemsSPQuery = (_, __) => itemCollection.Instance;
            ShimSPList.AllInstances.GetItemsSPView = (_, __) => itemCollection.Instance;
            ShimSPList.AllInstances.GetItemByIdInt32 = (_, __) => new ShimSPListItem();
        }

        private void PrepareSpFieldRelatedShims(string internalname, SPFieldType fieldType)
        {
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField();
            ShimSPFieldCollection.AllInstances.ContainsFieldWithStaticNameString = (_, __) => true;
            ShimSPFieldCollection.AllInstances.ItemGetGuid = (_, __) => new ShimSPField();

            var fieldId = Guid.NewGuid();
            ShimSPField.AllInstances.IdGet = _ => fieldId;
            ShimSPField.AllInstances.InternalNameGet = _ => internalname;
            ShimSPField.AllInstances.TypeAsStringGet = _ => internalname;
            ShimSPField.AllInstances.TypeGet = _ => fieldType;
            ShimSPField.AllInstances.ReadOnlyFieldGet = _ => false;
            ShimSPField.AllInstances.ShowInEditFormGet = _ => true;
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root>1</root>";
            ShimSPField.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPField.AllInstances.TitleGet = _ => DummyText;
            ShimSPField.AllInstances.GetFieldValueString = (_, __) => DummyVal;
            ShimSPField.AllInstances.GetFieldValueAsTextObject = (_, __) => DummyVal;
            ShimSPField.AllInstances.GetFieldValueAsHtmlObject = (_, val) => val as string;
            ShimSPFieldLookupValue.ConstructorString = (_, __) => { };
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => 1;
            ShimSPFieldLookupValue.AllInstances.LookupValueGet = _ => DummyVal;
            ShimSPFieldLookupValueCollection.ConstructorString = (instance, _) =>
            {
                var shimFields = new ShimSPFieldLookupValueCollection(instance);
                var list = new List<SPFieldLookupValue> { new ShimSPFieldLookupValue().Instance };
                shimFields.Bind(list as IList<SPFieldLookupValue>);
                var enumerator = list.GetEnumerator();
                ShimList<SPFieldLookupValue>.AllInstances.GetEnumerator = x => enumerator;
            };
            ShimSPFieldUserValue.ConstructorSPWebString = (a, b, c) => { };
            ShimSPFieldUserValue.AllInstances.LookupValueGet = _ => DummyText;
            ShimSPFieldUserValue.AllInstances.UserGet = _ => new ShimSPUser();
            ShimSPFieldUserValueCollection.ConstructorSPWebString = (instance, _, __) =>
            {
                var shimFields = new ShimSPFieldUserValueCollection(instance);
                var list = new List<SPFieldUserValue> { new ShimSPFieldUserValue().Instance };
                shimFields.Bind(list as IList<SPFieldUserValue>);
                var enumerator = list.GetEnumerator();
                ShimList<SPFieldUserValue>.AllInstances.GetEnumerator = x => enumerator;
            };
        }

        private void PrepareSpWebRelatedShims(string webId = null)
        {
            var webGuid = webId == null ? Guid.NewGuid() : new Guid(webId);
            ShimSPWeb.AllInstances.IDGet = _ => webGuid;
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => ExampleUrl;
            ShimSPWeb.AllInstances.UrlGet = _ => ExampleUrl;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPWeb.AllInstances.LanguageGet = _ => 1;
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPWeb.AllInstances.FoldersGet = _ => new ShimSPFolderCollection();
            ShimSPWeb.AllInstances.TitleGet = _ => One;
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.LocaleGet = _ => CultureInfo.InvariantCulture;
            ShimSPWeb.AllInstances.AllUsersGet = _ => new ShimSPUserCollection();
            ShimSPWeb.AllInstances.GetListString = (_, __) => new ShimSPList();

            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, __) => new ShimSPUser
            {
                NameGet = () => DummyText
            };

            var properties = new StringDictionary { { "reportingV2", bool.TrueString } };
            var propertyBag = new ShimSPPropertyBag();
            propertyBag.Bind(properties);
            ShimSPWeb.AllInstances.PropertiesGet = _ => propertyBag.Instance;
            ShimSPSite.AllInstances.UrlGet = _ => ExampleUrl;
        }
    }
}
