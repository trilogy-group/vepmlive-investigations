using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPMLiveWorkPlanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Collections;
using System.Data;
using System.Data.Fakes;

namespace EPMLiveWorkPlanner.Tests
{
    [TestClass()]
    public class WorkPlannerAPITests
    {
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
    }
}