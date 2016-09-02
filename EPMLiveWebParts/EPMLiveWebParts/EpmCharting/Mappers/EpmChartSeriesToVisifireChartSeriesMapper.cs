using System.Collections.Generic;
using EPMLiveWebParts.EpmCharting.DomainModel;

namespace EPMLiveWebParts.EpmCharting.Mappers
{
    public static class EpmChartSeriesToVisifireChartSeriesMapper
    {
        public static List<VfChartSeries> GetVisifireChartSeries(EpmChartDataSeriesList chartDataSeries)
        {
            var visifireChartSeriesList = new List<VfChartSeries>();

            foreach (var dataSeries in chartDataSeries)
            {
                // Setting null or empty to "No Value" otherwise it will be rendered as "Dataset0" by Visifire.
                var seriesName = string.IsNullOrEmpty(dataSeries.SeriesName) ? "No Value" : dataSeries.SeriesName;

                var visifireChartSeries = new VfChartSeries(seriesName);

                foreach (var dataPoint in dataSeries.ChartDataPoints)
                {
                    var visifireDataPoint = new VfPoint(dataPoint.XAxisLabel, dataPoint.YAxisValuesAggregated, dataPoint.ZAxisValue);
                    visifireDataPoint.DataPointColor = dataPoint.DataPointColor;
                    visifireDataPoint.ShowInLegend = dataPoint.ShowInLegend;
                    visifireDataPoint.LegendText = dataPoint.LegendText;
                    visifireDataPoint.Title = dataPoint.Title;
                    visifireDataPoint.XAxisValue = dataPoint.XAxisValue;
                    visifireDataPoint.XAxisLabel = dataPoint.XAxisLabel;
                    visifireDataPoint.XAxisFieldName = dataPoint.XAxisFieldName;
                    visifireDataPoint.ZAxisFieldName = dataPoint.ZAxisFieldName;
                    visifireDataPoint.YAxisFieldName = dataPoint.YAxisFieldName;
                    visifireDataPoint.YAxisLabel = dataPoint.YAxisLabel;
                    visifireDataPoint.ZAxisLabel = dataPoint.ZAxisLabel;
                    visifireChartSeries.Add(visifireDataPoint);
                }

                visifireChartSeriesList.Add(visifireChartSeries);
            }

            return visifireChartSeriesList;
        }
    }
}