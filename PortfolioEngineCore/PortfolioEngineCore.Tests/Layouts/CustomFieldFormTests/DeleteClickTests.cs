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
        public void Delete_Click()
        {
            // Arrange
            var sender = new object();
            var eventArgs = new EventArgs();
            var txtId = new TextBox {Text = "1"};
            var lblGeneralError = new Label {Visible = false};

            _privateObject.SetField("txtId", txtId);
            _privateObject.SetField("hiddenData", new HiddenField());
            _privateObject.SetField("lblGeneralError", lblGeneralError);
            ShimCustomFieldForm.DeleteCustomFieldDBAccessCustomFieldFormInt32Out = (DBAccess dba, CustomFieldForm Field, out int lRowsAffected) =>
            {
                lRowsAffected = 0;
                return StatusEnum.rsSuccess;
            };

            // Act
            _privateObject.Invoke("btnDelete_Click", BindingFlags.Instance | BindingFlags.NonPublic, sender, eventArgs);

            // Assert
            Assert.IsFalse(lblGeneralError.Visible);
        }

        [TestMethod]
        public void Delete_Click_Cannot_Open()
        {
            // Arrange
            var sender = new object();
            var eventArgs = new EventArgs();
            var txtId = new TextBox
            {
                Text = "1"
            };
            var lblGeneralError = new Label
            {
                Visible = false
            };

            _privateObject.SetField("txtId", txtId);
            _privateObject.SetField("hiddenData", new HiddenField());
            _privateObject.SetField("lblGeneralError", lblGeneralError);

            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsServerError;
            ShimSqlDb.AllInstances.FormatErrorText = _ => "FormatErrorText";
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsServerError;

            // Act
            _privateObject.Invoke("btnDelete_Click", BindingFlags.Instance | BindingFlags.NonPublic, sender, eventArgs);

            // Assert
            Assert.AreEqual("FormatErrorText", lblGeneralError.Text);
            Assert.IsTrue(lblGeneralError.Visible);
        }

        [TestMethod]
        public void Delete_Click_Failed()
        {
            // Arrange
            var sender = new object();
            var eventArgs = new EventArgs();
            var txtId = new TextBox {Text = "1"};
            var lblGeneralError = new Label {Visible = false};

            _privateObject.SetField("txtId", txtId);
            _privateObject.SetField("hiddenData", new HiddenField());
            _privateObject.SetField("lblGeneralError", lblGeneralError);
            ShimCustomFieldForm.DeleteCustomFieldDBAccessCustomFieldFormInt32Out = (DBAccess dba, CustomFieldForm Field, out int lRowsAffected) =>
            {
                lRowsAffected = 0;
                return StatusEnum.rsServerError;
            };

            // Act
            _privateObject.Invoke("btnDelete_Click", BindingFlags.Instance | BindingFlags.NonPublic, sender, eventArgs);

            // Assert
            Assert.AreEqual("DELETE FAILED!", lblGeneralError.Text);
            Assert.IsTrue(lblGeneralError.Visible);
        }
    }
}