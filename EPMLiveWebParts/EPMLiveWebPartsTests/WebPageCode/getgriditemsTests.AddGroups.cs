using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Fakes;
using System.Web.SessionState.Fakes;
using System.Web.UI.Fakes;
using System.Xml;
using EPMLiveCore;
using EPMLiveCore.Fakes;
using EPMLiveWebParts.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests
{
    public partial class GetGridItemsTests
    {
        private const string WorkspaceUrlView = "WorkspaceUrl";
        private const string DefaultErrorMessage = "DefaultErrorMessage";
        private const string MethodGetParams = "getParams";
        private const string FieldRollupLists = "rolluplists";
        private const string FieldInEditMode = "inEditMode";
        private const string FieldGlobalError = "globalError";
        private const string FieldUsePerformance = "usePerformance";
        private const string FieldFilterField = "filterfield";

        [TestMethod]
        public void AddGroups_NullRollupLists_FillsAfterInit()
        {
            // Arrange
            PrepareForAddGroups(true);

            // Act
            _testObj.addGroups(new ShimSPWeb().Instance, string.Empty, new SortedList());

            // Assert
            _afterInit.ShouldNotBeNull();
            _afterInit.InnerXml.ShouldBe("<call command=\"setuppaging\"><param>Dummy</param></call>");
        }

        [TestMethod]
        public void AddGroups_NotNullRollupListsNoData_ProcessesList()
        {
            // Arrange
            var didProcessList = false;
            PrepareForAddGroups(true);
            _privateObj.SetField(FieldRollupLists, new string[] { DummyListId });
            Shimgetgriditems.AllInstances.processListSPWebStringSPListSortedList =
                (a, b, c, d, e) => didProcessList = true;
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString =
                (a, b, c, d, e) => new DataTable();

            // Act
            _testObj.addGroups(new ShimSPWeb().Instance, string.Empty, new SortedList());

            // Assert
            didProcessList.ShouldBeTrue();
        }

        [TestMethod]
        public void AddGroups_NotNullRollupListsProcessError_WritesGlobalError()
        {
            // Arrange
            PrepareForAddGroups(true);
            _privateObj.SetField(FieldRollupLists, new string[] { DummyListId });
            Shimgetgriditems.AllInstances.processListSPWebStringSPListSortedList =
                (a, b, c, d, e) => { throw new InvalidOperationException(DefaultErrorMessage); };
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString =
                (a, b, c, d, e) => new DataTable();

            // Act
            _testObj.addGroups(new ShimSPWeb().Instance, string.Empty, new SortedList());

            // Assert
            var globalError = _privateObj.GetField(FieldGlobalError);
            globalError.ShouldNotBeNull();
            globalError.ShouldBe($"{DefaultErrorMessage}<br>");
        }

        [TestMethod]
        public void AddGroups_NotUseReportingNullRollupLists_ProcessesList()
        {
            // Arrange
            var didProcessList = false;
            PrepareForAddGroups(false);
            Shimgetgriditems.AllInstances.processListSPWebStringSPListSortedList =
                (a, b, c, d, e) => didProcessList = true;

            // Act
            _testObj.addGroups(new ShimSPWeb().Instance, string.Empty, new SortedList());

            // Assert
            didProcessList.ShouldBeTrue();
        }

        [TestMethod]
        public void AddGroups_InEditMode_ProcessesListAndAddsItems()
        {
            // Arrange
            var didProcessList = false;
            var didAddOtherGroups = false;
            var didCloseWeb = false;
            _privateObj.SetField(FieldRollupLists, new string[] { DummyListId });
            _privateObj.SetField(FieldInEditMode, true);
            PrepareForAddGroups(false);

            Shimgetgriditems.AllInstances.processListSPWebStringSPListSortedList =
                (a, b, c, d, e) => didProcessList = true;

            var webs = new List<SPWeb> { new ShimSPWeb() };
            var websCollection = new ShimSPWebCollection();
            websCollection.Bind(webs.AsEnumerable());

            ShimSPWeb.AllInstances.WebsGet = _ =>
            {
                Shimgetgriditems.AllInstances.addGroupsSPWebStringSortedList =
                    (a, b, c, d) => didAddOtherGroups = true;

                return websCollection.Instance;
            };
            ShimSPWeb.AllInstances.Close = _ => didCloseWeb = true;

            // Act
            _testObj.addGroups(new ShimSPWeb().Instance, string.Empty, new SortedList());

            // Assert
            this.ShouldSatisfyAllConditions(
                () => didAddOtherGroups.ShouldBeTrue(),
                () => didProcessList.ShouldBeTrue(),
                () => didCloseWeb.ShouldBeTrue());
        }

        [TestMethod]
        public void AddGroups_InEditModeAddError_DoesNotWriteGlobalError()
        {
            // Arrange
            _privateObj.SetField(FieldRollupLists, new string[] { DummyListId });
            _privateObj.SetField(FieldInEditMode, true);
            PrepareForAddGroups(false);

            Shimgetgriditems.AllInstances.processListSPWebStringSPListSortedList =
                (a, b, c, d, e) => { throw new InvalidOperationException(DefaultErrorMessage); };

            ShimSPWeb.AllInstances.WebsGet = _ =>
            {
                Shimgetgriditems.AllInstances.addGroupsSPWebStringSortedList =
                    (a, b, c, d) => { throw new InvalidOperationException(DefaultErrorMessage); };

                var webs = new List<SPWeb>();
                var websCollection = new ShimSPWebCollection();
                websCollection.Bind(webs.AsEnumerable());
                return websCollection.Instance;
            };

            // Act
            _testObj.addGroups(new ShimSPWeb().Instance, string.Empty, new SortedList());

            // Assert
            var globalError = _privateObj.GetField(FieldGlobalError);
            globalError.ShouldNotBeNull();
            globalError.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void AddGroups_InEditModeGetWebError_WritesGlobalError()
        {
            // Arrange
            _privateObj.SetField(FieldRollupLists, new string[] { DummyListId });
            _privateObj.SetField(FieldInEditMode, true);
            PrepareForAddGroups(false);

            Shimgetgriditems.AllInstances.processListSPWebStringSPListSortedList =
                (a, b, c, d, e) => { throw new InvalidOperationException(DefaultErrorMessage); };

            ShimSPWeb.AllInstances.WebsGet = _ => { throw new InvalidOperationException(DefaultErrorMessage); };

            // Act
            _testObj.addGroups(new ShimSPWeb().Instance, string.Empty, new SortedList());

            // Assert
            var globalError = _privateObj.GetField(FieldGlobalError);
            globalError.ShouldNotBeNull();
            globalError.ShouldBe(DefaultErrorMessage);
        }

        [TestMethod]
        public void AddGroups_InEditModeGetWebAccessError_WritesGlobalError()
        {
            // Arrange
            _privateObj.SetField(FieldRollupLists, new string[] { DummyListId });
            _privateObj.SetField(FieldInEditMode, true);
            PrepareForAddGroups(false);

            Shimgetgriditems.AllInstances.processListSPWebStringSPListSortedList =
                (a, b, c, d, e) => { throw new InvalidOperationException(DefaultErrorMessage); };

            ShimSPWeb.AllInstances.WebsGet = _ => { throw new InvalidOperationException("Access is denied"); };
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions =
                (_, permission) =>
                {
                    switch (permission)
                    {
                        case SPBasePermissions.ViewPages:
                            return true;
                        default:
                            return false;
                    }
                };

            // Act
            _testObj.addGroups(new ShimSPWeb().Instance, string.Empty, new SortedList());

            // Assert
            var globalError = _privateObj.GetField(FieldGlobalError);
            globalError.ShouldNotBeNull();
            globalError.ShouldBe("Although some data may have been returned, access was denied to some data due to incorrect security configuration. Visit <a href=\"http://kb.epmlive.com/KnowledgebaseArticle50056.aspx\">Our Knowledge Base</a> for more information.");
        }

        [TestMethod]
        public void AddGroups_NotInEditMode_FillsAfterInit()
        {
            // Arrange
            _privateObj.SetField(FieldRollupLists, new string[] { DummyListId });
            _privateObj.SetField(FieldInEditMode, false);
            _privateObj.SetField(FieldUsePerformance, true);
            PrepareForAddGroups(false);

            // Act
            _testObj.addGroups(new ShimSPWeb().Instance, string.Empty, new SortedList());

            // Assert
            _afterInit.ShouldNotBeNull();
            _afterInit.InnerXml.ShouldBeEmpty();
        }

        [TestMethod]
        public void AddGroups_NotInEditModeError_WritesGlobalError()
        {
            // Arrange
            _privateObj.SetField(FieldRollupLists, new string[] { DummyListId });
            _privateObj.SetField(FieldInEditMode, false);
            _privateObj.SetField(FieldUsePerformance, true);
            PrepareForAddGroups(false);
            _privateObj.SetField(FieldFilterField, string.Empty);
            Shimgetgriditems.AllInstances.processListDTSPWebDataRowArraySortedListString =
                (a, b, c, d, e) => { throw new InvalidOperationException(DefaultErrorMessage); };

            // Act
            _testObj.addGroups(new ShimSPWeb().Instance, string.Empty, new SortedList());

            // Assert
            var globalError = _privateObj.GetField(FieldGlobalError);
            globalError.ShouldNotBeNull();
            globalError.ShouldBe($"{DefaultErrorMessage}<br>");
        }

        [TestMethod]
        public void GetParams_Invoke_FillsParams()
        {
            // Arrange
            ShimPage.AllInstances.RequestGet = _ => new HttpRequest(string.Empty, ExampleUrl, string.Empty);
            ConfigureHttpContext();
            ConfigureTestSessions();

            PrepareSpSiteShims();
            PrepareSpWebRelatedShims();
            PrepareSpListRelatedShims();
            PrepareSpFieldRelatedShims(FieldTitle, SPFieldType.Computed);

            var views = new List<string> { WorkspaceUrlView };
            var viewsCollection = new ShimSPViewFieldCollection();
            viewsCollection.Bind(views);
            ShimSPView.AllInstances.ViewFieldsGet = _ => viewsCollection;
            ShimSPViewCollection.AllInstances.ItemGetString = (_, __) => new ShimSPView();
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root DisplayNameSrcField='parentField'></root>";
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = callback => callback?.Invoke();

            // Act
            _privateObj.Invoke(MethodGetParams, new object[] { new ShimSPWeb().Instance });

            // Assert
            var strlist = _privateObj.GetField("strlist");
            var strview = _privateObj.GetField("strview");
            var reportId = _privateObj.GetField("ReportID");
            var usewbs = _privateObj.GetField("usewbs");
            var executive = _privateObj.GetField("executive");
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    strlist.ShouldNotBeNull();
                    strlist.ShouldBe("strlist");
                },
                () =>
                {
                    strview.ShouldNotBeNull();
                    strview.ShouldBe("strview");
                },
                () =>
                {
                    reportId.ShouldNotBeNull();
                    reportId.ShouldBe("ReportID");
                },
                () =>
                {
                    usewbs.ShouldNotBeNull();
                    usewbs.ShouldBe("usewbs");
                },
                () =>
                {
                    executive.ShouldNotBeNull();
                    executive.ShouldBe("executive");
                });
        }

        private void PrepareForAddGroups(bool useReporting)
        {
            _idsCount = 300;
            _privateObj.SetField(FieldFilterField, DummyFieldName);
            _privateObj.SetField("filtervalue", DummyVal);
            _privateObj.SetField("lookupFilterField", DummyFieldName);
            _privateObj.SetField("reportFilterField", DummyFieldName);
            _privateObj.SetField("lookupFilterIDs", GetFilterIdsArray());
            _privateObj.SetField("reportFilterIDs", GetFilterIdsArray());
            _privateObj.SetField("iPageSize", 1);
            _privateObj.SetField("bUseReporting", useReporting);
            _privateObj.SetField("list", new ShimSPList().Instance);
            _privateObj.SetField("tb", new TimeDebug(DummyFieldName, bool.TrueString));

            _xmlDocument = new XmlDocument();
            _xmlDocument.LoadXml("<root><afterInit></afterInit></root>");
            _afterInit = _xmlDocument.SelectSingleNode("//afterInit");
            _privateObj.SetField("docXml", _xmlDocument);
            
            ShimReportingData.GetReportQuerySPWebSPListStringStringOut =
                (SPWeb a, SPList b, string c, out string orderby) =>
                {
                    orderby = DummyFieldName;
                    return DummyVal;
                };

            var set = SetupData();

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(new DataColumn[] { new DataColumn("InnerText") });
            dataTable.LoadDataRow(new object[] { DummyText }, true);
            set.Tables.Add(dataTable);

            PrepareSpListRelatedShims();
            PrepareSpWebRelatedShims();
        }

        private void ConfigureHttpContext()
        {
            var config = GetParamsConfig();
            var message = string.Join("\n", config);
            var data = Convert.ToBase64String(Encoding.ASCII.GetBytes(message));
            ShimHttpRequest.AllInstances.ItemGetString = (_, key) =>
            {
                switch (key)
                {
                    case "Page":
                        return "0";
                    case "FromGroupBy":
                        return "1";
                    case "GB":
                        return string.Empty;
                    case "data":
                        return data;
                    case "edit":
                    case "NP":
                        return bool.TrueString.ToLower();
                    case "Cols":
                        return $"{DummyFieldName},gantt,{FieldTitle}";
                    case "sSearchField":
                        return DummyFieldName;
                    default:
                        return DummyVal;
                }
            };
            ShimHttpContext.CurrentGet = () => new ShimHttpContext();
            ShimHttpContext.AllInstances.SessionGet = _ => new ShimHttpSessionState();
            ShimPage.AllInstances.SessionGet = _ => new ShimHttpSessionState();
            ShimGridGanttSettings.ConstructorSPList = (instance, __) =>
            {
                instance.DisplaySettings = "A|B|C";
            };
            ShimEditableFieldDisplay.IsDisplayFieldSPFieldDictionaryOfStringDictionaryOfStringStringString =
                (a, b, c) => true;
        }

        private void ConfigureTestSessions()
        {
            object viewSession = null;
            string fromGroupBy = null;
            ShimHttpSessionState.AllInstances.ItemGetString = (_, key) =>
            {
                switch (key)
                {
                    case "ViewSession":
                        return viewSession;
                    case "FromGroupBy":
                        return fromGroupBy;
                    default:
                        return null;
                }
            };
            ShimHttpSessionState.AllInstances.ItemSetStringObject = (_, key, obj) =>
            {
                switch (key)
                {
                    case "ViewSession":
                        viewSession = obj;
                        break;
                    case "FromGroupBy":
                        fromGroupBy = obj as string;
                        break;
                    default:
                        break;
                }
            };
        }

        private string[] GetParamsConfig()
        {
            return new string[]
            {
                "List\tstrlist",
                "View\tstrview",
                "ReportID\tReportID",
                "WBS\tusewbs",
                "Executive\texecutive",
                "LType\tlinktype",
                "LookupField\tlookupFilterField",
                "LookupFieldList\tlookupFilterFieldList",
                "RLists\t0|1,2",
                "FilterField\tfilterfield",
                "FilterValue\tfiltervalue",
                "LookupFilterField\tLookupFilterField",
                "LookupFilterValue\tLookupFilterValue",
                "RSites\trollupsites1,rollupsites2",
                "GridName\tgridname",
                "AGroups\tadditionalgroups",
                "Expand\t1",
                "Info\tInfoField",
                "Start\tStartDateField",
                "Finish\tDueDateField",
                "Percent\tProgressField",
                "ShowInsert\ttrue",
                "UsePerf\ttrue",
                "UsePopup\ttrue",
                "Requests\ttrue",
                "ShowCheckboxes\ttrue",
                "UseReporting\ttrue",
                "PageSize\t1",
                "WPID\tWPID",
            };
        }
    }
}
