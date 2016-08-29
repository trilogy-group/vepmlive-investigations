using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportFiltering
{
    //TODO: These should be in core.
    public static class ListExtensions
    {
        public static string AsCommaSeparatedString(this IEnumerable<string> list)
        {
            return String.Join(",", list.Select(x => x.ToString()).ToArray());
        }

        public static void PopulateFromCommaSeparatedString(this List<string> list, string stringToSeparate)
        {
            var separatedString = stringToSeparate.Split(new char[] {','});
            list.AddRange(separatedString);
        }
    }
}