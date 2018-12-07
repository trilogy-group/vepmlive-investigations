using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Xml;
using EPMLiveCore.Fakes;
using EPMLiveWebParts.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.WebPageCode
{
    public partial class GetGanttTasksTests
    {
        [TestMethod]
        public void AddGroups_NullRollupLists_ProcessesList()
        {
            // Arrange
            PrepareForAddGroups(false);
            
            var didProcessList = false;
            Shimgetgantttasks.AllInstances.processListSPWebStringSPListSortedList =
                (a, b, c, d, e) => didProcessList = true;

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddGroups, new object[]
            {
                new XmlDocument(),
                new ShimSPWeb().Instance,
                "query",
                new SortedList()
            });

            // Assert
            didProcessList.ShouldBeTrue();
        }

        [TestMethod]
        public void AddGroups_NotNullRollupListsNoData_ProcessesList()
        {
            // Arrange
            var didProcessList = false;
            PrepareForAddGroups(true);
            _getGanttTasksPrivate.SetField(FieldRollupLists, new string[] { DummyListId });
            Shimgetgantttasks.AllInstances.processListSPWebStringSPListSortedList =
                (a, b, c, d, e) => didProcessList = true;
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString =
                (a, b, c, d, e) => new DataTable();

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddGroups, new object[]
            {
                new XmlDocument(),
                new ShimSPWeb().Instance,
                "query",
                new SortedList()
            });

            // Assert
            didProcessList.ShouldBeTrue();
        }

        [TestMethod]
        public void AddGroups_NotNullRollupListsProcessError_WritesGlobalError()
        {
            // Arrange
            PrepareForAddGroups(true);
            _getGanttTasksPrivate.SetField(FieldRollupLists, new string[] { DummyListId });
            Shimgetgantttasks.AllInstances.processListSPWebStringSPListSortedList =
                (a, b, c, d, e) => { throw new InvalidOperationException(DefaultErrorMessage); };
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString =
                (a, b, c, d, e) => new DataTable();
            ShimSPWeb.AllInstances.WebsGet = _ => { throw new InvalidOperationException(DefaultErrorMessage); };

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddGroups, new object[]
            {
                new XmlDocument(),
                new ShimSPWeb().Instance,
                "query",
                new SortedList()
            });

            // Assert
            var globalError = _getGanttTasksPrivate.GetField(FieldGlobalError);
            globalError.ShouldNotBeNull();
            globalError.ShouldBe(DefaultErrorMessage);
        }

        [TestMethod]
        public void AddGroups_NotUseReportingNullRollupLists_ProcessesList()
        {
            // Arrange
            var didProcessList = false;
            PrepareForAddGroups(false);
            Shimgetgantttasks.AllInstances.processListSPWebStringSPListSortedList =
                (a, b, c, d, e) => didProcessList = true;

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddGroups, new object[]
            {
                new XmlDocument(),
                new ShimSPWeb().Instance,
                "query",
                new SortedList()
            });

            // Assert
            didProcessList.ShouldBeTrue();
        }

        [TestMethod]
        public void AddGroups_InEditMode_ProcessesListAndAddsItems()
        {
            // Arrange
            var didProcessList = false;
            var didAddOtherGroups = false;
            _getGanttTasksPrivate.SetField(FieldRollupLists, new string[] { DummyListId });
            PrepareForAddGroups(false);

            Shimgetgantttasks.AllInstances.processListSPWebStringSPListSortedList =
                (a, b, c, d, e) => didProcessList = true;

            var webs = new List<SPWeb> { new ShimSPWeb() };
            var websCollection = new ShimSPWebCollection();
            websCollection.Bind(webs.AsEnumerable());

            ShimSPWeb.AllInstances.WebsGet = _ =>
            {
                Shimgetgantttasks.AllInstances.addGroupsXmlDocumentSPWebStringSortedList =
                    (a, doc, b, c, d) =>
                    {
                        didAddOtherGroups = true;
                        return doc;
                    };

                return websCollection.Instance;
            };

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddGroups, new object[]
            {
                new XmlDocument(),
                new ShimSPWeb().Instance,
                "query",
                new SortedList()
            });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => didAddOtherGroups.ShouldBeTrue(),
                () => didProcessList.ShouldBeTrue());
        }

        [TestMethod]
        public void AddGroups_InEditModeAddError_DoesNotWriteGlobalError()
        {
            // Arrange
            _getGanttTasksPrivate.SetField(FieldRollupLists, new string[] { DummyListId });
            PrepareForAddGroups(false);

            Shimgetgantttasks.AllInstances.processListSPWebStringSPListSortedList =
                (a, b, c, d, e) => { throw new InvalidOperationException(DefaultErrorMessage); };

            ShimSPWeb.AllInstances.WebsGet = _ =>
            {
                Shimgetgantttasks.AllInstances.addGroupsXmlDocumentSPWebStringSortedList =
                    (a, b, c, d, e) => { throw new InvalidOperationException(DefaultErrorMessage); };

                var webs = new List<SPWeb>();
                var websCollection = new ShimSPWebCollection();
                websCollection.Bind(webs.AsEnumerable());
                return websCollection.Instance;
            };

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddGroups, new object[]
            {
                new XmlDocument(),
                new ShimSPWeb().Instance,
                "query",
                new SortedList()
            });

            // Assert
            var globalError = _getGanttTasksPrivate.GetField(FieldGlobalError);
            globalError.ShouldNotBeNull();
            globalError.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void AddGroups_InEditModeGetWebError_WritesGlobalError()
        {
            // Arrange
            _getGanttTasksPrivate.SetField(FieldRollupLists, new string[] { DummyListId });
            PrepareForAddGroups(false);

            Shimgetgantttasks.AllInstances.processListSPWebStringSPListSortedList =
                (a, b, c, d, e) => { throw new InvalidOperationException(DefaultErrorMessage); };

            ShimSPWeb.AllInstances.WebsGet = _ => { throw new InvalidOperationException(DefaultErrorMessage); };

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddGroups, new object[]
            {
                new XmlDocument(),
                new ShimSPWeb().Instance,
                "query",
                new SortedList()
            });

            // Assert
            var globalError = _getGanttTasksPrivate.GetField(FieldGlobalError);
            globalError.ShouldNotBeNull();
            globalError.ShouldBe(DefaultErrorMessage);
        }

        [TestMethod]
        public void AddGroups_InEditModeGetWebAccessError_WritesGlobalError()
        {
            // Arrange
            _getGanttTasksPrivate.SetField(FieldRollupLists, new string[] { DummyListId });
            PrepareForAddGroups(false);

            Shimgetgantttasks.AllInstances.processListSPWebStringSPListSortedList =
                (a, b, c, d, e) => { throw new InvalidOperationException(DefaultErrorMessage); };

            ShimSPWeb.AllInstances.WebsGet = _ => { throw new InvalidOperationException("Access is denied"); };
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions =
                (_, permission) =>
                {
                    switch (permission)
                    {
                        case SPBasePermissions.ViewPages:
                            return true;
                        default:
                            return false;
                    }
                };

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddGroups, new object[]
            {
                new XmlDocument(),
                new ShimSPWeb().Instance,
                "query",
                new SortedList()
            });

            // Assert
            var globalError = _getGanttTasksPrivate.GetField(FieldGlobalError);
            globalError.ShouldNotBeNull();
            globalError.ShouldBe("Although some data may have been returned, access was denied to some data due to incorrect security configuration. Visit <a href=\"http://kb.epmlive.com/KnowledgebaseArticle50056.aspx\">Our Knowledge Base</a> for more information.");
        }

        [TestMethod]
        public void AddGroups_NotInEditMode_ProcessesList()
        {
            // Arrange
            _getGanttTasksPrivate.SetField(FieldRollupLists, new string[] { DummyListId });
            _getGanttTasksPrivate.SetField(FieldUsePerformance, true);
            var itemsKey = $"{DefaultWebId}.{DefaultListId}.{DefaultId}";
            PrepareForAddGroups(false);
            var arrGTemp = new SortedList();

            // Act
            var result = _getGanttTasksPrivate.Invoke(MethodAddGroups, new object[]
            {
                new XmlDocument(),
                new ShimSPWeb().Instance,
                "query",
                arrGTemp
            });

            // Assert
            result.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeOfType<XmlDocument>(),
                () =>
                {
                    arrGTemp.ContainsKey(DummyVal).ShouldBeTrue();
                    arrGTemp[DummyVal].ShouldBe(string.Empty);
                },
                () =>
                {
                    var arrItems = _getGanttTasksPrivate.GetField("arrItems") as SortedList;
                    arrItems.ShouldNotBeNull();
                    arrItems.ContainsKey(itemsKey);
                },
                () =>
                {
                    var queueAllItems = _getGanttTasksPrivate.GetField("queueAllItems") as Queue;
                    queueAllItems.Count.ShouldBe(1);
                });
        }

        [TestMethod]
        public void AddGroups_NotInEditModeError_WritesGlobalError()
        {
            // Arrange
            _getGanttTasksPrivate.SetField(FieldRollupLists, new string[] { DummyListId });
            _getGanttTasksPrivate.SetField(FieldUsePerformance, true);
            PrepareForAddGroups(false);
            _getGanttTasksPrivate.SetField(FieldFilterField, string.Empty);
            ShimSqlCommand.AllInstances.ExecuteReader =
                _ => { throw new InvalidOperationException(DefaultErrorMessage); };

            // Act
            _getGanttTasksPrivate.Invoke(MethodAddGroups, new object[]
            {
                new XmlDocument(),
                new ShimSPWeb().Instance,
                "query",
                new SortedList()
            });

            // Assert
            var globalError = _getGanttTasksPrivate.GetField(FieldGlobalError);
            globalError.ShouldNotBeNull();
            globalError.ShouldBe(string.Empty);
        }

        private XmlDocument PrepareForAddGroups(bool useReporting)
        {
            _getGanttTasksPrivate.SetField("arrGroupFields", new string[] { "Group" });
            _getGanttTasksPrivate.SetField(FieldFilterField, DummyFieldName);
            _getGanttTasksPrivate.SetField("filtervalue", DummyVal);
            _getGanttTasksPrivate.SetField("list", new ShimSPList().Instance);
            _getGanttTasksPrivate.SetField("view", new ShimSPView().Instance);

            _getGanttTasksPrivate.SetField("start", "start");
            _getGanttTasksPrivate.SetField("finish", "finish");
            _getGanttTasksPrivate.SetField("progress", "progress");
            _getGanttTasksPrivate.SetField("wbsfield", "wbsfield");
            _getGanttTasksPrivate.SetField("milestone", "milestone");
            _getGanttTasksPrivate.SetField("information", "information");

            Shimgetgantttasks.AllInstances.formatFieldStringStringDataRowBoolean = (a, val, b, c, d) => val;

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml("<root><afterInit></afterInit></root>");

            ShimReportingData.GetReportQuerySPWebSPListStringStringOut =
                (SPWeb a, SPList b, string c, out string orderby) =>
                {
                    orderby = DummyFieldName;
                    return DummyVal;
                };

            var views = new List<string> { WorkspaceUrlView };
            var viewsCollection = new ShimSPViewFieldCollection();
            viewsCollection.Bind(views);
            ShimSPView.AllInstances.ViewFieldsGet = _ => viewsCollection;

            PrepareSpListRelatedShims();
            PrepareSpWebRelatedShims();
            PrepareSpFieldRelatedShims(DummyText, SPFieldType.User);
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, __) => true;

            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.ContentDatabaseGet = _ => new ShimSPContentDatabase();
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => "/server";
            ShimSPWeb.AllInstances.GetSiteDataSPSiteDataQuery = (_, __) => GetProcessData();
            ShimSPDatabase.AllInstances.DatabaseConnectionStringGet = _ => DummyText;
            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ =>
            {
                ShimSqlConnection.AllInstances.StateGet = __ => ConnectionState.Open;
            };
            ShimSqlConnection.AllInstances.Close = _ =>
            {
                ShimSqlConnection.AllInstances.StateGet = __ => ConnectionState.Closed;
            };

            var didRead = false;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () =>
                {
                    var read = didRead;
                    didRead = true;
                    return read;
                }
            };

            return xmlDocument;
        }

        private DataTable GetProcessData()
        {
            var columns = new string[]
            {
                DummyFieldName, "User", "UserText", "Admin", "AdminText", "Group", "WebID", "ListID", "ID"
            };
            var row = new object[]
            {
                DummyVal, DummyVal, DummyVal, DummyVal, DummyVal, DummyVal, DefaultWebId, DefaultListId, DefaultId
            };

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(columns.Select(x => new DataColumn(x)).ToArray());
            dataTable.LoadDataRow(row, true);

            var set = new DataSet();
            set.Tables.Add(dataTable);

            return dataTable;
        }
    }
}
