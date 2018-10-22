using System;
using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPMLiveCore;
using EPMLiveCore.Helpers;
using EPMLiveWebParts.Properties;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWebParts
{
    public partial class ResourcePlanning
    {
        private string getGanttParams()
        {
            var gSettings = new GridGanttSettings(rcList);
            var resources = string.Empty;
            var strRollupLists = gSettings.RollupLists;
            var strRollupSites = gSettings.RollupSites;

            if (!string.IsNullOrWhiteSpace(sResourceList))
            {
                var arrRes = sResourceList.Replace(";#", "\n").Split('\n');
                var arrListRes = new ArrayList();
                arrListRes.AddRange(arrRes);
                var resourceBuilder = new StringBuilder();

                foreach (SPListItem spListItem in reslist.Items)
                {
                    if (arrListRes.Contains(spListItem.ID.ToString()))
                    {
                        try
                        {
                            if (spListItem["SharePointAccount"] != null)
                            {
                                var fieldUserValue = new SPFieldUserValue(spListItem.Web, spListItem["SharePointAccount"].ToString());
                                resourceBuilder.Append($";#{HttpUtility.UrlEncode(fieldUserValue.LookupValue)}");
                            }
                        }
                        catch (Exception exception)
                        {
                            Trace.WriteLine(exception);
                        }
                    }
                }

                resources = resourceBuilder.ToString();

                if (resources.Length > 2)
                {
                    resources = resources.Substring(2);
                }
            }

            var data =
                $"Lists/Resource Center/DispForm.aspx\n{SPContext.Current.ViewContext.View.Title}\nStartDate\nDueDate\nPercentComplete\n\n\nTrue\n\n\n{strRollupLists}\n{Page.Request["FilterField1"]}\n{Page.Request["FilterValue1"]}\n{strRollupSites}\n{resources}\n{gSettings.UsePopup}";

            var toEncodeAsBytes = Encoding.ASCII.GetBytes(data);

            return Convert.ToBase64String(toEncodeAsBytes);
        }

        public void processControls(Control parentControl, string zoneIndex, string viewUrl, SPWeb curWeb)
        {
            Guard.ArgumentIsNotNull(viewUrl, nameof(viewUrl));
            Guard.ArgumentIsNotNull(zoneIndex, nameof(zoneIndex));
            Guard.ArgumentIsNotNull(parentControl, nameof(parentControl));

            foreach (Control childControl in parentControl.Controls)
            {
                var childControlString = childControl.ToString();

                if (childControlString == "System.Web.UI.WebControls.HyperLink")
                {
                    if (childControl.ID == "hlGanttScrollTo")
                    {
                        var hyperLink = (HyperLink)childControl;
                        hyperLink.NavigateUrl = "javascript:scrollTo()";
                    }
                }

                if (childControlString == "System.Web.UI.WebControls.Label")
                {
                    if (childControl.ID == "lblFilter")
                    {
                        try
                        {
                            var lblFilterText = (Label)parentControl.FindControl("lblFilterText");
                            var lblLink = (Label)childControl;
                            lblLink.Text = $"<a href=\"Javascript:switchFilter{zoneIndex}(\'{lblFilterText.ClientID}\');\">";
                        }
                        catch (Exception exception)
                        {
                            Trace.WriteLine(exception);
                        }
                    }
                }

                if (childControlString.Equals("MICROSOFT.SHAREPOINT.WEBCONTROLS.NEWMENU", StringComparison.OrdinalIgnoreCase))
                {
                    childControl.Visible = false;
                }

                if (childControlString.Equals("MICROSOFT.SHAREPOINT.WEBCONTROLS.ACTIONSMENU", StringComparison.OrdinalIgnoreCase))
                {
                    var menu = (ActionsMenu)childControl;

                    try
                    {
                        menu.GetMenuItem("EditInGridButton").Visible = false;
                    }
                    catch (Exception exception)
                    {
                        Trace.WriteLine(exception);
                    }

                    try
                    {
                        menu.GetMenuItem("ExportToDatabase").Visible = false;
                    }
                    catch (Exception exception)
                    {
                        Trace.WriteLine(exception);
                    }

                    try
                    {
                        menu.GetMenuItem("ExportToSpreadsheet").Visible = false;
                    }
                    catch (Exception exception)
                    {
                        Trace.WriteLine(exception);
                    }

                    try
                    {
                        menu.GetMenuItem("ViewRSS").Visible = false;
                    }
                    catch (Exception exception)
                    {
                        Trace.WriteLine(exception);
                    }

                    try
                    {
                        menu.GetMenuItem("SubscribeButton").Visible = false;
                    }
                    catch (Exception exception)
                    {
                        Trace.WriteLine(exception);
                    }

                    menu.AddMenuItem(
                        "ChangeResources",
                        "Select Resources",
                        "/_layouts/images/3people.GIF",
                        "Change the resources you are currently viewing.",
                        $"{viewUrl}?action=changeRes",
                        string.Empty);
                    menu.AddMenuItemSeparator();
                    menu.AddMenuItem(
                        "SaveResourcePlan",
                        "Save Resource Plan",
                        "/_layouts/images/save.GIF",
                        "Save resource plan to file.",
                        string.Empty,
                        $"savePlan(\'{curWeb.Url}\')");
                    menu.AddMenuItem(
                        "OpenResourcePlan",
                        "Open Resource Plan",
                        "/_layouts/images/FLDRNEW.GIF",
                        "Open resource plan from saved file.",
                        string.Empty,
                        $"loadPlans(\'{curWeb.Url}\')");
                    menu.AddMenuItemSeparator();
                    menu.AddMenuItem(
                        "PrintGantt",
                        "Print Gantt",
                        "/_layouts/epmlive/images/printmenu.GIF",
                        "Print Gantt Chart.",
                        string.Empty,
                        $"printGantt{this.ZoneIndex}{ZoneID}()");
                }

                processControls(childControl, zoneIndex, viewUrl, curWeb);
            }
        }

        private void renderGrid(HtmlTextWriter output)
        {
            Guard.ArgumentIsNotNull(output, nameof(output));

            AppendCssLibraries(output);
            AppendJsLibraries(output);

            output.Write($"<div id=\"grid{ID}\" style=\"width:100%;display:none;\" ></div>\r\n\r\n");
            output.Write($"<div  width=\"100%\" id=\"loadinggrid{ID}\" align=\"center\">");
            output.Write("<img src=\"/_layouts/images/GEARS_ANv4.GIF\" style=\"vertical-align: middle;\"/> Loading Resources...");
            output.Write("</div>");

            AppendFilteringScripts(output);

            output.Write("<script>");
            output.Write($"var mygrid{ZoneIndex}{ZoneID}Hidden = false;");
            output.Write($"mygrid{ZoneIndex}{ZoneID} = new dhtmlXGridObject(\'grid{ID}\');");
            output.Write($"mygrid{ZoneIndex}{ZoneID}.setImagePath(\"/_layouts/epmlive/dhtml/xgrid/imgs/\");");
            output.Write($"mygrid{ZoneIndex}{ZoneID}.setSkin(\"modern\");");
            output.WriteLine($"mygrid{sFullGridId}.addFocusedCommands = function($arr){{return $arr;}}");
            output.WriteLine($"mygrid{sFullGridId}.getGlobalCommands = function($arr){{return $arr;}}");
            output.WriteLine($"mygrid{sFullGridId}.canHandleCommand = function($Grid, commandId){{return false;}}");
            output.WriteLine(
                $"mygrid{sFullGridId}.handleCommand = function($Grid, commandId, properites){{if(typeof(properties) != \'undefined\')return properties;}}");

            if (string.IsNullOrWhiteSpace(Height))
            {
                output.Write($"mygrid{ZoneIndex}{ZoneID}.enableAutoHeigth(true);");
            }
            else
            {
                var matchCollection = Regex.Matches(Height, "\\d*");
                var value = "100";

                if (matchCollection.Count > 0)
                {
                    value = matchCollection[0].Value;

                    try
                    {
                        value = (int.Parse(value) - 30).ToString();
                    }
                    catch (Exception exception)
                    {
                        Trace.WriteLine(exception);
                    }
                }

                output.Write($"mygrid{ZoneIndex}{ZoneID}.enableAutoHeigth(true,{value},true);");
            }

            output.Write($"mygrid{ZoneIndex}{ZoneID}.setImageSize(1,1);");
            output.Write($"mygrid{ZoneIndex}{ZoneID}.enableTreeCellEdit(false);");
            output.Write($"mygrid{ZoneIndex}{ZoneID}.setDateFormat(\"%m/%d/%Y\");");
            output.Write($"mygrid{ZoneIndex}{ZoneID}.attachEvent(\"onXLE\",clearLoader);");
            output.Write($"mygrid{ZoneIndex}{ZoneID}.attachEvent(\"onCheck\", doOnCheck{ZoneIndex}{ZoneID});");
            output.Write($"mygrid{ZoneIndex}{ZoneID}.init();");
            output.Write("try{");
            output.Write(
                $"mygrid{ZoneIndex}{ZoneID}.loadXML(\"{resWeb.Url}/_layouts/epmlive/getresourcepool.aspx?view={reslist.DefaultView.Title.Replace(" ", "%20")}&gridname={ZoneIndex}{ZoneID}&source={HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString())}\");");
            output.Write("}catch(e){alert(e);}");

            output.Write("</script>");

            output.Write("<input type=\"hidden\" name=\"changeRes\" id=\"changeRes\" value=\"yes\">");
            output.Write("<input type=\"hidden\" name=\"resourceList\" id=\"resourceList\" value=\"\">");
        }

        private void AppendFilteringScripts(HtmlTextWriter output)
        {
            Guard.ArgumentIsNotNull(output, nameof(output));

            var zoneIdentifier = string.Concat(ZoneIndex, ZoneID);
            var requestUrl = HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString());

            output.Write("<script language=\"javascript\">");
            output.Write($"function gridfilter{zoneIdentifier}(value){{");
            output.Write("var vals = value.split('|');");
            output.Write($"mygrid{zoneIdentifier}.filterBy(vals[0],vals[1]);");
            output.Write("}");
            output.Write(Resources.txtResourcePlannerJavascript1.Replace("#gridid#", zoneIdentifier));
            output.Write($"function changeview{zoneIdentifier}(){{");
            output.Write("try{");
            output.Write($"var view = document.getElementById('viewselector{zoneIdentifier}').value;");
            output.Write($"document.getElementById(\"grid{ID}\").style.display = \"none\";");
            output.Write($"document.getElementById(\"loadinggrid{ID}\").style.display = \"\";");
            output.Write($"mygrid{zoneIdentifier}.detachHeader(1);");
            output.Write($"mygrid{zoneIdentifier}.clearAll(true);");
            output.Write($"mygrid{zoneIdentifier}.loadXML(\"{resWeb.Url}/_layouts/epmlive/getresourcepool.aspx");
            output.Write($"?view=\" + view + \"&gridname={zoneIdentifier}&source={requestUrl}\");");
            output.Write("}catch(e){alert(e);}");
            output.Write("}");
            output.Write($"function setSize{zoneIdentifier}(){{mygrid{zoneIdentifier}._askRealRows();}}");
            output.Write($"function printgrid{zoneIdentifier}() {{var temp = mygrid{zoneIdentifier}.hdr.rows[2];");
            output.Write(
                $"var parent = temp.parentNode;parent.removeChild(temp,true);mygrid{zoneIdentifier}.printView();parent.appendChild(temp);}}");
            output.Write($"function switchFilter{zoneIdentifier}(hlink){{");
            output.Write($"var input1 = mygrid{zoneIdentifier}.hdr.rows[2];");
            output.Write($"if(mygrid{zoneIdentifier}Hidden == false){{");
            output.Write("input1.style.display = \"none\";");
            output.Write($"mygrid{zoneIdentifier}Hidden = true;");
            output.Write("if(hlink != null){document.getElementById(hlink).innerHTML=\"&nbsp;Show Filters\";}");
            output.Write("}else{");
            output.Write("input1.style.display = \"\";");
            output.Write($"mygrid{zoneIdentifier}Hidden = false;");
            output.Write("if(hlink != null){document.getElementById(hlink).innerHTML=\"&nbsp;Hide Filters\";}");
            output.Write("}");
            output.Write($"mygrid{zoneIdentifier}.setSizes();");
            output.Write("}");
            output.Write($"function switchFilterLoad{zoneIdentifier}(){{switchFilter{zoneIdentifier}(null);}}");
            output.Write("</script>");
        }

        private void AppendJsLibraries(HtmlTextWriter output)
        {
            Guard.ArgumentIsNotNull(output, nameof(output));

            output.Write("<script>_css_prefix=\"/_layouts/epmlive/DHTML/xgrid/\"; _js_prefix=\"/_layouts/epmlive/DHTML/xgrid/\"; </script>");
            output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/dhtmlxcommon.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/dhtmlxgridcell.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid_post.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/DHTML/xtreegrid/dhtmlxtreegrid.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/DHTML/xtreegrid/ext/dhtmlxtreegrid_filter.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_nxml.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_filter.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_math.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_srnd.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/DHTML/xcombo/dhtmlxcombo.js\"></script>");
            output.Write("<script language=\"JavaScript\" src=\"/_layouts/epmlive/dhtml/xmenu/dhtmlxprotobar.js\"></script>");
            output.Write("<script language=\"JavaScript\" src=\"/_layouts/epmlive/dhtml/xmenu/dhtmlxmenubar.js\"></script>");
            output.Write("<script language=\"JavaScript\" src=\"/_layouts/epmlive/dhtml/xmenu/dhtmlxmenubar_cp.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/resPlanning.js\"></script>");
        }

        private void AppendCssLibraries(HtmlTextWriter output)
        {
            Guard.ArgumentIsNotNull(output, nameof(output));

            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xgrid/dhtmlxgrid.css\"/>");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xgrid/dhtmlxgrid_skins.css\"/>");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/calendar/dhtmlxcalendar.css\"/>");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xmenu/dhtmlxmenu.css\">");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xmenu/context.css\">");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xcombo/dhtmlxcombo.css\">");
        }
    }
}