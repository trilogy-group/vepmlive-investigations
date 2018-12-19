using System;
using System.Collections.Generic;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.Fakes;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint.WebPartPages.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using MyWorkWebpart = EPMLiveWebParts.MyWorkWebPart;

namespace EPMLiveWebParts.Tests.MyWorkWebPart
{
    [TestClass, ExcludeFromCodeCoverage]
    public class MyWorkToolpartTests
    {
        private const int Id = 1;
        private const string One = "1";
        private const string DummyString = "DummyString";
        private const string OtherDummyString = "OtherDummyString";
        private const string ExampleUrl = "http://example.com";
        private const string MethodRenderToolPart = "RenderToolPart";
        private MyWorkToolpart _testObject;
        private PrivateObject _privateObject;
        private IDisposable _shimsContext;
        private HtmlTextWriter _outputWriter;
        private StringWriter _textWriter;
        private StringBuilder _outputBuilder;
        private MyWorkWebpart _myWorkWebPart;
        private bool _connectedToDb;
        private bool _unconnectedFromDb;
        private Guid _item1Id = Guid.NewGuid();
        private Guid _item2Id = Guid.NewGuid();
        private Guid _siteId = Guid.NewGuid();
        private Guid _appId = Guid.NewGuid();
        private string _uniqueId = Guid.NewGuid().ToString();
        private string _uniqueIdMd5;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();

            CreateSPContextShims();
            CreateSqlConnectionShims();

            _testObject = new MyWorkToolpart();
            _privateObject = new PrivateObject(_testObject);
            SetMyWorkWebToolpart();

            ShimControl.AllInstances.UniqueIDGet = _ => _uniqueId;
            _uniqueIdMd5 = _uniqueId.Md5();

            _connectedToDb = false;
            _unconnectedFromDb = false;
            _outputBuilder = new StringBuilder();
            _textWriter = new StringWriter(_outputBuilder);
            _outputWriter = new HtmlTextWriter(_textWriter);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
            _outputWriter?.Dispose();
        }

