﻿using System;
using System.Collections.Generic;
using System.Collections.Generic.Fakes;
using System.Data;
using System.IO;
using System.IO.Fakes;
using System.Linq;
using System.Resources.Fakes;
using System.Xml;
using System.Xml.Linq;
using EPMLiveCore.Fakes;
using EPMLiveWorkPlanner.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using static EPMLiveWorkPlanner.PlannerCore;
using static EPMLiveWorkPlanner.WorkPlannerAPI;

namespace EPMLiveWorkPlanner.Tests.ISAPI
{
    public partial class WorkPlannerAPITests
    {
        private const string HoursString = "Hours";
        private const string DateString = "Date";
        private const string PublishProcessTasksMethodName = "PublishProcessTasks";
        private const string PublishProcessTaskMethodName = "PublishProcessTask";
        private const string PublishGetFieldValueMethodName = "PublishGetFieldValue";
        private const string PublishProcessFoldersMethodName = "PublishProcessFolders";
        private const string PublishMethodName = "Publish";
        private const string IGetGeneralLayoutMethodName = "iGetGeneralLayout";
        private const string IsNewValidTaskMethodName = "isNewValidTask";
        private const string AppendNewAgileTasksMethodName = "AppendNewAgileTasks";
        private const string GetAgileFolderFieldFormulaMethodName = "GetAgileFolderFieldFormula";
        private const string AddCalculationsMethodName = "addCalculations";
        private const string GetFolderLayoutMethodName = "GetFolderLayout";
        private const string GetViewsMethodName = "GetViews";
        private const string GetDetailLayoutMethodName = "GetDetailLayout";
        private const string SetupProjectCenterListMethodName = "SetupProjectCenterList";

        [TestMethod]
        public void PublishProcessTasks_WhenCalled_ProcessTasks()
        {
            // Arrange
            const string dataXmlString = @"
                <xmlcfg>
                    <I Def=""Iteration"" id=""1""/>
                    <I Def=""NotIteration"" id=""2""/>
                </xmlcfg>";
            var data = new XmlDocument();
            var node = default(XmlNode);

            data.LoadXml(dataXmlString);
            node = data.FirstChild;

            ShimWorkPlannerAPI.PublishProcessTaskXmlNodeStringXmlDocumentRefSPListDataSetStringWorkPlannerAPIPlannerProps =
                (XmlNode ndTask, string parentfolder, ref XmlDocument dataParam, SPList oTaskCenter, DataSet dsResources, string iteration, PlannerProps props) =>
                {
                    validations += 1;
                };

            // Act
            privateObject.Invoke(
                PublishProcessTasksMethodName,
                nonPublicStatic,
                new object[] { node, DummyString, data, spList.Instance, default(DataSet), DummyString, default(PlannerProps) });

            // Assert
            validations.ShouldBe(2);
        }

        [TestMethod]
        public void PublishProcessTask_DefAssignment_ProcessTasks()
        {
            // Arrange
            const string iteration = "IterationString";
            var dataXmlString = $@"
                <xmlcfg>
                    <B Def=""Task"" TaskType=""Individual"" Title=""{DummyString}"">
                        <I Def=""Assignment"" id=""1"" taskorder=""1"" PercentComplete=""0.5"" IsAssignment=""{DummyString}"" CT{DummyString}=""DummyString""/>
                    </B>
                </xmlcfg>";
            var data = new XmlDocument();
            var node = default(XmlNode);
            var plannerProps = new PlannerProps()
            {
                sIterationCT = DummyString
            };

            data.LoadXml(dataXmlString);
            node = data.FirstChild.SelectSingleNode("//B/I");

            ShimWorkPlannerAPI.PublishGetFieldValueStringXmlNodeSPListDataSet = (_1, _2, _3, _4) => DummyString;

            // Act
            privateObject.Invoke(
                PublishProcessTaskMethodName,
                nonPublicStatic,
                new object[] { node, DummyString, data, spList.Instance, default(DataSet), iteration, plannerProps });
            var actual = XDocument.Parse(data.OuterXml);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .Element("xmlcfg")
                    .Element("Task")
                    .Element("Title")
                    .Value
                    .ShouldBe(DummyString),
                () => actual
                    .Element("xmlcfg")
                    .Element("Task")
                    .Elements("Field")
                    .FirstOrDefault(x => x.Attribute("Name").Value.Equals("PercentComplete"))
                    .Value
                    .ShouldBe(DummyString),
                () => actual
                    .Element("xmlcfg")
                    .Element("Task")
                    .Elements("Field")
                    .FirstOrDefault(x => x.Attribute("Name").Value.Equals("IsAssignment"))
                    .Value
                    .ShouldBe("true"),
                () => actual
                    .Element("xmlcfg")
                    .Element("Task")
                    .Elements("Field")
                    .FirstOrDefault(x => x.Attribute("Name").Value.Equals("taskorder"))
                    .Value
                    .ShouldBe(DummyString),
                () => actual
                    .Element("xmlcfg")
                    .Element("Task")
                    .Elements("Field")
                    .FirstOrDefault(x => x.Attribute("Name").Value.Equals($"CT{DummyString}"))
                    .Value
                    .ShouldBe(iteration));
        }

