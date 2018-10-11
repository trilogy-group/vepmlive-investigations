using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic.Fakes;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.IO.Fakes;
using System.Reflection;
using System.Text;
using System.Web.Fakes;
using System.Xml;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveWorkPlanner.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API.Publish
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class APIPublishTests
    {
        private APIPublish testObj;
        private PrivateObject privateObj;
        private IDisposable shimsContext;
        private ShimSPWeb spWeb;
        private ShimSPSite spSite;
        private Guid guid;
        private ShimSqlDataReader dataReader;
        private DateTime now;
        private Dictionary<string, PlannerDefinition> defs;
        private ShimSPList list;
        private ShimSPListItem listItem;
        private ShimSPField spField;
        private DataTable dTable;
        private DataTable dTableTeam;
        private List<SPFieldUserValue> userList;
        private List<string> parameterList;
        private List<string> commandsList;
        private const string GetProjectInfoFromNameMethodName = "GetProjectInfoFromName";
        private const string GetPublisherSettingsMethodName = "GetPublisherSettings";
        private const string GetPublisherItemInfoMethodName = "GetPublisherItemInfo";
        private const string PublishMethodName = "Publish";
        private const string PublishStatusMethodName = "PublishStatus";
        private const string GetUpdateCountMethodName = "GetUpdateCount";
        private const string ProcessUpdatesMethodName = "ProcessUpdates";
        private const string GetUpdatesMethodName = "GetUpdates";
        private const string BuildTaskMethodName = "buildTask";
        private const string ConnectionString = "ConnectionString";
        private const string InternalNameString = "InternalName";
        private const string ProjectList = "EPMLivePublisherProjectCenter";
        private const string Planner = "Planner";
        private const string Title = "Title";
        private const string LockedItems = "Item1,Item2,Item3,Item4,Item5,Item6";
        private const string GetStringOutput = "GetString";
        private const string IdColumn = "ID";
        private const string SpIdColumn = "SPID";
        private const string PublishXml = @"
            <xml PlannerID=""msproject"" ID=""1"">
                <Field Name=""Project"">#ProjectName</Field>
            </xml>";
        private const string PublishStatusShowResultsTrue = @"
            <xml PlannerID=""msproject"" ID=""1"" ShowResults=""true"">
                <Field Name=""Project"">#ProjectName</Field>
            </xml>";
        private const string PublishStatusShowResultsFalse = @"
            <xml PlannerID=""msproject"" ID=""1"" ShowResults=""false"" UserType=""1"" DateFormat=""DateFormat"">
                <Field Name=""Project"">#ProjectName</Field>
                <Task ItemID=""1"" Status=""1"" taskuid=""1""></Task>
                <Task ItemID=""2"" Status=""0"" taskuid=""2""></Task>
            </xml>";

        [TestInitialize]
        public void Setup()
        {
            testObj = new APIPublish();
            privateObj = new PrivateObject(testObj);

            var row = default(DataRow);

            dTable = new DataTable();
            dTable.Columns.Add(IdColumn, typeof(int));
            row = dTable.NewRow();
            row[IdColumn] = 1;
            dTable.Rows.Add(row);

            dTableTeam = new DataTable();
            dTableTeam.Columns.Add(SpIdColumn, typeof(int));
            dTableTeam.Columns.Add(IdColumn, typeof(int));
            row = dTableTeam.NewRow();
            row[SpIdColumn] = 1;
            row[IdColumn] = 1;
            dTableTeam.Rows.Add(row);

            SetupShims();
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        private void SetupVariables()
        {
            guid = Guid.NewGuid();
            now = DateTime.Now;

            userList = new List<SPFieldUserValue>()
            {
                new ShimSPFieldUserValue()
                {
                    UserGet = () => new ShimSPUser()
                    {
                        LoginNameGet = () => GetStringOutput,
                        IDGet = () => 1
                    }
                }.Instance
            };

            listItem = new ShimSPListItem()
            {
                IDGet = () => 1,
                ItemGetGuid = _ => new object(),
                SystemUpdate = () => { },
                ItemGetString = key =>
                {
                    var result = key;
                    switch (key)
                    {
                        case "taskorder":
                        case "taskuid":
                            result = "1";
                            break;
                    }
                    return result;
                },
                TitleGet = () => Title
            };

            list = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = _ => new ShimSPField()
                    {
                        IdGet = () => guid
                    },
                    ItemGetGuid = _ => new ShimSPField()
                    {
                        GetFieldValueString = _1 => GetStringOutput
                    }
                },
                GetItemsSPQuery = _ => new ShimSPListItemCollection()
                {
                    CountGet = () => 1,
                    ItemGetInt32 = _1 => listItem
                },
                GetItemByIdInt32 = _ => listItem,
                IDGet = () => guid,
                ParentWebGet = () => new ShimSPWeb()
                {
                    GetSiteDataSPSiteDataQuery = _ => dTable
                },
                Update = () => { }
            };

            spField = new ShimSPField()
            {
                IdGet = () => guid,
                InternalNameGet = () => InternalNameString,
                SchemaXmlGet = () => PublishStatusShowResultsFalse
            };

            defs = new Dictionary<string, PlannerDefinition>()
            {
                [GetStringOutput] = new PlannerDefinition()
            };

            spSite = new ShimSPSite()
            {
                IDGet = () => guid,
                WebApplicationGet = () => new ShimSPWebApplication()
            };

            spWeb = new ShimSPWeb()
            {
                CurrentUserGet = () => new ShimSPUser()
                {
                    IDGet = () => 1
                },
                IDGet = () => guid,
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetString = key => list,
                    TryGetListString = _ => list
                },
                GetFileString = url => new ShimSPFile()
                {
                    ExistsGet = () => true,
                    ParentFolderGet = () => new ShimSPFolder()
                    {
                        NameGet = () => Planner
                    }
                },
                SiteGet = () => spSite
            };

            dataReader = new ShimSqlDataReader()
            {
                Close = () => { },
                GetGuidInt32 = index => guid,
                IsDBNullInt32 = index => false,
                GetInt32Int32 = index => 2,
                GetStringInt32 = index => GetStringOutput,
                GetDateTimeInt32 = index => now
            };

            parameterList = new List<string>();
            commandsList = new List<string>();
        }

        private void SetupShims()
        {
            shimsContext = ShimsContext.Create();

            SetupVariables();

            ShimAPIEmail.QueueItemMessageInt32BooleanHashtableStringArrayStringArrayBooleanBooleanSPWebSPUserBoolean =
                (_, _1, _2, _3, _4, _5, _6, _7, _8, _9) => { };
            ShimAPITeam.GetResourcePoolStringSPWeb = (_, __) => dTableTeam;
            ShimCoreFunctions.enqueueGuidInt32 = (_, __) => { };
            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (_, key, _2) =>
            {
                var result = key;
                switch (key)
                {
                    case "EPMLivePublisherProjectCenter":
                        result = ProjectList;
                        break;
                    case "EPMLivePlannermsprojectTaskCenterFields":
                        result = "field11,field12|field21,field22";
                        break;
                }
                return result;
            };
            ShimCoreFunctions.getLockedWebSPWeb = _ => guid;
            ShimCoreFunctions.getConnectionStringGuid = _ => ConnectionString;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, key) =>
            {
                var result = key;
                switch (key)
                {
                    case "EPMLivePlannerPlannerPJLockItems":
                        result = LockedItems;
                        break;
                    case "EPMLivePlannerPlannerTSFlag":
                    case "EPMLivePlannerPlannerTSHours":
                        result = string.Empty;
                        break;
                    case "updateperflimit":
                        result = "5";
                        break;
                }
                return result;
            };
            ShimCoreFunctions.getListSettingStringSPList = (key, _1) => string.Empty;
            ShimCoreFunctions.GetPlannerListSPWebSPListItem = (_, __) => defs;
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, _1) => true;
            ShimHttpUtility.UrlDecodeString = url => url;
            ShimList<SPFieldUserValue>.AllInstances.GetEnumerator = _ =>
            {
                var result = default(List<SPFieldUserValue>.Enumerator);
                ShimsContext.ExecuteWithoutShims(() =>
                {
                    result = userList.GetEnumerator();
                });
                return result;
            };
            ShimPath.GetFileNameWithoutExtensionString = fileName => fileName;
            ShimPlannerCore.getWorkPlannerStatusFieldsSPWebString = (_, __) => new SortedList();
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => 1;
            ShimSPFieldUserValue.ConstructorSPWebString = (_, _1, _2) => new ShimSPFieldUserValue();
            ShimSPFieldUserValue.AllInstances.LookupValueGet = _ => Title;
            ShimSPFieldUserValueCollection.ConstructorSPWebString = (_, _1, _2) => new SPFieldUserValueCollection();
            ShimSPPersistedObject.AllInstances.IdGet = _ => guid;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun =>
            {
                codeToRun();
            };
            ShimSPSite.ConstructorGuid = (_, _1) => new ShimSPSite();
            ShimSPSite.AllInstances.OpenWebGuid = (_, _1) => spWeb;
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                SiteGet = () => spSite,
                WebGet = () => spWeb
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => dataReader;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimSqlCommand.ConstructorStringSqlConnection = (_, commandString, connection) => commandsList.Add(commandString);
            ShimSqlConnection.ConstructorString = (_, __) => new ShimSqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlParameterCollection.AllInstances.AddWithValueStringObject = (_, parameterName, parameterObject) => 
            {
                parameterList.Add(parameterName);
                return null;
            };
        }

        [TestMethod]
        public void GetProjectInfoFromName_WhenCalled_ReturnsString()
        {
            // Arrange
            const string xml = @"<project List="""">projectName</project>";
            var expected = $"<ProjectInfo ProjectId=\"{guid}.{guid}.1\"></ProjectInfo>";

            // Act
            var actual = (string)privateObj.Invoke(
                GetProjectInfoFromNameMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { xml, spWeb.Instance });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetPublisherSettings_WhenCalled_ReturnsXml()
        {
            // Arrange
            const string inputData = "<projectUrl>http://projectUrl</projectUrl>";
            var actual = new XmlDocument();

            // Act
            actual.LoadXml((string)privateObj.Invoke(
                GetPublisherSettingsMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { inputData, spWeb.Instance }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("Properties"),
                () => actual.FirstChild.ChildNodes.Count.ShouldBe(15),
                () => actual.FirstChild.ChildNodes[8].Name.ShouldBe("EPMLiveTSFlag"),
                () => actual.FirstChild.ChildNodes[8].InnerText.ShouldBe("Flag15"),
                () => actual.FirstChild.ChildNodes[9].Name.ShouldBe("EPMLiveTSTimesheetHours"),
                () => actual.FirstChild.ChildNodes[9].InnerText.ShouldBe("Number15"));
        }

        [TestMethod]
        public void GetPublisherItemInfo_WhenCalled_ReturnsString()
        {
            // Arrange
            const string inputData = "<projectUrl>http://projectUrl</projectUrl>";
            var expected = $"<PublisherItemInfo ListId=\"{guid}\" ItemId=\"1\"/>";

            // Act
            var actual = (string)privateObj.Invoke(
                GetPublisherItemInfoMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { inputData, spWeb.Instance });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void Publish_ReadFalse_ReturnsString()
        {
            // Arrange
            const string expected = "Success";

            dataReader.Read = () => false;

            // Act
            var actual = (string)privateObj.Invoke(
                PublishMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { PublishXml });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void Publish_ReadFalse_AddParametersAndCommands()
        {
            // Arrange
            ReadOnlyCollection<string> expectedParameterList = new List<string>
            {
                "@siteguid", "@webguid", "@listguid", "@itemid", "@key",
                "@siteguid", "@webguid", "@listguid", "@itemid", "@jobdata", "@timerjobuid", "@jobname", "@key"
            }.AsReadOnly() ;

            ReadOnlyCollection<string> expectedCommandList = new List<string>
            {
                "select timerjobuid,status from vwQueueTimerLog where siteguid=@siteguid and webguid=@webguid and listguid=@listguid and itemid=@itemid and jobtype=9 and [key] = @key",
                "INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname,  scheduletype, webguid, listguid, itemid, jobdata, [key]) VALUES (@timerjobuid, @siteguid, 9, @jobname, 9, @webguid, @listguid, @itemid, @jobdata, @key)"
            }.AsReadOnly();

            dataReader.Read = () => false;

            // Act
            var actual = (string)privateObj.Invoke(
                PublishMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { PublishXml });

            // Assert
            parameterList.ShouldBe(expectedParameterList);
            commandsList.ShouldBe(expectedCommandList);
        }

        [TestMethod]
        public void Publish_ReadTrue_ReturnsString()
        {
            // Arrange
            const string expected = "Success";

            dataReader.Read = () => true;

            // Act
            var actual = (string)privateObj.Invoke(
                PublishMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { PublishXml });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void Publish_ReadTrue_AddParametersAndCommands()
        {
            // Arrange
            ReadOnlyCollection<string> expectedParameterList = new List<string>
            {
                "@siteguid", "@webguid", "@listguid", "@itemid", "@key",
                "@jobdata", "@timerjobuid"
            }.AsReadOnly();

            ReadOnlyCollection<string> expectedCommandList = new List<string>
            {
                "select timerjobuid,status from vwQueueTimerLog where siteguid=@siteguid and webguid=@webguid and listguid=@listguid and itemid=@itemid and jobtype=9 and [key] = @key",
                "update timerjobs set jobdata=@jobdata where timerjobuid=@timerjobuid"
            }.AsReadOnly();

            dataReader.Read = () => true;

            // Act
            var actual = (string)privateObj.Invoke(
                PublishMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { PublishXml });

            // Assert
            parameterList.ShouldBe(expectedParameterList);
            commandsList.ShouldBe(expectedCommandList);
        }

        [TestMethod]
        [ExpectedException(typeof(APIException), "Item Already Queued")]
        public void Publish_StatusDoesNotEqualTwo_ThrowAPIException()
        {
            // Arrange
            dataReader.Read = () => true;
            dataReader.GetInt32Int32 = _ => 0;

            // Act
            var actual = (string)privateObj.Invoke(
                PublishMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { PublishXml });            
        }

        [TestMethod]
        public void PublishStatus_ReadTrueCase0_ReturnsString()
        {
            // Arrange
            var expected = $"<PublishStatus Status=\"Queued\" PercentComplete=\"0\" TimeFinished=\"{now.ToString()}\" Result=\"{GetStringOutput}\"><![CDATA[{GetStringOutput}]]></PublishStatus>";

            dataReader.Read = () => true;
            dataReader.GetInt32Int32 = index => 0;

            // Act
            var actual = (string)privateObj.Invoke(
                PublishStatusMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { PublishStatusShowResultsTrue });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void PublishStatus_ReadTrueCase1_ReturnsString()
        {
            // Arrange
            var expected = $"<PublishStatus Status=\"Processing\" PercentComplete=\"1\" TimeFinished=\"{now.ToString()}\" Result=\"{GetStringOutput}\"><![CDATA[{GetStringOutput}]]></PublishStatus>";

            dataReader.Read = () => true;
            dataReader.GetInt32Int32 = index => 1;

            // Act
            var actual = (string)privateObj.Invoke(
                PublishStatusMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { PublishStatusShowResultsTrue });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void PublishStatus_ReadTrueCase2_ReturnsString()
        {
            // Arrange
            var expected = $"<PublishStatus Status=\"Complete\" PercentComplete=\"2\" TimeFinished=\"{now.ToString()}\" Result=\"{GetStringOutput}\"/>";

            dataReader.Read = () => true;
            dataReader.GetInt32Int32 = index => 2;

            // Act
            var actual = (string)privateObj.Invoke(
                PublishStatusMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { PublishStatusShowResultsFalse });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void PublishStatus_ReadFalse_ReturnsString()
        {
            // Arrange
            const string expected = "<PublishStatus/>";

            dataReader.Read = () => false;

            // Act
            var actual = (string)privateObj.Invoke(
                PublishStatusMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { PublishStatusShowResultsFalse });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetUpdateCount_WhenCalled_ReturnsString()
        {
            // Arrange
            const int expected = 5;

            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection()
            {
                CountGet = () => expected
            };

            // Act
            var actual = (string)privateObj.Invoke(
                GetUpdateCountMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { PublishStatusShowResultsFalse, spWeb.Instance });

            // Assert
            actual.ShouldBe(expected.ToString());
        }

        [TestMethod]
        public void ProcessUpdates_WhenCalled_ReturnsString()
        {
            // Arrange
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<Project>");
            stringBuilder.Append(@"<Task ID=""1"" Status=""0""/>");
            stringBuilder.Append(@"<Task ID=""2"" Status=""0""/>");
            stringBuilder.Append("</Project>");
            var expected = stringBuilder.ToString();

            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection()
            {
                CountGet = () => 0
            };

            // Act
            var actual = (string)privateObj.Invoke(
                ProcessUpdatesMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { PublishStatusShowResultsFalse, spWeb.Instance });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetUpdates_WhenCalled_ReturnsString()
        {
            // Arrange
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<Project>");
            stringBuilder.AppendFormat("<Task ID=\"1\" UID=\"1\" ItemID=\"1\"><Field Name=\"Title\"><![CDATA[{0}]]></Field>", Title);
            stringBuilder.AppendFormat("<Field Name=\"Editor\"><![CDATA[{0}]]></Field>", Title);
            stringBuilder.Append("<Field Name=\"IsAssignment\"><![CDATA[0]]></Field>");
            stringBuilder.Append("<Field Name=\"TaskHierarchy\"><![CDATA[TaskHierarchy]]></Field>");
            stringBuilder.Append("</Task>");
            stringBuilder.Append("</Project>");
            var expected = stringBuilder.ToString();
            
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPField>()
            {
                new ShimSPField()
                {
                    InternalNameGet = () => InternalNameString,
                    ShowInEditFormGet = () => null,
                    TypeGet = () => SPFieldType.Boolean
                }
            }.GetEnumerator();

            // Act
            var actual = (string)privateObj.Invoke(
                GetUpdatesMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { PublishStatusShowResultsFalse, spWeb.Instance });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void BuildTask_InvalidType_ReturnsString()
        {
            // Arrange
            const int userType = 1;

            var dateformat = string.Empty;
            var hashTable = new Hashtable();
            var outputValue = GetStringOutput;
            var expected = $"<Field Name=\"{InternalNameString}\"><![CDATA[{outputValue}]]></Field>";

            spField.TypeGet = () => SPFieldType.Attachments;

            // Act
            var actual = (string)privateObj.Invoke(
                BuildTaskMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, listItem.Instance, list.Instance, dateformat, userType, dTableTeam, hashTable });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void BuildTask_NumberType_ReturnsString()
        {
            // Arrange
            const int userType = 1;

            var dateformat = string.Empty;
            var input = 5.1;
            const string outputValue = "5.1";
            var expected = $"<Field Name=\"{InternalNameString}\"><![CDATA[{outputValue}]]></Field>";

            var hashTable = new Hashtable();
            spField.TypeGet = () => SPFieldType.Number;

            listItem.ItemGetGuid = _ => input;

            // Act
            var actual = (string)privateObj.Invoke(
                BuildTaskMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, listItem.Instance, list.Instance, dateformat, userType, dTableTeam, hashTable });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void BuildTask_CurrencyType_ReturnsString()
        {
            // Arrange
            const int userType = 1;

            var dateformat = string.Empty;
            var input = 5.1;
            const string outputValue = "5.1";
            var expected = $"<Field Name=\"{InternalNameString}\"><![CDATA[{outputValue}]]></Field>";

            var hashTable = new Hashtable();
            spField.TypeGet = () => SPFieldType.Currency;

            listItem.ItemGetGuid = _ => input;

            // Act
            var actual = (string)privateObj.Invoke(
                BuildTaskMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, listItem.Instance, list.Instance, dateformat, userType, dTableTeam, hashTable });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void BuildTask_DateTimeTypeCase0Format_ReturnsString()
        {
            // Arrange
            const string dateformat = "0";
            const int userType = 1;

            var input = now;
            var outputValue = now.ToString();
            var expected = $"<Field Name=\"{InternalNameString}\"><![CDATA[{outputValue}]]></Field>";

            var hashTable = new Hashtable();
            spField.TypeGet = () => SPFieldType.DateTime;

            listItem.ItemGetGuid = _ => input;

            // Act
            var actual = (string)privateObj.Invoke(
                BuildTaskMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, listItem.Instance, list.Instance, dateformat, userType, dTableTeam, hashTable });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void BuildTask_DateTimeTypeSFormat_ReturnsString()
        {
            // Arrange
            const int userType = 1;

            var dateformat = string.Empty;
            var input = now;
            var outputValue = now.ToString("s");
            var expected = $"<Field Name=\"{InternalNameString}\"><![CDATA[{outputValue}]]></Field>";

            var hashTable = new Hashtable();
            spField.TypeGet = () => SPFieldType.DateTime;

            listItem.ItemGetGuid = _ => input;

            // Act
            var actual = (string)privateObj.Invoke(
                BuildTaskMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, listItem.Instance, list.Instance, dateformat, userType, dTableTeam, hashTable });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void BuildTask_DateTimeTypeCustomFormat_ReturnsString()
        {
            // Arrange
            const string dateformat = "yyyy-MM-dd HH:mm:ss";
            const int userType = 1;

            var input = now;
            var outputValue = now.ToString(dateformat);
            var expected = $"<Field Name=\"{InternalNameString}\"><![CDATA[{outputValue}]]></Field>";

            var hashTable = new Hashtable();
            spField.TypeGet = () => SPFieldType.DateTime;

            listItem.ItemGetGuid = _ => input;

            // Act
            var actual = (string)privateObj.Invoke(
                BuildTaskMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, listItem.Instance, list.Instance, dateformat, userType, dTableTeam, hashTable });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void BuildTask_BooleanTypeTrue_ReturnsString()
        {
            // Arrange
            const int userType = 1;

            var dateformat = string.Empty;
            var input = true;
            const string outputValue = "1";
            var expected = $"<Field Name=\"{InternalNameString}\"><![CDATA[{outputValue}]]></Field>";

            var hashTable = new Hashtable();
            spField.TypeGet = () => SPFieldType.Boolean;

            listItem.ItemGetGuid = _ => input;

            // Act
            var actual = (string)privateObj.Invoke(
                BuildTaskMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, listItem.Instance, list.Instance, dateformat, userType, dTableTeam, hashTable });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void BuildTask_BooleanTypeFalse_ReturnsString()
        {
            // Arrange
            const int userType = 1;

            var dateformat = string.Empty;
            var input = false;
            const string outputValue = "0";
            var expected = $"<Field Name=\"{InternalNameString}\"><![CDATA[{outputValue}]]></Field>";

            var hashTable = new Hashtable();
            spField.TypeGet = () => SPFieldType.Boolean;

            listItem.ItemGetGuid = _ => input;

            // Act
            var actual = (string)privateObj.Invoke(
                BuildTaskMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, listItem.Instance, list.Instance, dateformat, userType, dTableTeam, hashTable });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void BuildTask_UserType0_ReturnsString()
        {
            // Arrange
            const int userType = 0;

            var dateformat = string.Empty;
            var input = GetStringOutput;
            var outputValue = $",{GetStringOutput}";
            var expected = $"<Field Name=\"{InternalNameString}\"><![CDATA[{outputValue}]]></Field>";

            var hashTable = new Hashtable();
            spField.TypeGet = () => SPFieldType.User;

            listItem.ItemGetGuid = _ => input;

            // Act
            var actual = (string)privateObj.Invoke(
                BuildTaskMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, listItem.Instance, list.Instance, dateformat, userType, dTableTeam, hashTable });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void BuildTask_UserType1_ReturnsString()
        {
            // Arrange
            const int userType = 1;

            var dateformat = string.Empty;
            var input = GetStringOutput;
            var outputValue = $",{1}";
            var expected = $"<Field Name=\"{InternalNameString}\"><![CDATA[{outputValue}]]></Field>";

            var hashTable = new Hashtable();
            spField.TypeGet = () => SPFieldType.User;

            listItem.ItemGetGuid = _ => input;

            // Act
            var actual = (string)privateObj.Invoke(
                BuildTaskMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, listItem.Instance, list.Instance, dateformat, userType, dTableTeam, hashTable });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void BuildTask_UserType2_ReturnsString()
        {
            // Arrange
            const int userType = 2;

            var dateformat = string.Empty;
            var input = GetStringOutput;
            var outputValue = $",{GetStringOutput}";
            var expected = $"<Field Name=\"{InternalNameString}\"><![CDATA[{outputValue}]]></Field>";

            var hashTable = new Hashtable();
            spField.TypeGet = () => SPFieldType.User;

            listItem.ItemGetGuid = _ => input;

            // Act
            var actual = (string)privateObj.Invoke(
                BuildTaskMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, listItem.Instance, list.Instance, dateformat, userType, dTableTeam, hashTable });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void BuildTask_UserType3_ReturnsString()
        {
            // Arrange
            const int userType = 3;

            var dateformat = string.Empty;
            var input = GetStringOutput;
            var outputValue = $"1";
            var expected = $"<Field Name=\"{InternalNameString}\"><![CDATA[{outputValue}]]></Field>";
            var hashTable = new Hashtable();
            hashTable.Add(InternalNameString, InternalNameString);

            spField.TypeGet = () => SPFieldType.User;

            listItem.ItemGetGuid = _ => input;

            // Act
            var actual = (string)privateObj.Invoke(
                BuildTaskMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, listItem.Instance, list.Instance, dateformat, userType, dTableTeam, hashTable });

            // Assert
            actual.ShouldBe(expected);
        }
    }
}
