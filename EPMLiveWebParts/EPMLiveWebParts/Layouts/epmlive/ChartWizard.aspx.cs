using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml.Linq;
using EPMLiveWebParts.Properties;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;
using EPMLiveCore.ReportingProxy;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Web.UI;

namespace EPMLiveWebParts.Layouts.epmlive
{
    public partial class ChartWizard : LayoutsPageBase
    {
        private string sChartTitle { get; set; }
        private string sChartType { get; set; }
        private string sPropChartSelectedPaletteName { get; set; }
        private string sPropChartSelectedListAndViewName { get; set; }
        private string sPropChartSelectedViewTitle { get; set; }
        private string sPropChartSelectedListTitle { get; set; }
        private string sPropChartXaxisField { get; set; }
        private string sPropChartXaxisFieldLabel { get; set; }
        private string sPropChartYaxisField { get; set; }
        private string sPropChartYaxisFieldLabel { get; set; }
        private string sPropChartZaxisField { get; set; }
        private string sPropChartZaxisFieldLabel { get; set; }
        private string sPropBubbleChartGroupBy { get; set; }
        private string sPropYaxisFormat { get; set; }
        private string sPropChartShowSeriesLabels { get; set; }
        private string sPropChartShowLegend { get; set; }
        private string sPropChartShowGridlines { get; set; }
        private string sPropChartAggregationType { get; set; }
        private string sPropChartLegendPosition { get; set; }

        protected string _GridUrl = SPContext.Current.Web.Url + @"/_layouts/epmlive/ChartWizardDataGrid.aspx";
        protected string _CSSUrl = SPContext.Current.Web.Url + @"/_layouts/epmlive/styles/ChartWizard/ChartWizardStyle.css";

        private void GetListAndViewName()
        {
            // Get data source, parse list and view name
            if (!string.IsNullOrEmpty(tbSelectedListAndView.Text))
            {
                sPropChartSelectedListAndViewName = tbSelectedListAndView.Text;
                string[] lv = sPropChartSelectedListAndViewName.Split(new string[] { " > " }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    sPropChartSelectedListTitle = lv[0];
                    sPropChartSelectedViewTitle = lv[1];
                }
                catch { }
            }
        }

        private void FillStaticData()
        {
            rcbAgg.Items.Clear();
            rcbAgg.Items.Add(new RadComboBoxItem("None"));
            rcbAgg.Items.Add(new RadComboBoxItem("Count"));
            rcbAgg.Items.Add(new RadComboBoxItem("Sum"));
            rcbAgg.Items.Add(new RadComboBoxItem("Avg"));

            rcbYAxisFormat.Items.Clear();
            rcbYAxisFormat.Items.Add(new RadComboBoxItem("None"));
            rcbYAxisFormat.Items.Add(new RadComboBoxItem("Currency"));
            rcbYAxisFormat.Items.Add(new RadComboBoxItem("Percentage"));
        }

