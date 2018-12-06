using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Xml;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using TimeSheets;

namespace EPMLiveTimerService.Tests.WebPageCode
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetPmApprovalsTests
    {
        private IDisposable _shimsContext;
        private getpmapprovals _getpmapprovals;
        private PrivateObject _privateObject;
        private ShimSPWeb _spWeb;
        private ShimSPSite _spSite;
        private ShimSPFieldCollection _shimSPFieldCollection;
        private ShimSPList _shimSpList;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            _spWeb = new ShimSPWeb
            {
                CurrentUserGet = () => new ShimSPUser
                {
                    LoginNameGet = () => "LoginName"
                },
                SiteGet = () => new ShimSPSite
                {
                    WebApplicationGet = () =>
                    {
                        var shim = new ShimSPWebApplication();
                        new ShimSPPersistedObject(shim)
                        {
                            IdGet = () => Guid.Empty
                        };
                        return shim;
                    }
                }
            };
            _shimSPFieldCollection = new ShimSPFieldCollection
            {
                ItemGetGuid = guid => new ShimSPField
                {
                    GetFieldValueString = stringValue => "[today]",
                    TypeGet = () => SPFieldType.DateTime
                },
                GetFieldByInternalNameString = stringValue => new ShimSPField
                {
                    TypeGet = () => SPFieldType.Calculated,
                    SchemaXmlGet = () => "<Default></Default>"
                }
            };
            _spSite = new ShimSPSite
            {
                RootWebGet = () => _spWeb,
                OpenWebGuid = guid => new ShimSPWeb
                {
                    IDGet = () => guid,
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetGuid = guidValue => new ShimSPList
                        {
                            IDGet = () => guid,
                            GetItemByIdInt32 = intValue => new ShimSPListItem
                            {
                                FieldsGet = () => _shimSPFieldCollection
                            },
                            FieldsGet = () => _shimSPFieldCollection
                        }
                    }
                }
            };
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                SiteGet = () => _spSite,
                WebGet = () => _spWeb
            };
            var shimSpView = new ShimSPView
            {
                ViewFieldsGet = () => new ShimSPViewFieldCollection()
                {
                    CountGet = () => 1
                }
            };
            _shimSpList = new ShimSPList
            {
                FieldsGet = () => _shimSPFieldCollection
            };
            _getpmapprovals = new getpmapprovals();
            _privateObject = new PrivateObject(_getpmapprovals);
            _privateObject.SetFieldOrProperty("site", (SPSite)_spSite);
            _privateObject.SetFieldOrProperty("view", (SPView)shimSpView);
            _privateObject.SetFieldOrProperty("list", (SPList)_shimSpList);
             var dataSet = new DataSet();
            dataSet.Tables.Add(GetDataTable("TimesheetMeta"));
            _privateObject.SetFieldOrProperty("dsTimesheetMeta", dataSet);
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void OutputXml_Always_SetExpectedValues()
        {
            // Arrange
            var xmlDocument = ArrangeForOutputXml(bool.TrueString);
            ArrangeSqlConnection();

            // Act
            _privateObject.Invoke("outputXml");

            // Assert
            this.ShouldSatisfyAllConditions(
                () => ((bool)_privateObject.GetFieldOrProperty("usecurrent")).ShouldBeFalse(),
                () => xmlDocument.InnerXml.ShouldBe(
                    Properties.Resources.OutputXmlAlwaysSetExpectedValuesExpectedXml));
        }

        [TestMethod]
        public void OutputXml_Always_WithTimeEditorFalseSetExpectedValues()
        {
            // Arrange
            var xmlDocument = ArrangeForOutputXml(bool.FalseString);
            ArrangeSqlConnection(false);

            // Act
            _privateObject.Invoke("outputXml");

            // Assert
            this.ShouldSatisfyAllConditions(
                () => ((bool)_privateObject.GetFieldOrProperty("usecurrent")).ShouldBeFalse(),
                () => xmlDocument.InnerXml.ShouldBe(
                    Properties.Resources.OutputXmlAlwaysWithTimeEditorFalseSetExpectedValuesExpectedXml));
        }

        [TestMethod]
        public void OutputXml_Always_WithoutUserDataSetExpectedValues()
        {
            // Arrange
            var xmlDocument = ArrangeForOutputXml(bool.FalseString);
            xmlDocument.LoadXml(xmlDocument.InnerXml.Replace(@"<userdata name=""listid""></userdata>", string.Empty));
            ArrangeSqlConnection(false);

            // Act
            _privateObject.Invoke("outputXml");

            // Assert
            this.ShouldSatisfyAllConditions(
                () => ((bool)_privateObject.GetFieldOrProperty("usecurrent")).ShouldBeFalse(),
                () => xmlDocument.InnerXml.ShouldBe(
                    Properties.Resources.OutputXmlAlwaysWithoutUserDataSetExpectedValuesExpectedXml));
        }

        [TestMethod]
        public void PopulateGroups_Always_SetExpectedValues()
        {
            // Arrange
            const string query = "query";
            var sortedList = new SortedList();
            _spWeb.GetSiteDataSPSiteDataQuery = spSiteDataQuery => new DataTable()
            {
                Columns = { "Title", "ListId" },
                Rows = { new object[] { "Title", "ListId" } }
            };
            ArrangeSqlConnection();
            ShimCoreFunctions.getConfigSettingSPWebString = (spWeb, stringKey) => string.Empty;
            var guid = new Guid("cc9437eb-a8d5-4c49-90db-e7d39824fe6f");
            ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSet) =>
            {
                dataSet.Tables.Add(new DataTable("DataTable1")
                {
                    Columns =
                    {
                        "guid1",
                        "guid2",
                        "intValue",
                        "title",
                        "list_uid",
                        "project"
                    },
                    Rows =
                    {
                        new object[]
                        {
                            guid,
                            guid,
                            "10",
                            "Title",
                            "ListId",
                            "project"
                        },
                        new object[]
                        {
                            Guid.Empty,
                            Guid.Empty,
                            "10",
                            "Title",
                            "ListId",
                            "project"
                        }
                    }
                });
                return 0;
            };
            _privateObject.SetFieldOrProperty("arrGroupFields", new string[] { "" });
            _shimSPFieldCollection.GetFieldByInternalNameString = stringValue => new ShimSPField()
            {
                TypeGet = () => SPFieldType.DateTime,
                SchemaXmlGet = () => "<Default></Default>"
            };
            _shimSPFieldCollection.ItemGetGuid = guidValue => new ShimSPField
            {
                GetFieldValueString = stringValue => "[today]",
                TypeGet = () => SPFieldType.DateTime
            };

            // Act
            _getpmapprovals.populateGroups(
                query,
                sortedList,
                _spWeb);

            // Assert
            var datasetTimesheetTasks = _privateObject.GetFieldOrProperty("dsTimesheetTasks") as DataSet;
            this.ShouldSatisfyAllConditions(
                () => datasetTimesheetTasks.ShouldNotBeNull(),
                () => datasetTimesheetTasks.Tables.Count.ShouldBe(1),
                () => datasetTimesheetTasks.Tables[0].Columns.Count.ShouldBe(6),
                () => datasetTimesheetTasks.Tables[0].Rows.Count.ShouldBe(2));
        }

        private XmlDocument ArrangeForOutputXml(string allowNotes)
        {
            ShimPage.AllInstances.RequestGet = instance => new ShimHttpRequest
            {
                ItemGetString = stringValue => "100"
            };
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(@"
<head>
    <beforeInit>
        <call command=""attachHeader"">
            <child></child>
        </call>
    </beforeInit>
    <column id=""culumnId1"" width=""100"" type=""type""></column>
    <settings></settings>
    <row id=""100000000000000001.100000000000000001.100000000000000001.100000000000000001.100000000000000001.100000000000000001"">
        <userdata name=""listid""></userdata>
        <userdata name=""itemid""></userdata>
        <userdata name=""Work""></userdata>
        <cell>culumnId1</cell>
    </row>
</head>");
            _privateObject.SetFieldOrProperty("docXml", xmlDocument);
            var dictionary = new Dictionary<string, string>
            {
                ["EPMLiveTSUseCurrent"] = bool.FalseString,
                ["EPMLiveTSAllowNotes"] = allowNotes,
                ["EPMLiveDaySettings"] = string.Format(
                    "{0}|{1}|{2}|{3}",
                    bool.TrueString,
                    bool.TrueString,
                    bool.TrueString,
                    bool.TrueString),
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (spWeb, stringKey) => dictionary[stringKey];
            ShimCoreFunctions.getConnectionStringGuid = (guidValue) => "connectionString";
            
            return xmlDocument;
        }

        private void ArrangeSqlConnection(bool configureRead = true)
        {
            ShimSqlConnection.ConstructorString = (instance, connectionString) => new ShimSqlConnection(instance)
            {
                Open = () => { },
                DisposeBoolean = boolValue => { }
            };
            var listInt = new List<int>
            {
                10,
                11,
                0
            };
            var listDateTime = new List<DateTime>
            {
                new DateTime(2018, 6, 11),
                new DateTime(2018, 6, 12)
            };
            IEnumerator enumerator = listInt.GetEnumerator();
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                var shim = new ShimSqlDataReader()
                {
                    Read = () =>
                    {
                        if (!configureRead)
                        {
                            configureRead = true;
                            return false;
                        }
                        return enumerator.MoveNext();
                    },
                    GetInt32Int32 = intIndex => listInt[intIndex],
                    GetDateTimeInt32 = intIndex => listDateTime[intIndex],
                    GetBooleanInt32 = intIndex => true
                };
                new ShimDbDataReader(shim)
                {
                    Dispose = () =>
                    {
                        enumerator = listDateTime.GetEnumerator();
                    }
                };
                return shim;
            };
            ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSet) =>
            {
                dataSet.Tables.Add(GetDataTable("DataTable1"));
                dataSet.Tables.Add(GetDataTable("DataTable2"));
                return 0;
            };
        }

        private DataTable GetDataTable(string dataTableName)
        {
            return new DataTable(dataTableName)
            {
                Columns =
                {
                    "TS_ITEM_HOURS",
                    "ts_item_uid",
                    "TS_ITEM_DATE",
                    "tstype_id",
                    "columnname",
                    "columnvalue",
                    "TS_ITEM_NOTES",
                    "title",
                    "list_uid",
                    "project"
                },
                Rows =
                {
                    new object[]
                    {
                        "10",
                        "00000000-0000-0000-0000-000000000000",
                        "06/11/2018",
                        "10",
                        "culumnId1",
                        "columnvalue.gif",
                        "TS_ITEM_NOTES",
                        "Title",
                        "ListId",
                        "project"
                    }
                }
            };
        }
    }
}
