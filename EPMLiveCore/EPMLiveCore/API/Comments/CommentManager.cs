using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EPMLiveCore.SocialEngine;
using EPMLiveCore.SocialEngine.Core;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    internal class CommentManager
    {
        #region Fields (11) 

        //const string XML_RESPONSE_COMMENT_SECTION_HEADER = "<CommentItem listId=\"##listId##\" itemId=\"##itemId##\">";

        // methods
        // insert new comment
        // edit comment
        // delete comment

        private const string COMMENTS_LIST_NAME = "Comments";
        private const string XML_RESPONSE_COMMENT_FOOTER = "</Comments>";
        private const string XML_RESPONSE_COMMENT_HEADER = "<Comments>";

        private const string XML_RESPONSE_COMMENT_ITEM = "<Comment " +
                                                         "listId=\"##listId##\" " +
                                                         "listName=\"##listName##\" " +
                                                         "listUrl=\"##listUrl##\" " +
                                                         "listDispUrl=\"##listDispUrl##\" " +
                                                         "itemId=\"##itemId##\" " +
                                                         "itemTitle=\"##itemTitle##\" " +
                                                         "createdDate=\"##createdDate##\" " +
                                                         "isLast=\"##isLast##\" " +
                                                         "><![CDATA[##comment##]]>";

        private const string XML_RESPONSE_COMMENT_ITEM_CLOSE = "</Comment>";
        private const string XML_RESPONSE_COMMENT_LOADEDIDS = "<LoadedIds>##loadedids##</LoadedIds>";
        private const string XML_RESPONSE_COMMENT_SECTION_FOOTER = "</CommentItem>";

        private const string XML_RESPONSE_COMMENT_SECTION_HEADER =
            "<CommentItem listId=\"##listId##\" itemId=\"##itemId##\">";

        private const string XML_RESPONSE_PUBLIC_COMMENT_ITEM =
            "<PublicCommentItem listId=\"##pubComListId##\" itemId=\"##pubComItemId##\" />";

        private const string XML_USER_INFO_SECTION = "<UserInfo>" +
                                                     "<UserName><![CDATA[##username##]]></UserName>" +
                                                     "<UserProfileUrl><![CDATA[##userprofile##]]></UserProfileUrl>" +
                                                     "<UserPic><![CDATA[##userpic##]]></UserPic>" +
                                                     "<UserEmail><![CDATA[##useremail##]]></UserEmail>" +
                                                     "</UserInfo>";

        private static readonly string UserProfileUrl =
            SPContext.Current.Site.MakeFullUrl(SPContext.Current.Web.ServerRelativeUrl) +
            "/_layouts/userdisp.aspx?Force=True&ID=##userid##&source=" + HttpContext.Current.Request.UrlReferrer;

        #endregion Fields 

        #region Methods (20) 

        // Public Methods (9) 

        public static Hashtable BuildBody(string userName, string listID, string itemID, string comment, SPSite cSite, SPWeb cWeb)
        {
            //0 - name of person who made comment
            //1 - created vs edited
            //2 - link to item being commented on
            //3 - title of the item that's being commented on
            //4 - workspace url
            //5 - workspace title
            //6 - actual comment
            //7 - link to comments page

            string itemLink = string.Empty;
            string itemTitle = string.Empty;
            string actualComment = comment;
            string commentsPageUrl = string.Empty;
            string listLink = string.Empty;
            string listTitle = string.Empty;

            SPList originList = cWeb.Lists[new Guid(listID)];
            SPListItem originListItem = originList.GetItemById(int.Parse(itemID));

            itemLink =
                cSite.MakeFullUrl(originList.Forms[PAGETYPE.PAGE_DISPLAYFORM].ServerRelativeUrl) +
                "?ID=" + originListItem.ID;

            itemTitle = originListItem[originList.Fields.GetFieldByInternalName("Title").Id].ToString();
            listLink = cSite.MakeFullUrl(originList.DefaultViewUrl);
            listTitle = originList.Title;

            commentsPageUrl = cWeb.Url + "/_layouts/epmlive/comments.aspx?listid=" + new Guid(listID).ToString("D") +
                              "&itemid=" + itemID;

            var hshProps = new Hashtable
            {
                {"ItemLink", itemLink},
                {"ItemName", itemTitle},
                {"ListLink", listLink},
                {"ListName", listTitle},
                {"Comment", actualComment},
                {"CommentsPageUrl", commentsPageUrl}
            };

            return hshProps;
        }

        public static string CreateComment(string data)
        {
            string retVal = string.Empty;

            SPWeb cWeb = SPContext.Current.Web;
            var cSite = cWeb.Site;
            var spUserToken = cWeb.CurrentUser.UserToken;

            // Data should look like the following:
            // ===============================
            // <Data>
            // <Param key="ListId">someguid</Param>
            // <Param key="ItemId">12</Param>
            // <Param key="Comment">abcabac</Param>
            // </Data>

            // load data into XML manager
            var dataMgr = new XMLDataManager(data);
            SPList commentsList = cWeb.Lists.TryGetList(COMMENTS_LIST_NAME);

            var sbResult = new StringBuilder();
            sbResult.Append(XML_RESPONSE_COMMENT_HEADER);

            if (commentsList != null)
            {
                cWeb.AllowUnsafeUpdates = true;
                SPListItem currentItem = commentsList.Items.Add();

                DateTime time = GetCurrentLocalTime();
                bool statusUpdate;
                bool.TryParse(dataMgr.GetPropVal("StatusUpdate"), out statusUpdate);
                string statusUpdateId = dataMgr.GetPropVal("StatusUpdateId");

                string genericTitle = cWeb.CurrentUser.Name + " made a new comment at " + time;
                currentItem[commentsList.Fields.GetFieldByInternalName("Title").Id] = genericTitle;

                string listId = dataMgr.GetPropVal("ListId");
                string itemId = dataMgr.GetPropVal("ItemId");
                string comment = HttpUtility.HtmlDecode(dataMgr.GetPropVal("Comment") ?? string.Empty);
                var laCommenters = new List<int>();
                SPListItem originListItem = null;

                currentItem[commentsList.Fields.GetFieldByInternalName("ListId").Id] = listId;
                currentItem[commentsList.Fields.GetFieldByInternalName("ItemId").Id] = itemId;
                currentItem[commentsList.Fields.GetFieldByInternalName("Comment").Id] = comment;
                //currentItem[commentsList.Fields.GetFieldByInternalName("Comment").Id] = Uri.UnescapeDataString(dataMgr.GetPropVal("Comment"));

                SetSocialEngineTransaction(currentItem);
                currentItem.Update();

                sbResult.Append(
                    XML_RESPONSE_COMMENT_SECTION_HEADER.Replace("##listId##", currentItem.ParentList.ID.ToString())
                        .Replace("##itemId##", currentItem.ID.ToString()));
                sbResult.Append(XML_RESPONSE_COMMENT_ITEM.Replace("##listId##", currentItem.ParentList.ID.ToString())
                    .Replace("##listName##", currentItem.ParentList.Title)
                    .Replace("##itemId##", currentItem.ID.ToString())
                    .Replace("##itemTitle##", currentItem.Title)
                    .Replace("##createdDate##", ((DateTime) currentItem["Created"]).ToFriendlyDateAndTime())
                    .Replace("##comment##", GetXMLSafeVersion(comment)));
                sbResult.Append(XML_RESPONSE_COMMENT_ITEM_CLOSE);
                sbResult.Append(XML_RESPONSE_COMMENT_SECTION_FOOTER);
                sbResult.Append(XML_RESPONSE_COMMENT_FOOTER);

                // save current user
                SPUser originalUser = SPContext.Current.Web.CurrentUser;

                string originListItemTitle = null;
                string originListItemUrl = null;

                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    using (var es = new SPSite(SPContext.Current.Site.ID))
                    {
                        using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ServerRelativeUrl))
                        {
                            ew.AllowUnsafeUpdates = true;

                            SPList originList = ew.Lists[new Guid(listId)];

                            if (originList != null)
                            {
                                originListItem = originList.GetItemById(int.Parse(itemId));
                            }

                            if (originListItem != null)
                            {
                                originListItemTitle = originListItem.Title;
                                originListItemUrl = originListItem.Url;

                                EnsureMetaCols(originList);

                                string sCommenters =
                                    originListItem[originList.Fields.GetFieldByInternalName("Commenters").Id] != null
                                        ? originListItem[originList.Fields.GetFieldByInternalName("Commenters").Id]
                                            .ToString()
                                        : string.Empty;

                                laCommenters.AddRange(
                                    from s in sCommenters.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                                    where !string.IsNullOrEmpty(s.Trim())
                                    select int.Parse(s));

                                // get user object 
                                var author = (SPFieldUser) originListItem.Fields[SPBuiltInFieldId.Author];
                                var userVal =
                                    (SPFieldUserValue)
                                        author.GetFieldValue(originListItem[SPBuiltInFieldId.Author].ToString());

                                SPUser authorObj = userVal.User;

                                // if user is not in commenters, and not creater or one of the assigned to users
                                if (!laCommenters.Contains(originalUser.ID) &&
                                    (authorObj != null && !originalUser.ID.Equals(authorObj.ID)) &&
                                    !UserIsAssigned(originalUser.ID, originListItem))
                                {
                                    laCommenters.Add(originalUser.ID);
                                    var sbNewCommenters = new StringBuilder();
                                    foreach (int id in laCommenters)
                                    {
                                        sbNewCommenters.Append(id + ",");
                                    }

                                    sCommenters = sbNewCommenters.ToString();
                                    sCommenters = sCommenters.Remove(sCommenters.LastIndexOf(','));

                                    originListItem[originList.Fields.GetFieldByInternalName("Commenters").Id] =
                                        sCommenters;
                                }

                                // set commentersread to blank
                                originListItem[originList.Fields.GetFieldByInternalName("CommentersRead").Id] =
                                    string.Empty;

                                // add current user to list
                                originListItem[originList.Fields.GetFieldByInternalName("CommentersRead").Id] =
                                    originalUser.ID.ToString();

                                SetSocialEngineTransaction(originListItem);
                                originListItem.SystemUpdate();

                                Task.Factory.StartNew(() =>
                                {
                                    var emailSentIDs = new List<int>();
                                    // send email to author

                                    var siteId = cSite.ID;
                                    var webId = cWeb.ID;

                                    if (authorObj != null && originalUser.ID != authorObj.ID)
                                    {
                                        emailSentIDs.Add(authorObj.ID);
                                        SendEmailNotification(authorObj.ID, dataMgr.GetPropVal("ListId"),
                                            dataMgr.GetPropVal("ItemId"), comment, siteId, webId, spUserToken);
                                    }

                                    // send email to assigned to people
                                    try
                                    {
                                        string[] vals =
                                            originListItem[originListItem.Fields.GetFieldByInternalName("AssignedTo").Id
                                                ]
                                                .ToString().Split(new[] {";#"}, StringSplitOptions.None);
                                        foreach (string val in vals)
                                        {
                                            int id;
                                            if (int.TryParse(val, out id) && !id.Equals(originalUser.ID) &&
                                                !emailSentIDs.Contains(id))
                                            {
                                                emailSentIDs.Add(id);
                                                SendEmailNotification(id, dataMgr.GetPropVal("ListId"),
                                                    dataMgr.GetPropVal("ItemId"), comment, siteId, webId, spUserToken);
                                            }
                                        }
                                    }
                                    catch { }

                                    // send email to each person in thread
                                    foreach (int id in laCommenters)
                                    {
                                        if ((id != originalUser.ID) && !emailSentIDs.Contains(id))
                                        {
                                            emailSentIDs.Add(id);
                                            SendEmailNotification(id, dataMgr.GetPropVal("ListId"),
                                                dataMgr.GetPropVal("ItemId"), comment, siteId, webId, spUserToken);
                                        }
                                    }
                                });
                            }

                            //retVal = currentItem.ID.ToString() + "," + createdDate;
                            retVal = sbResult.ToString();
                            InsertCommentCount(listId, itemId);
                        }
                    }
                });

                if (string.IsNullOrEmpty(comment) || string.IsNullOrEmpty(originListItemTitle)) return retVal;

                try
                {
                    if (!statusUpdate)
                    {
                        SyncToSocialStream(currentItem.UniqueId, comment, originListItem.ParentList.ID,
                            originListItem.ID, originListItemTitle,
                            originListItem.ParentList.Title, originListItemUrl, laCommenters, time, cWeb, "ADD");
                    }
                    else
                    {
                        var sId = new Guid(statusUpdateId);

                        SPListItem statusItem = currentItem.ParentList.GetItemByUniqueId(sId);

                        SyncStatusUpdateToSocialStream(sId, comment,
                            new Guid(currentItem["ListId"].ToString()),
                            int.Parse(currentItem["ItemId"].ToString()), (DateTime) statusItem["Created"], cWeb,
                            "COMMENT", (DateTime?) currentItem["Created"], currentItem.UniqueId);
                    }
                }
                catch { }
            }
            else
            {
                throw new Exception("The 'Comments' list needs to be created to support this functionality.");
            }

            return retVal;
        }

        public static string CreatePublicComment(string data)
        {
            string retVal = string.Empty;
            SPWeb cWeb = SPContext.Current.Web;
            var cSite = cWeb.Site;

            // Data should look like the following:
            // ===============================
            // <Data>
            // <Param key="ListId">someguid</Param>
            // <Param key="ItemId">12</Param>
            // <Param key="Comment">abcabac</Param>
            // </Data>

            // load data into XML manager
            var dataMgr = new XMLDataManager(data);
            EnsurePublicCommentsListExist();
            SPList publicCommentsList = cWeb.Lists.TryGetList("PublicComments");
            SPList commentsList = cWeb.Lists.TryGetList(COMMENTS_LIST_NAME);
            string itemId = dataMgr.GetPropVal("ItemId");
            dataMgr.EditProp("ListId", publicCommentsList.ID.ToString());

            if (string.IsNullOrEmpty(itemId))
            {
                cWeb.AllowUnsafeUpdates = true;
                SPListItem newItem = publicCommentsList.Items.Add();
                SetSocialEngineTransaction(newItem);
                newItem.Update();
                dataMgr.EditProp("ItemId", newItem.ID.ToString());
            }

            var sbResult = new StringBuilder();
            sbResult.Append(XML_RESPONSE_COMMENT_HEADER);

            if (publicCommentsList != null && commentsList != null)
            {
                cWeb.AllowUnsafeUpdates = true;
                SPListItem currentItem = commentsList.Items.Add();
                string genericTitle = cWeb.CurrentUser.Name + " made a new comment at " + DateTime.Now;
                currentItem[commentsList.Fields.GetFieldByInternalName("Title").Id] = genericTitle;
                currentItem[commentsList.Fields.GetFieldByInternalName("ListId").Id] = dataMgr.GetPropVal("ListId");
                currentItem[commentsList.Fields.GetFieldByInternalName("ItemId").Id] = dataMgr.GetPropVal("ItemId");
                string comment = dataMgr.GetPropVal("Comment");

                currentItem[commentsList.Fields.GetFieldByInternalName("Comment").Id] = comment;
                //currentItem[commentsList.Fields.GetFieldByInternalName("Comment").Id] = Uri.UnescapeDataString(dataMgr.GetPropVal("Comment"));
                SetSocialEngineTransaction(currentItem);
                currentItem.Update();

                try
                {
                    if (!string.IsNullOrEmpty(comment))
                    {
                        comment = comment.Trim();

                        SyncStatusUpdateToSocialStream(currentItem.UniqueId, comment,
                            new Guid(currentItem["ListId"].ToString()),
                            int.Parse(currentItem["ItemId"].ToString()), (DateTime) currentItem["Created"], cWeb, "ADD");
                    }
                }
                catch { }

                sbResult.Append(
                    XML_RESPONSE_PUBLIC_COMMENT_ITEM.Replace("##pubComListId##", dataMgr.GetPropVal("ListId"))
                        .Replace("##pubComItemId##", dataMgr.GetPropVal("ItemId")));
                sbResult.Append(
                    XML_RESPONSE_COMMENT_SECTION_HEADER.Replace("##listId##", currentItem.ParentList.ID.ToString())
                        .Replace("##itemId##", currentItem.ID.ToString()));
                sbResult.Append(XML_RESPONSE_COMMENT_ITEM.Replace("##listId##", currentItem.ParentList.ID.ToString())
                    .Replace("##listName##", currentItem.ParentList.Title)
                    .Replace("##itemId##", currentItem.ID.ToString())
                    .Replace("##itemTitle##", currentItem.Title)
                    .Replace("##createdDate##", ((DateTime) currentItem["Created"]).ToFriendlyDateAndTime())
                    .Replace("##comment##", GetXMLSafeVersion(HttpUtility.HtmlDecode(comment ?? string.Empty))));
                sbResult.Append(XML_RESPONSE_COMMENT_ITEM_CLOSE);
                sbResult.Append(XML_RESPONSE_COMMENT_SECTION_FOOTER);
                sbResult.Append(XML_RESPONSE_COMMENT_FOOTER);

                // save current user
                SPUser originalUser = SPContext.Current.Web.CurrentUser;

                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    using (var es = new SPSite(SPContext.Current.Site.ID))
                    {
                        using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ServerRelativeUrl))
                        {
                            SPListItem originListItem = null;
                            var laCommenters = new List<int>();
                            ew.AllowUnsafeUpdates = true;
                            SPList originList = ew.Lists[new Guid(dataMgr.GetPropVal("ListId"))];

                            if (originList != null)
                            {
                                originListItem = originList.GetItemById(int.Parse(dataMgr.GetPropVal("ItemId")));
                            }

                            if (originListItem != null)
                            {
                                string sCommenters =
                                    originListItem[originList.Fields.GetFieldByInternalName("Commenters").Id] != null
                                        ? originListItem[originList.Fields.GetFieldByInternalName("Commenters").Id]
                                            .ToString()
                                        : string.Empty;

                                laCommenters.AddRange(
                                    from s in sCommenters.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                                    where !string.IsNullOrEmpty(s.Trim())
                                    select int.Parse(s));

                                // get user object 
                                var author = (SPFieldUser) originListItem.Fields[SPBuiltInFieldId.Author];
                                var userVal =
                                    (SPFieldUserValue)
                                        author.GetFieldValue(originListItem[SPBuiltInFieldId.Author].ToString());
                                SPUser authorObj = userVal.User;

                                // if user is not in commenters, and not creater or one of the assigned to users
                                if (!laCommenters.Contains(originalUser.ID) &&
                                    (authorObj != null && !originalUser.ID.Equals(authorObj.ID)) &&
                                    !UserIsAssigned(originalUser.ID, originListItem))
                                {
                                    laCommenters.Add(originalUser.ID);
                                    var sbNewCommenters = new StringBuilder();
                                    foreach (int id in laCommenters)
                                    {
                                        sbNewCommenters.Append(id + ",");
                                    }

                                    sCommenters = sbNewCommenters.ToString();
                                    sCommenters = sCommenters.Remove(sCommenters.LastIndexOf(','));

                                    originListItem[originList.Fields.GetFieldByInternalName("Commenters").Id] =
                                        sCommenters;
                                }

                                // set commentersread to blank
                                originListItem[originList.Fields.GetFieldByInternalName("CommentersRead").Id] =
                                    string.Empty;

                                // add current user to list
                                originListItem[originList.Fields.GetFieldByInternalName("CommentersRead").Id] =
                                    originalUser.ID.ToString();

                                SetSocialEngineTransaction(originListItem);
                                originListItem.SystemUpdate();

                                Task.Factory.StartNew(() =>
                                {
                                    var emailSentIDs = new List<int>();
                                    // send email to author
                                    
                                    var siteId = cSite.ID;
                                    var webId = cWeb.ID;
                                    var spUserToken = cWeb.CurrentUser.UserToken;

                                    if (authorObj != null && originalUser.ID != authorObj.ID)
                                    {
                                        emailSentIDs.Add(authorObj.ID);
                                        SendEmailNotification(authorObj.ID, dataMgr.GetPropVal("ListId"),
                                            dataMgr.GetPropVal("ItemId"), comment, siteId, webId, spUserToken);
                                    }

                                    // send email to assigned to people
                                    try
                                    {
                                        string[] vals =
                                            originListItem[originListItem.Fields.GetFieldByInternalName("AssignedTo").Id
                                                ]
                                                .ToString().Split(new[] {";#"}, StringSplitOptions.None);
                                        foreach (string val in vals)
                                        {
                                            int id;
                                            if (int.TryParse(val, out id) && !id.Equals(originalUser.ID) &&
                                                !emailSentIDs.Contains(id))
                                            {
                                                emailSentIDs.Add(id);
                                                SendEmailNotification(id, dataMgr.GetPropVal("ListId"),
                                                    dataMgr.GetPropVal("ItemId"), comment, siteId, webId, spUserToken);
                                            }
                                        }
                                    }
                                    catch { }

                                    // send email to each person in thread
                                    foreach (int id in laCommenters)
                                    {
                                        if ((id != originalUser.ID) && !emailSentIDs.Contains(id))
                                        {
                                            emailSentIDs.Add(id);
                                            SendEmailNotification(id, dataMgr.GetPropVal("ListId"),
                                                dataMgr.GetPropVal("ItemId"), comment, siteId, webId, spUserToken);
                                        }
                                    }
                                });
                            }

                            string createdDate = currentItem["Created"].ToString();
                            //retVal = currentItem.ID.ToString() + "," + createdDate;
                            retVal = sbResult.ToString();
                            InsertCommentCount(dataMgr.GetPropVal("ListId"), dataMgr.GetPropVal("ItemId"));
                        }
                    }
                });
            }
            else
            {
                throw new Exception(
                    "Both 'PublicComments' list and 'Comments' list needs to be created to support this functionality.");
            }

            return retVal;
        }

        public static string DeleteComment(string data)
        {
            string retVal = string.Empty;
            SPWeb currentWeb = SPContext.Current.Web;
            SPSite currentSite = SPContext.Current.Site;
            // Data should look like the following:
            // ===============================
            // <Data>
            // <Param key='ListId'>someguid</Param>
            // <Param key='ItemId">12</Param>
            // <Param key='Comment'>abcabac</Param>
            // </Data>

            // load data into XML manager
            var dataMgr = new XMLDataManager(data);
            SPList commentsList = currentWeb.Lists.TryGetList(COMMENTS_LIST_NAME);

            if (commentsList != null)
            {
                string listId = dataMgr.GetPropVal("ListId");
                string itemId = dataMgr.GetPropVal("ItemId");
                int commentItemId = Convert.ToInt32(dataMgr.GetPropVal("CommentItemId"));
                SPListItem originListItem = null;
                SPListItem commentItem = null;

                SPList originList = null;
                originList = currentWeb.Lists[new Guid(dataMgr.GetPropVal("ListId"))];

                if (originList != null)
                {
                    originListItem = originList.GetItemById(int.Parse(dataMgr.GetPropVal("ItemId")));
                }

                var query = new SPQuery();
                query.Query = "<Where><And><Eq><FieldRef Name=\"ListId\" /><Value Type=\"Text\">" + listId +
                              "</Value></Eq><Eq><FieldRef Name=\"ItemId\" /><Value Type=\"Text\">" + itemId +
                              "</Value></Eq></And></Where>";
                SPListItemCollection itemColl = commentsList.GetItems(query);

                if (itemColl.Count > 0)
                {
                    foreach (SPListItem item in itemColl)
                    {
                        if (item.ID.Equals(commentItemId))
                        {
                            commentItem = item;
                            currentWeb.AllowUnsafeUpdates = true;

                            SetSocialEngineTransaction(item);

                            try
                            {
                                DeleteFromSocialStream(originListItem.Title, originListItem.ParentList.Title,
                                    originListItem.ParentList.ID, originListItem.ID, originListItem.Url,
                                    commentItem.UniqueId, currentWeb);
                            }
                            catch { }

                            item.Delete();
                            break;
                        }
                    }
                }
                else
                {
                    throw new Exception(String.Format("No comment with ListId = {0} and ItemId = {1} exists.", listId,
                        itemId));
                }

                // count comments made by current user, if 0, remove current user from "commenters" field
                query.Query = "<Where><And><Eq><FieldRef Name=\"ListId\" /><Value Type=\"Text\">" + listId +
                              "</Value></Eq><Eq><FieldRef Name=\"ItemId\" /><Value Type=\"Text\">" + itemId +
                              "</Value></Eq></And></Where>";
                SPListItemCollection items = commentsList.GetItems(query);
                bool userHasCommentsLeft = false;
                foreach (SPListItem i in items)
                {
                    // get user object 
                    var author = (SPFieldUser) i.Fields[SPBuiltInFieldId.Author];
                    var userVal = (SPFieldUserValue) author.GetFieldValue(i[SPBuiltInFieldId.Author].ToString());
                    SPUser authorObj = userVal.User;

                    if (authorObj != null && authorObj.ID == SPContext.Current.Web.CurrentUser.ID)
                    {
                        userHasCommentsLeft = true;
                    }
                }

                if (!userHasCommentsLeft)
                {
                    var laCommenters = new List<int>();
                    var laCommentersRead = new List<int>();
                    currentWeb.AllowUnsafeUpdates = true;

                    if (originListItem != null)
                    {
                        string sCommenters =
                            originListItem[originList.Fields.GetFieldByInternalName("Commenters").Id] != null
                                ? originListItem[originList.Fields.GetFieldByInternalName("Commenters").Id].ToString()
                                : string.Empty;
                        foreach (string s in sCommenters.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
                        {
                            if (!string.IsNullOrEmpty(s.Trim()))
                            {
                                laCommenters.Add(int.Parse(s));
                            }
                        }

                        string sCommentersRead =
                            originListItem[originList.Fields.GetFieldByInternalName("CommentersRead").Id] != null
                                ? originListItem[originList.Fields.GetFieldByInternalName("CommentersRead").Id].ToString
                                    ()
                                : string.Empty;
                        foreach (string s in sCommentersRead.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
                        {
                            if (!string.IsNullOrEmpty(s.Trim()))
                            {
                                laCommentersRead.Add(int.Parse(s));
                            }
                        }

                        if (laCommenters.Contains(SPContext.Current.Web.CurrentUser.ID))
                        {
                            laCommenters.Remove(SPContext.Current.Web.CurrentUser.ID);
                        }

                        if (laCommentersRead.Contains(SPContext.Current.Web.CurrentUser.ID))
                        {
                            laCommentersRead.Remove(SPContext.Current.Web.CurrentUser.ID);
                        }

                        // remove current user id from commenters field
                        var sbNewCommenters = new StringBuilder();
                        foreach (int id in laCommenters)
                        {
                            sbNewCommenters.Append(id + ",");
                        }

                        string sNewComenters = sbNewCommenters.ToString();
                        if (sNewComenters.IndexOf(',') != -1)
                        {
                            sNewComenters = sNewComenters.Remove(sNewComenters.LastIndexOf(','));
                        }

                        //originListItem[originList.Fields.GetFieldByInternalName("Commenters").Id] = sNewComenters;

                        // remove current user id from commentersRead field
                        var sbNewCommentersRead = new StringBuilder();
                        foreach (int id in laCommentersRead)
                        {
                            sbNewCommentersRead.Append(id + ",");
                        }

                        string sNewComentersRead = sbNewCommentersRead.ToString();
                        if (sNewComentersRead.IndexOf(',') != -1)
                        {
                            sNewComentersRead = sNewComentersRead.Remove(sNewComenters.LastIndexOf(','));
                        }

                        //originListItem[originList.Fields.GetFieldByInternalName("CommentersRead").Id] = sNewComentersRead;

                        SPSecurity.RunWithElevatedPrivileges(delegate
                        {
                            using (var es = new SPSite(currentSite.Url))
                            {
                                using (SPWeb ew = es.OpenWeb(currentWeb.ServerRelativeUrl))
                                {
                                    ew.AllowUnsafeUpdates = true;
                                    SPList tempList = ew.Lists[originList.ID];
                                    SPListItem tempItem = tempList.GetItemById(originListItem.ID);
                                    tempItem[tempList.Fields.GetFieldByInternalName("Commenters").Id] = sNewComenters;
                                    tempItem[tempList.Fields.GetFieldByInternalName("CommentersRead").Id] =
                                        sNewComentersRead;
                                    SetSocialEngineTransaction(tempItem);
                                    tempItem.SystemUpdate();
                                }
                            }
                        });
                    }
                }

                InsertCommentCount(dataMgr.GetPropVal("ListId"), dataMgr.GetPropVal("ItemId"));

                retVal = "Success";
            }
            else
            {
                throw new Exception("The 'Comments' list needs to be created to support this functionality.");
            }

            return retVal;
        }

        public static string GetMyCommentsByDate(string data)
        {
            string retVal = string.Empty;
            var sbResult = new StringBuilder();
            SPWeb cWeb = SPContext.Current.Web;

            SPListItemCollection userCreatedItems = null;
            var notifiedCommentItems = new List<string[]>();
            var aggregatedCommentItems = new List<string[]>();
            var targetComments = new List<string[]>();
            var saLoadedItems = new List<string>();

            // Data should look like the following:
            // ===============================
            // <Data>
            // <Param key="ItemIds"><listid>.<itemid>,<listid>.<itemid></Param>
            // <Parem key="Created"></Parem>
            // </Data>

            // load data into XML manager
            var dataMgr = new XMLDataManager(data);

            string sItemIds = dataMgr.GetPropVal("ItemIds");
            if (!string.IsNullOrEmpty(sItemIds))
            {
                string[] pairs = sItemIds.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in pairs)
                {
                    string[] vals = s.Split('.');
                    string list = new Guid(vals[0]).ToString();
                    string item = vals[1];
                    if (!ContainsItem(aggregatedCommentItems, new[] {list, item}))
                    {
                        aggregatedCommentItems.Add(new[] {list, item});
                    }
                }
            }

            SPList commentsList = cWeb.Lists.TryGetList(COMMENTS_LIST_NAME);
            SPList publicCommentsList = cWeb.Lists.TryGetList("PublicComments");
            SPListItemCollection comments = commentsList.Items;

            if (commentsList != null)
            {
                // Get comments created by current user
                // =================================================
                var q = new SPQuery();
                //q.Query = "<Where><And>" +
                //              "<Eq><FieldRef Name=\"Author\" LookupId=\"true\" /><Value Type=\"User\">" + cWeb.CurrentUser.ID.ToString() + "</Value></Eq>" +
                //              "<Geq><FieldRef Name=\"Created\" /><Value Type=\"DateTime\"><Today OffsetDays=\"" + dataMgr.GetPropVal("Created") + "\" /></Value></Geq>" +
                //          "</And></Where><OrderBy><FieldRef Name=\"Created\" Ascending=\"False\" /></OrderBy>";

                q.Query = "<Where><Or><Eq><FieldRef Name=\"Author\" LookupId=\"true\" /><Value Type=\"User\">" +
                          cWeb.CurrentUser.ID + "</Value></Eq>" +
                          "<Eq><FieldRef Name=\"ListId\" /><Value Type=\"Text\">" + publicCommentsList.ID +
                          "</Value></Eq></Or></Where>" +
                          "<OrderBy><FieldRef Name=\"Created\" Ascending=\"False\" /></OrderBy>";

                int numThreads = int.Parse(dataMgr.GetPropVal("NumThreads"));
                userCreatedItems = commentsList.GetItems(q);
                foreach (SPListItem item in userCreatedItems)
                {
                    var sListId = (string) (item["ListId"] ?? string.Empty);
                    var sItemId = (string) (item["ItemId"] ?? string.Empty);
                    string list = new Guid(sListId).ToString();

                    if (!ContainsItem(aggregatedCommentItems, new[] {list, sItemId}))
                    {
                        aggregatedCommentItems.Add(new[] {list, sItemId});
                    }
                }

                var allCommentsCol = new List<SPListItem>();

                foreach (var pair in aggregatedCommentItems)
                {
                    if (saLoadedItems.Count > 0 && saLoadedItems.Contains(pair[0] + '^' + pair[1])) { }
                    List<SPListItem> commentsCol = (from SPListItem i in comments
                        where
                            new Guid(pair[0]).ToString()
                                .Equals(new Guid((string) (i["ListId"] ?? string.Empty)).ToString()) &&
                            pair[1].Equals((string) (i["ItemId"] ?? string.Empty))
                        select i
                        ).ToList();
                    allCommentsCol.AddRange(commentsCol);
                }

                // sort aggregatedcommentitems by created date again
                aggregatedCommentItems.Clear();
                allCommentsCol = allCommentsCol.OrderByDescending(x => (DateTime) x["Created"]).ToList();
                foreach (SPListItem it in allCommentsCol)
                {
                    var sListId = (string) (it["ListId"] ?? string.Empty);
                    var sItemId = (string) (it["ItemId"] ?? string.Empty);
                    string list = new Guid(sListId).ToString();

                    if (!ContainsItem(aggregatedCommentItems, new[] {list, sItemId}))
                    {
                        aggregatedCommentItems.Add(new[] {list, sItemId});
                    }
                }

                // Construct response XML
                // =====================================
                sbResult.Append(XML_RESPONSE_COMMENT_HEADER);
                int totalThreads = 0;
                string loadedIds = string.Empty;

                // get item ids that's been loaded before
                string loadedItemIds = dataMgr.GetPropVal("LoadedItemIds");
                if (!string.IsNullOrEmpty(loadedItemIds))
                {
                    string[] rawIds = loadedItemIds.Split(',');
                    foreach (string s in rawIds)
                    {
                        if (!string.IsNullOrEmpty(s) && !saLoadedItems.Contains(s))
                        {
                            saLoadedItems.Add(s);
                        }
                    }
                }

                foreach (var pair in aggregatedCommentItems)
                {
                    if (saLoadedItems.Count > 0 && saLoadedItems.Contains(pair[0] + '^' + pair[1]))
                    {
                        continue;
                    }
                    // return the top x number of threads
                    if (!(totalThreads < numThreads))
                    {
                        break;
                    }

                    sbResult.Append(
                        XML_RESPONSE_COMMENT_SECTION_HEADER.Replace("##listId##", new Guid(pair[0]).ToString())
                            .Replace("##itemId##", pair[1]));
                    var commentsDesc = new List<SPListItem>();
                    var listId = new Guid(pair[0]);
                    int itemId = int.Parse(pair[1]);

                    SPListItem realItem = null;

                    try
                    {
                        SPList realList = cWeb.Lists[listId];
                        realItem = realList.GetItemById(itemId);
                    }
                    catch { }

                    // get matching list of comments in descending order
                    try
                    {
                        commentsDesc = (from SPListItem i in comments
                            where
                                new Guid(pair[0]).ToString()
                                    .Equals(new Guid((string) (i["ListId"] ?? string.Empty)).ToString()) &&
                                pair[1].Equals((string) (i["ItemId"] ?? string.Empty))
                            orderby (DateTime) i["Created"] ascending
                            select i
                            ).ToList();
                    }
                    catch { }

                    if (realItem != null && commentsDesc.Count > 0)
                    {
                        // display original comment
                        SPListItem originalComment = commentsDesc.OrderBy(x => (DateTime) x["Created"]).FirstOrDefault();
                        var sListId = (string) (originalComment["ListId"] ?? string.Empty);
                        var sItemId = (string) (originalComment["ItemId"] ?? string.Empty);
                        var dCreated = (DateTime) originalComment["Created"];

                        string soriginComment = string.Empty;
                        try
                        {
                            soriginComment = originalComment["Comment"].ToString();
                        }
                        catch { }

                        sbResult.Append(XML_RESPONSE_COMMENT_ITEM.Replace("##listId##", new Guid(sListId).ToString())
                            .Replace("##listName##", realItem.ParentList.Title)
                            .Replace("##listDispUrl##", realItem.ParentList.DefaultDisplayFormUrl)
                            .Replace("##listUrl##", realItem.ParentList.DefaultViewUrl)
                            .Replace("##itemId##", sItemId)
                            .Replace("##itemTitle##", realItem.Title.Replace('\"', '\''))
                            .Replace("##createdDate##", dCreated.ToFriendlyDateAndTime())
                            .Replace("##comment##",
                                GetXMLSafeVersion(HttpUtility.HtmlDecode(soriginComment ?? string.Empty))));
                        // get user object 
                        var author = (SPFieldUser) originalComment.Fields[SPBuiltInFieldId.Author];
                        var user =
                            (SPFieldUserValue) author.GetFieldValue(originalComment[SPBuiltInFieldId.Author].ToString());
                        SPUser userObject = user.User;

                        if (userObject == null)
                        {
                            continue;
                        }

                        //get user picture from user id
                        SPList userInfoList = SPContext.Current.Web.SiteUserInfoList;
                        SPListItem userItem = userInfoList.GetItemById(userObject.ID);
                        string userPictureUrl =
                            SPContext.Current.Site.MakeFullUrl(SPContext.Current.Web.ServerRelativeUrl) +
                            "/_layouts/epmlive/images/O14_person_placeHolder_32.png";

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
                                string[] picUrls =
                                    userItem[userItem.Fields.GetFieldByInternalName("Picture").Id].ToString().Split(',');
                                userPictureUrl = picUrls[0];
                            }
                            catch
                            {
                                userPictureUrl =
                                    SPContext.Current.Site.MakeFullUrl(SPContext.Current.Web.ServerRelativeUrl) +
                                    "/_layouts/epmlive/images/O14_person_placeHolder_32.png";
                            }
                        }

                        sbResult.Append(XML_USER_INFO_SECTION.Replace("##username##", userObject.Name)
                            .Replace("##useremail##", userObject.Email)
                            .Replace("##userprofile##", UserProfileUrl.Replace("##userid##", userObject.ID.ToString()))
                            .Replace("##userpic##", userPictureUrl));

                        sbResult.Append(XML_RESPONSE_COMMENT_ITEM_CLOSE);

                        for (int i = 0; i < commentsDesc.Count; i++)
                        {
                            SPListItem comment = commentsDesc[i];
                            if (comment.ID != originalComment.ID)
                            {
                                var sListId2 = (string) (comment["ListId"] ?? string.Empty);
                                var sItemId2 = (string) (comment["ItemId"] ?? string.Empty);
                                var dCreated2 = (DateTime) comment["Created"];

                                // get user object 
                                author = (SPFieldUser) comment.Fields[SPBuiltInFieldId.Author];
                                user =
                                    (SPFieldUserValue) author.GetFieldValue(comment[SPBuiltInFieldId.Author].ToString());
                                userObject = user.User;

                                if (userObject == null)
                                {
                                    continue;
                                }

                                //get user picture from user id
                                userInfoList = SPContext.Current.Web.SiteUserInfoList;
                                userItem = userInfoList.GetItemById(userObject.ID);
                                userPictureUrl =
                                    SPContext.Current.Site.MakeFullUrl(SPContext.Current.Web.ServerRelativeUrl) +
                                    "/_layouts/epmlive/images/O14_person_placeHolder_32.png";

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
                                        string[] picUrls =
                                            userItem[userItem.Fields.GetFieldByInternalName("Picture").Id].ToString()
                                                .Split(',');
                                        userPictureUrl = picUrls[0];
                                    }
                                    catch
                                    {
                                        userPictureUrl =
                                            SPContext.Current.Site.MakeFullUrl(SPContext.Current.Web.ServerRelativeUrl) +
                                            "/_layouts/epmlive/images/O14_person_placeHolder_32.png";
                                    }
                                }

                                // 1. display first item ordered by asending date
                                // 2. display rest ordered by desending date
                                // 3. do not repeat items 

                                string soriginComment2 = string.Empty;
                                try
                                {
                                    soriginComment2 = comment["Comment"].ToString();
                                }
                                catch { }

                                sbResult.Append(XML_RESPONSE_COMMENT_ITEM.Replace("##listId##",
                                    new Guid(sListId2).ToString())
                                    .Replace("##listName##", realItem.ParentList.Title)
                                    .Replace("##listDispUrl##", realItem.ParentList.DefaultDisplayFormUrl)
                                    .Replace("##listUrl##", realItem.ParentList.DefaultViewUrl)
                                    .Replace("##itemId##", sItemId2)
                                    .Replace("##itemTitle##", realItem.Title.Replace('\"', '\''))
                                    .Replace("##createdDate##", dCreated2.ToFriendlyDateAndTime())
                                    .Replace("##comment##",
                                        GetXMLSafeVersion(HttpUtility.HtmlDecode(soriginComment2 ?? string.Empty))));

                                sbResult.Append(XML_USER_INFO_SECTION.Replace("##username##", userObject.Name)
                                    .Replace("##useremail##", userObject.Email)
                                    .Replace("##userprofile##",
                                        UserProfileUrl.Replace("##userid##", userObject.ID.ToString()))
                                    .Replace("##userpic##", userPictureUrl));

                                sbResult.Append(XML_RESPONSE_COMMENT_ITEM_CLOSE);
                            }
                        }
                    }
                    sbResult.Append(XML_RESPONSE_COMMENT_SECTION_FOOTER);
                    totalThreads++;
                    loadedIds += (pair[0] + '^' + pair[1] + ',');

                    if (saLoadedItems.Count > 0 && !saLoadedItems.Contains(pair[0] + '^' + pair[1]))
                    {
                        break;
                    }
                }
                loadedIds = loadedIds.Trim(',');
                sbResult.Append(XML_RESPONSE_COMMENT_LOADEDIDS.Replace("##loadedids##", loadedIds));
                sbResult.Append(XML_RESPONSE_COMMENT_FOOTER);
                retVal = sbResult.ToString();
            }
            return retVal;
        }

        public static void InsertCommentCount(string listId, string itemId)
        {
            SPUser originalUser = SPContext.Current.Web.CurrentUser;
            SPWeb currentWeb = SPContext.Current.Web;
            SPSite currentSite = SPContext.Current.Site;
            SPList commentsList = currentWeb.Lists.TryGetList(COMMENTS_LIST_NAME);

            if (commentsList != null)
            {
                var targetListId = new Guid(listId);

                currentWeb.AllowUnsafeUpdates = true;
                SPList targetList = null;

                targetList = currentWeb.Lists.GetList(targetListId, false);
                var q = new SPQuery();
                q.Query = "<Where><And><Eq><FieldRef Name=\"ListId\" /><Value Type=\"Text\">" +
                          targetListId.ToString("D") +
                          "</Value></Eq><Eq><FieldRef Name=\"ItemId\" /><Value Type=\"Text\">" + itemId +
                          "</Value></Eq></And></Where>";
                SPListItemCollection itemsColl = commentsList.GetItems(q);
                int commentCount = (itemsColl.HasItems()) ? itemsColl.Count : 0;
                SPListItem item = targetList.GetItemById(Convert.ToInt32(itemId));

                SPField testFld = null;
                try
                {
                    testFld = targetList.Fields.GetFieldByInternalName("CommentCount");
                }
                catch (ArgumentException x)
                {
                    testFld = null;
                }

                if (testFld == null)
                {
                    try
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate
                        {
                            using (var site = new SPSite(currentSite.Url))
                            {
                                using (SPWeb web = site.OpenWeb(currentWeb.ServerRelativeUrl))
                                {
                                    web.AllowUnsafeUpdates = true;
                                    SPList newTargetList = web.Lists[targetListId];
                                    string fldCCIntName = newTargetList.Fields.Add("CommentCount", SPFieldType.Number,
                                        false);
                                    var fldCC =
                                        newTargetList.Fields.GetFieldByInternalName(fldCCIntName) as SPFieldNumber;
                                    fldCC.MinimumValue = 0;
                                    fldCC.Hidden = true;
                                    fldCC.Sealed = false;
                                    fldCC.AllowDeletion = false;
                                    fldCC.Update();
                                    newTargetList.Update();
                                    web.Update();
                                    SPListItem newItem = newTargetList.GetItemById(Convert.ToInt32(itemId));
                                    newItem[newTargetList.Fields.GetFieldByInternalName("CommentCount").Id] =
                                        commentCount;
                                    SetSocialEngineTransaction(newItem);
                                    newItem.SystemUpdate();
                                }
                            }
                        });
                    }
                    catch (Exception e) { }
                }
                else
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate
                    {
                        using (var site = new SPSite(currentSite.Url))
                        {
                            using (SPWeb web = site.OpenWeb(currentWeb.ServerRelativeUrl))
                            {
                                web.AllowUnsafeUpdates = true;
                                SPList newTargetList = web.Lists[targetListId];
                                SPListItem newItem = newTargetList.GetItemById(Convert.ToInt32(itemId));
                                newItem[targetList.Fields.GetFieldByInternalName("CommentCount").Id] = commentCount;
                                SetSocialEngineTransaction(newItem);
                                newItem.SystemUpdate();
                            }
                        }
                    });
                }
            }
            else
            {
                throw new Exception("The 'Comments' list needs to be created to support this functionality.");
            }
        }

        public static string ReadComment(string data)
        {
            string retVal = string.Empty;
            SPWeb currentWeb = SPContext.Current.Web;
            SPSite currentSite = SPContext.Current.Site;
            // Data should look like the following:
            // ===============================
            // <Data>
            // <Param key='ListId'></Param>
            // <Param key='ItemId'></Param>
            // </Data>

            // load data into XML manager
            var dataMgr = new XMLDataManager(data);
            SPList commentsList = currentWeb.Lists.TryGetList(COMMENTS_LIST_NAME);
            //SPUser user = currentWeb.AllUsers.GetByID(Convert.ToInt32(dataMgr.GetPropVal("UserId")));

            if (commentsList != null)
            {
                string listId = dataMgr.GetPropVal("ListId");
                string itemId = dataMgr.GetPropVal("ItemId");
                var query = new SPQuery();
                query.Query = "<Where><And><Eq><FieldRef Name=\"ListId\" /><Value Type=\"Text\">" + listId +
                              "</Value></Eq><Eq><FieldRef Name=\"ItemId\" /><Value Type=\"Text\">" + itemId +
                              "</Value></Eq></And></Where><OrderBy><FieldRef Name=\"Created\" Ascending=\"False\" /></OrderBy>";
                SPListItemCollection itemColl = commentsList.GetItems(query);

                if (itemColl.Count > 0)
                {
                    int commentItemId = Convert.ToInt32(dataMgr.GetPropVal("CommentItemId"));

                    foreach (SPListItem item in itemColl)
                    {
                        if (item.ID.Equals(commentItemId))
                        {
                            retVal = item[commentsList.Fields.GetFieldByInternalName("Comment").Id].ToString();
                            break;
                        }
                    }
                }

                InsertCommentCount(dataMgr.GetPropVal("ListId"), dataMgr.GetPropVal("ItemId"));
            }
            else
            {
                throw new Exception("The 'Comments' list needs to be created to support this functionality.");
            }

            return retVal;
        }

        public static string UpdateComment(string data)
        {
            string retVal = string.Empty;
            SPWeb cWeb = SPContext.Current.Web;
            SPSite cSite = SPContext.Current.Site;
            SPUser originalUser = SPContext.Current.Web.CurrentUser;
            // Data should look like the following:
            // ===============================
            // <Data>
            // <Param key='ListId'>someguid</Param>
            // <Param key='ItemId">12</Param>
            // <Param key='Comment'>abcabac</Param>
            // </Data>

            // load data into XML manager
            var dataMgr = new XMLDataManager(data);
            SPList commentsList = cWeb.Lists.TryGetList(COMMENTS_LIST_NAME);

            if (commentsList != null)
            {
                string listId = dataMgr.GetPropVal("ListId");
                string itemId = dataMgr.GetPropVal("ItemId");
                int commentItemId = Convert.ToInt32(dataMgr.GetPropVal("CommentItemId"));
                string comment = HttpUtility.HtmlDecode(dataMgr.GetPropVal("Comment"));
                var laCommenters = new List<int>();
                DateTime time = GetCurrentLocalTime();
                SPListItem originListItem = null;
                SPListItem targetComment = null;

                var query = new SPQuery();
                query.Query = "<Where><And><Eq><FieldRef Name=\"ListId\" /><Value Type=\"Text\">" + listId +
                              "</Value></Eq><Eq><FieldRef Name=\"ItemId\" /><Value Type=\"Text\">" + itemId +
                              "</Value></Eq></And></Where>";
                SPListItemCollection itemColl = commentsList.GetItems(query);

                if (itemColl.Count > 0)
                {
                    foreach (SPListItem item in itemColl)
                    {
                        if (item.ID.Equals(commentItemId))
                        {
                            cWeb.AllowUnsafeUpdates = true;
                            targetComment = item;
                            string genericTitle = cWeb.CurrentUser.Name + " updated this comment at " + time;
                            targetComment[commentsList.Fields.GetFieldByInternalName("Title").Id] = genericTitle;
                            targetComment[commentsList.Fields.GetFieldByInternalName("Comment").Id] = comment;
                            SetSocialEngineTransaction(targetComment);
                            targetComment.Update();

                            break;
                        }
                    }

                    SPList originList = null;

                    cWeb.AllowUnsafeUpdates = true;
                    originList = cWeb.Lists[new Guid(dataMgr.GetPropVal("ListId"))];

                    if (originList != null)
                    {
                        originListItem = originList.GetItemById(int.Parse(dataMgr.GetPropVal("ItemId")));
                    }

                    if (originListItem != null)
                    {
                        string sCommenters =
                            originListItem[originList.Fields.GetFieldByInternalName("Commenters").Id] != null
                                ? originListItem[originList.Fields.GetFieldByInternalName("Commenters").Id].ToString()
                                : string.Empty;
                        foreach (string s in sCommenters.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
                        {
                            if (!string.IsNullOrEmpty(s.Trim()))
                            {
                                laCommenters.Add(int.Parse(s));
                            }
                        }

                        // get user object 
                        var author = (SPFieldUser) originListItem.Fields[SPBuiltInFieldId.Author];
                        var userVal =
                            (SPFieldUserValue) author.GetFieldValue(originListItem[SPBuiltInFieldId.Author].ToString());
                        SPUser authorObj = userVal.User;
                        var emailSentIDs = new List<int>();

                        // send email to author
                        
                        var siteId = cSite.ID;
                        var webId = cWeb.ID;
                        var spUserToken = cWeb.CurrentUser.UserToken;

                        if ((authorObj != null) && (SPContext.Current.Web.CurrentUser.ID != authorObj.ID) &&
                            !emailSentIDs.Contains(authorObj.ID))
                        {
                            emailSentIDs.Add(authorObj.ID);
                            SendEmailNotification(authorObj.ID, dataMgr.GetPropVal("ListId"),
                                dataMgr.GetPropVal("ItemId"), dataMgr.GetPropVal("Comment"), siteId, webId, spUserToken);
                        }

                        // send emails out to people in assignedto field if that field exists
                        try
                        {
                            string[] vals =
                                originListItem[originListItem.Fields.GetFieldByInternalName("AssignedTo").Id].ToString()
                                    .Split(new[] {";#"}, StringSplitOptions.None);
                            foreach (string val in vals)
                            {
                                int id;
                                if (int.TryParse(val, out id) && !id.Equals(SPContext.Current.Web.CurrentUser.ID) &&
                                    !emailSentIDs.Contains(id))
                                {
                                    emailSentIDs.Add(id);
                                    SendEmailNotification(id, dataMgr.GetPropVal("ListId"), dataMgr.GetPropVal("ItemId"),
                                        dataMgr.GetPropVal("Comment"), siteId, webId, spUserToken);
                                }
                            }
                        }
                        catch { }

                        // send email to commenters
                        foreach (int id in laCommenters)
                        {
                            if ((id != SPContext.Current.Web.CurrentUser.ID) && !emailSentIDs.Contains(id))
                            {
                                emailSentIDs.Add(id);
                                SendEmailNotification(id, dataMgr.GetPropVal("ListId"), dataMgr.GetPropVal("ItemId"),
                                    dataMgr.GetPropVal("Comment"), siteId, webId, spUserToken);
                            }
                        }

                        SPSecurity.RunWithElevatedPrivileges(delegate
                        {
                            using (var es = new SPSite(siteId))
                            {
                                using (SPWeb ew = es.OpenWeb(cWeb.ServerRelativeUrl))
                                {
                                    ew.AllowUnsafeUpdates = true;
                                    SPList tempList = ew.Lists[originList.ID];
                                    SPListItem tempItem = tempList.GetItemById(originListItem.ID);
                                    tempItem[tempList.Fields.GetFieldByInternalName("CommentersRead").Id] = string.Empty;
                                    tempItem[tempList.Fields.GetFieldByInternalName("CommentersRead").Id] =
                                        originalUser.ID.ToString();
                                    SetSocialEngineTransaction(tempItem);
                                    tempItem.SystemUpdate();
                                }
                            }
                        });
                    }
                }
                else
                {
                    throw new Exception(String.Format("No comment with ListId = {0} and ItemId = {1} exists.", listId,
                        itemId));
                }

                InsertCommentCount(dataMgr.GetPropVal("ListId"), dataMgr.GetPropVal("ItemId"));

                retVal = "success";

                if (string.IsNullOrEmpty(comment) || originListItem == null) return retVal;

                try
                {
                    SyncToSocialStream(targetComment.UniqueId, comment, originListItem.ParentList.ID, originListItem.ID,
                        originListItem.Title,
                        originListItem.ParentList.Title, originListItem.Url, laCommenters, time, cWeb, "UPDATE");
                }
                catch { }
            }
            else
            {
                throw new Exception("The 'Comments' list needs to be created to support this functionality.");
            }

            return retVal;
        }

        public static bool UserIsAssigned(int userID, SPListItem item)
        {
            bool isAssigned = false;
            SPField testFld = null;

            try
            {
                testFld = item.Fields[item.Fields.GetFieldByInternalName("AssignedTo").Id];
            }
            catch { }

            if ((testFld != null) && (item[item.Fields.GetFieldByInternalName("AssignedTo").Id] != null))
            {
                string rawUserValues = item[item.Fields.GetFieldByInternalName("AssignedTo").Id].ToString();
                string[] vals = rawUserValues.Split(new[] {";#"}, StringSplitOptions.None);
                foreach (string s in vals)
                {
                    int id;
                    if (int.TryParse(s, out id) && id.Equals(SPContext.Current.Web.CurrentUser.ID))
                    {
                        isAssigned = true;
                    }
                }
            }

            return isAssigned;
        }

        // Private Methods (11) 

        private static bool AlreadyDisplayed(List<string[]> items, string[] item)
        {
            bool result = false;
            foreach (var pair in items)
            {
                if (pair[0].Equals(item[0]) && pair[1].Equals(item[1]))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private static bool ContainsItem(List<string[]> items, string[] item)
        {
            bool result = false;
            foreach (var pair in items)
            {
                string baseList = new Guid(pair[0]).ToString();
                string newList = new Guid(item[0]).ToString();
                if (baseList.Equals(newList) && pair[1].Equals(item[1]))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private static void DeleteFromSocialStream(string title, string listTitle, Guid listId, int itemId, string url,
            Guid commentItemId, SPWeb currentWeb)
        {
            SocialEngine.SocialEngine.Current.ProcessActivity(ObjectKind.ListItem, ActivityKind.CommentRemoved,
                new Dictionary<string, object>
                {
                    {"CommentId", commentItemId},
                    {"Id", itemId},
                    {"ListId", listId},
                    {"WebId", currentWeb.ID},
                    {"SiteId", currentWeb.Site.ID},
                    {"Title", title},
                    {"ListTitle", listTitle},
                    {"URL", url},
                    {"UserId", currentWeb.CurrentUser.ID},
                    {"ActivityTime", GetCurrentLocalTime()}
                }, currentWeb);
        }

        private static void EnsureMetaCols(SPList list)
        {
            string lists = CoreFunctions.getConfigSetting(list.ParentWeb, "EPM_Commentable_Lists");
            if (!string.IsNullOrEmpty(lists) && lists.Contains(list.ID.ToString())) return;

            foreach (SPFieldMultiLineText field in from col in new[] {"Commenters", "CommentersRead"}
                where !list.Fields.ContainsFieldWithInternalName(col)
                select list.Fields.Add(col, SPFieldType.Note, false)
                into fieldName
                select list.Fields.GetFieldByInternalName(fieldName) as SPFieldMultiLineText)
            {
                field.Sealed = false;
                field.Hidden = true;
                field.AllowDeletion = false;
                field.DefaultValue = string.Empty;
                field.Update();
                list.Update();
            }

            list.ParentWeb.Update();

            var allLists = new List<string>();
            if (!string.IsNullOrEmpty(lists)) allLists = lists.Split(',').ToList();

            allLists.Add(list.ID.ToString());

            CoreFunctions.setConfigSetting(list.ParentWeb, "EPM_Commentable_Lists", string.Join(",", allLists.ToArray()));
        }

        private static void EnsurePublicCommentsListExist()
        {
            SPWeb cWeb = SPContext.Current.Web;
            SPList lstPubComments = cWeb.Lists.TryGetList("PublicComments");

            if (lstPubComments == null)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    using (var eleSite = new SPSite(cWeb.Url))
                    {
                        using (SPWeb eleWeb = eleSite.OpenWeb())
                        {
                            eleWeb.AllowUnsafeUpdates = true;
                            Guid guid = eleWeb.Lists.Add("PublicComments", "", SPListTemplateType.GenericList);
                            lstPubComments = eleWeb.Lists[guid];
                            lstPubComments.Hidden = true;
                            lstPubComments.Update();

                            SPField fldCommenters = null;
                            string fldCommentersName = lstPubComments.Fields.Add("Commenters", SPFieldType.Note, false);
                            fldCommenters =
                                lstPubComments.Fields.GetFieldByInternalName(fldCommentersName) as SPFieldMultiLineText;
                            fldCommenters.Sealed = false;
                            fldCommenters.Hidden = true;
                            fldCommenters.AllowDeletion = false;
                            fldCommenters.DefaultValue = string.Empty;
                            fldCommenters.Update();

                            SPField fldCommentersRead = null;
                            string fldCommentersReadName = lstPubComments.Fields.Add("CommentersRead", SPFieldType.Note,
                                false);
                            fldCommentersRead =
                                lstPubComments.Fields.GetFieldByInternalName(fldCommentersReadName) as
                                    SPFieldMultiLineText;
                            fldCommentersRead.Hidden = true;
                            fldCommentersRead.Sealed = false;
                            fldCommentersRead.AllowDeletion = false;
                            fldCommentersRead.DefaultValue = string.Empty;
                            fldCommentersRead.Update();

                            lstPubComments.Update();
                            eleWeb.Update();
                        }
                    }
                });
            }
        }

        private static DateTime GetCurrentLocalTime()
        {
            SPRegionalSettings regionalSettings = SPContext.Current.RegionalSettings;
            return regionalSettings.TimeZone.UTCToLocalTime(DateTime.UtcNow);
        }

        private static string GetXMLSafeVersion(string s)
        {
            string result = s;
            if (!string.IsNullOrEmpty(result))
            {
                result = result.Replace("\"", "#quot#")
                    .Replace("&", "#amp#")
                    .Replace("'", "#apos#")
                    .Replace("<", "#lt#")
                    .Replace(">", "#gt#");
            }
            return result;
        }

        private static bool SendEmailNotification(int userID, string listId, string itemId, string newComment, Guid siteId, Guid webId, SPUserToken userToken)
        {
            using (var cSite = new SPSite(siteId, userToken))
            {
                using (var cWeb = cSite.OpenWeb(webId))
                {
                    bool mailSent = false;

                    // get target user email
                    SPUser targetUser = cWeb.AllUsers.GetByID(userID);

                    newComment = newComment.Replace("<P>", "")
                        .Replace("</P>", "")
                        .Replace("\n", "<br />")
                        .Replace("\r\n", "<br />");

                    if (newComment.Contains("%20"))
                    {
                        newComment = HttpUtility.UrlDecode(newComment);
                    }

                    try
                    {
                        //string subject = cWeb.CurrentUser.Name + " commented on: " + itemTitle;
                        Hashtable hshProps = BuildBody(cWeb.CurrentUser.Name, listId, itemId, newComment, cSite, cWeb);

                        SPList list = cWeb.Lists[new Guid(listId)];
                        SPListItem li = list.GetItemById(int.Parse(itemId));

                        APIEmail.QueueItemMessage(3, false, hshProps, new[] { targetUser.ID.ToString() }, null, false, true, li,
                            cWeb.CurrentUser, true);
                    }
                    catch (Exception e)
                    {
                        mailSent = false;
                    }

                    return mailSent;
                }
            }
        }

        private static void SetSocialEngineTransaction(SPListItem item)
        {
            try
            {
                SocialEngineProxy.SetTransaction(item.Web.ID, item.ParentList.ID, item.ID, "Comments", item.Web);
            }
            catch { }
        }

        private static void SyncStatusUpdateToSocialStream(Guid id, string status, Guid listId, int itemId,
            DateTime time, SPWeb spWeb, string operation, DateTime? commentTime = null, Guid? commentId = null)
        {
            Guid wId = spWeb.ID;

            ActivityKind activityKind;

            if (operation.Equals("ADD")) activityKind = ActivityKind.Created;
            else if (operation.Equals("UPDATE")) activityKind = ActivityKind.Updated;
            else if (operation.Equals("COMMENT")) activityKind = ActivityKind.CommentAdded;
            else return;

            SocialEngine.SocialEngine.Current.ProcessActivity(ObjectKind.StatusUpdate, activityKind,
                new Dictionary<string, object>
                {
                    {"Id", id},
                    {"Status", status},
                    {"Comment", status},
                    {"ItemId", itemId},
                    {"ListId", listId},
                    {"WebId", wId},
                    {"UserId", spWeb.CurrentUser.ID},
                    {"ActivityTime", time},
                    {"CommentTime", commentTime},
                    {"CommentId", commentId}
                }, spWeb);
        }

        private static void SyncToSocialStream(Guid id, string comment, Guid listId, int itemId, string itemTitle,
            string listTitle, string url, List<int> commenters, DateTime time, SPWeb spWeb, string operation)
        {
            Guid wId = spWeb.ID;

            ActivityKind activityKind;

            if (operation.Equals("ADD")) activityKind = ActivityKind.CommentAdded;
            else if (operation.Equals("UPDATE")) activityKind = ActivityKind.CommentUpdated;
            else return;

            SocialEngine.SocialEngine.Current.ProcessActivity(ObjectKind.ListItem, activityKind,
                new Dictionary<string, object>
                {
                    {"CommentId", id},
                    {"Comment", comment},
                    {"Commenters", string.Join(",", commenters.ToArray())},
                    {"Id", itemId},
                    {"Title", itemTitle},
                    {"ListTitle", listTitle},
                    {"ListId", listId},
                    {"URL", url},
                    {"WebId", wId},
                    {"SiteId", spWeb.Site.ID},
                    {"UserId", spWeb.CurrentUser.ID},
                    {"ActivityTime", time}
                }, spWeb);
        }

        #endregion Methods 
    }
}