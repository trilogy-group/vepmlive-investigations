using System;
using System.Text;
using System.Web;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using EPMLiveCore.GlobalResources;

namespace EPMLiveCore
{
    public partial class ChangeAppAjaxDataHost : System.Web.UI.Page
    {
        private string _requestUrl = string.Empty;
        private int _btnChangeAppCurrentAppId = -1;
        private const string LIST_ITEM_HTML =
            "<li id=\"{0}\"class=\"ms-MenuUIULItem\" type=\"option\" menugroupid=\"100\" description=\"{1}\"" +
                        "text=\"{2}\"" +
                        "iconsrc=\"{3}\" type=\"option\" enabled=\"true\" checked=\"false\"" +
                        "text_original=\"{2}\" description_original=\"{1}\">" +
                        "<div class=\"ms-MenuUIULItem\" menugroupid=\"100\" description=\"{1}\"" +
                            "text=\"{2}\"" +
                            "iconsrc=\"{3}\" type=\"option\" enabled=\"true\" checked=\"false\"" +
                            "text_original=\"{2}\" description_original=\"{1}\"" +
                            "onmouseover=\"javascript:this.className='ms-MenuUIULItemHover';\" onmouseout=\"javascript:this.className='ms-MenuUIULItem';\">" +
                            "<a class=\"ms-MenuUIULLink\" href=\"{4}\" onclick=\"{5}\" >" +
                                "<span style=\"white-space: nowrap\" class=\"ms-MenuUIIcon\" align=\"center\">" +
                                    "<img class=\"ms-MenuUIULImg\" title=\"\" alt=\"\" src=\"{3}\" width=\"16\" height=\"16\">" +
                                "</span>" +
                                "<span style=\"WHITE-SPACE: nowrap\" class=\"ms-MenuUILabel\">" +
                                    "<span style=\"white-space: normal\">{2}</span><br>" +
            //"<span style=\"white-space: normal\" class=\"ms-menuitemdescription\">{1}</span>" +
                                    "<span></span>" +
                                "</span>" +
                                "<span style=\"width: auto; display: none; white-space: nowrap; cssfloat: left\" class=\"ms-MenuUIAccessKey\"></span>" +
                                "<span style=\"display: none; white-space: nowrap\" class=\"ms-MenuUISubmenuArrow\"></span>" +
                            "</a>" +
                        "</div>" +
                    "</li>";

        private const string LIST_ITEM_HTML_NO_ICON =
           "<li id=\"{0}\"class=\"ms-MenuUIULItem\" type=\"option\" menugroupid=\"100\" description=\"{1}\"" +
                       "text=\"{2}\"" +
                       "iconsrc=\"{3}\" type=\"option\" enabled=\"true\" checked=\"false\"" +
                       "text_original=\"{2}\" description_original=\"{1}\">" +
                       "<div class=\"ms-MenuUIULItem\" menugroupid=\"100\" description=\"{1}\"" +
                           "text=\"{2}\"" +
                           "iconsrc=\"{3}\" type=\"option\" enabled=\"true\" checked=\"false\"" +
                           "text_original=\"{2}\" description_original=\"{1}\"" +
                           "onmouseover=\"javascript:this.className='ms-MenuUIULItemHover';\" onmouseout=\"javascript:this.className='ms-MenuUIULItem';\">" +
                           "<a class=\"ms-MenuUIULLink\" href=\"{4}\" onclick=\"{5}\" >" +
                               "<span style=\"white-space: nowrap\" class=\"ms-MenuUIIcon\" align=\"center\">" +
                               "</span>" +
                               "<span style=\"WHITE-SPACE: nowrap\" class=\"ms-MenuUILabel\">" +
                                   "<span style=\"white-space: normal\">{2}</span><br>" +
            //"<span style=\"white-space: normal\" class=\"ms-menuitemdescription\">{1}</span>" +
                                   "<span></span>" +
                               "</span>" +
                               "<span style=\"width: auto; display: none; white-space: nowrap; cssfloat: left\" class=\"ms-MenuUIAccessKey\"></span>" +
                               "<span style=\"display: none; white-space: nowrap\" class=\"ms-MenuUISubmenuArrow\"></span>" +
                           "</a>" +
                       "</div>" +
                   "</li>";

