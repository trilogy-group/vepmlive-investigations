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
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public partial class gotoresources : LayoutsPageBase
    {
        protected Panel pnlAdmin;
        protected HyperLink hlAdmin;
        protected Panel pnlFeature;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SPWeb web = SPContext.Current.Web;


                string url = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL").Trim();

                if (url != "" && url.ToLower() != web.ServerRelativeUrl.ToLower())
                {
                    pnlAdmin.Visible = true;
                    hlAdmin.NavigateUrl = ((url == "/")?"":url) + "/_layouts/epmlive/gotoresources.aspx";
                }
                else
                {
                    SPList list = null;
                    try
                    {
                        list = web.Lists[CoreFunctions.getConfigSetting(web, "EPMLiveResourcePool")];
                    }
                    catch { }
                    if (list == null)
                    {
                        pnlFeature.Visible = true;
                    }
                    else
                    {
                        bool bAdding = false;
                        bool bUpdating = false;
                        bool bDeleted = false;

                        foreach(SPEventReceiverDefinition spEventDef in list.EventReceivers)
                        {
                            if(spEventDef.Class.ToLower() == "epmlivecore.resourcepoolevent")
                            {
                                if(spEventDef.Type == SPEventReceiverType.ItemUpdating)
                                    bUpdating = true;
                                if(spEventDef.Type == SPEventReceiverType.ItemAdding)
                                    bAdding = true;
                                if(spEventDef.Type == SPEventReceiverType.ItemDeleting)
                                    bDeleted = true;
                            }
                        }
                        web.AllowUnsafeUpdates = true;
                        web.Site.CatchAccessDeniedException = false;
                        try
                        {
                            if(!bUpdating)
                            {
                                list.EventReceivers.Add(SPEventReceiverType.ItemUpdating, "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveCore.ResourcePoolEvent");
                                list.Update();
                            }
                            if(!bAdding)
                            {
                                list.EventReceivers.Add(SPEventReceiverType.ItemAdding, "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveCore.ResourcePoolEvent");
                                list.Update();
                            }
                            if(!bDeleted)
                            {
                                list.EventReceivers.Add(SPEventReceiverType.ItemDeleting, "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveCore.ResourcePoolEvent");
                                list.Update();
                            }
                        }
                        catch { }
                        Response.Redirect(list.DefaultView.ServerRelativeUrl);
                    }
                }
                //web.Close();
            }
        }

        protected void lnkButton_Click(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            web.AllowUnsafeUpdates = true;
            string url = "";

            Guid gList = web.Lists.Add(CoreFunctions.getConfigSetting(web, "EPMLiveResourcePool"), "Use this list to manage your resources for EPM Live", SPListTemplateType.GenericList);
            SPList list = web.Lists[gList];
            list.Fields.Add("SharePointAccount", SPFieldType.User, false);
            list.Update();
            url = list.DefaultView.ServerRelativeUrl;
            //web.Close();

            Response.Redirect(url);
        }

    }
}