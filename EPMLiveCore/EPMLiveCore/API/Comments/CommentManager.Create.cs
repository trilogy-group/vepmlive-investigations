using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using EPMLiveCore.SocialEngine.Core;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    internal partial class CommentManager
    {
        // Data should look like the following:
        // ===============================
        // <Data>
        // <Param key="ListId">someguid</Param>
        // <Param key="ItemId">12</Param>
        // <Param key="Comment">abcabac</Param>
        // </Data>
        public static string CreateComment(string data)
        {
            var returnValue = string.Empty;
            var web = SPContext.Current.Web;
            var site = SPContext.Current.Site;
            var dataMgr = new XMLDataManager(data);
            var commentsList = web.Lists.TryGetList(COMMENTS_LIST_NAME);

            var result = new StringBuilder();
            result.Append(XML_RESPONSE_COMMENT_HEADER);

            if (commentsList != null)
            {
                web.AllowUnsafeUpdates = true;
                var currentItem = commentsList.Items.Add();
                var time = GetCurrentLocalTime();
                bool statusUpdate;
                bool.TryParse(dataMgr.GetPropVal("StatusUpdate"), out statusUpdate);
                var statusUpdateId = dataMgr.GetPropVal("StatusUpdateId");
                var genericTitle = $"{web.CurrentUser.Name} made a new comment at {time.ToString()}";
                var listId = dataMgr.GetPropVal("ListId");
                var itemId = dataMgr.GetPropVal("ItemId");
                var comment = HttpUtility.HtmlDecode(dataMgr.GetPropVal("Comment") ?? string.Empty);
                var laCommenters = new List<int>();
                SPListItem originListItem = null;

                UpdateCurrentItem(currentItem, commentsList, genericTitle, listId, itemId, comment);
                AppendResponseComment(result, currentItem, comment, web);

                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (var currentSite = new SPSite(SPContext.Current.Site.ID))
                    {
                        using (var currentWeb = currentSite.OpenWeb(SPContext.Current.Web.ServerRelativeUrl))
                        {
                            currentWeb.AllowUnsafeUpdates = true;
                            var originList = currentWeb.Lists[new Guid(listId)];
                            originListItem = originList?.GetItemById(int.Parse(itemId));

                            if (originListItem != null)
                            {
                                SendNotificationEmails(originList, originListItem, laCommenters, listId, itemId, comment);
                            }

                            var createdDate = currentItem["Created"].ToString();
                            returnValue = result.ToString();
                            InsertCommentCount(listId, itemId);
                        }
                    }
                });

                SyncWithSocialStream(comment, originListItem, statusUpdate, currentItem, laCommenters, time, web, statusUpdateId);
            }
            else
            {
                throw new Exception("The 'Comments' list needs to be created to support this functionality.");
            }
            return returnValue;
        }

        private static void UpdateCurrentItem(
            SPListItem currentItem,
            SPList commentsList,
            string genericTitle,
            string listId,
            string itemId,
            string comment)
        {
            currentItem[commentsList.Fields.GetFieldByInternalName("Title").Id] = genericTitle;
            currentItem[commentsList.Fields.GetFieldByInternalName("ListId").Id] = listId;
            currentItem[commentsList.Fields.GetFieldByInternalName("ItemId").Id] = itemId;
            currentItem[commentsList.Fields.GetFieldByInternalName("Comment").Id] = comment;

            SetSocialEngineTransaction(currentItem);
            currentItem.Update();
        }

        private static void AppendResponseComment(StringBuilder result, SPListItem currentItem, string comment, SPWeb web)
        {
            result.Append(XML_RESPONSE_COMMENT_SECTION_HEADER
                .Replace("##listId##", currentItem.ParentList.ID.ToString())
                .Replace("##itemId##", currentItem.ID.ToString()));
            result.Append(XML_RESPONSE_COMMENT_ITEM
                .Replace("##listId##", currentItem.ParentList.ID.ToString())
                .Replace("##listName##", currentItem.ParentList.Title)
                .Replace("##itemId##", currentItem.ID.ToString())
                .Replace("##itemTitle##", currentItem.Title)
                .Replace("##createdDate##", ((DateTime)currentItem["Created"]).ToFriendlyDateAndTime(web))
                .Replace("##comment##", GetXMLSafeVersion(comment)));
            result.Append(XML_RESPONSE_COMMENT_ITEM_CLOSE)
                .Append(XML_RESPONSE_COMMENT_SECTION_FOOTER)
                .Append(XML_RESPONSE_COMMENT_FOOTER);
        }

        private static void SendNotificationEmails(
            SPList originList,
            SPListItem originListItem,
            List<int> laCommenters,
            string listId,
            string itemId,
            string comment)
        {
            var originalUser = SPContext.Current.Web.CurrentUser;

            EnsureMetaCols(originList);

            var emailSentIDs = GenerateEmailSentIds(originListItem, originList, laCommenters, originalUser, listId, itemId, comment);

            // send email to assigned to people
            try
            {
                var vals = originListItem[originListItem.Fields.GetFieldByInternalName("AssignedTo").Id].ToString().Split(new string[] { ";#" }, StringSplitOptions.None);
                foreach (var val in vals)
                {
                    int id;
                    if (int.TryParse(val, out id) && !id.Equals(originalUser.ID) && !emailSentIDs.Contains(id))
                    {
                        emailSentIDs.Add(id);
                        SendEmailNotification(id, listId, itemId, comment, "created");
                    }
                }
            }
            catch (Exception e)
            {
                Trace.TraceWarning("Unable to sent email notifications: {0}", e);
            }

            // send email to each person in thread
            foreach (var id in laCommenters)
            {
                if ((id != originalUser.ID) && !emailSentIDs.Contains(id))
                {
                    emailSentIDs.Add(id);
                    SendEmailNotification(id, listId, itemId, comment, "created");
                }
            }
        }

        private static void SyncWithSocialStream(
            string comment,
            SPListItem originListItem,
            bool isStatusUpdate,
            SPListItem currentItem,
            List<int> laCommenters,
            DateTime time,
            SPWeb web,
            string statusUpdateId)
        {
            if (!string.IsNullOrWhiteSpace(comment) && originListItem != null)
            {
                try
                {
                    if (!isStatusUpdate)
                    {
                        SyncToSocialStream(
                            currentItem.UniqueId,
                            comment,
                            originListItem.ParentList.ID,
                            originListItem.ID,
                            originListItem.Title,
                            originListItem.ParentList.Title,
                            $"{originListItem.ParentList.DefaultDisplayFormUrl}?ID={originListItem.ID}",
                            laCommenters,
                            time,
                            web,
                            "ADD"
                        );
                    }
                    else
                    {
                        var sId = new Guid(statusUpdateId);

                        var statusItem = currentItem.ParentList.GetItemByUniqueId(sId);

                        SyncStatusUpdateToSocialStream(
                            sId,
                            comment,
                            new Guid(currentItem["ListId"].ToString()),
                            int.Parse(currentItem["ItemId"].ToString()),
                            (DateTime)statusItem["Created"],
                            web,
                            "COMMENT",
                            (DateTime?)currentItem["Created"],
                            currentItem.UniqueId
                        );
                    }
                }
                catch (Exception e)
                {
                    Trace.TraceWarning("Unable to sync with social stream: {0}", e);
                }
            }
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
    }
}
