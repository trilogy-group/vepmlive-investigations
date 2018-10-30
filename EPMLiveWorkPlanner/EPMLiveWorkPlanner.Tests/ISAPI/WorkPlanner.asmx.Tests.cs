using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Resources.Fakes;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using EPMLiveCore.Fakes;
using EPMLiveWorkPlanner.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using static EPMLiveWorkPlanner.WorkPlannerAPI;

namespace EPMLiveWorkPlanner.Tests.ISAPI
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WorkPlannerAPITests
    {
        private WorkPlannerAPI testObject;
        private PrivateObject privateObject;
        private IDisposable shimsContext;
        private BindingFlags publicStatic;
        private BindingFlags publicInstance;
        private BindingFlags nonPublicInstance;
        private BindingFlags nonPublicStatic;
        private ShimSPWeb spWeb;
        private ShimSPSite spSite;
        private ShimSPListCollection spListCollection;
        private ShimSPList spList;
        private ShimSPListItem spListItem;
        private ShimSPFieldCollection spFieldCollection;
        private ShimSPField spField;
        private Guid guid;
        private int validations;
        private const string SampleGuidString = "83e81819-0112-4c22-bb70-d8ba101e9e0c";
        private const string DummyString = "DummyString";
        private const string GetExternalProjectsMethodName = "GetExternalProjects";
        private const string ImportTasksMethodName = "ImportTasks";
        private const string GetPlannersByProjectListMethodName = "GetPlannersByProjectList";
        private const string GetPlannersByTaskListMethodName = "GetPlannersByTaskList";
        private const string GetUpdateDetailLayoutMethodName = "GetUpdateDetailLayout";
        private const string ImportTasksFixXmlStructureMethodName = "ImportTasksFixXmlStructure";
        private const string SaveProjectMethodName = "SaveProject";

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

            ShimSPFieldLookupValueCollection.Constructor = _ => new ShimSPFieldLookupValueCollection();
            ShimSPFieldLookupValue.ConstructorString = (_, __) => new ShimSPFieldLookupValue();
            ShimSPSite.ConstructorGuid = (_, __) => new ShimSPSite();
            ShimSPSite.AllInstances.OpenWeb = _ => spWeb;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => spWeb;
            ShimSPSite.AllInstances.Dispose = _ => { };
            ShimSPWeb.AllInstances.Dispose = _ => { };
            ShimCoreFunctions.getLockedWebSPWeb = _ => guid;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => DummyString;
            ShimCoreFunctions.getListSettingStringSPList = (_, __) => DummyString;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();
        }

        private void SetupVariables()
        {
            validations = 0;
            publicStatic = BindingFlags.Static | BindingFlags.Public;
            publicInstance = BindingFlags.Instance | BindingFlags.Public;
            nonPublicInstance = BindingFlags.Instance | BindingFlags.NonPublic;
            nonPublicStatic = BindingFlags.Static | BindingFlags.NonPublic;
            guid = Guid.Parse(SampleGuidString);
            spWeb = new ShimSPWeb()
            {
                IDGet = () => guid,
                SiteGet = () => spSite,
                ListsGet = () => spListCollection
            };
            spSite = new ShimSPSite()
            {
                IDGet = () => guid
            };
            spListCollection = new ShimSPListCollection()
            {
                TryGetListString = _ => spList,
                ItemGetString = _ => spList
            };
            spList = new ShimSPList()
            {
                IDGet = () => guid,
                FieldsGet = () => spFieldCollection,
                GetItemByIdInt32 = _ => spListItem
            };
            spListItem = new ShimSPListItem()
            {
                ItemSetGuidObject = (_, __) => { },
                Update = () => { }
            };
            spFieldCollection = new ShimSPFieldCollection()
            {
                GetFieldByInternalNameString = _ => spField
            };
            spField = new ShimSPField()
            {
                IdGet = () => guid,
                TitleGet = () => DummyString,
                ReadOnlyFieldGet = () => false,
                TypeAsStringGet = () => DummyString
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
            dataTable.Columns.Add("Title");
            dataTable.Columns.Add("Start");
            dataTable.Columns.Add("Finish");
            dataTable.Columns.Add("ID");
            var row = dataTable.NewRow();
            row["Title"] = DummyString;
            row["Start"] = now;
            row["Finish"] = now;
            row["ID"] = DummyString;
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
                    var newNode = returnDocument.CreateNode(XmlNodeType.Element, "Item", returnDocument.NamespaceURI);
                    var statusAttribute = returnDocument.CreateAttribute("Status");

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
                    var newNode = returnDocument.CreateNode(XmlNodeType.Element, "Item", returnDocument.NamespaceURI);
                    var statusAttribute = returnDocument.CreateAttribute("Status");

                    statusAttribute.Value = "1";
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
                    InternalNameGet = () => "User",
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
                    .FirstOrDefault(x => x.Attribute("id").Value.Equals("Title"))
                    .Attribute("N")
                    .Value
                    .ShouldBe(DummyString),
                () => actual
                    .Element("Body")
                    .Element("B")
                    .Elements("I")
                    .Count(x => x.Attribute("id").Value.Equals("User") && x.Attribute("N").Value.Equals(DummyString))
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
            resourceDataSet.Tables[2].Columns.Add("ID");
            resourceDataSet.Tables[2].Columns.Add("SPAccountInfo");
            row = resourceDataSet.Tables[2].NewRow();
            row["ID"] = DummyString;
            row["SPAccountInfo"] = DummyString;

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
    }
}