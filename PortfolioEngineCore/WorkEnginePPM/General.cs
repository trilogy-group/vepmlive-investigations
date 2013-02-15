using System;
using System.Collections.Generic;
using System.Web;

namespace WorkEnginePPM
{
    public class vb
    {
        public static object IIf(bool Expression, object TruePart, object FalsePart)
        {
            if (Expression)
                return TruePart;
            else
                return FalsePart;
        }

        public static int val(string sInteger)
        {
            if (string.IsNullOrEmpty(sInteger) == true)
                return 0;
            string sTrimmed = sInteger.Trim();
            string[] sSplit = System.Text.RegularExpressions.Regex.Split(sTrimmed, "[^\\d]");
            //string sVal = string.Join(null, sSplit);
            string sVal = sSplit[0];
            int result;
            Int32.TryParse(sVal, out result);

            return result;
        }

        public static int Max(int p0, int p1)
        {
            return (int)IIf(p0 > p1, p0, p1);
        }

        public static string Left(string s, int nLen)
        {
            if (s.Length > nLen)
                return s.Substring(0, nLen);
            else
                return s;
        }
    }
}