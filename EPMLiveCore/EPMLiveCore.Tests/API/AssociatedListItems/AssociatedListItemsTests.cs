using System;
using System.Collections;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Web.Fakes;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportingProxy.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using AssociatedListItemsClass = EPMLiveCore.API.AssociatedListItems;

namespace EPMLiveCore.Tests.API.AssociatedListItems
{
    [TestClass, ExcludeFromCodeCoverage]
    public class AssociatedListItemsTests
    {
        private IDisposable _shimObject;
        private ShimSPSite _site;
        private ShimSPWeb _web;

        private bool _dataTableHasRows;
        private int _reportingDBQueryExecutedCount;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string DummyUrl = "http://xyz.com";
        private const string DummyError = "Dummy Error";
        private const string SiteID = "1941810b-e7ec-4c0d-a512-b50a84761e71";
        private const string WebID = "06676109-36f8-4957-a41a-9464d4e52fc5";
        private const string ProjectListID = "f42cdfdd-f66d-4588-8d2b-0dcd5fab4bc1";
        private const string ProjectID = "69490876-7284-4f10-9d1f-508230a8f76e";
        private const string FancyFormListID = "bef35162-aa84-4670-8758-d653af039b4f";
        private const string TitleField = "Title";
        private const string ListIdFIeld = "ListId";
        private const string HideNewButtonProperty = "HideNewButton";
        private const string RPTListIDField = "RPTListID";
        private const string ListNameField = "ListName";
        private const string TableNameField = "TableName";
        private const string CountField = "Count";
        private const string ItemIdField = "ItemId";

        [TestInitialize]
        public void TestInitialize()
        {
            _dataTableHasRows = true;
            _reportingDBQueryExecutedCount = 0;

            _shimObject = ShimsContext.Create();

            SetupShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }

        private void SetupShims()
        {
            ShimHttpContext.CurrentGet = () => new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    UrlReferrerGet = () => new Uri(DummyUrl)
                }
            };

            _site = new ShimSPSite
            {
                IDGet = () => new Guid(SiteID)
            };

            var count = 0;
            var list = new ShimSPList
            {
                IDGet = () => new Guid(ProjectListID),
                GetItemsSPQuery = _ =>
                {
                    count++;

                    if (count == 1)
                    {
                        return new ShimSPListItemCollection().Bind(new SPListItem[]
                        {
                            new ShimSPListItem
                            {
                                IDGet = () => DummyInt,
                                TitleGet = () => $"{DummyString}{DummyInt}_______________"
                            }.Instance,
                            new ShimSPListItem
                            {
                                IDGet = () => DummyInt + 1,
                                TitleGet = () => $"{DummyString}{DummyInt+1}"
                            }.Instance
                        });
                    }

                    return new ShimSPListItemCollection().Bind(new SPListItem[]
                    {
                        new ShimSPListItem().Instance,
                        new ShimSPListItem().Instance,
                        new ShimSPListItem().Instance,
                        new ShimSPListItem().Instance,
                        new ShimSPListItem().Instance,
                        new ShimSPListItem().Instance
                    });
                },
                GetItemByIdInt32 = _ => new ShimSPListItem
                {
                    IDGet = () => DummyInt,
                    TitleGet = () => DummyString
                },
                RootFolderGet = () => new ShimSPFolder
                {
                    UrlGet = () => DummyString
                }
            };

