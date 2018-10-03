using System;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Web;
using System.Web.UI.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests
{
    public partial class ListDisplaySettingIteratorTests
    {
        private const string OnInitMethod = "OnInit";
        private const string IsWorkListField = "isWorkList";
        private const string IsFeatureActivatedField = "isFeatureActivated";
        private const string OwnerNameField = "ownername";
        private const string OwnerUserNameField = "ownerusername";

        [TestMethod]
        public void OnInit_isFeatureActivated_False()
        {
            // Arrange
            
            // Act
            _privateObject.Invoke(OnInitMethod, new EventArgs());
            var actual = (bool)_privateObject.GetField(IsFeatureActivatedField);

            // Assert
            Assert.IsFalse(actual);            
        }

        [TestMethod]
        public void OnInit_With_isFeatureActivated()
        {
            // Arrange
            const string OwnerName = "OwnerName";
            const string OwnerUserName = "OwnerUserName";
            ShimSPFeatureCollection.AllInstances.ItemGetGuid = (a, guid) =>
                guid == new Guid("e97da3cd-4c42-44cd-ba51-2bfbb2c397cb") ||
                guid == new Guid("19e6ae14-9e68-44fa-9a08-c1c4514bf12e")
                ? new ShimSPFeature()
                : null;

            ShimDataRow.AllInstances.ItemGetInt32 = (a, b) => "3";
            ShimSqlDataReader.AllInstances.GetStringInt32 = (a, index) =>
            {
                switch (index)
                {
                    case 5: return OwnerName;
                    case 13: return OwnerUserName;
                    default: return string.Empty;
                }
            };

            // Act
            _privateObject.Invoke(OnInitMethod, new EventArgs());
            var isFeatureActivated = (bool)_privateObject.GetField(IsFeatureActivatedField);
            var isWorkList = (bool)_privateObject.GetField(IsWorkListField);
            var ownername = (string)_privateObject.GetField(OwnerNameField);
            var ownerusername = (string)_privateObject.GetField(OwnerUserNameField);

            // Assert
            Assert.IsTrue(isFeatureActivated);
            Assert.IsNotNull(isFeatureActivated);
            Assert.IsTrue(isWorkList);
            Assert.AreEqual(OwnerName, ownername);
            Assert.AreEqual(OwnerUserName, ownerusername);

            OnInitAdoAssert();
        }

        [TestMethod]
        public void OnInit_With_isFeatureActivated_And_isDlg()
        {
            // Arrange
            const string OwnerName = "OwnerName";
            const string OwnerUserName = "OwnerUserName";
            ShimSPFeatureCollection.AllInstances.ItemGetGuid = (a, guid) =>
                guid == new Guid("e97da3cd-4c42-44cd-ba51-2bfbb2c397cb") ||
                guid == new Guid("19e6ae14-9e68-44fa-9a08-c1c4514bf12e")
                ? new ShimSPFeature()
                : null;

            ShimGridGanttSettings.ConstructorSPList = (settings, b) =>
            {
                settings.DisplaySettings = "boo";
                settings.EnableWorkList = true;
                settings.DisplayFormRedirect = true;
            };

            ShimSPFormContext.AllInstances.FormModeGet = _ => SPControlMode.New;
            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", "IsDlg=0");
            ShimDataRow.AllInstances.ItemGetInt32 = (a, b) => "3";
            ShimSqlDataReader.AllInstances.GetStringInt32 = (a, index) =>
            {
                switch (index)
                {
                    case 5: return OwnerName;
                    case 13: return OwnerUserName;
                    default: return string.Empty;
                }
            };

            // Act
            _privateObject.Invoke(OnInitMethod, new EventArgs());
            var isFeatureActivated = (bool)_privateObject.GetField(IsFeatureActivatedField);
            var isWorkList = (bool)_privateObject.GetField(IsWorkListField);
            var ownername = (string)_privateObject.GetField(OwnerNameField);
            var ownerusername = (string)_privateObject.GetField(OwnerUserNameField);

            // Assert
            Assert.IsTrue(isFeatureActivated);
            Assert.IsNotNull(isFeatureActivated);
            Assert.IsTrue(isWorkList);
            Assert.AreEqual(OwnerName, ownername);
            Assert.AreEqual(OwnerUserName, ownerusername);

            OnInitAdoAssert();
        }

        [TestMethod]
        public void OnInit_With_isFeatureActivated_And_ActivationType_1()
        {
            // Arrange
            ShimSPFeatureCollection.AllInstances.ItemGetGuid = (a, guid) =>
                guid == new Guid("e97da3cd-4c42-44cd-ba51-2bfbb2c397cb") ||
                guid == new Guid("19e6ae14-9e68-44fa-9a08-c1c4514bf12e")
                ? new ShimSPFeature()
                : null;

            ShimDataRow.AllInstances.ItemGetInt32 = (a, b) => "0";
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (a, b) => 1;

            // Act
            _privateObject.Invoke(OnInitMethod, new EventArgs());
            var isFeatureActivated = (bool)_privateObject.GetField(IsFeatureActivatedField);
            var isWorkList = (bool)_privateObject.GetField(IsWorkListField);
            var barcolor = (string)_privateObject.GetField("barcolor");

            // Assert
            Assert.IsTrue(isFeatureActivated);
            Assert.IsNotNull(isFeatureActivated);
            Assert.IsTrue(isWorkList);
            Assert.AreEqual("FF0000", barcolor);

            OnInitAdoAssert();
        }

        [TestMethod]
        public void OnInit_With_isFeatureActivated_And_ActivationType_2()
        {
            // Arrange
            ShimSPFeatureCollection.AllInstances.ItemGetGuid = (a, guid) =>
                guid == new Guid("e97da3cd-4c42-44cd-ba51-2bfbb2c397cb") ||
                guid == new Guid("19e6ae14-9e68-44fa-9a08-c1c4514bf12e")
                ? new ShimSPFeature()
                : null;

            ShimDataRow.AllInstances.ItemGetInt32 = (a, b) => "0";
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (a, index) => index == 0 ? 3 : 1;

            // Act
            _privateObject.Invoke(OnInitMethod, new EventArgs());
            var isFeatureActivated = (bool)_privateObject.GetField(IsFeatureActivatedField);
            var isWorkList = (bool)_privateObject.GetField(IsWorkListField);
            var barcolor = (string)_privateObject.GetField("barcolor");

            // Assert
            Assert.IsTrue(isFeatureActivated);
            Assert.IsNotNull(isFeatureActivated);
            Assert.IsTrue(isWorkList);
            Assert.AreEqual("FFFF00", barcolor);

            OnInitAdoAssert();
        }

        [TestMethod]
        public void OnInit_With_isFeatureActivated_And_ActivationType_3()
        {
            // Arrange
            ShimSPFeatureCollection.AllInstances.ItemGetGuid = (a, guid) =>
                guid == new Guid("e97da3cd-4c42-44cd-ba51-2bfbb2c397cb") ||
                guid == new Guid("19e6ae14-9e68-44fa-9a08-c1c4514bf12e")
                ? new ShimSPFeature()
                : null;

            ShimDataRow.AllInstances.ItemGetInt32 = (a, b) => "0";
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (a, index) => index == 0 ? 10 : 1;

            // Act
            _privateObject.Invoke(OnInitMethod, new EventArgs());
            var isFeatureActivated = (bool)_privateObject.GetField(IsFeatureActivatedField);
            var isWorkList = (bool)_privateObject.GetField(IsWorkListField);
            var barcolor = (string)_privateObject.GetField("barcolor");

            // Assert
            Assert.IsTrue(isFeatureActivated);
            Assert.IsNotNull(isFeatureActivated);
            Assert.IsTrue(isWorkList);
            Assert.AreEqual("009900", barcolor);

            OnInitAdoAssert();
        }

        [TestMethod]
        public void OnInit_With_isFeatureActivated_And_FormMode_New()
        {
            // Arrange
            const string OwnerName = "OwnerName";
            const string OwnerUserName = "OwnerUserName";
            const string LookupField = "LookupField";
            const string LookupValue = "LookupValue";
            ShimSPFeatureCollection.AllInstances.ItemGetGuid = (a, guid) =>
                guid == new Guid("e97da3cd-4c42-44cd-ba51-2bfbb2c397cb") || 
                guid == new Guid("19e6ae14-9e68-44fa-9a08-c1c4514bf12e")
                ? new ShimSPFeature()
                : null;

            ShimSPFormContext.AllInstances.FormModeGet = _ => SPControlMode.New;
            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", $"LookupField={LookupField}&LookupValue={LookupValue}");
            ShimDataRow.AllInstances.ItemGetInt32 = (a, b) => "3";
            ShimSqlDataReader.AllInstances.GetStringInt32 = (a, index) =>
            {
                switch (index)
                {
                    case 5: return OwnerName;
                    case 13: return OwnerUserName;
                    default: return string.Empty;
                }
            };

            // Act
            _privateObject.Invoke(OnInitMethod, new EventArgs());
            var isFeatureActivated = (bool)_privateObject.GetField(IsFeatureActivatedField);
            var isWorkList = (bool)_privateObject.GetField(IsWorkListField);
            var ownername = (string)_privateObject.GetField(OwnerNameField);
            var ownerusername = (string)_privateObject.GetField(OwnerUserNameField);
            
            // Assert
            Assert.IsTrue(isFeatureActivated);
            Assert.IsNotNull(isFeatureActivated);
            Assert.IsTrue(isWorkList);
            Assert.AreEqual(OwnerName, ownername);
            Assert.AreEqual(OwnerUserName, ownerusername);

            OnInitAdoAssert();
        }

        [TestMethod]
        public void OnInit_With_isFeatureActivated_And_FormMode_Edit()
        {
            // Arrange
            const string OwnerName = "OwnerName";
            const string OwnerUserName = "OwnerUserName";
            const string LookupField = "LookupField";
            const string LookupValue = "LookupValue";
            ShimSPFeatureCollection.AllInstances.ItemGetGuid = (a, guid) =>
                guid == new Guid("e97da3cd-4c42-44cd-ba51-2bfbb2c397cb") ||
                guid == new Guid("19e6ae14-9e68-44fa-9a08-c1c4514bf12e")
                ? new ShimSPFeature()
                : null;

            ShimSPFormContext.AllInstances.FormModeGet = _ => SPControlMode.New;
            ShimPage.AllInstances.RequestGet = page => new HttpRequest(
                string.Empty,
                "http://site.com",
                $"LookupField={LookupField}&LookupValue={LookupValue}&Mode=Upload");

            ShimDataRow.AllInstances.ItemGetInt32 = (a, b) => "3";
            ShimSqlDataReader.AllInstances.GetStringInt32 = (a, index) =>
            {
                switch (index)
                {
                    case 5: return OwnerName;
                    case 13: return OwnerUserName;
                    default: return string.Empty;
                }
            };

            // Act
            _privateObject.Invoke(OnInitMethod, new EventArgs());
            var isFeatureActivated = (bool)_privateObject.GetField(IsFeatureActivatedField);
            var isWorkList = (bool)_privateObject.GetField(IsWorkListField);
            var ownername = (string)_privateObject.GetField(OwnerNameField);
            var ownerusername = (string)_privateObject.GetField(OwnerUserNameField);
            
            // Assert
            Assert.IsTrue(isFeatureActivated);
            Assert.IsNotNull(isFeatureActivated);
            Assert.IsTrue(isWorkList);
            Assert.AreEqual(OwnerName, ownername);
            Assert.AreEqual(OwnerUserName, ownerusername);

            OnInitAdoAssert();
        }

        private void OnInitAdoAssert()
        {
            Assert.AreEqual(2, _adoShims.CommandsCreated.Count);

            var list = _adoShims.CommandsCreated;
            Assert.AreEqual("2012SP_GetActivationInfo", list[0].CommandText);
            Assert.AreEqual("2010SP_GetSiteAccountNums", list[1].CommandText);

            Assert.AreEqual(1, _adoShims.DataAdaptersCreated.Count);
            list = _adoShims.DataAdaptersCreated.Keys.ToList();
            Assert.AreEqual("2012SP_GetActivationInfo", list[0].CommandText);

            Assert.AreEqual(1, _adoShims.CommandsExecuted.Count);
            list = _adoShims.CommandsExecuted;
            Assert.AreEqual("2010SP_GetSiteAccountNums", list[0].CommandText);
        }
    }
}