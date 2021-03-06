﻿using System;
using System.Text;
using System.Web;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using static EPMLiveCore.Layouts.epmlive.LayoutsHelper;

namespace EPMLiveCore
{
    public partial class CommonActionsAjaxDataHost : System.Web.UI.Page
    {
        private string _requestUrl = string.Empty;
        private const string COMMON_ACTIONS_LIST_NAME = "Common Actions";
        private const string COL_TITLE = "Title";
        private const string COL_DESCRIPTION = "Description";
        private const string COL_URL = "URL";
        private const string COL_NEW_WINDOW = "NewWindow";
        private const string COL_IMAGE_URL = "ImageUrl";

        // {0} - listItem Id
        // {1} - description
        // {2} - text of the list item 
        // {3} - imageUrl
        // {4} - link Url
        // {5} - target property of the link

        protected void Page_Load(object sender, EventArgs e)
        {
            SimplePageLoad(Response, Request, ref _requestUrl, BuildListItemHTML());
        }

        private string BuildListItemHTML()
        {
            StringBuilder itemsHtml = new StringBuilder();
            itemsHtml.Append("<ul class=\"ms-core-menu-list\">");
            SPSite site = SPContext.Current.Site;
            SPWeb web = SPContext.Current.Web;
            SPList commonActionsList = web.Lists.TryGetList(COMMON_ACTIONS_LIST_NAME);
            SPListItemCollection sortedItems = null;

            if (commonActionsList != null)
            {
                SPQuery q = new SPQuery();
                q.Query = "<OrderBy><FieldRef Name=\"Order0\" Ascending=\"True\" /><FieldRef Name=\"LinkTitle\" Ascending=\"True\" /></OrderBy>";
                sortedItems = commonActionsList.GetItems(q);
            }

            if (sortedItems != null)
            {
                for (int i = 0; i < sortedItems.Count; i++)
                {
                    string itemText = string.Empty;
                    string description = string.Empty;
                    string linkUrl = string.Empty;
                    string newWindow = string.Empty;
                    string imageUrl = string.Empty;
                    string onclick = string.Empty;

                    bool isPopup = false;

                    // get title
                    if (FieldExists(COMMON_ACTIONS_LIST_NAME, sortedItems[i], COL_TITLE))
                    {
                        object titleField = sortedItems[i][commonActionsList.Fields.GetFieldByInternalName(COL_TITLE).Id];

                        if (titleField != null && !string.IsNullOrEmpty(titleField.ToString()))
                        {
                            itemText = titleField.ToString();
                        }
                    }

                    // get description
                    if (FieldExists(COMMON_ACTIONS_LIST_NAME, sortedItems[i], COL_DESCRIPTION))
                    {
                        description = "Description for common action " + (i + 1).ToString();
                        object descriptionField = sortedItems[i][commonActionsList.Fields.GetFieldByInternalName(COL_DESCRIPTION).Id];

                        if (descriptionField != null && !string.IsNullOrEmpty(SPHttpUtility.ConvertSimpleHtmlToText(descriptionField.ToString(), -1)))
                        {
                            description = SPHttpUtility.ConvertSimpleHtmlToText(descriptionField.ToString(), -1);
                        }
                    }

                    if (FieldExists(COMMON_ACTIONS_LIST_NAME, sortedItems[i], COL_NEW_WINDOW))
                    {
                        string openInNewWindowValue = string.Empty;
                        if (sortedItems[i][commonActionsList.Fields.GetFieldByInternalName(COL_NEW_WINDOW).Id] != null)
                        {
                            openInNewWindowValue = sortedItems[i][commonActionsList.Fields.GetFieldByInternalName(COL_NEW_WINDOW).Id].ToString();
                        }

                        if (!string.IsNullOrEmpty(openInNewWindowValue))
                        {
                            switch (openInNewWindowValue)
                            {
                                case "Same window":
                                    newWindow = "_self";
                                    break;
                                case "New window":
                                    newWindow = "_blank";
                                    break;
                                case "Popup":
                                    newWindow = "";
                                    isPopup = true;
                                    break;
                                default:
                                    newWindow = "_self";
                                    break;
                            }
                        }
                        else
                        {
                            newWindow = "_self";
                        }
                    }

                    // get link Url
                    if (FieldExists(COMMON_ACTIONS_LIST_NAME, sortedItems[i], COL_URL))
                    {   
                        if (sortedItems[i][commonActionsList.Fields.GetFieldByInternalName(COL_URL).Id] != null)
                        {
                            linkUrl = new SPFieldUrlValue(sortedItems[i][commonActionsList.Fields.GetFieldByInternalName(COL_URL).Id].ToString()).Url;
                            if (linkUrl.IndexOf('?') != -1)
                            {
                                linkUrl += ("&source=" + _requestUrl);
                            }
                            else {
                                linkUrl += ("?source=" + _requestUrl);
                            }
                        }

                        if (linkUrl.StartsWith("/", StringComparison.CurrentCultureIgnoreCase))
                        {
                            linkUrl = (SPContext.Current.Web.ServerRelativeUrl == "/" ? "" : SPContext.Current.Web.ServerRelativeUrl) + linkUrl;
                        }

                        if (isPopup)
                        {   
                            string popupUrl = linkUrl;
                            onclick = "javascript:var options = { url:'" + linkUrl + "', title: '" + itemText + "' }; SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options); return false;";
                            linkUrl = "#";
                        }
                    }

                    // get image url from link field
                    if (FieldExists(COMMON_ACTIONS_LIST_NAME, sortedItems[i], COL_IMAGE_URL))
                    {
                        if (sortedItems[i][commonActionsList.Fields.GetFieldByInternalName(COL_IMAGE_URL).Id] != null)
                        {
                            imageUrl = new SPFieldUrlValue(sortedItems[i][commonActionsList.Fields.GetFieldByInternalName(COL_IMAGE_URL).Id].ToString()).Url;
                        }
                        
                        if (string.IsNullOrEmpty(imageUrl))
                        {
                            imageUrl = "/_layouts/EPMLive/images/WESite.png";
                        }
                    }

                    itemsHtml.Append(String.Format(LIST_ITEM_HTML, "MenuItem" + i, description, itemText, imageUrl, linkUrl, newWindow, onclick));
                }

                itemsHtml.Append("</ul>");
            }

            return itemsHtml.ToString();
        }

        private bool FieldExists(string listName, SPListItem item, string fieldName)
        {
            bool exists = false;

            SPList list = SPContext.Current.Web.Lists.TryGetList(listName);
            SPField testFld = null;

            if (list != null)
            {
                try
                {
                    testFld = list.Fields.GetFieldByInternalName(fieldName);
                }
                catch (ArgumentException x)
                {
                    testFld = null;
                }
            }

            exists = testFld != null;

            return exists;
        }

        private bool WebExists(string url)
        {
            bool exists = false;
            try
            {
                using (SPSite site = new SPSite(url))
                {
                    using (SPWeb cWeb = site.OpenWeb())
                    {
                        exists = cWeb.Exists;
                    }
                }
            }
            catch
            {
                exists = false;
            }

            return exists;
        }
    }
}
