using System;
using System.Collections;
using System.Collections.Fakes;
using System.Collections.Generic;
using System.Collections.Generic.Fakes;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices.ActiveDirectory.Fakes;
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

        [TestMethod]
        public void AddItem_EditNotInEditMode_()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("Edit", "DocIcon");

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_DocIcon_()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("Title", "DocIcon");

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_WorkspaceUrl_()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("Title", "WorkspaceUrl");

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_ContentType_()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("Title", "ContentType");

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_ContentTypeNoListItemId_()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("Title", "ContentType");
            ShimSPListItem.AllInstances.IDGet = _ => 0;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_FileLeafRefView_()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("Title", "FileLeafRef", "view");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_FileLeafRefEdit_()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("Title", "FileLeafRef", "edit");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_FileLeafRefEditLinkFilenameNoMenu_()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("LinkFilenameNoMenu", "FileLeafRef", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_FileLeafRefEditLinkFilename_()
        {
            // Arrange
            _inEditmode = false;
            var indexer = PrepareForAddItem("LinkFilename", "FileLeafRef", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_TitleCleanValues_()
        {
            // Arrange
            _cleanValues = true;
            _inEditmode = false;
            var indexer = PrepareForAddItem("Title", "Title", string.Empty);
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_TitleViewNotEditMode_()
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
        }

        [TestMethod]
        public void AddItem_TitleViewEditMode_()
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
        }

        [TestMethod]
        public void AddItem_TitleEditNotEditMode_()
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
        }

        [TestMethod]
        public void AddItem_TitleEditEditMode_()
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
        }

        [TestMethod]
        public void AddItem_TitleLinkTitleNoMenuNotEditMode_()
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
        }

        [TestMethod]
        public void AddItem_TitleLinkTitleNoMenuEditMode_()
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
        }

        [TestMethod]
        public void AddItem_TitleLinkTitleNotEditMode_()
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
        }

        [TestMethod]
        public void AddItem_TitleLinkTitleEditMode_()
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
        }

        [TestMethod]
        public void AddItem_TitleWorkspace_()
        {
            // Arrange
            _cleanValues = false;
            var indexer = PrepareForAddItem("Title", "Title", "workspace");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_TitleWorkplan_()
        {
            // Arrange
            _cleanValues = false;
            var indexer = PrepareForAddItem("Title", "Title", "workplan");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_TitlePlanner_()
        {
            // Arrange
            _cleanValues = false;
            var indexer = PrepareForAddItem("Title", "Title", "planner");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_TitleTasks_()
        {
            // Arrange
            _cleanValues = false;
            var indexer = PrepareForAddItem("Title", "Title", "tasks");
            ShimSPListItem.AllInstances.FileGet = _ => new ShimSPFile();

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_CleanValuesCalculatedIndicator_()
        {
            // Arrange
            _cleanValues = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Calculated);
            ShimSPField.AllInstances.DescriptionGet = _ => "Indicator";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_CleanValuesCalculatedNonIndicator_()
        {
            // Arrange
            _cleanValues = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Calculated);
            ShimSPField.AllInstances.DescriptionGet = _ => DummyVal;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_CleanValuesUserFieldUserValue_()
        {
            // Arrange
            _cleanValues = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.User);
            ShimSPField.AllInstances.GetFieldValueString = (_, __) => new ShimSPFieldUserValue().Instance;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_CleanValuesUserFieldUserValueCollection_()
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
        }

        [TestMethod]
        public void AddItem_CleanValuesMultiChoice_()
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
        }

        [TestMethod]
        public void AddItem_CleanValuesLookup_()
        {
            // Arrange
            _cleanValues = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Lookup);

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_CleanValuesDateTime_()
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
        }

        [TestMethod]
        public void AddItem_CleanValuesText_()
        {
            // Arrange
            _cleanValues = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Text);
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => DummyText;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_InEditModeNumber_()
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
        }

        [TestMethod]
        public void AddItem_InEditModeUserFieldUserValue_()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.User, editable: true);
            ShimSPField.AllInstances.GetFieldValueString = (_, __) => new ShimSPFieldUserValue().Instance;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_InEditModeUserFieldUserValueCollection_()
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
        }

        [TestMethod]
        public void AddItem_InEditModeMultiChoice_()
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
        }

        [TestMethod]
        public void AddItem_InEditModeChoice_()
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
        }

        [TestMethod]
        public void AddItem_InEditModeLookupMulti_()
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
        }

        [TestMethod]
        public void AddItem_InEditModeLookup_()
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
        }

        [TestMethod]
        public void AddItem_InEditModeCalculated_()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Calculated, editable: true);
            ShimSPField.AllInstances.DescriptionGet = _ => "Indicator";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_InEditModeCurrency_()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Currency, editable: true);

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_InEditModeAttachmentsEmpty_()
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
        }

        [TestMethod]
        public void AddItem_InEditModeAttachmentsNotEmpty_()
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
        }

        [TestMethod]
        public void AddItem_InEditModeText_()
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
        }
        
        [TestMethod]
        public void AddItem_InEditModeBooleanTrue_()
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
        }

        [TestMethod]
        public void AddItem_InEditModeBooleanFalse_()
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
        }

        [TestMethod]
        public void AddItem_InEditModeDateTime_()
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
        }

        [TestMethod]
        public void AddItem_InEditModeInteger_()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Integer, editable: true);
            ShimSPField.AllInstances.TypeAsStringGet = _ => "Integer";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_NotInEditModeAttachmentsEmpty_()
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
        }

        [TestMethod]
        public void AddItem_NotInEditModeAttachmentsNotEmpty_()
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
        }

        [TestMethod]
        public void AddItem_NotInEditModeUser_()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.User, editable: false);
            ShimSPField.AllInstances.GetFieldValueString = (_, __) => new ShimSPFieldUserValue().Instance;

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_NotInEditModeCalculated_()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Calculated, editable: false);
            ShimSPField.AllInstances.DescriptionGet = _ => "Indicator";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_NotInEditModeMultiChoice_()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.MultiChoice, editable: false);
            ShimSPWeb.AllInstances.TitleGet = _ => "1,2";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_NotInEditModeChoice_()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = false;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Choice, editable: false);
            ShimSPWeb.AllInstances.TitleGet = _ => "1,2";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
        }

        [TestMethod]
        public void AddItem_NotInEditModeLookup_()
        {
            // Arrange
            _cleanValues = false;
            _inEditmode = true;
            var indexer = PrepareForAddItem("ItemID", "ItemID", fieldType: SPFieldType.Lookup, editable: false);
            ShimSPWeb.AllInstances.TitleGet = _ => "1,2";

            // Act
            _privateObj.Invoke(AddItemMethod, new object[] { new ShimSPListItem().Instance, indexer });

            // Assert
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
            hshItemNodes.Add("Title", DummyVal);
            hshItemNodes.Add("SiteUrl", "");
            hshItemNodes.Add("List", "");
            hshItemNodes.Add("Site", "");
            hshItemNodes.Add(internalname + "Text", "Text");
            hshItemNodes.Add("ItemID", "");
            hshItemNodes.Add("Work", "");
            hshItemNodes.Add("WorkspaceUrl", "");
            if (!hshItemNodes.ContainsKey(internalname))
            {
                hshItemNodes.Add(internalname, "");
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

            return indexer;
        }

        private void ShimSharePoint(string internalname, SPFieldType fieldType, string listId, string webId)
        {
            ShimSPListCollection.AllInstances.ItemGetString = (_, __) => new ShimSPList();
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
            ShimSPList.AllInstances.IDGet = _ => new Guid(listId);
            ShimSPList.AllInstances.TitleGet = _ => DummyVal;
            ShimSPList.AllInstances.ImageUrlGet = _ => $"image.png";
            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb();
            ShimSPList.AllInstances.ContentTypesGet = _ => new ShimSPContentTypeCollection();
            ShimSPList.AllInstances.FormsGet = _ => new ShimSPFormCollection();
            ShimSPList.AllInstances.DefaultViewGet = _ => new ShimSPView();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPList.AllInstances.EnableVersioningGet = _ => true;
            ShimSPList.AllInstances.EnableModerationGet = _ => true;

            Shimgetgriditems.AllInstances.addMenusXmlNodeSPListString = (a, ndNewItem, b, c) => GetMenus(ndNewItem);

            ShimSPView.AllInstances.UrlGet = _ => ExampleUrl;

            ShimSPContentTypeCollection.AllInstances.ItemGetInt32 = (_, __) => new ShimSPContentType { NameGet = () => TypeTextPlain };

            ShimSPFormCollection.AllInstances.ItemGetPAGETYPE = (_, __) => new ShimSPForm();
            ShimSPForm.AllInstances.ServerRelativeUrlGet = _ => ExampleUrl;

            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField();
            ShimSPFieldCollection.AllInstances.ContainsFieldWithStaticNameString = (_, __) => true;
            ShimSPField.AllInstances.IdGet = _ => Guid.NewGuid();
            ShimSPField.AllInstances.InternalNameGet = _ => internalname;
            ShimSPField.AllInstances.TypeGet = _ => fieldType;
            ShimSPField.AllInstances.ReadOnlyFieldGet = _ => false;
            ShimSPField.AllInstances.ShowInEditFormGet = _ => true;
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root>1</root>";
            ShimSPField.AllInstances.ParentListGet = _ => new ShimSPList();
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

            ShimSPWeb.AllInstances.IDGet = _ => new Guid(webId);
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => ExampleUrl;
            ShimSPWeb.AllInstances.UrlGet = _ => ExampleUrl;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPWeb.AllInstances.LanguageGet = _ => 1;
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPWeb.AllInstances.FoldersGet = _ => new ShimSPFolderCollection();
            ShimSPWeb.AllInstances.TitleGet = _ => "1";
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.AllInstances.UrlGet = _ => ExampleUrl;

            ShimSPFolderCollection.AllInstances.ItemGetString = (_, __) => new ShimSPFolder();
            ShimSPFolder.AllInstances.SubFoldersGet = _ => new ShimSPFolderCollection();
            ShimSPFolder.AllInstances.FilesGet = _ => new ShimSPFileCollection();
            ShimSPFileCollection.AllInstances.ItemGetInt32 = (_, __) => new ShimSPFile();
            ShimSPFile.AllInstances.ServerRelativeUrlGet = _ => ExampleUrl;

            ShimSPUser.AllInstances.IDGet = _ => 1;
            ShimSPUser.AllInstances.LoginNameGet = _ => DummyText;
            ShimSPUser.AllInstances.NameGet = _ => DummyText;
        }

        private XmlNode GetMenus(XmlNode ndNewItem)
        {
            var viewMenus = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            string strViewMenus = "";

            foreach (int v in viewMenus)
            {
                strViewMenus += "," + v.ToString();
            }
            strViewMenus = strViewMenus.Substring(1);
            XmlNode ndUserData = _xmlDocument.CreateNode(XmlNodeType.Element, "userdata", _xmlDocument.NamespaceURI);
            ndUserData.InnerText = strViewMenus;

            XmlAttribute attrName = _xmlDocument.CreateAttribute("name");
            attrName.Value = "viewMenus";
            ndUserData.Attributes.Append(attrName);

            ndNewItem.AppendChild(ndUserData);

            return ndNewItem;
        }
    }
}
