using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using EPMLiveCore.Helpers;
using EPMLiveWebParts.Properties;
using Microsoft.SharePoint;
using DiagTrace = System.Diagnostics.Trace;

namespace EPMLiveWebParts
{
    public partial class ResourcePlanning
    {
        protected override void RenderWebPart(HtmlTextWriter output)
        {
            Guard.ArgumentIsNotNull(output, nameof(output));

            output.Write($"<B><font color=\"red\">{error}</font></b>");

            if (activation != 0)
            {
                output.Write(act.translateStatus(activation));
                return;
            }

            if (reslist == null)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(resUrl) && resWeb != null)
            {
                output.Write("<script language=\"javascript\">");
                output.Write($"var myDataProcessor{sFullGridId} = new fakeGridObject();");
                output.Write("function fakeGridObject(){}");
                output.Write("</script>");

                sResourceList = Page.Request.Cookies["EPMLiveResourcePlanResources"] != null
                    ? Page.Request.Cookies["EPMLiveResourcePlanResources"]["resources"]
                    : string.Empty;

                try
                {
                    sResourceList = sResourceList.Replace("|", ";#");
                }
                catch (Exception exception)
                {
                    DiagTrace.WriteLine(exception);
                }

                if (string.IsNullOrWhiteSpace(sResourceList) || strAction == "changeRes")
                {
                    var resToolbar = Resources.txtResourcePlannerBottom;
                    resToolbar = resToolbar.Replace("#lists#", viewList);
                    resToolbar = resToolbar.Replace("#gridid#", $"{ZoneIndex}{ZoneID}");

                    output.Write(Resources.txtResourcePlannerTop);
                    lnk?.RenderControl(output);
                    output.Write(resToolbar);
                    renderGrid(output);
                }
                else
                {
                    RenderFakeGridObject(output);
                }
            }
            else
            {
                output.Write("The Resource Pool has not been configured.");
                return;
            }

            foreach (WebPart wp in WebPartManager.WebParts)
            {
                try
                {
                    if (wp.ToString() == "Microsoft.SharePoint.WebPartPages.XsltListViewWebPart" ||
                        wp.ToString() == "Microsoft.SharePoint.WebPartPages.ListViewWebPart")
                    {
                        wp.Visible = false;
                    }
                }
                catch (Exception exception)
                {
                    DiagTrace.WriteLine(exception);
                }
            }
        }

        private void RenderFakeGridObject(HtmlTextWriter output)
        {
            Guard.ArgumentIsNotNull(output, nameof(output));

            output.Write("<script language=\"javascript\">");
            output.Write($"mygrid{sFullGridId} = new fakeGridObject();");
            output.WriteLine(Resources.txtResourcePlannerRibbonScripts.Replace("#gridid#", sFullGridId));
            output.WriteLine($"mygrid{sFullGridId}._webpartid = \'{ID}\';");

            try
            {
                output.WriteLine($"mygrid{sFullGridId}._modifylist = {reslist.DoesUserHavePermissions(SPBasePermissions.ManageLists).ToString().ToLower()};");
            }
            catch (Exception exception)
            {
                DiagTrace.WriteLine(exception);
                output.WriteLine($"mygrid{sFullGridId}._modifylist = false;");
            }

            try
            {
                output.WriteLine(
                    $"mygrid{sFullGridId}._listperms = {reslist.DoesUserHavePermissions(SPBasePermissions.ManagePermissions).ToString().ToLower()};");
            }
            catch (Exception exception)
            {
                DiagTrace.WriteLine(exception);
                output.WriteLine($"mygrid{sFullGridId}._listperms = false;");
            }

            output.WriteLine($"mygrid{sFullGridId}._shownewmenu = false;");
            output.WriteLine($"mygrid{sFullGridId}._allowedit = true;");

            var view = SPContext.Current.ViewContext.View;
            output.WriteLine($"mygrid{sFullGridId}._listid = \'{HttpUtility.UrlEncode(rcList.ID.ToString()).ToUpper()}\';");
            output.WriteLine($"mygrid{sFullGridId}._viewid = \'{HttpUtility.UrlEncode(view.ID.ToString()).ToUpper()}\';");
            output.WriteLine($"mygrid{sFullGridId}._viewurl = \'{view.ServerRelativeUrl.Replace(" ", "%20")}\';");
            output.WriteLine($"mygrid{sFullGridId}._viewname = \'{view.Title}\';");
            output.WriteLine($"mygrid{sFullGridId}._basetype = \'{reslist.BaseType}\';");
            output.WriteLine($"mygrid{sFullGridId}._templatetype = \'{(int)reslist.BaseTemplate}\';");

            var serverRelativeUrl = resWeb.ServerRelativeUrl;
            output.WriteLine($"mygrid{sFullGridId}._cururl = \'{(serverRelativeUrl == "/" ? string.Empty : serverRelativeUrl)}\';");
            output.WriteLine($"mygrid{sFullGridId}.getUserData = function(item, item2){{return \'0,0,0,0,0,0,0,0,0,0,0,0,0,0\';}}");
            output.WriteLine($"mygrid{sFullGridId}.getSelectedRowId = function(){{return \'0\';}}");
            output.WriteLine($"mygrid{sFullGridId}._excell = \'\';");
            output.WriteLine($"mygrid{sFullGridId}._gridid = \'{sFullGridId}\';");

            var sbForms = ProcessSbForms();

            output.WriteLine($"mygrid{sFullGridId}._formmenus = \"{sbForms}\";");
            output.Write("</script>");
            renderGantt(output);
        }

