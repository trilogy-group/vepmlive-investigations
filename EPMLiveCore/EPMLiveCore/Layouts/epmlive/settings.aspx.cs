using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Text;

namespace EPMLiveCore
{
    public partial class settings : LayoutsPageBase
    {
        protected string data = "";

        private string getCategoryName(string category)
        {
            try
            {
                return category.Substring(category.IndexOf(")") + 2);
            }
            catch { }
            return category;
        }

        private string getPicture(string category)
        {
            switch(getCategoryName(category))
            {
                case "User Management":
                    return "UserMgmt.png";
                case "Look & Feel":
                    return "Look.png";
                case "Configuration":
                    return "Config.png";
                case "Collaboration Settings":
                    return "Collab.png";
                case "System Settings":
                    return "System.png";
                case "Timesheet Settings":
                    return "Timesheet.png";
                case "Enterprise Reporting":
                    return "Reporting.png";
                case "Planner Settings":
                    return "Planner.gif";
                case "Advanced":
                    return "AdvancedSettings.png";
                case "Portfolio Management":
                    return "PortfolioMgmt.png";
                case "Cost Management":
                    return "editcosts.png";
                case "Resource Management":
                    return "ResourceMgmt.png";
                case "Utilities":
                    return "Advanced.png";

            };
            return "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;

            string siteurl = (web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl;

            SPList list = web.Lists.TryGetList("EPM Live Settings");

            if(list != null)
            {
                SortedList arr = new SortedList();
                try
                {
                    SPFieldChoice f = (SPFieldChoice)list.Fields.GetFieldByInternalName("Category");
                    SPField fsd = null;
                    try
                    {
                        fsd = list.Fields.GetFieldByInternalName("Description");
                    }
                    catch { }
                    foreach(string c in f.Choices)
                    {
                        arr.Add(c, "");
                    }

                    foreach(SPListItem li in list.Items)
                    {
                        try
                        {
                            string cat = li[f.Id].ToString();
                            if(arr.Contains(cat))
                            {
                                string shortDesc = "";
                                try
                                {
                                    shortDesc = li[fsd.Id].ToString();
                                }
                                catch { }
                                string newItem = "";

                                if(li["URL"].ToString().StartsWith("/_layouts/"))
                                    newItem = "<li><A class=\"settingtooltip\" style=\"color:#0072bc\" id=\"ql" + li.ID + "\" href=\"" + siteurl + li["URL"].ToString() + "?Source=" + siteurl + "/_layouts/epmlive/settings.aspx\">" + li["Title"].ToString();
                                else
                                    newItem = "<li><A class=\"settingtooltip\" style=\"color:#0072bc\" id=\"ql" + li.ID + "\" href=\"" + siteurl + li["URL"].ToString() + "?BackTo=" + siteurl + "/_layouts/epmlive/settings.aspx\">" + li["Title"].ToString();

                                if(shortDesc != "")
                                    newItem += "<span>" + shortDesc + "</span>";

                                newItem += "</A></li>";

                                arr[cat] = arr[cat] + newItem;
                            }
                        }
                        catch { }
                    }

                }
                catch { }

                

                string []arrData = new string[2] {"",""};

                int counter = 0;

                foreach(DictionaryEntry de in arr)
                {
                    if(de.Value.ToString() != "")
                    {
                        string insideData = "";

                        string pic = getPicture(de.Key.ToString());


                        insideData = "<table><tr><td style=\"WIDTH: 40px\" valign=\"top\">";
                        if(pic != "")
                        {
                            insideData += "<img src=\"/_layouts/epmlive/images/settings/" + pic + "\">";
                        }
                        insideData += "</td><td valign=\"top\" class=\"setting\">";
                        insideData += "<h3>" + getCategoryName(de.Key.ToString()) + "</h3><ul>";
                        insideData += de.Value;
                        insideData += "</ul></td></tr></table><br>";

                        if(counter % 2 == 0)
                            arrData[0] += insideData;
                        else
                            arrData[1] += insideData;

                        counter++;
                    }
                }

                data = "<table width=\"100%\"><tr><td width=\"33%\" valign=\"top\">" + arrData[0] + "</td><td width=\"33%\" valign=\"top\">" + arrData[1] + "</td><td width=\"33%\" valign=\"top\"></td></table>";

            }
            else
            {
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("settings.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
            
        }
    }
}
