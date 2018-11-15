using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EPMLiveCore.Fakes;
using EPMLiveWorkPlanner.Fakes;
using EPMLiveWorkPlanner.Layouts.epmlive.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWorkPlanner.Tests.Layouts.epmlive
{
    public partial class WorkPlannerWizardTests
    {
        [TestMethod]
        public void ICheckParams_ItemIDMissing_PnlItemVisibleOutputHtmlFilled()
        {
            // Arrange
            var webFirst = new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetGuid = guid => new ShimSPList()
                    {
                        ItemsGet = () => new ShimSPListItemCollection()
                        {
                            CountGet = () => 2
                        }.Bind(
                            new SPListItem[]
                            {
                                new ShimSPListItem()
                                {
                                    IDGet = () => DummyInt,
                                    TitleGet = () => DummyTitle
                                },
                                new ShimSPListItem()
                                {
                                    IDGet = () => DummyIntTwo,
                                    TitleGet = () => $"{DummyTitle}2"
                                }
                            })
                    },
                    ItemGetString = itemString => new ShimSPList()
                    {
                        IDGet = () => TaskListGuid
                    }
                }
            };

            var webSecond = new ShimSPWeb();

            ShimCoreFunctions.getConfigSettingSPWebString = (webParam, setting) => setting;

            _privateObject.SetField("sProjectListId", RequestProjectListId);
            _privateObject.SetField("sPlannerID", RequestPlanner);

            var expectedContent = new List<string>
            {
                $"<option value=\"{DummyInt}\">{DummyTitle}</option>",
                $"<option value=\"{DummyIntTwo}\">{DummyTitle}2</option>"
            };

            // Act
            _privateObject.Invoke(ICheckParamsMethod, webFirst.Instance, webSecond.Instance);

            // Assert
            var pnlItem = (Panel)_privateObject.GetField("pnlItem");
            var outputHtml = (string)_privateObject.GetField("sOutputHtml");

            this.ShouldSatisfyAllConditions(
                () => pnlItem.Visible.ShouldBeTrue(),
                () => expectedContent.ForEach(p => outputHtml.ShouldContainWithoutWhitespace(p)));
        }

        [TestMethod]
        public void ICheckParams_sPlannerIdEmptyPlannersNotFound_PnlPlannersVisibleOutputHtmlFilled()
        {
            // Arrange
            var webFirst = new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetGuid = guid => new ShimSPList()
                    {
                        TitleGet = () => DummyTitle
                    }
                }
            };

            var webSecond = new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetGuid = guid => new ShimSPList()
                }
            };

            ShimWorkPlannerAPI.GetPlannersByProjectListStringSPWeb = (title, webParam) => new SortedList()
            {
                { DummyTempPlanner, DummyTempPlanner }
            };

            ShimCoreFunctions.getConfigSettingSPWebString = (webParam, setting) =>
            {
                if (setting == $"EPMLivePlanner{DummyTempPlanner}Description")
                {
                    return DummyDescription;
                }

                if (setting == $"EPMLivePlanner{DummyTempPlanner}EnableOnline"
                    || setting == $"EPMLivePlanner{DummyTempPlanner}EnableProject")
                {
                    return TrueString;
                }

                return string.Empty;
            };

            ShimWorkPlannerAPI.GetPlannersByTaskListSPWebString = (webParam, taskListTitle) => new SortedList()
            {
                { DummyTempPlanner, DummyTempPlanner }
            };

            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = sender => new ShimSPWeb()
            {
                ServerRelativeUrlGet = () => "/"
            };

            _privateObject.SetField("sProjectListId", RequestProjectListId);
            _privateObject.SetField("sPlannerID", string.Empty);
            _privateObject.SetField("sTaskListId", TaskListGuid.ToString());

            var expectedContent = new List<string>
            {
                $"<a href=\"javascript:void(0);\" onclick=\"SelectPlanner('{DummyTempPlanner}|Online')\" class=\"btn btn-large\">",
                $"<span>{DummyTempPlanner}</span>",
                $"<div style=\"padding-top: 5px;padding-bottom:10px;padding-right:5px;min-height:35px;work-wrap:break-word;\">{DummyDescription}</div>",
                $"<span>{DummyTempPlanner} for Microsoft Project</span>"
            };

            // Act
            _privateObject.Invoke(ICheckParamsMethod, webFirst.Instance, webSecond.Instance);

            // Assert
            var pnlPlanner = (Panel)_privateObject.GetField("pnlPlanner");
            var outputHtml = (string)_privateObject.GetField("sOutputHtml");

            this.ShouldSatisfyAllConditions(
                () => pnlPlanner.Visible.ShouldBeTrue(),
                () => expectedContent.ForEach(p => outputHtml.ShouldContainWithoutWhitespace(p)));
        }

        [TestMethod]
        public void ICheckParams_sPlannerIdEmptyPlannersInLockConfigProjectTypeProject_PnlTemplateVisibleSetDefault()
        {
            // Arrange
            var actualSetDefault = false;
            var actualPopulateTemplate = false;
            var webFirst = new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetGuid = guid => new ShimSPList()
                    {
                        TitleGet = () => DummyTitle,
                        ItemsGet = () => new ShimSPListItemCollection()
                        {
                            ItemGetInt32 = pos => new ShimSPListItem()
                            {
                                IDGet = () => DummyIntTwo
                            },
                            CountGet = () => 1
                        },
                        GetItemByIdInt32 = idInt => new ShimSPListItem()
                        {
                            TitleGet = () => $"{DummyTitle}2"
                        }
                    },
                    TryGetListString = listName => new ShimSPList()
                }
            };

            var webSecond = new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetGuid = guid => new ShimSPList()
                }
            };

            ShimWorkPlannerAPI.GetPlannersByProjectListStringSPWeb = (title, webParam) => new SortedList();

            ShimCoreFunctions.getConfigSettingSPWebString = (webParam, setting) =>
            {
                if (setting == $"EPMLivePlanner{DummyTempPlanner}Description")
                {
                    return DummyDescription;
                }
                else if (setting == $"EPMLivePlanner{DummyTempPlanner}EnableOnline")
                {
                    return FalseString;
                }
                else if (setting == $"EPMLivePlanner{DummyTempPlanner}EnableProject")
                {
                    return TrueString;
                }

                return string.Empty;
            };

            ShimWorkPlannerAPI.GetPlannersByTaskListSPWebString = (webParam, taskListTitle) => new SortedList();

            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (webParam, setting, relative) => $"{DummyTempPlanner}|{DummyTempPlanner}";
            ShimWorkPlannerWizard.AllInstances.PopulateTemplatesSPWeb = (sender, webParam) =>
            {
                actualPopulateTemplate = true;
                return true;
            };
            ShimWorkPlannerWizard.AllInstances.setDefaultSPWeb = (sender, webParam) => actualSetDefault = true;

            _privateObject.SetField("sProjectListId", RequestProjectListId);
            _privateObject.SetField("sPlannerID", string.Empty);
            _privateObject.SetField("sTaskListId", TaskListGuid.ToString());

            // Act
            _privateObject.Invoke(ICheckParamsMethod, webFirst.Instance, webSecond.Instance);

            // Assert
            var pnlTemplate = (Panel)_privateObject.GetField("pnlTemplate");

            this.ShouldSatisfyAllConditions(
                () => pnlTemplate.Visible.ShouldBeTrue(),
                () => actualPopulateTemplate.ShouldBeTrue(),
                () => actualSetDefault.ShouldBeTrue());
        }

        [TestMethod]
        public void ICheckParams_sPlannerIdMpp_PnlDoneVisibleSetDefault()
        {
            // Arrange
            var actualSetDefault = false;
            var webFirst = new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetGuid = guid => new ShimSPList()
                    {
                        TitleGet = () => DummyTitle,
                        ItemsGet = () => new ShimSPListItemCollection()
                        {
                            ItemGetInt32 = pos => new ShimSPListItem()
                            {
                                IDGet = () => DummyIntTwo
                            },
                            CountGet = () => 1
                        },
                        GetItemByIdInt32 = idInt => new ShimSPListItem()
                        {
                            TitleGet = () => $"{DummyTitle}2"
                        }
                    },
                    TryGetListString = listName => new ShimSPList(),
                    ItemGetString = listName => new ShimSPList()
                    {
                        IDGet = () => TaskListGuid
                    }
                }
            };

            var webSecond = new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetGuid = guid => new ShimSPList()
                }
            };

            ShimWorkPlannerAPI.GetPlannersByProjectListStringSPWeb = (title, webParam) => new SortedList()
            {
                { PlannerIdMpp, PlannerIdMpp }
            };

            ShimCoreFunctions.getConfigSettingSPWebString = (webParam, setting) =>
            {
                if (setting == $"EPMLivePlanner{DummyTempPlanner}Description")
                {
                    return DummyDescription;
                }
                else if (setting == $"EPMLivePlanner{PlannerIdMpp}EnableOnline")
                {
                    return FalseString;
                }
                else if (setting == $"EPMLivePlanner{PlannerIdMpp}EnableProject")
                {
                    return TrueString;
                }

                return string.Empty;
            };
            ShimWorkPlannerWizard.AllInstances.setDefaultSPWeb = (sender, webParam) => actualSetDefault = true;

            _privateObject.SetField("sProjectListId", RequestProjectListId);
            _privateObject.SetField("sPlannerID", string.Empty);

            // Act
            _privateObject.Invoke(ICheckParamsMethod, webFirst.Instance, webSecond.Instance);

            // Assert
            var pnlDone = (Panel)_privateObject.GetField("pnlDone");

            this.ShouldSatisfyAllConditions(
                () => pnlDone.Visible.ShouldBeTrue(),
                () => actualSetDefault.ShouldBeTrue());
        }

        [TestMethod]
        public void ICheckParams_ProjectListIdNull_PnlTemplateVisiblePopulateTemplate()
        {
            // Arrange
            var actualPopulateTemplate = false;
            var webFirst = new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetGuid = guid => new ShimSPList(),
                    ItemGetString = itemName => new ShimSPList()
                    {
                        IDGet = () => new Guid(RequestProjectListId),
                        ItemsGet = () => new ShimSPListItemCollection()
                        {
                            CountGet = () => 1,
                            ItemGetInt32 = pos => new ShimSPListItem()
                            {
                                IDGet = () => DummyIntTwo
                            }
                        },
                        GetItemByIdInt32 = id => new ShimSPListItem()
                        {
                            TitleGet = () => DummyTitle
                        }
                    }
                }
            };

            var webSecond = new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetGuid = guid => new ShimSPList()
                }
            };

            ShimWorkPlannerAPI.GetPlannersByTaskListSPWebString = (title, webParam) => new SortedList()
            {
                { PlannerIdMpp, PlannerIdMpp }
            };

            ShimCoreFunctions.getConfigSettingSPWebString = (webParam, setting) =>
            {
                if (setting == $"EPMLivePlanner{DummyTempPlanner}Description")
                {
                    return DummyDescription;
                }
                else if (setting == $"EPMLivePlanner{PlannerIdMpp}EnableOnline")
                {
                    return TrueString;
                }
                else if (setting == $"EPMLivePlanner{PlannerIdMpp}EnableProject")
                {
                    return FalseString;
                }

                return string.Empty;
            };
            ShimWorkPlannerAPI.GetTaskFileSPWebStringString = (web, id, plannerId) => null;
            ShimWorkPlannerWizard.AllInstances.PopulateTemplatesSPWeb = (sender, webParam) =>
            {
                actualPopulateTemplate = true;
                return true;
            };

            _privateObject.SetField("sTaskListId", TaskListGuid.ToString());
            _privateObject.SetField("sPlannerID", string.Empty);

            // Act
            _privateObject.Invoke(ICheckParamsMethod, webFirst.Instance, webSecond.Instance);

            // Assert
            var pnlTemplate = (Panel)_privateObject.GetField("pnlTemplate");

            this.ShouldSatisfyAllConditions(
                () => pnlTemplate.Visible.ShouldBeTrue(),
                () => actualPopulateTemplate.ShouldBeTrue());
        }
    }
}