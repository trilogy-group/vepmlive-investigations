using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveWorkPlanner.Fakes;
using EPMLiveWorkPlanner.Layouts.epmlive;
using EPMLiveWorkPlanner.Layouts.epmlive.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWorkPlanner.Tests.Layouts.epmlive
{
    [TestClass, ExcludeFromCodeCoverage]
    public partial class WorkPlannerWizardTests
    {
        private IDisposable _shimContext;
        private WorkPlannerWizard _testEntity;
        private PrivateObject _privateObject;
        private const string PageLoadMethod = "Page_Load";
        private const string GetPlannerTableMethod = "GetPlannerTable";
        private const string BtnCancelClickMethod = "btnCancel_Click";
        private const string BtnUploadClickMethod = "btnUpload_Click";
        private const string GetTemplateTableMethod = "GetTemplateTable";
        private const string ICheckParamsMethod = "iCheckParams";
        private const string SetDefaultMethod = "setDefault";
        private const string PopulateTemplatesMethod = "PopulateTemplates";
        private const string CheckProjectTypeMethod = "CheckProjectType";
        private const string HasChildParentMethod = "hasChildParent";
        private const string RequestId = "11";
        private const string RequestProjectListId = "1793c445-8782-4663-937c-c2fd2592f1ba";
        private const string RequestPlanner = "RequestPlanner";
        private string RequestPType = "Online";
        private const string RequestTaskListId = "e54ad50a-5139-4417-863d-19c88e6023ef";
        private const string PlannerIdMpp = "MPP";

        private const string DummyTempPlanner = "DummyTempPlanner";
        private const string DummyTitle = "DummyTitle";
        private const string DummyString = "DummyString";
        private const string ProjectTypeOnline = "Online";
        private const string ProjectTypeProject = "Project";
        private const string TrueString = "true";
        private const string FalseString = "false";
        private const string DummyRelativeUrl = "DummyRelative";
        private const string DummyDescription = "DummyDescription";
        private const string DummyKey = "DummyKey";
        private const string DummyKey2 = "DummyKey2";
        private const string DummyValue = "DummyValue";
        private const string DummyValue2 = "DummyValue2";
        private const int DummyInt = 1;
        private const int DummyIntTwo = 2;
        private static readonly Guid WebId = Guid.NewGuid();
        private static readonly Guid TaskListGuid = Guid.NewGuid();

        private ShimSPWeb _currentWeb;
        private ShimHttpRequest _pageHttpRequest;
        private string _requestUpload;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            _testEntity = new WorkPlannerWizard();
            _privateObject = new PrivateObject(_testEntity);

            ShimsSetup();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
        }

        public void ShimsSetup()
        {
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();
            _currentWeb = new ShimSPWeb()
            {
                IDGet = () => WebId,
                SiteGet = () => new ShimSPSite()
                {
                    IDGet = () => Guid.NewGuid()
                }
            };

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => _currentWeb
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender);

            _requestUpload = "0";
            _pageHttpRequest = new ShimHttpRequest()
            {
                ItemGetString = input =>
                {
                    switch (input)
                    {
                        case "ID":
                            return RequestId;
                        case "listid":
                            return RequestProjectListId;
                        case "Planner":
                            return RequestPlanner;
                        case "PType":
                            return RequestPType;
                        case "tasklistid":
                            return RequestTaskListId;
                        case "Upload":
                            return _requestUpload;
                        case "setdefault":
                            return TrueString;
                        default:
                            return $"Dummy{input}";
                    }
                }
            };
            ShimPage.AllInstances.RequestGet = sender => _pageHttpRequest;

            _privateObject.SetField("pnlUpload", new Panel() { Visible = false });
            _privateObject.SetField("pnlUploadDone", new Panel() { Visible = false });
            _privateObject.SetField("pnlTemplate", new Panel() { Visible = false });
            _privateObject.SetField("pnlDone", new Panel() { Visible = false });
            _privateObject.SetField("lblUploadError", new Label() { Visible = false });
            _privateObject.SetField("pnlItem", new Panel() { Visible = false });
            _privateObject.SetField("pnlPlanner", new Panel() { Visible = false });
        }

        [TestMethod]
        public void PageLoad_RequestUploadTrue_PnlUploadVisible()
        {
            // Arrange
            _requestUpload = "1";

            // Act
            _privateObject.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            var pnlUpload = (Panel)_privateObject.GetField("pnlUpload");
            var pnlTemplate = (Panel)_privateObject.GetField("pnlTemplate");

            var itemId = _privateObject.GetField("sItemID");
            var projectListId = _privateObject.GetField("sProjectListId");
            var plannerId = _privateObject.GetField("sPlannerID");
            var projectType = _privateObject.GetField("sProjectType");
            var taskListId = _privateObject.GetField("sTaskListId");

            this.ShouldSatisfyAllConditions(
                () => pnlUpload.Visible.ShouldBeTrue(),
                () => pnlTemplate.Visible.ShouldBeFalse(),
                () => itemId.ShouldBe(RequestId),
                () => projectListId.ShouldBe(RequestProjectListId),
                () => plannerId.ShouldBe(RequestPlanner),
                () => projectType.ShouldBe(RequestPType),
                () => taskListId.ShouldBe(RequestTaskListId));
        }

        [TestMethod]
        public void PageLoad_RequestUploadFalseLockWebEmpty_pnlDoneVisible()
        {
            // Arrange
            _requestUpload = "0";
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                OpenWebGuid = guidParam => new ShimSPWeb()
            };
            ShimCoreFunctions.getLockedWebSPWeb = web => Guid.Empty;

            var listProjectList = new ShimSPList()
            {
                TitleGet = () => "Project List Title",
                GetItemByIdInt32 = id => new ShimSPListItem()
                {
                    TitleGet = () => DummyTitle
                }
            };

            var listTaskList = new ShimSPList();

            _currentWeb.ListsGet = () => new ShimSPListCollection()
            {
                ItemGetGuid = guid =>
                {
                    if (guid == new Guid(RequestProjectListId))
                    {
                        return listProjectList;
                    }

                    if (guid == new Guid(RequestTaskListId))
                    {
                        return listTaskList;
                    }

                    return new ShimSPList();
                }
            };

            ShimWorkPlannerAPI.GetPlannersByProjectListStringSPWeb = (projectList, web) => new SortedList()
            {
                { DummyTempPlanner, string.Empty }
            };

            ShimWorkPlannerAPI.GetTaskFileSPWebStringString = (web, id, plannerIdParam) => new ShimSPFile();

            // Act
            _privateObject.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            var pnlUpload = (Panel)_privateObject.GetField("pnlUpload");
            var pnlDone = (Panel)_privateObject.GetField("pnlDone");

            var itemId = _privateObject.GetField("sItemID");
            var projectListId = _privateObject.GetField("sProjectListId");
            var plannerId = _privateObject.GetField("sPlannerID");
            var projectType = _privateObject.GetField("sProjectType");
            var taskListId = _privateObject.GetField("sTaskListId");

            this.ShouldSatisfyAllConditions(
                () => pnlUpload.Visible.ShouldBeFalse(),
                () => pnlDone.Visible.ShouldBeTrue(),
                () => itemId.ShouldBe(RequestId),
                () => projectListId.ShouldBe(RequestProjectListId),
                () => plannerId.ShouldBe(RequestPlanner),
                () => projectType.ShouldBe(RequestPType),
                () => taskListId.ShouldBe(RequestTaskListId));
        }

        [TestMethod]
        public void PageLoad_RequestUploadFalseLockWebDifferentWebId_pnlTemplateVisible()
        {
            // Arrange
            _requestUpload = "0";
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                OpenWebGuid = guidParam => new ShimSPWeb()
            };
            ShimCoreFunctions.getLockedWebSPWeb = web => Guid.NewGuid();

            var listProjectList = new ShimSPList()
            {
                TitleGet = () => "Project List Title",
                GetItemByIdInt32 = id => new ShimSPListItem()
                {
                    TitleGet = () => DummyTitle
                }
            };

            var listTaskList = new ShimSPList();

            _currentWeb.ListsGet = () => new ShimSPListCollection()
            {
                ItemGetGuid = guid =>
                {
                    if (guid == new Guid(RequestProjectListId))
                    {
                        return listProjectList;
                    }

                    if (guid == new Guid(RequestTaskListId))
                    {
                        return listTaskList;
                    }

                    return new ShimSPList();
                }
            };

            ShimWorkPlannerAPI.GetPlannersByProjectListStringSPWeb = (projectList, web) => new SortedList()
            {
                { DummyTempPlanner, string.Empty }
            };

            ShimWorkPlannerAPI.GetTaskFileSPWebStringString = (web, id, plannerIdParam) => new ShimSPFile()
            {
                ExistsGet = () => false
            };
            ShimWorkPlannerWizard.AllInstances.PopulateTemplatesSPWeb = (sender, web) => true;

            // Act
            _privateObject.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            var pnlUpload = (Panel)_privateObject.GetField("pnlUpload");
            var pnlTemplate = (Panel)_privateObject.GetField("pnlTemplate");

            var itemId = _privateObject.GetField("sItemID");
            var projectListId = _privateObject.GetField("sProjectListId");
            var plannerId = _privateObject.GetField("sPlannerID");
            var projectType = _privateObject.GetField("sProjectType");
            var taskListId = _privateObject.GetField("sTaskListId");

            this.ShouldSatisfyAllConditions(
                () => pnlUpload.Visible.ShouldBeFalse(),
                () => pnlTemplate.Visible.ShouldBeTrue(),
                () => itemId.ShouldBe(RequestId),
                () => projectListId.ShouldBe(RequestProjectListId),
                () => plannerId.ShouldBe(RequestPlanner),
                () => projectType.ShouldBe(RequestPType),
                () => taskListId.ShouldBe(RequestTaskListId));
        }

        [TestMethod]
        public void GetPlannerTable_PlannerIdNotMpp_ReturnsPlannerTable()
        {
            // Arrange
            var plannerId = "NotMPP";
            var plannerName = string.Empty;
            var web = new ShimSPWeb();

            ShimCoreFunctions.getConfigSettingSPWebString = (webParam, setting) =>
            {
                if (setting == $"EPMLivePlanner{plannerId}Description")
                {
                    return DummyDescription;
                }
                else if (setting == $"EPMLivePlanner{plannerId}EnableOnline"
                    ||
                    setting == $"EPMLivePlanner{plannerId}EnableProject")
                {
                    return TrueString;
                }

                return string.Empty;
            };

            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = sender => new ShimSPWeb()
            {
                ServerRelativeUrlGet = () => "/"
            };

            var expectedContent = new List<string>
            {
                $"onclick=\"SelectPlanner('{plannerId}|Online')\"",
                $"onclick=\"SelectPlanner('{plannerId}|Project')\"",
                "<span> for Microsoft Project</span>",
                "src=\"/_layouts/epmlive/images/planner_online.png\"",
                "src=\"/_layouts/epmlive/images/planner_project.png\"",
                DummyDescription
            };

            // Act
            var actualResult = (string)_privateObject.Invoke(GetPlannerTableMethod, plannerId, plannerName, web.Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedContent.ForEach(p => actualResult.ShouldContainWithoutWhitespace(p)));
        }

        [TestMethod]
        public void GetPlannerTable_PlannerIdMpp_ReturnsPlannerTable()
        {
            // Arrange
            var plannerId = "MPP";
            var plannerName = string.Empty;
            var web = new ShimSPWeb();

            ShimCoreFunctions.getConfigSettingSPWebString = (webParam, setting) =>
            {
                if (setting == $"EPMLivePlanner{plannerId}Description")
                {
                    return DummyDescription;
                }
                else if (setting == $"EPMLivePlanner{plannerId}EnableOnline"
                    ||
                    setting == $"EPMLivePlanner{plannerId}EnableProject"
                    ||
                    setting == $"EPMLivePlanner{plannerId}EnableKanBan")
                {
                    return TrueString;
                }

                return string.Empty;
            };

            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = sender => new ShimSPWeb()
            {
                ServerRelativeUrlGet = () => DummyRelativeUrl
            };

            var expectedContent = new List<string>
            {
                $"onclick=\"SelectPlanner('{plannerId}|Project')\"",
                $"onclick=\"javascript:window.top.location.href='KanBanPlanner.aspx?ID=11&planner={plannerId}'\"",
                $"src=\"{DummyRelativeUrl}/_layouts/epmlive/images/planner_kanban.png\"",
                $"src=\"{DummyRelativeUrl}/_layouts/epmlive/images/planner_project.png\"",
                DummyDescription
            };

            // Act
            var actualResult = (string)_privateObject.Invoke(GetPlannerTableMethod, plannerId, plannerName, web.Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedContent.ForEach(p => actualResult.ShouldContainWithoutWhitespace(p)));
        }

        [TestMethod]
        public void BtnCancelClick_Should_RedirectUrl()
        {
            // Arrange
            var actualRedirect = string.Empty;
            var actualFlags = SPRedirectFlags.Default;

            _pageHttpRequest.QueryStringGet = () => new NameValueCollection()
            {
                { DummyKey, DummyValue },
                { DummyKey2, DummyValue2 }
            };

            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (url, flags, context) =>
            {
                actualRedirect = url;
                actualFlags = flags;
                return true;
            };

            // Act
            _privateObject.Invoke(BtnCancelClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualRedirect.ShouldBe($"epmlive/workplannerwizard.aspx?{DummyKey}={DummyValue}&{DummyKey2}={DummyValue2}"),
                () => actualFlags.ShouldBe(SPRedirectFlags.RelativeToLayoutsPage));
        }

        [TestMethod]
        public void BtnUploadClick_FileNameInvalid_LblUploadErrorFilled()
        {
            // Arrange
            var fileUpload = new ShimFileUpload()
            {
                FileNameGet = () => "invalidFile"
            };

            _privateObject.SetField("FileUpload", fileUpload.Instance);

            // Act
            _privateObject.Invoke(BtnUploadClickMethod, this, EventArgs.Empty);

            // Assert
            var lblUploadError = (Label)_privateObject.GetField("lblUploadError");

            this.ShouldSatisfyAllConditions(
                () => lblUploadError.Text.ShouldBe("That is not an mpp file<br>"),
                () => lblUploadError.Visible.ShouldBeTrue());
        }

        [TestMethod]
        public void BtnUploadClick_InvalidCharacters_LblUploadErrorFilled()
        {
            // Arrange
            var fileUpload = new ShimFileUpload()
            {
                FileNameGet = () => "file.mpp",
                FileBytesGet = () => new byte[] { }
            };

            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = sender => new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetGuid = guid => new ShimSPList()
                    {
                        GetItemByIdInt32 = idItem => new ShimSPListItem()
                        {
                            TitleGet = () => DummyTitle
                        }
                    }
                },
                GetFolderString = strUrl => new ShimSPFolder()
                {
                    ExistsGet = () => false
                },
                FoldersGet = () =>
                {
                    throw new Exception("contains invalid characters");
                }
            };

            _privateObject.SetField("sPlannerID", RequestPlanner);
            _privateObject.SetField("sProjectListId", RequestProjectListId);
            _privateObject.SetField("sItemID", RequestId);
            _privateObject.SetField("FileUpload", fileUpload.Instance);

            // Act
            _privateObject.Invoke(BtnUploadClickMethod, this, EventArgs.Empty);

            // Assert
            var lblUploadError = (Label)_privateObject.GetField("lblUploadError");

            this.ShouldSatisfyAllConditions(
                () => lblUploadError.Text.ShouldBe(@"You may not use the following characters in the name of your  item: ""# % & * : < > ? /  { | } "". Please rename your item and import the file again."),
                () => lblUploadError.Visible.ShouldBeTrue());
        }

        [TestMethod]
        public void BtnUploadClick_GenericException_LblUploadErrorFilled()
        {
            // Arrange
            var fileUpload = new ShimFileUpload()
            {
                FileNameGet = () => "file.mpp",
                FileBytesGet = () => new byte[] { }
            };

            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = sender => new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetGuid = guid => new ShimSPList()
                    {
                        GetItemByIdInt32 = idItem => new ShimSPListItem()
                        {
                            TitleGet = () => DummyTitle
                        }
                    }
                },
                GetFolderString = strUrl => new ShimSPFolder()
                {
                    ExistsGet = () => false
                },
                FoldersGet = () =>
                {
                    throw new Exception();
                }
            };

            _privateObject.SetField("sPlannerID", RequestPlanner);
            _privateObject.SetField("sProjectListId", RequestProjectListId);
            _privateObject.SetField("sItemID", RequestId);
            _privateObject.SetField("FileUpload", fileUpload.Instance);

            // Act
            _privateObject.Invoke(BtnUploadClickMethod, this, EventArgs.Empty);

            // Assert
            var lblUploadError = (Label)_privateObject.GetField("lblUploadError");

            this.ShouldSatisfyAllConditions(
                () => lblUploadError.Text.ShouldBe("Error: Exception of type 'System.Exception' was thrown."),
                () => lblUploadError.Visible.ShouldBeTrue());
        }

        [TestMethod]
        public void BtnUploadClick_UploadSuccess_PnlUploadDoneVisible()
        {
            // Arrange
            var actualAddFile = false;

            var fileUpload = new ShimFileUpload()
            {
                FileNameGet = () => "file.mpp",
                FileBytesGet = () => new byte[] { }
            };

            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = sender => new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetGuid = guid => new ShimSPList()
                    {
                        GetItemByIdInt32 = idItem => new ShimSPListItem()
                        {
                            TitleGet = () => DummyTitle
                        }
                    }
                },
                GetFolderString = strUrl => new ShimSPFolder()
                {
                    ExistsGet = () => false
                },
                FoldersGet = () => new ShimSPFolderCollection()
                {
                    ItemGetString = folderName => new ShimSPFolder()
                    {
                        SubFoldersGet = () => new ShimSPFolderCollection()
                        {
                            AddString = url => new ShimSPFolder()
                            {
                                FilesGet = () => new ShimSPFileCollection()
                                {
                                    AddStringByteArray = (urlOfFile, file) =>
                                    {
                                        actualAddFile = true;
                                        return new ShimSPFile();
                                    }
                                }
                            }
                        }
                    }
                }
            };

            _privateObject.SetField("sPlannerID", RequestPlanner);
            _privateObject.SetField("sProjectListId", RequestProjectListId);
            _privateObject.SetField("sItemID", RequestId);
            _privateObject.SetField("FileUpload", fileUpload.Instance);

            // Act
            _privateObject.Invoke(BtnUploadClickMethod, this, EventArgs.Empty);

            // Assert
            var pnlUpload = (Panel)_privateObject.GetField("pnlUpload");
            var pnlUploadDone = (Panel)_privateObject.GetField("pnlUploadDone");

            this.ShouldSatisfyAllConditions(
                () => actualAddFile.ShouldBeTrue(),
                () => pnlUpload.Visible.ShouldBeFalse(),
                () => pnlUploadDone.Visible.ShouldBeTrue());
        }

        [TestMethod]
        public void GetTemplateTable_Should_ReturnsTemplateTable()
        {
            // Arrange
            var dataTable = new DataTable("table");
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Title");
            dataTable.Columns.Add("Icon");
            dataTable.Columns.Add("Description");
            var dataRow = dataTable.NewRow();
            dataRow[0] = RequestId;
            dataRow[1] = DummyTitle;
            dataRow[2] = string.Empty;
            dataRow[3] = DummyDescription;

            var expectedContent = new List<string>
            {
                $"<a href=\"javascript:void(0);\" onclick=\"ApplyTemplate('{RequestId}')\" class=\"btn btn-large\" style=\"height:50px !important;\">",
                $"<b>{DummyTitle}</b><br>",
                $"<div style=\"padding-top: 5px\">{DummyDescription}</div>",
            };

            // Act
            var actualResult = (string)_privateObject.Invoke(GetTemplateTableMethod, dataRow);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedContent.ForEach(p => actualResult.ShouldContainWithoutWhitespace(p)));
        }

        [TestMethod]
        public void SetDefault_Should_IncludeDefaultPlannerField()
        {
            // Arrange
            var actualFieldUpdate = false;
            var actualListUpdate = false;
            var actualDefaultPlanner = string.Empty;
            var actualSystemUpdate = false;

            var web = new ShimSPWeb()
            {
                IDGet = () => WebId,

                SiteGet = () => new ShimSPSite()
                {
                    IDGet = () => Guid.Empty
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                OpenWebGuid = guidParam => new ShimSPWeb()
                {
                    ListsGet = () => new ShimSPListCollection()
                    {
                        ItemGetGuid = itemGuid => new ShimSPList()
                        {
                            GetItemByIdInt32 = listItemId => new ShimSPListItem()
                            {
                                ItemSetStringObject = (itemId, valueSet) => actualDefaultPlanner = valueSet.ToString(),
                                SystemUpdate = () => actualSystemUpdate = true
                            },
                            FieldsGet = () => new ShimSPFieldCollection()
                            {
                                ContainsFieldString = fieldName => false,
                                AddStringSPFieldTypeBoolean = (displayName, type, required) => string.Empty,
                                ItemGetString = fieldName => new ShimSPField()
                                {
                                    Update = () => actualFieldUpdate = true
                                }
                            },
                            Update = () => actualListUpdate = true
                        }
                    }
                }
            };

            _privateObject.SetField("sProjectListId", RequestProjectListId);
            _privateObject.SetField("sItemID", RequestId);

            // Act
            _privateObject.Invoke(SetDefaultMethod, web.Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualFieldUpdate.ShouldBeTrue(),
                () => actualListUpdate.ShouldBeTrue(),
                () => actualDefaultPlanner.ShouldBe($"{RequestPlanner}|"),
                () => actualSystemUpdate.ShouldBeTrue());
        }

        [TestMethod]
        public void PopulateTemplates_RowsZero_ReturnsFalse()
        {
            // Arrange
            var actualApplyNewTemplate = false;
            var web = new ShimSPWeb();

            ShimWorkPlannerAPI.GetTemplatesSPWebStringString = (webParam, planner, type) => new DataTable();
            ShimWorkPlannerAPI.ApplyNewTemplateSPWebStringStringStringStringString =
                (webParam, planner, templateId, itemid, type, projectName) => actualApplyNewTemplate = true;

            _privateObject.SetField("sProjectType", "Project");
            _privateObject.SetField("sItemID", RequestId);
            _privateObject.SetField("sProjectName", DummyTitle);

            // Act
            var actualResult = (bool)_privateObject.Invoke(PopulateTemplatesMethod, web.Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeFalse(),
                () => actualApplyNewTemplate.ShouldBeTrue());
        }

        [TestMethod]
        public void PopulateTemplates_RowsOneIdNotMinus101_ReturnsFalse()
        {
            // Arrange
            var actualApplyNewTemplate = false;
            var web = new ShimSPWeb();

            var dataTable = new DataTable("table");
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Title");
            dataTable.Columns.Add("Icon");
            dataTable.Columns.Add("Description");
            var dataRow = dataTable.NewRow();
            dataRow[0] = RequestId;
            dataRow[1] = DummyTitle;
            dataRow[2] = string.Empty;
            dataRow[3] = DummyDescription;
            dataTable.Rows.Add(dataRow);

            ShimWorkPlannerAPI.GetTemplatesSPWebStringString = (webParam, planner, type) => dataTable;
            ShimWorkPlannerAPI.ApplyNewTemplateSPWebStringStringStringStringString =
                (webParam, planner, templateId, itemid, type, projectName) => actualApplyNewTemplate = true;

            _privateObject.SetField("sProjectType", "Project");
            _privateObject.SetField("sItemID", RequestId);
            _privateObject.SetField("sProjectName", DummyTitle);

            // Act
            var actualResult = (bool)_privateObject.Invoke(PopulateTemplatesMethod, web.Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeFalse(),
                () => actualApplyNewTemplate.ShouldBeTrue());
        }

        [TestMethod]
        public void PopulateTemplates_RowsOneIdMinus101_ReturnsTrue()
        {
            // Arrange
            var actualApplyNewTemplate = false;
            var web = new ShimSPWeb();

            var dataTable = new DataTable("table");
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Title");
            dataTable.Columns.Add("Icon");
            dataTable.Columns.Add("Description");
            var dataRow = dataTable.NewRow();
            dataRow[0] = "-101";
            dataRow[1] = DummyTitle;
            dataRow[2] = string.Empty;
            dataRow[3] = DummyDescription;
            dataTable.Rows.Add(dataRow);

            ShimWorkPlannerAPI.GetTemplatesSPWebStringString = (webParam, planner, type) => dataTable;
            ShimWorkPlannerAPI.ApplyNewTemplateSPWebStringStringStringStringString =
                (webParam, planner, templateId, itemid, type, projectName) => actualApplyNewTemplate = true;

            _privateObject.SetField("sProjectType", "Project");
            _privateObject.SetField("sItemID", RequestId);
            _privateObject.SetField("sProjectName", DummyTitle);

            // Act
            var actualResult = (bool)_privateObject.Invoke(PopulateTemplatesMethod, web.Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => actualApplyNewTemplate.ShouldBeFalse());
        }

        [TestMethod]
        public void CheckProjectType_OnlineTrueProjectTrue_ReturnFalse()
        {
            // Arrange
            var web = new ShimSPWeb();

            ShimCoreFunctions.getConfigSettingSPWebString = (webParam, setting) => "true";

            // Act
            var actualResult = (bool)_privateObject.Invoke(CheckProjectTypeMethod, web.Instance);

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void CheckProjectType_OnlineFalseProjectFalse_ReturnTrue()
        {
            // Arrange
            var web = new ShimSPWeb();

            ShimCoreFunctions.getConfigSettingSPWebString = (webParam, setting) => "false";

            // Act
            var actualResult = (bool)_privateObject.Invoke(CheckProjectTypeMethod, web.Instance);

            // Assert
            var projectType = _privateObject.GetField("sProjectType");
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => projectType.ShouldBe(ProjectTypeOnline));
        }

        [TestMethod]
        public void CheckProjectType_OnlineTrueProjectFalse_ReturnTrue()
        {
            // Arrange
            var web = new ShimSPWeb();

            ShimCoreFunctions.getConfigSettingSPWebString = (webParam, setting) =>
            {
                if (setting.Contains("EnableOnline"))
                {
                    return "true";
                }

                return "false";
            };

            // Act
            var actualResult = (bool)_privateObject.Invoke(CheckProjectTypeMethod, web.Instance);

            // Assert
            var projectType = _privateObject.GetField("sProjectType");
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => projectType.ShouldBe(ProjectTypeOnline));
        }

        [TestMethod]
        public void CheckProjectType_OnlineFalseProjectTrue_ReturnTrue()
        {
            // Arrange
            var web = new ShimSPWeb();

            ShimCoreFunctions.getConfigSettingSPWebString = (webParam, setting) =>
            {
                if (setting.Contains("EnableOnline"))
                {
                    return "false";
                }

                return "true";
            };

            // Act
            var actualResult = (bool)_privateObject.Invoke(CheckProjectTypeMethod, web.Instance);

            // Assert
            var projectType = _privateObject.GetField("sProjectType");
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => projectType.ShouldBe(ProjectTypeProject));
        }

        [TestMethod]
        public void HasChildParent_HasChild_ReturnsOne()
        {
            var listItemHasChildParent = new ShimSPListItem()
            {
                ItemGetString = itemString =>
                {
                    if (itemString == "ChildItem")
                    {
                        return DummyString;
                    }

                    return string.Empty;
                }
            };

            var web = InitHasChildParent(listItemHasChildParent);

            var listid = Guid.Empty.ToString();
            var itemId = "10";

            // Act
            var actualResult = (int)_privateObject.Invoke(HasChildParentMethod, web.Instance, listid, itemId);

            // Assert
            actualResult.ShouldBe(1);
        }

        [TestMethod]
        public void HasChildParent_HasOnlyParent_ReturnsTwo()
        {
            var listItemHasChildParent = new ShimSPListItem()
            {
                ItemGetString = itemString =>
                {
                    if (itemString == "ParentItem")
                    {
                        return DummyString;
                    }

                    return string.Empty;
                }
            };

            var web = InitHasChildParent(listItemHasChildParent);

            var listid = Guid.Empty.ToString();
            var itemId = "10";

            // Act
            var actualResult = (int)_privateObject.Invoke(HasChildParentMethod, web.Instance, listid, itemId);

            // Assert
            actualResult.ShouldBe(2);
        }

        [TestMethod]
        public void HasChildParent_HasNothing_ReturnsZero()
        {
            var listItemHasChildParent = new ShimSPListItem()
            {
                ItemGetString = itemString => string.Empty
            };

            var web = InitHasChildParent(listItemHasChildParent);

            var listid = Guid.Empty.ToString();
            var itemId = "10";

            // Act
            var actualResult = (int)_privateObject.Invoke(HasChildParentMethod, web.Instance, listid, itemId);

            // Assert
            actualResult.ShouldBe(0);
        }

        private static ShimSPWeb InitHasChildParent(ShimSPListItem listItemHasChildParent)
        {
            return new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetGuid = guid => new ShimSPList()
                    {
                        GetItemByIdInt32 = id => listItemHasChildParent
                    }
                }
            };
        }
    }
}
