using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Net.Mail;
using EPMLiveCore.Properties;
using System.Collections;
using System.Web;
using Microsoft.SharePoint.Utilities;

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
            XmlDataManager dataMgr = new XmlDataManager(data);
            SPList commentsList = cWeb.Lists.TryGetList(COMMENTS_LIST_NAME);

            StringBuilder sbResult = new StringBuilder();
            sbResult.Append(XML_RESPONSE_COMMENT_HEADER);

            if (commentsList != null)
            {
                cWeb.AllowUnsafeUpdates = true;
                SPListItem currentItem = commentsList.Items.Add();
                string genericTitle = cWeb.CurrentUser.Name + " made a new comment at " + DateTime.Now.ToString();
                currentItem[commentsList.Fields.GetFieldByInternalName("Title").Id] = genericTitle;
                currentItem[commentsList.Fields.GetFieldByInternalName("ListId").Id] = dataMgr.GetPropVal("ListId");
                currentItem[commentsList.Fields.GetFieldByInternalName("ItemId").Id] = dataMgr.GetPropVal("ItemId");
                currentItem[commentsList.Fields.GetFieldByInternalName("Comment").Id] = Uri.UnescapeDataString(dataMgr.GetPropVal("Comment"));
                currentItem.Update();

                sbResult.Append(XML_RESPONSE_COMMENT_SECTION_HEADER.Replace("##listId##", currentItem.ParentList.ID.ToString()).Replace("##itemId##", currentItem.ID.ToString()));
                sbResult.Append(XML_RESPONSE_COMMENT_ITEM.Replace("##listId##", currentItem.ParentList.ID.ToString())
                                                         .Replace("##listName##", currentItem.ParentList.Title)
                                                         .Replace("##itemId##", currentItem.ID.ToString())
                                                         .Replace("##itemTitle##", currentItem.Title)
                                                         .Replace("##createdDate##", ((DateTime)currentItem["Created"]).ToFriendlyDateAndTime())
                                                         .Replace("##comment##", (string)(HttpUtility.HtmlDecode(dataMgr.GetPropVal("Comment")) ?? string.Empty)));
                sbResult.Append(XML_RESPONSE_COMMENT_ITEM_CLOSE);
                sbResult.Append(XML_RESPONSE_COMMENT_SECTION_FOOTER);
                sbResult.Append(XML_RESPONSE_COMMENT_FOOTER);

                SPList originList = null;
                SPListItem originListItem = null;
                List<int> laCommenters = new List<int>();
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

                    // if user is not in commenters, and not creater or one of the assigned to users
                    if (!laCommenters.Contains(SPContext.Current.Web.CurrentUser.ID) &&
                        !SPContext.Current.Web.CurrentUser.ID.Equals(authorObj.ID) &&
                        !UserIsAssigned(SPContext.Current.Web.CurrentUser.ID, originListItem))
                    {
                        laCommenters.Add(SPContext.Current.Web.CurrentUser.ID);
                        StringBuilder sbNewCommenters = new StringBuilder();
                        foreach (int id in laCommenters)
                        {
                            sbNewCommenters.Append(id.ToString() + ",");
                        }

                        sCommenters = sbNewCommenters.ToString();
                        sCommenters = sCommenters.Remove(sCommenters.LastIndexOf(','));

                        originListItem[originList.Fields.GetFieldByInternalName("Commenters").Id] = sCommenters;
                    }

                    // set commentersread to blank
                    originListItem[originList.Fields.GetFieldByInternalName("CommentersRead").Id] = string.Empty;
                    // add current user to list
                    originListItem[originList.Fields.GetFieldByInternalName("CommentersRead").Id] = SPContext.Current.Web.CurrentUser.ID.ToString();
                    originListItem.SystemUpdate();
                    List<int> emailSentIDs = new List<int>();
                    // send email to author
                    if (SPContext.Current.Web.CurrentUser.ID != authorObj.ID)
                    {
                        emailSentIDs.Add(authorObj.ID);
                        SendEmailNotification(authorObj.ID, dataMgr.GetPropVal("ListId"), dataMgr.GetPropVal("ItemId"), dataMgr.GetPropVal("Comment"), "created");
                    }

                    // send email to assigned to people
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

                    // send email to each person in thread
                    foreach (int id in laCommenters)
                    {
                        if ((id != SPContext.Current.Web.CurrentUser.ID) && !emailSentIDs.Contains(id))
                        {
                            emailSentIDs.Add(id);
                            SendEmailNotification(id, dataMgr.GetPropVal("ListId"), dataMgr.GetPropVal("ItemId"), dataMgr.GetPropVal("Comment"), "created");
                        }
                    }
                }

                string createdDate = currentItem["Created"].ToString();
                //retVal = currentItem.ID.ToString() + "," + createdDate;
                retVal = sbResult.ToString();
                InsertCommentCount(dataMgr.GetPropVal("ListId"), dataMgr.GetPropVal("ItemId"));
            }
            else
            {
                throw new Exception("The 'Comments' list needs to be created to support this functionality.");
            }

            return retVal;
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
            XmlDataManager dataMgr = new XmlDataManager(data);
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
            // Data should look like the following:
            // ===============================
            // <Data>
            // <Param key='ListId'>someguid</Param>
            // <Param key='ItemId">12</Param>
            // <Param key='Comment'>abcabac</Param>
            // </Data>

            // load data into XML manager
            XmlDataManager dataMgr = new XmlDataManager(data);
            SPList commentsList = cWeb.Lists.TryGetList(COMMENTS_LIST_NAME);

            if (commentsList != null)
            {
                string listId = dataMgr.GetPropVal("ListId");
                string itemId = dataMgr.GetPropVal("ItemId");
                SPQuery query = new SPQuery();
                query.Query = "<Where><And><Eq><FieldRef Name=\"ListId\" /><Value Type=\"Text\">" + listId + "</Value></Eq><Eq><FieldRef Name=\"ItemId\" /><Value Type=\"Text\">" + itemId + "</Value></Eq></And></Where>";
                SPListItemCollection itemColl = commentsList.GetItems(query);

                if (itemColl.Count > 0)
                {
                    int commentItemId = Convert.ToInt32(dataMgr.GetPropVal("CommentItemId"));

                    foreach (SPListItem item in itemColl)
                    {
                        if (item.ID.Equals(commentItemId))
                        {
                            cWeb.AllowUnsafeUpdates = true;
                            SPListItem targetComment = item;
                            string genericTitle = cWeb.CurrentUser.Name + " updated this comment at " + DateTime.Now.ToString();
                            targetComment[commentsList.Fields.GetFieldByInternalName("Title").Id] = genericTitle;
                            targetComment[commentsList.Fields.GetFieldByInternalName("Comment").Id] = HttpUtility.HtmlDecode(dataMgr.GetPropVal("Comment"));
                            targetComment.Update();

                            break;
                        }
                    }

                    SPList originList = null;
                    SPListItem originListItem = null;
                    List<int> laCommenters = new List<int>();
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
                        if ((SPContext.Current.Web.CurrentUser.ID != authorObj.ID) && !emailSentIDs.Contains(authorObj.ID))
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

                        originListItem[originList.Fields.GetFieldByInternalName("CommentersRead").Id] = string.Empty;
                        originListItem[originList.Fields.GetFieldByInternalName("CommentersRead").Id] = cWeb.CurrentUser.ID.ToString();
                        originListItem.SystemUpdate();

                    }
                }
                else
                {
                    throw new Exception(String.Format("No comment with ListId = {0} and ItemId = {1} exists.", listId, itemId));
                }

                InsertCommentCount(dataMgr.GetPropVal("ListId"), dataMgr.GetPropVal("ItemId"));

                retVal = "success";
            }
            else
            {
                throw new Exception("The 'Comments' list needs to be created to support this functionality.");
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
            XmlDataManager dataMgr = new XmlDataManager(data);
            SPList commentsList = currentWeb.Lists.TryGetList(COMMENTS_LIST_NAME);

            if (commentsList != null)
            {
                string listId = dataMgr.GetPropVal("ListId");
                string itemId = dataMgr.GetPropVal("ItemId");
                SPQuery query = new SPQuery();
                query.Query = "<Where><And><Eq><FieldRef Name=\"ListId\" /><Value Type=\"Text\">" + listId + "</Value></Eq><Eq><FieldRef Name=\"ItemId\" /><Value Type=\"Text\">" + itemId + "</Value></Eq></And></Where>";
                SPListItemCollection itemColl = commentsList.GetItems(query);

                if (itemColl.Count > 0)
                {
                    int commentItemId = Convert.ToInt32(dataMgr.GetPropVal("CommentItemId"));
                    foreach (SPListItem item in itemColl)
                    {
                        if (item.ID.Equals(commentItemId))
                        {
                            currentWeb.AllowUnsafeUpdates = true;
                            item.Delete();
                            break;
                        }
                    }

                }
                else
                {
                    throw new Exception(String.Format("No comment with ListId = {0} and ItemId = {1} exists.", listId, itemId));
                }

                // count comments made by current user, if 0, remove current user from "commenters" field
                query.Query = "<Where><And><Eq><FieldRef Name=\"ListId\" /><Value Type=\"Text\">" + listId + "</Value></Eq><Eq><FieldRef Name=\"ItemId\" /><Value Type=\"Text\">" + itemId + "</Value></Eq></And></Where>";
                SPListItemCollection items = commentsList.GetItems(query);
                bool userHasCommentsLeft = false;
                foreach (SPListItem i in items)
                {
                    // get user object 
                    SPFieldUser author = (SPFieldUser)i.Fields[SPBuiltInFieldId.Author];
                    SPFieldUserValue userVal = (SPFieldUserValue)author.GetFieldValue(i[SPBuiltInFieldId.Author].ToString());
                    SPUser authorObj = userVal.User;

                    if (authorObj.ID == SPContext.Current.Web.CurrentUser.ID)
                    {
                        userHasCommentsLeft = true;
                    }
                }

                if (!userHasCommentsLeft)
                {
                    SPList originList = null;
                    SPListItem originListItem = null;
                    List<int> laCommenters = new List<int>();
                    List<int> laCommentersRead = new List<int>();
                    currentWeb.AllowUnsafeUpdates = true;
                    originList = currentWeb.Lists[new Guid(dataMgr.GetPropVal("ListId"))];

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

                        string sCommentersRead = originListItem[originList.Fields.GetFieldByInternalName("CommentersRead").Id] != null ? originListItem[originList.Fields.GetFieldByInternalName("CommentersRead").Id].ToString() : string.Empty;
                        foreach (string s in sCommentersRead.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
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
                        StringBuilder sbNewCommenters = new StringBuilder();
                        foreach (int id in laCommenters)
                        {
                            sbNewCommenters.Append(id.ToString() + ",");
                        }

                        string sNewComenters = sbNewCommenters.ToString();
                        if (sNewComenters.IndexOf(',') != -1)
                        {
                            sNewComenters = sNewComenters.Remove(sNewComenters.LastIndexOf(','));
                        }

                        originListItem[originList.Fields.GetFieldByInternalName("Commenters").Id] = sNewComenters;

                        // remove current user id from commentersRead field
                        StringBuilder sbNewCommentersRead = new StringBuilder();
                        foreach (int id in laCommentersRead)
                        {
                            sbNewCommentersRead.Append(id.ToString() + ",");
                        }

                        string sNewComentersRead = sbNewCommentersRead.ToString();
                        if (sNewComentersRead.IndexOf(',') != -1)
                        {
                            sNewComentersRead = sNewComentersRead.Remove(sNewComenters.LastIndexOf(','));
                        }

                        originListItem[originList.Fields.GetFieldByInternalName("CommentersRead").Id] = sNewComentersRead;

                        originListItem.SystemUpdate();
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

        public static void InsertCommentCount(string listId, string itemId)
        {
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
                SPListItem item = targetList.Items.GetItemById(Convert.ToInt32(itemId));

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
                                    SPListItem newItem = newTargetList.Items.GetItemById(Convert.ToInt32(itemId));
                                    newItem[newTargetList.Fields.GetFieldByInternalName("CommentCount").Id] = commentCount;
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
                    item[targetList.Fields.GetFieldByInternalName("CommentCount").Id] = commentCount;
                    item.SystemUpdate();
                }


            }
            else
            {
                throw new Exception("The 'Comments' list needs to be created to support this functionality.");
            }


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

        public static string GetMyCommentsByDate(string data)
        {
            string retVal = string.Empty;
            StringBuilder sbResult = new StringBuilder();
            SPWeb cWeb = SPContext.Current.Web;

            SPListItemCollection userCreatedItems = null;
            List<string[]> notifiedCommentItems = new List<string[]>();
            List<string[]> aggregatedCommentItems = new List<string[]>();
            List<string[]> targetComments = new List<string[]>();
            List<string> saLoadedItems = new List<string>();

            // Data should look like the following:
            // ===============================
            // <Data>
            // <Param key="ItemIds"><listid>.<itemid>,<listid>.<itemid></Param>
            // <Parem key="Created"></Parem>
            // </Data>

            // load data into XML manager
            XmlDataManager dataMgr = new XmlDataManager(data);

            string sItemIds = dataMgr.GetPropVal("ItemIds");
            if (!string.IsNullOrEmpty(sItemIds))
            {
                string[] pairs = sItemIds.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in pairs)
                {
                    string[] vals = s.Split('.');
                    string list = new Guid(vals[0]).ToString();
                    string item = vals[1];
                    if (!ContainsItem(aggregatedCommentItems, new[] { list, item }))
                    {
                        aggregatedCommentItems.Add(new[] { list, item });
                    }
                }
            }

            SPList commentsList = cWeb.Lists.TryGetList(COMMENTS_LIST_NAME);
            SPListItemCollection comments = commentsList.Items;

            if (commentsList != null)
            {
                // Get comments created by current user
                // =================================================
                SPQuery q = new SPQuery();
                //q.Query = "<Where><And>" +
                //              "<Eq><FieldRef Name=\"Author\" LookupId=\"true\" /><Value Type=\"User\">" + cWeb.CurrentUser.ID.ToString() + "</Value></Eq>" +
                //              "<Geq><FieldRef Name=\"Created\" /><Value Type=\"DateTime\"><Today OffsetDays=\"" + dataMgr.GetPropVal("Created") + "\" /></Value></Geq>" +
                //          "</And></Where><OrderBy><FieldRef Name=\"Created\" Ascending=\"False\" /></OrderBy>";

                q.Query = "<Where><Eq><FieldRef Name=\"Author\" LookupId=\"true\" /><Value Type=\"User\">" + cWeb.CurrentUser.ID.ToString() + "</Value></Eq></Where>" +
                          "<OrderBy><FieldRef Name=\"Created\" Ascending=\"False\" /></OrderBy>";

                int numThreads = int.Parse(dataMgr.GetPropVal("NumThreads"));
                userCreatedItems = commentsList.GetItems(q);
                foreach (SPListItem item in userCreatedItems)
                {
                    string sListId = (string)(item["ListId"] ?? string.Empty);
                    string sItemId = (string)(item["ItemId"] ?? string.Empty);
                    string list = new Guid(sListId).ToString();

                    if (!ContainsItem(aggregatedCommentItems, new[] { list, sItemId }))
                    {
                        aggregatedCommentItems.Add(new[] { list, sItemId });
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

                foreach (string[] pair in aggregatedCommentItems)
                {
                    if (saLoadedItems.Count > 0 && saLoadedItems.Contains(pair[0] + '^' + pair[1]))
                    {
                        continue;
                    }
                    else
                    {
                        // return the top x number of threads
                        if (!(totalThreads < numThreads))
                        {
                            break;
                        }
                    }

                    sbResult.Append(XML_RESPONSE_COMMENT_SECTION_HEADER.Replace("##listId##", new Guid(pair[0]).ToString()).Replace("##itemId##", pair[1].ToString()));
                    List<SPListItem> commentsDesc = new List<SPListItem>();
                    Guid listId = new Guid(pair[0]);
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
                                        where new Guid(pair[0]).ToString().Equals(new Guid((string)(i["ListId"] ?? string.Empty)).ToString()) &&
                                            pair[1].Equals((string)(i["ItemId"] ?? string.Empty))
                                        orderby (DateTime)i["Created"] ascending
                                        select i
                                       ).ToList();
                    }
                    catch { }

                    if (realItem != null && commentsDesc.Count > 0)
                    {

                        // display original comment
                        SPListItem originalComment = commentsDesc.OrderBy(x => (DateTime)x["Created"]).FirstOrDefault();
                        string sListId = (string)(originalComment["ListId"] ?? string.Empty);
                        string sItemId = (string)(originalComment["ItemId"] ?? string.Empty);
                        DateTime dCreated = (DateTime)originalComment["Created"];

                        sbResult.Append(XML_RESPONSE_COMMENT_ITEM.Replace("##listId##", new Guid(sListId).ToString())
                                                                 .Replace("##listName##", realItem.ParentList.Title)
                                                                 .Replace("##itemId##", sItemId.ToString())
                                                                 .Replace("##itemTitle##", realItem.Title)
                                                                 .Replace("##createdDate##", dCreated.ToFriendlyDateAndTime())
                                                                 .Replace("##comment##", (string)(originalComment["Comment"] ?? string.Empty)));

                        // get user object 
                        SPFieldUser author = (SPFieldUser)originalComment.Fields[SPBuiltInFieldId.Author];
                        SPFieldUserValue user = (SPFieldUserValue)author.GetFieldValue(originalComment[SPBuiltInFieldId.Author].ToString());
                        SPUser userObject = user.User;

                        //get user picture from user id
                        SPList userInfoList = SPContext.Current.Web.SiteUserInfoList;
                        SPListItem userItem = userInfoList.GetItemById(userObject.ID);
                        string userPictureUrl = SPContext.Current.Site.MakeFullUrl(SPContext.Current.Web.ServerRelativeUrl) + "/_layouts/epmlive/images/O14_person_placeHolder_32.png";

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
                                userPictureUrl = SPContext.Current.Site.MakeFullUrl(SPContext.Current.Web.ServerRelativeUrl) + "/_layouts/epmlive/images/O14_person_placeHolder_32.png";
                            }
                        }

                        sbResult.Append(XML_USER_INFO_SECTION.Replace("##username##", userObject.Name)
                                                             .Replace("##useremail##", userObject.Email)
                                                             .Replace("##userprofile##", _userProfileUrl.Replace("##userid##", userObject.ID.ToString()))
                                                             .Replace("##userpic##", userPictureUrl));

                        sbResult.Append(XML_RESPONSE_COMMENT_ITEM_CLOSE);
                        
                        for (int i = 0; i < commentsDesc.Count; i++)
                        {
                            SPListItem comment = commentsDesc[i];
                            if (comment.ID != originalComment.ID)
                            {
                                string sListId2 = (string)(comment["ListId"] ?? string.Empty);
                                string sItemId2 = (string)(comment["ItemId"] ?? string.Empty);
                                DateTime dCreated2 = (DateTime)comment["Created"];
                                
                                // get user object 
                                author = (SPFieldUser)comment.Fields[SPBuiltInFieldId.Author];
                                user = (SPFieldUserValue)author.GetFieldValue(comment[SPBuiltInFieldId.Author].ToString());
                                userObject = user.User;

                                //get user picture from user id
                                userInfoList = SPContext.Current.Web.SiteUserInfoList;
                                userItem = userInfoList.GetItemById(userObject.ID);
                                userPictureUrl = SPContext.Current.Site.MakeFullUrl(SPContext.Current.Web.ServerRelativeUrl) + "/_layouts/epmlive/images/O14_person_placeHolder_32.png";
                                
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
                                        userPictureUrl = SPContext.Current.Site.MakeFullUrl(SPContext.Current.Web.ServerRelativeUrl) + "/_layouts/epmlive/images/O14_person_placeHolder_32.png";
                                    }
                                }

                                // 1. display first item ordered by asending date
                                // 2. display rest ordered by desending date
                                // 3. do not repeat items 
                                sbResult.Append(XML_RESPONSE_COMMENT_ITEM.Replace("##listId##", new Guid(sListId2).ToString())
                                                                         .Replace("##listName##", realItem.ParentList.Title)
                                                                         .Replace("##itemId##", sItemId2.ToString())
                                                                         .Replace("##itemTitle##", realItem.Title)
                                                                         .Replace("##createdDate##", dCreated2.ToFriendlyDateAndTime())
                                                                         .Replace("##comment##", (string)(comment["Comment"] ?? string.Empty)));
                                                                     
                                sbResult.Append(XML_USER_INFO_SECTION.Replace("##username##", userObject.Name)
                                                                     .Replace("##useremail##", userObject.Email)
                                                                     .Replace("##userprofile##", _userProfileUrl.Replace("##userid##", userObject.ID.ToString()))
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
    }
}
