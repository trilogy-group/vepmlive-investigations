using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Linq.Fakes;
using System.Xml.Serialization;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveCore.ReportingProxy.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API.MyWork
{
    public partial class MyWorkRemTests
    {
        private const string GetMyWorkFieldValueMethodName = "GetMyWorkFieldValue";
        private const string GetMyWorkGridViewMethodName = "GetMyWorkGridView";
        private const string GetMyWorkItemElementMethodName = "GetMyWorkItemElement";
        private const string GetMyWorkListIdsFromDbMethodName = "GetMyWorkListIdsFromDb";
        private const string GetPersonalViewsMethodName = "GetPersonalViews";
        private const string GetQueryMethodName = "GetQuery";
        private const string GetWorkingOnMethodName = "GetWorkingOn";
        private const string GetWorkspaceNameFromDbMethodName = "GetWorkspaceNameFromDb";
        private const string MapCompleteFieldMethodName = "MapCompleteField";
        private const string ProcessMyWorkMethodName = "ProcessMyWork";
        private const string QueryMyWorkDataMethodName = "QueryMyWorkData";
        private const string RenameGlobalViewMethodName = "RenameGlobalView";
        private const string RenamePersonalViewMethodName = "RenamePersonalView";
        private const string SavePersonalViewsMethodName = "SavePersonalViews";
        private const string TagSiteIdExistsMethodName = "TagSiteIdExists";
        private const string CheckListEditPermissionMethodName = "CheckListEditPermission";
        private const string DeleteMyWorkGridViewMethodName = "DeleteMyWorkGridView";
        private const string GetMyWorkMethodName = "GetMyWork";
        private const string ValueColumn = "Value";
        private const string SharePointTypeColumn = "SharePointType";
        private const string ColColumn = "Col";
        private const string MyWorkGridViewXml = @"
            <MyWork>
                <View ID=""ID"" Name=""Name"" Default=""True""
                      Personal=""True"" LeftCols=""LeftCols""
                      Cols=""Cols"" RightCols=""RightCols""
                      Filters=""Filters"" Grouping=""Grouping""
                      Sorting=""Sorting"" HasPermission=""True""></View>
              </MyWork>";

        private void SetupShimsSplitTwo()
        {
            ShimQueryExecutor.ConstructorSPWeb = (_, __) => new ShimQueryExecutor();
            ShimSPSite.ConstructorString = (_, __) => new ShimSPSite();
            ShimUtils.CleanGuidObject = _ => guid.ToString();
            ShimUtils.GetConfigWeb = () => spWeb;
            ShimSPSite.AllInstances.OpenWeb = _ => spWeb;
        }

        [TestMethod]
        public void GetMyWorkFieldValue_FieldFlag_ReturnsObject()
        {
            // Arrange
            const string myWorkField = "flag";

            var row = default(DataRow);
            var myWorkDataRow = default(DataRow);
            var columnDictionary = new Dictionary<string, int>()
            {
                [myWorkField] = 1
            };

            var dataTable = new DataTable();
            dataTable.Columns.Add(ListIdColumn);
            dataTable.Columns.Add(ItemIdColumn);
            myWorkDataRow = dataTable.NewRow();
            myWorkDataRow[ListIdColumn] = DummyString;
            myWorkDataRow[ItemIdColumn] = DummyString;

            var flagsTable = new DataTable();
            flagsTable.Columns.Add(ListIdColumn);
            flagsTable.Columns.Add(ItemIdColumn);
            flagsTable.Columns.Add(ValueColumn);
            row = flagsTable.NewRow();
            row[ListIdColumn] = DummyString;
            row[ItemIdColumn] = DummyString;
            row[ValueColumn] = null;
            flagsTable.Rows.Add(row);
            flagsTable.PrimaryKey = new[] { flagsTable.Columns[ListIdColumn], flagsTable.Columns[ItemIdColumn] };

            // Act
            var actual = privateObj.Invoke(
                GetMyWorkFieldValueMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { myWorkField, myWorkDataRow, columnDictionary, null, flagsTable });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.GetType().ShouldBe(typeof(int)),
                () => ((int)actual).ShouldBe(0));
        }

        [TestMethod]
        public void GetMyWorkFieldValue_ColInfo1_ReturnsObject()
        {
            // Arrange
            const string myWorkField = "someField";
            const string spType = "User";

            var idField = $"{myWorkField}ID";
            var textField = $"{myWorkField}Text";
            var row = default(DataRow);
            var myWorkDataRow = default(DataRow);
            var fieldsTableRows = default(EnumerableRowCollection<DataRow>);
            var columnDictionary = new Dictionary<string, int>()
            {
                [myWorkField] = 1
            };

            var dataTable = new DataTable();
            dataTable.Columns.Add(ListIdColumn);
            dataTable.Columns.Add(myWorkField);
            dataTable.Columns.Add(idField);
            dataTable.Columns.Add(textField);
            myWorkDataRow = dataTable.NewRow();
            myWorkDataRow[ListIdColumn] = guid.ToString();
            myWorkDataRow[myWorkField] = myWorkField;
            myWorkDataRow[idField] = null;
            myWorkDataRow[textField] = null;

            var flagsTable = new DataTable();
            var fieldsTable = new DataTable();
            fieldsTable.Columns.Add(ListIdColumn, typeof(Guid));
            fieldsTable.Columns.Add(InternalNameColumn, typeof(string));
            fieldsTable.Columns.Add(SharePointTypeColumn, typeof(string));
            row = fieldsTable.NewRow();
            row[ListIdColumn] = guid.ToString();
            row[InternalNameColumn] = myWorkField;
            row[SharePointTypeColumn] = spType;
            fieldsTable.Rows.Add(row);
            fieldsTableRows = fieldsTable.AsEnumerable();

            // Act
            var actual = privateObj.Invoke(
                GetMyWorkFieldValueMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { myWorkField, myWorkDataRow, columnDictionary, fieldsTableRows, flagsTable });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.GetType().ShouldBe(typeof(string)),
                () => ((string)actual).ShouldBe(myWorkField));
        }

        [TestMethod]
        public void GetMyWorkFieldValue_ColInfo2IdFieldNull_ReturnsObject()
        {
            // Arrange
            const string myWorkField = "someField";
            const string spType = "User";

            var idField = $"{myWorkField}ID";
            var textField = $"{myWorkField}Text";
            var row = default(DataRow);
            var myWorkDataRow = default(DataRow);
            var fieldsTableRows = default(EnumerableRowCollection<DataRow>);
            var columnDictionary = new Dictionary<string, int>()
            {
                [myWorkField] = 2
            };

            var dataTable = new DataTable();
            dataTable.Columns.Add(ListIdColumn);
            dataTable.Columns.Add(myWorkField);
            dataTable.Columns.Add(idField);
            dataTable.Columns.Add(textField);
            myWorkDataRow = dataTable.NewRow();
            myWorkDataRow[ListIdColumn] = guid.ToString();
            myWorkDataRow[myWorkField] = myWorkField;
            myWorkDataRow[idField] = null;
            myWorkDataRow[textField] = null;

            var flagsTable = new DataTable();
            var fieldsTable = new DataTable();
            fieldsTable.Columns.Add(ListIdColumn, typeof(Guid));
            fieldsTable.Columns.Add(InternalNameColumn, typeof(string));
            fieldsTable.Columns.Add(SharePointTypeColumn, typeof(string));
            row = fieldsTable.NewRow();
            row[ListIdColumn] = guid.ToString();
            row[InternalNameColumn] = myWorkField;
            row[SharePointTypeColumn] = spType;
            fieldsTable.Rows.Add(row);
            fieldsTableRows = fieldsTable.AsEnumerable();

            // Act
            var actual = privateObj.Invoke(
                GetMyWorkFieldValueMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { myWorkField, myWorkDataRow, columnDictionary, fieldsTableRows, flagsTable });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.GetType().ShouldBe(typeof(string)),
                () => ((string)actual).ShouldBe(string.Empty));
        }

        [TestMethod]
        public void GetMyWorkFieldValue_ColInfo2IdFieldNotNull_ReturnsObject()
        {
            // Arrange
            const string myWorkField = "someField";
            const string spType = "User";
            const string idFieldValue = "1,2";
            const string textFieldValue = "one,two";
            const string expected = "1;#one;#2;#two";

            var idField = $"{myWorkField}ID";
            var textField = $"{myWorkField}Text";
            var row = default(DataRow);
            var myWorkDataRow = default(DataRow);
            var fieldsTableRows = default(EnumerableRowCollection<DataRow>);
            var columnDictionary = new Dictionary<string, int>()
            {
                [myWorkField] = 2
            };

            var dataTable = new DataTable();
            dataTable.Columns.Add(ListIdColumn);
            dataTable.Columns.Add(myWorkField);
            dataTable.Columns.Add(idField);
            dataTable.Columns.Add(textField);
            myWorkDataRow = dataTable.NewRow();
            myWorkDataRow[ListIdColumn] = guid.ToString();
            myWorkDataRow[myWorkField] = myWorkField;
            myWorkDataRow[idField] = idFieldValue;
            myWorkDataRow[textField] = textFieldValue;

            var flagsTable = new DataTable();
            var fieldsTable = new DataTable();
            fieldsTable.Columns.Add(ListIdColumn, typeof(Guid));
            fieldsTable.Columns.Add(InternalNameColumn, typeof(string));
            fieldsTable.Columns.Add(SharePointTypeColumn, typeof(string));
            row = fieldsTable.NewRow();
            row[ListIdColumn] = guid.ToString();
            row[InternalNameColumn] = myWorkField;
            row[SharePointTypeColumn] = spType;
            fieldsTable.Rows.Add(row);
            fieldsTableRows = fieldsTable.AsEnumerable();

            // Act
            var actual = privateObj.Invoke(
                GetMyWorkFieldValueMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { myWorkField, myWorkDataRow, columnDictionary, fieldsTableRows, flagsTable });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.GetType().ShouldBe(typeof(string)),
                () => ((string)actual).ShouldBe(expected));
        }

        [TestMethod]
        public void GetMyWorkGridView_WhenCalled_ReturnsMyWorkGridView()
        {
            // Arrange
            var xDocument = XDocument.Parse(MyWorkGridViewXml);

            // Act
            var actual = (MyWorkGridView)privateObj.Invoke(
                GetMyWorkGridViewMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { xDocument });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Name.ShouldBe("Name"),
                () => actual.LeftCols.ShouldBe("LeftCols"),
                () => actual.RightCols.ShouldBe("RightCols"),
                () => actual.Sorting.ShouldBe("Sorting"),
                () => actual.Default.ShouldBeTrue(),
                () => actual.Personal.ShouldBeTrue(),
                () => actual.HasPermission.ShouldBeTrue());
        }

        [TestMethod]
        public void GetMyWorkItemElement_WhenCalled_ReturnsMyWorkItem()
        {
            // Arrange
            const string expected = "MyWorkItem";
            var data = string.Format(@"<{0} name=""{0}"">{0}</{0}>", expected);

            // Act
            var actual = (XElement)privateObj.Invoke(
                GetMyWorkItemElementMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { data });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Name.LocalName.ShouldBe(expected),
                () => actual.Value.ShouldBe(expected),
                () => actual.Attribute("name").Value.ShouldBe(expected));
        }

        [TestMethod]
        public void GetMyWorkListIdsFromDb_WhenCalled_ReturnsGuidList()
        {
            // Arrange
            const int expectedCount = 5;

            var readCount = 0;
            var archivedWebs = new List<Guid>()
            {
                guid
            };
            var selectedListIds = new List<string>()
            {
                DummyString
            };

            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                readCount = readCount + 1;
                return readCount <= expectedCount;
            };
            ShimSqlDataReader.AllInstances.GetGuidInt32 = (_, __) => guid;

            // Act
            var actual = (List<Guid>)privateObj.Invoke(
                GetMyWorkListIdsFromDbMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spWeb.Instance, archivedWebs, selectedListIds });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(expectedCount),
                () => actual[0].ToString().ShouldBe(guid.ToString()),
                () => actual[2].ToString().ShouldBe(guid.ToString()),
                () => actual[4].ToString().ShouldBe(guid.ToString()));
        }

        [TestMethod]
        public void GetPersonalViews_WhenCalled_ReturnsMyWorkGridViewList()
        {
            // Arrange
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>")
                .Append("<ArrayOfMyWorkGridView>")
                .Append("<MyWorkGridView>")
                .Append("<Cols>Cols</Cols>")
                .Append("<Default>true</Default>")
                .Append("<Filters>Filters</Filters>")
                .Append("<Grouping>Grouping</Grouping>")
                .Append("<Id>Id</Id>")
                .Append("<LeftCols>LeftCols</LeftCols>")
                .Append("<Name>Name</Name>")
                .Append("<Personal>true</Personal>")
                .Append("<RightCols>RightCols</RightCols>")
                .Append("<Sorting>Sorting</Sorting>")
                .Append("<HasPermission>true</HasPermission>")
                .Append("</MyWorkGridView>")
                .Append("<MyWorkGridView>")
                .Append("<Cols>Cols</Cols>")
                .Append("<Default>true</Default>")
                .Append("<Filters>Filters</Filters>")
                .Append("<Grouping>Grouping</Grouping>")
                .Append("<Id>Id</Id>")
                .Append("<LeftCols>LeftCols</LeftCols>")
                .Append("<Name>Name</Name>")
                .Append("<Personal>true</Personal>")
                .Append("<RightCols>RightCols</RightCols>")
                .Append("<Sorting>Sorting</Sorting>")
                .Append("<HasPermission>false</HasPermission>")
                .Append("</MyWorkGridView>")
                .Append("</ArrayOfMyWorkGridView>");

            ShimSqlCommand.AllInstances.ExecuteScalar = _ => stringBuilder.ToString();

            // Act
            var actual = (List<MyWorkGridView>)privateObj.Invoke(
                GetPersonalViewsMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldNotBeNull(),
                () => actual.ShouldNotBeEmpty(),
                () => actual.Count.ShouldBe(2),
                () => actual[0].HasPermission.ShouldBeTrue(),
                () => actual[1].HasPermission.ShouldBeFalse());
        }

        [TestMethod]
        public void GetQuery_EmptyData_ReturnsEmptyString()
        {
            // Arrange and Act
            var actual = (string)privateObj.Invoke(
                GetQueryMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { string.Empty });

            // Assert
            actual.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void GetQuery_NonEmptyData_ReturnsQueryString()
        {
            // Arrange
            const string expected = "where condition";

            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<MyWork>")
                .Append("<Query>")
                .Append("<Where>")
                .Append(expected)
                .Append("</Where>")
                .Append("</Query>")
                .Append("</MyWork>");

            // Act
            var actual = (string)privateObj.Invoke(
                GetQueryMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { stringBuilder.ToString() });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetWorkingOn_WhenCalled_ReturnsDataTable()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable.Columns.Add(ListIdColumn);
            var row = dataTable.NewRow();
            row[ListIdColumn] = GuidString;
            dataTable.Rows.Add(row);

            ShimQueryExecutor.AllInstances.ExecuteEpmLiveQueryStringIDictionaryOfStringObject = (_, _1, _2) => dataTable;

            // Act
            var actual = (DataTable)privateObj.Invoke(
                GetWorkingOnMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Rows.Count.ShouldBe(1),
                () => actual.Rows[0][ListIdColumn].ShouldBe(GuidString));
        }

        [TestMethod]
        public void GetWorkspaceNameFromDb_WhenCalled_ReturnsString()
        {
            // Arrange
            const string expected = "workspaceName";

            ShimSqlCommand.AllInstances.ExecuteScalar = _ => expected;

            // Act
            var actual = (string)privateObj.Invoke(
                GetWorkspaceNameFromDbMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { guid, string.Empty });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void MapCompleteField_WhenCalled_SetsConfigSetting()
        {
            // Arrange
            const string expectedKey = "EPMLive_MyWork_CompleteFieldAdded";
            SerializedGlobalViews = false.ToString();

            var dataTable = new DataTable();
            dataTable.Columns.Add(ListIdColumn, typeof(Guid));
            dataTable.Columns.Add(ColColumn);
            var row = dataTable.NewRow();
            row[ListIdColumn] = guid;
            row[ColColumn] = "NotComplete";
            dataTable.Rows.Add(row);

            var myWorkReportData = new ShimMyWorkReportData()
            {
                ExecuteSqlString = _ => dataTable
            };
            var actual = false;
            var actualKey = string.Empty;
            var actualValue = string.Empty;

            ShimCoreFunctions.setConfigSettingSPWebStringString = (_, key, value) =>
            {
                actual = true;
                actualKey = key;
                actualValue = value;
            };
            ShimReportData.AllInstances.InsertListColumnsGuidListOfColumnDef = (_, _1, _2) => true;
            ShimReportData.AllInstances.AddColumnsStringListOfColumnDef = (_, _1, _2) => true;

            // Act
            privateObj.Invoke(
                MapCompleteFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spWeb.Instance, myWorkReportData.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => actualKey.ShouldBe(expectedKey),
                () => actualValue.ShouldBe(true.ToString()));
        }

        [TestMethod]
        public void ProcessMyWork_WhenCalled_ProcessesWork()
        {
            // Arrange
            const string selectedField = "Author";
            const string expectedType = "Boolean";
            const string expectedFormat = "format";
            const string expectedUniqueIdValue = "UniqueIdValue";
            const string myWorkString = "MyWork";

            var inputElement = new XDocument();
            inputElement.Add(new XElement(myWorkString));
            var selectedFields = new List<string>()
            {
                selectedField
            };
            var workTypes = new Dictionary<string, string>();
            var workspaces = new Dictionary<string, string>();
            var actual = new XElement(selectedField);
            var actualCount = 0;

            var dTable = new DataTable();
            dTable.Columns.Add(IDColumn);
            dTable.Columns.Add(ListIdColumn);
            dTable.Columns.Add(selectedField);
            dTable.Columns.Add(WebIdColumn);
            dTable.Columns.Add(WorkingOnColumn);
            var row = dTable.NewRow();
            row[IDColumn] = guid.ToString();
            row[ListIdColumn] = guid.ToString().ToUpper();
            row[selectedField] = true.ToString();
            row[WebIdColumn] = guid.ToString();
            row[WorkingOnColumn] = WorkingOnColumn;
            dTable.Rows.Add(row);

            ShimMyWork.GetListNameFromDbGuidGuidSPWeb = (_, _1, _2) => expectedUniqueIdValue;
            ShimMyWork.GetWorkspaceNameFromDbGuidString = (_, _1) => expectedUniqueIdValue;
            ShimMyWork.GetTypeAndFormatDictionaryOfStringSPFieldStringStringOutStringOut = (Dictionary<string, SPField> fieldTypesParam, string selectedFieldParam, out string type, out string format) =>
            {
                type = expectedType;
                format = expectedFormat;
            };
            ShimXContainer.AllInstances.AddObject = (instance, element) =>
            {
                if (instance.NodeType == XmlNodeType.Element)
                {
                    if (((XElement)instance).Name.LocalName.Equals(myWorkString))
                    {
                        actual = (XElement)element;
                        actualCount = actualCount + 1;
                    }
                }
                ShimsContext.ExecuteWithoutShims(() =>
                {
                    instance.Add(element);
                });
            };

            // Act
            privateObj.Invoke(
                ProcessMyWorkMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { dTable, spSite.Instance, spWeb.Instance, selectedFields, null, workTypes, workspaces, inputElement });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actualCount.ShouldBe(1),
                () => actual.Name.ShouldBe("Item"),
                () => actual.Attribute("ID").Value.ShouldBe(guid.ToString().ToUpper()),
                () => actual.Attribute("ListID").Value.ShouldBe(guid.ToString().ToUpper()),
                () => actual.Attribute("WorkingOn").Value.ShouldBe(WorkingOnColumn),
                () => actual.Element("Fields").Elements("Field").ElementAt(0).Attribute("Name").Value.ShouldBe("AuthorID"),
                () => actual.Element("Fields").Elements("Field").ElementAt(1).Attribute("Name").Value.ShouldBe(selectedField));
        }

        [TestMethod]
        public void QueryMyWorkData_WhenCalled_ReturnsDataTable()
        {
            // Arrange
            var spSiteDataQuery = new SPSiteDataQuery();
            var userToken = new ShimSPUserToken().Instance;

            var dataTable = new DataTable();
            dataTable.Columns.Add(ListIdColumn);
            var row = dataTable.NewRow();
            row[ListIdColumn] = guid.ToString();
            dataTable.Rows.Add(row);

            spWeb.GetSiteDataSPSiteDataQuery = _ => dataTable;

            // Act
            var actual = (DataTable)privateObj.Invoke(
                QueryMyWorkDataMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spSiteDataQuery, string.Empty, guid, userToken });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Rows.Count.ShouldBe(1),
                () => actual.Rows[0][ListIdColumn].ShouldBe(guid.ToString()));
        }

        [TestMethod]
        public void RenameGlobalView_WhenCalled_RenamesGlobalView()
        {
            // Arrange
            const string viewId = "viewId";
            const string expectedViewName = "viewName";

            var actual = new List<MyWorkGridView>();
            var globalViews = new List<MyWorkGridView>()
            {
                new MyWorkGridView()
                {
                    Id = viewId,
                    Name = DummyString
                },
                new MyWorkGridView()
                {
                    Id = DummyString,
                    Name = DummyString
                },
                new MyWorkGridView()
                {
                    Id = viewId,
                    Name = DummyString
                }
            };

            ShimMyWork.SaveGlobalViewsIEnumerableOfMyWorkGridViewSPWeb = (views, _1) =>
            {
                actual.AddRange(views);
            };

            // Act
            privateObj.Invoke(
                RenameGlobalViewMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { viewId, expectedViewName, globalViews, spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(3),
                () => actual.Count(x => x.Id == viewId && x.Name != expectedViewName).ShouldBe(0),
                () => actual.Count(x => x.Id == viewId).ShouldBe(actual.Count(x => x.Id == viewId && x.Name == expectedViewName)));
        }

        [TestMethod]
        public void RenamePersonalView_WhenCalled_RenamesGlobalView()
        {
            // Arrange
            const string viewId = "viewId";
            const string expectedViewName = "viewName";

            var actual = new List<MyWorkGridView>();
            var personalViews = new List<MyWorkGridView>()
            {
                new MyWorkGridView()
                {
                    Id = viewId,
                    Name = DummyString
                },
                new MyWorkGridView()
                {
                    Id = DummyString,
                    Name = DummyString
                },
                new MyWorkGridView()
                {
                    Id = viewId,
                    Name = DummyString
                }
            };

            ShimMyWork.SavePersonalViewsIEnumerableOfMyWorkGridViewSPWeb = (views, _1) =>
            {
                actual.AddRange(views);
            };

            // Act
            privateObj.Invoke(
                RenamePersonalViewMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { viewId, expectedViewName, personalViews, spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(3),
                () => actual.Count(x => x.Id == viewId && x.Name != expectedViewName).ShouldBe(0),
                () => actual.Count(x => x.Id == viewId).ShouldBe(actual.Count(x => x.Id == viewId && x.Name == expectedViewName)));
        }

        [TestMethod]
        public void SaveGlobalViews_OverloadedWhenCalled_SavesViews()
        {
            // Arrange
            const string viewId = "viewId";
            const string expectedKey = "EPMLive_MyWork_Grid_GlobalViews";

            var actualSave = false;
            var actualKey = string.Empty;
            var outputValue = string.Empty;
            var actual = default(List<MyWorkGridView>);
            var personalViews = new List<MyWorkGridView>()
            {
                new MyWorkGridView()
                {
                    Id = viewId,
                    Name = DummyString
                },
                new MyWorkGridView()
                {
                    Id = DummyString,
                    Name = DummyString
                },
                new MyWorkGridView()
                {
                    Id = viewId,
                    Name = DummyString
                }
            };
            var xmlSerializer = new XmlSerializer(typeof(List<MyWorkGridView>));

            ShimCoreFunctions.setConfigSettingSPWebStringString = (_, key, value) =>
            {
                actualSave = true;
                actualKey = key;
                outputValue = value;
            };

            // Act
            privateObj.Invoke(
                SaveGlobalViewsMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { personalViews, spWeb.Instance });
            actual = (List<MyWorkGridView>)xmlSerializer.Deserialize(new StringReader(outputValue));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(3),
                () => actual.Count(x => x.Id == viewId).ShouldBe(2),
                () => actualSave.ShouldBeTrue(),
                () => actualKey.ShouldBe(expectedKey));
        }

        [TestMethod]
        public void SavePersonalViews_WhenCalled_SavesPersonalViews()
        {
            // Arrange
            var actualUpdateCount = 0;
            var myWorkGridViews = new List<MyWorkGridView>()
            {
                new MyWorkGridView()
                {
                    Id = DummyString,
                    Name = DummyString
                }
            };

            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                actualUpdateCount = actualUpdateCount + 1;
                return 1;
            };

            // Act
            privateObj.Invoke(
                SavePersonalViewsMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { myWorkGridViews, spWeb.Instance });

            // Assert
            actualUpdateCount.ShouldBe(2);
        }

        [TestMethod]
        public void TagSiteIdExists_WhenCalled_ReturnsBoolean()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable.Columns.Add(ListIdColumn);
            var row = dataTable.NewRow();
            row[ListIdColumn] = guid.ToString();
            dataTable.Rows.Add(row);

            ShimQueryExecutor.AllInstances.ExecuteReportingDBQueryStringIDictionaryOfStringObject = (_, _1, _2) => dataTable;

            // Act
            var actual = (bool)privateObj.Invoke(
                TagSiteIdExistsMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spWeb.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void CheckListEditPermission_WhenCalled_ReturnsString()
        {
            // Arrange
            ShimMyWork.GetMyWorkElementString = _ => null;
            ShimUtils.GetListWebSiteStringXElementGuidOutGuidOutGuidOutStringOut =
                (string data, XElement element, out Guid listId, out Guid webId, out Guid siteId, out string siteUrl) =>
                {
                    listId = guid;
                    webId = guid;
                    siteId = guid;
                    siteUrl = string.Empty;
                };
            spList.DoesUserHavePermissionsSPUserSPBasePermissions = (_1, _2) => true;

            // Act
            var actual = XDocument.Parse((string)privateObj.Invoke(
                CheckListEditPermissionMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { string.Empty }));

            // Assert
            actual.Element("MyWork").Element("HasEditPermission").Value.ToLower().ShouldBe("true");
        }

        [TestMethod]
        public void DeleteMyWorkGridView_PersonalViewTrue_ReturnsString()
        {
            // Arrange
            var actual = false;

            ShimMyWork.DeletePersonalViewStringIEnumerableOfMyWorkGridViewSPWeb = (_, _1, _2) =>
            {
                actual = true;
            };
            ShimMyWork.DeleteGlobalViewStringBooleanIEnumerableOfMyWorkGridViewSPWeb = (_, _1, _2, _3) => { };
            ShimMyWork.GetPersonalViewsSPWeb = _ => null;
            ShimMyWork.GetGlobalViewsSPWeb = _ => null;

            // Act
            var actualOutput = XDocument.Parse((string)privateObj.Invoke(
                DeleteMyWorkGridViewMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { MyWorkGridViewXml }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => actualOutput.Element("MyWork").ShouldNotBeNull());
        }

        [TestMethod]
        public void DeleteMyWorkGridView_PersonalViewFalse_ReturnsString()
        {
            // Arrange
            var actual = false;

            ShimMyWork.DeletePersonalViewStringIEnumerableOfMyWorkGridViewSPWeb = (_, _1, _2) => { };
            ShimMyWork.DeleteGlobalViewStringBooleanIEnumerableOfMyWorkGridViewSPWeb = (_, _1, _2, _3) =>
            {
                actual = true;
            };
            ShimMyWork.GetPersonalViewsSPWeb = _ => null;
            ShimMyWork.GetGlobalViewsSPWeb = _ => null;

            // Act
            var actualOutput = XDocument.Parse((string)privateObj.Invoke(
                DeleteMyWorkGridViewMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { MyWorkGridViewXml.Replace(@"Personal=""True""", @"Personal=""False""") }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => actualOutput.Element("MyWork").ShouldNotBeNull());
        }

        [TestMethod]
        public void GetMyWork_NotPerformanceMode_ReturnsString()
        {
            // Arrange
            const string siteUrl = "siteUrl";

            var archivedWebs = new List<Guid>();
            var fieldTypes = new Dictionary<string, SPField>();
            var methodEntered = false;

            ShimUtils.GetFieldTypes = () => fieldTypes;
            ShimMyWork.GetArchivedWebsGuid = _ => archivedWebs;
            ShimMyWork.GetQueryString = _ => string.Empty;
            ShimMyWork.GetDataFromListsXDocumentDictionaryOfStringSPFieldStringSPSiteSPWebListOfStringListOfString = (_, _1, _2, _3, _4, _5, _6) =>
            {
                methodEntered = true;
            };
            ShimMyWork.GetSettingsStringListOfStringRefListOfStringRefListOfStringRefBooleanRefBooleanRef =
                (string data, ref List<string> selectedFields, ref List<string> selectedLists,
                ref List<string> siteUrls, ref bool performanceMode, ref bool noListsSelected) =>
                {
                    siteUrls.Add(siteUrl);
                    performanceMode = false;
                };

            // Act
            var actual = XDocument.Parse((string)privateObj.Invoke(
                GetMyWorkMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { string.Empty }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("MyWork").Element("Params").Element("ProcessFlag").Value.ToLower().ShouldBe("false"),
                () => methodEntered.ShouldBeTrue());
        }

        [TestMethod]
        public void GetMyWork_ReportingDBTrue_ReturnsString()
        {
            // Arrange
            const string siteUrl = "siteUrl";

            var archivedWebs = new List<Guid>();
            var fieldTypes = new Dictionary<string, SPField>();
            var methodEntered = false;

            ShimUtils.GetFieldTypes = () => fieldTypes;
            ShimMyWork.GetArchivedWebsGuid = _ => archivedWebs;
            ShimMyWork.GetQueryString = _ => string.Empty;
            ShimMyWork.ShouldUseReportingDbSPWeb = _ => true;
            ShimMyWork.GetDataFromReportingDBDictionaryOfStringStringIEnumerableOfStringListOfGuidSPWebListOfStringString =
                (_, _1, _2, _3, _4, _5) => new List<DataTable>()
                {
                    new DataTable()
                };
            ShimMyWork.ProcessMyWorkDataTableSPSiteSPWebIEnumerableOfStringDictionaryOfStringSPFieldDictionaryOfStringStringDictionaryOfStringStringXDocumentRef =
                (DataTable dataTable, SPSite spSite, SPWeb spWeb,
                IEnumerable<string> selectedFields, Dictionary<string,
                SPField> fieldTypesParam, Dictionary<string, string> workTypes,
                Dictionary<string, string> workspaces, ref XDocument result) =>
                {
                    methodEntered = true;
                };
            ShimMyWork.GetSettingsStringListOfStringRefListOfStringRefListOfStringRefBooleanRefBooleanRef =
                (string data, ref List<string> selectedFields, ref List<string> selectedLists,
                ref List<string> siteUrls, ref bool performanceMode, ref bool noListsSelected) =>
                {
                    siteUrls.Add(siteUrl);
                    performanceMode = true;
                };

            // Act
            var actual = XDocument.Parse((string)privateObj.Invoke(
                GetMyWorkMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { string.Empty }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("MyWork").Element("Params").Element("ProcessFlag").Value.ToLower().ShouldBe("false"),
                () => methodEntered.ShouldBeTrue());
        }

        [TestMethod]
        public void GetMyWork_ReportingDBFalse_ReturnsString()
        {
            // Arrange
            const string siteUrl = "siteUrl";

            var archivedWebs = new List<Guid>();
            var fieldTypes = new Dictionary<string, SPField>();
            var methodEntered = false;

            ShimUtils.GetFieldTypes = () => fieldTypes;
            ShimMyWork.GetArchivedWebsGuid = _ => archivedWebs;
            ShimMyWork.GetQueryString = _ => string.Empty;
            ShimMyWork.ShouldUseReportingDbSPWeb = _ => false;
            ShimMyWork.GetDataFromSPListOfStringSPSiteDataQuerySPWebSPSiteListOfGuidIEnumerableOfString =
                (_, _1, _2, _3, _4, _5) => new List<DataTable>()
                {
                    new DataTable()
                };
            ShimMyWork.ProcessMyWorkDataTableSPSiteSPWebIEnumerableOfStringDictionaryOfStringSPFieldDictionaryOfStringStringDictionaryOfStringStringXDocumentRef =
                (DataTable dataTable, SPSite spSite, SPWeb spWeb,
                IEnumerable<string> selectedFields, Dictionary<string,
                SPField> fieldTypesParam, Dictionary<string, string> workTypes,
                Dictionary<string, string> workspaces, ref XDocument result) =>
                {
                    methodEntered = true;
                };
            ShimMyWork.GetSettingsStringListOfStringRefListOfStringRefListOfStringRefBooleanRefBooleanRef =
                (string data, ref List<string> selectedFields, ref List<string> selectedLists,
                ref List<string> siteUrls, ref bool performanceMode, ref bool noListsSelected) =>
                {
                    siteUrls.Add(siteUrl);
                    performanceMode = true;
                    noListsSelected = false;
                    selectedFields.Add(ListIdColumn);
                };

            // Act
            var actual = XDocument.Parse((string)privateObj.Invoke(
                GetMyWorkMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { string.Empty }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("MyWork").Element("Params").Element("ProcessFlag").Value.ToLower().ShouldBe("true"),
                () => methodEntered.ShouldBeTrue());
        }
    }
}
