using EPMLiveCore;
using EPMLiveCore.API;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Xml;

namespace EPMLiveWebParts.AssociatedItems
{
    [ToolboxItemAttribute(false)]
    public partial class AssociatedItems : WebPart
    {
        string strMenu = string.Empty;

        #region SP Events



        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected override void CreateChildControls()
        {
            SPWeb oWeb = SPContext.Current.Web;

            string serviceUrl = ((SPContext.Current.Web.ServerRelativeUrl == "/")
                                     ? ""
                                     : SPContext.Current.Web.ServerRelativeUrl) + "/_vti_bin/Workengine.asmx";

            ScriptManager scriptManager = ScriptManager.GetCurrent(Page);

            if (scriptManager != null)
            {
                scriptManager.Services.Add(new ServiceReference(serviceUrl));
            }
            else
            {
                scriptManager = new ScriptManager();
                scriptManager.Services.Add(new ServiceReference(serviceUrl));

                Page.Form.Controls.Add(scriptManager);
            }
        }

        #endregion

        #region Get Associated Items

        /// <summary>
        /// 
        /// </summary>
        protected void PrepareAssociatedListsString()
        {
            StringBuilder mainDivHtml = new StringBuilder();
            ArrayList arrAssociatedLists = EPMLiveCore.API.ListCommands.GetAssociatedLists(SPContext.Current.List);
            int rec = 0;

            if (arrAssociatedLists != null && arrAssociatedLists.Count > 0)
            {
                foreach (AssociatedListInfo item in arrAssociatedLists)
                {
                    rec++;
                    mainDivHtml.Append("<div id='div_" + Convert.ToString(item.ListId) + "' class='listMainDiv'>" + item.Title + " [0]</div>");
                    if (rec != arrAssociatedLists.Count)
                        mainDivHtml.Append("<div class='pipeSeperator'>|</div>");
                }
                associatedItemsDiv.InnerHtml = mainDivHtml.ToString();

                mainDivHtml = new StringBuilder();
                mainDivHtml.Append("<ProjectAssociatedItems>");
                mainDivHtml.Append("<SiteUrl>" + SPContext.Current.Site.Url + "</SiteUrl>");
                mainDivHtml.Append("<SiteID>" + Convert.ToString(SPContext.Current.Site.ID) + "</SiteID>");
                mainDivHtml.Append("<WebID>" + Convert.ToString(SPContext.Current.Web.ID) + "</WebID>");
                mainDivHtml.Append("<ProjectListID>" + Convert.ToString(SPContext.Current.ListId) + "</ProjectListID>");
                mainDivHtml.Append("<ProjectID>" + Convert.ToString(SPContext.Current.ItemId) + "</ProjectID>");
                mainDivHtml.Append("<ProjectTitle>" + SPContext.Current.ListItem.Title + "</ProjectTitle>");
                mainDivHtml.Append("</ProjectAssociatedItems>");

                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "dataXml", "<script type=\"text/javascript\">var dataXml='" + mainDivHtml.ToString() + "';</script>");
            }
        }

        #endregion

        #region Page_Load Event

        protected void Page_Load(object sender, EventArgs e)
        {
            PrepareAssociatedListsString();
        }

        #endregion
    }
}
