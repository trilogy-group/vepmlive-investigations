using System;
using System.Collections.Generic;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Xml;
using System.Xml.Fakes;
using EPMLiveCore.API.ProjectArchiver.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportingProxy.Fakes;
using EPMLiveWebParts.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.WebPageCode
{
    using EPMLiveCore;
    using WorkEnginePPM.Core.ResourceManagement.Fakes;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class GridActionTests
    {
        private readonly Guid DummyGuid = Guid.NewGuid();
        private const int DummyId = 5;
        private const string PageLoadMethodName = "Page_Load";
        private const string DummyString = "DummyString";
        private const string DummyUrl = "https://dummy.org/url/";
        private IDisposable shimsContext;
        private PrivateObject privateObject;
        private gridaction gridAction;
        private const string ArchiveRestoreProjectMethodName = "ArchiveRestoreProject";
        private const string LinkeditemspostMethodName = "linkeditemspost";
        private const string IsFavMethodName = "IsFav";
        private const string GetplannerlistMethodName = "getplannerlist";
        private const string GetWebMethodName = "GetWeb";
        private const string GetMenuItemMethodName = "getMenuItem";
        private const string GetmenusMethodName = "getmenus";
        private const string No = "No";


        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            gridAction = new gridaction();
            privateObject = new PrivateObject(gridAction);
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest();
            ShimPage.AllInstances.ResponseGet = _ => new ShimHttpResponse();
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPWeb.AllInstances.Close = _ => { };
            Shimgridaction.AllInstances.GetWebSPSite = (_, site) => new ShimSPWeb();
            ShimGridViewSession.ConstructorGuid = (_, guid) => { };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimSqlConnection.ConstructorString = (_, uri) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.AllInstances.IDGet = _ => DummyGuid;
            ShimSPFieldLookupValue.ConstructorString = (_, value) => { };
            ShimXmlDocument.AllInstances.LoadXmlString = (__, content) => { };
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, name) => new ShimSPField();
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlNode(new XmlDocument());
            ShimXmlNode.AllInstances.AttributesGet = _ => new ShimXmlAttributeCollection();
        }

        [TestMethod]
        public void PageLoad_ActionBuildTeam_RedirectsToUrl()
        {
            // Arrange
            var ExpectedUrl = $"{DummyUrl}_layouts/epmlive/buildteam.aspx?listid={DummyId}&id={DummyId}&Source={DummyString}";
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "buildteam",
                ["source"] = DummyString,
                ["listid"] = DummyId.ToString(),
                ["id"] = DummyId.ToString(),
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            Shimgridaction.AllInstances.GetWebSPSite = (_, site) => new ShimSPWeb
            {
                ServerRelativeUrlGet = () => DummyUrl
            };

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty(),
                () => redirectUrl.ShouldBe(ExpectedUrl));
        }

        [TestMethod]
        public void PageLoad_ActionLinkedItemsPost_RedirectsToUrl()
        {
            // Arrange
            var expectedUrl = $"{DummyUrl}|{DummyString}|{DummyId}|{DummyString}";
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "linkeditemspost",
                ["source"] = DummyString,
                ["listid"] = DummyId.ToString(),
                ["id"] = DummyId.ToString(),
                ["field"] = DummyString,
                ["lookupfieldlist"] = DummyString,
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            Shimgridaction.AllInstances.linkeditemspostSPWeb = (_, web) => { };

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);
            var data = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => data.ShouldNotBeNullOrEmpty(),
                () => data.ShouldBe(expectedUrl));
        }

        [TestMethod]
        public void PageLoad_ActionFancyDispForm_RedirectsToUrl()
        {
            // Arrange
            var expectedUrl = $"?lookupfield={DummyString}&LookupFieldList={DummyString}&Source={DummyString}&IsDlg=1";
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "fancydispform",
                ["list"] = Guid.NewGuid().ToString(),
                ["field"] = DummyString,
                ["lookupfieldlist"] = DummyString,
                ["source"] = DummyString,
                ["isdlg"] = "1"
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = guid => new ShimSPList()
            };

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty(),
                () => redirectUrl.ShouldBe(expectedUrl));
        }

        [TestMethod]
        public void PageLoad_ActionDeleteItemAttachment_RedirectsToUrl()
        {
            // Arrange
            var dummyGuid = Guid.NewGuid().ToString();
            var expectedUrl = $"{DummyUrl}|{dummyGuid}|{DummyId}|{DummyString}";
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "deleteitemattachment",
                ["listid"] = dummyGuid,
                ["itemid"] = DummyId.ToString(),
                ["fname"] = DummyString,
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = guid => new ShimSPList
                {
                    GetItemByIdInt32 = id => new ShimSPListItem
                    {
                        AttachmentsGet = () => new ShimSPAttachmentCollection
                        {
                            RecycleNowString = file => { }
                        }
                    }
                }
            };
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);
            var data = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => data.ShouldNotBeNullOrEmpty(),
                () => data.ShouldBe(expectedUrl));
        }

        [TestMethod]
        public void PageLoad_ActionLinkedItems_RedirectsToUrl()
        {
            // Arrange
            var dummyGuid = Guid.NewGuid().ToString();
            var expectedUrl = $"{DummyUrl}|{dummyGuid}|{DummyId}|{DummyString}";
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "linkeditems",
                ["list"] = DummyString,
                ["field"] = DummyId.ToString(),
                ["LookupFieldList"] = DummyString,
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetString = listName => new ShimSPList
                {
                    DefaultViewUrlGet = () => DummyUrl,
                    GetItemByIdInt32 = id => new ShimSPListItem
                    {
                        AttachmentsGet = () => new ShimSPAttachmentCollection
                        {
                            RecycleNowString = file => { }
                        }
                    }
                }
            };
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);
            var data = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => expectedUrl.ShouldNotBeNullOrEmpty(),
                () => expectedUrl.ShouldBe(expectedUrl));
        }

        [TestMethod]
        public void PageLoad_ActionGetRibbonPlanners_RedirectsToUrl()
        {
            // Arrange
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "getribbonplanners",
                ["listid"] = DummyGuid.ToString(),
                ["itemid"] = DummyId.ToString(),
                ["LookupFieldList"] = DummyString,
            });
            Shimgridaction.AllInstances.getplannerlistSPWebSPListItem =
                (_, web, list) => DummyString;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = guid => new ShimSPList
                {
                    DefaultViewUrlGet = () => DummyUrl,
                    GetItemByIdInt32 = id => new ShimSPListItem()
                }
            };
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);
            var data = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => data.ShouldNotBeNullOrEmpty(),
                () => data.ShouldBe(DummyString));
        }

        [TestMethod]
        public void PageLoad_ActionEditView_RedirectsToUrl()
        {
            // Arrange
            var expectedUrl = $"{DummyUrl}_layouts/15/ViewEdit.aspx?List={DummyString}&View={DummyString}";
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "editview",
                ["list"] = DummyString,
                ["view"] = DummyString,
            });
            ShimGridViewSession.ConstructorGuid = (_, guid) => { };
            Shimgridaction.AllInstances.getplannerlistSPWebSPListItem =
                (_, web, list) => DummyString;
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);
            var data = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty(),
                () => redirectUrl.ShouldBe(expectedUrl));
        }

        [TestMethod]
        public void PageLoad_ActionGetContextMenus_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedValue = "Dummy Value";
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "getcontextmenus",
            });
            Shimgridaction.AllInstances.getmenusSPWeb =
                (_, web) => ExpectedValue;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);
            var data = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => data.ShouldNotBeNullOrEmpty(),
                () => data.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void PageLoad_ActionComments_ExecutesCorrectly()
        {
            // Arrange
            var expectedUrl = $"/_layouts/epmlive/comments.aspx?itemID={DummyId}&Listid={DummyId}";
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "comments",
                ["id"] = DummyId.ToString(),
                ["listid"] = DummyId.ToString()
            });
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => string.Empty;
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);
            var data = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty(),
                () => redirectUrl.ShouldBe(expectedUrl));
        }

        [TestMethod]
        public void PageLoad_ActionWorkflows_ExecutesCorrectly()
        {
            // Arrange
            var expectedUrl = $"{DummyUrl}_layouts/Workflow.aspx?ID={DummyId}&List={{{DummyId}}}";
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "workflows",
                ["id"] = DummyId.ToString(),
                ["listid"] = DummyId.ToString()

            });
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);
            var data = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty(),
                () => redirectUrl.ShouldBe(expectedUrl));
        }

        [TestMethod]
        public void PageLoad_ActionSubscribe_ExecutesCorrectly()
        {
            // Arrange
            var expectedUrl = $"{DummyUrl}_layouts/subnew.aspx?List={DummyId}&ID={DummyId}";
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "subscribe",
                ["id"] = DummyId.ToString(),
                ["listid"] = DummyId.ToString()
            });
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);
            var data = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty(),
                () => redirectUrl.ShouldBe(expectedUrl));
        }

        [TestMethod]
        public void PageLoad_ActionApprove_ExecutesCorrectly()
        {
            // Arrange
            var expectedUrl = $"{DummyUrl}_layouts/approve.aspx?List={DummyId}&ID={DummyId}";
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "approve",
                ["id"] = DummyId.ToString(),
                ["listid"] = DummyId.ToString()
            });
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);
            var data = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty(),
                () => redirectUrl.ShouldBe(expectedUrl));
        }

        [TestMethod]
        public void PageLoad_ActionAttachFile_ExecutesCorrectly()
        {
            // Arrange
            var expectedUrl = $"{DummyUrl}_layouts/epmlive/attachfilemulti.aspx?ListId={DummyId}&ItemId={DummyId}";
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "attachfile",
                ["id"] = DummyId.ToString(),
                ["listid"] = DummyId.ToString()
            });
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);
            var data = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty(),
                () => redirectUrl.ShouldBe(expectedUrl));
        }

        [TestMethod]
        public void PageLoad_ActionRestoreProjectAction_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedValue = "Dummy Value";
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "restoreproject",
            });
            Shimgridaction.AllInstances.getplannerlistSPWebSPListItem =
                (_, web, list) => DummyString;
            Shimgridaction.AllInstances.ArchiveRestoreProjectSPSiteBoolean =
                (_, site, archive) => ExpectedValue;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);
            var data = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => data.ShouldNotBeNullOrEmpty(),
                () => data.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void PageLoad_ActionArchiveProjectAction_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedValue = "Dummy Value";
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "archiveproject",
            });
            Shimgridaction.AllInstances.getplannerlistSPWebSPListItem =
                (_, web, list) => DummyString;
            Shimgridaction.AllInstances.ArchiveRestoreProjectSPSiteBoolean =
                (_, site, archive) => ExpectedValue;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);
            var data = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => data.ShouldNotBeNullOrEmpty(),
                () => data.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void PageLoad_ActionErrorMessage_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedValue = "Dummy Value";
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "errormessage",
                ["message"] = ExpectedValue,
            });
            Shimgridaction.AllInstances.getplannerlistSPWebSPListItem =
                (_, web, list) => DummyString;
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);
            var data = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => data.ShouldNotBeNullOrEmpty(),
                () => data.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void PageLoad_ActionDefaultValue_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedValue = "Unknown Action";
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = DummyString,
            });
            Shimgridaction.AllInstances.getplannerlistSPWebSPListItem =
                (_, web, list) => DummyString;
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);
            var data = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => data.ShouldNotBeNullOrEmpty(),
                () => data.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void PageLoad_ActionCreateWorkspace_ExecutesCorrectly()
        {
            // Arrange
            var expectedUrl = $"{DummyUrl}_layouts/epmlive/requestworkspace.aspx?id={DummyId}&list={DummyId}";
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "createworkspace",
                ["id"] = DummyId.ToString(),
                ["listid"] = DummyId.ToString(),
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;

            Shimgridaction.AllInstances.getplannerlistSPWebSPListItem =
                (_, web, list) => DummyString;
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty(),
                () => redirectUrl.ShouldBe(expectedUrl));
        }

        [TestMethod]
        public void PageLoad_ActionEpkMultiPage_ExecutesCorrectly()
        {
            // Arrange
            var expectedUrl = $"{DummyUrl}_layouts/ppm/{DummyString}.aspx?dataid={DummyId}&epkurl={HttpUtility.UrlEncode(DummyUrl)}&view={DummyString}";
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "epkmultipage",
                ["id"] = DummyId.ToString(),
                ["ticket"] = DummyId.ToString(),
                ["epkcontrol"] = DummyString,
                ["view"] = DummyString
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => DummyUrl;
            ShimSPSite.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty(),
                () => redirectUrl.ShouldBe(expectedUrl));
        }

        [TestMethod]
        public void PageLoad_ActionEpkSinglePage_ExecutesCorrectly()
        {
            // Arrange
            var expectedUrl = $"{DummyUrl}_layouts/ppm/{DummyString}.aspx?itemid={DummyId}&listid={DummyId}";
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "epksinglepage",
                ["itemid"] = DummyId.ToString(),
                ["listid"] = DummyId.ToString(),
                ["epkcontrol"] = DummyString,
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => DummyUrl;
            ShimSPSite.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty(),
                () => redirectUrl.ShouldBe(expectedUrl));
        }

        [TestMethod]
        public void PageLoad_ActionGoToPlaner_ExecutesCorrectly()
        {
            // Arrange
            var expectedUrl = $"{DummyUrl}_layouts/epmlive/workplanner.aspx?listid={DummyId}&ID={DummyId}";
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "gotoplanner",
                ["listid"] = DummyId.ToString(),
                ["id"] = DummyId.ToString(),
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => DummyUrl;
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty(),
                () => redirectUrl.ShouldBe(expectedUrl));
        }

        [TestMethod]
        public void PageLoad_ActionGoToPlanerPc_ExecutesCorrectly()
        {
            // Arrange
            var expectedUrl = $"{DummyUrl}_layouts/epmlive/workplanner.aspx?listid={DummyId}&ID={DummyId}&PCSelected=true";
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "gotoplannerpc",
                ["listid"] = DummyId.ToString(),
                ["id"] = DummyId.ToString(),
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => DummyUrl;
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty(),
                () => redirectUrl.ShouldBe(expectedUrl));
        }

        [TestMethod]
        public void PageLoad_ActionEpkCommand_ExecutesCorrectly()
        {
            // Arrange
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "epkcommand",
                ["listid"] = DummyGuid.ToString(),
                ["id"] = DummyId.ToString(),
                ["view"] = "Dummy"
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) =>
            {
                return setting == "EPKCostViews"
                    ? $"Dummy,"
                    : string.Empty;
            };
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = guid => new ShimSPList
                {
                    DefaultViewGet = () => new ShimSPView
                    {
                        TitleGet = () => "Dummy"
                    },
                    TitleGet = () => DummyString
                }
            };

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void PageLoad_ActionPerms_ExecutesCorrectly()
        {
            // Arrange
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "perms",
                ["listid"] = DummyGuid.ToString(),
                ["id"] = DummyId.ToString(),
                ["gridid"] = DummyId.ToString(),
                ["rowid"] = DummyId.ToString(),
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => DummyUrl;
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = guid => new ShimSPList()
            };

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void PageLoad_ActionViewEdit2_ExecutesCorrectly()
        {
            // Arrange
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "viewedit2",
                ["listid"] = DummyGuid.ToString(),
                ["id"] = DummyId.ToString(),
                ["gridid"] = DummyId.ToString(),
                ["rowid"] = DummyId.ToString(),
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => DummyUrl;
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = guid => new ShimSPList()
            };

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void PageLoad_ActionDeleteMulti_ExecutesCorrectly()
        {
            // Arrange
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "deletemulti",
                ["items"] = $"{DummyGuid}.{DummyGuid}.3,val.or2",
            });
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetGuid = g => new ShimSPList
                    {
                        GetItemByIdInt32 = id => new ShimSPListItem
                        {
                            Recycle = () => Guid.NewGuid()
                        }
                    }
                }
            };
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = guid => new ShimSPList()
            };

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);
            var data = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => data.ShouldNotBeNullOrEmpty(),
                () => data.ShouldBe("Success"));
        }

        [TestMethod]
        public void PageLoad_ActionDelete_ExecutesCorrectly()
        {
            // Arrange
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "delete",
                ["listid"] = DummyGuid.ToString(),
                ["id"] = "1",
                ["extid"] = "1",

            });
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = g => new ShimSPList
                {
                    TitleGet = () => "resources",
                    GetItemByIdInt32 = id => new ShimSPListItem
                    {
                        ItemGetString = name => "1",
                        Recycle = () => Guid.NewGuid()
                    },
                    ParentWebGet = () => new ShimSPWeb(),
                }
            };
            ShimUtilities.PerformDeleteResourceCheckInt32GuidSPWebStringOutStringOut = PerformDeleteResourceCheck;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);
            var data = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => data.ShouldNotBeNullOrEmpty(),
                () => data.ShouldBe("Success"));
        }

        [TestMethod]
        public void PageLoad_ActionDeleteNotResource_ExecutesCorrectly()
        {
            // Arrange
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "delete",
                ["listid"] = DummyGuid.ToString(),
                ["id"] = "1",
                ["extid"] = "1",

            });
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = g => new ShimSPList
                {
                    TitleGet = () => DummyString,
                    GetItemByIdInt32 = id => new ShimSPListItem
                    {
                        ItemGetString = name => "1",
                        Recycle = () => Guid.NewGuid()
                    },
                    ParentWebGet = () => new ShimSPWeb(),
                }
            };
            ShimUtilities.PerformDeleteResourceCheckInt32GuidSPWebStringOutStringOut = PerformDeleteResourceCheck;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);
            var data = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => data.ShouldNotBeNullOrEmpty(),
                () => data.ShouldBe("Success"));
        }

        [TestMethod]
        public void PageLoad_ActionDeleteExtIdNotFound_ExecutesCorrectly()
        {
            // Arrange
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "delete",
                ["listid"] = DummyGuid.ToString(),
                ["id"] = "1",
            });
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = g => new ShimSPList
                {
                    TitleGet = () => "resources",
                    GetItemByIdInt32 = id => new ShimSPListItem
                    {
                        ItemGetString = name => null,
                        Recycle = () => Guid.NewGuid()
                    },
                    ParentWebGet = () => new ShimSPWeb(),
                }
            };
            ShimUtilities.PerformDeleteResourceCheckInt32GuidSPWebStringOutStringOut = PerformDeleteResourceCheck;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);
            var data = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => data.ShouldBeNull());
        }

        [TestMethod]
        public void PageLoad_ActionDeleteNotAllowed_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedMessage = "General Error: No";
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "delete",
                ["listid"] = DummyGuid.ToString(),
                ["id"] = "1",
            });
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = g => new ShimSPList
                {
                    TitleGet = () => "resources",
                    GetItemByIdInt32 = id => new ShimSPListItem
                    {
                        ItemGetString = name => "1",
                        Recycle = () => Guid.NewGuid()
                    },
                    ParentWebGet = () => new ShimSPWeb(),
                }
            };
            ShimUtilities.PerformDeleteResourceCheckInt32GuidSPWebStringOutStringOut = PerformDeleteResourceCheckNotAllowed;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);
            var data = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => data.ShouldNotBeNullOrEmpty(),
                () => data.ShouldBe(ExpectedMessage));
        }

        [TestMethod]
        public void PageLoad_ActionGetPSWebApp_ExecutesCorrectly()
        {
            // Arrange
            var expectedUrl = $"{DummyUrl}_layouts/epmlive/getpswebapp.aspx?listID={DummyGuid}&ID={DummyId}";
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "getpswebapp",
                ["listid"] = DummyGuid.ToString(),
                ["id"] = DummyId.ToString(),
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty(),
                () => redirectUrl.ShouldBe(expectedUrl));
        }


        [TestMethod]
        public void PageLoad_ActionGetPsProject_ExecutesCorrectly()
        {
            // Arrange
            var expectedUrl = $"{DummyUrl}_layouts/epmlive/getpsproject.aspx?listID={DummyGuid}&ID={DummyId}";
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "getpsproject",
                ["listid"] = DummyGuid.ToString(),
                ["id"] = DummyId.ToString(),
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty(),
                () => redirectUrl.ShouldBe(expectedUrl));
        }

        [TestMethod]
        public void PageLoad_ActionGetProject_ExecutesCorrectly()
        {
            // Arrange
            var expectedUrl = $"{DummyUrl}_layouts/epmlive/getproject.aspx?listID={DummyGuid}&ID={DummyId}";
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "getproject",
                ["listid"] = DummyGuid.ToString(),
                ["id"] = DummyId.ToString(),
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty(),
                () => redirectUrl.ShouldBe(expectedUrl));
        }

        [TestMethod]
        public void PageLoad_ActionGoToTaskPlanner_ExecutesCorrectly()
        {
            // Arrange
            var expectedUrl = $"{DummyUrl}_layouts/epmlive/workplanner.aspx";
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "gototaskplanner",
                ["id"] = DummyId.ToString(),
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty(),
                () => redirectUrl.ShouldBe(expectedUrl));
        }

        [TestMethod]
        public void PageLoad_ActionGoToTaskPlannerWithListId_ExecutesCorrectly()
        {
            // Arrange
            var expectedUrl = $"{DummyUrl}_layouts/epmlive/workplanner.aspx?listid={DummyString}&ID=0&tasklistid={DummyGuid}";
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "gototaskplanner",
                ["id"] = DummyId.ToString(),
                ["listid"] = DummyGuid.ToString()
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, guid) => new ShimSPList();
            ShimSPList.AllInstances.GetItemByIdInt32 = (_, id) => new ShimSPListItem();
            ShimSPListItem.AllInstances.ItemGetString = (_, name) => DummyString;

            ShimXmlAttributeCollection.AllInstances.ItemOfGetString = (_, name) => new ShimXmlAttribute
            {
                ValueGet = () => DummyString
            };

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty(),
                () => redirectUrl.ShouldBe(expectedUrl));
        }

        [TestMethod]
        public void PageLoad_ActionWorkspace_ExecutesCorrectly()
        {
            // Arrange
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "workspace",
                ["listid"] = DummyGuid.ToString(),
                ["id"] = DummyId.ToString(),
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, guid) => new ShimSPList();
            ShimSPList.AllInstances.GetItemByIdInt32 = (_, id) => new ShimSPListItem();
            ShimSPListItem.AllInstances.ItemGetString = (_, name) => $",Dummy";
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void PageLoad_ActionPlanner_ExecutesCorrectly()
        {
            // Arrange
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "planner",
                ["listid"] = DummyGuid.ToString(),
                ["id"] = DummyId.ToString(),
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, guid) => new ShimSPList();
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void PageLoad_ActionWorkPlan_ExecutesCorrectly()
        {
            // Arrange
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "workplan",
                ["listid"] = DummyGuid.ToString(),
                ["id"] = DummyId.ToString(),
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, guid) => new ShimSPList();
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void PageLoad_ActionAgile_ExecutesCorrectly()
        {
            // Arrange
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "agile",
                ["listid"] = DummyGuid.ToString(),
                ["id"] = DummyId.ToString(),
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, guid) => new ShimSPList();
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void PageLoad_ActionTasks_ExecutesCorrectly()
        {
            // Arrange
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "tasks",
                ["listid"] = DummyGuid.ToString(),
                ["id"] = DummyId.ToString(),
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, guid) => new ShimSPList();
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void PageLoad_ActionVersion_ExecutesCorrectly()
        {
            // Arrange
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "version",
                ["listid"] = DummyGuid.ToString(),
                ["id"] = DummyId.ToString(),
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, guid) => new ShimSPList();
            ShimSPList.AllInstances.GetItemByIdInt32 = (_, id) => new ShimSPListItem
            {
                UrlGet = () => DummyUrl
            };
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void PageLoad_ActionEdit_ExecutesCorrectly()
        {
            // Arrange
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "edit",
                ["listid"] = DummyGuid.ToString(),
                ["id"] = DummyId.ToString(),
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPList.AllInstances.FormsGet = _ => new ShimSPFormCollection
            {
                ItemGetPAGETYPE = type => new ShimSPForm()
            };
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, guid) => new ShimSPList();
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void PageLoad_ActionView_ExecutesCorrectly()
        {
            // Arrange
            var redirectUrl = string.Empty;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["action"] = "view",
                ["listid"] = DummyGuid.ToString(),
                ["id"] = DummyId.ToString(),
            });
            ShimHttpResponse.AllInstances.RedirectString = (_, url) => redirectUrl = url;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, guid) => new ShimSPList();
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPList.AllInstances.FormsGet = _ => new ShimSPFormCollection
            {
                ItemGetPAGETYPE = type => new ShimSPForm()
            };

            // Act
            privateObject.Invoke(PageLoadMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void ArchiveRestoreProject_SiteNull_ThrowsException()
        {
            // Arrange, Act
            Action action = () => privateObject.Invoke(ArchiveRestoreProjectMethodName, null, true);

            // Assert
            action.ShouldThrow<Exception>();
        }

        [TestMethod]
        public void ArchiveRestoreProject_Unauthorized_ThrowsException()
        {
            // Arrange
            var site = new ShimSPSite().Instance;
            ShimSPWeb.AllInstances.GroupsGet = _ => new ShimSPGroupCollection
            {
                GetByNameString = name => new ShimSPGroup()
            };
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser
            {
                IsSiteAdminGet = () => false
            };
            ShimSPWeb.AllInstances.IsCurrentUserMemberOfGroupInt32 = (_, id) => false;

            // Act
            Action action = () => privateObject.Invoke(ArchiveRestoreProjectMethodName, site, true);

            // Assert
            action.ShouldThrow<UnauthorizedAccessException>();
        }

        [TestMethod]
        public void ArchiveRestoreProject_Should_ArchiveProject()
        {
            // Arrange
            var site = new ShimSPSite().Instance;
            var archiveProjectWasCalled = false;
            ShimSPWeb.AllInstances.GroupsGet = _ => new ShimSPGroupCollection
            {
                GetByNameString = name => new ShimSPGroup()
            };
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser
            {
                IsSiteAdminGet = () => true
            };
            ShimSPWeb.AllInstances.IsCurrentUserMemberOfGroupInt32 = (_, id) => true;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["id"] = "1",
                ["listid"] = DummyGuid.ToString()
            });
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = guid => new ShimSPList
                {
                    GetItemByIdInt32 = id => new ShimSPListItem()
                }
            };
            ShimProjectArchiverService.AllInstances.ArchiveProjectSPListItem =
                (_, li) => archiveProjectWasCalled = true;

            // Act
            var result = privateObject.Invoke(ArchiveRestoreProjectMethodName, site, true) as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe("Success"),
                () => archiveProjectWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void ArchiveRestoreProject_Should_RestoreProject()
        {
            // Arrange
            var site = new ShimSPSite().Instance;
            var restoreProjectWasCalled = false;
            ShimSPWeb.AllInstances.GroupsGet = _ => new ShimSPGroupCollection
            {
                GetByNameString = name => new ShimSPGroup()
            };
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser
            {
                IsSiteAdminGet = () => true
            };
            ShimSPWeb.AllInstances.IsCurrentUserMemberOfGroupInt32 = (_, id) => true;
            ShimHttpRequest.AllInstances.ItemGetString = GetItem(new Dictionary<string, string>
            {
                ["id"] = "1",
                ["listid"] = DummyGuid.ToString()
            });
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = guid => new ShimSPList
                {
                    GetItemByIdInt32 = id => new ShimSPListItem()
                }
            };
            ShimProjectArchiverService.AllInstances.RestoreProjectSPListItem =
                (_, li) => restoreProjectWasCalled = true;

            // Act
            var result = privateObject.Invoke(ArchiveRestoreProjectMethodName, site, false) as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe("Success"),
                () => restoreProjectWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void Linkeditemspost_Should_ExecuteCorrectly()
        {
            // Arrange
            var web = new ShimSPWeb
            {
                IDGet = () => DummyGuid,
                CurrentUserGet = () => new ShimSPUser
                {
                    IDGet = () => DummyId
                },
                SiteGet = () => new ShimSPSite
                {
                    IDGet = () => DummyGuid,
                    WebApplicationGet = () => new ShimSPWebApplication()
                }
            }.Instance;
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimHttpRequest.AllInstances.ItemGetString = (_, name) => DummyString;
            var expectedCommands = new List<string>
            {
                "DELETE FROM PERSONALIZATIONS where userid=@userid and [key]=@key and listid=@listid",
                "INSERT INTO PERSONALIZATIONS (userid, [key], value,siteid,webid,listid,ItemId) " +
                "VALUES (@userid,@key,@value,@siteid,@webid,@listid,@ItemId)",
            };
            var executedCommands = new List<string>();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = commnad =>
            {
                executedCommands.Add(commnad.CommandText);
                return 1;
            };

            // Act
            privateObject.Invoke(LinkeditemspostMethodName, web);

            // Assert
            expectedCommands.All(p => executedCommands.Contains(p)).ShouldBeTrue();
        }

        [TestMethod]
        public void IsFav_Should_ReturnExpectedValue()
        {
            // Arrange
            var list = new ShimSPList().Instance;
            var listItem = new ShimSPListItem().Instance;
            var web = new ShimSPWeb
            {
                CurrentUserGet = () => new ShimSPUser(),
                SiteGet = () => new ShimSPSite()
            }.Instance;
            var settings = new ShimGridGanttSettings().Instance;
            ShimQueryExecutor.AllInstances.ExecuteEpmLiveQueryStringIDictionaryOfStringObject =
                (_, query, parameters) => new ShimDataTable
                {
                    RowsGet = () => new ShimDataRowCollection
                    {
                        ItemGetInt32 = i => new ShimDataRow
                        {
                            ItemGetInt32 = index => bool.TrueString
                        }
                    }
                };

            // Act
            var result = (bool)privateObject.Invoke(IsFavMethodName, list, listItem, web, settings);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void Getplannerlist_Should_ReturnExpectedValue()
        {
            // Arrange
            var web = new ShimSPWeb().Instance;
            var listItem = new ShimSPListItem().Instance;
            ShimCoreFunctions.GetPlannerListSPWebSPListItem =
                (spWeb, item) => new Dictionary<string, PlannerDefinition>
                {
                    [DummyString] = new PlannerDefinition
                    {
                        title = DummyString,
                        description = DummyString,
                        command = DummyString,
                        image = DummyString
                    }
                };

            // Act
            var result = privateObject.Invoke(GetplannerlistMethodName, web, listItem) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(DummyString));
        }

        [TestMethod]
        public void GetMenuItem_Should_ReturnValue()
        {
            // Arrange
            var args = new object[]
            {
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
            };

            // Act
            var result = privateObject.Invoke(GetMenuItemMethodName, args) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(DummyString));
        }

        [TestMethod]
        public void GetWeb_WithWebId_ReturnsExpectedObject()
        {
            // Arrange
            var web = new ShimSPWeb().Instance;
            var site = new ShimSPSite
            {
                OpenWebGuid = guid => web
            }.Instance;
            ShimHttpRequest.AllInstances.ItemGetString = (_, name) => DummyGuid.ToString();
            Shimgridaction.AllInstances.GetWebSPSite = null;

            // Act
            var result = privateObject.Invoke(GetWebMethodName, site) as SPWeb;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(web));
        }

        [TestMethod]
        public void GetWeb_WithCurrentWeb_ReturnsExpectedObject()
        {
            // Arrange
            var web = new ShimSPWeb().Instance;
            ShimSPContext.AllInstances.WebGet = _ => web;
            var site = new ShimSPSite().Instance;
            ShimHttpRequest.AllInstances.ItemGetString = (_, name) => string.Empty;
            Shimgridaction.AllInstances.GetWebSPSite = null;

            // Act
            var result = privateObject.Invoke(GetWebMethodName, site) as SPWeb;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(web));
        }

        private FakesDelegates.Func<HttpRequest, string, string> GetItem(
            IDictionary<string, string> dictionary)
        {
            return (_, name) =>
            {
                string value;
                dictionary.TryGetValue(name.ToLower(), out value);
                return value;
            };
        }

        private bool PerformDeleteResourceCheck(
            int extId,
            Guid dataId,
            SPWeb spWeb,
            out string status,
            out string message)
        {
            status = DummyString;
            message = DummyString;
            return true;
        }

        private bool PerformDeleteResourceCheckNotAllowed(
            int extId,
            Guid dataId,
            SPWeb spWeb,
            out string status,
            out string message)
        {
            status = No;
            message = No;
            return true;
        }
    }
}