        private void FillData()
        {
            #region FILL HIDDEN DATA FIELDS
            SPList list = SPContext.Current.Web.Lists.TryGetList(sPropChartSelectedListTitle);
            if (list != null)
            {
                tbListTitle.Text = list.Title.ToString();
                sPropChartSelectedListTitle = list.Title.ToString();
                SPView view = list.Views[sPropChartSelectedViewTitle];
                if (view != null)
                {
                    tbViewTitle.Text = view.Title.ToString();
                    sPropChartSelectedViewTitle = view.Title.ToString();
                }
            }
            #endregion

            #region FILL X, Y, AND Z FIELDS
            if (!string.IsNullOrEmpty(sPropChartSelectedListTitle))
            {
                SPList oList = SPContext.Current.Web.Lists.TryGetList(sPropChartSelectedListTitle);
                if (oList == null)
                    return;

                DataTable dt = GetListColumns(oList.ID);
                // FILL IN 'NONE SELECTED' OPTION FIRST
                if (rcbXField.Items.FindItemByValue("None") == null)
                    rcbXField.Items.Add(new RadComboBoxItem("None", "None"));

                if (rcbXNum.Items.FindItemByValue("None") == null)
                    rcbXNum.Items.Add(new RadComboBoxItem("None", "None"));

                if (rcbXNonNum.Items.FindItemByValue("None") == null)
                    rcbXNonNum.Items.Add(new RadComboBoxItem("None", "None"));

                if (rcbYNumSingle.Items.FindItemByValue("None") == null)
                    rcbYNumSingle.Items.Add(new RadComboBoxItem("None", "None"));

                if (rcbYNumMulti.Items.FindItemByValue("None") == null)
                    rcbYNumMulti.Items.Add(new RadComboBoxItem("None", "None"));

                if (rcbZField.Items.FindItemByValue("None") == null)
                    rcbZField.Items.Add(new RadComboBoxItem("None", "None"));

                if (rcbYNonNumSingle.Items.FindItemByValue("None") == null)
                    rcbYNonNumSingle.Items.Add(new RadComboBoxItem("None", "None"));

                if (rcbYNonNumMulti.Items.FindItemByValue("None") == null)
                    rcbYNonNumMulti.Items.Add(new RadComboBoxItem("None", "None"));

                if (rcbGroupBy.Items.FindItemByValue("None") == null)
                    rcbGroupBy.Items.Add(new RadComboBoxItem("None", "None"));

                foreach (DataRow fld in dt.Rows)
                {
                    string sFldSharePointType = fld["SharePointType"].ToString();
                    string sFldDisplayName = fld["DisplayName"].ToString();
                    string sFldInternalName = fld["InternalName"].ToString();
                    string sFldColType = fld["ColumnType"].ToString();

                    if (sFldSharePointType == "Attachments" || sFldInternalName == "Order" ||
                        sFldSharePointType == "File" || sFldInternalName == "Metainfo" ||
                        sFldSharePointType == "Computed" || sFldSharePointType == "Guid" ||
                        sFldSharePointType == "Counter" || sFldSharePointType == "Note")
                        continue;

                    if (rcbXField.Items.FindItemByValue(sFldInternalName) == null)
                    {
                        var liX = new RadComboBoxItem(sFldDisplayName, sFldInternalName);
                        rcbXField.Items.Add(liX);
                    }

                    // numeric
                    if ((sFldSharePointType == "Calculated" && sFldColType == "Float") ||
                        (sFldSharePointType == "Calculated" && sFldColType == "Int") ||
                        sFldSharePointType == "Currency" ||
                        sFldSharePointType == "Integer" ||
                        sFldSharePointType == "Number")
                    {
                        if (rcbXNum.Items.FindItemByValue(sFldInternalName) == null)
                            rcbXNum.Items.Add(new RadComboBoxItem(sFldDisplayName, sFldInternalName));

                        if (rcbYNumSingle.Items.FindItemByValue(sFldInternalName) == null)
                            rcbYNumSingle.Items.Add(new RadComboBoxItem(sFldDisplayName, sFldInternalName));

                        if (rcbYNumMulti.Items.FindItemByValue(sFldInternalName) == null)
                            rcbYNumMulti.Items.Add(new RadComboBoxItem(sFldDisplayName, sFldInternalName));

                        if (rcbZField.Items.FindItemByValue(sFldInternalName) == null)
                            rcbZField.Items.Add(new RadComboBoxItem(sFldDisplayName, sFldInternalName));
                    }
                    // non-numeric
                    else
                    {
                        if (rcbXNonNum.Items.FindItemByValue(sFldInternalName) == null)
                            rcbXNonNum.Items.Add(new RadComboBoxItem(sFldDisplayName, sFldInternalName));

                        if (rcbYNonNumSingle.Items.FindItemByValue(sFldInternalName) == null)
                            rcbYNonNumSingle.Items.Add(new RadComboBoxItem(sFldDisplayName, sFldInternalName));

                        if (rcbYNonNumMulti.Items.FindItemByValue(sFldInternalName) == null)
                            rcbYNonNumMulti.Items.Add(new RadComboBoxItem(sFldDisplayName, sFldInternalName));

                        if (rcbGroupBy.Items.FindItemByValue(sFldInternalName) == null)
                            rcbGroupBy.Items.Add(new RadComboBoxItem(sFldDisplayName, sFldInternalName));
                    }
                }

            }
            #endregion
        }

