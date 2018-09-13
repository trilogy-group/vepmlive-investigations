using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Linq.Fakes;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Shouldly;
using TypeToTest = EPMLiveCore.API.MyWork;

namespace EPMLiveCore.Tests.API.MyWork
{
    [TestClass, ExcludeFromCodeCoverage]
    public partial class MyWorkRemTests
    {
        private TypeToTest testObj;
        private PrivateObject privateObj;
        private IDisposable shimsContext;
        private Guid guid;
        private ShimSPWeb spWeb;
        private ShimSPSite spSite;
        private ShimSPWebApplication webApplication;
        private const string GuidString = "83e81819-0112-4c22-bb70-d8ba101e9e0c";
        private const string GetArchivedWebsMethodName = "GetArchivedWebs";
        private const string GetGlobalViewsMethodName = "GetGlobalViews";
        private const string GetListFieldsAndTypesFromDbMethodName = "GetListFieldsAndTypesFromDb";
        private const string GetListIdsFromDbMethodName = "GetListIdsFromDb";
        private const string GetListNameFromDbMethodName = "GetListNameFromDb";
        private const string ShouldUseReportingDbMethodName = "ShouldUseReportingDb";
        private const string BuildFieldElementMethodName = "BuildFieldElement";
        private const string SaveGlobalViewsMethodName = "SaveGlobalViews";
        private const string DeletePersonalViewMethodName = "DeletePersonalView";
        private const string GenerateColDictionaryMethodName = "GenerateColDictionary";
        private const string GetDataFromListsMethodName = "GetDataFromLists";
        private const string GetDataFromReportingDBMethodName = "GetDataFromReportingDB";
        private const string DeleteGlobalViewMethodName = "DeleteGlobalView";
        private const string GetDataFromSPMethodName = "GetDataFromSP";
        private const string GetExampleDateFormatMethodName = "GetExampleDateFormat";
        private const string GetGridSafeValueMethodName = "GetGridSafeValue";
        private const string GetLeftColsMethodName = "GetLeftCols";
        private const string GetMyWorkElementMethodName = "GetMyWorkElement";
        private const string ConnectionString = "ConnectionString";
        private const string ConfigSetting = "ConfigSetting";
        private const string ServerRelativeUrl = "/ServerRelativeUrl";
        private const string IDColumn = "ID";
        private const string ListIdColumn = "ListId";
        private const string ItemIdColumn = "ItemId";
        private const string SiteIdColumn = "SiteId";
        private const string WebIdColumn = "WebId";
        private const string AssignedToIDColumn = "AssignedToID";
        private const string InternalNameColumn = "InternalName";
        private const string WorkTypeColumn = "WorkType";
        private const string WorkingOnColumn = "WorkingOn";
        private const string DummyString = "1";
        private const string DateSeparator = "-";
        private const string Title = "Title";
        private const string Url = "Url";
        private string SerializedGlobalViews;

        [TestInitialize]
        public void Setup()
        {
            SetupShims();

            testObj = new TypeToTest();
            privateObj = new PrivateObject(testObj);
        }

        private void SetupShims()
        {
            shimsContext = ShimsContext.Create();
            SetupVariables();

            ShimSqlConnection.ConstructorString = (_, __) => new SqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimCoreFunctions.getConnectionStringGuid = _ => ConnectionString;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => SerializedGlobalViews;
            ShimCoreFunctions.getLockedWebSPWeb = _ => guid;
            ShimExtensionMethods.ToTreeListSPWeb = _ => new List<Guid>()
            {
                guid
            };
            ShimExtensionMethods.HasItemsSPListItemCollection = _ => true;
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, _1) => true;
            ShimExtensionMethods.Md5String = _ => DummyString;
            ShimMyWorkReportData.ConstructorGuid = (_, __) => new ShimMyWorkReportData();
            ShimReportData.ConstructorGuid = (_, __) => new ShimReportData();
            ShimReportData.AllInstances.GetSite = _ => new ShimDataRow();
            ShimReportData.AllInstances.GetListMappingGuid = (_, _1) => new ShimDataRow();
            ShimReportData.AllInstances.Dispose = _ => { };
            ShimSPDatabase.AllInstances.DatabaseConnectionStringGet = _ => ConnectionString;
            ShimSPPersistedObject.AllInstances.IdGet = _ => guid;
            ShimSPSite.ConstructorGuid = (_, __) => new ShimSPSite();
            ShimSPSite.ConstructorStringSPUserToken = (_, _1, _2) => new ShimSPSite();
            ShimSPSite.AllInstances.WebApplicationGet = _ => webApplication;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => spWeb;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = (codeToRun) =>
            {
                codeToRun();
            };
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.GetContextSPWeb = _ => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => spWeb;
            ShimSPContext.AllInstances.RegionalSettingsGet = _ => new ShimSPRegionalSettings();
            ShimSPRegionalSettings.AllInstances.DateSeparatorGet = _ => DateSeparator;
            ShimUtils.GetConfigWebSPWebGuid = (_, _1) => spWeb;
            ShimUtils.GetCleanFieldValueXElement = element => element.Value;
        }

