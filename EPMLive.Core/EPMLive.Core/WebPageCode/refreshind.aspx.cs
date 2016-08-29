using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.VisualBasic;

namespace EPMLiveCore
{
    public partial class refreshind : System.Web.UI.Page
    {
        SPList projectCenter;
        Hashtable hCurrentProjectCenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            hCurrentProjectCenter = new Hashtable();
            web.AllowUnsafeUpdates = true;
            try
            {
                projectCenter = web.Lists[new Guid(Request["ListId"])];

                try
                {
                    foreach (SPListItem li in projectCenter.Items)
                    {
                        foreach (SPField f in projectCenter.Fields)
                        {
                            if (f.TypeAsString == "TotalRollup")
                            {
                                li[f.InternalName] = getListItemCount(web, f, li.Title);
                            }
                        }
                        li.SystemUpdate();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("LI: " + ex.Message + ex.StackTrace + "<br><br>");
                }
                //Run_ReCalculate(web);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            //string url1 = web.Url + "/" + projectCenter.Views[projectCenter.DefaultView.ID].Url;
            //web.Close();
            if(Request["debug"] != "true")
                Response.Redirect(Request["Source"]);
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
                    query = "<And>" + query + "<Eq><FieldRef Name='" + lookup + "'/><Value Type='Text'>" + project + "</Value></Eq></And>";
                }
                else
                    query = "<Eq><FieldRef Name='" + lookup + "'/><Value Type='Text'>" + project + "</Value></Eq>";

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
                Response.Write("ERR ROLLUP: " + ex.Message + " " + HttpUtility.HtmlEncode(query) + "<br>");
            }
            return 0;
        }
    }
}