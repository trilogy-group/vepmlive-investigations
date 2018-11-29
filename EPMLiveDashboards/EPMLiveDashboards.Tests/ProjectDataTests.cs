using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Fakes;
using System.Web.UI.WebControls;
using Dashboard;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveDashboards.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ProjectDataTests
    {
        private IDisposable _shimContext;
        private ProjectData _testEntity;
        private PrivateObject _privateObject;

        private ShimSPListCollection _siteList;

        private const string GetRiskStatusMethodName = "getRiskStatus";
        private const string GetIssueStatusMethodName = "getIssueStatus";
        private const string ProcessProjectSummaryItem2MethodName = "processProjectSummaryItem2";

        private const string RiskPostponedFieldName = "risk_postponed";
        private const string RiskClosedFieldName = "risk_closed";
        private const string RiskListFieldName = "riskList";
        private const string IssuePostponedFieldName = "issue_postponed";
        private const string IssueClosedFieldName = "issue_closed";
        private const string IssueListFieldName = "issueList";
        private const string DataTableProjectDataFieldName = "dt";

        private const string DummyString = "DummyString";
        private const string DummyDateTimeString = "2018-01-01";
        private static readonly DateTime DummyDateTimeNow = new DateTime(2018, 6, 1);
        private static readonly DateTime DummyDateTimeSmaller = new DateTime(2018, 1, 1);

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            _testEntity = new ProjectData();
            _privateObject = new PrivateObject(_testEntity);

            _testEntity.site = new ShimSPWeb()
            {
                ListsGet = () => _siteList
            };

            ShimDateTime.NowGet = () => DummyDateTimeNow;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
        }

        [TestMethod]
        public void BuildData_Should_ReturnsStringEmptyFillProperties()
        {
            // Arrange
            _siteList = new ShimSPListCollection()
            {
                ItemGetString = itemName =>
                {
                    switch (itemName)
                    {
                        case "Project Center":
                            return new ShimSPList()
                            {
                                ItemsGet = () => new ShimSPListItemCollection().Bind(
                                    new SPListItem[]
                                    {
                                        new ShimSPListItem()
                                        {
                                            ItemGetString = itemNameListItem => "(2) Active"
                                        }
                                    })
                            };
                        case "Task Center":
                            return new ShimSPList();
                        case "Issues":
                            return new ShimSPList();
                        case "Risks":
                            return new ShimSPList();
                        default:
                            break;
                    }

                    return null;
                }
            };

            // Act
            var actualResult = _testEntity.buildData(true, true, true);

            // Assert
            var gridViewSummary = _testEntity.gvPJSummary;

            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBe(string.Empty),
                () => gridViewSummary.AllowGrouping.ShouldBeFalse(),
                () => gridViewSummary.ID.ShouldBe("gvPJSummary"),
                () => gridViewSummary.Width.ShouldBe(Unit.Percentage(100)),
                () => gridViewSummary.HeaderStyle.CssClass.ShouldBe("ms-vh"),
                () => gridViewSummary.Columns.Count.ShouldBe(6),
                () => gridViewSummary.Columns[0].HeaderText.ShouldBe("Project Name"),
                () => gridViewSummary.Columns[1].HeaderText.ShouldBe("% Complete"),
                () => gridViewSummary.Columns[2].HeaderText.ShouldBe("# of Late Tasks"),
                () => gridViewSummary.Columns[3].HeaderText.ShouldBe("Schedule Status"),
                () => gridViewSummary.Columns[4].HeaderText.ShouldBe("Issue Status"),
                () => gridViewSummary.Columns[5].HeaderText.ShouldBe("Risk Status"),
                () => gridViewSummary.Rows.Count.ShouldBe(1),
                () => gridViewSummary.Rows[0].Cells.Count.ShouldBe(6),
                () => gridViewSummary.Rows[0].Cells[0].Text.ShouldBe("<a href=\"/Lists/Project%20Center/DispForm.aspx?ID=0\"></a>"),
                () => gridViewSummary.Rows[0].Cells[1].Text.ShouldBe("0%"),
                () => gridViewSummary.Rows[0].Cells[2].Text.ShouldBe("-1"),
                () => gridViewSummary.Rows[0].Cells[3].Text.ShouldBe("<img src=\"/_layouts/images/green.gif\">"),
                () => gridViewSummary.Rows[0].Cells[4].Text.ShouldBe("<img src=\"/_layouts/images/.gif\">"),
                () => gridViewSummary.Rows[0].Cells[5].Text.ShouldBe("<img src=\"/_layouts/images/.gif\">"));
        }

        [TestMethod]
        public void BuildData_IssuesNotFoundRisksNotFound_ReturnsStringEmptyFillProperties()
        {
            // Arrange
            _siteList = new ShimSPListCollection()
            {
                ItemGetString = itemName =>
                {
                    switch (itemName)
                    {
                        case "Project Center":
                            return new ShimSPList()
                            {
                                ItemsGet = () => new ShimSPListItemCollection().Bind(
                                    new SPListItem[]
                                    {
                                        new ShimSPListItem()
                                        {
                                            ItemGetString = itemNameListItem => "(2) Active"
                                        }
                                    })
                            };
                        case "Task Center":
                            return new ShimSPList();
                        case "Issues":
                            throw new Exception();
                        case "Risks":
                            throw new Exception();
                        default:
                            break;
                    }

                    return null;
                }
            };

            // Act
            var actualResult = _testEntity.buildData(true, true, true);

            // Assert
            var gridViewSummary = _testEntity.gvPJSummary;

            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBe(string.Empty),
                () => gridViewSummary.AllowGrouping.ShouldBeFalse(),
                () => gridViewSummary.ID.ShouldBe("gvPJSummary"),
                () => gridViewSummary.Width.ShouldBe(Unit.Percentage(100)),
                () => gridViewSummary.HeaderStyle.CssClass.ShouldBe("ms-vh"),
                () => gridViewSummary.Columns.Count.ShouldBe(6),
                () => gridViewSummary.Columns[0].HeaderText.ShouldBe("Project Name"),
                () => gridViewSummary.Columns[1].HeaderText.ShouldBe("% Complete"),
                () => gridViewSummary.Columns[2].HeaderText.ShouldBe("# of Late Tasks"),
                () => gridViewSummary.Columns[3].HeaderText.ShouldBe("Schedule Status"),
                () => gridViewSummary.Columns[4].HeaderText.ShouldBe("Issue Status"),
                () => gridViewSummary.Columns[5].HeaderText.ShouldBe("Risk Status"),
                () => gridViewSummary.Rows.Count.ShouldBe(1),
                () => gridViewSummary.Rows[0].Cells.Count.ShouldBe(6),
                () => gridViewSummary.Rows[0].Cells[0].Text.ShouldBe("<a href=\"/Lists/Project%20Center/DispForm.aspx?ID=0\"></a>"),
                () => gridViewSummary.Rows[0].Cells[1].Text.ShouldBe("0%"),
                () => gridViewSummary.Rows[0].Cells[2].Text.ShouldBe("-1"),
                () => gridViewSummary.Rows[0].Cells[3].Text.ShouldBe("<img src=\"/_layouts/images/green.gif\">"),
                () => gridViewSummary.Rows[0].Cells[4].Text.ShouldBe("&nbsp;"),
                () => gridViewSummary.Rows[0].Cells[5].Text.ShouldBe("&nbsp;"));
        }

        [TestMethod]
        public void BuildData_ProjectListNotFound_ReturnsString()
        {
            // Arrange, Act
            var actualResult = _testEntity.buildData(true, true, true);

            // Assert
            actualResult.ShouldBe("The Project Center list does not exist on this site.");
        }

        [TestMethod]
        public void BuildData_TaskCenterNotFound_ReturnsString()
        {
            // Arrange
            _siteList = new ShimSPListCollection()
            {
                ItemGetString = itemName =>
                {
                    switch (itemName)
                    {
                        case "Project Center":
                            return new ShimSPList();
                        case "Task Center":
                            throw new Exception();
                        case "My Tasks":
                            return new ShimSPList();
                        default:
                            break;
                    }

                    return null;
                }
            };

            // Act
            var actualResult = _testEntity.buildData(true, true, true);

            // Assert
            actualResult.ShouldBe("In order to take advantage of the new EPM Live functionality, please follow the instructions located <a href=\"http://www.projectpublisher.com/downloads/ProjectPublisherUpdateProcess.pdf\" target=\"_blank\">here</a>.");
        }

        [TestMethod]
        public void BuildData_TaskCenterNotFoundMyTasksNotFound_ReturnsString()
        {
            // Arrange
            _siteList = new ShimSPListCollection()
            {
                ItemGetString = itemName =>
                {
                    switch (itemName)
                    {
                        case "Project Center":
                            return new ShimSPList();
                        case "Task Center":
                            throw new Exception();
                        case "My Tasks":
                            throw new Exception();
                        default:
                            break;
                    }

                    return null;
                }
            };

            // Act
            var actualResult = _testEntity.buildData(true, true, true);

            // Assert
            actualResult.ShouldBe("No Tasks List Found");
        }

        [TestMethod]
        public void BuildData_Exception_ReturnsString()
        {
            // Arrange
            _siteList = new ShimSPListCollection()
            {
                ItemGetString = itemName => null
            };

            // Act
            var actualResult = _testEntity.buildData(true, true, true);

            // Assert
            actualResult.ShouldContain("Object reference not set to an instance of an object.   at Dashboard.ProjectData.buildData(Boolean pTasks, Boolean pRisks, Boolean pIssues)");
        }

        [TestMethod]
        public void BuildData2_Should_ReturnsStringEmptyFillProperties()
        {
            // Arrange
            _siteList = new ShimSPListCollection()
            {
                ItemGetString = itemName =>
                {
                    switch (itemName)
                    {
                        case "Project Center":
                            return new ShimSPList()
                            {
                                ItemsGet = () => new ShimSPListItemCollection().Bind(
                                    new SPListItem[]
                                    {
                                        new ShimSPListItem()
                                        {
                                            ItemGetString = itemNameListItem => "(2) Active"
                                        }
                                    })
                            };
                        case "Task Center":
                            return new ShimSPList();
                        case "Issues":
                            return new ShimSPList();
                        case "Risks":
                            return new ShimSPList();
                        default:
                            break;
                    }

                    return null;
                }
            };

            // Act
            var actualResult = _testEntity.buildData2();

            // Assert
            var gridViewSummary2 = _testEntity.gvPJSummary2;

            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBe(string.Empty),
                () => gridViewSummary2.AllowGrouping.ShouldBeFalse(),
                () => gridViewSummary2.ID.ShouldBe("gvPJSummary"),
                () => gridViewSummary2.Width.ShouldBe(Unit.Percentage(100)),
                () => gridViewSummary2.HeaderStyle.CssClass.ShouldBe("ms-vh"),
                () => gridViewSummary2.Columns.Count.ShouldBe(5),
                () => gridViewSummary2.Columns[0].HeaderText.ShouldBe("Project Name"),
                () => gridViewSummary2.Columns[1].HeaderText.ShouldBe("% Complete"),
                () => gridViewSummary2.Columns[2].HeaderText.ShouldBe("Schedule"),
                () => gridViewSummary2.Columns[3].HeaderText.ShouldBe("Issues"),
                () => gridViewSummary2.Columns[4].HeaderText.ShouldBe("Risks"),
                () => gridViewSummary2.Rows.Count.ShouldBe(1),
                () => gridViewSummary2.Rows[0].Cells.Count.ShouldBe(5),
                () => gridViewSummary2.Rows[0].Cells[0].Text.ShouldBe("<a href=\"/Lists/Project%20Center/DispForm.aspx?ID=0\"></a>"),
                () => gridViewSummary2.Rows[0].Cells[1].Text.ShouldBe("0%"),
                () => gridViewSummary2.Rows[0].Cells[2].Text.ShouldBe("<img src=\"/_layouts/images/green.gif\">"),
                () => gridViewSummary2.Rows[0].Cells[3].Text.ShouldBe("<img src=\"/_layouts/images/.gif\">"),
                () => gridViewSummary2.Rows[0].Cells[4].Text.ShouldBe("<img src=\"/_layouts/images/.gif\">"));
        }

        [TestMethod]
        public void BuildData2_TaskCenterNotFound_ReturnsString()
        {
            // Arrange
            _siteList = new ShimSPListCollection()
            {
                ItemGetString = itemName =>
                {
                    switch (itemName)
                    {
                        case "Project Center":
                            return new ShimSPList();
                        case "Task Center":
                            throw new Exception();
                        case "My Tasks":
                            return new ShimSPList();
                        default:
                            break;
                    }

                    return null;
                }
            };

            // Act
            var actualResult = _testEntity.buildData2();

            // Assert
            actualResult.ShouldBe("In order to take advantage of the new EPM Live functionality, please follow the instructions located <a href=\"http://www.projectpublisher.com/downloads/ProjectPublisherUpdateProcess.pdf\" target=\"_blank\">here</a>.");
        }

        [TestMethod]
        public void BuildData2_TaskCenterNotFoundMyTasksNotFound_ReturnsString()
        {
            // Arrange
            _siteList = new ShimSPListCollection()
            {
                ItemGetString = itemName =>
                {
                    switch (itemName)
                    {
                        case "Project Center":
                            return new ShimSPList();
                        case "Task Center":
                            throw new Exception();
                        case "My Tasks":
                            throw new Exception();
                        default:
                            break;
                    }

                    return null;
                }
            };

            // Act
            _testEntity.buildData2();

            // Assert
        }

        [TestMethod]
        public void ProcessProjectSummaryItem2_Should_AddRowInDataTable()
        {
            // Arrange
            var dataTableProjectData = new DataTable();
            dataTableProjectData.Columns.Add("name");
            dataTableProjectData.Columns.Add("pctcomplete");
            dataTableProjectData.Columns.Add("latetasks");
            dataTableProjectData.Columns.Add("schedulestatus");
            dataTableProjectData.Columns.Add("issuestatus");
            dataTableProjectData.Columns.Add("riskstatus");
            _privateObject.SetField(DataTableProjectDataFieldName, dataTableProjectData);

            var listItem = new ShimSPListItem()
            {
                ItemGetString = itemName =>
                {
                    switch (itemName)
                    {
                        case "Start":
                            return DummyDateTimeString;
                        case "Finish":
                            return DummyDateTimeString;
                        case "PercentComplete":
                            return "1";
                        case "Status":
                            return "Late";
                        default:
                            break;
                    }

                    throw new Exception();
                }
            };

            // Act
            _privateObject.Invoke(ProcessProjectSummaryItem2MethodName, listItem.Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => dataTableProjectData.Rows.Count.ShouldBe(1),
                () => dataTableProjectData.Rows[0].ItemArray.Length.ShouldBe(6),
                () => dataTableProjectData.Rows[0][0].ShouldBe("<a href=\"/Lists/Project%20Center/DispForm.aspx?ID=0\"></a>"),
                () => dataTableProjectData.Rows[0][1].ShouldBe("100%"),
                () => dataTableProjectData.Rows[0][2].ShouldBe(string.Empty),
                () => dataTableProjectData.Rows[0][3].ShouldBe("<img src=\"/_layouts/images/red.gif\">"),
                () => dataTableProjectData.Rows[0][4].ShouldBe("<img src=\"/_layouts/images/.gif\">"),
                () => dataTableProjectData.Rows[0][5].ShouldBe("<img src=\"/_layouts/images/.gif\">"));
        }

        [TestMethod]
        public void GetIssueStatus_Should_ReturnsStringFillProperties()
        {
            // Arrange
            _privateObject.SetField(IssueListFieldName, new ShimSPList().Instance);

            ShimSPList.AllInstances.GetItemsSPQuery = (sender, query) => new ShimSPListItemCollection().Bind(
                new SPListItem[]
                {
                    new ShimSPListItem()
                    {
                        ItemGetString = itemName =>
                        {
                            throw new Exception();
                        }
                    },
                    new ShimSPListItem()
                    {
                        ItemGetString = itemName =>
                        {
                            if (itemName == "Status")
                            {
                                return "Active";
                            }

                            return DummyDateTimeSmaller;
                        }
                    },
                    new ShimSPListItem()
                    {
                        ItemGetString = itemName =>
                        {
                            if (itemName == "Status")
                            {
                                return "Postponed";
                            }

                            return DummyDateTimeSmaller;
                        }
                    },
                    new ShimSPListItem()
                    {
                        ItemGetString = itemName =>
                        {
                            if (itemName == "Status")
                            {
                                return "Closed";
                            }

                            return DummyDateTimeSmaller;
                        }
                    }
                });

            // Act
            var actualResult = (string)_privateObject.Invoke(GetIssueStatusMethodName, DummyString);

            // Assert
            var actualIssuePostponed = (int)_privateObject.GetField(IssuePostponedFieldName);
            var actualIssueClosed = (int)_privateObject.GetField(IssueClosedFieldName);

            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBe("red"),
                () => actualIssuePostponed.ShouldBe(1),
                () => actualIssueClosed.ShouldBe(1));
        }

        [TestMethod]
        public void GetRiskStatus_Should_ReturnsStringFillProperties()
        {
            // Arrange
            _privateObject.SetField(RiskListFieldName, new ShimSPList().Instance);

            ShimSPList.AllInstances.GetItemsSPQuery = (sender, query) => new ShimSPListItemCollection().Bind(
                new SPListItem[]
                {
                    new ShimSPListItem()
                    {
                        ItemGetString = itemName =>
                        {
                            throw new Exception();
                        }
                    },
                    new ShimSPListItem()
                    {
                        ItemGetString = itemName =>
                        {
                            if (itemName == "Status")
                            {
                                return "Active";
                            }

                            return DummyDateTimeSmaller;
                        }
                    },
                    new ShimSPListItem()
                    {
                        ItemGetString = itemName =>
                        {
                            if (itemName == "Status")
                            {
                                return "Postponed";
                            }

                            return DummyDateTimeSmaller;
                        }
                    },
                    new ShimSPListItem()
                    {
                        ItemGetString = itemName =>
                        {
                            if (itemName == "Status")
                            {
                                return "Closed";
                            }

                            return DummyDateTimeSmaller;
                        }
                    }
                });

            // Act
            var actualResult = (string)_privateObject.Invoke(GetRiskStatusMethodName, DummyString);

            // Assert
            var actualRiskPostponed = (int)_privateObject.GetField(RiskPostponedFieldName);
            var actualRiskClosed = (int)_privateObject.GetField(RiskClosedFieldName);

            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBe("red"),
                () => actualRiskPostponed.ShouldBe(1),
                () => actualRiskClosed.ShouldBe(1));
        }

        [TestMethod]
        public void BuildHeader_Should_ReturnsString()
        {
            // Arrange
            var expectedResult = new List<string>()
            {
                "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">",
                "<tr class=\"ms-WPHeader\">",
                $"<td title=\"{DummyString}\" id=\"WebPartTitleWPQ2\" style=\"width:100%;\">",
                "<h3 class=\"ms-standardheader ms-WPTitle\">",
                $"<nobr><span>{DummyString}</span><span id=\"WebPartCaptionWPQ2\"></span></nobr>",
                "</h3>",
                "</td>",
                "</tr>",
                "</table>"
            };

            // Act
            var actualResult = _testEntity.buildHeader(DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedResult.ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void BuildTaskSummary_Should_ReturnsString()
        {
            // Arrange
            var expectedResult = new List<string>()
            {
                "<table border=\"0\" width=\"100%\" cellpadding=\"2\" cellspacing=\"0\">",
                "<td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">In Progress: 0 ( 0% )</td>",
                "<table width=\"100%\">",
                "<td width=\"0%\" height=\"15px\" class=\"ms-selected\"></td>",
                "<td width=\"100%\"></td>",
                "<td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Late: 0 ( 0% )</td>",
                "<td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Not Started: 0 ( 0% )</td>",
                "<td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Completed: 0 ( 0% ) </td>"
            };

            // Act
            var actualResult = _testEntity.buildTaskSummary();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedResult.ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void BuildIssueSummary_Should_ReturnsString()
        {
            // Arrange
            var expectedResult = new List<string>()
            {
                "<table border=\"0\" width=\"100%\" cellpadding=\"2\" cellspacing=\"0\">",
                "<td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Active: 0 ( 0% )</td>",
                "<table width=\"100%\">",
                "<td width=\"0%\" height=\"15px\" class=\"ms-selected\"></td>",
                "<td width=\"100%\"></td>",
                "<td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Postponed: 0 ( 0% )</td>",
                "<td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Closed: 0 ( 0% )</td>"
            };

            // Act
            var actualResult = _testEntity.buildIssueSummary();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedResult.ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void BuildRiskSummary_Should_ReturnsString()
        {
            // Arrange
            var expectedResult = new List<string>()
            {
                "<table border=\"0\" width=\"100%\" cellpadding=\"2\" cellspacing=\"0\">",
                "<td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Active: 0 ( 0% )</td>",
                "<table width=\"100%\">",
                "<td width=\"0%\" height=\"15px\" class=\"ms-selected\"></td>",
                "<td width=\"100%\"></td>",
                "<td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Postponed: 0 ( 0% )</td>",
                "<td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Closed: 0 ( 0% )</td>"
            };

            // Act
            var actualResult = _testEntity.buildRiskSummary();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedResult.ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void BuildMSSummary_Should_ReturnsString()
        {
            // Arrange
            var expectedResult = new List<string>()
            {
                "<table border=\"0\" width=\"100%\" cellpadding=\"2\" cellspacing=\"0\">",
                "<td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">In Progress: 0 ( 0% )</td>",
                "<table width=\"100%\">",
                "<td width=\"0%\" height=\"15px\" class=\"ms-selected\"></td>",
                "<td width=\"100%\"></td>",
                "<td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Late: 0 ( 0% )</td>",
                "<td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Not Started: 0 ( 0% )</td>",
                "<td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Completed: 0 ( 0% ) </td>"
            };

            // Act
            var actualResult = _testEntity.buildMSSummary();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedResult.ForEach(c => actualResult.ShouldContain(c)));
        }
    }
}