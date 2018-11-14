using System;
using System.Diagnostics;
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
                Trace.TraceError("Exception Suppressed {0}", ex);
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
                    Trace.TraceError("Exception Suppressed {0}", ex);
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
                    Trace.TraceError("Exception Suppressed {0}", ex);
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

        public static string GetFormat(SPField field, XmlDocument xmlDoc, SPWeb web, Func<NumberFormatInfo, string> setCurrencyFormatFunc, string numberFormat)
        {
            var format = string.Empty;

            switch (field.Type)
            {
                case SPFieldType.DateTime:
                    try
                    {
                        format = xmlDoc.FirstChild.Attributes["Format"].Value == "DateOnly"
                            ? CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
                            : CultureInfo.CurrentCulture.DateTimeFormat.FullDateTimePattern;
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                    }
                    break;
                case SPFieldType.Number:
                    if (xmlDoc.FirstChild.Attributes["Percentage"] != null
                        && xmlDoc.FirstChild.Attributes["Percentage"].Value.ToLower() == "true")
                    {
                        format = "0\\%;0\\%;0\\%";
                    }
                    else
                    {
                        var decCount = 0;
                        var decimals = string.Empty;
                        try
                        {
                            decCount = int.Parse(xmlDoc.FirstChild.Attributes["Decimals"].Value);
                        }
                        catch (Exception ex)
                        {
                            Trace.TraceError("Exception Suppressed {0}", ex);
                        }

                        var stringBuilder = new StringBuilder(decimals);
                        for (var i = 0; i < decCount; i++)
                        {
                            stringBuilder.Append("0");
                        }
                        decimals = stringBuilder.ToString();

                        if (decCount > 0)
                        {
                            decimals = $".{decimals}";
                        }

                        format = ",0" + decimals;
                    }
                    break;
                case SPFieldType.Currency:
                    var currency = (SPFieldCurrency)field;
                    var info = CultureInfo.GetCultureInfo(currency.CurrencyLocaleId).NumberFormat;
                    format = setCurrencyFormatFunc?.Invoke(info);
                    break;
                case SPFieldType.Calculated:
                    switch (xmlDoc.FirstChild.Attributes["ResultType"].Value)
                    {
                        case "Currency":
                            format = $"{web.Locale.NumberFormat.CurrencySymbol},0.00";
                            break;
                        case "Number":
                            if (xmlDoc.FirstChild.Attributes["Percentage"] != null
                                && xmlDoc.FirstChild.Attributes["Percentage"].Value.ToLower() == "true")
                            {
                                format = numberFormat;
                            }
                            else
                            {
                                var decCount = 0;
                                var decimals = string.Empty;
                                try
                                {
                                    decCount = int.Parse(xmlDoc.FirstChild.Attributes["Decimals"].Value);
                                }
                                catch (Exception ex)
                                {
                                    Trace.TraceError("Exception Suppressed {0}", ex);
                                }

                                var stringBuilder = new StringBuilder(decimals);
                                for (var i = 0; i < decCount; i++)
                                {
                                    stringBuilder.Append("0");
                                }
                                decimals = stringBuilder.ToString();

                                if (decCount > 0)
                                {
                                    decimals = $".{decimals}";
                                }

                                format = $",0{decimals}";
                            }
                            break;
                    }
                    break;
            }
            return format;
        }
    }
}