        private void SetupVariables()
        {
            guid = new Guid(GuidString);

            spSite = new ShimSPSite()
            {
                IDGet = () => guid,
                UrlGet = () => Url,
                ContentDatabaseGet = () => new ShimSPContentDatabase(),
                OpenWebGuid = _ => spWeb
            };

            var currentUser = new ShimSPUser()
            {
                IDGet = () => 1,
                LoginNameGet = () => DummyString,
                RegionalSettingsGet = () => new ShimSPRegionalSettings()
            };

            spWeb = new ShimSPWeb()
            {
                CurrentUserGet = () => currentUser,
                SiteGet = () => spSite,
                TitleGet = () => Title,
                ServerRelativeUrlGet = () => ServerRelativeUrl,
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetString = _ => new ShimSPList()
                    {
                        IDGet = () => guid
                    },
                    TryGetListString = _ => new ShimSPList()
                    {
                        IDGet = () => guid,
                        TitleGet = () => Title,
                        GetItemsSPQuery = __ => new ShimSPListItemCollection()
                        {
                            FieldsGet = () => new ShimSPFieldCollection()
                            {
                                ContainsFieldString = _1 => true
                            },
                            GetEnumerator = () => new List<SPListItem>()
                            {
                                new ShimSPListItem()
                                {
                                    IDGet = () => 1,
                                    FieldsGet = () => new ShimSPFieldCollection(),
                                    ItemGetString = _1 => DummyString
                                }
                            }.GetEnumerator()
                        }
                    }
                }
            };

            webApplication = new ShimSPWebApplication();
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

       
        [TestMethod]
        public void GetArchivedWebs_WhenCalled_ReturnsList()
        {
            // Arrange
            const int expectedCount = 5;

            var readCount = 0;
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                readCount = readCount + 1;
                return readCount <= expectedCount;
            };
            ShimSqlDataReader.AllInstances.ItemGetInt32 = (_, __) => guid.ToString();

