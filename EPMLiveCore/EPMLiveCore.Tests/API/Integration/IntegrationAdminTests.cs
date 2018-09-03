using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using System.Xml;
using EPMLiveCore.API.Integration;
using EPMLiveCore.API.Integration.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API.Integration
{
    [TestClass, ExcludeFromCodeCoverage]
    public class IntegrationAdminTests
    {
        private class InputFormSectionTest : InputFormSection
        {

        }

        private const string DummyString = "DummyString";
        private const string One = "1";
        private const string ExampleUrl = "http://example.com";
        private const string ColumnId = "INTUID1";
        private const string AssemblyName = "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";
        private const string ClassName = "EPMLiveCore.IntegrateEvents";
        private const string ModuleIdKey = "MODULE_ID";
        private const string ListIdKey = "LIST_ID";
        private const string ColIdKey = "INT_COLID";
        private const string SiteIdKey = "SITE_ID";
        private const string WebIdKey = "WEB_ID";
        private const string PriorityKey = "Priority";
        private const string SitePriorityKey = "Site_Priority";
        private const string IconKey = "Icon";
        private const string DescriptionKey = "Description";
        private const string Root = "root";
        private const string Input = "Input";
        private const string Property = "Property";
        private const string Title = "Title";
        private const string Type = "Type";
        private const string ParentProperty = "ParentProperty";
        private const string True = "True";
        private const string TextType = "text";
        private const string PasswordType = "password";
        private const string TextAreaType = "textarea";
        private const string CheckboxType = "checkbox";
        private const string SelectType = "select";
        private const string ControlCollectionField = "ControlCollection";
        private const string Passphrase = "kKGBJ768d3q78^#&^dsas";
        private const string GetNodeAttributeMethod = "GetNodeAttribute";
        private const string DeleteStatementFormat = "DELETE FROM {0} where INT_LIST_ID=@intlistid";
        private const string IntListsTable = "INT_LISTS";
        private const string IntLogTable = "INT_LOG";
        private const string IntColumnsTable = "INT_COLUMNS";
        private const string IntPropsTable = "INT_PROPS";
        private const string InsertIntListStatement = "INSERT INTO INT_LISTS (INT_LIST_ID, MODULE_ID, LIST_ID,WEB_ID, SITE_ID, INT_COLID, PRIORITY, INT_KEY, SITE_PRIORITY, LIVEOUTGOING, LIVEINCOMING, TIMEOUTGOING, TIMEINCOMING) VALUES (@intlistid, @moduleid, @listid, @webid, @siteid, @colid, @priority, @intkey, @sitepriority, @lout, @lin, @tout, @tin)";
        private const string UpdateIntListStatement = "UPDATE INT_LISTS SET INT_KEY=@intkey, LIVEOUTGOING=@lout, LIVEINCOMING=@lin, TIMEOUTGOING=@tout, TIMEINCOMING = @tin where INT_LIST_ID=@intlistid";
        private string _imageAndTitleHtml = $"<table border=\"0\" width=\"100%\"><tr><td width=\"64\"><img src=\"/_layouts/epmlive/images/integration/{DummyString}\"></td><td valign=\"center\"><h4>{DummyString}</h4>";
        private string _descriptionHtml = $"<div style=\"padding-top: 5px;padding-bottom:10px;padding-right:5px;work-wrap:break-word;\">{DummyString}</div>";
        private IntegrationAdmin _testObject;
        private PrivateObject _privateObject;
        private IDisposable _shimsContext;
        private IntegrationCore _integrationCore;
        private Guid _guid1;
        private Guid _guid2;
        private Guid _dummyGuid;
        private List<string> _queries;
        private Dictionary<string, object> _queriesParams;
        private List<SPEventReceiverDefinition> _definitionsList;
        private Dictionary<string, SPField> _fields;
        private bool _listUpdated;
        private bool _fieldUpdated;
        private bool _fieldDeleted;
        private int _eventsDeleted;
        private Hashtable _propertiesSaved;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            ShimIntegrationCoreMethods();
            ShimSharePointMethods();

            _guid1 = Guid.NewGuid();
            _guid2 = Guid.NewGuid();
            _dummyGuid = Guid.NewGuid();
            _queries = new List<string>();
            _queriesParams = new Dictionary<string, object>();
            _fields = new Dictionary<string, SPField>();
            _listUpdated = false;
            _fieldUpdated = false;
            _fieldDeleted = false;
            _eventsDeleted = 0;
            _propertiesSaved = null;

            _integrationCore = new IntegrationCore(_guid1, _guid2);
            _testObject = new IntegrationAdmin(_integrationCore, _guid1, Guid.Empty);
            _privateObject = new PrivateObject(_testObject);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void DeleteIntegration_IntegrationRemoved_ReturnsTrue()
        {
            // Arrange
            var message = string.Empty;
            _fields.Add(ColumnId, GetDefaultSPField(ColumnId, SPFieldType.Text, false).Instance);
            ShimIntegrationCore.AllInstances.RemoveIntegrationGuidGuidStringOut = (IntegrationCore _, Guid a, Guid b, out string returnMessage) =>
            {
                returnMessage = DummyString;
                return true;
            };

            // Act
            var result = _testObject.DeleteIntegration(_dummyGuid, out message);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => message.ShouldBe(DummyString),
                () => _queries.ShouldContain(string.Format(DeleteStatementFormat, IntListsTable)),
                () => _queries.ShouldContain(string.Format(DeleteStatementFormat, IntLogTable)),
                () => _queries.ShouldContain(string.Format(DeleteStatementFormat, IntColumnsTable)),
                () => _queries.ShouldContain(string.Format(DeleteStatementFormat, IntPropsTable)),
                () => result.ShouldBeTrue());
        }

        [TestMethod]
        public void DeleteIntegration_IntegrationNotRemoved_ReturnsFalse()
        {
            // Arrange
            var message = string.Empty;
            ShimIntegrationCore.AllInstances.RemoveIntegrationGuidGuidStringOut = (IntegrationCore _, Guid a, Guid b, out string returnMessage) =>
            {
                returnMessage = DummyString;
                return false;
            };

            // Act
            var result = _testObject.DeleteIntegration(_dummyGuid, out message);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => message.ShouldBe(DummyString),
                () => _queries.ShouldNotContain(string.Format(DeleteStatementFormat, IntListsTable)),
                () => _queries.ShouldNotContain(string.Format(DeleteStatementFormat, IntLogTable)),
                () => _queries.ShouldNotContain(string.Format(DeleteStatementFormat, IntColumnsTable)),
                () => _queries.ShouldNotContain(string.Format(DeleteStatementFormat, IntPropsTable)),
                () => result.ShouldBeFalse());
        }

        [TestMethod]
        public void InstallEventHandlers_ItemAddedExists_UpdatesList()
        {
            // Arrange
            var list = ShimSPEventReceiverDefinitionCollectionMethods();
            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, AssemblyName, ClassName);

            // Act
            _testObject.InstallEventHandlers(list);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _listUpdated.ShouldBeTrue(),
                () => _definitionsList.Count.ShouldBe(3),
                () => _definitionsList[0].Type.ShouldBe(SPEventReceiverType.ItemAdded),
                () => _definitionsList[1].Type.ShouldBe(SPEventReceiverType.ItemUpdated),
                () => _definitionsList[2].Type.ShouldBe(SPEventReceiverType.ItemDeleting));
        }

        [TestMethod]
        public void InstallEventHandlers_ItemUpdatedExists_UpdatesList()
        {
            // Arrange
            var list = ShimSPEventReceiverDefinitionCollectionMethods();
            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, AssemblyName, ClassName);

            // Act
            _testObject.InstallEventHandlers(list);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _listUpdated.ShouldBeTrue(),
                () => _definitionsList.Count.ShouldBe(3),
                () => _definitionsList[0].Type.ShouldBe(SPEventReceiverType.ItemUpdated),
                () => _definitionsList[1].Type.ShouldBe(SPEventReceiverType.ItemAdded),
                () => _definitionsList[2].Type.ShouldBe(SPEventReceiverType.ItemDeleting));
        }

        [TestMethod]
        public void InstallEventHandlers_ItemDeletingExists_UpdatesList()
        {
            // Arrange
            var list = ShimSPEventReceiverDefinitionCollectionMethods();
            list.EventReceivers.Add(SPEventReceiverType.ItemDeleting, AssemblyName, ClassName);

            // Act
            _testObject.InstallEventHandlers(list);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _listUpdated.ShouldBeTrue(),
                () => _definitionsList.Count.ShouldBe(3),
                () => _definitionsList[0].Type.ShouldBe(SPEventReceiverType.ItemDeleting),
                () => _definitionsList[1].Type.ShouldBe(SPEventReceiverType.ItemAdded),
                () => _definitionsList[2].Type.ShouldBe(SPEventReceiverType.ItemUpdated));
        }

        [TestMethod]
        public void InstallEventHandlers_AllItemsExist_DoesntUpdateList()
        {
            // Arrange
            var list = ShimSPEventReceiverDefinitionCollectionMethods();
            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, AssemblyName, ClassName);
            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, AssemblyName, ClassName);
            list.EventReceivers.Add(SPEventReceiverType.ItemDeleting, AssemblyName, ClassName);

            // Act
            _testObject.InstallEventHandlers(list);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _listUpdated.ShouldBeFalse(),
                () => _definitionsList.Count.ShouldBe(3),
                () => _definitionsList[0].Type.ShouldBe(SPEventReceiverType.ItemAdded),
                () => _definitionsList[1].Type.ShouldBe(SPEventReceiverType.ItemUpdated),
                () => _definitionsList[2].Type.ShouldBe(SPEventReceiverType.ItemDeleting));
        }

        [TestMethod]
        public void RemoveEventHandlers_Remove_RemoveAllHandlers()
        {
            // Arrange
            ShimIntegrationCore.AllInstances.GetDataSetStringHashtable = (a, b, c) => GetEmptyDataSet();
            var list = ShimSPEventReceiverDefinitionCollectionMethods(new ShimSPWeb().Instance);
            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, AssemblyName, ClassName);
            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, AssemblyName, ClassName);
            list.EventReceivers.Add(SPEventReceiverType.ItemDeleting, AssemblyName, ClassName);

            // Act
            _testObject.RemoveEventHandlers(list);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _eventsDeleted.ShouldBe(_definitionsList.Count),
                () => _listUpdated.ShouldBeTrue());
        }

        [TestMethod]
        public void CreateIntegration_Create_UpdatesList()
        {
            // Arrange, Act
            _testObject.CreateIntegration(_guid1, _guid2, _guid2, DummyString, true, true, true, true);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _queries.ShouldContain(InsertIntListStatement),
                () => _queriesParams["sitepriority"].ShouldBe(2),
                () => _queriesParams["priority"].ShouldBe(2),
                () => _queriesParams["colid"].ShouldBe(2),
                () => _listUpdated.ShouldBeTrue());
        }

        [TestMethod]
        public void UpdateIntegration_Update_ExecutesUpdateQuery()
        {
            // Arrange, Act
            _testObject.UpdateIntegration(_guid1, DummyString, true, true, true, true);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _queries.ShouldContain(UpdateIntListStatement),
                () => _queriesParams["intlistid"].ShouldBe(_guid1),
                () => _queriesParams["intkey"].ShouldBe(DummyString),
                () => _queriesParams["lout"].ShouldBe(true),
                () => _queriesParams["lin"].ShouldBe(true),
                () => _queriesParams["tout"].ShouldBe(true),
                () => _queriesParams["tin"].ShouldBe(true));
        }

        [TestMethod]
        public void SaveProperties_TextType_SavesHashtable()
        {
            // Arrange
            ShimInputFormSection.AllInstances.TitleSetString = (_, __) => { };
            InvokeGetPropertyPanel(TextType);
            var hashtable = new Hashtable();

            // Act
            _testObject.SaveProperties(hashtable);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _propertiesSaved.ShouldNotBeNull(),
                () => _propertiesSaved.ContainsKey(DummyString).ShouldBeTrue(),
                () => _propertiesSaved[DummyString].ShouldBe(True));
        }

        [TestMethod]
        public void SaveProperties_PasswordType_SavesHashtable()
        {
            // Arrange
            ShimInputFormSection.AllInstances.TitleSetString = (_, __) => { };
            InvokeGetPropertyPanel(PasswordType);
            var controls = _privateObject.GetFieldOrProperty(ControlCollectionField) as ArrayList;
            if (controls?.Count > 0)
            {
                var textBox = controls[0] as TextBox;
                textBox.Text = DummyString;
            }
            var hashtable = new Hashtable();

            // Act
            _testObject.SaveProperties(hashtable);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _propertiesSaved.ShouldNotBeNull(),
                () => _propertiesSaved.ContainsKey(DummyString).ShouldBeTrue(),
                () => _propertiesSaved[DummyString].ShouldBe(CoreFunctions.Encrypt(DummyString, Passphrase)));
        }

        [TestMethod]
        public void SaveProperties_SelectType_SavesHashtable()
        {
            // Arrange
            ShimInputFormSection.AllInstances.TitleSetString = (_, __) => { };
            InvokeGetPropertyPanelSelect();
            var hashtable = new Hashtable();

            // Act
            _testObject.SaveProperties(hashtable);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _propertiesSaved.ShouldNotBeNull(),
                () => _propertiesSaved.ContainsKey(DummyString).ShouldBeTrue(),
                () => _propertiesSaved[DummyString].ShouldBe(True));
        }

        [TestMethod]
        public void SaveProperties_CheckboxType_SavesHashtable()
        {
            // Arrange
            ShimInputFormSection.AllInstances.TitleSetString = (_, __) => { };
            InvokeGetPropertyPanel(CheckboxType);
            var hashtable = new Hashtable();

            // Act
            _testObject.SaveProperties(hashtable);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _propertiesSaved.ShouldNotBeNull(),
                () => _propertiesSaved.ContainsKey(DummyString).ShouldBeTrue(),
                () => _propertiesSaved[DummyString].ShouldBe(True));
        }

        [TestMethod]
        public void GetCurrentPageProperties_TextType_ReturnsHashtable()
        {
            // Arrange
            ShimInputFormSection.AllInstances.TitleSetString = (_, __) => { };
            InvokeGetPropertyPanel(TextType);

            // Act
            var result = _testObject.GetCurrentPageProperties();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ContainsKey(DummyString).ShouldBeTrue(),
                () => result[DummyString].ShouldBe(True));
        }

        [TestMethod]
        public void GetCurrentPageProperties_PasswordType_SavesHashtable()
        {
            // Arrange
            ShimInputFormSection.AllInstances.TitleSetString = (_, __) => { };
            InvokeGetPropertyPanel(PasswordType);
            var controls = _privateObject.GetFieldOrProperty(ControlCollectionField) as ArrayList;
            if (controls?.Count > 0)
            {
                var textBox = controls[0] as TextBox;
                textBox.Text = DummyString;
            }

            // Act
            var result = _testObject.GetCurrentPageProperties();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ContainsKey(DummyString).ShouldBeTrue(),
                () => result[DummyString].ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetCurrentPageProperties_SelectType_SavesHashtable()
        {
            // Arrange
            ShimInputFormSection.AllInstances.TitleSetString = (_, __) => { };
            InvokeGetPropertyPanelSelect();

            // Act
            var result = _testObject.GetCurrentPageProperties();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ContainsKey(DummyString).ShouldBeTrue(),
                () => result[DummyString].ShouldBe(True));
        }

        [TestMethod]
        public void GetCurrentPageProperties_CheckboxType_SavesHashtable()
        {
            // Arrange
            ShimInputFormSection.AllInstances.TitleSetString = (_, __) => { };
            InvokeGetPropertyPanel(CheckboxType);

            // Act
            var result = _testObject.GetCurrentPageProperties();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ContainsKey(DummyString).ShouldBeTrue(),
                () => result[DummyString].ShouldBe(True));
        }

        [TestMethod]
        public void GetNodeAttribute_NodeException_ReturnsEmpty()
        {
            // Arrange, Act
            var result = _privateObject.Invoke(GetNodeAttributeMethod, new object[] { null, null });

            // Assert
            result.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void GetPropertyPanel_Text_ReturnsPanel()
        {
            // Arrange
            var sectionTitle = string.Empty;
            ShimInputFormSection.AllInstances.TitleSetString = (_, title) => { sectionTitle = title; };

            // Act
            var result = InvokeGetPropertyPanel(TextType);

            // Assert
            TextBox textBox = null;
            var controls = _privateObject.GetFieldOrProperty(ControlCollectionField) as ArrayList;
            if (controls?.Count > 0)
            {
                textBox = controls[0] as TextBox;
            }
            this.ShouldSatisfyAllConditions(
                () => sectionTitle.ShouldBe(DummyString),
                () => result.Controls.Count.ShouldBe(3),
                () => textBox.ShouldNotBeNull(),
                () => textBox.ID.ShouldBe(DummyString),
                () => textBox.Text.ShouldBe(True));
        }

        [TestMethod]
        public void GetPropertyPanel_Password_ReturnsPanel()
        {
            // Arrange
            var sectionTitle = string.Empty;
            ShimInputFormSection.AllInstances.TitleSetString = (_, title) => { sectionTitle = title; };

            // Act
            var result = InvokeGetPropertyPanel(PasswordType);

            // Assert
            TextBox textBox = null;
            var controls = _privateObject.GetFieldOrProperty(ControlCollectionField) as ArrayList;
            if (controls?.Count > 0)
            {
                textBox = controls[0] as TextBox;
            }
            this.ShouldSatisfyAllConditions(
                () => sectionTitle.ShouldBe(DummyString),
                () => result.Controls.Count.ShouldBe(3),
                () => textBox.ShouldNotBeNull(),
                () => textBox.ID.ShouldBe(DummyString),
                () => textBox.Text.ShouldBeNullOrEmpty(),
                () => textBox.TextMode.ShouldBe(TextBoxMode.Password));
        }

        [TestMethod]
        public void GetPropertyPanel_TextArea_ReturnsPanel()
        {
            // Arrange
            var sectionTitle = string.Empty;
            ShimInputFormSection.AllInstances.TitleSetString = (_, title) => { sectionTitle = title; };

            // Act
            var result = InvokeGetPropertyPanel(TextAreaType);

            // Assert
            TextBox textBox = null;
            var controls = _privateObject.GetFieldOrProperty(ControlCollectionField) as ArrayList;
            if (controls?.Count > 0)
            {
                textBox = controls[0] as TextBox;
            }
            this.ShouldSatisfyAllConditions(
                () => sectionTitle.ShouldBe(DummyString),
                () => result.Controls.Count.ShouldBe(3),
                () => textBox.ShouldNotBeNull(),
                () => textBox.ID.ShouldBe(DummyString),
                () => textBox.Text.ShouldBe(True),
                () => textBox.TextMode.ShouldBe(TextBoxMode.MultiLine));
        }

        [TestMethod]
        public void GetPropertyPanel_Checkbox_ReturnsPanel()
        {
            // Arrange
            var sectionTitle = string.Empty;
            ShimInputFormSection.AllInstances.TitleSetString = (_, title) => { sectionTitle = title; };

            // Act
            var result = InvokeGetPropertyPanel(CheckboxType);

            // Assert
            CheckBox checkboxBox = null;
            var controls = _privateObject.GetFieldOrProperty(ControlCollectionField) as ArrayList;
            if (controls?.Count > 0)
            {
                checkboxBox = controls[0] as CheckBox;
            }
            this.ShouldSatisfyAllConditions(
                () => sectionTitle.ShouldBe(DummyString),
                () => result.Controls.Count.ShouldBe(3),
                () => checkboxBox.ShouldNotBeNull(),
                () => checkboxBox.ID.ShouldBe(DummyString),
                () => checkboxBox.Checked.ShouldBeTrue());
        }

        [TestMethod]
        public void GetPropertyPanel_Select_ReturnsPanel()
        {
            // Arrange
            var sectionTitle = string.Empty;
            ShimInputFormSection.AllInstances.TitleSetString = (_, title) => { sectionTitle = title; };

            // Act
            var result = InvokeGetPropertyPanelSelect();

            // Assert
            DropDownList dropdown = null;
            var controls = _privateObject.GetFieldOrProperty(ControlCollectionField) as ArrayList;
            if (controls?.Count > 0)
            {
                dropdown = controls[0] as DropDownList;
            }
            this.ShouldSatisfyAllConditions(
                () => sectionTitle.ShouldBe(DummyString),
                () => result.Controls.Count.ShouldBe(3),
                () => dropdown.ShouldNotBeNull(),
                () => dropdown.ID.ShouldBe(DummyString),
                () => dropdown.Items.Count.ShouldNotBe(0),
                () => dropdown.EnableViewState.ShouldBeTrue());
        }

        [TestMethod]
        public void GetPropertyPanel_Default_ReturnsPanel()
        {
            // Arrange
            var sectionTitle = string.Empty;
            var propdoc = CreateTestDocument(DummyString);

            var props = new Hashtable();
            props[DummyString] = True;
            ShimTemplateControl.AllInstances.LoadControlString = (_, __) => new StubInputFormSection();
            ShimInputFormSection.AllInstances.TitleSetString = (_, title) => { sectionTitle = title; };

            // Act
            var result = _testObject.GetPropertyPanel(propdoc.ChildNodes[0], props, new LayoutsPageBase());

            // Assert
            TextBox textBox = null;
            var controls = _privateObject.GetFieldOrProperty(ControlCollectionField) as ArrayList;
            if (controls?.Count > 0)
            {
                textBox = controls[0] as TextBox;
            }
            this.ShouldSatisfyAllConditions(
                () => sectionTitle.ShouldBe(DummyString),
                () => result.Controls.Count.ShouldBe(3),
                () => textBox.ShouldNotBeNull(),
                () => textBox.ID.ShouldBe(DummyString),
                () => textBox.Text.ShouldBe(True));
        }

        [TestMethod]
        public void GetIntegrationHeader_Get_ReturnsHeaderHtml()
        {
            // Arrange, Act
            var result = _testObject.GetIntegrationHeader();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrWhiteSpace(),
                () => result.ShouldContain(_imageAndTitleHtml),
                () => result.ShouldContain(_descriptionHtml));
        }

        private void AppendAttributeToNode(XmlNode node, XmlDocument propdoc, string name, string value)
        {
            var attribute = propdoc.CreateAttribute(name);
            attribute.Value = value;
            node.Attributes.Append(attribute);
        }

        private DataSet GetEmptyDataSet()
        {
            var dataTable = GetDataTable();

            var dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);
            return dataSet;
        }

        private DataSet GetDataSet()
        {
            var dataTable = GetDataTable();
            CreateRowForTable(dataTable);

            var dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);
            return dataSet;
        }

        private static DataTable GetDataTable()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(ModuleIdKey);
            dataTable.Columns.Add(ListIdKey);
            dataTable.Columns.Add(ColIdKey);
            dataTable.Columns.Add(SiteIdKey);
            dataTable.Columns.Add(WebIdKey);
            dataTable.Columns.Add(PriorityKey);
            dataTable.Columns.Add(SitePriorityKey);
            dataTable.Columns.Add(IconKey);
            dataTable.Columns.Add(DescriptionKey);
            dataTable.Columns.Add(Title);
            return dataTable;
        }

        private void CreateRowForTable(DataTable dataTable)
        {
            var row = dataTable.NewRow();
            row[ModuleIdKey] = _guid2;
            row[ListIdKey] = _guid2;
            row[ColIdKey] = One;
            row[SiteIdKey] = _dummyGuid;
            row[WebIdKey] = _dummyGuid;
            row[PriorityKey] = One;
            row[SitePriorityKey] = One;
            row[IconKey] = DummyString;
            row[DescriptionKey] = DummyString;
            row[Title] = DummyString;
            dataTable.Rows.Add(row);
        }

        private void ShimIntegrationCoreMethods()
        {
            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimIntegrationCore.AllInstances.GetDataSetStringHashtable = (a, b, c) => GetDataSet();
            ShimIntegrationCore.AllInstances.ExecuteQueryStringHashtableBoolean = (a, query, props, d) =>
            {
                _queries.Add(query);
                foreach (var key in props.Keys)
                {
                    _queriesParams[key.ToString()] = props[key];
                }
            };
            ShimIntegrationCore.AllInstances.UpdatePriorityNumbersGuid = (_, __) => { };
            ShimIntegrationCore.AllInstances.GetDropDownPropertiesGuidGuidGuidStringString = (a, b, c, d, e, f) => new Dictionary<string, string>
            {
                { True, DummyString }
            };
            ShimIntegrationCore.AllInstances.SavePropertiesGuidHashtable = (_, __, props) => { _propertiesSaved = props; };
        }

        private void ShimSharePointMethods()
        {
            var webShim = new ShimSPWeb();

            var list = ShimSPEventReceiverDefinitionCollectionMethods(webShim.Instance);
            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, AssemblyName, ClassName);
            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, AssemblyName, ClassName);
            list.EventReceivers.Add(SPEventReceiverType.ItemDeleting, AssemblyName, ClassName);

            webShim.ListsGet = () => new ShimSPListCollection
            {
                ItemGetGuid = x => list
            };

            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.AllInstances.WebApplicationGet = _ => new SPWebApplication { Id = _dummyGuid };
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => webShim.Instance;
            ShimSPSite.AllInstances.AllowUnsafeUpdatesSetBoolean = (_, __) => { };
        }

        private ShimSPFieldCollection GetFieldsShim()
        {
            return new ShimSPFieldCollection
            {
                AddStringSPFieldTypeBoolean = (colname, type, required) =>
                {
                    _fields[colname] = GetDefaultSPField(colname, type, required).Instance;
                    return colname;
                },
                GetFieldByInternalNameString = colname => _fields[colname],
                DeleteString = colname => _fields.Remove(colname)
            };
        }

        private ShimSPField GetDefaultSPField(string colname, SPFieldType type, bool required)
        {
            return new ShimSPField
            {
                ColNameGet = () => colname,
                TypeGet = () => type,
                RequiredGet = () => required,
                Update = () => { _fieldUpdated = true; },
                InternalNameGet = () => colname
            };
        }

        private SPList ShimSPEventReceiverDefinitionCollectionMethods(SPWeb parentWeb = null)
        {
            _definitionsList = new List<SPEventReceiverDefinition>();
            var list = new ShimSPList
            {
                EventReceiversGet = () => new ShimSPEventReceiverDefinitionCollection
                {
                    AddSPEventReceiverTypeStringString = (type, assembly, klass) =>
                    {
                        _definitionsList.Add(new ShimSPEventReceiverDefinition
                        {
                            TypeGet = () => type,
                            AssemblyGet = () => assembly,
                            ClassGet = () => klass,
                            Delete = () => _eventsDeleted++
                        });
                    }
                }.Instance,
                FieldsGet = () => GetFieldsShim().Instance,
                Update = () => { _listUpdated = true; },
                ParentWebGet = () => parentWeb
            }.Instance;
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => _definitionsList.GetEnumerator();
            return list;
        }

        private XmlDocument CreateTestDocument(string type)
        {
            var propdoc = new XmlDocument();
            var node = propdoc.CreateNode(XmlNodeType.Element, Root, null);
            propdoc.AppendChild(node);

            var child = propdoc.CreateNode(XmlNodeType.Element, Input, null);
            AppendAttributeToNode(child, propdoc, Property, DummyString);
            AppendAttributeToNode(child, propdoc, Title, DummyString);
            AppendAttributeToNode(child, propdoc, Type, type);
            AppendAttributeToNode(child, propdoc, ParentProperty, DummyString);
            node.AppendChild(child);
            return propdoc;
        }

        private Panel InvokeGetPropertyPanel(string type)
        {
            var propdoc = CreateTestDocument(type);

            var props = new Hashtable();
            props[DummyString] = True;
            ShimTemplateControl.AllInstances.LoadControlString = (_, __) => new StubInputFormSection();

            // Act
            return _testObject.GetPropertyPanel(propdoc.ChildNodes[0], props, new LayoutsPageBase());
        }

        private Panel InvokeGetPropertyPanelSelect()
        {
            var propdoc = CreateTestDocument(SelectType);

            var props = new Hashtable();
            props[DummyString] = True;
            ShimTemplateControl.AllInstances.LoadControlString = (_, __) => new StubInputFormSection();

            var page = new LayoutsPageBase();
            var request = new HttpRequest(string.Empty, ExampleUrl, null);
            ShimHttpRequest.AllInstances.ItemGetString = (_, __) => _dummyGuid.ToString();
            ShimPage.AllInstances.RequestGet = _ => new HttpRequest(string.Empty, ExampleUrl, string.Empty);

            // Act
            return _testObject.GetPropertyPanel(propdoc.ChildNodes[0], props, page);
        }
    }
}
