using System;
using System.Globalization;
using System.Text;
using System.Xml;
using Microsoft.SharePoint;

namespace EPMLiveWebParts
{
    public class FormatHelper
    {
        internal static void FormatNumber(ref string val, XmlDocument fieldXml, string format, SPField spField, NumberFormatInfo numberFormatInfo, bool useFormatInfoOnString)
        {
            try
            {
                var decimals = int.Parse(fieldXml.ChildNodes[0].Attributes["Decimals"].Value);
                var stringBuilder = new StringBuilder(format);
                for (var j = 0; j < decimals; j++)
                {
                    stringBuilder.Append("0");
                }
                format = stringBuilder.ToString();
                format = format.Length > 0
                    ? $"#,##0.{format}"
                    : "#,##0";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("Exception Suppressed {0}", ex);
            }
            if (spField.SchemaXml.Contains("Percentage=\"TRUE\""))
            {
                var parsedValue = double.Parse(val, numberFormatInfo) * 100;
                val = useFormatInfoOnString
                    ? parsedValue.ToString(format, numberFormatInfo)
                    : parsedValue.ToString(format);
                val = $"{val}%";
            }
            else
            {
                try
                {
                    var parsedValue = double.Parse(val, numberFormatInfo);
                    val = useFormatInfoOnString
                        ? parsedValue.ToString(format, numberFormatInfo)
                        : parsedValue.ToString(format);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.TraceError("Exception Suppressed {0}", ex);
                }
            }
        }

        internal static void FormatDateTime(ref string val, string format, XmlDocument fieldXml)
        {
            if (DateTime.Parse(val).ToString() == DateTime.MaxValue.ToString()
                || DateTime.Parse(val).ToString() == DateTime.MinValue.ToString())
            {
                val = string.Empty;
            }
            else
            {
                try
                {
                    format = fieldXml.ChildNodes[0].Attributes["Format"].Value;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.TraceError("Exception Suppressed {0}", ex);
                }
                if (format == "DateOnly")
                {
                    val = DateTime.Parse(val).ToShortDateString();
                }
            }
        }

        internal static void FormatCurrency(ref string val, NumberFormatInfo numberFormatInfo)
        {
            var parsedValue = double.Parse(val, numberFormatInfo);
            val = parsedValue.ToString("c");
        }
    }
}