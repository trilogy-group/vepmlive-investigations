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
    public partial class getgriditemsTests
    {
        private const string MethodProcessList = "processList";
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

        private ArrayList GetFilterIdsArray()
        {
            var ids = new ArrayList();
            for (int i = 0; i < _idsCount; i++)
            {
                ids.Add(i.ToString());
            }
            ids.Add(DummyVal);
            return ids;
        }
    }
}
