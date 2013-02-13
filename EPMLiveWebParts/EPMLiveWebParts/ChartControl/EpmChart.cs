using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;
using EPMLiveWebParts.EpmCharting.DomainModel;
using EPMLiveWebParts.EpmCharting.DomainServices;
using EPMLiveWebParts.EpmCharting.Mappers;
using EPMLiveWebParts.Utilities;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;
using ReportFiltering.DomainServices;

namespace EPMLiveWebParts
{
    public class EpmChart : VfChart
    {
        public HttpRequest Request { get; set; }
        protected Literal ScriptTagHolder = new Literal();
        protected DataTable ChartDataTable;
        protected DataTable dtSPSiteDataQueryData;
        private int iChartLegendFontSize = 10; //default
        private int iChartTitleFontSize = 16;
        private int _numberOfColumnsInChartDataTable;
        private int _numberOfRowsInChartDataTable;

        private int iXaxisLabelFontSize = 10; //default
        private int iZaxisLabelFontSize = 10; //default
        private int iZaxisLabelRotationAngle = -27; //default

        protected Literal litNewWebPartScreen = new Literal();
        protected SPList oTopList;
        private SPQuery oTopQuery;

        protected ToolPart[] toolparts;

        private const int MAX_LOOKUPFILTER = 300;
        private string reportFilterField = "";
        ArrayList titlesToFilterOn = new ArrayList();
        private readonly Guid _reportFilterGuid;
        NumberFormatInfo providerEn = new NumberFormatInfo();


        public EpmChart()
        {
            providerEn.NumberDecimalSeparator = ".";
            providerEn.NumberGroupSeparator = ",";
            providerEn.NumberGroupSizes = new int[] { 3 };
        }

        public EpmChart(HttpRequest request)
            : base(request)
        {
            Request = request;
            var reportFilterGuidAsWebPartId = request.QueryString["reportFilterId"];
            if (string.IsNullOrEmpty(reportFilterGuidAsWebPartId)) return;

            var reportFilterGuidAsString = reportFilterGuidAsWebPartId.Replace("g_", "").Replace("_", "-");

            try
            {
                if (!string.IsNullOrEmpty(reportFilterGuidAsString))
                {
                    _reportFilterGuid = new Guid(reportFilterGuidAsString);
                }
            }
            catch (FormatException)
            {
                // Don't do anything, string wasn't a valid guid. Guid.TryParse() is only available in
                // .NET 4.0 and above so this empty catch is suitable for now.   
            }
        }

        public int PropChartTitleFontSize
        {
            get { return iChartTitleFontSize; }
            set { iChartTitleFontSize = value; }
        }
        public int PropChartXaxisLabelRotationAngle { get; set; }
        public int PropChartXaxisLabelFontSize
        {
            get { return iXaxisLabelFontSize; }
            set { iXaxisLabelFontSize = value; }
        }
        public int PropChartZaxisLabelRotationAngle
        {
            get { return iZaxisLabelRotationAngle; }
            set { iZaxisLabelRotationAngle = value; }
        }
        public int PropChartSeriesDataPointLabelFontSize
        {
            get { return iZaxisLabelFontSize; }
            set { iZaxisLabelFontSize = value; }
        }
        public bool PropChartShowSeriesNameAsLabel { get; set; }
        public bool PropChartShowSeriesValueAsLabel { get; set; }
        public string PropChartSeriesNameLabelPosition { get; set; }
        public string PropChartSeriesValueLabelPosition { get; set; }
        public string PropChartLegendFontName { get; set; }
        public int PropChartLegendFontSize
        {
            get { return iChartLegendFontSize; }
            set { iChartLegendFontSize = value; }
        }
        public bool PropChartShowFrame { get; set; }
        public Color PropChartFrameColor { get; set; }
        public bool PropChartFrameRoundCorners { get; set; }

        public EpmChartUserSettings BubbleChartUserSettings { get; set; }

