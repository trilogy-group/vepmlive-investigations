using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        private static void GetCommentsCreatedByCurrentUser(SPWeb web, SPList commentsList, List<string[]> aggregatedCommentItems, List<string> loadedItems, SPListItemCollection comments, List<SPListItem> allCommentsCol)
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

        private static void ProcessComments(List<string[]> aggregatedCommentItems, List<string> loadedItems, int numThreads, SPWeb web, SPListItemCollection comments, StringBuilder loadedIds, StringBuilder result)
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

        private static void AppendUserDetails(StringBuilder result, SPUser user, string userPictureUrl)
        {
            result.Append(XML_USER_INFO_SECTION
                .Replace("##username##", user.Name)
                .Replace("##useremail##", user.Email)
                .Replace("##userprofile##", _userProfileUrl.Replace("##userid##", user.ID.ToString()))
                .Replace("##userpic##", userPictureUrl));
            result.Append(XML_RESPONSE_COMMENT_ITEM_CLOSE);
        }

        private static void AppendCommenters(List<SPListItem> commentsDesc, SPListItem originalComment, SPListItem userItem, SPListItem realItem, SPWeb web, string pictureUrl, StringBuilder result)
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

        private static void AppendCommenterDetails(SPListItem comment, SPListItem userItem, SPListItem realItem, SPUser userObject, SPWeb web, string pictureUrl, StringBuilder result)
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
    }
}
