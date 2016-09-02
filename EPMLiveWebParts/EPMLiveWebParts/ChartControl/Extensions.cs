using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPMLiveWebParts
{
    public static class Extensions
    {
        public static string Delimit(this string value)
        {
            return value.Replace("\r\n", "\n").Replace('\n', VfChart.Separator).Replace(',', VfChart.Separator).Replace
                (';', VfChart.Separator).Trim();
        }
        public static string UnDelimit(this string value)
        {
            return value.Replace(VfChart.Separator.ToString(), Environment.NewLine).Trim();
        }
        public static string[] ToArray(this string value)
        {
            return value.Trim().Split(VfChart.Separator);
        }

        public static void Add(this StringBuilder sb, string formatString, params object[] args )
        {
            sb.Append(string.Format(formatString, args) + "\n");
        }
    }
}
