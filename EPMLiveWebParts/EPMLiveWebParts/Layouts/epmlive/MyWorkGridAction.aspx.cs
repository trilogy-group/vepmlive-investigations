using System;
using System.Web.UI;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    public class MyWorkGridAction : Page
    {
        #region Fields (1) 

        protected string Result;

        #endregion Fields 

        #region Methods (1) 

        // Protected Methods (1) 

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string action = Request.QueryString["action"];

                if (string.IsNullOrEmpty(action)) return;

                SPSite spSite = SPContext.Current.Site;
                string redirectUrl = string.Empty;

                switch (action)
                {
                    case "new":

                        using(SPWeb spWeb = spSite.OpenWeb(new Guid(Request.QueryString["webid"])))
                        {
                            redirectUrl = string.Format(@"{0}/{1}?IsDlg=1", spWeb.SafeServerRelativeUrl(),
                                                        spWeb.Lists[Request.QueryString["listname"]]
                                                        .Forms[PAGETYPE.PAGE_NEWFORM].Url);
                        }

                        break;
                    case "comments":

                        using (SPWeb spWeb = spSite.OpenWeb(new Guid(Request.QueryString["webid"])))
                        {
                            redirectUrl = string.Format(@"{0}/_layouts/epmlive/comments.aspx?listid={1}&itemid={2}&IsDlg=1",
                                                        spWeb.SafeServerRelativeUrl(), Request.QueryString["listid"],
                                                        Request.QueryString["ID"]);
                        }

                        break;
                }

                if (!string.IsNullOrEmpty(redirectUrl)) Response.Redirect(redirectUrl);
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
        }

        #endregion Methods 
    }
}