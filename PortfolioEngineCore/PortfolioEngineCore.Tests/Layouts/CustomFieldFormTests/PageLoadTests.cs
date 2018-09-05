using System;
using System.Data.Fakes;
using System.Reflection;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using WorkEnginePPM.Layouts.ppm.Fakes;

namespace PortfolioEngineCore.Tests.Layouts
{
    public partial class CustomFieldFormTests
    {
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
    }
}