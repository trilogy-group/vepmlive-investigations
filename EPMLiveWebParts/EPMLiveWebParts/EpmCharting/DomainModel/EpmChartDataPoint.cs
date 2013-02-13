using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace EPMLiveWebParts.EpmCharting.DomainModel
{
    public class EpmChartDataPoint
    {
        public string YAxisFieldName;
        public EpmChartAggregateType ChartAggregate { get; private set; }
        public Color DataPointColor { get; set; }
        public string Title { get; set; }
        public string LegendText { get; set; }
        public bool ShowInLegend { get; set; }
        public string XAxisLabel { get; set; }
        public string XAxisFieldName { get; set; }
        public double XAxisValue { get; set; }
        public string ZAxisLabel { get; set; }
        public string ZAxisFieldName { get; set; }
        public double ZAxisValue { get; set; }
        public string YAxisLabel { get; set; }
        public List<double> YAxisValuesRaw { get; private set; }
        public double YAxisValuesAggregated
        {
            get
            {
                if (ChartAggregate == EpmChartAggregateType.Sum)
                {
                    return YAxisValuesSummed();
                }

                if (ChartAggregate == EpmChartAggregateType.Average)
                {
                    return YAxisValuesAveraged();
                }

                return YAxisValuesCounted();
            }
        }

        public EpmChartDataPoint(EpmChartAggregateType chartAggregate)
        {
            ChartAggregate = chartAggregate;
            YAxisValuesRaw = new List<double>();            
        }
        
        public void AddYAxisValue(double value)
        {
            YAxisValuesRaw.Add(value);
        }

        private double YAxisValuesSummed()
        {
            return YAxisValuesRaw.Sum();
        }

        private double YAxisValuesAveraged()
        {
            return YAxisValuesRaw.Average();
        }

        private double YAxisValuesCounted()
        {
            return YAxisValuesRaw.Count();
        }
    }
}