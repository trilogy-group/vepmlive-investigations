using System;
using System.Collections;
using System.Collections.Fakes;
using System.Collections.Generic;
using System.Collections.Generic.Fakes;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices.ActiveDirectory.Fakes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Xml;
using System.Xml.Fakes;
using EPMLiveWebParts;
using EPMLiveWebParts.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Workflow.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.WebPageCode
{
    public partial class GetGanttTasksTests
    {

        [TestMethod]
        public void AddItem_DocIcon_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("Title", "DocIcon");

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });
            
            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_WorkspaceUrl_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("Title", "WorkspaceUrl");

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_ContentType_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("Title", "ContentType");

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_ContentTypeNoListItemId_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("Title", "ContentType");
            ShimSPListItem.AllInstances.IDGet = _ => 0;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldBeNull();
        }

        [TestMethod]
        public void AddItem_FileLeafRefView_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("Title", "FileLeafRef", "view");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_FileLeafRefEdit_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("Title", "FileLeafRef", "edit");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_FileLeafRefEditLinkFilenameNoMenu_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("LinkFilenameNoMenu", "FileLeafRef", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_FileLeafRefEditLinkFilename_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("LinkFilename", "FileLeafRef", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_TitleCleanValues_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("Title", "Title", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_TitleViewNotUsePopup_SetsNewItemRow()
        {
            // Arrange
            _wbs = $"{DummyText}.{DummyVal}";
            _usepopup = false;
            var indexer = PrepareForAddItem("Title", "Title", "view");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"&lt;ahttp://www.example.com/?ID=1&amp;Source=DummyVal&gt;DummyVal&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_TitleViewUsePopup_SetsNewItemRow()
        {
            // Arrange
            _usepopup = true;
            var indexer = PrepareForAddItem("Title", "Title", "view");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe($"<Cell Value=\"&lt;ajavascript:void(0);&quot; onclick=&quot;javascript:viewItem(1,'{DefaultListId}','{DefaultWebId}','00000000-0000-0000-0000-000000000000','http://www.example.com',1);&gt;DummyVal&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_TitleEditNotUsePopup_SetsNewItemRow()
        {
            // Arrange
            _isMilestone = "True";
            _usepopup = false;
            var indexer = PrepareForAddItem("Title", "Title", "edit");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"&lt;ahttp://www.example.com/?ID=1&amp;Source=DummyVal&gt;DummyVal&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"Milestone\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"0\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_TitleEditUsePopup_SetsNewItemRow()
        {
            // Arrange
            _usepopup = true;
            var indexer = PrepareForAddItem("Title", "Title", "edit");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe($"<Cell Value=\"&lt;ajavascript:void(0);&quot; onclick=&quot;javascript:viewItem(1,'{DefaultListId}','{DefaultWebId}','00000000-0000-0000-0000-000000000000','http://www.example.com',2);&gt;DummyVal&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_TitleLinkTitleNoMenuNotUsePopup_SetsNewItemRow()
        {
            // Arrange
            _usepopup = false;
            var indexer = PrepareForAddItem("LinkTitleNoMenu", "Title");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"&lt;ahttp://www.example.com/?ID=1&amp;Source=DummyVal&gt;DummyVal&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_TitleLinkTitleNoMenuUsePopup_SetsNewItemRow()
        {
            // Arrange
            _usepopup = true;
            var indexer = PrepareForAddItem("LinkTitleNoMenu", "Title");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe($"<Cell Value=\"&lt;ajavascript:viewItem(1,'{DefaultListId}','{DefaultWebId}','00000000-0000-0000-0000-000000000000','http://www.example.com',1);&gt;DummyVal&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_TitleLinkTitleNotUsePopup_SetsNewItemRow()
        {
            // Arrange
            _usepopup = false;
            var indexer = PrepareForAddItem("LinkTitle", "Title", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"&lt;ahttp://www.example.com/?ID=1&amp;Source=DummyVal&gt;DummyVal&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_TitleLinkTitleUsePopup_SetsNewItemRow()
        {
            // Arrange
            _usepopup = true;
            var indexer = PrepareForAddItem("LinkTitle", "Title", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe($"<Cell Value=\"&lt;ajavascript:viewItem(1,'{DefaultListId}','{DefaultWebId}','00000000-0000-0000-0000-000000000000','http://www.example.com',2);&gt;DummyVal&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_TitleWorkspace_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("Title", "Title", "workspace");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"&lt;ahttp://www.example.com/&gt;DummyVal&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_TitleWorkplan_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("Title", "Title", "workplan");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"&lt;ahttp://www.example.com/_layouts/epmlive/tasks.aspx?ID=1&gt;DummyVal&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_TitlePlanner_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("Title", "Title", "planner");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_TitleTasks_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("Title", "Title", "tasks");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"&lt;ahttp://www.example.com/http://www.example.com?FilterField1=Project&amp;FilterValue1=&gt;DummyVal&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_CleanValuesCalculatedIndicator_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Calculated);
            ShimSPField.AllInstances.DescriptionGet = _ => "Indicator";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_CleanValuesCalculatedNonIndicator_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Calculated);
            ShimSPField.AllInstances.DescriptionGet = _ => DummyVal;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_CleanValuesUserFieldUserValue_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.User);
            ShimSPField.AllInstances.GetFieldValueString = (_, __) => new ShimSPFieldUserValue().Instance;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_CleanValuesUserFieldUserValueCollection_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.User);

            var shimFields = new ShimSPFieldUserValueCollection();
            var list = new List<SPFieldUserValue> { new ShimSPFieldUserValue() };
            shimFields.Bind(list as IList<SPFieldUserValue>);
            var enumerator = list.GetEnumerator();
            ShimList<SPFieldUserValue>.AllInstances.GetEnumerator = _ => enumerator;

            ShimSPField.AllInstances.GetFieldValueString = (_, __) => shimFields.Instance;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_CleanValuesMultiChoice_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.MultiChoice);
            ShimSPField.AllInstances.DescriptionGet = _ => DummyVal;
            ShimSPFieldMultiChoiceValue.ConstructorString = (instance, _) => { };
            ShimSPFieldMultiChoiceValue.AllInstances.CountGet = _ => 1;
            ShimSPFieldMultiChoiceValue.AllInstances.ItemGetInt32 = (_, __) => DummyVal;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_CleanValuesLookup_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Lookup);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" />"));
        }

        [TestMethod]
        public void AddItem_CleanValuesDateTime_SetsNewItemRow()
        {
            // Arrange
            var date = new DateTime(2018, 10, 10);
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.DateTime);
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => date;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_CleanValuesText_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Text);
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => DummyText;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_InEditModeNumber_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Number, editable: true);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><value Percentage=\"TRUE\">1</value></root>";
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => One;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_InEditModeUserFieldUserValue_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.User, editable: true);
            ShimSPField.AllInstances.GetFieldValueString = (_, __) => new ShimSPFieldUserValue().Instance;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_InEditModeUserFieldUserValueCollection_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.User, editable: true);

            var shimFields = new ShimSPFieldUserValueCollection();
            var list = new List<SPFieldUserValue> { new ShimSPFieldUserValue() };
            shimFields.Bind(list as IList<SPFieldUserValue>);
            var enumerator = list.GetEnumerator();
            ShimList<SPFieldUserValue>.AllInstances.GetEnumerator = _ => enumerator;

            ShimSPField.AllInstances.GetFieldValueString = (_, __) => shimFields.Instance;
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><value Type=\"UserMulti\">1</value></root>";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_InEditModeCalculated_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Calculated, editable: true);
            ShimSPField.AllInstances.DescriptionGet = _ => "Indicator";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_InEditModeCurrency_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Currency, editable: true);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_InEditModeAttachmentsEmpty_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Attachments, editable: true);
            ShimSPListItem.AllInstances.AttachmentsGet = _ => new ShimSPAttachmentCollection();
            ShimSPAttachmentCollection.AllInstances.CountGet = _ => 0;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_InEditModeAttachmentsNotEmpty_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Attachments, editable: true);
            ShimSPListItem.AllInstances.AttachmentsGet = _ => new ShimSPAttachmentCollection();
            ShimSPAttachmentCollection.AllInstances.CountGet = _ => 1;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"&lt;ahttp://www.example.com&gt;&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_InEditModeText_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Text, editable: true);
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => $"{DummyText}.{DummyVal}";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_InEditModeBooleanTrue_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Boolean, editable: true);
            ShimSPWeb.AllInstances.TitleGet = _ => "true";
            ShimSPList.AllInstances.TitleGet = _ => "Project Center";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"No\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"No\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_InEditModeBooleanFalse_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Boolean, editable: true);
            ShimSPWeb.AllInstances.TitleGet = _ => "false";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"No\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"No\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_InEditModeDateTime_SetsNewItemRow()
        {
            // Arrange
            var date = new DateTime(2018, 10, 10);
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.DateTime, editable: true);
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => date.ToString();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_InEditModeInteger_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Integer, editable: true);
            ShimSPField.AllInstances.TypeAsStringGet = _ => "Integer";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_NotInEditModeAttachmentsEmpty_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Attachments, editable: false);
            ShimSPListItem.AllInstances.AttachmentsGet = _ => new ShimSPAttachmentCollection();
            ShimSPAttachmentCollection.AllInstances.CountGet = _ => 0;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_NotInEditModeAttachmentsNotEmpty_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Attachments, editable: false);
            ShimSPListItem.AllInstances.AttachmentsGet = _ => new ShimSPAttachmentCollection();
            ShimSPAttachmentCollection.AllInstances.CountGet = _ => 1;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"&lt;ahttp://www.example.com&gt;&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_NotInEditModeUser_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.User, editable: false);
            ShimSPField.AllInstances.GetFieldValueString = (_, __) => new ShimSPFieldUserValue().Instance;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_NotInEditModeCalculated_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Calculated, editable: false);
            ShimSPField.AllInstances.DescriptionGet = _ => "Indicator";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_NotInEditModeMultiChoice_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.MultiChoice, editable: false);
            ShimSPWeb.AllInstances.TitleGet = _ => "1,2";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_NotInEditModeChoice_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Choice, editable: false);
            ShimSPWeb.AllInstances.TitleGet = _ => "1,2";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/1/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" EPMLiveWork=\"1\" EPMLiveRW=\"False\" /></Bars>"));
        }

        [TestMethod]
        public void AddItem_NotInEditModeLookup_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Lookup, editable: false);
            ShimSPWeb.AllInstances.TitleGet = _ => "1,2";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { new ShimSPListItem().Instance, _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" />"));
        }

        private string PrepareForAddItem(string fieldName, string internalname, string linkType = "", SPFieldType fieldType = SPFieldType.Text, bool editable = true)
        {
            _xmlDocument = new XmlDocument();

            var listId = DefaultListId.ToString();
            var webId = DefaultWebId.ToString();
            var indexer = $"{webId}.{listId}.{1}";

            var hshWBS = new Hashtable();
            hshWBS.Add($"Admin\n{DummyText}", _xmlDocument.CreateNode(XmlNodeType.Element, DummyFieldName, _xmlDocument.NamespaceURI));

            var arrItems = new SortedList();
            arrItems.Add(indexer, new string[] { "Admin" });

            var hshLists = new Hashtable();
            hshLists.Add("ICON", "test.png");

            _getGanttTasksPrivate.SetField("hshWBS", hshWBS);
            _getGanttTasksPrivate.SetField("arrItems", arrItems);
            _getGanttTasksPrivate.SetField("hshLists", hshLists);
            _getGanttTasksPrivate.SetField("usePopup", _usepopup);
            _getGanttTasksPrivate.SetField("isResourcePlan", true);
            _getGanttTasksPrivate.SetField("start", "start");
            _getGanttTasksPrivate.SetField("finish", "finish");
            _getGanttTasksPrivate.SetField("progress", "progress");
            _getGanttTasksPrivate.SetField("wbsfield", "wbsfield");
            _getGanttTasksPrivate.SetField("milestone", "milestone");
            _getGanttTasksPrivate.SetField("information", "information");
            _getGanttTasksPrivate.SetField("rolluplists", new string[] { DummyVal });
            _getGanttTasksPrivate.SetField("linktype", linkType);
            _getGanttTasksPrivate.SetField("list", new ShimSPList().Instance);
            _getGanttTasksPrivate.SetField("view", new ShimSPView().Instance);
            _getGanttTasksPrivate.SetField("overallMin", new DateTime(2019, 10, 10));

            var arrGroupMin = new SortedList();
            arrGroupMin.Add("Admin", new DateTime(2019, 1, 2));
            arrGroupMin.Add(DummyText, new DateTime(2019, 1, 2));
            _getGanttTasksPrivate.SetField("arrGroupMin", arrGroupMin);

            var arrGroupMax = new SortedList();
            arrGroupMax.Add("Admin", new DateTime(2018, 10, 20));
            arrGroupMax.Add(DummyText, new DateTime(2018, 10, 20));
            _getGanttTasksPrivate.SetField("arrGroupMax", arrGroupMax);

            var hshItemNodes = new Hashtable();
            hshItemNodes.Add("Admin", _xmlDocument.CreateNode(XmlNodeType.Element, "Items", _xmlDocument.NamespaceURI));
            hshItemNodes.Add(FieldTitle, DummyVal);
            hshItemNodes.Add("SiteUrl", string.Empty);
            hshItemNodes.Add("List", string.Empty);
            hshItemNodes.Add("Site", string.Empty);
            hshItemNodes.Add(internalname + "Text", "Text");
            hshItemNodes.Add("ItemID", string.Empty);
            hshItemNodes.Add("Work", string.Empty);
            hshItemNodes.Add("WorkspaceUrl", string.Empty);
            if (!hshItemNodes.ContainsKey(internalname))
            {
                hshItemNodes.Add(internalname, string.Empty);
            }
            _getGanttTasksPrivate.SetField("hshItemNodes", hshItemNodes);

            ShimSharePoint(internalname, fieldType, listId, webId);

            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest();
            ShimHttpRequest.AllInstances.ItemGetString = (_, __) => DummyVal;

            var fields = new List<string> { fieldName };
            var fieldsCollection = new ShimSPViewFieldCollection();
            fieldsCollection.Bind(fields);
            ShimSPView.AllInstances.ViewFieldsGet = _ => fieldsCollection;
            ShimSPViewFieldCollection.AllInstances.CountGet = _ => fields.Count;
            ShimSPViewFieldCollection.AllInstances.ItemGetInt32 = (_, __) => fieldName;

            ShimXmlDocument.AllInstances.CreateNodeXmlNodeTypeStringString =
            (docXml, type, name, ns) =>
            {
                var node = ShimsContext.ExecuteWithoutShims(() => docXml.CreateNode(type, name, ns));

                if (type == XmlNodeType.Element && name == "Item" && _newItemNode == null)
                {
                    _newItemNode = node;
                }

                return node;
            };

            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, key) =>
            {
                ShimSPListItem.AllInstances.ItemGetGuid = (x, y) =>
                {
                    switch (key)
                    {
                        case "progress":
                        case "Duration":
                        case "Work":
                            return One;
                        case "start":
                        case "finish":
                            return new DateTime(2019, 1, 1).ToString();
                        case "wbsfield":
                            return _wbs;
                        case "milestone":
                            return _isMilestone;
                        default:
                            return DummyVal;
                    }
                };
                return new ShimSPField();
            };

            return indexer;
        }

        private void ShimSharePoint(string internalname, SPFieldType fieldType, string listId, string webId)
        {
            ShimSPView.AllInstances.UrlGet = _ => ExampleUrl;
            ShimSPContentTypeCollection.AllInstances.ItemGetInt32 = (_, __) => new ShimSPContentType { NameGet = () => TypeTextPlain };
            ShimSPFormCollection.AllInstances.ItemGetPAGETYPE = (_, __) => new ShimSPForm();
            ShimSPForm.AllInstances.ServerRelativeUrlGet = _ => ExampleUrl;

            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();

            PrepareSpListRelatedShims(listId);
            PrepareSpFieldRelatedShims(internalname, fieldType);
            PrepareSpWebRelatedShims(webId);
            PrepareSpFileRelatedShims();
            PrepareSpUserRelatedShims();
        }
    }
}
