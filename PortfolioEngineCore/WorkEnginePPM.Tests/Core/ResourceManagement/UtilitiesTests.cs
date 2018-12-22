using System;
using System.Collections.Generic;
using System.Collections.Generic.Fakes;
using System.ComponentModel.Fakes;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.IO.Fakes;
using System.Linq;
using System.Reflection;
using System.Web.Fakes;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using Shouldly;
using WorkEnginePPM.Fakes;
using currentNamespace = WorkEnginePPM.Core.ResourceManagement;
using currentNamespaceFake = WorkEnginePPM.Core.ResourceManagement.Fakes;

namespace WorkEnginePPM.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UtilitiesTests
    {
        private PrivateType privateObject;
        private IDisposable shimsContext;
        private BindingFlags publicStatic;
        private BindingFlags nonPublicStatic;
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
        private const string AddUpdateResourceMethodName = "AddUpdateResource";
        private const string BuildFieldsTableMethodName = "BuildFieldsTable";
        private const string DeleteResourceMethodName = "DeleteResource";
        private const string PerformDeleteResourceCheckMethodName = "PerformDeleteResourceCheck";
        private const string WriteDataTableToFileMethodName = "WriteDataTableToFile";
        private const string AreEqualObjectsMethodName = "AreEqualObjects";
        private const string GetUserNameMethodName = "GetUserName";
        private const string GetValidDateInFormatMethodName = "GetValidDateInFormat";
        private const string CheckPFEResourceCenterPermissionMethodName = "CheckPFEResourceCenterPermission";
        private const string GetCleanFieldValueMethodName = "GetCleanFieldValue";

        [TestInitialize]
        public void Setup()
        {
            SetupShims();
            privateObject = new PrivateType(typeof(currentNamespace.Utilities));
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
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => true;
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
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPSite.AllInstances.OpenWeb = _ => spWeb;
            ShimSPSite.AllInstances.OpenWebString = (_, __) => spWeb;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => spWeb;
            ShimSPSite.AllInstances.Dispose = _ => { };
            ShimSPWeb.AllInstances.Dispose = _ => { };
            ShimCoreFunctions.getLockedWebSPWeb = _ => guid;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => DummyString;
            ShimCoreFunctions.getListSettingStringSPList = (_, __) => DummyString;
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (_1, _2, _3) => DummyString;
            ShimConfigFunctions.GetCleanUsernameSPWeb = _ => DummyString;
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
            ShimSPFieldUserValueCollection.ConstructorSPWebString = (_, _1, input) => new ShimSPFieldUserValueCollection();
            ShimSPFieldUserValue.Constructor = _ => new ShimSPFieldUserValue();
            ShimSPFieldUserValue.ConstructorSPWebString = (_, _1, _2) => new ShimSPFieldUserValue();
            ShimSPWebApplication.AllInstances.FeaturesGet = _ => new ShimSPFeatureCollection()
            {
                ItemGetGuid = __ => new ShimSPFeature()
            };
        }

        private void SetupVariables()
        {
            validations = 0;
            publicStatic = BindingFlags.Static | BindingFlags.Public;
            nonPublicStatic = BindingFlags.Static | BindingFlags.NonPublic;
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
                Close = () => { },
                ItemGetString = input => input
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void AddUpdateResource_WhenCalled_ReturnsInteger()
        {
            // Arrange
            var row = default(DataRow);
            var fieldsTable = new DataTable();

            fieldsTable.Columns.Add("Id", typeof(int));
            fieldsTable.Columns.Add("Value");
            fieldsTable.Columns.Add("Field", typeof(SPField));
            fieldsTable.Columns.Add("3014");

            row = fieldsTable.NewRow();
            row["Id"] = Zero;
            row["Value"] = string.Empty;
            fieldsTable.Rows.Add(row);

            row = fieldsTable.NewRow();
            row["Id"] = Zero;
            row["Value"] = Five;
            fieldsTable.Rows.Add(row);

            row = fieldsTable.NewRow();
            row["Id"] = 3013;
            row["Value"] = null;
            row["Field"] = new ShimSPField()
            {
                TypeGet = () => SPFieldType.DateTime
            }.Instance;
            fieldsTable.Rows.Add(row);

            row = fieldsTable.NewRow();
            row["Id"] = 3014;
            row["Value"] = null;
            row["Field"] = new ShimSPField()
            {
                TypeGet = () => SPFieldType.Calculated
            }.Instance;
            fieldsTable.Rows.Add(row);

            var parameters = new object[]
            {
                fieldsTable,
                spWeb.Instance,
                guid,
                default(decimal),
                true
            };

            ShimSPField.AllInstances.GetFieldValueForEditObject = (_, __) => DummyString;
            ShimResources.AllInstances.UpdateResourceResource = (_, __) => Five;
            ShimResources.AllInstances.BuildResourceDataRow = (_, __) => null;
            ShimAdminFunctions.AllInstances.CalcResourceRateInt32 = (_, __) => Five;

            // Act
            var actual = (int)privateObject.InvokeStatic(
                AddUpdateResourceMethodName,
                publicStatic,
                parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(Five),
                () => validations.ShouldBe(0));
        }

        [TestMethod]
        public void BuildFieldsTable_IsNewResourceFalse_ReturnsFieldsTable()
        {
            // Arrange
            var values = new Dictionary<string, string>()
            {
                ["ID"] = "ID",
                ["EXTID"] = "EXTID",
                ["Permissions"] = "1,2",
                ["Generic"] = "Generic",
                ["CanLogin"] = "CanLogin",
                ["Email"] = "Email"
            };
            var properties = new ShimSPItemEventProperties()
            {
                AfterPropertiesGet = () => new ShimSPItemEventDataCollection()
                {
                    ItemGetString = key =>
                    {
                        if (values.ContainsKey(key))
                        {
                            return values[key];
                        }
                        return null;
                    }
                },
                WebGet = () => spWeb,
                ListGet = () => spList,
                ListItemGet = () => spListItem
            };
            var resourceFields = $"111,CanLogin";

            spListItem.ItemGetString = key =>
            {
                if (values.ContainsKey(key))
                {
                    return values[key];
                }
                return null;
            };

            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPField>()
            {
                new ShimSPField()
                {
                    InternalNameGet = () => "ID"
                },
                new ShimSPField()
                {
                    InternalNameGet = () => "Permissions"
                },
                new ShimSPField()
                {
                    InternalNameGet = () => "Generic"
                },
                new ShimSPField()
                {
                    InternalNameGet = () => "SharePointAccount"
                }
            }.GetEnumerator();
            ShimAPITeam.GetWebGroupsSPWeb = _ => new List<SPGroup>()
            {
                new ShimSPGroup()
                {
                    IDGet = () => 1,
                    NameGet = () => "1"
                },
                new ShimSPGroup()
                {
                    IDGet = () => 2,
                    NameGet = () => DummyString
                },
                new ShimSPGroup()
                {
                    IDGet = () => 3,
                    NameGet = () => "3"
                }
            };
            ShimSPGroup.AllInstances.UsersGet = _ => new ShimSPUserCollection();
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, __) => spUser;
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => DummyInt;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, input) => resourceFields;
            currentNamespaceFake.ShimUtilities.AreEqualObjectsObjectObjectSPFieldSPWeb = (_1, _2, _3, _4) => false;
            ShimSPField.AllInstances.ToString01 = instance => instance.InternalName;

            // Act
            var actual = (DataTable)privateObject.InvokeStatic(
                BuildFieldsTableMethodName,
                publicStatic,
                new object[]
                {
                    properties.Instance,
                    false
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldNotBeNull(),
                () => actual.Select("Id=3200")[0]["Value"].ToString().ShouldBe($"1:{true},{DummyString}:{true},3:{true}"),
                () => actual.Select("Id=3011")[0]["Value"].ToString().ShouldBe("Email"));
        }

        [TestMethod]
        public void BuildFieldsTable_IsNewResourceTrue_ReturnsFieldsTable()
        {
            // Arrange
            var values = new Dictionary<string, string>()
            {
                ["ID"] = "ID",
                ["EXTID"] = "EXTID",
                ["Permissions"] = "1,2",
                ["Generic"] = "Generic",
                ["CanLogin"] = "CanLogin",
                ["Email"] = "Email"
            };
            var properties = new ShimSPItemEventProperties()
            {
                AfterPropertiesGet = () => new ShimSPItemEventDataCollection()
                {
                    ItemGetString = key =>
                    {
                        if (values.ContainsKey(key))
                        {
                            return values[key];
                        }
                        return null;
                    }
                },
                WebGet = () => spWeb,
                ListGet = () => spList,
                ListItemGet = () => spListItem
            };
            var resourceFields = $"111,CanLogin";

            spListItem.ItemGetString = key =>
            {
                if (values.ContainsKey(key))
                {
                    return values[key];
                }
                return null;
            };

            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPField>()
            {
                new ShimSPField()
                {
                    InternalNameGet = () => "ID"
                },
                new ShimSPField()
                {
                    InternalNameGet = () => "Permissions"
                },
                new ShimSPField()
                {
                    InternalNameGet = () => "Generic"
                },
                new ShimSPField()
                {
                    InternalNameGet = () => "SharePointAccount"
                }
            }.GetEnumerator();
            ShimAPITeam.GetWebGroupsSPWeb = _ => new List<SPGroup>()
            {
                new ShimSPGroup()
                {
                    IDGet = () => 1,
                    NameGet = () => "1"
                },
                new ShimSPGroup()
                {
                    IDGet = () => 2,
                    NameGet = () => DummyString
                },
                new ShimSPGroup()
                {
                    IDGet = () => 3,
                    NameGet = () => "3"
                }
            };
            ShimSPGroup.AllInstances.UsersGet = _ => new ShimSPUserCollection();
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, __) => spUser;
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => DummyInt;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, input) => resourceFields;
            currentNamespaceFake.ShimUtilities.AreEqualObjectsObjectObjectSPFieldSPWeb = (_1, _2, _3, _4) => false;
            ShimSPField.AllInstances.ToString01 = instance => instance.InternalName;

            // Act
            var actual = (DataTable)privateObject.InvokeStatic(
                BuildFieldsTableMethodName,
                publicStatic,
                new object[]
                {
                    properties.Instance,
                    true
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldNotBeNull(),
                () => actual.Select("Id=3200")[0]["Value"].ToString().ShouldBe($"1:{true},{DummyString}:{true},3:{true}"),
                () => actual.Select("Id=3006")[0]["Value"].ToString().ShouldBe(bool.FalseString),
                () => actual.Select("Id=111")[0]["Value"].ToString().ShouldBe(bool.FalseString));
        }

        [TestMethod]
        public void DeleteResource_WhenCalled_DeletesResource()
        {
            // Arrange
            var resource = new ShimResource()
            {
                IdGet = () => One,
                ExternalUIdGet = () => DummyString,
                NTAccountGet = () => DummyString
            };

            ShimResources.AllInstances.BuildResourceDataRow = (_, __) =>
            {
                validations += 1;
                return resource;
            };
            ShimResources.AllInstances.DeleteResourceInt32 = (_, _1, _2) =>
            {
                validations += 1;
            };
            ShimExtensionMethods.GetExtIdSPUserSPWeb = (_, __) =>
            {
                validations += 1;
                return DummyInt;
            };

            // Act
            privateObject.InvokeStatic(
                DeleteResourceMethodName,
                publicStatic,
                new object[]
                {
                    One,
                    guid,
                    spWeb.Instance
                });

            // Assert
            validations.ShouldBe(3);
        }

        [TestMethod]
        public void PerformDeleteResourceCheck_WhenCalled_ChecksResourceDelete()
        {
            // Arrange
            const string yesString = "YES";
            var resource = new ShimResource()
            {
                IdGet = () => One,
                ExternalUIdGet = () => DummyString,
                NTAccountGet = () => DummyString
            };
            var parameters = new object[]
            {
                One,
                guid,
                spWeb.Instance,
                DummyString,
                DummyString
            };

            ShimResources.AllInstances.BuildResourceDataRow = (_, __) =>
            {
                validations += 1;
                return resource;
            };
            ShimResources.AllInstances.CanDeleteResourceStringOut = (Resources instance, Resource resourceInstance, out string message) =>
            {
                validations += 1;
                message = DummyString;
                return yesString;
            };

            // Act
            var actual = (bool)privateObject.InvokeStatic(
                PerformDeleteResourceCheckMethodName,
                publicStatic,
                parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => parameters[3].ShouldBe(yesString),
                () => parameters[4].ShouldBe(DummyString),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void WriteDataTableToFile_WhenCalled_WritesDataTableToFile()
        {
            // Arrange
            const string expected = "some random string longer than column name";
            var dataTable = new DataTable();
            var row = default(DataRow);
            var output = new List<string>();

            dataTable.Columns.Add(DummyString);
            row = dataTable.NewRow();
            row[DummyString] = expected;
            dataTable.Rows.Add(row);

            ShimStreamWriter.ConstructorStringBoolean = (_, _1, _2) => new ShimStreamWriter();
            ShimStreamWriter.AllInstances.DisposeBoolean = (_, __) => { };
            ShimStreamWriter.AllInstances.Close = _ => { };
            ShimStreamWriter.AllInstances.WriteString = (_, input) =>
            {
                output[output.Count - 1] += input;
            };
            ShimTextWriter.AllInstances.WriteLine = _ => { };
            ShimTextWriter.AllInstances.WriteLineString = (_, input) =>
            {
                output.Add(input);
            };

            // Act
            privateObject.InvokeStatic(
                WriteDataTableToFileMethodName,
                publicStatic,
                new object[]
                {
                    dataTable,
                    DummyString
                });

            // Assert
            output.ShouldSatisfyAllConditions(
                () => output.Any(line => line.Contains(DummyString)).ShouldBeTrue(),
                () => output.Any(line => line.Contains(expected)).ShouldBeTrue());
        }

        [TestMethod]
        public void AreEqualObjects_WhenCalled_ReturnCompareResult()
        {
            // Arrange
            currentNamespaceFake.ShimUtilities.GetCleanFieldValueSPWebObjectSPFieldBoolean = (_1, input, _2, _3) =>
            {
                validations += 1;
                return input.ToString();
            };

            // Act
            var actual = (bool)privateObject.InvokeStatic(
                AreEqualObjectsMethodName,
                nonPublicStatic,
                new object[]
                {
                    DummyString,
                    DummyString,
                    spField.Instance,
                    spWeb.Instance
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void GetUserName_UserNotNull_ReturnsUserName()
        {
            // Arrange
            var spFieldUserValue = new ShimSPFieldUserValue()
            {
                UserGet = () => spUser,
                LookupValueGet = () => DummyString
            };

            spUser.LoginNameGet = () => DummyString;

            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ =>
            {
                validations += 10;
                return -1;
            };
            ShimCoreFunctions.GetUserNameWithDomainString = _ =>
            {
                validations += 1;
                return DummyString;
            };
            ShimCoreFunctions.GetRealUserNameStringSPSite = (_, __) =>
            {
                validations += 1;
                return DummyString;
            };

            // Act
            var actual = (string)privateObject.InvokeStatic(
                GetUserNameMethodName,
                nonPublicStatic,
                new object[]
                {
                    spWeb.Instance,
                    spFieldUserValue.Instance
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(DummyString),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void GetUserName_UserNull_ReturnsUserName()
        {
            // Arrange
            var spFieldUserValue = new ShimSPFieldUserValue()
            {
                UserGet = () => null,
                LookupValueGet = () => DummyString
            };

            spUser.LoginNameGet = () => DummyString;

            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ =>
            {
                validations += 10;
                return -1;
            };
            ShimCoreFunctions.GetUserNameWithDomainString = _ =>
            {
                validations += 1;
                return DummyString;
            };
            ShimCoreFunctions.GetRealUserNameStringSPSite = (_, __) =>
            {
                validations += 1;
                return DummyString;
            };

            // Act
            var actual = (string)privateObject.InvokeStatic(
                GetUserNameMethodName,
                nonPublicStatic,
                new object[]
                {
                    spWeb.Instance,
                    spFieldUserValue.Instance
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(DummyString),
                () => validations.ShouldBe(11));
        }

        [TestMethod]
        public void GetValidDateInFormat_OrderMDY_ReturnsDateInFormat()
        {
            // Arrange
            const SPCalendarOrderType orderType = SPCalendarOrderType.MDY;
            const string dateSeparator = "-";
            const string format = "MM-dd-yyyy";

            // Act
            var actual = (string)privateObject.InvokeStatic(
                GetValidDateInFormatMethodName,
                publicStatic,
                new object[]
                {
                    orderType,
                    currentDate.ToString(format),
                    dateSeparator
                });

            // Assert
            actual.ShouldBe(currentDate.Date.ToString());
        }

        [TestMethod]
        public void GetValidDateInFormat_OrderDMY_ReturnsDateInFormat()
        {
            // Arrange
            const SPCalendarOrderType orderType = SPCalendarOrderType.DMY;
            const string dateSeparator = "-";
            const string format = "dd-MM-yyyy";

            // Act
            var actual = (string)privateObject.InvokeStatic(
                GetValidDateInFormatMethodName,
                publicStatic,
                new object[]
                {
                    orderType,
                    currentDate.ToString(format),
                    dateSeparator
                });

            // Assert
            actual.ShouldBe(currentDate.Date.ToString());
        }

        [TestMethod]
        public void GetValidDateInFormat_OrderYMD_ReturnsDateInFormat()
        {
            // Arrange
            const SPCalendarOrderType orderType = SPCalendarOrderType.YMD;
            const string dateSeparator = "-";
            const string format = "yyyy-MM-dd";

            // Act
            var actual = (string)privateObject.InvokeStatic(
                GetValidDateInFormatMethodName,
                publicStatic,
                new object[]
                {
                    orderType,
                    currentDate.ToString(format),
                    dateSeparator
                });

            // Assert
            actual.ShouldBe(currentDate.Date.ToString());
        }

        [TestMethod]
        public void CheckPFEResourceCenterPermission_HasDeletePermissionTrue_ChecksPermission()
        {
            // Arrange
            var parameters = new object[]
            {
                spWeb.Instance,
                One,
                true,
                false
            };
            const string baseInfo = @"<baseInfo basepath=""1"" username=""1"" pid=""1"" company=""1"" dbcnstring=""1"" port=""1"" session=""1""/>";

            ShimDataAccess.ConstructorStringSecurityLevels = (_, _1, _2) => new ShimDataAccess();
            ShimDataAccess.AllInstances.dbaGet = _ => new ShimDBAccess();
            ShimWebAdmin.BuildBaseInfoHttpContextSPWeb = (_, __) =>
            {
                validations += 1;
                return baseInfo;
            };
            ShimSqlDb.AllInstances.Open = _ =>
            {
                validations += 1;
                return StatusEnum.rsSuccess;
            };
            ShimdbaGeneral.CheckUserGlobalPermissionDBAccessGlobalPermissionsEnum = (_, __) =>
            {
                validations += 1;
                return true;
            };

            // Act
            var actual = (bool)privateObject.InvokeStatic(
                CheckPFEResourceCenterPermissionMethodName,
                publicStatic,
                parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => ((bool)parameters[3]).ShouldBeTrue(),
                () => validations.ShouldBe(3));
        }

        [TestMethod]
        public void CheckPFEResourceCenterPermission_HasDeletePermissionFalse_ChecksPermission()
        {
            // Arrange
            var parameters = new object[]
            {
                spWeb.Instance,
                One,
                false,
                false
            };
            const string baseInfo = @"<baseInfo basepath=""1"" username=""1"" pid=""1"" company=""1"" dbcnstring=""1"" port=""1"" session=""1""/>";

            ShimDataAccess.ConstructorStringSecurityLevels = (_, _1, _2) => new ShimDataAccess();
            ShimDataAccess.AllInstances.dbaGet = _ => new ShimDBAccess();
            ShimWebAdmin.BuildBaseInfoHttpContextSPWeb = (_, __) =>
            {
                validations += 1;
                return baseInfo;
            };
            ShimSqlDb.AllInstances.Open = _ =>
            {
                validations += 1;
                return StatusEnum.rsSuccess;
            };
            ShimdbaGeneral.CheckUserGlobalPermissionDBAccessGlobalPermissionsEnum = (_, __) =>
            {
                validations += 1;
                return true;
            };

            // Act
            var actual = (bool)privateObject.InvokeStatic(
                CheckPFEResourceCenterPermissionMethodName,
                publicStatic,
                parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => ((bool)parameters[3]).ShouldBeTrue(),
                () => validations.ShouldBe(3));
        }

        [TestMethod]
        public void GetCleanFieldValue_SPFieldTypeDateTime_ReturnsCleanFieldValue()
        {
            // Arrange
            spField.TypeGet = () => SPFieldType.DateTime;
            spField.TypeAsStringGet = () => DummyString;

            ShimSPUtility.CreateISO8601DateTimeFromSystemDateTimeDateTime = input =>
            {
                validations += 1;
                return input.ToString();
            };

            // Act
            var actual = (string)privateObject.InvokeStatic(
                GetCleanFieldValueMethodName,
                publicStatic,
                new object[]
                {
                    spWeb.Instance,
                    currentDate,
                    spField.Instance,
                    true
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(currentDate.ToString()),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void GetCleanFieldValue_SPFieldTypeUserRawValueString_ReturnsCleanFieldValue()
        {
            // Arrange
            var user = new ShimSPFieldUser();
            var customEnumerator = new List<SPFieldUserValue>()
            {
                new ShimSPFieldUserValue().Instance,
                new ShimSPFieldUserValue().Instance
            }.GetEnumerator();

            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.User;
            ShimSPField.AllInstances.TypeAsStringGet = _ => DummyString;
            ShimSPFieldLookup.AllInstances.AllowMultipleValuesGet = _ => true;
            ShimList<SPFieldUserValue>.AllInstances.GetEnumerator = _ => customEnumerator;
            currentNamespaceFake.ShimUtilities.GetUserNameSPWebSPFieldUserValue = (_, _1) =>
            {
                validations += 1;
                return DummyString;
            };

            // Act
            var actual = (string)privateObject.InvokeStatic(
                GetCleanFieldValueMethodName,
                publicStatic,
                new object[]
                {
                    spWeb.Instance,
                    DummyString,
                    user.Instance,
                    true
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe($"{DummyString},{DummyString}"),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void GetCleanFieldValue_SPFieldTypeUserRawValueNotString_ReturnsCleanFieldValue()
        {
            // Arrange
            var user = new ShimSPFieldUser();
            var customEnumerator = new List<SPFieldUserValue>()
            {
                new ShimSPFieldUserValue().Instance,
                new ShimSPFieldUserValue().Instance
            }.GetEnumerator();

            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.User;
            ShimSPField.AllInstances.TypeAsStringGet = _ => DummyString;
            ShimSPFieldLookup.AllInstances.AllowMultipleValuesGet = _ => true;
            ShimList<SPFieldUserValue>.AllInstances.GetEnumerator = _ => customEnumerator;
            currentNamespaceFake.ShimUtilities.GetUserNameSPWebSPFieldUserValue = (_, _1) =>
            {
                validations += 1;
                return DummyString;
            };

            // Act
            var actual = (string)privateObject.InvokeStatic(
                GetCleanFieldValueMethodName,
                publicStatic,
                new object[]
                {
                    spWeb.Instance,
                    new SPFieldUserValueCollection(),
                    user.Instance,
                    true
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe($"{DummyString},{DummyString}"),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void GetCleanFieldValue_SPFieldTypeUserAllowMultipleValuesFalse_ReturnsCleanFieldValue()
        {
            // Arrange
            var user = new ShimSPFieldUser();
            var customEnumerator = new List<SPFieldUserValue>()
            {
                new ShimSPFieldUserValue().Instance,
                new ShimSPFieldUserValue().Instance
            }.GetEnumerator();

            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.User;
            ShimSPField.AllInstances.TypeAsStringGet = _ => DummyString;
            ShimSPFieldLookup.AllInstances.AllowMultipleValuesGet = _ => false;
            ShimList<SPFieldUserValue>.AllInstances.GetEnumerator = _ => customEnumerator;
            currentNamespaceFake.ShimUtilities.GetUserNameSPWebSPFieldUserValue = (_, _1) =>
            {
                validations += 1;
                return DummyString;
            };

            // Act
            var actual = (string)privateObject.InvokeStatic(
                GetCleanFieldValueMethodName,
                publicStatic,
                new object[]
                {
                    spWeb.Instance,
                    DummyString,
                    user.Instance,
                    true
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(DummyString),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void GetCleanFieldValue_SPFieldTypeLookup_ReturnsCleanFieldValue()
        {
            // Arrange
            var field = new ShimSPFieldLookup()
            {
                LookupListGet = () => SampleGuidString1
            };
            var lookupValueCollection = new ShimSPFieldLookupValueCollection();
            var customEnumerator = new List<SPFieldLookupValue>()
            {
                new ShimSPFieldLookupValue()
                {
                    LookupIdGet = () => One
                }.Instance
            }.GetEnumerator();

            spListItem.ItemGetString = _ => One;

            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Lookup;
            ShimSPField.AllInstances.TypeAsStringGet = _ => DummyString;
            ShimSPFieldLookup.AllInstances.AllowMultipleValuesGet = _ => true;
            ShimSPFieldLookup.AllInstances.GetFieldValueString = (_, __) =>
            {
                validations += 1;
                return lookupValueCollection.Instance;
            };
            ShimList<SPFieldLookupValue>.AllInstances.GetEnumerator = _ => customEnumerator;
            ShimSPListItemCollection.AllInstances.GetEnumerator = _ => new List<SPListItem>()
            {
                spListItem.Instance,
                spListItem.Instance,
                spListItem.Instance
            }.GetEnumerator();

            // Act
            var actual = (string)privateObject.InvokeStatic(
                GetCleanFieldValueMethodName,
                publicStatic,
                new object[]
                {
                    spWeb.Instance,
                    DummyString,
                    field.Instance,
                    true
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe("1,1,1"),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void GetCleanFieldValue_SPFieldTypeLookupReturnIdFalse_ReturnsCleanFieldValue()
        {
            // Arrange
            var field = new ShimSPFieldLookup()
            {
                LookupListGet = () => SampleGuidString1
            };
            var lookupValueCollection = new ShimSPFieldLookupValueCollection();
            var lookupValue = new ShimSPFieldLookupValue()
            {
                LookupIdGet = () => One
            };
            var customEnumerator = new List<SPFieldLookupValue>()
            {
                lookupValue.Instance
            }.GetEnumerator();

            spListItem.ItemGetString = _ => One;

            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Lookup;
            ShimSPField.AllInstances.TypeAsStringGet = _ => DummyString;
            ShimSPFieldLookup.AllInstances.AllowMultipleValuesGet = _ => true;
            ShimSPFieldLookup.AllInstances.GetFieldValueString = (_, __) =>
            {
                validations += 1;
                return lookupValueCollection.Instance;
            };
            ShimList<SPFieldLookupValue>.AllInstances.GetEnumerator = _ => customEnumerator;
            ShimSPListItemCollection.AllInstances.GetEnumerator = _ => new List<SPListItem>()
            {
                spListItem.Instance,
                spListItem.Instance,
                spListItem.Instance
            }.GetEnumerator();

            // Act
            var actual = (string)privateObject.InvokeStatic(
                GetCleanFieldValueMethodName,
                publicStatic,
                new object[]
                {
                    spWeb.Instance,
                    DummyString,
                    field.Instance,
                    false
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe("1,1,1"),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void GetCleanFieldValue_SPFieldTypeLookupAllowMultipleValuesFalseReturnIdFalse_ReturnsCleanFieldValue()
        {
            // Arrange
            var field = new ShimSPFieldLookup()
            {
                LookupListGet = () => SampleGuidString1
            };
            var lookupValue = new ShimSPFieldLookupValue()
            {
                LookupIdGet = () => One
            };

            spListItem.ItemGetString = _ => One;

            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Lookup;
            ShimSPField.AllInstances.TypeAsStringGet = _ => DummyString;
            ShimSPFieldLookup.AllInstances.AllowMultipleValuesGet = _ => false;
            ShimSPFieldLookup.AllInstances.GetFieldValueString = (_, __) =>
            {
                validations += 1;
                return lookupValue.Instance;
            };
            ShimSPListItemCollection.AllInstances.GetEnumerator = _ => new List<SPListItem>()
            {
                spListItem.Instance,
                spListItem.Instance,
                spListItem.Instance
            }.GetEnumerator();

            // Act
            var actual = (string)privateObject.InvokeStatic(
                GetCleanFieldValueMethodName,
                publicStatic,
                new object[]
                {
                    spWeb.Instance,
                    DummyString,
                    field.Instance,
                    false
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(One.ToString()),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void GetCleanFieldValue_SPFieldTypeLookupAllowMultipleValuesFalseContainsFieldTrue_ReturnsCleanFieldValue()
        {
            // Arrange
            var field = new ShimSPFieldLookup()
            {
                LookupListGet = () => SampleGuidString1
            };
            var lookupValue = new ShimSPFieldLookupValue()
            {
                LookupIdGet = () => One
            };

            spListItem.ItemGetString = _ => One;
            spFieldCollection.ContainsFieldString = _ => true;

            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Lookup;
            ShimSPField.AllInstances.TypeAsStringGet = _ => DummyString;
            ShimSPFieldLookup.AllInstances.AllowMultipleValuesGet = _ => false;
            ShimSPFieldLookup.AllInstances.GetFieldValueString = (_, __) =>
            {
                validations += 1;
                return lookupValue.Instance;
            };
            ShimSPListItemCollection.AllInstances.GetEnumerator = _ => new List<SPListItem>()
            {
                spListItem.Instance,
                spListItem.Instance,
                spListItem.Instance
            }.GetEnumerator();

            // Act
            var actual = (string)privateObject.InvokeStatic(
                GetCleanFieldValueMethodName,
                publicStatic,
                new object[]
                {
                    spWeb.Instance,
                    DummyString,
                    field.Instance,
                    false
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(One.ToString()),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void GetCleanFieldValue_SPFieldTypeLookupAllowMultipleValuesFalseContainsFieldFalse_ReturnsCleanFieldValue()
        {
            // Arrange
            var field = new ShimSPFieldLookup()
            {
                LookupListGet = () => SampleGuidString1
            };
            var lookupValue = new ShimSPFieldLookupValue()
            {
                LookupIdGet = () => One
            };

            spListItem.ItemGetString = _ => One;
            spFieldCollection.ContainsFieldString = _ => false;

            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Lookup;
            ShimSPField.AllInstances.TypeAsStringGet = _ => DummyString;
            ShimSPFieldLookup.AllInstances.AllowMultipleValuesGet = _ => false;
            ShimSPFieldLookup.AllInstances.GetFieldValueString = (_, __) =>
            {
                validations += 1;
                return lookupValue.Instance;
            };
            ShimSPListItemCollection.AllInstances.GetEnumerator = _ => new List<SPListItem>()
            {
                spListItem.Instance,
                spListItem.Instance,
                spListItem.Instance
            }.GetEnumerator();

            // Act
            var actual = (string)privateObject.InvokeStatic(
                GetCleanFieldValueMethodName,
                publicStatic,
                new object[]
                {
                    spWeb.Instance,
                    DummyString,
                    field.Instance,
                    false
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(One.ToString()),
                () => validations.ShouldBe(1));
        }
    }
}