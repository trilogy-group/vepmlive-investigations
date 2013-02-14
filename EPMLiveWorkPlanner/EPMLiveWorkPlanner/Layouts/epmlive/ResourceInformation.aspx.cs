using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWorkPlanner
{
    public partial class ResourceInformation : LayoutsPageBase
    {
        protected string sError = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            SPList list = null;
            string resUrl = EPMLiveCore.CoreFunctions.getLockConfigSetting(web, "EPMLiveResourceURL", false);

            string dspform = "";

            if(resUrl.ToLower() == web.ServerRelativeUrl.ToLower())
            {
                list = web.Lists.TryGetList("Resources");
                if(list != null)
                    dspform = web.Url + "/" + list.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url;
            }
            else
            {
                using(SPSite rsite = new SPSite(resUrl))
                {
                    using(SPWeb rweb = rsite.OpenWeb())
                    {
                        list = rweb.Lists.TryGetList("Resources");
                        if(list != null)
                            dspform = rweb.Url + "/" + list.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url;
                    }
                }
            }

            if(list != null)
                Response.Redirect(dspform + "?ID=" + Request["ID"].Split('.')[1] + "&isDlg=1");
            else
                sError = "Resource List Not Found";
        }
    }
}
