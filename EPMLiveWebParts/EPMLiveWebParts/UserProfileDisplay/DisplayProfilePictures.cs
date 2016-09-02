using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Web.UI;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using Microsoft.SharePoint;
using System.Threading;
using Microsoft.SharePoint.WebPartPages;

namespace EPMLiveWebParts
{
    /// <summary> 
    /// This web part evaluates all user profiles and displays all those that have 
    /// set a user picture.
    /// </summary>
    /// <remarks>
    /// You must add references to the Microsoft.Office.Server and
    /// Microsoft.Office.Server.UserProfiles dlls in the 14 hive ISAPI directory. 
    /// You must have a User Profile service application in place.
    /// Also the code below only works in the context of an account that has the
    /// "manage user profiles" right. If you don't have that right you could get
    /// similar results by using the Search API and the People search scope.
    /// </remarks>
    [ToolboxData("<{0}:DisplayProfilePictures runat=server></{0}:DisplayProfilePictures>")]
    [Guid("A34230FD-6104-435E-A504-137C78D6926A")]
    [XmlRoot(Namespace = "MyDisplayProfilePictures")]
    public class DisplayProfilePictures : WebPart
    {
        private const string DefaultProfilePicturePath = "_layouts/epmlive/images/defaultprofilepic.png";

        [Category("Profile View Properties")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Profile Picture Size")]
        [Description("Set the size of a user's profile image.")]
        [Browsable(false)]
        public bool LargeImage { get; set; }

        protected override void Render(HtmlTextWriter writer)
        {
            EPMLiveCore.Act act = new EPMLiveCore.Act(SPContext.Current.Web);
            int activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.WebParts);

            if(activation != 0)
            {
                writer.Write(act.translateStatus(activation));
                return;
            }

            UpdateContextSoWeCanGetDataFromSiteUserInfoList();

            var currentUser = SPContext.Current.Web.CurrentUser;
            var loginName = SPContext.Current.Web.CurrentUser.LoginName;
            var profilePicturePath = "";

            WriteStylesToOutput(writer);

            if (currentUser != null)
            {
                currentUser = GetProfileUser(SPContext.Current.Site, SPContext.Current.Web.CurrentUser.LoginName, true, currentUser);
                var spListItem = SPContext.Current.Web.Site.RootWeb.SiteUserInfoList.GetItemById(currentUser.ID);
                profilePicturePath = GetProfilePicturePath(spListItem);
                loginName = spListItem.DisplayName;
            }

            //NOTE: This will automatically redirect to the users profile page if they are on server and not foundation.
            var userDisplayUrl = SPContext.Current.Web.Url + "/_layouts/userdisp.aspx";

            WriteJavascriptToOutput(writer);

            var userProfileManagementClass = GetUserProfileManagerClass();
            var isSharepointServer = userProfileManagementClass != null ? true : false;
            
            var hasMySite = HasMySite(userProfileManagementClass);

            if (!LargeImage)
            {
                WriteSmallImageHtmlToOutput(writer, loginName, profilePicturePath, userDisplayUrl, isSharepointServer, hasMySite);
            }
            else
            {
                WriteLargeImageHtmlToOutput(writer, profilePicturePath, loginName, currentUser, userDisplayUrl, isSharepointServer, hasMySite);
            }
        }

        private void WriteJavascriptToOutput(HtmlTextWriter writer)
        {
            var javascript = @"
                                <script type=""text/javascript"">                                
                                    $(function() {
                                        $(""#imgDiv"").hover(
                                            function() { $("".editIcon"").show(); },
                                            function() { $("".editIcon"").hide(); }
                                        );
                                        $(""#imgDivLarge"").hover(
                                            function() { $("".editIconLarge"").show(); },
                                            function() { $("".editIconLarge"").hide(); }
                                        );
                                    });
                                
                                    function openUploadProfilePicDialog(){
                                        var options = SP.UI.$create_DialogOptions();    
                                        options.url = L_Menu_BaseUrl + ""/_layouts/epmlive/UploadProfilePicture.aspx"";
                                        options.dialogReturnValueCallback = Function.createDelegate(null, modalDialogClosedCallback);
    
                                        SP.UI.ModalDialog.showModalDialog(options);                                    
                                    }

                                    function modalDialogClosedCallback(result, value) {
                                        if (result == SP.UI.DialogResult.OK) {
                                            $('#ProfileImage').attr(""src"", value +'?'+Math.random());
                                        }
                                    }
                                </script>
                              ";

            writer.Write(javascript);
        }

        public override ToolPart[] GetToolParts()
        {
            var toolparts = new ToolPart[2];

            toolparts[0] = new WebPartToolPart();
            toolparts[1] = new UserProfileToolPart();

            return toolparts;
        }

        private static void UpdateContextSoWeCanGetDataFromSiteUserInfoList()
        {
            //NOTE: RHS - I haven't dug deep enough to see why this is, but this needs to be called in order for the context to be updated and the SiteUserInfoList to be hydrated properly.
            SPServiceContext.GetContext(SPContext.Current.Site);
        }

