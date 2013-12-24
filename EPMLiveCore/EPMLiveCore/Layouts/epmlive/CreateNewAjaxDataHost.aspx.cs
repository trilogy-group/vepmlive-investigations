using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Text;
using System.Collections.Generic;

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
            SPWeb cWeb = SPContext.Current.Web;

            Dictionary<int, string[]> dict = GetCreatableLists(cWeb, _requestUrl);

            if (dict.Count > 0)
            {
                foreach (var pair in dict)
                {
                    var desc = pair.Value[0];
                    var text = pair.Value[1];
                    var imgUrl = pair.Value[2];
                    var url = pair.Value[3];
                    var onClick = pair.Value[4];

                    itemsHtml.Append(String.Format(LIST_ITEM_HTML, "MenuItem" + pair.Key, desc, text, imgUrl, url, onClick));
                }
            }

            return itemsHtml.ToString();
        }

        public static Dictionary<int, string[]> GetCreatableLists(SPWeb cWeb, string requestUrl = null)
        {
            var dict = new Dictionary<int, string[]>();
            requestUrl = requestUrl ?? string.Empty;

            var count = cWeb.Lists.Count;
            for (int i = 0; i < count; i++)
            {
                var list = cWeb.Lists[i];
                if ((list is SPDocumentLibrary))
                {
                    continue;
                }

                string itemText = string.Empty;
                string description = string.Empty;
                string imageUrl = string.Empty;
                string linkUrl = string.Empty;
                string onclick = string.Empty;
                bool hideNewBtn = true;

                GridGanttSettings gSettings = new GridGanttSettings(list);

                // if list is not hidden or 
                // the hide new button option is not true
                if (!list.Hidden)
                {
                    if (!list.DoesUserHavePermissions(SPBasePermissions.AddListItems))
                    {
                        continue;
                    }

                    string sHideNewBtn = string.Empty;
                    hideNewBtn = gSettings.HideNewButton;

                    if (!hideNewBtn)
                    {
                        itemText = list.Title;
                        string newItemText = gSettings.NewMenuName;

                        if (!string.IsNullOrEmpty(newItemText))
                        {
                            itemText = newItemText;
                        }

                        description = list.Description;
                        imageUrl = list.ImageUrl;

                        //string rlists = string.Empty;
                        //rlists = gSettings.RollupLists;

                        //bool disableNewButtonMod = false;
                        //string sDisableNewButtonMod = string.Empty;
                        //disableNewButtonMod = gSettings.DisableNewItemMod;

                        //bool useEnhancedNewMenu = false;
                        //string sUseEnhancedNewMenu = string.Empty;
                        //useEnhancedNewMenu = gSettings.UseNewMenu;

                        // if "Use Enhanced New Menu" option is turned on
                        // use the new create modal dialog
                        //if (useEnhancedNewMenu && !disableNewButtonMod)
                        //{
                        //    linkUrl = "#";
                        //    string createNewWorkspaceUrl = (cWeb.ServerRelativeUrl == "/" ? "" : cWeb.ServerRelativeUrl) + "/_layouts/epmlive/createnewworkspace.aspx?list=" + list.ID.ToString("B") + "&type=site&source=" + requestUrl;
                        //    onclick = "javascript:HideLayers();var options = { url:'" + createNewWorkspaceUrl + "', width: 800, height:600, title: 'Create', dialogReturnValueCallback : Function.createDelegate(null, HandleCreateNewWorkspaceCreate) }; SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options); return false;";
                        //}
                        // check for roll up lists
                        // not a pop up
                        //else if (!string.IsNullOrEmpty(rlists) && !disableNewButtonMod)
                        //{
                        //    onclick = "";
                        //    string firstListLName = rlists.Split(',')[0];
                        //    linkUrl = (cWeb.ServerRelativeUrl == "/" ? "" : cWeb.ServerRelativeUrl) + "/_layouts/epmlive/newitem.aspx?List=" + firstListLName + "&source=" + requestUrl;
                        //}
                        // if content management is allowed
                        if (list.AllowContentTypes)
                        {
                            if (list.NavigateForFormsPages)
                            {
                                var url = GetDefaultFormUrl(list, requestUrl);
                                onclick = !string.IsNullOrEmpty(url) ? "javascript:window.location.href='" + url + "'; return false;" : "";
                            }
                            else
                            {
                                var url = GetDefaultFormUrl(list, requestUrl);
                                onclick = !string.IsNullOrEmpty(url) ? "javascript:var options = { url:'" + url + "', title: 'Create', dialogReturnValueCallback: function (dialogResult) { SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.RefreshPage', dialogResult) } }; SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options); return false;" : "";
                            }
                        }
                        else
                        {
                            if (list.NavigateForFormsPages)
                            {
                                var url = GetDefaultFormUrl(list, requestUrl);
                                onclick = !string.IsNullOrEmpty(url) ? "javascript:window.location.href='" + url + "'; return false;" : "";
                            }
                            else
                            {
                                var url = GetDefaultFormUrl(list, requestUrl);
                                onclick = !string.IsNullOrEmpty(url) ? "javascript:var options = { url:'" + url + "', title: 'Create', dialogReturnValueCallback: function (dialogResult) { SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.RefreshPage', dialogResult) } }; SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options); return false;" : "";
                            }
                        }

                        dict.Add(i, new [] { description, itemText, imageUrl, linkUrl, onclick });
                    }
                }
            }

            return dict;
        }

        private string BuildDocumentLibrarySection()
        {
            StringBuilder itemsHtml = new StringBuilder();
            SPWeb cWeb = SPContext.Current.Web;

            Dictionary<int, string[]> dict = GetCreatableLibraries(cWeb, _requestUrl);

            if (dict.Count > 0)
            {
                foreach (var pair in dict)
                {
                    var desc = pair.Value[0];
                    var text = pair.Value[1];
                    var imgUrl = pair.Value[2];
                    var url = pair.Value[3];
                    var onClick = pair.Value[4];

                    itemsHtml.Append(String.Format(LIST_ITEM_HTML, "MenuItem" + pair.Key, desc, text, imgUrl, url, onClick));
                }
            }

            return itemsHtml.ToString();
        }

        public static Dictionary<int, string[]> GetCreatableLibraries(SPWeb cWeb, string requestUrl = null)
        {
            var dict = new Dictionary<int, string[]>();
            requestUrl = requestUrl ?? string.Empty;

            var count = cWeb.Lists.Count;
            for (int i = 0; i < count; i++)
            {
                var list = cWeb.Lists[i];

                if (!(list is SPDocumentLibrary))
                {
                    continue;
                }

                string itemText = string.Empty;
                string description = string.Empty;
                string imageUrl = string.Empty;
                string linkUrl = string.Empty;
                string onclick = string.Empty;
                bool hideNewBtn = true;

                GridGanttSettings gSettings = new GridGanttSettings(list);

                // if list is not hidden or 
                // the hide new button option is not true
                if (!list.Hidden)
                {
                    if (!list.DoesUserHavePermissions(SPBasePermissions.AddListItems))
                    {
                        continue;
                    }

                    string sHideNewBtn = string.Empty;
                    hideNewBtn = gSettings.HideNewButton;

                    if (!hideNewBtn)
                    {
                        try
                        {
                            itemText = list.Title;
                            itemText = !string.IsNullOrEmpty(gSettings.NewMenuName) ? gSettings.NewMenuName : list.Title;

                            description = list.Description;
                            imageUrl = list.ImageUrl;

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
                                string createNewWorkspaceUrl = cWeb.ServerRelativeUrl + "/_layouts/epmlive/createnewworkspace.aspx?list=" + list.ID.ToString("B") + "&type=site&source=" + requestUrl;
                                onclick = "javascript:var options = { url:'" + createNewWorkspaceUrl + "', width: 800, height:600, title: 'Create', dialogReturnValueCallback : Function.createDelegate(null, HandleCreateNewWorkspaceCreate) }; SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options); return false;";
                            }
                            // check for roll up lists
                            // not a pop up
                            else if (!string.IsNullOrEmpty(rlists) && !disableNewButtonMod)
                            {
                                onclick = "";
                                string firstListLName = rlists.Split(',')[0];
                                linkUrl = cWeb.ServerRelativeUrl + "/_layouts/epmlive/newitem.aspx?List=" + firstListLName + "&source=" + requestUrl;
                            }
                            // if content management is allowed
                            else if (list.AllowContentTypes)
                            {
                                if (list.NavigateForFormsPages)
                                {
                                    var url = GetDefaultFormUrl(list, requestUrl);
                                    onclick = !string.IsNullOrEmpty(url) ? "javascript:window.location.href='" + url + "'; return false;" : "";
                                }
                                else
                                {
                                    var url = GetDefaultFormUrl(list, requestUrl);
                                    onclick = !string.IsNullOrEmpty(url) ? "javascript:var options = { url:'" + url + "', title: 'Create', dialogReturnValueCallback: function (dialogResult) { SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.RefreshPage', dialogResult) } }; SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options); return false;" : "";
                                }
                            }
                            else
                            {
                                if (list.NavigateForFormsPages)
                                {
                                    var url = GetDefaultFormUrl(list, requestUrl);
                                    onclick = !string.IsNullOrEmpty(url) ? "javascript:window.location.href='" + url + "'; return false;" : "";
                                }
                                else
                                {
                                    var url = GetDefaultFormUrl(list, requestUrl);
                                    onclick = !string.IsNullOrEmpty(url) ? "javascript:var options = { url:'" + url + "', title: 'Create', dialogReturnValueCallback: function (dialogResult) { SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.RefreshPage', dialogResult) } }; SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options); return false;" : "";
                                }
                            }

                            dict.Add(i, new[] { description, itemText, imageUrl, linkUrl, onclick });
                        }
                        catch { }
                    }
                }
            }

            return dict;
        }

        #region helper methods

        private static string GetDefaultFormUrl(SPList list, string requestUrl)
        {
            //var defaultNewFormUrl = string.Empty;
            string defaultNewFormUrl = list.DefaultNewFormUrl;

            //if (!string.IsNullOrEmpty(list.DefaultNewFormUrl))
            //{
                if (defaultNewFormUrl.IndexOf('?') == -1)
                {
                    defaultNewFormUrl += "?source=" + requestUrl;
                }
                else
                {
                    defaultNewFormUrl += "&source=" + requestUrl;
                }
            //}

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
