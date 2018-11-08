using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls.WebParts.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.ChartControlTests
{
    using EpmCharting.DomainModel;
    using EpmCharting.DomainServices.Fakes;
    using EpmCharting.Repositories.Fakes;
    using EPMLiveCore.Fakes;
    using EPMLiveWebParts;
    using Fakes;
    using Microsoft.SharePoint.WebPartPages;
    using Microsoft.SharePoint.WebPartPages.Fakes;

    [TestClass]
    public class ChartControlTests
    {
        private IDisposable shimsContext;
        private ChartControl chartControl;
        private PrivateObject privateObject;
        private static Guid DummyGuid = Guid.NewGuid();
        private readonly DropDownList BubbleChartXaxisDropDownList = new DropDownList();
        private readonly DropDownList BubbleChartYaxisAsDropDownList = new DropDownList();
        private readonly CheckBoxList BubbleChartYaxisCheckBoxList = new CheckBoxList();
        private readonly DropDownList BubbleChartZaxisDropDownList = new DropDownList();
        private readonly DropDownList BubbleChartZcolorFieldDropDownList = new DropDownList();
        private readonly Button BubbleChartApplyButton = new Button();
        private readonly HtmlTable UserSettingsTable = new HtmlTable();
        private readonly HtmlTable MainTable = new HtmlTable();
        private const string DummyString = "Dummy";
        private const string CreateChildControlsMethodName = "CreateChildControls";
        private const string BubbleChartApplyButtonClickMethodName = "BubbleChartApplyButtonClick";
        private const string PopulateBubbleChartInputsWithInitialValuesMethodName = "PopulateBubbleChartInputsWithInitialValues";
        private const string SetBubbleChartInputsBasedOnWebPartPropertiesMethodName = "SetBubbleChartInputsBasedOnWebPartProperties";
        private const string SetBubbleChartInputSelectionsBasedOnPersonalizationSettingsMethodName = "SetBubbleChartInputSelectionsBasedOnPersonalizationSettings";
        private const string GetYaxisSelectionsMethodName = "GetYaxisSelections";
        private const string IsBubbleChartMethodName = "IsBubbleChart";
        private const string GetYaxisFieldLabelMethodName = "GetYaxisFieldLabel";
        private const string OnPreRenderMethodName = "OnPreRender";
        private const string OnInitMethodName = "OnInit";
        private const string RenderWebPartMethodName = "RenderWebPart";
        private const string RenderWebPartWithElevatedPermissionsMethodName = "RenderWebPartWithElevatedPermissions";

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            chartControl = new ChartControl();
            privateObject = new PrivateObject(chartControl);
            privateObject.SetFieldOrProperty("BubbleChartXaxisDropDownList", BubbleChartXaxisDropDownList);
            privateObject.SetFieldOrProperty("BubbleChartYaxisAsDropDownList", BubbleChartYaxisAsDropDownList);
            privateObject.SetFieldOrProperty("BubbleChartYaxisCheckBoxList", BubbleChartYaxisCheckBoxList);
            privateObject.SetFieldOrProperty("BubbleChartZaxisDropDownList", BubbleChartZaxisDropDownList);
            privateObject.SetFieldOrProperty("BubbleChartZcolorFieldDropDownList", BubbleChartZcolorFieldDropDownList);
            privateObject.SetFieldOrProperty("BubbleChartApplyButton", BubbleChartApplyButton);
            privateObject.SetFieldOrProperty("UserSettingsTable", UserSettingsTable);
            privateObject.SetFieldOrProperty("MainTable", MainTable);
            SetupShims();
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
            BubbleChartXaxisDropDownList?.Dispose();
            BubbleChartYaxisAsDropDownList?.Dispose();
            BubbleChartYaxisCheckBoxList?.Dispose();
            BubbleChartZaxisDropDownList?.Dispose();
            BubbleChartZcolorFieldDropDownList?.Dispose();
            BubbleChartApplyButton?.Dispose();
            UserSettingsTable?.Dispose();
            MainTable?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimAct.ConstructorSPWeb = (_, web) => { };
            ShimControl.AllInstances.PageGet = _ => new ShimPage();
            ShimVfChart.AllInstances.GetHtmlString = (_, content) => content;
            ShimWebPartManager.GetCurrentWebPartManagerPage = page => new WebPartManager();
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb();
            ShimSPWeb.AllInstances.IDGet = _ => DummyGuid;
            ShimSPSite.ConstructorString = (_, url) => { };
            privateObject.SetFieldOrProperty("_myProvider", new StubIReportID
            {
                ReportIDGet = () => "3"
            });
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
        }

        [TestMethod]
        public void CreateChildControls_ActivationFotZero_NoActionTaken()
        {
            // Arrange
            var controls = new List<Control>();
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, feature) => 1;
            ShimControlCollection.AllInstances.AddControl = (_, control) => controls.Add(control);

            // Act
            privateObject.Invoke(CreateChildControlsMethodName);

            // Assert
            controls.ShouldBeEmpty();
        }

        [TestMethod]
        public void CreateChildControls_Should_ExecuteCorrectly()
        {
            // Arrange
            var controls = new List<Control>();
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, feature) => 0;
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                QueryStringGet = () => new NameValueCollection
                {
                    ["charttrace"] = DummyString,
                    ["lookupfield"] = DummyString,
                    ["lookupfieldlist"] = DummyString
                }
            };
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser
            {
                IDGet = () => 1
            };
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite
            {
                IDGet = () => DummyGuid,
            };
            var reportProvider = new StubIReportID
            {
                ReportIDGet = () => "3"
            };
            privateObject.SetFieldOrProperty("_myProvider", reportProvider);
            chartControl.ID = DummyGuid.ToString();
            ShimEpmChartUserSettingsRepository.AllInstances.GetChartSettingsPersonalizationSearchCriteria =
                (_, critetira) => new EpmChartUserSettings();
            ShimWebPart.AllInstances.ZoneIDGet = _ => "1";
            ShimWebPartDisplayMode.AllInstances.NameGet = _ => "Design";
            chartControl.PropChartShowBubbleChartInputsInWebPart = true;
            ShimControlCollection.AllInstances.AddControl = (_, control) => controls.Add(control);
            
            // Act
            privateObject.Invoke(CreateChildControlsMethodName);

            // Assert
            controls.ShouldSatisfyAllConditions(
                () => controls.ShouldNotBeNull(),
                () => controls.Count.ShouldBeGreaterThan(0),
                () => controls.OfType<HtmlTable>().ShouldNotBeEmpty(),
                () => controls.OfType<LiteralControl>().ShouldNotBeEmpty(),
                () => controls.OfType<Literal>().ShouldNotBeEmpty());
        }

        [TestMethod]
        public void CreateChildControls_IsBubbleChart_ExecutesCorrectly()
        {
            // Arrange
            var controls = new List<Control>();
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, feature) => 0;
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                QueryStringGet = () => new NameValueCollection
                {
                    ["charttrace"] = DummyString,
                    ["lookupfield"] = DummyString,
                    ["lookupfieldlist"] = DummyString
                }
            };
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser
            {
                IDGet = () => 1
            };
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite
            {
                IDGet = () => DummyGuid,
            };
            chartControl.ID = DummyGuid.ToString();
            ShimEpmChartUserSettingsRepository.AllInstances.GetChartSettingsPersonalizationSearchCriteria =
                (_, critetira) => new EpmChartUserSettings();
            ShimWebPart.AllInstances.ZoneIDGet = _ => "1";
            ShimWebPartDisplayMode.AllInstances.NameGet = _ => "Design";
            chartControl.PropChartShowBubbleChartInputsInWebPart = true;
            chartControl.PropChartMainStyle = "bubble";
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetString = name => new ShimSPList()
            };
            ShimChartControl.AllInstances.PopulateBubbleChartInputsWithInitialValuesSPList = 
                (_, list) => { };
            ShimChartControl.AllInstances.SetBubbleChartInputSelectionsBasedOnPersonalizationSettingsEpmChartUserSettingsSPList = 
                (_, settings, list) => { };
            ShimChartControl.AllInstances.SetBubbleChartInputsBasedOnWebPartProperties = _ => { };
            ShimControlCollection.AllInstances.AddControl = (_, control) => controls.Add(control);

            // Act
            privateObject.Invoke(CreateChildControlsMethodName);

            // Assert
            controls.ShouldSatisfyAllConditions(
                () => controls.Count.ShouldBeGreaterThan(0),
                () => controls.OfType<HtmlTable>().ShouldNotBeEmpty(),
                () => controls.OfType<Literal>().ShouldNotBeEmpty(),
                () => controls.OfType<HtmlTable>().ShouldNotBeEmpty(),
                () => controls.OfType<HtmlTableRow>().ShouldNotBeEmpty(),
                () => controls.OfType<HtmlTableCell>().ShouldNotBeEmpty());
        }

        [TestMethod]
        public void BubbleChartApplyButtonClick_Should_ExecuteCorrectly()
        {
            // Arrange
            EpmChartUserSettings chartSettings = null;
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => new ShimSPWeb
                {
                    IDGet = () => DummyGuid,
                    SiteGet = () => new ShimSPSite
                    {
                        IDGet = () => DummyGuid
                    },
                    CurrentUserGet = () => new ShimSPUser
                    {
                        IDGet = () => 1
                    },
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetString = name => new ShimSPList
                        {
                            IDGet = () => DummyGuid
                        }
                    }
                }
            };
            ShimEpmChartUserSettingsRepository.AllInstances.PersistChartSettingsEpmChartUserSettings =
                (_, settings) =>
                {
                    chartSettings = settings;
                };
            chartControl.ID = DummyGuid.ToString();
            ShimListControl.AllInstances.SelectedItemGet = _ => new ListItem("Value");

            // Act
            privateObject.Invoke(BubbleChartApplyButtonClickMethodName, null, EventArgs.Empty);
            var isPostBack = (bool)privateObject.GetFieldOrProperty("_isPostBackFromBubbleChartInputsApplyButton");

            // Assert
            this.ShouldSatisfyAllConditions(
                () => isPostBack.ShouldBeTrue(),
                () => chartSettings.ShouldNotBeNull(),
                () => chartSettings.SiteId.ShouldBe(DummyGuid),
                () => chartSettings.WebId.GetValueOrDefault().ShouldBe(DummyGuid),
                () => chartSettings.WebPartId.ShouldBe(DummyGuid),
                () => chartSettings.ListId.ShouldBe(DummyGuid));
        }

        [TestMethod]
        public void PopulateBubbleChartInputsWithInitialValues_IsBubbleChart_ExecutesCorrectly()
        {
            // Arrange
            var spList = new ShimSPList
            {
                FieldsGet = () =>
                {
                    var list = new List<SPField>
                    {
                        new ShimSPField
                        {
                            TypeGet = () => SPFieldType.Choice,
                            InternalNameGet = () => DummyString,
                            TitleGet = () => DummyString
                        },
                        new ShimSPField
                        {
                            TypeGet = () => SPFieldType.Attachments,
                            InternalNameGet = () => DummyString,
                            TitleGet = () => DummyString
                        },
                        new ShimSPField
                        {
                            TypeAsStringGet = () => DummyString,
                            TypeGet = () => SPFieldType.Integer,
                            InternalNameGet = () => DummyString,
                            TitleGet = () => DummyString
                        },
                        new ShimSPField
                        {
                            TypeAsStringGet = () => "Currency",
                            TypeGet = () => SPFieldType.Calculated,
                            InternalNameGet = () => DummyString,
                            TitleGet = () => DummyString
                        }
                    };
                    return new ShimSPFieldCollection().Bind(list);
                }
            }.Instance;
            ShimChartHelper.IsCalculateableSharepointFieldSPField = _ => true;
            ShimEpmChart.GetFieldSchemaAttribValueStringString = (search, attribute) => attribute;
            chartControl.PropChartMainStyle = "bubble";

            // Act
            privateObject.Invoke(PopulateBubbleChartInputsWithInitialValuesMethodName, spList);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => BubbleChartYaxisAsDropDownList.ShouldNotBeNull(),
                () => BubbleChartYaxisAsDropDownList.Items.ShouldNotBeNull(),
                () => BubbleChartYaxisAsDropDownList.Items.Count.ShouldBeGreaterThan(0),
                () => BubbleChartYaxisAsDropDownList.Items.FindByText(DummyString).ShouldNotBeNull());
        }

        [TestMethod]
        public void PopulateBubbleChartInputsWithInitialValues_IsBubbleChartFalse_ExecutesCorrectly()
        {
            // Arrange
            var spList = new ShimSPList
            {
                FieldsGet = () =>
                {
                    var list = new List<SPField>
                    {
                        new ShimSPField
                        {
                            TypeGet = () => SPFieldType.Choice,
                            InternalNameGet = () => DummyString,
                            TitleGet = () => DummyString
                        },
                        new ShimSPField
                        {
                            TypeGet = () => SPFieldType.Attachments,
                            InternalNameGet = () => DummyString,
                            TitleGet = () => DummyString
                        },
                        new ShimSPField
                        {
                            TypeAsStringGet = () => DummyString,
                            TypeGet = () => SPFieldType.Integer,
                            InternalNameGet = () => DummyString,
                            TitleGet = () => DummyString
                        },
                        new ShimSPField
                        {
                            TypeAsStringGet = () => "Currency",
                            TypeGet = () => SPFieldType.Calculated,
                            InternalNameGet = () => DummyString,
                            TitleGet = () => DummyString
                        }
                    };
                    return new ShimSPFieldCollection().Bind(list);
                }
            }.Instance;
            ShimChartHelper.IsCalculateableSharepointFieldSPField = _ => true;
            ShimEpmChart.GetFieldSchemaAttribValueStringString = (search, attribute) => attribute;
            chartControl.PropChartMainStyle = string.Empty;

            // Act
            privateObject.Invoke(PopulateBubbleChartInputsWithInitialValuesMethodName, spList);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => BubbleChartYaxisCheckBoxList.ShouldNotBeNull(),
                () => BubbleChartYaxisCheckBoxList.Items.ShouldNotBeNull(),
                () => BubbleChartYaxisCheckBoxList.Items.Count.ShouldBeGreaterThan(0),
                () => BubbleChartYaxisCheckBoxList.Items.FindByText(DummyString).ShouldNotBeNull());
        }

        [TestMethod]
        public void SetBubbleChartInputsBasedOnWebPartProperties_IsBubbleChart_ExecutesCorrectly()
        {
            // Arrange
            chartControl.PropChartXaxisField = DummyString;
            chartControl.PropChartZaxisField = DummyString;
            chartControl.PropChartYaxisField = DummyString;
            chartControl.PropBubbleChartColorField = DummyString;
            var xAxisFieldItem = new ListItem(DummyString);
            BubbleChartXaxisDropDownList.Items.Add(xAxisFieldItem);
            var zAxisFieldItem = new ListItem(DummyString);
            BubbleChartZaxisDropDownList.Items.Add(zAxisFieldItem);
            var zColorFieldItem = new ListItem(DummyString);
            BubbleChartZcolorFieldDropDownList.Items.Add(zColorFieldItem);
            var bubbleItem = new ListItem(DummyString);
            BubbleChartYaxisAsDropDownList.Items.Add(bubbleItem);
            ShimChartControl.AllInstances.GetYaxisFields = _ => new string[] { DummyString };
            chartControl.PropChartMainStyle = "bubble";
            
            // Act
            privateObject.Invoke(SetBubbleChartInputsBasedOnWebPartPropertiesMethodName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => xAxisFieldItem.Selected.ShouldBeTrue(),
                () => zAxisFieldItem.Selected.ShouldBeTrue(),
                () => zColorFieldItem.Selected.ShouldBeTrue(),
                () => bubbleItem.Selected.ShouldBeTrue());
        }

        [TestMethod]
        public void SetBubbleChartInputsBasedOnWebPartProperties_IsBubbleChartFalse_ExecutesCorrectly()
        {
            // Arrange
            chartControl.PropChartXaxisField = DummyString;
            chartControl.PropChartZaxisField = DummyString;
            chartControl.PropChartYaxisField = DummyString;
            chartControl.PropBubbleChartColorField = DummyString;
            var xAxisFieldItem = new ListItem(DummyString);
            BubbleChartXaxisDropDownList.Items.Add(xAxisFieldItem);
            var zAxisFieldItem = new ListItem(DummyString);
            BubbleChartZaxisDropDownList.Items.Add(zAxisFieldItem);
            var zColorFieldItem = new ListItem(DummyString);
            BubbleChartZcolorFieldDropDownList.Items.Add(zColorFieldItem);
            var bubbleItem = new ListItem(DummyString);
            BubbleChartYaxisCheckBoxList.Items.Add(bubbleItem);
            ShimChartControl.AllInstances.GetYaxisFields = _ => new string[] { DummyString };
            chartControl.PropChartMainStyle = DummyString;

            // Act
            privateObject.Invoke(SetBubbleChartInputsBasedOnWebPartPropertiesMethodName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => xAxisFieldItem.Selected.ShouldBeTrue(),
                () => zAxisFieldItem.Selected.ShouldBeTrue(),
                () => zColorFieldItem.Selected.ShouldBeTrue(),
                () => bubbleItem.Selected.ShouldBeTrue());
        }

        [TestMethod]
        public void SetBubbleChartInputSelectionsBasedOnPersonalizationSettings_BubbleChartFalse()
        {
            // Arrange
            var userSettings = new EpmChartUserSettings
            {
                XaxisField = DummyString,
                YaxisFields = new List<string> { DummyString },
                ZaxisField = DummyString,
                ZaxisColorField = DummyString
            };
            var selectedList = new ShimSPList().Instance;
            var xAxisDropDownListItem = new ListItem(DummyString);
            BubbleChartXaxisDropDownList.Items.Add(xAxisDropDownListItem);
            var yAxisCheckBoxListItem = new ListItem(DummyString);
            BubbleChartYaxisCheckBoxList.Items.Add(yAxisCheckBoxListItem);
            var zAxisDropDownListItem = new ListItem(DummyString);
            BubbleChartZaxisDropDownList.Items.Add(zAxisDropDownListItem);
            var zColorFieldDropDownListItem = new ListItem(DummyString);
            BubbleChartZcolorFieldDropDownList.Items.Add(zColorFieldDropDownListItem);

            // Act
            privateObject.Invoke(
                SetBubbleChartInputSelectionsBasedOnPersonalizationSettingsMethodName,
                userSettings,
                selectedList);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => xAxisDropDownListItem.Selected.ShouldBeTrue(),
                () => yAxisCheckBoxListItem.Selected.ShouldBeTrue(),
                () => zAxisDropDownListItem.Selected.ShouldBeTrue(),
                () => zColorFieldDropDownListItem.Selected.ShouldBeTrue());
        }

        [TestMethod]
        public void SetBubbleChartInputSelectionsBasedOnPersonalizationSettings_IsBubbleChart()
        {
            // Arrange
            var userSettings = new EpmChartUserSettings
            {
                XaxisField = DummyString,
                YaxisFields = new List<string> { DummyString },
                ZaxisField = DummyString,
                ZaxisColorField = DummyString
            };
            var selectedList = new ShimSPList().Instance;
            var xAxisDropDownListItem = new ListItem(DummyString);
            BubbleChartXaxisDropDownList.Items.Add(xAxisDropDownListItem);
            var yAxisAsDropDownListItem = new ListItem(DummyString);
            BubbleChartYaxisAsDropDownList.Items.Add(yAxisAsDropDownListItem);
            var zAxisDropDownListItem = new ListItem(DummyString);
            BubbleChartZaxisDropDownList.Items.Add(zAxisDropDownListItem);
            var zColorFieldDropDownListItem = new ListItem(DummyString);
            BubbleChartZcolorFieldDropDownList.Items.Add(zColorFieldDropDownListItem);
            chartControl.PropChartMainStyle = "Bubble";

            // Act
            privateObject.Invoke(
                SetBubbleChartInputSelectionsBasedOnPersonalizationSettingsMethodName,
                userSettings,
                selectedList);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => xAxisDropDownListItem.Selected.ShouldBeTrue(),
                () => yAxisAsDropDownListItem.Selected.ShouldBeTrue(),
                () => zAxisDropDownListItem.Selected.ShouldBeTrue(),
                () => zColorFieldDropDownListItem.Selected.ShouldBeTrue());
        }

        [TestMethod]
        public void RebuildControlTree_Should_ExecuteCorrectly()
        {
            // Arrange
            var CreateChildControlsWasCalled = false;
            ShimChartControl.AllInstances.CreateChildControls = _ =>
            {
                CreateChildControlsWasCalled = true;
            };
            chartControl.Width = "2";
            chartControl.Height = "2";

            // Act
            chartControl.RebuildControlTree();
            var chart = privateObject.GetFieldOrProperty("Chart") as EpmChart;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chartControl.Controls.Count.ShouldBe(0),
                () => CreateChildControlsWasCalled.ShouldBeTrue(),
                () => chart.ShouldNotBeNull(),
                () => chart.PropChartWidth.ShouldBe(2),
                () => chart.PropChartHeight.ShouldBe(2));
        }

        [TestMethod]
        public void IsBubbleChart_ChartMainStyleBubble_ReturnsTrue()
        {
            // Arrange
            chartControl.PropChartMainStyle = "Bubble";

            // Act
            var result = (bool)privateObject.Invoke(IsBubbleChartMethodName);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void GetYaxisSelections_IsBubbleChart_ReturnsExpectedList()
        {
            // Arrange
            ShimChartControl.AllInstances.IsBubbleChart = _ => true;
            BubbleChartYaxisAsDropDownList.Items.Add(
                new ListItem(DummyString)
                {
                    Selected = true
                });
            BubbleChartYaxisAsDropDownList.Items.Add(
                new ListItem("SomeValue")
                {
                    Selected = false
                });

            // Act
            var result = privateObject.Invoke(GetYaxisSelectionsMethodName) as List<string>;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Count.ShouldBe(1),
                () => result.ShouldContain(DummyString));
        }

        [TestMethod]
        public void GetYaxisSelections_IsBubbleChartFalse_ReturnsExpectedList()
        {
            // Arrange
            ShimChartControl.AllInstances.IsBubbleChart = _ => false;
            BubbleChartYaxisCheckBoxList.Items.Add(
                new ListItem(DummyString)
                {
                    Selected = true
                });
            BubbleChartYaxisCheckBoxList.Items.Add(
                new ListItem("SomeValue")
                {
                    Selected = false
                });

            // Act
            var result = privateObject.Invoke(GetYaxisSelectionsMethodName) as List<string>;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Count.ShouldBe(1),
                () => result.ShouldContain(DummyString));
        }

        [TestMethod]
        public void GetYaxisFieldLabel_IsBubbleChart_ReturnsExpectedValue()
        {
            // Arrange
            ShimChartControl.AllInstances.IsBubbleChart = _ => true;
            BubbleChartXaxisDropDownList.Items.Add(DummyString);
            BubbleChartXaxisDropDownList.SelectedValue = DummyString;
            BubbleChartYaxisAsDropDownList.Items.Add(DummyString);
            BubbleChartYaxisAsDropDownList.SelectedValue = DummyString;

            // Act
            var result = privateObject.Invoke(GetYaxisFieldLabelMethodName) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetYaxisFieldLabel_IsBubbleChartFalse_ReturnsExpectedValue()
        {
            // Arrange
            ShimChartControl.AllInstances.IsBubbleChart = _ => false;
            BubbleChartYaxisCheckBoxList.Items.Add(DummyString);
            BubbleChartYaxisCheckBoxList.SelectedValue = DummyString;

            // Act
            var result = privateObject.Invoke(GetYaxisFieldLabelMethodName) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetToolParts_Should_ReturnExpectedObject()
        {
            // Arrange, Act
            var result = chartControl.GetToolParts();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Count().ShouldBe(3),
                () => result[0].ShouldBeOfType<ChartControlToolpartBase>(),
                () => result[1].ShouldBeOfType<WebPartToolPart>(),
                () => result[2].ShouldBeOfType<CustomPropertyToolPart>());
        }

        [TestMethod]
        public void OnPreRender_Should_ExecuteCorrectly()
        {
            // Arrange
            var rebuildControlTreeWasCalled = false;
            var cacheability = HttpCacheability.Public;
            var setNoStoreWasCalled = false;
            ShimChartControl.AllInstances.RebuildControlTree = _ =>
            {
                rebuildControlTreeWasCalled = true;
            };
            privateObject.SetFieldOrProperty("_isPostBackFromBubbleChartInputsApplyButton", true);
            ShimControl.AllInstances.PageGet = _ => new ShimPage
            {
                ResponseGet = () => new ShimHttpResponse
                {
                    CacheGet = () => new ShimHttpCachePolicy
                    {
                        SetCacheabilityHttpCacheability = cache => cacheability = cache
                    }
                }
            };
            ShimHttpCachePolicy.AllInstances.SetNoStore = _ => setNoStoreWasCalled = true;

            // Act
            privateObject.Invoke(OnPreRenderMethodName, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => rebuildControlTreeWasCalled.ShouldBeTrue(),
                () => cacheability.ShouldBe(HttpCacheability.NoCache),
                () => setNoStoreWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void OnInit_Should_ExecuteCorrectly()
        {
            // Arrange
            chartControl.Width = "6";
            chartControl.Height = "1";
            ShimWebPart.AllInstances.OnInitEventArgs = (_, eventArgs) => { };

            // Act
            privateObject.Invoke(OnInitMethodName, EventArgs.Empty);
            var chart = privateObject.GetFieldOrProperty("Chart") as EpmChart;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.ShouldNotBeNull(),
                () => chart.PropChartWidth.ShouldBe(6),
                () => chart.PropChartHeight.ShouldBe(1));
        }

        [TestMethod]
        public void ReportIdConsumer_Should_ExecuteCorrectly()
        {
            // Arrange
            var provider = new StubIReportID();

            // Act
            chartControl.ReportIdConsumer(provider);
            var myProvider = privateObject.GetFieldOrProperty("_myProvider") as IReportID;

            // Assert
            myProvider.ShouldSatisfyAllConditions(
                () => myProvider.ShouldNotBeNull(),
                () => myProvider.ShouldBe(provider));
        }

        [TestMethod]
        public void RenderWebPart_Should_RenderActStatus()
        {
            // Arrange
            var stringBuilder = new StringBuilder();
            var writer = new ShimHtmlTextWriter
            {
                WriteString = content => stringBuilder.Append(content)
            }.Instance;
            privateObject.SetFieldOrProperty("activation", 2);
            privateObject.SetFieldOrProperty("act", 
                new ShimAct
                {
                    translateStatusInt32 = _ => DummyString
                }.Instance);
            ShimAct.BehaveAsCurrent();

            // Act
            privateObject.Invoke(RenderWebPartMethodName, writer);
            var result = stringBuilder.ToString();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void RenderWebPart_Activation0_RendersWebPart()
        {
            // Arrange
            var stringBuilder = new StringBuilder();
            var writer = new ShimHtmlTextWriter
            {
                WriteString = content => stringBuilder.Append(content)
            }.Instance;
            privateObject.SetFieldOrProperty("activation", 0);
            ShimWebPartManager.GetCurrentWebPartManagerPage = _ => new WebPartManager();
            ShimControl.AllInstances.RenderControlHtmlTextWriter = (_, textWriter) =>
            {
                textWriter.Write("Render Content");
            };

            // Act
            privateObject.Invoke(RenderWebPartMethodName, writer);
            var result = stringBuilder.ToString();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe("Render Content"));
        }

        [TestMethod]
        public void RenderWebPartWithElevatedPermissions_Should_RenderChartVerbiageLiteral()
        {
            // Arrange
            var stringBuilder = new StringBuilder();
            var writer = new ShimHtmlTextWriter
            {
                WriteString = content => stringBuilder.Append(content)
            }.Instance;
            ShimWebPartManager.GetCurrentWebPartManagerPage = _ => new WebPartManager();
            chartControl.PropChartSelectedList = string.Empty;
            ShimWebPartDisplayMode.AllInstances.NameGet = _ => "Design";
            ShimControl.AllInstances.RenderControlHtmlTextWriter = (_, textWriter) =>
            {
                textWriter.Write("Render Content");
            };

            // Act
            privateObject.Invoke(RenderWebPartWithElevatedPermissionsMethodName, writer);
            var result = stringBuilder.ToString();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe("Render Content"));
        }

        [TestMethod]
        public void PropChartRollupData_GetSet_Test()
        {
            // Arrange, Act
            chartControl.PropChartRollupData = true;
            var result = chartControl.PropChartRollupData;

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void PropChartFrameRoundCorners_GetSet_Test()
        {
            // Arrange, Act
            chartControl.PropChartFrameRoundCorners = false;
            var result = chartControl.PropChartFrameRoundCorners;

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void PropChartShowFrame_GetSet_Test()
        {
            // Arrange, Act
            chartControl.PropChartShowFrame = false;
            var result = chartControl.PropChartShowFrame;

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void PropChartShowSeriesNameAsLabel_GetSet_Test()
        {
            // Arrange, Act
            chartControl.PropChartShowSeriesNameAsLabel = true;
            var result = chartControl.PropChartShowSeriesNameAsLabel;

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void PropChartFrameColor_GetSet_Test()
        {
            // Arrange, Act
            chartControl.PropChartFrameColor = Color.DeepSkyBlue;
            var result = chartControl.PropChartFrameColor;

            // Assert
            result.ShouldBe(Color.DeepSkyBlue);
        }

        [TestMethod]
        public void PropChartLegendFontName_GetSet_Test()
        {
            // Arrange, Act
            chartControl.PropChartLegendFontName = DummyString;
            var result = chartControl.PropChartLegendFontName;

            // Assert
            result.ShouldBe(DummyString);
        }

        [TestMethod]
        public void PropChartYaxisNumValues_GetSet_Test()
        {
            // Arrange
            const int ExpectedValue = 6;

            // Act
            chartControl.PropChartYaxisNumValues = ExpectedValue;
            var result = chartControl.PropChartYaxisNumValues;

            // Assert
            result.ShouldBe(ExpectedValue);
        }

        [TestMethod]
        public void PropChartSeriesValueLabelPosition_GetSet_Test()
        {
            // Arrange, Act
            chartControl.PropChartSeriesValueLabelPosition = DummyString;
            var result = chartControl.PropChartSeriesValueLabelPosition;

            // Assert
            result.ShouldBe(DummyString);
        }

        [TestMethod]
        public void PropChartSeriesNameLabelPosition_GetSet_Test()
        {
            // Arrange, Act
            chartControl.PropChartSeriesNameLabelPosition = DummyString;
            var result = chartControl.PropChartSeriesNameLabelPosition;

            // Assert
            result.ShouldBe(DummyString);
        }

        [TestMethod]
        public void PropChartShowSeriesValueAsLabel_GetSet_Test()
        {
            // Arrange, Act
            chartControl.PropChartShowSeriesValueAsLabel = true;
            var result = chartControl.PropChartShowSeriesValueAsLabel;

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void PropChartSeriesDataPointLabelFontSize_GetSet_Test()
        {
            // Arrange,
            const int ExpectedValue = 65;

            //Act
            chartControl.PropChartSeriesDataPointLabelFontSize = ExpectedValue;
            var result = chartControl.PropChartSeriesDataPointLabelFontSize;

            // Assert
            result.ShouldBe(ExpectedValue);
        }

        [TestMethod]
        public void PropChartZaxisLabelRotationAngle_GetSet_Test()
        {
            // Arrange,
            const int ExpectedValue = 100;

            //Act
            chartControl.PropChartZaxisLabelRotationAngle = ExpectedValue;
            var result = chartControl.PropChartZaxisLabelRotationAngle;

            // Assert
            result.ShouldBe(ExpectedValue);
        }
    }
}