            _web = new ShimSPWeb
            {
                IDGet = () => new Guid(WebID),
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetGuid = _ => list,
                    ItemGetString = _ => list
                },
                SiteGet = () => _site,
                UrlGet = () => DummyUrl
            };

            ShimSPSite.ConstructorString = (_, __) => { };
            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => _web;
            ShimSPSite.AllInstances.Dispose = _ => { };

            ShimSPWeb.AllInstances.Dispose = _ => { };

            ShimSPQuery.Constructor = _ => { };

            var associatedListInfo = new ShimAssociatedListInfo().Instance;
            var privateAssociatedListInto = new PrivateObject(associatedListInfo);
            privateAssociatedListInto.SetFieldOrProperty(TitleField, DummyString);
            privateAssociatedListInto.SetFieldOrProperty(ListIdFIeld, new Guid(ProjectListID));

            ShimListCommands.GetAssociatedListsSPList = _ => new ArrayList() { associatedListInfo };

            var gridGantt = new ShimGridGanttSettings().Instance;
            var privateGridGantt = new PrivateObject(gridGantt);
            privateGridGantt.SetFieldOrProperty(HideNewButtonProperty, false);

            ShimListCommands.GetGridGanttSettingsSPList = _ => gridGantt;

            ShimQueryExecutor.ConstructorSPWeb = (_, __) => { };
            ShimQueryExecutor.AllInstances.ExecuteReportingDBQueryStringIDictionaryOfStringObject = (_, __, ___) =>
            {
                _reportingDBQueryExecutedCount++;
                return CreateDataTable();
            };

            ShimResponse.SuccessString = message => message;
        }

        private DataTable CreateDataTable()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(RPTListIDField);
            dataTable.Columns.Add(ListNameField);
            dataTable.Columns.Add(TableNameField);
            dataTable.Columns.Add(CountField);
            dataTable.Columns.Add(TitleField);
            dataTable.Columns.Add(ItemIdField);

            if (_dataTableHasRows)
            {
                for (var i = 0; i < 6; i++)
                {
                    var dataRow = dataTable.NewRow();
                    dataRow[RPTListIDField] = i == 0 ? ProjectListID : string.Empty;
                    dataRow[ListNameField] = DummyString;
                    dataRow[TableNameField] = DummyString;
                    dataRow[CountField] = DummyInt;
                    dataRow[TitleField] = DummyString;
                    dataRow[ItemIdField] = DummyInt + i;

                    dataTable.Rows.Add(dataRow);
                }
            }

            return dataTable;
        }

        [TestMethod]
        public void GetAssociatedItems_OnValidCall_ConfirmResult()
        {
            // Arrange
            var xmlData = CreateXmlData();

            // Act
            var result = AssociatedListItemsClass.GetAssociatedItems(xmlData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingDBQueryExecutedCount.ShouldBe(2),
                () => result.ShouldContain($"<div id='div_{ProjectListID}' class='listMainDiv'>"),
                () => result.ShouldContain($"<div id='div_items_{ProjectListID}' class='slidingDiv'>"),
                () => result.ShouldContain($"<div class='slidingDivHeader'>{DummyString}</div>"),
                () => result.ShouldContain($"<div class='slidingDivAdd'>"),
                () => result.ShouldContain($"<a href='#' onclick=\"javascript:showNewForm('?LookupField=Project&LookupValue=69490876-7284-4f10-9d1f-508230a8f76e');return false;\">"),
                () => result.ShouldContain($"<img title='Add new {DummyString}' alt='' src='/_layouts/epmlive/images/newitem5.png' class='ms-core-menu-buttonIcon'>"),
                () => result.ShouldContain($"onclick=\"javascript:showNewForm('?ID=1&Source=http%3a%2f%2fxyz.com%2f');return false;\""),
                () => result.ShouldContain($"{DummyString}{DummyInt}________..."),
                () => result.ShouldContain($"<li class='associateditemscontextmenu'>"),
                () => result.ShouldContain($"data-webid='{WebID}'"),
                () => result.ShouldContain($"data-siteid='{SiteID}'"),
                () => result.ShouldContain($"data-listid='{ProjectListID}'"),
                () => result.ShouldContain($"<div class='pipeSeperator'>|</div>"));
        }

        [TestMethod]
        public void GetAssociatedItems_OnError_ReturnErrorMessage()
        {
            // Arrange
            var xmlData = CreateXmlData();

            ShimSPSite.ConstructorString = (_, __) =>
            {
                throw new APIException(DummyInt, DummyError);
            };

            // Act
            var result = AssociatedListItemsClass.GetAssociatedItems(xmlData);

            // Assert
            result.ShouldBe($"<Result Status=\"{DummyInt}\"><Error ID=\"{DummyInt}\">Error: {DummyError}</Error></Result>");
        }

        private string CreateXmlData()
        {
            return $@"<Root>
                        <SiteUrl>{DummyUrl}</SiteUrl>
                        <SiteID>{SiteID}</SiteID>
                        <WebID>{WebID}</WebID>
                        <ProjectListID>{ProjectListID}</ProjectListID>
                        <ProjectID>{ProjectID}</ProjectID>
                        <ProjectTitle>{DummyString}</ProjectTitle>
                        <FancyFormListID>{FancyFormListID}</FancyFormListID>
                        <FancyFormItemID>{DummyInt}</FancyFormItemID>
                      </Root>";
        }

        [TestMethod]
        public void GetFancyFormAssociatedItems_WhenNotEnableThrottling_ConfirmResult()
        {
            // Arrange
            var xmlData = CreateXmlData();

            // Act
            var result = AssociatedListItemsClass.GetFancyFormAssociatedItems(xmlData, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingDBQueryExecutedCount.ShouldBe(2),
                () => result.ShouldContain("<table style='width: 100%;'><tr><td><table style='border-collapse: collapse;'  class='fancy-col-table'>"),
                () => result.ShouldContain($"<td>{DummyString}</td>"),
                () => result.ShouldContain($"<a href='#' onclick=\"javascript:FancyDispFormClient.emptyFunction('');\">"),
                () => result.ShouldContain($"<div id='div_{ProjectListID}' class='listMainDiv'><span class='badge'>{DummyInt}</span>"),
                () => result.ShouldContain($"<div id='div_items_{ProjectListID}' class='slidingDiv'>"),
                () => result.ShouldContain($"<div class='fancy-display-form-wrapper slidingDivHeader'>{DummyString}</div>"),
                () => result.ShouldContain($"<a href='#' onclick=\"javascript:FancyDispFormClient.showNewForm('?LookupField=&LookupValue={DummyInt}');return false;\">"),
                () => result.ShouldContain($"<img title='Add new {DummyString}' alt='' src='/_layouts/epmlive/images/newitem5.png' class='ms-core-menu-buttonIcon'></img>"),
                () => result.ShouldContain($"<a href='#' alt='{DummyString}{DummyInt}_______________' title='{DummyString}{DummyInt}_______________'"),
                () => result.ShouldNotContain($"<a href='#' alt='{DummyString}' title='{DummyString}'"),
                () => result.ShouldContain($"onclick=\"javascript:FancyDispFormClient.showNewForm('?ID={DummyInt}&Source=http%3a%2f%2fxyz.com%2f');return false;\""),
                () => result.ShouldContain($"{DummyString}{DummyInt}_____________..."),
                () => result.ShouldContain($"<a data-itemid='{DummyInt}' data-listid='{ProjectListID}' data-webid='{WebID}' data-siteid='{SiteID}'></a>"));
        }

        [TestMethod]
        public void GetFancyFormAssociatedItems_WhenEnableThrottling_ConfirmResult()
        {
            // Arrange
            var xmlData = CreateXmlData();

            ShimSPList.AllInstances.EnableThrottlingGet = _ => true;

            // Act
            var result = AssociatedListItemsClass.GetFancyFormAssociatedItems(xmlData, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingDBQueryExecutedCount.ShouldBe(13),
                () => result.ShouldContain("<table style='width: 100%;'><tr><td><table style='border-collapse: collapse;'  class='fancy-col-table'>"),
                () => result.ShouldContain($"<td>{DummyString}</td>"),
                () => result.ShouldContain($"<a href='#' onclick=\"javascript:FancyDispFormClient.emptyFunction('');\">"),
                () => result.ShouldContain($"<div id='div_{ProjectListID}' class='listMainDiv'><span class='badge'>{DummyInt}</span>"),
                () => result.ShouldContain($"<div id='div_items_{ProjectListID}' class='slidingDiv'>"),
                () => result.ShouldContain($"<div class='fancy-display-form-wrapper slidingDivHeader'>{DummyString}</div>"),
                () => result.ShouldContain($"<a href='#' onclick=\"javascript:FancyDispFormClient.showNewForm('?LookupField=&LookupValue={DummyInt}');return false;\">"),
                () => result.ShouldContain($"<img title='Add new {DummyString}' alt='' src='/_layouts/epmlive/images/newitem5.png' class='ms-core-menu-buttonIcon'></img>"),
                () => result.ShouldNotContain($"<a href='#' alt='{DummyString}{DummyInt}_______________' title='{DummyString}{DummyInt}_______________'"),
                () => result.ShouldContain($"<a href='#' alt='{DummyString}' title='{DummyString}'"),
                () => result.ShouldContain($"onclick=\"javascript:FancyDispFormClient.showNewForm('?ID={DummyInt}&Source=http%3a%2f%2fxyz.com%2f');return false;\""),
                () => result.ShouldNotContain($"{DummyString}{DummyInt}_____________..."),
                () => result.ShouldContain($"<a data-itemid='{DummyInt}' data-listid='{ProjectListID}' data-webid='{WebID}' data-siteid='{SiteID}'></a>"));
        }

        [TestMethod]
        public void GetFancyFormAssociatedItems_WhenDataTableHasNoRows_ConfirmResult()
        {
            // Arrange
            var xmlData = CreateXmlData();
            _dataTableHasRows = false;

            ShimSPList.AllInstances.EnableThrottlingGet = _ => true;

            // Act
            var result = AssociatedListItemsClass.GetFancyFormAssociatedItems(xmlData, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingDBQueryExecutedCount.ShouldBe(1),
                () => result.ShouldContain("<table style='width:100%'><tr><td><table style='border-collapse: collapse;' class='fancy-col-table'>"),
                () => result.ShouldContain($"<td>{DummyString}</td>"),
                () => result.ShouldNotContain($"<a href='#' onclick=\"javascript:FancyDispFormClient.emptyFunction('');\">"),
                () => result.ShouldContain($"<div id='div_{ProjectListID}' class='listMainDiv'><span class='badge'>0</span>"),
                () => result.ShouldNotContain($"<div id='div_items_{ProjectListID}' class='slidingDiv'>"),
                () => result.ShouldNotContain($"<div class='fancy-display-form-wrapper slidingDivHeader'>{DummyString}</div>"),
                () => result.ShouldNotContain($"<a href='#' onclick=\"javascript:FancyDispFormClient.showNewForm('?LookupField=&LookupValue={DummyInt}');return false;\">"),
                () => result.ShouldNotContain($"<img title='Add new {DummyString}' alt='' src='/_layouts/epmlive/images/newitem5.png' class='ms-core-menu-buttonIcon'></img>"),
                () => result.ShouldNotContain($"<a href='#' alt='{DummyString}{DummyInt}_______________' title='{DummyString}{DummyInt}_______________'"),
                () => result.ShouldNotContain($"<a href='#' alt='{DummyString}' title='{DummyString}'"),
                () => result.ShouldNotContain($"onclick=\"javascript:FancyDispFormClient.showNewForm('?ID={DummyInt}&Source=http%3a%2f%2fxyz.com%2f');return false;\""),
                () => result.ShouldNotContain($"{DummyString}{DummyInt}_____________..."),
                () => result.ShouldNotContain($"<a data-itemid='{DummyInt}' data-listid='{ProjectListID}' data-webid='{WebID}' data-siteid='{SiteID}'></a>"));
        }

        [TestMethod]
        public void GetFancyFormAssociatedItems_OnError_ReturnErrorMessage()
        {
            // Arrange
            var xmlData = CreateXmlData();

            ShimSPSite.ConstructorGuid = (_, __) =>
            {
                throw new APIException(DummyInt, DummyError);
            };

            // Act
            var result = AssociatedListItemsClass.GetFancyFormAssociatedItems(xmlData, _web);

            // Assert
            result.ShouldBe($"<Result Status=\"{DummyInt}\"><Error ID=\"{DummyInt}\">Error: {DummyError}</Error></Result>");
        }

        [TestMethod]
        public void GetFancyFormAssociatedItemAttachments_WhenHasAttachments_ConfirmResult()
        {
            // Arrange
            var xmlData = CreateXmlData();

            ShimSPListItem.AllInstances.AttachmentsGet = _ => new ShimSPAttachmentCollection().Bind(new string[] { DummyString });

            // Act
            var result = AssociatedListItemsClass.GetFancyFormAssociatedItemAttachments(xmlData, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContain("<div id='attach-wrapper'>"),
                () => result.ShouldNotContain("<table class='fancy-col-table'><tr><td style='color:#bbbbbb;'>There are no attachments, click the \"+\" icon above to upload new attachments.</td></tr></table>"),
                () => result.ShouldContain("<div id='attach-text-wrapper'>"),
                () => result.ShouldContain("<div class='attach-text'>"),
                () => result.ShouldContain("<span class='icon-file'  style='margin-right:5px;color:#999999;'></span>"),
                () => result.ShouldContain($"<a href='{DummyUrl}/{DummyString}/attachments/{DummyInt}/{DummyString}' target='_blank' ID='{DummyString}' class='fancybox'>"),
                () => result.ShouldContain($"<span>{DummyString}</span>"),
                () => result.ShouldContain($"<a href='#' onclick=\"javascript:FancyDispFormClient.DeleteItemAttachment('"),
                () => result.ShouldContain($"{ DummyUrl}/_layouts/epmlive/gridaction.aspx?action=deleteitemattachment&listid={ProjectListID}&itemid={DummyInt}&fname={DummyString}"),
                () => result.ShouldContain($"<span class='fui-cross delete' style='top:2px;position:relative;'></span>"));
        }

        [TestMethod]
        public void GetFancyFormAssociatedItemAttachments_WhenHasNoAttachments_ConfirmResult()
        {
            // Arrange
            var xmlData = CreateXmlData();

            ShimSPListItem.AllInstances.AttachmentsGet = _ => new ShimSPAttachmentCollection();

            // Act
            var result = AssociatedListItemsClass.GetFancyFormAssociatedItemAttachments(xmlData, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContain("<div id='attach-wrapper'>"),
                () => result.ShouldContain("<table class='fancy-col-table'><tr><td style='color:#bbbbbb;'>There are no attachments, click the \"+\" icon above to upload new attachments.</td></tr></table>"),
                () => result.ShouldNotContain("<div id='attach-text-wrapper'>"),
                () => result.ShouldNotContain("<div class='attach-text'>"),
                () => result.ShouldNotContain("<span class='icon-file'  style='margin-right:5px;color:#999999;'></span>"),
                () => result.ShouldNotContain($"<a href='{DummyUrl}/{DummyString}/attachments/{DummyInt}/{DummyString}' target='_blank' ID='{DummyString}' class='fancybox'>"),
                () => result.ShouldNotContain($"<span>{DummyString}</span>"),
                () => result.ShouldNotContain($"<a href='#' onclick=\"javascript:FancyDispFormClient.DeleteItemAttachment('"),
                () => result.ShouldNotContain($"{ DummyUrl}/_layouts/epmlive/gridaction.aspx?action=deleteitemattachment&listid={ProjectListID}&itemid={DummyInt}&fname={DummyString}"),
                () => result.ShouldNotContain($"<span class='fui-cross delete' style='top:2px;position:relative;'></span>"));
        }

        [TestMethod]
        public void GetFancyFormAssociatedItemAttachments_OnError_ReturnErrorMessage()
        {
            // Arrange
            var xmlData = CreateXmlData();

            ShimSPSite.ConstructorGuid = (_, __) =>
            {
                throw new APIException(DummyInt, DummyError);
            };

            // Act
            var result = AssociatedListItemsClass.GetFancyFormAssociatedItemAttachments(xmlData, _web);

            // Assert
            result.ShouldBe($"<Result Status=\"{DummyInt}\"><Error ID=\"{DummyInt}\">Error: {DummyError}</Error></Result>");
        }
    }
}
