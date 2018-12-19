using System;
using System.Collections.Generic;
using System.Text;
using EpmListDisplay = EPMLiveCore.ListDisplayUtils;

namespace WorkEnginePPM
{
    public class ListDisplayUtils
    {
        public static string ConvertToString(Dictionary<string, Dictionary<string, string>> data)
        {
            return EpmListDisplay.ConvertToString(data);
        }

        public static Dictionary<string, Dictionary<string, string>> ConvertFromString(string values)
        {
            return EpmListDisplay.ConvertFromString(values);
        }
    }
}
