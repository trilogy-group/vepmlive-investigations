namespace EPMLiveWebParts.EpmCharting.DomainModel
{
    public class EpmChartYaxisFormat
    {
        public static EpmChartYaxisFormat Currency = new EpmChartYaxisFormat {Name = "Currency", Description="Format Y Axis values as Currency."};
        public static EpmChartYaxisFormat Percent = new EpmChartYaxisFormat { Name = "Percent", Description = "Format Y Axis values as Percent." };
        public static EpmChartYaxisFormat None = new EpmChartYaxisFormat {Name = "None", Description = "No formatting."};
        
        public string Name { get; set; }
        public string Description { get; set; }

        private EpmChartYaxisFormat(){}

        public static EpmChartYaxisFormat GetByName(string name)
        {
            switch (name.ToLower().Trim())
            {
                case "currency":
                    return Currency;
                case "percent":
                    return Percent;
                default:
                    return None;
            }
        }
    }
}