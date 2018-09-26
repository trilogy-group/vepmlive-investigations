using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Xml;
using EPMLive.TestFakes.Utility;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using TimeSheets.Fakes;

namespace TimeSheets.Tests
{
    public partial class GetTsTests
    {
        private IDisposable _shimContext;
        private SharepointShims _shimSharepointCalls;
        private PrivateObject _privateObject;

        private const string AddGroupsMethod = "addGroups";
        private const string docXmlProperty = "docXml";
        private const string ndMainParentProperty = "ndMainParent";
        private const string queueAllItemsProperty = "queueAllItems";
        private const string arrItemsProperty = "arrItems";

        private const string dsTimesheetsProperty = "dsTimesheets";
        private const string dsTimesheetTasksProperty = "dsTimesheetTasks";
        private const string dsTimesheetTaskHoursProperty = "dsTimesheetTaskHours";
        private const string dsTimesheetNotesProperty = "dsTimesheetNotes";
        private const string dsTimesheetTypesProperty = "dsTimesheetTypes";

        private const string hshResNodesProperty = "hshResNodes";
        private const string hshItemNodesProperty = "hshItemNodes";

        private const string dayDefsProperty = "dayDefs";

        private const string Group = "group";
        private const string LoginName = "loginName";
        private const string Name = "name";

        private const string Project = "project";
        private const string Hours = "hours";
        private const string ApprovalStatus1 = "APPROVAL_STATUS";
        private const string True = "True";

        private const string ApprovalStatus2 = "approval_status";
        private const string Submitted = "submitted";

        private const string Pending = "0";
        private const string Approved = "1";
        private const string Rejected = "2";

        private const int Id = 0;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            _shimSharepointCalls = SharepointShims.ShimSharepointCalls();

            _privateObject = new PrivateObject(typeof(getts));

            ArrangeShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
        }

        [TestMethod]
        public void addGroups_When_Pending_And_RowCount()
        {
            CommonTestData(Pending, 1, EPMLiveTimesheets.Tests.Properties.Resources.addGroups_When_Pending_And_RowCount);
        }

        [TestMethod]
        public void addGroups_When_Approved_And_RowCount()
        {
            CommonTestData(Approved, 1, EPMLiveTimesheets.Tests.Properties.Resources.addGroups_When_Approved_And_RowCount);
        }

        [TestMethod]
        public void addGroups_When_Rejected_And_RowCount()
        {
            CommonTestData(Rejected, 1, EPMLiveTimesheets.Tests.Properties.Resources.addGroups_When_Rejected_And_RowCount);
        }

        [TestMethod]
        public void addGroups_When_Pending()
        {
            CommonTestData(Pending, 0, EPMLiveTimesheets.Tests.Properties.Resources.addGroups_When_Pending_1);
        }

        [TestMethod]
        public void addGroups_When_Approved()
        {
            CommonTestData(Approved, 0, EPMLiveTimesheets.Tests.Properties.Resources.addGroups_When_Approved_1);
        }

        [TestMethod]
        public void addGroups_When_Rejected_2()
        {
            CommonTestData(Rejected, 0, EPMLiveTimesheets.Tests.Properties.Resources.addGroups_When_Rejected_2, "2");
        }

        [TestMethod]
        public void addGroups_When_Pending_And_Submitted()
        {
            CommonTestData(Pending, 0, EPMLiveTimesheets.Tests.Properties.Resources.addGroups_When_Pending_2, string.Empty, "true");
        }

        [TestMethod]
        public void addGroups_When_Approved_2()
        {
            CommonTestData(Approved, 0, EPMLiveTimesheets.Tests.Properties.Resources.addGroups_When_Approved_2, "1");
        }

        [TestMethod]
        public void addGroups_When_Rejected()
        {
            CommonTestData(Rejected, 0, EPMLiveTimesheets.Tests.Properties.Resources.addGroups_When_Rejected_1);
        }

