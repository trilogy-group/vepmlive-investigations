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
        
        private const string LIST_ITEM_HTML_NEW_WIN =
            "<li id=\"{0}\"class=\"ms-core-menu-item\" type=\"option\" menugroupid=\"100\" description=\"{1}\" text=\"{2}\"" +
                        "iconsrc=\"{3}\" type=\"option\" enabled=\"true\" checked=\"false\"" +
                        "text_original=\"{2}\" description_original=\"{1}\">" +
                        "<a class=\"ms-core-menu-link\" href=\"{4}\" onclick=\"{5}\" target=\"_blank\" >" +
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
            itemsHtml.Append("<ul class=\"ms-core-menu-list\">");
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
                itemsHtml.Append("<li id=\"mp1_0_2\" class=\"ms-core-menu-separator\" type=\"separator\" type=\"separator\"><hr class=\"ms-core-menu-separatorHr\"></li>");
                itemsHtml.Append(string.Format(LIST_ITEM_HTML, "MenuItem_CreateCom", "Create Community", "Create Community", "/_layouts/epmlive/images/addcommunity16.gif", "#", onclick));
                itemsHtml.Append("<li id=\"mp1_0_2\" class=\"ms-core-menu-separator\" type=\"separator\" type=\"separator\"><hr class=\"ms-core-menu-separatorHr\"></li>");
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

                                    itemsHtml.Append(string.Format(LIST_ITEM_HTML, "MenuItem" + i, description, itemText, imageUrl, linkUrl, onclick));
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
