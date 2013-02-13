namespace EPMLiveWebParts.EpmCharting.DomainModel
{
    public class EpmChartAggregateType
    {
        public static EpmChartAggregateType Sum = new EpmChartAggregateType { Name = "SUM", Description = "Return a count of all Y values." };
        public static EpmChartAggregateType Average = new EpmChartAggregateType { Name = "AVG", Description = "Return an average of all Y values." };
        public static EpmChartAggregateType Count = new EpmChartAggregateType { Name = "COUNT", Description = "Return a count of all Y values." };
        public static EpmChartAggregateType None = new EpmChartAggregateType { Name = "None", Description = "No aggregate." };
        
        public string Name { get; set; }
        public string Description { get; set; }

        private EpmChartAggregateType(){}

        public static EpmChartAggregateType GetByName(string aggregateType)
        {
            switch (aggregateType.ToLower())
            {
                case "sum":
                    return Sum;
                case "average":
                    return Average;
                case "count":
                    return Count;
                default:
                    return None;
            }
        }
    }
}