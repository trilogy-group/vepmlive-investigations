using System;
using System.Collections;
using System.Collections.Fakes;
using System.Collections.Generic;
using System.Collections.Generic.Fakes;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices.ActiveDirectory.Fakes;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Fakes;
using System.Web.SessionState.Fakes;
using System.Web.UI.Fakes;
using System.Xml;
using System.Xml.Fakes;
using EPMLiveCore;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Infrastructure.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveWebParts;
using EPMLiveWebParts.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Workflow.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests
{
    public partial class GetGridItemsTests
    {
        private const string MethodProcessList = "processList";
        private const string MethodAddMenus = "addMenus";
        private const string FieldPage = "iPage";
        private const string FieldPageSize = "iPageSize";
        private int _idsCount;
        private XmlNode _afterInit;

        [TestMethod]
        public void ProcessList_PageZero_FillsAfterInit()
        {
            // Arrange
            const string query = "<OrderBy><FieldRef Name='FieldName' /></OrderBy>";
            _idsCount = 300;
            PrepareForProcessList();
            _privateObj.SetField(FieldPage, 0);

            var arrGTemp = new SortedList();
            var parameters = new object[]
            {
                new ShimSPWeb().Instance,
                query,
                new ShimSPList().Instance,
                arrGTemp
            };

            // Act
            _privateObj.Invoke(MethodProcessList, parameters);

            // Assert
            _afterInit.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _afterInit.InnerXml.ShouldNotBeNullOrEmpty(),
                () => _afterInit.InnerXml.ShouldBe("<call command=\"setuppaging\"><param>0|1|1|false</param></call>"));
        }

        [TestMethod]
        public void ProcessList_Page1_FillsAfterInit()
        {
            // Arrange
            const string query = "<OrderBy><FieldRef Name='FieldName' /></OrderBy>";
            PrepareForProcessList();
            _privateObj.SetField(FieldPage, 1);

            var arrGTemp = new SortedList();
            var parameters = new object[]
            {
                new ShimSPWeb().Instance,
                query,
                new ShimSPList().Instance,
                arrGTemp
            };

            // Act
            _privateObj.Invoke(MethodProcessList, parameters);

            // Assert
            _afterInit.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _afterInit.InnerXml.ShouldNotBeNullOrEmpty(),
                () => _afterInit.InnerXml.ShouldBe("<call command=\"setuppaging\"><param>1|1|1|false</param></call>"));
        }

        [TestMethod]
        public void ProcessList_PageNegative1_FillsAfterInit()
        {
            // Arrange
            const string query = "<OrderBy><FieldRef Name='FieldName' /></OrderBy>";
            PrepareForProcessList();
            _privateObj.SetField(FieldPage, -1);

            var arrGTemp = new SortedList();
            var parameters = new object[]
            {
                new ShimSPWeb().Instance,
                query,
                new ShimSPList().Instance,
                arrGTemp
            };

            // Act
            _privateObj.Invoke(MethodProcessList, parameters);

            // Assert
            _afterInit.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _afterInit.InnerXml.ShouldNotBeNullOrEmpty(),
                () => _afterInit.InnerXml.ShouldBe("<call command=\"setuppaging\"><param>-1|1|1|false</param></call>"));
        }

        [TestMethod]
        public void ProcessList_CannotView_FillsAfterInit()
        {
            // Arrange
            const string query = "<OrderBy><FieldRef Name='FieldName' /></OrderBy>";
            PrepareForProcessList();
            _privateObj.SetField(FieldPage, 0);
            _privateObj.SetField("filtervalue", DummyText);

            var arrGTemp = new SortedList();
            var parameters = new object[]
            {
                new ShimSPWeb().Instance,
                query,
                new ShimSPList().Instance,
                arrGTemp
            };

            // Act
            _privateObj.Invoke(MethodProcessList, parameters);

            // Assert
            _afterInit.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _afterInit.InnerXml.ShouldNotBeNullOrEmpty(),
                () => _afterInit.InnerXml.ShouldBe("<call command=\"setuppaging\"><param>0|1|1|false</param></call>"));
        }

        [TestMethod]
        public void AddMenus_Invoke_FillsNode()
        {
            // Arrange
            var list = new ShimSPList().Instance;
            PrepareForAddMenus(list);
            var node = SetXmlDocument();
            ShimCoreFunctions.getLockedWebSPWeb = _ => Guid.NewGuid();

            // Act
            var result = _privateObj.Invoke(MethodAddMenus, new object[] { node, list, bool.TrueString });

            // Assert
            node.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => node.InnerXml.ShouldNotBeNullOrEmpty(),
                () => node.InnerXml.ShouldBe("<userdata name=\"viewMenus\">1,1,1,1,1,1,1,0,1,0,1,1,0,1</userdata>"));
        }

        [TestMethod]
        public void AddMenus_Invoke_SetsAllNodesButTwo()
        {
            // Arrange
            var list = new ShimSPList().Instance;
            PrepareForAddMenus(list);
            var node = SetXmlDocument();
            ShimCoreFunctions.getLockedWebSPWeb = _ => Guid.NewGuid();
            _privateObj.SetField("requestsenabled", true);

            // Act
            var result = _privateObj.Invoke(MethodAddMenus, new object[] { node, list, bool.TrueString });

            // Assert
            node.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => node.InnerXml.ShouldNotBeNullOrEmpty(),
                () => node.InnerXml.ShouldBe("<userdata name=\"viewMenus\">1,1,1,1,1,1,1,0,1,1,1,1,0,1</userdata>"));
        }

        [TestMethod]
        public void AddMenus_EmptyLockWeb_FillsNode()
        {
            // Arrange
            var list = new ShimSPList().Instance;
            PrepareForAddMenus(list);
            var node = SetXmlDocument();
            ShimCoreFunctions.getLockedWebSPWeb = _ => Guid.Empty;

            // Act
            var result = _privateObj.Invoke(MethodAddMenus, new object[] { node, list, bool.TrueString });

            // Assert
            node.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => node.InnerXml.ShouldNotBeNullOrEmpty(),
                () => node.InnerXml.ShouldBe("<userdata name=\"viewMenus\">1,1,1,1,1,1,1,0,1,0,1,1,0,1</userdata>"));
        }

        private ArrayList GetFilterIdsArray()
        {
            var ids = new ArrayList();
            for (var i = 0; i < _idsCount; i++)
            {
                ids.Add(i.ToString());
            }
            ids.Add(DummyVal);
            return ids;
        }

        private XmlNode SetXmlDocument()
        {
            _xmlDocument = new XmlDocument();
            var node = _xmlDocument.CreateNode(XmlNodeType.Element, DummyFieldName, _xmlDocument.NamespaceURI);
            _xmlDocument.AppendChild(node);
            _privateObj.SetField("docXml", _xmlDocument);
            return node;
        }

        private void PrepareForProcessList()
        {
            PrepareSpListRelatedShims();
            PrepareSpWebRelatedShims();
            PrepareSpFieldRelatedShims(DummyFieldName, SPFieldType.Text);

            ShimGridGanttSettings.ConstructorSPList = (instance, _) =>
            {
                instance.DisplaySettings = "A|B|C";
                var shimSettings = new ShimGridGanttSettings(instance);
            };

            ShimCacheStore.CurrentGet = () => new ShimCacheStore();
            ShimCacheStore.AllInstances.GetStringStringFuncOfObjectBoolean =
                (a, b, c, d, e) => new CachedValue("cacheValue");
            ShimCacheStore.AllInstances.SetStringObjectStringBoolean =
                (a, value, b, c, d) => new CachedValue(value);

            _xmlDocument = new XmlDocument();
            _xmlDocument.LoadXml("<root><afterInit></afterInit></root>");
            _afterInit = _xmlDocument.SelectSingleNode("//afterInit");

            _privateObj.SetField(FieldPageSize, 10);
            _privateObj.SetField("filterfield", DummyFieldName);
            _privateObj.SetField("filtervalue", DummyVal);
            _privateObj.SetField("lookupFilterField", DummyFieldName);
            _privateObj.SetField("reportFilterField", DummyFieldName);
            _privateObj.SetField("lookupFilterIDs", GetFilterIdsArray());
            _privateObj.SetField("reportFilterIDs", GetFilterIdsArray());
            _privateObj.SetField("arrGroupFields", new string[] { DummyFieldName });
            _privateObj.SetField("ReportID", "1");
            _privateObj.SetField("docXml", _xmlDocument);
            _privateObj.SetField("list", new ShimSPList().Instance);
        }

        private void PrepareForAddMenus(SPList list)
        {
            PrepareSPContext();

            var assembly = typeof(SPWorkflowAssociationCollection).Assembly;
            var type = assembly.GetType("Microsoft.SharePoint.Workflow.SPListWorkflowAssociationCollection");

            var listWorkflow = Activator.CreateInstance(type, new object[] { list });

            ShimCoreFunctions.getConfigSettingSPWebString = (_, key) =>
            {
                switch (key)
                {
                    case "EPMLiveWPEnable":
                    case "EPMLiveAgileEnable":
                        return bool.TrueString;
                    default:
                        return DummyVal;
                }
            };
            ShimSPListCollection.AllInstances.ItemGetString = (_, key) =>
            {
                switch (key)
                {
                    case "Project Schedules":
                        return new ShimSPDocumentLibrary().Instance;
                    default:
                        return new ShimSPList();
                }
            };
            ShimSPList.AllInstances.WorkflowAssociationsGet = _ => (SPWorkflowAssociationCollection)listWorkflow;

            _privateObj.SetField("DoesUserHavePermissionsViewListItems", true);
            _privateObj.SetField("DoesUserHavePermissionsEditListItems", true);
            _privateObj.SetField("DoesUserHavePermissionsManagePermissions", true);
            _privateObj.SetField("DoesUserHavePermissionsDeleteListItems", true);
            _privateObj.SetField("DoesUserHavePermissionsViewVersions", true);
            _privateObj.SetField("DoesUserHavePermissionsApproveItems", true);
        }
    }
}
