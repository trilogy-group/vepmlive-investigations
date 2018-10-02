using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private int _reportingDBQueryExecutedCount;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string DummyUrl = "http://xyz.com";
        private const string DummyError = "Dummy Error";
        private const string SiteID = "1941810b-e7ec-4c0d-a512-b50a84761e71";
        private const string WebID = "06676109-36f8-4957-a41a-9464d4e52fc5";
        private const string ProjectListID = "f42cdfdd-f66d-4588-8d2b-0dcd5fab4bc1";
        private const string ProjectID = "69490876-7284-4f10-9d1f-508230a8f76e";

        [TestInitialize]
        public void TestInitialize()
        {
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

            };

            var count = 0;
            var list = new ShimSPList
            {
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
                                TitleGet = () => $"{DummyString}{DummyInt}_____________"
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
                }
            };

            _web = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetGuid = _ => list,
                    ItemGetString = _ => list
                }
            };

            ShimSPSite.ConstructorString = (_, __) => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => _web;
            ShimSPSite.AllInstances.Dispose = _ => { };

            ShimSPWeb.AllInstances.Dispose = _ => { };

            ShimSPQuery.Constructor = _ => { };

            var associatedListInfo = new ShimAssociatedListInfo().Instance;
            var privateAssociatedListInto = new PrivateObject(associatedListInfo);
            privateAssociatedListInto.SetFieldOrProperty("Title", DummyString);

            ShimListCommands.GetAssociatedListsSPList = _ => new ArrayList() { associatedListInfo };

            var gridGantt = new ShimGridGanttSettings().Instance;
            var privateGridGantt = new PrivateObject(gridGantt);
            privateGridGantt.SetFieldOrProperty("HideNewButton", false);

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
            dataTable.Columns.Add("RPTListID");
            dataTable.Columns.Add("ListName");
            dataTable.Columns.Add("TableName");
            dataTable.Columns.Add("Count");

            var dataRow = dataTable.NewRow();
            dataRow["RPTListID"] = DummyString;
            dataRow["ListName"] = DummyString;
            dataRow["TableName"] = DummyString;
            dataRow["Count"] = DummyInt;

            dataTable.Rows.Add(dataRow);

            var dataRow2 = dataTable.NewRow();
            dataRow2["RPTListID"] = string.Empty;
            dataRow2["ListName"] = DummyString;
            dataRow2["TableName"] = DummyString;
            dataRow2["Count"] = DummyInt;

            dataTable.Rows.Add(dataRow2);

            return dataTable;
        }

        [TestMethod]
        public void GetAssociatedItems_WhenRPTListIdIsNotNull_ConfirmResult()
        {
            // Arrange
            var xmlData = CreateXmlData();

            // Act
            var result = AssociatedListItemsClass.GetAssociatedItems(xmlData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingDBQueryExecutedCount.ShouldBe(2),
                () => result.ShouldContain($"<div id='div_{DummyString}' class='listMainDiv'>"),
                () => result.ShouldContain($"<div id='div_items_{DummyString}' class='slidingDiv'>"),
                () => result.ShouldContain($"<div class='slidingDivHeader'>{DummyString}</div>"),
                () => result.ShouldContain($"<div class='slidingDivAdd'>"),
                () => result.ShouldContain($"<a href='#' onclick=\"javascript:showNewForm('?LookupField=Project&LookupValue=69490876-7284-4f10-9d1f-508230a8f76e');return false;\">"),
                () => result.ShouldContain($"<img title='Add new {DummyString}' alt='' src='/_layouts/epmlive/images/newitem5.png' class='ms-core-menu-buttonIcon'>"),
                () => result.ShouldContain($"onclick=\"javascript:showNewForm('?ID=1&Source=http%3a%2f%2fxyz.com%2f');return false;\""),
                () => result.ShouldContain($"{DummyString}{DummyInt}________..."),
                () => result.ShouldContain($"<li class='associateditemscontextmenu'>"),
                () => result.ShouldContain($"data-webid='{WebID}'"),
                () => result.ShouldContain($"data-siteid='{SiteID}'"),
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
                      </Root>";
        }
    }
}
