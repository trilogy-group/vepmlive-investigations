namespace EPMLiveWebParts.ReportFiltering.DomainModel
{
    public class CamlComparisonOperator
    {
        public static CamlComparisonOperator In = new CamlComparisonOperator {OperatorName = "In", Operator = "In"};
        public static CamlComparisonOperator EqualTo = new CamlComparisonOperator {OperatorName = "Equal To", Operator = "Eq"};
        public static CamlComparisonOperator NotEqualTo = new CamlComparisonOperator {OperatorName = "Not Equal To", Operator = "Neq"};
        public static CamlComparisonOperator GreaterThan = new CamlComparisonOperator { OperatorName = "Greater Than", Operator = "Gt" };
        public static CamlComparisonOperator GreaterThanOrEqualTo = new CamlComparisonOperator { OperatorName = "Greater Than Or Equal To", Operator = "Geq" };
        public static CamlComparisonOperator LessThan = new CamlComparisonOperator {OperatorName = "Less Than", Operator = "Lt"};
        public static CamlComparisonOperator LessThanOrEqualTo = new CamlComparisonOperator {OperatorName = "Less Than Or Equal To", Operator = "Leq"};
        public static CamlComparisonOperator BeginsWith = new CamlComparisonOperator {OperatorName = "Begins With", Operator = "BeginsWith"};
        public static CamlComparisonOperator Contains = new CamlComparisonOperator {OperatorName = "Contains", Operator = "Contains"};
        public static CamlComparisonOperator DateRangesOverlap = new CamlComparisonOperator { OperatorName = "Date Ranges Overlap", Operator = "DateRangesOverlap" };
        public static CamlComparisonOperator Includes = new CamlComparisonOperator { OperatorName = "Includes", Operator = "Includes" };
        public static CamlComparisonOperator NotIncludes = new CamlComparisonOperator { OperatorName = "Not Includes", Operator = "NotIncludes" };
        public static CamlComparisonOperator IsNull = new CamlComparisonOperator { OperatorName = "Is Null", Operator = "IsNull" };
        public static CamlComparisonOperator IsNotNull = new CamlComparisonOperator { OperatorName = "Is Not Null", Operator = "IsNotNull" };
        public static CamlComparisonOperator Empty = new CamlComparisonOperator {OperatorName = string.Empty, Operator = string.Empty};
        
        public string OperatorName { get; set; }
        public string Operator { get; set; }

        private CamlComparisonOperator() {}

        public static CamlComparisonOperator GetCamlOperatorByValue(string value)
        {
            if (string.IsNullOrEmpty(value)) return Empty;

            switch (value.ToLower().Trim())
            {
                case "in":
                    return In;
                case "eq":
                    return EqualTo;
                case "neq":
                    return NotEqualTo;
                case "gt":
                    return GreaterThan;
                case "lt":
                    return LessThan;
                case "leq":
                    return LessThanOrEqualTo;
                case "geq":
                    return GreaterThanOrEqualTo;
                case "beginswith":
                    return BeginsWith;
                case "contains":
                    return Contains;
                case "daterangesoverlap":
                    return DateRangesOverlap;
                case "includes":
                    return Includes;
                case "notincludes":
                    return NotIncludes;
                case "isnull":
                    return IsNull;
                case "isnotnull":
                    return IsNotNull;
                default:
                    return Empty;
            }
        }
    }
}