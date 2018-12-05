using System;
using System.Collections;
using System.Data.Fakes;
using System.Fakes;
using System.Xml;
using System.Xml.Fakes;
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
        private const string FieldDue = "Due";
        private const string FieldDaysOverdue = "DaysOverdue";
        private const string FieldScheduleStatus = "ScheduleStatus";
        private const string MethodGetField = "getField";

        [TestMethod]
        public void GetField_Text_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.Text);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodGetField, new object[] { new ShimSPListItem().Instance, DummyFieldName });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DummyVal);
        }

        [TestMethod]
        public void GetField_SiteUrl_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.URL, 1);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodGetField, new object[] { new ShimSPListItem().Instance, "Site" });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe($"<a{ExampleUrl}>1</a>");
        }

        [TestMethod]
        public void GetField_Site_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.Text, 1);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodGetField, new object[] { new ShimSPListItem().Instance, "Site" });

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
            var result = _getGanttTasksPrivate.Invoke(MethodGetField, new object[] { new ShimSPListItem().Instance, "List" });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe($"<a{ListUrl}>{DummyVal}</a>");
        }

        [TestMethod]
        public void GetField_List_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.Text, 1);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodGetField, new object[] { new ShimSPListItem().Instance, "List" });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DummyVal);
        }

        [TestMethod]
        public void GetField_TitleUserGroup_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.User, 1);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodGetField, new object[] { new ShimSPListItem().Instance, TitleSPField });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe($"1;#{DummyText}");
        }

        [TestMethod]
        public void GetField_TitleUserNotGroup_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.User, 1);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodGetField, new object[] { new ShimSPListItem().Instance, TitleSPField });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe($"1;#{DummyText}");
        }

        [TestMethod]
        public void GetField_TitleLookup_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.Lookup, 1);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodGetField, new object[] { new ShimSPListItem().Instance, TitleSPField });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DummyVal);
        }

        [TestMethod]
        public void GetField_TitleLookupMulti_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.Lookup, 1);
            ShimSPField.AllInstances.TypeAsStringGet = _ => "LookupMulti";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodGetField, new object[] { new ShimSPListItem().Instance, TitleSPField });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(DummyVal);
        }

        [TestMethod]
        public void GetField_TitleCalculated_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.Calculated, 1);
            ShimSPListItem.AllInstances.ItemGetGuid = (_, __) => "Item1;#Item2";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodGetField, new object[] { new ShimSPListItem().Instance, TitleSPField });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe("Item2");
        }

        [TestMethod]
        public void GetField_TitleCurrency_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.Currency, 1);
            ShimSPListItem.AllInstances.ItemGetGuid = (_, __) => "0.1";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodGetField, new object[] { new ShimSPListItem().Instance, TitleSPField });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe("0.1");
        }

        [TestMethod]
        public void GetField_TitleTotalRollup_ReturnsValue()
        {
            // Arrange
            PrepareForGetField(SPFieldType.Invalid, 1);
            ShimSPField.AllInstances.TypeAsStringGet = _ => "TotalRollup";
            ShimSPListItem.AllInstances.ItemGetGuid = (_, __) => "1.234";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodGetField, new object[] { new ShimSPListItem().Instance, TitleSPField });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe("1");
        }

        private void PrepareForGetField(SPFieldType fieldType, int id = 0)
        {
            PrepareSpListRelatedShims();
            PrepareSpFieldRelatedShims(DummyFieldName, fieldType);
            PrepareSpWebRelatedShims();

            ShimSPListItem.AllInstances.IDGet = _ => id;
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><Default></Default></root>";
            _getGanttTasksPrivate.SetField("list", new ShimSPList().Instance);
            _getGanttTasksPrivate.SetField("filterResources", new ArrayList { DummyVal });
        }
    }
}
