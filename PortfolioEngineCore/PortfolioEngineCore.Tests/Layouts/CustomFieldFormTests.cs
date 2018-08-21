using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using System.Reflection;
using System.Web;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using EPMLive.TestFakes.Utility;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using PPM.Fakes;
using WorkEnginePPM.Fakes;
using WorkEnginePPM.Layouts.ppm;
using WorkEnginePPM.Layouts.ppm.Fakes;

namespace PortfolioEngineCore.Tests.Layouts
{
    [TestClass]
    public class CustomFieldFormTests
    {
        private const string UpdatecustomfieldMethod = "UpdateCustomField";
        private IDisposable _shimContext;
        private bool _readFirstCall;
        private PrivateObject _privateObject;
        private AdoShims _shimAdoNetCalls;
        private NameValueCollection _valueCollection;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            _shimAdoNetCalls = AdoShims.ShimAdoNetCalls();

            _privateObject = new PrivateObject(typeof(CustomFieldForm));
            _readFirstCall = true;

            ArrangeShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
        }

        [TestMethod]
        public void UpdateCustomField_When_Field_Exist()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            var lRowsAffected = 0;
            
            // Act
            var actualStatus = _privateObject.Invoke(
                UpdatecustomfieldMethod,
                BindingFlags.Static | BindingFlags.NonPublic,
                dba,
                new ShimCustomFieldForm().Instance,
                lRowsAffected);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actualStatus);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("SELECT FA_FIELD_ID From EPGC_FIELD_ATTRIBS WHERE FA_NAME = @FIELD_NAME", list[0].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("SELECT FA_FIELD_ID From EPGC_FIELD_ATTRIBS WHERE FA_NAME = @FIELD_NAME", list[0].CommandText);

            Assert.AreEqual(_shimAdoNetCalls.CommandsCreated.Count, _shimAdoNetCalls.CommandsDisposed.Count);
        }

        [TestMethod]
        public void UpdateCustomField_When_FieldId_Not_Zero()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            var lRowsAffected = 0;
            ShimCustomFieldForm.AllInstances.idGet = _ => 1;

            // Act
            var actualStatus = _privateObject.Invoke(
                UpdatecustomfieldMethod,
                BindingFlags.Static | BindingFlags.NonPublic,
                dba,
                new ShimCustomFieldForm().Instance,
                lRowsAffected);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actualStatus);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("SELECT FA_FIELD_ID From EPGC_FIELD_ATTRIBS WHERE FA_NAME = @FIELD_NAME", list[0].CommandText);
            Assert.AreEqual("UPDATE EPGC_FIELD_ATTRIBS  SET FA_NAME=@pNAME,FA_DESC=@pDESC WHERE FA_FIELD_ID = 1", list[1].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("SELECT FA_FIELD_ID From EPGC_FIELD_ATTRIBS WHERE FA_NAME = @FIELD_NAME", list[0].CommandText);
            Assert.AreEqual("UPDATE EPGC_FIELD_ATTRIBS  SET FA_NAME=@pNAME,FA_DESC=@pDESC WHERE FA_FIELD_ID = 1", list[1].CommandText);

            Assert.AreEqual(_shimAdoNetCalls.CommandsCreated.Count, _shimAdoNetCalls.CommandsDisposed.Count);
        }

        [TestMethod]
        public void UpdateCustomField_When_FieldId_Zero()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            var lRowsAffected = 0;
            ShimCustomFieldForm.AllInstances.idGet = _ => 0;
            ShimCustomFieldForm.AllInstances.EntityGet = _ => (int)EntityID.Resource;
            ShimCustomFieldForm.AllInstances.DataTypeGet = _ => (int)FieldType.TypeNumber;
            ShimSqlDb.ReadIntValueObject = o => 0;

            // Act
            var actualStatus = _privateObject.Invoke(
                UpdatecustomfieldMethod,
                BindingFlags.Static | BindingFlags.NonPublic,
                dba,
                new ShimCustomFieldForm().Instance,
                lRowsAffected);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actualStatus);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("SELECT FA_FIELD_ID From EPGC_FIELD_ATTRIBS WHERE FA_NAME = @FIELD_NAME", list[0].CommandText);
            Assert.AreEqual("SELECT FA_FIELD_IN_TABLE FROM EPGC_FIELD_ATTRIBS Where FA_TABLE_ID=103", list[1].CommandText);
            Assert.AreEqual("INSERT Into EPGC_FIELD_ATTRIBS  (FA_NAME,FA_DESC,FA_FORMAT,FA_TABLE_ID,FA_FIELD_IN_TABLE) Values(@pNAME,@pDESC,@pFORMAT,@pTABLE,@pFIELD)", list[2].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("SELECT FA_FIELD_ID From EPGC_FIELD_ATTRIBS WHERE FA_NAME = @FIELD_NAME", list[0].CommandText);
            Assert.AreEqual("SELECT FA_FIELD_IN_TABLE FROM EPGC_FIELD_ATTRIBS Where FA_TABLE_ID=103", list[1].CommandText);
            Assert.AreEqual("INSERT Into EPGC_FIELD_ATTRIBS  (FA_NAME,FA_DESC,FA_FORMAT,FA_TABLE_ID,FA_FIELD_IN_TABLE) Values(@pNAME,@pDESC,@pFORMAT,@pTABLE,@pFIELD)", list[2].CommandText);

            Assert.AreEqual(_shimAdoNetCalls.CommandsCreated.Count, _shimAdoNetCalls.CommandsDisposed.Count);
        }

        [TestMethod]
        public void Page_Load_Invalid_field_selected()
        {
            // Arrange
            var sender = new object();
            var eventArgs = new EventArgs();
            var lblGeneralError = new Label();
            _privateObject.SetField("ddlEntity", new DropDownList());
            _privateObject.SetField("ddlFieldType", new DropDownList());
            _privateObject.SetField("hiddenData", new HiddenField());
            _privateObject.SetField("lblGeneralError", lblGeneralError);

            // Act
            _privateObject.Invoke("Page_Load", BindingFlags.Instance | BindingFlags.NonPublic, sender, eventArgs);

            // Assert
            Assert.AreEqual("Invalid field selected", lblGeneralError.Text);
            Assert.IsTrue(lblGeneralError.Visible);
        }

        [TestMethod]
        public void Page_Load_Invalid_field_selected_When_Id_Is_Negative()
        {
            // Arrange
            var sender = new object();
            var eventArgs = new EventArgs();
            var lblGeneralError = new Label();
            _privateObject.SetField("ddlEntity", new DropDownList());
            _privateObject.SetField("ddlFieldType", new DropDownList());
            _privateObject.SetField("hiddenData", new HiddenField());
            _privateObject.SetField("lblGeneralError", lblGeneralError);

            _valueCollection["id"] = "-1";

            // Act
            _privateObject.Invoke("Page_Load", BindingFlags.Instance | BindingFlags.NonPublic, sender, eventArgs);

            // Assert
            Assert.AreEqual("Invalid field selected", lblGeneralError.Text);
            Assert.IsTrue(lblGeneralError.Visible);
        }

        [TestMethod]
        public void Page_Load_When_Cannot_Open()
        {
            // Arrange
            var sender = new object();
            var eventArgs = new EventArgs();
            var lblGeneralError = new Label();
            _privateObject.SetField("ddlEntity", new DropDownList());
            _privateObject.SetField("ddlFieldType", new DropDownList());
            _privateObject.SetField("hiddenData", new HiddenField());
            _privateObject.SetField("lblGeneralError", lblGeneralError);

            _valueCollection["id"] = "1";
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsServerError;
            ShimSqlDb.AllInstances.FormatErrorText = _ => "FormatErrorText";

            // Act
            _privateObject.Invoke("Page_Load", BindingFlags.Instance | BindingFlags.NonPublic, sender, eventArgs);

            // Assert
            Assert.AreEqual("FormatErrorText", lblGeneralError.Text);
            Assert.IsTrue(lblGeneralError.Visible);
        }

        [TestMethod]
        public void Page_Load_When_Mode_Can_Delete()
        {
            // Arrange
            var sender = new object();
            var eventArgs = new EventArgs();
            var lblGeneralError = new Label();
            var btnOK = new Button();
            var btnDelete = new Button();
            var txtId = new TextBox();
            var txtName = new TextBox();
            var txtDesc = new TextBox();

            _privateObject.SetField("ddlEntity", new DropDownList());
            _privateObject.SetField("ddlFieldType", new DropDownList());
            _privateObject.SetField("hiddenData", new HiddenField());
            _privateObject.SetField("lblGeneralError", lblGeneralError);
            _privateObject.SetField("btnOK", btnOK);
            _privateObject.SetField("btnDelete", btnDelete);
            _privateObject.SetField("txtName", new TextBox());
            _privateObject.SetField("txtId", txtId);
            _privateObject.SetField("txtName", txtName);
            _privateObject.SetField("txtDesc", txtDesc);

            _valueCollection["id"] = "1";
            _valueCollection["mode"] = "Delete";

            ShimDataRow.AllInstances.ItemGetString = (a, key) =>
            {
                switch (key)
                {
                    case "FA_FIELD_ID":
                        return "id";
                    case "FA_NAME":
                        return "name";
                    case "FA_DESC":
                        return "desc";
                    default:
                        return string.Empty;
                }
            };

            ShimCustomFieldForm.CanDeleteCustomFieldDBAccessInt32StringOut = (DBAccess dba, int nField, out string message) =>
            {
                message = "delete message1";
                return true;
            };

            ShimCustomFieldForm.CheckDeleteCustomFieldDBAccessInt32StringOut = (DBAccess dba, int nField, out string message) =>
            {
                message = "delete message2";
                return true;
            };

            // Act
            _privateObject.Invoke("Page_Load", BindingFlags.Instance | BindingFlags.NonPublic, sender, eventArgs);
            var dialogTitle = _privateObject.GetField("DialogTitle", BindingFlags.Instance | BindingFlags.NonPublic);

            // Assert
            Assert.AreEqual("delete message2", lblGeneralError.Text);
            Assert.IsTrue(lblGeneralError.Visible);

            Assert.AreEqual("Delete Custom Field", dialogTitle);
            Assert.IsFalse(btnOK.Visible);
            Assert.IsTrue(btnDelete.Visible);
            Assert.AreEqual(txtId.Text, "id");
            Assert.AreEqual(txtName.Text, "name");
            Assert.AreEqual(txtDesc.Text, "desc");

            var list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("SELECT * FROM EPGC_FIELD_ATTRIBS WHERE FA_FIELD_ID = @p1", list[0].CommandText);
        }

        [TestMethod]
        public void Page_Load_When_Mode_Can_Not_Delete()
        {
            // Arrange
            var sender = new object();
            var eventArgs = new EventArgs();
            var lblGeneralError = new Label();
            var btnOK = new Button();
            var btnDelete = new Button();
            var txtId = new TextBox();
            var txtName = new TextBox();
            var txtDesc = new TextBox();

            _privateObject.SetField("ddlEntity", new DropDownList());
            _privateObject.SetField("ddlFieldType", new DropDownList());
            _privateObject.SetField("hiddenData", new HiddenField());
            _privateObject.SetField("lblGeneralError", lblGeneralError);
            _privateObject.SetField("btnOK", btnOK);
            _privateObject.SetField("btnDelete", btnDelete);
            _privateObject.SetField("txtName", new TextBox());
            _privateObject.SetField("txtId", txtId);
            _privateObject.SetField("txtName", txtName);
            _privateObject.SetField("txtDesc", txtDesc);

            _valueCollection["id"] = "1";
            _valueCollection["mode"] = "Delete";

            ShimDataRow.AllInstances.ItemGetString = (a, key) =>
            {
                switch (key)
                {
                    case "FA_FIELD_ID":
                        return "id";
                    case "FA_NAME":
                        return "name";
                    case "FA_DESC":
                        return "desc";
                    default:
                        return string.Empty;
                }
            };

            ShimCustomFieldForm.CanDeleteCustomFieldDBAccessInt32StringOut = (DBAccess dba, int nField, out string message) =>
            {
                message = "delete message1";
                return false;
            };

            ShimCustomFieldForm.CheckDeleteCustomFieldDBAccessInt32StringOut = (DBAccess dba, int nField, out string message) =>
            {
                message = "delete message2";
                return true;
            };

            // Act
            _privateObject.Invoke("Page_Load", BindingFlags.Instance | BindingFlags.NonPublic, sender, eventArgs);
            var dialogTitle = _privateObject.GetField("DialogTitle", BindingFlags.Instance | BindingFlags.NonPublic);

            // Assert
            Assert.AreEqual("delete message1", lblGeneralError.Text);
            Assert.IsTrue(lblGeneralError.Visible);

            Assert.AreEqual("Delete Custom Field", dialogTitle);
            Assert.IsFalse(btnOK.Visible);
            Assert.IsFalse(btnDelete.Visible);
            Assert.AreEqual(txtId.Text, "id");
            Assert.AreEqual(txtName.Text, "name");
            Assert.AreEqual(txtDesc.Text, "desc");

            var list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("SELECT * FROM EPGC_FIELD_ATTRIBS WHERE FA_FIELD_ID = @p1", list[0].CommandText);
        }

        [TestMethod]
        public void Page_Load_When_Mode_Add()
        {
            // Arrange
            var sender = new object();
            var eventArgs = new EventArgs();
            var lblGeneralError = new Label();
            var btnOK = new Button();
            var btnDelete = new Button();
            var txtName = new TextBox();
            var txtId = new TextBox();

            _privateObject.SetField("ddlEntity", new DropDownList());
            _privateObject.SetField("ddlFieldType", new DropDownList());
            _privateObject.SetField("hiddenData", new HiddenField());
            _privateObject.SetField("lblGeneralError", lblGeneralError);
            _privateObject.SetField("btnOK", btnOK);
            _privateObject.SetField("btnDelete", btnDelete);
            _privateObject.SetField("txtId", txtId);
            _privateObject.SetField("txtName", txtName);

            _valueCollection["id"] = "1";
            _valueCollection["mode"] = "Add";

            // Act
            _privateObject.Invoke("Page_Load", BindingFlags.Instance | BindingFlags.NonPublic, sender, eventArgs);
            var dialogTitle = _privateObject.GetField("DialogTitle", BindingFlags.Instance | BindingFlags.NonPublic);

            // Assert
            Assert.AreEqual("Add a new Custom Field", dialogTitle);
            Assert.IsTrue(btnOK.Visible);
            Assert.IsFalse(btnDelete.Visible);

            Assert.AreEqual("0", txtId.Text);
            Assert.AreEqual("New Custom Field", txtName.Text);
        }

        [TestMethod]
        public void Page_Load_When_Mode_Modify()
        {
            // Arrange
            var sender = new object();
            var eventArgs = new EventArgs();
            var lblGeneralError = new Label();
            var btnOK = new Button();
            var btnDelete = new Button();
            var txtId = new TextBox();
            var txtName = new TextBox();
            var txtDesc = new TextBox();

            _privateObject.SetField("ddlEntity", new DropDownList());
            _privateObject.SetField("ddlFieldType", new DropDownList());
            _privateObject.SetField("hiddenData", new HiddenField());
            _privateObject.SetField("lblGeneralError", lblGeneralError);
            _privateObject.SetField("btnOK", btnOK);
            _privateObject.SetField("btnDelete", btnDelete);
            _privateObject.SetField("txtId", txtId);
            _privateObject.SetField("txtName", txtName);
            _privateObject.SetField("txtDesc", txtDesc);

            _valueCollection["id"] = "1";
            _valueCollection["mode"] = "Modify";

            ShimDataRow.AllInstances.ItemGetString = (a, key) =>
            {
                switch (key)
                {
                    case "FA_FIELD_ID":
                        return "id";
                    case "FA_NAME":
                        return "name";
                    case "FA_DESC":
                        return "desc";
                    default:
                        return string.Empty;
                }
            };

            // Act
            _privateObject.Invoke("Page_Load", BindingFlags.Instance | BindingFlags.NonPublic, sender, eventArgs);
            var dialogTitle = _privateObject.GetField("DialogTitle", BindingFlags.Instance | BindingFlags.NonPublic);

            // Assert
            Assert.AreEqual("Modify Custom Field", dialogTitle);
            Assert.IsTrue(btnOK.Visible);
            Assert.IsFalse(btnDelete.Visible);
            Assert.AreEqual(txtId.Text, "id");
            Assert.AreEqual(txtName.Text, "name");
            Assert.AreEqual(txtDesc.Text, "desc");

            var list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("SELECT * FROM EPGC_FIELD_ATTRIBS WHERE FA_FIELD_ID = @p1", list[0].CommandText);
        }

        private void ArrangeShims()
        {
            ShimSqlDataReader.AllInstances.Read = reader =>
            {
                if (_readFirstCall)
                {
                    _readFirstCall = false;
                    return true;
                }
                return false;
            };
            ShimSqlDataReader.AllInstances.Close = reader => { _readFirstCall = true; };
            ShimDbDataReader.AllInstances.Dispose = reader => { _readFirstCall = true; };

            ShimSqlDb.ReadIntValueObject = o => 1;
            ShimSqlDb.ReadStringValueObject = o => "string";
            ShimSqlDb.ReadDoubleValueObject = o => 1.0;

            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = (SqlDb a, string b, StatusEnum c, out DataTable table) =>
            {
                table = new ShimDataTable().Instance;
                return StatusEnum.rsSuccess;
            };

            ShimDataTable.AllInstances.ColumnsGet = _ => new ShimDataColumnCollection();

            ShimInternalDataCollectionBase.AllInstances.GetEnumerator = _ =>
            {
                var list = new List<DataColumn>
                {
                    new ShimDataColumn().Instance
                };
                return list.GetEnumerator();
            };

            ShimDataColumn.AllInstances.ColumnNameGet = _ => "RC_001";
            
            _valueCollection = new NameValueCollection
            {
                ["id"] = string.Empty,
                ["mode"] = string.Empty
            };
            ShimHttpRequest.AllInstances.QueryStringGet = _ => _valueCollection;
            
            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", string.Empty);

            ShimWebAdmin.GetBasePath = () => string.Empty;
            ShimWebAdmin.GetConnectionString = () => string.Empty;

            ShimDBAccess.ConstructorString = (a, b) => { };
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsSuccess;

            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection();
            ShimDataRowCollection.AllInstances.CountGet = _ => 1;
            ShimDataRowCollection.AllInstances.ItemGetInt32 = (a, b) => new ShimDataRow();            
        }
    }
}
