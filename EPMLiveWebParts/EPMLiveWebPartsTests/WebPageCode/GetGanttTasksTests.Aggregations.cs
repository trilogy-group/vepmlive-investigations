using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.WebPageCode
{
    public partial class GetGanttTasksTests
    {
        private const string MethodSetAggVal = "setAggVal";
        private const string MethodCreateLinks = "createLinks";
        private const string MethodAddHeader = "addHeader";
        private const string FieldMainParent = "ndMainParent";
        private const string TitleSPField = "Title";
        private const string RootXml = "<root></root>";

        [TestMethod]
        public void SetAggVal_Count_ReturnsValue()
        {
            // Arrange
            const string key = "COUNT";
            const string currentValue = "1";
            var aggregationVals = PrepareForSetAggVal(key, currentValue);

            // Act
            _getGanttTasksPrivate.Invoke(MethodSetAggVal, new object[] { DummyText, DummyFieldName, DummyVal, new ShimSPList().Instance });

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
            _getGanttTasksPrivate.Invoke(MethodSetAggVal, new object[] { DummyText, DummyFieldName, "50%", new ShimSPList().Instance });

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
            _getGanttTasksPrivate.Invoke(MethodSetAggVal, new object[] { DummyText, DummyFieldName, "50%", new ShimSPList().Instance });

            // Assert
            var result = aggregationVals[$"{DummyText}\n{DummyText}"];
            result.ShouldNotBeNull();
            result.ShouldBe(60d);
        }

        [TestMethod]
        public void SetAggVal_MinNumber_ReturnsValue()
        {
            // Arrange
            const string key = "MIN";
            const string currentValue = "60";
            var aggregationVals = PrepareForSetAggVal(key, currentValue, SPFieldType.Number);

            // Act
            _getGanttTasksPrivate.Invoke(MethodSetAggVal, new object[] { DummyText, DummyFieldName, "50%", new ShimSPList().Instance });

            // Assert
            var result = aggregationVals[$"{DummyText}\n{DummyText}"];
            result.ShouldNotBeNull();
            result.ShouldBe(50d);
        }

        [TestMethod]
        public void SetAggVal_MinNumberNoCurrent_ReturnsNewValue()
        {
            // Arrange
            const string key = "MIN";
            var aggregationVals = PrepareForSetAggVal(key, string.Empty, SPFieldType.Number);

            // Act
            _getGanttTasksPrivate.Invoke(MethodSetAggVal, new object[] { DummyText, DummyFieldName, "50%", new ShimSPList().Instance });

            // Assert
            var result = aggregationVals[$"{DummyText}\n{DummyText}"];
            result.ShouldNotBeNull();
            result.ShouldBe(50d);
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
            _getGanttTasksPrivate.Invoke(MethodSetAggVal, new object[] { DummyText, DummyFieldName, newValue, new ShimSPList().Instance });

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
            _getGanttTasksPrivate.Invoke(MethodSetAggVal, new object[] { DummyText, DummyFieldName, "50%", new ShimSPList().Instance });

            // Assert
            var result = aggregationVals[$"{DummyText}\n{DummyText}"];
            result.ShouldNotBeNull();
            result.ShouldBe(50d);
        }

        [TestMethod]
        public void SetAggVal_MaxNumberNoCurrent_ReturnsNewValue()
        {
            // Arrange
            const string key = "MAX";
            var aggregationVals = PrepareForSetAggVal(key, string.Empty, SPFieldType.Number);

            // Act
            _getGanttTasksPrivate.Invoke(MethodSetAggVal, new object[] { DummyText, DummyFieldName, "50%", new ShimSPList().Instance });

            // Assert
            var result = aggregationVals[$"{DummyText}\n{DummyText}"];
            result.ShouldNotBeNull();
            result.ShouldBe(50d);
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
            _getGanttTasksPrivate.Invoke(MethodSetAggVal, new object[] { DummyText, DummyFieldName, newValue, new ShimSPList().Instance });

            // Assert
            var result = aggregationVals[$"{DummyText}\n{DummyText}"];
            result.ShouldNotBeNull();
            result.ShouldBe(newDate.ToShortDateString());
        }

        [TestMethod]
        public void CreateLinks_SS_FillsLinkNode()
        {
            // Arrange
            var xmlDoc = new XmlDocument();
            var links = PrepareForCreateLinks(xmlDoc, "SS");

            // Act
            _getGanttTasksPrivate.Invoke(MethodCreateLinks, new object[] { xmlDoc, links });

            // Assert
            var result = links.InnerXml;
            result.ShouldNotBeNullOrEmpty();
            result.ShouldBe(GetLinkElement("0", "0"));
        }

        [TestMethod]
        public void CreateLinks_FF_FillsLinkNode()
        {
            // Arrange
            var xmlDoc = new XmlDocument();
            var links = PrepareForCreateLinks(xmlDoc, "FF");

            // Act
            _getGanttTasksPrivate.Invoke(MethodCreateLinks, new object[] { xmlDoc, links });

            // Assert
            var result = links.InnerXml;
            result.ShouldNotBeNullOrEmpty();
            result.ShouldBe(GetLinkElement("2", "2"));
        }

        [TestMethod]
        public void CreateLinks_SF_FillsLinkNode()
        {
            // Arrange
            var xmlDoc = new XmlDocument();
            var links = PrepareForCreateLinks(xmlDoc, "SF");

            // Act
            _getGanttTasksPrivate.Invoke(MethodCreateLinks, new object[] { xmlDoc, links });

            // Assert
            var result = links.InnerXml;
            result.ShouldNotBeNullOrEmpty();
            result.ShouldBe(GetLinkElement("0", "2"));
        }

        [TestMethod]
        public void AddHeader_Title_FillsHeader()
        {
            // Arrange
            var xmlDoc = PrepareForAddHeader(TitleSPField, SPFieldType.Text);

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddHeader, new object[] { xmlDoc });

            // Assert
            var result = xmlDoc.InnerXml;
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    var columns = _getGanttTasksPrivate.GetField("arrColumns") as ArrayList;
                    columns.ShouldNotBeNull();
                    columns.Contains(TitleSPField).ShouldBeTrue();
                },
                () =>
                {
                    result.ShouldNotBeNullOrEmpty();
                    result.ShouldBe(GetHeaderElement(200, 0, 0, 0));
                });
        }

        [TestMethod]
        public void AddHeader_CalculatedNumber_FillsHeader()
        {
            // Arrange
            var xmlDoc = PrepareForAddHeader(DummyText, SPFieldType.Calculated);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root ResultType='Number'></root>";

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddHeader, new object[] { xmlDoc });

            // Assert
            var result = xmlDoc.InnerXml;
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    var columns = _getGanttTasksPrivate.GetField("arrColumns") as ArrayList;
                    columns.ShouldNotBeNull();
                    columns.Contains(TitleSPField).ShouldBeTrue();
                },
                () =>
                {
                    result.ShouldNotBeNullOrEmpty();
                    result.ShouldBe(GetHeaderElement(80, 2, 1, 0));
                });
        }

        [TestMethod]
        public void AddHeader_CalculatedIndicator_FillsHeader()
        {
            // Arrange
            var xmlDoc = PrepareForAddHeader(DummyText, SPFieldType.Calculated);
            ShimSPField.AllInstances.DescriptionGet = _ => "Indicator";

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddHeader, new object[] { xmlDoc });

            // Assert
            var result = xmlDoc.InnerXml;
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    var columns = _getGanttTasksPrivate.GetField("arrColumns") as ArrayList;
                    columns.ShouldNotBeNull();
                    columns.Contains(TitleSPField).ShouldBeTrue();
                },
                () =>
                {
                    result.ShouldNotBeNullOrEmpty();
                    result.ShouldBe(GetHeaderElement(80, 1, 0, 0));
                });
        }

        [TestMethod]
        public void AddHeader_DateTime_FillsHeader()
        {
            // Arrange
            var xmlDoc = PrepareForAddHeader(DummyText, SPFieldType.DateTime);

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddHeader, new object[] { xmlDoc });

            // Assert
            var result = xmlDoc.InnerXml;
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    var columns = _getGanttTasksPrivate.GetField("arrColumns") as ArrayList;
                    columns.ShouldNotBeNull();
                    columns.Contains(TitleSPField).ShouldBeTrue();
                },
                () =>
                {
                    result.ShouldNotBeNullOrEmpty();
                    result.ShouldBe(GetHeaderElement(80, 2, 3, 4));
                });
        }

        [TestMethod]
        public void AddHeader_Currency_FillsHeader()
        {
            // Arrange
            var xmlDoc = PrepareForAddHeader(DummyText, SPFieldType.Currency);

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddHeader, new object[] { xmlDoc });

            // Assert
            var result = xmlDoc.InnerXml;
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    var columns = _getGanttTasksPrivate.GetField("arrColumns") as ArrayList;
                    columns.ShouldNotBeNull();
                    columns.Contains(TitleSPField).ShouldBeTrue();
                },
                () =>
                {
                    result.ShouldNotBeNullOrEmpty();
                    result.ShouldBe(GetHeaderElement(80, 2, 1, 0));
                });
        }

        [TestMethod]
        public void AddHeader_Number_FillsHeader()
        {
            // Arrange
            var xmlDoc = PrepareForAddHeader(DummyText, SPFieldType.Number);

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddHeader, new object[] { xmlDoc });

            // Assert
            var result = xmlDoc.InnerXml;
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    var columns = _getGanttTasksPrivate.GetField("arrColumns") as ArrayList;
                    columns.ShouldNotBeNull();
                    columns.Contains(TitleSPField).ShouldBeTrue();
                },
                () =>
                {
                    result.ShouldNotBeNullOrEmpty();
                    result.ShouldBe(GetHeaderElement(80, 2, 1, 0));
                });
        }

        private SortedList PrepareForSetAggVal(string key, string fieldValue, SPFieldType fieldType = SPFieldType.Text)
        {
            var aggregationVals = new SortedList();
            aggregationVals.Add(DummyText, key);
            aggregationVals.Add($"{DummyText}\n{DummyText}", fieldValue);
            _getGanttTasksPrivate.SetField("arrAggregationVals", aggregationVals);
            _getGanttTasksPrivate.SetField("arrAggregationDef", aggregationVals);

            PrepareSpFieldRelatedShims(DummyText, fieldType);
            PrepareSpListRelatedShims();

            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root Format='DateOnly'></root>";

            return aggregationVals;
        }

        private XmlNode PrepareForCreateLinks(XmlDocument xmlDoc, string linkType)
        {
            xmlDoc.LoadXml($"<Main><Item Predecessors='123{linkType}' GroupTo='123.123' Index='1'></Item></Main>");
            var ndMainParent = xmlDoc.SelectSingleNode("Main");
            _getGanttTasksPrivate.SetField(FieldMainParent, ndMainParent);
            var links = xmlDoc.CreateNode(XmlNodeType.Element, "links", xmlDoc.NamespaceURI);

            return links;
        }

        private XmlDocument PrepareForAddHeader(string internalName, SPFieldType fieldType)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(RootXml);
            var views = new string[] { TitleSPField };
            var viewCollection = new ShimSPViewFieldCollection();
            viewCollection.Bind(views);
            ShimSPView.AllInstances.ViewFieldsGet = _ => viewCollection;
            PrepareSpFieldRelatedShims(internalName, fieldType);
            PrepareSpListRelatedShims();
            _getGanttTasksPrivate.SetField("list", new ShimSPList().Instance);
            _getGanttTasksPrivate.SetField("view", new ShimSPView().Instance);
            return xmlDoc;
        }

        private string GetLinkElement(string start, string end)
        {
            return $"<Link Key=\"Link0\" StartItem=\"0\" StartPos=\"{start}\" EndItem=\"0\" EndPos=\"{end}\" Visible=\"-1\" Color=\"0\" ShowDir=\"-1\" />";
        }

        private string GetHeaderElement(int width, int align, int sort, int filter)
        {
            return $"<root><Columns><Column Caption=\"DummyText\" Width=\"{width}\" Position=\"0\" Alignment=\"{align}\" DisplayFilterButton=\"1\" FilterType=\"{filter}\" SortType=\"{sort}\" /></Columns></root>";
        }
    }
}
