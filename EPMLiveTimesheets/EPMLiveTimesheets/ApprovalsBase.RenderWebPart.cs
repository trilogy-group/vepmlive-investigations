using System;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using Microsoft.SharePoint;

namespace TimeSheets
{
    public abstract partial class ApprovalsBase
    {
        protected void RenderGrid(
            HtmlTextWriter output,
            SPWeb web,
            string filterByAdd,
            string resourceRibbonFunctions,
            string approvalUrl,
            string ribbonId,
            string txtApprovalsJs,
            string txtExcels,
            bool initMb = false)
        {
            string firstEditorBox;
            var editEvents = "false";
            output.Write(SharedFunctions.getTimeEditorDiv(editEvents, FullGridId, Connection, web, out firstEditorBox));

            AppendCssAndJsLibraries(output);
            AppendStyles(output);
            AppendDialogWindows(output);
            AppendGridControlsScripts(output, web, filterByAdd);
            AppendMyGridScripts(output, web, resourceRibbonFunctions);

            output.Write($"function loadX{FullGridId}(){{");
            output.Write($"var w = document.getElementById('WebPart{Qualifier}').offsetWidth - 20;");
            output.Write($"mygrid{FullGridId}.loadXML(\"{web.Url}/_layouts/epmlive/{approvalUrl}.aspx?data={FullParamList}");
            output.Write(
                $"&source={HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString())}&rnd={Guid.NewGuid()}&period={Period}&width=\" + w);");
            output.Write("}");

            output.WriteLine("function clickTab(){");
            output.WriteLine($"var wp = document.getElementById('MSOZoneCell_WebPart{Qualifier}');");
            output.WriteLine("fireEvent(wp, 'mouseup');");
            output.WriteLine("setTimeout(\"clickbrowse()\",1000);");
            output.WriteLine("}");

            output.WriteLine("function clickbrowse(){");
            output.WriteLine($"var wp2 = document.getElementById('Ribbon.{ribbonId}-title').firstChild;");
            output.WriteLine("fireEvent(wp2, 'click');");
            output.WriteLine("}");

            output.Write("SP.SOD.executeOrDelayUntilScriptLoaded(clickTab, \"GridViewContextualTabPageComponent.js\");");
            output.Write($"_spBodyOnLoadFunctionNames.push(\"loadX{FullGridId}\");");

            if (initMb)
            {
                output.Write("initmb();");
            }

            output.Write(txtApprovalsJs.Replace("#gridid#", FullGridId));
            output.WriteLine("<script language=\"javascript\">");
            output.Write(txtExcels.Replace("#gridid#", FullGridId));
            output.WriteLine("</script>");
        }

        protected void AppendGridControlsScripts(HtmlTextWriter output, SPWeb web, string filterByAdd)
        {
            output.Write("<script language=\"javascript\">");
            output.Write($"var actionurl{FullGridId} = \"{web.Url}/_layouts/epmlive/dotsaction.aspx\";");
            output.Write($"var emailurl{FullGridId} = \"{web.Url}/_layouts/epmlive/sendtsemail.aspx\";");
            output.Write($"var period{FullGridId} = {Period};");

            output.Write($"function gridfilter{FullGridId}(value){{");
            output.Write("var vals = value.split('|');");
            output.Write($"mygrid{FullGridId}.filterBy(vals[0] +{filterByAdd},vals[1]);");
            output.Write("}");

            output.Write($"function setSize{FullGridId}(){{mygrid{FullGridId}._askRealRows();}}");
            output.Write($"function printgrid{FullGridId}() {{var temp = mygrid{FullGridId}.hdr.rows[2];");
            output.Write($"var parent = temp.parentNode;parent.removeChild(temp,true);mygrid{FullGridId}.printView();parent.appendChild(temp);}}");
            output.Write($"function switchFilter{FullGridId}(hlink){{");
            output.Write($"var input1 = mygrid{FullGridId}.hdr.rows[2];");
            output.Write($"if(mygrid{FullGridId}Hidden == false){{");
            output.Write("input1.style.display = \"none\";");
            output.Write($"mygrid{FullGridId}Hidden = true;");
            output.Write("if(hlink != null){document.getElementById(hlink).innerHTML=\"&nbsp;Show Filters\";}");
            output.Write("}else{");
            output.Write("input1.style.display = \"\";");
            output.Write($"mygrid{FullGridId}Hidden = false;");
            output.Write("if(hlink != null){document.getElementById(hlink).innerHTML=\"&nbsp;Hide Filters\";}");
            output.Write("}");
            output.Write($"mygrid{FullGridId}.setSizes();");
            output.Write("}");
            output.Write($"function switchFilterLoad{FullGridId}(){{switchFilter{FullGridId}(null);}}");

            output.Write("</script>");
        }