        private StringBuilder ProcessSbForms()
        {
            var sbForms = new StringBuilder();

            foreach (SPForm form in reslist.Forms)
            {
                if (form.Type == PAGETYPE.PAGE_DISPLAYFORM)
                {
                    sbForms.Append(
                        $"<Button Id=\'Ribbon.List.Settings.EditDefaultForms.Menu.MS.EditDefaultFormDisplay\' CommandValueId=\'{form.ServerRelativeUrl}\' Command=\'EditDefaultForm\' Image16by16=\'/_layouts/{resWeb.Language}/images/formatmap16x16.png\' Image16by16Top=\'-176\' Image16by16Left=\'-16\' Image32by32=\'/_layouts/{resWeb.Language}/images/formatmap32x32.png\' Image32by32Top=\'-256\' Image32by32Left=\'-320\' LabelText=\'Default Display Form\'/>");
                }
                else if (form.Type == PAGETYPE.PAGE_EDITFORM)
                {
                    sbForms.Append(
                        $"<Button Id=\'Ribbon.List.Settings.EditDefaultForms.Menu.MS.EditDefaultFormDisplay\' CommandValueId=\'{form.ServerRelativeUrl}\' Command=\'EditDefaultForm\' Image16by16=\'/_layouts/{resWeb.Language}/images/formatmap16x16.png\' Image16by16Top=\'-32\' Image16by16Left=\'-80\' Image32by32=\'/_layouts/{resWeb.Language}/images/formatmap32x32.png\' Image32by32Top=\'-96\' Image32by32Left=\'-448\' LabelText=\'Default Edit Form\'/>");
                }
                else if (form.Type == PAGETYPE.PAGE_NEWFORM)
                {
                    sbForms.Append(
                        $"<Button Id=\'Ribbon.List.Settings.EditDefaultForms.Menu.MS.EditDefaultFormDisplay\' CommandValueId=\'{form.ServerRelativeUrl}\' Command=\'EditDefaultForm\' Image16by16=\'/_layouts/{resWeb.Language}/images/formatmap16x16.png\' Image16by16Top=\'-128\' Image16by16Left=\'-224\' Image32by32=\'/_layouts/{resWeb.Language}/images/formatmap32x32.png\' Image32by32Top=\'-128\' Image32by32Left=\'-96\' LabelText=\'Default New Form\'/>");
                }
            }

            return sbForms;
        }
    }
}