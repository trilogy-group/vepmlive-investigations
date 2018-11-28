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
using Moq;
using Shouldly;

namespace EPMLiveWebParts.Tests
{
    public partial class getgriditemsTests
    {
        private const string ExampleUrl = "http://example.com";
        private const string TypeTextXml = "text/xml";
        private const string TypeTextPlain = "text/plain";
        private const string TitleField = "Title";
        private const string AddItemMethod = "addItem";
        private bool _inEditmode;
        private bool _timesheet;
        private bool _showCheckboxes;
        private bool _isTimesheet;
        private bool _titleFieldFound;
        private bool _usepopup;
        private bool _cleanValues;
        private bool _workspaceUrl;
        private XmlDocument _xmlDocument;
        private XmlNode _newItemNode;

        [TestMethod]
        public void AddItem_EditNotInEditMode_SetsNewItemRow()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("Edit", "DocIcon");

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.Attributes["locked"].ShouldNotBeNull(),
                () => _newItemNode.Attributes["locked"].Value.ShouldContainWithoutWhitespace("1"),
                () => _newItemNode.Attributes["id"].ShouldNotBeNull(),
                () => _newItemNode.Attributes["id"].Value.ShouldContainWithoutWhitespace(indexer),
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[#roweditid#]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DocIcon_SetsNewItemRow()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("Title", "DocIcon");

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItem_WorkspaceUrl_SetsNewItemRow()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("Title", "WorkspaceUrl");

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[<a href=\"{DummyVal}\"><img src=\"{ExampleUrl}/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_ContentType_SetsNewItemRow()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("Title", "ContentType");

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[{TypeTextXml};#{TypeTextXml}\t{DummyVal}]]></cell>"));
        }

        [TestMethod]
        public void AddItem_ContentTypeNoListItemId_SetsNewItemRow()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("Title", "ContentType");
            ShimSPListItem.AllInstances.IDGet = _ => 0;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[{TypeTextPlain};#{TypeTextPlain}\t{DummyVal}]]></cell>"));
        }

        [TestMethod]
        public void AddItem_FileLeafRefView_SetsNewItemRow()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("Title", "FileLeafRef", "view");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<A onfocus=\"OnLink(this)\" HREF=\"http://example.com\" onclick=\"return DispEx(this,event,'TRUE','FALSE','TRUE','SharePoint.OpenDocuments.3','0','SharePoint.OpenDocuments','','','','1','0','0','ows_PermMask')\">ows_BaseName</A>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_FileLeafRefEdit_SetsNewItemRow()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("Title", "FileLeafRef", "edit");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<A onfocus=\"OnLink(this)\" HREF=\"http://example.com\" onclick=\"return DispEx(this,event,'TRUE','FALSE','FALSE','SharePoint.OpenDocuments.3','0','SharePoint.OpenDocuments','','','','1','0','0','ows_PermMask')\">ows_BaseName<img src=\"/_layouts/images/blank.gif\" class=\"ms-hidden\" border=1 width=1 height=26 alt=\"Use SHIFT+ENTER to open the menu (new window).\"></A><img src=\"/_layouts/images/blank.gif\" width=13 style=\"visibility:hidden\" alt=\"\">]]></cell>"));
        }