        protected void AppendStyles(HtmlTextWriter output)
        {
            output.Write("<style>");
            output.Write("div.gridbox div.ftr td{");
            output.Write("text-align:right;");
            output.Write("font-weight:bold;");
            output.Write("background-color:#d2d2d2;");
            output.Write("border: 1px solid;");
            output.Write("border-color : Gray Gray Gray white;");
            output.Write("}");
            output.Write("div.gridbox_light table.hdr td {");
            output.Write("text-align:center;");
            output.Write("}");
            output.Write(".noborder{");
            output.Write("border: 0px !important;");
            output.Write("height: 9px !important;");
            output.Write("}");
            output.Write(".statustable {");
            output.Write("border: 1px solid gray;");
            output.Write("height: 9px;");
            output.Write("}");
            output.Write(".grid_hover { border: 10px solid #91CDF2; background-color: #F2FAFF } ");
            output.Write("</style>");
        }

        protected void AppendCssAndJsLibraries(HtmlTextWriter output)
        {
            output.Write("<link rel=\"stylesheet\" href=\"/_layouts/epmlive/modal/modalmain.css\" type=\"text/css\" /> ");
            output.Write("<script type=\"text/javascript\" src=\"/_layouts/epmlive/modal/modal.js\"></script>");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xgrid/dhtmlxgrid.css\"/>");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xgrid/dhtmlxgrid_skins.css\"/>");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/calendar/dhtmlxcalendar.css\"/>");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/skins/dhtmlxmenu_dhx_blue.css\">");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xcombo/dhtmlxcombo.css\">");
            output.Write("<script>_css_prefix=\"/_layouts/epmlive/DHTML/xgrid/\"; _js_prefix=\"/_layouts/epmlive/DHTML/xgrid/\"; </script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xgrid/dhtmlxcommon.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xgrid/dhtmlxgridcell.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xtreegrid/dhtmlxtreegrid.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xtreegrid/ext/dhtmlxtreegrid_filter.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_post.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_nxml.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_filter.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_math.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_srnd.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_drag.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/excells/dhtmlxgrid_excell_calendar.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/excells/dhtmlxgrid_excell_combo.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xgrid/excells/dhtmlxgrid_excell_dhxcalendar.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xcombo/dhtmlxcombo.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/calendar/dhtmlxcalendar.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xdataproc/dhtmlxdataprocessor.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/resPlanning.js\"></script>");
        }

        protected string GetGridHeightScript()
        {
            if (string.IsNullOrWhiteSpace(Height))
            {
                return ".enableAutoHeigth(true);";
            }

            var matchCollection = Regex.Matches(Height, "\\d*");
            var heightValue = "100";

            if (matchCollection.Count > 0)
            {
                int height;

                heightValue = int.TryParse(heightValue, out height)
                    ? (height - 30).ToString()
                    : matchCollection[0].Value;
            }

            return $".enableAutoHeigth(true,{heightValue},true);";
        }

        protected void AppendMyGridScripts(HtmlTextWriter output, SPWeb web, string resourceItem)
        {
            output.Write("\r\n\r\n\r\n<script>");
            output.Write($"var mygrid{FullGridId}Hidden = false;");
            output.Write($"mygrid{FullGridId} = new dhtmlXGridObject('grid{ID}');");
            output.Write($"mygrid{FullGridId}.setImagePath(\"/_layouts/epmlive/dhtml/xgrid/imgs/\");");
            output.Write($"mygrid{FullGridId}.setSkin(\"timesheet\");");
            output.Write($"mygrid{FullGridId}{GetGridHeightScript()}");
            output.Write($"mygrid{FullGridId}.setImageSize(1,1);");
            output.Write($"mygrid{FullGridId}.enableTreeCellEdit(false);");
            output.Write($"mygrid{FullGridId}.enableEditEvents(true,false,false);");
            output.Write($"mygrid{FullGridId}.setDateFormat(\"%m/%d/%Y\");");
            output.Write($"mygrid{FullGridId}.enableSmartXMLParsing(false);");
            output.Write($"mygrid{FullGridId}.attachEvent(\"onXLE\",clearLoader);");
            output.Write($"mygrid{FullGridId}.attachEvent(\"onXLE\",disableChecks{FullGridId});");
            output.Write($"mygrid{FullGridId}.attachEvent(\"onXLE\",switchFilterLoad{FullGridId});");

            if (Status != OpenStatus)
            {
                output.Write($"mygrid{FullGridId}.attachEvent(\"onXLE\",hideCol{FullGridId});");
            }

            output.Write($"mygrid{FullGridId}.attachEvent(\"onXLE\",function(){{");
            output.Write($"mygrid{FullGridId}.callEvent(\"onGridReconstructed\",[]);");
            output.Write("});");
            output.WriteLine($"mygrid{FullGridId}._webpartid = '{ID}';");
            output.WriteLine($"mygrid{FullGridId}.setImagePath(\"_layouts/epmlive/dhtml/xgrid/imgs/\");");
            output.WriteLine($"mygrid{FullGridId}._gridMode = 'standard';");
            output.WriteLine($"mygrid{FullGridId}._modifylist = {GetModifyListValue()};");
            output.WriteLine($"mygrid{FullGridId}._listperms = {GetListPermsValue()};");
            output.WriteLine($"mygrid{FullGridId}._cururl = '{HttpContext.Current.Request.Url.AbsolutePath}';");
            output.WriteLine($"mygrid{FullGridId}._timesheetstatus = '{Status}';");
            output.WriteLine($"mygrid{FullGridId}._timesheetperiod = '{CurrentPeriodName}';");
            output.WriteLine($"mygrid{FullGridId}._nextperiod = '{NextPeriod}';");
            output.WriteLine($"mygrid{FullGridId}._previousperiod = '{PreviousPeriod}';");
            output.WriteLine($"mygrid{FullGridId}._allperiods = '{AllPeriods}';");
            output.WriteLine($"mygrid{FullGridId}._shownewmenu = false;");
            output.WriteLine($"mygrid{FullGridId}._listid = '{HttpUtility.UrlEncode(SpList.ID.ToString()).ToUpper()}';");
            output.WriteLine($"mygrid{FullGridId}._viewid = '{HttpUtility.UrlEncode(View.ID.ToString()).ToUpper()}';");
            output.WriteLine($"mygrid{FullGridId}._viewurl = '{web.Url}{View.ServerRelativeUrl}';");
            output.WriteLine($"mygrid{FullGridId}._viewname = '{View.Title}';");
            output.WriteLine($"mygrid{FullGridId}._basetype = '{SpList.BaseType}';");
            output.WriteLine($"mygrid{FullGridId}._templatetype = '{(int)SpList.BaseTemplate}';");
            output.WriteLine($"mygrid{FullGridId}._newrow = false;");
            output.WriteLine($"mygrid{FullGridId}._gridid = '{FullGridId}';");
            output.WriteLine($"mygrid{FullGridId}._formmenus = \"{GetFormsMenus(web)}\";");
            output.WriteLine(resourceItem.Replace("#gridid#", FullGridId));
            output.Write($"mygrid{FullGridId}.init();\r\n\r\n\r\n");
        }

        protected string GetModifyListValue()
        {
            try
            {
                return SpList.DoesUserHavePermissions(SPBasePermissions.ManageLists).ToString().ToLower();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return bool.FalseString;
            }
        }

        protected string GetFormsMenus(SPWeb web)
        {
            var stringBuilder = new StringBuilder();

            foreach (SPForm form in SpList.Forms)
            {
                switch (form.Type)
                {
                    case PAGETYPE.PAGE_DISPLAYFORM:
                        stringBuilder.Append("<Button Id='Ribbon.List.Settings.EditDefaultForms.Menu.MS.EditDefaultFormDisplay' CommandValueId='")
                           .Append(HttpUtility.UrlEncode(form.ServerRelativeUrl))
                           .Append("' Command='EditDefaultForm' Image16by16='/_layouts/")
                           .Append(web.Language)
                           .Append("/images/formatmap16x16.png' Image16by16Top='-176' Image16by16Left='-16' Image32by32='/_layouts/")
                           .Append(web.Language)
                           .Append("/images/formatmap32x32.png' Image32by32Top='-256' Image32by32Left='-320' LabelText='Default Display Form'/>");
                        break;
                    case PAGETYPE.PAGE_EDITFORM:
                        stringBuilder.Append("<Button Id='Ribbon.List.Settings.EditDefaultForms.Menu.MS.EditDefaultFormDisplay' CommandValueId='")
                           .Append(HttpUtility.UrlEncode(form.ServerRelativeUrl))
                           .Append("' Command='EditDefaultForm' Image16by16='/_layouts/")
                           .Append(web.Language)
                           .Append("/images/formatmap16x16.png' Image16by16Top='-32' Image16by16Left='-80' Image32by32='/_layouts/")
                           .Append(web.Language)
                           .Append("/images/formatmap32x32.png' Image32by32Top='-96' Image32by32Left='-448' LabelText='Default Edit Form'/>");
                        break;
                    case PAGETYPE.PAGE_NEWFORM:
                        stringBuilder.Append("<Button Id='Ribbon.List.Settings.EditDefaultForms.Menu.MS.EditDefaultFormDisplay' CommandValueId='")
                           .Append(HttpUtility.UrlEncode(form.ServerRelativeUrl))
                           .Append("' Command='EditDefaultForm' Image16by16='/_layouts/")
                           .Append(web.Language)
                           .Append("/images/formatmap16x16.png' Image16by16Top='-128' Image16by16Left='-224' Image32by32='/_layouts/")
                           .Append(web.Language)
                           .Append("/images/formatmap32x32.png' Image32by32Top='-128' Image32by32Left='-96' LabelText='Default New Form'/>");
                        break;
                    default:
                        throw new InvalidOperationException($"Unexpected value: {form.Type}");
                }
            }

            return stringBuilder.ToString();
        }

        protected string GetListPermsValue()
        {
            try
            {
                return SpList.DoesUserHavePermissions(SPBasePermissions.ManagePermissions).ToString().ToLower();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return bool.FalseString;
            }
        }
    }
}