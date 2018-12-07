using System;
using System.Collections.Generic;
using System.Collections.Generic.Fakes;
using System.Data;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.WebPageCode
{
    public partial class GetGanttTasksTests
    {
        private const string TestUrl = "http://testURL";

        [TestMethod]
        public void AddItemDataRow_DocIcon_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("Title", "DocIcon");

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_WorkspaceUrl_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("Title", "WorkspaceUrl");

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe($"<Cell Value=\"{TestUrl}\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_ContentType_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("Title", "ContentType");

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_ContentTypeNoListItemId_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("Title", "ContentType");
            ShimSPListItem.AllInstances.IDGet = _ => 0;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_FileLeafRefView_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("Title", "FileLeafRef", "view");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_FileLeafRefEdit_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("Title", "FileLeafRef", "edit");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_FileLeafRefEditLinkFilenameNoMenu_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("LinkFilenameNoMenu", "FileLeafRef", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_FileLeafRefEditLinkFilename_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("LinkFilename", "FileLeafRef", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleCleanValues_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("Title", "Title", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleViewNotUsePopup_SetsNewItemRow()
        {
            // Arrange
            _wbs = $"{DummyText}.{DummyVal}";
            _usepopup = false;
            var indexer = PrepareForAddItem("Title", "Title", "view");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe($"<Cell Value=\"&lt;a/_layouts/epmlive/gridaction.aspx?action=view&amp;webid={DefaultWebId}&amp;listid={DefaultListId}&amp;ID=1&amp;Source=DummyVal&gt;DummyVal&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleViewUsePopup_SetsNewItemRow()
        {
            // Arrange
            _usepopup = true;
            var indexer = PrepareForAddItem("Title", "Title", "view");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe($"<Cell Value=\"&lt;ajavascript:viewItem(1,'{DefaultListId}','{DefaultWebId}','','',1);&gt;DummyVal&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleEditNotUsePopup_SetsNewItemRow()
        {
            // Arrange
            _isMilestone = "True";
            _usepopup = false;
            var indexer = PrepareForAddItem("Title", "Title", "edit");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe($"<Cell Value=\"&lt;a/_layouts/epmlive/gridaction.aspx?action=edit&amp;webid={DefaultWebId}&amp;listid={DefaultListId}&amp;ID=1&amp;Source=DummyVal&gt;DummyVal&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"Milestone\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"0\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleEditUsePopup_SetsNewItemRow()
        {
            // Arrange
            _usepopup = true;
            var indexer = PrepareForAddItem("Title", "Title", "edit");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe($"<Cell Value=\"&lt;ajavascript:viewItem(1,'{DefaultListId}','{DefaultWebId}','','',2);&gt;DummyVal&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleLinkTitleNoMenuNotUsePopup_SetsNewItemRow()
        {
            // Arrange
            _usepopup = false;
            var indexer = PrepareForAddItem("LinkTitleNoMenu", "Title");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe($"<Cell Value=\"&lt;a/_layouts/epmlive/gridaction.aspx?action=view&amp;webid={DefaultWebId}&amp;listid={DefaultListId}&amp;ID=1&amp;Source=DummyVal&gt;DummyVal&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleLinkTitleNoMenuUsePopup_SetsNewItemRow()
        {
            // Arrange
            _usepopup = true;
            var indexer = PrepareForAddItem("LinkTitleNoMenu", "Title");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe($"<Cell Value=\"&lt;ajavascript:viewItem(1,'{DefaultListId}','{DefaultWebId}','','',1);&gt;{DummyVal}&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleLinkTitleNotUsePopup_SetsNewItemRow()
        {
            // Arrange
            _usepopup = false;
            var indexer = PrepareForAddItem("LinkTitle", "Title", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe($"<Cell Value=\"&lt;a/_layouts/epmlive/gridaction.aspx?action=edit&amp;webid={DefaultWebId}&amp;listid={DefaultListId}&amp;ID=1&amp;Source={DummyVal}&gt;{DummyVal}&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleLinkTitleUsePopup_SetsNewItemRow()
        {
            // Arrange
            _usepopup = true;
            var indexer = PrepareForAddItem("LinkTitle", "Title", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe($"<Cell Value=\"&lt;ajavascript:viewItem(1,'{DefaultListId}','{DefaultWebId}','','',2);&gt;DummyVal&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleWorkspace_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("Title", "Title", "workspace");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe($"<Cell Value=\"&lt;a/_layouts/epmlive/gridaction.aspx?action=workspace&amp;webid={DefaultWebId}&gt;DummyVal&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleWorkplan_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("Title", "Title", "workplan");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe($"<Cell Value=\"&lt;a/_layouts/epmlive/gridaction.aspx?action=workplan&amp;webid={DefaultWebId}&amp;listid={DefaultListId}&amp;ID=1&gt;DummyVal&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitlePlanner_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("Title", "Title", "planner");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleTasks_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("Title", "Title", "tasks");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe($"<Cell Value=\"&lt;a/_layouts/epmlive/gridaction.aspx?action=tasks&amp;webid={DefaultWebId}&amp;listid={DefaultListId}&amp;ID=1&amp;Source=DummyVal&amp;FilterField1=Project&amp;FilterValue1=DummyVal&gt;DummyVal&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_CleanValuesCalculatedIndicator_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Calculated);
            ShimSPField.AllInstances.DescriptionGet = _ => "Indicator";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_CleanValuesCalculatedNonIndicator_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Calculated);
            ShimSPField.AllInstances.DescriptionGet = _ => DummyVal;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_CleanValuesUserFieldUserValue_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.User);
            ShimSPField.AllInstances.GetFieldValueString = (_, __) => new ShimSPFieldUserValue().Instance;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"&lt;a href=&quot;/_layouts/userdisp.aspx?ID=1&quot;&gt;DummyText&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_CleanValuesUserFieldUserValueCollection_SetsNewItemRow()
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
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"&lt;a href=&quot;/_layouts/userdisp.aspx?ID=1&quot;&gt;DummyText&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_CleanValuesMultiChoice_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.MultiChoice);
            ShimSPField.AllInstances.DescriptionGet = _ => DummyVal;
            ShimSPFieldMultiChoiceValue.ConstructorString = (instance, _) => { };
            ShimSPFieldMultiChoiceValue.AllInstances.CountGet = _ => 1;
            ShimSPFieldMultiChoiceValue.AllInstances.ItemGetInt32 = (_, __) => DummyVal;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_CleanValuesLookup_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Lookup);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert

            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_CleanValuesDateTime_SetsNewItemRow()
        {
            // Arrange
            var date = new DateTime(2018, 10, 10);
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.DateTime);
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => date;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_CleanValuesText_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Text);
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => DummyText;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeNumber_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Number, editable: true);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><value Percentage=\"TRUE\">1</value></root>";
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => One;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeUserFieldUserValue_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.User, editable: true);
            ShimSPField.AllInstances.GetFieldValueString = (_, __) => new ShimSPFieldUserValue().Instance;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"&lt;a href=&quot;/_layouts/userdisp.aspx?ID=1&quot;&gt;DummyText&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeUserFieldUserValueCollection_SetsNewItemRow()
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
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"&lt;a href=&quot;/_layouts/userdisp.aspx?ID=1&quot;&gt;DummyText&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeCalculated_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Calculated, editable: true);
            ShimSPField.AllInstances.DescriptionGet = _ => "Indicator";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeCurrency_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Currency, editable: true);

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeAttachmentsEmpty_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Attachments, editable: true);
            ShimSPListItem.AllInstances.AttachmentsGet = _ => new ShimSPAttachmentCollection();
            ShimSPAttachmentCollection.AllInstances.CountGet = _ => 0;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeAttachmentsNotEmpty_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Attachments, editable: true);
            ShimSPListItem.AllInstances.AttachmentsGet = _ => new ShimSPAttachmentCollection();
            ShimSPAttachmentCollection.AllInstances.CountGet = _ => 1;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeText_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Text, editable: true);
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => $"{DummyText}.{DummyVal}";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeBooleanTrue_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Boolean, editable: true);
            ShimSPWeb.AllInstances.TitleGet = _ => "true";
            ShimSPList.AllInstances.TitleGet = _ => "Project Center";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"No\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"No\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeBooleanFalse_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Boolean, editable: true);
            ShimSPWeb.AllInstances.TitleGet = _ => "false";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"No\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"No\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeDateTime_SetsNewItemRow()
        {
            // Arrange
            var date = new DateTime(2018, 10, 10);
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.DateTime, editable: true);
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => date.ToString();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeInteger_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Integer, editable: true);
            ShimSPField.AllInstances.TypeAsStringGet = _ => "Integer";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_NotInEditModeAttachmentsEmpty_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Attachments, editable: false);
            ShimSPListItem.AllInstances.AttachmentsGet = _ => new ShimSPAttachmentCollection();
            ShimSPAttachmentCollection.AllInstances.CountGet = _ => 0;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_NotInEditModeAttachmentsNotEmpty_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Attachments, editable: false);
            ShimSPListItem.AllInstances.AttachmentsGet = _ => new ShimSPAttachmentCollection();
            ShimSPAttachmentCollection.AllInstances.CountGet = _ => 1;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_NotInEditModeUser_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.User, editable: false);
            ShimSPField.AllInstances.GetFieldValueString = (_, __) => new ShimSPFieldUserValue().Instance;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"&lt;a href=&quot;/_layouts/userdisp.aspx?ID=1&quot;&gt;DummyText&lt;/a&gt;\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_NotInEditModeCalculated_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Calculated, editable: false);
            ShimSPField.AllInstances.DescriptionGet = _ => "Indicator";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_NotInEditModeMultiChoice_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.MultiChoice, editable: false);
            ShimSPWeb.AllInstances.TitleGet = _ => "1,2";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_NotInEditModeChoice_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Choice, editable: false);
            ShimSPWeb.AllInstances.TitleGet = _ => "1,2";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        [TestMethod]
        public void AddItemDataRow_NotInEditModeLookup_SetsNewItemRow()
        {
            // Arrange
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Lookup, editable: false);
            ShimSPWeb.AllInstances.TitleGet = _ => "1,2";

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddItem, new object[] { GetRow("ItemID"), _xmlDocument });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldBe("<Cell Value=\"DummyVal\" ValueFormat=\"1\" /><Bars><Bar Name=\"TaskP\" Start=\"1/1/2019 12:00:00 AM\" End=\"1/2/2019 12:00:00 AM\" Caption=\"DummyVal\" Percent=\"1\" HAlignCaption=\"18\" /></Bars>"));
        }

        private DataRow GetRow(string internalname, string itemID = DummyVal)
        {
            var dt = new DataTable();
            var newRow = dt.NewRow();
            var newColumn = new DataColumn("CustomerID");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("SiteUrl");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("ItemID");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("Work");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("TestColumn");
            dt.Columns.Add(newColumn);

            newColumn = new DataColumn("WebID");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("ListID");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("List");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("ID");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("siteid");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("ParentItem");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("Created");
            dt.Columns.Add(newColumn);

            newColumn = new DataColumn("CommentCount");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("TSDisableItem");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("Commenters");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("Author");
            dt.Columns.Add(newColumn);
            if (!dt.Columns.Contains(internalname))
            {
                newColumn = new DataColumn(internalname);
                dt.Columns.Add(newColumn);
            }
            newColumn = new DataColumn("CommentersRead");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn(internalname + "ID");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn(internalname + "Text");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("start");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("finish");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("wbsfield");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("information");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("milestone");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("progress");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("Critical");
            dt.Columns.Add(newColumn);
            if (internalname != "WorkspaceUrl")
            {
                newColumn = new DataColumn("WorkspaceUrl");
                dt.Columns.Add(newColumn);
            }
            if (internalname != "Title")
            {
                newColumn = new DataColumn("Title");
                dt.Columns.Add(newColumn);
            }
            newRow["SiteUrl"] = string.Empty;
            newRow["ItemID"] = itemID;
            newRow["Created"] = DateTime.Now;
            newRow[internalname + "ID"] = "13,14,15,16,17";
            newRow[internalname + "Text"] = "A,B,C,D,E";
            newRow["Title"] = DummyVal;
            newRow["Work"] = string.Empty;
            if (internalname != "WorkspaceUrl")
                newRow["WorkspaceUrl"] = TestUrl;
            newRow["WebID"] = DefaultWebId;
            newRow["ListID"] = DefaultListId;
            newRow["ID"] = 1;
            newRow["siteid"] = string.Empty;
            newRow["ParentItem"] = string.Empty;
            if (newRow[internalname] == null)
            {
                newRow[internalname] = DummyVal;
            }
            newRow["CommentCount"] = "20";
            newRow["TSDisableItem"] = string.Empty;
            newRow["Commenters"] = string.Empty;
            newRow["Author"] = string.Empty;
            newRow["CommentersRead"] = string.Empty;
            newRow["List"] = "ICON";
            newRow["TestColumn"] = $"{DummyText}.{DummyText}";
            newRow["start"] = new DateTime(2019, 1, 1).ToString();
            newRow["finish"] = new DateTime(2019, 1, 1).ToString();
            newRow["wbsfield"] = _wbs;
            newRow["information"] = DummyVal;
            newRow["milestone"] = _isMilestone;
            newRow["progress"] = One;
            newRow["Critical"] = bool.TrueString;

            return newRow;
        }
    }
}