        private string GetCurrentDate()
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture;
            var currentDate = DateTime.Now.ToString(currentCulture.DateTimeFormat.LongDatePattern, currentCulture);
            return currentDate;
        }

        private void WriteStylesToOutput(HtmlTextWriter writer)
        {
            var style = @"
            <style>
                .ms-profilepicture {
                    text-align: center;
                    word-wrap: normal;
                }
            
                .ms-profilepicture img {
                    background-color: #FFFFFF;
                    border: 1px solid #C5C7C9;
                    height: auto;
                    padding: 2px;
                    vertical-align: top;
                }
            
                .ms-contactcardpicture {
                    margin-bottom: 0px;
                    margin-right: 0px;
                    margin-top: 0px;
                }
            
                .ms-largethumbnailimage {
                    line-height: 128px;
                    width: 148px;
                }
            
                .ms-smallthumbnailimage {
                    line-height: 100px;
                    width: 110px;
                }
            
                .ms-largethumbnailimage img {
                    max-width: 148px;
                }
            
                .ms-smallthumbnailimage img {
                    max-width: 130px;
                }
            
                .ms-name {
                    font-size: 1.8em;
                }
            
                .ms-contactcardtext1 {
                    color: #0072BC;
                    font-family: verdana;
                }
            
                .ms-contactcardtext3 {
                    font-family: verdana;
                }
            
                .ms-hidden, a.ms-skip, a.ms-skip:hover, a.ms-skip:visited, a.ms-TurnOnAcc, a.ms-SkiptoMainContent, a.ms-SkiptoNavigation {
                    height: 1px;
                    overflow: hidden;
                    position: absolute;
                    top: -2000px;
                    width: 1px;
                    word-wrap: normal;
                    z-index: 3;
                }

                .editIcon
                {
                    margin-top:-30px;
                    margin-left:76px;
                    display:none;
                    position:absolute;
                }

                .editIcon:hover
                {
                    cursor:pointer;
                }

                .editIconLarge
                {
                    margin-top:-30px;
                    margin-left:120px;
                    display:none;
                    position:absolute;
                }

                .editIconLarge:hover
                {
                    cursor:pointer;
                }

                .imgDiv
                {
                    width:93px;
                }

                .imgDivLarge
                {
                    width:144px;
                }
            </style>";

            writer.Write(style);
        }

        private void WriteSmallImageHtmlToOutput(HtmlTextWriter writer, string loginName, string profilePicturePath, string personalUrl, bool isSharepointServer, bool hasMySite)
        {
            var uri = new Uri(System.Web.HttpContext.Current.Request.Url.ToString());
            var pathWithoutQueryString = uri.GetLeftPart(UriPartial.Path);

            personalUrl = string.Format("{0}?Source={1}", personalUrl, pathWithoutQueryString);
            
            writer.Write("<table bordor=\"0\" style=\"PADDING-LEFT: 0px\">");
            writer.Write("<tr>");
            writer.Write("<td  valign=\"top\">");
            writer.Write("<div id=\"imgDiv\">");
            writer.Write("<div class=\"ms-profilepicture ms-contactcardpicture ms-smallthumbnailimage\">");
            if (!isSharepointServer || hasMySite)
            {
                writer.WriteLine("<a href=\"" + personalUrl + "\"" + ">");
            }
            writer.Write("<img id=\"ProfileImage\" src=\"" + profilePicturePath + "\" width=\"93\" height=\"96\" onerror=\"this.src='_layouts/epmlive/images/DisplayProfilePicture/DefaultProfilePic.png';\"></img>");
            if (!isSharepointServer || hasMySite)
            {
                writer.WriteLine("</a>");
            }
            writer.Write("</div>");
            if (!isSharepointServer)
            {
                writer.Write("<div class=\"editIcon\" onclick=\"openUploadProfilePicDialog();\"><img src=\"_layouts/epmlive/images/DisplayProfilePicture/edit.png\" rel=\"tooltipbottom\" title=\"Change Profile Picture\" /></div>");
            }
            writer.Write("</div>");
            writer.Write("</td >");
            writer.Write("<td  valign=\"top\">");
            writer.WriteLine("<br />");
            writer.WriteLine("<br />");
            writer.Write("<div style=\"padding-top: 0px;vertical-align:top;\" class=\"ms-name ms-contactcardtext1\">");
            if (!isSharepointServer || hasMySite)
            {
                writer.WriteLine("<a href=\"" + personalUrl + "\"" + ">");
            }
            writer.WriteLine("<span style=\"vertical-align:top; padding: 0px 0px;\">" + loginName + "</span>");
            writer.WriteLine("<br />");
            if (!isSharepointServer || hasMySite)
            {
                writer.WriteLine("</a>");
            }
            writer.WriteLine("</div>");
            writer.Write("<label>" + GetCurrentDate() + "</label>");
            writer.Write("</td>");
            writer.Write("</tr>");
            writer.Write("</table>");
        }

