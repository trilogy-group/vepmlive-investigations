using System;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;

namespace EPMLiveWebParts
{
    [Guid("280587a3-950a-45f7-941f-2f803fc6dbfb")]
    public class EPMLiveQuickLaunchModifier : System.Web.UI.WebControls.WebParts.WebPart
    {
        public EPMLiveQuickLaunchModifier()
        {
        }

        protected override void Render(HtmlTextWriter writer)
        {
            try
            {
                SPWeb web = SPContext.Current.Web;
                web.Site.CatchAccessDeniedException = false;

                SPList pc = web.Lists["Project Center"];

                writer.Write(@"
                <script>
                    function replaceLink(hyperlink)
                    {
                        ");

                foreach (SPList list in web.Lists)
                {
                    SPQuery query = new SPQuery();
                    query.Query = "<OrderBy><FieldRef Name='ID'/></OrderBy>";

                    try
                    {
                        if (list.Items.Count > 0)
                        {
                            SPListItem li = list.GetItems(query)[0];

                            writer.Write("hyperlink.href = hyperlink.href.replace('{" + list.Title + "}', '" + li.ID + "');");
                        }
                        else
                        {
                            writer.Write(@"
                            if(hyperlink.href.indexOf('{" + list.Title + @"}') > 0)
                            {
                                hyperlink.href = '" + web.Url + "/" + list.Forms[PAGETYPE.PAGE_NEWFORM].Url + @"'
                            }");
                        }
                    }
                    catch
                    {

                    }
                }

                writer.Write(@"}
                    var i =0;
                    while(document.getElementById('zz3_QuickLaunchMenu2n'+i) != null)
                    { //&& i < divsArray.length){
                                            
                        var menu = document.getElementById('zz3_QuickLaunchMenu2n'+i);
                        var hyperlinks = menu.getElementsByTagName('a');  //looks for the hyperlink tags using the quicklaunch tag
                        
                         
                        hyperlinks[0].href = hyperlinks[0].href.replace('{Source}', location.href);
                        replaceLink(hyperlinks[0]);
                        i=i+1;
                    }
                    i =0;
                    while(document.getElementById('zz2_QuickLaunchMenu2n'+i) != null)
                    { //&& i < divsArray.length){
                                            
                        var menu = document.getElementById('zz2_QuickLaunchMenu2n'+i);
                        var hyperlinks = menu.getElementsByTagName('a');  //looks for the hyperlink tags using the quicklaunch tag
                        
                         
                        hyperlinks[0].href = hyperlinks[0].href.replace('{Source}', location.href);
                        replaceLink(hyperlinks[0]);
                        i=i+1;
                    }
                </script>

                ");
            }
            catch { }
        }
    }
}