            // Act
            var actual = (List<Guid>)privateObj.Invoke(
                GetArchivedWebsMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { guid });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(expectedCount),
                () => actual.Count(x => x.ToString() == guid.ToString()).ShouldBe(expectedCount));
        }
        
       [TestMethod]
       public void GetGlobalViews_WhenCalled_ReturnsList()
       {
           // Arrange
           var sb = new StringBuilder();
           sb.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
           sb.Append("<ArrayOfMyWorkGridView>");
           sb.Append("<MyWorkGridView>");
           sb.Append("<Cols>Cols</Cols>");
           sb.Append("<Default>true</Default>");
           sb.Append("<Filters>Filters</Filters>");
           sb.Append("<Grouping>Grouping</Grouping>");
           sb.Append("<Id>Id</Id>");
           sb.Append("<LeftCols>LeftCols</LeftCols>");
           sb.Append("<Name>Name</Name>");
           sb.Append("<Personal>true</Personal>");
           sb.Append("<RightCols>RightCols</RightCols>");
           sb.Append("<Sorting>Sorting</Sorting>");
           sb.Append("<HasPermission>true</HasPermission>");
           sb.Append("</MyWorkGridView>");
           sb.Append("<MyWorkGridView>");
           sb.Append("<Cols>Cols</Cols>");
           sb.Append("<Default>true</Default>");
           sb.Append("<Filters>Filters</Filters>");
           sb.Append("<Grouping>Grouping</Grouping>");
           sb.Append("<Id>Id</Id>");
           sb.Append("<LeftCols>LeftCols</LeftCols>");
           sb.Append("<Name>Name</Name>");
           sb.Append("<Personal>true</Personal>");
           sb.Append("<RightCols>RightCols</RightCols>");
           sb.Append("<Sorting>Sorting</Sorting>");
           sb.Append("<HasPermission>false</HasPermission>");
           sb.Append("</MyWorkGridView>");
           sb.Append("</ArrayOfMyWorkGridView>");
           SerializedGlobalViews = sb.ToString();

           // Act
           var actual = (List<MyWorkGridView>)privateObj.Invoke(
               GetGlobalViewsMethodName,
               BindingFlags.Static | BindingFlags.Public,
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
       public void GetListFieldsAndTypesFromDb_WhenCalled_ReturnsDictionary()
       {
           // Arrange
           var sb = new StringBuilder();
           sb.Append(@"<Field Name=""3"" Type=""Type3""></Field>");
           sb.Append(@"<Field Name=""1"" Type=""Type1""></Field>");
           sb.Append(@"<Field Name=""2"" Type=""Type2""></Field>");
           var fields = sb.ToString();

           ShimSqlCommand.AllInstances.ExecuteScalar = _ => new byte[] { 1 };
           ShimExtensionMethods.SpDecompressByteArray = _ => fields;

           // Act
           var actual = (IOrderedEnumerable<KeyValuePair<string, string>>)privateObj.Invoke(
               GetListFieldsAndTypesFromDbMethodName,
               BindingFlags.Static | BindingFlags.Public,
               new object[] { guid, guid, spWeb.Instance });

           // Assert
           actual.ShouldSatisfyAllConditions(
               () => actual.Count().ShouldBe(3),
               () => actual.ElementAt(0).Key.ShouldBe("1"),
               () => actual.ElementAt(1).Key.ShouldBe("2"),
               () => actual.ElementAt(2).Key.ShouldBe("3"),
               () => actual.ElementAt(0).Value.ShouldBe("Type1"),
               () => actual.ElementAt(1).Value.ShouldBe("Type2"),
               () => actual.ElementAt(2).Value.ShouldBe("Type3"));
       }

       [TestMethod]
       public void GetListIdsFromDb_WhenCalled_ReturnsList()
       {
           // Arrange
           const int expected = 5;

           var readCount = 0;
           var archivedWebs = new List<Guid>()
           {
               guid
           };

           ShimSqlDataReader.AllInstances.Read = _ =>
           {
               readCount = readCount + 1;
               return readCount <= expected;
           };
           ShimSqlDataReader.AllInstances.GetGuidInt32 = (_, _1) => guid;

           // Act
           var actual = (List<string>)privateObj.Invoke(
               GetListIdsFromDbMethodName,
               BindingFlags.Static | BindingFlags.Public,
               new object[] { string.Empty, spWeb.Instance, archivedWebs });

           // Assert
           actual.ShouldSatisfyAllConditions(
               () => actual.Count.ShouldBe(expected),
               () => actual.Where(x => x.ToString() == guid.ToString()).Count().ShouldBe(expected));
       }

        /**
       [TestMethod]
       public void GetListNameFromDb_WhenCalled_ReturnsString()
       {
           // Arrange
           const string expected = "expected";

           ShimSqlCommand.AllInstances.ExecuteScalar = _ => expected;

           // Act
           var actual = (string)privateObj.Invoke(
               GetListNameFromDbMethodName,
               BindingFlags.Static | BindingFlags.Public,
               new object[] { guid, guid, spWeb.Instance });

           // Assert
           actual.ShouldBe(expected);
       }

       [TestMethod]
       public void ShouldUseReportingDb_WhenCalled_ReturnsBoolean()
       {
           // Arrange and Act
           var actual = (bool)privateObj.Invoke(
               ShouldUseReportingDbMethodName,
               BindingFlags.Static | BindingFlags.Public,
               new object[] { spWeb.Instance });

           // Assert
           actual.ShouldBeTrue();
       }

       [TestMethod]
       public void BuildFieldElement_WhenCalled_ReturnsXElement()
       {
           // Arrange
           var fieldTypesInput = new Dictionary<string, SPField>();
           const string value = "True";
           const string field = "Complete";
           const string expectedType = "expectedType";
           const string expectedFormat = "expectedFormat";

           ShimMyWork.GetTypeAndFormatDictionaryOfStringSPFieldStringStringOutStringOut = (Dictionary<string, SPField> fieldTypes, string selectedField, out string type, out string format) =>
           {
               type = expectedType;
               format = expectedFormat;
           };

           // Act
           var actual = (XElement)privateObj.Invoke(
               BuildFieldElementMethodName,
               BindingFlags.Static | BindingFlags.NonPublic,
               new object[] { fieldTypesInput, value, field });

           // Assert
           actual.ShouldSatisfyAllConditions(
               () => actual.Name.ShouldBe("Field"),
               () => actual.Attribute("Name").Value.ShouldBe(field),
               () => actual.Attribute("Type").Value.ShouldBe(expectedType),
               () => actual.Attribute("Format").Value.ShouldBe(expectedFormat));
       }

       [TestMethod]
       public void SaveGlobalViews_WhenCalled_SavesViews()
       {
           // Arrange
           var actual = new List<MyWorkGridView>();
           var actualSave = false;
           var myWorkGridView = new MyWorkGridView()
           {
               Id = "1",
               Default = true
           };
           var myWorkGridViews = new List<MyWorkGridView>()
           {
               myWorkGridView,
               myWorkGridView,
               new MyWorkGridView()
               {
                   Id = "2",
                   Default = true
               }
           };

           ShimMyWork.SaveGlobalViewsIEnumerableOfMyWorkGridViewSPWeb = (gridViews, _1) =>
           {
               actual.AddRange(gridViews);
               actualSave = true;
           };
           ShimMyWork.GetGlobalViewsSPWeb = _ => myWorkGridViews;

           // Act
           privateObj.Invoke(
               SaveGlobalViewsMethodName,
               BindingFlags.Static | BindingFlags.Public,
               new object[] { myWorkGridView, spWeb.Instance });

           // Assert
           actual.ShouldSatisfyAllConditions(
               () => actualSave.ShouldBeTrue(),
               () => actual.ShouldNotBeNull(),
               () => actual.Count.ShouldBe(2),
               () => actual[0].Id.ShouldBe(2.ToString()),
               () => actual[1].Id.ShouldBe(1.ToString()),
               () => actual[0].Default.ShouldBeFalse(),
               () => actual[1].Default.ShouldBeTrue());
       }

       [TestMethod]
       public void DeletePersonalView_WhenCalled_SavesViews()
       {
           // Arrange
           const string viewId = "1";

           var gridView = new MyWorkGridView()
           {
               Id = viewId,
               Default = true
           };
           var personalViews = new List<MyWorkGridView>()
           {
               gridView,
               new MyWorkGridView()
               {
                   Id = "2",
                   Default = false
               },
               gridView
           };
           var actualSave = false;
           var actual = new List<MyWorkGridView>();
           ShimMyWork.SavePersonalViewsIEnumerableOfMyWorkGridViewSPWeb = (gridViews, _1) =>
           {
               actual.AddRange(gridViews);
               actualSave = true;
           };

           // Act
           privateObj.Invoke(
               DeletePersonalViewMethodName,
               BindingFlags.Static | BindingFlags.NonPublic,
               new object[] { viewId, personalViews, spWeb.Instance });

           // Assert
           actual.ShouldSatisfyAllConditions(
               () => actualSave.ShouldBeTrue(),
               () => actual.ShouldNotBeNull(),
               () => actual.Count.ShouldBe(1),
               () => actual[0].Id.ShouldBe(2.ToString()),
               () => actual[0].Default.ShouldBeFalse());
       }

       [TestMethod]
       public void GenerateColDictionary_WhenCalled_ReturnsDictionary()
       {
           // Arrange
           const string field1 = "Field1";
           const string field2 = "Field2";
           const string field3 = "Field3";

           var myWorkFields = new List<string>()
           {
               field1,
               field2,
               field3
           };
           var myWorkDataTable = new DataTable();
           myWorkDataTable.Columns.Add(field1);
           myWorkDataTable.Columns.Add($"{field2}ID");

           // Act
           var actual = (Dictionary<string, int>)privateObj.Invoke(
               GenerateColDictionaryMethodName,
               BindingFlags.Static | BindingFlags.NonPublic,
               new object[] { myWorkDataTable, myWorkFields });

           // Assert
           actual.ShouldSatisfyAllConditions(
               () => actual.Count.ShouldBe(3),
               () => actual[field1].ShouldBe(1),
               () => actual[field2].ShouldBe(2),
               () => actual[field3].ShouldBe(0));
       }

       [TestMethod]
       public void GetDataFromLists_WhenCalled_GetsData()
       {
           // Arrange
           const string query = "query";
           const string expectedType = "expectedType";
           const string expectedFormat = "expectedFormat";

           var actualCount = 0;
           var fieldTypes = new Dictionary<string, SPField>();
           var selectedLists = new List<string>()
           {
               DummyString
           };
           var selectedFields = new List<string>()
           {
               DummyString
           };
           var actual = default(XElement);
           var result = new XDocument();
           ShimsContext.ExecuteWithoutShims(() =>
           {
               result.Add(new XElement("MyWork"));
           });
           var dTable = new DataTable();
           dTable.Columns.Add(ListIdColumn);
           dTable.Columns.Add(ItemIdColumn);
           var row = dTable.NewRow();
           row[ListIdColumn] = guid.ToString().ToUpper();
           row[ItemIdColumn] = 1.ToString(CultureInfo.InvariantCulture);
           dTable.Rows.Add(row);

           ShimMyWork.GetArchivedWebsGuid = _ => new List<Guid>()
           {
               Guid.NewGuid()
           };
           ShimMyWork.GetWorkingOnSPWeb = _ => dTable;
           ShimMyWork.GetTypeAndFormatDictionaryOfStringSPFieldStringStringOutStringOut = (Dictionary<string, SPField> fieldTypesParam, string selectedField, out string type, out string format) =>
           {
               type = expectedType;
               format = expectedFormat;
           };
           ShimXContainer.AllInstances.AddObject = (instance, element) =>
           {
               if (instance.NodeType == XmlNodeType.Element)
               {
                   if (((XElement)instance).Name.LocalName.Equals("MyWork"))
                   {
                       actual = (XElement)element;
                       actualCount = actualCount + 1;
                       return;
                   }
               }
               ShimsContext.ExecuteWithoutShims(() =>
               {
                   instance.Add(element);
               });
           };

           // Act
           privateObj.Invoke(
               GetDataFromListsMethodName,
               BindingFlags.Static | BindingFlags.NonPublic,
               new object[] { result, fieldTypes, query, spSite.Instance, spWeb.Instance, selectedFields, selectedLists });

           // Assert
           actual.ShouldSatisfyAllConditions(
               () => actualCount.ShouldBe(1),
               () => actual.Name.ShouldBe("Item"),
               () => actual.Attribute("ID").Value.ShouldBe(DummyString),
               () => actual.Attribute("ListID").Value.ShouldBe(guid.ToString().ToUpper()),
               () => actual.Attribute("WorkingOn").Value.ToLower().ShouldBe("true"));
       }

       [TestMethod]
       public void GetDataFromReportingDB_WhenCalled_ReturnsDataTables()
       {
           // Arrange
           const string workTableQuery = "SELECT DISTINCT * FROM dbo.LSTMyWork";
           const string fieldsTableQuery = "FROM dbo.RPTColumn";
           const string flagsTableQuery = "FROM dbo.PERSONALIZATIONS";

           var workTypes = new Dictionary<string, string>();
           var selectedFields = new List<string>()
           {
               ListIdColumn,
               ItemIdColumn
           };
           var archivedWebs = new List<Guid>()
           {
               guid
           };
           var selectedLists = new List<string>()
           {
               DummyString
           };
           const string data = @"
               <xmlcfg>
                 <CompleteItemsQuery>true</CompleteItemsQuery>
                 <DateRange From=""2018-09-12 00:00:00"" To=""2018-09-12 12:00:00""/>
                 <ListId>83e81819-0112-4c22-bb70-d8ba101e9e0c</ListId>
               </xmlcfg>";
           var row = default(DataRow);
           var columnDictionary = new Dictionary<string, int>();

           var workDataTable = new DataTable();
           var fieldsTable = new DataTable();
           var flagsTable = new DataTable();
           var workingTable = new DataTable();

           workDataTable.Columns.Add(SiteIdColumn);
           workDataTable.Columns.Add(WebIdColumn);
           workDataTable.Columns.Add(ListIdColumn);
           workDataTable.Columns.Add(ItemIdColumn);
           workDataTable.Columns.Add(AssignedToIDColumn);
           workDataTable.Columns.Add(WorkTypeColumn);

           row = workDataTable.NewRow();
           foreach (DataColumn dataColumn in workDataTable.Columns)
           {
               row[dataColumn.ColumnName] = DummyString;
           }
           workDataTable.Rows.Add(row);

           fieldsTable.Columns.Add(InternalNameColumn);

           workingTable.Columns.Add(ListIdColumn);
           workingTable.Columns.Add(ItemIdColumn);

           row = workingTable.NewRow();
           row[ListIdColumn] = DummyString;
           row[ItemIdColumn] = DummyString;
           workingTable.Rows.Add(row);

           ShimMyWork.MapCompleteFieldSPWebMyWorkReportData = (_, __) => { };
           ShimMyWork.GenerateColDictionaryDataTableIEnumerableOfString = (_, __) => columnDictionary;
           ShimMyWork.GetWorkingOnSPWeb = _ => workingTable;
           ShimMyWork.GetMyWorkFieldValueStringDataRowDictionaryOfStringInt32EnumerableRowCollectionOfDataRowDataTable =
               (_, _1, _2, _3, _4) => DummyString;
           ShimMyWorkReportData.AllInstances.ExecuteSqlString = (_, query) =>
           {
               if (query.StartsWith(workTableQuery))
               {
                   return workDataTable;
               }
               else if (query.Contains(fieldsTableQuery))
               {
                   return fieldsTable;
               }

               return null;
           };
           ShimMyWorkReportData.AllInstances.ExecuteEpmLiveSqlString = (_, query) =>
           {
               if (query.Contains(flagsTableQuery))
               {
                   return flagsTable;
               }

               return null;
           };

           // Act
           var actual = (List<DataTable>)privateObj.Invoke(
               GetDataFromReportingDBMethodName,
               BindingFlags.Static | BindingFlags.NonPublic,
               new object[] { workTypes, selectedFields, archivedWebs, spWeb.Instance, selectedLists, data });

           // Assert
           actual.ShouldSatisfyAllConditions(
               () => actual.Count().ShouldBe(1),
               () => actual[0].Columns.Count.ShouldBe(3),
               () => actual[0].Rows.Count.ShouldBe(1),
               () => actual[0].Rows[0][ListIdColumn].ToString().ShouldBe(DummyString),
               () => actual[0].Rows[0][ItemIdColumn].ToString().ShouldBe(DummyString),
               () => actual[0].Rows[0][WorkingOnColumn].ToString().ShouldBe(true.ToString()));
       }

       [TestMethod]
       public void DeleteGlobalView_WhenCalled_Deletes()
       {
           // Arrange
           const string viewId = "1";
           const bool isDefault = true;
           const string dvId = "dv";

           var globalViews = new List<MyWorkGridView>()
           {
               new MyWorkGridView()
               {
                   Id = viewId,
                   Default = false
               },
               new MyWorkGridView()
               {
                   Id = dvId,
                   Default = false
               },
               new MyWorkGridView()
               {
                   Id = viewId,
                   Default = false
               }
           };
           var actual = new List<MyWorkGridView>();

           ShimMyWork.SaveGlobalViewsIEnumerableOfMyWorkGridViewSPWeb = (list, _1) =>
           {
               actual.AddRange(list);
           };

           // Act
           privateObj.Invoke(
               DeleteGlobalViewMethodName,
               BindingFlags.Static | BindingFlags.NonPublic,
               new object[] { viewId, isDefault, globalViews, spWeb.Instance });

           // Assert
           actual.ShouldSatisfyAllConditions(
               () => actual.Count.ShouldBe(1),
               () => actual[0].Id.ShouldBe(dvId),
               () => actual[0].Default.ShouldBeTrue());
       }

       [TestMethod]
       public void GetDataFromSP_WhenCalled_ReturnsDataTables()
       {
           // Arrange
           var selectedListIds = new List<string>();
           var spSiteDataQuery = new SPSiteDataQuery();
           var row = default(DataRow);
           var selectedLists = new List<string>()
           {
               DummyString
           };
           var archivedWebs = new List<Guid>()
           {
               guid
           };

           var dataTable = new DataTable();
           dataTable.Columns.Add(ListIdColumn);
           dataTable.Columns.Add(IDColumn);
           dataTable.Columns.Add(WorkingOnColumn);
           row = dataTable.NewRow();
           row[ListIdColumn] = DummyString;
           row[IDColumn] = DummyString;
           row[WorkingOnColumn] = DummyString;
           dataTable.Rows.Add(row);

           var workingTable = new DataTable();
           workingTable.Columns.Add(ListIdColumn);
           workingTable.Columns.Add(ItemIdColumn);
           row = workingTable.NewRow();
           row[ListIdColumn] = DummyString;
           row[ItemIdColumn] = DummyString;
           workingTable.Rows.Add(row);

           ShimMyWork.GetListIdsFromDbStringSPWebListOfGuid = (_, _1, _2) => new List<string>()
           {
               $"{DummyString}{DummyString}"
           };
           spWeb.GetSiteDataSPSiteDataQuery = _ => dataTable;
           ShimMyWork.GetWorkingOnSPWeb = _ => workingTable;

           // Act
           var actual = (List<DataTable>)privateObj.Invoke(
               GetDataFromSPMethodName,
               BindingFlags.Static | BindingFlags.NonPublic,
               new object[] { selectedListIds, spSiteDataQuery, spWeb.Instance, spSite.Instance, archivedWebs, selectedLists });

           // Assert
           actual.ShouldSatisfyAllConditions(
               () => actual.Count.ShouldBe(1),
               () => actual[0].Rows.Count.ShouldBe(1),
               () => actual[0].Rows[0][WorkingOnColumn].ToString().ToLower().ShouldBe("true"));
       }

       [TestMethod]
       public void GetExampleDateFormat_MDYFormat_ReturnsString()
       {
           // Arrange
           const string yearLabel = "yearLabel";
           const string monthLabel = "monthLabel";
           const string dayLabel = "dayLabel";

           var expected = $"{monthLabel}{DateSeparator}{dayLabel}{DateSeparator}{yearLabel}";

           ShimSPRegionalSettings.AllInstances.DateFormatGet = _ => (uint)SPCalendarOrderType.MDY;

           // Act
           var actual = (string)privateObj.Invoke(
               GetExampleDateFormatMethodName,
               BindingFlags.Static | BindingFlags.NonPublic,
               new object[] { spWeb.Instance, yearLabel, monthLabel, dayLabel });

           // Assert
           actual.ShouldBe(expected);
       }

       [TestMethod]
       public void GetExampleDateFormat_DMYFormat_ReturnsString()
       {
           // Arrange
           const string yearLabel = "yearLabel";
           const string monthLabel = "monthLabel";
           const string dayLabel = "dayLabel";

           var expected = $"{dayLabel}{DateSeparator}{monthLabel}{DateSeparator}{yearLabel}";

           ShimSPRegionalSettings.AllInstances.DateFormatGet = _ => (uint)SPCalendarOrderType.DMY;

           // Act
           var actual = (string)privateObj.Invoke(
               GetExampleDateFormatMethodName,
               BindingFlags.Static | BindingFlags.NonPublic,
               new object[] { spWeb.Instance, yearLabel, monthLabel, dayLabel });

           // Assert
           actual.ShouldBe(expected);
       }

       [TestMethod]
       public void GetExampleDateFormat_YMDormat_ReturnsString()
       {
           // Arrange
           const string yearLabel = "yearLabel";
           const string monthLabel = "monthLabel";
           const string dayLabel = "dayLabel";

           var expected = $"{yearLabel}{DateSeparator}{monthLabel}{DateSeparator}{dayLabel}";

           ShimSPRegionalSettings.AllInstances.DateFormatGet = _ => (uint)SPCalendarOrderType.YMD;

           // Act
           var actual = (string)privateObj.Invoke(
               GetExampleDateFormatMethodName,
               BindingFlags.Static | BindingFlags.NonPublic,
               new object[] { spWeb.Instance, yearLabel, monthLabel, dayLabel });

           // Assert
           actual.ShouldBe(expected);
       }

       [TestMethod]
       public void GetGridSafeValue_NameCommentCount_ReturnsString()
       {
           // Arrange
           const string value = "10.10";
           const string elementName = "field";
           const string name = "CommentCount";
           const string format = "*";
           const string type = "Other";
           const string expected = "10";

           var sb = new StringBuilder();
           sb.Append("<xmlcfg>");
           sb.AppendFormat(@"<{0} Name=""{1}"" Format=""{2}"" Type=""{3}"">", elementName, name, format, type);
           sb.AppendFormat("{0}", value);
           sb.AppendFormat("</{0}>", elementName);
           sb.Append("</xmlcfg>");

           var xml = XDocument.Parse(sb.ToString());

           var field = xml.Root.Element(elementName);

           // Act
           var actual = (string)privateObj.Invoke(
               GetGridSafeValueMethodName,
               BindingFlags.Static | BindingFlags.NonPublic,
               new object[] { field });

           // Assert
           actual.ShouldBe(expected);
       }

       [TestMethod]
       public void GetGridSafeValue_NamePriority_ReturnsString()
       {
           // Arrange
           const string value = "10.1000000001123";
           const string elementName = "field";
           const string name = "Priority";
           const string format = "*";
           const string type = "Number";
           const string expected = "10.1000000001";

           var sb = new StringBuilder();
           sb.Append("<xmlcfg>");
           sb.AppendFormat(@"<{0} Name=""{1}"" Format=""{2}"" Type=""{3}"">", elementName, name, format, type);
           sb.AppendFormat("{0}", value);
           sb.AppendFormat("</{0}>", elementName);
           sb.Append("</xmlcfg>");

           var xml = XDocument.Parse(sb.ToString());

           var field = xml.Root.Element(elementName);

           // Act
           var actual = (string)privateObj.Invoke(
               GetGridSafeValueMethodName,
               BindingFlags.Static | BindingFlags.NonPublic,
               new object[] { field });

           // Assert
           actual.ShouldBe(expected);
       }

       [TestMethod]
       public void GetGridSafeValue_NameOtherFormatIndicator_ReturnsString()
       {
           // Arrange
           const string value = "10.10";
           const string elementName = "field";
           const string name = "Other";
           const string format = "Indicator";
           const string type = "Other";
           const string expected = "/_layouts/images/10.10";

           var sb = new StringBuilder();
           sb.Append("<xmlcfg>");
           sb.AppendFormat(@"<{0} Name=""{1}"" Format=""{2}"" Type=""{3}"">", elementName, name, format, type);
           sb.AppendFormat("{0}", value);
           sb.AppendFormat("</{0}>", elementName);
           sb.Append("</xmlcfg>");

           var xml = XDocument.Parse(sb.ToString());

           var field = xml.Root.Element(elementName);

           // Act
           var actual = (string)privateObj.Invoke(
               GetGridSafeValueMethodName,
               BindingFlags.Static | BindingFlags.NonPublic,
               new object[] { field });

           // Assert
           actual.ShouldBe(expected);
       }

       [TestMethod]
       public void GetGridSafeValue_NameOtherTypeNumber_ReturnsString()
       {
           // Arrange
           const string value = "10";
           const string elementName = "field";
           const string name = "Other";
           const string format = "some%";
           const string type = "Number";
           const string expected = "1000";

           var sb = new StringBuilder();
           sb.Append("<xmlcfg>");
           sb.AppendFormat(@"<{0} Name=""{1}"" Format=""{2}"" Type=""{3}"">", elementName, name, format, type);
           sb.AppendFormat("{0}", value);
           sb.AppendFormat("</{0}>", elementName);
           sb.Append("</xmlcfg>");

           var xml = XDocument.Parse(sb.ToString());

           var field = xml.Root.Element(elementName);

           ShimSPRegionalSettings.AllInstances.LocaleIdGet = _ => 1033;

           // Act
           var actual = (string)privateObj.Invoke(
               GetGridSafeValueMethodName,
               BindingFlags.Static | BindingFlags.NonPublic,
               new object[] { field });

           // Assert
           actual.ShouldBe(expected);
       }

       [TestMethod]
       public void GetGridSafeValue_NameOtherTypeDate_ReturnsString()
       {
           // Arrange
           const string value = "2018-09-12 18:00:00";
           const string elementName = "field";
           const string name = "Other";
           const string format = "Other";
           const string type = "Date";
           const string expected = "2018-9-12 18:00:00";

           var sb = new StringBuilder();
           sb.Append("<xmlcfg>");
           sb.AppendFormat(@"<{0} Name=""{1}"" Format=""{2}"" Type=""{3}"">", elementName, name, format, type);
           sb.AppendFormat("{0}", value);
           sb.AppendFormat("</{0}>", elementName);
           sb.Append("</xmlcfg>");

           var xml = XDocument.Parse(sb.ToString());

           var field = xml.Root.Element(elementName);

           // Act
           var actual = (string)privateObj.Invoke(
               GetGridSafeValueMethodName,
               BindingFlags.Static | BindingFlags.NonPublic,
               new object[] { field });

           // Assert
           actual.ShouldBe(expected);
       }

       [TestMethod]
       public void GetLeftCols_WhenCalled_ReturnsString()
       {
           // Arrange
           const string input = "Complete:100,CommentCount:100,Priority:100,Other:100";

           var myWorkGridView = new MyWorkGridView()
           {
               LeftCols = input
           };

           // Act
           var actual = ((string)privateObj.Invoke(
               GetLeftColsMethodName,
               BindingFlags.Static | BindingFlags.NonPublic,
               new object[] { myWorkGridView })).Split(',');

           // Assert
           actual.ShouldSatisfyAllConditions(
               () => actual.Length.ShouldBe(4),
               () => actual[0].Split(':')[0].ShouldBe("Complete"),
               () => actual[0].Split(':')[1].ShouldBe("25"),
               () => actual[1].Split(':')[0].ShouldBe("CommentCount"),
               () => actual[1].Split(':')[1].ShouldBe("36"),
               () => actual[2].Split(':')[0].ShouldBe("Priority"),
               () => actual[2].Split(':')[1].ShouldBe("25"),
               () => actual[3].Split(':')[0].ShouldBe("Other"),
               () => actual[3].Split(':')[1].ShouldBe("100"));
       }

       [TestMethod]
       public void GetMyWorkElement_WhenCalled_ReturnsXElement()
       {
           // Arrange
           const string expected = "MyWork";
           var data = string.Format(@"<{0} name=""{0}"">{0}</{0}>", expected);

           // Act
           var actual = (XElement)privateObj.Invoke(
               GetMyWorkElementMethodName,
               BindingFlags.Static | BindingFlags.NonPublic,
               new object[] { data });

           // Assert
           actual.ShouldSatisfyAllConditions(
               () => actual.Name.LocalName.ShouldBe(expected),
               () => actual.Value.ShouldBe(expected),
               () => actual.Attribute("name").Value.ShouldBe(expected));
       }
   **/
    }
}
