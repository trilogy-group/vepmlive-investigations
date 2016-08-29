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

namespace EPMLiveSynch
{
    public partial class RenameTemplate : System.Web.UI.Page
    {
        protected string result;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["newname"] != null && Request["newname"].ToString().Length > 0)
            {
                string sNewName = Request["newname"].ToString();
                SPWeb web = SPContext.Current.Web;
                try
                {
                    string sOldName = web.Title;
                    web.AllowUnsafeUpdates = true;
                    web.Title = sNewName;
                    web.Update();
                    web.AllowUnsafeUpdates = false;

                    using (SPSite site = SPContext.Current.Site)
                    {
                        using (SPWeb rootWeb = site.RootWeb)
                        {
                            SPSecurity.RunWithElevatedPrivileges(delegate()
                            {
                                rootWeb.AllowUnsafeUpdates = true;
                                foreach (SPItem item in rootWeb.Lists["Solution Gallery"].Items)
                                {
                                    if (item["Name"].ToString() == sOldName)
                                    {
                                        item["Name"] = sNewName;
                                        //item["Title"] = sNewName;
                                        item.Update();
                                        break;
                                    }
                                }
                                rootWeb.Update();
                                rootWeb.AllowUnsafeUpdates = false;
                            });
                        }
                    }

                    result = "Success";
                }
                catch (Exception exc)
                {
                    result = exc.Message;
                }
            }
            else
            {
                result = "Missing variable for the new name of the template.";
            }
        }
    }
}