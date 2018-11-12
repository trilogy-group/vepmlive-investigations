using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Web;
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
        public static string CreatePublicComment(string data)
        {
            var returnValue = string.Empty;
            var web = SPContext.Current.Web;
            var dataMgr = new XMLDataManager(data);

            EnsurePublicCommentsListExist();

            var publicCommentsList = web.Lists.TryGetList("PublicComments");
            var commentsList = web.Lists.TryGetList(COMMENTS_LIST_NAME);
            var listId = dataMgr.GetPropVal("ListId");
            var itemId = dataMgr.GetPropVal("ItemId");
            dataMgr.EditProp("ListId", publicCommentsList.ID.ToString());

            UpdateIfNewItem(itemId, publicCommentsList, dataMgr);

            var result = new StringBuilder();
            result.Append(XML_RESPONSE_COMMENT_HEADER);

            if (publicCommentsList != null && commentsList != null)
            {
                web.AllowUnsafeUpdates = true;
                var currentItem = commentsList.Items.Add();
                var genericTitle = $"{web.CurrentUser.Name} made a new comment at {DateTime.Now}";
                var comment = dataMgr.GetPropVal("Comment");

                UpdateCurrentItem(currentItem, commentsList, genericTitle, listId, itemId, comment);
                AppendCurrentItem(result, currentItem, listId, itemId, comment);

                // save current user
                SPUser originalUser = SPContext.Current.Web.CurrentUser;
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                    {
                        using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ServerRelativeUrl))
                        {
                            ew.AllowUnsafeUpdates = true;
                            var laCommenters = new List<int>();
                            var originList = ew.Lists[new Guid(dataMgr.GetPropVal("ListId"))];
                            var originListItem = originList?.GetItemById(int.Parse(dataMgr.GetPropVal("ItemId")));
                            SendEmails(originListItem, originList, laCommenters, originalUser, listId, itemId, comment);

                            var createdDate = currentItem["Created"].ToString();
                            returnValue = result.ToString();
                            InsertCommentCount(dataMgr.GetPropVal("ListId"), dataMgr.GetPropVal("ItemId"));
                        }
                    }
                });
                SyncWithSocialStream(currentItem, comment);
            }
            else
            {
                throw new Exception("Both 'PublicComments' list and 'Comments' list needs to be created to support this functionality.");
            }
            return returnValue;
        }

        private static void EnsurePublicCommentsListExist()
        {
            var web = SPContext.Current.Web;
            var lstPubComments = web.Lists.TryGetList("PublicComments");

            if (lstPubComments == null)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (var eleSite = new SPSite(web.Url))
                    {
                        using (var eleWeb = eleSite.OpenWeb())
                        {
                            eleWeb.AllowUnsafeUpdates = true;
                            var guid = eleWeb.Lists.Add("PublicComments", "", SPListTemplateType.GenericList);
                            lstPubComments = eleWeb.Lists[guid];
                            lstPubComments.Hidden = true;
                            lstPubComments.Update();

                            var fldCommentersName = lstPubComments.Fields.Add("Commenters", SPFieldType.Note, false);
                            var fldCommenters = lstPubComments.Fields.GetFieldByInternalName(fldCommentersName) as SPFieldMultiLineText;
                            fldCommenters.Sealed = false;
                            fldCommenters.Hidden = true;
                            fldCommenters.AllowDeletion = false;
                            fldCommenters.DefaultValue = string.Empty;
                            fldCommenters.Update();

                            var fldCommentersReadName = lstPubComments.Fields.Add("CommentersRead", SPFieldType.Note, false);
                            var fldCommentersRead = lstPubComments.Fields.GetFieldByInternalName(fldCommentersReadName) as SPFieldMultiLineText;
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

        private static void UpdateIfNewItem(string itemId, SPList publicCommentsList, XMLDataManager dataMgr)
        {
            if (string.IsNullOrWhiteSpace(itemId))
            {
                SPContext.Current.Web.AllowUnsafeUpdates = true;
                var newItem = publicCommentsList.Items.Add();
                SetSocialEngineTransaction(newItem);
                newItem.Update();
                dataMgr.EditProp("ItemId", newItem.ID.ToString());
            }
        }

        private static void AppendCurrentItem(StringBuilder result, SPListItem currentItem, string listId, string itemId, string comment)
        {
            result.Append(XML_RESPONSE_PUBLIC_COMMENT_ITEM
                .Replace("##pubComListId##", listId)
                .Replace("##pubComItemId##", itemId));
            result.Append(XML_RESPONSE_COMMENT_SECTION_HEADER
                .Replace("##listId##", currentItem.ParentList.ID.ToString())
                .Replace("##itemId##", currentItem.ID.ToString()));
            result.Append(XML_RESPONSE_COMMENT_ITEM
                .Replace("##listId##", currentItem.ParentList.ID.ToString())
                .Replace("##listName##", currentItem.ParentList.Title)
                .Replace("##itemId##", currentItem.ID.ToString())
                .Replace("##itemTitle##", currentItem.Title)
                .Replace("##createdDate##", ((DateTime)currentItem["Created"]).ToFriendlyDateAndTime(SPContext.Current.Web))
                .Replace("##comment##", GetXMLSafeVersion(HttpUtility.HtmlDecode(comment ?? string.Empty))));
            result.Append(XML_RESPONSE_COMMENT_ITEM_CLOSE)
                .Append(XML_RESPONSE_COMMENT_SECTION_FOOTER)
                .Append(XML_RESPONSE_COMMENT_FOOTER);
        }

        private static void SendEmails(SPListItem originListItem, SPList originList, List<int> laCommenters, SPUser originalUser, string listId, string itemId, string comment)
        {
            const string created = "created";
            if (originListItem != null)
            {
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
                            SendEmailNotification(id, listId, itemId, comment, created);
                        }
                    }
                }
                catch (Exception e)
                {
                    Trace.TraceWarning("Unable to send email: {0}", e);
                }

                // send email to each person in thread
                foreach (var id in laCommenters)
                {
                    if (id != originalUser.ID && !emailSentIDs.Contains(id))
                    {
                        emailSentIDs.Add(id);
                        SendEmailNotification(id, listId, itemId, comment, created);
                    }
                }
            }
        }

        private static void SyncWithSocialStream(SPListItem currentItem, string comment)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(comment))
                {
                    comment = comment.Trim();

                    SyncStatusUpdateToSocialStream(currentItem.UniqueId, comment, new Guid(currentItem["ListId"].ToString()),
                        int.Parse(currentItem["ItemId"].ToString()), (DateTime)currentItem["Created"], SPContext.Current.Web, "ADD");
                }
            }
            catch (Exception e)
            {
                Trace.TraceWarning("Unable to sync with social stream: {0}", e);
            }
        }
    }
}
