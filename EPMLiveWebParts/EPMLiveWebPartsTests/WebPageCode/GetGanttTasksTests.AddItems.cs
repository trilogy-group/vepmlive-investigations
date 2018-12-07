using System;
using System.Collections;
using System.Data.Fakes;
using System.Xml;
using EPMLiveWebParts.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.WebPageCode
{
    public partial class GetGanttTasksTests
    {
        [TestMethod]
        public void AddItems_ExecutiveOn_AddsGroupsAndItems()
        {
            // Arrange
            var xmlDocument = new XmlDocument();
            var web = new ShimSPWeb();

            PrepareForAddItems(xmlDocument);
            SetAggregationDef("COUNT");
            _getGanttTasksPrivate.SetField("arrGroupMin", new SortedList { { DummyText, new DateTime(2018, 10, 10) } });
            _getGanttTasksPrivate.SetField("arrGroupMax", new SortedList { { DummyText, new DateTime(2019, 1, 1) } });

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddItems, new object[] { xmlDocument, web.Instance });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _didAddGroups.ShouldBeTrue(),
                () => _didAddItemFromList.ShouldBeTrue(),
                () => _didAddItemFromDataRow.ShouldBeTrue(),
                () => _hshItemNodes.ShouldNotBeNull(),
                () => _hshItemNodes.Count.ShouldBe(2),
                () => _hshItemNodes.ContainsKey(DummyText),
                () => _hshItemNodes.ContainsKey(NewKey));
        }

        [TestMethod]
        public void AddItems_ExecutiveOff_AddsGroupsAndItems()
        {
            // Arrange
            var xmlDocument = new XmlDocument();
            var web = new ShimSPWeb();

            PrepareForAddItems(xmlDocument);
            _getGanttTasksPrivate.SetField("executive", "off");

            SetAggregationDef("AVG");

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddItems, new object[] { xmlDocument, web.Instance });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _didAddGroups.ShouldBeTrue(),
                () => _didAddItemFromList.ShouldBeTrue(),
                () => _didAddItemFromDataRow.ShouldBeTrue(),
                () => _hshItemNodes.ShouldNotBeNull(),
                () => _hshItemNodes.Count.ShouldBe(2),
                () => _hshItemNodes.ContainsKey(DummyText),
                () => _hshItemNodes.ContainsKey(NewKey));
        }

        [TestMethod]
        public void AddItems_NotNullRollupSites_AddsGroupsAndItems()
        {
            // Arrange
            var xmlDocument = new XmlDocument();
            var web = new ShimSPWeb();

            PrepareForAddItems(xmlDocument);
            _getGanttTasksPrivate.SetField("rollupsites", new string[] { DummyText });
            SetAggregationDef("SUM");

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddItems, new object[] { xmlDocument, web.Instance });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _didAddGroups.ShouldBeTrue(),
                () => _didAddItemFromList.ShouldBeTrue(),
                () => _didAddItemFromDataRow.ShouldBeTrue(),
                () => _hshItemNodes.ShouldNotBeNull(),
                () => _hshItemNodes.Count.ShouldBe(2),
                () => _hshItemNodes.ContainsKey(DummyText),
                () => _hshItemNodes.ContainsKey(NewKey));
        }

        [TestMethod]
        public void AddItems_AggregationCount_AddsGroupsAndItems()
        {
            // Arrange
            var xmlDocument = new XmlDocument();
            var web = new ShimSPWeb();

            PrepareForAddItems(xmlDocument);
            SetAggregationDef("COUNT");

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddItems, new object[] { xmlDocument, web.Instance });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _didAddGroups.ShouldBeTrue(),
                () => _didAddItemFromList.ShouldBeTrue(),
                () => _didAddItemFromDataRow.ShouldBeTrue(),
                () => _hshItemNodes.ShouldNotBeNull(),
                () => _hshItemNodes.Count.ShouldBe(2),
                () => _hshItemNodes.ContainsKey(DummyText),
                () => _hshItemNodes.ContainsKey(NewKey));
        }

        [TestMethod]
        public void AddItems_AggregationSum_AddsGroupsAndItems()
        {
            // Arrange
            var xmlDocument = new XmlDocument();
            var web = new ShimSPWeb();

            PrepareForAddItems(xmlDocument);
            SetAggregationDef("SUM");

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddItems, new object[] { xmlDocument, web.Instance });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _didAddGroups.ShouldBeTrue(),
                () => _didAddItemFromList.ShouldBeTrue(),
                () => _didAddItemFromDataRow.ShouldBeTrue(),
                () => _hshItemNodes.ShouldNotBeNull(),
                () => _hshItemNodes.Count.ShouldBe(2),
                () => _hshItemNodes.ContainsKey(DummyText),
                () => _hshItemNodes.ContainsKey(NewKey));
        }

        [TestMethod]
        public void AddItems_AggregationMin_AddsGroupsAndItems()
        {
            // Arrange
            var xmlDocument = new XmlDocument();
            var web = new ShimSPWeb();

            PrepareForAddItems(xmlDocument);
            SetAggregationDef("MIN");

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddItems, new object[] { xmlDocument, web.Instance });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _didAddGroups.ShouldBeTrue(),
                () => _didAddItemFromList.ShouldBeTrue(),
                () => _didAddItemFromDataRow.ShouldBeTrue(),
                () => _hshItemNodes.ShouldNotBeNull(),
                () => _hshItemNodes.Count.ShouldBe(2),
                () => _hshItemNodes.ContainsKey(DummyText),
                () => _hshItemNodes.ContainsKey(NewKey));
        }

        [TestMethod]
        public void AddItems_AggregationMinDateTime_AddsGroupsAndItems()
        {
            // Arrange
            var xmlDocument = new XmlDocument();
            var web = new ShimSPWeb();

            PrepareForAddItems(xmlDocument, SPFieldType.DateTime);
            SetAggregationDef("MIN");

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddItems, new object[] { xmlDocument, web.Instance });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _didAddGroups.ShouldBeTrue(),
                () => _didAddItemFromList.ShouldBeTrue(),
                () => _didAddItemFromDataRow.ShouldBeTrue(),
                () => _hshItemNodes.ShouldNotBeNull(),
                () => _hshItemNodes.Count.ShouldBe(2),
                () => _hshItemNodes.ContainsKey(DummyText),
                () => _hshItemNodes.ContainsKey(NewKey));
        }

        [TestMethod]
        public void AddItems_AggregationMax_AddsGroupsAndItems()
        {
            // Arrange
            var xmlDocument = new XmlDocument();
            var web = new ShimSPWeb();

            PrepareForAddItems(xmlDocument);
            SetAggregationDef("MAX");

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddItems, new object[] { xmlDocument, web.Instance });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _didAddGroups.ShouldBeTrue(),
                () => _didAddItemFromList.ShouldBeTrue(),
                () => _didAddItemFromDataRow.ShouldBeTrue(),
                () => _hshItemNodes.ShouldNotBeNull(),
                () => _hshItemNodes.Count.ShouldBe(2),
                () => _hshItemNodes.ContainsKey(DummyText),
                () => _hshItemNodes.ContainsKey(NewKey));
        }

        [TestMethod]
        public void AddItems_AggregationMaxDateTime_AddsGroupsAndItems()
        {
            // Arrange
            var xmlDocument = new XmlDocument();
            var web = new ShimSPWeb();

            PrepareForAddItems(xmlDocument, SPFieldType.DateTime);
            SetAggregationDef("MAX");

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddItems, new object[] { xmlDocument, web.Instance });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _didAddGroups.ShouldBeTrue(),
                () => _didAddItemFromList.ShouldBeTrue(),
                () => _didAddItemFromDataRow.ShouldBeTrue(),
                () => _hshItemNodes.ShouldNotBeNull(),
                () => _hshItemNodes.Count.ShouldBe(2),
                () => _hshItemNodes.ContainsKey(DummyText),
                () => _hshItemNodes.ContainsKey(NewKey));
        }

        private void PrepareForAddItems(XmlDocument document, SPFieldType fieldType = SPFieldType.Number)
        {
            _getGanttTasksPrivate.SetField("list", new ShimSPList().Instance);
            _getGanttTasksPrivate.SetField("view", new ShimSPView().Instance);
            _getGanttTasksPrivate.SetField("additionalgroups", "Group1|Group2");
            _getGanttTasksPrivate.SetField("executive", "on");
            _getGanttTasksPrivate.SetField("expanded", "FALSE");

            var queue = new Queue();
            queue.Enqueue(new ShimSPListItem().Instance);
            queue.Enqueue(new ShimDataRow().Instance);
            _getGanttTasksPrivate.SetField("queueAllItems", queue);

            SetItemNodes(document);

            Shimgetgantttasks.AllInstances.addGroupsXmlDocumentSPWebStringSortedList =
                (a, b, c, d, arrGTemp) =>
                {
                    arrGTemp.Add(NewKey, DummyVal);
                    _didAddGroups = true;
                    return document;
                };
            Shimgetgantttasks.AllInstances.addItemSPListItemXmlDocument = (a, b, doc) =>
            {
                _didAddItemFromList = true;
                return doc;
            };
            Shimgetgantttasks.AllInstances.addItemDataRowXmlDocument = (a, b, doc) =>
            {
                _didAddItemFromDataRow = true;
                return doc;
            };

            PrepareSpWebRelatedShims();
            PrepareSpListRelatedShims();
            PrepareSpFieldRelatedShims(DummyVal, fieldType);

            ShimSPView.AllInstances.ViewFieldsGet = _ => new ShimSPViewFieldCollection();
            ShimSPViewFieldCollection.AllInstances.CountGet = _ => 1;
            ShimSPViewFieldCollection.AllInstances.ItemGetInt32 = (_, __) => "List";
            ShimSPView.AllInstances.QueryGet = _ => "<GroupBy><By Name='Title' Ascending='true'></By></GroupBy>";
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = callback => callback?.Invoke();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();

            ShimSPSite.ConstructorString = (_, __) => { };
            ShimSPSite.AllInstances.UrlGet = _ => ExampleUrl;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => new ShimSPWeb();
        }

        private void SetItemNodes(XmlDocument document)
        {
            var node = document.CreateNode(XmlNodeType.Element, "root", document.NamespaceURI);
            node.InnerXml = "<cell id='Title'></cell>";
            _hshItemNodes = new Hashtable { { DummyText, node } };
            _getGanttTasksPrivate.SetField("hshItemNodes", _hshItemNodes);
        }

        private void SetAggregationDef(string value)
        {
            var arrAggregationDef = new SortedList();
            arrAggregationDef.Add("Title", value);
            _getGanttTasksPrivate.SetField("arrAggregationDef", arrAggregationDef);

            var arrAggregationVals = new SortedList();
            arrAggregationVals.Add($"{DummyText}\nTitle", ",1,2");
            _getGanttTasksPrivate.SetField("arrAggregationVals", arrAggregationVals);
        }
    }
}
