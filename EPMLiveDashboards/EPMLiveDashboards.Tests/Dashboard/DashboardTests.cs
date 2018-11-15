using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Linq;
using System.Text;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using System.Web.UI.WebControls.WebParts.Fakes;
using System.Xml;
using System.Xml.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveDashboards.Tests
{
    using Dashboard;
    using Dashboard.Fakes;
    using EPMLiveCore.Fakes;

    [TestClass]
    public class DashboardTests
    {
        private const string GetTaskCountMethodName = "getTaskCount";
        private const string StartDate = "StartDate";
        private const string DueDate = "DueDate";
        private const string Finish = "Finish";
        private const string PercentComplete = "PercentComplete";
        private const string Milestone = "Milestone";
        private const string RenderWebPartMethodName = "RenderWebPart";
        private const string BuildSummaryTableMethodName = "buildSummaryTable";
        private const string DdlProjectSelectedIndexChangedMethodName = "ddlProject_SelectedIndexChanged";
        private const string DdlSelectedIndexChanged = "ddl_SelectedIndexChanged";
        private const string GetRiskStatusMethodName = "getRiskStatus";
        private const string GetIssueStatusMethodName = "getIssueStatus";
        private const string ProcessProjectSummaryItemMethodName = "processProjectSummaryItem";
        private const string CreateChildControlsMethodName = "CreateChildControls";
        private IDisposable shimsContext;
        private Dashboard dashboard;
        private PrivateObject privateObject;
        private string buildProjectGridMethodName = "buildProjectGrid";
        private readonly DropDownList ddlProject = new DropDownList(); 
        private readonly DropDownList ddl = new DropDownList();
        
        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            dashboard = new Dashboard();
            privateObject = new PrivateObject(dashboard);

            privateObject.SetFieldOrProperty("ddlProject", ddlProject);
            privateObject.SetFieldOrProperty("ddl", ddl);
        }

        [TestCleanup]
        public void Cleanupo()
        {
            shimsContext?.Dispose();
            ddlProject?.Dispose();
            ddl?.Dispose();
        }

        [TestMethod]
        public void MyRiskState_GetSet_Test()
        {
            // Arrange
            const string ExpectedValue = "Content";

            // Act
            dashboard.MyRiskState = ExpectedValue;
            var result = dashboard.MyRiskState;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void MyIssueState_GetSet_Test()
        {
            // Arrange
            const string ExpectedValue = "Content";

            // Act
            dashboard.MyIssueState = ExpectedValue;
            var result = dashboard.MyIssueState;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void MyState_GetSet_Test()
        {
            // Arrange
            const string ExpectedValue = "Content";

            // Act
            dashboard.MyState = ExpectedValue;
            var result = dashboard.MyState;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void BuildProjectGrid_Should_ExecutesCorrectly()
        {
            // Arrange
            var siteField = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = name => new ShimSPList
                    {
                        ItemsGet = () => new ShimSPListItemCollection
                        {
                            GetEnumerator = () => new List<SPListItem>
                            {
                                new ShimSPListItem
                                {
                                    TitleGet = () => "Dummy",
                                    UniqueIdGet = () => Guid.NewGuid(),
                                    ItemGetGuid = guid => "Dummy"
                                }
                            }.GetEnumerator()
                        },
                        FieldsGet = () => new ShimSPFieldCollection
                        {
                            GetFieldByInternalNameString = internalName => new ShimSPField
                            {
                                IdGet = () => Guid.Empty,
                                SchemaXmlGet = () => "Dummy"
                            }
                        }
                    }
                }
            }.Instance;
            privateObject.SetFieldOrProperty("site", siteField);
            ShimDashboard.AllInstances.processProjectSummaryItemSPListItem = (_, listItem) => { };
            ShimListControl.AllInstances.SelectedItemGet = _ => new ListItem("Dummy", string.Empty);
            ShimXmlDocument.AllInstances.LoadXmlString = (_, content) => { };
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, node) => new ShimXmlNode(new XmlDocument())
            {
                InnerTextGet = () => "Dummy",
                ChildNodesGet = () =>
                {
                    var doc = new XmlDocument();
                    var element = doc.CreateElement("DummyElement");
                    doc.AppendChild(element);
                    return doc.ChildNodes;
                }
            };

            // Act
            privateObject.Invoke(buildProjectGridMethodName);
            var gridView = privateObject.GetFieldOrProperty("gvPJSummary") as SPGridView;
            var arrRisks = privateObject.GetFieldOrProperty("arrRisks") as SortedList;
            

            // Assert
            dashboard.ShouldSatisfyAllConditions(
                () => gridView.ShouldNotBeNull(),
                () => gridView.AutoGenerateColumns.ShouldBeFalse(),
                () => gridView.Columns.Count.ShouldBeGreaterThan(0),
                () => gridView.DataSource.ShouldNotBeNull(),
                () => ddlProject.Items.Count.ShouldBeGreaterThan(0),
                () => arrRisks.ShouldNotBeNull(),
                () => arrRisks.Count.ShouldBeGreaterThan(0));
        }

        [TestMethod]
        public void BuildProjectGrid_DdlProjectSelectedItemNotEmpty_ExecutesCorrectly()
        {
            // Arrange
            var siteField = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = name => new ShimSPList
                    {
                        ItemsGet = () => new ShimSPListItemCollection
                        {
                            GetEnumerator = () => new List<SPListItem>
                            {
                                new ShimSPListItem
                                {
                                    TitleGet = () => "Dummy",
                                    UniqueIdGet = () => Guid.NewGuid(),
                                    ItemGetGuid = guid => "Dummy"
                                }
                            }.GetEnumerator()
                        },
                        FieldsGet = () => new ShimSPFieldCollection
                        {
                            GetFieldByInternalNameString = internalName => new ShimSPField
                            {
                                IdGet = () => Guid.Empty,
                                SchemaXmlGet = () => "Dummy"
                            }
                        }
                    }
                }
            }.Instance;
            privateObject.SetFieldOrProperty("site", siteField);
            ShimDashboard.AllInstances.processProjectSummaryItemSPListItem = (_, listItem) => { };
            ShimListControl.AllInstances.SelectedItemGet = _ => new ListItem("Dummy", Guid.NewGuid().ToString());
            ShimXmlDocument.AllInstances.LoadXmlString = (_, content) => { };
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, node) => 
            {
                throw new Exception();
            };

            // Act
            privateObject.Invoke(buildProjectGridMethodName);
            var gridView = privateObject.GetFieldOrProperty("gvPJSummary") as SPGridView;
            var arrRisks = privateObject.GetFieldOrProperty("arrRisks") as SortedList;

            // Assert
            dashboard.ShouldSatisfyAllConditions(
                () => gridView.ShouldNotBeNull(),
                () => gridView.AutoGenerateColumns.ShouldBeFalse(),
                () => gridView.Columns.Count.ShouldBeGreaterThan(0),
                () => gridView.DataSource.ShouldNotBeNull(),
                () => ddlProject.Items.Count.ShouldBe(0),
                () => arrRisks.ShouldNotBeNull(),
                () => arrRisks.Count.ShouldBe(0));
        }

        [TestMethod]
        public void BuildProjectGrid_TaskCenterListNotFound_ReturnsExpectedMessage()
        {
            // Arrange
            const string ExpectedList = "Task Center";
            const string ExpectedMessage = "In order to take advantage of the new EPM Live functionality, " + 
                "please follow the instructions located <a href=\"http://www.projectpublisher.com/downloads/ProjectPublisherUpdateProcess.pdf\" " + 
                "target=\"_blank\">here</a>.";
            var siteField = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = name =>
                    {
                        if (name == ExpectedList)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            return new ShimSPList();
                        }
                    }
                }
            }.Instance;
            privateObject.SetFieldOrProperty("site", siteField);

            // Act
            var result = privateObject.Invoke(buildProjectGridMethodName) as string;

            // Assert
            dashboard.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(ExpectedMessage));
        }

        [TestMethod]
        public void BuildProjectGrid_NoTaskListFound_ReturnsExpectedMessage()
        {
            // Arrange
            const string ExpectedList = "Project Center";
            const string ExpectedMessage = "No Tasks List Found";
            var siteField = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = name =>
                    {
                        if (name == ExpectedList)
                        {
                            return new ShimSPList();
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                }
            }.Instance;
            privateObject.SetFieldOrProperty("site", siteField);

            // Act
            var result = privateObject.Invoke(buildProjectGridMethodName) as string;

            // Assert
            dashboard.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(ExpectedMessage));
        }

        [TestMethod]
        public void GetTaskCount_ListItemEmpty_ReturnsExpectedValue()
        {
            // Arrange
            const string ProjectName = "Project";
            var taskList = new ShimSPList
            {
                GetItemsSPQuery = query => new ShimSPListItemCollection
                {
                    GetEnumerator = () => new List<SPListItem>().GetEnumerator()
                }
            }.Instance;

            // Act
            var result = (int)privateObject.Invoke(GetTaskCountMethodName, ProjectName);

            // Assert
            result.ShouldBe(0);
        }

        [TestMethod]
        public void GetTaskCount_OnSuccess_ReturnsExpectedValue()
        {
            // Arrange
            const string ProjectName = "Project";
            var taskList = new ShimSPList
            {
                GetItemsSPQuery = query => new ShimSPListItemCollection
                {
                    GetEnumerator = () => GetSPListItems().GetEnumerator()
                }
            }.Instance;
            privateObject.SetFieldOrProperty("taskList", taskList);

            // Act
            var result = (int)privateObject.Invoke(GetTaskCountMethodName, ProjectName);
            var msComplete = ((int?)privateObject.GetFieldOrProperty("ms_complete")).GetValueOrDefault(0);
            var taskComplete = ((int?)privateObject.GetFieldOrProperty("task_complete")).GetValueOrDefault(0);
            var msFuture = ((int?)privateObject.GetFieldOrProperty("ms_future")).GetValueOrDefault(0);
            var taskFuture = ((int?)privateObject.GetFieldOrProperty("task_future")).GetValueOrDefault(0);
            var msLate = ((int?)privateObject.GetFieldOrProperty("ms_late")).GetValueOrDefault(0);
            var taskLate = ((int?)privateObject.GetFieldOrProperty("task_late")).GetValueOrDefault(0);
            var msCurrent = ((int?)privateObject.GetFieldOrProperty("task_future")).GetValueOrDefault(0);
            var taskCurrent = ((int?)privateObject.GetFieldOrProperty("task_future")).GetValueOrDefault(0);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(2),
                () => msComplete.ShouldBe(1),
                () => taskComplete.ShouldBe(1),
                () => msFuture.ShouldBe(1),
                () => taskFuture.ShouldBe(1),
                () => msLate.ShouldBe(1),
                () => taskLate.ShouldBe(1),
                () => msCurrent.ShouldBe(1),
                () => taskCurrent.ShouldBe(1));
        }

        [TestMethod]
        public void GetTaskCount_OnException_ReturnsExpectedValue()
        {
            // Arrange
            const string ProjectName = "Project";
            var taskList = new ShimSPList
            {
                GetItemsSPQuery = query => 
                {
                    throw new Exception();
                }
            }.Instance;
            privateObject.SetFieldOrProperty("taskList", taskList);

            // Act
            var result = (int)privateObject.Invoke(GetTaskCountMethodName, ProjectName);

            // Assert
            result.ShouldBe(0);
        }

        [TestMethod]
        public void RenderWebPart_ProjectGridError_WritesErrorContent()
        {
            // Arrange
            const string Error = "Dummy Error";
            const string ExpectedMessage = "Error: " + Error;
            var stringBuilder = new StringBuilder();
            var writer = new ShimHtmlTextWriter
            {
                WriteString = content => stringBuilder.Append(content)
            }.Instance;
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            ShimDashboard.AllInstances.buildProjectGrid = _ => Error;

            // Act
            privateObject.Invoke(RenderWebPartMethodName, writer);
            var result = stringBuilder.ToString();

            // Assert
            stringBuilder.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExpectedMessage));
        }

        [TestMethod]
        public void RenderWebPart_Should_WriteExpectedContent()
        {
            // Arrange
            const int TasksTotal = 10;
            const int Current = 2;
            const int Late = 4;
            const int Future = 3;
            const int Complete = 1;
            var expectedContents = new List<string>
            {
                "<TABLE cellSpacing=0 cellPadding=2 width=\"100%\" border=0>",
                "<td title=\"Legend\" id=\"WebPartTitleWPQ2\" style=\"width:100 %; \">",
                "<td title=\"Project Summary\" id=\"WebPartTitleWPQ2\" style=\"width:100%;\">",
                "<td title=\"Risk Summary\" id=\"WebPartTitleWPQ2\" style=\"width:100%;\">",
                "<td title=\"Issue Summary\" id=\"WebPartTitleWPQ2\" style=\"width:100%;\">",
                "<td title=\"Milestone Summary\" id=\"WebPartTitleWPQ2\" style=\"width:100%;\">",
                "<nobr><span>Legend</span><span id=\"WebPartCaptionWPQ2\"></span></nobr>",
                $"In Progress: {Current} ( {Current * 100 / TasksTotal}% )",
                $"Late: {Late} ( {Late * 100 / TasksTotal}% )",
                $"Not Started: {Future} ( {Future * 100 / TasksTotal}% )",
                $"Completed: {Complete} ( {Complete * 100 / TasksTotal}% )",
            };
            var stringBuilder = new StringBuilder();
            var writer = new ShimHtmlTextWriter
            {
                WriteString = content => stringBuilder.Append(content)
            }.Instance;
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            ShimDashboard.AllInstances.buildProjectGrid = _ => string.Empty;
            privateObject.SetFieldOrProperty("gvPJSummary", new SPGridView());
            privateObject.SetFieldOrProperty("ms_current", Current);
            privateObject.SetFieldOrProperty("ms_late", Late);
            privateObject.SetFieldOrProperty("ms_future", Future);
            privateObject.SetFieldOrProperty("ms_complete", Complete);

            // Act
            privateObject.Invoke(RenderWebPartMethodName, writer);
            var result = stringBuilder.ToString();

            // Assert
            stringBuilder.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => expectedContents.ForEach(c => result.ShouldContainWithoutWhitespace(c)));
        }

        [TestMethod]
        public void RenderWebPart_OnException_WritesErrorContent()
        {
            // Arrange
            const string Error = "Dummy Error";
            const string ExpectedMessage = "RWP: " + Error;
            var stringBuilder = new StringBuilder();
            var writer = new ShimHtmlTextWriter
            {
                WriteString = content => stringBuilder.Append(content)
            }.Instance;
            ShimControl.AllInstances.EnsureChildControls = _ => 
            {
                throw new Exception(Error);
            };

            // Act
            privateObject.Invoke(RenderWebPartMethodName, writer);
            var result = stringBuilder.ToString();

            // Assert
            stringBuilder.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExpectedMessage));
        }

        [TestMethod]
        public void RenderWebPart_Activation1_WritesExpectedContent()
        {
            // Arrange
            const string ExpectedMessage = "WebPart feature not activated.";
            var stringBuilder = new StringBuilder();
            var writer = new ShimHtmlTextWriter
            {
                WriteString = content => stringBuilder.Append(content)
            }.Instance;
            privateObject.SetFieldOrProperty("activation", 1);

            // Act
            privateObject.Invoke(RenderWebPartMethodName, writer);
            var result = stringBuilder.ToString();

            // Assert
            stringBuilder.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedMessage));
        }

        [TestMethod]
        public void RenderWebPart_Activation2_WritesExpectedContent()
        {
            // Arrange
            const string ExpectedMessage = "Too many users activated for this feature.";
            var stringBuilder = new StringBuilder();
            var writer = new ShimHtmlTextWriter
            {
                WriteString = content => stringBuilder.Append(content)
            }.Instance;
            privateObject.SetFieldOrProperty("activation", 2);

            // Act
            privateObject.Invoke(RenderWebPartMethodName, writer);
            var result = stringBuilder.ToString();

            // Assert
            stringBuilder.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedMessage));
        }

        [TestMethod]
        public void RenderWebPart_ActivationNegative1_WritesExpectedContent()
        {
            // Arrange
            const string ExpectedMessage = "Unable to retrieve activation status.";
            var stringBuilder = new StringBuilder();
            var writer = new ShimHtmlTextWriter
            {
                WriteString = content => stringBuilder.Append(content)
            }.Instance;
            privateObject.SetFieldOrProperty("activation", -1);

            // Act
            privateObject.Invoke(RenderWebPartMethodName, writer);
            var result = stringBuilder.ToString();

            // Assert
            stringBuilder.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedMessage));
        }

        [TestMethod]
        public void BuildSummaryTable_Should_ReturnExpectedcontent()
        {
            // Arrange
            var list = new SortedList();
            list.Add("Dummy", 1);
            var expectedContents = new List<string>
            {
                "<table border=\"0\" width=\"100%\" cellpadding=\"2\" cellspacing=\"0\">",
                "<td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Dummy: 1 ( 100% )</td>",
            };

            // Act
            var result = privateObject.Invoke(BuildSummaryTableMethodName, list, 0) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => expectedContents.ForEach(c => result.ShouldContainWithoutWhitespace(c)));
        }

        [TestMethod]
        public void DdlProject_SelectedIndexChanged_ExecutesCorrectly()
        {
            // Arrange, Act
            privateObject.Invoke(DdlProjectSelectedIndexChangedMethodName, new object(), EventArgs.Empty);
            var changed = privateObject.GetFieldOrProperty("dpChanged") as bool?;

            // Assert
            changed.GetValueOrDefault().ShouldBeTrue();
        }

        [TestMethod]
        public void Ddl_SelectedIndexChanged_ExecutesCorrectly()
        {
            // Arrange
            const string State = "DummyValue";
            ShimListControl.AllInstances.SelectedItemGet = _ => new ListItem(State);
            var site = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = name => new ShimSPList
                    {
                        FieldsGet = () => new ShimSPFieldCollection
                        {
                            GetFieldByInternalNameString = internalName => new ShimSPField
                            {
                                IdGet = () => Guid.NewGuid()
                            }
                        },
                        ItemsGet = () => new ShimSPListItemCollection
                        {
                            GetEnumerator = () => new List<SPListItem>
                            {
                                new ShimSPListItem
                                {
                                    TitleGet = () => State,
                                    ItemGetString = n => State,
                                    UniqueIdGet = () => Guid.NewGuid()
                                },
                                new ShimSPListItem
                                {
                                    TitleGet = () => State,
                                    ItemGetString = n => null,
                                    UniqueIdGet = () => Guid.NewGuid()
                                }
                            }.GetEnumerator()
                        }
                    }
                }
            }.Instance;
            privateObject.SetFieldOrProperty("site", site);

            // Act
            privateObject.Invoke(DdlSelectedIndexChanged, new object(), EventArgs.Empty);
            var changed = privateObject.GetFieldOrProperty("dChanged") as bool?;

            // Assert
            dashboard.ShouldSatisfyAllConditions(
                () => changed.GetValueOrDefault().ShouldBeTrue(),
                () => ddlProject.Items.Count.ShouldBeGreaterThan(0),
                () => ddlProject.Items.FindByText(State).ShouldNotBeNull());
        }

        [TestMethod]
        public void GetRiskStatus_OnSuccess_ReturnsExpectedContent()
        {
            // Arrange
            const string DummyValue = "DummyValue";
            dashboard.MyRiskState = Milestone;
            const string ProjectName = "Project";
            var riskList = new ShimSPList
            {
                GetItemsSPQuery = query => new ShimSPListItemCollection
                {
                    GetEnumerator = () => new List<SPListItem>
                    {
                        new ShimSPListItem
                        {
                            ItemGetString = GetValue(new Hashtable())
                        },
                        new ShimSPListItem
                        {
                            ItemGetString = GetValue(new Hashtable
                            {
                                [Milestone] = DummyValue,
                                [DueDate] = DateTime.Now
                            })
                        }
                    }.GetEnumerator()
                }
            }.Instance;
            var risks = new SortedList
            {
                [DummyValue] = 1
            };
            privateObject.SetFieldOrProperty("riskList", riskList);
            privateObject.SetFieldOrProperty("arrRisks", risks);

            // Act
            var result = privateObject.Invoke(GetRiskStatusMethodName, ProjectName) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe("green"),
                () => risks[DummyValue].ShouldNotBeNull(),
                () => risks[DummyValue].ShouldBe(2));
        }

        [TestMethod]
        public void GetRiskStatus_OnException_ReturnsEmpty()
        {
            // Arrange
            const string ProjectName = "Project";
            var riskList = new ShimSPList
            {
                GetItemsSPQuery = query => 
                {
                    throw new Exception();
                }
            }.Instance;
            privateObject.SetFieldOrProperty("riskList", riskList);

            // Act
            var result = privateObject.Invoke(GetRiskStatusMethodName, ProjectName) as string;

            // Assert
            result.ShouldBeEmpty();
        }

        [TestMethod]
        public void GetIssueStatus_OnSuccess_ReturnsExpectedContent()
        {
            // Arrange
            const string DummyValue = "DummyValue";
            dashboard.MyIssueState = Milestone;
            const string ProjectName = "Project";
            var issueList = new ShimSPList
            {
                GetItemsSPQuery = query => new ShimSPListItemCollection
                {
                    GetEnumerator = () => new List<SPListItem>
                    {
                        new ShimSPListItem
                        {
                            ItemGetString = GetValue(new Hashtable())
                        },
                        new ShimSPListItem
                        {
                            ItemGetString = GetValue(new Hashtable
                            {
                                [Milestone] = DummyValue,
                                [DueDate] = DateTime.Now
                            })
                        }
                    }.GetEnumerator()
                }
            }.Instance;
            var issues = new SortedList
            {
                [DummyValue] = 1
            };
            privateObject.SetFieldOrProperty("issueList", issueList);
            privateObject.SetFieldOrProperty("arrIssues", issues);

            // Act
            var result = privateObject.Invoke(GetIssueStatusMethodName, ProjectName) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe("green"),
                () => issues[DummyValue].ShouldNotBeNull(),
                () => issues[DummyValue].ShouldBe(2));
        }

        [TestMethod]
        public void GetIssueStatus_OnException_ReturnsEmpty()
        {
            // Arrange
            const string ProjectName = "Project";
            var issueList = new ShimSPList
            {
                GetItemsSPQuery = query =>
                {
                    throw new Exception();
                }
            }.Instance;
            privateObject.SetFieldOrProperty("issueList", issueList);

            // Act
            var result = privateObject.Invoke(GetIssueStatusMethodName, ProjectName) as string;

            // Assert
            result.ShouldBeEmpty();
        }

        [TestMethod]
        public void ProcessProjectSummaryItem_WithEmptyParams_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedRiskStatus = "<img src=\"/_layouts/images/green.gif\">";
            const string ExpectedIssueStatus = "<img src=\"/_layouts/images/green.gif\">";
            const string ExpectedScheduleStatus = "<img src=\"/_layouts/images/green.gif\">";
            var title = string.Empty;
            var startDate= string.Empty;
            var finishDate= string.Empty;
            var porcentCompleted = string.Empty;
            var scheduleStatus = string.Empty;

            var rowValues = new object[] { };
            var listItem = new ShimSPListItem
            {
                TitleGet = () =>" Title",
                IDGet = () => 1,
                ItemGetString = GetValue(new Hashtable())
            }.Instance;
            var site = new ShimSPWeb
            {
                UrlGet = () => "Url"
            }.Instance;
            var dataTable = new DataTable();
            privateObject.SetFieldOrProperty("site", site);
            privateObject.SetFieldOrProperty("dt", dataTable);
            ShimDashboard.AllInstances.getTaskCountString = (_, name) => 1;
            ShimDataRowCollection.AllInstances.AddObjectArray = (_, parameters) =>
            {
                rowValues = parameters;
                return null;
            };
            ShimDashboard.AllInstances.getRiskStatusString = (_, name) => "green";
            ShimDashboard.AllInstances.getIssueStatusString = (_, name) => "green";

            // Act
            privateObject.Invoke(ProcessProjectSummaryItemMethodName, listItem);

            // Assert
            rowValues.ShouldSatisfyAllConditions(
                () => rowValues.Count().ShouldBe(8),
                () => rowValues[1].ShouldBe(new DateTime().ToShortDateString()),
                () => rowValues[2].ShouldBe(new DateTime().ToShortDateString()),
                () => rowValues[3].ShouldBe("0%"),
                () => rowValues[4].ShouldBe("1"),
                () => rowValues[5].ShouldBe(ExpectedScheduleStatus),
                () => rowValues[6].ShouldBe(ExpectedIssueStatus),
                () => rowValues[7].ShouldBe(ExpectedRiskStatus));
        }

        [TestMethod]
        public void ProcessProjectSummaryItem_WithParams_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedRiskStatus = "<img src=\"/_layouts/images/green.gif\">";
            const string ExpectedIssueStatus = "<img src=\"/_layouts/images/green.gif\">";
            const string ExpectedScheduleStatus = "<img src=\"/_layouts/images/red.gif\">";
            var title = string.Empty;
            var startDate = string.Empty;
            var finishDate = string.Empty;
            var porcentCompleted = string.Empty;
            var scheduleStatus = string.Empty;

            var rowValues = new object[] { };
            var listItem = new ShimSPListItem
            {
                TitleGet = () => " Title",
                IDGet = () => 1,
                ItemGetString = GetValue(new Hashtable
                {
                    ["Start"] = DateTime.Now,
                    ["Finish"] = DateTime.Now,
                    ["PercentComplete"] = 1,
                    ["Status"] = "Late",
                    ["Projects"] = "Late"
                })
            }.Instance;
            var site = new ShimSPWeb
            {
                UrlGet = () => "Url"
            }.Instance;
            var dataTable = new DataTable();
            privateObject.SetFieldOrProperty("site", site);
            privateObject.SetFieldOrProperty("dt", dataTable);
            ShimDashboard.AllInstances.getTaskCountString = (_, name) => 1;
            ShimDataRowCollection.AllInstances.AddObjectArray = (_, parameters) =>
            {
                rowValues = parameters;
                return null;
            };
            ShimDashboard.AllInstances.getRiskStatusString = (_, name) => "green";
            ShimDashboard.AllInstances.getIssueStatusString = (_, name) => "green";

            // Act
            privateObject.Invoke(ProcessProjectSummaryItemMethodName, listItem);

            // Assert
            rowValues.ShouldSatisfyAllConditions(
                () => rowValues.Count().ShouldBe(8),
                () => rowValues[1].ShouldBe(DateTime.Now.ToShortDateString()),
                () => rowValues[2].ShouldBe(DateTime.Now.ToShortDateString()),
                () => rowValues[3].ShouldBe("100%"),
                () => rowValues[4].ShouldBe("1"),
                () => rowValues[5].ShouldBe(ExpectedScheduleStatus),
                () => rowValues[6].ShouldBe(ExpectedIssueStatus),
                () => rowValues[7].ShouldBe(ExpectedRiskStatus));
        }

        [TestMethod]
        public void CreateChildControls_Something_NoActionTaken()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimAct.ConstructorSPWeb = (_, web) => { };
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, features) => 1;
            var controlsAdded = new List<Control>();
            ShimPart.AllInstances.ControlsGet = _ => new ShimControlCollection
            {
                AddControl = control => controlsAdded.Add(control)
            };

            // Act
            privateObject.Invoke(CreateChildControlsMethodName);

            // Assert
            dashboard.ShouldSatisfyAllConditions(
                () => controlsAdded.ShouldBeEmpty());
        }

        [TestMethod]
        public void CreateChildControls_OnException_ExecutesCorrectly()
        {
            // Arrange
            const string ErrorMessage = "Error Message";
            var expectedErrorMessage = $"ERROR: {ErrorMessage}<br>ERROR: {ErrorMessage}<br>";
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimAct.ConstructorSPWeb = (_, web) => { };
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, features) => 0;
            ShimSPControl.GetContextWebHttpContext = _ => new ShimSPWeb();
            ShimControl.AllInstances.ContextGet = _ => new ShimHttpContext();
            ShimControl.AllInstances.CreateChildControls = _ => { };
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetString = name => new ShimSPList
                {
                    FieldsGet = () => new ShimSPFieldCollection
                    {
                        GetFieldByInternalNameString = intName => new ShimSPField()
                    }
                }
            };
            ShimXmlDocument.AllInstances.LoadXmlString = (_, content) => 
            {
                throw new Exception(ErrorMessage);
            };
            ShimPart.AllInstances.ControlsGet = _ => new ShimControlCollection
            {
                AddControl = control => { }
            };
            ShimDashboard.AllInstances.popProjectString = (_, item) => 
            {
                throw new Exception(ErrorMessage);
            };
            ShimListControl.AllInstances.SelectedItemGet = _ => new ListItem("Dummy");

            // Act
            privateObject.Invoke(CreateChildControlsMethodName);
            var error = privateObject.GetFieldOrProperty("sError") as string;

            // Assert
            dashboard.ShouldSatisfyAllConditions(
                () => error.ShouldNotBeNullOrEmpty(),
                () => error.ShouldBe(expectedErrorMessage));
        }

        [TestMethod]
        public void CreateChildControls_OnSuccess_ExecutesCorrectly()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimAct.ConstructorSPWeb = (_, web) => { };
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, features) => 0;
            ShimSPControl.GetContextWebHttpContext = _ => new ShimSPWeb();
            ShimControl.AllInstances.ContextGet = _ => new ShimHttpContext();
            ShimControl.AllInstances.CreateChildControls = _ => { };
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetString = name => new ShimSPList
                {
                    FieldsGet = () => new ShimSPFieldCollection
                    {
                        GetFieldByInternalNameString = intName => new ShimSPField()
                    }
                }
            };
            ShimXmlDocument.AllInstances.LoadXmlString = (_, content) => { };
            var controlsAdded = new List<Control>();
            ShimPart.AllInstances.ControlsGet = _ => new ShimControlCollection
            {
                AddControl = control => controlsAdded.Add(control)
            };
            ShimDashboard.AllInstances.popProjectString = (_, item) => { };
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, node) => new ShimXmlNode(new XmlDocument())
            {
                InnerTextGet = () => "Dummy Value",
                ChildNodesGet = () =>
                {
                    var doc = new XmlDocument();
                    doc.AppendChild(doc.CreateElement("DummyElement"));
                    return doc.ChildNodes;
                }
            };
            ShimListControl.AllInstances.SelectedItemGet = _ => new ListItem("Dummy");

            // Act
            privateObject.Invoke(CreateChildControlsMethodName);

            // Assert
            dashboard.ShouldSatisfyAllConditions(
                () => controlsAdded.ShouldNotBeEmpty(),
                () => controlsAdded.OfType<DropDownList>().Count().ShouldBe(2));
        }

        [TestMethod]
        public void CreateChildControls_Dispose_VerifyMemoryLeak()
        {
            // Arrange
            using (ShimsContext.Create())
            {
                var dropdownListConstructorCount = 0;
                var dropdownListDisposeCount = 0;

                ShimDropDownList.Constructor = _ => dropdownListConstructorCount++;
                ShimControl.AllInstances.Dispose = control =>
                {
                    if (control is DropDownList)
                    {
                        dropdownListDisposeCount++;
                    }
                };

                var spWeb = new ShimSPWeb
                {
                    SiteGet = () => new ShimSPSite()
                };

                ShimSPContext.CurrentGet = () => new ShimSPContext
                {
                    WebGet = () => spWeb
                };

                ShimAct.ConstructorSPWeb = (act, web) => { };
                ShimAct.AllInstances.CheckFeatureLicenseActFeature = (act, feature) => 0;
                ShimSPControl.GetContextWebHttpContext = _ => new ShimSPWeb();

                // Act
                using (var dashBoard = new Dashboard())
                {
                    var privateObject = new PrivateObject(dashBoard);
                    privateObject.Invoke("CreateChildControls");
                }

                // Assert
                this.ShouldSatisfyAllConditions(
                    () => dropdownListConstructorCount.ShouldBeGreaterThanOrEqualTo(2),
                    () => dropdownListDisposeCount.ShouldBeGreaterThanOrEqualTo(2));
            }
        }

        private List<SPListItem> GetSPListItems()
        {
            return new List<SPListItem>
            {
                new ShimSPListItem
                {
                    ItemGetString = GetValue(new Hashtable
                    {
                        [StartDate] = null,
                        [DueDate] = null,
                        [Finish] = null,
                        [PercentComplete] = null,
                        [Milestone] = null,
                    })
                },
                new ShimSPListItem
                {
                    ItemGetString = GetValue(new Hashtable
                    {
                        [StartDate] = null,
                        [DueDate] = null,
                        [Finish] = null,
                        [PercentComplete] = null,
                        [Milestone] = bool.TrueString,
                    })
                },
                new ShimSPListItem
                {
                    ItemGetString = GetValue(new Hashtable
                    {
                        [StartDate] = DateTime.Now.AddDays(-3),
                        [DueDate] = DateTime.Now.AddDays(-2),
                        [PercentComplete] = 0.8F,
                    })
                },
                new ShimSPListItem
                {
                    ItemGetString = GetValue(new Hashtable
                    {
                        [StartDate] = DateTime.Now.AddDays(-3),
                        [DueDate] = DateTime.Now.AddDays(-2),
                        [PercentComplete] = 0.8F,
                        [Milestone] = bool.TrueString
                    })
                },
                new ShimSPListItem
                {
                    ItemGetString = GetValue(new Hashtable
                    {
                        [PercentComplete] = 1F,
                        [Milestone] = bool.TrueString
                    })
                },
                new ShimSPListItem
                {
                    ItemGetString = GetValue(new Hashtable
                    {
                        [PercentComplete] = 1F,
                        [Milestone] = bool.FalseString
                    })
                },
                new ShimSPListItem
                {
                    ItemGetString = GetValue(new Hashtable
                    {
                        [StartDate] = DateTime.Now.AddHours(1),
                        [PercentComplete] = 0F,
                        [Milestone] = bool.TrueString
                    })
                },
                new ShimSPListItem
                {
                    ItemGetString = GetValue(new Hashtable
                    {
                        [StartDate] = DateTime.Now.AddHours(1),
                        [PercentComplete] = 0F,
                    })
                }
            };
        }

        private FakesDelegates.Func<string, object> GetValue(Hashtable values)
        {
            return name =>
            {
                if (values.ContainsKey(name))
                {
                    return values[name];
                }
                else
                {
                    return null;
                }
            };
        }
    }
}