        private const string LIST_ITEM_HTML_NEW_WIN =
            "<li id=\"{0}\"class=\"ms-MenuUIULItem\" type=\"option\" menugroupid=\"100\" description=\"{1}\"" +
                        "text=\"{2}\"" +
                        "iconsrc=\"{3}\" type=\"option\" enabled=\"true\" checked=\"false\"" +
                        "text_original=\"{2}\" description_original=\"{1}\">" +
                        "<div class=\"ms-MenuUIULItem\" menugroupid=\"100\" description=\"{1}\"" +
                            "text=\"{2}\"" +
                            "iconsrc=\"{3}\" type=\"option\" enabled=\"true\" checked=\"false\"" +
                            "text_original=\"{2}\" description_original=\"{1}\"" +
                            "onmouseover=\"javascript:this.className='ms-MenuUIULItemHover';\" onmouseout=\"javascript:this.className='ms-MenuUIULItem';\">" +
                            "<a class=\"ms-MenuUIULLink\" href=\"{4}\" onclick=\"{5}\" target=\"_blank\" >" +
                                "<span style=\"white-space: nowrap\" class=\"ms-MenuUIIcon\" align=\"center\">" +
                                    "<img class=\"ms-MenuUIULImg\" title=\"\" alt=\"\" src=\"{3}\" width=\"16\" height=\"16\">" +
                                "</span>" +
                                "<span style=\"WHITE-SPACE: nowrap\" class=\"ms-MenuUILabel\">" +
                                    "<span style=\"white-space: normal\">{2}</span><br>" +
            //"<span style=\"white-space: normal\" class=\"ms-menuitemdescription\">{1}</span>" +
                                    "<span></span>" +
                                "</span>" +
                                "<span style=\"width: auto; display: none; white-space: nowrap; cssfloat: left\" class=\"ms-MenuUIAccessKey\"></span>" +
                                "<span style=\"display: none; white-space: nowrap\" class=\"ms-MenuUISubmenuArrow\"></span>" +
                            "</a>" +
                        "</div>" +
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

            int.TryParse(Request["appid"], out _btnChangeAppCurrentAppId);
            string status = "error";
            string retVal = string.Empty;
            try
            {
                retVal = BuildListItemHTML();
                if (!string.IsNullOrEmpty(retVal))
                {
                    status = "success";
                }
            }
            catch
            { }

            Response.Output.WriteLine(status + "#;" + retVal);
        }

        private string BuildListItemHTML()
        {
            StringBuilder itemsHtml = new StringBuilder();
            SPSite cSite = SPContext.Current.Site;
            SPWeb cWeb = SPContext.Current.Web;
            bool hasItems = false;
            itemsHtml.Append("<ul class=\"ms-MenuUIUL\" style=\"width:253px;\">");
            //itemsHtml.Append("<li class=\"ms-MenuUIULItem\"><div style=\"background-color: #F0F2F5 !important;border-bottom: 1px solid #E2E4E7;color: #4C535C;font-weight: bold !important;padding: 4px 2px !important;\"><span style=\"margin-left:5px\">Lists</span></div></li>");
            string html = BuildListSection();
            hasItems = !string.IsNullOrEmpty(html) ? true : false;

            if (hasItems)
            {
                itemsHtml.Append(html);
            }
            string onclick = "";
            onclick = GetCommOnClick();

            if (isCurrentUserRolesGreaterOrEqualThan("Design"))
            {
                itemsHtml.Append("<li class=ms-MenuUIULItem type=\"separator\"><div class=\"ms-MenuUISeparator\" type=\"separator\">&nbsp;</div></li>");
                itemsHtml.Append(string.Format(LIST_ITEM_HTML, "MenuItem_CreateCom", "Create Community", "Create Community", "/_layouts/epmlive/images/addcommunity16.gif", "#", onclick));
                itemsHtml.Append("<li class=ms-MenuUIULItem type=\"separator\"><div class=\"ms-MenuUISeparator\" type=\"separator\">&nbsp;</div></li>");
                itemsHtml.Append(string.Format(LIST_ITEM_HTML_NEW_WIN, "MenuItem_AddApp", "Add App", "Add App", "/_layouts/epmlive/images/installapplication16.gif", "http://market.epmlive.com/?source=" + SPContext.Current.Web.Url, ""));
            }

            itemsHtml.Append("</ul>");

            return itemsHtml.ToString();
        }

