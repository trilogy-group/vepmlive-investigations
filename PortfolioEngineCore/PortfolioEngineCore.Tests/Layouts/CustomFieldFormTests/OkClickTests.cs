using System;
using System.Reflection;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using WorkEnginePPM.Layouts.ppm;
using WorkEnginePPM.Layouts.ppm.Fakes;

namespace PortfolioEngineCore.Tests.Layouts
{
    public partial class CustomFieldFormTests
    {
        [TestMethod]
        public void OK_Click()
        {
            // Arrange
            var sender = new object();
            var eventArgs = new EventArgs();
            var txtId = new TextBox {Text = "1"};
            var txtName = new TextBox {Text = "name"};
            var txtDesc = new TextBox {Text = "desc"};
            var ddlEntity = new DropDownList {SelectedValue = "1"};
            var ddlFieldType = new DropDownList {SelectedValue = "1"};

            var lblGeneralError = new Label {Visible = false};

            _privateObject.SetField("txtId", txtId);
            _privateObject.SetField("txtName", txtName);
            _privateObject.SetField("txtDesc", txtDesc);
            _privateObject.SetField("ddlEntity", ddlEntity);
            _privateObject.SetField("ddlFieldType", ddlFieldType);
            _privateObject.SetField("hiddenData", new HiddenField());
            _privateObject.SetField("lblGeneralError", lblGeneralError);
            ShimCustomFieldForm.UpdateCustomFieldDBAccessCustomFieldFormInt32Out = (DBAccess dba, CustomFieldForm Field, out int lRowsAffected) =>
            {
                lRowsAffected = 0;
                return StatusEnum.rsSuccess;
            };

            // Act
            _privateObject.Invoke("btnOK_Click", BindingFlags.Instance | BindingFlags.NonPublic, sender, eventArgs);

            // Assert
            Assert.IsFalse(lblGeneralError.Visible);
        }

        [TestMethod]
        public void OK_Click_Name_cannot_be_blank()
        {
            // Arrange
            var sender = new object();
            var eventArgs = new EventArgs();
            var txtId = new TextBox {Text = "1"};
            var txtName = new TextBox {Text = string.Empty};
            var txtDesc = new TextBox {Text = "desc"};
            var ddlEntity = new DropDownList {SelectedValue = "1"};
            var ddlFieldType = new DropDownList {SelectedValue = "1"};
            var lblGeneralError = new Label {Visible = false};
            _privateObject.SetField("txtId", txtId);
            _privateObject.SetField("txtName", txtName);
            _privateObject.SetField("txtDesc", txtDesc);
            _privateObject.SetField("ddlEntity", ddlEntity);
            _privateObject.SetField("ddlFieldType", ddlFieldType);
            _privateObject.SetField("hiddenData", new HiddenField());
            _privateObject.SetField("lblGeneralError", lblGeneralError);

            // Act
            _privateObject.Invoke("btnOK_Click", BindingFlags.Instance | BindingFlags.NonPublic, sender, eventArgs);

            // Assert
            Assert.IsTrue(lblGeneralError.Visible);
            Assert.AreEqual("Error Saving Field : Name cannot be blank", lblGeneralError.Text);
        }

        [TestMethod]
        public void OK_Click_Cannot_Open()
        {
            // Arrange
            var sender = new object();
            var eventArgs = new EventArgs();
            var txtId = new TextBox {Text = "1"};
            var txtName = new TextBox {Text = "name"};
            var txtDesc = new TextBox {Text = "desc"};
            var ddlEntity = new DropDownList {SelectedValue = "1"};
            var ddlFieldType = new DropDownList {SelectedValue = "1"};
            var lblGeneralError = new Label {Visible = false};

            _privateObject.SetField("txtId", txtId);
            _privateObject.SetField("txtName", txtName);
            _privateObject.SetField("txtDesc", txtDesc);
            _privateObject.SetField("ddlEntity", ddlEntity);
            _privateObject.SetField("ddlFieldType", ddlFieldType);
            _privateObject.SetField("hiddenData", new HiddenField());
            _privateObject.SetField("lblGeneralError", lblGeneralError);

            ShimCustomFieldForm.UpdateCustomFieldDBAccessCustomFieldFormInt32Out = (DBAccess dba, CustomFieldForm Field, out int lRowsAffected) =>
            {
                lRowsAffected = 0;
                return StatusEnum.rsSuccess;
            };

            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsServerError;
            ShimSqlDb.AllInstances.FormatErrorText = _ => "FormatErrorText";
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsServerError;

            // Act
            _privateObject.Invoke("btnOK_Click", BindingFlags.Instance | BindingFlags.NonPublic, sender, eventArgs);

            // Assert
            Assert.AreEqual("FormatErrorText", lblGeneralError.Text);
            Assert.IsTrue(lblGeneralError.Visible);
        }

        [TestMethod]
        public void OK_Click_Failed()
        {
            // Arrange
            var sender = new object();
            var eventArgs = new EventArgs();
            var txtId = new TextBox {Text = "1"};
            var txtName = new TextBox {Text = "name"};
            var txtDesc = new TextBox {Text = "desc"};
            var ddlEntity = new DropDownList {SelectedValue = "1"};
            var ddlFieldType = new DropDownList {SelectedValue = "1"};
            var lblGeneralError = new Label {Visible = false};

            _privateObject.SetField("txtId", txtId);
            _privateObject.SetField("txtName", txtName);
            _privateObject.SetField("txtDesc", txtDesc);
            _privateObject.SetField("ddlEntity", ddlEntity);
            _privateObject.SetField("ddlFieldType", ddlFieldType);
            _privateObject.SetField("hiddenData", new HiddenField());
            _privateObject.SetField("lblGeneralError", lblGeneralError);

            ShimCustomFieldForm.UpdateCustomFieldDBAccessCustomFieldFormInt32Out = (DBAccess dba, CustomFieldForm Field, out int lRowsAffected) =>
            {
                lRowsAffected = 0;
                return StatusEnum.rsServerError;
            };
            ShimSqlDb.AllInstances.FormatErrorText = _ => "FormatErrorText";
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsServerError;

            // Act
            _privateObject.Invoke("btnOK_Click", BindingFlags.Instance | BindingFlags.NonPublic, sender, eventArgs);

            // Assert
            Assert.AreEqual("FormatErrorText", lblGeneralError.Text);
            Assert.IsTrue(lblGeneralError.Visible);
        }
    }
}