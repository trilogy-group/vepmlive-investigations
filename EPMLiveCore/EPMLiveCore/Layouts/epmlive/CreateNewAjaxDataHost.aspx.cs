using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Text;

namespace EPMLiveCore
{
    public partial class CreateNewAjaxDataHost : System.Web.UI.Page
    {
        private string _requestUrl = string.Empty;
        private const string LIST_ITEM_HTML =
             "<li id=\"{0}\" class=\"ms-core-menu-item\" type=\"option\" menugroupid=\"100\" description=\"{1}\" text=\"{2}\"" +
                         "iconsrc=\"{3}\" type=\"option\" enabled=\"true\" checked=\"false\"" +
                         "text_original=\"{2}\" description_original=\"{1}\">" +
                         "<a class=\"ms-core-menu-link\" href=\"{4}\" onclick=\"{5}\" >" +
                             "<div class=\"ms-hide\">" +
                                 "<img id=\"mp1_0_0_ICON\" title=\"\" alt=\"\" src=\"/_layouts/15/images/menuprofile.gif?rev=23\" width=\"32\" height=\"32\">" +
                             "</div>" +
                             "<div id=\"zz2_ID_PersonalInformation\" class=\"ms-core-menu-label\">" +
                                 "<span class=\"ms-core-menu-title\">{2}</span>" +
                                 "<span></span>" +
                             "</div>" +
                             "<span class=\"ms-accessible\"></span>" +
                             "<div></div>" +
                         "</a>" +
                     "</li>";

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            if (!string.IsNullOrEmpty(Request["requesturl"]))
            {
                _requestUrl = Request["requesturl"];
            }

            string retVal = BuildListItemHTML();
            Response.Output.WriteLine(!string.IsNullOrEmpty(retVal) ? retVal : string.Empty);
        }

        private string BuildListItemHTML()
        {
            StringBuilder itemsHtml = new StringBuilder();
            SPSite cSite = SPContext.Current.Site;
            SPWeb cWeb = SPContext.Current.Web;
            itemsHtml.Append("<ul class=\"ms-core-menu-list\">");
            itemsHtml.Append("<li class=\"ms-MenuUIULItem\"><div style=\"background-color: #F0F2F5 !important;border-bottom: 1px solid #E2E4E7;color: #4C535C;font-weight: bold !important;padding: 4px 2px !important;\"><span style=\"margin-left:5px\">Lists</span></div></li>");
            itemsHtml.Append(BuildListSection());
            itemsHtml.Append("<li class=\"ms-MenuUIULItem\"><div style=\"background-color: #F0F2F5 !important;border-bottom: 1px solid #E2E4E7;border-top: 1px solid #E2E4E7;color: #4C535C;font-weight: bold !important;padding: 4px 2px !important;\"><span style=\"margin-left:5px\">Document Libraries</span></div></li>");
            itemsHtml.Append(BuildDocumentLibrarySection());
            itemsHtml.Append("</ul>");
            return itemsHtml.ToString();
        }

