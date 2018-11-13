using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Resources.Fakes;
using System.Web.Fakes;
using System.Xml;
using System.Xml.Fakes;
using System.Xml.Linq;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportingProxy.Fakes;
using EPMLiveWorkPlanner.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using static EPMLiveWorkPlanner.WorkPlannerAPI;

namespace EPMLiveWorkPlanner.Tests.ISAPI
{
    public partial class WorkPlannerAPITests
    {
        private const string ReOrderAndSaveItemMethodName = "ReOrderAndSaveItem";
        private const string GetKanBanBoardMethodName = "GetKanBanBoard";
        private const string GetProjectInfoMethodName = "GetProjectInfo";
        private const string GetAssignmentLayoutMethodName = "GetAssignmentLayout";
        private const string GetLinksLayoutMethodName = "GetLinksLayout";
        private const string GetAllocationLayoutMethodName = "GetAllocationLayout";
        private const string GetAddLinksLayoutMethodName = "GetAddLinksLayout";
        private const string ProcessAllocationResourcesColsMethodName = "ProcessAllocationResourcesCols";

        [TestMethod]
        public void ReOrderAndSaveItem_WhenCalled_ReturnsString()
        {
            // Arrange
            var dataXmlString = string.Format(@"
                <xmlcfg>
                    <data-siteid>{2}</data-siteid>
                    <data-webid>{2}</data-webid>
                    <data-listid>{2}</data-listid>
                    <data-itemid>{1}</data-itemid>
                    <data-userid>{0}</data-userid>
                    <data-icon>{0}</data-icon>
                    <data-type>{0}</data-type>
                    <data-fstring>{0}</data-fstring>
                    <data-fdate>{0}</data-fdate>
                    <data-fint>{1}</data-fint>
                    <data-dragged-status>{0}</data-dragged-status>
                    <data-index-of-item>{1}</data-index-of-item>
                </xmlcfg>",
                DummyString, DummyInt, SampleGuidString1);
            var data = new XmlDocument();
            var plannerProps = new PlannerProps()
            {
                KanBanStatusColumn = DummyString
            };

            data.LoadXml(dataXmlString);

            spWeb.AllowUnsafeUpdatesSetBoolean = _ =>
            {
                validations += 1;
            };
            spListItem.ItemSetStringObject = (key, value) =>
            {
                var stringValue = (string)value;
                if (string.IsNullOrEmpty(stringValue))
                {
                    validations += 1;
                }
            };
            spListItem.Update = () =>
            {
                validations += 1;
            };

            ShimWorkPlannerAPI.getSettingsSPWebString = (_, __) =>
            {
                validations += 1;
                return plannerProps;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                validations += 1;
                return DummyInt;
            };

            // Act
            var actual = (string)privateObject.Invoke(
                ReOrderAndSaveItemMethodName,
                publicStatic,
                new object[]
                {
                    data,
                    spWeb.Instance
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(string.Empty),
                () => validations.ShouldBe(6));
        }

        [TestMethod]
        public void GetKanBanBoard_WhenCalled_ReturnsString()
        {
            // Arrange
            const string kanBanBoardName = "KanBanBoardName";
            var dataXmlString = $@"
                <xmlcfg>
                    <KanBanBoardName>{kanBanBoardName}</KanBanBoardName>
                    <KanBanFilter1>KanBanFilter1</KanBanFilter1>
                    <ID>ID</ID>
                </xmlcfg>";
            var data = new XmlDocument();
            var outputXmlDocument = new XmlDocument();
            var plannerProps = new PlannerProps()
            {
                sListTaskCenter = DummyString,
                KanBanFilterColumn = DummyString,
                KanBanTitleColumn = DummyString,
                KanBanAdditionalColumns = DummyString,
                KanBanStatusColumn = DummyString
            };
            var columnsDataTable = new DataTable();
            var sourceListData = new DataTable();
            var row = default(DataRow);
            var statusValues = new StringCollection()
            {
                kanBanBoardName
            };
            var methodHit = 0;

            data.LoadXml(dataXmlString);

            columnsDataTable.Columns.Add("ColumnName");
            columnsDataTable.Columns.Add("SharePointType");

            row = columnsDataTable.NewRow();
            row["ColumnName"] = DummyString;
            row["SharePointType"] = DummyString;
            columnsDataTable.Rows.Add(row);

            row = columnsDataTable.NewRow();
            row["ColumnName"] = $"{DummyString}id";
            row["SharePointType"] = "lookup";
            columnsDataTable.Rows.Add(row);

            sourceListData.Columns.Add("ID");
            sourceListData.Columns.Add(DummyString);

            row = sourceListData.NewRow();
            row["ID"] = DummyInt;
            row[DummyString] = "RandomString";
            sourceListData.Rows.Add(row);

            spField.TypeGet = () => SPFieldType.User;
            spFieldCollection.GetFieldString = _ => new ShimSPFieldChoice().Instance;
            ShimSPFieldMultiChoice.AllInstances.ChoicesGet = _ => statusValues;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.User;
            ShimHttpUtility.HtmlDecodeString = input => input;
            ShimHttpUtility.HtmlEncodeString = input => input;
            ShimWorkPlannerAPI.getSettingsSPWebString = (_, __) => plannerProps;
            ShimQueryExecutor.AllInstances.ExecuteReportingDBQueryStringIDictionaryOfStringObject = (_, _1, _2) => columnsDataTable;
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString = (_1, _2, _3, _4, _5) => sourceListData;
            ShimDbDataAdapter.AllInstances.FillDataTable = (instance, frfDataTable) =>
            {
                frfDataTable.Columns.Add("ITEM_ID");
                frfDataTable.Columns.Add("F_INT");
                row = frfDataTable.NewRow();
                row["ITEM_ID"] = DummyInt;
                row["F_INT"] = DummyInt;
                frfDataTable.Rows.Add(row);
                return DummyInt;
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (_, input) =>
            {
                methodHit += 1;
                if (methodHit.Equals(1))
                {
                    return kanBanBoardName;
                }
                return DummyString;
            };

            // Act
            var outputString = ((string)privateObject.Invoke(
                GetKanBanBoardMethodName,
                publicStatic,
                new object[]
                {
                    data,
                    spWeb.Instance
                }))
                .Replace("&nbsp;", string.Empty);

            outputXmlDocument.LoadXml(outputString);
            var actual = XDocument.Parse(outputString);
            var sortableListOne = default(XElement);
            var sortableListTwo = default(XElement);
            var sortableItem = default(XElement);

            var tdOne = actual.Element("table")
                .Element("tbody")
                .Element("tr")
                .Elements("td")
                .FirstOrDefault(x => x.Attribute("id") != null);
            var tdTwo = actual.Element("table")
                .Element("tbody")
                .Element("tr")
                .Elements("td")
                .FirstOrDefault(x => x.Attribute("id") == null);
            if (tdOne != null)
            {
                sortableListOne = tdOne
                    .Element("div")
                    .Elements("div")
                    .FirstOrDefault(x => x.Attribute("class").Value.Equals("sortable-list"));
            }
            if (tdTwo != null)
            {
                sortableListTwo = tdTwo.Element("div")
                    .Elements("div")
                    .FirstOrDefault(x => x.Attribute("class").Value.Equals("sortable-list"));
            }
            if (sortableListOne != null)
            {
                sortableItem = sortableListOne.Elements("div")
                    .FirstOrDefault(x => x.Attribute("class").Value.Equals("sortable-item"));
            }

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => outputXmlDocument
                    .GetElementsByTagName("div")
                    .Count
                    .ShouldBe(10),
                () => sortableListOne
                    .Attribute("data-dragged-status")
                    .Value
                    .ShouldBe(DummyString),
                () => sortableListOne
                    .Attribute("id")
                    .Value
                    .ShouldBe(DummyString),
                () => sortableListTwo
                    .Attribute("data-dragged-status")
                    .Value
                    .ShouldBe(kanBanBoardName),
                () => sortableListTwo
                    .Attribute("id")
                    .Value
                    .ShouldBe(kanBanBoardName),
                () => sortableItem
                    .Attribute("data-siteid")
                    .Value
                    .ShouldBe(SampleGuidString1),
                () => sortableItem
                    .Attribute("data-webid")
                    .Value
                    .ShouldBe(SampleGuidString1),
                () => sortableItem
                    .Attribute("data-listid")
                    .Value
                    .ShouldBe(SampleGuidString1),
                () => tdTwo
                    .Element("div")
                    .Elements("div")
                    .FirstOrDefault(x => x.Attribute("class").Value.Equals("stageContainerTitle"))
                    .Value
                    .ShouldBe(kanBanBoardName));
        }

        [TestMethod]
        public void GetProjectInfo_WhenCalled_ReturnsString()
        {
            // Arrange
            const string dataXmlString = @"
                <xmlcfg Planner=""1"" ID=""1"">
                    <B/>
                </xmlcfg>";
            var data = new XmlDocument();
            var plannerProps = new PlannerProps()
            {
                sListProjectCenter = DummyString
            };

            data.LoadXml(dataXmlString);
            spField.SchemaXmlGet = () => dataXmlString;
            spField.TypeGet = () => SPFieldType.User;

            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => dataXmlString;
            ShimWorkPlannerAPI.getSettingsSPWebString = (_, __) =>
            {
                validations += 1;
                return plannerProps;
            };
            ShimWorkPlannerAPI.SetupProjectCenterListSPListString = (_, __) =>
            {
                validations += 1;
            };
            ShimWorkPlannerAPI.GetResourceTableWorkPlannerAPIPlannerPropsGuidStringSPWeb = (_1, _2, _3, _4) =>
            {
                validations += 1;
                return default(DataSet);
            };
            ShimListCommands.GetGridGanttSettingsSPList = _ =>
            {
                validations += 1;
                return new ShimGridGanttSettings();
            };
            ShimListDisplayUtils.ConvertFromStringString = _ =>
            {
                validations += 1;
                return new Dictionary<string, Dictionary<string, string>>();
            };
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPField>()
            {
                spField
            }.GetEnumerator();
            ShimWorkPlannerAPI.isValidFieldStringBoolean = (_, __) =>
            {
                validations += 1;
                return true;
            };
            ShimWorkPlannerAPI.getFieldValueSPListItemSPFieldDataSet = (_1, _2, _3) =>
            {
                validations += 1;
                return DummyString;
            };
            ShimWorkPlannerAPI.getFormatSPFieldXmlDocumentStringOutSPWeb = (SPField oField, XmlDocument oDoc, out string EditFormat, SPWeb oWeb) =>
            {
                validations += 1;
                EditFormat = DummyString;
                return DummyString;
            };
            ShimEditableFieldDisplay.isEditableSPListItemSPFieldDictionaryOfStringDictionaryOfStringString = (_1, _2, _3) =>
            {
                validations += 1;
                return false;
            };
            ShimWorkPlannerAPI.setEnumFieldSPFieldXmlNodeRefXmlDocumentXmlDocumentSPWebBooleanStringDataSet = (SPField oField, ref XmlNode ndCol, XmlDocument fieldDoc, XmlDocument docOut, SPWeb web, bool multi, string enumattr, DataSet dsResources) =>
            {
                validations += 1;
            };

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(
                GetProjectInfoMethodName,
                publicStatic,
                new object[]
                {
                    data,
                    spWeb.Instance
                }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .Element("xmlcfg")
                    .Element("B")
                    .Element("I")
                    .Attribute("id")
                    .Value
                    .ShouldBe(DummyString),
                () => actual
                    .Element("xmlcfg")
                    .Element("B")
                    .Element("I")
                    .Attribute("CanEdit")
                    .Value
                    .ShouldBe("0"),
                () => actual
                    .Element("xmlcfg")
                    .Element("B")
                    .Element("I")
                    .Attribute("NoColorState")
                    .Value
                    .ShouldBe("1"),
                () => validations
                    .ShouldBe(10));
        }

        [TestMethod]
        public void SetEnumField_SPFieldTypeChoice_EditsNode()
        {
            // Arrange
            const string expected = "|  | CHOICE1| CHOICE2";
            const string dataXmlString = @"<xmlcfg/>";
            const string fieldDocXmlString = @"
                <xmlcfg>
                    <CHOICES>
                        <CHOICE>CHOICE1</CHOICE>
                        <CHOICE>CHOICE2</CHOICE>
                    </CHOICES>
                </xmlcfg>";
            var dataXml = new XmlDocument();
            var fieldDocXml = new XmlDocument();
            var node = default(XmlNode);

            dataXml.LoadXml(dataXmlString);
            fieldDocXml.LoadXml(fieldDocXmlString);
            node = dataXml.FirstChild;

            spField.TypeGet = () => SPFieldType.Choice;
            spField.RequiredGet = () => false;

            // Act
            WorkPlannerAPI.setEnumField(spField.Instance, ref node, fieldDocXml, dataXml, spWeb.Instance, true, DummyString, null);

            // Assert
            node.ShouldSatisfyAllConditions(
                () => node.Attributes.GetNamedItem($"{DummyString}IconAlign").Value.ShouldBe("Right"),
                () => node.Attributes.GetNamedItem($"{DummyString}Enum").Value.ShouldBe(expected));
        }

        [TestMethod]
        public void SetEnumField_SPFieldTypeMultiChoice_EditsNode()
        {
            // Arrange
            const string expected = "|CHOICE1|CHOICE2";
            const string dataXmlString = @"<xmlcfg/>";
            const string fieldDocXmlString = @"
                <xmlcfg>
                    <CHOICES>
                        <CHOICE>CHOICE1</CHOICE>
                        <CHOICE>CHOICE2</CHOICE>
                    </CHOICES>
                </xmlcfg>";
            var dataXml = new XmlDocument();
            var fieldDocXml = new XmlDocument();
            var node = default(XmlNode);

            dataXml.LoadXml(dataXmlString);
            fieldDocXml.LoadXml(fieldDocXmlString);
            node = dataXml.FirstChild;

            spField.TypeGet = () => SPFieldType.MultiChoice;
            spField.RequiredGet = () => false;

            // Act
            WorkPlannerAPI.setEnumField(spField.Instance, ref node, fieldDocXml, dataXml, spWeb.Instance, true, DummyString, null);

            // Assert
            node.ShouldSatisfyAllConditions(
                () => node.Attributes.GetNamedItem($"{DummyString}IconAlign").Value.ShouldBe("Right"),
                () => node.Attributes.GetNamedItem($"{DummyString}Enum").Value.ShouldBe(expected),
                () => node.Attributes.GetNamedItem($"{DummyString}Range").Value.ShouldBe("1"));
        }

        [TestMethod]
        public void SetEnumField_SPFieldTypeLookup_EditsNode()
        {
            // Arrange
            const string LookupMultiString = "LookupMulti";
            const string dataXmlString = @"<xmlcfg/>";
            var fieldDocXmlString = $@"<xmlcfg List=""{SampleGuidString1}""/>";
            var expectedEnumKey = $"|{DummyInt}|{DummyInt}";
            var expectedEnum = $"|{DummyString}|{DummyString}";
            var dataXml = new XmlDocument();
            var fieldDocXml = new XmlDocument();
            var node = default(XmlNode);

            dataXml.LoadXml(dataXmlString);
            fieldDocXml.LoadXml(fieldDocXmlString);
            node = dataXml.FirstChild;

            spField.TypeGet = () => SPFieldType.Lookup;
            spField.RequiredGet = () => false;
            spField.TypeAsStringGet = () => LookupMultiString;

            ShimSPListItemCollection.AllInstances.GetEnumerator = _ => new List<SPListItem>()
            {
                spListItem,
                spListItem
            }.GetEnumerator();

            // Act
            WorkPlannerAPI.setEnumField(spField.Instance, ref node, fieldDocXml, dataXml, spWeb.Instance, true, DummyString, null);

            // Assert
            node.ShouldSatisfyAllConditions(
                () => node.Attributes.GetNamedItem($"{DummyString}IconAlign").Value.ShouldBe("Right"),
                () => node.Attributes.GetNamedItem($"{DummyString}Enum").Value.ShouldBe(expectedEnum),
                () => node.Attributes.GetNamedItem($"{DummyString}EnumKeys").Value.ShouldBe(expectedEnumKey),
                () => node.Attributes.GetNamedItem($"{DummyString}Range").Value.ShouldBe("1"));
        }

        [TestMethod]
        public void SetEnumField_SPFieldTypeUser_EditsNode()
        {
            // Arrange
            const string UserMultiString = "UserMulti";
            const string dataXmlString = @"<xmlcfg/>";
            var fieldDocXmlString = $@"<xmlcfg List=""{SampleGuidString1}""/>";
            var expectedEnumKey = $"|{DummyInt}|{DummyInt}";
            var expectedEnum = $"|{DummyString}|{DummyString}";
            var dataXml = new XmlDocument();
            var fieldDocXml = new XmlDocument();
            var node = default(XmlNode);
            var dataSet = new DataSet();
            var row = default(DataRow);

            dataXml.LoadXml(dataXmlString);
            fieldDocXml.LoadXml(fieldDocXmlString);
            node = dataXml.FirstChild;

            spField.TypeGet = () => SPFieldType.User;
            spField.RequiredGet = () => false;
            spField.TypeAsStringGet = () => UserMultiString;

            dataSet.Tables.Add(new DataTable());
            dataSet.Tables.Add(new DataTable());
            dataSet.Tables.Add(new DataTable());

            dataSet.Tables[2].Columns.Add(TitleString);
            dataSet.Tables[2].Columns.Add(IDStringCaps);
            row = dataSet.Tables[2].NewRow();
            row[TitleString] = DummyString;
            row[IDStringCaps] = DummyInt;
            dataSet.Tables[2].Rows.Add(row);
            row = dataSet.Tables[2].NewRow();
            row[TitleString] = DummyString;
            row[IDStringCaps] = DummyInt;
            dataSet.Tables[2].Rows.Add(row);

            ShimSPListItemCollection.AllInstances.GetEnumerator = _ => new List<SPListItem>()
            {
                spListItem,
                spListItem
            }.GetEnumerator();

            // Act
            WorkPlannerAPI.setEnumField(spField.Instance, ref node, fieldDocXml, dataXml, spWeb.Instance, true, DummyString, dataSet);

            // Assert
            node.ShouldSatisfyAllConditions(
                () => node.Attributes.GetNamedItem($"{DummyString}IconAlign").Value.ShouldBe("Right"),
                () => node.Attributes.GetNamedItem($"{DummyString}Enum").Value.ShouldBe(expectedEnum),
                () => node.Attributes.GetNamedItem($"{DummyString}EnumKeys").Value.ShouldBe(expectedEnumKey),
                () => node.Attributes.GetNamedItem($"{DummyString}Range").Value.ShouldBe("1"));
        }

        [TestMethod]
        public void GetAssignmentLayout_WhenCalled_ReturnsString()
        {
            // Arrange
            const string dataXmlString = @"<xmlcfg Planner=""1""/>";
            var data = new XmlDocument();

            data.LoadXml(dataXmlString);

            ShimWorkPlannerAPI.getSettingsSPWebString = (_, __) =>
            {
                validations += 1;
                return default(PlannerProps);
            };
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) =>
            {
                validations += 1;
                return dataXmlString;
            };

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(
                GetAssignmentLayoutMethodName,
                publicStatic,
                new object[]
                {
                    data,
                    spWeb.Instance
                }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .Element("xmlcfg")
                    .Attribute("Planner")
                    .Value
                    .ShouldBe("1"),
                () => validations
                    .ShouldBe(2));
        }

