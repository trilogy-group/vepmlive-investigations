﻿using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Text;
using System.Xml.Serialization;
using Microsoft.SharePoint.WebPartPages;

namespace EPMLiveWebParts.Comments
{
    [ToolboxData("<{0}:CommentsWebpart runat=server></{0}:CommentsWebpart>")]
    [Guid("8F23B921-B5DC-4531-9527-549FED46C452")]
    [XmlRoot(Namespace = "Comments")]
    public class Comments : Microsoft.SharePoint.WebPartPages.WebPart
    {
        #region constant strings

        const string _loadingHtml = "<div id=\"divLoader_CommentsWebPart\" class=\"commentLoader\"></div>";

        const string _publicCommentsloadingHtml = "<div id=\"divLoaderPublic_CommentsWebPart\" style=\"display:none\" class=\"commentLoader\"></div>";
        
        const string _noCommentHtml = "<div id=\"divNoCommentIndicator\" style=\"width: 100%; text-align: center;display:none\">" +
                                        "<span id=\"spanMainLoading\">You have no comments.</span>" +
                                       "</div>";

        const string _webpartHtml = "<div class=\"COuterContainer\">" +
                                        "<div class=\"CItemContainer\">" +
                                            "<div class=\"CItemPicture\"></div>" +
                                            "<div class=\"CItemInfoContainer\">" +
                                                "<div class=\"CItemUserName\">" +
                                                    "##UserName##" +
                                                "</div>" +
                                                "<div class=\"CClearDiv\"></div>" +
                                                "<div class=\"CItemComment\">" +
                                                    "##ItemComment##" +
                                                "</div>" +
                                                "<div class=\"CClearDiv\"></div>" +
                                                "<div class=\"CItemOptions\">" +
                                                    "##ItemOptions##" +
                                                "</div>" +
                                            "</div>" +
                                        "</div>" +
                                        "<div class=\"CClearDiv\"></div>" +
                                        "<div class=\"CShowAllItems\"></div>" +
                                        "<div class=\"CClearDiv\"></div>" +
                                      "</div>" +
                                      "<div class=\"CClearDiv\">" +
                                      "</div>";

        const string _subitemHtml = "<div class=\"CSubItemContainer\">" +
                                        "<div class=\"CSubItemPicture\"></div>" +
                                        "<div class=\"CSubItemInfoContainer\">" +
                                            "<div class=\"CSubItemUserName\">" +
                                                "##UserName##" +
                                            "</div>" +
                                            "<div class=\"CClearDiv\"></div>" +
                                            "<div class=\"CSubItemComment\">" +
                                                "##ItemComment##" +
                                            "</div>" +
                                            "<div class=\"CClearDiv\"></div>" +
                                            "<div class=\"CSubItemOptions\">" +
                                                "##ItemOptions##" +
                                            "</div>" +
                                        "</div>" +
                                    "</div>";

        #endregion

        #region webpart properties

        private int _numThreads;
        private int _maxComments;

        [Category("Comments Properties")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Number Of Threads")]
        [Description("Default number of threads to display.")]
        [Browsable(false)]
        public int NumThreads
        {
            get
            {
                return _numThreads;
            }
            set
            {
                _numThreads = value;
            }
        }

        [Category("Comments Properties")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Number Of Comments")]
        [Description("Default number of comments per thread.")]
        [Browsable(false)]
        public int MaxComments
        {
            get
            {
                return _maxComments;
            }
            set
            {
                _maxComments = value;
            }
        }

        #endregion

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            
            ScriptLink.Register(Page, "/epmlive/javascripts/libraries/jquery.min.js", false);
            //ScriptLink.Register(Page, "/epmlive/slimScroll.js", false);
            //ScriptLink.Register(Page, "/epmlive/TextBoxAutoGrow.js", false);
            ScriptLink.Register(Page, "/epmlive/CommentsWebPart.js", false);
        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            EPMLiveCore.Act act = new EPMLiveCore.Act(SPContext.Current.Web);
            int activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.WebParts);

            if(activation != 0)
            {
                output.Write(act.translateStatus(activation));
                return;
            }

            SPWeb cWeb = SPContext.Current.Web;
            SPSite cSite = SPContext.Current.Site;
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"" + (cWeb.ServerRelativeUrl == "/" ? "" : cWeb.ServerRelativeUrl) + "/_layouts/epmlive/Comments.UI.css\"/>");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"" + (cWeb.ServerRelativeUrl == "/" ? "" : cWeb.ServerRelativeUrl) + "/_layouts/epmlive/CommentsWebPartStyle.css\"/>");

            output.Write("<div id=\"commentsWebPartMainContainer\" class=\"commentsWPMainContainer\">");
            output.Write("<div style=\"clear:both;\"></div>");
            //TODO: add the div here and include the button
            output.Write("<div class=\"divPublicCommentContainer\">");
            output.Write("<div class=\"inputSearch tbComment epmliveinput\" style=\"width: 95%;background:white;\" id=\"inputPublicComment\" class=\"ms-socialCommentInputBox ms-rtestate-write tbCommentInput\" contenteditable=\"true\" disableribboncommands=\"True\">");
            output.Write("<span style=\"color:gray\">Replaceble text...</span>");
            output.Write("</div>");
            output.Write("<div style=\"clear:both;\"></div>");
            output.Write("<input id=\"btnGeneralPost\" class=\"epmliveButton\" type=\"button\" value=\"post\" />");
            output.Write("</div>");

            output.Write("<div style=\"clear:both;\"></div>");

            output.Write("<div class=\"divGeneralComment\">");
            //output.Write(_publicCommentsloadingHtml);
            output.Write("</div>");

            output.Write(_loadingHtml);
            output.Write("<div style=\"clear:both;height:5px\"></div>");
            output.Write(_noCommentHtml);
            output.Write("</div>");

            SPUser user = cWeb.CurrentUser;
            //get user picture from user id
            SPList userInfoList = cWeb.SiteUserInfoList;
            SPListItem userItem = userInfoList.GetItemById(user.ID);
            string userPictureUrl = cSite.MakeFullUrl(cWeb.ServerRelativeUrl) + "/_layouts/epmlive/images/O14_person_placeHolder_32.png";

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
                    userPictureUrl = cSite.MakeFullUrl(cSite.ServerRelativeUrl) + "/_layouts/epmlive/images/O14_person_placeHolder_32.png";
                }
            }
            string userProfileUrl = cSite.MakeFullUrl(cWeb.ServerRelativeUrl) + "/_layouts/userdisp.aspx?Force=True&ID=" + user.ID + "&source=" + HttpContext.Current.Request.UrlReferrer;
            
            output.Write("<script>" +
                           "curWebUrl = '" + cWeb.Url + "';" +
                           "userProfileUrl = '" + userProfileUrl + "';" +
                           "userEmail = '" + user.Email + "';" +
                           "userPicUrl = '" + userPictureUrl + "';" +
                           "userName = '" + user.Name + "';" +
                           "numThreads = '" + this.NumThreads.ToString() + "';" +
                           "maxComments = '" + this.MaxComments.ToString() + "';" +
                         "</script>");
        }

        public override ToolPart[] GetToolParts()
        {
            ToolPart[] toolparts = new ToolPart[3];

            toolparts[0] = new WebPartToolPart();
            toolparts[1] = new CommentsToolPart();
            toolparts[2] = new CustomPropertyToolPart();

            return toolparts;
        }
    }
}
