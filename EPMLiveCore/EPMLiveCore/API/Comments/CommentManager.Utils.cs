using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    internal partial class CommentManager
    {
        private static SPUser GetUserObject(SPListItem comment)
        {
            var author = (SPFieldUser)comment.Fields[SPBuiltInFieldId.Author];
            var user = (SPFieldUserValue)author.GetFieldValue(comment[SPBuiltInFieldId.Author].ToString());
            return user.User;
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

        private static bool ContainsItem(List<string[]> items, string[] item)
        {
            foreach (string[] pair in items)
            {
                string baseList = new Guid(pair[0]).ToString();
                string newList = new Guid(item[0]).ToString();
                if (baseList.Equals(newList) && pair[1].Equals(item[1]))
                {
                    return true;
                }
            }
            return false;
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
    }
}
