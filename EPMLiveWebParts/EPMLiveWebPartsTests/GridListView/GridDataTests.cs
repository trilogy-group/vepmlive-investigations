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
        private const string GetListIDMethodName = "GetListID";
        private const string UsePopupMethodName = "UsePopup";
        private const string GetActionMethodName = "GetAction";
        private const string GetGridColumnsMethodName = "GetGridColumns";
        private const string InitGanttParamsMethodName = "InitGanttParams";
        private const string InitializeReqdFieldsMethodName = "InitializeReqdFields";
        private const string AddColumnsMethodName = "AddColumns";
        private const string GetGridFieldsMethodName = "GetGridFields";
        private const string FormatGridFieldMethodName = "formatGridField";

        [TestInitialize]
        public void Setup()
        {
            testObject = new GridData();
            privateObject = new PrivateObject(testObject);

            SetupShims();

            privateObject.SetFieldOrProperty("_spList", nonPublicInstance, spList.Instance);
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
    }
}