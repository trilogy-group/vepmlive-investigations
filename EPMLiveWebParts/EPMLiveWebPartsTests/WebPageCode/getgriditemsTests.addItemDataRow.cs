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

        [TestMethod]
        public void AddItem_DataRowEditNotInEditMode_SetsNewItemRow()
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
                () => _newItemNode.Attributes["id"].Value.ShouldContainWithoutWhitespace(indexer),
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[#roweditid#]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowDocIcon_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowWorkspaceUrl_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[<a href=\"{DummyVal}\"><img src=\"{ExampleUrl}/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowContentType_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[{TypeTextXml};#{TypeTextXml}\t{DummyVal}]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowContentTypeNoListItemId_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[{TypeTextPlain};#{TypeTextPlain}\t{DummyVal}]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowFileLeafRefView_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<A onfocus=\"OnLink(this)\" HREF=\"http://example.com\" onclick=\"return DispEx(this,event,'TRUE','FALSE','TRUE','SharePoint.OpenDocuments.3','0','SharePoint.OpenDocuments','','','','1','0','0','ows_PermMask')\">ows_BaseName</A>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowFileLeafRefEdit_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<A onfocus=\"OnLink(this)\" HREF=\"http://example.com\" onclick=\"return DispEx(this,event,'TRUE','FALSE','FALSE','SharePoint.OpenDocuments.3','0','SharePoint.OpenDocuments','','','','1','0','0','ows_PermMask')\">ows_BaseName<img src=\"/_layouts/images/blank.gif\" class=\"ms-hidden\" border=1 width=1 height=26 alt=\"Use SHIFT+ENTER to open the menu (new window).\"></A><img src=\"/_layouts/images/blank.gif\" width=13 style=\"visibility:hidden\" alt=\"\">]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowFileLeafRefEditLinkFilenameNoMenu_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<A onfocus=\"OnLink(this)\" HREF=\"http://example.com\" onclick=\"return DispEx(this,event,'TRUE','FALSE','TRUE','SharePoint.OpenDocuments.3','0','SharePoint.OpenDocuments','','','','1','0','0','ows_PermMask')\">ows_BaseName</A>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowFileLeafRefEditLinkFilename_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<A onfocus=\"OnLink(this)\" HREF=\"http://example.com\" onclick=\"return DispEx(this,event,'TRUE','FALSE','FALSE','SharePoint.OpenDocuments.3','0','SharePoint.OpenDocuments','','','','1','0','0','ows_PermMask')\">ows_BaseName<img src=\"/_layouts/images/blank.gif\" class=\"ms-hidden\" border=1 width=1 height=26 alt=\"Use SHIFT+ENTER to open the menu (new window).\"></A><img src=\"/_layouts/images/blank.gif\" width=13 style=\"visibility:hidden\" alt=\"\">]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowTitleCleanValues_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[{DummyFieldName}]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowTitleViewNotEditMode_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<a href=\"\" onclick=\"javascript:viewItem(this,'view');return false;\"></a> <img src=\"/_layouts/1/images/new.gif\"> &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\"><img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>&nbsp;<a href=\"DummyVal\"><img src=\"http://example.com/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowTitleViewEditMode_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowTitleEditNotEditMode_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>&nbsp;<a href=\"DummyVal\">"),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<img src=\"http://example.com/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowTitleEditEditMode_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowTitleLinkTitleNoMenuNotEditMode_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<a href=\"\" onclick=\"javascript:viewItem(this,'view');return false;\">"),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("</a> <img src=\"/_layouts/1/images/new.gif\"> &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\">"),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>&nbsp;<a href=\"DummyVal\">"),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<img src=\"http://example.com/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowTitleLinkTitleNoMenuEditMode_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowTitleLinkTitleNotEditMode_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<a href=\"\" onclick=\"javascript:viewItem(this,'edit');return false;\"></a> <img src=\"/_layouts/1/images/new.gif\"> &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\"><img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>&nbsp;<a href=\"DummyVal\"><img src=\"http://example.com/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowTitleLinkTitleEditMode_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowTitleWorkspace_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<a href=\"http://example.com/\"></a> <img src=\"/_layouts/1/images/new.gif\"> &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\">"),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>&nbsp;<a href=\"DummyVal\">"),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<img src=\"http://example.com/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowTitleWorkplan_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<a href=\"http://example.com/_layouts/epmlive/tasks.aspx?ID=1\"></a> <img src=\"/_layouts/1/images/new.gif\"> &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\">"));
        }

        [TestMethod]
        public void AddItem_DataRowTitlePlanner_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<a href=\"http://example.com/_layouts/epmlive/workplanner.aspx?ID=1&Source=DummyVal\"></a> <img src=\"/_layouts/1/images/new.gif\"> &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\"><img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>&nbsp;<a href=\"DummyVal\"><img src=\"http://example.com/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowTitleTasks_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<a href=\"http://example.com/http://example.com?FilterField1=Project&FilterValue1=\"></a> <img src=\"/_layouts/1/images/new.gif\"> &nbsp;<a href=\"javascript:viewItem(this,'comments');return false;\"><img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>&nbsp;<a href=\"DummyVal\"><img src=\"http://example.com/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowCleanValuesCalculatedIndicator_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<img src=\"/_layouts/images/dummyfieldname\">]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowCleanValuesCalculatedNonIndicator_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[{DummyFieldName}]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowCleanValuesUserFieldUserValue_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[<a Title=\"{DummyText}\"href=\"http://example.com/_layouts/userdisp.aspx?ID=1\">{DummyText}</a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowCleanValuesUserFieldUserValueCollection_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[<a Title=\"{DummyText}\"href=\"http://example.com/_layouts/userdisp.aspx?ID=1\">{DummyText}</a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowCleanValuesMultiChoice_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[{DummyVal}]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowCleanValuesLookup_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[{DummyVal}]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowCleanValuesDateTime_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[{DateTime.Today.ToString("MM/dd/yyyy")} 12:00:00 AM]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowCleanValuesText_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[{DummyFieldName}]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowInEditModeNumber_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell type=\"edn\"><![CDATA[100]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowInEditModeUserFieldUserValue_SetsNewItemRow()
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
        public void AddItem_DataRowInEditModeUserFieldUserValueCollection_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell type=\"usereditorm\"><![CDATA[{DummyText}\n{DummyText}\t]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowInEditModeMultiChoice_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell type=\"mchoice\"><![CDATA[{DummyFieldName};#{DummyFieldName}\t1;#1]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowInEditModeChoice_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell type=\"choice\"><![CDATA[{DummyFieldName};#{DummyFieldName}	1;#1]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowInEditModeLookupMulti_SetsNewItemRow()
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
        public void AddItem_DataRowInEditModeLookup_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell type=\"ro\"><![CDATA[1;#{DummyVal}\t]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowInEditModeCalculated_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<img src=\"/_layouts/images/dummyfieldname\">]]></cell"));
        }

        [TestMethod]
        public void AddItem_DataRowInEditModeCurrency_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell type=\"edn\"><![CDATA[{DummyFieldName}]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowInEditModeAttachmentsEmpty_SetsNewItemRow()
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
        public void AddItem_DataRowInEditModeAttachmentsNotEmpty_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[<a href=\"{ExampleUrl}\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowInEditModeText_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell type=\"ed\"><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowInEditModeBooleanTrue_SetsNewItemRow()
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
        public void AddItem_DataRowInEditModeBooleanFalse_SetsNewItemRow()
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
        public void AddItem_DataRowInEditModeDateTime_SetsNewItemRow()
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
        public void AddItem_DataRowInEditModeInteger_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowNotInEditModeAttachmentsEmpty_SetsNewItemRow()
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
        public void AddItem_DataRowNotInEditModeAttachmentsNotEmpty_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[<a href=\"{ExampleUrl}\"></a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowNotInEditModeUser_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell><![CDATA[<a Title=\"{DummyText}\"href=\"http://example.com/_layouts/userdisp.aspx?ID=1\">{DummyText}</a>]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowNotInEditModeCalculated_SetsNewItemRow()
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
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<cell><![CDATA[<img src=\"/_layouts/images/dummyfieldname\">]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowNotInEditModeMultiChoice_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.MultiChoice, editable: false);
            ShimSPWeb.AllInstances.TitleGet = _ => "1,2";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<![CDATA[<input type=\"checkbox\" style=\"display:none;\" onClick=\"(arguments[0]||event).cancelBubble=true;CheckBoxSelectRow(this);\">]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowNotInEditModeChoice_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Choice, editable: false);
            ShimSPWeb.AllInstances.TitleGet = _ => "1,2";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace("<![CDATA[<input type=\"checkbox\" style=\"display:none;\" onClick=\"(arguments[0]||event).cancelBubble=true;CheckBoxSelectRow(this);\">]]></cell>"));
        }

        [TestMethod]
        public void AddItem_DataRowNotInEditModeLookup_SetsNewItemRow()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Lookup, editable: false);
            ShimSPWeb.AllInstances.TitleGet = _ => "1,2";
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPFieldLookup { LookupListGet = () => Guid.NewGuid().ToString() }.Instance;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { GetRow("ItemID") });

            // Assert
            _newItemNode.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _newItemNode.InnerXml.ShouldNotBeEmpty(),
                () => _newItemNode.InnerXml.ShouldContainWithoutWhitespace($"<cell type=\"ro\"><![CDATA[{DummyFieldName}]]></cell>"));
        }

        private DataRow GetRow(string internalname, string itemID = "2")
        {
            var listId = "F316E11-C842-4440-9918-39A8F1C12DA9";
            var webID = "1A8F7946-CCA1-4A24-8785-CE8E32D012BE";
            var ID = "5D592B57-C072-4B36-8809-11262120484D";

            ResetFields(listId, webID, ID);

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
            newRow["SiteUrl"] = "";
            newRow["ItemID"] = itemID;
            newRow["Created"] = DateTime.Now;
            newRow[internalname + "ID"] = "13,14,15,16,17";
            newRow[internalname + "Text"] = "A,B,C,D,E";
            newRow["Title"] = "First Project";
            newRow["Work"] = "";
            if (internalname != "WorkspaceUrl")
                newRow["WorkspaceUrl"] = "http://testURL";
            newRow["WebID"] = webID;
            newRow["ListID"] = listId;
            newRow["ID"] = ID;
            newRow["siteid"] = "";
            newRow["ParentItem"] = "";
            if (newRow[internalname] == null)
            {
                newRow[internalname] = DummyVal;
            }
            newRow["CommentCount"] = "20";
            newRow["TSDisableItem"] = "";
            newRow["Commenters"] = "";
            newRow["Author"] = "";
            newRow["AssignedTo"] = "2";
            newRow["CommentersRead"] = "";
            newRow["List"] = "ICON";
            newRow["TestColumn"] = $"{DummyText}.{DummyText}";

            return newRow;
        }

        private void ResetFields(string listId, string webID, string iD)
        {
            var arrItems = new SortedList();
            arrItems.Add(webID + "." + listId + "." + iD, new string[] { "Admin" });
            _privateObj.SetField("arrItems", arrItems);
            _privateObj.SetField("usewbs", "TestColumn");
        }
    }
}
