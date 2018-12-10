using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EPMLiveCore.API;
using EPMLiveCore.Properties;
using EPMLiveCore.ReportingProxy.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API
{
    [TestClass, ExcludeFromCodeCoverage]
    public class WorkspaceCenterTests
    {
        private const int Id = 1;
        private const int DefaultErrorNumber = 2000;
        private const string DummyString = "DummyString";
        private const string ExampleUrl = "http://example.com";
        private const string Title = "Title";
        private const string ListTitle = "List Title";
        private const string FieldTitle = "Field Title";
        private const string MyFavorite = "MyFavorite";
        private const string WebTitle = "WebTitle";
        private const string WebDescription = "WebDescription";
        private const string Members = "Members";
        private const string SharePointAccountText = "SharePointAccountText";
        private const string KeyId = "Id";
        private const string KeySiteId = "SiteId";
        private static readonly Guid DefaultWebId = Guid.NewGuid();
        private static readonly Guid DefaultSiteId = Guid.NewGuid();
        private static readonly DateTime DefaultDate = new DateTime(2019, 1, 1);
        private IDisposable _shimsContext;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            PrepareSpContext();
            ShimConnectionMethods();

            ShimQueryExecutor.AllInstances.ExecuteQueryStringIEnumerableOfKeyValuePairOfStringObjectCommandTypeString =
                (a, b, c, d, e) =>
                {
                    var dataTable = new DataTable();
                    dataTable.Columns.Add(KeyId);
                    dataTable.Columns.Add("WebId", typeof(Guid));
                    dataTable.Columns.Add("WEB_ID", typeof(Guid));
                    dataTable.Columns.Add("HasAccess", typeof(int));
                    dataTable.Columns.Add(KeySiteId, typeof(Guid));
                    dataTable.Columns.Add("WebUrl");
                    dataTable.Columns.Add(WebTitle);
                    dataTable.Columns.Add(WebDescription);
                    dataTable.Columns.Add(Members);
                    dataTable.Columns.Add(SharePointAccountText);

                    dataTable.Rows.Add(new object[]
                    {
                        DefaultWebId,
                        DefaultWebId,
                        DefaultWebId,
                        Id,
                        DefaultSiteId,
                        ExampleUrl,
                        WebTitle,
                        WebDescription,
                        Members,
                        SharePointAccountText });
                    return dataTable;
                };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void GetWorkspaceCenterGridData_MyFavorite_ReturnsXml()
        {
            // Arrange, Act
            var result = WorkspaceCenter.GetWorkspaceCenterGridData(MyFavorite, new ShimSPWeb());

            // Assert
            result.ShouldNotBeNullOrEmpty();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContain($"<I WorkSpace=\"&lt;div&gt; &lt;div style='float:left;'&gt;&lt;a href='{ExampleUrl}'&gt;{WebTitle}&lt;/a&gt;"),
                () => result.ShouldContain($"&lt;/div&gt;&lt;div style='float:right;'&gt;&lt;ul style='margin: 0px; width: 20px;'&gt;&lt;li class='workspacecentercontextmenu' id='{DefaultWebId}'&gt;"),
                () => result.ShouldContain($"&lt;a data-webid='{DefaultWebId}' data-siteid='{DefaultSiteId}'&gt;&lt;/a&gt;&lt;/li&gt;&lt;/ul&gt;&lt;/div&gt;&lt;/div&gt;\""),
                () => result.ShouldContain($"Description=\"{WebDescription}\" Owner=\"{SharePointAccountText}\" CreateDate=\"{DefaultDate.ToShortDateString()}\" ModifiedDate=\"{DefaultDate.ToShortDateString()}\" Members=\"{Members}\" />"));
        }

        [TestMethod]
        public void GetWorkspaceCenterGridData_Standard_ReturnsXml()
        {
            // Arrange, Act
            var result = WorkspaceCenter.GetWorkspaceCenterGridData(DummyString, new ShimSPWeb());

            // Assert
            result.ShouldNotBeNullOrEmpty();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContain($"<I WorkSpace=\"&lt;div&gt; &lt;div style='float:left;'&gt;&lt;a href='{ExampleUrl}'&gt;{WebTitle}&lt;/a&gt;"),
                () => result.ShouldContain($"&lt;/div&gt;&lt;div style='float:right;'&gt;&lt;ul style='margin: 0px; width: 20px;'&gt;&lt;li class='workspacecentercontextmenu' id='{DefaultWebId}'&gt;"),
                () => result.ShouldContain($"&lt;a data-webid='{DefaultWebId}' data-siteid='{DefaultSiteId}'&gt;&lt;/a&gt;&lt;/li&gt;&lt;/ul&gt;&lt;/div&gt;&lt;/div&gt;\""),
                () => result.ShouldContain($"Description=\"{WebDescription}\" Owner=\"{SharePointAccountText}\" CreateDate=\"{DefaultDate.ToShortDateString()}\" ModifiedDate=\"{DefaultDate.ToShortDateString()}\" Members=\"{Members}\" />"));
        }

        [TestMethod]
        public void GetSpContentDbSqlConnection_ApiException_Throws()
        {
            // Arrange
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated =
                _ => { throw new APIException(DefaultErrorNumber, DummyString); };

            // Act
            var action = new Action(() => WorkspaceCenter.GetSpContentDbSqlConnection(new ShimSPWeb()));

            // Assert
            var exception = action.ShouldThrow<APIException>();
            this.ShouldSatisfyAllConditions(
                () => exception.ExceptionNumber.ShouldBe(DefaultErrorNumber),
                () => exception.Message.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetSpContentDbSqlConnection_InvalidOperationException_Throws()
        {
            // Arrange
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated =
                _ => { throw new InvalidOperationException(DummyString); };

            // Act
            var action = new Action(() => WorkspaceCenter.GetSpContentDbSqlConnection(new ShimSPWeb()));

            // Assert
            var exception = action.ShouldThrow<APIException>();
            this.ShouldSatisfyAllConditions(
                () => exception.ExceptionNumber.ShouldBe(2008),
                () => exception.Message.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetWorkSpaceCenterLayout_Invoke_ReturnsXml()
        {
            // Arrange
            var expectedDocument = XDocument.Parse(Resources.WorkSpaceCenterLayout);

            // Act
            var result = WorkspaceCenter.GetWorkSpaceCenterLayout(DummyString);

            // Assert
            expectedDocument.ShouldNotBeNull();
            result.ShouldNotBeNullOrEmpty();
            result.ShouldBe(expectedDocument.ToString());
        }

        private void PrepareSpContext()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();

            ShimSPWebCollection.AllInstances.ItemGetGuid = (_, __) => new ShimSPWeb();
            var listCollection = new ShimSPListCollection();
            ShimSPWeb.AllInstances.ListsGet = _ => listCollection.Bind(new SPList[] { new ShimSPList() });
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPUser.AllInstances.IDGet = _ => Id;

            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => new ShimSPWeb();
            ShimSPSite.AllInstances.AllWebsGet = _ => new ShimSPWebCollection();
            ShimSPSite.AllInstances.ContentDatabaseGet = _ => new ShimSPContentDatabase();
            ShimSPSite.AllInstances.SiteIdGet = _ => DefaultSiteId;
            ShimSPSite.AllInstances.IDGet = _ => DefaultSiteId;

            ShimSPListCollection.AllInstances.ItemGetString = (_, __) => new ShimSPList();
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, __) => new ShimSPList();
            ShimSPList.AllInstances.TitleGet = _ => ListTitle;
            var listItemCollection = new ShimSPListItemCollection();
            ShimSPList.AllInstances.GetItemsSPQuery = (_, __) => listItemCollection.Bind(new SPListItem[] { new ShimSPListItem() });
            var fieldCollection = new ShimSPFieldCollection();
            ShimSPList.AllInstances.FieldsGet = _ => fieldCollection.Bind(new SPField[] { new ShimSPField() });
            ShimSPListItem.AllInstances.TitleGet = _ => DummyString;

            ShimSPFieldCollection.AllInstances.ItemGetString = (_, __) => new ShimSPField();
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField();
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, __) => true;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Text;
            ShimSPField.AllInstances.TitleGet = _ => FieldTitle;
            ShimSPField.AllInstances.InternalNameGet = _ => Title;
            ShimSPField.AllInstances.ReorderableGet = _ => true;

            ShimSPFieldMultiChoice.AllInstances.ChoicesGet = _ => new StringCollection { DummyString };
            ShimSPFieldLookup.AllInstances.LookupWebIdGet = _ => DefaultWebId;

            ShimSPDatabase.AllInstances.DatabaseConnectionStringGet = _ => DummyString;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code?.Invoke();
        }

        private void ShimConnectionMethods()
        {
            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimDbDataAdapter.AllInstances.FillDataTable = (_, dataTable) =>
            {
                dataTable.Columns.Add(KeyId, typeof(Guid));
                dataTable.Columns.Add(KeySiteId, typeof(Guid));
                dataTable.Columns.Add("TimeCreated", typeof(DateTime));
                dataTable.Columns.Add("LastMetadataChange", typeof(DateTime));
                dataTable.Rows.Add(new object[] { DefaultWebId, DefaultSiteId, DefaultDate, DefaultDate });
                return 1;
            };
        }
    }
}