        private void CommonTestData(string approvalStatus1, int rowCount, string expected, string approvalStatus2 = "", string submitted = "")
        {
            // Arrange
            var queueAllItems = new Queue();
            queueAllItems.Enqueue(new ShimSPListItem().Instance);

            var docXml = new XmlDocument();
            docXml.LoadXml("<rows></rows>");

            var ndMainParent = docXml.ChildNodes[0];

            var arrItems = new SortedList();
            arrItems.Add(Id.ToString(), Group);

            var dayDefs = new[] { True, True, True, True };

            _privateObject.SetFieldOrProperty(docXmlProperty, docXml);
            _privateObject.SetFieldOrProperty(ndMainParentProperty, ndMainParent);
            _privateObject.SetFieldOrProperty(queueAllItemsProperty, queueAllItems);
            _privateObject.SetFieldOrProperty(arrItemsProperty, arrItems);

            _privateObject.SetFieldOrProperty(dsTimesheetsProperty, new ShimDataSet().Instance);
            _privateObject.SetFieldOrProperty(dsTimesheetTasksProperty, new ShimDataSet().Instance);
            _privateObject.SetFieldOrProperty(dsTimesheetTaskHoursProperty, new ShimDataSet().Instance);
            _privateObject.SetFieldOrProperty(dsTimesheetNotesProperty, new ShimDataSet().Instance);
            _privateObject.SetFieldOrProperty(dsTimesheetTypesProperty, new ShimDataSet().Instance);

            _privateObject.SetFieldOrProperty(dayDefsProperty, dayDefs);

            ShimDataRow.AllInstances.ItemGetString = (a, key) =>
            {
                switch (key)
                {
                    case Project: return Project;
                    case ApprovalStatus1: return approvalStatus1;
                    case ApprovalStatus2: return approvalStatus2;
                    case Submitted: return submitted;
                    case Hours: return "1";
                    default: return string.Empty;
                };
            };

            ShimDataRowCollection.AllInstances.CountGet = _ => rowCount;

            // Act
            _privateObject.Invoke(AddGroupsMethod, new ShimSPWeb().Instance);

            var actualResNodes = _privateObject.GetFieldOrProperty(hshResNodesProperty) as Hashtable;
            var actualItemNodes = _privateObject.GetFieldOrProperty(hshItemNodesProperty) as Hashtable;
            var actual = docXml.OuterXml;

            // Assert
            Assert.IsNotNull(actualResNodes);
            Assert.AreEqual(1, actualResNodes.Count);

            Assert.IsNotNull(actualItemNodes);
            Assert.AreEqual(2, actualItemNodes.Count);

            actual.ShouldBe(expected);
        }

        private void ArrangeShims()
        {
            ShimSPListItem.AllInstances.IDGet = _ => Id;
            ShimSPListItem.AllInstances.ItemGetString = (a, b) => string.Empty;
            ShimSPListItem.AllInstances.TitleGet = _ => Name;

            Shimgetts.AllInstances.processListSPWebSortedList = (a, b, sortedList) =>
            {
                sortedList.Add(Group, string.Empty);
            };

            ShimDataSet.AllInstances.TablesGet = _ => new ShimDataTableCollection();
            ShimInternalDataCollectionBase.AllInstances.CountGet = _ => 1;

            ShimDataTableCollection.AllInstances.ItemGetInt32 = (a, b) => new ShimDataTable();

            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection();
            ShimDataTable.AllInstances.SelectString = (a, b) => new[] { new ShimDataRow().Instance };

            ShimSPFieldUserValue.AllInstances.UserGet = _ => new ShimSPUser();

            ShimSPUser.AllInstances.NameGet = _ => Name;
            ShimSPUser.AllInstances.LoginNameGet = _ => LoginName;

            ShimDataRowCollection.AllInstances.GetEnumerator = _ =>
            {
                var list = new List<DataRow>
                {
                    new ShimDataRow().Instance
                };

                return list.GetEnumerator();
            };
        }
    }
}