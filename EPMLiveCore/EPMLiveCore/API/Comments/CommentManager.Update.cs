using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    internal partial class CommentManager
    {
        // Data should look like the following:
        // ===============================
        // <Data>
        // <Param key='ListId'>someguid</Param>
        // <Param key='ItemId">12</Param>
        // <Param key='Comment'>abcabac</Param>
        // </Data>
        public static string UpdateComment(string data)
        {
            var returnValue = string.Empty;
            var web = SPContext.Current.Web;
            var site = SPContext.Current.Site;
            var originalUser = SPContext.Current.Web.CurrentUser;
            var dataMgr = new XMLDataManager(data);
            var commentsList = web.Lists.TryGetList(COMMENTS_LIST_NAME);

            if (commentsList != null)
            {
                var listId = dataMgr.GetPropVal("ListId");
                var itemId = dataMgr.GetPropVal("ItemId");
                var commentItemId = Convert.ToInt32(dataMgr.GetPropVal("CommentItemId"));
                var comment = HttpUtility.HtmlDecode(dataMgr.GetPropVal("Comment"));
                var laCommenters = new List<int>();
                var time = GetCurrentLocalTime();
                SPListItem originListItem = null;
                SPListItem targetComment = null;

                var query = new SPQuery();
                query.Query = $"<Where><And><Eq><FieldRef Name=\"ListId\" /><Value Type=\"Text\">{listId}</Value></Eq><Eq><FieldRef Name=\"ItemId\" /><Value Type=\"Text\">{itemId}</Value></Eq></And></Where>";
                var items = commentsList.GetItems(query);

                if (items.Count > 0)
                {
                    UpdateTargetComment(items, commentItemId, ref targetComment, web, commentsList, time, comment);

                    web.AllowUnsafeUpdates = true;
                    var originList = web.Lists[new Guid(listId)];
                    originListItem = originList?.GetItemById(int.Parse(itemId));

                    if (originListItem != null)
                    {
                        GetCommentersAndSendEmails(originListItem, originList, laCommenters, listId, itemId, comment);
                        UpdateSocialEngineTransaction(site, web, originList, originListItem, originalUser);

                    }
                }
                else
                {
                    throw new Exception(String.Format("No comment with ListId = {0} and ItemId = {1} exists.", listId, itemId));
                }

                InsertCommentCount(listId, itemId);

                returnValue = "success";
                if (string.IsNullOrWhiteSpace(comment) || originListItem == null)
                {
                    return returnValue;
                }

                SyncWithSocialStream(targetComment, comment, originListItem, laCommenters, time, web);
            }
            else
            {
                throw new Exception("The 'Comments' list needs to be created to support this functionality.");
            }

            return returnValue;
        }

        private static void UpdateTargetComment(
            SPListItemCollection items,
            int commentItemId,
            ref SPListItem targetComment,
            SPWeb web,
            SPList commentsList,
            DateTime time,
            string comment)
        {
            foreach (SPListItem item in items)
            {
                if (item.ID.Equals(commentItemId))
                {
                    web.AllowUnsafeUpdates = true;
                    targetComment = item;
                    var genericTitle = $"{web.CurrentUser.Name} updated this comment at {time.ToString()}";
                    targetComment[commentsList.Fields.GetFieldByInternalName("Title").Id] = genericTitle;
                    targetComment[commentsList.Fields.GetFieldByInternalName("Comment").Id] = comment;
                    SetSocialEngineTransaction(targetComment);
                    targetComment.Update();

                    break;
                }
            }
        }

        private static void GetCommentersAndSendEmails(
            SPListItem originListItem,
            SPList originList,
            List<int> laCommenters,
            string listId,
            string itemId,
            string comment)
        {
            var commenters = originListItem[originList.Fields.GetFieldByInternalName("Commenters").Id] != null
                ? originListItem[originList.Fields.GetFieldByInternalName("Commenters").Id].ToString()
                : string.Empty;
            foreach (var commenter in commenters.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (!string.IsNullOrWhiteSpace(commenter.Trim()))
                {
                    laCommenters.Add(int.Parse(commenter));
                }
            }

            // get user object 
            var author = (SPFieldUser)originListItem.Fields[SPBuiltInFieldId.Author];
            var userVal = (SPFieldUserValue)author.GetFieldValue(originListItem[SPBuiltInFieldId.Author].ToString());
            var authorObj = userVal.User;
            var emailSentIDs = new List<int>();

            // send email to author
            if ((authorObj != null) && (SPContext.Current.Web.CurrentUser.ID != authorObj.ID) && !emailSentIDs.Contains(authorObj.ID))
            {
                emailSentIDs.Add(authorObj.ID);
                SendEmailNotification(authorObj.ID, listId, itemId, comment, "edited");
            }

            // send emails out to people in assignedto field if that field exists
            try
            {
                var vals = originListItem[originListItem.Fields.GetFieldByInternalName("AssignedTo").Id].ToString().Split(new string[] { ";#" }, StringSplitOptions.None);
                foreach (var val in vals)
                {
                    int id;
                    if (int.TryParse(val, out id) && !id.Equals(SPContext.Current.Web.CurrentUser.ID) && !emailSentIDs.Contains(id))
                    {
                        emailSentIDs.Add(id);
                        SendEmailNotification(id, listId, itemId, comment, "created");
                    }
                }
            }
            catch (Exception e)
            {
                Trace.TraceWarning("Unable to send emails: {0}", e);
            }

            // send email to commenters
            foreach (var id in laCommenters)
            {
                if ((id != SPContext.Current.Web.CurrentUser.ID) && !emailSentIDs.Contains(id))
                {
                    emailSentIDs.Add(id);
                    SendEmailNotification(id, listId, itemId, comment, "edited");
                }
            }
        }

        private static void UpdateSocialEngineTransaction(
            SPSite site,
            SPWeb web,
            SPList originList,
            SPListItem originListItem,
            SPUser originalUser)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (var currentSite = new SPSite(site.ID))
                {
                    using (var currentWeb = currentSite.OpenWeb(web.ServerRelativeUrl))
                    {
                        currentWeb.AllowUnsafeUpdates = true;
                        var tempList = currentWeb.Lists[originList.ID];
                        var tempItem = tempList.GetItemById(originListItem.ID);
                        tempItem[tempList.Fields.GetFieldByInternalName("CommentersRead").Id] = string.Empty;
                        tempItem[tempList.Fields.GetFieldByInternalName("CommentersRead").Id] = originalUser.ID.ToString();
                        SetSocialEngineTransaction(tempItem);
                        tempItem.SystemUpdate();
                    }
                }
            });
        }

        private static void SyncWithSocialStream(
            SPListItem targetComment,
            string comment,
            SPListItem originListItem,
            List<int> laCommenters,
            DateTime time,
            SPWeb web)
        {
            try
            {
                SyncToSocialStream(
                    targetComment.UniqueId,
                    comment,
                    originListItem.ParentList.ID,
                    originListItem.ID,
                    originListItem.Title,
                    originListItem.ParentList.Title,
                    $"{originListItem.ParentList.DefaultDisplayFormUrl}?ID={originListItem.ID}",
                    laCommenters,
                    time,
                    web,
                    "UPDATE"
                );
            }
            catch (Exception e)
            {
                Trace.TraceWarning("Could not sync with social stream: {0}", e);
            }
        }
    }
}