        [TestMethod]
        public void GetLinksLayout_WhenCalled_ReturnsString()
        {
            // Arrange
            const string dataXmlString = @"<xmlcfg Planner=""1""/>";
            var data = new XmlDocument();

            data.LoadXml(dataXmlString);

            ShimWorkPlannerAPI.getSettingsSPWebString = (_, __) =>
            {
                validations += 1;
                return default(PlannerProps);
            };
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) =>
            {
                validations += 1;
                return dataXmlString;
            };

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(
                GetLinksLayoutMethodName,
                publicStatic,
                new object[]
                {
                    data,
                    spWeb.Instance
                }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .Element("xmlcfg")
                    .Attribute("Planner")
                    .Value
                    .ShouldBe("1"),
                () => validations
                    .ShouldBe(2));
        }

        [TestMethod]
        public void GetAllocationLayout_WhenCalled_ReturnsString()
        {
            // Arrange
            const string dataXmlString = @"<xmlcfg Planner=""1""/>";
            var data = new XmlDocument();

            data.LoadXml(dataXmlString);

            ShimWorkPlannerAPI.getSettingsSPWebString = (_, __) =>
            {
                validations += 1;
                return default(PlannerProps);
            };
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) =>
            {
                validations += 1;
                return dataXmlString;
            };

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(GetAllocationLayoutMethodName, publicStatic, new object[] { data, spWeb.Instance }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .Element("xmlcfg")
                    .Attribute("Planner")
                    .Value
                    .ShouldBe("1"),
                () => validations
                    .ShouldBe(2));
        }

        [TestMethod]
        public void GetAddLinksLayout_WhenCalled_ReturnsString()
        {
            // Arrange
            const string dataXmlString = @"<xmlcfg Planner=""1""/>";
            var data = new XmlDocument();

            data.LoadXml(dataXmlString);

            ShimWorkPlannerAPI.getSettingsSPWebString = (_, __) =>
            {
                validations += 1;
                return default(PlannerProps);
            };
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) =>
            {
                validations += 1;
                return dataXmlString;
            };

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(
                GetAddLinksLayoutMethodName,
                publicStatic,
                new object[]
                {
                    data,
                    spWeb.Instance
                }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .Element("xmlcfg")
                    .Attribute("Planner")
                    .Value
                    .ShouldBe("1"),
                () => validations
                    .ShouldBe(2));
        }

        [TestMethod]
        public void ProcessAllocationResourcesCols_WhenCalled_AppendsChild()
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
            spField.ReorderableGet = () => true;

            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPField>()
            {
                spField,
                spField
            }.GetEnumerator();
            ShimXmlNode.AllInstances.AppendChildXmlNode = (parentNode, childNode) =>
            {
                if (childNode.Name.Equals("C"))
                {
                    validations += 1;
                    if (childNode.Attributes.GetNamedItem("Name").Value.Equals(DummyString))
                    {
                        validations += 1;
                    }
                }
                ShimsContext.ExecuteWithoutShims(() =>
                {
                    parentNode.AppendChild(childNode);
                });
                return childNode;
            };

            // Act
            var actual = privateObject.Invoke(
                ProcessAllocationResourcesColsMethodName,
                nonPublicStatic,
                new object[]
                {
                    colsNode,
                    spWeb.Instance
                });

            // Assert
            validations.ShouldBe(4);
        }
    }
}