        [TestMethod]
        public void AddItem_FileLeafRefEditLinkFilenameNoMenu_SetsNewItemRow()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("LinkFilenameNoMenu", "FileLeafRef", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<A onfocus=\"OnLink(this)\" HREF=\"http://example.com\" onclick=\"return DispEx(this,event,'TRUE','FALSE','TRUE','SharePoint.OpenDocuments.3','0','SharePoint.OpenDocuments','','','','1','0','0','ows_PermMask')\">ows_BaseName</A>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_FileLeafRefEditLinkFilename_SetsNewItemRow()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("LinkFilename", "FileLeafRef", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<A onfocus=\"OnLink(this)\" HREF=\"http://example.com\" onclick=\"return DispEx(this,event,'TRUE','FALSE','FALSE','SharePoint.OpenDocuments.3','0','SharePoint.OpenDocuments','','','','1','0','0','ows_PermMask')\">ows_BaseName<img src=\"/_layouts/images/blank.gif\" class=\"ms-hidden\" border=1 width=1 height=26 alt=\"Use SHIFT+ENTER to open the menu (new window).\"></A><img src=\"/_layouts/images/blank.gif\" width=13 style=\"visibility:hidden\" alt=\"\">]]></cell>"));
        }

        [TestMethod]
        public void AddItem_TitleCleanValues_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = true;
            _inEditmode = false;
            var indexer = PrepareForAddItem("Title", "Title", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[{DummyFieldName}]]></cell>"));
        }

        [TestMethod]
        public void AddItem_TitleViewNotEditMode_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            _usepopup = true;
            var indexer = PrepareForAddItem("Title", "Title", "view");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<a href=\"\" onclick=\"javascript:viewItem(this,'view');return false;\"></a> <img src=\"/_layouts/1/images/new.gif\"> &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\"><img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>&nbsp;<a href=\"DummyVal\"><img src=\"http://example.com/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_TitleViewEditMode_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            _usepopup = true;
            var indexer = PrepareForAddItem("Title", "Title", "view");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItem_TitleEditNotEditMode_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            _usepopup = true;
            var indexer = PrepareForAddItem("Title", "Title", "edit");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<a href=\"\" onclick=\"javascript:viewItem(this,'edit');return false;\">"),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("</a> <img src=\"/_layouts/1/images/new.gif\"> &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\">"),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>&nbsp;<a href=\"DummyVal\">"),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<img src=\"http://example.com/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_TitleEditEditMode_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            _usepopup = true;
            var indexer = PrepareForAddItem("Title", "Title", "edit");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItem_TitleLinkTitleNoMenuNotEditMode_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            _usepopup = true;
            var indexer = PrepareForAddItem("LinkTitleNoMenu", "Title", null);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<a href=\"\" onclick=\"javascript:viewItem(this,'view');return false;\">"),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("</a> <img src=\"/_layouts/1/images/new.gif\"> &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\">"),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>&nbsp;<a href=\"DummyVal\">"),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<img src=\"http://example.com/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_TitleLinkTitleNoMenuEditMode_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            _usepopup = true;
            var indexer = PrepareForAddItem("LinkTitleNoMenu", "Title", null);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItem_TitleLinkTitleNotEditMode_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            _usepopup = true;
            var indexer = PrepareForAddItem("LinkTitle", "Title", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<a href=\"\" onclick=\"javascript:viewItem(this,'edit');return false;\"></a> <img src=\"/_layouts/1/images/new.gif\"> &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\"><img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>&nbsp;<a href=\"DummyVal\"><img src=\"http://example.com/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_TitleLinkTitleEditMode_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            _usepopup = true;
            _timesheet = true;
            var indexer = PrepareForAddItem("LinkTitle", "Title", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItem_TitleWorkspace_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            var indexer = PrepareForAddItem("Title", "Title", "workspace");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<a href=\"http://example.com/\"></a> <img src=\"/_layouts/1/images/new.gif\"> &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\">"),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>&nbsp;<a href=\"DummyVal\">"),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<img src=\"http://example.com/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_TitleWorkplan_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            var indexer = PrepareForAddItem("Title", "Title", "workplan");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<a href=\"http://example.com/_layouts/epmlive/tasks.aspx?ID=1\"></a> <img src=\"/_layouts/1/images/new.gif\"> &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\">"));
        }

        [TestMethod]
        public void AddItem_TitlePlanner_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            var indexer = PrepareForAddItem("Title", "Title", "planner");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<a href=\"http://example.com/_layouts/epmlive/workplanner.aspx?ID=1&Source=DummyVal\"></a> <img src=\"/_layouts/1/images/new.gif\"> &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\"><img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>&nbsp;<a href=\"DummyVal\"><img src=\"http://example.com/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_TitleTasks_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            var indexer = PrepareForAddItem("Title", "Title", "tasks");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<a href=\"http://example.com/http://example.com?FilterField1=Project&FilterValue1=\"></a> <img src=\"/_layouts/1/images/new.gif\"> &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\"><img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>&nbsp;<a href=\"DummyVal\"><img src=\"http://example.com/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_CleanValuesCalculatedIndicator_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Calculated);
            ShimSPField.AllInstances.DescriptionGet = _ => "Indicator";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<img src=\"/_layouts/images/dummyfieldname\">]]></cell>"));
        }

        [TestMethod]
        public void AddItem_CleanValuesCalculatedNonIndicator_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Calculated);
            ShimSPField.AllInstances.DescriptionGet = _ => DummyVal;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[{DummyFieldName}]]></cell>"));
        }

        [TestMethod]
        public void AddItem_CleanValuesUserFieldUserValue_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.User);
            ShimSPField.AllInstances.GetFieldValueString = (_, __) => new ShimSPFieldUserValue().Instance;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[<a Title=\"{DummyText}\"href=\"http://example.com/_layouts/userdisp.aspx?ID=1\">{DummyText}</a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_CleanValuesUserFieldUserValueCollection_SetsNewItemRow()
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
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[<a Title=\"{DummyText}\"href=\"http://example.com/_layouts/userdisp.aspx?ID=1\">{DummyText}</a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_CleanValuesMultiChoice_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.MultiChoice);
            ShimSPField.AllInstances.DescriptionGet = _ => DummyVal;
            ShimSPFieldMultiChoiceValue.ConstructorString = (instance, _) => { };
            ShimSPFieldMultiChoiceValue.AllInstances.CountGet = _ => 1;
            ShimSPFieldMultiChoiceValue.AllInstances.ItemGetInt32 = (_, __) => DummyVal;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[{DummyVal}]]></cell>"));
        }

        [TestMethod]
        public void AddItem_CleanValuesLookup_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Lookup);

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[{DummyVal}]]></cell>"));
        }

        [TestMethod]
        public void AddItem_CleanValuesDateTime_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.DateTime);
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => DateTime.Today;
            Shimgetgriditems.AllInstances.getFieldSPListItemStringBoolean =
                (a, b, c, d) => DateTime.Today.ToString();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[{DateTime.Today.ToString("MM/dd/yyyy")} 12:00:00 AM]]></cell>"));
        }

        [TestMethod]
        public void AddItem_CleanValuesText_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Text);
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => DummyText;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[{DummyFieldName}]]></cell>"));
        }

        [TestMethod]
        public void AddItem_InEditModeNumber_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Number, editable: true);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><value Percentage=\"TRUE\">1</value></root>";
            Shimgetgriditems.AllInstances.getFieldSPListItemStringBoolean =
                (a, b, c, d) => "1";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell type=\"edn\"><![CDATA[100]]></cell>"));
        }

        [TestMethod]
        public void AddItem_InEditModeUserFieldUserValue_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.User, editable: true);
            ShimSPField.AllInstances.GetFieldValueString = (_, __) => new ShimSPFieldUserValue().Instance;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell type=\"usereditor\"><![CDATA[{DummyText}\n{DummyText}\t]]></cell>"));
        }

        [TestMethod]
        public void AddItem_InEditModeUserFieldUserValueCollection_SetsNewItemRow()
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
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell type=\"usereditorm\"><![CDATA[{DummyText}\n{DummyText}\t]]></cell>"));
        }

        [TestMethod]
        public void AddItem_InEditModeMultiChoice_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.MultiChoice, editable: true);
            _privateObj.SetField("hshComboCells", new Hashtable());
            ShimSPWeb.AllInstances.TitleGet = _ => "1;#2";
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><CHOICE>1</CHOICE></root>";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell type=\"mchoice\"><![CDATA[{DummyFieldName};#{DummyFieldName}\t1;#1]]></cell>"));
        }

        [TestMethod]
        public void AddItem_InEditModeChoice_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Choice, editable: true);
            _privateObj.SetField("hshComboCells", new Hashtable());
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root><CHOICE>1</CHOICE></root>";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell type=\"choice\"><![CDATA[{DummyFieldName};#{DummyFieldName}	1;#1]]></cell>"));
        }

        [TestMethod]
        public void AddItem_InEditModeLookupMulti_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "LookupMulti", fieldType: SPFieldType.Lookup, editable: true);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root List='1' ShowField='1'></root>";
            ShimSPField.AllInstances.TypeAsStringGet = _ => "LookupMulti";
            _privateObj.SetField("hshComboCells", new Hashtable());

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell type=\"mchoice\"><![CDATA[\n]]></cell>"));
        }

        [TestMethod]
        public void AddItem_InEditModeLookup_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Lookup, editable: true);
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root List='1' ShowField='1'></root>";
            _privateObj.SetField("hshComboCells", new Hashtable());

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell type=\"ro\"><![CDATA[1;#{DummyVal}\t]]></cell>"));
        }

        [TestMethod]
        public void AddItem_InEditModeCalculated_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Calculated, editable: true);
            ShimSPField.AllInstances.DescriptionGet = _ => "Indicator";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<img src=\"/_layouts/images/dummyfieldname\">]]></cell"));
        }

        [TestMethod]
        public void AddItem_InEditModeCurrency_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Currency, editable: true);

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell type=\"edn\"><![CDATA[{DummyFieldName}]]></cell>"));
        }

        [TestMethod]
        public void AddItem_InEditModeAttachmentsEmpty_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Attachments, editable: true);
            ShimSPListItem.AllInstances.AttachmentsGet = _ => new ShimSPAttachmentCollection();
            ShimSPAttachmentCollection.AllInstances.CountGet = _ => 0;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItem_InEditModeAttachmentsNotEmpty_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Attachments, editable: true);
            ShimSPListItem.AllInstances.AttachmentsGet = _ => new ShimSPAttachmentCollection();
            ShimSPAttachmentCollection.AllInstances.CountGet = _ => 1;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[<a href=\"{ExampleUrl}\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_InEditModeText_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Text, editable: true);
            Shimgetgriditems.AllInstances.getFieldSPListItemStringBoolean =
                (a, b, c, d) => $"{DummyText}.{DummyVal}";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell type=\"ed\"><![CDATA[]]></cell>"));
        }
        
        [TestMethod]
        public void AddItem_InEditModeBooleanTrue_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            _isTimesheet = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Boolean, editable: true);
            ShimSPWeb.AllInstances.TitleGet = _ => "true";
            ShimSPList.AllInstances.TitleGet = _ => "Project Center";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell type=\"ch\"><![CDATA[0]]></cell>"));
        }

        [TestMethod]
        public void AddItem_InEditModeBooleanFalse_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            _isTimesheet = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Boolean, editable: true);
            ShimSPWeb.AllInstances.TitleGet = _ => "false";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell type=\"ch\"><![CDATA[0]]></cell>"));
        }

        [TestMethod]
        public void AddItem_InEditModeDateTime_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.DateTime, editable: true);
            Shimgetgriditems.AllInstances.getFieldSPListItemStringBoolean =
                (a, b, c, d) => DateTime.Today.ToString();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell type=\"dhxCalendarA\"><![CDATA[{DateTime.Today.ToString("MM/dd/yyyy")} 12:00:00 AM]]></cell>"));
        }

        [TestMethod]
        public void AddItem_InEditModeInteger_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Integer, editable: true);
            ShimSPField.AllInstances.TypeAsStringGet = _ => "Integer";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItem_NotInEditModeAttachmentsEmpty_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Attachments, editable: false);
            ShimSPListItem.AllInstances.AttachmentsGet = _ => new ShimSPAttachmentCollection();
            ShimSPAttachmentCollection.AllInstances.CountGet = _ => 0;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItem_NotInEditModeAttachmentsNotEmpty_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Attachments, editable: false);
            ShimSPListItem.AllInstances.AttachmentsGet = _ => new ShimSPAttachmentCollection();
            ShimSPAttachmentCollection.AllInstances.CountGet = _ => 1;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[<a href=\"{ExampleUrl}\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_NotInEditModeUser_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.User, editable: false);
            ShimSPField.AllInstances.GetFieldValueString = (_, __) => new ShimSPFieldUserValue().Instance;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[<a Title=\"{DummyText}\"href=\"http://example.com/_layouts/userdisp.aspx?ID=1\">{DummyText}</a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_NotInEditModeCalculated_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Calculated, editable: false);
            ShimSPField.AllInstances.DescriptionGet = _ => "Indicator";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<img src=\"/_layouts/images/dummyfieldname\">]]></cell>"));
        }

        [TestMethod]
        public void AddItem_NotInEditModeMultiChoice_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.MultiChoice, editable: false);
            ShimSPWeb.AllInstances.TitleGet = _ => "1,2";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<![CDATA[<input type=\"checkbox\" style=\"display:none;\" onClick=\"(arguments[0]||event).cancelBubble=true;CheckBoxSelectRow(this);\">]]></cell>"));
        }

        [TestMethod]
        public void AddItem_NotInEditModeChoice_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Choice, editable: false);
            ShimSPWeb.AllInstances.TitleGet = _ => "1,2";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<![CDATA[<input type=\"checkbox\" style=\"display:none;\" onClick=\"(arguments[0]||event).cancelBubble=true;CheckBoxSelectRow(this);\">]]></cell>"));
        }

        [TestMethod]
        public void AddItem_NotInEditModeLookup_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Lookup, editable: false);
            ShimSPWeb.AllInstances.TitleGet = _ => "1,2";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell type=\"ro\"><![CDATA[{DummyFieldName}]]></cell>"));
        }

        private string PrepareForAddItem(string fieldName, string internalname, string linkType = "", SPFieldType fieldType = SPFieldType.Text, bool editable = true)
        {
            _xmlDocument = new XmlDocument();

            var listId = Guid.NewGuid().ToString();
            var webId = Guid.NewGuid().ToString();
            var iD = Guid.NewGuid().ToString();
            var indexer = $"{webId}.{listId}.{iD}";

            var hshWBS = new Hashtable();
            hshWBS.Add($"Admin\n{DummyText}", _xmlDocument.CreateNode(XmlNodeType.Element, DummyFieldName, _xmlDocument.NamespaceURI));

            var hshFieldProperties = new Hashtable();
            hshFieldProperties.Add(listId, new Dictionary<string, Dictionary<string, string>>());

            var arrItems = new SortedList();
            arrItems.Add(indexer, new string[] { "Admin" });

            var hshLists = new Hashtable();
            hshLists.Add(DummyVal, "test.png");

            _privateObj.SetField("hshWBS", hshWBS);
            _privateObj.SetField("hshFieldProperties", hshFieldProperties);
            _privateObj.SetField("arrItems", arrItems);
            _privateObj.SetField("hshLists", hshLists);
            _privateObj.SetField("docXml", _xmlDocument);
            _privateObj.SetField("inEditMode", _inEditmode);
            _privateObj.SetField("isTimesheet", _timesheet);
            _privateObj.SetField("showCheckboxes", _showCheckboxes);
            _privateObj.SetField("isTimesheet", _isTimesheet);
            _privateObj.SetField("titleFieldFound", _titleFieldFound);
            _privateObj.SetField("usePopup", _usepopup);
            _privateObj.SetField("bCleanValues", _cleanValues);
            _privateObj.SetField("bWorkspaceUrl", _workspaceUrl);
            _privateObj.SetField("rolluplists", new string[] { DummyVal });
            _privateObj.SetField("linktype", linkType);
            _privateObj.SetField("list", new ShimSPList().Instance);

            var hshComboCells = new Hashtable
            {
                { $"{internalname}-{listId}-{webId}", DummyVal }
            };
            _privateObj.SetField("hshComboCells", hshComboCells);

            var aViewFields = new ArrayList();
            aViewFields.Add(fieldName);
            _privateObj.SetField("aViewFields", aViewFields);

            var hshItemNodes = new Hashtable();
            hshItemNodes.Add(TitleField, DummyVal);
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
            _privateObj.SetField("hshColumnSelectFilter", hshItemNodes);
            _privateObj.SetField("hshItemNodes", hshItemNodes);

            ShimSharePoint(internalname, fieldType, listId, webId);

            Shimgetgriditems.AllInstances.getFieldSPListItemStringBoolean =
                (a, b, c, d) => DummyFieldName;
            Shimgetgriditems.AllInstances.isEditableSPListItemSPFieldDictionaryOfStringDictionaryOfStringString =
                (a, b, c, d) => editable;

            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest();
            ShimHttpRequest.AllInstances.ItemGetString = (_, __) => DummyVal;

            ShimXmlDocument.AllInstances.CreateNodeXmlNodeTypeStringString =
            (docXml, type, name, ns) =>
            {
                var node = ShimsContext.ExecuteWithoutShims(() => docXml.CreateNode(type, name, ns));

                if (type == XmlNodeType.Element && name == "row" && _newItemNode == null)
                {
                    _newItemNode = node;
                }

                return node;
            };

            return indexer;
        }

        private void ShimSharePoint(string internalname, SPFieldType fieldType, string listId, string webId)
        {
            Shimgetgriditems.AllInstances.addMenusXmlNodeSPListString = (a, ndNewItem, b, c) => GetMenus(ndNewItem);

            ShimSPView.AllInstances.UrlGet = _ => ExampleUrl;
            ShimSPContentTypeCollection.AllInstances.ItemGetInt32 = (_, __) => new ShimSPContentType { NameGet = () => TypeTextPlain };
            ShimSPFormCollection.AllInstances.ItemGetPAGETYPE = (_, __) => new ShimSPForm();
            ShimSPForm.AllInstances.ServerRelativeUrlGet = _ => ExampleUrl;

            PrepareSpListRelatedShims(listId);
            PrepareSpFieldRelatedShims(internalname, fieldType);
            PrepareSpWebRelatedShims(webId);
            PrepareSpFileRelatedShims();
            PrepareSpUserRelatedShims();
        }

        private static void PrepareSpListRelatedShims(string listId = null)
        {
            ShimSPListCollection.AllInstances.ItemGetString = (_, __) => new ShimSPList();
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
            ShimSPList.AllInstances.IDGet = _ => listId == null ? Guid.NewGuid() : new Guid(listId);
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

            ShimSPListItemCollection.AllInstances.Add = _ => new ShimSPListItem();
            var itemCollection = new ShimSPListItemCollection();
            itemCollection.Bind(new List<SPListItem>
            {
                new ShimSPListItem()
            });
            ShimSPList.AllInstances.GetItemsSPQuery = (_, __) => itemCollection.Instance;
            ShimSPList.AllInstances.GetItemsSPView = (_, __) => itemCollection.Instance;
        }

        private void PrepareSpUserRelatedShims()
        {
            ShimSPUser.AllInstances.IDGet = _ => 1;
            ShimSPUser.AllInstances.LoginNameGet = _ => DummyText;
            ShimSPUser.AllInstances.NameGet = _ => DummyText;
        }

        private void PrepareSpFieldRelatedShims(string internalname, SPFieldType fieldType)
        {
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField();
            ShimSPFieldCollection.AllInstances.ContainsFieldWithStaticNameString = (_, __) => true;
            ShimSPField.AllInstances.IdGet = _ => Guid.NewGuid();
            ShimSPField.AllInstances.InternalNameGet = _ => internalname;
            ShimSPField.AllInstances.TypeAsStringGet = _ => internalname;
            ShimSPField.AllInstances.TypeGet = _ => fieldType;
            ShimSPField.AllInstances.ReadOnlyFieldGet = _ => false;
            ShimSPField.AllInstances.ShowInEditFormGet = _ => true;
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root>1</root>";
            ShimSPField.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPField.AllInstances.TitleGet = _ => DummyText;
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

        private void PrepareSpFileRelatedShims()
        {
            ShimSPFolderCollection.AllInstances.ItemGetString = (_, __) => new ShimSPFolder();
            ShimSPFolder.AllInstances.SubFoldersGet = _ => new ShimSPFolderCollection();
            ShimSPFolder.AllInstances.FilesGet = _ => new ShimSPFileCollection();
            ShimSPFileCollection.AllInstances.ItemGetInt32 = (_, __) => new ShimSPFile();
            ShimSPFile.AllInstances.ServerRelativeUrlGet = _ => ExampleUrl;
        }

        private void PrepareSpWebRelatedShims(string webId = null)
        {
            ShimSPWeb.AllInstances.IDGet = _ => webId == null ? Guid.NewGuid() : new Guid(webId);
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => ExampleUrl;
            ShimSPWeb.AllInstances.UrlGet = _ => ExampleUrl;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPWeb.AllInstances.LanguageGet = _ => 1;
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPWeb.AllInstances.FoldersGet = _ => new ShimSPFolderCollection();
            ShimSPWeb.AllInstances.TitleGet = _ => "1";
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.LocaleGet = _ => CultureInfo.InvariantCulture;

            var properties = new StringDictionary { { "reportingV2", bool.TrueString } };
            var propertyBag = new ShimSPPropertyBag();
            propertyBag.Bind(properties);
            ShimSPWeb.AllInstances.PropertiesGet = _ => propertyBag.Instance;
            ShimSPSite.AllInstances.UrlGet = _ => ExampleUrl;
        }

        private XmlNode GetMenus(XmlNode ndNewItem)
        {
            var viewMenus = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var strViewMenus = string.Empty;
            foreach (int v in viewMenus)
            {
                strViewMenus += "," + v.ToString();
            }
            strViewMenus = strViewMenus.Substring(1);

            var ndUserData = _xmlDocument.CreateNode(XmlNodeType.Element, "userdata", _xmlDocument.NamespaceURI);
            ndUserData.InnerText = strViewMenus;

            var attrName = _xmlDocument.CreateAttribute("name");
            attrName.Value = "viewMenus";
            ndUserData.Attributes.Append(attrName);

            ndNewItem.AppendChild(ndUserData);

            return ndNewItem;
        }
    }
}
