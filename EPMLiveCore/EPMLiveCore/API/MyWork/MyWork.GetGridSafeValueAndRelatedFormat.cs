using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Linq;
using EPMLiveCore.Helpers;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public partial class MyWork
    {
        /// <summary>
        ///     Gets the grid safe value.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <returns></returns>
        private static string GetGridSafeValue(XElement field)
        {
            Guard.ArgumentIsNotNull(field, nameof(field));

            var value = Utils.GetCleanFieldValue(field);
            var name = field.Attribute(Name).Value;
            var format = field.Attribute(Format).Value;

            if (field.Attribute(Format).Value.Equals(Indicator))
            {
                value = $"/_layouts/images/{value}";
            }

            if (name.Equals(CommentCountField))
            {
                value = !string.IsNullOrWhiteSpace(value)
                    ? decimal.Truncate(Convert.ToDecimal(value, new CultureInfo(string.Empty)))
                       .ToString(CultureInfo.InvariantCulture)
                    : string.Empty;
            }

            if (name.Equals(Priority))
            {
                double priority;

                if (double.TryParse(value, out priority))
                {
                    value = $"{priority:0.##########}";
                }
            }
            else
            {
                value = GetFieldValue(field, value, format);
            }

            return value;
        }

        private static string GetFieldValue(XElement field, string value, string format)
        {
            Guard.ArgumentIsNotNull(field, nameof(field));

            var type = field.Attribute(Type).Value;

            if (type.Equals(Number))
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    var cultureInfo = new CultureInfo((int)SPContext.Current.RegionalSettings.LocaleId);

                    if (format.EndsWith(Percent))
                    {
                        try
                        {
                            value = (decimal.Parse(value) * 100).ToString(cultureInfo);
                        }
                        catch (Exception exception)
                        {
                            Trace.WriteLine(exception);
                        }
                    }

                    try
                    {
                        value = decimal.Parse(value, cultureInfo).ToString(CultureInfo.InvariantCulture);
                    }
                    catch (Exception exception)
                    {
                        Trace.WriteLine(exception);
                    }
                }
            }
            else if (type.Contains(Date))
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    try
                    {
                        value = DateTime.Parse(value).ToString(YearMonthDateFormat);
                    }
                    catch (Exception exception)
                    {
                        Trace.WriteLine(exception);
                    }
                }
            }

            return value;
        }

        /// <summary>
        ///     Gets the related grid format.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="format">The format.</param>
        /// <param name="spField">The sp field.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        internal static string GetRelatedGridFormat(string type, string format, SPField spField, SPWeb spWeb)
        {
            var currencyFormatDictionary = new Dictionary<int, string> { { 0, "$n" }, { 1, "n$" }, { 2, "$ n" }, { 3, "n $" } };

            switch (type)
            {
                case Float:

                    if (spField.Type == SPFieldType.Number)
                    {
                        var percentageSign = string.Empty;

                        if (((SPFieldNumber)spField).ShowAsPercentage)
                        {
                            percentageSign = @"\%";
                        }

                        switch (((SPFieldNumber)spField).DisplayFormat)
                        {
                            case SPNumberFormatTypes.Automatic:
                                return $",#0.##########{percentageSign}";
                            case SPNumberFormatTypes.NoDecimal:
                                return $",#0{percentageSign}";
                            case SPNumberFormatTypes.OneDecimal:
                                return $",#0.0{percentageSign}";
                            case SPNumberFormatTypes.TwoDecimals:
                                return $",#0.00{percentageSign}";
                            case SPNumberFormatTypes.ThreeDecimals:
                                return $",#0.000{percentageSign}";
                            case SPNumberFormatTypes.FourDecimals:
                                return $",#0.0000{percentageSign}";
                            case SPNumberFormatTypes.FiveDecimals:
                                return $",#0.00000{percentageSign}";
                            default:
                                Trace.WriteLine($"Unexpected value: {((SPFieldNumber)spField).DisplayFormat}");
                                break;
                        }
                    }
                    else if (spField.Type == SPFieldType.Currency)
                    {
                        var currencyCultureInfo = new CultureInfo(((SPFieldCurrency)spField).CurrencyLocaleId);
                        var numberFormatInfo = currencyCultureInfo.NumberFormat;

                        return currencyFormatDictionary[numberFormatInfo.CurrencyPositivePattern]
                           .Replace(DollarSign, numberFormatInfo.CurrencySymbol)
                           .Replace(
                                NField,
                                $"##,#.{new string('0', numberFormatInfo.CurrencyDecimalDigits)}");
                    }

                    return string.Empty;
                case Date:
                    var dateFormat = GetExampleDateFormat(spWeb, YearFormat, MField, DField);
                    return format.Equals(DateOnly)
                        ? dateFormat
                        : $"{dateFormat} h:mm tt";
                default:
                    return string.Empty;
            }
        }
    }
}