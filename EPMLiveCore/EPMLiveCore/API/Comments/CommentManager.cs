using System;
using System.Collections;
using System.Web;
using EPMLiveCore.SocialEngine;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    internal partial class CommentManager
    {
        private static string _userProfileUrl =
            $"{SPContext.Current.Site.MakeFullUrl(SPContext.Current.Web.ServerRelativeUrl)}/_layouts/userdisp.aspx?Force=True&ID=##userid##&source={HttpContext.Current.Request.UrlReferrer}";

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

        private static DateTime GetCurrentLocalTime()
        {
            var regionalSettings = SPContext.Current.RegionalSettings;
            return regionalSettings.TimeZone.UTCToLocalTime(DateTime.UtcNow);
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
                        SPSecurity.RunWithElevatedPrivileges(delegate ()
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
                    SPSecurity.RunWithElevatedPrivileges(delegate ()
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
