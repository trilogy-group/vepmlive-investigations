using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Fakes;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.IO.Fakes;
using System.Linq;
using System.Net.Mail.Fakes;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Xml;
using System.Xml.Linq;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using TimeSheets;
using TimeSheets.Fakes;

namespace EPMLiveTimesheets.Tests.WebPageCode
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class dotsactionTests
    {
        private dotsaction testObject;
        private PrivateObject privateObject;
        private IDisposable shimsContext;
        private BindingFlags publicStatic;
        private BindingFlags nonPublicStatic;
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
        private Dictionary<string, string> request;
        private Guid guid;
        private DateTime currentDate;
        private int validations;
        private const int DummyInt = 1;
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
        private const string CreatePeriodsMethodName = "CreatePeriods";
        private const string ApproveMethodName = "approve";
        private const string AutoAddMethodName = "autoAdd";
        private const string PageLoadMethodName = "Page_Load";

        [TestInitialize]
        public void Setup()
        {
            SetupShims();

            testObject = new dotsaction();
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
            ShimCoreFunctions.getLockedWebSPWeb = _ => guid;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => bool.FalseString;
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
            ShimSPUserCollection.AllInstances.ItemGetString = (_, __) => spUser;
            ShimSPSiteDataQuery.Constructor = _ => new ShimSPSiteDataQuery();
            ShimPage.AllInstances.ResponseGet = _ => new ShimHttpResponse();
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest();
            ShimHttpRequest.AllInstances.ItemGetString = (_, key) =>
            {
                if (request.ContainsKey(key))
                {
                    return request[key];
                }
                return DummyString;
            };
            ShimSharedFunctions.canUserImpersonateStringStringSPWebStringOut =
                (string curuser, string iuser, SPWeb web, out string resName) =>
                {
                    resName = DummyString;
                    return true;
                };
            ShimHttpResponse.AllInstances.ExpiresSetInt32 = (_, __) => { };
            ShimHttpResponse.AllInstances.CacheGet = _ => new ShimHttpCachePolicy();
            ShimHttpCachePolicy.AllInstances.SetCacheabilityHttpCacheability = (_, __) => { };
            ShimSPAdministrationWebApplication.LocalGet = () => new ShimSPAdministrationWebApplication();
            ShimSPWebApplication.AllInstances.OutboundMailServiceInstanceGet = _ => new ShimSPOutboundMailServiceInstance();
            ShimSPServiceInstance.AllInstances.ServerGet = _ => new ShimSPServer();
            ShimSPPersistedObject.AllInstances.NameGet = _ => DummyString;
        }

        private void SetupVariables()
        {
            validations = 0;
            publicStatic = BindingFlags.Static | BindingFlags.Public;
            nonPublicStatic = BindingFlags.Static | BindingFlags.NonPublic;
            publicInstance = BindingFlags.Instance | BindingFlags.Public;
            nonPublicInstance = BindingFlags.Instance | BindingFlags.NonPublic;
            guid = Guid.Parse(SampleGuidString1);
            request = new Dictionary<string, string>()
            {
                ["period"] = DummyString,
                ["action"] = DummyString,
                ["duser"] = DummyString,
                ["ts_uids"] = DummyString,
                ["tsitemuids"] = DummyString
            };
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
                TitleGet = () => DummyString
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
                UserTokenGet = () => new ShimSPUserToken(),
                EmailGet = () => DummyString
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
                ServerRelativeUrlGet = () => SampleUrl
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
                GetInt32Int32 = _ => One,
                GetDateTimeInt32 = _ => currentDate,
                GetStringInt32 = _ => DummyString,
                GetGuidInt32 = _ => guid,
                Close = () => { }
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void CreatePeriods_WhenCalled_ReturnsPeriodIds()
        {
            // Arrange
            var periods = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    ["start"] = currentDate.ToString(),
                    ["finish"] = currentDate.ToString(),
                },
                new Dictionary<string, string>()
                {
                    ["start"] = currentDate.ToString(),
                    ["finish"] = currentDate.ToString(),
                },
                new Dictionary<string, string>()
                {
                    ["start"] = currentDate.ToString(),
                    ["finish"] = currentDate.ToString(),
                }
            };
            var expected = new int[]
            {
                2, 3, 4
            };

            dataReader.Read = () => true;

            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                validations += 1;
                return DummyInt;
            };

            // Act
            var actual = (string[])privateObject.Invoke(
                CreatePeriodsMethodName,
                nonPublicStatic,
                new object[]
                {
                    default(SqlConnection),
                    periods
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Length.ShouldBe(3),
                () => expected.Any(x => !actual.Contains(x.ToString())).ShouldBeFalse(),
                () => validations.ShouldBe(3));
        }

        [TestMethod]
        public void Approve_StatusNotOne_SetsData()
        {
            // Arrange
            const string expected = "Success";
            const string xmlString = @"<xmlcfg Status=""0""/>";

            ShimTimesheetAPI.ApproveTimesheetsStringSPWeb = (_, __) =>
            {
                validations += 1;
                return xmlString;
            };

            // Act
            privateObject.Invoke(
                ApproveMethodName,
                nonPublicInstance,
                new object[]
                {
                    DummyString,
                    spWeb.Instance,
                    DummyString
                });
            var actual = (string)privateObject.GetFieldOrProperty("data", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void Approve_StatusOne_SetsData()
        {
            // Arrange
            var expected = $"Error: {DummyString}";
            var xmlString = $@"
                <xmlcfg Status=""1"">
                    <Error>{DummyString}</Error>
                </xmlcfg>";

            ShimTimesheetAPI.ApproveTimesheetsStringSPWeb = (_, __) =>
            {
                validations += 1;
                return xmlString;
            };

            // Act
            privateObject.Invoke(
                ApproveMethodName,
                nonPublicInstance,
                new object[]
                {
                    DummyString,
                    spWeb.Instance,
                    DummyString
                });
            var actual = (string)privateObject.GetFieldOrProperty("data", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void AutoAdd_WhenCalled_InsertsIntoDatabase()
        {
            // Arrange
            var rollupLists = "1";
            var readHit = 0;
            var dataTable = new DataTable();
            var row = default(DataRow);
            var columns = new List<string>()
            {
                "WEBID",
                "LISTID",
                "ID",
                "Title"
            };

            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }

            dataTable.Rows.Add(dataTable.NewRow());

            dataTable.Rows[0]["WEBID"] = SampleGuidString1;
            dataTable.Rows[0]["LISTID"] = SampleGuidString2;
            dataTable.Rows[0]["ID"] = One;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit <= One;
            };
            spWeb.GetSiteDataSPSiteDataQuery = _ => dataTable;

            ShimSPFieldLookupValue.AllInstances.LookupValueGet = _ => null;
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => DummyInt;
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readHit = 0;
                if (instance.CommandText.Equals("SELECT * FROM TSITEM where WEB_UID=@web_uid and LIST_UID = @list_uid and item_id=@item_id and ts_uid=@ts_uid"))
                {
                    readHit = 111;
                }
                return dataReader;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                validations += 1;
                return DummyInt;
            };
            ShimSharedFunctions.processResourcesSqlConnectionStringSPWebString = (_1, _2, _3, _4) =>
            {
                validations += 1;
            };
            ShimSharedFunctions.getProjectCenterListSPList = _ =>
            {
                validations += 1;
                return spList;
            };
            ShimSharedFunctions.processMetaSPWebSPListSPListItemGuidStringSqlConnectionSPList =
                (_1, _2, _3, _4, _5, _6, _7) =>
                {
                    validations += 1;
                };

            // Act
            privateObject.Invoke(
                AutoAddMethodName,
                nonPublicInstance,
                new object[]
                {
                    default(SqlConnection),
                    string.Empty,
                    spWeb.Instance,
                    rollupLists
                });

            // Assert
            validations.ShouldBe(6);
        }

        [TestMethod]
        public void PageLoad_ActionDeleteTS_DoesLoadEvents()
        {
            // Arrange
            const string expectedOutput = "Success";
            const string expectedQuery = "DELETE FROM TSTIMESHEET where ts_uid=@ts_uid";

            request["action"] = "deleteTS";

            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                if (instance.CommandText.Equals(expectedQuery))
                {
                    validations += 1;
                }
                return DummyInt;
            };

            // Act
            privateObject.Invoke(
                PageLoadMethodName,
                nonPublicInstance,
                new object[]
                {
                    default(object),
                    EventArgs.Empty
                });
            var actual = (string)privateObject.GetFieldOrProperty("data", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expectedOutput),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void PageLoad_ActionclosePeriod_DoesLoadEvents()
        {
            // Arrange
            const string expectedQuery = "update tsperiod set locked=1 where period_id=@periodid and site_id=@siteid";

            request["action"] = "closePeriod";

            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                if (instance.CommandText.Equals(expectedQuery))
                {
                    validations += 1;
                }
                return DummyInt;
            };

            // Act
            privateObject.Invoke(
                PageLoadMethodName,
                nonPublicInstance,
                new object[]
                {
                    default(object),
                    EventArgs.Empty
                });
            var actual = (string)privateObject.GetFieldOrProperty("data", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(DummyString),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void PageLoad_ActionopenPeriod_DoesLoadEvents()
        {
            // Arrange
            const string expectedQuery = "update tsperiod set locked=0 where period_id=@periodid and site_id=@siteid";

            request["action"] = "openPeriod";

            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                if (instance.CommandText.Equals(expectedQuery))
                {
                    validations += 1;
                }
                return DummyInt;
            };

            // Act
            privateObject.Invoke(
                PageLoadMethodName,
                nonPublicInstance,
                new object[]
                {
                    default(object),
                    EventArgs.Empty
                });
            var actual = (string)privateObject.GetFieldOrProperty("data", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(DummyString),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void PageLoad_ActiondeletePeriod_DoesLoadEvents()
        {
            // Arrange
            const string expectedQuery = "delete from tsperiod where period_id=@periodid and site_id=@siteid";

            request["action"] = "deletePeriod";

            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                if (instance.CommandText.Equals(expectedQuery))
                {
                    validations += 1;
                }
                return DummyInt;
            };

            // Act
            privateObject.Invoke(
                PageLoadMethodName,
                nonPublicInstance,
                new object[]
                {
                    default(object),
                    EventArgs.Empty
                });
            var actual = (string)privateObject.GetFieldOrProperty("data", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe("Success"),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void PageLoad_ActionaddPeriod_DoesLoadEvents()
        {
            // Arrange
            const string expectedQuery = "insert into tsperiod (period_start,period_end,period_id,site_id) values (@periodstart,@periodend,@period_id,@siteid)";
            const string expectedReaderQuery = "select top 1 period_id from tsperiod where site_id=@siteid order by period_id desc";

            request["action"] = "addPeriod";

            dataReader.Read = () => true;

            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                if (instance.CommandText.Equals(expectedQuery))
                {
                    validations += 1;
                }
                return DummyInt;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                if (instance.CommandText.Equals(expectedReaderQuery))
                {
                    validations += 1;
                }
                return dataReader;
            };

            // Act
            privateObject.Invoke(
                PageLoadMethodName,
                nonPublicInstance,
                new object[]
                {
                    default(object),
                    EventArgs.Empty
                });
            var actual = (string)privateObject.GetFieldOrProperty("data", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe("Success"),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void PageLoad_ActionaddType_DoesLoadEvents()
        {
            // Arrange
            const string expectedQuery = "insert into tstype (tstype_id,tstype_name,site_uid) values (@tstype_id,@tstype_name,@siteid)";
            const string expectedReaderQuery = "select top 1 tstype_id from tstype where site_uid=@siteid order by tstype_id desc";

            request["action"] = "addType";

            dataReader.Read = () => true;

            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                if (instance.CommandText.Equals(expectedQuery))
                {
                    validations += 1;
                }
                return DummyInt;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                if (instance.CommandText.Equals(expectedReaderQuery))
                {
                    validations += 1;
                }
                return dataReader;
            };

            // Act
            privateObject.Invoke(
                PageLoadMethodName,
                nonPublicInstance,
                new object[]
                {
                    default(object),
                    EventArgs.Empty
                });
            var actual = (string)privateObject.GetFieldOrProperty("data", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe("Success"),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void PageLoad_ActioneditType_DoesLoadEvents()
        {
            // Arrange
            const string expectedQuery = "update tstype set tstype_name = @tstype_name where tstype_id=@tstype_id and site_uid=@siteid";

            request["action"] = "editType";

            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                if (instance.CommandText.Equals(expectedQuery))
                {
                    validations += 1;
                }
                return DummyInt;
            };

            // Act
            privateObject.Invoke(
                PageLoadMethodName,
                nonPublicInstance,
                new object[]
                {
                    default(object),
                    EventArgs.Empty
                });
            var actual = (string)privateObject.GetFieldOrProperty("data", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe("Success"),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void PageLoad_ActionrejectTS_DoesLoadEvents()
        {
            // Arrange
            const string expectedQuery = "update TSTIMESHEET set approval_status=2,approval_notes=@notes where ts_uid=@ts_uid";

            request["action"] = "rejectTS";
            request["ts_uids"] = "1|2";

            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                if (instance.CommandText.Equals(expectedQuery))
                {
                    validations += 1;
                }
                return DummyInt;
            };
            ShimSharedFunctions.processActualWorkSqlConnectionStringSPSiteBooleanBoolean =
                (_1, _2, _3, _4, _5) => string.Empty;

            // Act
            privateObject.Invoke(
                PageLoadMethodName,
                nonPublicInstance,
                new object[]
                {
                    default(object),
                    EventArgs.Empty
                });
            var actual = (string)privateObject.GetFieldOrProperty("data", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe("Success"),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void PageLoad_ActionunlockTS_DoesLoadEvents()
        {
            // Arrange
            const string expectedQuery = "update TSTIMESHEET set approval_status=0 where ts_uid=@ts_uid";

            request["action"] = "unlockTS";
            request["ts_uids"] = "1|2";

            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                if (instance.CommandText.Equals(expectedQuery))
                {
                    validations += 1;
                }
                return DummyInt;
            };

            // Act
            privateObject.Invoke(
                PageLoadMethodName,
                nonPublicInstance,
                new object[]
                {
                    default(object),
                    EventArgs.Empty
                });
            var actual = (string)privateObject.GetFieldOrProperty("data", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe("Success"),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void PageLoad_ActionapprovePM_DoesLoadEvents()
        {
            // Arrange
            const string expectedQuery = "update tsitem set approval_status=1 where ts_item_uid=@tsitemuid";

            request["action"] = "approvePM";
            request["tsitemuids"] = "1|2";

            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                if (instance.CommandText.Equals(expectedQuery))
                {
                    validations += 1;
                }
                return DummyInt;
            };

            // Act
            privateObject.Invoke(
                PageLoadMethodName,
                nonPublicInstance,
                new object[]
                {
                    default(object),
                    EventArgs.Empty
                });
            var actual = (string)privateObject.GetFieldOrProperty("data", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe("Success"),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void PageLoad_ActionrejectPM_DoesLoadEvents()
        {
            // Arrange
            const string expectedQuery = "update tsitem set approval_status=2 where ts_item_uid=@tsitemuid";

            request["action"] = "rejectPM";
            request["tsitemuids"] = "1|2";

            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                if (instance.CommandText.Equals(expectedQuery))
                {
                    validations += 1;
                }
                return DummyInt;
            };

            // Act
            privateObject.Invoke(
                PageLoadMethodName,
                nonPublicInstance,
                new object[]
                {
                    default(object),
                    EventArgs.Empty
                });
            var actual = (string)privateObject.GetFieldOrProperty("data", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe("Success"),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void PageLoad_ActionsubmitTimeSettingTrue_DoesLoadEvents()
        {
            // Arrange
            const string expectedQuery = "update TSTIMESHEET set submitted=1,approval_status=0,lastmodifiedbyu=@u,lastmodifiedbyn=@n where ts_uid=@ts_uid";
            var columns = new List<string>()
            {
                "WEB_UID",
                "LIST_UID",
                "ITEM_ID",
                "ts_item_uid",
                "project"
            };
            var dataTable = new DataTable();
            var row = default(DataRow);

            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }
            for (var index = 0; index < 2; index++)
            {
                row = dataTable.NewRow();
                row["WEB_UID"] = SampleGuidString2;
                row["LIST_UID"] = SampleGuidString2;
                row["ITEM_ID"] = One;
                row["ts_item_uid"] = SampleGuidString2;
                row["project"] = DummyString;
                dataTable.Rows.Add(row);
            }

            request["action"] = "submitTime";

            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                if (instance.CommandText.Equals(expectedQuery))
                {
                    validations += 1;
                }
                return DummyInt;
            };
            ShimSharedFunctions.processResourcesSqlConnectionStringSPWebString = (_1, _2, _3, _4) =>
            {
                validations += 1;
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) =>
            {
                validations += 1;
                return bool.TrueString;
            };
            Shimdotsaction.AllInstances.approveStringSPWebString = (_, _1, _2, _3) =>
            {
                validations += 1;
            };
            ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSet) =>
            {
                dataSet.Tables.Add(dataTable);
                return DummyInt;
            };
            ShimSharedFunctions.processMetaSPWebSPListSPListItemGuidStringSqlConnectionSPList =
                (_1, _2, _3, _4, _5, _6, _7) =>
                {
                    validations += 1;
                };
            ShimSharedFunctions.getProjectCenterListSPList = _ =>
            {
                validations += 1;
                return spList;
            };

            // Act
            privateObject.Invoke(
                PageLoadMethodName,
                nonPublicInstance,
                new object[]
                {
                    default(object),
                    EventArgs.Empty
                });
            var actual = (string)privateObject.GetFieldOrProperty("data", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe("Success"),
                () => validations.ShouldBe(9));
        }

        [TestMethod]
        public void PageLoad_ActionsubmitTimeSettingFalse_DoesLoadEvents()
        {
            // Arrange
            const string expectedQuery = "update TSTIMESHEET set submitted=1,approval_status=0,lastmodifiedbyu=@u,lastmodifiedbyn=@n where ts_uid=@ts_uid";
            var columns = new List<string>()
            {
                "WEB_UID",
                "LIST_UID",
                "ITEM_ID",
                "ts_item_uid",
                "project"
            };
            var dataTable = new DataTable();
            var row = default(DataRow);

            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }
            for (var index = 0; index < 2; index++)
            {
                row = dataTable.NewRow();
                row["WEB_UID"] = SampleGuidString2;
                row["LIST_UID"] = SampleGuidString2;
                row["ITEM_ID"] = One;
                row["ts_item_uid"] = SampleGuidString2;
                row["project"] = DummyString;
                dataTable.Rows.Add(row);
            }

            request["action"] = "submitTime";

            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                if (instance.CommandText.Equals(expectedQuery))
                {
                    validations += 1;
                }
                return DummyInt;
            };
            ShimSharedFunctions.processResourcesSqlConnectionStringSPWebString = (_1, _2, _3, _4) =>
            {
                validations += 1;
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) =>
            {
                validations += 1;
                return bool.FalseString;
            };
            Shimdotsaction.AllInstances.approveStringSPWebString = (_, _1, _2, _3) =>
            {
                validations += 1;
            };
            ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSet) =>
            {
                dataSet.Tables.Add(dataTable);
                return DummyInt;
            };
            ShimSharedFunctions.processMetaSPWebSPListSPListItemGuidStringSqlConnectionSPList =
                (_1, _2, _3, _4, _5, _6, _7) =>
                {
                    validations += 1;
                };
            ShimSharedFunctions.getProjectCenterListSPList = _ =>
            {
                validations += 1;
                return spList;
            };
            ShimSharedFunctions.processActualWorkSqlConnectionStringSPSiteBooleanBoolean =
                (_1, _2, _3, _4, _5) =>
                {
                    validations += 1;
                    return DummyString;
                };

            // Act
            privateObject.Invoke(
                PageLoadMethodName,
                nonPublicInstance,
                new object[]
                {
                    default(object),
                    EventArgs.Empty
                });
            var actual = (string)privateObject.GetFieldOrProperty("data", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(DummyString),
                () => validations.ShouldBe(9));
        }

        [TestMethod]
        public void PageLoad_ActionunsubmitTime_DoesLoadEvents()
        {
            // Arrange
            const string expectedQuery = "update TSTIMESHEET set submitted=0,approval_status=0,lastmodifiedbyu=@u,lastmodifiedbyn=@n where ts_uid=@ts_uid";
            var methodHit = 0;

            request["action"] = "unsubmitTime";

            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                if (instance.CommandText.Equals(expectedQuery))
                {
                    validations += 1;
                }
                return DummyInt;
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) =>
            {
                validations += 1;
                methodHit += 1;
                return methodHit.Equals(1) ? bool.FalseString : bool.TrueString;
            };
            ShimSharedFunctions.processActualWorkSqlConnectionStringSPSiteBooleanBoolean =
                (_1, _2, _3, _4, _5) =>
                {
                    validations += 1;
                    return string.Empty;
                };

            // Act
            privateObject.Invoke(
                PageLoadMethodName,
                nonPublicInstance,
                new object[]
                {
                    default(object),
                    EventArgs.Empty
                });
            var actual = (string)privateObject.GetFieldOrProperty("data", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe("Success"),
                () => validations.ShouldBe(4));
        }

        [TestMethod]
        public void PageLoad_Actionautoadd_DoesLoadEvents()
        {
            // Arrange
            request["action"] = "autoadd";

            Shimdotsaction.AllInstances.autoAddSqlConnectionStringSPWebString = (_, _1, _2, _3, _4) =>
            {
                validations += 1;
            };

            // Act
            privateObject.Invoke(
                PageLoadMethodName,
                nonPublicInstance,
                new object[]
                {
                    default(object),
                    EventArgs.Empty
                });
            var actual = (string)privateObject.GetFieldOrProperty("data", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe("Success"),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void PageLoad_ActionrejectEmail_DoesLoadEvents()
        {
            // Arrange
            const string expectedQuery = "select username,approval_notes,period_start,period_end from vwTSApprovalNotes where ts_uid=@ts_uid";
            var expectedSubject = $"{DummyString} Timesheet approval notice";
            var expectedBody = $"Your timesheet for period ({currentDate.ToShortDateString()} - {currentDate.ToShortDateString()}) has been rejected:<br>{DummyString}";

            request["action"] = "rejectEmail";
            spUser.EmailGet = () => $"{DummyString}@{DummyString}.com";
            dataReader.Read = () => true;

            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                if (instance.CommandText.Equals(expectedQuery))
                {
                    validations += 1;
                }
                return dataReader;
            };
            ShimSmtpClient.AllInstances.SendMailMessage = (smtpClient, message) =>
            {
                if(smtpClient.Host.Equals(DummyString))
                {
                    validations += 1;
                }
                if(message.Subject.Equals(expectedSubject))
                {
                    validations += 1;
                }
                if (message.Body.Equals(expectedBody))
                {
                    validations += 1;
                }
            };

            // Act
            privateObject.Invoke(
                PageLoadMethodName,
                nonPublicInstance,
                new object[]
                {
                    default(object),
                    EventArgs.Empty
                });
            var actual = (string)privateObject.GetFieldOrProperty("data", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe("Success"),
                () => validations.ShouldBe(4));
        }
    }
}