        protected void WriteControlClientIds()
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "_CtrlClientIds_",
                "<script>" +
                "var updatePnlClientId = '" + upMain.ClientID + "';" +
                "var tbSelectedListAndViewClientId = '" + tbSelectedListAndView.ClientID + "';" +
                "var tbListTitleClientId = '" + tbListTitle.ClientID + "';" +
                "var tbViewTitleClientId = '" + tbViewTitle.ClientID + "';" +
                "var pnlAggClientId = '" + pnlAggDdl.ClientID + "';" +
                "var ddlAggClientId = '" + rcbAgg.ClientID + "';" +
                "var pnlXDdlClientId = '" + pnlXDdl.ClientID + "';" +
                "var ddlXFieldClientId = '" + rcbXField.ClientID + "';" +
                "var ddlXNumClientId = '" + rcbXNum.ClientID + "';" +
                "var ddlXNonNumClientId = '" + rcbXNonNum.ClientID + "';" +
                "var pnlYDdlClientId = '" + pnlYDdl.ClientID + "';" +
                "var ddlYNumSingleClientId = '" + rcbYNumSingle.ClientID + "';" +
                "var ddlYNonNumSingleClientId = '" + rcbYNonNumSingle.ClientID + "';" +
                "var ddlYNumMultiClientId = '" + rcbYNumMulti.ClientID + "';" +
                "var ddlYNonNumMultiClientId = '" + rcbYNonNumMulti.ClientID + "';" +
                "var ddlYAxisFormatClientId = '" + rcbYAxisFormat.ClientID + "';" +
                "var ddlZFieldClientId = '" + rcbZField.ClientID + "';" +
                "var pnlZFieldClientId = '" + pnlZDdl.ClientID + "';" +
                "var ddlGroupByClientId = '" + rcbGroupBy.ClientID + "';" +
                "var tbChartTypeClientId = '" + tbChartType.ClientID + "';" +
                "var tbChartTitleClientId = '" + tbChartTitle.ClientID + "';" +
                "var ddlPaletteClientId = '" + ddlPalette.ClientID + "';" +
                "var cbShowXAxisLabelsClientId = '" + cbShowXAxisLabels.ClientID + "';" +
                "var cbShowGridLinesClientId = '" + cbShowGridLines.ClientID + "';" +
                "var cbShowLegendClientId = '" + cbShowLegend.ClientID + "';" +
                "var ddlLegendPositionClientId = '" + ddlLegendPosition.ClientID + "';" +
                "</script>", false);
        }

        private void RegisterControlEvents()
        {
            rcbAgg.OnClientSelectedIndexChanged = "ManageUI";
            rcbXField.OnClientSelectedIndexChanged = "ManageUI";
            rcbXNum.OnClientSelectedIndexChanged = "ManageUI";
            rcbXNonNum.OnClientSelectedIndexChanged = "ManageUI";
            rcbYNumSingle.OnClientSelectedIndexChanged = "ManageUI";
            rcbYNumMulti.OnClientItemChecked = "ManageUI";
            rcbZField.OnClientSelectedIndexChanged = "ManageUI";
            rcbYNonNumSingle.OnClientSelectedIndexChanged = "ManageUI";
            rcbYNonNumMulti.OnClientItemChecked = "ManageUI";
            rcbYAxisFormat.OnClientSelectedIndexChanged = "ManageUI";
            rcbGroupBy.OnClientSelectedIndexChanged = "ManageUI";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WriteControlClientIds();
                FillStaticData();
                RegisterControlEvents();
            }
            GetListAndViewName();
            FillData();
        }

        #region HELPER METHODS
        private DataTable GetListColumns(Guid id)
        {
            DataTable result = new DataTable();
            string sGuid = id.ToString();
            if (!string.IsNullOrEmpty(sGuid))
            {
                QueryExecutor qExec = new QueryExecutor(SPContext.Current.Web);
                string sql = @"SELECT rc.ColumnType, rc.DisplayName, rc.InternalName, rc.SharePointType
                               FROM RPTColumn rc
                               WHERE RPTListId = '" + sGuid + @"'
                               ORDER BY DisplayName";

                result = qExec.ExecuteReportingDBQuery(sql, new Dictionary<string, object>());
            }
            return result;
        }
        #endregion

    }

}
