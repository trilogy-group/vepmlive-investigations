using System.Collections.Generic;
using System.Linq;

namespace EPMLiveWebParts.EpmCharting.DomainModel
{
    public class EpmChartDataSeries
    {
        public string SeriesName { get; private set; }
        public List<EpmChartDataPoint> ChartDataPoints { get; private set; }

        public EpmChartDataSeries(string seriesName)
        {
            SeriesName = seriesName;
            ChartDataPoints = new List<EpmChartDataPoint>();
        }

        public void AddDataPoint(EpmChartDataPoint dataPoint)
        {
            ChartDataPoints.Add(dataPoint);
        }

        //TODO: This is bubble chart specific and should be in a different class, perhaps derived from this class. Consider a factory if there are enough variations.
        public void OrderDataPointsSoSmallerBubblesAreInFront()
        {
            ChartDataPoints = ChartDataPoints.OrderByDescending(z => z.ZAxisValue).ThenBy(x => x.XAxisValue).ToList();
        }
    }
}