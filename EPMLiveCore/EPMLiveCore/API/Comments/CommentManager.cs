using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using EPMLiveCore.SocialEngine;
using EPMLiveCore.SocialEngine.Core;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    internal class CommentManager
    {
        // methods
        // insert new comment
        // edit comment
        // delete comment
        const string COMMENTS_LIST_NAME = "Comments";
        const string XML_RESPONSE_COMMENT_HEADER = "<Comments>";
        const string XML_RESPONSE_COMMENT_LOADEDIDS = "<LoadedIds>##loadedids##</LoadedIds>";
        const string XML_RESPONSE_COMMENT_SECTION_HEADER = "<CommentItem listId=\"##listId##\" itemId=\"##itemId##\">";

        const string XML_RESPONSE_COMMENT_ITEM = "<Comment " +
                                                 "listId=\"##listId##\" " +
                                                 "listName=\"##listName##\" " +
                                                 "listUrl=\"##listUrl##\" " +
                                                 "listDispUrl=\"##listDispUrl##\" " +
                                                 "itemId=\"##itemId##\" " +
                                                 "itemTitle=\"##itemTitle##\" " +
                                                 "createdDate=\"##createdDate##\" " +
                                                 "isLast=\"##isLast##\" " +
                                                 "><![CDATA[##comment##]]>";

        const string XML_USER_INFO_SECTION = "<UserInfo>" +
                                                "<UserName><![CDATA[##username##]]></UserName>" +
                                                "<UserProfileUrl><![CDATA[##userprofile##]]></UserProfileUrl>" +
                                                "<UserPic><![CDATA[##userpic##]]></UserPic>" +
                                                "<UserEmail><![CDATA[##useremail##]]></UserEmail>" +
                                             "</UserInfo>";
        const string XML_RESPONSE_COMMENT_ITEM_CLOSE = "</Comment>";
        const string XML_RESPONSE_COMMENT_SECTION_FOOTER = "</CommentItem>";
        const string XML_RESPONSE_COMMENT_FOOTER = "</Comments>";

        const string XML_RESPONSE_PUBLIC_COMMENT_ITEM = "<PublicCommentItem listId=\"##pubComListId##\" itemId=\"##pubComItemId##\" />";

        //const string XML_RESPONSE_COMMENT_SECTION_HEADER = "<CommentItem listId=\"##listId##\" itemId=\"##itemId##\">";

        static string _userProfileUrl = SPContext.Current.Site.MakeFullUrl(SPContext.Current.Web.ServerRelativeUrl) + "/_layouts/userdisp.aspx?Force=True&ID=##userid##&source=" + HttpContext.Current.Request.UrlReferrer;

        public static string CreateComment(string data)
        {
            string retVal = string.Empty;
            SPWeb cWeb = SPContext.Current.Web;
            SPSite cSite = SPContext.Current.Site;
            // Data should look like the following:
            // ===============================
            // <Data>
            // <Param key="ListId">someguid</Param>
            // <Param key="ItemId">12</Param>
            // <Param key="Comment">abcabac</Param>
            // </Data>

            // load data into XML manager
            XMLDataManager dataMgr = new XMLDataManager(data);
            SPList commentsList = cWeb.Lists.TryGetList(COMMENTS_LIST_NAME);

            StringBuilder sbResult = new StringBuilder();
            sbResult.Append(XML_RESPONSE_COMMENT_HEADER);

            if (commentsList != null)
            {
                cWeb.AllowUnsafeUpdates = true;
                SPListItem currentItem = commentsList.Items.Add();

                var time = GetCurrentLocalTime();
                bool statusUpdate;
                bool.TryParse(dataMgr.GetPropVal("StatusUpdate"), out statusUpdate);
                var statusUpdateId = dataMgr.GetPropVal("StatusUpdateId");

                string genericTitle = cWeb.CurrentUser.Name + " made a new comment at " + time.ToString();
                currentItem[commentsList.Fields.GetFieldByInternalName("Title").Id] = genericTitle;

                var listId = dataMgr.GetPropVal("ListId");
                var itemId = dataMgr.GetPropVal("ItemId");
                var comment = HttpUtility.HtmlDecode(dataMgr.GetPropVal("Comment") ?? string.Empty);
                List<int> laCommenters = new List<int>();
                SPListItem originListItem = null;

                currentItem[commentsList.Fields.GetFieldByInternalName("ListId").Id] = listId;
                currentItem[commentsList.Fields.GetFieldByInternalName("ItemId").Id] = itemId;
                currentItem[commentsList.Fields.GetFieldByInternalName("Comment").Id] = comment;
                //currentItem[commentsList.Fields.GetFieldByInternalName("Comment").Id] = Uri.UnescapeDataString(dataMgr.GetPropVal("Comment"));

                SetSocialEngineTransaction(currentItem);
                currentItem.Update();

                sbResult.Append(XML_RESPONSE_COMMENT_SECTION_HEADER.Replace("##listId##", currentItem.ParentList.ID.ToString()).Replace("##itemId##", currentItem.ID.ToString()));
                sbResult.Append(XML_RESPONSE_COMMENT_ITEM.Replace("##listId##", currentItem.ParentList.ID.ToString())
                                                         .Replace("##listName##", currentItem.ParentList.Title)
                                                         .Replace("##itemId##", currentItem.ID.ToString())
                                                         .Replace("##itemTitle##", currentItem.Title)
                                                         .Replace("##createdDate##", ((DateTime)currentItem["Created"]).ToFriendlyDateAndTime(cWeb))
                                                         .Replace("##comment##", GetXMLSafeVersion((string)(comment))));
                sbResult.Append(XML_RESPONSE_COMMENT_ITEM_CLOSE);
                sbResult.Append(XML_RESPONSE_COMMENT_SECTION_FOOTER);
                sbResult.Append(XML_RESPONSE_COMMENT_FOOTER);
                // save current user
                SPUser originalUser = SPContext.Current.Web.CurrentUser;

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                    {
                        using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ServerRelativeUrl))
                        {
                            SPList originList = null;
                            ew.AllowUnsafeUpdates = true;
                            originList = ew.Lists[new Guid(listId)];

                            if (originList != null)
                            {
                                originListItem = originList.GetItemById(int.Parse(itemId));
                            }

                            if (originListItem != null)
                            {
                                EnsureMetaCols(originList);

                                var emailSentIDs = GenerateEmailSentIds(originListItem, originList, laCommenters, originalUser, listId, itemId, comment);

                                // send email to assigned to people
                                try
                                {
                                    string[] vals = originListItem[originListItem.Fields.GetFieldByInternalName("AssignedTo").Id].ToString().Split(new string[] { ";#" }, StringSplitOptions.None);
                                    foreach (string val in vals)
                                    {
                                        int id;
                                        if (int.TryParse(val, out id) && !id.Equals(originalUser.ID) && !emailSentIDs.Contains(id))
                                        {
                                            emailSentIDs.Add(id);
                                            SendEmailNotification(id, listId, itemId, comment, "created");
                                        }
                                    }
                                }
                                catch
                                {
                                }

                                // send email to each person in thread
                                foreach (int id in laCommenters)
                                {
                                    if ((id != originalUser.ID) && !emailSentIDs.Contains(id))
                                    {
                                        emailSentIDs.Add(id);
                                        SendEmailNotification(id, listId, itemId, comment, "created");
                                    }
                                }
                            }

                            string createdDate = currentItem["Created"].ToString();
                            //retVal = currentItem.ID.ToString() + "," + createdDate;
                            retVal = sbResult.ToString();
                            InsertCommentCount(listId, itemId);
                        }
                    }
                });

                if (!string.IsNullOrEmpty(comment) && originListItem != null)
                {
                    try
                    {
                        if (!statusUpdate)
                        {
                            SyncToSocialStream(currentItem.UniqueId, comment, originListItem.ParentList.ID,
                                originListItem.ID, originListItem.Title,
                                originListItem.ParentList.Title, originListItem.ParentList.DefaultDisplayFormUrl + "?ID=" + originListItem.ID, laCommenters, time, cWeb, "ADD");
                        }
                        else
                        {
                            var sId = new Guid(statusUpdateId);

                            var statusItem = currentItem.ParentList.GetItemByUniqueId(sId);

                            SyncStatusUpdateToSocialStream(sId, comment,
                                new Guid(currentItem["ListId"].ToString()),
                                int.Parse(currentItem["ItemId"].ToString()), (DateTime)statusItem["Created"], cWeb,
                                "COMMENT", (DateTime?)currentItem["Created"], currentItem.UniqueId);
                        }
                    }
                    catch { }
                }
            }
            else
            {
                throw new Exception("The 'Comments' list needs to be created to support this functionality.");
            }

            return retVal;
        }

        private static void EnsureMetaCols(SPList list)
        {
            string lists = CoreFunctions.getConfigSetting(list.ParentWeb, "EPM_Commentable_Lists");
            if (!string.IsNullOrEmpty(lists) && lists.Contains(list.ID.ToString())) return;

            foreach (var field in from col in new[] { "Commenters", "CommentersRead" }
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

        private static List<int> GenerateEmailSentIds(
            SPListItem originListItem,
            SPList originList,
            List<int> laCommenters,
            SPUser originalUser,
            string listId,
            string itemId,
            string comment)
        {
            var item = originListItem[originList.Fields.GetFieldByInternalName("Commenters").Id];
            var commenters = item != null ? item.ToString() : string.Empty;
            foreach (var commenter in commenters.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (!string.IsNullOrEmpty(commenter.Trim()))
                {
                    laCommenters.Add(int.Parse(commenter));
                }
            }
            // get user object 
            var author = (SPFieldUser)originListItem.Fields[SPBuiltInFieldId.Author];
            var userVal = (SPFieldUserValue)author.GetFieldValue(originListItem[SPBuiltInFieldId.Author].ToString());
            var authorObj = userVal.User;

            // if user is not in commenters, and not creater or one of the assigned to users
            if (!laCommenters.Contains(originalUser.ID) &&
                (authorObj != null && !originalUser.ID.Equals(authorObj.ID)) &&
                !UserIsAssigned(originalUser.ID, originListItem))
            {
                laCommenters.Add(originalUser.ID);
                var newCommenters = new StringBuilder();
                foreach (var id in laCommenters)
                {
                    newCommenters.Append(id.ToString() + ",");
                }

                commenters = newCommenters.ToString();
                commenters = commenters.Remove(commenters.LastIndexOf(','));

                originListItem[originList.Fields.GetFieldByInternalName("Commenters").Id] = commenters;
            }

            // set commentersread to blank
            originListItem[originList.Fields.GetFieldByInternalName("CommentersRead").Id] = string.Empty;
            // add current user to list
            originListItem[originList.Fields.GetFieldByInternalName("CommentersRead").Id] = originalUser.ID.ToString();
            SetSocialEngineTransaction(originListItem);
            originListItem.SystemUpdate();

            var emailSentIds = new List<int>();
            // send email to author
            if (authorObj != null && originalUser.ID != authorObj.ID)
            {
                emailSentIds.Add(authorObj.ID);
                SendEmailNotification(authorObj.ID, listId, itemId, comment, "created");
            }
            return emailSentIds;
        }

        private static void SyncToSocialStream(Guid id, string comment, Guid listId, int itemId, string itemTitle,
            string listTitle, string url, List<int> commenters, DateTime time, SPWeb spWeb, string operation)
        {
            var wId = spWeb.ID;

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

        private static void SyncStatusUpdateToSocialStream(Guid id, string status, Guid listId, int itemId,
            DateTime time, SPWeb spWeb, string operation, DateTime? commentTime = null, Guid? commentId = null)
        {
            var wId = spWeb.ID;

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

        public static string CreatePublicComment(string data)
        {
            string retVal = string.Empty;
            SPWeb cWeb = SPContext.Current.Web;
            SPSite cSite = SPContext.Current.Site;
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
            var publicCommentsList = cWeb.Lists.TryGetList("PublicComments");
            var commentsList = cWeb.Lists.TryGetList(COMMENTS_LIST_NAME);
            var itemId = dataMgr.GetPropVal("ItemId");
            dataMgr.EditProp("ListId", publicCommentsList.ID.ToString());

            if (string.IsNullOrEmpty(itemId))
            {
                cWeb.AllowUnsafeUpdates = true;
                var newItem = publicCommentsList.Items.Add();
                SetSocialEngineTransaction(newItem);
                newItem.Update();
                dataMgr.EditProp("ItemId", newItem.ID.ToString());
            }

            StringBuilder sbResult = new StringBuilder();
            sbResult.Append(XML_RESPONSE_COMMENT_HEADER);

            if (publicCommentsList != null && commentsList != null)
            {
                cWeb.AllowUnsafeUpdates = true;
                SPListItem currentItem = commentsList.Items.Add();
                string genericTitle = cWeb.CurrentUser.Name + " made a new comment at " + DateTime.Now.ToString();
                currentItem[commentsList.Fields.GetFieldByInternalName("Title").Id] = genericTitle;
                currentItem[commentsList.Fields.GetFieldByInternalName("ListId").Id] = dataMgr.GetPropVal("ListId");
                currentItem[commentsList.Fields.GetFieldByInternalName("ItemId").Id] = dataMgr.GetPropVal("ItemId");
                var comment = dataMgr.GetPropVal("Comment");

                currentItem[commentsList.Fields.GetFieldByInternalName("Comment").Id] = comment;
                //currentItem[commentsList.Fields.GetFieldByInternalName("Comment").Id] = Uri.UnescapeDataString(dataMgr.GetPropVal("Comment"));
                SetSocialEngineTransaction(currentItem);
                currentItem.Update();

                sbResult.Append(XML_RESPONSE_PUBLIC_COMMENT_ITEM.Replace("##pubComListId##", dataMgr.GetPropVal("ListId")).Replace("##pubComItemId##", dataMgr.GetPropVal("ItemId")));
                sbResult.Append(XML_RESPONSE_COMMENT_SECTION_HEADER.Replace("##listId##", currentItem.ParentList.ID.ToString()).Replace("##itemId##", currentItem.ID.ToString()));
                sbResult.Append(XML_RESPONSE_COMMENT_ITEM.Replace("##listId##", currentItem.ParentList.ID.ToString())
                                                         .Replace("##listName##", currentItem.ParentList.Title)
                                                         .Replace("##itemId##", currentItem.ID.ToString())
                                                         .Replace("##itemTitle##", currentItem.Title)
                                                         .Replace("##createdDate##", ((DateTime)currentItem["Created"]).ToFriendlyDateAndTime(cWeb))
                                                         .Replace("##comment##", GetXMLSafeVersion((string)(HttpUtility.HtmlDecode(comment ?? string.Empty)))));
                sbResult.Append(XML_RESPONSE_COMMENT_ITEM_CLOSE);
                sbResult.Append(XML_RESPONSE_COMMENT_SECTION_FOOTER);
                sbResult.Append(XML_RESPONSE_COMMENT_FOOTER);
                // save current user
                SPUser originalUser = SPContext.Current.Web.CurrentUser;

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                    {
                        using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ServerRelativeUrl))
                        {
                            SPList originList = null;
                            SPListItem originListItem = null;
                            List<int> laCommenters = new List<int>();
                            ew.AllowUnsafeUpdates = true;
                            originList = ew.Lists[new Guid(dataMgr.GetPropVal("ListId"))];

                            if (originList != null)
                            {
                                originListItem = originList.GetItemById(int.Parse(dataMgr.GetPropVal("ItemId")));
                            }

                            if (originListItem != null)
                            {
                                var emailSentIDs = GenerateEmailSentIds(originListItem, originList, laCommenters, originalUser, dataMgr.GetPropVal("ListId"), dataMgr.GetPropVal("ItemId"), comment);

                                // send email to assigned to people
                                try
                                {
                                    string[] vals = originListItem[originListItem.Fields.GetFieldByInternalName("AssignedTo").Id].ToString().Split(new string[] { ";#" }, StringSplitOptions.None);
                                    foreach (string val in vals)
                                    {
                                        int id;
                                        if (int.TryParse(val, out id) && !id.Equals(originalUser.ID) && !emailSentIDs.Contains(id))
                                        {
                                            emailSentIDs.Add(id);
                                            SendEmailNotification(id, dataMgr.GetPropVal("ListId"), dataMgr.GetPropVal("ItemId"), comment, "created");
                                        }
                                    }
                                }
                                catch
                                {
                                }

                                // send email to each person in thread
                                foreach (int id in laCommenters)
                                {
                                    if ((id != originalUser.ID) && !emailSentIDs.Contains(id))
                                    {
                                        emailSentIDs.Add(id);
                                        SendEmailNotification(id, dataMgr.GetPropVal("ListId"), dataMgr.GetPropVal("ItemId"), comment, "created");
                                    }
                                }
                            }

                            string createdDate = currentItem["Created"].ToString();
                            //retVal = currentItem.ID.ToString() + "," + createdDate;
                            retVal = sbResult.ToString();
                            InsertCommentCount(dataMgr.GetPropVal("ListId"), dataMgr.GetPropVal("ItemId"));
                        }
                    }
                });

                try
                {
                    if (!string.IsNullOrEmpty(comment))
                    {
                        comment = comment.Trim();

                        SyncStatusUpdateToSocialStream(currentItem.UniqueId, comment, new Guid(currentItem["ListId"].ToString()),
                            int.Parse(currentItem["ItemId"].ToString()), (DateTime)currentItem["Created"], cWeb, "ADD");
                    }
                }
                catch { }

            }
            else
            {
                throw new Exception("Both 'PublicComments' list and 'Comments' list needs to be created to support this functionality.");
            }

            return retVal;
        }

        static void EnsurePublicCommentsListExist()
        {
            SPSite cSite = SPContext.Current.Site;
            SPWeb cWeb = SPContext.Current.Web;
            SPList lstPubComments = cWeb.Lists.TryGetList("PublicComments");

            if (lstPubComments == null)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (var eleSite = new SPSite(cWeb.Url))
                    {
                        using (var eleWeb = eleSite.OpenWeb())
                        {
                            eleWeb.AllowUnsafeUpdates = true;
                            var guid = eleWeb.Lists.Add("PublicComments", "", SPListTemplateType.GenericList);
                            lstPubComments = eleWeb.Lists[guid];
                            lstPubComments.Hidden = true;
                            lstPubComments.Update();

                            SPField fldCommenters = null;
                            string fldCommentersName = lstPubComments.Fields.Add("Commenters", SPFieldType.Note, false);
                            fldCommenters = lstPubComments.Fields.GetFieldByInternalName(fldCommentersName) as SPFieldMultiLineText;
                            fldCommenters.Sealed = false;
                            fldCommenters.Hidden = true;
                            fldCommenters.AllowDeletion = false;
                            fldCommenters.DefaultValue = string.Empty;
                            fldCommenters.Update();

                            SPField fldCommentersRead = null;
                            string fldCommentersReadName = lstPubComments.Fields.Add("CommentersRead", SPFieldType.Note, false);
                            fldCommentersRead = lstPubComments.Fields.GetFieldByInternalName(fldCommentersReadName) as SPFieldMultiLineText;
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
            XMLDataManager dataMgr = new XMLDataManager(data);
            SPList commentsList = currentWeb.Lists.TryGetList(COMMENTS_LIST_NAME);
            //SPUser user = currentWeb.AllUsers.GetByID(Convert.ToInt32(dataMgr.GetPropVal("UserId")));

            if (commentsList != null)
            {
                string listId = dataMgr.GetPropVal("ListId");
                string itemId = dataMgr.GetPropVal("ItemId");
                SPQuery query = new SPQuery();
                query.Query = "<Where><And><Eq><FieldRef Name=\"ListId\" /><Value Type=\"Text\">" + listId + "</Value></Eq><Eq><FieldRef Name=\"ItemId\" /><Value Type=\"Text\">" + itemId + "</Value></Eq></And></Where><OrderBy><FieldRef Name=\"Created\" Ascending=\"False\" /></OrderBy>";
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
            XMLDataManager dataMgr = new XMLDataManager(data);
            SPList commentsList = cWeb.Lists.TryGetList(COMMENTS_LIST_NAME);

            if (commentsList != null)
            {
                string listId = dataMgr.GetPropVal("ListId");
                string itemId = dataMgr.GetPropVal("ItemId");
                int commentItemId = Convert.ToInt32(dataMgr.GetPropVal("CommentItemId"));
                var comment = HttpUtility.HtmlDecode(dataMgr.GetPropVal("Comment"));
                List<int> laCommenters = new List<int>();
                var time = GetCurrentLocalTime();
                SPListItem originListItem = null;
                SPListItem targetComment = null;

                SPQuery query = new SPQuery();
                query.Query = "<Where><And><Eq><FieldRef Name=\"ListId\" /><Value Type=\"Text\">" + listId + "</Value></Eq><Eq><FieldRef Name=\"ItemId\" /><Value Type=\"Text\">" + itemId + "</Value></Eq></And></Where>";
                SPListItemCollection itemColl = commentsList.GetItems(query);

                if (itemColl.Count > 0)
                {
                    foreach (SPListItem item in itemColl)
                    {
                        if (item.ID.Equals(commentItemId))
                        {
                            cWeb.AllowUnsafeUpdates = true;
                            targetComment = item;
                            string genericTitle = cWeb.CurrentUser.Name + " updated this comment at " + time.ToString();
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
                        string sCommenters = originListItem[originList.Fields.GetFieldByInternalName("Commenters").Id] != null ? originListItem[originList.Fields.GetFieldByInternalName("Commenters").Id].ToString() : string.Empty;
                        foreach (string s in sCommenters.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            if (!string.IsNullOrEmpty(s.Trim()))
                            {
                                laCommenters.Add(int.Parse(s));
                            }
                        }

                        // get user object 
                        SPFieldUser author = (SPFieldUser)originListItem.Fields[SPBuiltInFieldId.Author];
                        SPFieldUserValue userVal = (SPFieldUserValue)author.GetFieldValue(originListItem[SPBuiltInFieldId.Author].ToString());
                        SPUser authorObj = userVal.User;
                        List<int> emailSentIDs = new List<int>();

                        // send email to author
                        if ((authorObj != null) && (SPContext.Current.Web.CurrentUser.ID != authorObj.ID) && !emailSentIDs.Contains(authorObj.ID))
                        {
                            emailSentIDs.Add(authorObj.ID);
                            SendEmailNotification(authorObj.ID, dataMgr.GetPropVal("ListId"), dataMgr.GetPropVal("ItemId"), dataMgr.GetPropVal("Comment"), "edited");
                        }

                        // send emails out to people in assignedto field if that field exists
                        try
                        {
                            string[] vals = originListItem[originListItem.Fields.GetFieldByInternalName("AssignedTo").Id].ToString().Split(new string[] { ";#" }, StringSplitOptions.None);
                            foreach (string val in vals)
                            {
                                int id;
                                if (int.TryParse(val, out id) && !id.Equals(SPContext.Current.Web.CurrentUser.ID) && !emailSentIDs.Contains(id))
                                {
                                    emailSentIDs.Add(id);
                                    SendEmailNotification(id, dataMgr.GetPropVal("ListId"), dataMgr.GetPropVal("ItemId"), dataMgr.GetPropVal("Comment"), "created");
                                }
                            }
                        }
                        catch
                        {
                        }

                        // send email to commenters
                        foreach (int id in laCommenters)
                        {
                            if ((id != SPContext.Current.Web.CurrentUser.ID) && !emailSentIDs.Contains(id))
                            {
                                emailSentIDs.Add(id);
                                SendEmailNotification(id, dataMgr.GetPropVal("ListId"), dataMgr.GetPropVal("ItemId"), dataMgr.GetPropVal("Comment"), "edited");
                            }
                        }

                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            using (SPSite es = new SPSite(cSite.ID))
                            {
                                using (SPWeb ew = es.OpenWeb(cWeb.ServerRelativeUrl))
                                {
                                    ew.AllowUnsafeUpdates = true;
                                    SPList tempList = ew.Lists[originList.ID];
                                    SPListItem tempItem = tempList.GetItemById(originListItem.ID);
                                    tempItem[tempList.Fields.GetFieldByInternalName("CommentersRead").Id] = string.Empty;
                                    tempItem[tempList.Fields.GetFieldByInternalName("CommentersRead").Id] = originalUser.ID.ToString();
                                    SetSocialEngineTransaction(tempItem);
                                    tempItem.SystemUpdate();
                                }
                            }
                        });

                    }
                }
                else
                {
                    throw new Exception(String.Format("No comment with ListId = {0} and ItemId = {1} exists.", listId, itemId));
                }

                InsertCommentCount(dataMgr.GetPropVal("ListId"), dataMgr.GetPropVal("ItemId"));

                retVal = "success";

                if (string.IsNullOrEmpty(comment) || originListItem == null) return retVal;

                try
                {
                    SyncToSocialStream(targetComment.UniqueId, comment, originListItem.ParentList.ID, originListItem.ID, originListItem.Title,
                        originListItem.ParentList.Title, originListItem.ParentList.DefaultDisplayFormUrl + "?ID=" + originListItem.ID, laCommenters, time, cWeb, "UPDATE");
                }
                catch { }
            }
            else
            {
                throw new Exception("The 'Comments' list needs to be created to support this functionality.");
            }

            return retVal;
        }

        private static DateTime GetCurrentLocalTime()
        {
            var regionalSettings = SPContext.Current.RegionalSettings;
            return regionalSettings.TimeZone.UTCToLocalTime(DateTime.UtcNow);
        }

        // Data should look like the following:
        // ===============================
        // <Data>
        // <Param key='ListId'>someguid</Param>
        // <Param key='ItemId">12</Param>
        // <Param key='Comment'>abcabac</Param>
        // </Data>
        public static string DeleteComment(string data)
        {
            var returnValue = string.Empty;
            var currentWeb = SPContext.Current.Web;
            var currentSite = SPContext.Current.Site;
            var dataMgr = new XMLDataManager(data);
            var commentsList = currentWeb.Lists.TryGetList(COMMENTS_LIST_NAME);

            if (commentsList != null)
            {
                var listId = dataMgr.GetPropVal("ListId");
                var itemId = dataMgr.GetPropVal("ItemId");
                var commentItemId = Convert.ToInt32(dataMgr.GetPropVal("CommentItemId"));
                var originList = currentWeb.Lists[new Guid(dataMgr.GetPropVal("ListId"))];
                var originListItem = originList?.GetItemById(int.Parse(dataMgr.GetPropVal("ItemId")));
                var query = new SPQuery()
                {
                    Query = $"<Where><And><Eq><FieldRef Name=\"ListId\" /><Value Type=\"Text\">{listId}</Value></Eq><Eq><FieldRef Name=\"ItemId\" /><Value Type=\"Text\">{itemId}</Value></Eq></And></Where>"
                };
                var comments = commentsList.GetItems(query);
                var userHasCommentsLeft = false;

                if (comments.Count > 0)
                {
                    userHasCommentsLeft = DeleteUserComments(comments, commentItemId, currentWeb, originListItem);
                }
                else
                {
                    throw new Exception(String.Format("No comment with ListId = {0} and ItemId = {1} exists.", listId, itemId));
                }

                if (!userHasCommentsLeft)
                {
                    UpdateSocialEngineTransaction(currentWeb, currentSite, originList, originListItem);
                }

                InsertCommentCount(listId, itemId);

                returnValue = "Success";
            }
            else
            {
                throw new Exception("The 'Comments' list needs to be created to support this functionality.");
            }

            return returnValue;
        }

        private static bool DeleteUserComments(SPListItemCollection comments, int commentItemId, SPWeb currentWeb, SPListItem originListItem)
        {
            var userHasCommentsLeft = false;
            foreach (SPListItem comment in comments)
            {
                if (comment.ID.Equals(commentItemId))
                {
                    currentWeb.AllowUnsafeUpdates = true;
                    SetSocialEngineTransaction(comment);
                    DeleteFromSocialStream(originListItem, comment, currentWeb);
                    comment.Delete();
                }

                // get user object 
                var author = (SPFieldUser)comment.Fields[SPBuiltInFieldId.Author];
                var userVal = (SPFieldUserValue)author.GetFieldValue(comment[SPBuiltInFieldId.Author].ToString());
                var authorObj = userVal.User;

                if (authorObj != null && authorObj.ID == SPContext.Current.Web.CurrentUser.ID)
                {
                    userHasCommentsLeft = true;
                }
            }
            return userHasCommentsLeft;
        }

        private static void DeleteFromSocialStream(SPListItem originListItem, SPListItem comment, SPWeb currentWeb)
        {
            try
            {
                DeleteFromSocialStream(
                    originListItem.Title,
                    originListItem.ParentList.Title,
                    originListItem.ParentList.ID,
                    originListItem.ID,
                    originListItem.Url,
                    comment.UniqueId,
                    currentWeb
                );
            }
            catch (Exception e)
            {
                Trace.TraceWarning("Unable to delete from social stream: {0}", e);
            }
        }

        private static void UpdateSocialEngineTransaction(SPWeb currentWeb, SPSite currentSite, SPList originList, SPListItem originListItem)
        {
            const string commentersField = "Commenters";
            const string commentersReadField = "CommentersRead";

            var laCommenters = new List<int>();
            var laCommentersRead = new List<int>();

            currentWeb.AllowUnsafeUpdates = true;

            if (originListItem != null)
            {
                var newComenters = ReadCommentersAndRemoveCurrentUser(originList, originListItem, commentersField, laCommenters);
                var newComentersRead = ReadCommentersAndRemoveCurrentUser(originList, originListItem, commentersReadField, laCommentersRead);

                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (var site = new SPSite(currentSite.Url))
                    using (var web = site.OpenWeb(currentWeb.ServerRelativeUrl))
                    {
                        web.AllowUnsafeUpdates = true;
                        var tempList = web.Lists[originList.ID];
                        var tempItem = tempList.GetItemById(originListItem.ID);
                        tempItem[tempList.Fields.GetFieldByInternalName(commentersField).Id] = newComenters;
                        tempItem[tempList.Fields.GetFieldByInternalName(commentersReadField).Id] = newComentersRead;
                        SetSocialEngineTransaction(tempItem);
                        tempItem.SystemUpdate();
                    }
                });
            }
        }

        private static string ReadCommentersAndRemoveCurrentUser(SPList originList, SPListItem originListItem, string commentersField, List<int> commentersList)
        {
            var fieldId = originList.Fields.GetFieldByInternalName(commentersField).Id;
            var commenters = originListItem[fieldId] != null ? originListItem[fieldId].ToString() : string.Empty;

            foreach (var commenter in commenters.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (!string.IsNullOrWhiteSpace(commenter.Trim()))
                {
                    commentersList.Add(int.Parse(commenter));
                }
            }

            if (commentersList.Contains(SPContext.Current.Web.CurrentUser.ID))
            {
                commentersList.Remove(SPContext.Current.Web.CurrentUser.ID);
            }

            return string.Join(",", commentersList);
        }

        private static void DeleteFromSocialStream(string title, string listTitle, Guid listId, int itemId, string url, Guid commentItemId, SPWeb currentWeb)
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

        public static void InsertCommentCount(string listId, string itemId)
        {
            SPUser originalUser = SPContext.Current.Web.CurrentUser;
            SPWeb currentWeb = SPContext.Current.Web;
            SPSite currentSite = SPContext.Current.Site;
            SPList commentsList = currentWeb.Lists.TryGetList(COMMENTS_LIST_NAME);

            if (commentsList != null)
            {

                Guid targetListId = new Guid(listId);

                currentWeb.AllowUnsafeUpdates = true;
                SPList targetList = null;

                targetList = currentWeb.Lists.GetList(targetListId, false);
                SPQuery q = new SPQuery();
                q.Query = "<Where><And><Eq><FieldRef Name=\"ListId\" /><Value Type=\"Text\">" + targetListId.ToString("D") + "</Value></Eq><Eq><FieldRef Name=\"ItemId\" /><Value Type=\"Text\">" + itemId + "</Value></Eq></And></Where>";
                SPListItemCollection itemsColl = commentsList.GetItems(q);
                int commentCount = (itemsColl.HasItems()) ? itemsColl.Count : 0;
                SPListItem item = targetList.GetItemById(Convert.ToInt32(itemId));

                SPField testFld = null;
                try
                {
                    testFld = targetList.Fields.GetFieldByInternalName("CommentCount");
                }
                catch (System.ArgumentException x)
                {
                    testFld = null;
                }

                if (testFld == null)
                {
                    try
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            using (SPSite site = new SPSite(currentSite.Url))
                            {
                                using (SPWeb web = site.OpenWeb(currentWeb.ServerRelativeUrl))
                                {
                                    web.AllowUnsafeUpdates = true;
                                    SPList newTargetList = web.Lists[targetListId];
                                    string fldCCIntName = newTargetList.Fields.Add("CommentCount", SPFieldType.Number, false);
                                    SPFieldNumber fldCC = newTargetList.Fields.GetFieldByInternalName(fldCCIntName) as SPFieldNumber;
                                    fldCC.MinimumValue = 0;
                                    fldCC.Hidden = true;
                                    fldCC.Sealed = false;
                                    fldCC.AllowDeletion = false;
                                    fldCC.Update();
                                    newTargetList.Update();
                                    web.Update();
                                    SPListItem newItem = newTargetList.GetItemById(Convert.ToInt32(itemId));
                                    newItem[newTargetList.Fields.GetFieldByInternalName("CommentCount").Id] = commentCount;
                                    SetSocialEngineTransaction(newItem);
                                    newItem.SystemUpdate();
                                }
                            }
                        });

                    }
                    catch (Exception e)
                    { }
                }
                else
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        using (SPSite site = new SPSite(currentSite.Url))
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

        private static void SetSocialEngineTransaction(SPListItem item)
        {
            try
            {
                SocialEngineProxy.SetTransaction(item.Web.ID, item.ParentList.ID, item.ID, "Comments", item.Web);
            }
            catch { }
        }

        private static bool SendEmailNotification(int userID, string listId, string itemId, string newComment, string emailType)
        {
            bool mailSent = false;
            SPSite cSite = SPContext.Current.Site;
            SPWeb cWeb = SPContext.Current.Web;

            // get target user email
            SPUser targetUser = cWeb.AllUsers.GetByID(userID);

            SPList originList = cWeb.Lists[new Guid(listId)];
            SPListItem originItem = originList.GetItemById(int.Parse(itemId));
            string itemTitle = (originItem[originList.Fields.GetFieldByInternalName("Title").Id] != null) ?
                originItem[originList.Fields.GetFieldByInternalName("Title").Id].ToString() : string.Empty;

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
                Hashtable hshProps = BuildBody(cWeb.CurrentUser.Name, listId, itemId, newComment);

                SPList list = cWeb.Lists[new Guid(listId)];
                SPListItem li = list.GetItemById(int.Parse(itemId));

                APIEmail.QueueItemMessage(3, false, hshProps, new string[] { targetUser.ID.ToString() }, null, false, true, li, cWeb.CurrentUser, true);
            }
            catch (Exception e)
            {
                mailSent = false;
            }

            return mailSent;
        }

        public static Hashtable BuildBody(string userName, string listID, string itemID, string comment)
        {
            string body = string.Empty;
            SPWeb cWeb = SPContext.Current.Web;

            //0 - name of person who made comment
            //1 - created vs edited
            //2 - link to item being commented on
            //3 - title of the item that's being commented on
            //4 - workspace url
            //5 - workspace title
            //6 - actual comment
            //7 - link to comments page
            string name = userName;
            string itemLink = string.Empty;
            string itemTitle = string.Empty;
            string workspaceUrl = cWeb.Url;
            string workspaceTitle = cWeb.Title;
            string actualComment = comment;
            string commentsPageUrl = string.Empty;
            string listLink = string.Empty;
            string listTitle = string.Empty;

            SPList originList = cWeb.Lists[new Guid(listID)];
            SPListItem originListItem = originList.GetItemById(int.Parse(itemID));
            itemLink = SPContext.Current.Site.MakeFullUrl(originList.Forms[PAGETYPE.PAGE_DISPLAYFORM].ServerRelativeUrl) + "?ID=" + originListItem.ID;
            itemTitle = originListItem[originList.Fields.GetFieldByInternalName("Title").Id].ToString();
            listLink = SPContext.Current.Site.MakeFullUrl(originList.DefaultViewUrl);
            listTitle = originList.Title;
            commentsPageUrl = cWeb.Url + "/_layouts/epmlive/comments.aspx?listid=" + new Guid(listID).ToString("D") + "&itemid=" + itemID;

            Hashtable hshProps = new Hashtable();
            hshProps.Add("ItemLink", itemLink);
            hshProps.Add("ItemName", itemTitle);
            hshProps.Add("ListLink", listLink);
            hshProps.Add("ListName", listTitle);
            hshProps.Add("Comment", actualComment);
            hshProps.Add("CommentsPageUrl", commentsPageUrl);

            return hshProps;
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
                string[] vals = rawUserValues.Split(new string[] { ";#" }, StringSplitOptions.None);
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

        // Data should look like the following:
        // ===============================
        // <Data>
        // <Param key="ItemIds"><listid>.<itemid>,<listid>.<itemid></Param>
        // <Parem key="Created"></Parem>
        // </Data>
        public static string GetMyCommentsByDate(string data)
        {
            var returnValue = string.Empty;
            var result = new StringBuilder();
            var web = SPContext.Current.Web;
            var aggregatedCommentItems = new List<string[]>();
            var loadedItems = new List<string>();
            var dataMgr = new XMLDataManager(data);

            PopulateAggregatedComments(dataMgr.GetPropVal("ItemIds"), aggregatedCommentItems);

            var commentsList = web.Lists.TryGetList(COMMENTS_LIST_NAME);
            if (commentsList != null)
            {
                var comments = commentsList.Items;
                var allCommentsCol = new List<SPListItem>();
                GetCommentsCreatedByCurrentUser(web, commentsList, aggregatedCommentItems, loadedItems, comments, allCommentsCol);

                // sort aggregatedcommentitems by created date again
                aggregatedCommentItems.Clear();
                allCommentsCol = allCommentsCol.OrderByDescending(x => (DateTime)x["Created"]).ToList();
                AddToAggregatedComments(allCommentsCol, aggregatedCommentItems);

                // Construct response XML
                // =====================================
                result.Append(XML_RESPONSE_COMMENT_HEADER);
                var loadedIds = new StringBuilder();

                // get item ids that's been loaded before
                var loadedItemIds = dataMgr.GetPropVal("LoadedItemIds");
                AddIdsToLoadedItems(loadedItemIds, loadedItems);

                var numThreads = int.Parse(dataMgr.GetPropVal("NumThreads"));
                ProcessComments(aggregatedCommentItems, loadedItems, numThreads, web, comments, loadedIds, result);

                result.Append(XML_RESPONSE_COMMENT_LOADEDIDS.Replace("##loadedids##", loadedIds.ToString().Trim(',')))
                    .Append(XML_RESPONSE_COMMENT_FOOTER);
                returnValue = result.ToString();
            }
            return returnValue;
        }

        private static void PopulateAggregatedComments(string itemIds, List<string[]> aggregatedCommentItems)
        {
            if (!string.IsNullOrWhiteSpace(itemIds))
            {
                var pairs = itemIds.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var pair in pairs)
                {
                    var vals = pair.Split('.');
                    var list = new Guid(vals[0]).ToString();
                    var item = vals[1];
                    if (!ContainsItem(aggregatedCommentItems, new[] { list, item }))
                    {
                        aggregatedCommentItems.Add(new[] { list, item });
                    }
                }
            }
        }

        private static void GetCommentsCreatedByCurrentUser(
            SPWeb web,
            SPList commentsList,
            List<string[]> aggregatedCommentItems,
            List<string> loadedItems,
            SPListItemCollection comments,
            List<SPListItem> allCommentsCol)
        {
            
            var publicCommentsList = web.Lists.TryGetList("PublicComments");
            SPQuery q = new SPQuery()
            {
                Query = $"<Where><Or><Eq><FieldRef Name=\"Author\" LookupId=\"true\" /><Value Type=\"User\">{web.CurrentUser.ID}</Value></Eq>" +
                    $"<Eq><FieldRef Name=\"ListId\" /><Value Type=\"Text\">{publicCommentsList.ID}</Value></Eq></Or></Where><OrderBy><FieldRef Name=\"Created\" Ascending=\"False\" /></OrderBy>"
            };

            AddToAggregatedComments(commentsList.GetItems(q), aggregatedCommentItems);

            foreach (var pair in aggregatedCommentItems)
            {
                if (loadedItems.Count > 0 && loadedItems.Contains($"{pair[0]}^{pair[1]}"))
                {
                    continue;
                }
                else
                {
                    var commentsCol = (from SPListItem i in comments
                                       where new Guid(pair[0]).ToString().Equals(new Guid((string)(i["ListId"] ?? string.Empty)).ToString())
                                       && pair[1].Equals((string)(i["ItemId"] ?? string.Empty))
                                       select i
                                       ).ToList();
                    allCommentsCol.AddRange(commentsCol);
                }
            }
        }

        private static void AddToAggregatedComments(IEnumerable items, List<string[]> aggregatedCommentItems)
        {
            foreach (SPListItem item in items)
            {
                var listId = (string)(item["ListId"] ?? string.Empty);
                var itemId = (string)(item["ItemId"] ?? string.Empty);
                var list = new Guid(listId).ToString();

                if (!ContainsItem(aggregatedCommentItems, new[] { list, itemId }))
                {
                    aggregatedCommentItems.Add(new[] { list, itemId });
                }
            }
        }

        private static void AddIdsToLoadedItems(string loadedItemIds, List<string> loadedItems)
        {
            if (!string.IsNullOrWhiteSpace(loadedItemIds))
            {
                var rawIds = loadedItemIds.Split(',');
                foreach (var id in rawIds)
                {
                    if (!string.IsNullOrWhiteSpace(id) && !loadedItems.Contains(id))
                    {
                        loadedItems.Add(id);
                    }
                }
            }
        }

        private static void ProcessComments(
            List<string[]> aggregatedCommentItems,
            List<string> loadedItems,
            int numThreads,
            SPWeb web,
            SPListItemCollection comments,
            StringBuilder loadedIds,
            StringBuilder result)
        {
            var totalThreads = 0;
            foreach (var pair in aggregatedCommentItems)
            {
                var pairedItems = $"{pair[0]}^{pair[1]}";
                if (loadedItems.Count > 0 && loadedItems.Contains(pairedItems))
                {
                    continue;
                }
                else if (!(totalThreads < numThreads))
                {
                    // return the top x number of threads
                    break;
                }

                var listId = new Guid(pair[0]);
                var itemId = int.Parse(pair[1]);
                AppendCommentSectionHeader(listId.ToString(), pair[1], result);

                var realItem = GetRealItem(web, listId, itemId);
                var commentsDesc = GetMatchingComments(comments, listId.ToString(), pair[1]);
                if (realItem != null && commentsDesc.Count > 0)
                {
                    var originalComment = commentsDesc.OrderBy(x => (DateTime)x["Created"]).FirstOrDefault();
                    DisplayOriginalComment(commentsDesc, originalComment, realItem, web, result);

                    var userObject = GetUserObject(originalComment);
                    if (userObject == null)
                    {
                        continue;
                    }

                    const string pictureUrl = "/_layouts/epmlive/images/O14_person_placeHolder_32.png";
                    var userItem = SPContext.Current.Web.SiteUserInfoList.GetItemById(userObject.ID);
                    var userPictureUrl = $"{SPContext.Current.Site.MakeFullUrl(SPContext.Current.Web.ServerRelativeUrl)}{pictureUrl}";

                    AppendUserDetails(result, userObject, userPictureUrl);
                    AppendCommenters(commentsDesc, originalComment, userItem, realItem, web, pictureUrl, result);

                }
                result.Append(XML_RESPONSE_COMMENT_SECTION_FOOTER);
                totalThreads++;
                loadedIds.Append(pairedItems)
                    .Append(',');

                if (loadedItems.Count > 0 && !loadedItems.Contains(pairedItems))
                {
                    break;
                }
            }
        }

        private static void AppendCommentSectionHeader(string listId, string itemId, StringBuilder result)
        {
            result.Append(XML_RESPONSE_COMMENT_SECTION_HEADER
                .Replace("##listId##", listId)
                .Replace("##itemId##", itemId)
            );
        }

        private static SPListItem GetRealItem(SPWeb web, Guid listId, int itemId)
        {
            try
            {
                return web.Lists[listId].GetItemById(itemId);
            }
            catch (Exception e)
            {
                Trace.TraceWarning("Could not retrieve value: {0}", e);
                return null;
            }
        }

        private static List<SPListItem> GetMatchingComments(SPListItemCollection comments, string listId, string itemId)
        {
            try
            {
                return (from SPListItem i in comments
                        where listId.Equals(new Guid((string)(i["ListId"] ?? string.Empty)).ToString()) &&
                        itemId.Equals((string)(i["ItemId"] ?? string.Empty))
                        orderby (DateTime)i["Created"] ascending
                        select i
                        ).ToList();
            }
            catch (Exception e)
            {
                Trace.TraceWarning("Unable to read comments: {0}", e);
                return new List<SPListItem>();
            }
        }

        private static string GetOriginComment(SPListItem originalComment)
        {
            try
            {
                return originalComment["Comment"].ToString();
            }
            catch (Exception e)
            {
                Trace.TraceWarning("Unable to read comment: {0}", e);
                return string.Empty;
            }
        }

        private static void DisplayOriginalComment(List<SPListItem> commentsDesc, SPListItem originalComment, SPListItem realItem, SPWeb web, StringBuilder result)
        {
            var listId = (string)(originalComment["ListId"] ?? string.Empty);
            var itemId = (string)(originalComment["ItemId"] ?? string.Empty);
            var created = (DateTime)originalComment["Created"];
            var originComment = GetOriginComment(originalComment);

            result.Append(XML_RESPONSE_COMMENT_ITEM
                .Replace("##listId##", new Guid(listId).ToString())
                .Replace("##listName##", realItem.ParentList.Title)
                .Replace("##listDispUrl##", realItem.ParentList.DefaultDisplayFormUrl)
                .Replace("##listUrl##", realItem.ParentList.DefaultViewUrl)
                .Replace("##itemId##", itemId.ToString())
                .Replace("##itemTitle##", realItem.Title.Replace('\"', '\''))
                .Replace("##createdDate##", created.ToFriendlyDateAndTime(web))
                .Replace("##comment##", GetXMLSafeVersion(HttpUtility.HtmlDecode(originComment ?? string.Empty)))
            );
        }

        private static SPUser GetUserObject(SPListItem comment)
        {
            var author = (SPFieldUser)comment.Fields[SPBuiltInFieldId.Author];
            var user = (SPFieldUserValue)author.GetFieldValue(comment[SPBuiltInFieldId.Author].ToString());
            return user.User;
        }

        private static void AppendUserDetails(StringBuilder result, SPUser user, string userPictureUrl)
        {
            result.Append(XML_USER_INFO_SECTION
                .Replace("##username##", user.Name)
                .Replace("##useremail##", user.Email)
                .Replace("##userprofile##", _userProfileUrl.Replace("##userid##", user.ID.ToString()))
                .Replace("##userpic##", userPictureUrl));
            result.Append(XML_RESPONSE_COMMENT_ITEM_CLOSE);
        }

        private static void AppendCommenters(
            List<SPListItem> commentsDesc,
            SPListItem originalComment,
            SPListItem userItem,
            SPListItem realItem,
            SPWeb web,
            string pictureUrl,
            StringBuilder result)
        {
            for (var i = 0; i < commentsDesc.Count; i++)
            {
                var comment = commentsDesc[i];
                if (comment.ID != originalComment.ID)
                {
                    var userObject = GetUserObject(comment);

                    if (userObject == null)
                    {
                        continue;
                    }
                    AppendCommenterDetails(comment, userItem, realItem, userObject, web, pictureUrl, result);
                }
            }
        }

        private static void AppendCommenterDetails(
            SPListItem comment,
            SPListItem userItem,
            SPListItem realItem,
            SPUser userObject,
            SPWeb web,
            string pictureUrl,
            StringBuilder result)
        {
            var listId = (string)(comment["ListId"] ?? string.Empty);
            var itemId = (string)(comment["ItemId"] ?? string.Empty);
            var created = (DateTime)comment["Created"];
            var userPictureUrl = GetUserPicture(userItem, pictureUrl);

            // 1. display first item ordered by asending date
            // 2. display rest ordered by desending date
            // 3. do not repeat items 
            var originComment = string.Empty;
            try
            {
                originComment = comment["Comment"].ToString();
            }
            catch (Exception e)
            {
                Trace.TraceWarning("Could not retrieve Comment: {0}", e);
            }

            result.Append(XML_RESPONSE_COMMENT_ITEM
                .Replace("##listId##", new Guid(listId).ToString())
                .Replace("##listName##", realItem.ParentList.Title)
                .Replace("##listDispUrl##", realItem.ParentList.DefaultDisplayFormUrl)
                .Replace("##listUrl##", realItem.ParentList.DefaultViewUrl)
                .Replace("##itemId##", itemId.ToString())
                .Replace("##itemTitle##", realItem.Title.Replace('\"', '\''))
                .Replace("##createdDate##", created.ToFriendlyDateAndTime(web))
                .Replace("##comment##", GetXMLSafeVersion(HttpUtility.HtmlDecode(originComment ?? string.Empty))));

            result.Append(XML_USER_INFO_SECTION
                .Replace("##username##", userObject.Name)
                .Replace("##useremail##", userObject.Email)
                .Replace("##userprofile##", _userProfileUrl.Replace("##userid##", userObject.ID.ToString()))
                .Replace("##userpic##", userPictureUrl));

            result.Append(XML_RESPONSE_COMMENT_ITEM_CLOSE);
        }

        private static string GetUserPicture(SPListItem userItem, string pictureUrl)
        {
            SPField pictureField;
            if (TryGetPictureField(userItem, out pictureField))
            {
                try
                {
                    var picUrls = userItem[pictureField.Id].ToString().Split(',');
                    return picUrls[0];
                }
                catch (Exception e)
                {
                    Trace.TraceWarning("Could not get user picture: {0}", e);
                }
            }
            return $"{SPContext.Current.Site.MakeFullUrl(SPContext.Current.Web.ServerRelativeUrl)}{pictureUrl}";
        }

        private static bool TryGetPictureField(SPListItem item, out SPField pictureField)
        {
            try
            {
                pictureField = item.Fields.GetFieldByInternalName("Picture");
                return true;
            }
            catch (ArgumentException e)
            {
                Trace.TraceWarning("Could not get Picture field: {0}", e);
                pictureField = null;
                return false;
            }
        }

        private static bool ContainsItem(List<string[]> items, string[] item)
        {
            bool result = false;
            foreach (string[] pair in items)
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

        private static bool AlreadyDisplayed(List<string[]> items, string[] item)
        {
            bool result = false;
            foreach (string[] pair in items)
            {
                if (pair[0].Equals(item[0]) && pair[1].Equals(item[1]))
                {
                    result = true;
                    break;
                }
            }

            return result;
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
    }
}