        private string BuildListSection()
        {
            StringBuilder itemsHtml = new StringBuilder();
            SPSite cSite = SPContext.Current.Site;
            SPWeb cWeb = SPContext.Current.Web;

            for (int i = 0; i < cWeb.Lists.Count; i++)
            {
                if ((cWeb.Lists[i] is SPDocumentLibrary))
                {
                    continue;
                }

                string itemText = string.Empty;
                string description = string.Empty;
                string imageUrl = string.Empty;
                string linkUrl = string.Empty;
                string onclick = string.Empty;
                bool hideNewBtn = true;

                GridGanttSettings gSettings = new GridGanttSettings(cWeb.Lists[i]);


                // if list is not hidden or 
                // the hide new button option is not true
                if (!cWeb.Lists[i].Hidden)
                {
                    if (!cWeb.Lists[i].DoesUserHavePermissions(SPBasePermissions.AddListItems))
                    {
                        continue;
                    }

                    string sHideNewBtn = string.Empty;
                    hideNewBtn = gSettings.HideNewButton;

                    if (!hideNewBtn)
                    {
                        itemText = cWeb.Lists[i].Title;
                        string newItemText = gSettings.NewMenuName;

                        if (!string.IsNullOrEmpty(newItemText))
                        {
                            itemText = newItemText;
                        }

                        description = cWeb.Lists[i].Description;
                        imageUrl = cWeb.Lists[i].ImageUrl;

                        string rlists = string.Empty;
                        rlists = gSettings.RollupLists;

                        bool disableNewButtonMod = false;
                        string sDisableNewButtonMod = string.Empty;
                        disableNewButtonMod = gSettings.DisableNewItemMod;

                        bool useEnhancedNewMenu = false;
                        string sUseEnhancedNewMenu = string.Empty;
                        useEnhancedNewMenu = gSettings.UseNewMenu;

                        // if "Use Enhanced New Menu" option is turned on
                        // use the new create modal dialog
                        if (useEnhancedNewMenu && !disableNewButtonMod)
                        {
                            linkUrl = "#";
                            string createNewWorkspaceUrl = (cWeb.ServerRelativeUrl == "/" ? "" : cWeb.ServerRelativeUrl) + "/_layouts/epmlive/createnewworkspace.aspx?list=" + cWeb.Lists[i].ID.ToString("B") + "&type=site&source=" + _requestUrl;
                            onclick = "javascript:HideLayers();var options = { url:'" + createNewWorkspaceUrl + "', width: 800, height:600, title: 'Create', dialogReturnValueCallback : Function.createDelegate(null, HandleCreateNewWorkspaceCreate) }; SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options); return false;";
                        }
                        // check for roll up lists
                        // not a pop up
                        else if (!string.IsNullOrEmpty(rlists) && !disableNewButtonMod)
                        {
                            onclick = "";
                            string firstListLName = rlists.Split(',')[0];
                            linkUrl = (cWeb.ServerRelativeUrl == "/" ? "" : cWeb.ServerRelativeUrl) + "/_layouts/epmlive/newitem.aspx?List=" + firstListLName + "&source=" + _requestUrl;
                        }
                        // if content management is allowed
                        else if (cWeb.Lists[i].AllowContentTypes)
                        {
                            if (cWeb.Lists[i].NavigateForFormsPages)
                            {
                                onclick = "javascript:window.location.href='" + GetDefaultFormUrl(cWeb.Lists[i]) + "'; return false;";
                            }
                            else
                            {
                                onclick = "javascript:var options = { url:'" + GetDefaultFormUrl(cWeb.Lists[i]) + "', title: 'Create', dialogReturnValueCallback: function (dialogResult) { SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.RefreshPage', dialogResult) } }; SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options); return false;";
                            }
                        }
                        else
                        {
                            if (cWeb.Lists[i].NavigateForFormsPages)
                            {
                                onclick = "javascript:window.location.href='" + GetDefaultFormUrl(cWeb.Lists[i]) + "'; return false;";
                            }
                            else
                            {
                                onclick = "javascript:var options = { url:'" + GetDefaultFormUrl(cWeb.Lists[i]) + "', title: 'Create', dialogReturnValueCallback: function (dialogResult) { SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.RefreshPage', dialogResult) } }; SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options); return false;";
                            }
                        }

                        itemsHtml.Append(String.Format(LIST_ITEM_HTML, "MenuItem" + i, description, itemText, imageUrl, linkUrl, onclick));
                    }
                }
            }
            return itemsHtml.ToString();
        }

