using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs
{
    public class RollupJob
    {
        public void Execute(SPWeb web, Guid listid, int itemid)
        {
            SPList oList = null;
            SPListItem oLi = null;
            try
            {
                oList = web.Lists[listid];
                oLi = oList.GetItemById(itemid);
                foreach (SPField f in oList.Fields)
                {
                    if (f.TypeAsString == "TotalRollup")
                    {
                        oLi[f.InternalName] = getListItemCount(web, f, oLi.Title);
                    }
                }
                try
                {
                    if (oList.Fields.ContainsField("PubUpdate"))
                        oLi["PubUpdate"] = oLi["PubUpdate"];
                }
                catch { }
                try
                {
                    if (oList.Fields.ContainsField("IsPublished"))
                        oLi["IsPublished"] = oLi["IsPublished"];
                }
                catch { }

                if (web.Features[new Guid("ebc3f0dc-533c-4c72-8773-2aaf3eac1055")] != null && oList.Title.ToLower() == "task center")
                {
                    oLi["taskuid"] = oLi["taskuid"].ToString();
                }
                oLi.SystemUpdate();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                oList = null;
                oLi = null;
                if (web != null)
                    web.Dispose();
            }
        }

        private double getListItemCount(SPWeb web, SPField f, string project)
        {
            string list = f.GetCustomProperty("ListName").ToString();
            string query = f.GetCustomProperty("ListQuery").ToString();
            string lookup = "";
            try
            {
                lookup = f.GetCustomProperty("LookupColumn").ToString();
            }
            catch { }
            string aggtype = "";
            try
            {
                aggtype = f.GetCustomProperty("AggType").ToString();
            }
            catch { }
            string aggcolumn = "";
            try
            {
                aggcolumn = f.GetCustomProperty("AggColumn").ToString();
            }
            catch { }

            try
            {


                if (lookup == "")
                {
                    lookup = "Project";
                }

                SPList tList = web.Lists[list];

                if (query != "")
                {
                    query = "<And>" + query + "<Eq><FieldRef Name='" + lookup + "'/><Value Type='Lookup'>" + project + "</Value></Eq></And>";
                }
                else
                    query = "<Eq><FieldRef Name='" + lookup + "'/><Value Type='Lookup'>" + project + "</Value></Eq>";

                SPQuery q = new SPQuery();
                q.Query = "<Where>" + query + "</Where>";

                switch (aggtype)
                {
                    case "Sum":
                        double val = 0;
                        foreach (SPListItem li in tList.GetItems(q))
                        {
                            try
                            {
                                string sval = li.Fields.GetFieldByInternalName(aggcolumn).GetFieldValue(li[aggcolumn].ToString()).ToString();
                                if (sval.Contains(";#"))
                                    sval = sval.Replace(";#", "\n").Split('\n')[1];
                                val += double.Parse(sval);
                            }
                            catch { }
                        }
                        return val;
                    case "Avg":
                        double val1 = 0;
                        double counter = 0;
                        foreach (SPListItem li in tList.GetItems(q))
                        {
                            counter++;
                            try
                            {
                                string sval = li.Fields.GetFieldByInternalName(aggcolumn).GetFieldValue(li[aggcolumn].ToString()).ToString();
                                if (sval.Contains(";#"))
                                    sval = sval.Replace(";#", "\n").Split('\n')[1];
                                val1 += double.Parse(sval);
                            }
                            catch { }
                        }
                        if (counter == 0)
                            return 0;
                        return val1 / counter;
                    default:
                        return tList.GetItems(q).Count;
                }

            }
            catch (Exception ex)
            {
                //Response.Write("ERR ROLLUP: " + ex.Message + " " + HttpUtility.HtmlEncode(query) + "<br>");
            }
            return 0;
        }
    }
}
