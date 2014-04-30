using System;
using System.Web;
using EPMLiveCore;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWebParts.Layouts.epmlive
{
    public partial class RedirectionProxy : LayoutsPageBase
    {
        #region Properties (1) 

        protected string Result { get; set; }

        #endregion Properties 

        #region Methods (1) 

        // Protected Methods (1) 

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string action = Request.QueryString["action"];
                string id = Request.QueryString["id"];
                string listId = Request.QueryString["listid"];
                string listName = Request.QueryString["listname"];
                string isDlg = Request.QueryString["isdlg"] ?? "1";

                bool noDlg;
                bool.TryParse(Request.QueryString["nodlg"], out noDlg);

                if (string.IsNullOrEmpty(action)) return;

                SPSite spSite = SPContext.Current.Site;
                SPWeb spWeb = spSite.OpenWeb(new Guid(Request.QueryString["webid"]));

                string safeServerRelativeUrl = spWeb.SafeServerRelativeUrl();

                string redirectUrl = string.Empty;

                if (string.IsNullOrEmpty(listName))
                {
                    if (!string.IsNullOrEmpty(listId))
                    {
                        try
                        {
                            listName = spWeb.Lists.GetList(new Guid(listId), true).Title;
                        }
                        catch { }
                    }
                }

                switch (action)
                {
                    case "new":
                        using (spWeb)
                        {
                            redirectUrl = string.Format(@"{0}/{1}?IsDlg={2}", safeServerRelativeUrl,
                                                        spWeb.Lists[listName].Forms[PAGETYPE.PAGE_NEWFORM].Url, isDlg);
                        }
                        break;
                    case "edit":
                        using (spWeb)
                        {
                            redirectUrl = string.Format(@"{0}/{1}?ID={2}&IsDlg={3}", safeServerRelativeUrl,
                                                        spWeb.Lists[listName].Forms[PAGETYPE.PAGE_EDITFORM].Url,
                                                        Request["id"], isDlg);
                        }
                        break;
                    case "view":
                        using (spWeb)
                        {
                            redirectUrl = string.Format(@"{0}/{1}?ID={2}&IsDlg={3}", safeServerRelativeUrl,
                                                        spWeb.Lists[listName].Forms[PAGETYPE.PAGE_DISPLAYFORM].Url,
                                                        Request["id"], isDlg);
                        }
                        break;
                    case "gotolist":
                        using (spWeb)
                        {
                            redirectUrl = string.Format(@"{0}{1}", spWeb.Lists[listName].DefaultViewUrl,
                                isDlg.Equals("1") ? "?isdlg=1" : string.Empty);
                        }
                        break;
                    case "comments":
                        using (spWeb)
                        {
                            redirectUrl =
                                string.Format(@"{0}/_layouts/epmlive/comments.aspx?listid={1}&itemid={2}&IsDlg={3}",
                                              safeServerRelativeUrl, Request.QueryString["listid"], id, isDlg);
                        }
                        break;
                    case "version":
                        using (spWeb)
                        {
                            SPList spList = spWeb.Lists[listName];
                            SPListItem spListItem = spList.GetItemById(int.Parse(Request["id"]));
                            redirectUrl =
                                string.Format(@"{0}/_layouts/versions.aspx?List={1}&ID={2}&Filename={3}&IsDlg={4}",
                                              safeServerRelativeUrl, spList.ID, id,
                                              HttpUtility.UrlEncode(spListItem.Url), isDlg);
                        }
                        break;
                    case "viewprofile":
                        using (spWeb)
                        {
                            redirectUrl = string.Format(@"{0}/_layouts/userdisp.aspx?ID={1}&IsDlg={2}",
                                                        safeServerRelativeUrl, id, isDlg);
                        }
                        break;
                    case "perms":
                        using (spWeb)
                        {
                            SPList spList = spWeb.Lists[listName];
                            redirectUrl =
                                string.Format(
                                    @"{0}/_layouts/user.aspx?obj={1},{2},LISTITEM&LIST={1}&Source={3}&IsDlg={4}",
                                    safeServerRelativeUrl, spList.ID, id, Request.QueryString["source"], isDlg);
                        }
                        break;
                    case "attachfile":
                        using (spWeb)
                        {
                            SPList spList = spWeb.Lists[listName];
                            redirectUrl = string.Format(
                                @"{0}/_layouts/AttachFile.aspx?ListId={1}&ItemId={2}&IsDlg={3}", safeServerRelativeUrl,
                                spList.ID, id, isDlg);
                        }
                        break;
                    case "alertme":
                        using (spWeb)
                        {
                            SPList spList = spWeb.Lists[listName];
                            redirectUrl = string.Format(
                                @"{0}/_layouts/subnew.aspx?List={1}&ItemId={2}&IsDlg={3}", safeServerRelativeUrl,
                                spList.ID, id, isDlg);
                        }
                        break;
                    case "showcomments":
                        using (spWeb)
                        {
                            SPList spList = spWeb.Lists[listName];
                            redirectUrl =
                                string.Format(@"{0}/_layouts/epmlive/comments.aspx?listid={1}&itemid={2}&IsDlg={3}",
                                              safeServerRelativeUrl, spList.ID, id, isDlg);
                        }
                        break;
                }

                if (string.IsNullOrEmpty(redirectUrl)) return;

                if (noDlg) redirectUrl = redirectUrl.ToLower().Replace("isdlg=1", string.Empty).Replace("isdlg=0", string.Empty);
                if (redirectUrl.EndsWith("?")) redirectUrl = redirectUrl.Replace("?", string.Empty);

                Response.Redirect(redirectUrl);
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
        }

        #endregion Methods 
    }
}