        public void LoadChartDataUsingSPSiteDataQuery()
        {
            try
            {
                if (ChartDataTable == null)
                {
                    ChartDataTable = new DataTable("Series");
                }

                DataColumn dcSeriesName = ChartDataTable.Columns["SeriesName"];

                if (dcSeriesName == null)
                {
                    ChartDataTable.Columns.Add("SeriesName");
                }

                _numberOfColumnsInChartDataTable = 0;
                _numberOfRowsInChartDataTable = 0;
                SPView oView = null;
                try
                {
                    oTopList = SPContext.Current.Web.Lists[PropChartSelectedList];
                    oView = oTopList.Views[PropChartSelectedView];
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
                if (oView != null)
                {
                    var docQuery = new XmlDocument();
                    docQuery.LoadXml("<Query>" + oView.Query + "</Query>");
                    try
                    {
                        XmlNode ndGroupBy = docQuery.SelectSingleNode("//GroupBy");
                        if (ndGroupBy != null) docQuery.FirstChild.RemoveChild(ndGroupBy);
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);

                    } // node doesn't exist
                    try
                    {
                        XmlNode ndOrderBy = docQuery.SelectSingleNode("//OrderBy");
                        if (ndOrderBy != null) docQuery.FirstChild.RemoveChild(ndOrderBy);
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);

                    } // node doesn't exist

                    oTopQuery = new SPQuery();
                    oTopQuery.Query = GetFilterQuery(oTopList, docQuery); // oView.Query;
                }

                // process this site
                SPSecurity.RunWithElevatedPrivileges(
                    delegate
                    {
                        using (SPWeb web = SPContext.Current.Site.OpenWeb())
                        {
                            GetSiteDataUsingSPSiteDataQuery(web);
                        }
                    });

                // process any sites configured in the chart web part settings
                if (PropChartRollupSites.Length > 0)
                {
                    string[] arSites = PropChartRollupSites.ToArray();

                    foreach (string sSite in arSites)
                    {
                        if (sSite.Trim().Length > 0)
                        {
                            try
                            {
                                SPSecurity.RunWithElevatedPrivileges(
                                    delegate
                                    {
                                        using (var site = new SPSite(sSite))
                                        {
                                            using (SPWeb webCurr = site.OpenWeb())
                                            {
                                                if (webCurr.Url.ToLower() == sSite)
                                                {
                                                    GetSiteDataUsingSPSiteDataQuery(webCurr);
                                                }
                                            }
                                        }
                                    });
                            }
                            catch (Exception ex)
                            {
                                HandleException(ex);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);

            }
        }

        /// <summary>
        /// GetSiteDataUsingSPSiteDataQuery - RUN WITH ELEVATED PRIVILEDGES
        /// </summary>
        /// <param name="web"></param>
        private void GetSiteDataUsingSPSiteDataQuery(SPWeb web)
        {
            SPSite s = SPContext.Current.Site;
            SPWeb w = SPContext.Current.Web;
            try
            {
                string dbCon =
                    s.ContentDatabase.DatabaseConnectionString;
                var cn = new SqlConnection(dbCon);
                cn.Open();

                string siteurl = w.ServerRelativeUrl.Substring(1);

                string[] rolluplists = PropChartRollupLists.ToArray();

                //TODO: This little section is for when they didn't elect to have rollup lists. This will stick the one selected list into the array to use. Refactor this.
                bool hasRollupLists = true;
                var selectedList = w.Lists[PropChartSelectedList];
                if (rolluplists[0] == "")
                {
                    hasRollupLists = false;
                    rolluplists[0] = selectedList.Title;
                }

                string lists = "";


                foreach (string list in rolluplists)
                {
                    if (hasRollupLists)
                    {
                        string query = "";
                        if (siteurl == "")
                            query =
                                "SELECT     dbo.AllLists.tp_ID FROM         dbo.Webs INNER JOIN dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId WHERE     webs.siteid='" +
                                web.Site.ID +
                                "' AND (dbo.AllLists.tp_Title like '" +
                                list.Replace("'", "''") + "')";
                        else
                            query =
                                "SELECT     dbo.AllLists.tp_ID FROM         dbo.Webs INNER JOIN dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId WHERE     (dbo.Webs.FullUrl LIKE '" +
                                siteurl + "/%' OR dbo.Webs.FullUrl = '" +
                                siteurl +
                                "') AND (dbo.AllLists.tp_Title like '" +
                                list.Replace("'", "''") + "')";

                        var cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@list", list);
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            lists += "<List ID='" + dr.GetGuid(0) + "'/>";
                        }

                        dr.Close();
                    }
                    else
                    {
                        lists = "<List ID='" + selectedList.ID + "'/>";
                    }

                    var dq = new SPSiteDataQuery();

                    dq.Lists = "<Lists>" + lists + "</Lists>";

                    dq.Query = oTopQuery.Query.Replace("<Query>", "").Replace("</Query>", ""); //get from current view
                    dq.Webs = "<Webs Scope='Recursive'/>";

                    string sYFields = "";
                    for (int iSeries = 0; iSeries < GetYFields().Length; iSeries++)
                    {
                        string sSeriesName = GetYFields()[iSeries];
                        sYFields += "<FieldRef Name='" + sSeriesName + "' Nullable='TRUE'/>";
                    }

                    if (IsBubbleChart())
                    {
                        dq.ViewFields = "<FieldRef Name='" + PropChartXaxisField + "' Nullable='TRUE'/>" +
                                        sYFields +
                                        "<FieldRef Name='" + PropChartZaxisField + "' Nullable='TRUE'/>" +
                                        "<FieldRef Name='" + PropBubbleChartColorField + "' Nullable='TRUE'/>" +
                                        "<FieldRef Name='Title' Nullable='TRUE'/>";
                    }
                    else
                    {
                        if (!PropChartZaxisField.Contains("None Selected"))
                        {
                            dq.ViewFields = "<FieldRef Name='" +
                                            PropChartXaxisField +
                                            "' Nullable='TRUE'/>" +
                                            "<FieldRef Name='" +
                                            PropChartZaxisField +
                                            "' Nullable='TRUE'/>" +
                                            sYFields;
                        }
                        else
                        {
                            dq.ViewFields = "<FieldRef Name='" + PropChartXaxisField + "' Nullable='TRUE'/>" +
                                            sYFields;
                        }

                    }

                    dtSPSiteDataQueryData = new DataTable("SiteDataQueryData");

                    AppendLookupQueryIfApplicable(dq);

                    dtSPSiteDataQueryData = web.GetSiteData(dq);

                    ConvertEmptySiteQueryDataToNoValue();

                    ProcessSiteQueryData(list);

                }
                cn.Close();
            }
            catch (Exception ex)
            {
                HandleException(ex);

            }
        }

        private void AppendLookupQueryIfApplicable(SPSiteDataQuery dq)
        {
            if (!IsLookupQuery()) return;

            var queryXml = new XmlDocument();
            queryXml.LoadXml(dq.Query);
            LookupFilterHelper.AppendLookupQueryToExistingQuery(ref queryXml, ChartLookupField, ChartLookupFieldList);
            dq.Query = queryXml.OuterXml;
        }

        private bool IsLookupQuery()
        {
            return !string.IsNullOrEmpty(ChartLookupField) && !string.IsNullOrEmpty(ChartLookupFieldList);
        }

        private void ConvertEmptySiteQueryDataToNoValue()
        {
            try
            {
                for (int x = 0; x < dtSPSiteDataQueryData.Rows.Count; x++)
                {
                    if (String.IsNullOrEmpty(dtSPSiteDataQueryData.Rows[x][3].ToString().Trim()))
                    {
                        dtSPSiteDataQueryData.Rows[x][3] = "No Value";
                    }
                    if (!PropChartZaxisField.Contains("None Selected") &&
                        String.IsNullOrEmpty(dtSPSiteDataQueryData.Rows[x][4].ToString().Trim()))
                    {
                        dtSPSiteDataQueryData.Rows[x][4] = "No Value";
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);

            }
        }

        private void ProcessSiteQueryData(string sListName)
        {
            const int xAxisColumnIndex = 3;
            const int zAxisFieldIndex = 4;

            try
            {
                var xAxisField = oTopList.Fields.GetFieldByInternalName(PropChartXaxisField);
                SPField zAxisField = null;

                if (!PropChartZaxisField.Contains("None Selected"))
                {
                    zAxisField = oTopList.Fields.GetFieldByInternalName(PropChartZaxisField);
                }

                AddZAxisRowToChartDataTable(xAxisColumnIndex, xAxisField);

                foreach (DataRow dr in dtSPSiteDataQueryData.Rows)
                {
                    var xAxisFieldValue = GetXaxisFieldValue(sListName, xAxisField, xAxisColumnIndex, dr);
                    var zAxisFieldValue = GetZaxisFieldValue(sListName, zAxisField, zAxisFieldIndex, dr);

                    var sYaxisFldVal = "";

                    AddXAxisColumnToChartDataTableIfDoesntExist(xAxisFieldValue);

                    switch (PropChartAggregationType.ToUpper())
                    {
                        case "COUNT":
                            if (PropChartZaxisField.Trim().Length != 0 && !PropChartZaxisField.Contains("None Selected"))
                            {
                                if (zAxisFieldValue.Trim() == "") zAxisFieldValue = "No Value";

                                if (SeriesExistsInChartDataTable(zAxisFieldValue))
                                {
                                    UpdateCellValue(zAxisFieldValue, xAxisFieldValue, zAxisFieldValue, PropChartAggregationType);
                                    _numberOfRowsInChartDataTable++;
                                }
                                else
                                {
                                    AddNewRowToChartDataTable(zAxisFieldValue);
                                    _numberOfRowsInChartDataTable++;
                                    UpdateCellValue(zAxisFieldValue, xAxisFieldValue, zAxisFieldValue, PropChartAggregationType);
                                }
                            }
                            else
                            {
                                if (xAxisField.InternalName.ToUpper() == "LIST")
                                {
                                    UpdateCellValue(xAxisField.Title, xAxisFieldValue, "1", "COUNT");
                                }
                                else
                                {
                                    UpdateCellValue(dtSPSiteDataQueryData.Columns[xAxisColumnIndex].ColumnName, xAxisFieldValue, "1", "COUNT");
                                }
                                _numberOfRowsInChartDataTable++;
                            }
                            break;
                        case "SUM":
                        case "AVG":
                            if (PropChartAggregationType.ToUpper() != "SUM" && (PropChartZaxisField.Trim() != "" && !PropChartZaxisField.Contains("None Selected")))
                            {
                                if (zAxisFieldValue.Trim().Length == 0) zAxisFieldValue = "No Value";

                                if (GetYFields().Length > 0)
                                {
                                    if (SeriesExistsInChartDataTable(zAxisFieldValue))
                                    {
                                        UpdateCellValue(zAxisFieldValue, xAxisFieldValue, sYaxisFldVal,
                                                        PropChartAggregationType);
                                        _numberOfRowsInChartDataTable++;
                                    }
                                    else
                                    {
                                        AddNewRowToChartDataTable(zAxisFieldValue);
                                        _numberOfRowsInChartDataTable++;
                                        UpdateCellValue(zAxisFieldValue, xAxisFieldValue, sYaxisFldVal,
                                                        PropChartAggregationType);
                                    }
                                }
                                else
                                {
                                    if (dtSPSiteDataQueryData.Columns.Count > 5)
                                    {
                                        if (
                                            SeriesExistsInChartDataTable(zAxisField.GetFieldValueAsText(dtSPSiteDataQueryData.Columns[5].ColumnName)))
                                        {
                                            UpdateCellValue(dtSPSiteDataQueryData.Columns[5].ColumnName, xAxisFieldValue,
                                                            zAxisFieldValue, PropChartAggregationType);
                                            _numberOfRowsInChartDataTable++;
                                        }
                                        else
                                        {
                                            AddNewRowToChartDataTable(dtSPSiteDataQueryData.Columns[5].ColumnName);
                                            _numberOfRowsInChartDataTable++;
                                            UpdateCellValue(dtSPSiteDataQueryData.Columns[5].ColumnName, xAxisFieldValue,
                                                            zAxisFieldValue, PropChartAggregationType);
                                        }
                                    }
                                    else
                                    {
                                        if (dtSPSiteDataQueryData.Columns[zAxisFieldIndex].ColumnName.ToUpper() == "LIST")
                                        {
                                            if (zAxisField != null)
                                            {
                                                if (SeriesExistsInChartDataTable(zAxisField.Title))
                                                {
                                                    UpdateCellValue(zAxisField.Title, xAxisFieldValue, zAxisFieldValue,
                                                                    PropChartAggregationType);
                                                    _numberOfRowsInChartDataTable++;
                                                }
                                                else
                                                {
                                                    AddNewRowToChartDataTable(zAxisField.Title);
                                                    _numberOfRowsInChartDataTable++;
                                                    UpdateCellValue(zAxisField.Title, xAxisFieldValue, zAxisFieldValue,
                                                                    PropChartAggregationType);
                                                }
                                            }
                                            else
                                            {
                                                if (SeriesExistsInChartDataTable("Work Type"))
                                                {
                                                    UpdateCellValue("Work Type", xAxisFieldValue, zAxisFieldValue,
                                                                    PropChartAggregationType);
                                                    _numberOfRowsInChartDataTable++;
                                                }
                                                else
                                                {
                                                    AddNewRowToChartDataTable("Work Type");
                                                    _numberOfRowsInChartDataTable++;
                                                    UpdateCellValue("Work Type", xAxisFieldValue, zAxisFieldValue,
                                                                    PropChartAggregationType);
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            if (GetYFields().Length > 0)
                            {
                                string sSeriesName;
                                int iStartCol;
                                if (!PropChartZaxisField.Contains("None Selected") && !IsBubbleChart())
                                {
                                    iStartCol = 5;
                                }
                                else
                                {
                                    iStartCol = 4;
                                }

                                SPField fldYaxis;

                                if (!IsBubbleChart())
                                {
                                    for (int iSeries = iStartCol; iSeries < dtSPSiteDataQueryData.Columns.Count; iSeries++)
                                    {
                                        string sFieldName = dtSPSiteDataQueryData.Columns[iSeries].ColumnName;
                                        fldYaxis = oTopList.Fields.GetFieldByInternalName(sFieldName);
                                        sSeriesName = fldYaxis.Title;
                                        sYaxisFldVal = dr.ItemArray[iSeries].ToString();
                                        if (sYaxisFldVal.Length > 0)
                                        {
                                            if (sYaxisFldVal.Contains(";#"))
                                            {
                                                sYaxisFldVal =
                                                    GetCleanNumberValue(
                                                        sYaxisFldVal.Substring(sYaxisFldVal.IndexOf(";#") + 2)).ToString
                                                        ();
                                            }
                                            if (GetFieldSchemaAttribValue(fldYaxis.SchemaXml, "Percentage").ToUpper() ==
                                                "TRUE")
                                            {
                                                try
                                                {
                                                    var flTempVal = double.Parse(sYaxisFldVal, providerEn);
                                                    flTempVal = flTempVal * 100;
                                                    sYaxisFldVal = flTempVal.ToString();
                                                }
                                                catch (Exception ex)
                                                {
                                                    HandleException(ex);

                                                }
                                            }
                                        }

                                        if (PropChartZaxisField.Trim().Length != 0 &&
                                            !PropChartZaxisField.Contains("None Selected"))
                                        {
                                            if (zAxisFieldValue.Trim().Length == 0) zAxisFieldValue = "No Value";

                                            if (SeriesExistsInChartDataTable(zAxisFieldValue))
                                            {
                                                UpdateCellValue(zAxisFieldValue, xAxisFieldValue, sYaxisFldVal,
                                                                PropChartAggregationType);
                                                _numberOfRowsInChartDataTable++;
                                            }
                                            else
                                            {
                                                //AddNewRowToChartDataTable(fldZaxis.GetFieldValueAsText(sZaxisFldVal));
                                                AddNewRowToChartDataTable(zAxisFieldValue);
                                                _numberOfRowsInChartDataTable++;
                                                UpdateCellValue(zAxisFieldValue, xAxisFieldValue, sYaxisFldVal,
                                                                PropChartAggregationType);
                                            }
                                        }
                                        else
                                        {
                                            if (SeriesExistsInChartDataTable(sSeriesName))
                                            {
                                                UpdateCellValue(sSeriesName, xAxisFieldValue, sYaxisFldVal,
                                                                PropChartAggregationType);
                                                _numberOfRowsInChartDataTable++;
                                            }
                                            else
                                            {
                                                AddNewRowToChartDataTable(sSeriesName);
                                                _numberOfRowsInChartDataTable++;
                                                UpdateCellValue(sSeriesName, xAxisFieldValue, sYaxisFldVal,
                                                                PropChartAggregationType);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    string sFieldName = dtSPSiteDataQueryData.Columns[iStartCol].ColumnName;
                                    fldYaxis = oTopList.Fields.GetFieldByInternalName(sFieldName);
                                    sSeriesName = fldYaxis.Title;
                                    sYaxisFldVal = dr.ItemArray[iStartCol].ToString();
                                    if (sYaxisFldVal.Length > 0)
                                    {
                                        if (sYaxisFldVal.Contains(";#"))
                                        {
                                            sYaxisFldVal =
                                                GetCleanNumberValue(
                                                    sYaxisFldVal.Substring(sYaxisFldVal.IndexOf(";#") + 2)).ToString
                                                    ();
                                        }
                                        if (GetFieldSchemaAttribValue(fldYaxis.SchemaXml, "Percentage").ToUpper() ==
                                            "TRUE")
                                        {
                                            try
                                            {
                                                var flTempVal = double.Parse(sYaxisFldVal, providerEn);
                                                flTempVal = flTempVal * 100;
                                                sYaxisFldVal = flTempVal.ToString();
                                            }
                                            catch (Exception ex)
                                            {
                                                HandleException(ex);

                                            }
                                        }
                                    }

                                    if (PropChartZaxisField.Trim().Length != 0 &&
                                        !PropChartZaxisField.Contains("None Selected"))
                                    {
                                        if (zAxisFieldValue.Trim().Length == 0) zAxisFieldValue = "No Value";

                                        if (SeriesExistsInChartDataTable(zAxisFieldValue))
                                        {
                                            UpdateCellValue(zAxisFieldValue, xAxisFieldValue, sYaxisFldVal,
                                                            PropChartAggregationType);
                                            _numberOfRowsInChartDataTable++;
                                        }
                                        else
                                        {
                                            //AddNewRowToChartDataTable(fldZaxis.GetFieldValueAsText(sZaxisFldVal));
                                            AddNewRowToChartDataTable(zAxisFieldValue);
                                            _numberOfRowsInChartDataTable++;
                                            UpdateCellValue(zAxisFieldValue, xAxisFieldValue, sYaxisFldVal,
                                                            PropChartAggregationType);
                                        }
                                    }
                                    else
                                    {
                                        if (SeriesExistsInChartDataTable(sSeriesName))
                                        {
                                            UpdateCellValue(sSeriesName, xAxisFieldValue, sYaxisFldVal,
                                                            PropChartAggregationType);
                                            _numberOfRowsInChartDataTable++;
                                        }
                                        else
                                        {
                                            AddNewRowToChartDataTable(sSeriesName);
                                            _numberOfRowsInChartDataTable++;
                                            UpdateCellValue(sSeriesName, xAxisFieldValue, sYaxisFldVal,
                                                            PropChartAggregationType);
                                        }
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);

            }
        }

        private void AddXAxisColumnToChartDataTableIfDoesntExist(string xAxisFieldValue)
        {
            DataColumn dc = ChartDataTable.Columns[xAxisFieldValue];
            if (dc == null)
            {
                ChartDataTable.Columns.Add(xAxisFieldValue);
                _numberOfColumnsInChartDataTable++;
            }
        }

        private void AddZAxisRowToChartDataTable(int xAxisColumnIndex, SPField xAxisField)
        {
            if ((String.IsNullOrEmpty(PropChartZaxisField.Trim()) || PropChartZaxisField.Contains("None Selected")) &&
                PropChartAggregationType.ToUpper() == "COUNT")
            {
                if (xAxisField.InternalName.ToUpper() == "LIST")
                {
                    if (!SeriesExistsInChartDataTable(xAxisField.Title))
                    {
                        AddNewRowToChartDataTable(xAxisField.Title);
                    }
                }
                else
                {
                    AddNewRowToChartDataTable(dtSPSiteDataQueryData.Columns[xAxisColumnIndex].ColumnName);
                }

                _numberOfRowsInChartDataTable++;
            }
        }

        private string GetZaxisFieldValue(string sListName, SPField zAxisField, int zAxisFieldIndex, DataRow dr)
        {
            var zAxisFieldValue = "";
            if (!String.IsNullOrEmpty(PropChartZaxisField.Trim()) && !PropChartZaxisField.Contains("None Selected") &&
                dr.ItemArray.Length > zAxisFieldIndex)
            {
                zAxisFieldValue = dr.ItemArray[zAxisFieldIndex].ToString();
                if (zAxisField != null && zAxisField.InternalName.ToUpper() == "LIST")
                {
                    zAxisFieldValue = sListName;
                }
                else if (zAxisFieldValue.Length > 0 && zAxisFieldValue != "No Value")
                {
                    if (zAxisField != null)
                    {
                        if (zAxisFieldValue.Contains(";#"))
                        {
                            zAxisFieldValue = zAxisFieldValue.Substring(zAxisFieldValue.IndexOf(";#") + 2);

                            if (IsBubbleChart())
                            {
                                zAxisFieldValue = GetCleanNumberValue(zAxisFieldValue).ToString();
                            }
                        }

                        //zAxisFieldValue = zAxisField.GetFieldValueForEdit(zAxisFieldValue);
                    }
                }

                //zAxisFieldValue = GetCleanNumberValue(zAxisFieldValue).ToString();
            }
            return zAxisFieldValue;
        }

        private string GetXaxisFieldValue(string sListName, SPField xAxisField, int xAxisColumnIndex, DataRow dr)
        {
            var xAxisFieldValue = dr.ItemArray[xAxisColumnIndex].ToString();
            if (xAxisField.InternalName.ToUpper() == "LIST")
            {
                xAxisFieldValue = sListName;
            }
            else if (xAxisFieldValue.Length > 0 && xAxisFieldValue != "No Value")
            {
                xAxisFieldValue = xAxisField.GetFieldValueForEdit(xAxisFieldValue);
            }
            if (xAxisFieldValue.Contains(";#"))
            {
                xAxisFieldValue = GetCleanNumberValue(xAxisFieldValue.Substring(xAxisFieldValue.IndexOf(";#") + 2)).ToString();
            }
            return xAxisFieldValue;
        }

        private string GetFilterQuery(SPList list, XmlDocument originalQuery)
        {
            if (ThisChartIsTiedToAReportFilter())
            {
                UpdateTheOriginalQueryToAlsoFilterTitles(list, ref originalQuery);
            }

            return originalQuery.InnerXml;
        }

        private string UpdateTheOriginalQueryToAlsoFilterTitles(SPList list, ref XmlDocument originalQuery)
        {
            var titleFilterQueryService = new TitleFilterQueryService();
            titleFilterQueryService.MergeExistingQueryWithTitleQuery(list, _reportFilterGuid, ref originalQuery);

            return originalQuery.InnerXml;
        }

        private bool ThisChartIsTiedToAReportFilter()
        {
            return _reportFilterGuid != Guid.Empty;
        }

        public void DataBindChart()
        {
            LoadChartDataUsingSPSiteDataQuery();

            TraceHeader();

            try
            {
                if (_numberOfColumnsInChartDataTable > 0 && _numberOfRowsInChartDataTable > 0) // has data points
                {
                    if (IsBubbleChart())
                    {
                        Series.AddRange(BuildSeriesArrayForBubbleChart());
                    }
                    else
                    {
                        int iCol = 0;
                        var x = new String[_numberOfColumnsInChartDataTable];
                        foreach (DataColumn col in ChartDataTable.Columns)
                        {
                            if (col.ColumnName != "SeriesName")
                            {
                                x[iCol] = col.ColumnName;
                                iCol++;
                            }
                        }

                        DataView v = ChartDataTable.DefaultView;
                        v.Sort = "[" + ChartDataTable.Columns[0].ColumnName + "] desc";
                        ChartDataTable = v.ToTable();

                        switch (PropChartAggregationType.ToUpper())
                        {
                            case "COUNT":
                                if ((PropChartZaxisField.Trim() == "" || PropChartZaxisField.Contains("None Selected")) &&
                                    _numberOfRowsInChartDataTable > 1)
                                {
                                    foreach (DataRow dr in ChartDataTable.Rows)
                                    {
                                        AddChartSeries(dr["SeriesName"].ToString(), PropChartAggregationType, ChartDataTable.Rows.Count, 0, false, false);
                                    }
                                }
                                else
                                {
                                    foreach (DataRow dr in ChartDataTable.Rows)
                                    {
                                        AddChartSeries(dr["SeriesName"].ToString(), PropChartAggregationType, ChartDataTable.Rows.Count, 0, false, false);
                                    }
                                }
                                break;
                            case "SUM":
                            case "AVG":
                                if ((String.IsNullOrEmpty(PropChartZaxisField.Trim()) ||
                                     PropChartZaxisField.Contains("None Selected")) && _numberOfRowsInChartDataTable > 1)
                                {
                                    foreach (DataRow dr in ChartDataTable.Rows)
                                    {
                                        AddChartSeries(dr["SeriesName"].ToString(), PropChartAggregationType, ChartDataTable.Rows.Count, 0, false, true);
                                    }
                                }
                                else
                                {
                                    foreach (DataRow dr in ChartDataTable.Rows)
                                    {
                                        AddChartSeries(dr["SeriesName"].ToString(), PropChartAggregationType, ChartDataTable.Rows.Count, 0, false, true);
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                else // no data points - show msg
                {

                    PropChartTitle = "There are no results to show in this chart.";
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);

            }
        }

        private void TraceHeader()
        {
            TraceOutput.AppendLine("*************************************");
            TraceOutput.AppendLine("_numberOfColumnsInChartDataTable: " + _numberOfColumnsInChartDataTable);
            TraceOutput.AppendLine("_numberOfRowsInChartDataTable: " + _numberOfRowsInChartDataTable);
            TraceOutput.AppendLine("ChartData");
            if (ChartDataTable == null)
                TraceOutput.AppendLine("Null");
            else
            {
                foreach (var column in ChartDataTable.Columns)
                {
                    TraceOutput.Append(column + " ");
                }
                TraceOutput.AppendLine();
                foreach (DataRow row in ChartDataTable.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        TraceOutput.Append(item + " ");
                    }
                    TraceOutput.AppendLine();
                }
            }
        }




        private bool AddChartSeries(string sSeriesName, string sAggregType, int iNumPoints, int iMarkerSizePoints, bool bHasIndependentYAxis, bool formatLabels)
        {
            try
            {
                Series.Add(BuildSeriesArray(sSeriesName, sAggregType));

                return true;
            }
            catch (Exception ex)
            {
                HandleException(ex);

                return false;
            }
        }

        //TODO: BuildSeries2 does the series building for a non bubble chart. Refactor so that its modular for all chart types.
        private IEnumerable<VfChartSeries> BuildSeriesArrayForBubbleChart()
        {
            var aggregate = EpmChartAggregateType.Sum;

            var hasZAxis = !PropChartZaxisField.Contains("None Selected");
            var hasZAxisColor = !PropBubbleChartColorField.Contains("None Selected");
            var zAxisFieldName = hasZAxis ? PropChartZaxisField : "";
            var bubbleChartColumnMapping = GetBubbleChartColumnMappings();

            var currentList = SPContext.Current.Web.Lists[PropChartSelectedList];
            SPField xAxisField = null;
            SPField yAxisField = null;
            SPField zAxisField = null;

            if (currentList != null)
            {
                xAxisField = currentList.Fields.GetFieldByInternalName(PropChartXaxisField);
                yAxisField = currentList.Fields.GetFieldByInternalName(PropChartYaxisField);
                zAxisField = currentList.Fields.GetFieldByInternalName(PropChartZaxisField);
            }

            var epmChartDataSeriesList = new EpmChartDataSeriesList(dtSPSiteDataQueryData, aggregate, xAxisField, yAxisField, zAxisField, hasZAxis, hasZAxisColor, bubbleChartColumnMapping);

            return EpmChartSeriesToVisifireChartSeriesMapper.GetVisifireChartSeries(epmChartDataSeriesList);
        }

        private BubbleChartAxisToColumnMapping GetBubbleChartColumnMappings()
        {
            //TODO: I know this is a disgusting algorithm. It was done in haste to accomodate the bubble chart needing 4 axis when all 4 may not be present in the chart data (i.e. several axis use the same column)
            var mappings = new BubbleChartAxisToColumnMapping();
            var numOfColumns = 1;

            mappings.XaxisColumnIndex = 0;

            if (PropChartYaxisField.ToLower().Trim() == PropChartXaxisField.ToLower().Trim())
            {
                mappings.YaxisColumnIndex = mappings.XaxisColumnIndex;
            }
            else
            {
                mappings.YaxisColumnIndex = 1;
                numOfColumns++;
            }

            if (PropChartZaxisField.ToLower().Trim() == PropChartXaxisField.ToLower().Trim())
            {
                mappings.ZaxisColumnIndex = mappings.XaxisColumnIndex;
            }
            else if (PropChartZaxisField.ToLower().Trim() == PropChartYaxisField.ToLower().Trim())
            {
                mappings.ZaxisColumnIndex = mappings.YaxisColumnIndex;
            }
            else
            {
                mappings.ZaxisColumnIndex = numOfColumns;
                numOfColumns++;
            }

            if (PropBubbleChartColorField.ToLower().Trim() == PropChartXaxisField.ToLower().Trim())
            {
                mappings.ZaxisColorColumnIndex = mappings.XaxisColumnIndex;
            }
            else if (PropBubbleChartColorField.ToLower().Trim() == PropChartYaxisField.ToLower().Trim())
            {
                mappings.ZaxisColorColumnIndex = mappings.YaxisColumnIndex;
            }
            else if (PropBubbleChartColorField.ToLower().Trim() == PropChartZaxisField.ToLower().Trim())
            {
                mappings.ZaxisColorColumnIndex = mappings.ZaxisColumnIndex;
            }
            else
            {
                mappings.ZaxisColorColumnIndex = numOfColumns;
            }

            return mappings;
        }

        private VfChartSeries BuildSeriesArray(string sSeriesName, string sAggregType)
        {
            DataRow[] drArr = ChartDataTable.Select("SeriesName = '" + sSeriesName + "'");
            var srs = new VfChartSeries(sSeriesName);
            if (drArr != null)
            {
                for (int x = 0; x < (drArr[0].ItemArray.Length - 1); x++)
                {
                    if (sAggregType.ToUpper() == "AVG")
                    {
                        if (String.IsNullOrEmpty(drArr[0][x + 1].ToString().Trim()))
                        {
                            srs.AddItem(ChartDataTable.Columns[x + 1].ColumnName, 0, 0);
                        }
                        else
                        {
                            string[] sValArr = drArr[0][x + 1].ToString().Split(',');
                            int iNumVals = sValArr.Length;
                            var fTot = 0D;
                            foreach (string sVal in sValArr)
                            {
                                fTot = fTot + double.Parse(sVal, providerEn);
                            }

                            srs.AddItem(ChartDataTable.Columns[x + 1].ColumnName, fTot / iNumVals, 0);
                        }
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(drArr[0][x + 1].ToString().Trim()))
                        {
                            srs.AddItem(ChartDataTable.Columns[x + 1].ColumnName, 0, 0);
                        }
                        else
                        {
                            srs.AddItem(ChartDataTable.Columns[x + 1].ColumnName, Convert.ToDouble(drArr[0][x + 1]), 0);
                        }
                    }
                }
            }

            return srs;
        }

        private bool IsBubbleChart()
        {
            return PropChartMainStyleSafe.ToLower() == "bubble";
        }

        private double GetCleanNumberValue(string toString)
        {
            var cleanString = toString.Replace("$", "").Replace("%", "");

            return ChartHelper.ParseDouble(cleanString, providerEn, EpmChartAggregateType.GetByName(PropChartAggregationType));
        }


        private bool SeriesExistsInChartDataTable(string sName)
        {
            if (IsBubbleChart()) return false;

            DataRow[] drArr = ChartDataTable.Select("SeriesName = '" + sName + "'");

            return drArr.Length > 0;
        }

        private bool AddNewRowToChartDataTable(string sColVal)
        {
            DataRow drNew = ChartDataTable.NewRow();
            drNew["SeriesName"] = sColVal;
            ChartDataTable.Rows.Add(drNew);
            return true;
        }

        private bool UpdateCellValue(string sRowName, string sColName, string sColVal, string sAggregType)
        {
            try
            {
                DataRow[] drArr = ChartDataTable.Select("SeriesName = '" + sRowName + "'");

                if (drArr != null)
                {
                    double dCurrVal = 0;
                    if (drArr[0][sColName].ToString().Trim() != "")
                    {
                        try
                        {
                            dCurrVal = Convert.ToDouble(drArr[0][sColName]);
                        }
                        catch (Exception ex)
                        {
                            HandleException(ex);

                        }
                    }

                    if (sColVal.Contains("%"))
                    {
                        sColVal = sColVal.Replace("%", "");
                        sColVal = sColVal.Trim();
                    }
                    if (String.IsNullOrEmpty(sColVal.Trim()))
                    {
                        sColVal = "0";
                    }

                    double dNewval;
                    if (sAggregType.ToUpper() == "COUNT")
                    {
                        dCurrVal += 1;
                        drArr[0][sColName] = dCurrVal;
                    }
                    else if (sAggregType.ToUpper() == "PCT")
                    {
                        dCurrVal += 1;
                        drArr[0][sColName] = dCurrVal;
                    }
                    else if (sAggregType.ToUpper() == "SUM")
                    {
                        dNewval = dCurrVal + double.Parse(sColVal, providerEn);
                        drArr[0][sColName] = dNewval;
                    }
                    else if (sAggregType.ToUpper() == "AVG")
                    {
                        string sCurrVal = drArr[0][sColName].ToString();
                        if (sCurrVal.Trim() == "")
                        {
                            drArr[0][sColName] = sColVal;
                        }
                        else
                        {
                            drArr[0][sColName] = sCurrVal + "," + sColVal;
                        }
                    }

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return false;
            }
        }

        /* STATIC METHODS */

        internal static string GetFieldSchemaAttribValue(string sStringToSearch, string sAttribName)
        {
            string sAttribVal = "";
            int iFindPos = sStringToSearch.ToUpper().IndexOf(sAttribName.ToUpper() + "=");
            int iSubStrStart = iFindPos + sAttribName.Length + 2;
            int iSubStrEnd = sStringToSearch.IndexOf("\"", iSubStrStart);
            sAttribVal = sStringToSearch.Substring(iSubStrStart, iSubStrEnd - iSubStrStart);
            return sAttribVal;
        }


    }
}