        private void WriteLargeImageHtmlToOutput(HtmlTextWriter writer, string profilePicturePath, string loginName, SPUser currentUser, string personalUrl, bool isSharepointServer, bool hasMySite)
        {
            var uri = new Uri(System.Web.HttpContext.Current.Request.Url.ToString());
            var pathWithoutQueryString = uri.GetLeftPart(UriPartial.Path);

            personalUrl = string.Format("{0}?Source={1}", personalUrl, pathWithoutQueryString);
            
            writer.Write("<table>");
            writer.Write("<tr>");
            writer.Write("<td>");
            writer.Write("<div id=\"imgDivLarge\">");
            writer.Write("<div class=\"ms-profilepicture ms-contactcardpicture ms-largethumbnailimage\">");
            if (!isSharepointServer || hasMySite)
            {
                writer.WriteLine("<a href=\"" + personalUrl + "\"" + ">");
            }
            writer.Write("<img id=\"ProfileImage\" src=\"" + profilePicturePath + "\" width=\"144\" height=\"144\" onerror=\"this.src='_layouts/epmlive/images/DisplayProfilePicture/DefaultProfilePic.png';\"></img>");
            if (!isSharepointServer || hasMySite)
            {
                writer.WriteLine("</a>");
            }
            writer.Write("</div>");
            if (!isSharepointServer)
            {
                writer.Write("<div class=\"editIconLarge\" onclick=\"openUploadProfilePicDialog();\"><img src=\"_layouts/epmlive/images/DisplayProfilePicture/edit.png\" rel=\"tooltipbottom\" title=\"Change Profile Picture\" /></div>");
            }
            writer.Write("</div>");
            if (!isSharepointServer || hasMySite)
            {
                writer.WriteLine("<a href=\"" + personalUrl + "\"" + ">");
            }
            writer.Write("<div style=\"padding-top: 0px;vertical-align:top;\" class=\"ms-name ms-contactcardtext1\">" + loginName + "</div>");
            if (!isSharepointServer || hasMySite)
            {
                writer.WriteLine("</a>");
            }
            writer.WriteLine("<div class=\"ms-contactcardtext3\" style=\"width:100%;\">");
            writer.WriteLine("<div></div>");
            writer.WriteLine("</div>");
            writer.Write("</td>");
            writer.Write("</tr>");
            writer.Write("</table>");
        }

        private string GetProfilePicturePath(SPListItem spListItem)
        {
            var profilePicturePath = spListItem["Picture"] as string;

            if (!string.IsNullOrEmpty(profilePicturePath))
            {
                if (profilePicturePath.Split(',').Length > 1)
                {
                    profilePicturePath = profilePicturePath.Split(',')[0];
                }
            }
            else
            {
                profilePicturePath = DefaultProfilePicturePath;
            }
            return profilePicturePath;
        }

        private SPUser GetProfileUser(SPSite site, string loginName, bool revertSystemAccount, SPUser user)
        {
            var ensuredUser = user;
            if (IsSharePointSystemAccount(loginName) && revertSystemAccount)
            {
                var originalAllowUnsafeUpdatesFlag = site.RootWeb.AllowUnsafeUpdates;
                site.RootWeb.AllowUnsafeUpdates = true;
                
                loginName = site.WebApplication.ApplicationPool.Username;
                ensuredUser = site.RootWeb.EnsureUser(loginName);

                site.RootWeb.AllowUnsafeUpdates = originalAllowUnsafeUpdatesFlag;
            }

            return ensuredUser;
        }

        private bool IsSharePointSystemAccount(string loginName)
        {
            return (loginName.ToLower() == @"sharepoint\system");
        }

        private Type GetUserProfileManagerClass()
        {
            Assembly userProfileAssembly;

            var windowsFolderPath = Environment.GetEnvironmentVariable("windir");
            var pathToServerAssembly = string.Format(@"{0}\assembly\GAC_MSIL\Microsoft.Office.Server.UserProfiles\14.0.0.0__71e9bce111e9429c\Microsoft.Office.Server.UserProfiles.dll", windowsFolderPath);

            try
            {
                userProfileAssembly = Assembly.LoadFrom(pathToServerAssembly);
            }
            catch (FileNotFoundException)
            {
                // Assembly wasn't found, so eject.
                return null;
            }

            var userProfileManagerClass = userProfileAssembly.GetType("Microsoft.Office.Server.UserProfiles.UserProfileManager");
            if (userProfileManagerClass == null)
            {
                return null;
            }

            return userProfileManagerClass;
        }

        private bool HasMySite(Type userProfileManagerClass)
        {
            try
            {
                var instantiatedUserProfileManagerClass = Activator.CreateInstance(userProfileManagerClass);
                var property = instantiatedUserProfileManagerClass.GetType().GetProperty("MySiteHostUrl");
                if(property == null)
                {
                    return false;
                }

                var myhostUrl = property.GetValue(instantiatedUserProfileManagerClass, null);
                if(myhostUrl == null)
                {
                    return false;
                }

                if(myhostUrl.ToString() == "")
                {
                    return false;
                }

                return true;
            }
            catch { return false; }
        }
    }
}
