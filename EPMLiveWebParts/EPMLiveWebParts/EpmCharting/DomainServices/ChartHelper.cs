using System;
using EPMLiveWebParts.EpmCharting.DomainModel;
using Microsoft.SharePoint;

namespace EPMLiveWebParts.EpmCharting.DomainServices
{
    /// <summary>
    /// Helper class is only a place for methods that don't have a home in a class that makes sense for them.
    /// Move any of these methods if they fit properly elsewhere.
    /// </summary>
    public class ChartHelper
    {
       public static bool IsCalculateableSharepointField(SPField fld)
       {
           return fld.TypeAsString == "Currency" || fld.TypeAsString == "Number" || (fld.Type == SPFieldType.Calculated && EpmChart.GetFieldSchemaAttribValue(fld.SchemaXml, "ResultType") == "Number") || (fld.Type == SPFieldType.Calculated && EpmChart.GetFieldSchemaAttribValue(fld.SchemaXml, "ResultType") == "Currency");
       }

       public static double ParseDouble(string doubleAsString, IFormatProvider formatProvider, EpmChartAggregateType aggregateType)
       {
           return ParseDouble(doubleAsString, formatProvider, aggregateType, false);
       }
        
       public static double ParseDouble(string doubleAsString, IFormatProvider formatProvider, EpmChartAggregateType aggregateType, Boolean isCurrency)
       {
           var returnValue = 0D;

           try
           {
               if (aggregateType == EpmChartAggregateType.Average)
               {
                   returnValue = double.Parse(doubleAsString, formatProvider);
               }
               else
               {
                   returnValue = Convert.ToDouble(doubleAsString, formatProvider);
               }
           }
           catch (OverflowException)
           {
               // Don't do anything, the value couldn't be converted.
           }
           catch (FormatException)
           {
               // Don't do anything, the value couldn't be converted.
           }

           if (isCurrency) returnValue = Math.Round(returnValue * 100);

           return returnValue;
       }
    }
}