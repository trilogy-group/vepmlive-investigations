namespace EPMLiveCore.API
{
    internal partial class CommentManager
    {
        private const string COMMENTS_LIST_NAME = "Comments";
        private const string XML_RESPONSE_COMMENT_HEADER = "<Comments>";
        private const string XML_RESPONSE_COMMENT_LOADEDIDS = "<LoadedIds>##loadedids##</LoadedIds>";
        private const string XML_RESPONSE_COMMENT_SECTION_HEADER = "<CommentItem listId=\"##listId##\" itemId=\"##itemId##\">";
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
        private const string XML_USER_INFO_SECTION = "<UserInfo>" +
                                                "<UserName><![CDATA[##username##]]></UserName>" +
                                                "<UserProfileUrl><![CDATA[##userprofile##]]></UserProfileUrl>" +
                                                "<UserPic><![CDATA[##userpic##]]></UserPic>" +
                                                "<UserEmail><![CDATA[##useremail##]]></UserEmail>" +
                                                "</UserInfo>";
        private const string XML_RESPONSE_COMMENT_ITEM_CLOSE = "</Comment>";
        private const string XML_RESPONSE_COMMENT_SECTION_FOOTER = "</CommentItem>";
        private const string XML_RESPONSE_COMMENT_FOOTER = "</Comments>";
        private const string XML_RESPONSE_PUBLIC_COMMENT_ITEM = "<PublicCommentItem listId=\"##pubComListId##\" itemId=\"##pubComItemId##\" />";
    }
}
