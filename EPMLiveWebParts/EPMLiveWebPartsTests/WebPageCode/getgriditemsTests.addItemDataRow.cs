using System;
using System.Collections;
using System.Collections.Fakes;
using System.Collections.Generic;
using System.Collections.Generic.Fakes;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices.ActiveDirectory.Fakes;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Fakes;
using System.Web.SessionState.Fakes;
using System.Web.UI.Fakes;
using System.Xml;
using System.Xml.Fakes;
using EPMLiveCore;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Infrastructure.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveWebParts;
using EPMLiveWebParts.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Workflow.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests
{
    public partial class getgriditemsTests
    {
        private const string DefaultListId = "F316E11-C842-4440-9918-39A8F1C12DA9";
        private const string DefaultWebId = "1A8F7946-CCA1-4A24-8785-CE8E32D012BE";
        private const string DefaultId = "5D592B57-C072-4B36-8809-11262120484D";
        private const string MultiTitle = "1,2";
        private static readonly string DefaultIndexer = $"{DefaultWebId}.{DefaultListId}.{DefaultId}";

        [TestMethod]
        public void AddItemDataRow_EditNotInEditMode_SetsNewItemRow()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("Edit", "DocIcon");

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("DocIcon") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.Attributes["locked"].ShouldNotBeNull(),
                () => _newItemNode.Attributes["locked"].Value.ShouldContainWithoutWhitespace("1"),
                () => _newItemNode.Attributes["id"].ShouldNotBeNull(),
                () => _newItemNode.Attributes["id"].Value.ShouldBe(DefaultIndexer, StringCompareShould.IgnoreCase),
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[#roweditid#]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_DocIcon_SetsNewItemRow()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("Title", "DocIcon");

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("DocIcon") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[<img src=\"{ExampleUrl}/_layouts/images/test.png\">]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_WorkspaceUrl_SetsNewItemRow()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("Title", "WorkspaceUrl");

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("WorkspaceUrl") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[<a href=\"\"><img src=\"{ExampleUrl}/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_ContentType_SetsNewItemRow()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("Title", "ContentType");

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ContentType") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_ContentTypeNoListItemId_SetsNewItemRow()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("Title", "ContentType");
            ShimSPListItem.AllInstances.IDGet = _ => 0;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ContentType") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_FileLeafRefView_SetsNewItemRow()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("Title", "FileLeafRef", "view");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("FileLeafRef") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_FileLeafRefEdit_SetsNewItemRow()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("Title", "FileLeafRef", "edit");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("FileLeafRef") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_FileLeafRefEditLinkFilenameNoMenu_SetsNewItemRow()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("LinkFilenameNoMenu", "FileLeafRef", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("FileLeafRef") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_FileLeafRefEditLinkFilename_SetsNewItemRow()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("LinkFilename", "FileLeafRef", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("FileLeafRef") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleCleanValues_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = true;
            _inEditmode = false;
            var indexer = PrepareForAddItem("Title", "Title", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("Title") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[First Project]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleViewNotEditMode_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            _usepopup = true;
            var indexer = PrepareForAddItem("Title", "Title", "view");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("Title") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[<a href=\"\" onclick=\"javascript:viewItem(this,'view');return false;\">First Project</a> <img src=\"/_layouts/1/images/new.gif\"> &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\"><img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>&nbsp;<a href=\"http://testURL\"><img src=\"{ExampleUrl}/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleViewEditMode_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            _usepopup = true;
            var indexer = PrepareForAddItem("Title", "Title", "view");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("Title") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[First Project]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleEditNotEditMode_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            _usepopup = true;
            var indexer = PrepareForAddItem("Title", "Title", "edit");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("Title") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<a href=\"\" onclick=\"javascript:viewItem(this,'edit');return false;\">"),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("</a> <img src=\"/_layouts/1/images/new.gif\"> &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\">"),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>&nbsp;<a href=\"http://testURL\">"),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<img src=\"http://example.com/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleEditEditMode_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            _usepopup = true;
            var indexer = PrepareForAddItem("Title", "Title", "edit");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("Title") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[First Project]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleLinkTitleNoMenuNotEditMode_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            _usepopup = true;
            var indexer = PrepareForAddItem("LinkTitleNoMenu", "Title", null);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("Title") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[First Project &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\"><img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>&nbsp;<a href=\"http://testURL\"><img src=\"http://example.com/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleLinkTitleNoMenuEditMode_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            _usepopup = true;
            var indexer = PrepareForAddItem("LinkTitleNoMenu", "Title", null);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("Title") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[First Project]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleLinkTitleNotEditMode_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            _usepopup = true;
            var indexer = PrepareForAddItem("LinkTitle", "Title", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("Title") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<a href=\"\" onclick=\"javascript:viewItem(this,'edit');return false;\">First Project</a> <img src=\"/_layouts/1/images/new.gif\"> &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\"><img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>&nbsp;<a href=\"http://testURL\"><img src=\"http://example.com/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleLinkTitleEditMode_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            _usepopup = true;
            _timesheet = true;
            var indexer = PrepareForAddItem("LinkTitle", "Title", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("Title") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[First Project]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleWorkspace_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            var indexer = PrepareForAddItem("Title", "Title", "workspace");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("Title") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[<a href=\"/_layouts/epmlive/gridaction.aspx?action=workspace&webid={DefaultWebId}\">First Project</a> <img src=\"/_layouts/1/images/new.gif\"> &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\">"),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>&nbsp;<a href=\"http://testURL\">"),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<img src=\"http://example.com/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleWorkplan_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            var indexer = PrepareForAddItem("Title", "Title", "workplan");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("Title") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[<a href=\"/_layouts/epmlive/gridaction.aspx?action=workplan&webid={DefaultWebId}&listid={DefaultListId}&ID={DefaultId}\">First Project</a> <img src=\"/_layouts/1/images/new.gif\"> &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\"><img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>&nbsp;<a href=\"http://testURL\"><img src=\"{ExampleUrl}/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitlePlanner_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            var indexer = PrepareForAddItem("Title", "Title", "planner");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("Title") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[<a href=\"/_layouts/epmlive/gridaction.aspx?action=planner&webid={DefaultWebId}&listid={DefaultListId}&ID={DefaultId}\">First Project</a> <img src=\"/_layouts/1/images/new.gif\"> &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\"><img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>&nbsp;<a href=\"http://testURL\"><img src=\"http://example.com/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_TitleTasks_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            var indexer = PrepareForAddItem("Title", "Title", "tasks");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("Title") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[<a href=\"/_layouts/epmlive/gridaction.aspx?action=tasks&webid={DefaultWebId}&listid={DefaultListId}&ID={DefaultId}&Source={DummyVal}&FilterField1=Project&FilterValue1=First+Project\">First Project</a> <img src=\"/_layouts/1/images/new.gif\"> &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\"><img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>&nbsp;<a href=\"http://testURL\"><img src=\"http://example.com/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_CleanValuesCalculatedIndicator_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Calculated);
            ShimSPField.AllInstances.DescriptionGet = _ => "Indicator";
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPFieldCalculated().Instance;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<img src=\"/_layouts/images/2\">]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_CleanValuesCalculatedNonIndicator_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Calculated);
            ShimSPField.AllInstances.DescriptionGet = _ => DummyVal;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPFieldCalculated().Instance;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[2]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_CleanValuesUserFieldUserValue_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.User);
            ShimSPField.AllInstances.GetFieldValueString = (_, __) => new ShimSPFieldUserValue().Instance;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[<a href=\"{ExampleUrl}/_layouts/userdisp.aspx?ID=1\">{DummyText}</a>]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_CleanValuesUserFieldUserValueCollection_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.User);

            var shimFields = new ShimSPFieldUserValueCollection();
            var list = new List<SPFieldUserValue> { new ShimSPFieldUserValue() };
            shimFields.Bind(list as IList<SPFieldUserValue>);
            var enumerator = list.GetEnumerator();
            ShimList<SPFieldUserValue>.AllInstances.GetEnumerator = _ => enumerator;

            ShimSPField.AllInstances.GetFieldValueString = (_, __) => shimFields.Instance;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[<a href=\"http://example.com/_layouts/userdisp.aspx?ID=1\">{DummyText}</a>]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_CleanValuesMultiChoice_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.MultiChoice);
            ShimSPField.AllInstances.DescriptionGet = _ => DummyVal;
            ShimSPFieldMultiChoiceValue.ConstructorString = (instance, _) => { };
            ShimSPFieldMultiChoiceValue.AllInstances.CountGet = _ => 1;
            ShimSPFieldMultiChoiceValue.AllInstances.ItemGetInt32 = (_, __) => DummyVal;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[2]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_CleanValuesLookup_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Lookup);
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPFieldLookup { LookupListGet = () => Guid.NewGuid().ToString() }.Instance;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[13;#;#14;#;#15;#;#16;#;#17;#]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_CleanValuesDateTime_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.DateTime);
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => DateTime.Today;
            Shimgetgriditems.AllInstances.getFieldSPListItemStringBoolean =
                (a, b, c, d) => DateTime.Today.ToString();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID", DateTime.Today.ToString()) });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[{DateTime.Today.ToString("yyyy-MM-dd")} 00:00:00Z]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_CleanValuesText_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Text);
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => DummyText;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[2]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeNumber_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Number, editable: true);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><value Percentage=\"TRUE\">1</value></root>";
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPFieldNumber { ShowAsPercentageGet = () => true }.Instance;
            Shimgetgriditems.AllInstances.getFieldSPListItemStringBoolean =
                (a, b, c, d) => "1";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell type=\"edn\"><![CDATA[2]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeUserFieldUserValue_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.User, editable: true);
            ShimSPField.AllInstances.GetFieldValueString = (_, __) => new ShimSPFieldUserValue().Instance;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell type=\"usereditor\"><![CDATA[{DummyText}\n{DummyText}\t]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeUserFieldUserValueCollection_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.User, editable: true);

            var shimFields = new ShimSPFieldUserValueCollection();
            var list = new List<SPFieldUserValue> { new ShimSPFieldUserValue() };
            shimFields.Bind(list as IList<SPFieldUserValue>);
            var enumerator = list.GetEnumerator();
            ShimList<SPFieldUserValue>.AllInstances.GetEnumerator = _ => enumerator;

            ShimSPField.AllInstances.GetFieldValueString = (_, __) => shimFields.Instance;
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><value Type=\"UserMulti\">1</value></root>";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell type=\"usereditor\"><![CDATA[{DummyText}\n{DummyText}\t]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeMultiChoice_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.MultiChoice, editable: true);
            _privateObj.SetField("hshComboCells", new Hashtable());
            ShimSPWeb.AllInstances.TitleGet = _ => "1;#2";
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><CHOICE>1</CHOICE></root>";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell type=\"mchoice\"><![CDATA[2;#2\t1;#1]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeChoice_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Choice, editable: true);
            _privateObj.SetField("hshComboCells", new Hashtable());
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><CHOICE>1</CHOICE></root>";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell type=\"choice\">2;#2\t1;#1</cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeLookupMulti_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "LookupMulti", fieldType: SPFieldType.Lookup, editable: true);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root List='1' ShowField='1'></root>";
            ShimSPField.AllInstances.TypeAsStringGet = _ => "LookupMulti";
            _privateObj.SetField("hshComboCells", new Hashtable());

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("LookupMulti") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell type=\"mchoice\"><![CDATA[\n]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeLookup_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Lookup, editable: true);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root List='1' ShowField='1'></root>";
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPFieldLookup { LookupListGet = () => Guid.NewGuid().ToString() }.Instance;
            _privateObj.SetField("hshComboCells", new Hashtable());

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[{DummyVal}]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeCalculated_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Calculated, editable: true);
            ShimSPField.AllInstances.DescriptionGet = _ => "Indicator";
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPFieldCalculated().Instance;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<img src=\"/_layouts/images/2\">]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeCurrency_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Currency, editable: true);

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell type=\"edn\"><![CDATA[2]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeAttachmentsEmpty_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Attachments, editable: true);
            ShimSPListItem.AllInstances.AttachmentsGet = _ => new ShimSPAttachmentCollection();
            ShimSPAttachmentCollection.AllInstances.CountGet = _ => 0;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeAttachmentsNotEmpty_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Attachments, editable: true);
            ShimSPListItem.AllInstances.AttachmentsGet = _ => new ShimSPAttachmentCollection();
            ShimSPAttachmentCollection.AllInstances.CountGet = _ => 1;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeText_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Text, editable: true);
            Shimgetgriditems.AllInstances.getFieldSPListItemStringBoolean =
                (a, b, c, d) => $"{DummyText}.{DummyVal}";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell type=\"ed\"><![CDATA[2]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeBooleanTrue_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            _isTimesheet = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Boolean, editable: true);
            ShimSPWeb.AllInstances.TitleGet = _ => "true";
            ShimSPList.AllInstances.TitleGet = _ => "Project Center";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell type=\"ch\"><![CDATA[0]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeBooleanFalse_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            _isTimesheet = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Boolean, editable: true);
            ShimSPWeb.AllInstances.TitleGet = _ => "false";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell type=\"ch\"><![CDATA[0]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeDateTime_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.DateTime, editable: true);
            Shimgetgriditems.AllInstances.getFieldSPListItemStringBoolean =
                (a, b, c, d) => DateTime.Today.ToString();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID", DateTime.Today.ToString()) });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell type=\"dhxCalendarA\"><![CDATA[{DateTime.Today.ToString("MM/dd/yyyy")} 12:00:00 AM]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_InEditModeInteger_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Integer, editable: true);
            ShimSPField.AllInstances.TypeAsStringGet = _ => "Integer";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[2]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_NotInEditModeAttachmentsEmpty_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Attachments, editable: false);
            ShimSPListItem.AllInstances.AttachmentsGet = _ => new ShimSPAttachmentCollection();
            ShimSPAttachmentCollection.AllInstances.CountGet = _ => 0;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_NotInEditModeAttachmentsNotEmpty_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Attachments, editable: false);
            ShimSPListItem.AllInstances.AttachmentsGet = _ => new ShimSPAttachmentCollection();
            ShimSPAttachmentCollection.AllInstances.CountGet = _ => 1;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_NotInEditModeUser_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.User, editable: false);
            ShimSPField.AllInstances.GetFieldValueString = (_, __) => new ShimSPFieldUserValue().Instance;
            _privateObj.SetField("hshWBS", new Hashtable());

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[<a href=\"/_layouts/userdisp.aspx?ID=1\">{DummyText}</a>]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_NotInEditModeCalculated_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Calculated, editable: false);
            ShimSPField.AllInstances.DescriptionGet = _ => "Indicator";
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPFieldCalculated().Instance;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<img src=\"/_layouts/images/2\">]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_NotInEditModeMultiChoice_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.MultiChoice, editable: false);
            ShimSPWeb.AllInstances.TitleGet = _ => MultiTitle;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[{DummyVal}]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_NotInEditModeChoice_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Choice, editable: false);
            ShimSPWeb.AllInstances.TitleGet = _ => MultiTitle;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[2]]></cell>"));
        }

        [TestMethod]
        public void AddItemDataRow_NotInEditModeLookup_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Lookup, editable: false);
            ShimSPWeb.AllInstances.TitleGet = _ => MultiTitle;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPFieldLookup { LookupListGet = () => Guid.NewGuid().ToString() }.Instance;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell type=\"choice\">1;#{DummyVal}\t{DummyVal}</cell>"));
        }

        private DataRow GetRow(string internalname, string itemID = "2")
        {
            ResetFields(DefaultListId, DefaultWebId, DefaultId);

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
            newColumn = new DataColumn("AssignedTo");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("CommentersRead");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn(internalname + "ID");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn(internalname + "Text");
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
            newRow["Title"] = "First Project";
            newRow["Work"] = string.Empty;
            if (internalname != "WorkspaceUrl")
                newRow["WorkspaceUrl"] = "http://testURL";
            newRow["WebID"] = DefaultWebId;
            newRow["ListID"] = DefaultListId;
            newRow["ID"] = DefaultId;
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
            newRow["AssignedTo"] = "2";
            newRow["CommentersRead"] = string.Empty;
            newRow["List"] = "ICON";
            newRow["TestColumn"] = $"{DummyText}.{DummyText}";

            return newRow;
        }

        private void ResetFields()
        {
            var arrItems = new SortedList();
            arrItems.Add(DefaultIndexer, new string[] { "Admin" });
            _privateObj.SetField("arrItems", arrItems);
            _privateObj.SetField("usewbs", "TestColumn");
        }
    }
}
