using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostDataValues;

public abstract class DataCacheBase
{
    protected delegate bool DataItemAccessorDelegate(int key, out IDataItem value);

    protected static string FormatExtraDisplay<TDataItem>(
        string input, 
        int inputType,
        IDictionary<int, TDataItem> codesDictionary,
        IDictionary<int, TDataItem> resesDictionary,
        IDictionary<int, TDataItem> stagesDictionary) 
        
        where TDataItem : IDataItem
    {
        DateTime dateTimeInput;
        int intInput = 0;
        double doubleInput = 0;
        TDataItem dataItem;

        var isIntInput = int.TryParse(input, out intInput) && intInput > 0;
        var isDoubleInput = double.TryParse(input, out doubleInput) && doubleInput > 0;

        switch (inputType)
        {
            case 1:
                dateTimeInput = DateTime.MinValue;

                if (DateTime.TryParseExact(input, "yyyyMMdd", null, DateTimeStyles.None, out dateTimeInput)
                    || DateTime.TryParseExact(input, "yyyyMMddHHmm", null, DateTimeStyles.None, out dateTimeInput)
                    )
                {
                    if (dateTimeInput > DateTime.MinValue)
                        return dateTimeInput.ToString("MM/dd/yyyy");
                }
                break;
            case 2:
                if (isIntInput)
                {
                    return intInput.ToString();
                }
                break;
            case 3:
                if (isDoubleInput)
                {
                    return doubleInput.ToString();
                }
                break;
            case 11:
                if (isIntInput)
                {
                    return intInput.ToString("0%");
                }
                break;
            case 13:
                return isIntInput
                    ? "Yes"
                    : "No";
            case 6:
            case 9:
            case 19:
                return input;
            case 8:
                if (isDoubleInput)
                {
                    return doubleInput.ToString("$#,##0.00");
                }
                break;
            case 20:
                return FormatWork(doubleInput);
            case 23:
                return FormatDuration(doubleInput);
            case 4:
                if (codesDictionary.TryGetValue(intInput, out dataItem))
                {
                    return dataItem.Name;
                }
                break;
            case 7:
                if (resesDictionary.TryGetValue(intInput, out dataItem))
                {
                    return dataItem.Name;
                }
                break;
            case 9911:
                if (stagesDictionary.TryGetValue(intInput, out dataItem))
                {
                    return dataItem.Name;
                }
                break;
        }

        return string.Empty;
    }

    private static string FormatWork(double hours)
    {
        string s;
        double d;

        d = hours / 100;

        if (d < 0.005)
            return "";

        s = d.ToString("0.000");

        for (int i = 1; i <= 3; ++i)
        {
            if (s[s.Length] == '0')
                s = s.Substring(0, s.Length - 1);
        }

        if (s[s.Length] == '.')
            s = s.Substring(0, s.Length - 1);

        if (s == "0")
            return "";

        return s + " h";
    }

    private static string FormatDuration(double minutes)
    {
        string s;
        double d;


        if (minutes == 0)
            return "";


        d = minutes / (60 * 8 * 10);

        s = d.ToString("0.000");

        for (int i = 1; i <= 3; ++i)
        {
            if (s[s.Length] == '0')
                s = s.Substring(0, s.Length - 1);
        }

        if (s[s.Length] == '.')
            s = s.Substring(0, s.Length - 1);


        if (s == "0")
            return "";

        return s + " d";
    }
}