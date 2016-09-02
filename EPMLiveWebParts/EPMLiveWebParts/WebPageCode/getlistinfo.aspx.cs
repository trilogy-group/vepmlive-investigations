using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;
using System.Text.RegularExpressions;

namespace EPMLiveWebParts
{
    public partial class getlistinfo : System.Web.UI.Page
    {

        protected string data;

        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;

            data = "Error: Failed";

            SPWeb web = SPContext.Current.Web;
            {
                web.AllowUnsafeUpdates = true;
                try
                {
                    SPList list = web.GetListFromUrl(Request["listurl"]);

                    string views = "";

                    foreach (SPView view in list.Views)
                    {
                        if (!view.Hidden && !view.PersonalView)
                        {
                            views += "|" + view.Title;
                        }
                    }
                    if (views.Length > 1)
                        views = views.Substring(1);

                    string cFields = "";
                    foreach (SPField f in list.Fields)
                    {
                        if (!f.Hidden && f.Type != SPFieldType.Computed)
                        {
                            cFields += "," + f.Title + "|" + f.InternalName + "|" + f.Type.ToString();
                        }
                    }
                    if (cFields.Length > 1)
                        cFields = cFields.Substring(1);

                    data = views + "\n" + cFields;
                }
                catch (Exception ex)
                {
                    data = "Error: " + ex.Message;
                }
            }
            
        }


    }
}