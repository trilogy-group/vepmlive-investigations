using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using EPMLiveWebParts.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.JSGrid;
using Microsoft.SharePoint.JSGrid.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPADataCache;
using Shouldly;

namespace EPMLiveWebParts.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class GridDataTests
    {
        private GridData testObject;
        private PrivateObject privateObject;
        private IDisposable shimsContext;
        private BindingFlags publicStatic;
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
        private Guid guid;
        private Hashtable GanttParameters;
        private DateTime currentDateTime;
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
        private const string HierarchyParentKeyString = "HierarchyParentKey";
        private const string KeyString = "Key";
        private const string IdNumberString = "idno";
        private const string RowIdString = "rowid";
        private const string GetListIDMethodName = "GetListID";
        private const string UsePopupMethodName = "UsePopup";
        private const string GetActionMethodName = "GetAction";
        private const string GetGridColumnsMethodName = "GetGridColumns";
        private const string InitGanttParamsMethodName = "InitGanttParams";
        private const string InitializeReqdFieldsMethodName = "InitializeReqdFields";
        private const string AddColumnsMethodName = "AddColumns";
        private const string GetGridFieldsMethodName = "GetGridFields";
        private const string FormatGridFieldMethodName = "formatGridField";
        private const string GetInternalNameMethodName = "GetInternalName";
        private const string GetOrderByFieldMethodName = "GetOrderByField";
        private const string InitRoutineMethodName = "InitRoutine";
        private const string ConvertXmlToDatatableMethodName = "ConvertXmlToDatatable";
        private const string InitializeGanttStartAndFinishMethodName = "InitializeGanttStartAndFinish";
        private const string FinalizeDataMethodName = "FinalizeData";
        private const string AddRowHierarchyMethodName = "AddRowHierarchy";
        private const string AddReqdFieldsToViewMethodName = "AddReqdFieldsToView";
        private const string RemoveReqdFieldsFromViewMethodName = "RemoveReqdFieldsFromView";
        private const string InitializeColumnDefsMethodName = "InitializeColumnDefs";

        [TestInitialize]
        public void Setup()
        {
            testObject = new GridData();
            privateObject = new PrivateObject(testObject);

            SetupShims();

            privateObject.SetFieldOrProperty("_spList", nonPublicInstance, spList.Instance);
            privateObject.SetFieldOrProperty("_spView", nonPublicInstance, spView.Instance);
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
            ShimComponent.AllInstances.Dispose = _ => { };
            ShimSqlCommand.AllInstances.TransactionSetSqlTransaction = (_, __) => { };
            ShimSPDatabase.AllInstances.DatabaseConnectionStringGet = _ => DummyString;
            ShimGridGanttSettings.ConstructorSPList = (_, __) => new ShimGridGanttSettings();
            ShimHttpUtility.HtmlEncodeString = input => input;
            ShimSPSite.ConstructorString = (_, __) => new ShimSPSite();
            ShimSPSite.ConstructorGuid = (_, __) => new ShimSPSite();
            ShimSPSite.ConstructorGuidSPUserToken = (_, _1, _2) => new ShimSPSite();
            ShimSPSite.AllInstances.AllWebsGet = _ => new ShimSPWebCollection();
            ShimSPSite.AllInstances.OpenWeb = _ => spWeb;
            ShimSPSite.AllInstances.OpenWebString = (_, __) => spWeb;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => spWeb;
            ShimSPSite.AllInstances.Dispose = _ => { };
            ShimSPWeb.AllInstances.Dispose = _ => { };
            ShimSPWebCollection.AllInstances.ItemGetGuid = (_, __) => spWeb;
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
        }

        private void SetupVariables()
        {
            validations = 0;
            publicStatic = BindingFlags.Static | BindingFlags.Public;
            publicInstance = BindingFlags.Instance | BindingFlags.Public;
            nonPublicInstance = BindingFlags.Instance | BindingFlags.NonPublic;
            guid = Guid.Parse(SampleGuidString1);
            currentDateTime = DateTime.Now;
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
                GetListFromUrlString = _ => spList,
                Update = () => { }
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
                DefaultViewUrlGet = () => SampleUrl,
                Update = () => { }
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
                TypeAsStringGet = () => DummyString,
                DescriptionGet = () => DummyString
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
                Update = () => { }
            };
            spViewFieldCollection = new ShimSPViewFieldCollection()
            {
                ToStringCollection = () => new StringCollection()
            };
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
            GanttParameters = new Hashtable();
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void GetListID_WhenCalled_ReturnsListId()
        {
            // Arrange and  Act
            var actual = (Guid)privateObject.Invoke(
                GetListIDMethodName,
                publicStatic,
                new object[]
                {
                    guid,
                    guid,
                    DummyString
                });

            // Assert
            actual.Equals(guid).ShouldBeTrue();
        }

        [TestMethod]
        public void UsePopup_WhenCalled_ReturnsUsePopupValueFromHashTable()
        {
            // Arrange
            GanttParameters.Add("UsePopup", DummyString);
            privateObject.SetFieldOrProperty("_htGanttParams", nonPublicInstance, GanttParameters);

            // Act
            var actual = (string)privateObject.Invoke(UsePopupMethodName, publicInstance, new object[] { });

            // Assert
            actual.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetAction_WhenCalled_ReturnsLTypeValueFromHashTable()
        {
            // Arrange
            GanttParameters.Add("LType", DummyString);
            privateObject.SetFieldOrProperty("_htGanttParams", nonPublicInstance, GanttParameters);

            // Act
            var actual = (string)privateObject.Invoke(GetActionMethodName, publicInstance, new object[] { });

            // Assert
            actual.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetGridColumns_WhenCalled_ReturnsListOfGridColumn()
        {
            // Arrange
            var fields = new StringCollection()
            {
                DummyString
            };
            var dataTable = new DataTable();
            var gridColumns = new List<GridColumn>();

            dataTable.Columns.Add("Edit");
            dataTable.Columns.Add(DummyString);

            ShimGridData.AllInstances.GetInternalNameString = (_, input) => input;
            ShimGridData.AllInstances.GetDisplayNameString = (_, input) => input;

            privateObject.SetFieldOrProperty("_spvwFields", nonPublicInstance, fields);

            // Act
            gridColumns.AddRange((IList<GridColumn>)privateObject.Invoke(GetGridColumnsMethodName, publicInstance, new object[] { dataTable }));
            var editColumn = gridColumns.FirstOrDefault(x => x.FieldKey.Equals("Edit"));
            var dummyColumn = gridColumns.FirstOrDefault(x => x.FieldKey.Equals(DummyString));

            // Assert
            gridColumns.ShouldSatisfyAllConditions(
                () => gridColumns.Count.ShouldBe(Two),
                () => editColumn.IsVisible.ShouldBeFalse(),
                () => editColumn.IsSortable.ShouldBeTrue(),
                () => editColumn.IsAutoFilterable.ShouldBeTrue(),
                () => editColumn.Width.ShouldBe(50),
                () => dummyColumn.Width.ShouldBe(100));
        }

        [TestMethod]
        public void InitGanttParams_WhenCalled_InitializeGanttParametersFromHashTable()
        {
            // Arrange
            var now = DateTime.Now;

            GanttParameters.Add("Start", now);
            GanttParameters.Add("Finish", now);
            GanttParameters.Add("Percent", One);
            GanttParameters.Add("Milestone", Two);
            GanttParameters.Add("WBS", DummyString);

            privateObject.SetFieldOrProperty("_htGanttParams", nonPublicInstance, GanttParameters);

            // Act
            privateObject.Invoke(InitGanttParamsMethodName, nonPublicInstance, new object[] { });

            // Assert
            GanttParameters.ShouldSatisfyAllConditions(
                () => testObject.GanttStartField.ShouldBe(now.ToString()),
                () => testObject.GanttFinishField.ShouldBe(now.ToString()),
                () => testObject.PctComplete.ShouldBe(One.ToString()),
                () => testObject.GanttMilestone.ShouldBe(Two.ToString()),
                () => testObject.WBS.ShouldBe(DummyString));
        }

        [TestMethod]
        public void InitializeReqdFields_WhenCalled_InitializeGanttParametersFromHashTable()
        {
            // Arrange
            spFieldCollection.ContainsFieldString = _ => true;

            // Act
            privateObject.Invoke(InitializeReqdFieldsMethodName, nonPublicInstance, new object[] { });
            var requiredFields = (List<string>)privateObject.GetFieldOrProperty("_reqdfields", nonPublicInstance);

            // Assert
            GanttParameters.ShouldSatisfyAllConditions(
                () => requiredFields.Count.ShouldBe(9),
                () => requiredFields.Contains("Predecessors").ShouldBeTrue(),
                () => requiredFields.Contains("Critical").ShouldBeTrue());
        }

        [TestMethod]
        public void AddColumns_WhenCalled_AddsDefaultColumnsToDataTable()
        {
            // Arrange
            var row = default(DataRow);
            var dataTable = new DataTable();

            dataTable.Columns.Add("DisplayName");
            dataTable.Columns.Add("IsImage");
            dataTable.Columns.Add("ColumnType");
            dataTable.Columns.Add("InternalName");
            row = dataTable.NewRow();
            row["DisplayName"] = DummyString;
            row["IsImage"] = "true";
            dataTable.Rows.Add(row);

            privateObject.SetFieldOrProperty("_columnDefinitions", nonPublicInstance, dataTable);

            // Act
            var actual = (DataTable)privateObject.Invoke(AddColumnsMethodName, nonPublicInstance, new object[] { dataTable });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Columns.Count.ShouldBe(25),
                () => actual.Rows.Count.ShouldBe(21));
        }

        [TestMethod]
        public void GetGridFields_WhenCalled_ReturnsGridFieldsList()
        {
            // Arrange
            var imageColumns = new List<string>()
            {
                One.ToString(),
                Two.ToString(),
                Three.ToString(),
            };
            var formatGridHit = 0;
            var ganttImageHit = 0;
            var row = default(DataRow);
            var dataTable = new DataTable();

            dataTable.Columns.Add(One.ToString());
            dataTable.Columns.Add(Two.ToString());
            dataTable.Columns.Add(Three.ToString());
            row = dataTable.NewRow();
            dataTable.Rows.Add(row);

            ShimGridData.AllInstances.formatGridFieldGridFieldDataColumn = (_, _1, _2) =>
            {
                formatGridHit += 1;
                var result = new GridField()
                {
                    FieldKey = formatGridHit.ToString()
                };
                if (formatGridHit.Equals(One))
                {
                    result.DefaultCellStyleId = DummyString;
                }
                else if (formatGridHit.Equals(Three))
                {
                    result.DefaultCellStyleId = null;
                }
                return result;
            };
            ShimGanttUtilities.GanttImageHashtableListOfString = (_1, _2) =>
            {
                ganttImageHit += 1;
                if (ganttImageHit.Equals(One) || ganttImageHit.Equals(Four))
                {
                    return null;
                }
                return new LookupTypeInfo(DummyString, new List<LookupTypeItem>());
            };
            ShimGridField.AllInstances.AssociateWithLookupTypeInfoLookupTypeInfo = (_, _1) =>
            {
                validations += 1;
            };
            ShimGridData.AllInstances.GetInternalNameString = (_, input) =>
            {
                validations += 1;
                return input;
            };

            privateObject.SetFieldOrProperty("_imageColumns", nonPublicInstance, imageColumns);

            // Act
            var actual = (List<GridField>)privateObject.Invoke(GetGridFieldsMethodName, publicInstance, new object[] { dataTable });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(Three),
                () => actual.FirstOrDefault(x => x.FieldKey.Equals(One.ToString())).DefaultCellStyleId.ShouldBe("ralign"),
                () => actual.FirstOrDefault(x => x.FieldKey.Equals(Two.ToString())).DefaultCellStyleId.ShouldBe("halign"),
                () => actual.FirstOrDefault(x => x.FieldKey.Equals(Three.ToString())).DefaultCellStyleId.ShouldBe("ralign"),
                () => formatGridHit.ShouldBe(Three),
                () => ganttImageHit.ShouldBe(Four),
                () => validations.ShouldBe(Four));
        }

        [TestMethod]
        public void FormatGridField_ColumnDataTypeString_ReturnsGridField()
        {
            // Arrange
            const string expected = "String";
            const string columnName = "Quarter";
            var columnType = typeof(String);
            var dataTable = new DataTable();
            var dataColumn = default(DataColumn);
            var field = new GridField()
            {
                DefaultCellStyleId = DummyString
            };
            var fieldNames = new List<string>()
            {
                "master_checkbox2"
            };
            var viewFields = new StringCollection()
            {
                "linktitle",
                "LinkTitleVersionNoMenu"
            };

            dataTable.Columns.Add(DummyString, columnType);
            dataTable.Columns.Add(columnName, columnType);
            dataColumn = dataTable.Columns[One];

            ShimGridData.AllInstances.GetInternalNameString = (_, input) =>
            {
                validations += 1;
                return input;
            };

            privateObject.SetFieldOrProperty("_spvwFields", nonPublicInstance, viewFields);
            privateObject.SetFieldOrProperty("_fieldNames", nonPublicInstance, fieldNames);

            // Act
            var actual = (GridField)privateObject.Invoke(FormatGridFieldMethodName, nonPublicInstance, new object[] { field, dataColumn });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.DefaultCellStyleId.ShouldBe("link"),
                () => actual.EditMode.ShouldBe(EditMode.ReadOnly),
                () => actual.TextDirection.ShouldBe(TextDirection.LeftToRight),
                () => actual.PropertyTypeId.ShouldBe(expected),
                () => actual.FieldKey.ShouldBe(columnName),
                () => actual.SerializeLocalizedValue.ShouldBeTrue(),
                () => actual.SerializeDataValue.ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void FormatGridField_ColumnDataTypeInt_ReturnsGridField()
        {
            // Arrange
            const string expected = "JSNumber";
            const string columnName = "costq";
            var columnType = typeof(Int32);
            var dataTable = new DataTable();
            var dataColumn = default(DataColumn);
            var field = new GridField()
            {
                DefaultCellStyleId = DummyString
            };
            var fieldNames = new List<string>()
            {
                "master_checkbox2"
            };
            var viewFields = new StringCollection()
            {
                "linktitle",
                "LinkTitleVersionNoMenu"
            };

            dataTable.Columns.Add(DummyString, columnType);
            dataTable.Columns.Add(columnName, columnType);
            dataColumn = dataTable.Columns[One];

            ShimGridData.AllInstances.GetInternalNameString = (_, input) =>
            {
                validations += 1;
                return input;
            };

            privateObject.SetFieldOrProperty("_spvwFields", nonPublicInstance, viewFields);
            privateObject.SetFieldOrProperty("_fieldNames", nonPublicInstance, fieldNames);

            // Act
            var actual = (GridField)privateObject.Invoke(FormatGridFieldMethodName, nonPublicInstance, new object[] { field, dataColumn });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.DefaultCellStyleId.ShouldBe("link"),
                () => actual.EditMode.ShouldBe(EditMode.ReadOnly),
                () => actual.TextDirection.ShouldBe(TextDirection.LeftToRight),
                () => actual.PropertyTypeId.ShouldBe(expected),
                () => actual.FieldKey.ShouldBe(columnName),
                () => actual.SerializeLocalizedValue.ShouldBeTrue(),
                () => actual.SerializeDataValue.ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void FormatGridField_ColumnDataTypeLookupTypeItem_ReturnsGridField()
        {
            // Arrange
            const string expected = "GanttImage";
            const string columnName = "Quarter";
            var columnType = typeof(LookupTypeItem);
            var dataTable = new DataTable();
            var dataColumn = default(DataColumn);
            var field = new GridField()
            {
                DefaultCellStyleId = DummyString
            };
            var fieldNames = new List<string>()
            {
                "master_checkbox2"
            };
            var viewFields = new StringCollection()
            {
                "linktitle",
                "LinkTitleVersionNoMenu"
            };

            dataTable.Columns.Add(DummyString, columnType);
            dataTable.Columns.Add(columnName, columnType);
            dataColumn = dataTable.Columns[One];

            ShimGridData.AllInstances.GetInternalNameString = (_, input) =>
            {
                validations += 1;
                return input;
            };

            privateObject.SetFieldOrProperty("_spvwFields", nonPublicInstance, viewFields);
            privateObject.SetFieldOrProperty("_fieldNames", nonPublicInstance, fieldNames);

            // Act
            var actual = (GridField)privateObject.Invoke(FormatGridFieldMethodName, nonPublicInstance, new object[] { field, dataColumn });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.DefaultCellStyleId.ShouldBe("link"),
                () => actual.EditMode.ShouldBe(EditMode.ReadOnly),
                () => actual.TextDirection.ShouldBe(TextDirection.LeftToRight),
                () => actual.PropertyTypeId.ShouldBe(expected),
                () => actual.FieldKey.ShouldBe(columnName),
                () => actual.SerializeLocalizedValue.ShouldBeTrue(),
                () => actual.SerializeDataValue.ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void FormatGridField_ColumnDataTypeHyperlink_ReturnsGridField()
        {
            // Arrange
            const string expected = "Hyperlink";
            const string columnName = "Quarter";
            var columnType = typeof(Hyperlink);
            var dataTable = new DataTable();
            var dataColumn = default(DataColumn);
            var field = new GridField()
            {
                DefaultCellStyleId = DummyString
            };
            var fieldNames = new List<string>()
            {
                "master_checkbox2"
            };
            var viewFields = new StringCollection()
            {
                "linktitle",
                "LinkTitleVersionNoMenu"
            };

            dataTable.Columns.Add(DummyString, columnType);
            dataTable.Columns.Add(columnName, columnType);
            dataColumn = dataTable.Columns[One];

            ShimGridData.AllInstances.GetInternalNameString = (_, input) =>
            {
                validations += 1;
                return input;
            };

            privateObject.SetFieldOrProperty("_spvwFields", nonPublicInstance, viewFields);
            privateObject.SetFieldOrProperty("_fieldNames", nonPublicInstance, fieldNames);

            // Act
            var actual = (GridField)privateObject.Invoke(FormatGridFieldMethodName, nonPublicInstance, new object[] { field, dataColumn });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.DefaultCellStyleId.ShouldBe("link"),
                () => actual.EditMode.ShouldBe(EditMode.ReadOnly),
                () => actual.TextDirection.ShouldBe(TextDirection.LeftToRight),
                () => actual.PropertyTypeId.ShouldBe(expected),
                () => actual.FieldKey.ShouldBe(columnName),
                () => actual.SerializeLocalizedValue.ShouldBeFalse(),
                () => actual.SerializeDataValue.ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void FormatGridField_ColumnDataTypeBoolean_ReturnsGridField()
        {
            // Arrange
            const string expected = "CheckBoxBoolean";
            const string columnName = "Quarter";
            var columnType = typeof(bool);
            var dataTable = new DataTable();
            var dataColumn = default(DataColumn);
            var field = new GridField()
            {
                DefaultCellStyleId = DummyString
            };
            var fieldNames = new List<string>()
            {
                "master_checkbox2"
            };
            var viewFields = new StringCollection()
            {
                "linktitle",
                "LinkTitleVersionNoMenu"
            };

            dataTable.Columns.Add(DummyString, columnType);
            dataTable.Columns.Add(columnName, columnType);
            dataColumn = dataTable.Columns[One];

            ShimGridData.AllInstances.GetInternalNameString = (_, input) =>
            {
                validations += 1;
                return input;
            };

            privateObject.SetFieldOrProperty("_spvwFields", nonPublicInstance, viewFields);
            privateObject.SetFieldOrProperty("_fieldNames", nonPublicInstance, fieldNames);

            // Act
            var actual = (GridField)privateObject.Invoke(FormatGridFieldMethodName, nonPublicInstance, new object[] { field, dataColumn });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.DefaultCellStyleId.ShouldBe("link"),
                () => actual.EditMode.ShouldBe(EditMode.ReadOnly),
                () => actual.TextDirection.ShouldBe(TextDirection.LeftToRight),
                () => actual.PropertyTypeId.ShouldBe(expected),
                () => actual.FieldKey.ShouldBe(columnName),
                () => actual.SerializeLocalizedValue.ShouldBeFalse(),
                () => actual.SerializeDataValue.ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void FormatGridField_ColumnDataTypeDateTime_ReturnsGridField()
        {
            // Arrange
            const string expected = "JSDateTime";
            const string columnName = "Quarter";
            var columnType = typeof(DateTime);
            var dataTable = new DataTable();
            var dataColumn = default(DataColumn);
            var field = new GridField()
            {
                DefaultCellStyleId = DummyString
            };
            var fieldNames = new List<string>()
            {
                "master_checkbox2"
            };
            var viewFields = new StringCollection()
            {
                "linktitle",
                "LinkTitleVersionNoMenu"
            };

            dataTable.Columns.Add(DummyString, columnType);
            dataTable.Columns.Add(columnName, columnType);
            dataColumn = dataTable.Columns[One];

            ShimGridData.AllInstances.GetInternalNameString = (_, input) =>
            {
                validations += 1;
                return input;
            };

            privateObject.SetFieldOrProperty("_spvwFields", nonPublicInstance, viewFields);
            privateObject.SetFieldOrProperty("_fieldNames", nonPublicInstance, fieldNames);

            // Act
            var actual = (GridField)privateObject.Invoke(FormatGridFieldMethodName, nonPublicInstance, new object[] { field, dataColumn });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.DefaultCellStyleId.ShouldBe("link"),
                () => actual.EditMode.ShouldBe(EditMode.ReadOnly),
                () => actual.TextDirection.ShouldBe(TextDirection.LeftToRight),
                () => actual.PropertyTypeId.ShouldBe(expected),
                () => actual.FieldKey.ShouldBe(columnName),
                () => actual.SerializeLocalizedValue.ShouldBeTrue(),
                () => actual.SerializeDataValue.ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void FormatGridField_ColumnDataTypeGuid_ReturnsGridField()
        {
            // Arrange
            const string expected = "String";
            const string columnName = "Quarter";
            var columnType = typeof(Guid);
            var dataTable = new DataTable();
            var dataColumn = default(DataColumn);
            var field = new GridField()
            {
                DefaultCellStyleId = DummyString
            };
            var fieldNames = new List<string>()
            {
                "master_checkbox2"
            };
            var viewFields = new StringCollection()
            {
                "linktitle",
                "LinkTitleVersionNoMenu"
            };

            dataTable.Columns.Add(DummyString, columnType);
            dataTable.Columns.Add(columnName, columnType);
            dataColumn = dataTable.Columns[One];

            ShimGridData.AllInstances.GetInternalNameString = (_, input) =>
            {
                validations += 1;
                return input;
            };

            privateObject.SetFieldOrProperty("_spvwFields", nonPublicInstance, viewFields);
            privateObject.SetFieldOrProperty("_fieldNames", nonPublicInstance, fieldNames);

            // Act
            var actual = (GridField)privateObject.Invoke(FormatGridFieldMethodName, nonPublicInstance, new object[] { field, dataColumn });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.DefaultCellStyleId.ShouldBe("link"),
                () => actual.EditMode.ShouldBe(EditMode.ReadOnly),
                () => actual.TextDirection.ShouldBe(TextDirection.LeftToRight),
                () => actual.PropertyTypeId.ShouldBe(expected),
                () => actual.FieldKey.ShouldBe(columnName),
                () => actual.SerializeLocalizedValue.ShouldBeTrue(),
                () => actual.SerializeDataValue.ShouldBeFalse(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void FormatGridField_ColumnDataTypeDouble_ReturnsGridField()
        {
            // Arrange
            const string expected = "JSNumber";
            const string columnName = "Quarter";
            var columnType = typeof(Double);
            var dataTable = new DataTable();
            var dataColumn = default(DataColumn);
            var field = new GridField()
            {
                DefaultCellStyleId = DummyString
            };
            var fieldNames = new List<string>()
            {
                "master_checkbox2"
            };
            var viewFields = new StringCollection()
            {
                "linktitle",
                "LinkTitleVersionNoMenu"
            };

            dataTable.Columns.Add(DummyString, columnType);
            dataTable.Columns.Add(columnName, columnType);
            dataColumn = dataTable.Columns[One];

            ShimGridData.AllInstances.GetInternalNameString = (_, input) =>
            {
                validations += 1;
                return input;
            };

            privateObject.SetFieldOrProperty("_spvwFields", nonPublicInstance, viewFields);
            privateObject.SetFieldOrProperty("_fieldNames", nonPublicInstance, fieldNames);

            // Act
            var actual = (GridField)privateObject.Invoke(FormatGridFieldMethodName, nonPublicInstance, new object[] { field, dataColumn });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.DefaultCellStyleId.ShouldBe("link"),
                () => actual.EditMode.ShouldBe(EditMode.ReadOnly),
                () => actual.TextDirection.ShouldBe(TextDirection.LeftToRight),
                () => actual.PropertyTypeId.ShouldBe(expected),
                () => actual.FieldKey.ShouldBe(columnName),
                () => actual.SerializeLocalizedValue.ShouldBeTrue(),
                () => actual.SerializeDataValue.ShouldBeFalse(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void GetInternalName_WhenCalled_ReturnsInternalName()
        {
            // Arrange
            spFieldCollection.ContainsFieldString = _ =>
            {
                validations += 1;
                return true;
            };

            // Act
            var actual = (string)privateObject.Invoke(GetInternalNameMethodName, nonPublicInstance, new object[] { string.Empty });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(DummyString),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void GetOrderByField_WbsFieldEqualsWBS_ReturnsWbs()
        {
            // Arrange
            const string wbs = "WBS";
            const string title = "Task Center";

            spList.TitleGet = () =>
            {
                validations += 1;
                return title;
            };
            spView.QueryGet = () =>
            {
                validations += 1;
                return string.Empty;
            };

            privateObject.SetFieldOrProperty("_spList", nonPublicInstance, spList.Instance);
            privateObject.SetFieldOrProperty("_spView", nonPublicInstance, spView.Instance);
            privateObject.SetFieldOrProperty("_wbs", nonPublicInstance, wbs);

            // Act
            var actual = (string)privateObject.Invoke(GetOrderByFieldMethodName, nonPublicInstance, new object[] { });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(wbs),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void GetOrderByField_WbsFieldNotEqualsWBS_ReturnsWbs()
        {
            // Arrange
            const string wbs = "NotWBS";
            const string title = "Task Center";
            const string expected = "Outline Number";
            const string query = @"
                <OrderBy>
                    <Field Name=""FieldName""/>
                </OrderBy>";

            spList.TitleGet = () =>
            {
                validations += 1;
                return title;
            };

            spView.QueryGet = () =>
            {
                validations += 1;
                return query;
            };

            privateObject.SetFieldOrProperty("_spList", nonPublicInstance, spList.Instance);
            privateObject.SetFieldOrProperty("_spView", nonPublicInstance, spView.Instance);
            privateObject.SetFieldOrProperty("_wbs", nonPublicInstance, wbs);

            // Act
            var actual = (string)privateObject.Invoke(GetOrderByFieldMethodName, nonPublicInstance, new object[] { });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void GetOrderByField_WbsFieldEmpty_ReturnsWbs()
        {
            // Arrange
            const string expected = "Task ID";
            const string title = "Task Center";

            spList.TitleGet = () =>
            {
                validations += 1;
                return title;
            };
            spView.QueryGet = () =>
            {
                validations += 1;
                return string.Empty;
            };

            privateObject.SetFieldOrProperty("_spList", nonPublicInstance, spList.Instance);
            privateObject.SetFieldOrProperty("_spView", nonPublicInstance, spView.Instance);
            privateObject.SetFieldOrProperty("_wbs", nonPublicInstance, string.Empty);

            // Act
            var actual = (string)privateObject.Invoke(GetOrderByFieldMethodName, nonPublicInstance, new object[] { });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void InitRoutine_UrlPresent_InitiaizesRoutine()
        {
            // Arrange
            var stringArray = new string[]
            {
                SampleUrl
            };
            var parameters = new object[]
            {
                true
            };

            GanttParameters.Add("List", DummyString);
            GanttParameters.Add("View", DummyString);

            spSite.UrlGet = () => SampleUrl;

            ShimGridData.AllInstances.InitGanttParamsString = (_, __) =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("_spList", nonPublicInstance, null);
            privateObject.SetFieldOrProperty("_spView", nonPublicInstance, null);
            privateObject.SetFieldOrProperty("_htGanttParams", nonPublicInstance, GanttParameters);
            privateObject.SetFieldOrProperty("_rollupLists", nonPublicInstance, stringArray);
            privateObject.SetFieldOrProperty("_rollupSites", nonPublicInstance, stringArray);

            // Act
            privateObject.Invoke(InitRoutineMethodName, publicInstance, parameters);
            var list = privateObject.GetFieldOrProperty("_spList", nonPublicInstance);
            var view = privateObject.GetFieldOrProperty("_spView", nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => list.ShouldNotBeNull(),
                () => view.ShouldNotBeNull(),
                () => ((bool)parameters[0]).ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void InitRoutine_UrlNotPresent_InitiaizesRoutine()
        {
            // Arrange
            var stringArray = new string[]
            {
                DummyString
            };
            var parameters = new object[]
            {
                true
            };

            GanttParameters.Add("List", DummyString);
            GanttParameters.Add("View", DummyString);

            spSite.UrlGet = () => SampleUrl;

            ShimGridData.AllInstances.InitGanttParamsString = (_, __) =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("_spList", nonPublicInstance, null);
            privateObject.SetFieldOrProperty("_spView", nonPublicInstance, null);
            privateObject.SetFieldOrProperty("_htGanttParams", nonPublicInstance, GanttParameters);
            privateObject.SetFieldOrProperty("_rollupLists", nonPublicInstance, stringArray);
            privateObject.SetFieldOrProperty("_rollupSites", nonPublicInstance, stringArray);

            // Act
            privateObject.Invoke(InitRoutineMethodName, publicInstance, parameters);
            var list = privateObject.GetFieldOrProperty("_spList", nonPublicInstance);
            var view = privateObject.GetFieldOrProperty("_spView", nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => list.ShouldNotBeNull(),
                () => view.ShouldNotBeNull(),
                () => ((bool)parameters[0]).ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void InitRoutine_RollUpSitesNull_InitiaizesRoutine()
        {
            // Arrange
            var stringArray = new string[]
            {
                DummyString
            };
            var parameters = new object[]
            {
                true
            };

            GanttParameters.Add("List", DummyString);
            GanttParameters.Add("View", DummyString);

            spSite.UrlGet = () => SampleUrl;

            ShimGridData.AllInstances.InitGanttParamsString = (_, __) =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("_spList", nonPublicInstance, null);
            privateObject.SetFieldOrProperty("_spView", nonPublicInstance, null);
            privateObject.SetFieldOrProperty("_htGanttParams", nonPublicInstance, GanttParameters);
            privateObject.SetFieldOrProperty("_rollupLists", nonPublicInstance, stringArray);
            privateObject.SetFieldOrProperty("_rollupSites", nonPublicInstance, null);
            privateObject.SetFieldOrProperty("_useCurrent", nonPublicInstance, false);

            // Act
            privateObject.Invoke(InitRoutineMethodName, publicInstance, parameters);
            var list = privateObject.GetFieldOrProperty("_spList", nonPublicInstance);
            var view = privateObject.GetFieldOrProperty("_spView", nonPublicInstance);
            var rollupSites = (string[])privateObject.GetFieldOrProperty("_rollupSites", nonPublicInstance);
            var useCurrent = (bool)privateObject.GetFieldOrProperty("_useCurrent", nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => list.ShouldNotBeNull(),
                () => view.ShouldNotBeNull(),
                () => ((bool)parameters[0]).ShouldBeTrue(),
                () => rollupSites.Length.ShouldBe(1),
                () => rollupSites[0].ShouldBe(SampleUrl),
                () => useCurrent.ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void InitRoutine_RollupListsNull_InitiaizesRoutine()
        {
            // Arrange
            var stringArray = new string[]
            {
                DummyString
            };
            var parameters = new object[]
            {
                true
            };

            GanttParameters.Add("List", DummyString);
            GanttParameters.Add("View", DummyString);

            spSite.UrlGet = () => SampleUrl;

            ShimGridData.AllInstances.InitGanttParamsString = (_, __) =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("_spList", nonPublicInstance, null);
            privateObject.SetFieldOrProperty("_spView", nonPublicInstance, null);
            privateObject.SetFieldOrProperty("_htGanttParams", nonPublicInstance, GanttParameters);
            privateObject.SetFieldOrProperty("_rollupLists", nonPublicInstance, null);
            privateObject.SetFieldOrProperty("_rollupSites", nonPublicInstance, null);

            // Act
            privateObject.Invoke(InitRoutineMethodName, publicInstance, parameters);
            var list = privateObject.GetFieldOrProperty("_spList", nonPublicInstance);
            var view = privateObject.GetFieldOrProperty("_spView", nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => list.ShouldNotBeNull(),
                () => view.ShouldNotBeNull(),
                () => ((bool)parameters[0]).ShouldBeFalse(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void ConvertXmlToDatatable_WhenCalled_ReturnsDataTable()
        {
            // Arrange
            ShimGridData.AllInstances.InitializeColumnDefsString = (_, __) =>
            {
                validations += 1;
            };
            ShimGridData.AllInstances.AddColumnsDataTable = (_, input) =>
            {
                validations += 1;
                return input;
            };
            ShimGridData.AllInstances.LoadDataDataTable = (_, __) =>
            {
                validations += 1;
            };
            ShimGridData.AllInstances.FinalizeDataDataTable = (_, __) =>
            {
                validations += 1;
            };
            ShimGridData.AllInstances.InitializeGanttStartAndFinishDataTable = (_, __) =>
            {
                validations += 1;
            };

            // Act
            var actual = (DataTable)privateObject.Invoke(ConvertXmlToDatatableMethodName, nonPublicInstance, new object[] { DummyString });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldNotBeNull(),
                () => validations.ShouldBe(5));
        }

        [TestMethod]
        public void InitializeGanttStartAndFinish_WhenCalled_InitializesGanttStartAndFinish()
        {
            // Arrange
            currentDateTime = currentDateTime.Date;

            var row = default(DataRow);
            var dataTable = new DataTable();
            var rows = new string[]
            {
                currentDateTime.AddDays(-1).ToString(),
                currentDateTime.AddDays(-2).ToString(),
                currentDateTime.ToString(),
                currentDateTime.AddDays(1).ToString(),
                currentDateTime.AddDays(2).ToString()
            };

            dataTable.Columns.Add(DummyString);
            foreach (var item in rows)
            {
                row = dataTable.NewRow();
                row[DummyString] = item;
                dataTable.Rows.Add(row);
            }

            spFieldCollection.ContainsFieldString = _ => true;
            privateObject.SetFieldOrProperty("GanttStartField", publicInstance, DummyString);
            privateObject.SetFieldOrProperty("GanttFinishField", publicInstance, DummyString);

            // Act
            privateObject.Invoke(InitializeGanttStartAndFinishMethodName, nonPublicInstance, new object[] { dataTable });
            var startDate = privateObject.GetFieldOrProperty("_ganttStartDate", nonPublicInstance);
            var finishDate = privateObject.GetFieldOrProperty("_ganttFinishDate", nonPublicInstance);

            // Assert
            startDate.ShouldSatisfyAllConditions(
                () => startDate.ShouldBe(currentDateTime.AddDays(-2)),
                () => finishDate.ShouldBe(currentDateTime.AddDays(2)));
        }

        [TestMethod]
        public void FinalizeData_WhenCalled_FinalizesData()
        {
            // Arrange
            const string expected = "1,2,3";
            var row = default(DataRow);
            var dataTable = new DataTable();
            var nodeData = new Hashtable()
            {
                [Zero] = default(XmlNode),
                [One] = default(XmlNode)
            };
            var addRowPredecessors = 0;
            var images = new List<string>()
            {
                One.ToString(),
                Two.ToString(),
                Three.ToString(),
            };

            dataTable.Columns.Add(HierarchyParentKeyString, typeof(int));
            dataTable.Columns.Add(KeyString, typeof(int));

            row = dataTable.NewRow();
            row[HierarchyParentKeyString] = Zero;
            row[KeyString] = One;
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row[HierarchyParentKeyString] = One;
            row[KeyString] = Two;
            dataTable.Rows.Add(row);

            ShimGridData.AllInstances.AddRowHierarchyDataRowDataTableXmlNode = (_, rowInput, table, node) =>
            {
                validations += 1;
            };
            ShimGridData.AllInstances.AddRowPredecessorsDataRowDataTable = (_, rowInput, table) =>
            {
                addRowPredecessors += 1;
                if ((int)rowInput[HierarchyParentKeyString] == (int)rowInput[KeyString])
                {
                    validations += 1;
                }
            };
            ShimGanttUtilities.ImageNamesSetListOfString = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("_htNodeData", nonPublicInstance, nodeData);
            privateObject.SetFieldOrProperty("_images", nonPublicInstance, images);
            privateObject.SetFieldOrProperty("_imagesClientSide", nonPublicInstance, string.Empty);

            // Act
            privateObject.Invoke(FinalizeDataMethodName, nonPublicInstance, new object[] { dataTable });
            var actual = privateObject.GetFieldOrProperty("_imagesClientSide", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => addRowPredecessors.ShouldBe(2),
                () => validations.ShouldBe(3));
        }

        [TestMethod]
        public void AddRowHierarchy_ParentNotRows_EditsDataRow()
        {
            // Arrange
            const string xmlString = @"
                <xmlcfg id=""2"">
                    <row/>
                </xmlcfg>";
            var dataXml = new XmlDocument();
            var node = default(XmlNode);
            var row = default(DataRow);
            var dataTable = new DataTable();

            dataTable.Columns.Add(HierarchyParentKeyString, typeof(int));
            dataTable.Columns.Add(KeyString, typeof(int));
            dataTable.Columns.Add(IdNumberString, typeof(int));
            dataTable.Columns.Add(RowIdString, typeof(int));

            row = dataTable.NewRow();
            row[HierarchyParentKeyString] = Zero;
            row[KeyString] = Two;
            row[IdNumberString] = Two;
            row[RowIdString] = Two;
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row[HierarchyParentKeyString] = Zero;
            row[KeyString] = One;
            row[IdNumberString] = One;
            row[RowIdString] = One;

            dataXml.LoadXml(xmlString);
            node = dataXml.FirstChild.FirstChild;

            var parameters = new object[]
            {
                row,
                dataTable,
                node
            };

            // Act
            privateObject.Invoke(AddRowHierarchyMethodName, nonPublicInstance, parameters);
            var actual = (DataRow)parameters[0];

            // Assert
            actual[HierarchyParentKeyString].ToString().ShouldBe(Two.ToString());
        }

        [TestMethod]
        public void AddRowHierarchy_ParentRows_EditsDataRow()
        {
            // Arrange
            const string xmlString = @"
                <rows id=""2"">
                    <row/>
                </rows>";
            var dataXml = new XmlDocument();
            var node = default(XmlNode);
            var row = default(DataRow);
            var dataTable = new DataTable();

            dataTable.Columns.Add(HierarchyParentKeyString, typeof(int));
            dataTable.Columns.Add(KeyString, typeof(int));
            dataTable.Columns.Add(IdNumberString, typeof(int));
            dataTable.Columns.Add(RowIdString, typeof(int));

            row = dataTable.NewRow();
            row[HierarchyParentKeyString] = Zero;
            row[KeyString] = Two;
            row[IdNumberString] = Two;
            row[RowIdString] = Two;
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row[HierarchyParentKeyString] = Zero;
            row[KeyString] = One;
            row[IdNumberString] = One;
            row[RowIdString] = One;

            dataXml.LoadXml(xmlString);
            node = dataXml.FirstChild.FirstChild;

            var parameters = new object[]
            {
                row,
                dataTable,
                node
            };

            // Act
            privateObject.Invoke(AddRowHierarchyMethodName, nonPublicInstance, parameters);
            var actual = (DataRow)parameters[0];

            // Assert
            actual[HierarchyParentKeyString].ToString().ShouldBe(One.ToString());
        }

        [TestMethod]
        public void AddReqdFieldsToView_WhenCalled_ReturnsSPWeb()
        {
            // Arrange
            var stringCollection = new StringCollection()
            {
                DummyString
            };
            var requiredFields = new List<string>()
            {
                DummyString,
                One.ToString()
            };

            GanttParameters.Add("List", DummyString);
            GanttParameters.Add("View", DummyString);

            spFieldCollection.ContainsFieldString = _ => true;
            spWeb.AllowUnsafeUpdatesSetBoolean = input =>
            {
                validations += 1;
            };
            spViewFieldCollection.DeleteAll = () =>
            {
                validations += 1;
            };
            spViewFieldCollection.ToStringCollection = () =>
            {
                validations += 1;
                return stringCollection;
            };
            spViewFieldCollection.AddString = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("_htGanttParams", nonPublicInstance, GanttParameters);
            privateObject.SetFieldOrProperty("_reqdfields", nonPublicInstance, requiredFields);

            // Act
            var actual = (SPWeb)privateObject.Invoke(AddReqdFieldsToViewMethodName, nonPublicInstance, new object[] { });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldNotBeNull(),
                () => validations.ShouldBe(7));
        }

        [TestMethod]
        public void RemoveReqdFieldsFromView_WhenCalled_RemovesFieldsFromView()
        {
            // Arrange
            var requiredFields = new List<string>()
            {
                DummyString,
                One.ToString()
            };

            GanttParameters.Add("View", DummyString);

            spFieldCollection.ContainsFieldString = _ => true;
            spWeb.AllowUnsafeUpdatesSetBoolean = input =>
            {
                validations += 1;
            };
            spViewFieldCollection.DeleteString = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("_htGanttParams", nonPublicInstance, GanttParameters);
            privateObject.SetFieldOrProperty("_reqdfields", nonPublicInstance, requiredFields);
            privateObject.SetFieldOrProperty("_fieldsAddedToView", nonPublicInstance, requiredFields);

            // Act
            privateObject.Invoke(RemoveReqdFieldsFromViewMethodName, nonPublicInstance, new object[] { });

            // Assert
            validations.ShouldBe(4);
        }

        [TestMethod]
        public void InitializeColumnDefs_WhenCalled_InitializeColumnDefinitions()
        {
            // Arrange
            const string xmlString = @"<xmlcfg/>";
            var fieldNames = new List<string>()
            {
                $"1|2",
                DummyString,
                "master_checkbox2"
            };
            var viewFields = new StringCollection()
            {
                DummyString
            };

            spFieldCollection.ContainsFieldString = _ => true;
            spField.DescriptionGet = () => "indicator";

            ShimGridData.AllInstances.IsHyperLinkStringInt32 = (_, _1, _2) => true;
            ShimGridData.AllInstances.InitViewFieldNames = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("_fieldNames", nonPublicInstance, fieldNames);
            privateObject.SetFieldOrProperty("_spvwFields", nonPublicInstance, viewFields);

            // Act
            privateObject.Invoke(InitializeColumnDefsMethodName, nonPublicInstance, new object[] { xmlString });
            var actual = (DataTable)privateObject.GetFieldOrProperty("_columnDefinitions", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Rows.Count.ShouldBe(3),
                () => actual.Rows[0]["DisplayName"].ToString().ShouldBe(fieldNames[0]),
                () => actual.Rows[0]["InternalName"].ToString().ShouldBe(DummyString),
                () => actual.Rows[0]["IsHyperLink"].ToString().ShouldBe("true"),
                () => actual.Rows[0]["IsImage"].ToString().ShouldBe("true"),
                () => validations.ShouldBe(1));
        }
    }
}