using System;
using System.Collections;
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
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using Shouldly;
using WorkEnginePPM.Fakes;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class IntegrationTests
    {
        private Integration testObject;
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
        private const string ExecuteMethodName = "execute";
        private const string SetupPublishListMethodName = "setupPublishList";
        private const string GetUserFieldValueMethodName = "GetUserFieldValue";
        private const string ClearTimerJobMethodName = "clearTimerJob";
        private const string GetTimerJobMethodName = "getTimerJob";
        private const string SetTimerJobMethodName = "setTimerJob";

        [TestInitialize]
        public void Setup()
        {
            testObject = new Integration();
            privateObject = new PrivateObject(testObject);

            SetupShims();
        }

        private void SetupShims()
        {
            shimsContext = ShimsContext.Create();
            SetupVariables();

            ShimSqlConnection.ConstructorString = (_, __) => new SqlConnection();
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
            ShimSPSite.AllInstances.Close = _ => { };
            ShimSPWeb.AllInstances.Dispose = _ => { };
            ShimSPWeb.AllInstances.Close = _ => { };
            ShimCoreFunctions.getLockedWebSPWeb = _ => guid;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => DummyString;
            ShimCoreFunctions.getListSettingStringSPList = (_, __) => DummyString;
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (_1, _2, _3) => DummyString;
            ShimCoreFunctions.GetRealUserNameString = input => input;
            ShimCoreFunctions.getPrefix = () => DummyString;
            ShimConfigFunctions.getConnectionStringGuid = _ => DummyString;
            ShimConfigFunctions.getLockConfigSettingSPWebStringBoolean = (_1, _2, _3) => DummyString;
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
            ShimSqlDb.ReadDoubleValueObject = _ => DummyInt;
            ShimSqlDb.ReadIntValueObjectBooleanOut = (object input, out bool output) =>
            {
                output = false;
                return DummyInt;
            };
            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimSqlDb.ReadBoolValueObject = _ => true;
            ShimSqlDb.ReadDateValueObject = _ => currentDate;
            ShimSqlDb.AllInstances.HandleExceptionStringStatusEnumExceptionBoolean = (_, _1, _2, _3, _4) => StatusEnum.rsRequestInvalid;
            ShimSPFieldUserValueCollection.ConstructorSPWebString = (_, _1, _2) => new ShimSPFieldUserValueCollection();
        }

        private void SetupVariables()
        {
            validations = 0;
            publicStatic = BindingFlags.Static | BindingFlags.Public;
            nonPublicStatic = BindingFlags.Static | BindingFlags.NonPublic;
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
                UrlGet = () => SampleUrl,
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
                UserTokenGet = () => new ShimSPUserToken(),
                LoginNameGet = () => DummyString
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
                TitleGet = () => DummyString
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
                GetGuidInt32 = _ => guid,
                GetInt32Int32 = _ => DummyInt,
                GetStringInt32 = _ => DummyString,
                IsDBNullInt32 = _ => false
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void SetupPublishList_WhenCalled_UpdatesList()
        {
            // Arrange
            var expectedFields = new List<string>()
            {
                "Status",
                "PercentComplete",
                "Result",
                "ResultText",
                "FinishDate"
            };
            var actual = new List<string>();

            spFieldCollection.ContainsFieldString = _ => false;
            spFieldCollection.AddStringSPFieldTypeBoolean = (fieldName, _1, _2) =>
            {
                actual.Add(fieldName);
                return fieldName;
            };
            spFieldCollection.AddStringSPFieldTypeBooleanBooleanStringCollection = (fieldName, _1, _2, _3, _4) =>
            {
                actual.Add(fieldName);
                return fieldName;
            };
            spList.Update = () =>
            {
                validations += 1;
            };

            // Act
            privateObject.Invoke(
                SetupPublishListMethodName,
                nonPublicInstance,
                new object[]
                {
                    spList.Instance
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => expectedFields.Any(x => !actual.Contains(x)).ShouldBeFalse(),
                () => validations.ShouldBe(5));
        }

        [TestMethod]
        public void PublishTasks_ReadFalse_InsertsNewRecord()
        {
            // Arrange
            const string targetMethod = "PublishTasks";
            const string xmlString = @"<xmlcfg ID=""1.2.3""/>";
            const string expectedQuery = "select timerjobuid,status from vwQueueTimerLog where siteguid=@siteguid and webguid=@webguid and listguid=@listguid and itemid=@itemid and jobtype=9";
            const string expectedCommand = "INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname,  scheduletype, webguid, listguid, itemid, jobdata) VALUES (@timerjobuid, @siteguid, 9, 'Project Publish', 9, @webguid, @listguid, @itemid, @jobdata)";
            var parameters = new object[]
            {
                targetMethod,
                xmlString
            };

            dataReader.Read = () => false;

            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                if (instance.CommandText.Equals(expectedQuery))
                {
                    validations += 1;
                }
                return dataReader;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                if (instance.CommandText.Equals(expectedCommand))
                {
                    validations += 1;
                }
                return DummyInt;
            };
            ShimConfigFunctions.enqueueGuidInt32 = (_, __) =>
            {
                validations += 1;
            };

            // Act
            var actual = (XmlNode)privateObject.Invoke(ExecuteMethodName, publicInstance, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Name.ShouldBe("Result"),
                () => actual.InnerText.ShouldBe("Successfully Queued"),
                () => actual.Attributes["Status"].Value.ShouldBe("0"),
                () => validations.ShouldBe(3));
        }

        [TestMethod]
        public void PublishTasks_ReadTrue_UpdatesDatabase()
        {
            // Arrange
            const string targetMethod = "PublishTasks";
            const string xmlString = @"<xmlcfg ID=""1.2.3""/>";
            const string expectedQuery = "select timerjobuid,status from vwQueueTimerLog where siteguid=@siteguid and webguid=@webguid and listguid=@listguid and itemid=@itemid and jobtype=9";
            const string expectedCommand = "update timerjobs set jobdata=@jobdata where timerjobuid=@timerjobuid";
            var parameters = new object[]
            {
                targetMethod,
                xmlString
            };

            dataReader.Read = () => true;

            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                if (instance.CommandText.Equals(expectedQuery))
                {
                    validations += 1;
                }
                return dataReader;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                if (instance.CommandText.Equals(expectedCommand))
                {
                    validations += 1;
                }
                return DummyInt;
            };
            ShimConfigFunctions.enqueueGuidInt32 = (_, __) =>
            {
                validations += 1;
            };

            // Act
            var actual = (XmlNode)privateObject.Invoke(ExecuteMethodName, publicInstance, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Name.ShouldBe("Result"),
                () => actual.SelectSingleNode("//Error").Attributes["ID"].Value.ShouldBe("101"),
                () => actual.SelectSingleNode("//Error").InnerText.ShouldBe("Item Already Queued"),
                () => actual.Attributes["Status"].Value.ShouldBe("1"),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void PublishStatus_WhenCalled_ParseSelectQuery()
        {
            // Arrange
            const string targetMethod = "PublishStatus";
            const string xmlString = @"<xmlcfg ID=""1.2.3"" ShowResults=""True""/>";
            const string expectedCommand = "select percentComplete,status,dtfinished,result,resulttext from vwQueueTimerLog where siteguid=@siteguid and webguid=@webguid and listguid=@listguid and itemid=@itemid and jobtype=9";
            var parameters = new object[]
            {
                targetMethod,
                xmlString
            };

            ShimPublishHelper.ParseResultsSqlCommandString = (instance, __) =>
            {
                if (instance.CommandText.Equals(expectedCommand))
                {
                    validations += 1;
                }
                return DummyString;
            };

            // Act
            var actual = (XmlNode)privateObject.Invoke(ExecuteMethodName, publicInstance, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Name.ShouldBe("Result"),
                () => actual.InnerText.ShouldBe(DummyString),
                () => actual.Attributes["Status"].Value.ShouldBe("0"),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void GetUpdateCount_WhenCalled_GetsUpdateCount()
        {
            // Arrange
            const string targetMethod = "GetUpdateCount";
            var xmlString = $@"<xmlcfg ID=""{SampleGuidString1}.{SampleGuidString2}.{DummyInt}"" Key=""key""/>";
            var expectedList = $"<Lists><List ID=\"{guid}\"/></Lists>";
            var expectedQuery = $"<Where><And><Eq><FieldRef Name=\"{DummyString}\" LookupId=\"True\"/><Value Type=\"Lookup\">{DummyInt}</Value></Eq><Neq><FieldRef Name=\"PubTransUid\"/><Value Type=\"Text\">{DummyString.ToUpper()}</Value></Neq></And></Where>";
            const string expectedViewFields = "<FieldRef Name=\"Title\"/><FieldRef Name=\"taskuid\"/><FieldRef Name=\"PubTransUid\"/>";
            var parameters = new object[]
            {
                targetMethod,
                xmlString
            };
            var dataTable = new DataTable();

            dataTable.Columns.Add(DummyString);
            dataTable.Rows.Add(dataTable.NewRow());
            dataTable.Rows.Add(dataTable.NewRow());
            dataTable.Rows.Add(dataTable.NewRow());

            spWeb.GetSiteDataSPSiteDataQuery = _ => dataTable;
            ShimConfigFunctions.getLockConfigSettingSPWebStringBoolean = (_1, _2, _3) => DummyString;
            ShimSPSiteDataQuery.AllInstances.ListsSetString = (_, input) =>
            {
                if (input.Equals(expectedList))
                {
                    validations += 1;
                }
            };
            ShimSPSiteDataQuery.AllInstances.QuerySetString = (_, input) =>
            {
                if (input.Equals(expectedQuery))
                {
                    validations += 1;
                }
            };
            ShimSPSiteDataQuery.AllInstances.ViewFieldsSetString = (_, input) =>
            {
                if (input.Equals(expectedViewFields))
                {
                    validations += 1;
                }
            };

            // Act
            var actual = (XmlNode)privateObject.Invoke(ExecuteMethodName, publicInstance, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Name.ShouldBe("Result"),
                () => actual.InnerText.ShouldBe(Three.ToString()),
                () => actual.Attributes["Status"].Value.ShouldBe("0"),
                () => validations.ShouldBe(3));
        }

        [TestMethod]
        public void GetUserFieldValue_WhenCalled_ReturnsUserFieldValue()
        {
            // Arrange
            var expected = $"{DummyString},{DummyString},{DummyString}";
            var parameters = new object[]
            {
                spList.Instance,
                spListItem.Instance,
                spField.Instance,
                DummyString
            };
            var userFieldValue = new ShimSPFieldUserValue()
            {
                UserGet = () => spUser
            };
            var customEnumerator = new List<SPFieldUserValue>()
            {
                userFieldValue,
                userFieldValue,
                userFieldValue
            }.GetEnumerator();

            ShimList<SPFieldUserValue>.AllInstances.GetEnumerator = _ => customEnumerator;

            // Act
            privateObject.Invoke(GetUserFieldValueMethodName, nonPublicStatic, parameters);
            var actual = (string)parameters[3];

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => validations.ShouldBe(0));
        }

        [TestMethod]
        public void Getresourcepoolurl_WhenCalled_GetsResourcePoolUrl()
        {
            // Arrange
            const string targetMethod = "getresourcepoolurl";
            var parameters = new object[]
            {
                targetMethod,
                DummyString
            };

            ShimConfigFunctions.getLockConfigSettingSPWebStringBoolean = (_1, _2, _3) =>
            {
                validations += 1;
                return DummyString;
            };

            // Act
            var actual = (XmlNode)privateObject.Invoke(ExecuteMethodName, publicInstance, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Name.ShouldBe("Result"),
                () => actual.InnerText.ShouldBe(DummyString),
                () => actual.Attributes["Status"].Value.ShouldBe("0"),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void GetMappedView_WhenCalled_GetsMappedView()
        {
            // Arrange
            const string targetMethod = "GetMappedView";
            var xmlString = $@"<xmlcfg Key=""key"" List=""{SampleGuidString1}"" View=""{One}"">{DummyString}</xmlcfg>";
            var parameters = new object[]
            {
                targetMethod,
                xmlString
            };

            ShimConfigFunctions.getConfigSettingSPWebString = (_1, _2) =>
            {
                validations += 1;
                return $"{DummyString},{DummyString}";
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (_1, _2) =>
            {
                validations += 1;
                return string.Empty;
            };

            // Act
            var actual = (XmlNode)privateObject.Invoke(ExecuteMethodName, publicInstance, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Name.ShouldBe("Result"),
                () => actual.Attributes["Status"].Value.ShouldBe("0"),
                () => actual.SelectSingleNode("//DefaultView").Attributes["ViewId"].Value.ShouldBe(DummyString),
                () => actual.SelectSingleNode("//DefaultView").Attributes["ViewName"].Value.ShouldBe(DummyString),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void GetProjectIdFromName_WhenCalled_GetsProjectId()
        {
            // Arrange
            const string targetMethod = "GetProjectIdFromName";
            var xmlString = $@"<xmlcfg Key=""key"" List=""{SampleGuidString1}"" View=""{One}"">{DummyString}</xmlcfg>";
            var expected = $"{guid}.{guid}.{DummyInt}";
            var parameters = new object[]
            {
                targetMethod,
                xmlString
            };

            // Act
            var actual = (XmlNode)privateObject.Invoke(ExecuteMethodName, publicInstance, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Name.ShouldBe("Result"),
                () => actual.Attributes["Status"].Value.ShouldBe("0"),
                () => actual.InnerText.ShouldBe(expected),
                () => validations.ShouldBe(0));
        }

        [TestMethod]
        public void GetTimesheetTypes_WhenCalled_GetsTimeSheetTypes()
        {
            // Arrange
            const string targetMethod = "GetTimesheetTypes";
            var xmlString = $@"<xmlcfg Key=""key"">{DummyString}</xmlcfg>";
            var parameters = new object[]
            {
                targetMethod,
                xmlString
            };
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            // Act
            var actual = (XmlNode)privateObject.Invoke(ExecuteMethodName, publicInstance, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Name.ShouldBe("Result"),
                () => actual.SelectSingleNode("//Type").Attributes["ID"].Value.ShouldBe(DummyInt.ToString()),
                () => actual.SelectSingleNode("//Type").Attributes["Type"].Value.ShouldBe(DummyInt.ToString()),
                () => actual.Attributes["Status"].Value.ShouldBe("0"),
                () => validations.ShouldBe(0));
        }

        [TestMethod]
        public void UpdateResources_WhenCalled_UpdatesResources()
        {
            // Arrange
            const string targetMethod = "UpdateResources";
            var xmlString = $@"
                <Resources Key=""key"">
                    <Resource/>
                    <Resource/>
                    <Resource/>
                </Resources>";
            var parameters = new object[]
            {
                targetMethod,
                xmlString
            };
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimConfigFunctions.getLockConfigSettingSPWebStringBoolean = (_1, _2, _3) =>
            {
                validations += 1;
                return $"{DummyString},{DummyString}";
            };
            ShimHelperFunctions.processResourceXmlNodeSPListHashtableBooleanRefString =
                (XmlNode nd, SPList resList, Hashtable hshFields, ref bool errors, string sPrefix) =>
                {
                    validations += 1;
                    errors = true;
                    return DummyString;
                };

            // Act
            var actual = (XmlNode)privateObject.Invoke(ExecuteMethodName, publicInstance, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Name.ShouldBe("Result"),
                () => actual.InnerText.ShouldBe($"{DummyString}{DummyString}{DummyString}"),
                () => actual.Attributes["Status"].Value.ShouldBe("1"),
                () => validations.ShouldBe(5));
        }

        [TestMethod]
        public void DisableResources_WhenCalled_DisablesResources()
        {
            // Arrange
            const string targetMethod = "DisableResources";
            var xmlString = $@"
                <Resources Key=""key"">
                    <Resource/>
                    <Resource/>
                    <Resource/>
                </Resources>";
            var parameters = new object[]
            {
                targetMethod,
                xmlString
            };
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimConfigFunctions.getLockConfigSettingSPWebStringBoolean = (_1, _2, _3) =>
            {
                validations += 1;
                return $"{DummyString},{DummyString}";
            };
            ShimHelperFunctions.processResourceDisableXmlNodeSPListBooleanOut =
                (XmlNode nd, SPList resList, out bool errors) =>
                {
                    validations += 1;
                    errors = true;
                    return DummyString;
                };

            // Act
            var actual = (XmlNode)privateObject.Invoke(ExecuteMethodName, publicInstance, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Name.ShouldBe("Result"),
                () => actual.InnerText.ShouldBe($"{DummyString}{DummyString}{DummyString}"),
                () => actual.Attributes["Status"].Value.ShouldBe("1"),
                () => validations.ShouldBe(4));
        }

        [TestMethod]
        public void ClearTimerJob_WhenCalled_DeletesFromDatabase()
        {
            // Arrange
            const string expectedQuery = "delete from timerjobs where siteguid=@siteguid and jobtype=@jobtype";
            var jobType = 111.ToString();
            var sqlCommand = default(SqlCommand);

            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                sqlCommand = instance;
                validations += 1;
                return DummyInt;
            };

            // Act
            privateObject.Invoke(
                ClearTimerJobMethodName,
                nonPublicInstance,
                new object[]
                {
                    jobType,
                    spWeb.Instance
                });

            // Assert
            sqlCommand.ShouldSatisfyAllConditions(
                () => sqlCommand.CommandText.ShouldBe(expectedQuery),
                () => sqlCommand.Parameters["@siteguid"].Value.ShouldBe(guid.ToString()),
                () => sqlCommand.Parameters["@jobtype"].Value.ShouldBe(jobType),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void GetTimerJob_WhenCalled_SelectsJobFromDatabase()
        {
            // Arrange
            const string expectedQuery = "select jobname,runtime,scheduletype,coalesce(days,'') as days from timerjobs where siteguid=@siteguid and jobtype=@jobtype";
            var jobType = 111.ToString();
            var sqlCommand = default(SqlCommand);
            var expected = $"{DummyString}|{jobType}|{DummyInt}|{DummyInt}|{DummyString}";

            dataReader.Read = () => true;

            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                sqlCommand = instance;
                validations += 1;
                return dataReader;
            };

            // Act
            var actual = (string)privateObject.Invoke(
                GetTimerJobMethodName,
                nonPublicInstance,
                new object[]
                {
                    jobType,
                    spWeb.Instance
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => sqlCommand.CommandText.ShouldBe(expectedQuery),
                () => sqlCommand.Parameters["@siteguid"].Value.ShouldBe(guid.ToString()),
                () => sqlCommand.Parameters["@jobtype"].Value.ShouldBe(jobType),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void setTimerJob_ReadTrue_UpdatesJob()
        {
            // Arrange
            const string expectedSelectQuery = "select timerjobuid from timerjobs where siteguid=@siteguid and jobtype=@jobtype";
            const string expectedCommand = "UPDATE TIMERJOBS set runtime = @runtime, days=@days,scheduletype=@scheduletype where siteguid=@siteguid and jobtype=@jobtype";
            var sqlCommand = default(SqlCommand);
            var jobType = 111.ToString();
            var settings = $"{DummyString}|{jobType}|{DummyInt}|{DummyInt}|{DummyString}";

            dataReader.Read = () => true;

            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                if (instance.CommandText.Equals(expectedSelectQuery))
                {
                    validations += 1;
                }
                return dataReader;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                sqlCommand = instance;
                validations += 1;
                return DummyInt;
            };

            // Act
            privateObject.Invoke(
                SetTimerJobMethodName,
                nonPublicInstance,
                new object[]
                {
                    settings,
                    spWeb.Instance
                });

            // Assert
            sqlCommand.ShouldSatisfyAllConditions(
                () => sqlCommand.CommandText.ShouldBe(expectedCommand),
                () => sqlCommand.Parameters["@siteguid"].Value.ShouldBe(guid.ToString()),
                () => sqlCommand.Parameters["@runtime"].Value.ShouldBe(DummyInt.ToString()),
                () => sqlCommand.Parameters["@scheduletype"].Value.ShouldBe(DummyInt.ToString()),
                () => sqlCommand.Parameters["@jobtype"].Value.ShouldBe(jobType),
                () => sqlCommand.Parameters["@days"].Value.ShouldBe(DummyString),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void setTimerJob_ReadFalse_UpdatesJob()
        {
            // Arrange
            const string expectedSelectQuery = "select timerjobuid from timerjobs where siteguid=@siteguid and jobtype=@jobtype";
            const string expectedCommand = "INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname, runtime, scheduletype, webguid, days) VALUES (@timerjobuid, @siteguid, @jobtype, @name, @runtime, @scheduletype, @webguid, @days)";
            var sqlCommand = default(SqlCommand);
            var jobType = 111.ToString();
            var settings = $"{DummyString}|{jobType}|{DummyInt}|{DummyInt}|{DummyString}";

            dataReader.Read = () => false;

            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                if (instance.CommandText.Equals(expectedSelectQuery))
                {
                    validations += 1;
                }
                return dataReader;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                sqlCommand = instance;
                validations += 1;
                return DummyInt;
            };

            // Act
            privateObject.Invoke(
                SetTimerJobMethodName,
                nonPublicInstance,
                new object[]
                {
                    settings,
                    spWeb.Instance
                });

            // Assert
            sqlCommand.ShouldSatisfyAllConditions(
                () => sqlCommand.CommandText.ShouldBe(expectedCommand),
                () => sqlCommand.Parameters["@siteguid"].Value.ShouldBe(guid.ToString()),
                () => sqlCommand.Parameters["@runtime"].Value.ShouldBe(DummyInt.ToString()),
                () => sqlCommand.Parameters["@scheduletype"].Value.ShouldBe(DummyInt.ToString()),
                () => sqlCommand.Parameters["@jobtype"].Value.ShouldBe(jobType),
                () => sqlCommand.Parameters["@days"].Value.ShouldBe(DummyString),
                () => sqlCommand.Parameters["@name"].Value.ShouldBe(DummyString),
                () => validations.ShouldBe(2));
        }
    }
}