        private string BuildDocumentLibrarySection()
        {
            StringBuilder itemsHtml = new StringBuilder();
            SPSite cSite = SPContext.Current.Site;
            SPWeb cWeb = SPContext.Current.Web;

            for (int i = 0; i < cWeb.Lists.Count; i++)
            {
                if (!(cWeb.Lists[i] is SPDocumentLibrary))
                {
                    continue;
                }

                string itemText = string.Empty;
                string description = string.Empty;
                string imageUrl = string.Empty;
                string linkUrl = string.Empty;
                string onclick = string.Empty;
                bool hideNewBtn = true;

                GridGanttSettings gSettings = new GridGanttSettings(cWeb.Lists[i]);

                // if list is not hidden or 
                // the hide new button option is not true
                if (!cWeb.Lists[i].Hidden)
                {
                    if (!cWeb.Lists[i].DoesUserHavePermissions(SPBasePermissions.AddListItems))
                    {
                        continue;
                    }

                    string sHideNewBtn = string.Empty;
                    hideNewBtn = gSettings.HideNewButton;

                    if (!hideNewBtn)
                    {
                        itemText = cWeb.Lists[i].Title;
                        itemText = !string.IsNullOrEmpty(gSettings.NewMenuName) ? gSettings.NewMenuName : cWeb.Lists[i].Title;

                        description = cWeb.Lists[i].Description;
                        imageUrl = cWeb.Lists[i].ImageUrl;

                        string rlists = string.Empty;
                        rlists = gSettings.RollupLists;

                        bool disableNewButtonMod = false;
                        string sDisableNewButtonMod = string.Empty;
                        disableNewButtonMod = gSettings.DisableNewItemMod;

                        bool useEnhancedNewMenu = false;
                        string sUseEnhancedNewMenu = string.Empty;
                        useEnhancedNewMenu = gSettings.UseNewMenu;

                        // if "Use Enhanced New Menu" option is turned on
                        // use the new create modal dialog
                        if (useEnhancedNewMenu && !disableNewButtonMod)
                        {
                            linkUrl = "#";
                            string createNewWorkspaceUrl = cWeb.ServerRelativeUrl + "/_layouts/epmlive/createnewworkspace.aspx?list=" + cWeb.Lists[i].ID.ToString("B") + "&type=site&source=" + _requestUrl;
                            onclick = "javascript:var options = { url:'" + createNewWorkspaceUrl + "', width: 800, height:600, title: 'Create', dialogReturnValueCallback : Function.createDelegate(null, HandleCreateNewWorkspaceCreate) }; SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options); return false;";
                        }
                        // check for roll up lists
                        // not a pop up
                        else if (!string.IsNullOrEmpty(rlists) && !disableNewButtonMod)
                        {
                            onclick = "";
                            string firstListLName = rlists.Split(',')[0];
                            linkUrl = cWeb.ServerRelativeUrl + "/_layouts/epmlive/newitem.aspx?List=" + firstListLName + "&source=" + _requestUrl;
                        }
                        // if content management is allowed
                        else if (cWeb.Lists[i].AllowContentTypes)
                        {
                            if (cWeb.Lists[i].NavigateForFormsPages)
                            {
                                onclick = "javascript:window.location.href='" + GetDefaultFormUrl(cWeb.Lists[i]) + "'; return false;";
                            }
                            else
                            {
                                onclick = "javascript:var options = { url:'" + GetDefaultFormUrl(cWeb.Lists[i]) + "', title: 'Create', dialogReturnValueCallback: function (dialogResult) { SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.RefreshPage', dialogResult) } }; SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options); return false;";
                            }
                        }
                        else
                        {
                            if (cWeb.Lists[i].NavigateForFormsPages)
                            {
                                onclick = "javascript:window.location.href='" + GetDefaultFormUrl(cWeb.Lists[i]) + "'; return false;";
                            }
                            else
                            {
                                onclick = "javascript:var options = { url:'" + GetDefaultFormUrl(cWeb.Lists[i]) + "', title: 'Create', dialogReturnValueCallback: function (dialogResult) { SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.RefreshPage', dialogResult) } }; SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options); return false;";
                            }
                        }

                        itemsHtml.Append(String.Format(LIST_ITEM_HTML, "MenuItem" + i, description, itemText, imageUrl, linkUrl, onclick));
                    }
                }
            }
            return itemsHtml.ToString();
        }

        #region helper methods

        private string GetDefaultFormUrl(SPList list)
        {
            SPWeb cWeb = SPContext.Current.Web;

            string defaultNewFormUrl = list.DefaultNewFormUrl;

            if (defaultNewFormUrl.IndexOf('?') == -1)
            {
                defaultNewFormUrl += "?source=" + _requestUrl;
            }
            else
            {
                defaultNewFormUrl += "&source=" + _requestUrl;
            }

            return defaultNewFormUrl;
        }

        private bool TryListSettingByIndex(string properties, int propIndex, out string returnVal)
        {
            bool isSuccessful = true;
            returnVal = string.Empty;
            string[] props = properties.Split('\n');
            try
            {
                returnVal = props[propIndex];
            }
            catch
            {
                isSuccessful = false;
            }
            return isSuccessful;
        }

        #endregion

    }
}
