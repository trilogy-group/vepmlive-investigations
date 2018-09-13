using System;
using System.Collections.Generic;
using System.Collections.Specialized.Fakes;
using System.Data;
using System.Data.Fakes;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveReportsAdmin.Layouts.EPMLive;
using EPMLiveReportsAdmin.Layouts.EPMLive.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveReporting.Tests
{
    [TestClass]
    public class EventAuditTests
    {
        private const string AddEventHandlerMethod = "AddEventHandler";
        private const string AuditWebsMethod = "AuditWebs";
        private const string ResultsRowCreatedMethod = "grdVwResults_RowCreated";
        private const string InitializeMethod = "Initialize";
        private const string AuditListsMethod = "AuditLists";
        private const string AuditRecsField = "_dtAuditRecs";
        private const string GridViewField = "grdVwResults";
        private const string EPMLiveReportsAdminLstEvents = "EPMLiveReportsAdmin.LstEvents";
        private const string LName = "lname";
        private const string SiteIdField = "_SiteID";
        private const string ListNameField = "_sListName";

        private IDisposable _shimContext;
        private PrivateObject _privateObject;
        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            SharepointShims.ShimSharepointCalls();
            _privateObject = new PrivateObject(typeof(EventAudit));

            ArrangeShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
        }

        [TestMethod]
        public void AddEventHandler()
        {
            // Arange
            var addWasCalled = false;
            var deleteWasCalled = false;
            var updateWasCalled = false;
            var sequenceNumber = int.MinValue;
            var list = new List<bool>();
            ShimSPEventReceiverDefinitionCollection.AllInstances.AddSPEventReceiverTypeStringString= (a, b, c, d) => { addWasCalled = true; };
            ShimSPEventReceiverDefinition.AllInstances.Delete = _ => { deleteWasCalled = true; };
            ShimSPEventReceiverDefinition.AllInstances.Update = _ => { updateWasCalled = true; };
            ShimSPEventReceiverDefinition.AllInstances.SequenceNumberSetInt32 = (a, value) => { sequenceNumber = value; };
            ShimSPWeb.AllInstances.AllowUnsafeUpdatesSetBoolean = (a, value) => { list.Add(value); };

            // Act
            _privateObject.Invoke(AddEventHandlerMethod, new object[] { string.Empty, string.Empty});

            // Assert
            Assert.IsTrue(addWasCalled);
            Assert.IsTrue(deleteWasCalled);
            Assert.IsTrue(updateWasCalled);
            Assert.AreEqual(11000, sequenceNumber);
            Assert.AreEqual(2, list.Count);
            Assert.IsTrue(list[0]);
            Assert.IsFalse(list[1]);
        }

        [TestMethod]
        public void AuditWebs_Should_Call_Audit()
        {
            // Arrange
            var listAddUditList = new List<string>();
            ShimEventAudit.AllInstances.AddAuditRecordStringStringString = (a, message, b, c) => { listAddUditList.Add(message); };
            ShimDataRowCollection.AllInstances.CountGet = _ => 1;

            _privateObject.SetFieldOrProperty(AuditRecsField, new ShimDataTable().Instance);
            _privateObject.SetFieldOrProperty(GridViewField, new ShimSPGridView().Instance);

            // Act
            _privateObject.Invoke(AuditWebsMethod);

            // Assert
            Assert.AreEqual(8, listAddUditList.Count);
            Assert.AreEqual("ItemAdded", listAddUditList[0]);
            Assert.AreEqual("ItemUpdated", listAddUditList[1]);
            Assert.AreEqual("ItemDeleting", listAddUditList[2]);
            Assert.AreEqual("ListDeleting", listAddUditList[3]);
            Assert.AreEqual("FieldAdded", listAddUditList[4]);
            Assert.AreEqual("FieldUpdated", listAddUditList[5]);
            Assert.AreEqual("FieldDeleting", listAddUditList[6]);
            Assert.AreEqual("FieldAdding", listAddUditList[7]);
        }

        [TestMethod]
        public void AuditWebs_Should_Not_Call_Audit()
        {
            // Arrange
            var listAddUditList = new List<string>();            
            ShimEventAudit.AllInstances.AddAuditRecordStringStringString = (a, message, b, c) => { listAddUditList.Add(message); };
            ShimDataRowCollection.AllInstances.CountGet = _ => 0;

            var index1 = 0;
            var eventTypes = new List<SPEventReceiverType>
            {
                SPEventReceiverType.ItemAdded,
                SPEventReceiverType.ItemUpdated,
                SPEventReceiverType.ItemDeleting,

                SPEventReceiverType.ListDeleting,
                SPEventReceiverType.FieldAdded,
                SPEventReceiverType.FieldUpdated,
                SPEventReceiverType.FieldDeleting,
                SPEventReceiverType.FieldAdding
            };
            var index2 = 0;
            var eventClasses = new List<string>()
            {
                EPMLiveCore.Properties.Resources.ReportingClassName.ToUpper(),
                EPMLiveCore.Properties.Resources.ReportingClassName.ToUpper(),
                EPMLiveCore.Properties.Resources.ReportingClassName.ToUpper(),

                EPMLiveReportsAdminLstEvents.ToUpper(),
                EPMLiveReportsAdminLstEvents.ToUpper(),
                EPMLiveReportsAdminLstEvents.ToUpper(),
                EPMLiveReportsAdminLstEvents.ToUpper(),
                EPMLiveReportsAdminLstEvents.ToUpper(),
            };

            ShimSPEventReceiverDefinition.AllInstances.TypeGet = _ => eventTypes[index1++];
            ShimSPEventReceiverDefinition.AllInstances.ClassGet = _ => eventClasses[index2++];

            _privateObject.SetFieldOrProperty(AuditRecsField, new ShimDataTable().Instance);
            _privateObject.SetFieldOrProperty(GridViewField, new ShimSPGridView().Instance);

            // Act
            _privateObject.Invoke(AuditWebsMethod);

            // Assert
            Assert.AreEqual(0, listAddUditList.Count);
        }

        [TestMethod]
        public void AuditWebs_Should_Call_Audit_List_Not_Present()
        {
            // Arrange
            var listAddUditList = new List<string>();
            ShimEventAudit.AllInstances.AddAuditRecordStringStringString = (a, message, b, c) => { listAddUditList.Add(message); };
            ShimDataRowCollection.AllInstances.CountGet = _ => 0;

            ShimSPListCollection.AllInstances.ItemGetString = (a, b) => null;

            _privateObject.SetFieldOrProperty(AuditRecsField, new ShimDataTable().Instance);
            _privateObject.SetFieldOrProperty(GridViewField, new ShimSPGridView().Instance);

            // Act
            _privateObject.Invoke(AuditWebsMethod);

            // Assert
            Assert.AreEqual(1, listAddUditList.Count);
            Assert.AreEqual("List Not Present.", listAddUditList[0]);
        }

        [TestMethod]
        public void ResultsRowCreated_Separator()
        {
            // Arrange
            ShimGridViewRow.AllInstances.RowTypeGet = _ => DataControlRowType.Separator;
            _privateObject.SetFieldOrProperty(AuditRecsField, new ShimDataTable().Instance);
            var actual = string.Empty;
            ShimCheckBox.AllInstances.TextSetString = (a, value) => { actual = value; };

            // Act
            _privateObject.Invoke(ResultsRowCreatedMethod, new object[] { new object(), new ShimGridViewRowEventArgs().Instance});

            // Assert
            Assert.AreEqual("Activate", actual);
        }

        [TestMethod]
        public void ResultsRowCreated_Header()
        {
            // Arrange
            ShimGridViewRow.AllInstances.RowTypeGet = _ => DataControlRowType.Header;
            _privateObject.SetFieldOrProperty(AuditRecsField, new ShimDataTable().Instance);
            var actual = string.Empty;
            ShimCheckBox.AllInstances.TextSetString = (a, value) => { actual = value; };
            
            // Act
            _privateObject.Invoke(ResultsRowCreatedMethod, new object[] { new object(), new ShimGridViewRowEventArgs().Instance });

            // Assert
            Assert.AreEqual("Activate All", actual);
        }

        [TestMethod]
        public void Initialize()
        {
            // Arrange
            _privateObject.SetFieldOrProperty(GridViewField, new ShimSPGridView().Instance);
            var headers = new List<string>();
            ShimDataControlField.AllInstances.HeaderTextSetString = (a, value) => { headers.Add(value); };

            var fields = new List<string>();
            ShimSPBoundField.AllInstances.DataFieldSetString = (a, value) => { fields.Add(value); };

            // Act
            _privateObject.Invoke(InitializeMethod);
            var actual = (DataTable)_privateObject.GetFieldOrProperty(AuditRecsField);

            // Assert
            Assert.IsNotNull(actual);

            Assert.AreEqual(4, headers.Count);
            Assert.AreEqual("Web url", headers[0]);
            Assert.AreEqual("List Name", headers[1]);
            Assert.AreEqual("Message", headers[2]);
            Assert.AreEqual("Activate", headers[3]);

            Assert.AreEqual(4, fields.Count);
            Assert.AreEqual("Web", fields[0]);
            Assert.AreEqual("List Name", fields[1]);
            Assert.AreEqual("Message", fields[2]);
            Assert.AreEqual("Activate", fields[3]);
        }

        [TestMethod]
        public void AuditLists_Call_Methods()
        {
            // Arrange
            var initializeWasCalled = false;
            var auditWebsWasCalled = false;
            ShimNameValueCollection.AllInstances.ItemGetString = (a, key) =>
            {
                switch (key)
                {
                    case "sid": return Guid.Empty.ToString();
                    case LName: return LName;
                    default: throw new ArgumentOutOfRangeException();
                }
            };

            ShimEventAudit.AllInstances.Initialize = _ => initializeWasCalled = true;
            ShimEventAudit.AllInstances.AuditWebs = _ =>  auditWebsWasCalled = true;

            // Act
            _privateObject.Invoke(AuditListsMethod);
            var actualSiteID = (Guid)_privateObject.GetFieldOrProperty(SiteIdField);
            var actualsListName = (string)_privateObject.GetFieldOrProperty(ListNameField);

            // Assert
            Assert.IsTrue(initializeWasCalled);
            Assert.IsTrue(auditWebsWasCalled);

            Assert.AreEqual(Guid.Empty, actualSiteID);
            Assert.AreEqual(LName, actualsListName);
        }

        [TestMethod]
        public void AuditLists_Create_Label()
        {
            // Arrange
            ShimNameValueCollection.AllInstances.ItemGetString = (a, b) => null;
            var actual = string.Empty;
            ShimLabel.AllInstances.TextSetString = (a, value) => actual = value;

            // Act
            _privateObject.Invoke(AuditListsMethod);

            // Assert
            Assert.AreEqual("Audit not run. No siteId and/or list name provided.", actual);
        }

        private void ArrangeShims()
        {
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();

            ShimSPSite.ConstructorGuid = (a, b) => { };
            ShimSPSite.AllInstances.OpenWebString = (a, b) => new ShimSPWeb();
            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.AllWebsGet = _ => new ShimSPWebCollection();

            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();

            ShimSPListCollection.AllInstances.ItemGetString = (a, b) => new ShimSPList();

            ShimEventAudit.AllInstances.GetListEventsSPListStringStringListOfSPEventReceiverType = (a, b, c, e, f) => new List<SPEventReceiverDefinition> { new ShimSPEventReceiverDefinition().Instance};

            ShimSPList.AllInstances.EventReceiversGet = _ => new ShimSPEventReceiverDefinitionCollection();

            ShimSPWeb.AllInstances.UrlGet = _ => string.Empty;

            ShimReportData.ConstructorGuid = (a, b) => { };

            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection();

            ShimDataRowCollection.AllInstances.ItemGetInt32 = (a, b) => new ShimDataRow();

            ShimDataRow.AllInstances.ItemGetString = (a, b) => new ShimDataRow();

            ShimPage.AllInstances.MasterGet = _ => new ShimMasterPage();

            ShimControl.AllInstances.FindControlString = (a, b) => new ShimContentPlaceHolder();
            ShimControl.AllInstances.ControlsGet = _ => new ShimControlCollection();

            ShimSPBaseCollection.AllInstances.GetEnumerator = (instance) =>
            {
                if (instance is SPWebCollection)
                {
                    var list = new List<SPWeb>
                    {
                        new ShimSPWeb().Instance
                    };

                    return list.GetEnumerator();
                }

                if (instance is SPEventReceiverDefinitionCollection)
                {
                    var list = new List<SPEventReceiverDefinition>
                    {
                        new ShimSPEventReceiverDefinition().Instance
                    };

                    return list.GetEnumerator();
                }

                throw new NotSupportedException();
            };

            ShimCheckBox.Constructor = _ => { };

            ShimTableCell.Constructor = _ => { };


            ShimGridViewRowEventArgs.AllInstances.RowGet = _ => new ShimGridViewRow();

            ShimTableRow.AllInstances.CellsGet = _ => new ShimTableCellCollection();

            ShimTableCellCollection.AllInstances.ItemGetInt32 = (a, b) => new ShimTableCell();

            ShimSPBoundField.Constructor = _ => { };

            ShimGridView.AllInstances.ColumnsGet = _ => new ShimDataControlFieldCollection();

            ShimHttpRequest.AllInstances.QueryStringGet = _ => new ShimNameValueCollection();

            ShimLabel.Constructor = _ => { };

            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest();
        }
    }
}