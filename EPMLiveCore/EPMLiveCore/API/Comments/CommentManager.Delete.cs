using System;
using System.Collections.Generic;
using System.Diagnostics;
using EPMLiveCore.SocialEngine.Core;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    internal partial class CommentManager
    {// Data should look like the following:
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
    }
}
