using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient.Fakes;
using System.Globalization;
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
        private const string GetFormatMethodName = "getFormat";
        private const string AddFieldNodeToDefMethodName = "addFieldNodeToDef";
        private const string ProcessIndividualFieldMethodName = "processIndividualField";
        private const string GetRealFieldMethodName = "getRealField";
        private const string ProcessFieldMethodName = "processField";
        private const string GetSettingsMethodName = "getSettings";
        private const string GetKanBanPlannersMethodName = "GetKanBanPlanners";
        private const string GetKanBanFilter1MethodName = "GetKanBanFilter1";
        private const string TableNameString = "TableName";
        private const string SharePointTypeString = "SharePointType";
        private const string ColumnNameString = "ColumnName";
        private const string ValueString = "Value";

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

            columnsDataTable.Columns.Add(ColumnNameString);
            columnsDataTable.Columns.Add(SharePointTypeString);

            row = columnsDataTable.NewRow();
            row[ColumnNameString] = DummyString;
            row[SharePointTypeString] = DummyString;
            columnsDataTable.Rows.Add(row);

            row = columnsDataTable.NewRow();
            row[ColumnNameString] = $"{DummyString}id";
            row[SharePointTypeString] = "lookup";
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

        [TestMethod]
        public void GetFormat_SPFieldTypeDateTime_ReturnsString()
        {
            // Arrange
            const string dataXmlString = @"<xmlcfg/>";
            var data = new XmlDocument();
            var expected = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

            data.LoadXml(dataXmlString);
            spField.TypeGet = () => SPFieldType.DateTime;

            // Act
            var actual = (string)privateObject.Invoke(
                GetFormatMethodName,
                nonPublicStatic,
                new object[]
                {
                    spField.Instance,
                    data,
                    string.Empty,
                    spWeb.Instance
                });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetFormat_SPFieldTypeNumberPercentageTrue_ReturnsString()
        {
            // Arrange
            const string dataXmlString = @"<xmlcfg Percentage=""true""/>";
            const string expected = "0\\%;;0\\%";
            var data = new XmlDocument();

            data.LoadXml(dataXmlString);
            spField.TypeGet = () => SPFieldType.Number;

            // Act
            var actual = (string)privateObject.Invoke(
                GetFormatMethodName,
                nonPublicStatic,
                new object[]
                {
                    spField.Instance,
                    data,
                    string.Empty,
                    spWeb.Instance
                });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetFormat_SPFieldTypeNumberPercentageFalse_ReturnsString()
        {
            // Arrange
            const string dataXmlString = @"<xmlcfg Percentage=""false"" Decimals=""5""/>";
            const string expected = ",0.00000";
            var data = new XmlDocument();

            data.LoadXml(dataXmlString);
            spField.TypeGet = () => SPFieldType.Number;

            // Act
            var actual = (string)privateObject.Invoke(
                GetFormatMethodName,
                nonPublicStatic,
                new object[]
                {
                    spField.Instance,
                    data,
                    string.Empty,
                    spWeb.Instance
                });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetFormat_SPFieldTypeCurrency_ReturnsString()
        {
            // Arrange
            const string dataXmlString = @"<xmlcfg/>";
            var expected = $"{CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol},0.00";
            var data = new XmlDocument();

            data.LoadXml(dataXmlString);
            spField.TypeGet = () => SPFieldType.Currency;
            spWeb.LocaleGet = () => CultureInfo.CurrentCulture;

            // Act
            var actual = (string)privateObject.Invoke(
                GetFormatMethodName,
                nonPublicStatic,
                new object[]
                {
                    spField.Instance,
                    data,
                    string.Empty,
                    spWeb.Instance
                });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetFormat_SPFieldTypeCalculatedResultTypeCurrency_ReturnsString()
        {
            // Arrange
            const string dataXmlString = @"<xmlcfg ResultType=""Currency"" Decimals=""5""/>";
            var expected = $"{CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol},0.00";
            var data = new XmlDocument();

            data.LoadXml(dataXmlString);
            spField.TypeGet = () => SPFieldType.Calculated;
            spWeb.LocaleGet = () => CultureInfo.CurrentCulture;

            // Act
            var actual = (string)privateObject.Invoke(
                GetFormatMethodName,
                nonPublicStatic,
                new object[]
                {
                    spField.Instance,
                    data,
                    string.Empty,
                    spWeb.Instance
                });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetFormat_SPFieldTypeCalculatedResultTypeNumber_ReturnsString()
        {
            // Arrange
            const string dataXmlString = @"<xmlcfg ResultType=""Number"" Decimals=""5""/>";
            const string expected = ",0.00000";
            var data = new XmlDocument();

            data.LoadXml(dataXmlString);
            spField.TypeGet = () => SPFieldType.Calculated;

            // Act
            var actual = (string)privateObject.Invoke(
                GetFormatMethodName,
                nonPublicStatic,
                new object[]
                {
                    spField.Instance,
                    data,
                    string.Empty,
                    spWeb.Instance
                });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void AddFieldNodeToDef_WhenCalled_ReturnsXmlNode()
        {
            // Arrange
            const string xmlString = @"<xmlcfg/>";
            var data = new XmlDocument();

            data.LoadXml(xmlString);

            // Act
            var actual = (XmlNode)privateObject.Invoke(
                AddFieldNodeToDefMethodName,
                nonPublicStatic,
                new object[]
                {
                    data,
                    DummyString,
                    DummyString
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Name.ShouldBe("D"),
                () => actual.Attributes.GetNamedItem("Name").Value.ShouldBe(DummyString),
                () => actual.Attributes.GetNamedItem($"{DummyString}CanEdit").Value.ShouldBe("0"));
        }

        [TestMethod]
        public void ProcessIndividualField_WhenCalled_Returns()
        {
            // Arrange
            var dataXmlString = $@"
                <xmlcfg>
                    <Def/>
                    <{DummyString} {DummyString}CanEdit=""0""/>
                </xmlcfg>";
            var data = new XmlDocument();
            var plannerProps = new PlannerProps()
            {
                oTaskFields = spFieldLinkCollection,
                oFolderFields = spFieldLinkCollection,
                oIterationFields = spFieldLinkCollection,
                bAgile = true,
                rollups = new ArrayList(),
                rolldowns = new ArrayList(),
                StatusFields = new SortedList()
                {
                    [DummyString] = DummyString
                }
            };

            data.LoadXml(dataXmlString);

            ShimWorkPlannerAPI.addFieldNodeToDefXmlDocumentRefStringString = (ref XmlDocument docOut, string defName, string field) =>
            {
                return docOut.FirstChild.SelectSingleNode($"//{DummyString}");
            };
            ShimXmlNode.AllInstances.AppendChildXmlNode = (parentNode, childNode) =>
            {
                if (parentNode.Name.Equals("Def"))
                {
                    if (childNode.Attributes[$"{DummyString}CanEdit"].Value.Equals("1"))
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
            privateObject.Invoke(
                ProcessIndividualFieldMethodName,
                nonPublicStatic,
                new object[]
                {
                    data,
                    spField.Instance,
                    data,
                    plannerProps
                });

            // Assert
            validations.ShouldBe(6);
        }

        [TestMethod]
        public void GetRealField_WhenCalled_Returns()
        {
            // Arrange
            const string schemaXml = @"<xmlcfg DisplayNameSrcField=""DisplayNameSrcField""/>";

            spField.TypeGet = () => SPFieldType.Computed;
            spField.SchemaXmlGet = () => schemaXml;

            // Act
            var actual = (SPField)privateObject.Invoke(GetRealFieldMethodName, nonPublicStatic, new object[] { spField.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.SchemaXml.ShouldBe(schemaXml),
                () => actual.Type.ShouldBe(SPFieldType.Computed));
        }

        [TestMethod]
        public void ProcessField_SPFieldTypeText_AddsAttributes()
        {
            // Arrange
            const string dataXmlString = @"
                <xmlcfg>
                    <cols/>
                    <header/>
                </xmlcfg>";
            const string visible = "visible";
            var dataXml = new XmlDocument();
            var colsNode = default(XmlNode);
            var headerNode = default(XmlNode);
            var plannerProps = new PlannerProps();

            dataXml.LoadXml(dataXmlString);
            colsNode = dataXml.FirstChild.SelectSingleNode("//cols");
            headerNode = dataXml.FirstChild.SelectSingleNode("//header");

            spField.SchemaXmlGet = () => dataXmlString;
            spField.TypeGet = () => SPFieldType.Text;
            spField.InternalNameGet = () => TitleString;

            ShimWorkPlannerAPI.processIndividualFieldXmlDocumentRefSPFieldXmlDocumentWorkPlannerAPIPlannerProps = (ref XmlDocument docOut, SPField oField, XmlDocument docF, PlannerProps p) =>
            {
                validations += 1;
            };
            ShimWorkPlannerAPI.getFormatSPFieldXmlDocumentStringOutSPWeb = (SPField oField, XmlDocument oDoc, out string EditFormat, SPWeb oWeb) =>
            {
                validations += 1;
                EditFormat = DummyString;
                return DummyString;
            };

            // Act
            privateObject.Invoke(
                ProcessFieldMethodName,
                nonPublicStatic,
                new object[]
                {
                    dataXml,
                    spField.Instance,
                    visible,
                    colsNode,
                    headerNode,
                    plannerProps,
                    spWeb.Instance,
                    default(DataSet)
                });
            var actual = colsNode.SelectSingleNode("//C");

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Attributes["Name"].Value.ShouldBe(TitleString),
                () => actual.Attributes["CanEdit"].Value.ShouldBe("1"),
                () => actual.Attributes["Width"].Value.ShouldBe("200"),
                () => actual.Attributes["Type"].Value.ShouldBe("Text"),
                () => actual.Attributes["CanFilter"].Value.ShouldBe("1"),
                () => actual.Attributes["CanSort"].Value.ShouldBe("1"),
                () => actual.Attributes["Visible"].Value.ShouldBe(visible),
                () => actual.Attributes["Format"].Value.ShouldBe(DummyString),
                () => actual.Attributes["EditFormat"].Value.ShouldBe(DummyString),
                () => headerNode.Attributes[TitleString].Value.ShouldBe(DummyString),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void ProcessField_SPFieldTypeNumber_AddsAttributes()
        {
            // Arrange
            const string summaryString = "Summary";
            const string dataXmlString = @"
                <xmlcfg>
                    <cols/>
                    <header/>
                </xmlcfg>";
            const string visible = "visible";
            var dataXml = new XmlDocument();
            var colsNode = default(XmlNode);
            var headerNode = default(XmlNode);
            var plannerProps = new PlannerProps();

            dataXml.LoadXml(dataXmlString);
            colsNode = dataXml.FirstChild.SelectSingleNode("//cols");
            headerNode = dataXml.FirstChild.SelectSingleNode("//header");

            spField.SchemaXmlGet = () => dataXmlString;
            spField.TypeGet = () => SPFieldType.Number;
            spField.InternalNameGet = () => summaryString;
            spField.ReadOnlyFieldGet = () => true;

            ShimWorkPlannerAPI.processIndividualFieldXmlDocumentRefSPFieldXmlDocumentWorkPlannerAPIPlannerProps = (ref XmlDocument docOut, SPField oField, XmlDocument docF, PlannerProps p) =>
            {
                validations += 1;
            };
            ShimWorkPlannerAPI.getFormatSPFieldXmlDocumentStringOutSPWeb = (SPField oField, XmlDocument oDoc, out string EditFormat, SPWeb oWeb) =>
            {
                validations += 1;
                EditFormat = DummyString;
                return DummyString;
            };

            // Act
            privateObject.Invoke(
                ProcessFieldMethodName,
                nonPublicStatic,
                new object[]
                {
                    dataXml,
                    spField.Instance,
                    visible,
                    colsNode,
                    headerNode,
                    plannerProps,
                    spWeb.Instance,
                    default(DataSet)
                });
            var actual = colsNode.SelectSingleNode("//C");

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Attributes["Align"].Value.ShouldBe("Right"),
                () => actual.Attributes["CanEdit"].Value.ShouldBe("0"),
                () => actual.Attributes["Width"].Value.ShouldBe("100"),
                () => actual.Attributes["Type"].Value.ShouldBe("Float"),
                () => headerNode.Attributes[summaryString].Value.ShouldBe(DummyString),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void ProcessField_SPFieldTypeCalculated_AddsAttributes()
        {
            // Arrange
            const string summaryString = "Summary";
            const string indicatorString = "Indicator";
            const string dataXmlString = @"
                <xmlcfg ResultType=""ResultType"">
                    <cols/>
                    <header/>
                    <Formula>=Formula</Formula>
                </xmlcfg>";
            const string visible = "visible";
            var dataXml = new XmlDocument();
            var colsNode = default(XmlNode);
            var headerNode = default(XmlNode);
            var plannerProps = new PlannerProps();

            dataXml.LoadXml(dataXmlString);
            colsNode = dataXml.FirstChild.SelectSingleNode("//cols");
            headerNode = dataXml.FirstChild.SelectSingleNode("//header");

            spField.SchemaXmlGet = () => dataXmlString;
            spField.TypeGet = () => SPFieldType.Calculated;
            spField.InternalNameGet = () => summaryString;
            spField.ReadOnlyFieldGet = () => true;
            spField.DescriptionGet = () => indicatorString;

            ShimWorkPlannerAPI.processIndividualFieldXmlDocumentRefSPFieldXmlDocumentWorkPlannerAPIPlannerProps = (ref XmlDocument docOut, SPField oField, XmlDocument docF, PlannerProps p) =>
            {
                validations += 1;
            };
            ShimWorkPlannerAPI.getFormatSPFieldXmlDocumentStringOutSPWeb = (SPField oField, XmlDocument oDoc, out string EditFormat, SPWeb oWeb) =>
            {
                validations += 1;
                EditFormat = DummyString;
                return DummyString;
            };

            // Act
            privateObject.Invoke(
                ProcessFieldMethodName,
                nonPublicStatic,
                new object[]
                {
                    dataXml,
                    spField.Instance,
                    visible,
                    colsNode,
                    headerNode,
                    plannerProps,
                    spWeb.Instance,
                    default(DataSet)
                });
            var actual = colsNode.SelectSingleNode("//C");

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Attributes["Formula"].Value.ShouldBe("Formula"),
                () => actual.Attributes["Align"].Value.ShouldBe("Center"),
                () => actual.Attributes["CanEdit"].Value.ShouldBe("0"),
                () => actual.Attributes["Width"].Value.ShouldBe("100"),
                () => actual.Attributes["Type"].Value.ShouldBe("Html"),
                () => headerNode.Attributes[summaryString].Value.ShouldBe(DummyString),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void ProcessField_SPFieldTypeChoice_AddsAttributes()
        {
            // Arrange
            const string expectedType = "Enum";
            const string expectedWidth = "150";
            const string summaryString = "Summary";
            const string dataXmlString = @"
                <xmlcfg>
                    <cols/>
                    <header/>
                </xmlcfg>";
            const string visible = "visible";
            var dataXml = new XmlDocument();
            var colsNode = default(XmlNode);
            var headerNode = default(XmlNode);
            var plannerProps = new PlannerProps();

            dataXml.LoadXml(dataXmlString);
            colsNode = dataXml.FirstChild.SelectSingleNode("//cols");
            headerNode = dataXml.FirstChild.SelectSingleNode("//header");

            spField.SchemaXmlGet = () => dataXmlString;
            spField.TypeGet = () => SPFieldType.Choice;
            spField.InternalNameGet = () => summaryString;
            spField.ReadOnlyFieldGet = () => true;

            ShimWorkPlannerAPI.processIndividualFieldXmlDocumentRefSPFieldXmlDocumentWorkPlannerAPIPlannerProps = (ref XmlDocument docOut, SPField oField, XmlDocument docF, PlannerProps p) =>
            {
                validations += 1;
            };
            ShimWorkPlannerAPI.getFormatSPFieldXmlDocumentStringOutSPWeb = (SPField oField, XmlDocument oDoc, out string EditFormat, SPWeb oWeb) =>
            {
                validations += 1;
                EditFormat = DummyString;
                return DummyString;
            };
            ShimWorkPlannerAPI.setEnumFieldSPFieldXmlNodeRefXmlDocumentXmlDocumentSPWebBooleanStringDataSet =
                (SPField oField, ref XmlNode ndCol, XmlDocument fieldDoc, XmlDocument docOut, SPWeb web, bool multi, string enumattr, DataSet dsResources) =>
                {
                    validations += 1;
                };

            // Act
            privateObject.Invoke(
                ProcessFieldMethodName,
                nonPublicStatic,
                new object[]
                {
                    dataXml,
                    spField.Instance,
                    visible,
                    colsNode,
                    headerNode,
                    plannerProps,
                    spWeb.Instance,
                    default(DataSet)
                });
            var actual = colsNode.SelectSingleNode("//C");

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Attributes["CanEdit"].Value.ShouldBe("0"),
                () => actual.Attributes["Width"].Value.ShouldBe(expectedWidth),
                () => actual.Attributes["Type"].Value.ShouldBe(expectedType),
                () => headerNode.Attributes[summaryString].Value.ShouldBe(DummyString),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void ProcessField_SPFieldTypeLookup_AddsAttributes()
        {
            // Arrange
            const string expectedType = "Enum";
            const string expectedWidth = "150";
            const string summaryString = "Summary";
            const string dataXmlString = @"
                <xmlcfg>
                    <cols/>
                    <header/>
                </xmlcfg>";
            const string visible = "visible";
            var dataXml = new XmlDocument();
            var colsNode = default(XmlNode);
            var headerNode = default(XmlNode);
            var plannerProps = new PlannerProps();

            dataXml.LoadXml(dataXmlString);
            colsNode = dataXml.FirstChild.SelectSingleNode("//cols");
            headerNode = dataXml.FirstChild.SelectSingleNode("//header");

            spField.SchemaXmlGet = () => dataXmlString;
            spField.TypeGet = () => SPFieldType.Lookup;
            spField.InternalNameGet = () => summaryString;
            spField.ReadOnlyFieldGet = () => true;

            ShimWorkPlannerAPI.processIndividualFieldXmlDocumentRefSPFieldXmlDocumentWorkPlannerAPIPlannerProps = (ref XmlDocument docOut, SPField oField, XmlDocument docF, PlannerProps p) =>
            {
                validations += 1;
            };
            ShimWorkPlannerAPI.getFormatSPFieldXmlDocumentStringOutSPWeb = (SPField oField, XmlDocument oDoc, out string EditFormat, SPWeb oWeb) =>
            {
                validations += 1;
                EditFormat = DummyString;
                return DummyString;
            };
            ShimWorkPlannerAPI.setEnumFieldSPFieldXmlNodeRefXmlDocumentXmlDocumentSPWebBooleanStringDataSet =
                (SPField oField, ref XmlNode ndCol, XmlDocument fieldDoc, XmlDocument docOut, SPWeb web, bool multi, string enumattr, DataSet dsResources) =>
                {
                    validations += 1;
                };

            // Act
            privateObject.Invoke(
                ProcessFieldMethodName,
                nonPublicStatic,
                new object[]
                {
                    dataXml,
                    spField.Instance,
                    visible,
                    colsNode,
                    headerNode,
                    plannerProps,
                    spWeb.Instance,
                    default(DataSet)
                });
            var actual = colsNode.SelectSingleNode("//C");

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Attributes["CanEdit"].Value.ShouldBe("0"),
                () => actual.Attributes["Width"].Value.ShouldBe(expectedWidth),
                () => actual.Attributes["Type"].Value.ShouldBe(expectedType),
                () => headerNode.Attributes[summaryString].Value.ShouldBe(DummyString),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void ProcessField_SPFieldTypeMultiChoice_AddsAttributes()
        {
            // Arrange
            const string expectedType = "Enum";
            const string expectedWidth = "150";
            const string summaryString = "Summary";
            const string dataXmlString = @"
                <xmlcfg>
                    <cols/>
                    <header/>
                </xmlcfg>";
            const string visible = "visible";
            var dataXml = new XmlDocument();
            var colsNode = default(XmlNode);
            var headerNode = default(XmlNode);
            var plannerProps = new PlannerProps();

            dataXml.LoadXml(dataXmlString);
            colsNode = dataXml.FirstChild.SelectSingleNode("//cols");
            headerNode = dataXml.FirstChild.SelectSingleNode("//header");

            spField.SchemaXmlGet = () => dataXmlString;
            spField.TypeGet = () => SPFieldType.MultiChoice;
            spField.InternalNameGet = () => summaryString;
            spField.ReadOnlyFieldGet = () => true;

            ShimWorkPlannerAPI.processIndividualFieldXmlDocumentRefSPFieldXmlDocumentWorkPlannerAPIPlannerProps = (ref XmlDocument docOut, SPField oField, XmlDocument docF, PlannerProps p) =>
            {
                validations += 1;
            };
            ShimWorkPlannerAPI.getFormatSPFieldXmlDocumentStringOutSPWeb = (SPField oField, XmlDocument oDoc, out string EditFormat, SPWeb oWeb) =>
            {
                validations += 1;
                EditFormat = DummyString;
                return DummyString;
            };
            ShimWorkPlannerAPI.setEnumFieldSPFieldXmlNodeRefXmlDocumentXmlDocumentSPWebBooleanStringDataSet =
                (SPField oField, ref XmlNode ndCol, XmlDocument fieldDoc, XmlDocument docOut, SPWeb web, bool multi, string enumattr, DataSet dsResources) =>
                {
                    validations += 1;
                };

            // Act
            privateObject.Invoke(
                ProcessFieldMethodName,
                nonPublicStatic,
                new object[]
                {
                    dataXml,
                    spField.Instance,
                    visible,
                    colsNode,
                    headerNode,
                    plannerProps,
                    spWeb.Instance,
                    default(DataSet)
                });
            var actual = colsNode.SelectSingleNode("//C");

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Attributes["CanEdit"].Value.ShouldBe("0"),
                () => actual.Attributes["Width"].Value.ShouldBe(expectedWidth),
                () => actual.Attributes["Type"].Value.ShouldBe(expectedType),
                () => headerNode.Attributes[summaryString].Value.ShouldBe(DummyString),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void ProcessField_SPFieldTypeUser_AddsAttributes()
        {
            // Arrange
            const string expectedType = "Enum";
            const string expectedWidth = "150";
            const string summaryString = "Summary";
            const string dataXmlString = @"
                <xmlcfg>
                    <cols/>
                    <header/>
                </xmlcfg>";
            const string visible = "visible";
            var dataXml = new XmlDocument();
            var colsNode = default(XmlNode);
            var headerNode = default(XmlNode);
            var plannerProps = new PlannerProps();

            dataXml.LoadXml(dataXmlString);
            colsNode = dataXml.FirstChild.SelectSingleNode("//cols");
            headerNode = dataXml.FirstChild.SelectSingleNode("//header");

            spField.SchemaXmlGet = () => dataXmlString;
            spField.TypeGet = () => SPFieldType.User;
            spField.InternalNameGet = () => summaryString;
            spField.ReadOnlyFieldGet = () => true;

            ShimWorkPlannerAPI.processIndividualFieldXmlDocumentRefSPFieldXmlDocumentWorkPlannerAPIPlannerProps = (ref XmlDocument docOut, SPField oField, XmlDocument docF, PlannerProps p) =>
            {
                validations += 1;
            };
            ShimWorkPlannerAPI.getFormatSPFieldXmlDocumentStringOutSPWeb = (SPField oField, XmlDocument oDoc, out string EditFormat, SPWeb oWeb) =>
            {
                validations += 1;
                EditFormat = DummyString;
                return DummyString;
            };
            ShimWorkPlannerAPI.setEnumFieldSPFieldXmlNodeRefXmlDocumentXmlDocumentSPWebBooleanStringDataSet =
                (SPField oField, ref XmlNode ndCol, XmlDocument fieldDoc, XmlDocument docOut, SPWeb web, bool multi, string enumattr, DataSet dsResources) =>
                {
                    validations += 1;
                };

            // Act
            privateObject.Invoke(
                ProcessFieldMethodName,
                nonPublicStatic,
                new object[]
                {
                    dataXml,
                    spField.Instance,
                    visible,
                    colsNode,
                    headerNode,
                    plannerProps,
                    spWeb.Instance,
                    default(DataSet)
                });
            var actual = colsNode.SelectSingleNode("//C");

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Attributes["CanEdit"].Value.ShouldBe("0"),
                () => actual.Attributes["Width"].Value.ShouldBe(expectedWidth),
                () => actual.Attributes["Type"].Value.ShouldBe(expectedType),
                () => headerNode.Attributes[summaryString].Value.ShouldBe(DummyString),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void ProcessField_SPFieldTypeURL_AddsAttributes()
        {
            // Arrange
            const string expectedType = "Link";
            const string expectedWidth = "150";
            const string summaryString = "Summary";
            const string dataXmlString = @"
                <xmlcfg>
                    <cols/>
                    <header/>
                </xmlcfg>";
            const string visible = "visible";
            var dataXml = new XmlDocument();
            var colsNode = default(XmlNode);
            var headerNode = default(XmlNode);
            var plannerProps = new PlannerProps();

            dataXml.LoadXml(dataXmlString);
            colsNode = dataXml.FirstChild.SelectSingleNode("//cols");
            headerNode = dataXml.FirstChild.SelectSingleNode("//header");

            spField.SchemaXmlGet = () => dataXmlString;
            spField.TypeGet = () => SPFieldType.URL;
            spField.InternalNameGet = () => summaryString;
            spField.ReadOnlyFieldGet = () => true;

            ShimWorkPlannerAPI.processIndividualFieldXmlDocumentRefSPFieldXmlDocumentWorkPlannerAPIPlannerProps = (ref XmlDocument docOut, SPField oField, XmlDocument docF, PlannerProps p) =>
            {
                validations += 1;
            };
            ShimWorkPlannerAPI.getFormatSPFieldXmlDocumentStringOutSPWeb = (SPField oField, XmlDocument oDoc, out string EditFormat, SPWeb oWeb) =>
            {
                validations += 1;
                EditFormat = DummyString;
                return DummyString;
            };
            ShimWorkPlannerAPI.setEnumFieldSPFieldXmlNodeRefXmlDocumentXmlDocumentSPWebBooleanStringDataSet =
                (SPField oField, ref XmlNode ndCol, XmlDocument fieldDoc, XmlDocument docOut, SPWeb web, bool multi, string enumattr, DataSet dsResources) =>
                {
                    validations += 1;
                };

            // Act
            privateObject.Invoke(
                ProcessFieldMethodName,
                nonPublicStatic,
                new object[]
                {
                    dataXml,
                    spField.Instance,
                    visible,
                    colsNode,
                    headerNode,
                    plannerProps,
                    spWeb.Instance,
                    default(DataSet)
                });
            var actual = colsNode.SelectSingleNode("//C");

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Attributes["CanEdit"].Value.ShouldBe("0"),
                () => actual.Attributes["Width"].Value.ShouldBe(expectedWidth),
                () => actual.Attributes["Type"].Value.ShouldBe(expectedType),
                () => headerNode.Attributes[summaryString].Value.ShouldBe(DummyString),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void ProcessField_SPFieldTypeNote_AddsAttributes()
        {
            // Arrange
            const string expectedType = "Html";
            const string expectedWidth = "200";
            const string summaryString = "Summary";
            const string dataXmlString = @"
                <xmlcfg>
                    <cols/>
                    <header/>
                </xmlcfg>";
            const string visible = "visible";
            var dataXml = new XmlDocument();
            var colsNode = default(XmlNode);
            var headerNode = default(XmlNode);
            var plannerProps = new PlannerProps();

            dataXml.LoadXml(dataXmlString);
            colsNode = dataXml.FirstChild.SelectSingleNode("//cols");
            headerNode = dataXml.FirstChild.SelectSingleNode("//header");

            spField.SchemaXmlGet = () => dataXmlString;
            spField.TypeGet = () => SPFieldType.Note;
            spField.InternalNameGet = () => summaryString;
            spField.ReadOnlyFieldGet = () => true;

            ShimWorkPlannerAPI.processIndividualFieldXmlDocumentRefSPFieldXmlDocumentWorkPlannerAPIPlannerProps = (ref XmlDocument docOut, SPField oField, XmlDocument docF, PlannerProps p) =>
            {
                validations += 1;
            };
            ShimWorkPlannerAPI.getFormatSPFieldXmlDocumentStringOutSPWeb = (SPField oField, XmlDocument oDoc, out string EditFormat, SPWeb oWeb) =>
            {
                validations += 1;
                EditFormat = DummyString;
                return DummyString;
            };
            ShimWorkPlannerAPI.setEnumFieldSPFieldXmlNodeRefXmlDocumentXmlDocumentSPWebBooleanStringDataSet =
                (SPField oField, ref XmlNode ndCol, XmlDocument fieldDoc, XmlDocument docOut, SPWeb web, bool multi, string enumattr, DataSet dsResources) =>
                {
                    validations += 1;
                };

            // Act
            privateObject.Invoke(
                ProcessFieldMethodName,
                nonPublicStatic,
                new object[]
                {
                    dataXml,
                    spField.Instance,
                    visible,
                    colsNode,
                    headerNode,
                    plannerProps,
                    spWeb.Instance,
                    default(DataSet)
                });
            var actual = colsNode.SelectSingleNode("//C");

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Attributes["CanEdit"].Value.ShouldBe("0"),
                () => actual.Attributes["Width"].Value.ShouldBe(expectedWidth),
                () => actual.Attributes["Type"].Value.ShouldBe(expectedType),
                () => headerNode.Attributes[summaryString].Value.ShouldBe(DummyString),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void GetSettings_LockWebEmpty_ReturnsPlannerProps()
        {
            // Arrange
            const string suffix = "EPMLivePlanner";
            const string plannerString = "planner";
            const string fields = "1|RollDown\n2|RollUp";
            var expectedQuery = $"<Where><Eq><FieldRef Name='HolidaySchedule' LookupId='True'/><Value Type='Lookup'>{DummyString}</Value></Eq></Where>";
            var configSettings = new Dictionary<string, string>()
            {
                [$"{suffix}{plannerString}UseFolders"] = bool.TrueString,
                [$"{suffix}{plannerString}EnableAgile"] = bool.TrueString,
                [$"{suffix}{plannerString}CalcWork"] = bool.TrueString,
                [$"{suffix}{plannerString}CalcCost"] = bool.TrueString,
                [$"{suffix}{plannerString}EnableLink"] = bool.TrueString,
                [$"{suffix}{plannerString}StartSoon"] = bool.TrueString,
                [$"{suffix}{plannerString}TaskType"] = DummyInt.ToString(),
                [$"{suffix}{plannerString}LunchStart"] = DummyInt.ToString(),
                [$"{suffix}{plannerString}LunchEnd"] = DummyInt.ToString(),
                [$"{suffix}{plannerString}Fields"] = fields,
            };

            spWeb.RegionalSettingsGet = () => new ShimSPRegionalSettings()
            {
                WorkDaysGet = () => 5,
                WorkDayStartHourGet = () => 9,
                WorkDayEndHourGet = () => 18,
            };
            spListItemCollection.GetDataTable = () => new DataTable();
            spListItemCollection.CountGet = () => One;

            ShimCoreFunctions.getLockedWebSPWeb = _ => Guid.Empty;
            ShimCoreFunctions.getConfigSettingSPWebString = (_1, input) =>
            {
                if (configSettings.ContainsKey(input))
                {
                    return configSettings[input];
                }
                return DummyString;
            };
            ShimSPQuery.AllInstances.QuerySetString = (_, query) =>
            {
                if (query.Equals(expectedQuery))
                {
                    validations += 1;
                }
            };

            // Act
            var actual = (PlannerProps)privateObject.Invoke(
                GetSettingsMethodName,
                publicStatic,
                new object[]
                {
                    spWeb.Instance,
                    plannerString
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.rolldowns.Count.ShouldBe(1),
                () => actual.rollups.Count.ShouldBe(1),
                () => actual.bUseFolders.ShouldBeTrue(),
                () => actual.bAgile.ShouldBeTrue(),
                () => actual.bCalcWork.ShouldBeTrue(),
                () => actual.bStartSoon.ShouldBeTrue(),
                () => actual.Holidays.ShouldNotBeNull(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void GetSettings_LockWebNotEmpty_ReturnsPlannerProps()
        {
            // Arrange
            const string suffix = "EPMLivePlanner";
            const string plannerString = "planner";
            const string fields = "1|RollDown\n2|RollUp";
            var expectedQuery = $"<Where><Eq><FieldRef Name='HolidaySchedule' LookupId='True'/><Value Type='Lookup'>{DummyString}</Value></Eq></Where>";
            var configSettings = new Dictionary<string, string>()
            {
                [$"{suffix}{plannerString}UseFolders"] = bool.TrueString,
                [$"{suffix}{plannerString}EnableAgile"] = bool.TrueString,
                [$"{suffix}{plannerString}CalcWork"] = bool.TrueString,
                [$"{suffix}{plannerString}CalcCost"] = bool.TrueString,
                [$"{suffix}{plannerString}EnableLink"] = bool.TrueString,
                [$"{suffix}{plannerString}StartSoon"] = bool.TrueString,
                [$"{suffix}{plannerString}TaskType"] = DummyInt.ToString(),
                [$"{suffix}{plannerString}LunchStart"] = DummyInt.ToString(),
                [$"{suffix}{plannerString}LunchEnd"] = DummyInt.ToString(),
                [$"{suffix}{plannerString}Fields"] = fields,
            };

            spWeb.RegionalSettingsGet = () => new ShimSPRegionalSettings()
            {
                WorkDaysGet = () => 5,
                WorkDayStartHourGet = () => 9,
                WorkDayEndHourGet = () => 18,
            };
            spListItemCollection.GetDataTable = () => new DataTable();
            spListItemCollection.CountGet = () => One;

            ShimCoreFunctions.getLockedWebSPWeb = _ => Guid.Parse(SampleGuidString2);
            ShimCoreFunctions.getConfigSettingSPWebString = (_1, input) =>
            {
                if (configSettings.ContainsKey(input))
                {
                    return configSettings[input];
                }
                return DummyString;
            };
            ShimSPQuery.AllInstances.QuerySetString = (_, query) =>
            {
                if (query.Equals(expectedQuery))
                {
                    validations += 1;
                }
            };

            // Act
            var actual = (PlannerProps)privateObject.Invoke(
                GetSettingsMethodName,
                publicStatic,
                new object[]
                {
                    spWeb.Instance,
                    plannerString
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.rolldowns.Count.ShouldBe(1),
                () => actual.rollups.Count.ShouldBe(1),
                () => actual.bUseFolders.ShouldBeTrue(),
                () => actual.bAgile.ShouldBeTrue(),
                () => actual.bCalcWork.ShouldBeTrue(),
                () => actual.bStartSoon.ShouldBeTrue(),
                () => actual.Holidays.ShouldNotBeNull(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void GetKanBanPlanners_WhenCalled_ReturnsString()
        {
            // Arrange
            const string plannerKey = "EPMLivePlannerPlanners";
            const string plannerString = "1|2,3|4";
            var jsonData = $"{{\"id\":\"{1}\",\"text\":\"{2}\"}},{{\"id\":\"{3}\",\"text\":\"{4}\"}}";
            var expected = $"{{ \"kanbanplanners\": [{jsonData}] }}";
            const string dataXmlString = @"<xmlcfg/>";
            var data = new XmlDocument();

            data.LoadXml(dataXmlString);

            ShimCoreFunctions.getConfigSettingSPWebString = (_, input) =>
            {
                if (input.Equals(plannerKey))
                {
                    return plannerString;
                }
                return bool.TrueString;
            };
            ShimHttpUtility.HtmlEncodeString = input =>
            {
                validations += 1;
                return input;
            };

            // Act
            var actual = (string)privateObject.Invoke(
                GetKanBanPlannersMethodName,
                publicStatic,
                new object[]
                {
                    data,
                    spWeb.Instance
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void GetKanBanFilter1_WhenCalled_ReturnsString()
        {
            // Arrange
            const string lookupString = "Lookup";
            const string dataXmlString = @"
                <xmlcfg>
                    <ID>1</ID>
                    <KanBanBoardName>KanBanBoardName</KanBanBoardName>
                </xmlcfg>";
            var data = new XmlDocument();
            var plannerProps = new PlannerProps()
            {
                sListTaskCenter = DummyString,
                sProjectField = DummyString,
                KanBanFilterColumn = DummyString,
                KanBanStatusColumn = DummyString,
                KanBanItemStatusFieldsAvailable = "1,2"
            };
            var methodHit = 0;
            var tableName = new DataTable();
            var filterColumns = new DataTable();
            var filterColumnValues = new DataTable();
            var row = default(DataRow);
            var jsonData = $"{{\"id\":\"{1}\",\"text\":\"{1}\"}},{{\"id\":\"{2}\",\"text\":\"{2}\"}}";
            var jsonBacklogStatus = $"{{\"id\":\"{1}\"}},{{\"id\":\"{2}\"}}";
            var kanbanNewItemUrl = $"{DummyString}?LookupField={DummyString}&LookupValue={1}";
            var expected = $"{{ \"kanbannewitemurl\": \"{kanbanNewItemUrl}\", \"kanbanitemname\": \"{DummyString}\", \"kanbanstatuscolumn\": \"{DummyString}\", \"kanbanstatusvalues\": [{jsonBacklogStatus}], \"kanbanerror\": \"\", \"kanbanfilter1name\": \"{DummyString}\", \"kanbanfilter1\": [{jsonData}] }}";

            data.LoadXml(dataXmlString);

            tableName.Columns.Add(TableNameString);
            row = tableName.NewRow();
            row[TableNameString] = DummyString;
            tableName.Rows.Add(row);

            filterColumns.Columns.Add(SharePointTypeString);
            filterColumns.Columns.Add(ColumnNameString);
            row = filterColumns.NewRow();
            row[SharePointTypeString] = lookupString;
            row[ColumnNameString] = DummyString;
            filterColumns.Rows.Add(row);
            row = filterColumns.NewRow();
            row[SharePointTypeString] = lookupString;
            row[ColumnNameString] = DummyString;
            filterColumns.Rows.Add(row);

            filterColumnValues.Columns.Add(ValueString);
            row = filterColumnValues.NewRow();
            row[ValueString] = 1;
            filterColumnValues.Rows.Add(row);
            row = filterColumnValues.NewRow();
            row[ValueString] = 2;
            filterColumnValues.Rows.Add(row);

            spList.DefaultNewFormUrlGet = () => DummyString;
            ShimHttpUtility.HtmlEncodeString = input => input;
            ShimWorkPlannerAPI.getSettingsSPWebString = (_, __) => plannerProps;
            ShimQueryExecutor.AllInstances.ExecuteReportingDBQueryStringIDictionaryOfStringObject = (_, _1, _2) =>
            {
                methodHit += 1;
                if (methodHit.Equals(1))
                {
                    return tableName;
                }
                else if (methodHit.Equals(2))
                {
                    return filterColumns;
                }
                else
                {
                    return filterColumnValues;
                }
            };

            // Act
            var actual = (string)privateObject.Invoke(
                GetKanBanFilter1MethodName,
                publicStatic,
                new object[]
                {
                    data,
                    spWeb.Instance
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => methodHit.ShouldBe(3));
        }
    }
}