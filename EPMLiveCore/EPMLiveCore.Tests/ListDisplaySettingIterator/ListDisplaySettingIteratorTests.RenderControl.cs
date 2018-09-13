using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Tests.Properties;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests
{
    public partial class ListDisplaySettingIteratorTests
    {
        private const string Isonline = "isOnline";
        private const string ListField = "list";
        private const string IsResListField = "isResList";
        private const string DControlsField = "dControls";
        private const string CountField = "count";
        private const string NameField = "max";

        [TestMethod]
        public void RenderControl_Should_Be_Empty()
        {
            // Arrange
            var wasCalled = false;
            var writer = new ShimHtmlTextWriter();
            _htmlWriterShims.Contents.Add(writer.Instance, new StringBuilder());
            ShimControl.AllInstances.RenderControlHtmlTextWriter = (a, b) => wasCalled = true; 

            // Act
            _listDisplaySettingIterator.RenderControl(writer);

            // Assert
            Assert.IsTrue(wasCalled);
            Assert.AreEqual(0, _htmlWriterShims.TextWriterCreated.Count);
            Assert.AreEqual(string.Empty, _htmlWriterShims.Contents[writer.Instance].ToString());
        }

        [TestMethod]
        public void RenderControl_With_New()
        {
            // Arrange
            var writer = new ShimHtmlTextWriter();
            _htmlWriterShims.Contents.Add(writer.Instance, new StringBuilder());
            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(Isonline, true);
            _privateObject.SetFieldOrProperty(ListField, new ShimSPList().Instance);

            ShimFormComponent.AllInstances.ControlModeGet = _ => SPControlMode.New;
            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", "IsDlg=0");

            // Act
            _listDisplaySettingIterator.RenderControl(writer);

            // Assert
            Assert.AreEqual(0, _htmlWriterShims.TextWriterCreated.Count);
            var list = _htmlWriterShims.Contents.Values.ToList();
            Assert.AreEqual(1, list.Count);
            list[0].ToString().Trim().ShouldBe(Resources.RenderControl_With_New);
        }

        [TestMethod]
        public void RenderControl_With_Edit()
        {
            // Arrange
            var writer = new ShimHtmlTextWriter();
            _htmlWriterShims.Contents.Add(writer.Instance, new StringBuilder());
            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(Isonline, true);
            _privateObject.SetFieldOrProperty(ListField, new ShimSPList().Instance);

            ShimFormComponent.AllInstances.ControlModeGet = _ => SPControlMode.Edit;
            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", "IsDlg=1&GetLastID=true");

            // Act
            _listDisplaySettingIterator.RenderControl(writer);

            // Assert
            Assert.AreEqual(0, _htmlWriterShims.TextWriterCreated.Count);
            var list = _htmlWriterShims.Contents.Values.ToList();
            Assert.AreEqual(1, list.Count);
            list[0].ToString().Trim().ShouldBe(Resources.RenderControl_With_Edit);
        }

        [TestMethod]
        public void RenderControl_With_Display()
        {
            // Arrange
            var writer = new ShimHtmlTextWriter();
            _htmlWriterShims.Contents.Add(writer.Instance, new StringBuilder());
            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(Isonline, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ListField, new ShimSPList().Instance);
            _privateObject.SetFieldOrProperty(DControlsField, GetDictionary());

            ShimFormComponent.AllInstances.ControlModeGet = _ => SPControlMode.Display;
            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", "IsDlg=1&GetLastID=true");

            // Act
            _listDisplaySettingIterator.RenderControl(writer);

            // Assert
            Assert.AreEqual(3, _htmlWriterShims.TextWriterCreated.Count);
            var list = _htmlWriterShims.Contents.Values.ToList();
            Assert.AreEqual(4, list.Count);
            list[0].ToString().Trim().ShouldBe(Resources.RenderControl_With_Display_Expected);
            list[1].ToString().ShouldBe(Resources.User);
            list[2].ToString().ShouldBe(Resources.Profile);
            list[3].ToString().ShouldBe(Resources.Permissions);
        }

        [TestMethod]
        public void RenderControl_With_Display_And_IsSiteAdmin()
        {
            // Arrange
            var writer = new ShimHtmlTextWriter();
            _htmlWriterShims.Contents.Add(writer.Instance, new StringBuilder());            
            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(Isonline, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ListField, new ShimSPList().Instance);


            ShimFormComponent.AllInstances.ControlModeGet = _ => SPControlMode.Display;
            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", "IsDlg=1&GetLastID=true");
            ShimSPUser.AllInstances.IsSiteAdminGet = _ => true;
            ShimCoreFunctions.getConfigSettingSPWebString = (a, b) => true.ToString();

            // Act
            _listDisplaySettingIterator.RenderControl(writer);

            // Assert
            Assert.AreEqual(3, _htmlWriterShims.TextWriterCreated.Count);
            var list = _htmlWriterShims.Contents.Values.ToList();
            Assert.AreEqual(4, list.Count);
            list[0].ToString().Trim().ShouldBe(Resources.RenderControl_With_Display_And_IsSiteAdmin);
            list[1].ToString().ShouldBe(Resources.User);
            list[2].ToString().ShouldBe(Resources.Profile);
            list[3].ToString().ShouldBe(Resources.Permissions);
        }

        [TestMethod]
        public void RenderControl_With_Display_And_OwnerUserName()
        {
            // Arrange
            var writer = new ShimHtmlTextWriter();
            _htmlWriterShims.Contents.Add(writer.Instance, new StringBuilder());
            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(Isonline, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ListField, new ShimSPList().Instance);
            _privateObject.SetFieldOrProperty(OwnerUserNameField, "ownerusername");
            ShimSPUser.AllInstances.LoginNameGet = _ => "OwnerUserName";

            ShimFormComponent.AllInstances.ControlModeGet = _ => SPControlMode.Display;
            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", "IsDlg=1&GetLastID=true");
            ShimSPUser.AllInstances.IsSiteAdminGet = _ => true;
            ShimCoreFunctions.getConfigSettingSPWebString = (a, b) => true.ToString();

            // Act
            _listDisplaySettingIterator.RenderControl(writer);

            // Assert
            Assert.AreEqual(3, _htmlWriterShims.TextWriterCreated.Count);
            var list = _htmlWriterShims.Contents.Values.ToList();
            Assert.AreEqual(4, list.Count);
            list[0].ToString().Trim().ShouldBe(Resources.RenderControl_With_Display_And_OwnerUserName);
            list[1].ToString().ShouldBe(Resources.User);
            list[2].ToString().ShouldBe(Resources.Profile);
            list[3].ToString().ShouldBe(Resources.Permissions);
        }

        [TestMethod]
        public void RenderControl_With_Display_And_Count_Less_Than_Max()
        {
            // Arrange
            var writer = new ShimHtmlTextWriter();
            _htmlWriterShims.Contents.Add(writer.Instance, new StringBuilder());
            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(Isonline, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ListField, new ShimSPList().Instance);
            _privateObject.SetFieldOrProperty(CountField, 1);
            _privateObject.SetFieldOrProperty(NameField, 2);

            ShimFormComponent.AllInstances.ControlModeGet = _ => SPControlMode.Display;
            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", "IsDlg=1&GetLastID=true");
            ShimSPUser.AllInstances.IsSiteAdminGet = _ => true;
            ShimCoreFunctions.getConfigSettingSPWebString = (a, b) => true.ToString();

            // Act
            _listDisplaySettingIterator.RenderControl(writer);

            // Assert
            Assert.AreEqual(3, _htmlWriterShims.TextWriterCreated.Count);
            var list = _htmlWriterShims.Contents.Values.ToList();
            Assert.AreEqual(4, list.Count);
            list[0].ToString().Trim().ShouldBe(Resources.RenderControl_With_Display_And_Count_Less_Than_Max);
            list[1].ToString().ShouldBe(Resources.User);
            list[2].ToString().ShouldBe(Resources.Profile);
            list[3].ToString().ShouldBe(Resources.Permissions);
        }

        [TestMethod]
        public void RenderControl_With_Display_And_InternalName_FirstName()
        {
            // Arrange
            var dictionary = new Dictionary<string, string>
            {
                ["FirstName"] = "FirstNameId",
                ["LastName"] = "LastNameId"
            };
            var writer = new ShimHtmlTextWriter();
            _htmlWriterShims.Contents.Add(writer.Instance, new StringBuilder());
            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(Isonline, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ListField, new ShimSPList().Instance);
            _privateObject.SetFieldOrProperty(DControlsField, dictionary);

            ShimSPField.AllInstances.InternalNameGet = _ => "FirstName";
            ShimFormComponent.AllInstances.ControlModeGet = _ => SPControlMode.Display;
            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", "IsDlg=1&GetLastID=true");

            // Act
            _listDisplaySettingIterator.RenderControl(writer);

            // Assert
            Assert.AreEqual(3, _htmlWriterShims.TextWriterCreated.Count);
            var list = _htmlWriterShims.Contents.Values.ToList();
            Assert.AreEqual(4, list.Count);
            list[0].ToString().Trim().ShouldBe(Resources.RenderControl_With_Display_And_InternalName_FirstName);
            list[1].ToString().ShouldBe(Resources.User);
            list[2].ToString().ShouldBe(Resources.Profile);
            list[3].ToString().ShouldBe(Resources.Permissions);
        }

        [TestMethod]
        public void RenderControl_With_Display_And_InternalName_ResourceLevel()
        {
            // Arrange
            var writer = new ShimHtmlTextWriter();
            _htmlWriterShims.Contents.Add(writer.Instance, new StringBuilder());
            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(Isonline, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ListField, new ShimSPList().Instance);

            ShimSPField.AllInstances.InternalNameGet = _ => "ResourceLevel";
            ShimFormComponent.AllInstances.ControlModeGet = _ => SPControlMode.Display;
            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", "IsDlg=1&GetLastID=true");

            // Act
            _listDisplaySettingIterator.RenderControl(writer);

            // Assert
            Assert.AreEqual(3, _htmlWriterShims.TextWriterCreated.Count);
            var list = _htmlWriterShims.Contents.Values.ToList();
            Assert.AreEqual(4, list.Count);
            list[0].ToString().Trim().ShouldBe(Resources.RenderControl_With_Display_And_InternalName_ResourceLevel);
            list[1].ToString().ShouldBe(Resources.User);
            list[2].ToString().ShouldBe(Resources.Profile);
            list[3].ToString().ShouldBe(Resources.Permissions);
        }

        [TestMethod]
        public void RenderControl_With_Display_And_InternalName_Due()
        {
            // Arrange
            var writer = new ShimHtmlTextWriter();
            _htmlWriterShims.Contents.Add(writer.Instance, new StringBuilder());
            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(Isonline, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ListField, new ShimSPList().Instance);

            ShimSPField.AllInstances.InternalNameGet = _ => "Due";
            ShimFormComponent.AllInstances.ControlModeGet = _ => SPControlMode.Display;
            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", "IsDlg=1&GetLastID=true");

            // Act
            _listDisplaySettingIterator.RenderControl(writer);

            // Assert
            Assert.AreEqual(3, _htmlWriterShims.TextWriterCreated.Count);
            var list = _htmlWriterShims.Contents.Values.ToList();
            Assert.AreEqual(4, list.Count);
            list[0].ToString().Trim().ShouldBe(Resources.RenderControl_With_Display_And_InternalName_Due);
            list[1].ToString().ShouldBe(Resources.User);
            list[2].ToString().ShouldBe(Resources.Profile);
            list[3].ToString().ShouldBe(Resources.Permissions);
        }

        [TestMethod]
        public void RenderControl_With_Display_And_InternalName_DaysOverdue()
        {
            // Arrange
            var writer = new ShimHtmlTextWriter();
            _htmlWriterShims.Contents.Add(writer.Instance, new StringBuilder());
            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(Isonline, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ListField, new ShimSPList().Instance);

            ShimSPField.AllInstances.InternalNameGet = _ => "DaysOverdue";
            ShimFormComponent.AllInstances.ControlModeGet = _ => SPControlMode.Display;
            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", "IsDlg=1&GetLastID=true");

            // Act
            _listDisplaySettingIterator.RenderControl(writer);

            // Assert
            Assert.AreEqual(3, _htmlWriterShims.TextWriterCreated.Count);
            var list = _htmlWriterShims.Contents.Values.ToList();
            Assert.AreEqual(4, list.Count);
            list[0].ToString().Trim().ShouldBe(Resources.RenderControl_With_Display_And_InternalName_DaysOverdue);
            list[1].ToString().ShouldBe(Resources.User);
            list[2].ToString().ShouldBe(Resources.Profile);
            list[3].ToString().ShouldBe(Resources.Permissions);
        }

        [TestMethod]
        public void RenderControl_With_Display_And_InternalName_ScheduleStatus()
        {
            // Arrange
            var writer = new ShimHtmlTextWriter();
            _htmlWriterShims.Contents.Add(writer.Instance, new StringBuilder());
            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(Isonline, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ListField, new ShimSPList().Instance);

            ShimSPField.AllInstances.InternalNameGet = _ => "ScheduleStatus";
            ShimFormComponent.AllInstances.ControlModeGet = _ => SPControlMode.Display;
            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", "IsDlg=1&GetLastID=true");

            // Act
            _listDisplaySettingIterator.RenderControl(writer);

            // Assert
            Assert.AreEqual(3, _htmlWriterShims.TextWriterCreated.Count);
            var list = _htmlWriterShims.Contents.Values.ToList();
            Assert.AreEqual(4, list.Count);
            list[0].ToString().Trim().ShouldBe(Resources.RenderControl_With_Display_And_InternalName_ScheduleStatus);
            list[1].ToString().ShouldBe(Resources.User);
            list[2].ToString().ShouldBe(Resources.Profile);
            list[3].ToString().ShouldBe(Resources.Permissions);
        }
        
        [TestMethod]
        public void RenderControl_With_Display_And_InternalName_Title()
        {
            // Arrange
            var writer = new ShimHtmlTextWriter();
            _htmlWriterShims.Contents.Add(writer.Instance, new StringBuilder());
            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(Isonline, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ListField, new ShimSPList().Instance);

            ShimSPField.AllInstances.InternalNameGet = _ => "Title(";
            ShimFormComponent.AllInstances.ControlModeGet = _ => SPControlMode.Display;
            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", "IsDlg=1&GetLastID=true");

            // Act
            _listDisplaySettingIterator.RenderControl(writer);

            // Assert
            Assert.AreEqual(3, _htmlWriterShims.TextWriterCreated.Count);
            var list = _htmlWriterShims.Contents.Values.ToList();
            Assert.AreEqual(4, list.Count);
            list[0].ToString().Trim().ShouldBe(Resources.RenderControl_With_Display_And_InternalName_Title);
            list[1].ToString().ShouldBe(Resources.User);
            list[2].ToString().ShouldBe(Resources.Profile);
            list[3].ToString().ShouldBe(Resources.Permissions);
        }

        [TestMethod]
        public void RenderControl_With_Display_And_Type_Calculated()
        {
            // Arrange
            var writer = new ShimHtmlTextWriter();
            _htmlWriterShims.Contents.Add(writer.Instance, new StringBuilder());
            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(Isonline, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ListField, new ShimSPList().Instance);

            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Calculated;
            ShimFormComponent.AllInstances.ControlModeGet = _ => SPControlMode.Display;
            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", "IsDlg=1&GetLastID=true");

            // Act
            _listDisplaySettingIterator.RenderControl(writer);

            // Assert
            Assert.AreEqual(3, _htmlWriterShims.TextWriterCreated.Count);
            var list = _htmlWriterShims.Contents.Values.ToList();
            Assert.AreEqual(4, list.Count);
            list[0].ToString().Trim().ShouldBe(Resources.RenderControl_With_Display_And_Type_Calculated);
            list[1].ToString().ShouldBe(Resources.User);
            list[2].ToString().ShouldBe(Resources.Profile);
            list[3].ToString().ShouldBe(Resources.Permissions);
        }

        [TestMethod]
        public void RenderControl_With_Display_And_Type_Lookup()
        {
            // Arrange
            var writer = new ShimHtmlTextWriter();
            _htmlWriterShims.Contents.Add(writer.Instance, new StringBuilder());
            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(Isonline, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ListField, new ShimSPList().Instance);

            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Lookup;
            ShimFormComponent.AllInstances.ControlModeGet = _ => SPControlMode.Display;
            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", "IsDlg=1&GetLastID=true");

            // Act
            _listDisplaySettingIterator.RenderControl(writer);

            // Assert
            Assert.AreEqual(3, _htmlWriterShims.TextWriterCreated.Count);
            var list = _htmlWriterShims.Contents.Values.ToList();
            Assert.AreEqual(4, list.Count);
            list[0].ToString().Trim().ShouldBe(Resources.RenderControl_With_Display_And_Type_Lookup);
            list[1].ToString().ShouldBe(Resources.User);
            list[2].ToString().ShouldBe(Resources.Profile);
            list[3].ToString().ShouldBe(Resources.Permissions);
        }

        [TestMethod]
        public void RenderControl_With_Display_And_arrwpFields()
        {
            // Arrange
            const string InternalName = "name";
            var sortedList = new SortedList
            {
                {InternalName, true}
            };
            var writer = new ShimHtmlTextWriter();
            _htmlWriterShims.Contents.Add(writer.Instance, new StringBuilder());
            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(Isonline, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ListField, new ShimSPList().Instance);
            _privateObject.SetFieldOrProperty("arrwpFields", sortedList);

            ShimFormComponent.AllInstances.ControlModeGet = _ => SPControlMode.Display;
            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", "IsDlg=1&GetLastID=true");
            ShimListDisplaySettingIterator.GetControlTypeControlInt32 = (a, b) => "Microsoft.SharePoint.WebControls.FieldLabel";

            // Act
            _listDisplaySettingIterator.RenderControl(writer);

            // Assert
            Assert.AreEqual(3, _htmlWriterShims.TextWriterCreated.Count);
            var list = _htmlWriterShims.Contents.Values.ToList();
            Assert.AreEqual(4, list.Count);
            list[0].ToString().Trim().ShouldBe(Resources.RenderControl_With_Display_And_arrwpFields);
            list[1].ToString().ShouldBe(Resources.User);
            list[2].ToString().ShouldBe(Resources.Profile);
            list[3].ToString().ShouldBe(Resources.Permissions);
        }

        [TestMethod]
        public void RenderControl_With_Display_And_InternalName_CanLogin()
        {
            // Arrange
            var writer = new ShimHtmlTextWriter();
            _htmlWriterShims.Contents.Add(writer.Instance, new StringBuilder());
            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(Isonline, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ListField, new ShimSPList().Instance);

            ShimSPField.AllInstances.InternalNameGet = _ => "CanLogin";
            ShimFormComponent.AllInstances.ControlModeGet = _ => SPControlMode.Display;
            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", "IsDlg=1&GetLastID=true");

            // Act
            _listDisplaySettingIterator.RenderControl(writer);

            // Assert
            Assert.AreEqual(3, _htmlWriterShims.TextWriterCreated.Count);
            var list = _htmlWriterShims.Contents.Values.ToList();
            Assert.AreEqual(4, list.Count);
            list[0].ToString().Trim().ShouldBe(Resources.RenderControl_With_Display_And_InternalName_CanLogin);
            list[1].ToString().ShouldBe(Resources.User);
            list[2].ToString().ShouldBe(Resources.Profile);
            list[3].ToString().ShouldBe(Resources.Permissions);
        }

        [TestMethod]
        public void RenderControl_With_Display_And_InternalName_Generic()
        {
            // Arrange
            var writer = new ShimHtmlTextWriter();
            _htmlWriterShims.Contents.Add(writer.Instance, new StringBuilder());
            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(Isonline, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ListField, new ShimSPList().Instance);

            ShimSPField.AllInstances.InternalNameGet = _ => "Generic";
            ShimFormComponent.AllInstances.ControlModeGet = _ => SPControlMode.Display;
            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", "IsDlg=1&GetLastID=true");

            // Act
            _listDisplaySettingIterator.RenderControl(writer);

            // Assert
            Assert.AreEqual(3, _htmlWriterShims.TextWriterCreated.Count);
            var list = _htmlWriterShims.Contents.Values;
            Assert.AreEqual(4, list.Count);
        }

        [TestMethod]
        public void RenderControl_With_Display_And_InternalName_Status()
        {
            // Arrange
            var writer = new ShimHtmlTextWriter();
            _htmlWriterShims.Contents.Add(writer.Instance, new StringBuilder());
            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(Isonline, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ListField, new ShimSPList().Instance);

            ShimSPField.AllInstances.InternalNameGet = _ => "Status";
            ShimFormComponent.AllInstances.ControlModeGet = _ => SPControlMode.Display;
            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", "IsDlg=1&GetLastID=true");

            // Act
            _listDisplaySettingIterator.RenderControl(writer);

            // Assert
            Assert.AreEqual(3, _htmlWriterShims.TextWriterCreated.Count);
            var list = _htmlWriterShims.Contents.Values.ToList();
            Assert.AreEqual(4, list.Count);
            list[0].ToString().Trim().ShouldBe(Resources.RenderControl_With_Display_And_InternalName_Status);
            list[1].ToString().ShouldBe(Resources.User);
            list[2].ToString().ShouldBe(Resources.Profile);
            list[3].ToString().ShouldBe(Resources.Permissions);
        }

        private static IDictionary<string, string> GetDictionary()
        {
            return new Dictionary<string, string>
            {
                ["FirstName"] = "FirstNameId",
                ["LastName"] = "LastNameId",
                ["Email"] = "EmailId",
                ["Generic"] = "GenericId",
                ["Title"] = "TitleId",
                ["SharePointAccount"] = "SharePointAccountId",
                ["Permissions"] = "PermissionsId",
                ["ResourceLevel"] = "ResourceLevel",
                ["Approved"] = "ApprovedId",
                ["TimesheetAdministrator"] = "TimesheetAdministratorId",
                ["Active"] = "ActiveId",
                ["Disable"] = "DisableId",
                ["PercentComplete"] = "PercentCompleteId",
                ["Complete"] = "CompleteId",
                ["Status"] = "StatusId",
                ["CanLogin"] = "CanLoginId",
                ["Generic"] = "Generic"
            };
        }
    }
}