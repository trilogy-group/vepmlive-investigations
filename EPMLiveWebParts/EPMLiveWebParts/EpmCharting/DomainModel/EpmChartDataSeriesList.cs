using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using EPMLiveWebParts.EpmCharting.DomainServices;
using Microsoft.SharePoint;

namespace EPMLiveWebParts.EpmCharting.DomainModel
{
    //NOTE: This class is currently just used for the Bubble Chart. The goal however is to use this for all chart types once the charting logic can be refactored.
    public class EpmChartDataSeriesList : List<EpmChartDataSeries>
    {
        readonly NumberFormatInfo _englishNumberFormat = new NumberFormatInfo();
        
        public EpmChartDataSeriesList(DataTable chartData, EpmChartAggregateType aggregateType, SPField xAxisField, SPField yAxisField, SPField zAxisField, bool hasZAxis, bool hasZIndexColor, BubbleChartAxisToColumnMapping columnMappings)
        {
            _englishNumberFormat.NumberDecimalSeparator = ".";
            _englishNumberFormat.NumberGroupSeparator = ",";
            _englishNumberFormat.NumberGroupSizes = new int[] { 3 };
            
            //TODO: Ditch the data table and create a repository so we can have it hydrate this class.
            HydrateChartSeriesList(chartData, aggregateType, xAxisField, yAxisField, zAxisField, hasZAxis, hasZIndexColor, columnMappings);
        }

        private void HydrateChartSeriesList(DataTable originalChartData, EpmChartAggregateType aggregateType, SPField xAxisField, SPField yAxisField, SPField zAxisField, bool hasZAxis, bool hasZAxisColor, BubbleChartAxisToColumnMapping columnMappings)
        {
            var colorsAlreadyInLegend = new List<Color>();
            
            var chartData = originalChartData.Copy();
            RemoveUnusedChartDataColumns(chartData);

            var xAxisColumn = chartData.Columns[columnMappings.XaxisColumnIndex];
            var yAxisColumn = chartData.Columns[columnMappings.YaxisColumnIndex];
            var titleColumn = chartData.Columns[chartData.Columns.Count - 1];
            
            var zAxisColumn = new DataColumn();
            if (hasZAxis)
            {
                zAxisColumn = chartData.Columns[columnMappings.ZaxisColumnIndex];
            }

            var zAxisColorColumn = chartData.Columns[columnMappings.ZaxisColorColumnIndex];

            var zAxisColorMap = GetZAxisColorMap(chartData, zAxisColorColumn);


            //TODO: Update this to not hardcode the series.
            const string hardcodingBubblechartForNow = "BubbleChart";
            var chartDataSeries = new EpmChartDataSeries(hardcodingBubblechartForNow);
            
            foreach (DataRow row in chartData.Rows)
            {
                var zAxisColorFieldValue = "";
                if (hasZAxisColor)
                {
                    zAxisColorFieldValue = row[zAxisColorColumn].ToString();
                }

                var chartDataPoint = new EpmChartDataPoint(aggregateType);
                chartDataPoint.Title = row[titleColumn].ToString();
                chartDataPoint.XAxisLabel = ParseValue(xAxisColumn.ColumnName);
                chartDataPoint.XAxisValue = ChartHelper.ParseDouble(ParseValue(row[xAxisColumn].ToString()), _englishNumberFormat, aggregateType, FieldIsPercentage(xAxisField));
                chartDataPoint.XAxisFieldName = xAxisField.InternalName;
                chartDataPoint.YAxisFieldName = yAxisField.InternalName;
                chartDataPoint.ZAxisFieldName = zAxisField.InternalName;
                chartDataPoint.LegendText = zAxisColorFieldValue == "" ? "No Value" : zAxisColorFieldValue;
                chartDataPoint.ZAxisValue = ChartHelper.ParseDouble(ParseValue(row[zAxisColumn].ToString()), _englishNumberFormat, aggregateType, FieldIsPercentage(zAxisField));
                chartDataPoint.AddYAxisValue(ChartHelper.ParseDouble(ParseValue(row[yAxisColumn].ToString()), _englishNumberFormat, aggregateType, FieldIsPercentage(yAxisField)));

                //Only show one of each color in the legend.
                if (hasZAxisColor)
                {
                    if (zAxisColorMap.ContainsKey(zAxisColorFieldValue))
                    {
                        chartDataPoint.DataPointColor = zAxisColorMap[zAxisColorFieldValue];
                
                        if (!colorsAlreadyInLegend.Contains(chartDataPoint.DataPointColor))
                        {
                            chartDataPoint.ShowInLegend = true;
                            colorsAlreadyInLegend.Add(chartDataPoint.DataPointColor);
                        }
                        else
                        {
                            chartDataPoint.ShowInLegend = false;
                        }
                    }
                }
                else
                {
                    chartDataPoint.DataPointColor = HtmlColorService.GetRandomHtmlColor();
                }

                chartDataSeries.AddDataPoint(chartDataPoint);
            }

            //NOTE: This is to set the zindex of the bubbles, but visifire doesnt support it on datapoints, only dataseries. So, we just need to order by ZAxis descending so smaller bubbles land on top.
            chartDataSeries.OrderDataPointsSoSmallerBubblesAreInFront(); 
            Add(chartDataSeries);
        }

        private static bool FieldIsPercentage(SPField spfield)
        {
            return spfield.Type == SPFieldType.Number && ((SPFieldNumber) spfield).ShowAsPercentage;
        }

        private static Dictionary<string, Color> GetZAxisColorMap(DataTable chartData, DataColumn zAxisColorFieldColumn)
        {
            var zAxisColorMap = new Dictionary<string, Color>();
            var distinctZaxisColorFields = (from row in chartData.AsEnumerable()
                                            select row.Field<string>(zAxisColorFieldColumn)
                                           ).Distinct().ToList();

            var colorIndex = 1;

            foreach (var zAxisColorField in distinctZaxisColorFields)
            {
                var dataPointColor = HtmlColorService.GetPredefinedColorBasedOnIndex(colorIndex);
                zAxisColorMap.Add(zAxisColorField, dataPointColor);
                colorIndex++;
            }
            return zAxisColorMap;
        }

        private static void RemoveUnusedChartDataColumns(DataTable chartData)
        {
            var listIdColumn = chartData.Columns[0];
            var webIdColumn = chartData.Columns[1];
            var idColumn = chartData.Columns[2];
            chartData.Columns.Remove(listIdColumn);
            chartData.Columns.Remove(webIdColumn);
            chartData.Columns.Remove(idColumn);
        }

        private static string ParseValue(string valueToParse)
        {
            var returnValue = valueToParse;

            if (returnValue.Contains(";#"))
            {
                returnValue = valueToParse.Substring(returnValue.IndexOf(";#") + 2);
            }

            return returnValue;
        }
    }
}