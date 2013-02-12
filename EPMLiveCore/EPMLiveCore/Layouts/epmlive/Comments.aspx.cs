using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;

using EPMLiveCore;
using EPMLiveCore.API;

namespace EPMLiveCore
{
    public partial class Comments : LayoutsPageBase
    {
        public Guid _ListId;
        public int _ItemId;
        protected string _hasPerm;
        protected string _webUrl;
        protected string _userProfileUrl;
        protected string _userEmail;
        protected string _userPictureUrl = string.Empty;
        protected string _currentUserLoginName = string.Empty;
        protected string _listTitle = string.Empty;
        protected string _itemTitle = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptLink.RegisterScriptAfterUI(this.Page, "SP.Core.js", false, false);
            ScriptLink.RegisterScriptAfterUI(this.Page, "SP.js", false, false);
            ScriptLink.RegisterScriptAfterUI(this.Page, "SP.UI.Dialog.js", false, false);
            EnsureCommentsListExist();
            ManageFields();
            AddCommentersFields();
            BuildHTMLTableRowsForEachComment();
        }

        private void EnsureCommentsListExist()
        {
            SPSite cSite = SPContext.Current.Site;
            SPWeb cWeb = SPContext.Current.Web;
            SPList commentsList = cWeb.Lists.TryGetList("Comments");

            if (commentsList == null)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite eleSite = new SPSite(cWeb.Url))
                    {
                        using (SPWeb eleWeb = eleSite.OpenWeb())
                        {
                            eleWeb.AllowUnsafeUpdates = true;
                            Guid guid = eleWeb.Lists.Add("Comments", "", SPListTemplateType.GenericList);
                            commentsList = eleWeb.Lists[guid];
                            commentsList.Hidden = true;
                            commentsList.Fields.Add("ItemId", SPFieldType.Text, true);
                            commentsList.Fields.Add("ListId", SPFieldType.Text, true);
                            commentsList.Fields.Add("Comment", SPFieldType.Note, false);
                            commentsList.Update();

                            SPView view = commentsList.DefaultView;
                            view.ViewFields.Add("ItemId");
                            view.ViewFields.Add("ListId");
                            view.ViewFields.Add("Comment");
                            view.Update();

                            commentsList.Update();
                            eleWeb.Update();
                        }
                    }
                });
            }

            _hasPerm = commentsList.DoesUserHavePermissions(SPBasePermissions.AddListItems).ToString();
        }

        private void ManageFields()
        {
            SPWeb currentWeb = SPContext.Current.Web;
            SPSite currentSite = SPContext.Current.Site;

            if (!string.IsNullOrEmpty(Request.Params["listId"]))
            {
                _ListId = new Guid(Request.Params["listId"]);
                hdnListId.Value = _ListId.ToString("D");
            }

            if (!string.IsNullOrEmpty(Request.Params["itemid"]))
            {
                _ItemId = Convert.ToInt32(Request.Params["itemid"]);
                hdnItemId.Value = _ItemId.ToString();
            }

            if (!string.IsNullOrEmpty(Request.Params["listId"]))
            {
                SPList list = currentWeb.Lists[_ListId];
                SPListItem item = list.GetItemById(_ItemId);
                _listTitle = SPHttpUtility.HtmlEncode(list.Title);
                _itemTitle = (item[item.Fields.GetFieldByInternalName("Title").Id] != null) ? SPHttpUtility.HtmlEncode(item[item.Fields.GetFieldByInternalName("Title").Id].ToString()) : string.Empty;
            }

            hdnUserId.Value = Web.CurrentUser.ID.ToString();
            string currentWebUrl = SPContext.Current.Web.Url;
            _webUrl = currentSite.MakeFullUrl(currentWeb.ServerRelativeUrl) + "/_layouts/EPMLive/CommentsProxy.aspx?";
            _currentUserLoginName = SPHttpUtility.HtmlEncode(Web.CurrentUser.Name);
            //_userProfileUrl = currentWebUrl + "/my/person.aspx?accountname=" + Web.CurrentUser.Name;
            _userProfileUrl = currentSite.MakeFullUrl(currentWeb.ServerRelativeUrl) + "/_layouts/userdisp.aspx?Force=True&ID=" + Web.CurrentUser.ID + "&source=" + HttpContext.Current.Request.UrlReferrer;
            // user picture url
            SPList userInfoList = Web.SiteUserInfoList;
            SPListItem userItem = userInfoList.GetItemById(Web.CurrentUser.ID);
            _userEmail = !string.IsNullOrEmpty(Web.CurrentUser.Email) ? Web.CurrentUser.Email : string.Empty;
            _userPictureUrl = currentSite.MakeFullUrl(currentWeb.ServerRelativeUrl) + "/_layouts/epmlive/images/O14_person_placeHolder_32.png";

            SPField fldPicture = null;
            try
            {
                fldPicture = userItem.Fields.GetFieldByInternalName("Picture");
            }
            catch (ArgumentException x)
            {
                fldPicture = null;
            }

            if (fldPicture != null)
            {
                try
                {
                    string[] picUrls = userItem[userItem.Fields.GetFieldByInternalName("Picture").Id].ToString().Split(',');
                    _userPictureUrl = picUrls[0];
                }
                catch
                {
                    _userPictureUrl = currentSite.MakeFullUrl(currentWeb.ServerRelativeUrl) + "/_layouts/epmlive/images/O14_person_placeHolder_32.png";
                }
            }
        }

        private void AddCommentersFields()
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite tempSite = new SPSite(SPContext.Current.Web.Url))
                {
                    using (SPWeb tempWeb = tempSite.OpenWeb())
                    {
                        tempWeb.AllowUnsafeUpdates = true;
                        SPList originList = tempWeb.Lists[_ListId];
                        // add commenters field
                        SPField fldCommenters = null;
                        try
                        {
                            fldCommenters = originList.Fields.GetFieldByInternalName("Commenters");
                        }
                        catch (System.ArgumentException x)
                        {
                            fldCommenters = null;
                        }

                        tempWeb.AllowUnsafeUpdates = true;
                        if (fldCommenters == null)
                        {
                            string fldCommentersName = originList.Fields.Add("Commenters", SPFieldType.Note, false);
                            fldCommenters = originList.Fields.GetFieldByInternalName(fldCommentersName) as SPFieldMultiLineText;
                            fldCommenters.Sealed = false;
                            fldCommenters.Hidden = true;
                            fldCommenters.AllowDeletion = false;
                            fldCommenters.DefaultValue = string.Empty;
                            fldCommenters.Update();
                            originList.Update();
                        }

                        SPField fldCommentersRead = null;

                        // add commentersread field
                        try
                        {
                            fldCommentersRead = originList.Fields.GetFieldByInternalName("CommentersRead");
                        }
                        catch (System.ArgumentException x)
                        {
                            fldCommentersRead = null;
                        }

                        if (fldCommentersRead == null)
                        {
                            string fldCommentersReadName = originList.Fields.Add("CommentersRead", SPFieldType.Note, false);
                            fldCommentersRead = originList.Fields.GetFieldByInternalName(fldCommentersReadName) as SPFieldMultiLineText;
                            fldCommentersRead.Hidden = true;
                            fldCommentersRead.Sealed = false;
                            fldCommentersRead.AllowDeletion = false;
                            fldCommentersRead.DefaultValue = string.Empty;
                            fldCommentersRead.Update();
                            originList.Update();
                        }
                        tempWeb.Update();


                        SPListItem originListItem = null;
                        List<int> laCommenters = new List<int>();
                        List<int> laCommentersRead = new List<int>();

                        if (originList != null)
                        {
                            originListItem = originList.GetItemById(_ItemId);
                        }

                        if (originListItem != null)
                        {
                            string sCommenters = originListItem[originList.Fields.GetFieldByInternalName("Commenters").Id] != null ? originListItem[originList.Fields.GetFieldByInternalName("Commenters").Id].ToString() : string.Empty;
                            foreach (string s in sCommenters.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                if (!string.IsNullOrEmpty(s.Trim()))
                                {
                                    laCommenters.Add(int.Parse(s));
                                }
                            }

                            string sCommentersRead = originListItem[originList.Fields.GetFieldByInternalName("CommentersRead").Id] != null ? originListItem[originList.Fields.GetFieldByInternalName("CommentersRead").Id].ToString() : string.Empty;
                            foreach (string s in sCommentersRead.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                if (!string.IsNullOrEmpty(s.Trim()))
                                {
                                    laCommentersRead.Add(int.Parse(s));
                                }
                            }

                            // get user object 
                            SPFieldUser author = (SPFieldUser)originListItem.Fields[SPBuiltInFieldId.Author];
                            SPFieldUserValue userVal = (SPFieldUserValue)author.GetFieldValue(originListItem[SPBuiltInFieldId.Author].ToString());
                            SPUser authorObj = userVal.User;

                            // (if current user is item creator OR in commenters column OR in the assigned to field) AND not in commentersread column
                            if (((SPContext.Current.Web.CurrentUser.ID == authorObj.ID) || (laCommenters.Contains(SPContext.Current.Web.CurrentUser.ID)) || (CommentManager.UserIsAssigned(SPContext.Current.Web.CurrentUser.ID, originListItem)))
                                && (!laCommentersRead.Contains(SPContext.Current.Web.CurrentUser.ID)))
                            {
                                string sNewCommentersRead = originListItem[originList.Fields.GetFieldByInternalName("CommentersRead").Id] != null ? originListItem[originList.Fields.GetFieldByInternalName("CommentersRead").Id].ToString() : string.Empty;
                                List<int> newCommenters = new List<int>();
                                if (!string.IsNullOrEmpty(sNewCommentersRead))
                                {
                                    string[] vals = sNewCommentersRead.Split(',');
                                    foreach (string s in vals)
                                    {
                                        if (!string.IsNullOrEmpty(s.Trim()))
                                        {
                                            newCommenters.Add(int.Parse(s));
                                        }
                                    }
                                }

                                if (!newCommenters.Contains(SPContext.Current.Web.CurrentUser.ID))
                                {
                                    newCommenters.Add(SPContext.Current.Web.CurrentUser.ID);
                                }

                                StringBuilder sb = new StringBuilder();
                                foreach (int i in newCommenters)
                                {
                                    sb.Append(i.ToString() + ",");
                                }
                                string s1 = sb.ToString();
                                s1 = s1.Remove(s1.LastIndexOf(","));

                                originListItem[originList.Fields.GetFieldByInternalName("CommentersRead").Id] = s1;
                            }

                            originListItem.SystemUpdate();
                        }

                    }
                }
            });
        }

        private void BuildHTMLTableRowsForEachComment()
        {
            SPSite currentSite = SPContext.Current.Site;
            SPWeb currentWeb = SPContext.Current.Web;

            SPList commentsList = currentWeb.Lists.TryGetList("Comments");

            // insert a table to serve as an anchor 
            // for javascript to target and inject html dynamically
            // notice the display none css property
            pnlCommentsContainer.Controls.Add(new LiteralControl("<div style=\"float:left;width:100%\"> <table class=\"ms-socialCommentItem\" style=\" display: none;\" id=\"commentItem_PlaceHolder\"></table></div>"));
            SPQuery q = new SPQuery();
            //q.Query = "<Where><And><Eq><FieldRef Name=\"ListId\" /><Value Type=\"Text\">" + _ListId.ToString("D") + "</Value></Eq><Eq><FieldRef Name=\"ItemId\" /><Value Type=\"Text\">" + _ItemId + "</Value></Eq></And></Where><OrderBy><FieldRef Name=\"Created\" Ascending=\"False\" /></OrderBy>";
            q.Query = "<Where><And><Or><Eq><FieldRef Name=\"ListId\" /><Value Type=\"Text\">" + _ListId.ToString("D") + "</Value></Eq><Eq><FieldRef Name=\"ListId\" /><Value Type=\"Text\">" + _ListId.ToString("B") + "</Value></Eq></Or><Eq><FieldRef Name=\"ItemId\" /><Value Type=\"Text\">" + _ItemId + "</Value></Eq></And></Where><OrderBy><FieldRef Name=\"Created\" Ascending=\"False\" /></OrderBy></Query>";
            
            if (commentsList != null)
            {
                SPListItemCollection items = commentsList.GetItems(q);

                foreach (SPListItem item in items)
                {
                    // get user object 
                    SPFieldUser author = (SPFieldUser)item.Fields[SPBuiltInFieldId.Author];
                    SPFieldUserValue user = (SPFieldUserValue)author.GetFieldValue(item[SPBuiltInFieldId.Author].ToString());
                    SPUser userObject = user.User;

                    //get user picture from user id
                    SPList userInfoList = Web.SiteUserInfoList;
                    SPListItem userItem = userInfoList.GetItemById(userObject.ID);
                    string userPictureUrl = currentSite.MakeFullUrl(currentWeb.ServerRelativeUrl) + "/_layouts/epmlive/images/O14_person_placeHolder_32.png";

                    SPField fldPicture = null;
                    try
                    {
                        fldPicture = userItem.Fields.GetFieldByInternalName("Picture");
                    }
                    catch (ArgumentException x)
                    {
                        fldPicture = null;
                    }

                    if (fldPicture != null)
                    {
                        try
                        {
                            string[] picUrls = userItem[userItem.Fields.GetFieldByInternalName("Picture").Id].ToString().Split(',');
                            userPictureUrl = picUrls[0];
                        }
                        catch
                        {
                            userPictureUrl = currentSite.MakeFullUrl(currentWeb.ServerRelativeUrl) + "/_layouts/epmlive/images/O14_person_placeHolder_32.png";
                        }
                    }

                    string createdDate = item[commentsList.Fields.GetFieldByInternalName("Created").Id].ToString();
                    string userComment = string.Empty;
                    object testObj = null;
                    try
                    {
                        testObj = item[commentsList.Fields.GetFieldByInternalName("Comment").Id];
                    }
                    catch { }

                    if (testObj != null && !string.IsNullOrEmpty(item[commentsList.Fields.GetFieldByInternalName("Comment").Id].ToString()))
                    {
                        userComment = item[commentsList.Fields.GetFieldByInternalName("Comment").Id].ToString();
                    }

                    if (userObject.ID == Web.CurrentUser.ID)
                    {
                        pnlCommentsContainer.Controls.Add(new LiteralControl("<div style=\"float:left;width:100%\"><table class=\"ms-socialCommentItem customCommentItem\" id=\"commentItem_" + item.ID.ToString() + "\">" +
                                                                                "<tbody>" +
                                                                                    "<tr>" +
                                                                                        "<td class=\"socialcomment-image\" vAlign=\"left\" rowSpan=\"2\">" +
                                                                                            "<img alt=\"User Photo\" style=\"width:32px;height:32px\" src=\"" + userPictureUrl + "\">" +
                                                                                        "</td>" +
                                                                                        "<td class=\"socialcomment-IMPawn\" rowSpan=\"2\" align=\"left\">" +
                                                                                            "<div id=\"DataFrameManager_ctl02_socomIM_0\" class=\"socialcomment-IMPawn\">" +
                                                                                                "<span>" +
                                                                                                    "<img id=\"commentAvailBubble" + item.ID.ToString() + "\" alt=\"Status indicator\" src=\"/_layouts/images/imnhdr.gif\" width=\"12\" onload=\"QueuePopulateIMNRC('" + userObject.Email + "',this);\" height=\"12\" ShowOfflinePawn=\"1\">" +
                                                                                                "</span>" +
                                                                                            "</div>" +
                                                                                        "</td>" +
                                                                                        "<td class=\"socialcomment-top\" vAlign=\"left\">" +
                                                                                            "<span class=\"socialcomment-username\">" +
                                                                                                "<a href=\"" + _userProfileUrl + "\" target=\"_parent\">" + userObject.Name + "</a>" +
                                                                                            "</span>" +
                                                                                            "<span class=\"socialcomment-time\">" + createdDate.ToString() + "</span>" +
                                                                                        "</td>" +
                                                                                        "<td class=\"socialcomment-top socialcomment-cmdlink\" vAlign=\"right\">" +
                                                                                            "<span class=\"socialcomment-cmdlink\">" +
                                                                                                "<a onclick=\"javaScript:document.getElementById(\'" + hdnCommentItemId.ClientID + "\').value=\'" + item.ID.ToString() + "\'; EnterEditMode(" + item.ID.ToString() + "); return false;\" href=\'#\'>Edit</a>" +
                                                                                                "<span class=\"separator\">&nbsp;|&nbsp;</span>" +
                                                                                                "<a onclick=\"javaScript:document.getElementById(\'" + hdnCommentItemId.ClientID + "\').value=\'" + item.ID.ToString() + "\'; ajaxPost(\'DeleteComment\'); return false;\" href=\'#\'>Delete</a>" +
                                                                                            "</span>" +
                                                                                        "</td>" +
                                                                                    "</tr>" +
                                                                                    "<tr>" +
                                                                                        "<td class=\"socialcomment-bottom\" vAlign=\"left\" colSpan=\"3\">" +
                                                                                        "<div id=\"divComment_" + item.ID.ToString() + "\" class=\"socialcomment-contents-TRC\">" + userComment + "</div>" +
                                                                                        "</td>" +
                                                                                    "</tr>" +
                                                                                "</tbody>" +
                                                                            "</table></div>"));
                    }
                    else
                    {
                        pnlCommentsContainer.Controls.Add(new LiteralControl("<div style=\"float:left;width:100%\"><table class=\"ms-socialCommentItem customCommentItem\" >" +
                                                                                "<tbody>" +
                                                                                    "<tr>" +
                                                                                        "<td class=\"socialcomment-image\" vAlign=\"left\" rowSpan=\"2\">" +
                                                                                            "<img alt=\"User Photo\" style=\"width:32px;height:32px\" src=\"" + userPictureUrl + "\">" +
                                                                                        "</td>" +
                                                                                        "<td class=\"socialcomment-IMPawn\" rowSpan=\"2\" align=\"left\">" +
                                                                                            "<div class=\"socialcomment-IMPawn\">" +
                                                                                                "<span>" +
                                                                                                    "<img id=\"commentAvailBubble" + item.ID.ToString() + "\" alt=\"Status indicator\" src=\"/_layouts/images/imnhdr.gif\" width=\"12\" onload=\"QueuePopulateIMNRC('" + userObject.Email + "',this);\" height=\"12\" ShowOfflinePawn=\"1\">" +
                                                                                                "</span>" +
                                                                                            "</div>" +
                                                                                        "</td>" +
                                                                                        "<td class=\"socialcomment-top\" vAlign=\"left\">" +
                                                                                            "<span class=\"socialcomment-username\">" +
                                                                                                "<a href=\"" + (currentWeb.ServerRelativeUrl == "/" ? "" : currentWeb.ServerRelativeUrl) + "/_layouts/userdisp.aspx?Force=True&ID=" + userObject.ID + "&source" + HttpContext.Current.Request.Url.AbsolutePath + "\" target=\"_parent\">" + userObject.Name + "</a>" +
                                                                                            "</span>" +
                                                                                            "<span class=\"socialcomment-time\">" + createdDate.ToString() + "</span>" +
                                                                                        "</td>" +
                                                                                    // the edit and delete links are taken out for comments
                                                                                    // not posted by currently logged in user
                                                                                    "</tr>" +
                                                                                    "<tr>" +
                                                                                        "<td class=\"socialcomment-bottom\" vAlign=\"left\" colSpan=\"3\">" +
                                                                                        "<div id=\"divComment_" + item.ID.ToString() + "\" class=\"socialcomment-contents-TRC\" >" + userComment + "</div>" +
                                                                                        "</td>" +
                                                                                    "</tr>" +
                                                                                "</tbody>" +
                                                                            "</table></div>"));
                    }
                }
            }
        }

    }
}
