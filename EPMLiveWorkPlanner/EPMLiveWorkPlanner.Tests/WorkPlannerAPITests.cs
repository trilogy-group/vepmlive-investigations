using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Xml;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveWorkPlanner.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWorkPlanner.Tests
{
    [TestClass()]
    public class WorkPlannerAPITests
    {
        private IDisposable shimsContext;

        [TestInitialize()]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        [TestMethod()]
        public void processTasksTest_Execute_Catch_Block()
        {
            //Arrange
            #region  Arrange
            XmlNode ndImportTask, ndParent;
            XmlDocument docRet, docPlan;
            string sUID, sResField, sTaskType, xml;
            int curtaskuid = 5;
            ArrayList arrCols = new ArrayList();
            arrCols.Add("TaskType");
            arrCols.Add("AssignedTo");
            arrCols.Add("TestColumn");

            bool bAllowDuplicates = false;

            sUID = "";
            DataSet dsResources = new DataSet();
            // First Datatable
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Title");
            dt1.Columns.Add("SPID");
            DataRow dr1 = dt1.NewRow();
            dr1["Title"] = "";
            dr1["SPID"] = "";
            dt1.Rows.Add(dr1);
            dsResources.Tables.Add(dt1);
            // End 

            // Second Datatable
            dsResources.Tables.Add(new DataTable());
            // End

            // Third Datatable
            DataTable dt = new DataTable();
            dt.Columns.Add("ResId");
            dt.Columns.Add("ID");
            dt.Columns.Add("ResName");
            DataRow dr = dt.NewRow();
            dr["ResId"] = string.Empty;
            dr["ResName"] = string.Empty;
            dr["ID"] = "13";
            dt.Rows.Add(dr);
            dsResources.Tables.Add(dt);
            //End

            sTaskType = "";
            sResField = "ResId";
            xml = "<book id=\"1\" Def=\"\">" +
                "<title id=\"1\" Def=\"\">Test XML</title>" +
                "</book>";
            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xml);
            docRet = doc;
            docPlan = doc;
            ndImportTask = doc.FirstChild;
            ndParent = doc.FirstChild;
            #endregion

            //Act
            PrivateType objToTestPrivateMethod = new PrivateType(typeof(WorkPlannerAPI));
            objToTestPrivateMethod.InvokeStatic("processTasks", new object[] { ndImportTask, docRet, ndParent, docPlan, sUID, arrCols, bAllowDuplicates, curtaskuid, sResField, dsResources, sTaskType });


            //Assert
            Assert.AreEqual(docRet.FirstChild.Attributes["id"].Value, "1");
            Assert.AreEqual(docRet.FirstChild.Attributes["Def"].Value, "Summary");

        }

        [TestMethod()]
        public void processTasksTest()
        {
            //Arrange
            #region Arrange
            XmlNode ndImportTask, ndParent;
            XmlDocument docRet, docPlan;
            string sUID, sResField, sTaskType, xml;
            int curtaskuid = 5;
            ArrayList arrCols = new ArrayList();
            arrCols.Add("TaskType");
            arrCols.Add("AssignedTo");
            arrCols.Add("Title");
            arrCols.Add("ResourceNames");

            bool bAllowDuplicates = false;

            sUID = "";
            DataSet dsResources = new DataSet();
            // First Datatable
            DataTable dt1 = new DataTable();

            dsResources.Tables.Add(dt1);
            // End 

            // Second Datatable
            dsResources.Tables.Add(new DataTable());
            // End

            // Third Datatable
            DataTable dt = new DataTable();
            dt.Columns.Add("ResId");
            dt.Columns.Add("ID");
            dt.Columns.Add("ResName");
            dt.Columns.Add("Title");
            dt.Columns.Add("SPID");
            DataRow dr = dt.NewRow();
            dr["ResId"] = string.Empty;
            dr["ResName"] = string.Empty;
            dr["Title"] = "";
            dr["SPID"] = "";

            dr["ID"] = "13";
            dt.Rows.Add(dr);
            dsResources.Tables.Add(dt);
            //End

            sTaskType = "";
            sResField = "ResId";
            xml = "<book id=\"1\" Def=\"\" >" +
                "<title id=\"1\" Def=\"\">Test XML</title>" +
                "</book>";
            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xml);
            docRet = doc;
            docPlan = doc;
            ndImportTask = doc.FirstChild;
            ndParent = doc.FirstChild;
            #endregion
            //Act
            PrivateType objToTestPrivateMethod = new PrivateType(typeof(WorkPlannerAPI));
            objToTestPrivateMethod.InvokeStatic("processTasks", new object[] { ndImportTask, docRet, ndParent, docPlan, sUID, arrCols, bAllowDuplicates, curtaskuid, sResField, dsResources, sTaskType });

            //Assert
            Assert.AreEqual(docRet.FirstChild.Attributes["id"].Value, "1");
            Assert.AreEqual(docRet.FirstChild.Attributes["Def"].Value, "Summary");

        }

        [TestMethod()]
        public void processTasksTest_When_ndCurNode_notNull_and_bAllowDuplicates_Is_false()
        {
            //Arrange
            #region Arrange
            XmlNode ndImportTask, ndParent;
            XmlDocument docRet, docPlan;
            string sUID, sResField, sTaskType, xml;
            int curtaskuid = 5;
            ArrayList arrCols = new ArrayList();
            arrCols.Add("TaskType");
            arrCols.Add("AssignedTo");
            arrCols.Add("Title");
            arrCols.Add("ResourceNames");

            bool bAllowDuplicates = false;

            sUID = "";
            DataSet dsResources = new DataSet();
            // First Datatable
            DataTable dt1 = new DataTable();

            dsResources.Tables.Add(dt1);
            // End 

            // Second Datatable
            dsResources.Tables.Add(new DataTable());
            // End

            // Third Datatable
            DataTable dt = new DataTable();
            dt.Columns.Add("ResId");
            dt.Columns.Add("ID");
            dt.Columns.Add("ResName");
            dt.Columns.Add("Title");
            dt.Columns.Add("SPID");
            DataRow dr = dt.NewRow();
            dr["ResId"] = string.Empty;
            dr["ResName"] = string.Empty;
            dr["Title"] = "";
            dr["SPID"] = "";

            dr["ID"] = "13";
            dt.Rows.Add(dr);
            dsResources.Tables.Add(dt);
            //End

            sTaskType = "";
            sResField = "ResId";
            xml = "<book id=\"1\" Def=\"\" >" +
                "<title id=\"1\" Def=\"\">Test XML</title>" +
                "<I EXTID=\"\"></I>" +
                "</book>";
            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xml);
            docRet = doc;
            docPlan = doc;
            ndImportTask = doc.FirstChild;
            ndParent = doc.FirstChild;
            #endregion
            //Act
            PrivateType objToTestPrivateMethod = new PrivateType(typeof(WorkPlannerAPI));
            objToTestPrivateMethod.InvokeStatic("processTasks", new object[] { ndImportTask, docRet, ndParent, docPlan, sUID, arrCols, bAllowDuplicates, curtaskuid, sResField, dsResources, sTaskType });

            //Assert
            Assert.AreEqual(docRet.FirstChild.Attributes["id"].Value, "1");
            Assert.AreEqual(docRet.FirstChild.Attributes["Def"].Value, "");
        }

        [TestMethod]
        public void GetExternalTasks_Should_ExecuteCorrectly()
        {
            // Arrange
            SetupShims();
            const string DummyString = "Dummy";
            const string PercentField = "PercentField";
            const string NumberField = "NumberField";
            var xmlDocument = new XmlDocument();
            var web = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    TryGetListString = name => new ShimSPList
                    {
                        FieldsGet = () =>
                        {
                            var list = new List<SPField>
                            {
                                new ShimSPField
                                {
                                    TypeGet = () => SPFieldType.User,
                                    InternalNameGet = () => DummyString
                                },
                                new ShimSPField
                                {
                                    TypeGet = () => SPFieldType.Text,
                                    HiddenGet = () => false,
                                    InternalNameGet = () => "WBS",
                                    ReorderableGet = () => true
                                },
                                new ShimSPField(new ShimSPFieldNumber() {  ShowAsPercentageGet = () => true })
                                {
                                    TypeGet = () => SPFieldType.Number,
                                    HiddenGet = () => false,
                                    InternalNameGet = () => PercentField,
                                    ReorderableGet = () => true
                                },
                                new ShimSPField(new ShimSPFieldNumber() {  ShowAsPercentageGet = () => false })
                                {
                                    TypeGet = () => SPFieldType.Number,
                                    HiddenGet = () => false,
                                    InternalNameGet = () => NumberField,
                                    ReorderableGet = () => true
                                },
                                new ShimSPField()
                                {
                                    TypeGet = () => SPFieldType.Boolean,
                                    HiddenGet = () => false,
                                    InternalNameGet = () => "BoolField",
                                    ReorderableGet = () => true
                                },
                                new ShimSPField
                                {
                                    TypeGet = () => SPFieldType.Text,
                                    HiddenGet = () => false,
                                    InternalNameGet = () => $"{DummyString}ID",
                                    ReorderableGet = () => true
                                }
                            };
                            return new ShimSPFieldCollection().Bind(list);
                        }
                    }
                }
            };
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString = (spWeb, list, rollup, query, orderBy) => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow
                        {
                            ItemGetString = name => $"{DummyString}.{DummyString}"
                        },
                        new ShimDataRow
                        {
                            ItemGetString = name => DummyString
                        }
                    }.GetEnumerator()
                }
            };
            var expectedContent = new List<string>
            {
                "<Actions OnClickCell=\"ClearSelection,SelectRow\" />",
                $"<I Def=\"Task\" PercentField=\"\" Dummy=\"\" WBS=\"{DummyString}\" " +
                $"NumberField=\"{DummyString}\" BoolField=\"0\" id=\"{DummyString}\" />",
                "<Cfg id=\"WorkPlannerGrid\" SuppressCfg=\"1\" DateStrings=\"2\" ConstWidth=\"0\" ConstHeight=\"1\" Editing=\"0\" Dragging=\"0\" />"
            };

            // Act
            var result = WorkPlannerAPI.GetExternalTasks(xmlDocument, web);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => expectedContent.ForEach(p => result.ShouldContainWithoutWhitespace(p)));
        }

        private void SetupShims()
        {
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimSPSite.ConstructorGuid = (_, guid) => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimCoreFunctions.getLockedWebSPWeb = _ => Guid.NewGuid();
            ShimCoreFunctions.getConfigSettingSPWebString = (_, name) => "Dummy";
            ShimWorkPlannerAPI.getAttributeXmlNodeString = (node, name) => "Dummy";
            ShimWorkPlannerAPI.iGetGeneralLayoutSPWebStringXmlDocumentBoolean = (spWeb, plannerXml, data, agileLayout) => plannerXml;
            ShimAPITeam.GetResourcePoolStringSPWeb = (xml, spWeb) => new DataTable();
        }
    }
}