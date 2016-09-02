using Microsoft.SharePoint;

namespace EPMLibrary
{
    public class Utility
    {
        public static SPList GetResList(SPWeb resWeb)
        {
            SPList reslist;
            try
            {
                reslist = resWeb.Lists["Resources"];
            }
            catch
            {
                return null;
            }
            return reslist;
        }

        /*public static SPWeb GetResWeb(string resUrl, SPWeb web)
        {
            SPWeb resWeb;
            if (resUrl.ToLower() != web.Url.ToLower())
            {
                using(SPSite tempSite = new SPSite(resUrl))
                {
                    using(resWeb = tempSite.OpenWeb())
                    {
                        if(resWeb.Url.ToLower() != resUrl.ToLower())
                        {
                            resWeb = null;
                        }
                    }
                }
            }
            else
                resWeb = web;
            return resWeb;
        }*/
    }
}