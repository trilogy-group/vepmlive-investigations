using System.Collections.Generic;
using System.Drawing;

namespace EPMLiveWebParts
{
    public class VfPoint
    {
        public string Title;
        public string XAxisLabel;
        public string XAxisFieldName;
        public double XAxisValue;
        public string YAxisLabel { get; set; }
        public string YAxisFieldName;
        public double YValue;
        public string ZAxisFieldName;
        public string ZAxisLabel { get; set; }
        public double ZValue;
        public bool ShowInLegend;
        public string LegendText;
        public Color DataPointColor;
        public string DataPointColorAsString
        {
            get
            {
                if (!DataPointColor.IsNamedColor)
                {
                    return "#" + DataPointColor.Name;
                }

                return DataPointColor.Name;
            }
        }

        public VfPoint(string xAxisLabel, double yValue, double zValue)
        {
            XAxisLabel = xAxisLabel;
            YValue = yValue;
            ZValue = zValue;
        }
    }

    public class VfChartSeries : List<VfPoint>
    {
        private readonly string _seriesName;

        public VfChartSeries(string seriesName)
        {
            _seriesName = seriesName;
        }

        public string SeriesName
        {
            get { return _seriesName; }
        }

        public string Format { get; set; }
        public string LegendColor { get; set; }

        public void AddItem(string xAxisLabel, double yValue, double zValue)
        {
            Add(new VfPoint(xAxisLabel, yValue, zValue));
        }

        public void AddItem(string xAxisLabel, double yValue, double zValue, Color dataPointColor)
        {
            var point = new VfPoint(xAxisLabel, yValue, zValue);
            point.DataPointColor = dataPointColor;
            Add(point);
        }


    }
}