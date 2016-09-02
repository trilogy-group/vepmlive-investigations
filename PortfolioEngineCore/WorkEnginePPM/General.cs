using System;
using System.Collections.Generic;
using System.Web;
using System.Runtime.Serialization.Formatters.Binary;
using PortfolioEngineCore;

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

    public class DataCacheAPI
    {

        private static string SerializeToBinary(object value)
        {
            string str;
            BinaryFormatter bf = new BinaryFormatter();
            System.IO.MemoryStream mem = new System.IO.MemoryStream();
            bf.Serialize(mem, value);
            str = Convert.ToBase64String(mem.ToArray());

            return str;
        }
        private static object BinaryToClass(string str)
        {
            BinaryFormatter bf = new BinaryFormatter();
            System.IO.MemoryStream mem = new System.IO.MemoryStream(Convert.FromBase64String(str));
            object mine = bf.Deserialize(mem);
            return mine;
        }


        public static void SaveCachedData(HttpContext Context, string sKey, object value)
        {
            string basePath;
            string ppmId;
            string ppmCompany;
            string ppmDbConn;
            string username;
            SecurityLevels securityLevel;

            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioEngineCore.AnalyzerDataCache rpa = new AnalyzerDataCache(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);
            string sdata = SerializeToBinary(value);

            rpa.SaveStashEntry(sKey, sdata);
        }


        public static object GetCachedData(HttpContext Context, string sKey)
        {

            string basePath;
            string ppmId;
            string ppmCompany;
            string ppmDbConn;
            string username;
            SecurityLevels securityLevel; 
            
            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioEngineCore.AnalyzerDataCache rpa = new AnalyzerDataCache(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);

            string sdata = rpa.GetStashEntry(sKey);

            if (sdata == "")
                return null;

            return BinaryToClass(sdata);
        }
        

    }
}