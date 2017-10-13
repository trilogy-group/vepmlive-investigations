<%@ Assembly Name="Microsoft.SharePoint.IdentityModel, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Assembly Name="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" Inherits="Microsoft.SharePoint.IdentityModel.Pages.FormsSignInPage" MasterPageFile="uplandlogin.master" %>

<%@ Import Namespace="Microsoft.SharePoint.WebControls" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<asp:Content ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    <SharePoint:EncodedLiteral runat="server" EncodeMethod="HtmlEncode" ID="ClaimsFormsPageTitleInTitleArea" />
</asp:Content>
<asp:Content ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    EPM Live - Log In
    <SharePoint:EncodedLiteral runat="server" EncodeMethod="HtmlEncode" ID="ClaimsFormsPageTitle" />
</asp:Content>
<asp:Content ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    
    <link rel="stylesheet" type="text/css" href="flat-ui.css" />
    
</asp:Content>
<asp:Content ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <WebPartPages:AllowFraming runat="server" />
    <div id="SslWarning" style="color: red; display: none">
        <SharePoint:EncodedLiteral runat="server" EncodeMethod="HtmlEncode" ID="ClaimsFormsPageMessage" />
    </div>
    
    <div class="mainLogin" id="divLogin" runat="server">

        <asp:Login ID="signInControl" FailureText="<%$Resources:wss,login_pageFailureText%>" runat="server" Width="100%">
            <LayoutTemplate>
                <asp:Label ID="FailureText" class="ms-error" runat="server" />
                <div id="login-wrapper">
                    <div id="login-main">
                        <div>
                            <img alt="Logo" id="login-logo" src="Logo.png">
                        </div>
                        <div id="login-content">
                            <div class="username-img input-img">
                                <span class="fui-ext-user"></span>
                            </div>
                            <asp:TextBox ID="UserName" autocomplete="off" runat="server" class="ms-inputuserfield" placeholder="Username" title="Username" Style="margin-top: 15px;" />
                            <br>
                            <div class="password-img input-img">
                                <span class="fui-lock"></span>
                            </div>
                            <input type="hidden" name="ctl00$PlaceHolderMain$signInControl$login" value="Sign in" />
                            <asp:TextBox ID="password" TextMode="Password" autocomplete="off" runat="server" class="" placeholder="Password" title="Password" Style="margin-top: 10px;" />
                            <asp:Button ID="login" CommandName="Login" Text="<%$Resources:wss,login_pagetitle%>" runat="server" class="login-button" OnClientClick="javascript: return DisableButton(this);" />
                            <asp:CheckBox ID="RememberMe" Text="<%$SPHtmlEncodedResources:wss,login_pageRememberMe%>" runat="server" />
                        </div>
                        <div id="footer-content">
                            <div>
                                <span style="font-size: .8em;"><a href="resetpassword.aspx">Help!&nbsp;&nbsp;I forgot my username or password.</a></span>
                            </div>
                            <div style="padding-top: 13px; font-size: .7em;">
                                <span><a target="_blank" href="http://support.epmlive.com">Support</a></span>&nbsp;|&nbsp;<span><a href="https://epmlive.ideas.aha.io/" target="_blank">Feedback</a></span>&nbsp;|&nbsp;<span><a target="_blank" href="http://epmlive.com/epm-live-service-agreement">Legal</a></span>&nbsp;|&nbsp;<span><a target="_blank" href="http://epmlive.com/privacy-policy81/">Privacy Policy</a></span>
                            </div>
                        </div>
                    </div>
                    <div id="login-ad-main">
                        <div id="login-ad-content">
                            <div id="login-ad-bg">
                                <div style="color: #ffffff; font-size: 25px; text-align: center; padding-top: 20px; line-height: 35px;">
                                    Visit the new EPM Live Community<br>
                                    for EPM Live
                                </div>
                                <a href="http://epmliveuniversity.com" target="_blank" style="text-decoration: none;">
                                    <div class="call-to-action-button">
                                        <span style="word-spacing: 3px;">Visit the Community</span>
                                    </div>
                                </a>
                                <div class="support-links-wrapper">
                                    <ul>
                                        <li>
                                            <a href="https://community.uplandsoftware.com/hc/en-us/community/topics" target="_blank" style="text-decoration: none;" />
                                            <img alt="Forums" src="./img/forums2-final.png" />
                                            <span>Forums</span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="https://community.uplandsoftware.com/hc/en-us/categories/200348089" target="_blank" style="text-decoration: none;" />
                                            <img alt="Knowledgebase" src="./img/KB-final.png" />
                                            <span>Knowledge<br>
                                                Base</span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="https://community.uplandsoftware.com/hc/en-us/categories/200290999" target="_blank" style="text-decoration: none;" />
                                            <img alt="video" src="./img/video-final.png" />
                                            <span>Videos</span>
                                            </a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </LayoutTemplate>
        </asp:Login>
    </div>
    <div class="mainLogin" id="divSSO" runat="server" visible="false">
        <asp:Literal ID="litSSO" runat="server"></asp:Literal>
        <div>
            Initializing SSO
        </div>

    </div>
    <script type="text/javascript">
        var clickedit = false;
        if (document.location.protocol != 'https:') {
            var SslWarning = document.getElementById('SslWarning');
            SslWarning.style.display = '';
        }
        function DisableButton(btn) {
            if (!clickedit) {
                clickedit = true;

                btn.className = "login-buttond";
                btn.value = "Signing In...";

                return true;

            }
            return false;
        }
    </script>
    <script type="text/javascript" src="jquery.soap.js"></script>
    <script type="text/javascript" src="login.js"></script>
    <script type="text/jscript" src="placeholder.js"></script>
</asp:Content>
