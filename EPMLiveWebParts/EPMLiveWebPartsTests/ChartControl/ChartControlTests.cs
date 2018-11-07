using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Specialized;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls.WebParts.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Shouldly;

namespace EPMLiveWebParts.Tests.ChartControlTests
{
    using Microsoft.SharePoint.WebPartPages;

    using EpmCharting.DomainModel;
    using EpmCharting.Repositories.Fakes;
    using EPMLiveCore.Fakes;
    using EPMLiveWebParts;
    using Fakes;
    using Microsoft.SharePoint.WebPartPages.Fakes;
    using System.Web.UI;

    [TestClass]
    public class ChartControlTests
    {
        private IDisposable shimsContext;
        private ChartControl chartControl;
        private PrivateObject privateObject;
        private const string CreateChildControlsMethodName = "CreateChildControls";
        private string BubbleChartApplyButtonClickMethodName = "BubbleChartApplyButtonClick";
        private static Guid DummyGuid = Guid.NewGuid();
        private const string DummyString = "Dummy";


        private readonly DropDownList BubbleChartXaxisDropDownList = new DropDownList();
        private readonly DropDownList BubbleChartYaxisAsDropDownList = new DropDownList();
        private readonly CheckBoxList BubbleChartYaxisCheckBoxList = new CheckBoxList();
        private readonly DropDownList BubbleChartZaxisDropDownList = new DropDownList();
        private readonly DropDownList BubbleChartZcolorFieldDropDownList = new DropDownList();
        private readonly Button BubbleChartApplyButton = new Button();
        private readonly HtmlTable UserSettingsTable = new HtmlTable();
        private readonly HtmlTable MainTable = new HtmlTable();

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
        }

        [TestMethod]
        public void CreateChildControls_ActivationFotZero_NoActionTaken()
        {
            // Arrange
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, feature) => 1;

            // Act
            privateObject.Invoke(CreateChildControlsMethodName);

            // Assert
            // some validation

        }

        [TestMethod]
        public void CreateChildControls_()
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
        public void CreateChildControls_IsBubbleChart()
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



    }
}
