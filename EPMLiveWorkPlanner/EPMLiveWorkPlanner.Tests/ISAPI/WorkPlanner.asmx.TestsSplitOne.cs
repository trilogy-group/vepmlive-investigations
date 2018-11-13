using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Fakes;
using System.Linq;
using System.Reflection;
using System.Resources.Fakes;
using System.Xml;
using System.Xml.Linq;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportingProxy.Fakes;
using EPMLiveWorkPlanner.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using static EPMLiveWorkPlanner.WorkPlannerAPI;

namespace EPMLiveWorkPlanner.Tests.ISAPI
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public partial class WorkPlannerAPITests
    {
        private WorkPlannerAPI testObject;
        private PrivateObject privateObject;
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
        private Guid guid;
        private int validations;
        private const int DummyInt = 1;
        private const int One = 1;
        private const string SampleGuidString1 = "83e81819-0112-4c22-bb70-d8ba101e9e0c";
        private const string SampleGuidString2 = "83e81819-0104-4c22-bb70-d8ba101e9e0c";
        private const string DummyString = "DummyString";
        private const string TitleString = "Title";
        private const string StartString = "Start";
        private const string FinishString = "Finish";
        private const string IDStringCaps = "ID";
        private const string StatusString = "Status";
        private const string ItemString = "Item";
        private const string UserString = "User";
        private const string AccountInfoString = "SPAccountInfo";
        private const string TaskUidString = "taskuid";
        private const string CommentCountString = "CommentCount";
        private const string AttachmentsString = "Attachments";
        private const string LinkedString = "Linked";
        private const string SourceTaskIdString = "SourceTaskId";
        private const string PredecessorsString = "Predecessors";
        private const string SuccessorsString = "Successors";
        private const string DestProjectIdString = "DestProjectId";
        private const string DestTaskIdString = "DestTaskId";
        private const string GetExternalProjectsMethodName = "GetExternalProjects";
        private const string ImportTasksMethodName = "ImportTasks";
        private const string GetPlannersByProjectListMethodName = "GetPlannersByProjectList";
        private const string GetPlannersByTaskListMethodName = "GetPlannersByTaskList";
        private const string GetUpdateDetailLayoutMethodName = "GetUpdateDetailLayout";
        private const string ImportTasksFixXmlStructureMethodName = "ImportTasksFixXmlStructure";
        private const string SaveProjectMethodName = "SaveProject";
        private const string SaveAgilePlanMethodName = "SaveAgilePlan";
        private const string SaveWorkPlanMethodName = "SaveWorkPlan";
        private const string UpgradeProjectScheduleLibraryMethodName = "UpgradeProjectScheduleLibrary";
        private const string IApplyNewTemplateMethodName = "iApplyNewTemplate";
        private const string ApplyNewTemplateMethodName = "ApplyNewTemplate";
        private const string IGetTemplatesMethodName = "iGetTemplates";
        private const string ISaveTemplateMethodName = "iSaveTemplate";
        private const string SaveTemplateMethodName = "SaveTemplate";
        private const string GetTemplatesMethodName = "GetTemplates";
        private const string GetTaskFileMethodName = "GetTaskFile";
        private const string ProcessTaskXmlFromTaskCenterMethodName = "ProcessTaskXmlFromTaskCenter";
        private const string GetTasksMethodName = "GetTasks";
        private const string ProcessExternalMethodName = "ProcessExternal";
        private const string GetExternalLinkLayoutMethodName = "GetExternalLinkLayout";
        private const string AddCustomFooterMethodName = "AddCustomFooter";
        private const string GetUpdatesMethodName = "GetUpdates";
        private const string GetFieldValueMethodName = "getFieldValue";
        private const string AppendSpecialColumnsMethodName = "appendSpecialColumns";

        [TestInitialize]
        public void Setup()
        {
            SetupShims();
            SetupVariables();

            testObject = new WorkPlannerAPI();
            privateObject = new PrivateObject(testObject);
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            shimsContext = ShimsContext.Create();

            ShimSqlConnection.ConstructorString = (_, __) => new ShimSqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSPFieldLookupValueCollection.Constructor = _ => new ShimSPFieldLookupValueCollection();
            ShimSPFieldLookupValue.ConstructorString = (_, __) => new ShimSPFieldLookupValue();
            ShimSPSite.ConstructorString = (_, __) => new ShimSPSite();
            ShimSPSite.ConstructorGuid = (_, __) => new ShimSPSite();
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
            ShimSPList.AllInstances.RootFolderGet = _ => spFolder;
            ShimSPList.AllInstances.GetItemsSPQuery = (_, __) => spListItemCollection;
            ShimSPPersistedObject.AllInstances.IdGet = _ => guid;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();
            ShimSPFieldUserValueCollection.ConstructorSPWebString = (_, _1, _2) => new ShimSPFieldUserValueCollection();
            ShimQueryExecutor.ConstructorSPWeb = (_, __) => new ShimQueryExecutor();
            ShimSPQuery.Constructor = _ => new ShimSPQuery();
            ShimQueryExecutor.ConstructorSPWeb = (_, __) => new ShimQueryExecutor();
        }

        private void SetupVariables()
        {
            validations = 0;
            publicStatic = BindingFlags.Static | BindingFlags.Public;
            nonPublicStatic = BindingFlags.Static | BindingFlags.NonPublic;
            guid = Guid.Parse(SampleGuidString1);
            spWeb = new ShimSPWeb()
            {
                IDGet = () => guid,
                SiteGet = () => spSite,
                ListsGet = () => spListCollection,
                GetFolderString = _ => spFolder,
                GetFileString = _ => spFile,
                FoldersGet = () => spFolderCollection
            };
            spSite = new ShimSPSite()
            {
                IDGet = () => guid,
                WebApplicationGet = () => new ShimSPWebApplication(),
                RootWebGet = () => spWeb
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
                TitleGet = () => DummyString
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
                ItemSetGuidObject = (_, __) => { },
                Update = () => { },
                FileGet = () => spFile,
                ParentListGet = () => spList
            };
            spFieldCollection = new ShimSPFieldCollection()
            {
                GetFieldByInternalNameString = _ => spField,
                ContainsFieldString = _ => false,
                GetFieldString = _ => spField
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
            spFolderCollection = new ShimSPFolderCollection()
            {
                ItemGetString = _ => spFolder,
                AddString = _ => spFolder
            };
            spFolder = new ShimSPFolder()
            {
                ExistsGet = () => false,
                SubFoldersGet = () => spFolderCollection,
                FilesGet = () => spFileCollection
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
                ViewFieldsGet = () => spViewFieldCollection
            };
            spViewFieldCollection = new ShimSPViewFieldCollection();
            spContentTypeCollection = new ShimSPContentTypeCollection()
            {
                ItemGetString = _ => spContentType
            };
            spContentType = new ShimSPContentType()
            {
                FieldLinksGet = () => spFieldLinkCollection
            };
            spFieldLinkCollection = new ShimSPFieldLinkCollection()
            {
                ItemGetGuid = _ => new ShimSPFieldLink()
            };
        }

        [TestMethod]
        public void GetExternalProjects_WhenCalled_ReturnsString()
        {
            // Arrange
            const string xmlString = @"
                <Grid>
                    <Header Title=""Title""/>
                    <Body>
                        <B/>
                    </Body>
                </Grid>";
            const string dataXml = @"
                <xmlcfg>
                    <PlannerID/>
                </xmlcfg>";
            var data = new XmlDocument();
            var dataTable = new DataTable();
            var now = DateTime.Now;

            data.LoadXml(dataXml);
            dataTable.Columns.Add(TitleString);
            dataTable.Columns.Add(StartString);
            dataTable.Columns.Add(FinishString);
            dataTable.Columns.Add(IDStringCaps);
            var row = dataTable.NewRow();
            row[TitleString] = DummyString;
            row[StartString] = now;
            row[FinishString] = now;
            row[IDStringCaps] = DummyString;
            dataTable.Rows.Add(row);

            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => xmlString;
            ShimReportingData.GetReportQuerySPWebSPListStringStringOut = (SPWeb web, SPList list, string spquery, out string orderby) =>
            {
                validations += 1;
                orderby = DummyString;
                return DummyString;
            };
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString = (_1, _2, _3, _4, _5) =>
            {
                validations += 1;
                return dataTable;
            };
            ShimWorkPlannerAPI.getAttributeXmlNodeString = (node, input) =>
            {
                validations += 1;
                return input;
            };

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(GetExternalProjectsMethodName, publicStatic, new object[] { data, spWeb.Instance }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .Element("Grid")
                    .Element("Body")
                    .Element("B")
                    .Element("I")
                    .Attribute("Title")
                    .Value
                    .ShouldBe(DummyString),
                () => actual
                    .Element("Grid")
                    .Element("Body")
                    .Element("B")
                    .Element("I")
                    .Attribute("Start")
                    .Value
                    .ShouldBe(now.ToShortDateString()),
                () => actual
                    .Element("Grid")
                    .Element("Body")
                    .Element("B")
                    .Element("I")
                    .Attribute("Finish")
                    .Value
                    .ShouldBe(now.ToShortDateString()),
                () => actual
                    .Element("Grid")
                    .Element("Body")
                    .Element("B")
                    .Element("I")
                    .Attribute("id")
                    .Value
                    .ShouldBe(DummyString),
                () => validations.ShouldBe(3));
        }

        [TestMethod]
        public void ImportTasks_UidEmptyAllowDuplicatesFalse_ReturnsString()
        {
            // Arrange
            const string expected = "<Result Status=\"1\">UID Column not specified and allow duplicated is on. You must either specify UID column or you must allow duplicates.</Result>";
            var dataXml = string.Format(@"
                <xmlcfg Structure=""Structure"" ResourceField=""ResourceField"" UIDColumn=""{0}"" AllowDuplicateRows=""{1}"" Planner=""Planner"" ID=""ID"">
                </xmlcfg>", string.Empty, false);
            var data = new XmlDocument();

            data.LoadXml(dataXml);

            // Act
            var actual = (string)privateObject.Invoke(ImportTasksMethodName, publicStatic, new object[] { data, spWeb.Instance });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void ImportTasks_idEmpty_ReturnsString()
        {
            // Arrange
            const string expected = "<Result Status=\"1\">ID Not Specified</Result>";
            var allowDuplicates = bool.TrueString;
            var dataXml = string.Format(@"
                <xmlcfg Structure=""Structure"" ResourceField=""ResourceField"" UIDColumn=""{0}"" AllowDuplicateRows=""{1}"" Planner=""{2}"" ID=""{3}"">
                </xmlcfg>", DummyString, true, DummyString, string.Empty);
            var data = new XmlDocument();

            data.LoadXml(dataXml);

            // Act
            var actual = (string)privateObject.Invoke(ImportTasksMethodName, publicStatic, new object[] { data, spWeb.Instance });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void ImportTasks_UidNotEmptyPlannerEmpty_ReturnsString()
        {
            // Arrange
            const string expected = "<Result Status=\"1\">Planner Not Specified</Result>";
            var dataXml = string.Format(@"
                <xmlcfg Structure=""Structure"" ResourceField=""ResourceField"" UIDColumn=""{0}"" AllowDuplicateRows=""{1}"" Planner=""{2}"" ID=""ID"">
                </xmlcfg>", DummyString, true, string.Empty);
            var data = new XmlDocument();

            data.LoadXml(dataXml);

            // Act
            var actual = (string)privateObject.Invoke(ImportTasksMethodName, publicStatic, new object[] { data, spWeb.Instance });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void ImportTasks_NoException_ReturnsXml()
        {
            // Arrange
            var dataXml = string.Format(@"
                <xmlcfg Structure=""Structure"" ResourceField=""ResourceField"" UIDColumn=""{0}"" AllowDuplicateRows=""{1}"" Planner=""{2}"" ID=""ID"">
                    <LeftCols>
                        <C Name=""LeftCols1""/>
                    </LeftCols>
                    <Cols>
                        <C Name=""Cols1""/>
                    </Cols>
                    <I id=""1""/>
                    <Item/>
                </xmlcfg>",
                DummyString, true, DummyString);
            var data = new XmlDocument();
            var actualArray = default(ArrayList);
            var props = new PlannerProps()
            {
                sListProjectCenter = DummyString
            };

            data.LoadXml(dataXml);

            ShimWorkPlannerAPI.ImportTasksFixXmlStructureXmlDocumentRefStringString = (ref XmlDocument document, string sUID, string sStructure) =>
            {
                validations += 1;
            };
            ShimWorkPlannerAPI.GetTasksXmlDocumentSPWeb = (_, __) =>
            {
                validations += 1;
                return dataXml;
            };
            ShimWorkPlannerAPI.iGetGeneralLayoutSPWebStringXmlDocumentBoolean = (_1, _2, _3, _4) =>
            {
                validations += 1;
                return dataXml;
            };
            ShimWorkPlannerAPI.getSettingsSPWebString = (_1, _2) =>
            {
                validations += 1;
                return props;
            };
            ShimWorkPlannerAPI.GetResourceTableWorkPlannerAPIPlannerPropsGuidStringSPWeb = (_1, _2, _3, _4) =>
            {
                validations += 1;
                return default(DataSet);
            };
            ShimWorkPlannerAPI.processTasksXmlNodeXmlDocumentRefXmlNodeXmlDocumentStringArrayListBooleanInt32RefStringDataSetString =
                (XmlNode ndImportTask, ref XmlDocument returnDocument, XmlNode ndParent, XmlDocument docPlan,
                string sUID, ArrayList columnArray, bool bAllowDuplicates, ref int curtaskuid, string sResField,
                DataSet dsResources, string sTaskType) =>
                {
                    validations += 1;
                    var newNode = returnDocument.CreateNode(XmlNodeType.Element, ItemString, returnDocument.NamespaceURI);
                    var statusAttribute = returnDocument.CreateAttribute(StatusString);

                    statusAttribute.Value = "1";
                    newNode.Attributes.Append(statusAttribute);
                    returnDocument.FirstChild.AppendChild(newNode);

                    actualArray = columnArray;
                };
            ShimWorkPlannerAPI.SaveWorkPlanXmlDocumentSPWeb = (_1, _2) =>
            {
                validations += 1;
                return DummyString;
            };

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(ImportTasksMethodName, publicStatic, new object[] { data, spWeb.Instance }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("Import").Element("SavePlan").Attribute("Status").Value.ShouldBe("0"),
                () => actual.Element("Import").Element("Item").Attribute("Status").Value.ShouldBe("1"),
                () => actual.Element("Import").Attribute("Status").Value.ShouldBe("1"),
                () => actualArray.Count.ShouldBe(2),
                () => actualArray.Contains("LeftCols1").ShouldBeTrue(),
                () => actualArray.Contains("Cols1").ShouldBeTrue(),
                () => validations.ShouldBe(7));
        }

        [TestMethod]
        public void ImportTasks_WithException_ReturnsXml()
        {
            // Arrange
            var dataXml = string.Format(@"
                <xmlcfg Structure=""Structure"" ResourceField=""ResourceField"" UIDColumn=""{0}"" AllowDuplicateRows=""{1}"" Planner=""{2}"" ID=""ID"">
                    <LeftCols>
                        <C Name=""LeftCols1""/>
                    </LeftCols>
                    <Cols>
                        <C Name=""Cols1""/>
                    </Cols>
                    <I id=""1""/>
                    <Item/>
                </xmlcfg>",
                DummyString, true, DummyString);
            var data = new XmlDocument();
            var actualArray = default(ArrayList);
            var props = new PlannerProps()
            {
                sListProjectCenter = DummyString
            };

            data.LoadXml(dataXml);

            ShimWorkPlannerAPI.ImportTasksFixXmlStructureXmlDocumentRefStringString = (ref XmlDocument document, string sUID, string sStructure) =>
            {
                validations += 1;
            };
            ShimWorkPlannerAPI.GetTasksXmlDocumentSPWeb = (_, __) =>
            {
                validations += 1;
                return dataXml;
            };
            ShimWorkPlannerAPI.iGetGeneralLayoutSPWebStringXmlDocumentBoolean = (_1, _2, _3, _4) =>
            {
                validations += 1;
                return dataXml;
            };
            ShimWorkPlannerAPI.getSettingsSPWebString = (_1, _2) =>
            {
                validations += 1;
                return props;
            };
            ShimWorkPlannerAPI.GetResourceTableWorkPlannerAPIPlannerPropsGuidStringSPWeb = (_1, _2, _3, _4) =>
            {
                validations += 1;
                return default(DataSet);
            };
            ShimWorkPlannerAPI.processTasksXmlNodeXmlDocumentRefXmlNodeXmlDocumentStringArrayListBooleanInt32RefStringDataSetString =
                (XmlNode ndImportTask, ref XmlDocument returnDocument, XmlNode ndParent, XmlDocument docPlan,
                string sUID, ArrayList columnArray, bool bAllowDuplicates, ref int curtaskuid, string sResField,
                DataSet dsResources, string sTaskType) =>
                {
                    validations += 1;
                    var newNode = returnDocument.CreateNode(XmlNodeType.Element, ItemString, returnDocument.NamespaceURI);
                    var statusAttribute = returnDocument.CreateAttribute(StatusString);

                    statusAttribute.Value = One.ToString();
                    newNode.Attributes.Append(statusAttribute);
                    returnDocument.FirstChild.AppendChild(newNode);

                    actualArray = columnArray;
                };
            ShimWorkPlannerAPI.SaveWorkPlanXmlDocumentSPWeb = (_1, _2) =>
            {
                validations += 1;
                throw new Exception(DummyString);
            };

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(ImportTasksMethodName, publicStatic, new object[] { data, spWeb.Instance }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("Import").Element("SavePlan").Attribute("Status").Value.ShouldBe("1"),
                () => actual.Element("Import").Element("SavePlan").Value.ShouldBe(DummyString),
                () => actual.Element("Import").Element("Item").Attribute("Status").Value.ShouldBe("1"),
                () => actual.Element("Import").Attribute("Status").Value.ShouldBe("1"),
                () => actualArray.Count.ShouldBe(2),
                () => actualArray.Contains("LeftCols1").ShouldBeTrue(),
                () => actualArray.Contains("Cols1").ShouldBeTrue(),
                () => validations.ShouldBe(7));
        }

        [TestMethod]
        public void GetPlannersByProjectList_WhenCalled_ReturnsSortedList()
        {
            // Arrange
            const string planners = "planner11|planner12";
            const string projectList = "Project Center";
            var methodHit = 0;

            spListCollection.TryGetListString = _ => null;

            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (_1, _2, _3) =>
            {
                methodHit += 1;
                var returnValue = DummyString;
                switch (methodHit)
                {
                    case 1:
                        returnValue = planners;
                        break;
                    case 2:
                        returnValue = projectList;
                        break;
                    case 3:
                        returnValue = bool.FalseString;
                        break;
                }
                return returnValue;
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (_1, _2) => bool.TrueString;

            // Act
            var actual = (SortedList)privateObject.Invoke(GetPlannersByProjectListMethodName, publicStatic, new object[] { projectList, spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(2),
                () => actual["planner11"].ShouldBe("planner12"),
                () => actual["MPP"].ShouldBe("Microsoft Office Project"));
        }

        [TestMethod]
        public void GetPlannersByTaskList_WhenCalled_ReturnsSortedList()
        {
            // Arrange
            const string planners = "planner11|planner12,planner21|planner22";
            const string taskList = "Project Center";
            var methodHit = 0;

            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (_1, _2, _3) =>
            {
                methodHit += 1;
                if (methodHit.Equals(1))
                {
                    return planners;
                }
                return taskList;
            };

            // Act
            var actual = (SortedList)privateObject.Invoke(GetPlannersByTaskListMethodName, publicStatic, new object[] { spWeb.Instance, taskList });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(2),
                () => actual["planner11"].ShouldBe("planner12"),
                () => actual["planner21"].ShouldBe("planner22"));
        }

        [TestMethod]
        public void GetUpdateDetailLayout_WhenCalled_ReturnsXmlString()
        {
            // Arrange
            const string dataXmlString = @"<xmlcfg Planner=""Planner""/>";
            const string outXmlString = @"
                <Body>
                    <B/>
                    <I id=""Title""/>
                </Body>";

            var data = new XmlDocument();
            var fieldProperties = default(Dictionary<string, Dictionary<string, string>>);
            var plannerProps = new PlannerProps()
            {
                sListTaskCenter = DummyString,
                StatusFields = new SortedList()
                {
                    [DummyString] = DummyString
                }
            };

            data.LoadXml(dataXmlString);

            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => outXmlString;
            ShimWorkPlannerAPI.getSettingsSPWebString = (_1, _2) =>
            {
                validations += 1;
                return plannerProps;
            };
            ShimListDisplayUtils.ConvertFromStringString = _ => fieldProperties;
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPField>()
            {
                new ShimSPField()
                {
                    TypeGet = () => SPFieldType.Calculated,
                    InternalNameGet = () => DummyString,
                    TitleGet = () => DummyString
                },
                new ShimSPField()
                {
                    TypeGet = () => SPFieldType.User,
                    InternalNameGet = () => UserString,
                    TitleGet = () => DummyString,
                    ShowInEditFormGet = () => true
                }
            }.GetEnumerator();
            ShimEditableFieldDisplay.isEditableSPListSPFieldDictionaryOfStringDictionaryOfStringString = (_1, _2, _3) =>
            {
                validations += 1;
                return true;
            };

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(GetUpdateDetailLayoutMethodName, publicStatic, new object[] { data, spWeb.Instance }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .Element("Body")
                    .Elements("I")
                    .Count()
                    .ShouldBe(1),
                () => actual
                    .Element("Body")
                    .Element("B")
                    .Elements("I")
                    .Count()
                    .ShouldBe(2),
                () => actual
                    .Element("Body")
                    .Elements("I")
                    .FirstOrDefault(x => x.Attribute("id").Value.Equals(TitleString))
                    .Attribute("N")
                    .Value
                    .ShouldBe(DummyString),
                () => actual
                    .Element("Body")
                    .Element("B")
                    .Elements("I")
                    .Count(x => x.Attribute("id").Value.Equals(UserString) && x.Attribute("N").Value.Equals(DummyString))
                    .ShouldBe(1),
                () => actual
                    .Element("Body")
                    .Element("B")
                    .Elements("I")
                    .Count(x => x.Attribute("id").Value.Equals(DummyString) && x.Attribute("N").Value.Equals(DummyString))
                    .ShouldBe(1),
                () => validations
                    .ShouldBe(2));
        }

        [TestMethod]
        public void ImportTasksFixXmlStructure_WhenCalled_ApppendsChilds()
        {
            // Arrange
            const string idString = "id";
            const string nodeString1 = "node1";
            const string nodeString2 = "node2";
            const string nodeString3 = "node3";
            var data = new XmlDocument();
            var dataXmlString = $@"
                <xmlcfg>
                    <Item {idString}=""{nodeString1}""/>
                    <Item {idString}=""{nodeString1}.{nodeString2}""/>
                    <Item {idString}=""{nodeString1}.{nodeString3}""/>
                </xmlcfg>";

            data.LoadXml(dataXmlString);

            // Act
            privateObject.Invoke(ImportTasksFixXmlStructureMethodName, nonPublicStatic, new object[] { data, DummyString, idString });
            var actual = XDocument.Parse(data.OuterXml).Elements("xmlcfg").Elements("Item").FirstOrDefault(x => x.Attribute(idString).Value.Equals(nodeString1));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .ShouldNotBeNull(),
                () => actual
                    .Elements("Item")
                    .Count()
                    .ShouldBe(2));
        }

        [TestMethod]
        public void SaveProject_WhenCalled_ReturnsString()
        {
            // Arrange
            const string expected = "<Result Status=\"0\"></Result>";
            var now = DateTime.Now;
            var data = new XmlDocument();
            var dataXmlString = $@"
                <xmlcfg ID=""1"" PlannerID=""1"">
                    <Field Name=""{(int)SPFieldType.DateTime}""></Field>
                    <Field Name=""{(int)SPFieldType.DateTime}"">{now}</Field>
                    <Field Name=""{(int)SPFieldType.Currency}""></Field>
                    <Field Name=""{(int)SPFieldType.Currency}"">{DummyString}</Field>
                    <Field Name=""{(int)SPFieldType.Number}"">{100}</Field>
                    <Field Name=""{(int)SPFieldType.Number}"">{100}</Field>
                    <Field Name=""{(int)SPFieldType.User}""></Field>
                    <Field Name=""{(int)SPFieldType.User}"">{DummyString}</Field>
                    <Field Name=""{(int)SPFieldType.Lookup}""></Field>
                    <Field Name=""{(int)SPFieldType.Lookup}"">{DummyString}</Field>
                    <Field Name=""{(int)SPFieldType.Calculated}"">{DummyString}</Field>
                </xmlcfg>";
            var props = new PlannerProps()
            {
                sListProjectCenter = DummyString
            };
            var resourceDataSet = new DataSet();
            var row = default(DataRow);
            var methodHit = 0;

            data.LoadXml(dataXmlString);
            resourceDataSet.Tables.Add(new DataTable());
            resourceDataSet.Tables.Add(new DataTable());
            resourceDataSet.Tables.Add(new DataTable());
            resourceDataSet.Tables[2].Columns.Add(IDStringCaps);
            resourceDataSet.Tables[2].Columns.Add(AccountInfoString);
            row = resourceDataSet.Tables[2].NewRow();
            row[IDStringCaps] = DummyString;
            row[AccountInfoString] = DummyString;

            spWeb.AllowUnsafeUpdatesSetBoolean = _ =>
            {
                validations += 1;
            };
            spFieldCollection.GetFieldByInternalNameString = internalName =>
            {
                var fieldType = (SPFieldType)int.Parse(internalName);
                if (fieldType.Equals(SPFieldType.Number))
                {
                    methodHit += 1;
                    var fieldNumber = new ShimSPFieldNumber()
                    {
                        ShowAsPercentageGet = () => methodHit.Equals(1)
                    };
                    return fieldNumber.Instance;
                }
                else if (fieldType.Equals(SPFieldType.Lookup))
                {
                    var fieldLookup = new ShimSPFieldLookup()
                    {
                        AllowMultipleValuesGet = () => true
                    };
                    return fieldLookup.Instance;
                }
                spField.TypeGet = () => fieldType;
                return spField;
            };
            spListItem.ItemSetGuidObject = (_, __) =>
            {
                validations += 1;
            };
            spListItem.Update = () =>
            {
                validations += 1;
            };

            ShimSPField.AllInstances.ReadOnlyFieldGet = _ => false;
            ShimSPField.AllInstances.TypeAsStringGet = _ => DummyString;
            ShimWorkPlannerAPI.getSettingsSPWebString = (_1, _2) =>
            {
                validations += 1;
                return props;
            };
            ShimWorkPlannerAPI.GetResourceTableWorkPlannerAPIPlannerPropsGuidStringSPWeb = (_1, _2, _3, _4) =>
            {
                validations += 1;
                return resourceDataSet;
            };

            // Act
            var actual = (string)privateObject.Invoke(SaveProjectMethodName, publicStatic, new object[] { data, spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => validations.ShouldBe(15));
        }

        [TestMethod]
        public void SaveAgilePlan_WhenCalled_ReturnsString()
        {
            // Arrange
            const string expected = "<Grid><IO Result='0'/></Grid>";
            const string dataXmlString = @"
                <xmlcfg ID=""1"" Planner=""Planner"">
                    <node1/>
                    <node2/>
                </xmlcfg>";
            var data = new XmlDocument();
            var actualXml = default(XDocument);

            data.LoadXml(dataXmlString);

            spListCollection.ItemGetString = _ => new ShimSPDocumentLibrary().Instance;
            spWeb.AllowUnsafeUpdatesSetBoolean = _ =>
            {
                validations += 1;
            };
            spFolderCollection.AddString = _ =>
            {
                validations += 1;
                return spFolder;
            };
            spFileCollection.AddStringByteArrayBoolean = (_1, _2, _3) =>
            {
                validations += 1;
                return spFile;
            };
            ShimWorkPlannerAPI.getSettingsSPWebString = (_, __) =>
            {
                validations += 1;
                return default(PlannerProps);
            };
            ShimWorkPlannerAPI.StrToByteArrayString = outerXml =>
            {
                validations += 1;
                actualXml = XDocument.Parse(outerXml);
                return default(byte[]);
            };

            // Act
            var actual = (string)privateObject.Invoke(SaveAgilePlanMethodName, publicStatic, new object[] { data, spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => actualXml.Element("xmlcfg").Elements().Count().ShouldBe(2),
                () => actualXml.Element("xmlcfg").Attributes().Count().ShouldBe(0),
                () => validations.ShouldBe(5));
        }

        [TestMethod]
        public void SaveWorkPlan_WhenCalled_ReturnsString()
        {
            // Arrange
            const string expected = "<Grid><IO Result='0'/></Grid>";
            const string dataXmlString = @"
                <xmlcfg ID=""1"" Planner=""Planner"">
                    <I id="""" Def=""Folder""/>
                    <I id=""BacklogRow"" Def=""""/>
                    <I id="""" Def="""" Detail=""""/>
                </xmlcfg>";
            var data = new XmlDocument();
            var actualXml = default(XDocument);

            data.LoadXml(dataXmlString);

            spListCollection.ItemGetString = _ => new ShimSPDocumentLibrary().Instance;
            spWeb.AllowUnsafeUpdatesSetBoolean = _ =>
            {
                validations += 1;
            };
            spFolderCollection.AddString = _ =>
            {
                validations += 1;
                return spFolder;
            };
            spFileCollection.AddStringByteArrayBoolean = (_1, _2, _3) =>
            {
                validations += 1;
                return spFile;
            };
            ShimWorkPlannerAPI.getSettingsSPWebString = (_, __) =>
            {
                validations += 1;
                return default(PlannerProps);
            };
            ShimWorkPlannerAPI.StrToByteArrayString = outerXml =>
            {
                validations += 1;
                actualXml = XDocument.Parse(outerXml);
                return default(byte[]);
            };

            // Act
            var actual = (string)privateObject.Invoke(SaveWorkPlanMethodName, publicStatic, new object[] { data, spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .ShouldBe(expected),
                () => actualXml
                    .Element("xmlcfg")
                    .Attributes()
                    .Count()
                    .ShouldBe(0),
                () => actualXml
                    .Element("xmlcfg")
                    .Elements("I")
                    .Count()
                    .ShouldBe(3),
                () => actualXml
                    .Element("xmlcfg")
                    .Elements("I")
                    .Count(x => x.Attribute("Detail").Value.Equals("WorkPlannerGrid"))
                    .ShouldBe(1),
                () => actualXml
                    .Element("xmlcfg")
                    .Elements("I")
                    .Count(x => x.Attribute("Detail").Value.Equals("AgileGrid"))
                    .ShouldBe(1),
                () => validations
                    .ShouldBe(5));
        }

        [TestMethod]
        public void UpgradeProjectScheduleLibrary_WhenCalled_UpgradesLibrary()
        {
            // Arrange
            spWeb.AllowUnsafeUpdatesSetBoolean = _ =>
            {
                validations += 1;
            };
            spFolderCollection.AddString = _ =>
            {
                validations += 1;
                return spFolder;
            };
            spFileCollection.AddStringStream = (_1, _2) =>
            {
                validations += 1;
                return spFile;
            };
            spFile.OpenBinaryStream = () =>
            {
                validations += 1;
                return default(Stream);
            };
            spFile.Delete = () =>
            {
                validations += 1;
            };

            // Act
            privateObject.Invoke(UpgradeProjectScheduleLibraryMethodName, publicStatic, new object[] { spWeb.Instance, DummyString, DummyString, spFile.Instance });

            // Assert
            validations.ShouldBe(5);
        }

        [TestMethod]
        public void IApplyNewTemplate_TemplateIdEmpty_AppliesTemplate()
        {
            // Arrange
            const string itemId = "ItemId";
            const string projectName = "ProjectName";
            const string fileName = "filename.mpp";
            const string extension = ".mpp";
            var templateId = string.Empty;

            spListItemCollection.CountGet = () => 0;
            spFile.NameGet = () => fileName;
            spList.GetItemsSPQuery = _ =>
            {
                validations += 1;
                return spListItemCollection;
            };
            spWeb.AllowUnsafeUpdatesSetBoolean = _ =>
            {
                validations += 1;
            };
            spFolderCollection.AddString = _ =>
            {
                validations += 1;
                return spFolder;
            };
            spFileCollection.AddStringStream = (actualFileName, stream) =>
            {
                validations += 1;
                if (actualFileName.Equals($"{projectName}{extension}"))
                {
                    validations += 1;
                }
                return spFile;
            };
            spFile.OpenBinaryStream = () =>
            {
                validations += 1;
                return default(Stream);
            };

            // Act
            privateObject.Invoke(
                IApplyNewTemplateMethodName,
                nonPublicStatic,
                new object[] { spWeb.Instance, spWeb.Instance, DummyString, templateId, itemId, DummyString, projectName });

            // Assert
            validations.ShouldBe(1);
        }

        [TestMethod]
        public void IApplyNewTemplate_TemplateIdNotEmpty_AppliesTemplate()
        {
            // Arrange
            const string itemId = "ItemId";
            const string projectName = "ProjectName";
            const string fileName = "filename.mpp";
            const string extension = ".mpp";
            const string templateId = "1";

            spListItemCollection.CountGet = () => 0;
            spFile.NameGet = () => fileName;
            spList.GetItemsSPQuery = _ =>
            {
                validations += 1;
                return spListItemCollection;
            };
            spWeb.AllowUnsafeUpdatesSetBoolean = _ =>
            {
                validations += 1;
            };
            spFolderCollection.AddString = _ =>
            {
                validations += 1;
                return spFolder;
            };
            spFileCollection.AddStringStream = (actualFileName, stream) =>
            {
                validations += 1;
                if (actualFileName.Equals($"{projectName}{extension}"))
                {
                    validations += 1;
                }
                return spFile;
            };
            spFile.OpenBinaryStream = () =>
            {
                validations += 1;
                return default(Stream);
            };

            // Act
            privateObject.Invoke(
                IApplyNewTemplateMethodName,
                nonPublicStatic,
                new object[] { spWeb.Instance, spWeb.Instance, DummyString, templateId, itemId, DummyString, projectName });

            // Assert
            validations.ShouldBe(5);
        }

        [TestMethod]
        public void ApplyNewTemplate_LockedWebEmpty_AppliesNewTemplate()
        {
            // Arrange
            ShimCoreFunctions.getLockedWebSPWeb = _ =>
            {
                validations += 1;
                return Guid.Empty;
            };
            ShimWorkPlannerAPI.iApplyNewTemplateSPWebSPWebStringStringStringStringString = (_1, _2, _3, _4, _5, _6, _7) =>
            {
                validations += 1;
            };
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) =>
            {
                validations += 1;
                return spWeb;
            };

            // Act
            privateObject.Invoke(ApplyNewTemplateMethodName, publicStatic, new object[] { spWeb.Instance, DummyString, DummyString, DummyString, DummyString, DummyString });

            // Assert
            validations.ShouldBe(3);
        }

        [TestMethod]
        public void ApplyNewTemplate_LockedWebNotEmpty_AppliesNewTemplate()
        {
            // Arrange
            ShimCoreFunctions.getLockedWebSPWeb = _ =>
            {
                validations += 1;
                return Guid.Parse(SampleGuidString2);
            };
            ShimWorkPlannerAPI.iApplyNewTemplateSPWebSPWebStringStringStringStringString = (_1, _2, _3, _4, _5, _6, _7) =>
            {
                validations += 1;
            };
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) =>
            {
                validations += 1;
                return spWeb;
            };

            // Act
            privateObject.Invoke(ApplyNewTemplateMethodName, publicStatic, new object[] { spWeb.Instance, DummyString, DummyString, DummyString, DummyString, DummyString });

            // Assert
            validations.ShouldBe(4);
        }

        [TestMethod]
        public void IGetTemplates_TypeOnline_ReturnsDataTable()
        {
            // Arrange
            const string type = "Online";
            const string fileName = "FileName";
            const string extension = ".xml";
            var fullName = $"{fileName}{extension}";

            spListCollection.ItemGetString = _ => new ShimSPDocumentLibrary().Instance;
            spFile.NameGet = () => fullName;
            spListItem.TitleGet = () => fullName;
            spListItemCollection.GetEnumerator = () => new List<SPListItem>()
            {
                spListItem
            }.GetEnumerator();

            // Act
            var actual = (DataTable)privateObject.Invoke(IGetTemplatesMethodName, nonPublicStatic, new object[] { spWeb.Instance, DummyString, type });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Rows.Count.ShouldBe(2),
                () => actual.Rows[0][IDStringCaps].ShouldBe(DummyInt.ToString()),
                () => actual.Rows[0][TitleString].ShouldBe(fullName),
                () => actual.Rows[0]["Description"].ShouldBe(DummyString),
                () => actual.Rows[1][IDStringCaps].ShouldBe(DummyInt.ToString()),
                () => actual.Rows[1][TitleString].ShouldBe(fileName),
                () => actual.Rows[1]["Description"].ShouldBe(DummyString));
        }

        [TestMethod]
        public void IGetTemplates_TypeProject_ReturnsDataTable()
        {
            // Arrange
            const string type = "Project";
            const string fileName = "FileName";
            const string extension = ".mpp";
            var fullName = $"{fileName}{extension}";

            spListCollection.ItemGetString = _ => new ShimSPDocumentLibrary().Instance;
            spFile.NameGet = () => fullName;
            spListItem.TitleGet = () => fullName;
            spListItemCollection.GetEnumerator = () => new List<SPListItem>()
            {
                spListItem
            }.GetEnumerator();

            // Act
            var actual = (DataTable)privateObject.Invoke(IGetTemplatesMethodName, nonPublicStatic, new object[] { spWeb.Instance, DummyString, type });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Rows.Count.ShouldBe(3),
                () => actual.Rows[0][IDStringCaps].ShouldBe(DummyInt.ToString()),
                () => actual.Rows[0][TitleString].ShouldBe(fullName),
                () => actual.Rows[0]["Description"].ShouldBe(DummyString),
                () => actual.Rows[1][IDStringCaps].ShouldBe(DummyInt.ToString()),
                () => actual.Rows[1][TitleString].ShouldBe(fileName),
                () => actual.Rows[1]["Description"].ShouldBe(DummyString),
                () => actual.Rows[2][IDStringCaps].ShouldBe("-101"),
                () => actual.Rows[2][TitleString].ShouldBe("Import Project"),
                () => actual.Rows[2]["Description"].ShouldBe("Select this option to upload a project file."));
        }

        [TestMethod]
        public void ISaveTemplate_WhenCalled_ReturnsString()
        {
            // Arrange
            const string expected = "<Result Status=\"0\"></Result>";
            var itemGetHit = 0;
            var data = new XmlDocument();

            data.LoadXml(expected);

            spFileCollection.CountGet = () => 0;
            spFolderCollection.ItemGetString = _ =>
            {
                itemGetHit += 1;
                if (itemGetHit.Equals(1))
                {
                    return null;
                }
                return spFolder;
            };
            spFolderCollection.AddString = _ =>
            {
                validations += 1;
                return spFolder;
            };
            spFileCollection.AddStringByteArrayBoolean = (_1, _2, _3) =>
            {
                validations += 1;
                return spFile;
            };
            spListItem.ItemSetStringObject = (_, __) =>
            {
                validations += 1;
            };
            spListItem.Update = () =>
            {
                validations += 1;
            };

            ShimWorkPlannerAPI.StrToByteArrayString = _ => default(byte[]);

            // Act
            var actual = (string)privateObject.Invoke(
                ISaveTemplateMethodName,
                nonPublicStatic,
                new object[] { DummyString, DummyString, DummyString, data, spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => itemGetHit.ShouldBe(2),
                () => validations.ShouldBe(7));
        }

        [TestMethod]
        public void SaveTemplate_PlannerIdEmpty_ReturnsString()
        {
            // Arrange
            const string expected = "<Result Status=\"1\">Planner Not Specified</Result>";
            var plannerId = string.Empty;
            var templateName = string.Empty;
            var dataXml = $@"<xmlcfg Planner=""{plannerId}"" TemplateName=""{templateName}"" Description=""Description""/>";
            var data = new XmlDocument();

            data.LoadXml(dataXml);

            ShimCoreFunctions.getLockedWebSPWeb = _ => guid;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) =>
            {
                validations += 1;
                return spWeb;
            };
            ShimWorkPlannerAPI.iSaveTemplateStringStringStringXmlDocumentSPWeb = (_1, _2, _3, _4, _5) =>
            {
                validations += 1;
                return DummyString;
            };

            // Act
            var actual = (string)privateObject.Invoke(SaveTemplateMethodName, publicStatic, new object[] { data, spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => validations.ShouldBe(0));
        }

        [TestMethod]
        public void SaveTemplate_TemplateNameEmpty_ReturnsString()
        {
            // Arrange
            const string plannerId = "1";
            const string expected = "<Result Status=\"1\">Template Name Not Specified</Result>";
            var templateName = string.Empty;
            var dataXml = $@"<xmlcfg Planner=""{plannerId}"" TemplateName=""{templateName}"" Description=""Description""/>";
            var data = new XmlDocument();

            data.LoadXml(dataXml);

            ShimCoreFunctions.getLockedWebSPWeb = _ => guid;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) =>
            {
                validations += 1;
                return spWeb;
            };
            ShimWorkPlannerAPI.iSaveTemplateStringStringStringXmlDocumentSPWeb = (_1, _2, _3, _4, _5) =>
            {
                validations += 1;
                return DummyString;
            };

            // Act
            var actual = (string)privateObject.Invoke(SaveTemplateMethodName, publicStatic, new object[] { data, spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => validations.ShouldBe(0));
        }

        [TestMethod]
        public void SaveTemplate_LockedWebEqualsSPWebTrue_ReturnsString()
        {
            // Arrange
            const string plannerId = "1";
            const string templateName = "TemplateName";
            var dataXml = $@"<xmlcfg Planner=""{plannerId}"" TemplateName=""{templateName}"" Description=""Description""/>";
            var data = new XmlDocument();

            data.LoadXml(dataXml);

            ShimCoreFunctions.getLockedWebSPWeb = _ => guid;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) =>
            {
                validations += 1;
                return spWeb;
            };
            ShimWorkPlannerAPI.iSaveTemplateStringStringStringXmlDocumentSPWeb = (_1, _2, _3, _4, _5) =>
            {
                validations += 1;
                return DummyString;
            };

            // Act
            var actual = (string)privateObject.Invoke(SaveTemplateMethodName, publicStatic, new object[] { data, spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(DummyString),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void SaveTemplate_LockedWebEqualsSPWebFalse_ReturnsString()
        {
            // Arrange
            const string plannerId = "1";
            const string templateName = "TemplateName";
            var dataXml = $@"<xmlcfg Planner=""{plannerId}"" TemplateName=""{templateName}"" Description=""Description""/>";
            var data = new XmlDocument();

            data.LoadXml(dataXml);

            ShimCoreFunctions.getLockedWebSPWeb = _ => Guid.Empty;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) =>
            {
                validations += 1;
                return spWeb;
            };
            ShimWorkPlannerAPI.iSaveTemplateStringStringStringXmlDocumentSPWeb = (_1, _2, _3, _4, _5) =>
            {
                validations += 1;
                return DummyString;
            };

            // Act
            var actual = (string)privateObject.Invoke(SaveTemplateMethodName, publicStatic, new object[] { data, spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(DummyString),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void GetTemplates_LockedWebEqualsSPWebTrue_ReturnsDataTable()
        {
            // Arrange
            var dataTable = new DataTable();
            var row = default(DataRow);

            dataTable.Columns.Add(DummyString);
            row = dataTable.NewRow();
            row[DummyString] = DummyString;
            dataTable.Rows.Add(row);

            ShimCoreFunctions.getLockedWebSPWeb = _ => guid;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) =>
            {
                validations += 1;
                return spWeb;
            };
            ShimWorkPlannerAPI.iGetTemplatesSPWebStringString = (_1, _2, _3) =>
            {
                validations += 1;
                return dataTable;
            };

            // Act
            var actual = (DataTable)privateObject.Invoke(GetTemplatesMethodName, publicStatic, new object[] { spWeb.Instance, DummyString, DummyString });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Rows.Count.ShouldBe(1),
                () => actual.Rows[0][DummyString].ShouldBe(DummyString),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void GetTemplates_LockedWebEqualsSPWebFalse_ReturnsDataTable()
        {
            // Arrange
            var dataTable = new DataTable();
            var row = default(DataRow);

            dataTable.Columns.Add(DummyString);
            row = dataTable.NewRow();
            row[DummyString] = DummyString;
            dataTable.Rows.Add(row);

            ShimCoreFunctions.getLockedWebSPWeb = _ => Guid.Parse(SampleGuidString2);
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) =>
            {
                validations += 1;
                return spWeb;
            };
            ShimWorkPlannerAPI.iGetTemplatesSPWebStringString = (_1, _2, _3) =>
            {
                validations += 1;
                return dataTable;
            };

            // Act
            var actual = (DataTable)privateObject.Invoke(GetTemplatesMethodName, publicStatic, new object[] { spWeb.Instance, DummyString, DummyString });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Rows.Count.ShouldBe(1),
                () => actual.Rows[0][DummyString].ShouldBe(DummyString),
                () => validations.ShouldBe(3));
        }

        [TestMethod]
        public void GetTaskFile_WhenCalled_ReturnsSPFile()
        {
            // Arrange
            spFile.ExistsGet = () => true;
            spListCollection.ItemGetString = _ => new ShimSPDocumentLibrary().Instance;

            ShimWorkPlannerAPI.UpgradeProjectScheduleLibrarySPWebStringStringSPFile = (_1, _2, _3, _4) =>
            {
                validations += 1;
            };

            // Act
            var actual = (SPFile)privateObject.Invoke(GetTaskFileMethodName, publicStatic, new object[] { spWeb.Instance, DummyString, DummyString });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldNotBeNull(),
                () => actual.Exists.ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void ProcessTaskXmlFromTaskCenter_WhenCalled_ReturnsString()
        {
            // Arrange
            const string dataXml = @"
                <xmlcfg>
                    <I id=""1""/>
                    <I id=""2""/>
                </xmlcfg>";
            var lastId = 0;
            var data = new XmlDocument();
            var dataTable = new DataTable();
            var row = default(DataRow);
            var props = new PlannerProps()
            {
                sListTaskCenter = DummyString
            };

            data.LoadXml(dataXml);
            dataTable.Columns.Add(TaskUidString);
            dataTable.Columns.Add(CommentCountString);
            dataTable.Columns.Add(AttachmentsString);
            row = dataTable.NewRow();
            row[TaskUidString] = 1;
            row[CommentCountString] = DummyString;
            row[AttachmentsString] = 1;
            dataTable.Rows.Add(row);
            row = dataTable.NewRow();
            row[TaskUidString] = 2;
            row[CommentCountString] = DummyString;
            row[AttachmentsString] = 0;
            dataTable.Rows.Add(row);
            spListItemCollection.GetDataTable = () => dataTable;

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(
                ProcessTaskXmlFromTaskCenterMethodName,
                nonPublicStatic,
                new object[] { data, props, spWeb.Instance, DummyString, lastId }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .Element("xmlcfg")
                    .Elements("I")
                    .FirstOrDefault(x => x.Attribute("id").Value.Equals("1"))
                    .Attribute("CommentCount")
                    .Value
                    .ShouldBe(DummyString),
                () => actual
                    .Element("xmlcfg")
                    .Elements("I")
                    .FirstOrDefault(x => x.Attribute("id").Value.Equals("1"))
                    .Attribute("Attachments")
                    .Value
                    .ShouldBe("True"),
                () => actual
                    .Element("xmlcfg")
                    .Elements("I")
                    .FirstOrDefault(x => x.Attribute("id").Value.Equals("2"))
                    .Attribute("Attachments")
                    .Value
                    .ShouldBe(string.Empty));
        }

        [TestMethod]
        public void GetTasks_AgileTrue_ReturnsString()
        {
            // Arrange
            const string dataXml = @"<xmlcfg Planner=""Planner"" ID=""1"" />";
            const string newXml = @"<xmlcfg/>";
            var data = new XmlDocument();
            var dataSet = new DataSet();
            var props = new PlannerProps()
            {
                bAgile = true
            };

            data.LoadXml(dataXml);
            spFile.OpenBinaryStream = () => new MemoryStream();
            ShimStreamReader.AllInstances.ReadToEnd = _ =>
            {
                validations += 1;
                return dataXml;
            };
            ShimWorkPlannerAPI.getSettingsSPWebString = (_1, _2) =>
            {
                validations += 1;
                return props;
            };
            ShimWorkPlannerAPI.GetTaskFileSPWebStringString = (_1, _2, _3) =>
            {
                validations += 1;
                return spFile;
            };
            ShimWorkPlannerAPI.GetResourceTableWorkPlannerAPIPlannerPropsGuidStringSPWeb = (_1, _2, _3, _4) =>
            {
                validations += 1;
                return dataSet;
            };
            ShimWorkPlannerAPI.AppendNewAgileTasksSPWebWorkPlannerAPIPlannerPropsXmlDocumentStringDataSet = (_1, _2, _3, _4, _5) =>
            {
                validations += 1;
                return newXml;
            };
            ShimWorkPlannerAPI.SaveWorkPlanXmlDocumentSPWeb = (_1, _2) =>
            {
                validations += 1;
                return DummyString;
            };

            // Act
            var actual = (string)privateObject.Invoke(GetTasksMethodName, publicStatic, new object[] { data, spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(newXml),
                () => validations.ShouldBe(6));
        }

        [TestMethod]
        public void GetTasks_AgileFalse_ReturnsString()
        {
            // Arrange
            const string predecessors = PredecessorsString;
            const string descendants = "Descendants";
            const string dataXml = @"<xmlcfg Planner=""Planner"" ID=""1"" />";
            var newXml = $@"
                <xmlcfg>
                    <I id=""{DummyInt}"" Predecessors=""{predecessors}"" Descendants=""{descendants}""/>
                </xmlcfg>";
            var data = new XmlDocument();
            var dataSet = new DataSet();
            var dataTable = new DataTable();
            var row = default(DataRow);
            var props = new PlannerProps()
            {
                bAgile = false
            };

            data.LoadXml(dataXml);
            dataTable.Columns.Add(LinkedString);
            dataTable.Columns.Add(SourceTaskIdString);
            dataTable.Columns.Add(PredecessorsString);
            dataTable.Columns.Add(SuccessorsString);
            dataTable.Columns.Add(DestProjectIdString);
            dataTable.Columns.Add(DestTaskIdString);
            row = dataTable.NewRow();
            row[LinkedString] = bool.TrueString;
            row[SourceTaskIdString] = 1;
            row[PredecessorsString] = PredecessorsString;
            row[SuccessorsString] = SuccessorsString;
            row[DestProjectIdString] = 1;
            row[DestTaskIdString] = 1;
            dataTable.Rows.Add(row);

            spFile.OpenBinaryStream = () => new MemoryStream();
            ShimStreamReader.AllInstances.ReadToEnd = _ =>
            {
                validations += 1;
                return newXml;
            };
            ShimWorkPlannerAPI.getSettingsSPWebString = (_1, _2) =>
            {
                validations += 1;
                return props;
            };
            ShimWorkPlannerAPI.GetTaskFileSPWebStringString = (_1, _2, _3) =>
            {
                validations += 1;
                return spFile;
            };
            ShimWorkPlannerAPI.GetResourceTableWorkPlannerAPIPlannerPropsGuidStringSPWeb = (_1, _2, _3, _4) =>
            {
                validations += 1;
                return dataSet;
            };
            ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSetToFill) =>
            {
                dataSetToFill.Tables.Add(dataTable);
                return DummyInt;
            };
            ShimWorkPlannerAPI.AddCustomFooterXmlDocumentStringString = (_1, _2, taskUpdates) =>
            {
                if (taskUpdates.Equals($"{DummyString}{DummyString}{DummyString}"))
                {
                    validations += 1;
                }
            };
            ShimWorkPlannerAPI.ProcessTaskXmlFromTaskCenterXmlDocumentWorkPlannerAPIPlannerPropsSPWebStringInt32Out =
                (XmlDocument doc, PlannerProps propsParameter, SPWeb web, string projectid, out int lastid) =>
                {
                    validations += 1;
                    lastid = 1;
                    return DummyString;
                };
            ShimWorkPlannerAPI.ProcessExternalXmlDocumentSPListStringStringStringBooleanDataSetXmlNodeBooleanStringInt32Ref =
                (XmlDocument doc, SPList oListTaskCenter, string predsucc, string projectid, string plannerid, bool before, DataSet dsResources, XmlNode ndTaskLinkedTO, bool bLinked, string curtaskid, ref int lastid) =>
                {
                    validations += 1;
                    return DummyString;
                };

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(GetTasksMethodName, publicStatic, new object[] { data, spWeb.Instance }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .Element("xmlcfg")
                    .Element("I")
                    .Attribute("Predecessors")
                    .Value
                    .ShouldBe($"Predecessors;myString"),
                () => actual
                    .Element("xmlcfg")
                    .Element("I")
                    .Attribute("Descendants")
                    .Value
                    .ShouldBe($"Descendants;myString"),
                () => validations
                    .ShouldBe(9));
        }

        [TestMethod]
        public void ProcessExternal_TaskNodeNullFieldTypeDateTimeBeforeTrue_ReturnsString()
        {
            // Arrange
            const bool linked = true;
            const bool before = true;
            const string taskId = "1";
            const string dataXml = @"
                <xmlcfg>
                    <I />
                </xmlcfg>";
            var lastId = 0;
            var now = DateTime.Now;
            var data = new XmlDocument();
            var node = default(XmlNode);

            data.LoadXml(dataXml);
            node = data.DocumentElement.FirstChild;

            spField.TypeGet = () => SPFieldType.DateTime;
            ShimWorkPlannerAPI.getFieldValueSPListItemSPFieldDataSet = (_1, _2, _3) => now.ToString();
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPField>()
            {
                spField
            }.GetEnumerator();

            // Act
            var actual = (string)privateObject.Invoke(
                ProcessExternalMethodName,
                nonPublicStatic,
                new object[] { data, spList.Instance, DummyString, DummyString, DummyString, before, default(DataSet), node, linked, taskId, lastId });

            // Assert
            actual.ShouldBe(",A:1");
        }

        [TestMethod]
        public void ProcessExternal_TaskNodeNullFieldTypeNotDateTimeBeforeFalse_ReturnsString()
        {
            // Arrange
            const bool linked = true;
            const bool before = false;
            const string dataXml = @"
                <xmlcfg>
                    <I />
                </xmlcfg>";
            var lastId = 0;
            var data = new XmlDocument();
            var node = default(XmlNode);

            data.LoadXml(dataXml);
            node = data.DocumentElement.FirstChild;

            spField.TypeGet = () => SPFieldType.Calculated;
            ShimWorkPlannerAPI.getFieldValueSPListItemSPFieldDataSet = (_1, _2, _3) => DummyString;
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPField>()
            {
                spField
            }.GetEnumerator();

            // Act
            var actual = (string)privateObject.Invoke(
                ProcessExternalMethodName,
                nonPublicStatic,
                new object[] { data, spList.Instance, DummyString, DummyString, DummyString, before, default(DataSet), node, linked, string.Empty, lastId });

            // Assert
            actual.ShouldBe(",A:1");
        }

        [TestMethod]
        public void ProcessExternal_TaskNodeNotNull_ReturnsString()
        {
            // Arrange
            const bool linked = true;
            const bool before = false;
            const string taskId = "1";
            var now = DateTime.Now;
            var dataXml = $@"
                <xmlcfg>
                    <I id=""{taskId}"" StartDate=""{now}"" DueDate=""{now.AddDays(1)}"" />
                </xmlcfg>";
            var lastId = 0;
            var data = new XmlDocument();
            var node = default(XmlNode);

            data.LoadXml(dataXml);
            node = data.DocumentElement.FirstChild;

            spField.TypeGet = () => SPFieldType.Calculated;
            ShimWorkPlannerAPI.getFieldValueSPListItemSPFieldDataSet = (_1, _2, _3) => DummyString;
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPField>()
            {
                spField
            }.GetEnumerator();

            // Act
            var actual = (string)privateObject.Invoke(
                ProcessExternalMethodName,
                nonPublicStatic,
                new object[] { data, spList.Instance, DummyString, DummyString, DummyString, before, default(DataSet), node, linked, taskId, lastId });

            // Assert
            actual.ShouldBe($",U:{taskId}");
        }

        [TestMethod]
        public void GetExternalLinkLayout_WhenCalled_ReturnsString()
        {
            // Arrange
            const string dataXml = @"
                <xmlcfg>
                    <I />
                    <I />
                    <I />
                    <Grid />
                </xmlcfg>";
            var data = new XmlDocument();
            data.LoadXml(dataXml);

            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => dataXml;

            // Act
            privateObject.Invoke(AddCustomFooterMethodName, nonPublicStatic, new object[] { data, DummyString, DummyString });
            var actual = XDocument.Parse((string)privateObject.Invoke(GetExternalLinkLayoutMethodName, publicStatic, new object[] { data, spWeb.Instance }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .Element("xmlcfg")
                    .Elements("I")
                    .Count()
                    .ShouldBe(3));
        }

        [TestMethod]
        public void GetUpdates_WhenCalled_ReturnsString()
        {
            // Arrange
            const string dataXml = @"<xmlcfg ID=""1"" Planner=""1""/>";
            const string docResXmlString = @"
                <xmlcfg Status=""0"">
                    <tables>
                        <I task_id=""0"" uid=""0"" itemid=""0""/>
                        <C Task_Id=""0"" Name=""CName"" field_text=""field_text""/>
                    </tables>
                </xmlcfg>";
            const string docGridXmlString = @"
                <xmlcfg Status=""0"">
                    <Cols></Cols>
                    <Header></Header>
                    <B></B>
                </xmlcfg>";
            var data = new XmlDocument();
            var props = new PlannerProps()
            {
                sListProjectCenter = DummyString
            };

            data.LoadXml(dataXml);

            ShimWorkEngineAPI.GetUpdatesStringSPWeb = (_, __) =>
            {
                validations += 1;
                return docResXmlString;
            };
            ShimWorkPlannerAPI.getSettingsSPWebString = (_1, _2) =>
            {
                validations += 1;
                return props;
            };
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) =>
            {
                validations += 1;
                return docGridXmlString;
            };

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(GetUpdatesMethodName, publicStatic, new object[] { data, spWeb.Instance }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .Element("xmlcfg")
                    .Element("Cols")
                    .Elements("C")
                    .Count(x => x.Attribute("Name").Value.Equals("SPID"))
                    .ShouldBe(1),
                () => actual
                    .Element("xmlcfg")
                    .Element("Header")
                    .Attribute("CName")
                    .Value
                    .ShouldBe(DummyString),
                () => actual
                    .Element("xmlcfg")
                    .Element("Cols")
                    .Elements("C")
                    .Count(x => x.Attribute("Name").Value.Equals("CName"))
                    .ShouldBe(1),
                () => actual
                    .Element("xmlcfg")
                    .Element("B")
                    .Elements("I")
                    .Count(x => x.Attribute("id").Value.Equals("0") && x.Attribute("SPID").Value.Equals("0") && x.Attribute("CName").Value.Equals("field_text"))
                    .ShouldBe(1),
                () => validations
                    .ShouldBe(3));
        }

        [TestMethod]
        public void GetFieldValue_PercentComplete_ReturnsString()
        {
            // Arrange
            const string field = "PercentComplete";
            const string value = "0.5";

            // Act
            var actual = (string)privateObject.Invoke(GetFieldValueMethodName, nonPublicStatic, new object[] { field, value });

            // Assert
            actual.ShouldBe("50");
        }

        [TestMethod]
        public void GetFieldValue_StartDate_ReturnsString()
        {
            // Arrange
            const string field = "StartDate";
            const string format = "dddd, dd MMMM yyyy";
            var now = DateTime.Now;
            var value = now.ToString();

            // Act
            var actual = (string)privateObject.Invoke(GetFieldValueMethodName, nonPublicStatic, new object[] { field, value });

            // Assert
            actual.ShouldBe(now.ToString(format));
        }

        [TestMethod]
        public void AppendSpecialColumns_WhenCalled_AddsColumns()
        {
            // Arrange
            const string dataXmlString = @"
                <xmlcfg>
                    <Cols/>
                </xmlcfg>";
            var data = new XmlDocument();
            var colsNode = default(XmlNode);

            data.LoadXml(dataXmlString);
            colsNode = data.FirstChild.SelectSingleNode("//Cols");

            // Act
            privateObject.Invoke(AppendSpecialColumnsMethodName, publicStatic, new object[] { data, colsNode });

            // Assert
            colsNode.ChildNodes.Count.ShouldBe(11);
        }
    }
}