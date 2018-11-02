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
    public partial class WorkPlannerAPITests
    {
        private const string PublishProcessTasksMethodName = "PublishProcessTasks";
        private const string PublishProcessTaskMethodName = "PublishProcessTask";
        private const string PublishGetFieldValueMethodName = "PublishGetFieldValue";
        private const string PublishProcessFoldersMethodName = "PublishProcessFolders";
        private const string PublishMethodName = "Publish";
        private const string IGetGeneralLayoutMethodName = "iGetGeneralLayout";
        private const string HoursString = "Hours";
        private const string DateString = "Date";

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
            dataSet.Tables[2].Columns.Add(AccountInfpString);

            row = dataSet.Tables[2].NewRow();
            row[IDStringCaps] = 1;
            row[AccountInfpString] = DummyString;

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
    }
}