        [TestMethod]
        public void RenderToolPart_Render_WritesInputs()
        {
            // Arrange, Act
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _outputWriter });

            // Assert
            var result = _outputBuilder.ToString();
            result.ShouldNotBeNullOrEmpty();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContainWithoutWhitespace($"<input id=\"cbUseCentralizedSettings_{_uniqueIdMd5}\" name=\"cbUseCentralizedSettings_{_uniqueIdMd5}\""),
                () => result.ShouldContainWithoutWhitespace($"<input id=\"btnExclude_{_uniqueIdMd5}\" type=\"button\" value=\"&lt;&lt;\" onclick=\"moveListBoxItems_{_uniqueIdMd5}('lstIncludedMyWorkLists_{_uniqueIdMd5}', 'lstExcludedMyWorkLists_{_uniqueIdMd5}')\" /></td>"),
                () => result.ShouldContainWithoutWhitespace($"<input id=\"selectedMyWorkLists_{_uniqueIdMd5}\" name=\"selectedMyWorkLists_{_uniqueIdMd5}\" type=\"hidden\" /></td>"),
                () => result.ShouldContainWithoutWhitespace($"<input id=\"btnRemove_{_uniqueIdMd5}\" type=\"button\" value=\"&lt;&lt;\" onclick=\"moveListBoxItems_{_uniqueIdMd5}('lstSelectedFields_{_uniqueIdMd5}', 'lstAvailableFields_{_uniqueIdMd5}')\" /></td>"),
                () => result.ShouldContainWithoutWhitespace($"<input id=\"selectedFields_{_uniqueIdMd5}\" name=\"selectedFields_{_uniqueIdMd5}\" type=\"hidden\" /></td>"),
                () => result.ShouldContainWithoutWhitespace($"<td colspan=\"3\"><input id=\"cbPerformanceMode_{_uniqueIdMd5}\" name=\"cbPerformanceMode_{_uniqueIdMd5}\" type=\"checkbox\" />On/Off</td>"),
                () => result.ShouldContainWithoutWhitespace($"<input id=\"cbDaysAgo_{_uniqueIdMd5}\" type=\"checkbox\" onclick=\"document.getElementById('tbDaysAgo_{_uniqueIdMd5}').disabled = !this.checked;\" name=\"cbDaysAgo_{_uniqueIdMd5}\">"),
                () => result.ShouldContainWithoutWhitespace($"<input id=\"tbDaysAgo_{_uniqueIdMd5}\" type=\"text\" style=\"width:25px;margin:3px 5px;\" onchange=\"this.value = this.value <= 0 ? '' : this.value;\" name=\"tbDaysAgo_{_uniqueIdMd5}\">days ago."));
        }

        [TestMethod]
        public void RenderToolPart_Render_WritesSelects()
        {
            // Arrange, Act
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _outputWriter });

            // Assert
            var result = _outputBuilder.ToString();
            result.ShouldNotBeNullOrEmpty();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContainWithoutWhitespace($"<select id=\"lstExcludedMyWorkLists_{_uniqueIdMd5}\" multiple=\"multiple\" name=\"lstExcludedMyWorkLists_{_uniqueIdMd5}\" style=\"width: 200px; height: 100px;\" onchange=\"showListDetails_{_uniqueIdMd5}(this)\">"),
                () => result.ShouldContainWithoutWhitespace($"<select id=\"lstIncludedMyWorkLists_{_uniqueIdMd5}\" name=\"lstIncludedMyWorkLists_{_uniqueIdMd5}\" multiple=\"multiple\" style=\"width: 200px; height: 100px;\" onchange=\"showListDetails_{_uniqueIdMd5}(this)\">"),
                () => result.ShouldContainWithoutWhitespace($"<select id=\"lstAvailableFields_{_uniqueIdMd5}\" multiple=\"multiple\" name=\"lstAvailableFields_{_uniqueIdMd5}\" style=\"width: 200px; height: 100px;\" onchange=\"showFieldDetails_{_uniqueIdMd5}(this)\">"),
                () => result.ShouldContainWithoutWhitespace($"<select id=\"lstSelectedFields_{_uniqueIdMd5}\" name=\"lstSelectedFields_{_uniqueIdMd5}\" multiple=\"multiple\" style=\"width: 200px; height: 100px;\" onchange=\"showFieldDetails_{_uniqueIdMd5}(this)\">"));
        }

        [TestMethod]
        public void RenderToolPart_Render_WritesColumnsAndRows()
        {
            // Arrange, Act
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _outputWriter });

            // Assert
            var result = _outputBuilder.ToString();
            result.ShouldNotBeNullOrEmpty();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContainWithoutWhitespace($"<tr id=\"trListsAndFields_{_uniqueIdMd5}\">"),
                () => result.ShouldContainWithoutWhitespace("<td colspan=\"3\"><strong>Lists and Fields</strong></td>"),
                () => result.ShouldContainWithoutWhitespace("<td colspan=\"3\">Select which Lists will be included in the My Work results.  All Lists based off the EPM Live Work List Definition are available for inclusion/exclusion.</td>"),
                () => result.ShouldContainWithoutWhitespace("<td width=\"200\">Excluded MyWork Lists<br />"),
                () => result.ShouldContainWithoutWhitespace($"<td align=\"center\" width=\"50\"><input id=\"btnInclude_{_uniqueIdMd5}\" type=\"button\" value=\"&gt;&gt;\" onclick=\"moveListBoxItems_{_uniqueIdMd5}('lstExcludedMyWorkLists_{_uniqueIdMd5}', 'lstIncludedMyWorkLists_{_uniqueIdMd5}')\" />"),
                () => result.ShouldContainWithoutWhitespace($"<td colspan=\"3\"><div id=\"listName_{_uniqueIdMd5}\">&nbsp;</div>"),
                () => result.ShouldContainWithoutWhitespace("<td colspan=\"3\">Please enter the List names of any additional Lists to be included in the My Work results.</td>"),
                () => result.ShouldContainWithoutWhitespace($"<td align=\"right\" width=\"200\"><textarea id=\"tbLists_{_uniqueIdMd5}\" name=\"tbLists_{_uniqueIdMd5}\" cols=\"20\" style=\"width: 200px;\""),
                () => result.ShouldContainWithoutWhitespace("<td colspan=\"3\">The Fields displayed are all available fields based on the Lists included/excluded above.  Select which fields will be available for users to add/remove from their My Work views.</td>"),
                () => result.ShouldContainWithoutWhitespace($"<td align=\"center\" width=\"50\"><input id=\"btnAdd_{_uniqueIdMd5}\" type=\"button\" value=\"&gt;&gt;\" onclick=\"moveListBoxItems_{_uniqueIdMd5}('lstAvailableFields_{_uniqueIdMd5}', 'lstSelectedFields_{_uniqueIdMd5}')\" />"),
                () => result.ShouldContainWithoutWhitespace($"<td colspan=\"3\"><div id=\"internalFieldName_{_uniqueIdMd5}\">&nbsp;</div>"),
                () => result.ShouldContainWithoutWhitespace($"<td colspan=\"3\"><textarea id=\"tbCrossSiteUrls_{_uniqueIdMd5}\" name=\"tbCrossSiteUrls_{_uniqueIdMd5}\" cols=\"20\" rows=\"5\""));
        }

        [TestMethod]
        public void RenderToolPart_Render_WritesDivsTextsAndLabels()
        {
            // Arrange, Act
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _outputWriter });

            // Assert
            var result = _outputBuilder.ToString();
            result.ShouldNotBeNullOrEmpty();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContainWithoutWhitespace($"type=\"checkbox\" onclick=\"toggleCentralizedSettingsUsage_{_uniqueIdMd5}()\" />"),
                () => result.ShouldContainWithoutWhitespace($"<div id=\"listInWebs_{_uniqueIdMd5}\">&nbsp;</div></td>"),
                () => result.ShouldContainWithoutWhitespace($"<a href=\"javascript:refreshFields_{_uniqueIdMd5}();\">[Refresh fields below]</a></td>"),
                () => result.ShouldContainWithoutWhitespace($"<div id=\"fieldInLists_{_uniqueIdMd5}\">&nbsp;</div></td>"),
                () => result.ShouldContainWithoutWhitespace($"<label for=\"cbDaysAgo_{_uniqueIdMd5}\">Only show work that was due within</label>"));
        }

        private void CreateSqlConnectionShims()
        {
            var didRead = false;
            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ => _connectedToDb = true;
            ShimSqlConnection.AllInstances.Close = _ => _unconnectedFromDb = true;
            ShimSqlCommand.ConstructorStringSqlConnection = (a, b, c) => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                didRead = false;
                return new ShimSqlDataReader
                {
                    Read = () =>
                    {
                        if (didRead)
                        {
                            return false;
                        }

                        didRead = true;
                        return true;
                    },
                    ItemGetInt32 = __ => _item1Id,
                    GetGuidInt32 = __ => _item2Id,
                    GetStringInt32 = __ => DummyString
                };
            };
        }

        private void CreateSPContextShims()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();

            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => ExampleUrl;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection().Bind(new List<SPList>
            {
                new ShimSPList
                {
                    TitleGet = () => DummyString
                }
            });

            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection().Bind(new List<SPField>
            {
                new ShimSPField
                {
                    HiddenGet = () => false,
                    ReorderableGet = () => true,
                    InternalNameGet = () => DummyString
                }.Instance
            });

            var siteGuid = _siteId;
            ShimSPSite.ConstructorGuid = (_, __) => new ShimSPSite();
            ShimSPSite.AllInstances.IDGet = _ => siteGuid;
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPSite.AllInstances.ContentDatabaseGet = _ => new ShimSPContentDatabase();

            var applicationGuid = _appId;
            ShimSPPersistedObject.AllInstances.IdGet = _ => applicationGuid;

            ShimSPDatabase.AllInstances.DatabaseConnectionStringGet = _ => DummyString;

            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = callback => callback?.Invoke();

            ShimUtils.GetConfigWeb = () => new ShimSPWeb();
        }

        private void SetMyWorkWebToolpart()
        {
            _myWorkWebPart = new MyWorkWebpart();
            _myWorkWebPart.SelectedLists = new string[] { DummyString, OtherDummyString };
            _myWorkWebPart.SelectedFields = new string[] { DummyString, OtherDummyString };
            _myWorkWebPart.MyWorkSelectedLists = new string[] { DummyString, OtherDummyString };
            _myWorkWebPart.CrossSiteUrls = new string[] { ExampleUrl };
            _myWorkWebPart.DefaultGlobalView = One;
            _myWorkWebPart.DueDayFilter = $"{bool.TrueString}|0|{bool.FalseString}|2";
            _myWorkWebPart.NewItemIndicator = $"{bool.TrueString}|1";
            var toolPane = new ShimToolPane
            {
                SelectedWebPartGet = () => _myWorkWebPart
            };
            ShimToolPart.AllInstances.ParentToolPaneGet = _ => toolPane;
            ShimMyWork.GetGlobalViewsSPWeb = _ => new List<MyWorkGridView>
            {
                new MyWorkGridView { Id = One }
            };
        }
    }
}
