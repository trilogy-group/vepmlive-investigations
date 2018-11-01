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
    }
}