        private string BuildListSection()
        {
            StringBuilder itemsHtml = new StringBuilder();
            string itemText = string.Empty;
            string description = string.Empty;
            string imageUrl = string.Empty;
            //string linkUrl = SPContext.Current.Web.Url + "/_layouts/epmlive/ChangeApp.aspx?appid={0}&desturl={1}";
            string linkUrl = string.Empty;
            string homePageUrl = string.Empty;
            string onclick = string.Empty;
            SPUser originalUser = SPContext.Current.Web.CurrentUser;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Web.Url))
                {
                    using (SPWeb ew = es.OpenWeb())
                    {
                        SPList list = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);
                        if (list != null)
                        {
                            Guid fld_Id_Title = list.Fields.GetFieldByInternalName("Title").Id;
                            Guid fld_Id_Description = list.Fields.GetFieldByInternalName("Description").Id;
                            Guid fld_Id_ImageUrl = list.Fields.GetFieldByInternalName("Icon").Id;
                            Guid fld_Id_EXTID = list.Fields.GetFieldByInternalName("EXTID").Id;
                            Guid fld_Id_HomePage = list.Fields.GetFieldByInternalName("HomePage").Id;
                            // save listitems collection in memory 
                            // for performance
                            SPListItemCollection listItems = list.Items;
                            for (int i = 0; i < listItems.Count; i++)
                            {
                                // skip the current app
                                if ((listItems[i].ID == _btnChangeAppCurrentAppId) ||
                                    (bool.Parse(listItems[i]["Visible"].ToString()) == false))
                                {
                                    continue;
                                }

                                if (listItems[i].DoesUserHavePermissions(originalUser, SPBasePermissions.ViewListItems))
                                {
                                    itemText = GetItemFieldValueInString(listItems[i], fld_Id_Title);
                                    description = GetItemFieldValueInString(listItems[i], fld_Id_Description);
                                    imageUrl = GetUrlFieldValueInString(listItems[i], fld_Id_ImageUrl);
                                    //imageUrl = "/_layouts/epmlive/images/installapplication16.gif";
                                    homePageUrl = GetUrlFieldValueInString(listItems[i], fld_Id_HomePage);
                                    //linkUrl = !string.IsNullOrEmpty(homePageUrl) ?
                                    //    string.Format(linkUrl, (listItems[i]).ID.ToString(), homePageUrl) :
                                    //    string.Format(linkUrl, (listItems[i]).ID.ToString(), ew.Url);

                                    onclick = !string.IsNullOrEmpty(homePageUrl) ?
                                        ConstructOnClick(homePageUrl, (listItems[i]).ID.ToString()) :
                                        ConstructOnClick(ew.Url, (listItems[i]).ID.ToString());

                                    itemsHtml.Append(string.Format(LIST_ITEM_HTML_NO_ICON, "MenuItem" + i, description, itemText, imageUrl, linkUrl, onclick));
                                }

                            }
                        }
                    }
                }
            });

            return itemsHtml.ToString();
        }

        #region helper methods

        private bool isCurrentUserRolesGreaterOrEqualThan(string role)
        {
            //User's permission level
            bool limitedAccess = false;
            bool read = false;
            bool contribute = false;
            bool design = false;
            bool fullControl = false;

            //Current web
            SPWeb web = SPContext.Current.Web;

            //Gets all user's roles
            SPRoleDefinitionBindingCollection usersRoles = web.AllRolesForCurrentUser;

            //Role definitions to compare with user's roles
            SPRoleDefinitionCollection roleDefinitions = web.RoleDefinitions;

            //Checks user's permission level-Read, Contribute, Design, Full Control, and Limited Access
            if (usersRoles.Contains(roleDefinitions["Read"]))
                read = true;
            if (usersRoles.Contains(roleDefinitions["Contribute"]))
                contribute = true;
            if (usersRoles.Contains(roleDefinitions["Design"]))
                design = true;
            if (usersRoles.Contains(roleDefinitions["Full Control"]))
                fullControl = true;
            if (usersRoles.Contains(roleDefinitions["Limited Access"]))
                limitedAccess = true;

            //Compares given role with user's permission level
            if (role == "Limited Access")
                if (limitedAccess || read || contribute || design || fullControl)
                    return true;
            if (role == "Read")
                if (read || contribute || design || fullControl)
                    return true;
            if (role == "Contribute")
                if (contribute || design || fullControl)
                    return true;
            if (role == "Design")
                if (design || fullControl)
                    return true;
            if (role == "Full Control")
                if (fullControl)
                    return true;

            SPUser currentUser = web.CurrentUser;
            if (currentUser.IsSiteAdmin || web.UserIsWebAdmin)
            {
                return true;
            }

            return false;
        }


        private string GetCommOnClick()
        {
            string txt = "OpenUrlWithModal('" + SPContext.Current.Web.Url + "/_layouts/epmlive/Applications/AddCommunity.aspx', 'Add Community')";
            return txt;
        }

        private string ConstructOnClick(string homePageUrl, string itemId)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(homePageUrl))
            {
                result = "AsyncChangeApp('" + homePageUrl + "', '" + itemId + "'); return false;";
            }

            return result;
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

        private string GetItemFieldValueInString(SPListItem item, Guid fieldId)
        {
            string result = string.Empty;
            object fv = null;

            try
            {
                fv = item[fieldId];
            }
            catch { }

            if (fv != null)
            {
                result = fv.ToString();
            }

            return result;
        }

        private string GetUrlFieldValueInString(SPListItem item, Guid fieldId)
        {
            string result = string.Empty;
            object fv = null;

            try
            {
                fv = item[fieldId];
            }
            catch { }

            if (fv != null)
            {
                SPFieldUrlValue v = new SPFieldUrlValue(fv.ToString());
                result = v.Url;
            }

            return result;
        }
        #endregion
    }
}
