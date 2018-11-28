using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Fakes;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.IO.Fakes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Fakes;
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
using PortfolioEngineCore.Fakes;
using RPADataCache;
using Shouldly;
using PortfolioFakes = PortfolioEngineCore.Fakes;

namespace PortfolioEngineCore.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ResourceSelectorTests
    {
        private ResourceSelector testObject;
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
        private SqlCommand sqlCommand;
        private Guid guid;
        private int validations;
        private DateTime currentDate;
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
        private const string ReadResourcesMethodName = "ReadResources";
        private const string GetResourceDisplayFieldsMethodName = "GetResourceDisplayFields";
        private const string BuildResourceSelectQueryMethodName = "BuildResourceSelectQuery";
        private const string GetPIResourcesXMLMethodName = "GetPIResourcesXML";

        [TestInitialize]
        public void Setup()
        {
            SetupShims();

            testObject = new ResourceSelector
            (
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                SecurityLevels.AdminCalc,
                false
            );
            privateObject = new PrivateObject(testObject);

            privateObject.SetFieldOrProperty("debug", nonPublicInstance, new Debugger(false));
            privateObject.SetFieldOrProperty("_dba", nonPublicInstance, new DBAccess(DummyString, new SqlConnection()));
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
            ShimSqlConnection.AllInstances.CreateCommand = _ => sqlCommand;
            ShimSqlCommand.ConstructorStringSqlConnectionSqlTransaction = (_, _1, _2, _3) => new SqlCommand();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => DummyInt;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => dataReader;
            ShimComponent.AllInstances.Dispose = _ => { };
            ShimSqlCommand.AllInstances.TransactionSetSqlTransaction = (_, __) => { };
            ShimSPDatabase.AllInstances.DatabaseConnectionStringGet = _ => DummyString;
            ShimDbDataReader.AllInstances.Dispose = _ => { };
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
            ShimSqlDb.AllInstances.TransactionGet = _ => transaction;
            ShimSqlDb.ReadIntValueObject = _ => DummyInt;
            ShimSqlDb.ReadIntValueObjectBooleanOut = (object input, out bool output) =>
            {
                output = false;
                return DummyInt;
            };
            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimSqlDb.ReadBoolValueObject = _ => true;
            ShimSqlDb.ReadDateValueObject = _ => currentDate;
            ShimActivation.AllInstances.checkActivationStringStringString = (_, _1, _2, _3) => { };
            ShimPFEEncrypt.DecryptStringString = (_, input) => input;
            ShimDatabase.AllInstances.OpenDatabaseStringString = (_, _1, _2) => new SqlConnection();
            ShimBaseSecurity.AllInstances.ChecksScurityStringSecurityLevels = (_, _1, _2) => true;
        }

        private void SetupVariables()
        {
            validations = 0;
            currentDate = DateTime.Now;
            publicStatic = BindingFlags.Static | BindingFlags.Public;
            nonPublicStatic = BindingFlags.Static | BindingFlags.NonPublic;
            publicInstance = BindingFlags.Instance | BindingFlags.Public;
            nonPublicInstance = BindingFlags.Instance | BindingFlags.NonPublic;
            guid = Guid.Parse(SampleGuidString1);
            sqlCommand = new SqlCommand();
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
                Read = () => true,
                HasRowsGet = () => true,
                Close = () => { },
                ItemGetString = _ => DummyString
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
            sqlCommand?.Dispose();
        }

        [TestMethod]
        public void ReadResources_WhenCalled_ReturnsResourcesXml()
        {
            // Arrange
            const string advancedQueryXml = "<xmlcfg/>";
            const string displayFieldsXml = @"
                <xmlcfg>
                    <RowLimit>0</RowLimit>
                    <Items>
                        <Item FieldFormat=""4"" FieldID=""1"" CCRoleUID=""1""/>
                        <Item FieldFormat=""9"" FieldID=""9004""/>
                        <Item FieldFormat=""9"" FieldID=""9019""/>
                        <Item FieldFormat=""9"" FieldID=""9006""/>
                        <Item FieldFormat=""9"" FieldID=""1""/>
                        <Item FieldFormat=""98"" FieldID=""1""/>
                        <Item FieldFormat=""40"" FieldID=""1""/>
                        <Item FieldFormat=""96"" FieldID=""9020""/>
                    </Items>
                </xmlcfg>";
            var parameters = new object[]
            {
                One,
                DummyString,
                advancedQueryXml,
                displayFieldsXml,
                true,
                true,
                true,
                DummyString
            };
            var row = default(DataRow);
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit < Three;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readHit = 0;
                return dataReader;
            };
            PortfolioFakes.ShimSecurity.GetResourcesUserCanViewDBAccessInt32StringOut =
                (DBAccess dba, int lWResID, out string sWResIDs) =>
                {
                    validations += 1;
                    sWResIDs = DummyString;
                    return StatusEnum.rsBasePathNotSet;
                };
            ShimResourceSelector.AllInstances.BuildResourceSelectQueryDBAccessInt32CStructInt32ListOfCStructStringBooleanBooleanIncludeGenericsEnum =
                (_, _1, _2, _3, _4, _5, _6, _7, _8, _9) =>
                {
                    return DummyString;
                };
            ShimDataTable.AllInstances.LoadIDataReader = (DataTable instance, IDataReader input) =>
            {
                instance.Columns.Add("WRES_ID");
                instance.Columns.Add("RES_NAME");
                instance.Columns.Add("MR_NOTES");
                instance.Columns.Add("WRES_IS_GENERIC");
                instance.Columns.Add("WRES_IS_RESOURCE");
                instance.Columns.Add("CCRoleUID");
                instance.Columns.Add("Field1");
                instance.Columns.Add("Field9004");
                instance.Columns.Add("Field9019");
                instance.Columns.Add("Field9006");
                instance.Columns.Add("Field9020");
                row = instance.NewRow();
                foreach (DataColumn column in instance.Columns)
                {
                    row[column.ColumnName] = One;
                }
                instance.Rows.Add(row);
            };
            ShimCommon.IsIDInListStringInt32 = (_1, _2) => true;
            ShimCommon.AppendItemToListStringString = (_1, _2) => DummyString;
            ShimCommon.AddIDToListStringRefInt32 = (ref string sList, int lID) =>
            {
                sList = One.ToString();
                return true;
            };
            ShimResourceSelector.GetCostCategoryRolesDBAccessInt32Int32DictionaryOfStringCStructOut =
                (DBAccess dba, int lPortfolioCommitmentsCalendarUID, int lStartPeriodID, out Dictionary<string, CStruct> dicCostCategoryRolesOut) =>
                {
                    validations += 1;
                    const string roleXml = @"<xmlcfg Name=""NodeName"" ParentName=""ParentName""/>";
                    var costCategoryRole = new CStruct();
                    costCategoryRole.LoadXML(roleXml);
                    dicCostCategoryRolesOut = new Dictionary<string, CStruct>()
                    {
                        [One.ToString()] = costCategoryRole
                    };
                    return StatusEnum.rsSuccess;
                };

            // Act
            var result = (bool)privateObject.Invoke(ReadResourcesMethodName, publicInstance, parameters);
            var actual = new XmlDocument();
            actual.LoadXml((string)parameters[7]);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => actual.FirstChild.SelectSingleNode("//WResID").InnerText.ShouldBe(Zero.ToString()),
                () => actual.FirstChild.SelectSingleNode("//Resources/Resource/WResID").InnerText.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//Resources/Resource/CCRoleUID").InnerText.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//Resources/Resource/Field9019").InnerText.ShouldBe("ParentName.NodeName"),
                () => actual.FirstChild.SelectNodes("//Resources/Resource/Field1").Count.ShouldBe(Three),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void GetResourceDisplayFields_WhenCalled_ReturnsDisplayFields()
        {
            // Arrange
            var dbAccess = new DBAccess(DummyString, new SqlConnection());
            var parameters = new object[]
            {
                dbAccess,
                default(CStruct)
            };
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit <= Three;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readHit = 0;
                return dataReader;
            };

            // Act
            var result = (StatusEnum)privateObject.Invoke(GetResourceDisplayFieldsMethodName, nonPublicStatic, parameters);
            var replyXmlNode = (CStruct)parameters[1];
            var itemList = replyXmlNode.GetSubStruct("Items").GetList("Item");

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => itemList.Count.ShouldBe(17));
        }

        [TestMethod]
        public void BuildResourceSelectQuery_SearchModeZero_ReturnsQueryString()
        {
            // Arrange
            const int searchMode = 0;
            const bool includeUsers = false;
            const bool includeInactive = false;
            const IncludeGenericsEnum includeGenerics = IncludeGenericsEnum.igExclusive;
            const string displayFieldsXml = @"
                <xmlcfg>
                    <RowLimit>0</RowLimit>
                    <Items>
                        <Item FieldFormat=""4"" FieldID=""1"" CCRoleUID=""1""/>
                        <Item FieldFormat=""4"" FieldID=""9005"" CCRoleUID=""1""/>
                        <Item FieldFormat=""4"" FieldID=""9015"" CCRoleUID=""1""/>
                        <Item FieldFormat=""9"" FieldID=""9004""/>
                        <Item FieldFormat=""9"" FieldID=""1""/>
                        <Item FieldFormat=""96"" FieldID=""9020""/>
                    </Items>
                </xmlcfg>";
            const string queryXml = @"<xmlcfg/>";
            var dbAccess = new DBAccess(DummyString, new SqlConnection());
            var queryNode = new CStruct();
            var displayFields = new CStruct();

            displayFields.LoadXML(displayFieldsXml);
            queryNode.LoadXML(queryXml);

            var parameters = new object[]
            {
                dbAccess,
                searchMode,
                queryNode,
                One,
                displayFields.GetSubStruct("Items").GetList("Item"),
                One.ToString(),
                includeUsers,
                includeInactive,
                includeGenerics
            };
            var expected = new List<string>()
            {
                $"LEFT join EPG_MY_RESOURCES MR ON WR.WRES_ID = MR.WRES_ID AND MR.MR_WRES_ID = {One}",
                $"DEPT.LV_VALUE AS Field9005",
                $"RPDEPT.LV_VALUE AS Field9015",
                "LEFT JOIN EPGP_LOOKUP_VALUES DEPT ON (DEPT.LV_UID = WR.WRES_DEPT)",
                "LEFT JOIN EPGP_LOOKUP_VALUES RPDEPT ON (RPDEPT.LV_UID = WR.WRES_RP_DEPT)",
                "WR.WRES_IS_GENERIC <> 0",
                "WR.WRES_INACTIVE = 0",
                $"MR_WRES_ID = {One} ORDER BY MR_SEQ"
            };

            ShimResourceSelector.GetCustomFieldNameFromIDDBAccessInt32StringOutStringOut =
                (DBAccess dba, int lFieldID, out string sTableName, out string sFieldName) =>
                {
                    sTableName = DummyString;
                    sFieldName = DummyString;
                    return StatusEnum.rsSuccess;
                };

            // Act
            var actual = (string)privateObject.Invoke(BuildResourceSelectQueryMethodName, nonPublicInstance, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldNotBe(string.Empty),
                () => expected.Any(x => !actual.Contains(x)).ShouldBeFalse());
        }

        [TestMethod]
        public void BuildResourceSelectQuery_SearchModeThree_ReturnsQueryString()
        {
            // Arrange
            const int searchMode = 3;
            const bool includeUsers = false;
            const bool includeInactive = false;
            const IncludeGenericsEnum includeGenerics = IncludeGenericsEnum.igNo;
            const string displayFieldsXml = @"
                <xmlcfg>
                    <RowLimit>0</RowLimit>
                    <Items>
                        <Item FieldFormat=""4"" FieldID=""1"" CCRoleUID=""1""/>
                        <Item FieldFormat=""4"" FieldID=""9005"" CCRoleUID=""1""/>
                        <Item FieldFormat=""4"" FieldID=""9015"" CCRoleUID=""1""/>
                        <Item FieldFormat=""9"" FieldID=""9004""/>
                        <Item FieldFormat=""9"" FieldID=""1""/>
                        <Item FieldFormat=""96"" FieldID=""9020""/>
                    </Items>
                </xmlcfg>";
            const string queryXml = @"<xmlcfg/>";
            var dbAccess = new DBAccess(DummyString, new SqlConnection());
            var queryNode = new CStruct();
            var displayFields = new CStruct();

            displayFields.LoadXML(displayFieldsXml);
            queryNode.LoadXML(queryXml);

            var parameters = new object[]
            {
                dbAccess,
                searchMode,
                queryNode,
                One,
                displayFields.GetSubStruct("Items").GetList("Item"),
                One.ToString(),
                includeUsers,
                includeInactive,
                includeGenerics
            };
            var expected = new List<string>()
            {
                $"LEFT join EPG_MY_RESOURCES MR ON WR.WRES_ID = MR.WRES_ID AND MR.MR_WRES_ID = {One}",
                $"DEPT.LV_VALUE AS Field9005",
                $"RPDEPT.LV_VALUE AS Field9015",
                "LEFT JOIN EPGP_LOOKUP_VALUES DEPT ON (DEPT.LV_UID = WR.WRES_DEPT)",
                "LEFT JOIN EPGP_LOOKUP_VALUES RPDEPT ON (RPDEPT.LV_UID = WR.WRES_RP_DEPT)",
                "AND WR.WRES_IS_RESOURCE <> 0",
                "WR.WRES_INACTIVE = 0",
                $"INNER JOIN dbo.EPG_FN_ConvertListToTable(N'{One}') LT on WR.WRES_ID=LT.TokenVal"
            };

            ShimResourceSelector.GetCustomFieldNameFromIDDBAccessInt32StringOutStringOut =
                (DBAccess dba, int lFieldID, out string sTableName, out string sFieldName) =>
                {
                    sTableName = DummyString;
                    sFieldName = DummyString;
                    return StatusEnum.rsSuccess;
                };

            // Act
            var actual = (string)privateObject.Invoke(BuildResourceSelectQueryMethodName, nonPublicInstance, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldNotBe(string.Empty),
                () => expected.Any(x => !actual.Contains(x)).ShouldBeFalse());
        }

        [TestMethod]
        public void BuildResourceSelectQuery_SearchModeFour_ReturnsQueryString()
        {
            // Arrange
            const int searchMode = 4;
            const bool includeUsers = true;
            const bool includeInactive = false;
            const IncludeGenericsEnum includeGenerics = IncludeGenericsEnum.igNo;
            const string displayFieldsXml = @"
                <xmlcfg>
                    <RowLimit>0</RowLimit>
                    <Items>
                        <Item FieldFormat=""4"" FieldID=""1"" CCRoleUID=""1""/>
                        <Item FieldFormat=""4"" FieldID=""9005"" CCRoleUID=""1""/>
                        <Item FieldFormat=""4"" FieldID=""9015"" CCRoleUID=""1""/>
                        <Item FieldFormat=""9"" FieldID=""9004""/>
                        <Item FieldFormat=""9"" FieldID=""1""/>
                        <Item FieldFormat=""96"" FieldID=""9020""/>
                    </Items>
                </xmlcfg>";
            const string queryXml = @"
                <xmlcfg>
                    <QueryRow Value=""1""/>
                    <QueryRow Value=""2""/>
                </xmlcfg>";
            var dbAccess = new DBAccess(DummyString, new SqlConnection());
            var queryNode = new CStruct();
            var displayFields = new CStruct();

            displayFields.LoadXML(displayFieldsXml);
            queryNode.LoadXML(queryXml);

            var parameters = new object[]
            {
                dbAccess,
                searchMode,
                queryNode,
                One,
                displayFields.GetSubStruct("Items").GetList("Item"),
                One.ToString(),
                includeUsers,
                includeInactive,
                includeGenerics
            };
            var expected = new List<string>()
            {
                $"LEFT join EPG_MY_RESOURCES MR ON WR.WRES_ID = MR.WRES_ID AND MR.MR_WRES_ID = {One}",
                $"DEPT.LV_VALUE AS Field9005",
                $"RPDEPT.LV_VALUE AS Field9015",
                "LEFT JOIN EPGP_LOOKUP_VALUES DEPT ON (DEPT.LV_UID = WR.WRES_DEPT)",
                "LEFT JOIN EPGP_LOOKUP_VALUES RPDEPT ON (RPDEPT.LV_UID = WR.WRES_RP_DEPT)",
                "AND WR.WRES_IS_GENERIC = 0",
                "WR.WRES_INACTIVE = 0",
                $"AND ( RES_NAME LIKE '%1%' OR  RES_NAME LIKE '%2%' )"
            };

            ShimResourceSelector.GetCustomFieldNameFromIDDBAccessInt32StringOutStringOut =
                (DBAccess dba, int lFieldID, out string sTableName, out string sFieldName) =>
                {
                    sTableName = DummyString;
                    sFieldName = DummyString;
                    return StatusEnum.rsSuccess;
                };

            // Act
            var actual = (string)privateObject.Invoke(BuildResourceSelectQueryMethodName, nonPublicInstance, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldNotBe(string.Empty),
                () => expected.Any(x => !actual.Contains(x)).ShouldBeFalse());
        }

        [TestMethod]
        public void BuildResourceSelectQuery_SearchModeDefault_ReturnsQueryString()
        {
            // Arrange
            const int searchMode = 1;
            const bool includeUsers = false;
            const bool includeInactive = false;
            const IncludeGenericsEnum includeGenerics = IncludeGenericsEnum.igYes;
            const string displayFieldsXml = @"
                <xmlcfg>
                    <RowLimit>0</RowLimit>
                    <Items>
                        <Item FieldFormat=""4"" FieldID=""1"" CCRoleUID=""1""/>
                        <Item FieldFormat=""4"" FieldID=""9005"" CCRoleUID=""1""/>
                        <Item FieldFormat=""4"" FieldID=""9015"" CCRoleUID=""1""/>
                        <Item FieldFormat=""9"" FieldID=""9004""/>
                        <Item FieldFormat=""9"" FieldID=""1""/>
                        <Item FieldFormat=""96"" FieldID=""9020""/>
                    </Items>
                </xmlcfg>";
            const string queryXml = @"
                <xmlcfg>
                    <QueryRow Operator=""1"" Value=""1"" FieldID=""9005"" FieldFormat=""4""/>
                    <QueryRow Operator=""6"" Value=""1"" FieldID=""9005"" FieldFormat=""4""/>
                    <QueryRow Operator=""2"" Value=""1"" FieldID=""9015"" FieldFormat=""4""/>
                    <QueryRow Operator=""5"" Value=""1"" FieldID=""9015"" FieldFormat=""4""/>
                    <QueryRow Operator=""5"" Value=""1"" FieldID=""1"" FieldFormat=""4""/>
                    <QueryRow Operator=""1"" Value=""1"" FieldID=""1"" FieldFormat=""40""/>
                    <QueryRow Operator=""2"" Value=""1"" FieldID=""1"" FieldFormat=""40""/>
                    <QueryRow Operator=""3"" Value=""1"" FieldID=""1"" FieldFormat=""40""/>
                    <QueryRow Operator=""4"" Value=""1"" FieldID=""1"" FieldFormat=""40""/>
                    <QueryRow Operator=""1"" Value=""1"" FieldID=""1"" FieldFormat=""98""/>
                    <QueryRow Operator=""2"" Value=""1"" FieldID=""1"" FieldFormat=""98""/>
                    <QueryRow Operator=""3"" Value=""1"" FieldID=""1"" FieldFormat=""98""/>
                    <QueryRow Operator=""4"" Value=""1"" FieldID=""1"" FieldFormat=""98""/>
                    <QueryRow Operator=""1"" Value=""1"" FieldID=""9004"" FieldFormat=""9""/>
                    <QueryRow Operator=""2"" Value=""1"" FieldID=""9004"" FieldFormat=""9""/>
                    <QueryRow Operator=""3"" Value=""1"" FieldID=""9004"" FieldFormat=""9""/>
                    <QueryRow Operator=""4"" Value=""1"" FieldID=""9004"" FieldFormat=""9""/>
                    <QueryRow Operator=""1"" Value=""1"" FieldID=""9006"" FieldFormat=""9""/>
                    <QueryRow Operator=""2"" Value=""1"" FieldID=""9006"" FieldFormat=""9""/>
                    <QueryRow Operator=""3"" Value=""1"" FieldID=""9006"" FieldFormat=""9""/>
                    <QueryRow Operator=""4"" Value=""1"" FieldID=""9006"" FieldFormat=""9""/>
                    <QueryRow Operator=""1"" Value=""1"" FieldID=""1"" FieldFormat=""9""/>
                    <QueryRow Operator=""2"" Value=""1"" FieldID=""1"" FieldFormat=""9""/>
                    <QueryRow Operator=""3"" Value=""1"" FieldID=""1"" FieldFormat=""9""/>
                    <QueryRow Operator=""4"" Value=""1"" FieldID=""1"" FieldFormat=""9""/>
                    <QueryRow Operator=""1"" Value=""2"" FieldID=""9018"" FieldFormat=""96""/>
                    <QueryRow Operator=""2"" Value=""2"" FieldID=""9018"" FieldFormat=""96""/>
                    <QueryRow Operator=""1"" Value=""1"" FieldID=""9018"" FieldFormat=""96""/>
                    <QueryRow Operator=""2"" Value=""1"" FieldID=""9018"" FieldFormat=""96""/>
                    <QueryRow Operator=""1"" Value=""1"" FieldID=""9020"" FieldFormat=""96""/>
                    <QueryRow Operator=""2"" Value=""1"" FieldID=""9020"" FieldFormat=""96""/>
                    <QueryRow Operator=""5"" Value=""1"" FieldID=""9020"" FieldFormat=""96""/>
                    <QueryRow Operator=""6"" Value=""1"" FieldID=""9020"" FieldFormat=""96""/>
                    <QueryRow Operator=""1"" Value=""1"" FieldID=""9021"" FieldFormat=""96""/>
                    <QueryRow Operator=""2"" Value=""1"" FieldID=""9021"" FieldFormat=""96""/>
                    <QueryRow Operator=""1"" Value=""2"" FieldID=""9021"" FieldFormat=""96""/>
                    <QueryRow Operator=""2"" Value=""2"" FieldID=""9021"" FieldFormat=""96""/>
                </xmlcfg>";
            var dbAccess = new DBAccess(DummyString, new SqlConnection());
            var queryNode = new CStruct();
            var displayFields = new CStruct();

            displayFields.LoadXML(displayFieldsXml);
            queryNode.LoadXML(queryXml);

            var parameters = new object[]
            {
                dbAccess,
                searchMode,
                queryNode,
                One,
                displayFields.GetSubStruct("Items").GetList("Item"),
                One.ToString(),
                includeUsers,
                includeInactive,
                includeGenerics
            };
            var expected = new List<string>()
            {
                $"LEFT join EPG_MY_RESOURCES MR ON WR.WRES_ID = MR.WRES_ID AND MR.MR_WRES_ID = {One}",
                $"DEPT.LV_VALUE AS Field9005",
                $"RPDEPT.LV_VALUE AS Field9015",
                "LEFT JOIN EPGP_LOOKUP_VALUES DEPT ON (DEPT.LV_UID = WR.WRES_DEPT)",
                "LEFT JOIN EPGP_LOOKUP_VALUES RPDEPT ON (RPDEPT.LV_UID = WR.WRES_RP_DEPT)",
                "AND (WR.WRES_IS_RESOURCE <> 0 OR WR.WRES_IS_GENERIC <> 0)",
                "WR.WRES_INACTIVE = 0",
                "AND RES_NAME LIKE '1'",
                "AND RES_NAME LIKE '%1%'",
                "AND RES_NAME LIKE '1%'",
                "AND RES_NAME NOT LIKE '1'",
                "AND CAT.BC_NAME LIKE '1'",
                "AND CAT.BC_NAME LIKE '%1%'",
                "AND CAT.BC_NAME LIKE '1%'",
                "AND CAT.BC_NAME NOT LIKE '1'",
                "AND WRES_IS_RESOURCE <> 0",
                "AND WRES_IS_RESOURCE = 0",
                "AND WRES_CAN_LOGIN <> 0",
                "AND WRES_CAN_LOGIN = 0"
            };

            ShimResourceSelector.GetCustomFieldNameFromIDDBAccessInt32StringOutStringOut =
                (DBAccess dba, int lFieldID, out string sTableName, out string sFieldName) =>
                {
                    sTableName = DummyString;
                    sFieldName = DummyString;
                    return StatusEnum.rsSuccess;
                };

            // Act
            var actual = (string)privateObject.Invoke(BuildResourceSelectQueryMethodName, nonPublicInstance, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldNotBe(string.Empty),
                () => expected.Any(x => !actual.Contains(x)).ShouldBeFalse());
        }

        [TestMethod]
        public void GetPIResourcesXML_WhenCalled_ReturnsResourceXmlString()
        {
            // Arrange
            const string xmlString = "<xmlcfg />";
            var parameters = new object[]
            {
                One,
                DummyString,
                false,
                DummyString
            };

            ShimResourceSelector.GetPeriodsDBAccessInt32ListOfCPeriodOut =
                (DBAccess dba, int iCal, out List<CPeriod> clnPeriods) =>
                {
                    validations += 1;
                    clnPeriods = new List<CPeriod>()
                    {
                        new CPeriod()
                        {
                            PeriodID = One,
                            StartDate = currentDate.AddDays(-1),
                            FinishDate = currentDate.AddDays(1)
                        }
                    };
                    return StatusEnum.rsSuccess;
                };
            ShimResourceSelector.GetPIResourcesStructDBAccessInt32StringStringListOfCPeriodCAdminInt32CStructOut =
                (DBAccess dba, int lUserWResId, string sProjectIDs, string sWResIDs, List<CPeriod> clnPeriods, CAdmin oAdmin, int lStartPeriodID, out CStruct xReply) =>
                {
                    validations += 1;
                    xReply = new CStruct();
                    xReply.LoadXML(xmlString);
                    return StatusEnum.rsSuccess;
                };

            // Act
            var actual = (bool)privateObject.Invoke(GetPIResourcesXMLMethodName, publicInstance, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => parameters[3].ShouldBe(xmlString),
                () => validations.ShouldBe(2));
        }
    }
}