        [TestMethod]
        public void PublishProcessTask_DefExternal_ProcessTasks()
        {
            // Arrange
            const string iteration = "IterationString";
            var dataXmlString = $@"
                <xmlcfg>
                    <B Def=""Task"" TaskType=""Individual"" Title=""{DummyString}"">
                        <I Def=""External"" id=""1"" taskorder=""1"" Timesheet=""8"" AssignedTo=""{DummyString}"" IsExternal=""True"" CT{DummyString}=""DummyString"" TaskType=""Individual"" Title=""{DummyString}"" SPID=""1""/>
                    </B>
                </xmlcfg>";
            var data = new XmlDocument();
            var node = default(XmlNode);
            var plannerProps = new PlannerProps()
            {
                sIterationCT = DummyString
            };

            data.LoadXml(dataXmlString);
            node = data.FirstChild.SelectSingleNode("//B/I");

            ShimWorkPlannerAPI.PublishGetFieldValueStringXmlNodeSPListDataSet = (_1, _2, _3, _4) => DummyString;

            // Act
            privateObject.Invoke(
                PublishProcessTaskMethodName,
                nonPublicStatic,
                new object[] { node, DummyString, data, spList.Instance, default(DataSet), iteration, plannerProps });
            var actual = XDocument.Parse(data.OuterXml);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .Element("xmlcfg")
                    .Element("Task")
                    .Element("Title")
                    .Value
                    .ShouldBe(DummyString),
                () => actual
                    .Element("xmlcfg")
                    .Element("Task")
                    .Elements("Field")
                    .FirstOrDefault(x => x.Attribute("Name").Value.Equals("Timesheet"))
                    .Value
                    .ShouldBe("0"),
                () => actual
                    .Element("xmlcfg")
                    .Element("Task")
                    .Elements("Field")
                    .FirstOrDefault(x => x.Attribute("Name").Value.Equals("IsExternal"))
                    .Value
                    .ShouldBe("1"),
                () => actual
                    .Element("xmlcfg")
                    .Element("Task")
                    .Elements("Field")
                    .FirstOrDefault(x => x.Attribute("Name").Value.Equals("AssignedTo"))
                    .Value
                    .ShouldBe(string.Empty),
                () => actual
                    .Element("xmlcfg")
                    .Element("Task")
                    .Elements("Field")
                    .FirstOrDefault(x => x.Attribute("Name").Value.Equals("taskorder"))
                    .Value
                    .ShouldBe(DummyString),
                () => actual
                    .Element("xmlcfg")
                    .Element("Task")
                    .Elements("Field")
                    .FirstOrDefault(x => x.Attribute("Name").Value.Equals($"CT{DummyString}"))
                    .Value
                    .ShouldBe(iteration));
        }

        [TestMethod]
        public void PublishProcessTask_DefIteration_ProcessTasks()
        {
            // Arrange
            const string iteration = "IterationString";
            var dataXmlString = $@"
                <xmlcfg>
                    <B Def=""Task"" TaskType=""Individual"" Title=""{DummyString}"">
                        <I Def=""Iteration"" id=""1"" taskorder=""1"" AssignedTo=""{DummyString}"" IsExternal=""True"" CT{DummyString}=""DummyString"" TaskType=""Individual"" Title=""{DummyString}"" SPID=""1""/>
                    </B>
                </xmlcfg>";
            var data = new XmlDocument();
            var node = default(XmlNode);
            var plannerProps = new PlannerProps()
            {
                sIterationCT = DummyString
            };

            data.LoadXml(dataXmlString);
            node = data.FirstChild.SelectSingleNode("//B/I");

            ShimWorkPlannerAPI.PublishGetFieldValueStringXmlNodeSPListDataSet = (_1, _2, _3, _4) => DummyString;

            // Act
            privateObject.Invoke(
                PublishProcessTaskMethodName,
                nonPublicStatic,
                new object[] { node, DummyString, data, spList.Instance, default(DataSet), iteration, plannerProps });
            var actual = XDocument.Parse(data.OuterXml);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .Element("xmlcfg")
                    .Element("Task")
                    .Element("Title")
                    .Value
                    .ShouldBe(DummyString),
                () => actual
                    .Element("xmlcfg")
                    .Element("Task")
                    .Elements("Field")
                    .FirstOrDefault(x => x.Attribute("Name").Value.Equals("IsExternal"))
                    .Value
                    .ShouldBe("0"),
                () => actual
                    .Element("xmlcfg")
                    .Element("Task")
                    .Attribute("Iteration")
                    .Value
                    .ShouldBe("1"),
                () => actual
                    .Element("xmlcfg")
                    .Element("Task")
                    .Elements("Field")
                    .FirstOrDefault(x => x.Attribute("Name").Value.Equals("AssignedTo"))
                    .Value
                    .ShouldBe(string.Empty),
                () => actual
                    .Element("xmlcfg")
                    .Element("Task")
                    .Elements("Field")
                    .FirstOrDefault(x => x.Attribute("Name").Value.Equals("taskorder"))
                    .Value
                    .ShouldBe(DummyString),
                () => actual
                    .Element("xmlcfg")
                    .Element("Task")
                    .Elements("Field")
                    .FirstOrDefault(x => x.Attribute("Name").Value.Equals($"CT{DummyString}"))
                    .Value
                    .ShouldBe(iteration));
        }

        [TestMethod]
        public void PublishGetFieldValue_PredecessorsField_ReturnsString()
        {
            // Arrange
            const string field = "Predecessors";
            const string value = "1PredInfo;2PredInfo";
            const string expected = "100PredInfo";
            const string schemaXmlString = @"<xmlcfg/>";
            var dataXmlString = $@"
                <xmlcfg>
                    <Task {field}=""{value}""/>
                    <I id=""1"" taskorder=""100""/>
                    <I id=""2""/>
                </xmlcfg>";
            var data = new XmlDocument();
            var taskNode = default(XmlNode);

            data.LoadXml(dataXmlString);
            taskNode = data.FirstChild.SelectSingleNode("//Task");
            spField.SchemaXmlGet = () => schemaXmlString;

            // Act
            var actual = (string)privateObject.Invoke(PublishGetFieldValueMethodName, nonPublicStatic, new object[] { field, taskNode, spList.Instance, default(DataSet) });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void PublishGetFieldValue_TypeNumber_ReturnsString()
        {
            // Arrange
            const string field = "NotPredecessors";
            const string value = "500";
            const SPFieldType type = SPFieldType.Number;
            const string expected = "5";
            const string schemaXmlString = @"<xmlcfg Percentage=""TRUE""/>";
            var dataXmlString = $@"
                <xmlcfg>
                    <Task {field}=""{value}""/>
                </xmlcfg>";
            var data = new XmlDocument();
            var taskNode = default(XmlNode);

            data.LoadXml(dataXmlString);
            taskNode = data.FirstChild.SelectSingleNode("//Task");
            spField.SchemaXmlGet = () => schemaXmlString;
            spField.TypeGet = () => type;

            // Act
            var actual = (string)privateObject.Invoke(PublishGetFieldValueMethodName, nonPublicStatic, new object[] { field, taskNode, spList.Instance, default(DataSet) });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void PublishGetFieldValue_TypeMultiChoice_ReturnsString()
        {
            // Arrange
            const string field = "NotPredecessors";
            const string value = "500;1000";
            const SPFieldType type = SPFieldType.MultiChoice;
            const string expected = "500;#1000";
            const string schemaXmlString = @"<xmlcfg Percentage=""TRUE""/>";
            var dataXmlString = $@"
                <xmlcfg>
                    <Task {field}=""{value}""/>
                </xmlcfg>";
            var data = new XmlDocument();
            var taskNode = default(XmlNode);

            data.LoadXml(dataXmlString);
            taskNode = data.FirstChild.SelectSingleNode("//Task");
            spField.SchemaXmlGet = () => schemaXmlString;
            spField.TypeGet = () => type;

            // Act
            var actual = (string)privateObject.Invoke(PublishGetFieldValueMethodName, nonPublicStatic, new object[] { field, taskNode, spList.Instance, default(DataSet) });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void PublishGetFieldValue_TypeChoice_ReturnsString()
        {
            // Arrange
            const string field = "NotPredecessors";
            const string value = "    500;#1000      ";
            const SPFieldType type = SPFieldType.Choice;
            const string expected = "500;#1000";
            const string schemaXmlString = @"<xmlcfg Percentage=""TRUE""/>";
            var dataXmlString = $@"
                <xmlcfg>
                    <Task {field}=""{value}""/>
                </xmlcfg>";
            var data = new XmlDocument();
            var taskNode = default(XmlNode);

            data.LoadXml(dataXmlString);
            taskNode = data.FirstChild.SelectSingleNode("//Task");
            spField.SchemaXmlGet = () => schemaXmlString;
            spField.TypeGet = () => type;

            // Act
            var actual = (string)privateObject.Invoke(PublishGetFieldValueMethodName, nonPublicStatic, new object[] { field, taskNode, spList.Instance, default(DataSet) });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void PublishGetFieldValue_TypeUser_ReturnsString()
        {
            // Arrange
            const string field = "NotPredecessors";
            const string value = "1";
            const SPFieldType type = SPFieldType.User;
            const string schemaXmlString = @"<xmlcfg Percentage=""TRUE""/>";
            var dataXmlString = $@"
                <xmlcfg>
                    <Task {field}=""{value}""/>
                </xmlcfg>";
            var data = new XmlDocument();
            var taskNode = default(XmlNode);
            var dataSet = new DataSet();
            var row = default(DataRow);

            dataSet.Tables.Add(new DataTable());
            dataSet.Tables.Add(new DataTable());
            dataSet.Tables.Add(new DataTable());

            dataSet.Tables[2].Columns.Add(IDStringCaps);
            dataSet.Tables[2].Columns.Add(AccountInfoString);

            row = dataSet.Tables[2].NewRow();
            row[IDStringCaps] = 1;
            row[AccountInfoString] = DummyString;

            dataSet.Tables[2].Rows.Add(row);

            data.LoadXml(dataXmlString);
            taskNode = data.FirstChild.SelectSingleNode("//Task");
            spField.SchemaXmlGet = () => schemaXmlString;
            spField.TypeGet = () => type;

            // Act
            var actual = (string)privateObject.Invoke(PublishGetFieldValueMethodName, nonPublicStatic, new object[] { field, taskNode, spList.Instance, dataSet });

            // Assert
            actual.ShouldBe(DummyString);
        }

        [TestMethod]
        public void PublishGetFieldValue_TypeLookup_ReturnsString()
        {
            // Arrange
            const string field = "NotPredecessors";
            const string value = "1;2";
            const SPFieldType type = SPFieldType.Lookup;
            var schemaXmlString = $@"<xmlcfg Percentage=""TRUE"" List=""{SampleGuidString1}""/>";
            var dataXmlString = $@"
                <xmlcfg>
                    <Task {field}=""{value}""/>
                </xmlcfg>";
            var data = new XmlDocument();
            var taskNode = default(XmlNode);

            data.LoadXml(dataXmlString);
            taskNode = data.FirstChild.SelectSingleNode("//Task");
            spField.SchemaXmlGet = () => schemaXmlString;
            spField.TypeGet = () => type;
            spListCollection.ItemGetGuid = _ => spList;

            ShimSPFieldLookupValueCollection.AllInstances.ToString01 = _ => DummyString;

            // Act
            var actual = (string)privateObject.Invoke(PublishGetFieldValueMethodName, nonPublicStatic, new object[] { field, taskNode, spList.Instance, default(DataSet) });

            // Assert
            actual.ShouldBe(DummyString);
        }

        [TestMethod]
        public void PublishProcessFolders_WhenCalled_PublishFolders()
        {
            // Arrange
            const string dataXmlString = @"
                <xmlcfg>
                    <I Def=""Folder"" Title=""Title1"">
                        <I Def=""Folder"" Title=""Title2""/>
                    </I>
                </xmlcfg>";
            var data = new XmlDocument();
            var folder = default(XmlNode);

            data.LoadXml(dataXmlString);
            folder = data.FirstChild.SelectSingleNode("//I");

            ShimWorkPlannerAPI.PublishProcessTasksXmlNodeStringXmlDocumentRefSPListDataSetStringWorkPlannerAPIPlannerProps =
                (XmlNode ndFolder, string parentfolderpath, ref XmlDocument dataParam, SPList oTaskCenter, DataSet dsResources, string iteration, PlannerProps props) =>
                {
                    validations += 1;
                };

            // Act
            privateObject.Invoke(
                PublishProcessFoldersMethodName,
                nonPublicStatic,
                new object[] { folder, DummyString, data, spList.Instance, default(DataSet), default(PlannerProps) });

            // Assert
            validations.ShouldBe(2);
        }

        [TestMethod]
        public void Publish_WhenCalled_ReturnsString()
        {
            // Arrange
            const string dataXmlString = @"<xmlcfg PlannerID=""1"" ID=""1""/>";
            const string newXml = @"
                <B>
                    <I Def=""Folder"">
                        <I Def=""Folder""/>
                    </I>
                </B>";
            var data = new XmlDocument();
            var itemGetHit = 0;
            var props = new PlannerProps()
            {
                sListProjectCenter = DummyString,
                sListTaskCenter = DummyString
            };

            data.LoadXml(dataXmlString);

            spListCollection.ItemGetString = input =>
            {
                itemGetHit += 1;
                if (itemGetHit.Equals(1))
                {
                    return new ShimSPDocumentLibrary().Instance;
                }
                return spList;
            };
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
                return default(DataSet);
            };
            ShimWorkEngineAPI.PublishStringSPWeb = (_1, _2) =>
            {
                validations += 1;
                return DummyString;
            };
            ShimWorkPlannerAPI.PublishProcessTaskXmlNodeStringXmlDocumentRefSPListDataSetStringWorkPlannerAPIPlannerProps =
                (XmlNode ndTask, string parentfolder, ref XmlDocument dataParam, SPList oTaskCenter, DataSet dsResources, string iteration, PlannerProps propsParam) =>
                {
                    validations += 1;
                };
            ShimWorkPlannerAPI.PublishProcessTasksXmlNodeStringXmlDocumentRefSPListDataSetStringWorkPlannerAPIPlannerProps =
                (XmlNode ndFolder, string parentfolderpath, ref XmlDocument dataParam, SPList oTaskCenter, DataSet dsResources, string iteration, PlannerProps propsParam) =>
                {
                    validations += 1;
                };
            ShimWorkPlannerAPI.PublishProcessFoldersXmlNodeStringXmlDocumentRefSPListDataSetWorkPlannerAPIPlannerProps =
                (XmlNode ndFolder, string parentfolderpath, ref XmlDocument dataParam, SPList oTaskCenter, DataSet dsResources, PlannerProps propsParam) =>
                {
                    validations += 1;
                };

            // Act
            var actual = (string)privateObject.Invoke(PublishMethodName, publicStatic, new object[] { data, spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(DummyString),
                () => validations.ShouldBe(8));
        }

        [TestMethod]
        public void IGetGeneralLayout_SPFieldTypeNumber_ReturnsString()
        {
            // Arrange
            const bool agileLayout = true;
            const SPFieldType type = SPFieldType.Number;
            const string dataXmlString = @"<xmlcfg Planner=""1"" View=""ViewName"" ID=""1""/>";
            const string plannerXmlString = @"
                <xmlcfg>
                    <Head>
                        <I Kind=""Filter"" Visible=""0""/>
                    </Head>
                    <Solid>
                        <Group Visible=""0""/>
                    </Solid>
                    <Cols/>
                    <Cfg/>
                    <LeftCols/>
                    <Header/>
                    <Def>
                        <D Name=""Assignment"" Visible=""0""/>
                        <D Name=""Task"" Visible=""0""/>
                    </Def>
                    <RightCols>
                        <C Name=""G"" GanttStrict=""0"" Visible=""0""/>
                        <C GanttDataUnits=""28800000""/>
                    </RightCols>
                    <Resources/>
                    <Foot/>
                </xmlcfg>";
            const string assignments = "True";
            const string filterInfo = "True^FilterField^FilterFieldValue^FilterFieldType";
            const string viewGroup = "1^viewGroup";
            const string gantt = "1";
            const string defaultView = "defaultView";
            var viewList = $"{defaultView}|1|2|3|4|5|6|7|8|{assignments}`0|1|{filterInfo}|{viewGroup}|viewSort|{gantt}|6|7|8|9";
            var schemaXml = $@"
                <xmlcfg>
                    <Default>{DummyString}</Default>
                </xmlcfg>";
            const string hours = "300";
            var plannerProps = new PlannerProps()
            {
                bStartSoon = true,
                bAgile = true,
                sListProjectCenter = DummyString,
                sListTaskCenter = DummyString,
                iWorkHours = new int[]
                {
                    60, 120, 180, 240
                },
                sWorkDays = "0",
                Holidays = new DataTable()
            };
            var dataSet = default(DataSet);
            var row = default(DataRow);
            var now = DateTime.Now;
            var data = new XmlDocument();

            data.LoadXml(dataXmlString);
            plannerProps.Holidays.Columns.Add(HoursString);
            plannerProps.Holidays.Columns.Add(DateString);
            row = plannerProps.Holidays.NewRow();
            row[HoursString] = string.Empty;
            row[DateString] = now;
            plannerProps.Holidays.Rows.Add(row);
            row = plannerProps.Holidays.NewRow();
            row[HoursString] = hours;
            row[DateString] = now;
            plannerProps.Holidays.Rows.Add(row);

            spField.TypeGet = () => type;
            spField.SchemaXmlGet = () => schemaXml;
            spViewFieldCollection.ExistsString = _ => true;
            spListItem.ItemGetGuid = _ => now;
            spFieldCollection.ContainsFieldString = _ => true;

            ShimCoreFunctions.getConfigSettingSPWebString = (_1, input) =>
            {
                if (input.EndsWith("ViewsDefault"))
                {
                    return defaultView;
                }
                return viewList;
            };
            ShimWorkPlannerAPI.getSettingsSPWebString = (_1, _2) =>
            {
                validations += 1;
                return plannerProps;
            };
            ShimWorkPlannerAPI.GetResourceTableWorkPlannerAPIPlannerPropsGuidStringSPWeb = (_1, _2, _3, _4) =>
            {
                validations += 1;
                return dataSet;
            };
            ShimWorkPlannerAPI.getRealFieldSPField = _ =>
            {
                validations += 1;
                return spField;
            };
            ShimWorkPlannerAPI.processFieldXmlDocumentRefSPFieldStringXmlNodeRefXmlNodeRefWorkPlannerAPIPlannerPropsSPWebDataSet = (ref XmlDocument docOut, SPField oField, string visible, ref XmlNode ndCols, ref XmlNode ndHeader, PlannerProps p, SPWeb web, DataSet dsResources) =>
            {
                validations += 1;
            };
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPField>()
            {
                spField
            }.GetEnumerator();
            ShimWorkPlannerAPI.isValidFieldStringBoolean = (_1, _2) =>
            {
                validations += 1;
                return true;
            };
            ShimWorkPlannerAPI.appendSpecialColumnsXmlDocumentRefXmlNodeRef = (ref XmlDocument docOut, ref XmlNode ndCols) =>
            {
                validations += 1;
            };
            ShimWorkPlannerAPI.addCalculationsWorkPlannerAPIPlannerPropsXmlDocumentRefXmlNodeRefBoolean = (PlannerProps p, ref XmlDocument docOut, ref XmlNode ndDef, bool bAgile) =>
            {
                validations += 1;
            };

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(
                IGetGeneralLayoutMethodName,
                nonPublicStatic,
                new object[] { spWeb.Instance, plannerXmlString, data, agileLayout }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .Element("xmlcfg")
                    .Element("Head")
                    .Elements("I")
                    .Count(x => x.Attribute("Visible").Value.Equals("1") && x.Attribute("FilterField").Value.Equals("FilterFieldValue") && x.Attribute("FilterFieldFilter").Value.Equals("FilterFieldType"))
                    .ShouldBe(1),
                () => actual
                    .Element("xmlcfg")
                    .Element("Solid")
                    .Element("Group")
                    .Attribute("Visible")
                    .Value
                    .ShouldBe("1"),
                () => actual
                    .Element("xmlcfg")
                    .Element("Def")
                    .Elements("D")
                    .Count()
                    .ShouldBe(4),
                () => actual
                    .Element("xmlcfg")
                    .Element("Def")
                    .Elements("D")
                    .FirstOrDefault(x => x.Attribute("Name").Value.Equals("Assignment"))
                    .Attribute("Visible")
                    .Value
                    .ShouldBe("1"),
                () => actual
                    .Element("xmlcfg")
                    .Element("RightCols")
                    .Elements("C")
                    .Count()
                    .ShouldBe(5),
                () => validations
                    .ShouldBe(11));
        }

        [TestMethod]
        public void IGetGeneralLayout_SPFieldTypeBoolean_ReturnsString()
        {
            // Arrange
            const bool agileLayout = true;
            const SPFieldType type = SPFieldType.Boolean;
            const string dataXmlString = @"<xmlcfg Planner=""1"" View=""ViewName"" ID=""1""/>";
            const string plannerXmlString = @"
                <xmlcfg>
                    <Head>
                        <I Kind=""Filter"" Visible=""0""/>
                    </Head>
                    <Solid>
                        <Group Visible=""0""/>
                    </Solid>
                    <Cols/>
                    <Cfg/>
                    <LeftCols/>
                    <Header/>
                    <Def>
                        <D Name=""Assignment"" Visible=""0""/>
                        <D Name=""Task"" Visible=""0""/>
                    </Def>
                    <RightCols>
                        <C Name=""G"" GanttStrict=""0"" Visible=""0""/>
                        <C GanttDataUnits=""28800000""/>
                    </RightCols>
                    <Resources/>
                    <Foot/>
                </xmlcfg>";
            const string assignments = "false";
            const string filterInfo = "false^FilterField^FilterFieldValue^FilterFieldType";
            const string viewGroup = "1^viewGroup";
            const string gantt = "1";
            const string defaultView = "defaultView";
            var viewList = $"{defaultView}|1|2|3|4|5|6|7|8|{assignments}`0|1|{filterInfo}|{viewGroup}|viewSort|{gantt}|6|7|8|9";
            var schemaXml = $@"
                <xmlcfg>
                    <Default>{DummyString}</Default>
                </xmlcfg>";
            const string hours = "300";
            var plannerProps = new PlannerProps()
            {
                bStartSoon = true,
                bAgile = true,
                sListProjectCenter = DummyString,
                sListTaskCenter = DummyString,
                iWorkHours = new int[]
                {
                    240, 180, 120, 60
                },
                sWorkDays = "0",
                Holidays = new DataTable()
            };
            var dataSet = default(DataSet);
            var row = default(DataRow);
            var now = DateTime.Now;
            var data = new XmlDocument();

            data.LoadXml(dataXmlString);
            plannerProps.Holidays.Columns.Add(HoursString);
            plannerProps.Holidays.Columns.Add(DateString);
            row = plannerProps.Holidays.NewRow();
            row[HoursString] = string.Empty;
            row[DateString] = now;
            plannerProps.Holidays.Rows.Add(row);
            row = plannerProps.Holidays.NewRow();
            row[HoursString] = hours;
            row[DateString] = now;
            plannerProps.Holidays.Rows.Add(row);

            spField.TypeGet = () => type;
            spField.SchemaXmlGet = () => schemaXml;
            spViewFieldCollection.ExistsString = _ => true;
            spListItem.ItemGetGuid = _ => bool.TrueString;
            spFieldCollection.ContainsFieldString = _ => true;

            ShimCoreFunctions.getConfigSettingSPWebString = (_1, input) =>
            {
                if (input.EndsWith("ViewsDefault"))
                {
                    return defaultView;
                }
                return viewList;
            };
            ShimWorkPlannerAPI.getSettingsSPWebString = (_1, _2) =>
            {
                validations += 1;
                return plannerProps;
            };
            ShimWorkPlannerAPI.GetResourceTableWorkPlannerAPIPlannerPropsGuidStringSPWeb = (_1, _2, _3, _4) =>
            {
                validations += 1;
                return dataSet;
            };
            ShimWorkPlannerAPI.getRealFieldSPField = _ =>
            {
                validations += 1;
                return spField;
            };
            ShimWorkPlannerAPI.processFieldXmlDocumentRefSPFieldStringXmlNodeRefXmlNodeRefWorkPlannerAPIPlannerPropsSPWebDataSet = (ref XmlDocument docOut, SPField oField, string visible, ref XmlNode ndCols, ref XmlNode ndHeader, PlannerProps p, SPWeb web, DataSet dsResources) =>
            {
                validations += 1;
            };
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPField>()
            {
                spField
            }.GetEnumerator();
            ShimWorkPlannerAPI.isValidFieldStringBoolean = (_1, _2) =>
            {
                validations += 1;
                return true;
            };
            ShimWorkPlannerAPI.appendSpecialColumnsXmlDocumentRefXmlNodeRef = (ref XmlDocument docOut, ref XmlNode ndCols) =>
            {
                validations += 1;
            };
            ShimWorkPlannerAPI.addCalculationsWorkPlannerAPIPlannerPropsXmlDocumentRefXmlNodeRefBoolean = (PlannerProps p, ref XmlDocument docOut, ref XmlNode ndDef, bool bAgile) =>
            {
                validations += 1;
            };

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(
                IGetGeneralLayoutMethodName,
                nonPublicStatic,
                new object[] { spWeb.Instance, plannerXmlString, data, agileLayout }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .Element("xmlcfg")
                    .Element("Head")
                    .Elements("I")
                    .Count(x => x.Attribute("Visible").Value.Equals("0") && x.Attribute("FilterField").Value.Equals("FilterFieldValue") && x.Attribute("FilterFieldFilter").Value.Equals("FilterFieldType"))
                    .ShouldBe(1),
                () => actual
                    .Element("xmlcfg")
                    .Element("Solid")
                    .Element("Group")
                    .Attribute("Visible")
                    .Value
                    .ShouldBe("1"),
                () => actual
                    .Element("xmlcfg")
                    .Element("Def")
                    .Elements("D")
                    .Count()
                    .ShouldBe(4),
                () => actual
                    .Element("xmlcfg")
                    .Element("Def")
                    .Elements("D")
                    .FirstOrDefault(x => x.Attribute("Name").Value.Equals("Assignment"))
                    .Attribute("Visible")
                    .Value
                    .ShouldBe("0"),
                () => actual
                    .Element("xmlcfg")
                    .Element("RightCols")
                    .Elements("C")
                    .Count()
                    .ShouldBe(5),
                () => validations
                    .ShouldBe(11));
        }

        [TestMethod]
        public void IsNewValidTask_SPIDPresent_ReturnsFalse()
        {
            // Arrange
            var dataXmlString = $@"
                <xmlcfg>
                    <I SPID=""{DummyInt}""/>
                    <I id=""{DummyString}""/>
                </xmlcfg>";
            var data = new XmlDocument();

            data.LoadXml(dataXmlString);

            // Act
            var actual = (bool)privateObject.Invoke(IsNewValidTaskMethodName, nonPublicStatic, new object[] { spListItem.Instance, data });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void IsNewValidTask_SPIDNotPresentIDPresent_ReturnsFalse()
        {
            // Arrange
            var dataXmlString = $@"
                <xmlcfg>
                    <I SPID=""Not{DummyInt}""/>
                    <I id=""{DummyString}""/>
                </xmlcfg>";
            var data = new XmlDocument();

            data.LoadXml(dataXmlString);

            // Act
            var actual = (bool)privateObject.Invoke(IsNewValidTaskMethodName, nonPublicStatic, new object[] { spListItem.Instance, data });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void IsNewValidTask_SPIDNotPresentIDNotPresent_ReturnsFalse()
        {
            // Arrange
            var dataXmlString = $@"
                <xmlcfg>
                    <I SPID=""Not{DummyInt}""/>
                    <I id=""Not{DummyString}""/>
                </xmlcfg>";
            var data = new XmlDocument();

            data.LoadXml(dataXmlString);

            // Act
            var actual = (bool)privateObject.Invoke(IsNewValidTaskMethodName, nonPublicStatic, new object[] { spListItem.Instance, data });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void AppendNewAgileTasks_WhenCalled_ReturnsString()
        {
            // Arrange
            const string dummyString2 = "SomeRandomString";
            const string dataXmlString = @"
                <xmlcfg>
                    <B>
                        <I id=""0""/>
                    </B>
                </xmlcfg>";
            var data = new XmlDocument();
            var plannerProps = new PlannerProps()
            {
                sListTaskCenter = DummyString,
                sIterationCT = DummyString
            };
            var spField2 = new ShimSPField()
            {
                TypeGet = () => SPFieldType.DateTime,
                HiddenGet = () => false,
                InternalNameGet = () => dummyString2,
                ReorderableGet = () => true
            };

            data.LoadXml(dataXmlString);

            spField.TypeGet = () => SPFieldType.Number;
            spListItem.ItemSetStringObject = (_1, _2) =>
            {
                validations += 1;
            };
            spListItem.SystemUpdate = () =>
            {
                validations += 1;
            };

            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPField>()
            {
                spField,
                spField2
            }.GetEnumerator();
            ShimSPListItemCollection.AllInstances.GetEnumerator = _ => new List<SPListItem>()
            {
                spListItem
            }.GetEnumerator();
            ShimWorkPlannerAPI.isNewValidTaskSPListItemXmlDocument = (_1, _2) =>
            {
                validations += 1;
                return true;
            };
            ShimWorkPlannerAPI.isValidFieldStringBoolean = (_1, _2) =>
            {
                validations += 1;
                return true;
            };
            ShimWorkPlannerAPI.getFieldValueSPListItemSPFieldDataSet = (_1, _2, _3) =>
            {
                validations += 1;
                return DummyString;
            };

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(
                AppendNewAgileTasksMethodName,
                nonPublicStatic,
                new object[] { spWeb.Instance, plannerProps, data, DummyString, default(DataSet) }));
            var backLogNode = actual.Element("xmlcfg").Element("B").Element("I").Elements("I").FirstOrDefault(x => x.Attribute("id").Value.Equals("BacklogRow"));
            var taskNode = backLogNode.Element("I");

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => backLogNode
                    .ShouldNotBeNull(),
                () => backLogNode
                    .Attribute("Title")
                    .Value
                    .ShouldBe("Backlog"),
                () => backLogNode
                    .Attribute("Detail")
                    .Value
                    .ShouldBe("AgileGrid"),
                () => taskNode
                    .Attribute("SPID")
                    .Value
                    .ShouldBe($"{DummyInt}"),
                () => taskNode
                    .Attribute("Def")
                    .Value
                    .ShouldBe("Task"),
                () => taskNode
                    .Attribute(DummyString)
                    .Value
                    .ShouldBe(DummyString),
                () => taskNode
                    .Attribute(dummyString2)
                    .Value
                    .ShouldBe(DummyString),
                () => validations
                    .ShouldBe(7));
        }

        [TestMethod]
        public void GetAgileFolderFieldFormula_StartDateField_ReturnsString()
        {
            // Arrange
            const string field = "StartDate";
            const string expected = "min()";

            // Act
            var actual = (string)privateObject.Invoke(GetAgileFolderFieldFormulaMethodName, nonPublicStatic, new object[] { field });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetAgileFolderFieldFormula_DueDateField_ReturnsString()
        {
            // Arrange
            const string field = "DueDate";
            const string expected = "max()";

            // Act
            var actual = (string)privateObject.Invoke(GetAgileFolderFieldFormulaMethodName, nonPublicStatic, new object[] { field });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetAgileFolderFieldFormula_ResourcePointsField_ReturnsString()
        {
            // Arrange
            const string field = "ResourcePoints";
            const string expected = "sum()";

            // Act
            var actual = (string)privateObject.Invoke(GetAgileFolderFieldFormulaMethodName, nonPublicStatic, new object[] { field });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetAgileFolderFieldFormula_WorkCapacityField_ReturnsString()
        {
            // Arrange
            const string field = "WorkCapacity";
            const string expected = "sum()";

            // Act
            var actual = (string)privateObject.Invoke(GetAgileFolderFieldFormulaMethodName, nonPublicStatic, new object[] { field });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetAgileFolderFieldFormula_OtherField_ReturnsString()
        {
            // Arrange
            const string field = "Other";

            // Act
            var actual = (string)privateObject.Invoke(GetAgileFolderFieldFormulaMethodName, nonPublicStatic, new object[] { field });

            // Assert
            actual.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void AddCalculations_WhenCalled_AddsAttributes()
        {
            // Arrange
            const string expectedOrder = "StartDate,DueDate,Duration,PercentComplete,G,DummyString,ResourcePoints,RollDown,WorkCapacity";
            const string expectedIterationOrder = "StartDate,DueDate,Duration,PercentComplete,G,DummyString,ResourcePoints,RollDown,WorkCapacity,Available,AvailableWork";
            const string expectedStartDateFormula = "minimum(min('StartDate'),min('DueDate'))";
            const string expectedDueDateFormula = "maximum(max('StartDate'),max('DueDate'))";
            const string dataXmlString = @"
                <xmlcfg>
                    <Def/>
                </xmlcfg>";
            var data = new XmlDocument();
            var defNode = default(XmlNode);
            var plannerProps = new PlannerProps()
            {
                bAgile = true,
                wpFields = new WorkPlannerProperties(string.Empty)
            };

            data.LoadXml(dataXmlString);
            defNode = data.FirstChild.SelectSingleNode("//Def");
            plannerProps.wpFields.set("PercentComplete", string.Empty);
            plannerProps.wpFields.set("StartDate", string.Empty);
            plannerProps.wpFields.set("DueDate", string.Empty);
            plannerProps.wpFields.set(DummyString, DummyString);
            plannerProps.wpFields.set("RollDown", "RollDown");

            // Act
            privateObject.Invoke(AddCalculationsMethodName, nonPublicStatic, new object[] { plannerProps, data, defNode, true });

            // Assert
            defNode.ShouldSatisfyAllConditions(
                () => defNode.ChildNodes.Count.ShouldBe(14),
                () => defNode.SelectSingleNode($"//D[@CalcOrder='{expectedOrder}']").ShouldNotBeNull(),
                () => defNode.SelectSingleNode($"//D[@CalcOrder='{expectedIterationOrder}']").ShouldNotBeNull(),
                () => defNode.SelectNodes("//D[@DummyStringFormula='dummystring()']").Count.ShouldBe(3),
                () => defNode.SelectNodes($"//D[@StartDateFormula=\"{expectedStartDateFormula}\"]").Count.ShouldBe(2),
                () => defNode.SelectNodes($"//D[@DueDateFormula=\"{expectedDueDateFormula}\"]").Count.ShouldBe(2),
                () => defNode.SelectNodes("//D[@StartDateFormula='min()']").Count.ShouldBe(1),
                () => defNode.SelectNodes("//D[@DueDateFormula='max()']").Count.ShouldBe(1),
                () => defNode.SelectNodes("//D[@WorkCapacityFormula='sum()']").Count.ShouldBe(1));
        }

        [TestMethod]
        public void GetFolderLayout_WhenCalled_ReturnsString()
        {
            // Arrange
            const string dataXmlString = @"<xmlcfg Planner=""1"" View="""" ID=""1""/>";
            const string docXmlString = @"
                <xmlcfg>
                    <C Name=""Title"" Width=""""/>
                    <Cols/>
                    <Header/>
                    <Def/>
                </xmlcfg>";
            var data = new XmlDocument();
            var props = new PlannerProps()
            {
                sListTaskCenter = DummyString,
                sListProjectCenter = DummyString
            };

            data.LoadXml(dataXmlString);

            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => docXmlString;
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
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPField>()
            {
                spField
            }.GetEnumerator();
            ShimWorkPlannerAPI.getRealFieldSPField = _ =>
            {
                validations += 1;
                return spField;
            };
            ShimWorkPlannerAPI.isValidFieldStringBoolean = (_1, _2) =>
            {
                validations += 1;
                return true;
            };
            ShimWorkPlannerAPI.processFieldXmlDocumentRefSPFieldStringXmlNodeRefXmlNodeRefWorkPlannerAPIPlannerPropsSPWebDataSet = (ref XmlDocument docOut, SPField oField, string visible, ref XmlNode ndCols, ref XmlNode ndHeader, PlannerProps p, SPWeb web, DataSet dsResources) =>
            {
                validations += 1;
            };
            ShimWorkPlannerAPI.appendSpecialColumnsXmlDocumentRefXmlNodeRef = (ref XmlDocument docOut, ref XmlNode ndCols) =>
            {
                validations += 1;
            };
            ShimWorkPlannerAPI.addCalculationsWorkPlannerAPIPlannerPropsXmlDocumentRefXmlNodeRefBoolean = (PlannerProps p, ref XmlDocument docOut, ref XmlNode ndDef, bool bAgile) =>
            {
                validations += 1;
            };

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(GetFolderLayoutMethodName, publicStatic, new object[] { data, spWeb.Instance }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .Element("xmlcfg")
                    .Elements("C")
                    .FirstOrDefault(x => x.Attribute("Name").Value.Equals("Title"))
                    .Attribute("Width")
                    .ShouldBeNull(),
                () => actual
                    .Element("xmlcfg")
                    .Elements("C")
                    .FirstOrDefault(x => x.Attribute("Name").Value.Equals("Title"))
                    .Attribute("RelWidth")
                    .Value
                    .ShouldBe("100"),
                () => validations
                    .ShouldBe(7));
        }

        [TestMethod]
        public void GetViews_WhenCalled_ReturnsString()
        {
            // Arrange
            const string dataXmlString = @"<xmlcfg Planner=""1""/>";
            const string docXmlString = @"
                <xmlcfg>
                    <C/>
                    <Cols/>
                    <Header/>
                    <Def/>
                </xmlcfg>";
            var data = new XmlDocument();

            data.LoadXml(dataXmlString);
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => docXmlString;
            ShimWorkPlannerAPI.getSettingsSPWebString = (_1, _2) =>
            {
                validations += 1;
                return default(PlannerProps);
            };

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(GetViewsMethodName, publicStatic, new object[] { data, spWeb.Instance }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .Element("xmlcfg")
                    .Element("C")
                    .ShouldNotBeNull(),
                () => actual
                    .Element("xmlcfg")
                    .Element("Cols")
                    .ShouldNotBeNull(),
                () => actual
                    .Element("xmlcfg")
                    .Element("Header")
                    .ShouldNotBeNull(),
                () => actual
                    .Element("xmlcfg")
                    .Element("Def")
                    .ShouldNotBeNull(),
                () => validations
                    .ShouldBe(1));
        }

        [TestMethod]
        public void GetDetailLayout_WhenCalled_ReturnsString()
        {
            // Arrange
            const string dataXmlString = @"<xmlcfg Planner=""1"" View=""1"" ID=""1""/>";
            const string docXmlString = @"
                <xmlcfg>
                    <B/>
                </xmlcfg>";
            var data = new XmlDocument();
            var props = new PlannerProps()
            {
                sListTaskCenter = DummyString,
                sListProjectCenter = DummyString
            };

            data.LoadXml(dataXmlString);

            spField.TypeGet = () => SPFieldType.MultiChoice;
            spField.SchemaXmlGet = () => docXmlString;
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => docXmlString;
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
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPField>()
            {
                spField
            }.GetEnumerator();
            ShimWorkPlannerAPI.isValidFieldStringBoolean = (_1, _2) =>
            {
                validations += 1;
                return true;
            };
            ShimWorkPlannerAPI.getFormatSPFieldXmlDocumentStringOutSPWeb = (SPField oField, XmlDocument oDoc, out string EditFormat, SPWeb oWeb) =>
            {
                validations += 1;
                EditFormat = DummyString;
                return DummyString;
            };
            ShimWorkPlannerAPI.ReadOnlyFieldSPFieldWorkPlannerAPIPlannerProps = (_, __) =>
            {
                validations += 1;
                return true;
            };
            ShimWorkPlannerAPI.setEnumFieldSPFieldXmlNodeRefXmlDocumentXmlDocumentSPWebBooleanStringDataSet = (SPField oField, ref XmlNode ndCol, XmlDocument fieldDoc, XmlDocument docOut, SPWeb web, bool multi, string enumattr, DataSet dsResources) =>
            {
                validations += 1;
            };

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(GetDetailLayoutMethodName, publicStatic, new object[] { data, spWeb.Instance }));

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
                    .Attribute("VType")
                    .Value
                    .ShouldBe("Enum"),
                () => actual
                    .Element("xmlcfg")
                    .Element("B")
                    .Element("I")
                    .Attribute("VCanEdit")
                    .Value
                    .ShouldBe("0"),
                () => actual
                    .Element("xmlcfg")
                    .Element("B")
                    .Element("I")
                    .Attribute("VFormat")
                    .Value
                    .ShouldBe(DummyString),
                () => actual
                    .Element("xmlcfg")
                    .Element("B")
                    .Element("I")
                    .Attribute("VEditFormat")
                    .Value
                    .ShouldBe(DummyString),
                () => validations
                .ShouldBe(6));
        }

        [TestMethod]
        public void GetFieldValue_SPFieldTypeDateTime_ReturnsString()
        {
            // Arrange
            const string format = "yyyy-MM-dd HH:mm:ss";
            var now = DateTime.Now;
            var dataSet = default(DataSet);
            var expected = now.ToString(format);

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.DescriptionGet = () => DummyString;
            spListItem.ItemGetGuid = _ => now;

            // Act
            var actual = (string)privateObject.Invoke(
                GetFieldValueMethodName,
                publicStatic,
                new object[]
                {
                    spListItem.Instance,
                    spField.Instance,
                    dataSet
                });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetFieldValue_SPFieldTypeUser_ReturnsString()
        {
            // Arrange
            var expected = $"{One};{One}";
            var dataSet = new DataSet();
            var row = default(DataRow);

            dataSet.Tables.Add(new DataTable());
            dataSet.Tables.Add(new DataTable());
            dataSet.Tables.Add(new DataTable());

            dataSet.Tables[2].Columns.Add(IDStringCaps);
            dataSet.Tables[2].Columns.Add(AccountInfoString);

            row = dataSet.Tables[2].NewRow();
            row[IDStringCaps] = One;
            row[AccountInfoString] = DummyString;

            dataSet.Tables[2].Rows.Add(row);

            spField.TypeGet = () => SPFieldType.User;
            spField.DescriptionGet = () => DummyString;
            spListItem.ItemGetGuid = _ => DummyString;

            ShimList<SPFieldUserValue>.AllInstances.GetEnumerator = _ =>
            {
                var result = default(List<SPFieldUserValue>.Enumerator);
                var userValue = new ShimSPFieldUserValue();
                ShimsContext.ExecuteWithoutShims(() =>
                {
                    result = new List<SPFieldUserValue>()
                    {
                        userValue,
                        userValue
                    }.GetEnumerator();
                });
                return result;
            };
            ShimSPFieldLookupValue.AllInstances.ToString01 = _ => DummyString;

            // Act
            var actual = (string)privateObject.Invoke(
                GetFieldValueMethodName,
                publicStatic,
                new object[]
                {
                    spListItem.Instance,
                    spField.Instance,
                    dataSet
                });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetFieldValue_SPFieldTypeNote_ReturnsString()
        {
            // Arrange
            const string indicatorString = "Indicator";
            var dataSet = default(DataSet);
            var expected = $"<img src=\"{DummyString}/_layouts/images/{DummyString}\">";

            spField.TypeGet = () => SPFieldType.Note;
            spField.DescriptionGet = () => indicatorString;
            spListItem.ItemGetGuid = _ => DummyString;
            spWeb.ServerRelativeUrlGet = () => DummyString;

            // Act
            var actual = (string)privateObject.Invoke(
                GetFieldValueMethodName,
                publicStatic,
                new object[]
                {
                    spListItem.Instance,
                    spField.Instance,
                    dataSet
                });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetFieldValue_SPFieldTypeCalculatedNumber_ReturnsString()
        {
            // Arrange
            var dataSet = default(DataSet);
            var newField = new ShimSPFieldCalculated()
            {
                OutputTypeGet = () => SPFieldType.Number
            };

            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Calculated;
            ShimSPField.AllInstances.DescriptionGet = _ => DummyString;
            spListItem.ItemGetGuid = _ => $"{DummyString};#{DummyString}";

            // Act
            var actual = (string)privateObject.Invoke(GetFieldValueMethodName, publicStatic, new object[] { spListItem.Instance, newField.Instance, dataSet });

            // Assert
            actual.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetFieldValue_SPFieldTypeCalculatedOther_ReturnsString()
        {
            // Arrange
            var dataSet = default(DataSet);
            var newField = new ShimSPFieldCalculated()
            {
                OutputTypeGet = () => SPFieldType.Attachments
            };

            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Calculated;
            ShimSPField.AllInstances.DescriptionGet = _ => DummyString;
            spListItem.ItemGetGuid = _ => DummyString;
            ShimSPFieldCalculated.AllInstances.GetFieldValueAsTextObject = (_, __) => DummyString;

            // Act
            var actual = (string)privateObject.Invoke(
                GetFieldValueMethodName,
                publicStatic,
                new object[]
                {
                    spListItem.Instance,
                    newField.Instance,
                    dataSet
                });

            // Assert
            actual.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetFieldValue_SPFieldTypeNumber_ReturnsString()
        {
            // Arrange
            const string expected = "100";
            var dataSet = default(DataSet);
            var newField = new ShimSPFieldNumber()
            {
                ShowAsPercentageGet = () => true
            };

            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;
            ShimSPField.AllInstances.DescriptionGet = _ => DummyString;
            spListItem.ItemGetGuid = _ => One;

            // Act
            var actual = (string)privateObject.Invoke(
                GetFieldValueMethodName,
                publicStatic,
                new object[]
                {
                    spListItem.Instance,
                    newField.Instance,
                    dataSet
                });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetFieldValue_SPFieldTypeCurrency_ReturnsString()
        {
            // Arrange
            var dataSet = default(DataSet);

            spField.TypeGet = () => SPFieldType.Currency;
            spField.DescriptionGet = () => DummyString;
            spListItem.ItemGetGuid = _ => DummyString;

            // Act
            var actual = (string)privateObject.Invoke(
                GetFieldValueMethodName,
                publicStatic,
                new object[]
                {
                    spListItem.Instance,
                    spField.Instance,
                    dataSet
                });

            // Assert
            actual.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetFieldValue_SPFieldTypeBooleanTrue_ReturnsString()
        {
            // Arrange
            const string expected = "1";
            var dataSet = default(DataSet);

            spField.TypeGet = () => SPFieldType.Boolean;
            spField.DescriptionGet = () => DummyString;
            spListItem.ItemGetGuid = _ => bool.TrueString;

            // Act
            var actual = (string)privateObject.Invoke(
                GetFieldValueMethodName,
                publicStatic,
                new object[]
                {
                    spListItem.Instance,
                    spField.Instance,
                    dataSet
                });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetFieldValue_SPFieldTypeBooleanFalse_ReturnsString()
        {
            // Arrange
            const string expected = "0";
            var dataSet = default(DataSet);

            spField.TypeGet = () => SPFieldType.Boolean;
            spField.DescriptionGet = () => DummyString;
            spListItem.ItemGetGuid = _ => bool.FalseString;

            // Act
            var actual = (string)privateObject.Invoke(
                GetFieldValueMethodName,
                publicStatic,
                new object[]
                {
                    spListItem.Instance,
                    spField.Instance,
                    dataSet
                });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetFieldValue_SPFieldTypeOther_ReturnsString()
        {
            // Arrange
            var dataSet = default(DataSet);

            spField.TypeGet = () => SPFieldType.Attachments;
            spField.DescriptionGet = () => DummyString;
            spListItem.ItemGetGuid = _ => DummyString;
            spField.GetFieldValueAsTextObject = _ => DummyString;

            // Act
            var actual = (string)privateObject.Invoke(
                GetFieldValueMethodName,
                publicStatic,
                new object[]
                {
                    spListItem.Instance,
                    spField.Instance,
                    dataSet
                });

            // Assert
            actual.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetFieldValue_SPFieldTypeLookup_ReturnsString()
        {
            // Arrange
            var expected = $"{One};{One}";
            var dataSet = default(DataSet);

            spField.TypeGet = () => SPFieldType.Lookup;
            spField.DescriptionGet = () => DummyString;
            spListItem.ItemGetGuid = _ => DummyString;

            ShimList<SPFieldLookupValue>.AllInstances.GetEnumerator = _ =>
            {
                var result = default(List<SPFieldLookupValue>.Enumerator);
                var lookupValue = new ShimSPFieldLookupValue()
                {
                    LookupIdGet = () => One
                };
                ShimsContext.ExecuteWithoutShims(() =>
                {
                    result = new List<SPFieldLookupValue>()
                    {
                        lookupValue,
                        lookupValue
                    }.GetEnumerator();
                });
                return result;
            };

            // Act
            var actual = (string)privateObject.Invoke(
                GetFieldValueMethodName,
                publicStatic,
                new object[]
                {
                    spListItem.Instance,
                    spField.Instance,
                    dataSet
                });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void SetupProjectCenterList_WhenCalled_Returns()
        {
            // Arrange
            var actual = new Dictionary<string, bool>()
            {
                [$"{DummyString}FAC"] = false,
                [$"{DummyString}FRL"] = false,
                [$"{DummyString}FSC"] = false,
                [$"{DummyString}BD"] = false,
            };

            spFieldCollection.AddStringSPFieldTypeBoolean = (input, _1, _2) =>
            {
                if (actual.ContainsKey(input))
                {
                    actual[input] = true;
                    validations += 1;
                }
                return input;
            };
            spFieldCollection.ItemGetString = _ =>
            {
                validations += 1;
                return spField;
            };
            spField.TitleSetString = _ =>
            {
                validations += 1;
            };
            spField.HiddenSetBoolean = _ =>
            {
                validations += 1;
            };
            spField.SealedSetBoolean = _ =>
            {
                validations += 1;
            };
            spField.Update = () =>
            {
                validations += 1;
            };
            spList.Update = () =>
            {
                validations += 1;
            };

            // Act
            privateObject.Invoke(SetupProjectCenterListMethodName, nonPublicStatic, new object[] { spList.Instance, DummyString });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count(x => x.Value.Equals(true)).ShouldBe(4),
                () => validations.ShouldBe(28));
        }
    }
}