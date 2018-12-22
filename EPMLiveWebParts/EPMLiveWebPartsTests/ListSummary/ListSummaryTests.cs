using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Fakes;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Web.Fakes;
using System.Xml;
using EPMLiveCore.Fakes;
using EPMLiveWebParts.Fakes;
using EPMLiveWebParts.Utilities.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ListSummaryTests
    {
        private ListSummary testObject;
        private PrivateObject privateObject;
        private IDisposable shimsContext;
        private BindingFlags publicInstance;
        private BindingFlags nonPublicInstance;
        private ShimSPWeb spWeb;
        private ShimSPSite spSite;
        private ShimSPListCollection spListCollection;
        private ShimSPList spList;
        private ShimSPListItemCollection spListItemCollection;
        private ShimSPListItem spListItem;
        private ShimSPFieldCollection spFieldCollection;
        private ShimSPField spField;
        private ShimSPUser spUser;
        private ShimSPFolderCollection spFolderCollection;
        private ShimSPFolder spFolder;
        private ShimSPFileCollection spFileCollection;
        private ShimSPFile spFile;
        private ShimSPViewCollection spViewCollection;
        private ShimSPView spView;
        private ShimSPViewFieldCollection spViewFieldCollection;
        private ShimSPFieldLinkCollection spFieldLinkCollection;
        private ShimSPContentTypeCollection spContentTypeCollection;
        private ShimSPContentType spContentType;
        private ShimSqlTransaction transaction;
        private ShimSqlDataReader dataReader;
        private Guid guid;
        private DateTime currentDate;
        private int validations;
        private const int DummyInt = 1;
        private const int Zero = 0;
        private const int One = 1;
        private const int Two = 2;
        private const int Three = 3;
        private const int Four = 4;
        private const int Five = 5;
        private const string SampleGuidString1 = "83e81819-0112-4c22-bb70-d8ba101e9e0c";
        private const string SampleGuidString2 = "83e81819-0104-4c22-bb70-d8ba101e9e0c";
        private const string DummyString = "DummyString";
        private const string IDStringCaps = "ID";
        private const string SampleUrl = "http://www.sampleurl.com";
        private const string ProcessWebMethodName = "processWeb";

        [TestInitialize]
        public void Setup()
        {
            SetupShims();

            testObject = new ListSummary();
            privateObject = new PrivateObject(testObject);
        }

        private void SetupShims()
        {
            shimsContext = ShimsContext.Create();
            SetupVariables();

            ShimSqlConnection.ConstructorString = (_, __) => new ShimSqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlConnection.AllInstances.BeginTransaction = _ => transaction;
            ShimDbTransaction.AllInstances.Dispose = _ => { };
            ShimSqlConnection.AllInstances.CreateCommand = _ => new SqlCommand();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => DummyInt;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => dataReader;
            ShimComponent.AllInstances.Dispose = _ => { };
            ShimSqlCommand.AllInstances.TransactionSetSqlTransaction = (_, __) => { };
            ShimSPDatabase.AllInstances.DatabaseConnectionStringGet = _ => DummyString;
            ShimGridGanttSettings.ConstructorSPList = (_, __) => new ShimGridGanttSettings();
            ShimHttpUtility.HtmlEncodeString = input => input;
            ShimSPSite.ConstructorString = (_, __) => new ShimSPSite();
            ShimSPSite.ConstructorGuid = (_, __) => new ShimSPSite();
            ShimSPSite.ConstructorGuidSPUserToken = (_, _1, _2) => new ShimSPSite();
            ShimSPSite.AllInstances.OpenWeb = _ => spWeb;
            ShimSPSite.AllInstances.OpenWebString = (_, __) => spWeb;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => spWeb;
            ShimSPSite.AllInstances.Dispose = _ => { };
            ShimSPWeb.AllInstances.Dispose = _ => { };
            ShimSPSite.AllInstances.ContentDatabaseGet = _ => new ShimSPContentDatabase();
            ShimCoreFunctions.getLockedWebSPWeb = _ => guid;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => DummyString;
            ShimCoreFunctions.getListSettingStringSPList = (_, __) => DummyString;
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (_1, _2, _3) => DummyString;
            ShimSPList.AllInstances.GetItemsSPQuery = (_, __) => spListItemCollection;
            ShimSPPersistedObject.AllInstances.IdGet = _ => guid;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();
            ShimUnsecuredLayoutsPageBase.AllInstances.SiteGet = _ => spSite;
            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = _ => spWeb;
            ShimAct.ConstructorSPWeb = (_, __) => new ShimAct();
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => spWeb;
            ShimSPContext.AllInstances.SiteGet = _ => spSite;
            ShimSPFieldLookupValueCollection.ConstructorString = (_, __) => new ShimSPFieldLookupValueCollection();
            ShimSPFieldLookupValue.ConstructorString = (_, __) => new ShimSPFieldLookupValue();
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => DummyInt;
            ShimDisabledItemEventScope.Constructor = _ => new ShimDisabledItemEventScope();
            ShimDisabledItemEventScope.AllInstances.Dispose = _ => { };
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, __) => spUser;
            ShimSPSiteDataQuery.Constructor = _ => new ShimSPSiteDataQuery();
            ShimHttpContext.CurrentGet = () => new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    QueryStringGet = () => new NameValueCollection()
                    {
                        ["lookupfield"] = "lookupfield",
                        ["lookupfieldlist"] = "lookupfieldlist"
                    }
                }
            };
        }

        private void SetupVariables()
        {
            validations = 0;
            publicInstance = BindingFlags.Instance | BindingFlags.Public;
            nonPublicInstance = BindingFlags.Instance | BindingFlags.NonPublic;
            guid = Guid.Parse(SampleGuidString1);
            currentDate = DateTime.Now;
            spWeb = new ShimSPWeb()
            {
                IDGet = () => guid,
                SiteGet = () => spSite,
                ListsGet = () => spListCollection,
                GetFolderString = _ => spFolder,
                GetFileString = _ => spFile,
                FoldersGet = () => spFolderCollection,
                CurrentUserGet = () => spUser,
                ServerRelativeUrlGet = () => SampleUrl,
                AllUsersGet = () => new ShimSPUserCollection(),
                SiteUsersGet = () => new ShimSPUserCollection(),
                GetListFromUrlString = _ => spList
            };
            spSite = new ShimSPSite()
            {
                IDGet = () => guid,
                WebApplicationGet = () => new ShimSPWebApplication(),
                RootWebGet = () => spWeb,
                FeaturesGet = () => new ShimSPFeatureCollection()
                {
                    ItemGetGuid = _ => new ShimSPFeature()
                },
                ContentDatabaseGet = () => new ShimSPContentDatabase()
            };
            spListCollection = new ShimSPListCollection()
            {
                TryGetListString = _ => spList,
                ItemGetString = _ => spList,
                ItemGetGuid = _ => spList
            };
            spList = new ShimSPList()
            {
                IDGet = () => guid,
                FieldsGet = () => spFieldCollection,
                GetItemByIdInt32 = _ => spListItem,
                ItemsGet = () => spListItemCollection,
                GetItemsSPQuery = _ => spListItemCollection,
                RootFolderGet = () => spFolder,
                ParentWebGet = () => spWeb,
                DefaultViewGet = () => spView,
                ViewsGet = () => spViewCollection,
                ContentTypesGet = () => spContentTypeCollection,
                TitleGet = () => DummyString,
                EventReceiversGet = () => new ShimSPEventReceiverDefinitionCollection(),
                DefaultViewUrlGet = () => SampleUrl
            };
            spListItemCollection = new ShimSPListItemCollection()
            {
                CountGet = () => DummyInt,
                ItemGetInt32 = _ => spListItem
            };
            spListItem = new ShimSPListItem()
            {
                IDGet = () => DummyInt,
                TitleGet = () => DummyString,
                ItemGetString = _ => DummyString,
                ItemGetGuid = _ => DummyString,
                ItemSetGuidObject = (_, __) => { },
                Update = () => { },
                FileGet = () => spFile,
                ParentListGet = () => spList,
                NameGet = () => DummyString
            };
            spFieldCollection = new ShimSPFieldCollection()
            {
                GetFieldByInternalNameString = _ => spField,
                ContainsFieldString = _ => false,
                GetFieldString = _ => spField,
                ItemGetString = _ => spField
            };
            spField = new ShimSPField()
            {
                IdGet = () => guid,
                TitleGet = () => DummyString,
                InternalNameGet = () => DummyString,
                ReadOnlyFieldGet = () => false,
                HiddenGet = () => false,
                ReorderableGet = () => true,
                TypeAsStringGet = () => DummyString
            };
            spUser = new ShimSPUser()
            {
                IDGet = () => DummyInt,
                IsSiteAdminGet = () => true,
                UserTokenGet = () => new ShimSPUserToken()
            };
            spFolderCollection = new ShimSPFolderCollection()
            {
                ItemGetString = _ => spFolder,
                AddString = _ => spFolder
            };
            spFolder = new ShimSPFolder()
            {
                ExistsGet = () => false,
                SubFoldersGet = () => spFolderCollection,
                FilesGet = () => spFileCollection,
                UrlGet = () => SampleUrl,
                UniqueIdGet = () => guid,
                ParentWebGet = () => spWeb
            };
            spFileCollection = new ShimSPFileCollection()
            {
                CountGet = () => DummyInt,
                AddStringByteArrayBoolean = (_1, _2, _3) => spFile,
                AddStringStream = (_1, _2) => spFile,
                ItemGetString = _ => spFile
            };
            spFile = new ShimSPFile()
            {
                Delete = () => { },
                OpenBinaryStream = () => null,
                NameGet = () => DummyString,
                GetListItemStringArray = _ => spListItem
            };
            spViewCollection = new ShimSPViewCollection()
            {
                ItemGetString = _ => spView
            };
            spView = new ShimSPView()
            {
                ViewFieldsGet = () => spViewFieldCollection,
                ServerRelativeUrlGet = () => SampleUrl,
                QueryGet = () => DummyString
            };
            spViewFieldCollection = new ShimSPViewFieldCollection();
            spContentTypeCollection = new ShimSPContentTypeCollection()
            {
                ItemGetString = _ => spContentType
            };
            spContentType = new ShimSPContentType()
            {
                IdGet = () => default(SPContentTypeId),
                FieldLinksGet = () => spFieldLinkCollection
            };
            spFieldLinkCollection = new ShimSPFieldLinkCollection()
            {
                ItemGetGuid = _ => new ShimSPFieldLink()
            };
            transaction = new ShimSqlTransaction()
            {
                Commit = () => { },
                Rollback = () => { }
            };
            dataReader = new ShimSqlDataReader()
            {
                Read = () => false,
                Close = () => { },
                ItemGetString = input => input,
                GetGuidInt32 = _ => guid
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void ProcessWeb_RollupListNotEmpty_ProcessesWeb()
        {
            // Arrange
            var schemaXml = $@"
                <xmlcfg>
                    <CHOICE>{DummyString}</CHOICE>
                </xmlcfg>";
            var expected = $"<Lists MaxListLimit='0'><List ID='{guid}'/></Lists>";
            var expectedError = $"Get Rollup Site Data Error: {DummyString}<br>";
            var expectedQuery = $"SELECT     dbo.AllLists.tp_ID FROM         dbo.Webs INNER JOIN dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId WHERE     webs.siteid='{guid}' AND (dbo.AllLists.tp_Title like '{DummyString}')";
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };
            spWeb.ServerRelativeUrlGet = () => SampleUrl;
            spWeb.GetSiteDataSPSiteDataQuery = _ => new DataTable();
            spField.TypeGet = () => SPFieldType.Choice;
            spField.SchemaXmlGet = () => schemaXml;

            ShimListSummary.AllInstances.ProcessReportFilterXmlDocumentSPListSPWeb = (_, _1, _2, _3) =>
            {
                validations += 1;
                return DummyString;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readHit = 0;
                if (instance.CommandText.Equals(expectedQuery))
                {
                    validations += 1;
                }
                return dataReader;
            };
            ShimSPSiteDataQuery.AllInstances.ListsSetString = (_, input) =>
            {
                if (input.Equals(expected))
                {
                    validations += 1;
                }
            };
            ShimSPSiteDataQuery.AllInstances.QuerySetString = (_, __) =>
            {
                validations += 1;
            };
            ShimSPSiteDataQuery.AllInstances.WebsSetString = (_, __) =>
            {
                validations += 1;
            };
            ShimSPSiteDataQuery.AllInstances.ViewFieldsSetString = (_, __) =>
            {
                validations += 1;
            };
            ShimSPSiteDataQuery.AllInstances.QueryThrottleModeSetSPQueryThrottleOption = (_, input) =>
            {
                if (input.Equals(SPQueryThrottleOption.Override))
                {
                    validations += 1;
                }
            };
            ShimListSummary.AllInstances.processListDataTable = (_, input) =>
            {
                if (input != null)
                {
                    validations += 1;
                }
                throw new Exception(DummyString);
            };
            ShimLookupFilterHelper.AppendLookupQueryToExistingQueryXmlDocumentRefStringString =
                (ref XmlDocument xmlQuery, string lookupField, string lookupFieldList) =>
                {
                    validations += 1;
                };

            privateObject.SetFieldOrProperty("PropStatus", publicInstance, DummyString);
            privateObject.SetFieldOrProperty("PropRollupList", publicInstance, DummyString);
            privateObject.SetFieldOrProperty("sErrors", nonPublicInstance, string.Empty);

            // Act
            privateObject.Invoke(
                ProcessWebMethodName,
                nonPublicInstance,
                new object[]
                {
                    spWeb.Instance
                });
            var error = (string)privateObject.GetFieldOrProperty("sErrors", nonPublicInstance);
            var status = (SortedList<string, int>)privateObject.GetFieldOrProperty("slStatus", nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => error.ShouldBe(expectedError),
                () => status.Count.ShouldBe(1),
                () => status[DummyString].ShouldBe(Zero),
                () => validations.ShouldBe(8));
        }

        [TestMethod]
        public void ProcessWeb_RollupListEmpty_ProcesssesWeb()
        {
            // Arrange
            var schemaXml = $@"
                <xmlcfg>
                    <CHOICE>{DummyString}</CHOICE>
                </xmlcfg>";
            var expected = $"<Lists MaxListLimit='0'><List ID='{guid}'/></Lists>";
            var expectedError = $"Get Site Data Error: {DummyString}<br>";
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };
            spWeb.ServerRelativeUrlGet = () => SampleUrl;
            spWeb.GetSiteDataSPSiteDataQuery = _ => new DataTable();
            spField.TypeGet = () => SPFieldType.Choice;
            spField.SchemaXmlGet = () => schemaXml;

            ShimListSummary.AllInstances.ProcessReportFilterXmlDocumentSPListSPWeb = (_, _1, _2, _3) =>
            {
                validations += 1;
                return DummyString;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readHit = 0;
                return dataReader;
            };
            ShimSPSiteDataQuery.AllInstances.ListsSetString = (_, input) =>
            {
                if (input.Equals(expected))
                {
                    validations += 1;
                }
            };
            ShimSPSiteDataQuery.AllInstances.QuerySetString = (_, __) =>
            {
                validations += 1;
            };
            ShimSPSiteDataQuery.AllInstances.WebsSetString = (_, __) =>
            {
                validations += 1;
            };
            ShimSPSiteDataQuery.AllInstances.ViewFieldsSetString = (_, __) =>
            {
                validations += 1;
            };
            ShimSPSiteDataQuery.AllInstances.QueryThrottleModeSetSPQueryThrottleOption = (_, input) =>
            {
                if (input.Equals(SPQueryThrottleOption.Override))
                {
                    validations += 1;
                }
            };
            ShimListSummary.AllInstances.processListDataTable = (_, input) =>
            {
                if (input != null)
                {
                    validations += 1;
                }
                throw new Exception(DummyString);
            };
            ShimLookupFilterHelper.AppendLookupQueryToExistingQueryXmlDocumentRefStringString =
                (ref XmlDocument xmlQuery, string lookupField, string lookupFieldList) =>
                {
                    validations += 1;
                };

            privateObject.SetFieldOrProperty("PropStatus", publicInstance, DummyString);
            privateObject.SetFieldOrProperty("PropRollupList", publicInstance, string.Empty);
            privateObject.SetFieldOrProperty("sErrors", nonPublicInstance, string.Empty);

            // Act
            privateObject.Invoke(
                ProcessWebMethodName,
                nonPublicInstance,
                new object[]
                {
                    spWeb.Instance
                });
            var error = (string)privateObject.GetFieldOrProperty("sErrors", nonPublicInstance);
            var status = (SortedList<string, int>)privateObject.GetFieldOrProperty("slStatus", nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => error.ShouldBe(expectedError),
                () => status.Count.ShouldBe(1),
                () => status[DummyString].ShouldBe(Zero),
                () => validations.ShouldBe(7));
        }
    }
}